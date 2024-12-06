package com.example.orm.repository

import com.example.orm.entity.User
import org.springframework.data.jpa.repository.JpaRepository
import org.springframework.stereotype.Repository

@Repository
interface UserRepository : JpaRepository<User, Long> {
    fun findByUsername(username: String): List<User>
}


/*
@Repository("userCustomRepositoryImpl")
class UserCustomRepositoryImpl(
    @PersistenceContext private val entityManager: EntityManager
) : UserCustomRepository {
    override fun unsafeFindUsersByName(name: String): List<User> {
        val query = "SELECT u FROM User u WHERE u.name = '$name'"
        return entityManager.createQuery(query, User::class.java).resultList
    }
}
*/
