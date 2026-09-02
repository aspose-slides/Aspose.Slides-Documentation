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
- renderowanie kształtu czarno-białe
- renderowanie kształtu w odcieniach szarości
- obrót kształtu
- efekt 3D przycięcia
- efekt 3D obrotu
- resetowanie formatowania
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w C++ przy użyciu Aspose.Slides — ustawiaj style wypełnień, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz formatować je, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełnienia ich wnętrza.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ udostępnia interfejsy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji, które są dostępne w programie PowerPoint.

## **Formatowanie linii**

Korzystając z Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniższe kroki opisują procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [line style](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [dash style](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokątną `AutoShape`:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Uzyskaj pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto shape typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Ustaw kolor wypełnienia dla kształtu prostokąta.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Zastosuj formatowanie do linii prostokąta.
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

Rezultat:

![The formatted lines in the presentation](formatted-lines.png)

## **Zastosowanie efektów szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda na odręcznie rysowaną. Użyj [IShape::get_LineFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_lineformat/) do uzyskania dostępu do ustawień linii, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilineformat/get_sketchformat/) do uzyskania dostępu do ustawień szkicu oraz [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isketchformat/set_sketchtype/) aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linesketchtype/).

Poniższy kod C++ pokazuje, jak zastosować efekt [LineSketchType::Curved](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linesketchtype/), odczytać przypisaną wartość i usunąć efekt za pomocą [LineSketchType::None](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linesketchtype/):

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

Wartość zwrócona przez [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isketchformat/get_sketchtype/) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu‑mistrza lub slajdu‑układu, użyj [ILineFormat::GetEffective](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilineformat/geteffective/), uzyskaj dostęp do [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) i odczytaj [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Efektywna wartość odzwierciedla formatowanie, które faktycznie zostaje zastosowane po rozwiązaniu dziedziczenia:

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

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w rogu kształtu), używa ustawienia **Round**. Jednakże, jeśli rysujesz kształt o ostrych kątach, możesz preferować opcję **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Poniższy kod C++ demonstruje, jak trzy prostokąty (jak na powyższym obrazie) zostały utworzone przy użyciu ustawień Miter, Bevel i Round:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj trzy auto shape typu Rectangle.
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

W programie PowerPoint wypełnienie gradientowe jest opcją formatowania, która pozwala na zastosowanie ciągłego przejścia kolorów do kształtu. Na przykład możesz nałożyć dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwie preferowane kolory z określonymi pozycjami, używając metod `Add` kolekcji przystanków gradientu udostępnianej przez interfejs [IGradientFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod C++ demonstruje, jak zastosować efekt wypełnienia gradientowego do elipsy:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto shape typu Ellipse.
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

Rezultat:

![The ellipse with gradient fill](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala na zastosowanie dwukolorowego wzoru — takiego jak kropki, paski, krzyżówki lub szachownica — do kształtu. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wstępnie zdefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu gotowego wzoru możesz określić dokładne kolory, które ma on używać.

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
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto shape typu Rectangle.
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

Rezultat:

![The rectangle with pattern fill](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem jest opcją formatowania, która pozwala umieścić obraz wewnątrz kształtu — skutecznie używając obrazu jako tła kształtu.

Oto jak używać Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `ISlidesPicture.set_Image`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik „lotus.png” z następującym obrazem:

![The lotus picture](lotus.png)

Poniższy kod C++ demonstruje, jak wypełnić kształt obrazem:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto shape typu Rectangle.
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

Rezultat:

![The shape with picture fill](picture-fill.png)

### **Kafelkowanie obrazu jako tekstury**

Jeśli chcesz ustawić obraz w trybie kafelkowania jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/) i klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Określa wyrównanie kafelków wewnątrz kształtu.
- [set_TileFlip](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Kontroluje, czy kafelek jest odbijany w poziomie, w pionie lub w obu kierunkach.
- [set_TileOffsetX](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [set_TileOffsetY](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [set_TileScaleX](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definiuje poziomą skalę kafelka jako procent.
- [set_TileScaleY](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokątny kształt z kafelkowanym wypełnieniem obrazu i skonfigurować opcje kafelkowania:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto firstSlide = presentation->get_Slide(0);

// Dodaj prostokątny auto shape.
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

Rezultat:

![The tile options](tile-options.png)

## **Jednolite wypełnienie kolorem**

W programie PowerPoint jednolite wypełnienie kolorem jest opcją formatowania, która wypełnia kształt jednym, jednolitym kolorem. Ten prosty kolor tła jest stosowany bez gradientów, tekstur ani wzorów.

Aby zastosować jednolite wypełnienie kolorem do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz preferowany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod C++ demonstruje, jak zastosować jednolite wypełnienie kolorem do prostokąta w slajdzie PowerPoint:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj auto shape typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ustaw typ wypełnienia na Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Ustaw kolor wypełnienia.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Zapisz plik PPTX na dysku.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Rezultat:

![The shape with solid color fill](solid-color-fill.png)

## **Ustawienie przezroczystości**

W programie PowerPoint, gdy stosujesz jednolity kolor, gradient, obraz lub wypełnienie teksturą do kształtów, możesz również ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przezroczysty, co pozwala częściowo widzieć tło lub obiekty pod spodem.

Aspose.Slides umożliwia ustawienie poziomu przezroczystości poprzez dostosowanie wartości alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) na `Solid`.
1. Użyj klasy `Color`, aby zdefiniować kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

Poniższy kod C++ demonstruje, jak zastosować przezroczysty kolor wypełnienia do prostokąta:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto slide = presentation->get_Slide(0);

// Dodaj prostokątny auto shape wypełniony kolorem.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Dodaj przezroczysty prostokątny auto shape nad stałym kształtem.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Zapisz plik PPTX na dysku.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Rezultat:

![The transparent shape](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych wymagających określonego wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość obrotu kształtu na żądany kąt.
1. Zapisz prezentację.

Poniższy kod C++ demonstruje, jak obrócić kształt o 5 stopni:

```cpp
#include <DOM/IAutoShape> 
#include <DOM/IShapeCollection>
#include <DOM/ISlide>
#include <DOM/Presentation>
#include <DOM/ShapeType>
#include <Export/SaveFormat>
#include <system/smart_ptr>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>();

// Pobierz pierwszy slajd.
auto  ?


```

Rezultat:

![The shape rotation](shape-rotation.png)

## **Dodawanie efektów 3‑D przycięcia**

Aspose.Slides pozwala zastosować efekty 3‑D przycięcia do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/threedformat/).

Aby dodać efekty 3‑D przycięcia do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/threedformat/) kształtu, aby określić ustawienia przycięcia.
1. Zapisz prezentację.

Poniższy kod C++ pokazuje, jak zastosować efekty 3‑D przycięcia do kształtu:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Create an instance of the Presentation class.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Rezultat:

![The 3D bevel effect](3D-bevel-effect.png)

## **Dodawanie efektów 3‑D obrotu**

Aspose.Slides pozwala zastosować efekty 3‑D obrotu do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/threedformat/).

Aby zastosować 3‑D obrót do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Użyj metod [set_CameraType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icamera/set_cameratype/) i [set_LightType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilightrig/set_lighttype/), aby określić 3‑D obrót.
1. Zapisz prezentację.

Poniższy kod C++ demonstruje, jak zastosować efekty 3‑D obrotu do kształtu:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Rezultat:

![The 3D rotation effect](3D-rotation-effect.png)

## **Kontrola renderowania czarno‑białego dla kształtów**

Metoda [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/set_blackwhitemode/) określa, w jaki sposób pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno‑białym. Nie włącza ona samej funkcji wyświetlania w czerni i bieli i nie zmienia wypełnienia, linii ani innych formatowań kształtu w normalnym trybie kolorowym.

Użyj wartości z wyliczenia [BlackWhiteMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/blackwhitemode/), aby wybrać pożądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają odcieni szarości, `BlackWhite` używa wyłącznie czerni i bieli, `Black` i `White` wymuszają pojedynczy kolor, `Color` zachowuje normalne kolory, a `Hidden` pomija kształt w trybie czarno‑białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Poniższy kod C++ tworzy kolorowy kształt i sprawia, że w trybie wyświetlania czarno‑białego jest on wyświetlany w szarości:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Zachowaj pomarańczowe wypełnienie w trybie kolorowym, ale renderuj kształt w odcieniach szarości w trybie czarno-białym.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

W normalnym trybie kolorowym prostokąt zachowuje pomarańczowe wypełnienie. W przepływie pracy wyświetlania czarno‑białego używa szarego koloru, ponieważ jego tryb został ustawiony na `Gray`. Dzięki temu możesz zachować slajd w pełnym kolorze, definiując jednocześnie odrębny wygląd dla drukowania, podglądu lub innych przepływów, które respektują ustawienia wyświetlania czarno‑białego prezentacji.

## **Resetowanie formatowania**

Poniższy kod C++ pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z placeholderami na [LayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/layoutslide/) do ich domyślnych ustawień:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Zresetuj każdy kształt na slajdzie, który ma placeholder w układzie.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko minimalnie. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, natomiast parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — wypełnienie, linię i ustawienia efektów. Jeśli wszystkie odpowiadające sobie wartości są zgodne, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw własnych stylów kształtów w oddzielnym pliku do ponownego użycia w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie slajdów lub w pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowane kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.