---
title: Dodawanie kształtów linii do prezentacji w PHP
linktitle: Linia
type: docs
weight: 50
url: /pl/php-java/line/
keywords:
- linia
- tworzenie linii
- dodawanie linii
- zwykła linia
- konfigurowanie linii
- dostosowywanie linii
- styl kreski
- grot strzały
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak manipulować formatowaniem linii w prezentacjach PowerPoint za pomocą Aspose.Slides for PHP via Java. Odkryj właściwości, metody i przykłady."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie kształtów linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię oraz jak ją dostosować, aby wyglądała jak strzałka.

Dowiesz się, jak dodać kształt linii do slajdu, dostosować jego wygląd oraz zapisać zaktualizowaną prezentację. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, szerokość, wzór kreski, opcje końcówek strzałek oraz kolor wypełnienia.

## **Utworzenie prostej linii**

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody [addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addAutoShape) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```php
  # Utwórz instancję klasy PresentationEx reprezentującej plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu line
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

Aspose.Slides for PHP via Java umożliwia również deweloperom konfigurowanie niektórych właściwości linii, aby wyglądała bardziej atrakcyjnie. Spróbujmy skonfigurować kilka właściwości linii, aby wyglądała jak strzałka. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody [addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addAutoShape) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).
- Ustaw [Line Style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineStyle) na jeden ze stylów oferowanych przez Aspose.Slides for PHP via Java.
- Ustaw szerokość (Width) linii.
- Ustaw [Dash Style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineDashStyle) linii na jeden ze stylów oferowanych przez Aspose.Slides for PHP via Java.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineArrowheadStyle) oraz [Length](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineArrowheadLength) punktu początkowego linii.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineArrowheadStyle) oraz [Length](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LineArrowheadLength) punktu końcowego linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```php
  # Utwórz instancję klasy PresentationEx reprezentującej plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu line
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Zastosuj formatowanie linii
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

**Czy mogę przekształcić zwykłą linię w łącznik, aby „przyklejała się” do kształtów?**

Nie. Zwykła linia ( [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapetype/) ) nie zamienia się automatycznie w łącznik. Aby przyklejała się do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/) oraz [odpowiednich interfejsów API](/slides/pl/php-java/connector/) do połączeń.

**Co zrobić, gdy właściwości linii są dziedziczone z motywu i trudno określić ich końcowe wartości?**

[Przeczytaj skuteczne właściwości](/slides/pl/php-java/shape-effective-properties/) za pośrednictwem `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — uwzględniają one już dziedziczenie i style motywu.

**Czy mogę zablokować linię przed edycją (przemieszczaniem, skalowaniem)?**

Tak. Kształty udostępniają [obiekty blokady](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/getautoshapelock/), które pozwalają uniemożliwić operacje edycyjne.