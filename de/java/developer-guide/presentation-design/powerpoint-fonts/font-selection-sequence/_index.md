---
title: Schriftauswahlablauf in Aspose.Slides für Java
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Java Schriftarten auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien sicherstellt – verbessern Sie jetzt Ihre Folien."
---

## **Schriftauswahl**

Bestimmte Regeln gelten für Schriftarten in einer Präsentation, wenn die Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird. Zum Beispiel werden beim Versuch, eine Präsentation (ihre Folien) in Bilder zu konvertieren, die Schriftarten der Präsentation überprüft, um zu verifizieren, dass die gewählten Schriftarten im Betriebssystem verfügbar sind. Wenn die Schriftarten als fehlend bestätigt werden, werden sie ersetzt — siehe [**Font-Ersetzung**](https://docs.aspose.com/slides/java/font-replacement/) und [**Font-Substitution**](https://docs.aspose.com/slides/java/font-substitution/).

Dies ist der Prozess, dem Aspose.Slides bei der Verarbeitung von Schriftarten folgt:

1. Aspose.Slides sucht im Betriebssystem nach Schriftarten, um die Schriftart zu finden, die der in der Präsentation gewählten Schriftart entspricht.  
2. Wird die gewählte Schriftart gefunden, verwendet Aspose.Slides sie. Andernfalls verwendet Aspose.Slides eine Ersatzschriftart, die so nahe wie möglich an das herankommt, was PowerPoint verwenden würde.  
3. Wenn über [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) Schriftart-Ersetzungsregeln festgelegt wurden, werden diese angewendet.  

Aspose.Slides ermöglicht das Hinzufügen von Schriftarten zur Laufzeit der Anwendung und deren Nutzung. Siehe [**Benutzerdefinierte Fonts**](https://docs.aspose.com/slides/java/custom-font/).  

Wenn zusätzliche Schriftarten in einer Präsentation abgelegt werden, nennt man sie [**Eingebettete Fonts**](https://docs.aspose.com/slides/java/embedded-font/).  

Aspose.Slides erlaubt das Hinzufügen von Schriftarten, die **nur** auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriftarten enthält, die in Ihrem System und in den eingebetteten Fonts fehlen, können Sie die benötigten Schriftarten als **externe Fonts** hinzufügen oder laden.  

{{% alert title="Hinweis" color="primary" %}} 
Wir verteilen keine Schriftarten, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Fonts und das Einbetten in Dokumente, jedoch geschieht dies nach Ihrem Ermessen und Ihrer Verantwortung. 
{{% /alert %}}

## **FAQ**

**Wie kann ich bestimmen, welche Schriftarten tatsächlich in einer Präsentation vor der Konvertierung verwendet werden?**

Aspose.Slides lässt Sie die über den [font manager](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/) verwendeten Schriftarten inspizieren, sodass Sie entscheiden können, ob Sie [einbetten](/slides/de/java/embedded-font/), [ersetzen](/slides/de/java/font-replacement/) oder [externe Quellen](/slides/de/java/custom-font/) hinzufügen möchten. Das hilft, unerwünschte Substitutionen während des Renderns und Exports zu verhindern.

**Kann ich zusätzliche Schriftartenverzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [externe Font-Quellen](/slides/de/java/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dies entfernt die Abhängigkeit von den Systemfonts des Hosts und hält das Layout vorhersehbar.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schriftart, wenn ein Glyph fehlt?**

Definieren Sie im Voraus eindeutige [Font-Ersetzung](/slides/de/java/font-replacement/) und Font-[Fallback‑Regeln](/slides/de/java/fallback-font/). Durch Analyse der verwendeten Schriftarten und Festlegung einer kontrollierten Priorität für Ersatzschriften stellen Sie konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.