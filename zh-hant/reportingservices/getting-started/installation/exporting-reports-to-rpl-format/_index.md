---
title: 匯出報告為 RPL 格式
type: docs
weight: 110
url: /zh-hant/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides 使用 RPL（Report Processing Language）格式的報告進行呈現。此頁面示範如何將報告匯出為 RPL 格式。
{{% /alert %}} 

在許多情況下，客戶必須將包含問題的報告分享給 Aspose 工作人員以便解決。當共享的報告為 RDL 格式時，還需要一起分享資料集或結構，以便我們重現問題。有時，即使連同資料集一起分享 RDL 報告，也無法完全解決問題。在此情況下，我們建議您將報告匯出為 RPL 格式，並將 RPL 檔案與我們分享。RPL 檔案同時包含使用的資料集。這樣即可更容易匯出為 RPL，並能即時與我們共享。

執行以下步驟：

1. 將 Aspose.ReportingServices.Debug.Rpl.dll 複製到 Reporting Services 的 bin 目錄（通常位於 c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin）。
{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll 於 Aspose.Slides for Reporting Services 的最新版本中提供，可從 [Releases page](https://releases.aspose.com/slides/zh-hant/reportingservices/) 下載。
{{% /alert %}} 
2. 將此擴充功能新增至 **<Render>** 標籤的 **rsreportserver.config** 檔案（通常位於 c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config）
``` xml



//將此標籤新增至 <Render> 元素 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```
3. 透過修改 path 元素來指定產生的 RPL 檔案路徑。
4. 以以下方式授予 Aspose.ReportingServices.Debug.Rpl.dll 執行權限：開啟 C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config，並將此項目新增為第二層外部 **<CodeGroup>** 元素的最後一項（應為 **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">**）：
``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--此處開始。-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--此處結束。-->

  </CodeGroup>

</CodeGroup>


```
5. 重新啟動 Reporting Services。您應該能在匯出功能表中找到 Aspose.Rpl 選項。

「Rpl export」選項會出現在匯出面板上。您需要將報告匯出為 RPL 並分享該 RPL 檔案。