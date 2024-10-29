---
title: 扩展 Aspose.Slides for RS 以自定义渲染结果
type: docs
weight: 10
url: /zh/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---

{{% alert color="primary" %}}

本页面描述了如何为 Aspose.Slides for RS 创建扩展。

- [创建扩展程序集](/slides/zh/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/)。
- [集成扩展](/slides/zh/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/)。

{{% /alert %}}

自定义扩展功能使您可以在报告导出期间添加额外元素或更新现有元素。
## **如何创建扩展程序集**
1. 创建 .NET 项目并添加对 Aspose.Slides.ReportingServices.dll 的引用。
1. 添加一个类并从 Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase 继承。
1. 重写类的虚方法以添加自定义功能。
### **示例**
假设我们想要为每个用 Aspose.Slides for RS 导出的报告添加一个带有一些文本、一个徽标并更新公司名称的备注。

为此，我们添加以下类：

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//为第一张幻灯片添加备注

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("これはAspose.Slides for ReportingServicesのレンダリング拡張のデモです", 

textFormat);

}

//在每张幻灯片的右下角显示徽标

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//在报告中提到公司名称的地方添加 (TM)

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

构建它，您将得到扩展程序集。我们已准备好集成该扩展。

{{% /alert %}}

[RenderingExtensionDemo.zip 的 Visual Studio 项目](attachments/10289195/10452998.zip)
### **集成扩展**
假设您的程序集名为 **TestSlidesRenderingExtension.dll**：

- 将程序集复制到 ReportingService **bin** 目录，和 Aspose.Slides.ReportingServices.dll 放在一起。(例如：c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- 通过将以下 CodeGroup 添加到 **rssrvpolicy.config** 来授予您的程序集 FullTrust 权限：

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="此代码组授予 MyComputer 代码执行权限。 ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="此代码组授予 Aspose.Slides for Reporting Services 渲染扩展完全信任。">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

更新 **rsreportserver.config** 的 Aspose.Slides 渲染扩展配置部分以包含您的扩展。

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

如果您希望对 Aspose.Slides 支持的每种输出类型使用该扩展，请将相同的配置添加到名为 ASPPTX、ASPPT、ASPPS、ASPPSX 的扩展中。
Extension 标签的内容是该类型的程序集限定名称。(请参见 <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

现在重启 Reporting Services 并导出报告。您将从 Adventureworks 示例的 Company Sales SQL2008R2 报告中得到类似于 [此演示文稿](attachments/10289195/10452997.pptx) 的内容。