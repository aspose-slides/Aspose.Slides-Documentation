---
title: Schriftauswahlsequenz in Aspose.Slides für Python via Java
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/python-java/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftersatz
- Schrift-Ersetzung
- Ersetzungsregel
- verfügbare Schriftart
- fehlende Schriftart
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python via Java Schriften auswählt, um eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien zu gewährleisten – verbessern Sie jetzt Ihre Folien."
---
## **Übersicht**

Wenn eine Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird, prüft Aspose.Slides, ob die in der Präsentation verwendeten Schriften im Betriebssystem verfügbar sind. Fehlt eine erforderliche Schrift, wählt Aspose.Slides eine Ersatzschrift, die PowerPoint so nahe wie möglich kommt.

Aspose.Slides sucht zuerst die ausgewählte Schrift im Betriebssystem. Wird die Schrift gefunden, wird sie verwendet. Wird sie nicht gefunden, wird ein geeigneter Ersatz angewendet. Wenn Schriftersatzregeln über [FontSubstRule](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsubstrule/) definiert sind, werden diese ebenfalls berücksichtigt.

Sie können Schriften auch zur Laufzeit der Anwendung hinzufügen, eingebettete Schriften aus einer Präsentation verwenden oder externe Schriften für Ausgabedokumente wie PDF‑Dateien laden.

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriften in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Beispielsweise werden beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, die Schriften der Präsentation überprüft, um sicherzustellen, dass die gewählten Schriften im Betriebssystem vorhanden sind. Werden die Schriften als fehlend bestätigt, werden sie ersetzt – siehe [Font Replacement](/slides/de/python-java/font-replacement/) und [Font Substitution](/slides/de/python-java/font-substitution/).

So geht Aspose.Slides mit Schriften um:

1. Aspose.Slides sucht im Betriebssystem nach Schriften, die der in der Präsentation gewählten Schrift entsprechen.
2. Wird die gewählte Schrift gefunden, verwendet Aspose.Slides sie. Andernfalls nutzt Aspose.Slides eine Ersatzschrift, die PowerPoint so nahe wie möglich kommt.
3. Wenn über [FontSubstRule](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsubstrule/) Schriftersatzregeln festgelegt wurden, werden sie angewendet.

Aspose.Slides ermöglicht das Hinzufügen von Schriften zur Laufzeit der Anwendung und deren Nutzung. Siehe [Custom fonts](/slides/de/python-java/custom-font/).

Wenn zusätzliche Schriften in einer Präsentation gespeichert werden, nennt man sie [Embedded fonts](/slides/de/python-java/embedded-font/).

Aspose.Slides erlaubt das Hinzufügen von Schriften, die *nur* auf Ausgabedokumente angewendet werden. Beispielsweise können Sie, wenn eine zu PDF zu konvertierende Präsentation Schriften verwendet, die weder auf Ihrem System installiert noch in der Präsentation eingebettet sind, die benötigten Schriften als **externe Schriften** hinzufügen oder laden.

{{% alert title="Note" color="info" %}}
Wir verteilen keine Schriften, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriften und das Einbetten in Dokumente, aber Sie tun dies auf eigenes Ermessen und eigene Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich feststellen, welche Schriften tatsächlich in einer Präsentation vor der Konvertierung verwendet werden?**

Aspose.Slides lässt Sie die verwendeten Schriften über den [font manager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) inspizieren, sodass Sie entscheiden können, ob Sie [embed](/slides/de/python-java/embedded-font/), [replace](/slides/de/python-java/font-replacement/) oder [external sources](/slides/de/python-java/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Ersetzungen beim Rendern und Export zu verhindern.

**Kann ich zusätzliche Schriftverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [external font sources](/slides/de/python-java/custom-font/) wie Ordner oder In‑Memory‑Streams registrieren für das Rendern und den Export. Dadurch entfällt die Abhängigkeit von Systemschriften und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schrift, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [font replacement](/slides/de/python-java/font-replacement/) und Schrift‑[fallback rules](/slides/de/python-java/fallback-font/). Durch Analyse der verwendeten Schriften und Festlegung einer kontrollierten Priorität für Ersatzschriften stellen Sie konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.