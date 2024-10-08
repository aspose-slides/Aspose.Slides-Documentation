---
title: 导出到 XAML
type: docs
weight: 30
url: /python-net/export-to-xaml/
keywords: "导出 PowerPoint 演示文稿, 转换 PowerPoint, XAML, PowerPoint 到 XAML, PPT 到 XAML, PPTX 到 XAML, Python"
description: "导出或转换 PowerPoint 演示文稿到 XAML"
---

# 导出演示文稿到 XAML

{{% alert title="信息" color="info" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/) 中，我们实现了对 XAML 导出的支持。您现在可以将演示文稿导出为 XAML。 

{{% /alert %}} 

# 关于 XAML

XAML 是一种描述性编程语言，允许您为应用程序构建或编写用户界面，特别是那些使用 WPF（Windows Presentation Foundation）、UWP（通用 Windows 平台）和 Xamarin 表单的应用程序。  

XAML 是一种基于 XML 的语言，是微软用于描述 GUI 的变体。您可能会使用设计工具来处理 XAML 文件，但您仍然可以编写和编辑您的 GUI。 

## 使用默认选项导出演示文稿到 XAML

以下 Python 代码演示如何使用默认设置将演示文稿导出为 XAML：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## 使用自定义选项导出演示文稿到 XAML

您可以从 [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) 接口中选择控制导出过程并决定 Aspose.Slides 如何将您的演示文稿导出为 XAML 的选项。 

例如，如果您希望 Aspose.Slides 在导出到 XAML 时添加演示文稿中的隐藏幻灯片，您可以将 [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) 属性设置为 true。请参见以下示例 Python 代码： 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```