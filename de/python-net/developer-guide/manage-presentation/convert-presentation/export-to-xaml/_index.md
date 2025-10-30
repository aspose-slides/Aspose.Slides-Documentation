---
title: Export Präsentationen nach XAML mit Python
linktitle: Export nach XAML
type: docs
weight: 30
url: /de/python-net/export-to-xaml/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- PowerPoint zu XAML
- OpenDocument zu XAML
- Präsentation zu XAML
- PPT zu XAML
- PPTX zu XAML
- ODP zu XAML
- Python
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Folien in Python mit Aspose.Slides in XAML konvertieren – schnelle, Office‑freie Lösung, die Ihr Layout beibehält."
---

## **Übersicht**

{{% alert title="Info" color="info" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/), haben wir die Unterstützung für den XAML‑Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren. 

{{% /alert %}} 

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, das eine XML‑basierte Sprache ist, ist Microsofts Variante zur Beschreibung einer GUI. Sie verwenden wahrscheinlich die meiste Zeit einen Designer, um an XAML‑Dateien zu arbeiten, können aber dennoch Ihre GUI schreiben und bearbeiten. 

## **Präsentationen mit Standardoptionen nach XAML exportieren**

Dieser Python‑Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Sie können Optionen aus dem [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/)‑Interface auswählen, die den Exportprozess steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Zum Beispiel, wenn Aspose.Slides beim Export nach XAML versteckte Folien aus Ihrer Präsentation hinzufügen soll, können Sie die Eigenschaft [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) auf true setzen. Siehe diesen Beispiel‑Python‑Code: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart auf dem Rechner nicht verfügbar ist?**

Setzen Sie [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) in [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — er wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Das hilft, unerwartete Substitutionen zu vermeiden.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft‑XAML‑Stacks ab; das genaue Verhalten und die Unterstützung spezieller Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht eingeschlossen. Sie können dieses Verhalten über [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) steuern — deaktivieren Sie es, wenn Sie sie nicht exportieren möchten.