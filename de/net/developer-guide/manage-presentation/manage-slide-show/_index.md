---
title: Verwalten der Bildschirmpräsentation in .NET
linktitle: Bildschirmpräsentation
type: docs
weight: 90
url: /de/net/manage-slide-show/
keywords:
- Anzeigetyp
- Von Redner präsentiert
- Von Einzelperson durchblättert
- Im Kiosk durchblättert
- Anzeigeoptionen
- Kontinuierlich wiederholen
- Anzeige ohne Sprache
- Anzeige ohne Animation
- Stiftfarbe
- Folien anzeigen
- Benutzerdefinierte Anzeige
- Folienvorschub
- Manuell
- Mit Zeitabläufen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Bildschirmpräsentationen in Aspose.Slides für .NET verwalten. Steuern Sie Folienübergänge, Zeitabläufe und mehr in den Formaten PPT, PPTX und ODP mühelos."
---

In Microsoft PowerPoint sind die **Slide Show**-Einstellungen ein wichtiges Werkzeug zum Vorbereiten und Durchführen professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, die es Ihnen ermöglicht, Ihre Präsentation an bestimmte Bedingungen und Zielgruppen anzupassen und so Flexibilität und Komfort zu gewährleisten. Mit dieser Funktion können Sie den Anzeigetyp auswählen (z. B. von einem Redner präsentiert, von einer Einzelperson durchblättert oder an einem Kiosk durchblättert), Schleifen aktivieren oder deaktivieren, bestimmte Folien zur Anzeige auswählen und Zeitabläufe verwenden. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation wirksamer und professioneller zu gestalten.

`SlideShowSettings` ist eine Eigenschaft der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) vom Typ [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), mit der Sie die Slide‑Show‑Einstellungen in einer PowerPoint‑Präsentation verwalten können. In diesem Artikel zeigen wir, wie Sie diese Eigenschaft verwenden, um verschiedene Aspekte der Slide‑Show‑Einstellungen zu konfigurieren und zu steuern. 

## **Auswahl des Anzeigetyps**

`SlideShowSettings.SlideShowType` definiert den Typ der Slide‑Show und kann eine Instanz einer der folgenden Klassen sein: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), oder [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Mit dieser Eigenschaft können Sie die Präsentation an verschiedene Nutzungsszenarien anpassen, wie z. B. automatisierte Kioske oder manuelle Präsentationen.

Das nachstehende Codebeispiel erstellt eine neue Präsentation und setzt den Anzeigetyp auf „Browsed by an individual“, ohne die Bildlaufleiste anzuzeigen.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Showoptionen aktivieren**

`SlideShowSettings.Loop` bestimmt, ob die Slide‑Show in einer Schleife wiederholt wird, bis sie manuell gestoppt wird. Das ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen sollen. `SlideShowSettings.ShowNarration` legt fest, ob während der Slide‑Show Sprachkommentare wiedergegeben werden sollen. Das ist praktisch für automatisierte Präsentationen, die eine gesprochene Anleitung für das Publikum enthalten. `SlideShowSettings.ShowAnimation` entscheidet, ob Animationen, die Folienobjekten hinzugefügt wurden, abgespielt werden sollen. Dies ist hilfreich, um den vollen visuellen Effekt der Präsentation zu erzielen.

Das folgende Codebeispiel erstellt eine neue Präsentation und lässt die Slide‑Show schleifen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Auswahl der anzuzeigenden Folien**

`SlideShowSettings.Slides` ermöglicht es Ihnen, einen Bereich von Folien auszuwählen, die während der Präsentation angezeigt werden sollen. Das ist nützlich, wenn Sie nur einen Teil der Präsentation und nicht alle Folien zeigen möchten. Das folgende Codebeispiel erstellt eine neue Präsentation und legt den Folienbereich von Folie `2` bis `9` fest.
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


## **Verwendung von Folienvorschub**

`SlideShowSettings.UseTimings` ermöglicht das Aktivieren oder Deaktivieren der Verwendung vordefinierter Zeitabläufe für jede Folie. Das ist nützlich, um Folien automatisch mit vordefinierten Anzeigedauern zu präsentieren. Das nachstehende Codebeispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Zeitabläufen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Mediensteuerungen anzeigen**

`SlideShowSettings.ShowMediaControls` legt fest, ob Mediensteuerelemente (wie Wiedergabe, Pause und Stopp) während der Slide‑Show angezeigt werden, wenn multimediale Inhalte (z. B. Video oder Audio) abgespielt werden. Das ist nützlich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Codebeispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerungen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Kann ich eine Präsentation speichern, sodass sie direkt im Slide‑Show‑Modus geöffnet wird?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten in PowerPoint direkt im Slide‑Show‑Modus. In Aspose.Slides wählen Sie das entsprechende Speicherformat [während des Exports](/slides/de/net/save-presentation/).

**Kann ich einzelne Folien von der Show ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Slide‑Show nicht angezeigt.

**Kann Aspose.Slides eine Slide‑Show abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Anzeigesoftware wie PowerPoint übernommen.