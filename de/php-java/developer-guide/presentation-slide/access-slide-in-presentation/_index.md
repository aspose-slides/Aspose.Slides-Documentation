---
title: Zugriff auf Präsentationsfolien in PHP
linktitle: Folienzugriff
type: docs
weight: 20
url: /de/php-java/access-slide-in-presentation/
keywords:
- Zugriff auf Folie
- Folienindex
- Folien-ID
- Folienposition
- Position ändern
- Folieneigenschaften
- Foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP über Java zugreifen und verwalten können. Steigern Sie die Produktivität mit Code-Beispielen."
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: über den Index und über die ID.

## **Zugriff auf eine Folie per Index**

Alle Folien in einer Präsentation sind numerisch nach der Folienposition angeordnet, beginnend bei 0. Die erste Folie ist über den Index 0 zugänglich; die zweite Folie wird über den Index 1 aufgerufen; usw.

Die Klasse Presentation, die eine Präsentationsdatei repräsentiert, stellt alle Folien als eine [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)-Sammlung (Sammlung von [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)-Objekten) bereit. Dieser PHP-Code zeigt, wie man über den Index auf eine Folie zugreift:
```php
  # Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    # Greift auf eine Folie über ihren Folienindex zu
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


## **Zugriff auf eine Folie per ID**

Jede Folie in einer Präsentation hat eine eindeutige ID. Sie können die Methode [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) verwenden, um diese ID anzusprechen. Dieser PHP-Code zeigt, wie man eine gültige Folien-ID angibt und über die Methode [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) auf die Folie zugreift:
```php
  # Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    # Holt eine Folien-ID
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Greift auf die Folie über ihre ID zu
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```


## **Ändern der Folienposition**

Aspose.Slides ermöglicht es, die Position einer Folie zu ändern. Zum Beispiel können Sie festlegen, dass die erste Folie zur zweiten Folie wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.
1. Holen Sie die Referenz der Folie (deren Position Sie ändern möchten) über ihren Index.
1. Setzen Sie eine neue Position für die Folie über die Methode [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#setSlideNumber).
1. Speichern Sie die geänderte Präsentation.

Dieser PHP-Code demonstriert eine Operation, bei der die Folie an Position 1 nach Position 2 verschoben wird:
```php
  # Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("Presentation.pptx");
  try {
    # Holt die Folie, deren Position geändert wird
    $sld = $pres->getSlides()->get_Item(0);
    # Setzt die neue Position für die Folie
    $sld->setSlideNumber(2);
    # Speichert die geänderte Präsentation
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden die anderen Folien automatisch angepasst.

## **Festlegen der Foliennummer**

Mit der Methode [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Dieser Vorgang führt dazu, dass die übrigen Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.
1. Holen Sie die Foliennummer.
1. Setzen Sie die Foliennummer.
1. Speichern Sie die geänderte Präsentation.

Dieser PHP-Code demonstriert eine Operation, bei der die erste Foliennummer auf 10 gesetzt wird:
```php
  # Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Ermittelt die Foliennummer
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Setzt die Foliennummer
    $pres->setFirstSlideNumber(10);
    # Speichert die geänderte Präsentation
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


Falls Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummerierung für die erste Folie ausblenden) auf folgende Weise:
```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Setzt die Nummer für die erste Präsentationsfolie
    $presentation->setFirstSlideNumber(0);
    # Zeigt die Foliennummern für alle Folien an
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Blendet die Foliennummer für die erste Folie aus
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Speichert die geänderte Präsentation
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**Entspricht die von einem Benutzer sichtbare Foliennummer dem nullbasierten Index der Sammlung?**

Die auf einer Folie angezeigte Nummer kann mit einem beliebigen Wert beginnen (z. B. 10) und muss nicht mit dem Index übereinstimmen; die Beziehung wird durch die Einstellung der [first slide number](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) der Präsentation gesteuert.

**Beeinflussen ausgeblendete Folien die Indexierung?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indexierung mitgezählt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfüge-, Lösch- und Verschiebevorgängen neu berechnet.