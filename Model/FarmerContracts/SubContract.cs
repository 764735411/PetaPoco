using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetaPocoWebApi.Model.FarmerContracts
{
    /// <summary>
    /// 子合同
    /// </summary>
    [TableName("YYSG_JSZ_LB")]
    [PrimaryKey("JSZ_LB_ID", AutoIncrement = false)]
    public class SubContract
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("JSZ_LB_ID")]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("JSZ_ID")]
        public Guid ContractId { get; set; }

        [Column("DW_BM")]
        public string DepCode { get; set; }

        [Column("ND_MC")]
        public int Year { get; set; }

        [Column("JSSL")]
        public decimal Amount { get; set; }

        [Column("YJSL")]
        public decimal Completed { get; set; }

        [Column("LB_BM")]
        public int ContractType { get; set; }

        [Column("LB_MC")]
        public string ContractName { get; set; }

        [Column("DR_JSSL")]
        public decimal ImportWeight { get; set; }

        [Column("DR_YJSL")]
        public decimal ImportCompleted { get; set; }

        [Column("SFSC")]
        public bool IsDeleted { get; set; }
    }
}
