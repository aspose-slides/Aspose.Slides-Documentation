---
title: 在 PHP 中将演示文稿导出为 XAML
linktitle: 演示文稿到 XAML
type: docs
weight: 30
url: /zh/php-java/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出 演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- PowerPoint 到 XAML
- OpenDocument 到 XAML
- 演示文稿 到 XAML
- PPT 到 XAML
- PPTX 到 XAML
- ODP 到 XAML
- 将 PPT 保存为 XAML
- 将 PPTX 保存为 XAML
- 将 ODP 保存为 XAML
- 导出 PPT 为 XAML
- 导出 PPTX 为 XAML
- 导出 ODP 为 XAML
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML — 快速、无 Office 的解决方案，保持布局完整。"
---

## **导出演示文稿为 XAML**

{{% alert color="primary" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/)，我们实现了对 XAML 导出的支持。现在您可以将演示文稿导出为 XAML。

{{% /alert %}} 

## **关于 XAML**

XAML 是一种描述性编程语言，可用于构建或编写应用程序的用户界面，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的应用程序。  

XAML 是基于 XML 的语言，是微软用于描述 GUI 的变体。您通常会使用设计器来处理 XAML 文件，但仍然可以手动编写和编辑 GUI。 

## **使用默认选项导出演示文稿为 XAML**

此 PHP 代码展示了如何使用默认设置将演示文稿导出为 XAML：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **使用自定义选项导出演示文稿为 XAML**

您可以从 [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) 类中选择选项，以控制导出过程并决定 Aspose.Slides 如何将演示文稿导出为 XAML。

例如，如果希望 Aspose.Slides 在导出为 XAML 时包含演示文稿中的隐藏幻灯片，可以使用 [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) 方法并将值设为 `true`。请参阅以下示例 PHP 代码：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**如何确保在机器上不存在原始字体时使用可预测的字体？**

在 [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) 中设置 [默认常规字体](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) — 当原始字体缺失时，它将作为后备字体使用，从而避免意外的字体替换。

**导出的 XAML 仅适用于 WPF 吗，还是也可以在其他 XAML 体系中使用？**

XAML 是一种通用的 UI 标记语言，适用于 WPF、UWP 和 Xamarin.Forms。导出目标与 Microsoft 的 XAML 体系兼容；具体行为和对特定结构的支持取决于目标平台。请在您的环境中测试生成的标记。

**是否支持隐藏幻灯片，如何默认阻止导出它们？**

默认情况下，隐藏幻灯片不会被包含。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) 来控制此行为——如果不需要导出隐藏幻灯片，请保持该选项为禁用状态。