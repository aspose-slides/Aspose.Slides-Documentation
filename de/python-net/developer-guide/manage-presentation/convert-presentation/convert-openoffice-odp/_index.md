---
title: OpenDocument-Präsentationen in Python konvertieren
linktitle: OpenDocument konvertieren
type: docs
weight: 10
url: /de/python-net/convert-openoffice-odp/
keywords:
- OpenDocument konvertieren
- ODP konvertieren
- ODP nach PDF
- ODP nach PPT
- ODP nach PPTX
- ODP nach XPS
- ODP nach HTML
- ODP nach TIFF
- ODP nach SWF
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Konvertieren Sie OpenDocument ODP in PDF, PPT, PPTX, XPS, HTML, TIFF oder SWF in Python mit Aspose.Slides: Beispielcode, hohe Wiedergabetreue, Batch-Konvertierung und Anpassungsmöglichkeiten."
---

## **ODP-Dateien konvertieren**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) ermöglicht das Konvertieren von OpenOffice ODP-Präsentationen in viele Formate. Die API, die zum Konvertieren von ODP-Dateien in andere Dokumentformate verwendet wird, ist dieselbe, die für PowerPoint (PPT und PPTX) Conversion-Operationen verwendet wird. 

Diese Beispiele zeigen, wie Sie ODP-Dokumente in andere Formate konvertieren (ändern Sie einfach die Quell‑ODP‑Datei):

- [ODP in HTML konvertieren](/slides/de/python-net/convert-powerpoint-to-html/)
- [ODP in PDF konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP in TIFF konvertieren](/slides/de/python-net/convert-powerpoint-to-tiff/)
- [ODP in SWF Flash konvertieren](/slides/de/python-net/convert-powerpoint-to-swf-flash/)
- [ODP in XPS konvertieren](/slides/de/python-net/convert-powerpoint-to-xps/)
- [ODP in PDF mit Notizen konvertieren](/slides/de/python-net/convert-powerpoint-to-pdf-with-notes/)
- [ODP in TIFF mit Notizen konvertieren](/slides/de/python-net/convert-powerpoint-to-tiff-with-notes/)

Zum Beispiel, wenn Sie eine ODP‑Präsentation in PDF konvertieren müssen, kann das so durchgeführt werden:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **FAQ**

**Kann ich ODP nach PPTX konvertieren, ohne LibreOffice oder OpenOffice zu installieren?**

Ja. Aspose.Slides ist eine vollständig eigenständige Bibliothek, die sowohl PowerPoint- als auch OpenOffice-Formate verarbeitet, ohne externe Anwendungen zu benötigen.

**Öffnet und speichert Aspose.Slides passwortgeschützte ODP/OTP‑Dateien?**

Ja. Es kann [verschlüsselte Präsentationen](/slides/de/python-net/password-protected-presentation/) laden, wenn Sie das Passwort angeben, und kann Präsentationen auch mit Verschlüsselungs- und Schutz‑Einstellungen speichern.

**Kann ich eingebettete Mediendateien (Audio/Video) aus einer ODP extrahieren, bevor ich sie konvertiere?**

Ja. Aspose.Slides ermöglicht den Zugriff auf und das Extrahieren von eingebetteten [Audio](/slides/de/python-net/audio-frame/) und [Video](/slides/de/python-net/video-frame/) aus Präsentationen, was für die Verarbeitung vor der Konvertierung oder für die separate Wiederverwendung nützlich ist.

**Kann ich die konvertierte ODP als Strict Office Open XML speichern?**

Ja. Beim Speichern als PPTX können Sie Strict OOXML über die [Speicheroptionen](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) aktivieren, um strengere Konformitätsanforderungen zu erfüllen.