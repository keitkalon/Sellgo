import React, { useEffect } from 'react'
//import { useSelector, useDispatch } from 'react-redux'
import { connect } from 'react-redux'
import { fetchUsers } from '../../redux/Users/UserActions'

function UsersContainer ({ userData, fetchUsers }) {
    useEffect(() => {
      fetchUsers()
    }, [])
    return userData.loading ? (
      <h2>Loading</h2>
    ) : userData.error ? (
      <h2>{userData.error}</h2>
    ) : (
      <div>
        <h2>Users List</h2>
        <div>
          {
            userData.users.map((user, index) => <p key={index}>{user.firstName} {user.lastName}</p>)
          }
        </div>
      </div>
    )
  }
  
  const mapStateToProps = state => {
    return {
      userData: state.userRedux
    }
  }
  
  const mapDispatchToProps = dispatch => {
    return {
      fetchUsers: () => dispatch(fetchUsers())
    }
  }
  
  export default connect(
    mapStateToProps,
    mapDispatchToProps
  )(UsersContainer)


