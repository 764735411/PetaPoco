using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetaPocoWebApi.Model.FarmerContracts
{/// <summary>
 /// 烟农合同
 /// </summary>
    [TableName("YYSG_JSZ")]
    [PrimaryKey("JSZ_ID", AutoIncrement = false)]
    public class FarmerContract
    {
        public FarmerContract()
        {
            subContracts = new List<SubContract>();
        }
        /// <summary>
        /// 交售证Id
        /// </summary>
        [Column("JSZ_ID")]
        public Guid Id { get; set; }

        /// <summary>
        /// 户主名称
        /// </summary>
        [Column("HZ_MC")]
        public string Name { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Column("SFZH")]
        public string IdCard { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        [Column("HTH")]
        public string ContractNo { get; set; }

        /// <summary>
        /// 省合同号
        /// </summary>
        [Column("SHTH")]
        public string ProvinceContractNo { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [Column("YHZH")]
        public string BankCardNum { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        [Column("ND_MC")]
        public int Year { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [Column("YNDH")]
        public string Phone { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        [Column("QDRQ")]
        public DateTime SignedTime { get; set; }

        /// <summary>
        /// 合同量
        /// </summary>
        [Column("JSSL")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 已交量
        /// </summary>
        [Column("YJSL")]
        public decimal Completed { get; set; }

        /// <summary>
        /// 种植面积
        /// </summary>
        [Column("ZZMJ")]
        public decimal PlantArea { get; set; }

        /// <summary>
        /// 烟点编码
        /// </summary>
        [Column("DWBM_ID")]
        public string DepCode { get; set; }

        /// <summary>
        /// 烟点名称
        /// </summary>
        [Column("DWBM_MC")]
        public string DepName { get; set; }

        /// <summary>
        /// 住址代码
        /// </summary>
        [Column("ZZ_ID")]
        public string AddressCode { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        [Column("ZZ")]
        public string Address { get; set; }

        /// <summary>
        /// 品种代码
        /// </summary>
        [Column("PZ_ID")]
        public string VarityCode { get; set; }

        /// <summary>
        /// 品种名称
        /// </summary>
        [Column("PZ_MC")]
        public string VarityName { get; set; }

        /// <summary>
        /// 删除状态
        /// </summary>
        [Column("SFSC")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 子合同
        /// </summary>
        [Ignore]
        public List<SubContract> subContracts { get; set; }
    }
}
