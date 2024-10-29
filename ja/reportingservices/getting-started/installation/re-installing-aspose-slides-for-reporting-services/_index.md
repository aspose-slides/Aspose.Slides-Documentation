---
title: Aspose.Slides for Reporting Servicesの再インストール
type: docs
weight: 40
url: /ja/reportingservices/re-installing-aspose-slides-for-reporting-services/
---

{{% alert color="primary" %}} 

この記事では、Aspose.Slides for Reporting Servicesがすでにインストールされているが、何らかの理由で再インストールが必要な状況の修正方法について説明します。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

**Aspose.Slides for Reporting Services**は、ホストマシンに**.NET Framework 3.5**のインストールを必要とします。 

{{% /alert %}}

## **Aspose.Slides for Reporting Servicesの再インストール手順**
最も重要なのは、以前のAspose.Slides for Reporting Servicesのインストールを完全に削除することです。MSIインストーラーは、Aspose.Slides for Reporting Servicesを自動的にアンインストールし、したがって再インストールするために必要な操作を正常に実行できますが、以下の手順を守る必要があります。

1. MSIインストーラーを使用してAspose.Slides for Reporting Servicesをアンインストールする。 

2. 通常、次の場所にあるAspose.Slides for Reporting Servicesのインストールディレクトリを探します：

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. MSIインストーラーがAspose.Slides for Reporting Servicesをアンインストールした際に「Aspose.Slides for Reporting Services」ディレクトリを削除していなかった場合、そのフォルダを削除します。 

4. 各SQL Server Reporting Serviceインスタンスの「bin」ディレクトリ内にある**Aspose.Slides.ReportingServices.dll**バイナリを見つけます。たとえば、Microsoft SQL Server 2008インスタンス「MSSQLSERVER」がある場合、対応するReporting Serviceの「bin」ディレクトリは次の場所にある可能性があります：

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. MSIインストーラーがAspose.Slides for Reporting Servicesをアンインストールした際に上記のディレクトリからAspose.Slides.ReportingServices.dllバイナリファイルを削除していなかった場合、今すぐそのファイルを削除します。

6. 各SSRSインスタンスの**rsreportserver.config**ファイルを見つけます。たとえば、Reporting Serviceインスタンス「**MSRS10.MSSQLSERVER**」がある場合、**rsreportserver.config**ファイルは次のディレクトリにあります：

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. 任意のエディタで**rsreportserver.config**ファイルを開き、Aspose.Slides for Reporting Servicesのインストール中にPowerPointフォーマット拡張機能を追加するために作成された行を見つけます。 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

``` 

**ステップ** **8:** MSIインストーラーがAspose.Slides for Reporting Servicesをアンインストールした際にこれらの行を削除していなかった場合、今すぐ**rsreportserver.config**ファイルから行を削除します。

**ステップ** **9:** 各SSRSインスタンスの**rssrvpolicy.config**ファイルを探します。たとえば、Reporting Serviceインスタンス「MSRS10.MSSQLSERVER」がある場合、**rssrvpolicy.config**ファイルはこのディレクトリにあります：

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**ステップ** **10:** 任意のエディタで**rssrvpolicy.config**ファイルを開き、Aspose.Slides for Reporting Servicesのインストール中に実行権限を付与するために作成された行を見つけます。

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--ここから開始します。-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="このコードグループはAS4SSRSアセンブリに完全な信頼を付与します。">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

           PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--ここで終了します。-->

  </CodeGroup>

</CodeGroup>

``` 

**ステップ** **11:** MSIインストーラーが製品をアンインストールした際に上記の行を削除していなかった場合、今すぐ**rssrvpolicy.config**ファイルからその行を削除します。 

**ステップ** **12:** Microsoft Visual StudioでRDLレポートの開発とPowerPointフォーマットへのエクスポートのためにAspose.Slides for Reporting Servicesをインストールしている場合、Microsoft Visual Studio 2008の場合の**Aspose.Slides.ReportingServices.dll**バイナリファイルと設定ファイル（**rsreportserver.config**および**rssrvpolicy.config**）は以下の通りです：

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**ステップ** **13:** MSIインストーラーが**Aspose.Slides.ReportingServices.dll**バイナリを削除していなかった場合、削除します。また、PowerPointフォーマット拡張機能とコード実行権限をそれぞれ削除するために**rsreportserver.config**および**rssrvpolicy.config**ファイルを更新していなかった場合、前の手順でファイルを削除したのと同じように手動で削除します。 

**ステップ** **14:** Aspose.Slides for Reporting Servicesを再インストールする時間です。自動インストールのためにMSIインストーラーを使用するか、手動で行ってください。