---
title: Export to XAML
type: docs
weight: 30
url: /net/export-to-xaml/

---

# Exporting Presentations to XAML

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), we implemented support for XAML export. You can now export your presentations to XAML. 

{{% /alert %}} 

# About XAML

XAML is a descriptive programming language that allows you to build or write user interfaces for apps, especially those that use WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), and Xamarin forms.  

XAML, which is an XML-based language, is Microsoft’s variant for describing a GUI. You are likely to use a designer to work on XAML files most of the time, but you can still write and edit your GUI. 

## Exporting Presentations to XAML With Default Options

This C# code shows you how to export a presentation to XAML with default settings:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## Exporting Presentations to XAML With Custom Options

You get to select options from the [IXamlOptions](https://apireference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) interface that control the export process and determine how Aspose.Slides exports your presentation to XAML. 

For example, if you want Aspose.Slides to add hidden slides from your presentation when exporting it to XAML, you can set the [ExportHiddenSlides](https://apireference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) property to true. See this sample C# code: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```