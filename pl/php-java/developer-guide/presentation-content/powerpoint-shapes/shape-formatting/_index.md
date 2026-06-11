---
title: Formatowanie kształtów PowerPoint w PHP
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/php-java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- formatowanie stylu łączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednolitym kolorem
- przezroczystość kształtu
- obrót kształtu
- efekt fazowania 3D
- efekt obrotu 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w PHP przy użyciu Aspose.Slides — ustaw style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Introduction**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty na ich konturach. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełniania ich wnętrz.

![formatowanie-kształtu-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java udostępnia klasy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji, które są dostępne w PowerPoint.

## **Format Lines**

Korzystając z Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniżej opisano procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [line style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [dash style](https://reference.aspose.com/slides/pl/php-java/aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod PHP demonstruje, jak sformatować prostokąt `AutoShape`:

```php
    // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
    $presentation = new Presentation();
    try {
        // Uzyskaj pierwszy slajd.
        $slide = $presentation->getSlides()->get_Item(0);

        // Dodaj automatyczny kształt typu Prostokąt.
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

        // Ustaw kolor wypełnienia dla prostokątnego kształtu.
        $shape->getFillFormat()->setFillType(FillType::NoFill);

        // Zastosuj formatowanie linii prostokąta.
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

## **Format Join Styles**

Oto trzy dostępne opcje typu połączenia:

* Round
* Miter
* Bevel

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (na przykład w rogu kształtu), używa ustawienia **Round**. Jednak jeśli rysujesz kształt o ostrych kątach, możesz woleć opcję **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod PHP pokazuje, jak trzy prostokąty (widoczne na powyższym obrazku) zostały utworzone przy użyciu ustawień połączenia Miter, Bevel i Round:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj trzy automatyczne kształty typu Prostokąt.
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

    // Ustaw kolor linii dla każdego prostokąta.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Ustaw styl łączenia.
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

## **Gradient Fill**

W programie PowerPoint wypełnienie gradientowe to opcja formatowania, która pozwala zastosować ciągłe przejście kolorów do kształtu. Na przykład możesz nałożyć dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość [FillType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwie wybrane kolory z określonymi pozycjami, używając metod `add` kolekcji przystanków gradientu udostępnianej przez klasę [GradientFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/gradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod PHP demonstruje, jak zastosować efekt wypełnienia gradientowego do elipsy:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Elipsa.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Zastosuj formatowanie gradientowe do elipsy.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Ustaw kierunek gradientu.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Dodaj dwa przystanki gradientu.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Zapisz plik PPTX na dysku.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Pattern Fill**

W programie PowerPoint wypełnienie wzorem to opcja formatowania, która pozwala zastosować dwukolorowy wzór — taki jak kropki, paski, krzyżykowe kreski lub kratkę — do kształtu. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 predefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu predefiniowanego wzoru możesz określić dokładne kolory, które mają być użyte.

Jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość [FillType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru z dostępnych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/php-java/aspose.slides/patternformat/#getBackColor) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/php-java/aspose.slides/patternformat/#getForeColor) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod PHP demonstruje, jak zastosować wypełnienie wzorem do prostokąta:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Wzór.
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

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Picture Fill**

W programie PowerPoint wypełnienie obrazem to opcja formatowania, która pozwala wstawić obraz wewnątrz kształtu — skutecznie używając obrazu jako tła kształtu.

Jak używać Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość [FillType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `SlidesPicture.setImage`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik "lotus.png" z następującym obrazem:

![Obrazek lotosu](lotus.png)

Poniższy kod PHP demonstruje, jak wypełnić kształt obrazem:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Ustaw typ wypełnienia na Obraz.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Ustaw tryb wypełnienia obrazem.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Wczytaj obraz i dodaj go do zasobów prezentacji.
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

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Tile Picture As Texture**

Jeśli chcesz ustawić obraz kafelkowany jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#setTileAlignment): Określa wyrównanie kafelków w kształcie.
- [setTileFlip](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#setTileFlip): Kontroluje, czy kafelek jest odbijany w poziomie, w pionie lub w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definiuje poziomą skalę kafelka w procentach.
- [setTileScaleY](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definiuje pionową skalę kafelka w procentach.

Poniższy przykład kodu pokazuje, jak dodać prostokątny kształt z kafelkowanym wypełnieniem obrazem i skonfigurować opcje kafelkowania:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt prostokątny.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Ustaw typ wypełnienia kształtu na Obraz.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Wczytaj obraz i dodaj go do zasobów prezentacji.
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

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Solid Color Fill**

W programie PowerPoint wypełnienie jednolitym kolorem to opcja formatowania, która wypełnia kształt jednym, równomiernym kolorem. Ten prosty kolor tła jest nakładany bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie jednolitym kolorem do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość [FillType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod PHP demonstruje, jak zastosować wypełnienie jednolitym kolorem do prostokąta w slajdzie PowerPoint:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Jednolity.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Ustaw kolor wypełnienia.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Zapisz plik PPTX na dysku.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Kształt z wypełnieniem jednolitym kolorem](solid-color-fill.png)

## **Set Transparency**

W programie PowerPoint, gdy stosujesz wypełnienie jednolitym kolorem, gradientem, obrazem lub teksturą do kształtów, możesz także ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przezroczysty, pozwalając częściowo widzieć tło lub obiekty pod nim.

Aspose.Slides umożliwia ustawienie poziomu przezroczystości poprzez dostosowanie wartości alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/filltype/) na `Solid`.
1. Użyj klasy `Color`, aby zdefiniować kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

Poniższy kod PHP demonstruje, jak zastosować przezroczysty kolor wypełnienia do prostokąta:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt prostokątny jednolity.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Dodaj automatyczny kształt prostokątny przezroczysty nad jednolitym kształtem.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Zapisz plik PPTX na dysku.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych z określonym wyrównaniem lub wymaganiami projektowymi.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość obrotu kształtu na żądany kąt.
1. Zapisz prezentację.

Poniższy kod PHP demonstruje, jak obrócić kształt o 5 stopni:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    $shape->setRotation(5);

    // Zapisz plik PPTX na dysku.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Obrócenie kształtu](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides pozwala dodać efekty 3‑D fazowania do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/).

Aby dodać efekty 3‑D fazowania do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/) kształtu, aby określić ustawienia fazowania.
1. Zapisz prezentację.

Poniższy kod PHP pokazuje, jak zastosować efekty 3‑D fazowania do kształtu:

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

Wynik:

![Efekt 3‑D fazowania](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides pozwala dodać efekty obrotu 3‑D do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/).

Aby zastosować obrót 3‑D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
1. Użyj metod [setCameraType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/camera/#setCameraType) i [setLightType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/lightrig/#setLightType), aby określić obrót 3‑D.
1. Zapisz prezentację.

Poniższy kod PHP demonstruje, jak zastosować efekty obrotu 3‑D do kształtu:

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

Wynik:

![Efekt obrotu 3‑D](3D-rotation-effect.png)

## **Reset Formatting**

Poniższy kod Java pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z placeholderami na [LayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/) do ich domyślnych ustawień:

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

Tylko minimalnie. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, natomiast parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby móc je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości są takie same, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw własnych stylów kształtów w osobnym pliku i ponownie używać go w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z żądanymi stylami w szablonie prezentacji lub pliku szablonu .POTX. Podczas tworzenia nowej prezentacji otwórz szablon, sklonuj potrzebne stylowane kształty i zastosuj ich formatowanie tam, gdzie jest wymagane.