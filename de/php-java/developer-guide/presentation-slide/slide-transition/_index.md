---
title: Verwalten von Folienübergängen in Präsentationen mit PHP
linktitle: Folienübergang
type: docs
weight: 80
url: /de/php-java/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang anwenden
- Erweiterter Folienübergang
- Morph-Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie, wie Sie Folienübergänge in Aspose.Slides für PHP via Java anpassen können, mit Schritt‑für‑Schritt‑Anleitungen für PowerPoint‑ und OpenDocument‑Präsentationen."
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides für PHP via Java ermöglicht Entwicklern zudem, die Folienübergangseffekte zu verwalten oder anzupassen. In diesem Thema behandeln wir die einfache Steuerung von Folienübergängen mit Aspose.Slides für PHP via Java.

{{% /alert %}} 

Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides für PHP via Java zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen.

## **Folienübergang hinzufügen**
Um einen einfachen Folienübergangseffekt zu erstellen, folgen Sie den unten stehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für PHP via Java angebotenen Übergangseffekte über das TransitionType‑Enum auswählen.
1. Schreiben Sie die geänderte Präsentationsdatei.
```php
  # Instantiieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Wenden Sie den Kreis-Übergangstyp auf Folie 1 an
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Wenden Sie den Kamm-Übergangstyp auf Folie 2 an
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Speichern Sie die Präsentation auf dem Datenträger
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Erweiterte Folienübergänge hinzufügen**
Im vorherigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergangseffekt noch besser und kontrollierter zu gestalten, folgen Sie bitte den unten stehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für PHP via Java angebotenen Übergangseffekte auswählen.
1. Sie können den Übergang auch so einstellen, dass er bei Klick, nach einem bestimmten Zeitraum oder beides voranschreitet.
1. Wenn der Folienübergang auf „Advance On Click“ (Bei Klick fortschreiten) eingestellt ist, wird er nur dann fortschreiten, wenn jemand die Maus klickt. Außerdem wird der Übergang automatisch fortschreiten, sobald die im Advance After Time‑Eigenschaft festgelegte Zeit verstrichen ist.
1. Schreiben Sie die geänderte Präsentation in eine Präsentationsdatei.
```php
  # Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Wenden Sie den Kreis‑Übergangstyp auf Folie 1 an
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Setzen Sie die Übergangszeit von 3 Sekunden
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Wenden Sie den Kamm‑Übergangstyp auf Folie 2 an
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Setzen Sie die Übergangszeit von 5 Sekunden
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Wenden Sie den Zoom‑Übergangstyp auf Folie 3 an
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Setzen Sie die Übergangszeit von 7 Sekunden
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Schreiben Sie die Präsentation auf die Festplatte
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Morph-Übergang**
{{% alert color="primary" %}} 

Aspose.Slides für PHP via Java unterstützt jetzt den [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/). Sie stellen den neuen Morph‑Übergang dar, der in PowerPoint 2019 eingeführt wurde.

{{% /alert %}} 

Der Morph‑Übergang ermöglicht es Ihnen, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Verwendung des Morph‑Übergangs. Um den Morph‑Übergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg ist, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Position zu verschieben.

Der folgende Code‑Abschnitt zeigt, wie Sie eine Kopie der Folie mit etwas Text zur Präsentation hinzufügen und der zweiten Folie einen Übergang des [morph type](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) zuweisen.
```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Morph-Übergangstypen**
Ein neues Enum [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) wurde hinzugefügt. Es stellt verschiedene Typen des Morph‑Folienübergangs dar.

Das TransitionMorphType‑Enum hat drei Mitglieder:

- ByObject: Der Morph‑Übergang wird unter Berücksichtigung der Formen als unteilbare Objekte durchgeführt.
- ByWord: Der Morph‑Übergang wird nach Möglichkeit Text wortweise übertragen.
- ByChar: Der Morph‑Übergang wird nach Möglichkeit Text zeichenweise übertragen.

Der folgende Code‑Abschnitt zeigt, wie Sie den Morph‑Übergang für eine Folie festlegen und den Morph‑Typ ändern:
```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Übergangseffekte festlegen**
Aspose.Slides für PHP via Java unterstützt das Festlegen von Übergangseffekten wie „von Schwarz“, „von links“, „von rechts“ usw. Um den Übergangseffekt festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Holen Sie die Referenz der Folie.
- Legen Sie den Übergangseffekt fest.
- Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Im unten gezeigten Beispiel haben wir die Übergangseffekte festgelegt.
```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Effekt festlegen
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Speichern Sie die Präsentation auf dem Datenträger
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Setzen Sie die [speed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (z. B. slow/medium/fast).

**Kann ich einer Transition Audio hinzufügen und es wiederholen?**

Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Wiederholung steuern (z. B. [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/), plus Metadaten wie [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) und [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang derzeit auf einer Folie eingestellt ist?**

Untersuchen Sie die [transition settings](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie und lesen Sie deren [transition type](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/); dieser Wert gibt genau an, welcher Effekt angewendet wird.