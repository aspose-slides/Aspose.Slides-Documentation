---
title: Formatowanie kształtów PowerPoint w C++
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/cpp/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia szkicu kształtu
- formatowanie stylu połączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednolitym kolorem
- przezroczystość kształtu
- obracanie kształtu
- efekt 3D bevel
- efekt rotacji 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w C++ przy użyciu Aspose.Slides — ustalaj style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz formatować je, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełnienia ich wnętrza.

![formatowanie-kształtu-powerpoint](format-shape-powerpoint.png)

Aspose.Slides dla C++ udostępnia interfejsy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji, które są dostępne w programie PowerPoint.

## **Formatowanie linii**

Korzystając z Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniżej opisano procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [line style](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [dash style](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokąt `AutoShape`:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj automatyczny kształt typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Ustaw kolor wypełnienia dla kształtu prostokąta.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Zastosuj formatowanie linii prostokąta.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Ustaw kolor linii prostokąta.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Zapisz plik PPTX na dysku.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Zastosowanie efektów szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda na narysowaną ręcznie. Użyj [IShape::get_LineFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_lineformat/), aby uzyskać dostęp do ustawień linii, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilineformat/get_sketchformat/), aby uzyskać dostęp do ustawień szkicu, oraz [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isketchformat/set_sketchtype/), aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linesketchtype/).

Poniższy kod C++ pokazuje, jak zastosować efekt [LineSketchType::Curved](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linesketchtype/), odczytać jawnie przypisaną wartość i usunąć efekt przy użyciu [LineSketchType::None](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Wartość zwracana przez [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isketchformat/get_sketchtype/) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być odziedziczone z motywu, slajdu nadrzędnego lub slajdu układu, użyj [ILineFormat::GetEffective](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilineformat/geteffective/), uzyskaj dostęp do [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), i odczytaj [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Efektywna wartość odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Round
* Miter
* Bevel

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w rogu kształtu), używa ustawienia **Round**. Jednak przy rysowaniu kształtu o ostrych kątach możesz woleć opcję **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod C++ demonstruje, jak trzy prostokąty (jak na powyższym obrazie) zostały utworzone przy użyciu ustawień połączeń Miter, Bevel i Round:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj trzy automatyczne kształty typu Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Ustaw kolor wypełnienia dla każdego prostokątnego kształtu.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Ustaw szerokość linii.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Ustaw kolor linii każdego prostokąta.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Ustaw styl połączenia.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Dodaj tekst do każdego prostokąta.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Zapisz plik PPTX na dysku.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gradient Fill**

W programie PowerPoint wypełnienie gradientowe to opcja formatowania, która umożliwia zastosowanie płynnego przejścia kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwa wybrane kolory z określonymi pozycjami, używając metod `Add` kolekcji zatrzymań gradientu udostępnianej przez interfejs [IGradientFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod C++ demonstruje, jak zastosować efekt wypełnienia gradientowego do elipsy:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj automatyczny kształt typu Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Zastosuj formatowanie gradientowe do elipsy.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Ustaw kierunek gradientu.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Dodaj dwa przystanki gradientu.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Zapisz plik PPTX na dysku.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Pattern Fill**

W programie PowerPoint wypełnienie wzorem to opcja formatowania, która pozwala zastosować dwukolorowy wzór — na przykład kropki, paski, skrzyżowania lub kratkę — do kształtu. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides oferuje ponad 45 wbudowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu wbudowanego wzoru możesz określić dokładne kolory, które mają być użyte.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru spośród dostępnych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipatternformat/get_backcolor/) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipatternformat/get_forecolor/) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod C++ demonstruje, jak zastosować wypełnienie wzorem do prostokąta:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj automatyczny kształt typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ustaw typ wypełnienia na Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Ustaw styl wzoru.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Ustaw kolory tła i pierwszego planu wzoru.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Zapisz plik PPTX na dysku.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Picture Fill**

W programie PowerPoint wypełnienie obrazem to opcja formatowania, która pozwala wstawić obraz wewnątrz kształtu — efektywnie używając obrazu jako tła kształtu.

Oto jak używać Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazu na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `ISlidesPicture.set_Image`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik „lotus.png” z następującym obrazem:

![Obraz lotosu](lotus.png)

Poniższy kod C++ demonstruje, jak wypełnić kształt obrazem:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj automatyczny kształt typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Ustaw typ wypełnienia na Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Ustaw tryb wypełnienia obrazem.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Wczytaj obraz i dodaj go do zasobów prezentacji.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Ustaw obraz.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Zapisz plik PPTX na dysku.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Tile Picture As Texture**

