---
title: Verwalten von Folienpräsentationen in PHP
linktitle: Folienpräsentation
type: docs
weight: 90
url: /de/php-java/manage-slide-show/
keywords:
- Showtyp
- vom Sprecher präsentiert
- von einzelner Person durchgesehen
- an Kiosk durchgesehen
- Anzeigeoptionen
- kontinuierlich wiederholen
- ohne Erzählung anzeigen
- ohne Animation anzeigen
- Stiftfarbe
- Folien anzeigen
- Benutzerdefinierte Show
- Folien vorwärts
- manuell
- mit Timings
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienpräsentationen in Aspose.Slides für PHP über Java verwalten. Steuern Sie Folienübergänge, Timings und mehr in PPT-, PPTX- und ODP-Formaten mühelos."
---

In Microsoft PowerPoint sind die **Slide Show**-Einstellungen ein wichtiges Werkzeug zur Vorbereitung und Durchführung professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, mit der Sie Ihre Präsentation an bestimmte Bedingungen und Zielgruppen anpassen können, was Flexibilität und Komfort gewährleistet. Mit dieser Funktion können Sie den Präsentationstyp auswählen (z.B. von einem Sprecher präsentiert, von einer einzelnen Person durchgesehen oder an einem Kiosk durchgesehen), das Looping aktivieren oder deaktivieren, bestimmte Folien zur Anzeige auswählen und Timings verwenden. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation effektiver und professioneller zu machen.

`getSlideShowSettings` ist eine Methode der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse, die ein Objekt vom Typ [SlideShowSettings](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowsettings/) zurückgibt, mit dem Sie die Slide‑Show‑Einstellungen in einer PowerPoint‑Präsentation verwalten können. In diesem Artikel erfahren Sie, wie Sie diese Methode verwenden, um verschiedene Aspekte der Slide‑Show‑Einstellungen zu konfigurieren und zu steuern. 

## **Showtyp auswählen**

`SlideShowSettings->setSlideShowType` definiert den Typ der Slide‑Show, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/php-java/aspose.slides/browsedbyindividual/), oder [BrowsedAtKiosk](https://reference.aspose.com/slides/php-java/aspose.slides/browsedatkiosk/). Mit dieser Methode können Sie die Präsentation an verschiedene Anwendungsszenarien anpassen, z.B. automatisierte Kioske oder manuelle Präsentationen.

Das nachstehende Codebeispiel erstellt eine neue Präsentation und legt den Showtyp auf „Browsed by an individual“ fest, ohne die Bildlaufleiste anzuzeigen.
```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Showoptionen aktivieren**

`SlideShowSettings->setLoop` bestimmt, ob die Slide‑Show in einer Schleife wiederholt werden soll, bis sie manuell gestoppt wird. Dies ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen müssen. `SlideShowSettings->setShowNarration` legt fest, ob während der Slide‑Show Sprachnarrationen abgespielt werden sollen. Dies ist nützlich für automatisierte Präsentationen, die eine sprachliche Anleitung für das Publikum enthalten. `SlideShowSettings->setShowAnimation` bestimmt, ob zu Folienobjekten hinzugefügte Animationen abgespielt werden sollen. Dies ist nützlich, um den vollen visuellen Effekt der Präsentation zu erzielen.

Das folgende Codebeispiel erstellt eine neue Präsentation und lässt die Slide‑Show wiederholen.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Anzuzeigende Folien auswählen**

Die Methode `SlideShowSettings->setSlides` ermöglicht es Ihnen, einen Folienbereich auszuwählen, der während der Präsentation angezeigt werden soll. Dies ist nützlich, wenn Sie nur einen Teil der Präsentation statt aller Folien zeigen möchten. Das folgende Codebeispiel erstellt eine neue Präsentation und legt den anzuzeigenden Folienbereich von Folie `2` bis `9` fest.
```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Fortschritt der Folien verwenden**

Die Methode `SlideShowSettings->setUseTimings` ermöglicht es, die Verwendung vordefinierter Timings für jede Folie zu aktivieren oder zu deaktivieren. Dies ist nützlich, um Folien automatisch mit vorab festgelegten Anzeigedauern zu präsentieren. Das untenstehende Codebeispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Timings.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Mediensteuerungen anzeigen**

Die Methode `SlideShowSettings->setShowMediaControls` legt fest, ob Mediensteuerelemente (wie Wiedergabe, Pause und Stopp) während der Slide‑Show angezeigt werden sollen, wenn multimediale Inhalte (z.B. Video oder Audio) abgespielt werden. Dies ist nützlich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Codebeispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerelementen.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **FAQ**

**Kann ich eine Präsentation speichern, sodass sie direkt im Folienmodus geöffnet wird?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten beim Öffnen in PowerPoint direkt im Folienmodus. In Aspose.Slides wählen Sie das entsprechende Speicherformat [during export](/slides/de/php-java/save-presentation/).

**Kann ich einzelne Folien von der Show ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [hidden](https://reference.aspose.com/slides/php-java/aspose.slides/slide/sethidden/). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Folienpräsentation nicht angezeigt.

**Kann Aspose.Slides eine Folienpräsentation abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Viewer‑Anwendung wie PowerPoint übernommen.