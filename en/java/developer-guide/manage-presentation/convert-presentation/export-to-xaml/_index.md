---
title: Export Presentations to XAML in Java
linktitle: Presentation to XAML
type: docs
weight: 30
url: /java/export-to-xaml/
keywords:
- export PowerPoint
- export OpenDocument
- export presentation
- convert PowerPoint
- convert OpenDocument
- convert presentation
- PowerPoint to XAML
- OpenDocument to XAML
- presentation to XAML
- PPT to XAML
- PPTX to XAML
- ODP to XAML
- save PPT as XAML
- save PPTX as XAML
- save ODP as XAML
- export PPT to XAML
- export PPTX to XAML
- export ODP to XAML
- Java
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument slides to XAML in Java using Aspose.Slides—quick, Office-free solution that keeps your layout intact."
---

## **Export Presentations to XAML**

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-6-release-notes/), we implemented support for XAML export. You can now export your presentations to XAML. 

{{% /alert %}} 

## **About XAML**

XAML is a descriptive programming language that allows you to build or write user interfaces for apps, especially those that use WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), and Xamarin forms.  

XAML, which is an XML-based language, is Microsoft’s variant for describing a GUI. You are likely to use a designer to work on XAML files most of the time, but you can still write and edit your GUI. 

## **Export Presentations to XAML with Default Options**

This Java code shows you how to export a presentation to XAML with default settings:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Export Presentations to XAML with Custom Options**

You get to select options from the [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions) interface that control the export process and determine how Aspose.Slides exports your presentation to XAML. 

For example, if you want Aspose.Slides to add hidden slides from your presentation when exporting it to XAML, you can set the [ExportHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) property to true. See this sample Java code: 

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

## **FAQ**

**How can I ensure predictable fonts if the original font is not available on the machine?**

Set [a default regular font](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/xamloptions/) — it is used as a fallback font when the original is missing. This helps avoid unexpected substitutions.

**Is the exported XAML intended only for WPF, or can it be used in other XAML stacks as well?**

XAML is a general UI markup language used in WPF, UWP, and Xamarin.Forms. The export targets compatibility with Microsoft XAML stacks; the exact behavior and support for specific constructs depend on the target platform. Test the markup in your environment.

**Are hidden slides supported, and how can I prevent them from being exported by default?**

By default, hidden slides are not included. You can control this behavior via [setExportHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/xamloptions/) — keep it disabled if you do not need to export them.
