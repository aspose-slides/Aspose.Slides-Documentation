---
title: Schriftauswahlsequenz in Aspose.Slides für Android via Java
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/androidjava/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftsubstitution
- Schriftersatz
- Ersatzregel
- verfügbare Schrift
- fehlende Schrift
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Android via Java Schriften auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet – verbessern Sie jetzt Ihre Folien."
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriften in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Zum Beispiel wird beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, überprüft, ob die gewählten Schriften im Betriebssystem verfügbar sind. Wenn die Schriften als fehlend bestätigt werden, werden sie ersetzt – siehe [**Font Replacement**](https://docs.aspose.com/slides/androidjava/font-replacement/) und [**Font Substitution**](https://docs.aspose.com/slides/androidjava/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides bei der Verarbeitung von Schriften folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriften, um die Schrift zu finden, die der in der Präsentation gewählten Schrift entspricht. 
2. Wenn die gewählte Schrift gefunden wird, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschrift, die so nahe wie möglich an dem liegt, was PowerPoint verwenden würde.
3. Wenn Schrift‑Ersatzregeln über [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet.

Aspose.Slides ermöglicht das Hinzufügen von Schriften zur Laufzeit der Anwendung und deren Verwendung. Siehe [**Custom fonts**](https://docs.aspose.com/slides/androidjava/custom-font/).

Wenn zusätzliche Schriften in einer Präsentation eingebettet werden, nennt man sie [**Embedded fonts**](https://docs.aspose.com/slides/androidjava/embedded-font/).

Aspose.Slides ermöglicht das Hinzufügen von Schriften, die *nur* auf Ausgabedokumente angewendet werden. Zum Beispiel, wenn eine Präsentation, die Sie in PDF konvertieren möchten, Schriften enthält, die in Ihrem System und den eingebetteten Schriften fehlen, können Sie die benötigten Schriften als **external fonts** hinzufügen oder laden.

{{% alert title="Note" color="primary" %}} 
Wir vertreiben keine Schriften, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriften und das Einbetten in Dokumente, aber Sie tun dies mit Schriften nach eigenem Ermessen und Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich feststellen, welche Schriften in einer Präsentation vor der Konvertierung tatsächlich verwendet werden?**

Aspose.Slides ermöglicht die Inspektion der verwendeten Schriften über den [font manager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/), sodass Sie entscheiden können, ob Sie [embed](/slides/de/androidjava/embedded-font/), [replace](/slides/de/androidjava/font-replacement/) oder [external sources](/slides/de/androidjava/custom-font/) hinzufügen. Dies hilft, unerwünschte Ersetzungen beim Rendern und Export zu verhindern.

**Kann ich zusätzliche Schriftverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [external font sources](/slides/de/androidjava/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von den Schriften des Hostsystems und das Layout bleibt vorhersehbar.

**Wie kann ich verhindern, dass bei einem fehlenden Glyph still zu einer ungeeigneten Schrift gewechselt wird?**

Definieren Sie im Voraus explizite [font replacement](/slides/de/androidjava/font-replacement/) und Schrift‑[fallback rules](/slides/de/androidjava/fallback-font/). Durch die Analyse der verwendeten Schriften und das Festlegen einer kontrollierten Priorität für Ersatzschriften gewährleisten Sie eine konsistente Typografie und vermeiden unerwartete Ergebnisse.