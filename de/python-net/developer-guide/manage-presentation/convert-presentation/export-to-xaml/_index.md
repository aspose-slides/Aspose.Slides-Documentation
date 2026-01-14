---
title: Präsentationen nach XAML mit Python exportieren
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
- PowerPoint nach XAML
- OpenDocument nach XAML
- Präsentation nach XAML
- PPT nach XAML
- PPTX nach XAML
- ODP nach XAML
- Python
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien in XAML mit Python und Aspose.Slides - eine schnelle, Office-freie Lösung, die Ihr Layout unverändert beibehält."
---

## **Übersicht**

{{% alert title="Info" color="info" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/) haben wir die Unterstützung für den XAML‑Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren. 

{{% /alert %}} 

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, eine XML‑basierte Sprache, ist Microsofts Variante zur Beschreibung einer GUI. Sie arbeiten wahrscheinlich die meiste Zeit mit einem Designer an XAML‑Dateien, können aber dennoch Ihre GUI schreiben und bearbeiten. 

## **Präsentationen mit den Standardeinstellungen nach XAML exportieren**

Dieser Python‑Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Sie können Optionen aus der [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/)‑Klasse auswählen, die den Exportvorgang steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Zum Beispiel, wenn Sie möchten, dass Aspose.Slides beim Export nach XAML versteckte Folien aus Ihrer Präsentation hinzufügt, können Sie die Eigenschaft [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) auf `True` setzen. Siehe diesen Beispiel‑Python‑Code: 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart auf dem System nicht verfügbar ist?**

Setzen Sie [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) in [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) – sie wird als Ausweichschriftart verwendet, wenn die Originalschriftart fehlt. Das hilft, unerwartete Ersetzungen zu vermeiden.

**Ist das exportierte XAML nur für WPF gedacht, oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft‑XAML‑Stacks ab; das genaue Verhalten und die Unterstützung spezifischer Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) steuern – deaktivieren Sie die Option, wenn Sie sie nicht exportieren möchten.