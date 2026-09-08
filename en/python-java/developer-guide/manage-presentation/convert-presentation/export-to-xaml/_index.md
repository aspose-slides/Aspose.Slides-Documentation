---
title: Export Presentations to XAML in Python via Java
linktitle: Presentation to XAML
type: docs
weight: 30
url: /python-java/export-to-xaml/
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
- Python
- Java
- Aspose.Slides
description: "Export PowerPoint and OpenDocument presentations to XAML with Aspose.Slides for Python via Java. Use default options or include hidden slides."
---

## **Overview**

This article explains how to export PowerPoint and OpenDocument presentations to XAML using Aspose.Slides for Python via Java. It introduces XAML, shows how to export with default settings, and demonstrates how to include hidden slides with [XamlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/).

The examples require Aspose.Slides for Python via Java and a compatible Java runtime. Place `pres.pptx` in the current working directory. Each example starts the JVM only if it is not already running.

## **About XAML**

XAML (Extensible Application Markup Language) is an XML-based language for describing user interfaces. It is used by frameworks such as Windows Presentation Foundation (WPF). You can create and edit XAML with a visual designer or a text editor.

## **Export Presentations to XAML with Default Options**

Create a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) from the input file, then pass [XamlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/) to [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) to export with default settings:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Export Presentations to XAML with Custom Options**

Use [XamlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/) to configure the export. To include hidden slides, call [setExportHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) with `True` before saving:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **FAQ**

**How can I choose a fallback font when the original font is unavailable?**

Use [setDefaultRegularFont](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) on your [XamlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/) object to specify a fallback font. Make sure the selected font is available in the export environment.

**Can I use the exported markup in any XAML framework?**

XAML frameworks differ in their supported elements and features. Test the exported markup in your target framework before integrating it into an application.

**Are hidden slides exported by default?**

No. To include them, call [setExportHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) with `True`. Keep it set to `False` to exclude them.
