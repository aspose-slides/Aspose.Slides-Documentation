---
title: Export Presentations to XAML with Python
linktitle: Export to XAML
type: docs
weight: 30
url: /python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument slides to XAML in Python using Aspose.Slides—quick, Office-free solution that keeps your layout intact."
---

## **Overview**

{{% alert title="Info" color="info" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/), we implemented support for XAML export. You can now export your presentations to XAML. 

{{% /alert %}} 

XAML is a descriptive programming language that allows you to build or write user interfaces for apps, especially those that use WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), and Xamarin forms.  

XAML, which is an XML-based language, is Microsoft’s variant for describing a GUI. You are likely to use a designer to work on XAML files most of the time, but you can still write and edit your GUI. 

## **Export Presentations to XAML with Default Options**

This Python code shows you how to export a presentation to XAML with default settings:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Export Presentations to XAML with Custom Options**

You get to select options from the [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) class that control the export process and determine how Aspose.Slides exports your presentation to XAML. 

For example, if you want Aspose.Slides to add hidden slides from your presentation when exporting it to XAML, you can set the [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) property to `True`. See this sample Python code: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **FAQ**

**How can I ensure predictable fonts if the original font is not available on the machine?**

Set [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) in [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — it is used as a fallback font when the original is missing. This helps avoid unexpected substitutions.

**Is the exported XAML intended only for WPF, or can it be used in other XAML stacks as well?**

XAML is a general UI markup language used in WPF, UWP, and Xamarin.Forms. The export targets compatibility with Microsoft XAML stacks; the exact behavior and support for specific constructs depend on the target platform. Test the markup in your environment.

**Are hidden slides supported, and how can I prevent them from being exported by default?**

By default, hidden slides are not included. You can control this behavior via [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — keep it disabled if you do not need to export them.
