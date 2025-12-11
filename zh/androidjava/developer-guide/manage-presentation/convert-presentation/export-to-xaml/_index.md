---
title: 在 Android 上将演示文稿导出为 XAML
linktitle: 演示文稿到 XAML
type: docs
weight: 30
url: /zh/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无需 Office 的解决方案，保持布局完整。"
---

## **导出演示文稿为 XAML**

{{% alert color="primary" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/) 中，我们实现了对 XAML 导出的支持。现在您可以将演示文稿导出为 XAML。

{{% /alert %}} 

## **关于 XAML**

XAML 是一种描述性编程语言，可帮助您为应用程序构建或编写用户界面，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的应用程序。

XAML 基于 XML，是 Microsoft 用于描述 GUI 的变体。您通常会使用设计器来处理 XAML 文件，但仍然可以手动编写和编辑 GUI。

## **使用默认选项导出演示文稿为 XAML**

以下 Java 代码示例展示了如何使用默认设置将演示文稿导出为 XAML：
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **使用自定义选项导出演示文稿为 XAML**

您可以从 [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) 接口中选择选项，以控制导出过程并决定 Aspose.Slides 如何将演示文稿导出为 XAML。

例如，如果希望在导出为 XAML 时让 Aspose.Slides 包含演示文稿中的隐藏幻灯片，可以将 [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) 属性设置为 true。请参阅以下 Java 示例代码：
```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


## **常见问题**

**如果原始字体在机器上不可用，如何确保使用可预测的字体？**

在 [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) 中设置 [默认普通字体](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-)，当原始字体缺失时会使用该字体作为回退。这有助于避免意外的字体替换。

**导出的 XAML 仅适用于 WPF 吗？还是可以在其他 XAML 体系中使用？**

XAML 是一种通用的 UI 标记语言，适用于 WPF、UWP 和 Xamarin.Forms。导出旨在兼容 Microsoft 的 XAML 体系；具体行为和对特定结构的支持取决于目标平台。请在您的环境中测试生成的标记。

**是否支持隐藏幻灯片？如何默认阻止导出它们？**

默认情况下，隐藏幻灯片不会被包含。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 来控制此行为——如果不需要导出隐藏幻灯片，请保持该属性为禁用状态。