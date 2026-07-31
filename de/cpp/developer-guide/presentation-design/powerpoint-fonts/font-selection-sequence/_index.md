---
title: Schriftauswahl‑Sequenz in Aspose.Slides für C++
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/cpp/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftsubstitution
- Schriftersetzung
- Substitutionsregel
- verfügbare Schrift
- fehlende Schrift
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für C++ Schriften auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP‑Dateien gewährleistet – verbessern Sie jetzt Ihre Folien."
---
## **Übersicht**

Wenn eine Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird, prüft Aspose.Slides, ob die in der Präsentation verwendeten Schriften im Betriebssystem vorhanden sind. Fehlt eine erforderliche Schrift, wählt Aspose.Slides eine Ersatzschrift aus, die so nahe wie möglich an die von PowerPoint verwendete Schrift herankommt.

Aspose.Slides sucht zunächst die ausgewählte Schrift im Betriebssystem. Wird die Schrift gefunden, wird sie verwendet. Wird sie nicht gefunden, wird ein geeigneter Ersatz angewendet. Wenn Schrift‑substitutionsregeln über `FontSubstRule` definiert sind, werden diese ebenfalls berücksichtigt.

Sie können außerdem Schriften zur Laufzeit der Anwendung hinzufügen, eingebettete Schriften aus einer Präsentation verwenden oder externe Schriften für Ausgabedokumente wie PDF‑Dateien laden.

## **Schriftauswahl**

Für Schriften in einer Präsentation gelten bestimmte Regeln, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Wenn Sie beispielsweise versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriften der Präsentation geprüft, ob die ausgewählten Schriften im Betriebssystem verfügbar sind. Werden die Schriften als fehlend bestätigt, werden sie ersetzt – siehe [**Schrift‑Ersetzung**](https://docs.aspose.com/slides/de/cpp/font-replacement/) und [**Schrift‑Substitution**](https://docs.aspose.com/slides/de/cpp/font-substitution/).

Dies ist der Ablauf, dem Aspose.Slides bei der Verarbeitung von Schriften folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriften, um die Schrift zu finden, die der in der Präsentation ausgewählten Schrift entspricht. 
2. Wird die ausgewählte Schrift gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschrift, die so nahe wie möglich an die von PowerPoint verwendete Schrift herankommt.
3. Wenn über [FontSubstRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsubstrule/) Schrift‑ersatzregeln festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht es Ihnen, Schriften zur Laufzeit der Anwendung hinzuzufügen und diese dann zu verwenden. Siehe [**Benutzerdefinierte Schriften**](https://docs.aspose.com/slides/de/cpp/custom-font/). 

Wenn zusätzliche Schriften in einer Präsentation eingebettet werden, nennt man sie [**Eingebettete Schriften**](https://docs.aspose.com/slides/de/cpp/embedded-font/).

Aspose.Slides ermöglicht es Ihnen, Schriften hinzuzufügen, die *nur* für Ausgabedokumente gelten. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriften enthält, die auf Ihrem System und in den eingebetteten Schriften fehlen, können Sie die benötigten Schriften als **externe Schriften** hinzufügen oder laden. 

{{% alert title="Note" color="primary" %}} 
Wir stellen keine Schriften bereit, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriften und das Einbetten in Dokumente, jedoch geschieht dies nach Ihrem Ermessen und auf Ihre Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich feststellen, welche Schriften in einer Präsentation vor der Konvertierung tatsächlich verwendet werden?**

Aspose.Slides ermöglicht es Ihnen, die verwendeten Schriften über den [Schrift‑Manager](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_fontsmanager/) zu prüfen, sodass Sie entscheiden können, ob Sie sie [einbetten](/slides/de/cpp/embedded-font/), [ersetzen](/slides/de/cpp/font-replacement/) oder [externe Quellen](/slides/de/cpp/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Ersetzungen beim Rendern und Export zu vermeiden.

**Kann ich zusätzliche Schriftverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [externe Schriftquellen](/slides/de/cpp/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von den Schriftarten des Host‑Systems und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schrift, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [Schrift‑Ersetzung](/slides/de/cpp/font-replacement/) und Schrift‑[FallBack‑Regeln](/slides/de/cpp/fallback-font/). Durch die Analyse der verwendeten Schriften und das Festlegen einer kontrollierten Priorität für Ersatzschriften stellen Sie eine konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.