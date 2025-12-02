---
title: Schriftauswahlsequenz in Aspose.Slides für Python
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/python-net/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftart-Substitution
- Schriftart-Ersetzung
- Ersetzungsregel
- verfügbare Schrift
- fehlende Schrift
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python über .NET Schriften auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet — verbessern Sie jetzt Ihre Folien."
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriften in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Wenn Sie beispielsweise versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriften der Präsentation überprüft, um sicherzustellen, dass die ausgewählten Schriften im Betriebssystem verfügbar sind. Sind die Schriften nicht vorhanden, werden sie ersetzt — siehe [**Schriftart-Ersetzung**](https://docs.aspose.com/slides/python-net/font-replacement/) und [**Schriftart-Substitution**](https://docs.aspose.com/slides/python-net/font-substitution/).

Dies ist der Prozess, den Aspose.Slides beim Umgang mit Schriften befolgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriften, um die Schrift zu finden, die der in der Präsentation ausgewählten Schrift entspricht.  
2. Wird die ausgewählte Schrift gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschrift, die so nahe wie möglich an der von PowerPoint verwendeten liegt.  
3. Wenn Schrift-Ersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) festgelegt wurden, werden diese angewendet.  

Aspose.Slides ermöglicht es Ihnen, Schriften zur Laufzeit der Anwendung hinzuzufügen und diese dann zu verwenden. Siehe [**Benutzerdefinierte Schriften**](https://docs.aspose.com/slides/python-net/custom-font/).  

Wenn zusätzliche Schriften in einer Präsentation eingebettet werden, nennt man sie [**Eingebettete Schriften**](https://docs.aspose.com/slides/python-net/embedded-font/).

Aspose.Slides erlaubt es Ihnen, Schriften hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriften enthält, die auf Ihrem System und in den eingebetteten Schriften fehlen, können Sie die benötigten Schriften als **externe Schriften** hinzufügen oder laden.  

{{% alert title="Note" color="primary" %}} 
Wir vertreiben keine Schriften, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht es Ihnen, externe Schriften zu laden und in Dokumente einzubetten, aber Sie tun dies nach eigenem Ermessen und auf eigene Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich ermitteln, welche Schriften tatsächlich in einer Präsentation vor der Konvertierung verwendet werden?**

Aspose.Slides lässt Sie die verwendeten Schriften über den [Schriften-Manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) inspizieren, sodass Sie entscheiden können, ob Sie [einbetten](/slides/de/python-net/embedded-font/), [ersetzen](/slides/de/python-net/font-replacement/) oder [externe Quellen](/slides/de/python-net/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Substitutionen beim Rendern und Export zu verhindern.

**Kann ich zusätzliche Schriftverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [externe Schriftquellen](/slides/de/python-net/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von Systemschriften und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schrift, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [Schriftart-Ersetzung](/slides/de/python-net/font-replacement/) und Schriftart-[Fallback‑Regeln](/slides/de/python-net/fallback-font/). Durch Analyse der verwendeten Schriften und das Festlegen einer kontrollierten Priorität für Ersatzschriften stellen Sie eine konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.