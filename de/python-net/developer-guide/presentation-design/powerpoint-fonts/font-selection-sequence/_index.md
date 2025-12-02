---
title: Schriftartauswahl-Sequenz in Aspose.Slides für Python
linktitle: Schriftartauswahl
type: docs
weight: 80
url: /de/python-net/font-selection-sequence/
keywords:
- Schriftartauswahl
- Schriftartensubstitution
- Schriftartenersatz
- Ersetzungsregel
- verfügbare Schriftart
- fehlende Schriftart
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python über .NET Schriftarten auswählt, um eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien zu gewährleisten - verbessern Sie jetzt Ihre Folien."
---

## **Schriftartauswahl**

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Zum Beispiel werden beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, die Schriftarten der Präsentation überprüft, um sicherzustellen, dass die ausgewählten Schriftarten im Betriebssystem verfügbar sind. Wenn festgestellt wird, dass die Schriftarten fehlen, werden sie ersetzt – siehe [**Schriftartenersatz**](https://docs.aspose.com/slides/python-net/font-replacement/) und [**Schriftartensubstitution**](https://docs.aspose.com/slides/python-net/font-substitution/).

Dies ist der Prozess, den Aspose.Slides bei der Behandlung von Schriftarten folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der in der Präsentation ausgewählten Schriftart entspricht. 
2. Wenn die ausgewählte Schriftart gefunden wird, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nahe wie möglich an der von PowerPoint verwendeten liegt.
3. Wenn Schriftart‑Ersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Laufzeit der Anwendung hinzuzufügen und diese dann zu verwenden. Siehe [**Benutzerdefinierte Schriftarten**](https://docs.aspose.com/slides/python-net/custom-font/). 

Wenn zusätzliche Schriftarten in einer Präsentation eingebettet werden, werden sie [**Eingebettete Schriftarten**](https://docs.aspose.com/slides/python-net/embedded-font/) genannt.

Aspose.Slides ermöglicht es Ihnen, Schriftarten hinzuzufügen, die nur auf Ausgabedokumente angewendet werden. Zum Beispiel, wenn eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die auf Ihrem System und in den eingebetteten Schriftarten fehlen, können Sie die benötigten Schriftarten als **externe Schriftarten** hinzufügen oder laden. 

{{% alert title="Note" color="primary" %}} 
Wir vertreiben keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht es Ihnen, externe Schriftarten zu laden und in Dokumente einzubetten, jedoch geschieht dies nach Ihrem Ermessen und Ihrer Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich feststellen, welche Schriftarten in einer Präsentation tatsächlich verwendet werden, bevor ich sie konvertiere?**

Aspose.Slides ermöglicht Ihnen, die verwendeten Schriftarten über den [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) zu untersuchen, sodass Sie entscheiden können, ob Sie [einbetten](/slides/de/python-net/embedded-font/), [ersetzen](/slides/de/python-net/font-replacement/) oder [externe Quellen](/slides/de/python-net/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Ersetzungen beim Rendern und Export zu verhindern.

**Kann ich zusätzliche Schriftartenverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [externe Schriftquellen](/slides/de/python-net/custom-font/) wie Ordner oder In-Memory-Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von den Schriftarten des Host-Systems und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schriftart, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [Schriftartenersatz](/slides/de/python-net/font-replacement/) und Schriftarten-[FallBack-Regeln](/slides/de/python-net/fallback-font/). Durch die Analyse der verwendeten Schriftarten und das Festlegen einer kontrollierten Priorität für Ersatzschriften stellen Sie eine konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.