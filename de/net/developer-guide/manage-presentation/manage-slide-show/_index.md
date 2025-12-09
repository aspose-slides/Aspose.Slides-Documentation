---
title: Diashow in .NET verwalten
linktitle: Diashow
type: docs
weight: 90
url: /de/net/manage-slide-show/
keywords:
- Anzeigetyp
- präsentiert vom Redner
- von Einzelperson durchsucht
- am Kiosk durchsucht
- Anzeigeoptionen
- Schleife kontinuierlich
- Anzeige ohne Erzählung
- Anzeige ohne Animation
- Stiftfarbe
- Folien anzeigen
- Benutzerdefinierte Anzeige
- Folien vorschieben
- manuell
- mit Zeitabläufen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diashows in Aspose.Slides für .NET verwalten. Steuern Sie Folienübergänge, Zeitabläufe und mehr in PPT-, PPTX- und ODP-Formaten mühelos."
---

In Microsoft PowerPoint sind die **Slide Show**‑Einstellungen ein wichtiges Werkzeug zum Vorbereiten und Vorführen professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, mit der Sie Ihre Präsentation an bestimmte Bedingungen und Zielgruppen anpassen können, um Flexibilität und Komfort zu gewährleisten. Mit dieser Funktion können Sie den Anzeigetyp auswählen (z. B. präsentiert von einem Redner, von einer einzelnen Person durchgesehen oder an einem Kiosk durchgesehen), das Schleifen aktivieren oder deaktivieren, bestimmte Folien zum Anzeigen auswählen und Zeitabläufe verwenden. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation effektiver und professioneller zu gestalten.

`SlideShowSettings` ist eine Eigenschaft der [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse vom Typ [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), die es Ihnen ermöglicht, die Diashow‑Einstellungen in einer PowerPoint‑Präsentation zu verwalten. In diesem Artikel untersuchen wir, wie Sie diese Eigenschaft verwenden, um verschiedene Aspekte der Diashow‑Einstellungen zu konfigurieren und zu steuern. 

## **Auswahl des Anzeigetyps**

`SlideShowSettings.SlideShowType` definiert den Typ der Diashow, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/) oder [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Mit dieser Eigenschaft können Sie die Präsentation an verschiedene Nutzungsszenarien anpassen, etwa automatisierte Kioske oder manuelle Präsentationen.

Der Code‑Beispiel unten erstellt eine neue Präsentation und setzt den Anzeigetyp auf „Durch eine einzelne Person durchgesehen“, ohne die Bildlaufleiste anzuzeigen.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Anzeigeoptionen aktivieren**

`SlideShowSettings.Loop` bestimmt, ob die Diashow in einer Schleife wiederholt werden soll, bis sie manuell gestoppt wird. Das ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen sollen. `SlideShowSettings.ShowNarration` legt fest, ob Sprachkommentare während der Diashow abgespielt werden sollen. Das ist hilfreich für automatisierte Präsentationen, die eine mündliche Anleitung für das Publikum enthalten. `SlideShowSettings.ShowAnimation` bestimmt, ob zu Folienobjekten hinzugefügte Animationen abgespielt werden sollen. Das ist nützlich, um den vollen visuellen Effekt der Präsentation zu zeigen.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und lässt die Diashow schleifen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Auswahl der anzuzeigenden Folien**

Die Eigenschaft `SlideShowSettings.Slides` ermöglicht Ihnen, einen Bereich von Folien auszuwählen, die während der Präsentation angezeigt werden sollen. Das ist praktisch, wenn Sie nur einen Teil der Präsentation und nicht alle Folien zeigen möchten. Das folgende Code‑Beispiel erstellt eine neue Präsentation und legt den Folienbereich von Folie `2` bis `9` fest.
```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Vortakten von Folien verwenden**

Die Eigenschaft `SlideShowSettings.UseTimings` ermöglicht das Aktivieren oder Deaktivieren der Verwendung vordefinierter Zeitabläufe für jede Folie. Das ist nützlich, um Folien automatisch mit festgelegten Anzeigedauern zu präsentieren. Das untenstehende Code‑Beispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Zeitabläufen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Mediensteuerelemente anzeigen**

Die Eigenschaft `SlideShowSettings.ShowMediaControls` bestimmt, ob Mediensteuerelemente (wie Wiedergabe, Pause und Stopp) während der Diashow angezeigt werden sollen, wenn multimediale Inhalte (z. B. Video oder Audio) abgespielt werden. Das ist nützlich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerelementen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Kann ich eine Präsentation speichern, sodass sie direkt im Diashow‑Modus öffnet?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten beim Öffnen in PowerPoint sofort im Diashow‑Modus. In Aspose.Slides wählen Sie das entsprechende Speicherformat [während des Exports](/slides/de/net/save-presentation/).

**Kann ich einzelne Folien von der Anzeige ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Diashow nicht angezeigt.

**Kann Aspose.Slides eine Diashow abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Viewer‑Anwendung wie PowerPoint übernommen.