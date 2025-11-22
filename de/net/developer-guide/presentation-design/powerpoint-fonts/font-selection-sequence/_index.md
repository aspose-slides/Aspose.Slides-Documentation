---
title: Schriftartauswahlsequenz in C#
linktitle: Schriftartauswahlsequenz in C#
type: docs
weight: 80
url: /de/net/font-selection-sequence/
keywords:
- Schriftart
- Schriftartauswahl
- Schriftartsubstitution
- Schriftartersetzung
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides for .NET
description: PowerPoint-Schriftartauswahlsequenz in C#
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Beispielsweise wird beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, überprüft, ob die Schriftarten der Präsentation im Betriebssystem verfügbar sind. Wenn festgestellt wird, dass die Schriftarten fehlen, werden sie ersetzt – siehe [**Font Replacement**](https://docs.aspose.com/slides/net/font-replacement/) und [**Font Substitution**](https://docs.aspose.com/slides/net/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides folgt, wenn es um Schriftarten geht:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der in der Präsentation gewählten Schriftart entspricht. 
2. Wenn die gewählte Schriftart gefunden wird, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nah wie möglich an dem liegt, was PowerPoint verwenden würde.
3. Wenn Schriftart‑Ersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet. 

Aspose.Slides ermöglicht es Ihnen, Schriftarten zur Laufzeit der Anwendung hinzuzufügen und diese dann zu verwenden. Siehe [**Custom fonts**](https://docs.aspose.com/slides/net/custom-font/). 

Wenn zusätzliche Schriftarten in einer Präsentation abgelegt werden, nennt man sie [**Embedded fonts**](https://docs.aspose.com/slides/net/embedded-font/).

Aspose.Slides ermöglicht es Ihnen, Schriftarten hinzuzufügen, die *nur* auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die in Ihrem System und in eingebetteten Schriftarten fehlen, können Sie die erforderlichen Schriftarten als **external fonts** hinzufügen oder laden. 

{{% alert title="Note" color="primary" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht es Ihnen, externe Schriftarten zu laden und in Dokumente einzubetten, aber Sie tun dies mit Schriftarten nach Ihrem Ermessen und Ihrer Verantwortung.
{{% /alert %}}

## **FAQ**

**Wie kann ich feststellen, welche Schriftarten in einer Präsentation tatsächlich vor der Konvertierung verwendet werden?**

Aspose.Slides lässt Sie die verwendeten Schriftarten über den [font manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) inspizieren, sodass Sie entscheiden können, ob Sie [embed](/slides/de/net/embedded-font/), [replace](/slides/de/net/font-replacement/) oder [external sources](/slides/de/net/custom-font/) hinzufügen möchten. Dies hilft Ihnen, unerwünschte Ersetzungen beim Rendern und Export zu verhindern.

**Kann ich zusätzliche Schriftartenverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [external font sources](/slides/de/net/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von den Schriftarten des Host‑Systems und das Layout bleibt vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schriftart, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [font replacement](/slides/de/net/font-replacement/) und Font‑[fallBack rules](/slides/de/net/fallback-font/). Durch die Analyse der verwendeten Schriftarten und das Festlegen einer kontrollierten Priorität für Ersatzschriften stellen Sie eine konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.