---
title: Zugriff auf Folie in der Präsentation
type: docs
weight: 20
url: /de/php-java/access-slide-in-presentation/
keywords: "Zugriff auf PowerPoint-Präsentation, Zugriff auf Folie, Folieneigenschaften bearbeiten, Folienposition ändern, Foliennummer, Index, ID, Position Java, Aspose.Slides"
description: "Zugriff auf PowerPoint-Folie nach Index, ID oder Position. Folieneigenschaften bearbeiten"
---

Aspose.Slides ermöglicht Ihnen den Zugriff auf Folien auf zwei Arten: nach Index und nach ID.

## **Zugriff auf Folie nach Index**

Alle Folien in einer Präsentation sind numerisch basierend auf der Folienposition angeordnet, beginnend bei 0. Die erste Folie ist über den Index 0 zugänglich; die zweite Folie wird über den Index 1 aufgerufen; usw.

Die Klasse Presentation, die eine Präsentationsdatei repräsentiert, stellt alle Folien als eine [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) Sammlung (Sammlung von [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) Objekten) bereit. Dieser PHP-Code zeigt Ihnen, wie Sie auf eine Folie über ihren Index zugreifen:

```php
  # Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    # Greift auf eine Folie über ihren Folienindex zu
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **Zugriff auf Folie nach ID**

Jede Folie in einer Präsentation hat eine eindeutige ID, die ihr zugeordnet ist. Sie können die [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) Methode (die von der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse bereitgestellt wird) verwenden, um diese ID anzusprechen. Dieser PHP-Code zeigt Ihnen, wie Sie eine gültige Folien-ID angeben und auf diese Folie über die [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) Methode zugreifen:

```php
  # Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    # Holt sich eine Folien-ID
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Greift auf die Folie über ihre ID zu
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Folie Position ändern**

Aspose.Slides ermöglicht es Ihnen, die Position einer Folie zu ändern. Sie können beispielsweise angeben, dass die erste Folie zur zweiten Folie werden soll.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Referenz der Folie (deren Position Sie ändern möchten) über ihren Index.
3. Setzen Sie eine neue Position für die Folie über die [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/islide/#setSlideNumber-int-) Eigenschaft.
4. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code demonstriert eine Operation, bei der die Folie an Position 1 auf Position 2 verschoben wird:

```php
  # Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("Presentation.pptx");
  try {
    # Holt sich die Folie, deren Position geändert werden soll
    $sld = $pres->getSlides()->get_Item(0);
    # Setzt die neue Position für die Folie
    $sld->setSlideNumber(2);
    # Speichert die modifizierte Präsentation
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden andere Folien automatisch angepasst.

## **Foliennummer festlegen**

Mit der [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) Eigenschaft (die von der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse bereitgestellt wird) können Sie eine neue Nummer für die erste Folie in einer Präsentation festlegen. Diese Operation führt dazu, dass andere Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Foliennummer.
3. Setzen Sie die Foliennummer.
4. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code demonstriert eine Operation, bei der die erste Foliennummer auf 10 gesetzt wird:

```php
  # Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Holt sich die Foliennummer
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Setzt die Foliennummer
    $pres->setFirstSlideNumber(10);
    # Speichert die modifizierte Präsentation
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung von der zweiten Folie (und die Nummerierung für die erste Folie ausblenden) so beginnen:

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
    # Speichert die modifizierte Präsentation
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```