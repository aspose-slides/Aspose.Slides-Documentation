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
- Morph‑Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienübergänge in Aspose.Slides für PHP via Java anpassen, mit Schritt‑für‑Schritt‑Anleitungen für PowerPoint‑ und OpenDocument‑Präsentationen."
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java ermöglicht Entwicklern ebenfalls das Verwalten oder Anpassen von Folienübergangseffekten. In diesem Thema besprechen wir, wie Sie Folienübergänge mit großer Einfachheit mithilfe von Aspose.Slides for PHP via Java steuern können.

{{% /alert %}} 

Zur besseren Verständlichkeit haben wir die Verwendung von Aspose.Slides for PHP via Java zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergänge anpassen.

## **Folienübergang hinzufügen**
Um einen einfachen Folienübergangseffekt zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides for PHP via Java angebotenen Übergangseffekte über das TransitionType‑Enum auswählen.
1. Schreiben Sie die geänderte Präsentationsdatei.
```php
  # Instanzieren der Presentation-Klasse, um die Quellpräsentationsdatei zu laden
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Kreisförmigen Übergang auf Folie 1 anwenden
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Kammtyp-Übergang auf Folie 2 anwenden
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Präsentation auf Festplatte speichern
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Erweiterten Folienübergang hinzufügen**
Im vorherigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Effekt noch besser und kontrollierter zu gestalten, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides for PHP via Java angebotenen Übergangseffekte auswählen.
1. Sie können den Übergang zudem auf „Bei Klick fortschreiten“, nach einer bestimmten Zeitdauer oder beides einstellen.
1. Wenn der Folienübergang auf „Bei Klick fortschreiten“ eingestellt ist, erfolgt das Vorankommen nur, wenn ein Mausklick erfolgt. Ist das Attribut „Advance After Time“ gesetzt, wird der Übergang automatisch nach Ablauf der angegebenen Zeit fortgesetzt.
1. Schreiben Sie die geänderte Präsentation in eine Präsentationsdatei.
```php
  # Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Kreisübergang auf Folie 1 anwenden
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Setze die Übergangszeit auf 3 Sekunden
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Kammübergang auf Folie 2 anwenden
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Setze die Übergangszeit auf 5 Sekunden
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Zoom-Übergang auf Folie 3 anwenden
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Setze die Übergangszeit auf 7 Sekunden
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Präsentation auf Festplatte speichern
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Morph‑Übergang**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java unterstützt jetzt den [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). Dies ist der neue Morph‑Übergang, der in PowerPoint 2019 eingeführt wurde.

{{% /alert %}} 

Der Morph‑Übergang ermöglicht die Animation einer fließenden Bewegung von einer Folie zur nächsten. Dieser Artikel beschreibt das Konzept und die Verwendung des Morph‑Übergangs. Um den Morph‑Übergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg ist, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Position zu verschieben.

Der folgende Code‑Abschnitt zeigt, wie Sie eine Kopie der Folie mit etwas Text zur Präsentation hinzufügen und der zweiten Folie einen [Morph‑Typ](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType)-Übergang zuweisen.
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


## **Morph‑Übergangstypen**
Das neue [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType)-Enum wurde hinzugefügt. Es repräsentiert verschiedene Arten von Morph‑Folienübergängen.

Das TransitionMorphType‑Enum besitzt drei Mitglieder:

- ByObject: Der Morph‑Übergang wird durchgeführt, wobei Formen als unteilbare Objekte betrachtet werden.
- ByWord: Der Morph‑Übergang wird durchgeführt, indem nach Möglichkeit Text Wort für Wort übertragen wird.
- ByChar: Der Morph‑Übergang wird durchgeführt, indem nach Möglichkeit Text Zeichen für Zeichen übertragen wird.

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
Aspose.Slides for PHP via Java unterstützt das Festlegen von Übergangseffekten wie „Von Schwarz“, „Von Links“, „Von Rechts“ usw. Um den Übergangseffekt zu setzen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
- Holen Sie die Referenz der Folie.
- Setzen Sie den Übergangseffekt.
- Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)-Datei.

Im nachfolgenden Beispiel haben wir die Übergangseffekte gesetzt.
```php
  # Instanz der Presentation-Klasse erstellen
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Effekt festlegen
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Präsentation auf Festplatte schreiben
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Setzen Sie die [Geschwindigkeit](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (z. B. langsam/mittel/schnell).

**Kann ich einem Übergang Audio hinzufügen und es wiederholen lassen?**

Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Looping steuern (z. B. [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/), plus Metadaten wie [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) und [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Was ist der schnellste Weg, denselben Übergang auf alle Folien anzuwenden?**

Konfigurieren Sie den gewünschten Übergangstyp in den Transition‑Einstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden des gleichen Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang aktuell auf einer Folie eingestellt ist?**

Untersuchen Sie die [Transition‑Einstellungen](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie und lesen Sie den [Transition‑Typ](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/) aus; dieser Wert gibt exakt an, welcher Effekt angewendet wird.