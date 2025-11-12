---
title: OpenDocument-Präsentationen in Python konvertieren
linktitle: OpenDocument konvertieren
type: docs
weight: 10
url: /de/python-net/convert-openoffice-odp/
keywords:
- OpenDocument konvertieren
- ODP konvertieren
- ODP zu PDF
- ODP zu PPT
- ODP zu PPTX
- ODP zu XPS
- ODP zu HTML
- ODP zu TIFF
- ODP zu SWF
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Konvertieren Sie OpenDocument ODP in PDF, PPT, PPTX, XPS, HTML, TIFF oder SWF in Python mit Aspose.Slides: Codebeispiele, hohe Treue, Batch-Konvertierung und Anpassungen."
---

## **ODP-Dateien konvertieren**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) ermöglicht das Konvertieren von OpenOffice ODP‑Präsentationen in viele Formate. Die API, die zum Konvertieren von ODP‑Dateien in andere Dokumentformate verwendet wird, ist dieselbe, die für PowerPoint‑Konvertierungen (PPT und PPTX) verwendet wird.

Diese Beispiele zeigen, wie Sie ODP‑Dokumente in andere Formate konvertieren (einfach die Quell‑ODP‑Datei ändern):

- [ODP zu HTML konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP zu PDF konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP zu TIFF konvertieren](/slides/de/python-net/convert-powerpoint-to-tiff/)
- [ODP zu SWF Flash konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [ODP zu XPS konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [ODP zu PDF mit Notizen konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [ODP zu TIFF mit Notizen konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Zum Beispiel, wenn Sie eine ODP‑Präsentation in PDF konvertieren möchten, geht das so:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**Kann ich ODP ohne Installation von LibreOffice oder OpenOffice in PPTX konvertieren?**

Ja. Aspose.Slides ist eine vollständig eigenständige Bibliothek, die sowohl PowerPoint‑ als auch OpenOffice‑Formate verarbeitet, ohne externe Anwendungen zu benötigen.

**Öffnet und speichert Aspose.Slides passwortgeschützte ODP/OTP‑Dateien?**

Ja. Sie können [verschlüsselte Präsentationen laden](/slides/de/python-net/password-protected-presentation/), wenn Sie das Passwort angeben, und Sie können Präsentationen auch mit Verschlüsselungs‑ und Schutzeinstellungen speichern.

**Kann ich eingebettete Mediendateien (Audio/Video) aus einem ODP extrahieren, bevor ich es konvertiere?**

Ja. Aspose.Slides ermöglicht den Zugriff auf und das Extrahieren von eingebetteten [Audio](/slides/de/python-net/audio-frame/) und [Video](/slides/de/python-net/video-frame/) aus Präsentationen, was für die Vorverarbeitung oder separate Wiederverwendung hilfreich ist.

**Kann ich das konvertierte ODP als Strict Office Open XML speichern?**

Ja. Beim Speichern als PPTX können Sie Strict OOXML über die [Speicheroptionen](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) aktivieren, um strengere Konformitätsanforderungen zu erfüllen.