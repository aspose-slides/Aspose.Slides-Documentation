---
title: 导出到 XAML
type: docs
weight: 30
url: /java/export-to-xaml/

---

# 将演示文稿导出到 XAML

{{% alert color="primary" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-6-release-notes/) 中，我们实现了对 XAML 导出的支持。现在你可以将演示文稿导出为 XAML。 

{{% /alert %}} 

# 关于 XAML

XAML 是一种描述性编程语言，允许你为应用程序构建或编写用户界面，尤其是那些使用 WPF（Windows Presentation Foundation）、UWP（通用 Windows 平台）和 Xamarin 表单的应用程序。  

XAML 是一种基于 XML 的语言，是 Microsoft 用于描述 GUI 的变体。你可能大多数时候会使用设计器来处理 XAML 文件，但你仍然可以手动编写和编辑你的 GUI。 

## 使用默认选项将演示文稿导出到 XAML

以下 Java 代码展示了如何使用默认设置将演示文稿导出到 XAML：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## 使用自定义选项将演示文稿导出到 XAML

你可以从 [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions) 接口中选择控制导出过程的选项，并确定 Aspose.Slides 如何将演示文稿导出到 XAML。 

例如，如果你希望 Aspose.Slides 在导出到 XAML 时添加演示文稿中的隐藏幻灯片，可以将 [ExportHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) 属性设置为 true。请参见以下示例 Java 代码： 

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