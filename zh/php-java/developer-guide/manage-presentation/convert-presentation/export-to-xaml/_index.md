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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML — 快速、无需 Office 的解决方案，保持布局完整。"
---

## **导出演示文稿为 XAML**

{{% alert color="primary" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/) 中，我们实现了对 XAML 导出的支持。您现在可以将演示文稿导出为 XAML。

{{% /alert %}} 

## **关于 XAML**

XAML 是一种描述性编程语言，允许您为应用程序构建或编写用户界面，尤其是那些使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的应用程序。  

XAML 基于 XML，是 Microsoft 用于描述 GUI 的变体。您大多数时候可能会使用设计器来处理 XAML 文件，但仍然可以手动编写和编辑 GUI。

## **使用默认选项导出演示文稿为 XAML**

以下 PHP 代码演示如何使用默认设置将演示文稿导出为 XAML：
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

您可以从 [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions) 接口中选择控制导出过程的选项，以决定 Aspose.Slides 如何将演示文稿导出为 XAML。

例如，如果您希望在导出为 XAML 时让 Aspose.Slides 添加演示文稿中的隐藏幻灯片，可以将 [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) 属性设为 true。请参阅以下示例 PHP 代码：
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


## **FAQ**

**如何在原始字体在机器上不可用时确保使用可预测的字体？**

在 [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) 中设置 [默认常规字体](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont)——当原始字体缺失时，它将作为回退字体使用。这有助于避免意外的替代。

**导出的 XAML 仅针对 WPF，还是可以在其他 XAML 堆栈中使用？**

XAML 是一种通用的 UI 标记语言，适用于 WPF、UWP 和 Xamarin.Forms。导出针对 Microsoft XAML 堆栈的兼容性；具体行为和对特定构造的支持取决于目标平台。请在您的环境中测试该标记。

**是否支持隐藏幻灯片，如何默认防止它们被导出？**

默认情况下，不会包含隐藏幻灯片。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) 中的 [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) 来控制此行为——如果不需要导出隐藏幻灯片，请保持其禁用。