---
title: Schriftauswahlsequenz in JavaScript
linktitle: Schriftauswahlsequenz
type: docs
weight: 80
url: /de/nodejs-java/font-selection-sequence/
keywords:
- Schriftart
- Schriftauswahl
- Schriftartersetzung
- Schriftartersetzung
- PowerPoint-Präsentation
- Java
- Aspose.Slides für Node.js über Java
description: PowerPoint-Schriftauswahlsequenz in JavaScript
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Zum Beispiel, wenn Sie versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriftarten der Präsentation überprüft, um sicherzustellen, dass die ausgewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt – siehe [**Font Replacement**](https://docs.aspose.com/slides/nodejs-java/font-replacement/) und [**Font Substitution**](https://docs.aspose.com/slides/nodejs-java/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides folgt, wenn es um Schriftarten geht:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der in der Präsentation ausgewählten Schriftart entspricht. 
2. Wird die ausgewählte Schriftart gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die PowerPoint möglichst nahekommt. 
3. Wenn Schriftart‑Ersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet.

Aspose.Slides ermöglicht das Hinzufügen von Schriftarten zur Laufzeit der Anwendung und deren Verwendung. Siehe [**Custom fonts**](https://docs.aspose.com/slides/nodejs-java/custom-font/).

Wenn zusätzliche Schriftarten in einer Präsentation eingebettet werden, nennt man sie [**Embedded fonts**](https://docs.aspose.com/slides/nodejs-java/embedded-font/).

Aspose.Slides ermöglicht das Hinzufügen von Schriftarten, die *nur* auf Ausgabedokumente angewendet werden. Beispiel: Wenn eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die weder auf Ihrem System noch als eingebettete Schriftarten vorhanden sind, können Sie die benötigten Schriftarten als **external fonts** hinzufügen oder laden.

{{% alert title="Note" color="primary" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriftarten und deren Einbettung in Dokumente, jedoch tun Sie dies nach eigenem Ermessen und auf eigene Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich bestimmen, welche Schriftarten in einer Präsentation vor der Konvertierung tatsächlich verwendet werden?**

Aspose.Slides ermöglicht es Ihnen, die verwendeten Schriftarten über den [font manager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) zu prüfen, sodass Sie entscheiden können, ob Sie [embed](/slides/de/nodejs-java/embedded-font/), [replace](/slides/de/nodejs-java/font-replacement/) oder [external sources](/slides/de/nodejs-java/custom-font/) hinzufügen möchten. Dadurch können ungewollte Ersetzungen beim Rendern und Export vermieden werden.

**Kann ich zusätzliche Schriftartenverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [external font sources](/slides/de/nodejs-java/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von Schriftarten des Host‑Systems und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Zurückgreifen auf eine ungeeignete Schriftart, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [font replacement](/slides/de/nodejs-java/font-replacement/) und Schrift‑[fallBack rules](/slides/de/nodejs-java/fallback-font/). Durch Analyse der verwendeten Schriftarten und Festlegung einer kontrollierten Priorität für Ersatzschriften gewährleisten Sie eine konsistente Typografie und vermeiden unerwartete Ergebnisse.