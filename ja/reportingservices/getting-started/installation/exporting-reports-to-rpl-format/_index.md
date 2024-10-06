---  
title: RPL形式でのレポートのエクスポート  
type: docs  
weight: 110  
url: /ja/reportingservices/exporting-reports-to-rpl-format/  
---  

﻿  

{{% alert color="primary" %}}  

Aspose.Slidesは、レンダリングにRPL（レポート処理言語）形式のレポートを使用します。このページでは、レポートをRPL形式にエクスポートする方法を示します﻿。  

{{% /alert %}}  

多くのシナリオでは、顧客は問題解決のためにAsposeのスタッフと問題を含むレポートを共有する必要があります。共有されるレポートがRDL形式の場合、データセットやスキーマも共有されるため、問題を再現できます。時には、データセットと共にRDLレポートを共有するだけでは、問題を完全に解決するには不十分な場合があります。そのような場合には、レポートをRPL形式にエクスポートし、RPLファイルを私たちと共有することをお勧めします。RPLファイルには使用されているデータセットも含まれています。これにより、RPLへのエクスポートが容易になり、即座に私たちと共有できます。  

以下の手順を実行してください：  

1. Aspose.ReportingServices.Debug.Rpl.dllをReporting servicesのbinディレクトリ（通常はc:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin）にコピーします。  

{{% alert color="primary" %}}  

Aspose.ReportingServices.Debug.Rpl.dllは、最新のAspose.Slides for Reporting Servicesのバージョンで利用可能で、[リリースページ](https://releases.aspose.com/slides/reportingservices/)からダウンロードできます。  

{{% /alert %}}  

2. **rsreportserver.config**ファイルの**<Render>**タグにこの拡張機能を追加します（通常はc:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config）。  

``` xml  
  
//<Render>要素にこのタグを追加します  

   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >  
	  </Extension>  

```  

3. 生成されたRPLファイルのパスを指定するために、パス要素を変更します。  

4. Aspose.ReportingServices.Debug.Rpl.dllに次のように実行権限を付与します：C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.configを開き、外側の**<CodeGroup>**要素の最後のアイテムとして以下を追加します（これは**<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="このコードグループはMyComputerコードの実行権限を付与します。">**である必要があります）：  

``` xml  
  
<CodeGroup>  
  ...  
  <CodeGroup>  
    ...  
    <!--ここから開始。-->  
				<CodeGroup class="UnionCodeGroup"  
					version="1"  
					PermissionSetName="FullTrust"  
					Name="Aspose.Rpl_Debug_for_Reporting_Services"  
					Description="私のAspose.Rpl.Debugレンダリング拡張のためのコードグループ">  
			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />  
				</CodeGroup>  
    <!--ここで終了。-->  
  </CodeGroup>  
</CodeGroup>  

```  

5. Reporting servicesを再起動します。エクスポートメニューにAspose.Rplオプションが表示されるはずです。  

「Rplエクスポート」オプションがエクスポートパネルに表示される必要があります。レポートをRPLにエクスポートし、RPLファイルを共有する必要があります。