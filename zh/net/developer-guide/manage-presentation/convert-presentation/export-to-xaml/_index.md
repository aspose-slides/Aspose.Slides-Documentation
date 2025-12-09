---
title: 在 .NET 中将演示文稿导出为 XAML
linktitle: 演示文稿转 XAML
type: docs
weight: 30
url: /zh/net/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出 演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- PowerPoint 转 XAML
- OpenDocument 转 XAML
- 演示文稿 转 XAML
- PPT 转 XAML
- PPTX 转 XAML
- ODP 转 XAML
- 将 PPT 保存为 XAML
- 将 PPTX 保存为 XAML
- 将 ODP 保存为 XAML
- 导出 PPT 为 XAML
- 导出 PPTX 为 XAML
- 导出 ODP 为 XAML
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无需 Office 的解决方案，保持布局完整。"
---

# **Exporting Presentations to XAML**

{{% alert title="Info" color="info" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/) 中，我们实现了对 XAML 导出的支持。现在您可以将演示文稿导出为 XAML。 

{{% /alert %}} 

# **About XAML**

XAML 是一种描述性编程语言，可用于构建或编写应用程序的用户界面，特别是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的应用程序。  

XAML 基于 XML，是微软用于描述 GUI 的变体。大多数情况下您可能会使用设计器来处理 XAML 文件，但仍然可以手动编写和编辑 GUI。 

## **Exporting Presentations to XAML With Default Options**

下面的 C# 代码演示了如何使用默认设置将演示文稿导出为 XAML：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **Exporting Presentations to XAML With Custom Options**

您可以从 [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) 接口中选择影响导出过程的选项，以决定 Aspose.Slides 如何将演示文稿导出为 XAML。 

例如，如果希望 Aspose.Slides 在导出为 XAML 时添加演示文稿中的隐藏幻灯片，可以将 [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) 属性设为 true。以下是相应的 C# 示例代码： 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**How can I ensure predictable fonts if the original font is not available on the machine?**

在 [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) 中设置 [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) —— 当原始字体缺失时，它会作为回退字体使用，从而避免意外的字体替换。

**Is the exported XAML intended only for WPF, or can it be used in other XAML stacks as well?**

XAML 是一种通用的 UI 标记语言，适用于 WPF、UWP 和 Xamarin.Forms。导出主要面向 Microsoft XAML 堆栈的兼容性；具体行为和对特定构造的支持取决于目标平台。请在您的环境中测试生成的标记。

**Are hidden slides supported, and how can I prevent them from being exported by default?**

默认情况下，隐藏幻灯片不会被包含。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) 中的 [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 属性来控制此行为——如果不需要导出隐藏幻灯片，请保持该属性禁用。