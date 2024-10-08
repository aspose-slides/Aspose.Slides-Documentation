---
title: Export nach XAML
type: docs
weight: 30
url: /de/python-net/export-to-xaml/
keywords: "Export PowerPoint-Präsentation, PowerPoint konvertieren, XAML, PowerPoint nach XAML, PPT nach XAML, PPTX nach XAML, Python"
description: "Exportieren oder Konvertieren von PowerPoint-Präsentationen nach XAML"
---

# Exportieren von Präsentationen nach XAML

{{% alert title="Info" color="info" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/) haben wir die Unterstützung für den XAML-Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren. 

{{% /alert %}} 

# Über XAML

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin-Formulare verwenden.  

XAML, eine XML-basierte Sprache, ist die Variante von Microsoft zur Beschreibung einer GUI. Wahrscheinlich verwenden Sie meistens einen Designer, um an XAML-Dateien zu arbeiten, aber Sie können Ihre GUI auch selbst schreiben und bearbeiten. 

## Exportieren von Präsentationen nach XAML mit Standardeinstellungen

Dieser Python-Code zeigt Ihnen, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## Exportieren von Präsentationen nach XAML mit benutzerdefinierten Optionen

Sie können Optionen aus der [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) Schnittstelle auswählen, die den Exportprozess steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Wenn Sie beispielsweise möchten, dass Aspose.Slides beim Export nach XAML die verborgenen Folien Ihrer Präsentation hinzufügt, können Sie die [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) Eigenschaft auf true setzen. Hier ist ein Beispiel-Python-Code: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```