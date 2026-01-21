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
description: "Konvertieren Sie OpenDocument ODP in PDF, PPT, PPTX, XPS, HTML, TIFF oder SWF in Python mit Aspose.Slides: Codebeispiele, hohe Wiedergabetreue, Stapelkonvertierung und Anpassung."
---

## **ODP-Dateien konvertieren**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) ermöglicht das Konvertieren von OpenDocument (ODP)-Präsentationen in zahlreiche Formate (HTML, PDF, TIFF, SWF, XPS usw.). Die API, die zum Konvertieren von ODP-Dateien in andere Dokumentformate verwendet wird, ist dieselbe wie die für PowerPoint‑(PPT und PPTX) Konvertierungsoperationen.

Beispielsweise können Sie eine ODP‑Präsentation in PDF konvertieren, indem Sie Folgendes tun:
```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **FAQ**

**Kann ich ODP nach PPTX konvertieren, ohne LibreOffice oder OpenOffice zu installieren?**

Ja. Aspose.Slides ist eine vollständig eigenständige Bibliothek, die sowohl PowerPoint‑ als auch OpenOffice‑Formate verarbeitet, ohne externe Anwendungen zu benötigen.

**Öffnet und speichert Aspose.Slides passwortgeschützte ODP/OTP‑Dateien?**

Ja. Es kann [verschlüsselte Präsentationen](/slides/de/python-net/password-protected-presentation/) laden, wenn Sie das Passwort angeben, und Präsentationen mit Verschlüsselungs‑ und Schutzeinstellungen speichern.

**Kann ich eingebettete Mediendateien (Audio/Video) aus einer ODP extrahieren, bevor ich sie konvertiere?**

Ja. Aspose.Slides ermöglicht den Zugriff auf und das Extrahieren eingebetteter [Audio](/slides/de/python-net/audio-frame/) und [Video](/slides/de/python-net/video-frame/) aus Präsentationen, was für Vorverarbeitungen vor der Konvertierung oder zur separaten Wiederverwendung hilfreich ist.

**Kann ich die konvertierte ODP als Strict Office Open XML speichern?**

Ja. Beim Speichern als PPTX können Sie Strict OOXML über die [Speicheroptionen](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) aktivieren, um strengere Konformitätsanforderungen zu erfüllen.