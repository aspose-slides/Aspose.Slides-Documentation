---
title: Dodaj prostokąty do prezentacji w PHP
linktitle: Prostokąt
type: docs
weight: 80
url: /pl/php-java/rectangle/
keywords:
- dodaj prostokąt
- utwórz prostokąt
- kształt prostokąta
- prosty prostokąt
- sformatowany prostokąt
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zwiększ jakość swoich prezentacji PowerPoint, dodając prostokąty przy użyciu Aspose.Slides dla PHP poprzez Java — łatwo projektuj i modyfikuj kształty programowo."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty prostokątów do slajdów PowerPoint przy użyciu Aspose.Slides. Obejmuje tworzenie prostego prostokąta, tworzenie sformatowanego prostokąta oraz zapisywanie zaktualizowanej prezentacji jako pliku PPTX.  
Zobaczysz także, jak zastosować podstawowe formatowanie prostokąta, takie jak jednolity kolor wypełnienia, kolor linii i szerokość linii. Dodatkowo, sekcja FAQ artykułu wskazuje na powiązane zadania dotyczące prostokątów, w tym zaokrąglone rogi, wypełnienia obrazem, efekty wizualne, hiperłącza, blokady kształtów, opcje eksportu oraz właściwości efektywne.

## **Dodaj prostokąt do slajdu**
Aby dodać prosty prostokąt do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) typu Rectangle przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addAutoShape) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy prosty prostokąt do pierwszego slajdu prezentacji.

```php
  # Utwórz instancję klasy Presentation reprezentującej plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu elipsy
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Zapisz plik PPTX na dysku
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dodaj sformatowany prostokąt do slajdu**
Aby dodać sformatowany prostokąt do slajdu, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) typu Rectangle przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addAutoShape) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).
- Ustaw typ wypełnienia prostokąta na Solid.
- Ustaw kolor prostokąta przy użyciu metody [ColorFormat::setColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/colorformat/#setColor) udostępnionej przez obiekt [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/) powiązany z obiektem [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/).
- Ustaw kolor linii prostokąta.
- Ustaw szerokość linii prostokąta.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

Powyższe kroki zostały zaimplementowane w poniższym przykładzie.

```php
  # Utwórz instancję klasy Presentation reprezentującej plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu elipsy
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Zastosuj formatowanie do kształtu elipsy
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Zastosuj formatowanie do linii elipsy
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Zapisz plik PPTX na dysku
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jak dodać prostokąt z zaokrąglonymi rogami?**

Użyj typu kształtu o zaokrąglonych rogach i dostosuj promień rogu w właściwościach kształtu; zaokrąglenie można również zastosować osobno dla każdego rogu przy pomocy modyfikacji geometrii.

**Jak wypełnić prostokąt obrazem (teksturą)?**

Wybierz typ wypełnienia obrazem, podaj źródło obrazu i skonfiguruj tryby rozciągania/układania.

**Czy prostokąt może mieć cień i poświatę?**

Tak. Dostępne są zewnętrzny/wewnętrzny cień, poświata i miękkie krawędzie, które można regulować.

**Czy mogę przekształcić prostokąt w przycisk z hiperłączem?**

Tak. Przypisz hiperłącze do kliknięcia kształtu (przejście do slajdu, pliku, adresu internetowego lub e‑maila).

**Jak mogę zabezpieczyć prostokąt przed przenoszeniem i zmianami?**

Użyj blokad kształtu: możesz zablokować przenoszenie, zmianę rozmiaru, zaznaczanie lub edycję tekstu, aby zachować układ.

**Czy mogę przekształcić prostokąt w obraz rastrowy lub SVG?**

Tak. Możesz wyrenderować kształt do obrazu o określonym rozmiarze/skali lub wyeksportować go jako SVG do wykorzystania wektorowego.

**Jak szybko uzyskać rzeczywiste (efektywne) właściwości prostokąta uwzględniając motyw i dziedziczenie?**

Użyj efektywnych właściwości kształtu: API zwraca obliczone wartości, które uwzględniają style motywu, układ i ustawienia lokalne, upraszczając analizę formatowania.