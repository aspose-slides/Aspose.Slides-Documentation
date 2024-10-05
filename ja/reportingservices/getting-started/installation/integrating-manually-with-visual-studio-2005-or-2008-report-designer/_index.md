---
title: Visual Studio 2005または2008レポートデザイナーとの手動統合
type: docs
weight: 50
url: /reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---

{{% alert color="primary" %}} 

この記事では、Aspose.Slides for Reporting ServicesをVisual Studioと手動で統合する方法を説明します。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

**Aspose.Slides for Reporting Services**は、ホストマシンに**.NET Framework 3.5**のインストールを必要とします。 

{{% /alert %}}

## **Visual StudioとのAspose.Slides for Reporting Servicesの統合**
Aspose.Slides for Reporting ServicesをインストールするにはMSIインストーラーを使用することをお勧めします。これにより、必要なインストールタスクと構成プロセスが自動的に実行されます。ただし、MSIインストーラーを使用したインストールが失敗した場合は、こちらのガイドを使用してください。 

この記事では、Business Intelligence Development Studioを搭載したコンピューターにAspose.Slides for Reporting Servicesをインストールする方法も示しています。これにより、Microsoft Visual Studio 2005または2008レポートデザイナーからデザイン時にMicrosoft PowerPoint形式にレポートをエクスポートできるようになります。 

1. Aspose.Slides.ReportingServices.dllをVisual Studioディレクトリにコピーします。

   - Visual Studio 2005レポートデザイナーと統合するには、**Aspose.Slides.ReportingServices.dll**を**C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**ディレクトリにコピーします。
   - Visual Studio 2008レポートデザイナーと統合するには、**Aspose.Slides.ReportingServices.dll**を**C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**ディレクトリにコピーします。
2. Aspose.Slides for Reporting Servicesをレンダリング拡張機能として登録します。 

3. **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config**を開き（<Version>はVisual Studio 2005の場合は「8」、Visual Studio 2008の場合は「9.0」）、<Render>要素にこれらの行を追加します:

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Aspose.Slides for Reporting Servicesに実行するための権限を与えます。 
   1. **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config**を開きます（<Version>はVisual Studio 2005の場合は「8」、Visual Studio 2008の場合は「9.0」）。
   1. この行を2番目の外側の<CodeGroup>要素の最後の項目として追加します（これは<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="このコードグループはMyComputerコードの実行権限を付与します。">であるべきです）

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--ここから始めます。-->

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

    <!--ここで終わります。-->

  </CodeGroup>

</CodeGroup>



```

5. Aspose.Slides for Reporting Servicesが正常にインストールされたかどうかを確認します。 
6. Microsoft Visual Studio 2005または2008レポートデザイナーを実行または再起動します。エクスポート形式のリストに新しい形式が表示されるはずです。

**新しいエクスポート形式がレポートデザイナーに表示されます。** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)