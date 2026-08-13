---
title: Schriftauswahlsequenz in Aspose.Slides für C++
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/cpp/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftartenersetzung
- Schriftartenaustausch
- Ersetzungsregel
- verfügbare Schriftart
- fehlende Schriftart
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für C++ Schriftarten auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet – verbessern Sie jetzt Ihre Folien."
---
## **Übersicht**

Wenn eine Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird, prüft Aspose.Slides, ob die in der Präsentation verwendeten Schriftarten im Betriebssystem verfügbar sind. Fehlt eine erforderliche Schriftart, wählt Aspose.Slides eine Ersatzschriftart aus, die so nahe wie möglich an der liegt, die PowerPoint verwenden würde.

Aspose.Slides sucht zunächst die ausgewählte Schriftart im Betriebssystem. Wird die Schriftart gefunden, wird sie verwendet. Wird sie nicht gefunden, wird ein geeigneter Ersatz angewendet. Wenn Schriftart‑Ersetzungsregeln über `FontSubstRule` definiert sind, werden diese ebenfalls berücksichtigt.

Sie können Schriftarten auch zur Laufzeit der Anwendung hinzufügen, eingebettete Schriftarten aus einer Präsentation verwenden oder externe Schriftarten für Ausgabedokumente wie PDF‑Dateien laden.

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Beispielsweise werden beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, die Schriftarten der Präsentation überprüft, um sicherzustellen, dass die gewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt – siehe [**Font Replacement**](https://docs.aspose.com/slides/de/cpp/font-replacement/) und [**Font Substitution**](https://docs.aspose.com/slides/de/cpp/font-substitution/).

Dies ist der Ablauf, den Aspose.Slides beim Umgang mit Schriftarten befolgt:

1. Aspose.Slides sucht in dem Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der in der Präsentation gewählten Schriftart entspricht. 
2. Wird die gewählte Schriftart gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nahe wie möglich an dem liegt, was PowerPoint verwenden würde.
3. Wenn Schriftart‑Ersatzregeln über [FontSubstRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Laufzeit der Anwendung hinzuzufügen und diese dann zu verwenden. Siehe [**Custom fonts**](https://docs.aspose.com/slides/de/cpp/custom-font/). 

Wenn zusätzliche Schriftarten innerhalb einer Präsentation platziert werden, werden sie [**Embedded fonts**](https://docs.aspose.com/slides/de/cpp/embedded-font/) genannt.

Aspose.Slides ermöglicht es Ihnen, Schriftarten hinzuzufügen, die nur auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in ein PDF konvertieren möchten, Schriftarten enthält, die auf Ihrem System und in eingebetteten Schriftarten fehlen, können Sie die benötigten Schriftarten als **external fonts** hinzufügen oder laden. 

{{% alert title="Note" color="info" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriftarten und das Einbetten in Dokumente, jedoch geschieht dies nach Ihrem Ermessen und Ihrer Verantwortung.
{{% /alert %}}

## **FAQ**

### Wie kann ich ermitteln, welche Schriftarten in einer Präsentation tatsächlich vor der Konvertierung verwendet werden?

Aspose.Slides ermöglicht es Ihnen, die verwendeten Schriftarten über den [font manager](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_fontsmanager/) zu prüfen, sodass Sie entscheiden können, ob Sie [embed](/slides/de/cpp/embedded-font/), [replace](/slides/de/cpp/font-replacement/) oder [external sources](/slides/de/cpp/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Ersetzungen beim Rendern und Export zu vermeiden.

### Kann ich zusätzliche Schriftartenverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?

Ja. Sie können [external font sources](/slides/de/cpp/custom-font/) wie Ordner oder In-Memory-Streams für das Rendern und den Export registrieren. Dies eliminiert die Abhängigkeit von den Schriftarten des Host-Systems und sorgt für ein vorhersehbares Layout.

### Wie verhindere ich ein stilles Fallback zu einer ungeeigneten Schriftart, wenn ein Glyph fehlt?

Definieren Sie im Voraus explizite [font replacement](/slides/de/cpp/font-replacement/) und Schriftart-[fallBack rules](/slides/de/cpp/fallback-font/). Durch die Analyse der verwendeten Schriftarten und das Festlegen einer kontrollierten Priorität für Ersatzschriften stellen Sie eine konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.