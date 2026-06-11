---
title: Dodaj kształty linii do prezentacji w PHP
linktitle: Linia
type: docs
weight: 50
url: /pl/php-java/Line/
keywords:
- linia
- tworzenie linii
- dodaj linię
- prosta linia
- konfiguracja linii
- dostosowanie linii
- styl kreski
- grot strzałki
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak manipulować formatowaniem linii w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP via Java. Odkryj właściwości, metody i przykłady."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie kształtów linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię oraz jak dostosować linię, aby wyglądała jak strzałka.

Poznasz sposób dodania kształtu linii do slajdu, dostosowania jej wyglądu oraz zapisania zmodyfikowanej prezentacji. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, szerokość, wzór kreski, opcje grotów oraz kolor wypełnienia.

## **Utworzenie prostej linii**

Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody [addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addAutoShape) dostępnej w obiekcie [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```php
  # Utwórz instancję klasy PresentationEx, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu linia
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Zapisz plik PPTX na dysku
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Utworzenie linii w kształcie strzałki**

Aspose.Slides dla PHP via Java pozwala także programistom konfigurować niektóre właściwości linii, aby wyglądała atrakcyjniej. Spróbujmy skonfigurować kilka właściwości linii, aby przypominała strzałkę. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody [addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addAutoShape) dostępnej w obiekcie [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).
- Ustaw [Line Style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineStyle) na jeden ze stylów dostępnych w Aspose.Slides dla PHP via Java.
- Ustaw szerokość (Width) linii.
- Ustaw [Dash Style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineDashStyle) linii na jeden ze stylów dostępnych w Aspose.Slides dla PHP via Java.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineArrowheadStyle) i [Length](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineArrowheadLength) punktu początkowego linii.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineArrowheadStyle) i [Length](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineArrowheadLength) punktu końcowego linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```php
  # Utwórz instancję klasy PresentationEx, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu linia
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Zastosuj formatowanie do linii
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Zapisz plik PPTX na dysku
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę przekonwertować zwykłą linię na łącznik, aby „przyciągała” się do kształtów?**

Nie. Zwykła linia ( [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapetype/) ) nie staje się automatycznie łącznikiem. Aby przyciągała się do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/) oraz [corresponding APIs](/slides/pl/php-java/connector/) do połączeń.

**Co zrobić, gdy właściwości linii są dziedziczone z motywu i trudno określić ich ostateczne wartości?**

[Read the effective properties](/slides/pl/php-java/shape-effective-properties/) poprzez `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — te już uwzględniają dziedziczenie i style motywu.

**Czy mogę zablokować linię przed edycją (przesuwaniem, zmianą rozmiaru)?**

Tak. Kształty udostępniają [lock objects](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/getautoshapelock/), które pozwalają uniemożliwić operacje edycji.