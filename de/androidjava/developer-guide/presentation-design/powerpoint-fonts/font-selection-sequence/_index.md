---
title: Schriftauswahlsequenz in Aspose.Slides für Android via Java
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/androidjava/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftart-Substitution
- Schriftart-Ersetzung
- Substitutionsregel
- verfügbare Schriftart
- fehlende Schriftart
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Android via Java Schriftarten auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet - verbessern Sie jetzt Ihre Folien."
---
## **Übersicht**

Wenn eine Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird, prüft Aspose.Slides, ob die in der Präsentation verwendeten Schriftarten im Betriebssystem verfügbar sind. Fehlt eine erforderliche Schriftart, wählt Aspose.Slides eine Ersatzschriftart aus, die so nah wie möglich an der liegt, die PowerPoint verwenden würde.

Aspose.Slides sucht zunächst die ausgewählte Schriftart im Betriebssystem. Wird die Schriftart gefunden, wird sie verwendet. Wird sie nicht gefunden, wird ein geeigneter Ersatz angewendet. Werden Schriftartersetzungsregeln über `FontSubstRule` definiert, werden diese ebenfalls berücksichtigt.

Sie können Schriftarten zur Laufzeit der Anwendung hinzufügen, eingebettete Schriftarten aus einer Präsentation verwenden oder externe Schriftarten für Ausgabedokumente wie PDF-Dateien laden.

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Beispielsweise wird beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, überprüft, ob die in der Präsentation verwendeten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt — siehe [**Font Replacement**](https://docs.aspose.com/slides/de/androidjava/font-replacement/) und [**Font Substitution**](https://docs.aspose.com/slides/de/androidjava/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides bei der Behandlung von Schriftarten folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der in der Präsentation gewählten Schriftart entspricht. 
2. Wird die gewählte Schriftart gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nah wie möglich an dem liegt, was PowerPoint verwenden würde.
3. Wenn Schriftartersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet.

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Laufzeit der Anwendung hinzuzufügen und diese anschließend zu verwenden. Siehe [**Custom fonts**](https://docs.aspose.com/slides/de/androidjava/custom-font/).

Wenn zusätzliche Schriftarten innerhalb einer Präsentation platziert werden, nennt man sie [**Embedded fonts**](https://docs.aspose.com/slides/de/androidjava/embedded-font/).

Aspose.Slides ermöglicht es Ihnen, Schriftarten hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Beispielsweise können Sie, wenn eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die auf Ihrem System und in den eingebetteten Schriftarten fehlen, die benötigten Schriftarten als **external fonts** hinzufügen oder laden. 

{{% alert title="Note" color="info" %}} 
Wir vertreiben keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht es Ihnen, externe Schriftarten zu laden und in Dokumente einzubetten, aber Sie tun dies mit Schriftarten nach eigenem Ermessen und Verantwortung.
{{% /alert %}}

## **FAQ**

### Wie kann ich feststellen, welche Schriftarten in einer Präsentation vor der Konvertierung tatsächlich verwendet werden?

Aspose.Slides ermöglicht es Ihnen, die verwendeten Schriftarten über den [font manager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsmanager/) zu inspizieren, sodass Sie entscheiden können, ob Sie [embed](/slides/de/androidjava/embedded-font/), [replace](/slides/de/androidjava/font-replacement/) oder [external sources](/slides/de/androidjava/custom-font/) hinzufügen möchten. Dies hilft Ihnen, unerwünschte Ersetzungen während des Renderns und Exports zu verhindern.

### Kann ich zusätzliche Schriftartenverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?

Ja. Sie können [external font sources](/slides/de/androidjava/custom-font/) wie Ordner oder In-Memory-Streams für das Rendern und den Export registrieren. Dadurch wird die Abhängigkeit von Schriftarten des Host-Systems entfernt und das Layout bleibt vorhersehbar.

### Wie verhindere ich ein stilles Zurückgreifen auf eine ungeeignete Schriftart, wenn ein Glyph fehlt?

Definieren Sie im Vorfeld explizite [font replacement](/slides/de/androidjava/font-replacement/) und Schriftarten-[fallback rules](/slides/de/androidjava/fallback-font/). Durch die Analyse der verwendeten Schriftarten und das Festlegen einer kontrollierten Priorität für Ersatzschriften sichern Sie eine konsistente Typografie und vermeiden unerwartete Ergebnisse.