﻿using Dapper;
using InterviewExercise.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace InterviewExercise.Core.Repositories
{
    public interface IMemberRepository
    {
        Member GetMember(string memberId);
    }

    public class MemberRepository : IMemberRepository
    {
        private string sqlConnection;
        public MemberRepository(string sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public Member GetMember(string memberId)
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                var member = connection.QueryFirst<Member>(
                    "select * from Member where member_id = {=Id}",
                    new { Id = int.Parse(memberId) });

                return member;
            }
        }
    }
}