Jeśli chcesz ustawić obraz jako teksturę powtarzaną i dostosować zachowanie kafelkowania, możesz użyć następujących metod interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/) i klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Określa wyrównanie kafelków wewnątrz kształtu.
- [set_TileFlip](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Kontroluje, czy kafelek jest odbity poziomo, pionowo czy w obu kierunkach.
- [set_TileOffsetX](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [set_TileOffsetY](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [set_TileScaleX](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definiuje poziomą skalę kafelka w procentach.
- [set_TileScaleY](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definiuje pionową skalę kafelka w procentach.

Poniższy przykład kodu pokazuje, jak dodać prostokątny kształt z wypełnieniem obrazem powtarzanym i skonfigurować opcje kafelkowania:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto firstSlide = presentation->get_Slide(0);

// Dodaj automatyczny kształt prostokąta.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Ustaw typ wypełnienia kształtu na Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Wczytaj obraz i dodaj go do zasobów prezentacji.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Przypisz obraz do kształtu.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Skonfiguruj tryb wypełnienia obrazem i właściwości kafelkowania.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Zapisz plik PPTX na dysku.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Solid Color Fill**

W programie PowerPoint wypełnienie jednolitym kolorem to opcja formatowania, która wypełnia kształt jednym, jednolitym kolorem. Ten prosty kolor tła jest stosowany bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie jednolitym kolorem do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod C++ demonstruje, jak zastosować wypełnienie jednolitym kolorem do prostokąta w slajdzie PowerPoint:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj automatyczny kształt typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ustaw typ wypełnienia na Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Ustaw kolor wypełnienia.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Zapisz plik PPTX na dysku.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Kształt z jednolitym kolorem wypełnienia](solid-color-fill.png)

## **Ustawienie przezroczystości**

W programie PowerPoint, gdy stosujesz wypełnienie jednolitym kolorem, gradientem, obrazem lub teksturą do kształtów, możesz także określić poziom przezroczystości, aby kontrolować nieprzezroczystość wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, co umożliwia częściowe widzenie tła lub obiektów pod nim.

Aspose.Slides pozwala ustawić poziom przezroczystości, modyfikując wartość alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) na `Solid`.
1. Użyj klasy `Color`, aby zdefiniować kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

Poniższy kod C++ demonstruje, jak zastosować przezroczysty kolor wypełnienia do prostokąta:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj prostokątny automatyczny kształt wypełniony kolorem.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Dodaj przezroczysty prostokątny automatyczny kształt nad wypełnionym kształtem.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Zapisz plik PPTX na dysku.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych według określonych wymagań projektowych lub wyrównania.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość rotacji kształtu na żądany kąt.
1. Zapisz prezentację.

Poniższy kod C++ demonstruje, jak obrócić kształt o 5 stopni:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj automatyczny kształt typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Obróć kształt o 5 stopni.
shape->set_Rotation(5);

// Zapisz plik PPTX na dysku.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodawanie efektów 3D Bevel**

Aspose.Slides pozwala zastosować efekty 3D bevel do kształtów poprzez skonfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/threedformat/).

Aby dodać efekty 3D bevel do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/threedformat/) kształtu, aby określić ustawienia bevel.
1. Zapisz prezentację.

Poniższy kod C++ pokazuje, jak zastosować efekty 3D bevel do kształtu:

```cpp
// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Dodaj kształt do slajdu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Ustaw właściwości ThreeDFormat kształtu.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Zapisz prezentację jako plik PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Efekt 3D bevel](3D-bevel-effect.png)

## **Dodawanie efektów rotacji 3D**

Aspose.Slides umożliwia zastosowanie efektów rotacji 3D do kształtów poprzez skonfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/threedformat/).

Aby zastosować rotację 3D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Użyj metod [set_CameraType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icamera/set_cameratype/) i [set_LightType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilightrig/set_lighttype/), aby zdefiniować rotację 3D.
1. Zapisz prezentację.

Poniższy kod C++ demonstruje, jak zastosować efekty rotacji 3D do kształtu:

```cpp
// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Efekt rotacji 3D](3D-rotation-effect.png)

## **Resetowanie formatowania**

Poniższy kod C++ pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z polami wstawienia na [LayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/layoutslide/) do ich domyślnych ustawień:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Zresetuj każdy kształt na slajdzie, który ma pole zastępcze w układzie.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Czy formatowanie kształtu wpływa na ostateczny rozmiar pliku prezentacji?**

Jedynie minimalnie. Osadzone obrazy i media zajmują większość miejsca, natomiast parametry kształtu, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak wykryć na slajdzie kształty o identycznym formatowaniu, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — wypełnienie, linie i ustawienia efektów. Jeśli wszystkie odpowiadające sobie wartości są zgodne, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw własnych stylów kształtów w osobnym pliku do ponownego użycia w innych prezentacjach?**

Tak. Przechowaj przykładowe kształty z pożądanymi stylami w szablonie prezentacji lub w pliku szablonu *.POTX*. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylizowane kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.