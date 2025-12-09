---
title: Schriftauswahlsequenz in Aspose.Slides für Python
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/python-net/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftsubstitution
- Schriftersetzung
- Substitutionsregel
- verfügbare Schrift
- fehlende Schrift
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Python über .NET Schriften auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet – verbessern Sie jetzt Ihre Folien."
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriften in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Wenn Sie beispielsweise versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriften der Präsentation überprüft, um sicherzustellen, dass die ausgewählten Schriften im Betriebssystem verfügbar sind. Wenn die Schriften als fehlend bestätigt werden, werden sie ersetzt – siehe [**Font Replacement**](https://docs.aspose.com/slides/python-net/font-replacement/) und [**Font Substitution**](https://docs.aspose.com/slides/python-net/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides beim Umgang mit Schriften folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriften, um die Schrift zu finden, die der in der Präsentation gewählten Schrift entspricht. 
2. Wird die gewählte Schrift gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschrift, die so nahe wie möglich an dem liegt, was PowerPoint verwenden würde.
3. Wenn Schrift‑Ersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht das Hinzufügen von Schriften zur Laufzeit der Anwendung und deren Verwendung. Siehe [**Custom fonts**](https://docs.aspose.com/slides/python-net/custom-font/). 

Wenn zusätzliche Schriften in einer Präsentation abgelegt werden, nennt man sie [**Embedded fonts**](https://docs.aspose.com/slides/python-net/embedded-font/).

Aspose.Slides erlaubt das Hinzufügen von Schriften, die **nur** auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriften enthält, die auf Ihrem System und in eingebetteten Schriften fehlen, können Sie die benötigten Schriften als **external fonts** hinzufügen oder laden. 

{{% alert title="Note" color="primary" %}} 
Wir verteilen keine Schriften, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriften und deren Einbetten in Dokumente, aber Sie tun dies nach eigenem Ermessen und auf eigene Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich feststellen, welche Schriften in einer Präsentation vor der Konvertierung tatsächlich verwendet werden?**

Aspose.Slides lässt Sie die verwendeten Schriften über den [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) inspizieren, sodass Sie entscheiden können, ob Sie [embed](/slides/de/python-net/embedded-font/), [replace](/slides/de/python-net/font-replacement/) oder [external sources](/slides/de/python-net/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Ersetzungen beim Rendern und Export zu verhindern.

**Kann ich zusätzliche Schriftordner hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [external font sources](/slides/de/python-net/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von Systemschriften und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schrift, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [font replacement](/slides/de/python-net/font-replacement/) und Schrift‑[fallBack rules](/slides/de/python-net/fallback-font/). Durch Analyse der verwendeten Schriften und Festlegung einer kontrollierten Priorität für Ersatzschriften stellen Sie konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.