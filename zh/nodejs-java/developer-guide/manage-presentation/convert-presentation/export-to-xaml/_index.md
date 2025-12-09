---
title: 导出为 XAML
type: docs
weight: 30
url: /zh/nodejs-java/export-to-xaml/
---

## **将演示文稿导出为 XAML**

{{% alert color="primary" %}} 

在[Aspose.Slides 21.6](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-6-release-notes/)，我们实现了对 XAML 导出的支持。现在您可以将演示文稿导出为 XAML。

{{% /alert %}} 

## **关于 XAML**

XAML 是一种描述性编程语言，可帮助您为应用程序构建或编写用户类，特别是那些使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的应用程序。

XAML 是基于 XML 的语言，是 Microsoft 用于描述 GUI 的变体。您大多数情况下可能会使用设计器来处理 XAML 文件，但仍然可以手动编写和编辑 GUI。 

## **使用默认选项将演示文稿导出为 XAML**

以下 JavaScript 代码演示如何使用默认设置将演示文稿导出为 XAML：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **使用自定义选项将演示文稿导出为 XAML**

您可以从[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions)类中选择选项，以控制导出过程并决定 Aspose.Slides 如何将演示文稿导出为 XAML。

例如，如果您希望 Aspose.Slides 在导出为 XAML 时添加演示文稿中的隐藏幻灯片，可以将[setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-)方法设置为 true。请参阅以下示例 JavaScript 代码：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**如果原始字体在机器上不可用，如何确保使用可预测的字体？**

在[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)中使用[setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) —— 当原始字体缺失时，它会作为回退字体使用。这样可以避免意外的字体替换。

**导出的 XAML 仅针对 WPF，还是也可以用于其他 XAML 框架？**

XAML 是一种用于 WPF、UWP 和 Xamarin.Forms 的通用 UI 标记语言。导出旨在兼容 Microsoft 的 XAML 堆栈；具体行为及对特定结构的支持取决于目标平台。请在您的环境中测试该标记。

**是否支持隐藏幻灯片，如何防止默认导出它们？**

默认情况下，不会包含隐藏幻灯片。您可以通过在[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)中使用[setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/)来控制此行为——如果不需要导出隐藏幻灯片，请保持该选项为禁用状态。