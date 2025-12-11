---
title: Slide-Show auf Android verwalten
linktitle: Slide-Show
type: docs
weight: 90
url: /de/androidjava/manage-slide-show/
keywords:
- Show-Typ
- Präsentiert vom Redner
- Einzeln betrachtet
- Im Kiosk betrachtet
- Show-Optionen
- Durchgehend wiederholen
- Ohne Erzählung anzeigen
- Ohne Animation anzeigen
- Stiftfarbe
- Folien anzeigen
- Benutzerdefinierte Show
- Folien fortschreiten lassen
- Manuell
- Mit Zeitabläufen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Slide-Shows in Aspose.Slides für Android via Java verwalten. Steuern Sie Folienübergänge, Zeitabläufe und mehr in PPT-, PPTX- und ODP-Formaten mühelos."
---

In Microsoft PowerPoint sind die **Slide Show**‑Einstellungen ein wichtiges Werkzeug zum Erstellen und Vorführen professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, mit der Sie Ihre Präsentation an bestimmte Bedingungen und Zielgruppen anpassen können, was Flexibilität und Komfort gewährleistet. Mit dieser Funktion können Sie den Präsentationstyp auswählen (z. B. präsentiert von einem Redner, von einer Person angesehen oder an einem Kiosk angesehen), das Schleifen aktivieren oder deaktivieren, bestimmte Folien zum Anzeigen auswählen und Zeitabläufe nutzen. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation wirkungsvoller und professioneller zu machen.

`getSlideShowSettings` ist eine Methode der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) , die ein Objekt vom Typ [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/) zurückgibt, mit dem Sie die Slide‑Show‑Einstellungen in einer PowerPoint‑Präsentation verwalten können. In diesem Artikel werden wir untersuchen, wie Sie diese Methode verwenden, um verschiedene Aspekte der Slide‑Show‑Einstellungen zu konfigurieren und zu steuern. 

## **Show‑Typ auswählen**

`SlideShowSettings.setSlideShowType` definiert den Typ der Slide‑Show, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/), oder [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). Mit dieser Methode können Sie die Präsentation an verschiedene Nutzungsszenarien anpassen, z. B. automatisierte Kioske oder manuelle Präsentationen.

Das nachfolgende Code‑Beispiel erstellt eine neue Präsentation und legt den Show‑Typ auf „Browsed by an individual“ fest, ohne die Bildlaufleiste anzuzeigen.
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Show‑Optionen aktivieren**

`SlideShowSettings.setLoop` bestimmt, ob die Slide‑Show in einer Schleife wiederholt werden soll, bis sie manuell gestoppt wird. Dies ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen müssen. `SlideShowSettings.setShowNarration` bestimmt, ob Sprach‑Narrationen während der Slide‑Show abgespielt werden sollen. Dies ist nützlich für automatisierte Präsentationen, die Sprach‑Anleitungen für das Publikum enthalten. `SlideShowSettings.setShowAnimation` bestimmt, ob zu Folienobjekten hinzugefügte Animationen abgespielt werden sollen. Dies ist nützlich, um die volle visuelle Wirkung der Präsentation zu erzielen.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und lässt die Slide‑Show schleifen.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Folien zum Anzeigen auswählen**

`SlideShowSettings.setSlides` ermöglicht es Ihnen, einen Bereich von Folien auszuwählen, die während der Präsentation angezeigt werden sollen. Dies ist nützlich, wenn Sie nur einen Teil der Präsentation und nicht alle Folien zeigen möchten.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und legt den Folienbereich von Folie `2` bis `9` zum Anzeigen fest.
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Fortschrittliche Folien verwenden**

`SlideShowSettings.setUseTimings` ermöglicht es Ihnen, die Verwendung vordefinierter Zeitabläufe für jede Folie zu aktivieren oder zu deaktivieren. Dies ist nützlich, um Folien automatisch mit vordefinierten Anzeigedauern zu zeigen. Das folgende Code‑Beispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Zeitabläufen.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Mediensteuerelemente anzeigen**

`SlideShowSettings.setShowMediaControls` bestimmt, ob Mediensteuerelemente (wie Abspielen, Anhalten und Stoppen) während der Slide‑Show angezeigt werden sollen, wenn Multimedia‑Inhalte (z. B. Video oder Audio) abgespielt werden. Dies ist nützlich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerelementen.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**Kann ich eine Präsentation speichern, sodass sie direkt im Präsentationsmodus geöffnet wird?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten direkt im Präsentationsmodus, wenn sie in PowerPoint geöffnet werden. In Aspose.Slides wählen Sie das entsprechende Speicherformat [während des Exports](/slides/de/androidjava/save-presentation/).

**Kann ich einzelne Folien von der Show ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [hidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Slide‑Show nicht angezeigt.

**Kann Aspose.Slides eine Slide‑Show abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Viewer‑Anwendung wie PowerPoint übernommen.