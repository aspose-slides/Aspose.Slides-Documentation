---
title: 在 JavaScript 中导出演示文稿为 XAML
linktitle: 演示文稿转 XAML
type: docs
weight: 30
url: /zh/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无 Office 的解决方案，保持布局完整。"
---

## **将演示文稿导出为 XAML**

Aspose.Slides 支持 XAML 导出。您可以将演示文稿转换为 XAML。

## **关于 XAML**

XAML 是一种描述性编程语言，可让您为应用程序构建或编写用户类，尤其是那些使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的应用程序。

XAML 是一种基于 XML 的语言，是 Microsoft 用于描述 GUI 的变体。您大多数时间可能会使用设计器来处理 XAML 文件，但仍然可以编写和编辑 GUI。

## **使用默认选项将演示文稿导出为 XAML**

以下 JavaScript 代码展示了如何使用默认设置将演示文稿导出为 XAML：
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

您可以从 [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions) 类中选择控制导出过程的选项，以决定 Aspose.Slides 如何将演示文稿导出为 XAML。

例如，如果您希望 Aspose.Slides 在导出为 XAML 时包含演示文稿中的隐藏幻灯片，可以将 [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) 方法设置为 true。请参阅以下 JavaScript 示例代码：
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


## **常见问题**

**如果原始字体在机器上不可用，如何确保字体可预测？**

在 [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) 中使用 [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) — 当原始字体缺失时，它会作为回退字体使用。这有助于避免意外的替换。

**导出的 XAML 只针对 WPF 吗，还是也可以在其他 XAML 框架中使用？**

XAML 是一种通用 UI 标记语言，可在 WPF、UWP 和 Xamarin.Forms 中使用。导出目标是兼容 Microsoft 的 XAML 堆栈；具体行为和对特定构造的支持取决于目标平台。请在您的环境中测试标记。

**是否支持隐藏幻灯片，如何防止它们默认被导出？**

默认情况下，不会包含隐藏幻灯片。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) 来控制此行为——如果不需要导出隐藏幻灯片，请保持其禁用状态。