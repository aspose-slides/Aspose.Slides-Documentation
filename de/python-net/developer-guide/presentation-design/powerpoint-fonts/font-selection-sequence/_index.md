---
title: Schrift-Auswahlablauf in Präsentationen mit Python
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/python-net/font-selection-sequence/
keywords:
- Schriftauswahl
- Schrift-Substitution
- Schrift-Ersetzung
- Substitutionsregel
- verfügbare Schrift
- fehlende Schrift
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python über .NET Schriften auswählt und dadurch eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet – verbessern Sie jetzt Ihre Folien."
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriften in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Zum Beispiel wird beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, überprüft, ob die gewählten Schriften im Betriebssystem verfügbar sind. Wenn festgestellt wird, dass die Schriften fehlen, werden sie ersetzt — siehe [**Schriftersetzung**](https://docs.aspose.com/slides/python-net/font-replacement/) und [**Schrift-Substitution**](https://docs.aspose.com/slides/python-net/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides beim Umgang mit Schriften folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriften, um die Schrift zu finden, die der in der Präsentation gewählten Schrift entspricht. 
2. Wird die gewählte Schrift gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschrift, die so nahe wie möglich an der von PowerPoint verwendeten liegt.
3. Wenn Schrift‑Ersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht das Hinzufügen von Schriften zur Laufzeit der Anwendung und deren Nutzung. Siehe [**Benutzerdefinierte Schriften**](https://docs.aspose.com/slides/python-net/custom-font/). 

Wenn zusätzliche Schriften in einer Präsentation eingebettet werden, nennt man sie [**Eingebettete Schriften**](https://docs.aspose.com/slides/python-net/embedded-font/).

Aspose.Slides erlaubt das Hinzufügen von Schriften, die *nur* auf Ausgabedokumente angewendet werden. Zum Beispiel können Sie, wenn eine Präsentation, die Sie in PDF konvertieren möchten, Schriften enthält, die auf Ihrem System und in eingebetteten Schriften fehlen, die benötigten Schriften als **externe Schriften** hinzufügen oder laden. 

{{% alert title="Note" color="primary" %}} 
Wir verteilen keine Schriften, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriften und deren Einbettung in Dokumente, jedoch tun Sie dies nach eigenem Ermessen und Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich feststellen, welche Schriften tatsächlich in einer Präsentation vor der Konvertierung verwendet werden?**

Aspose.Slides lässt Sie die verwendeten Schriften über den [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) inspizieren, sodass Sie entscheiden können, ob Sie [einbetten](/slides/de/python-net/embedded-font/), [ersetzen](/slides/de/python-net/font-replacement/) oder [externe Quellen](/slides/de/python-net/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Substitutionen beim Rendern und Export zu verhindern.

**Kann ich zusätzliche Schriftverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [externe Schriftquellen](/slides/de/python-net/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von Systemschriften und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schrift, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [Schrift‑Ersetzung](/slides/de/python-net/font-replacement/) und Schrift‑[FallBack‑Regeln](/slides/de/python-net/fallback-font/). Durch die Analyse der verwendeten Schriften und das Festlegen einer kontrollierten Priorität für Ersatzschriften stellen Sie konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.