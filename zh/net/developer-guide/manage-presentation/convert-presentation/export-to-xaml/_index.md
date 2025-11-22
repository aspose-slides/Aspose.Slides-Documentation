---
title: 导出为 XAML
type: docs
weight: 30
url: /zh/net/export-to-xaml/
keywords: "导出 PowerPoint 演示文稿, 转换 PowerPoint, XAML, PowerPoint 转 XAML, PPT 转 XAML, PPTX 转 XAML, C#, C#, .NET"
description: "将 PowerPoint 演示文稿导出或转换为 XAML"
---

# **将演示文稿导出为 XAML**

{{% alert title="Info" color="info" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/) 中，我们实现了对 XAML 导出的支持。现在您可以将演示文稿导出为 XAML。 

{{% /alert %}} 

# **关于 XAML**

XAML 是一种描述性编程语言，允许您为应用程序构建或编写用户界面，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin 表单的应用。  

XAML 基于 XML，是 Microsoft 用于描述 GUI 的变体。您大多数情况下会使用设计器来编辑 XAML 文件，但仍然可以手动编写和修改 GUI。 

## **使用默认选项将演示文稿导出为 XAML**

以下 C# 代码演示了如何使用默认设置将演示文稿导出为 XAML：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **使用自定义选项将演示文稿导出为 XAML**

您可以从 [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) 接口中选择控制导出过程的选项，以决定 Aspose.Slides 如何将演示文稿导出为 XAML。 

例如，如果您希望在导出为 XAML 时让 Aspose.Slides 包含演示文稿中的隐藏幻灯片，可以将 [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) 属性设为 true。请参阅以下示例 C# 代码： 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **常见问题**

**如果原始字体在机器上不可用，如何确保使用可预测的字体？**

在 [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) 中设置 [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/)，当原始字体缺失时，它将作为回退字体使用。这有助于避免意外的字体替换。

**导出的 XAML 只针对 WPF 吗，还是也可以用于其他 XAML 平台？**

XAML 是一种通用的 UI 标记语言，适用于 WPF、UWP 和 Xamarin.Forms。导出旨在兼容 Microsoft 的 XAML 堆栈；具体行为和对特定构造的支持取决于目标平台。请在您的环境中测试该标记。

**是否支持隐藏幻灯片，如何默认阻止它们被导出？**

默认情况下，不会包含隐藏幻灯片。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) 中的 [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 来控制此行为——如果不需要导出隐藏幻灯片，请保持该选项禁用。