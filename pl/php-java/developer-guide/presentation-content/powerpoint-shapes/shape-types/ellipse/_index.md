---
title: Dodawanie elips do prezentacji w PHP
linktitle: Elipsa
type: docs
weight: 30
url: /pl/php-java/ellipse/
keywords:
- elipsa
- kształt
- dodaj elipsę
- utwórz elipsę
- rysuj elipsę
- sformatowana elipsa
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, formatować i manipulować kształtami elips w Aspose.Slides dla PHP przy użyciu Java w prezentacjach PPT i PPTX — włączone przykłady kodu."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodawać kształty elips do slajdów programu PowerPoint przy użyciu Aspose.Slides. Omawia tworzenie prostej elipsy, tworzenie sformatowanej elipsy oraz zapisywanie zaktualizowanej prezentacji jako pliku PPTX. Porusza także powiązane zagadnienia, takie jak praca z położeniem i rozmiarem elipsy, kontrolowanie kolejności warstw oraz stosowanie efektów animacji.

## **Utwórz elipsę**
- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Ellipse, używając metody [addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addAutoShape) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy elipsę do pierwszego slajdu

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu elipsy
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Zapisz plik PPTX na dysku
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Utwórz sformatowaną elipsę**
- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Ellipse, używając metody [addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addAutoShape) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).
- Ustaw typ wypełnienia elipsy na Solid.
- Ustaw kolor elipsy, używając metody `SolidFillColor::setColor` udostępnionej przez obiekt [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/) powiązany z obiektem [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/).
- Ustaw kolor linii elipsy.
- Ustaw szerokość linii elipsy.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy sformatowaną elipsę do pierwszego slajdu prezentacji.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu elipsy
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Zastosuj formatowanie do kształtu elipsy
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Zastosuj formatowanie do linii elipsy
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Zapisz plik PPTX na dysku
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jak ustawić dokładne położenie i rozmiar elipsy względem jednostek slajdu?**

Współrzędne i rozmiary są zazwyczaj podawane **w punktach**. Aby uzyskać przewidywalne wyniki, oprzyj obliczenia na rozmiarze slajdu i przed przypisaniem wartości przelicz wymagane milimetry lub cale na punkty.

**Jak umieścić elipsę nad lub pod innymi obiektami (kontrola kolejności warstw)?**

Dostosuj kolejność rysowania obiektu, przenosząc go na wierzch lub wysyłając na spód. Dzięki temu elipsa może nakładać się na inne obiekty lub odsłaniać te znajdujące się pod nią.

**Jak animować pojawienie się lub podkreślenie elipsy?**

Zastosuj efekty wejścia, podkreślenia lub wyjścia do kształtu, używając [Apply](/slides/pl/php-java/shape-animation/), i skonfiguruj wyzwalacze oraz timing, aby określić, kiedy i jak animacja ma być odtwarzana.