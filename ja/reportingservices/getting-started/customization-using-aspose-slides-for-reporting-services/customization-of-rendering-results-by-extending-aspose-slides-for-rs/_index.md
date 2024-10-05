---
title: Aspose.Slides for RSのレンダリング結果のカスタマイズ
type: docs
weight: 10
url: /reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for RSの拡張機能を作成する方法について説明します。

- [拡張アセンブリを作成する](/slides/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/)。
- [拡張機能を統合する](/slides/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/)。

{{% /alert %}} 

カスタム拡張機能は、レポートのエクスポート中に追加の要素を追加したり、既存の要素を更新したりするオプションを提供します。
## **拡張アセンブリの作成方法**
1. .NETプロジェクトを作成し、Aspose.Slides.ReportingServices.dllへの参照を追加します。
1. クラスを追加し、Aspose.Slides.ReportingServices.Extension.RenderingExtensionBaseを継承します。
1. カスタム機能を追加するために、クラスの仮想メソッドをオーバーライドします。
### **例**
Aspose.Slides for RSでエクスポートされたすべてのレポートに対して、テキスト、ロゴ、会社名を更新するノートを追加したいとします。

そのために、次のクラスを追加します：

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//最初のスライドにノートを追加

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("これはAspose.Slides for ReportingServicesのレンダリング拡張のデモです",

textFormat);

}

//すべてのスライドの右下隅にロゴを表示

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//レポート内の会社名のいずれかの言及に(TM)を追加

string companyName = "Adventure Works";

if (textBox.Text.Contains(companyName))

{

textBox.Text = textBox.Text.Replace(companyName, companyName + "™");

}

base.PostProcessTextBox(textBox);

}

}

```

{{% alert color="primary" %}} 

ビルドすると、拡張アセンブリが作成されます。拡張機能を統合する準備が整いました。

{{% /alert %}} 

[RenderingExtensionDemo.zipのVisual Studioプロジェクト](attachments/10289195/10452998.zip)
### **拡張機能の統合**
あなたのアセンブリが**TestSlidesRenderingExtension.dll**と呼ばれていると仮定します：

- アセンブリをAspose.Slides.ReportingServices.dllの隣のReportingService **bin**ディレクトリにコピーします。（例：c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin）
- 次のCodeGroupを**rssrvpolicy.config**に追加して、アセンブリにFullTrust権限を付与します：

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" /> 

... 

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="このコードグループはMyComputerコードの実行権限を付与します。">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" /> 

... 

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="このコードグループはAspose.Slides for Reporting Services Rendering拡張へのフルトラストを付与します。">

<IMembershipCondition class="UrlMembershipCondition" version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" /> 

</CodeGroup> 

</CodeGroup> 

</CodeGroup> 

```

**rsreportserver.config**のAspose.Slidesレンダリング拡張の設定セクションを更新して、拡張機能を含めます。

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Aspose.Slidesがサポートするすべての出力タイプに対して拡張機能を使用したい場合は、ASPPTX、ASPPT、ASPPS、ASPPSXの名前を持つ拡張機能に同じ設定を追加します。
Extensionタグの内容は、その型のアセンブリ完全修飾名です。（詳細は<https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>を参照してください）

Reporting Servicesを再起動し、レポートをエクスポートします。AdventureworksサンプルのCompany Sales SQL2008R2レポートから[このプレゼンテーション](attachments/10289195/10452997.pptx)のようなものが得られます。