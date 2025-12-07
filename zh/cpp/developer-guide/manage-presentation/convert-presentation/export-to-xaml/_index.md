---
title: 导出演示文稿为 XAML（C++）
linktitle: 演示文稿到 XAML
type: docs
weight: 30
url: /zh/cpp/export-to-xaml/
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
- 将 PPT 保存为 XAML
- 将 PPTX 保存为 XAML
- 将 ODP 保存为 XAML
- 导出 PPT 为 XAML
- 导出 PPTX 为 XAML
- 导出 ODP 为 XAML
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 幻灯片转换为 C++ 中的 XAML——快速、无 Office 的解决方案，保持原有布局完整。"
---

## **将演示文稿导出为 XAML**

{{% alert color="primary" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/) 中，我们实现了对 XAML 导出的支持。您现在可以将演示文稿导出为 XAML。 

{{% /alert %}} 

## **关于 XAML**

XAML 是一种描述性编程语言，允许您为应用程序构建或编写用户界面，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的应用程序。  

XAML 是基于 XML 的语言，是 Microsoft 用于描述 GUI 的变体。大多数情况下您可能会使用设计器来处理 XAML 文件，但仍然可以手动编写和编辑 GUI。 

## **使用默认选项将演示文稿导出为 XAML**

下面的 C++ 代码演示了如何使用默认设置将演示文稿导出为 XAML：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **使用自定义选项将演示文稿导出为 XAML**

您可以从 [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) 接口中选择控制导出过程的选项，从而决定 Aspose.Slides 如何将演示文稿导出为 XAML。 

例如，如果希望 Aspose.Slides 在导出为 XAML 时包含演示文稿中的隐藏幻灯片，可以将 `true` 传递给 [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) 方法。参见以下示例 C++ 代码： 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **常见问题**

**如果原始字体在机器上不可用，如何确保使用可预测的字体？**

在 [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) 中使用 [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/)，它在原始字体缺失时作为回退字体使用，可帮助避免意外的替换。

**导出的 XAML 仅用于 WPF，还是也可以在其他 XAML 框架中使用？**

XAML 是一种通用的 UI 标记语言，适用于 WPF、UWP 和 Xamarin.Forms。导出目标兼容 Microsoft XAML 堆栈；具体行为和对特定结构的支持取决于目标平台。请在您的环境中测试标记。

**是否支持隐藏幻灯片，如何默认阻止它们被导出？**

默认情况下，隐藏幻灯片不包含在内。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) 中使用 [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) 方法来控制此行为——如果不需要导出，请保持该选项禁用。