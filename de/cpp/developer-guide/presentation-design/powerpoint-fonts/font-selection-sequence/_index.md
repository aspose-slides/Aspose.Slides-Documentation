---
title: Schriftauswahlsequenz in Aspose.Slides für С++
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/cpp/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftsubstitution
- Schriftersetzung
- Ersetzungsregel
- verfügbare Schrift
- fehlende Schrift
- PowerPoint
- OpenDocument
- Präsentation
- С++
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für С++ Schriften auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet – verbessern Sie jetzt Ihre Folien."
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriften in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Beispielsweise werden beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, die Schriften der Präsentation überprüft, um festzustellen, ob die gewählten Schriften im Betriebssystem verfügbar sind. Werden die Schriften als fehlend bestätigt, werden sie ersetzt — siehe [**Schriftersetzung**](https://docs.aspose.com/slides/cpp/font-replacement/) und [**Schriftsubstitution**](https://docs.aspose.com/slides/cpp/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides bei der Verarbeitung von Schriften folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriften, um die Schrift zu finden, die der in der Präsentation gewählten Schrift entspricht. 
2. Wird die gewählte Schrift gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschrift, die so nahe wie möglich an dem liegt, was PowerPoint verwenden würde.
3. Wenn Schrift‑Ersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht das Hinzufügen von Schriften zur Laufzeit der Anwendung und deren Verwendung. Siehe [**Benutzerdefinierte Schriften**](https://docs.aspose.com/slides/cpp/custom-font/). 

Wenn zusätzliche Schriften in einer Präsentation eingebettet sind, werden sie [**Eingebettete Schriften**](https://docs.aspose.com/slides/cpp/embedded-font/) genannt.

Aspose.Slides ermöglicht das Hinzufügen von Schriften, die nur auf Ausgabedokumente angewendet werden. Zum Beispiel, wenn ein Vortrag, den Sie in PDF konvertieren möchten, Schriften enthält, die auf Ihrem System und in eingebetteten Schriften fehlen, können Sie die benötigten Schriften als **externe Schriften** hinzufügen oder laden. 

{{% alert title="Note" color="primary" %}} 
Wir distribuieren keine Schriften, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriften und deren Einbettung in Dokumente, jedoch tun Sie dies nach eigenem Ermessen und Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich feststellen, welche Schriften in einem Vortrag vor der Konvertierung tatsächlich verwendet werden?**

Aspose.Slides ermöglicht die Inspektion der verwendeten Schriften über den [Schriftmanager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/), sodass Sie entscheiden können, ob Sie [einbetten](/slides/de/cpp/embedded-font/), [ersetzen](/slides/de/cpp/font-replacement/) oder [externe Quellen](/slides/de/cpp/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Ersetzungen beim Rendern und Export zu vermeiden.

**Kann ich zusätzliche Schriftverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [externe Schriftquellen](/slides/de/cpp/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dadurch wird die Abhängigkeit von Schriftarten des Host‑Systems entfernt und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schrift, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [Schriftersetzung](/slides/de/cpp/font-replacement/) und Schrift-[Fallback‑Regeln](/slides/de/cpp/fallback-font/). Durch die Analyse der verwendeten Schriften und das Festlegen einer kontrollierten Priorität für Ersatzschriften gewährleisten Sie eine konsistente Typografie und vermeiden unerwartete Ergebnisse.