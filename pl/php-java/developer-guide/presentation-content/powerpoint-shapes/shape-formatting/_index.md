---
title: Formatowanie kształtów PowerPoint w PHP
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/php-java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicowy
- szkicowa linia kształtu
- formatowanie stylu połączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednolitym kolorem
- przezroczystość kształtu
- renderowanie kształtu czarno-białe
- renderowanie kształtu w skali szarości
- obracanie kształtu
- efekt fazowania 3D
- efekt rotacji 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w PHP za pomocą Aspose.Slides — ustaw style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty na ich konturach. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełniania ich wnętrz.

![formatowanie-kształtu-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java udostępnia klasy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Korzystając z Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniższe kroki opisują procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [styl linii](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [styl kreski](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod PHP demonstruje, jak sformatować prostokąt `AutoShape`:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Ustaw kolor wypełnienia dla kształtu prostokąt.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Zastosuj formatowanie do linii prostokąta.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Ustaw kolor linii prostokąta.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Zapisz plik PPTX na dysku.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Zastosuj efekty szkicowe do linii kształtu**

Efekt szkicowy sprawia, że linia kształtu wygląda jak narysowana ręcznie. Użyj [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) aby uzyskać dostęp do ustawień linii, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) aby uzyskać dostęp do ustawień szkicu oraz [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Poniższy kod PHP pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), odczytać wyraźnie przypisaną wartość oraz usunąć efekt przy użyciu [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Uzyskaj dostęp do formatu linii kształtu i jego formatu szkicu.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Zastosuj efekt szkicu.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Odczytaj efekt szkicu przypisany bezpośrednio do kształtu.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Usuń efekt szkicu.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Wartość zwrócona przez [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu nadrzędnego lub slajdu układu, użyj [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), uzyskaj dostęp do metody `getSketchFormat` zwróconego obiektu i odczytaj jego wartość `getSketchType`. Wartość efektywna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Zaokrąglony
* Kątowy
* Ścięty

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (na przykład na rogu kształtu), używa ustawienia **Zaokrąglony**. Jednakże, jeśli rysujesz kształt o ostrych kątach, możesz preferować opcję **Kątowy**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod PHP demonstruje, jak trzy prostokąty (jak na powyższym obrazie) zostały utworzone przy użyciu ustawień typu połączenia Kątowy, Ścięty i Zaokrąglony:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Uzyskaj pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj trzy automatyczne kształty typu Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Ustaw kolor wypełnienia dla każdego prostokątnego kształtu.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Ustaw szerokość linii.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Ustaw kolor linii każdego prostokąta.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Ustaw styl połączenia.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Dodaj tekst do każdego prostokąta.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Zapisz plik PPTX na dysku.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Wypełnienie gradientowe**

W programie PowerPoint wypełnienie gradientowe jest opcją formatowania, która umożliwia zastosowanie ciągłego przejścia kolorów do kształtu. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwa wybrane kolory z określonymi pozycjami, używając metod `add` kolekcji punktów gradientu udostępnianej przez klasę [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Zastosuj formatowanie gradientowe do elipsy.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Ustaw kierunek gradientu.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Dodaj dwa punkty gradientu.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Zapisz plik PPTX na dysku.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Elipsa z wypełnieniem gradientowym:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

Jeśli gradient wygląda inaczej w wyeksportowanym obrazie niż w programie PowerPoint, zobacz [Wybierz styl renderowania gradientu](/slides/pl/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Możesz wybrać styl renderowania bez zmiany wypełnienia gradientowego zapisanego w prezentacji.

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala zastosować dwukolorowy wzór — taki jak kropki, paski, krzyżowe kreskowanie lub kratkę — do kształtu. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wstępnie zdefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu wstępnie zdefiniowanego wzoru możesz nadal określić dokładne kolory, które ma używać.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru z dostępnych opcji.
1. Ustaw [Kolor tła](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) wzoru.
1. Ustaw [Kolor pierwszego planu](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Ustaw styl wzoru.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Ustaw kolory tła i pierwszego planu wzoru.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Zapisz plik PPTX na dysku.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Prostokąt z wypełnieniem wzorem:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem jest opcją formatowania, która pozwala wstawić obraz wewnątrz kształtu — skutecznie używając obrazu jako tła kształtu.

Oto jak użyć Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `SlidesPicture.setImage`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik „lotus.png” z następującym obrazem:

![Obraz lotosu](lotus.png)

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Ustaw typ wypełnienia na Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Ustaw tryb wypełnienia obrazem.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Załaduj obraz i dodaj go do zasobów prezentacji.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Ustaw obraz.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Zapisz plik PPTX na dysku.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kształt z wypełnieniem obrazem:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Obraz w kafelkach jako tekstura**

Jeśli chcesz ustawić obraz w kafelkach jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod klasy [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Określa wyrównanie kafelków wewnątrz kształtu.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Kontroluje, czy kafelek jest odwrócony w poziomie, w pionie lub w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Ustawia poziomy offset kafelka (w punktach) od pochodzenia kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Ustawia pionowy offset kafelka (w punktach) od pochodzenia kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definiuje pionową skalę kafelka jako procent.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt prostokątny.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Ustaw typ wypełnienia kształtu na Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Załaduj obraz i dodaj go do zasobów prezentacji.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Przypisz obraz do kształtu.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Skonfiguruj tryb wypełnienia obrazem i właściwości kafelkowania.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Zapisz plik PPTX na dysku.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Opcje kafelkowania:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie jednolitym kolorem**

W programie PowerPoint wypełnienie jednolitym kolorem jest opcją formatowania, która wypełnia kształt jednym, jednolitym kolorem. Ten prosty kolor tła jest stosowany bez żadnych gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie jednolitym kolorem do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Ustaw kolor wypełnienia.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Zapisz plik PPTX na dysku.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kształt z wypełnieniem jednolitym kolorem:

![Kształt z wypełnieniem jednolitym kolorem](solid-color-fill.png)

## **Ustaw przezroczystość**

W programie PowerPoint, gdy stosujesz wypełnienie jednolitym kolorem, gradientem, obrazem lub teksturą do kształtów, możesz również ustawić poziom przezroczystości, aby kontrolować nieprzezroczystość wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, umożliwiając częściowe widzenie tła lub znajdujących się pod nim obiektów.

Aspose.Slides pozwala ustawić poziom przezroczystości, dostosowując wartość alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) kształtu na `Solid`.
1. Użyj `Color`, aby zdefiniować kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny prostokąt wypełniony.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny auto kształt nad wypełnionym kształtem.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Zapisz plik PPTX na dysku.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Przezroczysty kształt:

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych z określonymi wymaganiami dotyczącymi wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość rotacji kształtu na żądany kąt.
1. Zapisz prezentację.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    $shape->setRotation(5);

    // Zapisz plik PPTX na dysku.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Obrót kształtu:

![Obrót kształtu](shape-rotation.png)

## **Dodaj efekty fazowania 3D**

Aspose.Slides pozwala stosować efekty fazowania 3D do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Aby dodać efekty fazowania 3D do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) kształtu, aby określić ustawienia fazowania.
1. Zapisz prezentację.

```php
// Utwórz instancję klasy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj kształt do slajdu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Ustaw właściwości ThreeDFormat kształtu.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Zapisz prezentację jako plik PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Efekt fazowania 3D:

![Efekt fazowania 3D](3D-bevel-effect.png)

## **Dodaj efekty rotacji 3D**

Aspose.Slides umożliwia stosowanie efektów rotacji 3D do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Aby zastosować rotację 3D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) do slajdu.
1. Użyj metod [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) i [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), aby określić rotację 3D.
1. Zapisz prezentację.

```php
// Utwórz instancję klasy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Zapisz prezentację jako plik PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Efekt rotacji 3D:

![Efekt rotacji 3D](3D-rotation-effect.png)

## **Kontrola renderowania czarno-białego dla kształtów**

Metoda [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) określa, jak pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno-białym. Nie włącza ona samodzielnie wyświetlania czarno-białego oraz nie zmienia wypełnienia, linii ani innych formatów kształtu w normalnym trybie kolorów.

Użyj wartości z klasy [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/), aby wybrać żądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają szarego koloru, `BlackWhite` używa tylko czerni i bieli, `Black` i `White` wymuszają pojedynczy kolor, `Color` zachowuje normalne kolorowanie, a `Hidden` pomija kształt w trybie czarno-białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Poniższy kod PHP tworzy kolorowy kształt i sprawia, że wyświetla się szary w trybie czarno-białym:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Zachowaj pomarańczowe wypełnienie w trybie kolorowym, ale renderuj kształt w odcieniach szarości w trybie czarno-białym.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

W normalnym trybie kolorów prostokąt zachowuje pomarańczowe wypełnienie. W przepływie pracy wyświetlania czarno-białego używa szarego koloru, ponieważ jego tryb jest ustawiony na `Gray`. Pozwala to zachować slajd w pełnym kolorze, definiując jednocześnie odrębny wygląd dla drukowania, podglądu lub innych przepływów pracy, które respektują ustawienia wyświetlania czarno-białego prezentacji.

## **Resetowanie formatowania**

Poniższy kod Java pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z placeholderami na [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) do ich domyślnych ustawień:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Zresetuj każdy kształt na slajdzie, który ma placeholder w układzie.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko minimalnie. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające wartości się zgadzają, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów do osobnego pliku, aby ponownie używać ich w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w zestawie slajdów szablonowych lub pliku szablonu .POTX. Podczas tworzenia nowej prezentacji otwórz szablon, sklonuj potrzebne stylowe kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.