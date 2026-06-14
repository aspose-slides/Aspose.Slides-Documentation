---
title: 透過擴充 Aspose.Slides for RS 來自訂渲染結果
type: docs
weight: 10
url: /zh-hant/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

此頁面說明如何為 Aspose.Slides for RS 建立擴充功能。

- [建立擴充組件](/slides/zh-hant/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [整合擴充功能](/slides/zh-hant/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

自訂擴充功能讓您可以在報表匯出期間新增額外元素或更新現有元素。

## **如何建立擴充組件**
1. 建立 .NET 專案，並加入對 Aspose.Slides.ReportingServices.dll 的參考。
1. 新增一個類別，並繼承 Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase。
1. 覆寫類別的虛擬方法，以加入自訂功能。

### **範例**
假設我們想為每個使用 Aspose.Slides for RS 匯出的報表加入帶有文字的備註、徽標，並更新公司名稱。

為此，我們加入以下類別：

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//在第一張投影片加入備註

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//在每張投影片的右下角顯示標誌

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//在報表中任何公司名稱的提及後加入 (TM)

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

建置它後即可取得擴充組件。我們已準備好整合此擴充功能。

{{% /alert %}} 

[RenderingExtensionDemo.zip 的 Visual Studio 專案](attachments/10289195/10452998.zip)

### **整合擴充功能**
假設您的組件名稱為 **TestSlidesRenderingExtension.dll**：

- 將組件複製到 ReportingService **bin** 目錄，與 Aspose.Slides.ReportingServices.dll 置於同一位置。（例如：c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin）
- 透過將以下 CodeGroup 新增至 **rssrvpolicy.config**，授予您的組件 FullTrust 權限：

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="This code group grants full trust to the Aspose.Slides for Reporting Services Rendering extension.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

更新 **rsreportserver.config** 中 Aspose.Slides 呈現擴充功能的設定區段，以納入您的擴充功能。

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

如果您想將此擴充功能用於 Aspose.Slides 支援的所有輸出類型，請將相同的設定新增至名稱為 ASPPTX、ASPPT、ASPPS、ASPPSX 的擴充功能中。  
Extension 標籤的內容是型別的組件限定名稱。（參見 <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>）

現在重新啟動 Reporting Services 並匯出報表。您將得到類似 [此簡報](attachments/10289195/10452997.pptx) 的結果，來源為 Adventureworks 範例的 Company Sales SQL2008R2 報表。