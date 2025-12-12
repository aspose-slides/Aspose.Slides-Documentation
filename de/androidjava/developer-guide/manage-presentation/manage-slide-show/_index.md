---
title: Slide Show auf Android verwalten
linktitle: Slide Show
type: docs
weight: 90
url: /de/androidjava/manage-slide-show/
keywords:
- Show-Typ
- präsentiert vom Redner
- von Einzelperson angezeigt
- am Kiosk angezeigt
- Show-Optionen
- dauerhaft wiederholen
- Show ohne Erzählung
- Show ohne Animation
- Stiftfarbe
- Folien anzeigen
- benutzerdefinierte Show
- Folien vorwärtsblättern
- manuell
- mit Timings
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Slide-Shows in Aspose.Slides für Android via Java verwalten. Steuern Sie Folienübergänge, Timings und mehr mühelos in den Formaten PPT, PPTX und ODP."
---

In Microsoft PowerPoint sind die **Slide Show**-Einstellungen ein wichtiges Werkzeug zum Vorbereiten und Präsentieren professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, die es Ihnen ermöglicht, Ihre Präsentation an bestimmte Bedingungen und Zielgruppen anzupassen und so Flexibilität und Komfort zu gewährleisten. Mit dieser Funktion können Sie den Show‑Typ auswählen (z. B. präsentiert von einem Redner, von einer Person durchgesehen oder an einem Kiosk durchgesehen), das Wiederholen aktivieren oder deaktivieren, bestimmte Folien zur Anzeige auswählen und Timings verwenden. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation wirkungsvoller und professioneller zu machen.

`getSlideShowSettings` ist eine Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse, die ein Objekt vom Typ [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/) zurückgibt, mit dem Sie die Slide‑Show‑Einstellungen in einer PowerPoint‑Präsentation verwalten können. In diesem Artikel werden wir untersuchen, wie Sie diese Methode verwenden, um verschiedene Aspekte der Slide‑Show‑Einstellungen zu konfigurieren und zu steuern. 

## **Show‑Typ auswählen**

`SlideShowSettings.setSlideShowType` definiert den Typ der Slide‑Show, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/), oder [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). Die Verwendung dieser Methode ermöglicht es Ihnen, die Präsentation an verschiedene Anwendungsszenarien anzupassen, wie z. B. automatisierte Kioske oder manuelle Präsentationen.

Das nachstehende Codebeispiel erstellt eine neue Präsentation und setzt den Show‑Typ auf „Browsed by an individual“, ohne die Bildlaufleiste anzuzeigen.
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Show‑Optionen aktivieren**

`SlideShowSettings.setLoop` bestimmt, ob die Slide‑Show in einer Schleife wiederholt werden soll, bis sie manuell gestoppt wird. Dies ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen müssen. `SlideShowSettings.setShowNarration` legt fest, ob Sprachkommentare während der Slide‑Show abgespielt werden sollen. Dies ist hilfreich für automatisierte Präsentationen, die eine Sprachführung für das Publikum enthalten. `SlideShowSettings.setShowAnimation` legt fest, ob Animationen, die zu Folienobjekten hinzugefügt wurden, abgespielt werden sollen. Dies ist nützlich, um den vollen visuellen Effekt der Präsentation zu gewährleisten.

Das folgende Codebeispiel erstellt eine neue Präsentation und lässt die Slide‑Show wiederholen.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Anzuzeigende Folien auswählen**

`SlideShowSettings.setSlides`‑Methode ermöglicht es Ihnen, einen Bereich von Folien auszuwählen, die während der Präsentation angezeigt werden sollen. Dies ist nützlich, wenn Sie nur einen Teil der Präsentation und nicht alle Folien zeigen möchten. Das folgende Codebeispiel erstellt eine neue Präsentation und legt den Folienbereich fest, der von Folie `2` bis `9` angezeigt wird.
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Automatisches Vorwärtsblättern verwenden**

`SlideShowSettings.setUseTimings`‑Methode ermöglicht es Ihnen, die Verwendung vordefinierter Timings für jede Folie zu aktivieren oder zu deaktivieren. Dies ist nützlich, um Folien automatisch mit vordefinierten Anzeigedauern zu präsentieren. Das untenstehende Codebeispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Timings.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Mediensteuerungen anzeigen**

`SlideShowSettings.setShowMediaControls`‑Methode bestimmt, ob Mediensteuerelemente (wie Abspielen, Pause und Stopp) während der Slide‑Show angezeigt werden sollen, wenn multimediale Inhalte (z. B. Video oder Audio) wiedergegeben werden. Dies ist nützlich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Codebeispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerelementen.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**Kann ich eine Präsentation speichern, sodass sie direkt im Slide‑Show‑Modus geöffnet wird?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten beim Öffnen in PowerPoint direkt im Slide‑Show‑Modus. In Aspose.Slides wählen Sie das entsprechende Speicherformat [während des Exports](/slides/de/androidjava/save-presentation/).

**Kann ich einzelne Folien von der Show ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [hidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Slide‑Show nicht angezeigt.

**Kann Aspose.Slides eine Slide‑Show abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Viewer‑Anwendung wie PowerPoint übernommen.