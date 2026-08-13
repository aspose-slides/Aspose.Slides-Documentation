---
title: Schriftauswahlsequenz in Aspose.Slides für Java
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/java/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftart-Substitution
- Schriftart-Ersetzung
- Substitutionsregel
- verfügbare Schriftart
- fehlende Schriftart
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Java Schriftarten auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet – verbessern Sie jetzt Ihre Folien."
---
## **Übersicht**

Wenn eine Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird, prüft Aspose.Slides, ob die in der Präsentation verwendeten Schriftarten im Betriebssystem verfügbar sind. Fehlt eine erforderliche Schriftart, wählt Aspose.Slides eine Ersatzschriftart aus, die so nah wie möglich an der liegt, die PowerPoint verwenden würde.

Aspose.Slides sucht zunächst die ausgewählte Schriftart im Betriebssystem. Wird die Schriftart gefunden, wird sie verwendet. Wird sie nicht gefunden, wird ein geeigneter Ersatz angewendet. Werden Schriftart‑Ersetzungsregeln über `FontSubstRule` definiert, fließen diese ebenfalls ein.

Sie können auch zur Laufzeit der Anwendung Schriftarten hinzufügen, eingebettete Schriftarten aus einer Präsentation verwenden oder externe Schriftarten für Ausgabedokumente wie PDF‑Dateien laden.

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Wenn Sie beispielsweise versuchen, eine Präsentation (ihre Folien) in Bilder zu konvertieren, werden die Schriftarten der Präsentation überprüft, ob die gewählten Schriftarten im Betriebssystem verfügbar sind. Werden die Schriftarten als fehlend bestätigt, werden sie ersetzt – siehe [**Schriftart-Ersetzung**](https://docs.aspose.com/slides/de/java/font-replacement/) und [**Schriftart-Substitution**](https://docs.aspose.com/slides/de/java/font-substitution/).

So geht Aspose.Slides beim Umgang mit Schriftarten vor:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der in der Präsentation gewählten Schriftart entspricht. 
2. Wird die gewählte Schriftart gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nah wie möglich an der liegt, die PowerPoint verwenden würde.
3. Sind Schriftart‑Ersetzungsregeln über [FontSubstRule](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstrule/) festgelegt, werden sie angewendet. 

Aspose.Slides ermöglicht das Hinzufügen von Schriftarten zur Laufzeit der Anwendung, die dann verwendet werden können. Siehe [**Benutzerdefinierte Schriftarten**](https://docs.aspose.com/slides/de/java/custom-font/). 

Wenn zusätzliche Schriftarten in einer Präsentation eingebettet werden, nennt man sie [**Eingebettete Schriftarten**](https://docs.aspose.com/slides/de/java/embedded-font/).

Aspose.Slides ermöglicht das Hinzufügen von Schriftarten, die *nur* auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die in Ihrem System und den eingebetteten Schriftarten fehlen, können Sie die erforderlichen Schriftarten als **externe Schriftarten** hinzufügen oder laden. 

{{% alert title="Note" color="info" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriftarten und deren Einbettung in Dokumente, aber Sie tun dies mit Schriftarten nach eigenem Ermessen und Verantwortung.
{{% /alert %}}

## **FAQ**

### Wie kann ich feststellen, welche Schriftarten in einer Präsentation vor der Konvertierung tatsächlich verwendet werden?

Aspose.Slides ermöglicht die Inspektion der verwendeten Schriftarten über den [Schriftarten-Manager](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsmanager/), sodass Sie entscheiden können, ob Sie [einbetten](/slides/de/java/embedded-font/), [ersetzen](/slides/de/java/font-replacement/) oder [externe Quellen](/slides/de/java/custom-font/) hinzufügen möchten. Dies hilft, unerwünschte Ersetzungen beim Rendern und Export zu verhindern.

### Kann ich zusätzliche Schriftart-Verzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?

Ja. Sie können [externe Schriftart-Quellen](/slides/de/java/custom-font/) wie Ordner oder In-Memory-Streams für das Rendern und den Export registrieren. Dadurch entfällt die Abhängigkeit von den Schriftarten des Host-Systems und das Layout bleibt vorhersehbar.

### Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schriftart, wenn ein Glyph fehlt?

Definieren Sie im Voraus explizite [Schriftart-Ersetzung](/slides/de/java/font-replacement/) und Schriftart-[Fallback-Regeln](/slides/de/java/fallback-font/). Durch Analyse der verwendeten Schriftarten und Festlegung einer kontrollierten Priorität für Ersatzschriften gewährleisten Sie konsistente Typografie und vermeiden unerwartete Ergebnisse.