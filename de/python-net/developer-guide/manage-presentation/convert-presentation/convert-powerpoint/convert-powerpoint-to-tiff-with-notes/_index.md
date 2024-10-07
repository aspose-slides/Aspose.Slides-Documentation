---
title: PowerPoint in TIFF mit Notizen konvertieren
type: docs
weight: 100
url: /python-net/convert-powerpoint-to-tiff-with-notes/
keywords: "PowerPoint in TIFF mit Notizen konvertieren"
description: "PowerPoint in TIFF mit Notizen in Aspose.Slides konvertieren."
---

{{% alert title="Tipp" color="primary" %}}

Sie möchten vielleicht den Aspose [KOSTENLOSEN PowerPoint zu Poster Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ausprobieren.

{{% /alert %}}

TIFF ist eines von mehreren weit verbreiteten Bildformaten, die Aspose.Slides für Python über .NET zur Konvertierung von PowerPoint PPT und PPTX Präsentationen mit Notizen in Bilder unterstützt. Sie können auch Miniaturansichten von Folien in der Notizfolienansicht generieren. Die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode der Presentation-Klasse kann verwendet werden, um die gesamte Präsentation in der Notizfolienansicht in TIFF zu konvertieren. Das Speichern einer Microsoft PowerPoint-Präsentation als TIFF-Notizen mit Aspose.Slides für Python über .NET ist ein zweizeiliger Prozess. Sie öffnen einfach die Präsentation und speichern sie als TIFF-Notizen. Sie können auch eine Miniaturansicht einer Folie in der Notizfolienansicht für einzelne Folien generieren. Die folgenden Codebeispiele aktualisieren die Musterpräsentation in TIFF-Bilder in der Notizfolienansicht, wie unten gezeigt:

```py
import aspose.slides as slides

# Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
presentation = slides.Presentation("pres.pptx")

# Speichern der Präsentation als TIFF-Notizen
presentation.save("Notes_In_Tiff_out.tiff", slides.export.SaveFormat.TIFF)
```