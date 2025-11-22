---
title: Bildschirmpräsentation verwalten
type: docs
weight: 90
url: /de/net/manage-slide-show/
keywords:
- Anzeigetyp
- vom Sprecher präsentiert
- von einer Einzelperson durchsucht
- im Kiosk-Modus
- Anzeigeoptionen
- schleifen kontinuierlich
- ohne Erzählung anzeigen
- ohne Animation anzeigen
- Stiftfarbe
- Folien anzeigen
- Benutzerdefinierte Anzeige
- Folien vorwärts
- manuell
- mit Timings
- PowerPoint
- Präsentation
- C#
- .NET
- Aspose.Slides für .NET
description: "Bildschirmpräsentationseinstellungen in PowerPoint-Präsentationen mit C# verwalten"
---

In Microsoft PowerPoint sind die **Bildschirmpräsentation**‑Einstellungen ein wichtiges Werkzeug zur Vorbereitung und Durchführung professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, das Ihnen ermöglicht, Ihre Präsentation an bestimmte Bedingungen und Zielgruppen anzupassen und dabei Flexibilität und Komfort zu gewährleisten. Mit dieser Funktion können Sie den Anzeigetyp auswählen (z. B. Präsentation durch einen Sprecher, durch einen einzelnen Betrachter oder im Kiosk‑Modus), das Schleifen aktivieren oder deaktivieren, bestimmte Folien zur Anzeige auswählen und Zeitsteuerungen verwenden. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation wirkungsvoller und professioneller zu gestalten.

`SlideShowSettings` ist eine Eigenschaft der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) vom Typ [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), die Ihnen ermöglicht, die Bildschirmpräsentationseinstellungen in einer PowerPoint‑Präsentation zu verwalten. In diesem Artikel zeigen wir, wie Sie diese Eigenschaft verwenden, um verschiedene Aspekte der Bildschirmpräsentationseinstellungen zu konfigurieren und zu steuern. 

## **Auswahl des Anzeigetyps**

`SlideShowSettings.SlideShowType` definiert den Typ der Bildschirmpräsentation, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), oder [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Mit dieser Eigenschaft können Sie die Präsentation an verschiedene Nutzungsszenarien anpassen, z. B. automatisierte Kioske oder manuelle Präsentationen.

Das nachstehende Codebeispiel erstellt eine neue Präsentation und setzt den Anzeigetyp auf „Durch einen einzelnen Betrachter“ ohne die Bildlaufleiste anzuzeigen.
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

`SlideShowSettings.Loop` bestimmt, ob die Bildschirmpräsentation in einer Schleife wiederholt werden soll, bis sie manuell gestoppt wird. Dies ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen müssen. `SlideShowSettings.ShowNarration` bestimmt, ob während der Bildschirmpräsentation Sprachkommentare abgespielt werden sollen. Das ist nützlich für automatisierte Präsentationen, die eine Sprachführung für das Publikum enthalten. `SlideShowSettings.ShowAnimation` bestimmt, ob Animationen, die Folienobjekten hinzugefügt wurden, abgespielt werden sollen. Dies ist nützlich, um den vollen visuellen Effekt der Präsentation zu vermitteln.

Das folgende Codebeispiel erstellt eine neue Präsentation und lässt die Bildschirmpräsentation wiederholt ablaufen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Auswahl der anzuzeigenden Folien**

`SlideShowSettings.Slides` ermöglicht es Ihnen, einen Folienbereich auszuwählen, der während der Präsentation angezeigt werden soll. Dies ist nützlich, wenn Sie nur einen Teil der Präsentation und nicht alle Folien zeigen möchten. Das folgende Codebeispiel erstellt eine neue Präsentation und legt den Folienbereich von Folie `2` bis `9` fest.
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


## **Timings verwenden**

`SlideShowSettings.UseTimings` ermöglicht das Aktivieren oder Deaktivieren der Verwendung vordefinierter Timings für jede Folie. Dies ist nützlich, um Folien automatisch mit vorher festgelegten Anzeigedauern zu zeigen. Das nachstehende Codebeispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Timings.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Mediensteuerelemente anzeigen**

`SlideShowSettings.ShowMediaControls` bestimmt, ob Mediensteuerelemente (wie Wiedergabe, Pause und Stopp) während der Bildschirmpräsentation angezeigt werden, wenn multimediale Inhalte (z. B. Video oder Audio) abgespielt werden. Dies ist nützlich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Codebeispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerelementen.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Kann ich eine Präsentation speichern, so dass sie beim Öffnen direkt im Bildschirmpräsentationsmodus startet?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten die Bildschirmpräsentation direkt, wenn sie in PowerPoint geöffnet wird. In Aspose.Slides wählen Sie das entsprechende Speicherformat [bei der Exportierung](/slides/de/net/save-presentation/).

**Kann ich einzelne Folien von der Präsentation ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Bildschirmpräsentation nicht angezeigt.

**Kann Aspose.Slides eine Bildschirmpräsentation abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Anzeiganwendung wie PowerPoint übernommen.