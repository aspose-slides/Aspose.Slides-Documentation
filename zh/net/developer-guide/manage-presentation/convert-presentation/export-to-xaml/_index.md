---
title: 在 .NET 中将演示文稿导出为 XAML
linktitle: 演示文稿到 XAML
type: docs
weight: 30
url: /zh/net/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- PowerPoint 转 XAML
- OpenDocument 转 XAML
- 演示文稿转 XAML
- PPT 转 XAML
- PPTX 转 XAML
- ODP 转 XAML
- 保存 PPT 为 XAML
- 保存 PPTX 为 XAML
- 保存 ODP 为 XAML
- 导出 PPT 到 XAML
- 导出 PPTX 到 XAML
- 导出 ODP 到 XAML
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无需 Office 的解决方案，保持布局完整。"
---

## **将演示文稿导出为 XAML**

{{% alert title="Info" color="info" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/) 中，我们实现了对 XAML 导出的支持。现在您可以将演示文稿导出为 XAML。 

{{% /alert %}} 

## **关于 XAML**

XAML 是一种描述性编程语言，可用于为应用程序构建或编写用户界面，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的应用程序。

XAML 是基于 XML 的语言，是 Microsoft 用于描述 GUI 的变体。您在大多数情况下会使用设计器来编辑 XAML 文件，但仍然可以手动编写和编辑 GUI。

## **使用默认选项将演示文稿导出为 XAML**

下面的 C# 代码演示了如何使用默认设置将演示文稿导出为 XAML：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **使用自定义选项将演示文稿导出为 XAML**

您可以从 [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) 接口中选择控制导出过程的选项，以决定 Aspose.Slides 如何将您的演示文稿导出为 XAML。

例如，如果您希望在导出为 XAML 时让 Aspose.Slides 包含演示文稿中的隐藏幻灯片，可以将 [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) 属性设置为 true。参考以下 C# 示例代码：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**如果原始字体在机器上不可用，如何确保使用可预测的字体？**

在 [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) 中设置 [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export.saveoptions/defaultregularfont/)，当原始字体缺失时会使用该字体作为回退，从而避免意外的字体替换。

**导出的 XAML 仅用于 WPF 吗，还是可以在其他 XAML 堆栈中使用？**

XAML 是一种通用的 UI 标记语言，适用于 WPF、UWP 和 Xamarin.Forms。导出针对 Microsoft XAML 堆栈的兼容性；具体行为和对特定构造的支持取决于目标平台。请在您的环境中测试生成的标记。

**是否支持隐藏幻灯片，默认情况下如何防止它们被导出？**

默认情况下，隐藏幻灯片不会被包含。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) 中的 [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 属性来控制此行为——如果不需要导出隐藏幻灯片，请保持该属性为禁用状态。