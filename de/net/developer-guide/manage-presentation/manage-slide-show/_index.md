---
title: Slide Show in .NET verwalten
linktitle: Slide-Show
type: docs
weight: 90
url: /de/net/manage-slide-show/
keywords:
- Anzeigetyp
- präsentiert vom Redner
- durchblättert von Einzelperson
- durchblättert im Kiosk
- Anzeigeoptionen
- schleifen kontinuierlich
- Anzeige ohne Erzählung
- Anzeige ohne Animation
- Stiftfarbe
- Folien anzeigen
- Benutzerdefinierte Show
- Folien vorwärts schalten
- manuell
- mit Timings
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Slide-Shows in Aspose.Slides für .NET verwalten. Steuern Sie Folienübergänge, Timings und mehr in PPT-, PPTX- und ODP-Formaten mühelos."
---

In Microsoft PowerPoint sind die **Slide Show**‑Einstellungen ein wichtiges Werkzeug zum Vorbereiten und Durchführen professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, die es Ihnen ermöglicht, Ihre Präsentation an bestimmte Bedingungen und Zielgruppen anzupassen und dadurch Flexibilität und Komfort zu gewährleisten. Mit dieser Funktion können Sie den Anzeigetyp auswählen (z. B. präsentiert von einem Redner, von einer Einzelperson durchblättert oder an einem Kiosk durchblättert), das Schleifen aktivieren oder deaktivieren, bestimmte Folien zur Anzeige auswählen und Timings verwenden. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation wirksamer und professioneller zu machen.

`SlideShowSettings` ist eine Eigenschaft der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) , vom Typ [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/) , mit der Sie die Slide‑Show‑Einstellungen in einer PowerPoint‑Präsentation verwalten können. In diesem Artikel untersuchen wir, wie man diese Eigenschaft verwendet, um verschiedene Aspekte der Slide‑Show‑Einstellungen zu konfigurieren und zu steuern. 

## **Auswahl des Anzeigetyps**

`SlideShowSettings.SlideShowType` definiert den Typ der Slide‑Show, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/) oder [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Durch die Verwendung dieser Eigenschaft können Sie die Präsentation an unterschiedliche Nutzungsszenarien anpassen, z. B. automatisierte Kioske oder manuelle Präsentationen.

Das untenstehende Code‑Beispiel erstellt eine neue Präsentation und setzt den Anzeigetyp auf „Browsed by an individual“, ohne die Bildlaufleiste anzuzeigen.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Show‑Optionen aktivieren**

`SlideShowSettings.Loop` legt fest, ob die Slide‑Show in einer Schleife wiederholt wird, bis sie manuell gestoppt wird. Dies ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen müssen. `SlideShowSettings.ShowNarration` bestimmt, ob während der Slide‑Show Sprach‑Narrationen abgespielt werden sollen. Das ist nützlich für automatisierte Präsentationen, die Sprach‑Anleitungen für das Publikum enthalten. `SlideShowSettings.ShowAnimation` legt fest, ob Animationen, die zu Folienobjekten hinzugefügt wurden, abgespielt werden sollen. Dies ist hilfreich, um den vollen visuellen Effekt der Präsentation zu bieten.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und lässt die Slide‑Show schleifen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Auswahl der anzuzeigenden Folien**

`SlideShowSettings.Slides` ermöglicht es Ihnen, einen Bereich von Folien auszuwählen, die während der Präsentation angezeigt werden sollen. Dies ist nützlich, wenn Sie nur einen Teil der Präsentation und nicht alle Folien zeigen möchten. Das folgende Code‑Beispiel erstellt eine neue Präsentation und legt den Folienbereich fest, der von Folie `2` bis `9` angezeigt wird.
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


## **Erweiterte Folien verwenden**

`SlideShowSettings.UseTimings` ermöglicht es, die Verwendung vordefinierter Timings für jede Folie zu aktivieren oder zu deaktivieren. Dies ist nützlich, um Folien automatisch mit festgelegten Anzeigedauern zu präsentieren. Das untenstehende Code‑Beispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Timings.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Mediensteuerungen anzeigen**

`SlideShowSettings.ShowMediaControls` legt fest, ob Mediensteuerungen (wie Abspielen, Pause und Stoppen) während der Slide‑Show angezeigt werden sollen, wenn Multimedia‑Inhalte (z. B. Video oder Audio) abgespielt werden. Dies ist nützlich, wenn Sie dem Vortragenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerungen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Kann ich eine Präsentation speichern, damit sie direkt im Folien‑Show‑Modus geöffnet wird?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten direkt im Folien‑Show‑Modus, wenn sie in PowerPoint geöffnet werden. In Aspose.Slides wählen Sie das entsprechende Speicherformat [during export](/slides/de/net/save-presentation/).

**Kann ich einzelne Folien aus der Show ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Folien‑Show nicht angezeigt.

**Kann Aspose.Slides eine Folien‑Show abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Viewer‑Anwendung wie PowerPoint übernommen.