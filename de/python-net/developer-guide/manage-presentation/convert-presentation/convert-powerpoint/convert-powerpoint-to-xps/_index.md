---
title: PowerPoint-Präsentationen in XPS in Python konvertieren
linktitle: PowerPoint zu XPS
type: docs
weight: 70
url: /de/python-net/convert-powerpoint-to-xps/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PowerPoint zu XPS
- Präsentation zu XPS
- PPT zu XPS
- PPTX zu XPS
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertige, plattformunabhängige XPS in Python mit Aspose.Slides konvertieren. Erhalten Sie eine Schritt-für-Schritt-Anleitung und Beispielcode."
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht das Drucken von Inhalten, indem eine Datei erzeugt wird, die einer PDF sehr ähnlich ist. Das XPS‑Format basiert auf XML. Das Layout oder die Struktur einer XPS‑Datei bleibt auf allen Betriebssystemen und Druckern gleich.

## Wann das Microsoft XPS‑Format verwendet wird

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie sich die [diese kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/conversion) ansehen. 

{{% /alert %}} 

Wenn Sie Speicherkosten reduzieren möchten, können Sie Ihre Microsoft PowerPoint‑Präsentation in das XPS‑Format konvertieren. So finden Sie es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken.

Microsoft bietet weiterhin umfassende Unterstützung für XPS in Windows (auch in Windows 10), sodass Sie in Erwägung ziehen sollten, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein.

- **Windows 8** verwendet das OXPS (Open XPS)‑Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet besseren Support für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Integrierter XPS‑Betrachter/-Leser und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader verfügbar, aber keine Druck‑zu‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Diese Betriebssysteme bieten ebenfalls besseren Support für XPS‑Dateien als für PDFs. 
  - **XPS:** Integrierter XPS‑Betrachter und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF über die Funktion „Drucken nach PDF“ in Windows 10 implementiert. Zuvor mussten Benutzer Dokumente über das XPS‑Format drucken. 

## XPS‑Konvertierung mit Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) für .NET können Sie die [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Methode der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse verwenden, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren. 

Beim Konvertieren einer Präsentation nach XPS müssen Sie die Präsentation mit einer der folgenden Einstellungen speichern:

- Standard‑Einstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **Präsentationen mit den Standardeinstellungen nach XPS konvertieren**

Dieser Beispielcode in Python zeigt, wie man eine Präsentation mit den Standard‑Einstellungen in ein XPS‑Dokument konvertiert:
```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
pres = slides.Presentation("Convert_XPS.pptx")

# Speichern der Präsentation als XPS-Dokument
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **Präsentationen mit benutzerdefinierten Einstellungen nach XPS konvertieren**
Dieser Beispielcode zeigt, wie man eine Präsentation mit benutzerdefinierten Einstellungen in Python in ein XPS‑Dokument konvertiert:
```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Instanziieren Sie die XpsOptions-Klasse
options = slides.export.XpsOptions()

# MetaFiles als PNG speichern
options.save_metafiles_as_png = True

# Die Präsentation als XPS-Dokument speichern
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```


## **FAQ**

**Kann ich XPS in einen Stream statt in eine Datei speichern?**

Ja – Aspose.Slides ermöglicht das direkte Exportieren in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jedes Szenario ist, in dem Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

**Werden versteckte Folien in XPS übernommen und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können [versteckte Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) über die [Export‑Einstellungen](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/), bevor Sie nach XPS speichern, sodass die Ausgabe genau die Seiten enthält, die Sie benötigen.