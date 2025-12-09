---
title: Slide-Show verwalten
type: docs
weight: 90
url: /de/nodejs-java/manage-slide-show/
keywords:
- Show-Typ
- von einem Redner präsentiert
- von einer Einzelperson durchblättert
- an einem Kiosk durchblättert
- Show-Optionen
- kontinuierlich wiederholen
- ohne Erzählertext anzeigen
- ohne Animation anzeigen
- Stiftfarbe
- Folien anzeigen
- benutzerdefinierte Show
- Folien vorwärts schalten
- manuell
- mit Timings verwenden
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "Verwalten von Slide-Show-Einstellungen in PowerPoint-Präsentationen mit JavaScript"
---

In Microsoft PowerPoint sind die **Slide Show**‑Einstellungen ein wichtiges Werkzeug zum Vorbereiten und Durchführen professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, die es Ihnen ermöglicht, Ihre Präsentation an bestimmte Bedingungen und Zielgruppen anzupassen und so Flexibilität und Komfort zu gewährleisten. Mit dieser Funktion können Sie den Anzeigetyp auswählen (z. B. von einem Redner präsentiert, von einer Einzelperson durchblättert oder an einem Kiosk durchblättert), das Looping ein‑ oder ausschalten, bestimmte Folien zur Anzeige auswählen und Timings verwenden. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation wirkungsvoller und professioneller zu gestalten.

`getSlideShowSettings` ist eine Methode der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) , die ein Objekt vom Typ [SlideShowSettings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowsettings/) zurückgibt, mit dem Sie die Slide‑Show‑Einstellungen in einer PowerPoint‑Präsentation verwalten können. In diesem Artikel zeigen wir, wie Sie diese Methode verwenden, um verschiedene Aspekte der Slide‑Show‑Einstellungen zu konfigurieren und zu steuern. 

## **Show‑Typ auswählen**

`SlideShowSettings.setSlideShowType` definiert den Typ der Slide‑Show, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedbyindividual/) oder [BrowsedAtKiosk](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedatkiosk/). Durch die Verwendung dieser Methode können Sie die Präsentation an verschiedene Nutzungsszenarien anpassen, z. B. automatisierte Kioske oder manuelle Präsentationen.

Das nachstehende Codebeispiel erstellt eine neue Präsentation und setzt den Show‑Typ auf „Browsed by an individual“, ohne die Bildlaufleiste anzuzeigen.
```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Show‑Optionen aktivieren**

`SlideShowSettings.setLoop` bestimmt, ob die Slide‑Show in einer Schleife wiederholt werden soll, bis sie manuell gestoppt wird. Dies ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen müssen. `SlideShowSettings.setShowNarration` legt fest, ob während der Slide‑Show gesprochene Kommentare abgespielt werden sollen. Das ist hilfreich für automatisierte Präsentationen, die dem Publikum eine Sprachführung bieten. `SlideShowSettings.setShowAnimation` bestimmt, ob Animationen, die Folienobjekten hinzugefügt wurden, abgespielt werden. Das ist nützlich, um den vollständigen visuellen Effekt der Präsentation zu gewährleisten.

Das folgende Codebeispiel erstellt eine neue Präsentation und wiederholt die Slide‑Show in einer Schleife.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Folien zum Anzeigen auswählen**

`SlideShowSettings.setSlides` ermöglicht es Ihnen, einen Folienbereich festzulegen, der während der Präsentation angezeigt werden soll. Das ist nützlich, wenn Sie nur einen Teil der Präsentation statt aller Folien zeigen möchten. Das nachstehende Codebeispiel erstellt eine neue Präsentation und legt den Folienbereich von Folie `2` bis `9` fest.
```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Automatisches Vorwärtsblättern von Folien**

`SlideShowSettings.setUseTimings` erlaubt das Aktivieren oder Deaktivieren der Verwendung vordefinierter Timings für jede Folie. Das ist praktisch, um Folien automatisch mit festgelegten Anzeigedauern zu zeigen. Das unten stehende Codebeispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Timings.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Mediensteuerungen anzeigen**

`SlideShowSettings.setShowMediaControls` legt fest, ob Mediensteuerungen (wie Play, Pause und Stop) während der Slide‑Show angezeigt werden sollen, wenn multimediale Inhalte (z. B. Video oder Audio) wiedergegeben werden. Das ist nützlich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Codebeispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerungen.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**Kann ich eine Präsentation speichern, sodass sie direkt im Slide‑Show‑Modus geöffnet wird?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten die Slide‑Show direkt, wenn sie in PowerPoint geöffnet werden. In Aspose.Slides wählen Sie das entsprechende Speicherformat [during export](/slides/de/nodejs-java/save-presentation/).

**Kann ich einzelne Folien von der Show ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [hidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/sethidden/). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Slide‑Show nicht angezeigt.

**Kann Aspose.Slides eine Slide‑Show abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Viewer‑Anwendung wie PowerPoint übernommen.