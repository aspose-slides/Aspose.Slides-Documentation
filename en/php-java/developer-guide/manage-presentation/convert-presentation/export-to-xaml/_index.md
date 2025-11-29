---
title: Export Presentations to XAML in PHP
linktitle: Presentation to XAML
type: docs
weight: 30
url: /php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument slides to XAML using Aspose.Slides for PHP via Java — quick, Office-free solution that keeps your layout intact."
---

# Exporting Presentations to XAML

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/), we implemented support for XAML export. You can now export your presentations to XAML.

{{% /alert %}} 

# About XAML

XAML is a descriptive programming language that allows you to build or write user interfaces for apps, especially those that use WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), and Xamarin forms.  

XAML, which is an XML-based language, is Microsoft’s variant for describing a GUI. You are likely to use a designer to work on XAML files most of the time, but you can still write and edit your GUI. 

## Exporting Presentations to XAML With Default Options

This PHP code shows you how to export a presentation to XAML with default settings:

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

## Exporting Presentations to XAML With Custom Options

You get to select options from the [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions) interface that control the export process and determine how Aspose.Slides exports your presentation to XAML.

For example, if you want Aspose.Slides to add hidden slides from your presentation when exporting it to XAML, you can set the [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) property to true. See this sample PHP code:

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
