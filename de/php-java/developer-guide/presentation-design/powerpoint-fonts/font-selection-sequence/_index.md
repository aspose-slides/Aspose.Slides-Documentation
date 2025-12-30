---
title: Schriftauswahlsequenz in Aspose.Slides für PHP
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/php-java/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftartsubstitution
- Schriftersetzung
- Ersetzungsregel
- verfügbare Schrift
- fehlende Schrift
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für PHP via Java Schriften auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet – verbessern Sie jetzt Ihre Folien."
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriften in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Beispielsweise werden beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, die Schriften der Präsentation überprüft, um sicherzustellen, dass die gewählten Schriften im Betriebssystem verfügbar sind. Wenn festgestellt wird, dass Schriften fehlen, werden sie ersetzt — siehe [**Schriftersetzung**](https://docs.aspose.com/slides/php-java/font-replacement/) und [**Schriftartsubstitution**](https://docs.aspose.com/slides/php-java/font-substitution/).

Das ist der Prozess, dem Aspose.Slides bei der Verarbeitung von Schriften folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriften, um die Schrift zu finden, die der in der Präsentation gewählten Schrift entspricht.  
2. Wird die gewählte Schrift gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschrift, die so nah wie möglich an der von PowerPoint verwendeten liegt.  
3. Wenn über [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) Schriftersetzungsregeln festgelegt wurden, werden diese angewendet.

Aspose.Slides ermöglicht es Ihnen, Schriften zur Aspose‑Laufzeit hinzuzufügen und diese anschließend zu verwenden. Siehe [**Benutzerdefinierte Schriften**](https://docs.aspose.com/slides/php-java/custom-font/).

Wenn zusätzliche Schriften in einer Präsentation eingebettet werden, werden sie als [**Eingebettete Schriften**](https://docs.aspose.com/slides/php-java/embedded-font/) bezeichnet.

Aspose.Slides ermöglicht es Ihnen, Schriften hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Beispielsweise können Sie bei einer Präsentation, die Sie in PDF konvertieren möchten und bei der Schriften fehlen, die nicht im System oder als eingebettete Schriften verfügbar sind, die benötigten Schriften als **Externe Schriften** hinzufügen oder laden.

## **FAQ**

**Wie kann ich bestimmen, welche Schriften in einer Präsentation vor der Konvertierung tatsächlich verwendet werden?**

Aspose.Slides lässt Sie die verwendeten Schriften über den [Schriften‑Manager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) inspizieren, sodass Sie entscheiden können, ob Sie [einbetten](/slides/de/php-java/embedded-font/), [ersetzen](/slides/de/php-java/font-replacement/) oder [externe Quellen](/slides/de/php-java/custom-font/) hinzufügen möchten. Das hilft, ungewollte Substitutionen beim Rendern und Export zu verhindern.

**Kann ich zusätzliche Schriftordner hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [externe Schriftquellen](/slides/de/php-java/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Das entfernt die Abhängigkeit von den Schriften des Host‑Systems und hält das Layout vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schrift, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [Schriftersetzungen](/slides/de/php-java/font-replacement/) und [Fallback‑Regeln](/slides/de/php-java/fallback-font/). Durch die Analyse der verwendeten Schriften und das Festlegen einer kontrollierten Priorität für Ersatzschriften stellen Sie konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.