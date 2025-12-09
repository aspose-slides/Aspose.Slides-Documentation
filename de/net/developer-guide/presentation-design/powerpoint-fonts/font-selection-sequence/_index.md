---
title: Schriftauswahlablauf in Aspose.Slides für .NET
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/net/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftsubstitution
- Schriftersatz
- Substitutionsregel
- verfügbare Schrift
- fehlende Schrift
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für .NET Schriften auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet - verbessern Sie jetzt Ihre Folien."
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriften in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Beispielsweise werden beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, die Schriften der Präsentation geprüft, um festzustellen, ob die ausgewählten Schriften im Betriebssystem verfügbar sind. Wenn die Schriften als fehlend bestätigt werden, werden sie ersetzt – siehe [**Schrift­ersatz**](https://docs.aspose.com/slides/net/font-replacement/) und [**Schrift­substitution**](https://docs.aspose.com/slides/net/font-substitution/).

Dies ist der Vorgang, dem Aspose.Slides bei der Verarbeitung von Schriften folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriften, um die Schrift zu finden, die der in der Präsentation gewählten Schrift entspricht. 
2. Wird die gewählte Schrift gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschrift, die so nah wie möglich an dem liegt, was PowerPoint verwenden würde.
3. Wenn Schrift­ersatz‑Regeln über [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht es Ihnen, Schriften zur Laufzeit der Anwendung hinzuzufügen und diese dann zu verwenden. Siehe [**Benutzerdefinierte Schriften**](https://docs.aspose.com/slides/net/custom-font/). 

Wenn zusätzliche Schriften in einer Präsentation eingebettet werden, werden sie [**Eingebettete Schriften**](https://docs.aspose.com/slides/net/embedded-font/). 

Aspose.Slides ermöglicht es Ihnen, Schriften hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriften enthält, die auf Ihrem System und in den eingebetteten Schriften fehlen, können Sie die benötigten Schriften als **externe Schriften** hinzufügen oder laden. 

{{% alert title="Note" color="primary" %}} 
Wir verteilen keine Schriften, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht es Ihnen, externe Schriften zu laden und in Dokumente einzubetten, jedoch tun Sie dies nach Ihrem eigenen Ermessen und auf eigene Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich feststellen, welche Schriften in einer Präsentation vor der Konvertierung tatsächlich verwendet werden?**

Aspose.Slides ermöglicht es Ihnen, die verwendeten Schriften über den [font manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), zu inspizieren, sodass Sie entscheiden können, ob Sie sie [einbetten](/slides/de/net/embedded-font/), [ersetzen](/slides/de/net/font-replacement/) oder [externe Quellen](/slides/de/net/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Substitutionen beim Rendern und Export zu verhindern.

**Kann ich zusätzliche Schriftverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [externe Schriftquellen](/slides/de/net/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von Systemschriften und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Ausweichen auf eine ungeeignete Schrift, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [font replacement](/slides/de/net/font-replacement/)- und Schrift‑[fallBack rules](/slides/de/net/fallback-font/). Durch die Analyse der verwendeten Schriften und das Festlegen einer kontrollierten Priorität für Ersatzschriften stellen Sie eine konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.