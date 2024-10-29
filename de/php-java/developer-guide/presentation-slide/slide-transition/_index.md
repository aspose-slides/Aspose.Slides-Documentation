---
title: Folienübergang
type: docs
weight: 80
url: /de/php-java/slide-transition/
keywords: "PowerPoint Folienübergang, Morphübergang"
description: "PowerPoint Folienübergang, PowerPoint Morphübergang"
---


## **Überblick**
{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java ermöglicht Entwicklern auch die Verwaltung oder Anpassung der Folienübergangseffekte der Folien. In diesem Thema werden wir besprechen, wie man Folienübergänge mit großer Leichtigkeit steuern kann, indem man Aspose.Slides für PHP über Java verwendet.

{{% /alert %}} 

Um es einfacher zu verstehen, haben wir die Verwendung von Aspose.Slides für PHP über Java zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen.

## **Folienübergang hinzufügen**
Um einen einfachen Folienübergangseffekt zu erstellen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für PHP über Java angebotenen Übergangseffekte durch das TransitionType-Enum an.
1. Schreiben Sie die modifizierte Präsentationsdatei.

```php
  # Instanziieren Sie die Präsentationsklasse, um die Quellpräsentationsdatei zu laden
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Wenden Sie einen kreisförmigen Übergang auf Folie 1 an
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Wenden Sie einen Kombiübergang auf Folie 2 an
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Schreiben Sie die Präsentation auf die Festplatte
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Erweiterten Folienübergang hinzufügen**
Im obigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergangseffekt noch besser und kontrollierbarer zu machen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für PHP über Java angebotenen Übergangseffekte an.
1. Sie können den Übergang auch auf "Beim Klicken weiterblättern", nach einer bestimmten Zeitspanne oder beidem einstellen.
1. Wenn der Folienübergang auf "Beim Klicken weiterblättern" aktiviert ist, wird der Übergang nur bei einem Mausklick weitergeführt. Außerdem wird der Übergang automatisch weitergeführt, wenn die Eigenschaft "Nach Zeit weiterblättern" festgelegt ist, nachdem die angegebene Vorlaufzeit abgelaufen ist.
1. Schreiben Sie die modifizierte Präsentation als Präsentationsdatei.

```php
  # Instanziieren Sie die Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Wenden Sie einen kreisförmigen Übergang auf Folie 1 an
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Setzen Sie die Übergangszeit auf 3 Sekunden
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Wenden Sie einen Kombiübergang auf Folie 2 an
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Setzen Sie die Übergangszeit auf 5 Sekunden
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Wenden Sie einen Zoomübergang auf Folie 3 an
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Setzen Sie die Übergangszeit auf 7 Sekunden
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Schreiben Sie die Präsentation auf die Festplatte
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Morphübergang**
{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java unterstützt jetzt den [Morphübergang](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). Dieser stellt den neuen Morphübergang dar, der in PowerPoint 2019 eingeführt wurde.

{{% /alert %}} 

Der Morphübergang ermöglicht es Ihnen, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und wie man den Morphübergang verwendet. Um den Morphübergang effektiv zu nutzen, müssen Sie zwei Folien mit mindestens einem gemeinsamen Objekt haben. Der einfachste Weg ist, die Folie zu duplizieren und dann das Objekt auf der zweiten Folie an einen anderen Ort zu verschieben.

Der folgende Code-Ausschnitt zeigt Ihnen, wie Sie einen Klon der Folie mit etwas Text zur Präsentation hinzufügen und einen Übergang vom [Morph-Typ](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) zur zweiten Folie einstellen.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morphübergang in PowerPoint-Präsentationen");
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

## **Morphübergangstypen**
Ein neues [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) Enum wurde hinzugefügt. Es stellt verschiedene Arten von Morph-Folienübergängen dar.

Das TransitionMorphType-Enum hat drei Mitglieder:

- ByObject: Der Morphübergang wird unter Berücksichtigung von Formen als untrennbare Objekte durchgeführt.
- ByWord: Der Morphübergang wird durchgeführt, indem der Text nach Wörtern übertragen wird, wo dies möglich ist.
- ByChar: Der Morphübergang wird durchgeführt, indem der Text nach Zeichen übertragen wird, wo dies möglich ist.

Der folgende Code-Ausschnitt zeigt Ihnen, wie Sie den Morphübergang auf die Folie setzen und den Morph-Typ ändern:

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
Aspose.Slides für PHP über Java unterstützt die Festlegung der Übergangseffekte wie von schwarz, von links, von rechts usw. Um den Übergangseffekt festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Holen Sie sich die Referenz der Folie.
- Den Übergangseffekt festlegen.
- Schreiben Sie die Präsentation als [PPTX ](https://docs.fileformat.com/presentation/pptx/)Datei.

Im folgenden Beispiel haben wir die Übergangseffekte festgelegt.

```php
  # Erstellen Sie eine Instanz der Präsentationsklasse
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Effekt festlegen
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Schreiben Sie die Präsentation auf die Festplatte
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```