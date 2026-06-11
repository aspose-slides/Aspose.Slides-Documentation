---
title: Formatowanie kształtów PowerPoint w C++
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/cpp/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- formatowanie stylu połączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie kolorem jednolitym
- przezroczystość kształtu
- obracanie kształtu
- efekt 3D bevel
- efekt obrotu 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w C++ przy użyciu Aspose.Slides — ustaw style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełnienia ich wnętrz.

![Formatowanie kształtu w PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ udostępnia interfejsy i metody, które umożliwiają formatowanie kształtów przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Używając Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniżej przedstawiono procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [styl linii](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [dash style](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokąt `AutoShape`:

```cpp
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto kształt typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Ustaw kolor wypełnienia dla prostokątnego kształtu.
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

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Zaokrąglone
* Kątowy
* Fazowany

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w rogu kształtu), używa ustawienia **Zaokrąglone**. Jednak jeśli rysujesz kształt z ostrymi kątami, możesz preferować opcję **Kątowy**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod C++ pokazuje, jak utworzono trzy prostokąty (jak na powyższym obrazie) przy użyciu ustawień typu połączenia Kątowy, Fazowany i Zaokrąglone:

```cpp
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj trzy auto kształty typu Rectangle.
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

## **Wypełnienie gradientowe**

W PowerPoint wypełnienie gradientowe jest opcją formatowania, która umożliwia zastosowanie ciągłego przejścia kolorów do kształtu. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwa wybrane kolory z określonymi pozycjami, korzystając z metod `Add` kolekcji gradientowych przystanków udostępnianej przez interfejs [IGradientFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```cpp
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto kształt typu Ellipse.
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

## **Wypełnienie wzorem**

W PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala zastosować dwukolorowy wzór — taki jak kropki, paski, krzyżowanie lub kratkę — do kształtu. Możesz wybrać własne kolory pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 predefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu predefiniowanego wzoru możesz określić dokładne kolory, które ma używać.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru spośród predefiniowanych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipatternformat/get_backcolor/) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipatternformat/get_forecolor/) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```cpp
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto kształt typu Rectangle.
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

## **Wypełnienie obrazem**

W PowerPoint wypełnienie obrazem jest opcją formatowania, która pozwala wstawić obraz wewnątrz kształtu — efektywnie używając obrazu jako tła kształtu.

Oto jak użyć Aspose.Slides, aby zastosować wypełnienie obrazem do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazu na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `ISlidesPicture.set_Image`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik "lotus.png" z następującym obrazem:

![Obraz lotosu](lotus.png)

```cpp
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto kształt typu Rectangle.
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

### **Kafelkowanie obrazu jako tekstura**

Jeśli chcesz ustawić kafelkowany obraz jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/) oraz klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Ustawia tryb wypełnienia obrazu — `Tile` lub `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Określa wyrównanie kafelków wewnątrz kształtu.
- [set_TileFlip](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Kontroluje, czy kafelek jest odwrócony w poziomie, w pionie, czy w oba sposoby.
- [set_TileOffsetX](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Ustawia poziomy offset kafelka (w punktach) od pochodzenia kształtu.
- [set_TileOffsetY](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Ustawia pionowy offset kafelka (w punktach) od pochodzenia kształtu.
- [set_TileScaleX](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definiuje poziomą skalę kafelka jako procent.
- [set_TileScaleY](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definiuje pionową skalę kafelka jako procent.

```cpp
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto firstSlide = presentation->get_Slide(0);

// Dodaj prostokątny auto kształt.
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

// Skonfiguruj tryb wypełnienia obrazem oraz właściwości kafelkowania.
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

## **Wypełnienie kolorem jednolitym**

W PowerPoint wypełnienie kolorem jednolitym jest opcją formatowania, która wypełnia kształt jednym, jednolitym kolorem. Ten prosty kolor tła jest stosowany bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie kolorem jednolitym do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```cpp
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto kształt typu Rectangle.
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

![Kształt z wypełnieniem kolorem jednolitym](solid-color-fill.png)

## **Ustawienie przezroczystości**

W PowerPoint, gdy stosujesz wypełnienie kolorem jednolitym, gradientem, obrazem lub teksturą do kształtów, możesz także ustawić poziom przezroczystości, aby kontrolować nieprzezroczystość wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, co pozwala częściowo widzieć tło lub znajdujące się pod nim obiekty.

Aspose.Slides pozwala ustawić poziom przezroczystości, dostosowując wartość alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) na `Solid`.
1. Użyj `Color`, aby zdefiniować kolor z przezroczystością (składnik `alpha` steruje przezroczystością).
1. Zapisz prezentację.

```cpp
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj automatyczny prostokątny kształt wypełniony kolorem.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Dodaj automatyczny prostokątny kształt przezroczysty nad wypełnionym kształtem.
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

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych wymagających określonego wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość obrotu kształtu na żądany kąt.
1. Zapisz prezentację.

```cpp
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto kształt typu Rectangle.
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

Aspose.Slides pozwala stosować efekty 3D Bevel do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/threedformat/).

Aby dodać efekty 3D Bevel do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/threedformat/) kształtu, aby określić ustawienia bevel.
1. Zapisz prezentację.

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

![Efekt 3D Bevel](3D-bevel-effect.png)

## **Dodawanie efektów obrotu 3D**

Aspose.Slides pozwala stosować efekty obrotu 3D do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/threedformat/).

Aby zastosować obrót 3D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Użyj [set_CameraType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icamera/set_cameratype/) i [set_LightType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilightrig/set_lighttype/), aby zdefiniować obrót 3D.
1. Zapisz prezentację.

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

// Zapisz prezentację jako plik PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Efekt obrotu 3D](3D-rotation-effect.png)

## **Resetowanie formatowania**

Poniższy kod C++ pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z symbolami zastępczymi na [LayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/layoutslide/) do ich domyślnych ustawień:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Zresetuj każdy kształt na slajdzie, który ma symbol zastępczy w układzie.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko nieznacznie. Osadzone obrazy i media zajmują większość przestrzeni pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości są identyczne, potraktuj ich style jako takie same i logicznie pogrupuj te kształty, co ułatwia późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów w osobnym pliku do ponownego użycia w innych prezentacjach?**

Tak. Przechowaj przykładowe kształty z pożądanymi stylami w zestawie slajdów szablonu lub w pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowane kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.