---
title: 使用 Python 将演示文稿导出为 XAML
linktitle: 导出为 XAML
type: docs
weight: 30
url: /zh/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: 使用 Aspose.Slides 在 Python 中将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无 Office 的解决方案，保持布局完整。
---

## **概述**

{{% alert title="Info" color="info" %}} 
在 Aspose.Slides 21.6 中，我们实现了对 XAML 导出的支持。您现在可以将演示文稿导出为 XAML。 
{{% /alert %}} 

XAML 是一种描述性编程语言，可用于构建或编写应用程序的用户界面，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的应用。  

XAML 是基于 XML 的语言，是 Microsoft 用于描述 GUI 的变体。您大多会使用设计器来处理 XAML 文件，但仍然可以手动编写和编辑 GUI。 

## **使用默认选项将演示文稿导出为 XAML**

以下 Python 代码展示了如何使用默认设置将演示文稿导出为 XAML：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **使用自定义选项将演示文稿导出为 XAML**

您可以从 [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) 接口中选择选项，以控制导出过程并决定 Aspose.Slides 如何将您的演示文稿导出为 XAML。  

例如，如果您希望 Aspose.Slides 在导出为 XAML 时包含演示文稿中的隐藏幻灯片，可以将 [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) 属性设为 true。请参见以下 Python 示例代码： 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **常见问题**

**如果原始字体在机器上不可用，如何确保字体保持一致？**

在 XamlOptions 中设置 `default_regular_font` —— 当原始字体缺失时，它会作为回退字体使用。这有助于避免意外的字体替换。

**导出的 XAML 仅适用于 WPF，还是也可以在其他 XAML 框架中使用？**

XAML 是在 WPF、UWP 和 Xamarin.Forms 中使用的通用 UI 标记语言。导出旨在兼容 Microsoft 的 XAML 框架；具体行为和对特定构造的支持取决于目标平台。请在您的环境中测试该标记。

**是否支持隐藏幻灯片，如何默认防止其导出？**

默认情况下，隐藏幻灯片不会被包含。您可以通过 `export_hidden_slides` 在 XamlOptions 中控制此行为——如果不需要导出隐藏幻灯片，请保持其禁用状态。