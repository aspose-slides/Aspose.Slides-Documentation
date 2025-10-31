---
title: PowerPoint-Präsentationen in XPS konvertieren in Python
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
description: "PowerPoint PPT/PPTX in Python mit Aspose.Slides in hochwertige, plattformunabhängige XPS konvertieren. Erhalten Sie eine schrittweise Anleitung und Beispielcode."
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/).  Es ermöglicht das Drucken von Inhalten, indem eine Datei erzeugt wird, die einem PDF sehr ähnlich ist. Das XPS-Format basiert auf XML. Das Layout oder die Struktur einer XPS-Datei bleibt auf allen Betriebssystemen und Druckern gleich. 

## Wann das Microsoft XPS-Format verwenden

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT- oder PPTX-Präsentationen in das XPS-Format konvertiert, können Sie sich [diese kostenlose Online-Konverter-App](https://products.aspose.app/slides/conversion) ansehen. 

{{% /alert %}} 

Wenn Sie Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint-Präsentation in das XPS-Format konvertieren. So wird es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken. 

Microsoft setzt die starke Unterstützung für XPS in Windows (auch in Windows 10) fort, sodass Sie in Betracht ziehen sollten, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS für bestimmte Vorgänge tatsächlich Ihre beste Option sein. 

- **Windows 8** verwendet das OXPS (Open XPS)-Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet eine bessere Unterstützung für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Eingebauter XPS‑Viewer/Reader und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader verfügbar, aber keine Druck‑zu‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Auch diese Betriebssysteme bieten eine bessere Unterstützung für XPS‑Dateien als für PDFs. 
  - **XPS:** Eingebauter XPS‑Viewer und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF über die Funktion „Print to PDF“ in Windows 10 implementiert. Zuvor wurden die Benutzer erwartet, Dokumente über das XPS‑Format zu drucken. 

## XPS-Konvertierung mit Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) für .NET können Sie die [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Methode der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse verwenden, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren. 

Beim Konvertieren einer Präsentation in XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standardeinstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **Präsentationen mit Standardeinstellungen in XPS konvertieren**

Dieser Beispielcode in Python zeigt, wie Sie eine Präsentation mit Standard‑Einstellungen in ein XPS‑Dokument konvertieren:

```py
import aspose.slides as slides

# Erstelle ein Presentation-Objekt, das eine Präsentationsdatei darstellt
pres = slides.Presentation("Convert_XPS.pptx")

# Speichere die Präsentation als XPS-Dokument
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in Python in ein XPS‑Dokument konvertieren:

```py
import aspose.slides as slides

# Erstelle ein Presentation-Objekt, das eine Präsentationsdatei darstellt
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Instanziiere die XpsOptions‑Klasse
options = slides.export.XpsOptions()

# Metadateien als PNG speichern
options.save_metafiles_as_png = True

# Speichere die Präsentation als XPS-Dokument
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **FAQ**

**Kann ich XPS in einen Stream anstatt einer Datei speichern?**

Ja – Aspose.Slides ermöglicht den direkten Export in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jedes Szenario ist, in dem Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

**Werden versteckte Folien in XPS übernommen und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können über die [Export‑Einstellungen](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) [versteckte Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/), bevor Sie nach XPS speichern, sodass die Ausgabe genau die Seiten enthält, die Sie benötigen.