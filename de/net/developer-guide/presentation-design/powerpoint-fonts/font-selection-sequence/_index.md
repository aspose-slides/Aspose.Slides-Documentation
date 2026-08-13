---
title: Schriftauswahlsequenz in Aspose.Slides für .NET
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/net/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftart-Substitution
- Schriftart-Ersetzung
- Ersetzungsregel
- verfügbare Schriftart
- fehlende Schriftart
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für .NET Schriftarten auswählt und so eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet — verbessern Sie jetzt Ihre Folien."
---
## **Übersicht**

Wenn eine Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird, prüft Aspose.Slides, ob die in der Präsentation verwendeten Schriftarten im Betriebssystem verfügbar sind. Fehlt eine erforderliche Schriftart, wählt Aspose.Slides eine Ersatzschriftart aus, die so nahe wie möglich an der liegt, die PowerPoint verwenden würde.

Aspose.Slides sucht zunächst nach der ausgewählten Schriftart im Betriebssystem. Wird die Schriftart gefunden, wird sie verwendet. Wird sie nicht gefunden, wird ein geeigneter Ersatz angewendet. Wenn Schriftart‑Ersetzungsregeln über `FontSubstRule` definiert wurden, werden diese ebenfalls berücksichtigt.

Sie können Schriftarten auch zur Laufzeit der Anwendung hinzufügen, eingebettete Schriftarten einer Präsentation verwenden oder externe Schriftarten für Ausgabedokumente wie PDF‑Dateien laden.

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Beispielsweise werden beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, die Schriftarten der Präsentation überprüft, um festzustellen, ob die gewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt – siehe [**Schriftarten‑Ersetzung**](https://docs.aspose.com/slides/de/net/font-replacement/) und [**Schriftarten‑Substitution**](https://docs.aspose.com/slides/de/net/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides bei der Behandlung von Schriftarten folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der in der Präsentation gewählten Schriftart entspricht.  
2. Wird die gewählte Schriftart gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nahe wie möglich an dem liegt, was PowerPoint verwenden würde.  
3. Wenn Schriftarten‑Ersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/de/net/aspose.slides/fontsubstrule/) festgelegt wurden, werden sie angewendet.

Aspose.Slides ermöglicht das Hinzufügen von Schriftarten zur Laufzeit der Anwendung und deren anschließende Verwendung. Siehe [**Benutzerdefinierte Schriftarten**](https://docs.aspose.com/slides/de/net/custom-font/).

Wenn zusätzliche Schriftarten in einer Präsentation eingebettet werden, nennt man sie [**Eingebettete Schriftarten**](https://docs.aspose.com/slides/de/net/embedded-font/).

Aspose.Slides erlaubt das Hinzufügen von Schriftarten, die **nur** auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die auf Ihrem System und in den eingebetteten Schriftarten fehlen, können Sie die benötigten Schriftarten als **externe Schriftarten** hinzufügen oder laden.

{{% alert title="Note" color="info" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriftarten und deren Einbetten in Dokumente, jedoch geschieht dies nach Ihrem Ermessen und auf eigene Verantwortung.
{{% /alert %}}

## **FAQ**

### Wie kann ich feststellen, welche Schriftarten tatsächlich in einer Präsentation verwendet werden, bevor ich sie konvertiere?

Aspose.Slides lässt Sie die verwendeten Schriftarten über den [Schriftarten‑Manager](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/fontsmanager/) inspizieren, sodass Sie entscheiden können, ob Sie sie [einbetten](/slides/de/net/embedded-font/), [ersetzen](/slides/de/net/font-replacement/) oder [externe Quellen](/slides/de/net/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Substitutionen beim Rendern und Export zu vermeiden.

### Kann ich zusätzliche Schriftarten‑Verzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?

Ja. Sie können [externe Schriftarten‑Quellen](/slides/de/net/custom-font/) wie Ordner oder In‑Memory‑Streams registrieren für das Rendern und den Export. Dadurch entfallen Abhängigkeiten von den Schriftarten des Host‑Systems und das Layout bleibt vorhersehbar.

### Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schriftart, wenn ein Glyph fehlt?

Definieren Sie im Voraus explizite [Schriftarten‑Ersetzung](/slides/de/net/font-replacement/) und Schriftarten‑[Fallback‑Regeln](/slides/de/net/fallback-font/). Durch die Analyse der verwendeten Schriftarten und das Festlegen einer kontrollierten Priorität für Ersatzschriftarten stellen Sie konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.