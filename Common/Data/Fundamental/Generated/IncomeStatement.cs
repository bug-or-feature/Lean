/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2023 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
*/

using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using QuantConnect.Data.UniverseSelection;

namespace QuantConnect.Data.Fundamental
{
    /// <summary>
    /// Definition of the IncomeStatement class
    /// </summary>
    public readonly struct IncomeStatement
    {
        /// <summary>
        /// Filing date of the Income Statement.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20423
        /// </remarks>
        [JsonProperty("20423")]
        public DateTime ISFileDate => FundamentalService.Get<DateTime>(_time, _securityIdentifier, "FinancialStatements.IncomeStatement.ISFileDate");

        /// <summary>
        /// The non-cash expense recognized on intangible assets over the benefit period of the asset.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20007
        /// </remarks>
        [JsonProperty("20007")]
        public AmortizationIncomeStatement Amortization => new(_time, _securityIdentifier);

        /// <summary>
        /// The gradual elimination of a liability, such as a mortgage, in regular payments over a specified period of time. Such payments must be sufficient to cover both principal and interest.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20008
        /// </remarks>
        [JsonProperty("20008")]
        public SecuritiesAmortizationIncomeStatement SecuritiesAmortization => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate cost of goods produced and sold and services rendered during the reporting period. It excludes all operating expenses such as depreciation, depletion, amortization, and SG&amp;A. For the must have cost industry, if the number is not reported by the company, it will be calculated based on accounting equation. Cost of Revenue = Revenue - Operating Expenses - Operating Profit.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20013
        /// </remarks>
        [JsonProperty("20013")]
        public CostOfRevenueIncomeStatement CostOfRevenue => new(_time, _securityIdentifier);

        /// <summary>
        /// The non-cash expense recognized on natural resources (eg. Oil and mineral deposits) over the benefit period of the asset.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20017
        /// </remarks>
        [JsonProperty("20017")]
        public DepletionIncomeStatement Depletion => new(_time, _securityIdentifier);

        /// <summary>
        /// The current period non-cash expense recognized on tangible assets used in the normal course of business, by allocating the cost of assets over their useful lives, in the Income Statement. Examples of tangible asset include buildings, production and equipment.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20018
        /// </remarks>
        [JsonProperty("20018")]
        public DepreciationIncomeStatement Depreciation => new(_time, _securityIdentifier);

        /// <summary>
        /// The sum of depreciation and amortization expense in the Income Statement. Depreciation is the non-cash expense recognized on tangible assets used in the normal course of business, by allocating the cost of assets over their useful lives Amortization is the non-cash expense recognized on intangible assets over the benefit period of the asset.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20019
        /// </remarks>
        [JsonProperty("20019")]
        public DepreciationAndAmortizationIncomeStatement DepreciationAndAmortization => new(_time, _securityIdentifier);

        /// <summary>
        /// The sum of depreciation, amortization and depletion expense in the Income Statement. Depreciation is the non-cash expense recognized on tangible assets used in the normal course of business, by allocating the cost of assets over their useful lives Amortization is the non-cash expense recognized on intangible assets over the benefit period of the asset. Depletion is the non-cash expense recognized on natural resources (eg. Oil and mineral deposits) over the benefit period of the asset.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20020
        /// </remarks>
        [JsonProperty("20020")]
        public DepreciationAmortizationDepletionIncomeStatement DepreciationAmortizationDepletion => new(_time, _securityIdentifier);

        /// <summary>
        /// To be classified as discontinued operations, if both of the following conditions are met: 1: The operations and cash flow of the component have been or will be removed from the ongoing operations of the entity as a result of the disposal transaction, and 2: The entity will have no significant continuing involvement in the operations of the component after the disposal transaction. The discontinued operation is reported net of tax. Gains/Loss on Disposal of Discontinued Operations: Any gains or loss recognized on disposal of discontinued operations, which is the difference between the carrying value of the division and its fair value less costs to sell. Provision for Gain/Loss on Disposal: The amount of current expense charged in order to prepare for the disposal of discontinued operations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20022
        /// </remarks>
        [JsonProperty("20022")]
        public NetIncomeDiscontinuousOperationsIncomeStatement NetIncomeDiscontinuousOperations => new(_time, _securityIdentifier);

        /// <summary>
        /// Excise taxes are taxes paid when purchases are made on a specific good, such as gasoline. Excise taxes are often included in the price of the product. There are also excise taxes on activities, such as on wagering or on highway usage by trucks.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20028
        /// </remarks>
        [JsonProperty("20028")]
        public ExciseTaxesIncomeStatement ExciseTaxes => new(_time, _securityIdentifier);

        /// <summary>
        /// Gains (losses), whether arising from extinguishment of debt, prior period adjustments, or from other events or transactions, that are both unusual in nature and infrequent in occurrence thereby meeting the criteria for an event or transaction to be classified as an extraordinary item.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20030
        /// </remarks>
        [JsonProperty("20030")]
        public NetIncomeExtraordinaryIncomeStatement NetIncomeExtraordinary => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of fees, commissions, and other income.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20031
        /// </remarks>
        [JsonProperty("20031")]
        public FeeRevenueAndOtherIncomeIncomeStatement FeeRevenueAndOtherIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate total of general managing and administering expenses for the company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20045
        /// </remarks>
        [JsonProperty("20045")]
        public GeneralAndAdministrativeExpenseIncomeStatement GeneralAndAdministrativeExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// Total revenue less cost of revenue. The number is as reported by the company on the income statement; however, the number will be calculated if it is not reported. This field is null if the cost of revenue is not given. Gross Profit = Total Revenue - Cost of Revenue.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20046
        /// </remarks>
        [JsonProperty("20046")]
        public GrossProfitIncomeStatement GrossProfit => new(_time, _securityIdentifier);

        /// <summary>
        /// Relates to the general cost of borrowing money. It is the price that a lender charges a borrower for the use of the lender's money.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20057
        /// </remarks>
        [JsonProperty("20057")]
        public InterestExpenseIncomeStatement InterestExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// Interest expense caused by long term financing activities; such as interest expense incurred on trading liabilities, commercial paper, long-term debt, capital leases, deposits, and all other borrowings.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20064
        /// </remarks>
        [JsonProperty("20064")]
        public InterestExpenseNonOperatingIncomeStatement InterestExpenseNonOperating => new(_time, _securityIdentifier);

        /// <summary>
        /// Net interest and dividend income or expense, including any amortization and accretion (as applicable) of discounts and premiums, including consideration of the provisions for loan, lease, credit, and other related losses, if any.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20066
        /// </remarks>
        [JsonProperty("20066")]
        public InterestIncomeAfterProvisionForLoanLossIncomeStatement InterestIncomeAfterProvisionForLoanLoss => new(_time, _securityIdentifier);

        /// <summary>
        /// Interest income earned from long term financing activities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20075
        /// </remarks>
        [JsonProperty("20075")]
        public InterestIncomeNonOperatingIncomeStatement InterestIncomeNonOperating => new(_time, _securityIdentifier);

        /// <summary>
        /// Net-Non Operating interest income or expenses caused by financing activities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20077
        /// </remarks>
        [JsonProperty("20077")]
        public NetNonOperatingInterestIncomeExpenseIncomeStatement NetNonOperatingInterestIncomeExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// Losses generally refer to (1) the amount of reduction in the value of an insured's property caused by an insured peril, (2) the amount sought through an insured's claim, or (3) the amount paid on behalf of an insured under an insurance contract. Loss Adjustment Expenses is expenses incurred in the course of investigating and settling claims that includes any legal and adjusters' fees and the costs of paying claims and all related expenses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20084
        /// </remarks>
        [JsonProperty("20084")]
        public LossAdjustmentExpenseIncomeStatement LossAdjustmentExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents par or stated value of the subsidiary stock not owned by the parent company plus the minority interest's equity in the surplus of the subsidiary. This item includes preferred dividend averages on the minority preferred stock (preferred shares not owned by the reporting parent company). Minority interest also refers to stockholders who own less than 50% of a subsidiary's outstanding voting common stock. The minority stockholders hold an interest in the subsidiary's net assets and share earnings with the parent company.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20087
        /// </remarks>
        [JsonProperty("20087")]
        public MinorityInterestsIncomeStatement MinorityInterests => new(_time, _securityIdentifier);

        /// <summary>
        /// Includes all the operations (continuing and discontinued) and all the other income or charges (extraordinary, accounting changes, tax loss carry forward, and other gains and losses).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20091
        /// </remarks>
        [JsonProperty("20091")]
        public NetIncomeIncomeStatement NetIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Net income minus the preferred dividends paid as presented in the Income Statement.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20093
        /// </remarks>
        [JsonProperty("20093")]
        public NetIncomeCommonStockholdersIncomeStatement NetIncomeCommonStockholders => new(_time, _securityIdentifier);

        /// <summary>
        /// Revenue less expenses and taxes from the entity's ongoing operations and before income (loss) from: Preferred Dividends; Extraordinary Gains and Losses; Income from Cumulative Effects of Accounting Change; Discontinuing Operation; Income from Tax Loss Carry forward; Other Gains/Losses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20094
        /// </remarks>
        [JsonProperty("20094")]
        public NetIncomeContinuousOperationsIncomeStatement NetIncomeContinuousOperations => new(_time, _securityIdentifier);

        /// <summary>
        /// Total interest income minus total interest expense. It represents the difference between interest and dividends earned on interest- bearing assets and interest paid to depositors and other creditors.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20095
        /// </remarks>
        [JsonProperty("20095")]
        public NetInterestIncomeIncomeStatement NetInterestIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Total of interest, dividends, and other earnings derived from the insurance company's invested assets minus the expenses associated with these investments. Excluded from this income are capital gains or losses as the result of the sale of assets, as well as any unrealized capital gains or losses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20096
        /// </remarks>
        [JsonProperty("20096")]
        public NetInvestmentIncomeIncomeStatement NetInvestmentIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// All sales, business revenues and income that the company makes from its business operations, net of excise taxes. This applies for all companies and can be used as comparison for all industries. For Normal, Mining, Transportation and Utility templates companies, this is the sum of Operating Revenues, Excise Taxes and Fees. For Bank template companies, this is the sum of Net Interest Income and Non-Interest Income. For Insurance template companies, this is the sum of Premiums, Interest Income, Fees, Investment and Other Income.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20100
        /// </remarks>
        [JsonProperty("20100")]
        public TotalRevenueIncomeStatement TotalRevenue => new(_time, _securityIdentifier);

        /// <summary>
        /// Any expenses that not related to interest. It includes labor and related expense, occupancy and equipment, commission, professional expense and contract services expenses, selling, general and administrative, research and development depreciation, amortization and depletion, and any other special income/charges.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20105
        /// </remarks>
        [JsonProperty("20105")]
        public NonInterestExpenseIncomeStatement NonInterestExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// The total amount of non-interest income which may be derived from: (1) fees and commissions; (2) premiums earned; (3) equity investment; (4) the sale or disposal of assets; and (5) other sources not otherwise specified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20106
        /// </remarks>
        [JsonProperty("20106")]
        public NonInterestIncomeIncomeStatement NonInterestIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Operating expenses are primary recurring costs associated with central operations (other than cost of goods sold) that are incurred in order to generate sales.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20108
        /// </remarks>
        [JsonProperty("20108")]
        public OperatingExpenseIncomeStatement OperatingExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// Income from normal business operations after deducting cost of revenue and operating expenses. It does not include income from any investing activities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20109
        /// </remarks>
        [JsonProperty("20109")]
        public OperatingIncomeIncomeStatement OperatingIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Sales and income that the company makes from its business operations. This applies only to non-bank and insurance companies. For Utility template companies, this is the sum of revenue from electric, gas, transportation and other operating revenue. For Transportation template companies, this is the sum of revenue-passenger, revenue-cargo, and other operating revenue.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20112
        /// </remarks>
        [JsonProperty("20112")]
        public OperatingRevenueIncomeStatement OperatingRevenue => new(_time, _securityIdentifier);

        /// <summary>
        /// Income or expense that comes from miscellaneous sources.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20117
        /// </remarks>
        [JsonProperty("20117")]
        public OtherIncomeExpenseIncomeStatement OtherIncomeExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// Costs that vary with and are primarily related to the acquisition of new and renewal insurance contracts. Also referred to as underwriting expenses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20125
        /// </remarks>
        [JsonProperty("20125")]
        public PolicyAcquisitionExpenseIncomeStatement PolicyAcquisitionExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// The net provision in current period for future policy benefits, claims, and claims settlement expenses incurred in the claims settlement process before the effects of reinsurance arrangements. The value is net of the effects of contracts assumed and ceded.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20129
        /// </remarks>
        [JsonProperty("20129")]
        public NetPolicyholderBenefitsAndClaimsIncomeStatement NetPolicyholderBenefitsAndClaims => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount of dividends declared or paid in the period to preferred shareholders, or the amount for which the obligation to pay them dividends arose in the period. Preferred dividends are the amount required for the current year only, and not for any amount required in past years.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20134
        /// </remarks>
        [JsonProperty("20134")]
        public PreferredStockDividendsIncomeStatement PreferredStockDividends => new(_time, _securityIdentifier);

        /// <summary>
        /// Premiums earned is the portion of an insurance written premium which is considered "earned" by the insurer, based on the part of the policy period that the insurance has been in effect, and during which the insurer has been exposed to loss.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20135
        /// </remarks>
        [JsonProperty("20135")]
        public TotalPremiumsEarnedIncomeStatement TotalPremiumsEarned => new(_time, _securityIdentifier);

        /// <summary>
        /// Reported income before the deduction or benefit of income taxes.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20136
        /// </remarks>
        [JsonProperty("20136")]
        public PretaxIncomeIncomeStatement PretaxIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Include any taxes on income, net of any investment tax credits for the current accounting period.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20145
        /// </remarks>
        [JsonProperty("20145")]
        public TaxProvisionIncomeStatement TaxProvision => new(_time, _securityIdentifier);

        /// <summary>
        /// A charge to income which represents an expense deemed adequate by management given the composition of a bank's credit portfolios, their probability of default, the economic environment and the allowance for credit losses already established. Specific provisions are established to reduce the book value of specific assets (primarily loans) to establish the amount expected to be recovered on the loans.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20146
        /// </remarks>
        [JsonProperty("20146")]
        public CreditLossesProvisionIncomeStatement CreditLossesProvision => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of research and development expenses during the year.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20151
        /// </remarks>
        [JsonProperty("20151")]
        public ResearchAndDevelopmentIncomeStatement ResearchAndDevelopment => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate total amount of expenses directly related to the marketing or selling of products or services.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20158
        /// </remarks>
        [JsonProperty("20158")]
        public SellingAndMarketingExpenseIncomeStatement SellingAndMarketingExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate total costs related to selling a firm's product and services, as well as all other general and administrative expenses. Selling expenses are those directly related to the company's efforts to generate sales (e.g., sales salaries, commissions, advertising, delivery expenses). General and administrative expenses are expenses related to general administration of the company's operation (e.g., officers and office salaries, office supplies, telephone, accounting and legal services, and business licenses and fees).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20159
        /// </remarks>
        [JsonProperty("20159")]
        public SellingGeneralAndAdministrationIncomeStatement SellingGeneralAndAdministration => new(_time, _securityIdentifier);

        /// <summary>
        /// Earnings or losses attributable to occurrences or actions by the firm that is either infrequent or unusual.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20162
        /// </remarks>
        [JsonProperty("20162")]
        public SpecialIncomeChargesIncomeStatement SpecialIncomeCharges => new(_time, _securityIdentifier);

        /// <summary>
        /// The sum of operating expense and cost of revenue. If the company does not give the reported number, it will be calculated by adding operating expense and cost of revenue.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20164
        /// </remarks>
        [JsonProperty("20164")]
        public TotalExpensesIncomeStatement TotalExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// Income generated from interest-bearing deposits or accounts.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20177
        /// </remarks>
        [JsonProperty("20177")]
        public InterestIncomeIncomeStatement InterestIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Earnings minus expenses (excluding interest and tax expenses).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20189
        /// </remarks>
        [JsonProperty("20189")]
        public EBITIncomeStatement EBIT => new(_time, _securityIdentifier);

        /// <summary>
        /// Earnings minus expenses (excluding interest, tax, depreciation, and amortization expenses).
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20190
        /// </remarks>
        [JsonProperty("20190")]
        public EBITDAIncomeStatement EBITDA => new(_time, _securityIdentifier);

        /// <summary>
        /// Revenue less expenses and taxes from the entity's ongoing operations net of minority interest and before income (loss) from: Preferred Dividends; Extraordinary Gains and Losses; Income from Cumulative Effects of Accounting Change; Discontinuing Operation; Income from Tax Loss Carry forward; Other Gains/Losses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20191
        /// </remarks>
        [JsonProperty("20191")]
        public NetIncomeContinuousOperationsNetMinorityInterestIncomeStatement NetIncomeContinuousOperationsNetMinorityInterest => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount of premiums paid and payable to another insurer as a result of reinsurance arrangements in order to exchange for that company accepting all or part of insurance on a risk or exposure. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20201
        /// </remarks>
        [JsonProperty("20201")]
        public CededPremiumsIncomeStatement CededPremiums => new(_time, _securityIdentifier);

        /// <summary>
        /// <remarks> Morningstar DataId: 20202 </remarks>
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20202
        /// </remarks>
        [JsonProperty("20202")]
        public CommissionExpensesIncomeStatement CommissionExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// Income earned from credit card services including late, over limit, and annual fees. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20204
        /// </remarks>
        [JsonProperty("20204")]
        public CreditCardIncomeStatement CreditCard => new(_time, _securityIdentifier);

        /// <summary>
        /// Dividends earned from equity investment securities. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20206
        /// </remarks>
        [JsonProperty("20206")]
        public DividendIncomeIncomeStatement DividendIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// The earnings from equity interest can be a result of any of the following: Income from earnings distribution of the business, either as dividends paid to corporate shareholders or as drawings in a partnership; Capital gain realized upon sale of the business; Capital gain realized from selling his or her interest to other partners. This item is usually not available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20208
        /// </remarks>
        [JsonProperty("20208")]
        public EarningsFromEquityInterestIncomeStatement EarningsFromEquityInterest => new(_time, _securityIdentifier);

        /// <summary>
        /// Equipment expenses include depreciation, repairs, rentals, and service contract costs. This also includes equipment purchases which do not qualify for capitalization in accordance with the entity's accounting policy. This item may also include furniture expenses. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20210
        /// </remarks>
        [JsonProperty("20210")]
        public EquipmentIncomeStatement Equipment => new(_time, _securityIdentifier);

        /// <summary>
        /// Costs incurred in identifying areas that may warrant examination and in examining specific areas that are considered to have prospects of containing energy or metal reserves, including costs of drilling exploratory wells. Development expense is the capitalized costs incurred to obtain access to proved reserves and to provide facilities for extracting, treating, gathering and storing the energy and metal. Mineral property includes oil and gas wells, mines, and other natural deposits (including geothermal deposits). The payment for leasing those properties is called mineral property lease expense. Exploration expense is included in operation expenses for mining industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20211
        /// </remarks>
        [JsonProperty("20211")]
        public ExplorationDevelopmentAndMineralPropertyLeaseExpensesIncomeStatement ExplorationDevelopmentAndMineralPropertyLeaseExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// Total fees and commissions earned from providing services such as leasing of space or maintaining: (1) depositor accounts; (2) transfer agent; (3) fiduciary and trust; (4) brokerage and underwriting; (5) mortgage; (6) credit cards; (7) correspondent clearing; and (8) other such services and activities performed for others. This item is usually available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20213
        /// </remarks>
        [JsonProperty("20213")]
        public FeesAndCommissionsIncomeStatement FeesAndCommissions => new(_time, _securityIdentifier);

        /// <summary>
        /// Trading revenues that result from foreign exchange exposures such as cash instruments and off-balance sheet derivative instruments. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20214
        /// </remarks>
        [JsonProperty("20214")]
        public ForeignExchangeTradingGainsIncomeStatement ForeignExchangeTradingGains => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of fuel cost for current period associated with the revenue generation. This item is usually only available for transportation industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20215
        /// </remarks>
        [JsonProperty("20215")]
        public FuelIncomeStatement Fuel => new(_time, _securityIdentifier);

        /// <summary>
        /// Cost of fuel, purchase power and gas associated with revenue generation. This item is usually only available for utility industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20216
        /// </remarks>
        [JsonProperty("20216")]
        public FuelAndPurchasePowerIncomeStatement FuelAndPurchasePower => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount of excess earned in comparison to fair value when selling a business. This item is usually not available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20217
        /// </remarks>
        [JsonProperty("20217")]
        public GainOnSaleOfBusinessIncomeStatement GainOnSaleOfBusiness => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount of excess earned in comparison to the net book value for sale of property, plant, equipment. This item is usually not available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20218
        /// </remarks>
        [JsonProperty("20218")]
        public GainOnSaleOfPPEIncomeStatement GainOnSaleOfPPE => new(_time, _securityIdentifier);

        /// <summary>
        /// The amount of excess earned in comparison to the original purchase value of the security.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20219
        /// </remarks>
        [JsonProperty("20219")]
        public GainOnSaleOfSecurityIncomeStatement GainOnSaleOfSecurity => new(_time, _securityIdentifier);

        /// <summary>
        /// Total premiums generated from all policies written by an insurance company within a given period of time. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20224
        /// </remarks>
        [JsonProperty("20224")]
        public GrossPremiumsWrittenIncomeStatement GrossPremiumsWritten => new(_time, _securityIdentifier);

        /// <summary>
        /// Impairments are considered to be permanent, which is a downward revaluation of fixed assets. If the sum of all estimated future cash flows is less than the carrying value of the asset, then the asset would be considered impaired and would have to be written down to its fair value. Once an asset is written down, it may only be written back up under very few circumstances. Usually the company uses the sum of undiscounted future cash flows to determine if the impairment should occur, and uses the sum of discounted future cash flows to make the impairment judgment. The impairment decision emphasizes on capital assets' future profit collection ability.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20225
        /// </remarks>
        [JsonProperty("20225")]
        public ImpairmentOfCapitalAssetsIncomeStatement ImpairmentOfCapitalAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Premium might contain a portion of the amount that has been paid in advance for insurance that has not yet been provided, which is called unearned premium. If either party cancels the contract, the insurer must have the unearned premium ready to refund. Hence, the amount of premium reserve maintained by insurers is called unearned premium reserves, which is prepared for liquidation. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20230
        /// </remarks>
        [JsonProperty("20230")]
        public IncreaseDecreaseInNetUnearnedPremiumReservesIncomeStatement IncreaseDecreaseInNetUnearnedPremiumReserves => new(_time, _securityIdentifier);

        /// <summary>
        /// Insurance and claims are the expenses in the period incurred with respect to protection provided by insurance entities against risks other than risks associated with production (which is allocated to cost of sales). This item is usually not available for insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20231
        /// </remarks>
        [JsonProperty("20231")]
        public InsuranceAndClaimsIncomeStatement InsuranceAndClaims => new(_time, _securityIdentifier);

        /// <summary>
        /// Includes interest expense on the following deposit accounts: Interest-bearing Demand deposit; Checking account; Savings account; Deposit in foreign offices; Money Market Certificates &amp; Deposit Accounts. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20235
        /// </remarks>
        [JsonProperty("20235")]
        public InterestExpenseForDepositIncomeStatement InterestExpenseForDeposit => new(_time, _securityIdentifier);

        /// <summary>
        /// Gross expenses on the purchase of Federal funds at a specified price with a simultaneous agreement to sell the same to the same counterparty at a fixed or determinable price at a future date. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20236
        /// </remarks>
        [JsonProperty("20236")]
        public InterestExpenseForFederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResellIncomeStatement InterestExpenseForFederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResell => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate interest expenses incurred on long-term borrowings and any interest expenses on fixed assets (property, plant, equipment) that are leased due longer than one year. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20238
        /// </remarks>
        [JsonProperty("20238")]
        public InterestExpenseForLongTermDebtAndCapitalSecuritiesIncomeStatement InterestExpenseForLongTermDebtAndCapitalSecurities => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate interest expenses incurred on short-term borrowings and any interest expenses on fixed assets (property, plant, equipment) that are leased within one year. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20239
        /// </remarks>
        [JsonProperty("20239")]
        public InterestExpenseForShortTermDebtIncomeStatement InterestExpenseForShortTermDebt => new(_time, _securityIdentifier);

        /// <summary>
        /// Interest income generated from all deposit accounts. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20240
        /// </remarks>
        [JsonProperty("20240")]
        public InterestIncomeFromDepositsIncomeStatement InterestIncomeFromDeposits => new(_time, _securityIdentifier);

        /// <summary>
        /// The carrying value of funds outstanding loaned in the form of security resale agreements if the agreement requires the purchaser to resell the identical security purchased or a security that meets the definition of ""substantially the same"" in the case of a dollar roll. Also includes purchases of participations in pools of securities that are subject to a resale agreement; This category includes all interest income generated from federal funds sold and securities purchases under agreements to resell; This category includes all interest income generated from federal funds sold and securities purchases under agreements to resell.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20241
        /// </remarks>
        [JsonProperty("20241")]
        public InterestIncomeFromFederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResellIncomeStatement InterestIncomeFromFederalFundsSoldAndSecuritiesPurchaseUnderAgreementsToResell => new(_time, _securityIdentifier);

        /// <summary>
        /// Includes interest and fee income generated by direct lease financing. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20243
        /// </remarks>
        [JsonProperty("20243")]
        public InterestIncomeFromLeasesIncomeStatement InterestIncomeFromLeases => new(_time, _securityIdentifier);

        /// <summary>
        /// Loan is a common field to banks. Interest Income from Loans is interest and fee income generated from all loans, which includes Commercial loans; Credit loans; Other consumer loans; Real Estate - Construction; Real Estate - Mortgage; Foreign loans. Banks earn interest from loans. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20244
        /// </remarks>
        [JsonProperty("20244")]
        public InterestIncomeFromLoansIncomeStatement InterestIncomeFromLoans => new(_time, _securityIdentifier);

        /// <summary>
        /// Total interest and fee income generated by loans and lease. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20245
        /// </remarks>
        [JsonProperty("20245")]
        public InterestIncomeFromLoansAndLeaseIncomeStatement InterestIncomeFromLoansAndLease => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents total interest and dividend income from U.S. Treasury securities, U.S. government agency and corporation obligations, securities issued by states and political subdivisions, other domestic debt securities, foreign debt securities, and equity securities (including investments in mutual funds). Excludes interest income from securities held in trading accounts. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20246
        /// </remarks>
        [JsonProperty("20246")]
        public InterestIncomeFromSecuritiesIncomeStatement InterestIncomeFromSecurities => new(_time, _securityIdentifier);

        /// <summary>
        /// Includes (1) underwriting revenue (the spread between the resale price received and the cost of the securities and related expenses) generated through the purchasing, distributing and reselling of new issues of securities (alternatively, could be a secondary offering of a large block of previously issued securities); and (2) fees earned for mergers, acquisitions, divestitures, restructurings, and other types of financial advisory services. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20248
        /// </remarks>
        [JsonProperty("20248")]
        public InvestmentBankingProfitIncomeStatement InvestmentBankingProfit => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of maintenance and repair expenses in the current period associated with the revenue generation. Mainly for fixed assets. This item is usually only available for transportation industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20252
        /// </remarks>
        [JsonProperty("20252")]
        public MaintenanceAndRepairsIncomeStatement MaintenanceAndRepairs => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate foreign currency translation gain or loss (both realized and unrealized) included as part of revenue. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20255
        /// </remarks>
        [JsonProperty("20255")]
        public NetForeignExchangeGainLossIncomeStatement NetForeignExchangeGainLoss => new(_time, _securityIdentifier);

        /// <summary>
        /// Occupancy expense may include items, such as depreciation of facilities and equipment, lease expenses, property taxes and property and casualty insurance expense. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20256
        /// </remarks>
        [JsonProperty("20256")]
        public NetOccupancyExpenseIncomeStatement NetOccupancyExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// Net premiums written are gross premiums written less ceded premiums. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20257
        /// </remarks>
        [JsonProperty("20257")]
        public NetPremiumsWrittenIncomeStatement NetPremiumsWritten => new(_time, _securityIdentifier);

        /// <summary>
        /// Gain or loss realized during the period of time for all kinds of investment securities. In might include trading, available-for-sale, or held-to-maturity securities. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20258
        /// </remarks>
        [JsonProperty("20258")]
        public NetRealizedGainLossOnInvestmentsIncomeStatement NetRealizedGainLossOnInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// Includes total expenses of occupancy and equipment. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20260
        /// </remarks>
        [JsonProperty("20260")]
        public OccupancyAndEquipmentIncomeStatement OccupancyAndEquipment => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of operation and maintenance expenses, which is the one important operating expense for the utility industry. It includes any costs related to production and maintenance cost of the property during the revenue generation process. This item is usually only available for mining and utility industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20262
        /// </remarks>
        [JsonProperty("20262")]
        public OperationAndMaintenanceIncomeStatement OperationAndMaintenance => new(_time, _securityIdentifier);

        /// <summary>
        /// Represents fees and commissions earned from provide other services. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20263
        /// </remarks>
        [JsonProperty("20263")]
        public OtherCustomerServicesIncomeStatement OtherCustomerServices => new(_time, _securityIdentifier);

        /// <summary>
        /// All other interest expense that is not otherwise classified
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20265
        /// </remarks>
        [JsonProperty("20265")]
        public OtherInterestExpenseIncomeStatement OtherInterestExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// All other interest income that is not otherwise classified
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20266
        /// </remarks>
        [JsonProperty("20266")]
        public OtherInterestIncomeIncomeStatement OtherInterestIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// All other non interest expense that is not otherwise classified
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20267
        /// </remarks>
        [JsonProperty("20267")]
        public OtherNonInterestExpenseIncomeStatement OtherNonInterestExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// All other special charges that are not otherwise classified
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20269
        /// </remarks>
        [JsonProperty("20269")]
        public OtherSpecialChargesIncomeStatement OtherSpecialCharges => new(_time, _securityIdentifier);

        /// <summary>
        /// Any taxes that are not part of income taxes. This item is usually not available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20271
        /// </remarks>
        [JsonProperty("20271")]
        public OtherTaxesIncomeStatement OtherTaxes => new(_time, _securityIdentifier);

        /// <summary>
        /// The provision in current period for future policy benefits, claims, and claims settlement, which is under reinsurance arrangements. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20273
        /// </remarks>
        [JsonProperty("20273")]
        public PolicyholderBenefitsCededIncomeStatement PolicyholderBenefitsCeded => new(_time, _securityIdentifier);

        /// <summary>
        /// The gross amount of provision in current period for future policyholder benefits, claims, and claims settlement, incurred in the claims settlement process before the effects of reinsurance arrangements. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20274
        /// </remarks>
        [JsonProperty("20274")]
        public PolicyholderBenefitsGrossIncomeStatement PolicyholderBenefitsGross => new(_time, _securityIdentifier);

        /// <summary>
        /// Payments made or credits extended to the insured by the company, usually at the end of a policy year results in reducing the net insurance cost to the policyholder. Such dividends may be paid in cash to the insured or applied by the insured as reductions of the premiums due for the next policy year. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20275
        /// </remarks>
        [JsonProperty("20275")]
        public PolicyholderDividendsIncomeStatement PolicyholderDividends => new(_time, _securityIdentifier);

        /// <summary>
        /// The periodic income payment provided to the annuitant by the insurance company, which is determined by the assumed interest rate (AIR) and other factors. This item is usually only available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20276
        /// </remarks>
        [JsonProperty("20276")]
        public PolicyholderInterestIncomeStatement PolicyholderInterest => new(_time, _securityIdentifier);

        /// <summary>
        /// Professional and contract service expense includes cost reimbursements for support services related to contracted projects, outsourced management, technical and staff support. This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20280
        /// </remarks>
        [JsonProperty("20280")]
        public ProfessionalExpenseAndContractServicesExpenseIncomeStatement ProfessionalExpenseAndContractServicesExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// Amount of the current period expense charged against operations, the offset which is generally to the allowance for doubtful accounts for the purpose of reducing receivables, including notes receivable, to an amount that approximates their net realizable value (the amount expected to be collected). The category includes provision for loan losses, provision for any doubtful account receivable, and bad debt expenses. This item is usually not available for bank and insurance industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20283
        /// </remarks>
        [JsonProperty("20283")]
        public ProvisionForDoubtfulAccountsIncomeStatement ProvisionForDoubtfulAccounts => new(_time, _securityIdentifier);

        /// <summary>
        /// Rent fees are the cost of occupying space during the accounting period. Landing fees are a change paid to an airport company for landing at a particular airport. This item is not available for insurance industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20287
        /// </remarks>
        [JsonProperty("20287")]
        public RentAndLandingFeesIncomeStatement RentAndLandingFees => new(_time, _securityIdentifier);

        /// <summary>
        /// Expenses are related to restructuring, merger, or acquisitions. Restructuring expenses are charges associated with the consolidation and relocation of operations, disposition or abandonment of operations or productive assets. Merger and acquisition expenses are the amount of costs of a business combination including legal, accounting, and other costs that were charged to expense during the period.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20289
        /// </remarks>
        [JsonProperty("20289")]
        public RestructuringAndMergernAcquisitionIncomeStatement RestructuringAndMergernAcquisition => new(_time, _securityIdentifier);

        /// <summary>
        /// All salary, wages, compensation, management fees, and employee benefit expenses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20292
        /// </remarks>
        [JsonProperty("20292")]
        public SalariesAndWagesIncomeStatement SalariesAndWages => new(_time, _securityIdentifier);

        /// <summary>
        /// Income/Loss from Securities and Activities
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20293
        /// </remarks>
        [JsonProperty("20293")]
        public SecuritiesActivitiesIncomeStatement SecuritiesActivities => new(_time, _securityIdentifier);

        /// <summary>
        /// Includes any service charges on following accounts: Demand Deposit; Checking account; Savings account; Deposit in foreign offices; ESCROW accounts; Money Market Certificates &amp; Deposit accounts, CDs (Negotiable Certificates of Deposits); NOW Accounts (Negotiable Order of Withdrawal); IRAs (Individual Retirement Accounts). This item is usually only available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20295
        /// </remarks>
        [JsonProperty("20295")]
        public ServiceChargeOnDepositorAccountsIncomeStatement ServiceChargeOnDepositorAccounts => new(_time, _securityIdentifier);

        /// <summary>
        /// A broker-dealer or other financial entity may buy and sell securities exclusively for its own account, sometimes referred to as proprietary trading. The profit or loss is measured by the difference between the acquisition cost and the selling price or current market or fair value. The net gain or loss, includes both realized and unrealized, from trading cash instruments, equities and derivative contracts (including commodity contracts) that has been recognized during the accounting period for the broker dealer or other financial entity's own account. This item is typically available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20298
        /// </remarks>
        [JsonProperty("20298")]
        public TradingGainLossIncomeStatement TradingGainLoss => new(_time, _securityIdentifier);

        /// <summary>
        /// Bank manages funds on behalf of its customers through the operation of various trust accounts. Any fees earned through managing those funds are called trust fees, which are recognized when earned. This item is typically available for bank industry.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20300
        /// </remarks>
        [JsonProperty("20300")]
        public TrustFeesbyCommissionsIncomeStatement TrustFeesbyCommissions => new(_time, _securityIdentifier);

        /// <summary>
        /// Also known as Policy Acquisition Costs; and reported by insurance companies. The cost incurred by an insurer when deciding whether to accept or decline a risk; may include meetings with the insureds or brokers, actuarial review of loss history, or physical inspections of exposures. Also, expenses deducted from insurance company revenues (including incurred losses and acquisition costs) to determine underwriting profit.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20301
        /// </remarks>
        [JsonProperty("20301")]
        public UnderwritingExpensesIncomeStatement UnderwritingExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// A reduction in the value of an asset or earnings by the amount of an expense or loss.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20304
        /// </remarks>
        [JsonProperty("20304")]
        public WriteOffIncomeStatement WriteOff => new(_time, _securityIdentifier);

        /// <summary>
        /// Usually available for the banking industry. This is Non-Interest Income that is not otherwise classified.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20306
        /// </remarks>
        [JsonProperty("20306")]
        public OtherNonInterestIncomeIncomeStatement OtherNonInterestIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate expense charged against earnings to allocate the cost of intangible assets (nonphysical assets not used in production) in a systematic and rational manner to the periods expected to benefit from such assets.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20308
        /// </remarks>
        [JsonProperty("20308")]
        public AmortizationOfIntangiblesIncomeStatement AmortizationOfIntangibles => new(_time, _securityIdentifier);

        /// <summary>
        /// Net Income from Continuing Operations and Discontinued Operations, added together.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20309
        /// </remarks>
        [JsonProperty("20309")]
        public NetIncomeFromContinuingAndDiscontinuedOperationIncomeStatement NetIncomeFromContinuingAndDiscontinuedOperation => new(_time, _securityIdentifier);

        /// <summary>
        /// Occurs if a company has had a net loss from operations on a previous year that can be carried forward to reduce net income for tax purposes.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20311
        /// </remarks>
        [JsonProperty("20311")]
        public NetIncomeFromTaxLossCarryforwardIncomeStatement NetIncomeFromTaxLossCarryforward => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of operating expenses associated with normal operations. Will not include any gain, loss, benefit, or income; and its value reported by the company should be &lt;0.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20312
        /// </remarks>
        [JsonProperty("20312")]
        public OtherOperatingExpensesIncomeStatement OtherOperatingExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// The sum of the money market investments held by a bank's depositors, which are FDIC insured.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20313
        /// </remarks>
        [JsonProperty("20313")]
        public TotalMoneyMarketInvestmentsIncomeStatement TotalMoneyMarketInvestments => new(_time, _securityIdentifier);

        /// <summary>
        /// The Cost Of Revenue plus Depreciation, Depletion &amp; Amortization from the IncomeStatement; minus Depreciation, Depletion &amp; Amortization from the Cash Flow Statement
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20314
        /// </remarks>
        [JsonProperty("20314")]
        public ReconciledCostOfRevenueIncomeStatement ReconciledCostOfRevenue => new(_time, _securityIdentifier);

        /// <summary>
        /// Is Depreciation, Depletion &amp; Amortization from the Cash Flow Statement
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20315
        /// </remarks>
        [JsonProperty("20315")]
        public ReconciledDepreciationIncomeStatement ReconciledDepreciation => new(_time, _securityIdentifier);

        /// <summary>
        /// This calculation represents earnings adjusted for items that are irregular or unusual in nature, and/or are non-recurring. This can be used to fairly measure a company's profitability. This is calculated using Net Income from Continuing Operations plus/minus any tax affected unusual Items and Goodwill Impairments/Write Offs.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20316
        /// </remarks>
        [JsonProperty("20316")]
        public NormalizedIncomeIncomeStatement NormalizedIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Revenue less expenses and taxes from the entity's ongoing operations net of minority interest and before income (loss) from: Preferred Dividends; Extraordinary Gains and Losses; Income from Cumulative Effects of Accounting Change; Discontinuing Operation; Income from Tax Loss Carry forward; Other Gains/Losses.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20331
        /// </remarks>
        [JsonProperty("20331")]
        public NetIncomeFromContinuingOperationNetMinorityInterestIncomeStatement NetIncomeFromContinuingOperationNetMinorityInterest => new(_time, _securityIdentifier);

        /// <summary>
        /// Any gain (loss) recognized on the sale of assets or a sale which generates profit or loss, which is a difference between sales price and net book value at the disposal time.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20333
        /// </remarks>
        [JsonProperty("20333")]
        public GainLossonSaleofAssetsIncomeStatement GainLossonSaleofAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Gain on sale of any loans investment.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20334
        /// </remarks>
        [JsonProperty("20334")]
        public GainonSaleofLoansIncomeStatement GainonSaleofLoans => new(_time, _securityIdentifier);

        /// <summary>
        /// Gain on the disposal of investment property.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20335
        /// </remarks>
        [JsonProperty("20335")]
        public GainonSaleofInvestmentPropertyIncomeStatement GainonSaleofInvestmentProperty => new(_time, _securityIdentifier);

        /// <summary>
        /// Loss on extinguishment of debt is the accounting loss that results from a debt extinguishment. A debt shall be accounted for as having been extinguished in a number of circumstances, including when it has been settled through repayment or replacement by another liability. It generally results in an accounting gain or loss. Amount represents the difference between the fair value of the payments made and the carrying amount of the debt at the time of its extinguishment.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20343
        /// </remarks>
        [JsonProperty("20343")]
        public LossonExtinguishmentofDebtIncomeStatement LossonExtinguishmentofDebt => new(_time, _securityIdentifier);

        /// <summary>
        /// Income from other equity interest reported after Provision of Tax. This applies to all industries.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20345
        /// </remarks>
        [JsonProperty("20345")]
        public EarningsfromEquityInterestNetOfTaxIncomeStatement EarningsfromEquityInterestNetOfTax => new(_time, _securityIdentifier);

        /// <summary>
        /// Net income of the group after the adjustment of all expenses and benefit.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20346
        /// </remarks>
        [JsonProperty("20346")]
        public NetIncomeIncludingNoncontrollingInterestsIncomeStatement NetIncomeIncludingNoncontrollingInterests => new(_time, _securityIdentifier);

        /// <summary>
        /// Dividend paid to the preferred shareholders before the common stock shareholders.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20347
        /// </remarks>
        [JsonProperty("20347")]
        public OtherunderPreferredStockDividendIncomeStatement OtherunderPreferredStockDividend => new(_time, _securityIdentifier);

        /// <summary>
        /// Total staff cost which is paid to the employees that is not part of Selling, General, and Administration expense.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20359
        /// </remarks>
        [JsonProperty("20359")]
        public StaffCostsIncomeStatement StaffCosts => new(_time, _securityIdentifier);

        /// <summary>
        /// Benefits paid to the employees in respect of their work.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20360
        /// </remarks>
        [JsonProperty("20360")]
        public SocialSecurityCostsIncomeStatement SocialSecurityCosts => new(_time, _securityIdentifier);

        /// <summary>
        /// The expense that a company incurs each year by providing a pension plan for its employees. Major expenses in the pension cost include employer matching contributions and management fees.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20361
        /// </remarks>
        [JsonProperty("20361")]
        public PensionCostsIncomeStatement PensionCosts => new(_time, _securityIdentifier);

        /// <summary>
        /// Total Other Operating Income- including interest income, dividend income and other types of operating income.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20363
        /// </remarks>
        [JsonProperty("20363")]
        public OtherOperatingIncomeTotalIncomeStatement OtherOperatingIncomeTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Total income from the associates and joint venture via investment, accounted for in the Non-Operating section.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20367
        /// </remarks>
        [JsonProperty("20367")]
        public IncomefromAssociatesandOtherParticipatingInterestsIncomeStatement IncomefromAssociatesandOtherParticipatingInterests => new(_time, _securityIdentifier);

        /// <summary>
        /// Any other finance cost which is not clearly defined in the Non-Operating section.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20368
        /// </remarks>
        [JsonProperty("20368")]
        public TotalOtherFinanceCostIncomeStatement TotalOtherFinanceCost => new(_time, _securityIdentifier);

        /// <summary>
        /// Total amount paid in dividends to investors- this includes dividends paid on equity and non-equity shares.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20371
        /// </remarks>
        [JsonProperty("20371")]
        public GrossDividendPaymentIncomeStatement GrossDividendPayment => new(_time, _securityIdentifier);

        /// <summary>
        /// Fees and commission income earned by bank and insurance companies on the rendering services.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20377
        /// </remarks>
        [JsonProperty("20377")]
        public FeesandCommissionIncomeIncomeStatement FeesandCommissionIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Cost incurred by bank and insurance companies for fees and commission income.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20378
        /// </remarks>
        [JsonProperty("20378")]
        public FeesandCommissionExpenseIncomeStatement FeesandCommissionExpense => new(_time, _securityIdentifier);

        /// <summary>
        /// Any trading income on the securities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20379
        /// </remarks>
        [JsonProperty("20379")]
        public NetTradingIncomeIncomeStatement NetTradingIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Other costs in incurred in lieu of the employees that cannot be identified by other specific items in the Staff Costs section.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20381
        /// </remarks>
        [JsonProperty("20381")]
        public OtherStaffCostsIncomeStatement OtherStaffCosts => new(_time, _securityIdentifier);

        /// <summary>
        /// Gain on disposal and change in fair value of investment properties.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20383
        /// </remarks>
        [JsonProperty("20383")]
        public GainonInvestmentPropertiesIncomeStatement GainonInvestmentProperties => new(_time, _securityIdentifier);

        /// <summary>
        /// Adjustments to reported net income to calculate Diluted EPS, by assuming that all convertible instruments are converted to Common Equity. The adjustments usually include the interest expense of debentures when assumed converted and preferred dividends of convertible preferred stock when assumed converted.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20385
        /// </remarks>
        [JsonProperty("20385")]
        public AverageDilutionEarningsIncomeStatement AverageDilutionEarnings => new(_time, _securityIdentifier);

        /// <summary>
        /// Gain/Loss through hedging activities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20391
        /// </remarks>
        [JsonProperty("20391")]
        public GainLossonFinancialInstrumentsDesignatedasCashFlowHedgesIncomeStatement GainLossonFinancialInstrumentsDesignatedasCashFlowHedges => new(_time, _securityIdentifier);

        /// <summary>
        /// Gain/loss on the write-off of financial assets available-for-sale.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20392
        /// </remarks>
        [JsonProperty("20392")]
        public GainLossonDerecognitionofAvailableForSaleFinancialAssetsIncomeStatement GainLossonDerecognitionofAvailableForSaleFinancialAssets => new(_time, _securityIdentifier);

        /// <summary>
        /// Negative Goodwill recognized in the Income Statement. Negative Goodwill arises where the net assets at the date of acquisition, fairly valued, falls below the cost of acquisition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20394
        /// </remarks>
        [JsonProperty("20394")]
        public NegativeGoodwillImmediatelyRecognizedIncomeStatement NegativeGoodwillImmediatelyRecognized => new(_time, _securityIdentifier);

        /// <summary>
        /// Gain or loss on derivatives investment due to the fair value adjustment.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20395
        /// </remarks>
        [JsonProperty("20395")]
        public GainsLossesonFinancialInstrumentsDuetoFairValueAdjustmentsinHedgeAccountingTotalIncomeStatement GainsLossesonFinancialInstrumentsDuetoFairValueAdjustmentsinHedgeAccountingTotal => new(_time, _securityIdentifier);

        /// <summary>
        /// Impairment or reversal of impairment on financial instrument such as derivative. This is a contra account under Total Revenue in banks.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20396
        /// </remarks>
        [JsonProperty("20396")]
        public ImpairmentLossesReversalsFinancialInstrumentsNetIncomeStatement ImpairmentLossesReversalsFinancialInstrumentsNet => new(_time, _securityIdentifier);

        /// <summary>
        /// All reported claims arising out of incidents in that year are considered incurred grouped with claims paid out.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20400
        /// </remarks>
        [JsonProperty("20400")]
        public ClaimsandPaidIncurredIncomeStatement ClaimsandPaidIncurred => new(_time, _securityIdentifier);

        /// <summary>
        /// Claim on the reinsurance company and take the benefits.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20401
        /// </remarks>
        [JsonProperty("20401")]
        public ReinsuranceRecoveriesClaimsandBenefitsIncomeStatement ReinsuranceRecoveriesClaimsandBenefits => new(_time, _securityIdentifier);

        /// <summary>
        /// Income/Expense due to changes between periods in insurance liabilities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20402
        /// </remarks>
        [JsonProperty("20402")]
        public ChangeinInsuranceLiabilitiesNetofReinsuranceIncomeStatement ChangeinInsuranceLiabilitiesNetofReinsurance => new(_time, _securityIdentifier);

        /// <summary>
        /// Income/Expense due to changes between periods in Investment Contracts.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20405
        /// </remarks>
        [JsonProperty("20405")]
        public ChangeinInvestmentContractIncomeStatement ChangeinInvestmentContract => new(_time, _securityIdentifier);

        /// <summary>
        /// Provision for the risk of loss of principal or loss of a financial reward stemming from a borrower's failure to repay a loan or otherwise meet a contractual obligation. Credit risk arises whenever a borrower is expecting to use future cash flows to pay a current debt. Investors are compensated for assuming credit risk by way of interest payments from the borrower or issuer of a debt obligation. This is a contra account under Total Revenue in banks.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20409
        /// </remarks>
        [JsonProperty("20409")]
        public CreditRiskProvisionsIncomeStatement CreditRiskProvisions => new(_time, _securityIdentifier);

        /// <summary>
        /// This is the portion under Staff Costs that represents salary paid to the employees in respect of their work.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20411
        /// </remarks>
        [JsonProperty("20411")]
        public WagesandSalariesIncomeStatement WagesandSalaries => new(_time, _securityIdentifier);

        /// <summary>
        /// Total other income and expense of the company that cannot be identified by other specific items in the Non-Operating section.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20412
        /// </remarks>
        [JsonProperty("20412")]
        public OtherNonOperatingIncomeExpensesIncomeStatement OtherNonOperatingIncomeExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// Other income of the company that cannot be identified by other specific items in the Non-Operating section.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20414
        /// </remarks>
        [JsonProperty("20414")]
        public OtherNonOperatingIncomeIncomeStatement OtherNonOperatingIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// Other expenses of the company that cannot be identified by other specific items in the Non-Operating section.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20415
        /// </remarks>
        [JsonProperty("20415")]
        public OtherNonOperatingExpensesIncomeStatement OtherNonOperatingExpenses => new(_time, _securityIdentifier);

        /// <summary>
        /// Total unusual items including Negative Goodwill.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20416
        /// </remarks>
        [JsonProperty("20416")]
        public TotalUnusualItemsIncomeStatement TotalUnusualItems => new(_time, _securityIdentifier);

        /// <summary>
        /// The sum of all the identifiable operating and non-operating unusual items.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20417
        /// </remarks>
        [JsonProperty("20417")]
        public TotalUnusualItemsExcludingGoodwillIncomeStatement TotalUnusualItemsExcludingGoodwill => new(_time, _securityIdentifier);

        /// <summary>
        /// Tax rate used for Morningstar calculations.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20418
        /// </remarks>
        [JsonProperty("20418")]
        public TaxRateForCalcsIncomeStatement TaxRateForCalcs => new(_time, _securityIdentifier);

        /// <summary>
        /// Tax effect of the usual items
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20419
        /// </remarks>
        [JsonProperty("20419")]
        public TaxEffectOfUnusualItemsIncomeStatement TaxEffectOfUnusualItems => new(_time, _securityIdentifier);

        /// <summary>
        /// EBITDA less Total Unusual Items
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20420
        /// </remarks>
        [JsonProperty("20420")]
        public NormalizedEBITDAIncomeStatement NormalizedEBITDA => new(_time, _securityIdentifier);

        /// <summary>
        /// The cost to the company for granting stock options to reward employees.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20422
        /// </remarks>
        [JsonProperty("20422")]
        public StockBasedCompensationIncomeStatement StockBasedCompensation => new(_time, _securityIdentifier);

        /// <summary>
        /// Net income to calculate Diluted EPS, accounting for adjustments assuming that all the convertible instruments are being converted to Common Equity.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20424
        /// </remarks>
        [JsonProperty("20424")]
        public DilutedNIAvailtoComStockholdersIncomeStatement DilutedNIAvailtoComStockholders => new(_time, _securityIdentifier);

        /// <summary>
        /// Income/Expenses due to the insurer's liabilities incurred in Investment Contracts.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20425
        /// </remarks>
        [JsonProperty("20425")]
        public InvestmentContractLiabilitiesIncurredIncomeStatement InvestmentContractLiabilitiesIncurred => new(_time, _securityIdentifier);

        /// <summary>
        /// Income/Expense due to recoveries from reinsurers for Investment Contracts.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20426
        /// </remarks>
        [JsonProperty("20426")]
        public ReinsuranceRecoveriesofInvestmentContractIncomeStatement ReinsuranceRecoveriesofInvestmentContract => new(_time, _securityIdentifier);

        /// <summary>
        /// Total amount paid in dividends to equity securities investors.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20429
        /// </remarks>
        [JsonProperty("20429")]
        public TotalDividendPaymentofEquitySharesIncomeStatement TotalDividendPaymentofEquityShares => new(_time, _securityIdentifier);

        /// <summary>
        /// Total amount paid in dividends to Non-Equity securities investors.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20430
        /// </remarks>
        [JsonProperty("20430")]
        public TotalDividendPaymentofNonEquitySharesIncomeStatement TotalDividendPaymentofNonEquityShares => new(_time, _securityIdentifier);

        /// <summary>
        /// The change in the amount of the unearned premium reserves maintained by insurers.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20431
        /// </remarks>
        [JsonProperty("20431")]
        public ChangeinTheGrossProvisionforUnearnedPremiumsIncomeStatement ChangeinTheGrossProvisionforUnearnedPremiums => new(_time, _securityIdentifier);

        /// <summary>
        /// The change in the amount of unearned premium reserve to be covered by reinsurers.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20432
        /// </remarks>
        [JsonProperty("20432")]
        public ChangeinTheGrossProvisionforUnearnedPremiumsReinsurersShareIncomeStatement ChangeinTheGrossProvisionforUnearnedPremiumsReinsurersShare => new(_time, _securityIdentifier);

        /// <summary>
        /// Income/Expense due to the insurer's changes in insurance liabilities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20433
        /// </remarks>
        [JsonProperty("20433")]
        public ClaimsandChangeinInsuranceLiabilitiesIncomeStatement ClaimsandChangeinInsuranceLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Income/Expense due to recoveries from reinsurers for insurance liabilities.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20434
        /// </remarks>
        [JsonProperty("20434")]
        public ReinsuranceRecoveriesofInsuranceLiabilitiesIncomeStatement ReinsuranceRecoveriesofInsuranceLiabilities => new(_time, _securityIdentifier);

        /// <summary>
        /// Operating profit/loss as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20435
        /// </remarks>
        [JsonProperty("20435")]
        public TotalOperatingIncomeAsReportedIncomeStatement TotalOperatingIncomeAsReported => new(_time, _securityIdentifier);

        /// <summary>
        /// Other General and Administrative Expenses not categorized that the company incurs that are not directly tied to a specific function such as manufacturing, production, or sales.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20436
        /// </remarks>
        [JsonProperty("20436")]
        public OtherGAIncomeStatement OtherGA => new(_time, _securityIdentifier);

        /// <summary>
        /// Other costs associated with the revenue-generating activities of the company not categorized above.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20437
        /// </remarks>
        [JsonProperty("20437")]
        public OtherCostofRevenueIncomeStatement OtherCostofRevenue => new(_time, _securityIdentifier);

        /// <summary>
        /// Costs paid to use the facilities necessary to generate revenue during the accounting period.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20438
        /// </remarks>
        [JsonProperty("20438")]
        public RentandLandingFeesCostofRevenueIncomeStatement RentandLandingFeesCostofRevenue => new(_time, _securityIdentifier);

        /// <summary>
        /// Costs of depreciation and amortization on assets used for the revenue-generating activities during the accounting period
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20439
        /// </remarks>
        [JsonProperty("20439")]
        public DDACostofRevenueIncomeStatement DDACostofRevenue => new(_time, _securityIdentifier);

        /// <summary>
        /// The sum of all rent expenses incurred by the company for operating leases during the year, it is a supplemental value which would be reported outside consolidated statements or consolidated statement's footnotes.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20440
        /// </remarks>
        [JsonProperty("20440")]
        public RentExpenseSupplementalIncomeStatement RentExpenseSupplemental => new(_time, _securityIdentifier);

        /// <summary>
        /// This calculation represents pre-tax earnings adjusted for items that are irregular or unusual in nature, and/or are non-recurring. This can be used to fairly measure a company's profitability. This is calculated using Pre-Tax Income plus/minus any unusual Items and Goodwill Impairments/Write Offs.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20441
        /// </remarks>
        [JsonProperty("20441")]
        public NormalizedPreTaxIncomeIncomeStatement NormalizedPreTaxIncome => new(_time, _securityIdentifier);

        /// <summary>
        /// The aggregate amount of research and development expenses during the year. It is a supplemental value which would be reported outside consolidated statements.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20442
        /// </remarks>
        [JsonProperty("20442")]
        public ResearchAndDevelopmentExpensesSupplementalIncomeStatement ResearchAndDevelopmentExpensesSupplemental => new(_time, _securityIdentifier);

        /// <summary>
        /// The current period expense charged against earnings on tangible asset over its useful life. It is a supplemental value which would be reported outside consolidated statements.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20443
        /// </remarks>
        [JsonProperty("20443")]
        public DepreciationSupplementalIncomeStatement DepreciationSupplemental => new(_time, _securityIdentifier);

        /// <summary>
        /// The current period expense charged against earnings on intangible asset over its useful life. It is a supplemental value which would be reported outside consolidated statements.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20444
        /// </remarks>
        [JsonProperty("20444")]
        public AmortizationSupplementalIncomeStatement AmortizationSupplemental => new(_time, _securityIdentifier);

        /// <summary>
        /// Total revenue as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20445
        /// </remarks>
        [JsonProperty("20445")]
        public TotalRevenueAsReportedIncomeStatement TotalRevenueAsReported => new(_time, _securityIdentifier);

        /// <summary>
        /// Operating expense as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20446
        /// </remarks>
        [JsonProperty("20446")]
        public OperatingExpenseAsReportedIncomeStatement OperatingExpenseAsReported => new(_time, _securityIdentifier);

        /// <summary>
        /// Earnings adjusted for items that are irregular or unusual in nature, and/or are non-recurring. This can be used to fairly measure a company's profitability. This is as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20447
        /// </remarks>
        [JsonProperty("20447")]
        public NormalizedIncomeAsReportedIncomeStatement NormalizedIncomeAsReported => new(_time, _securityIdentifier);

        /// <summary>
        /// EBITDA less Total Unusual Items. This is as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20448
        /// </remarks>
        [JsonProperty("20448")]
        public NormalizedEBITDAAsReportedIncomeStatement NormalizedEBITDAAsReported => new(_time, _securityIdentifier);

        /// <summary>
        /// EBIT less Total Unusual Items. This is as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20449
        /// </remarks>
        [JsonProperty("20449")]
        public NormalizedEBITAsReportedIncomeStatement NormalizedEBITAsReported => new(_time, _securityIdentifier);

        /// <summary>
        /// Operating profit adjusted for items that are irregular or unusual in nature, and/or are non-recurring. This can be used to fairly measure a company's profitability. This is as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20450
        /// </remarks>
        [JsonProperty("20450")]
        public NormalizedOperatingProfitAsReportedIncomeStatement NormalizedOperatingProfitAsReported => new(_time, _securityIdentifier);

        /// <summary>
        /// The average tax rate for the period as reported by the company, may be the same or not the same as Morningstar's standardized definition.
        /// </summary>
        /// <remarks>
        /// Morningstar DataId: 20451
        /// </remarks>
        [JsonProperty("20451")]
        public EffectiveTaxRateAsReportedIncomeStatement EffectiveTaxRateAsReported => new(_time, _securityIdentifier);

        private readonly DateTime _time;
        private readonly SecurityIdentifier _securityIdentifier;

        /// <summary>
        /// Creates a new instance for the given time and security
        /// </summary>
        public IncomeStatement(DateTime time, SecurityIdentifier securityIdentifier)
        {
            _time = time;
            _securityIdentifier = securityIdentifier;
        }
    }
}
