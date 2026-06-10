---
title: "PowerPoint alakzatok formázása C++-ban"
linktitle: "Alakzat formázása"
type: docs
weight: 20
url: /hu/cpp/shape-formatting/
keywords:
- "alakzat formázása"
- "vonal formázása"
- "csatlakozási stílus formázása"
- "gradient kitöltés"
- "minta kitöltés"
- "kép kitöltés"
- "textúra kitöltés"
- "egyszínű kitöltés"
- "alakzat átlátszóság"
- "alakzat forgatása"
- "3D ferde hatás"
- "3D forgatási hatás"
- "formázás visszaállítása"
- "PowerPoint"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Tudjon meg mindent a PowerPoint alakzatok C++-ban történő formázásáról az Aspose.Slides segítségével – állítson be kitöltés, vonal és effektus stílusokat PPT, PPTX és ODP fájlokhoz precíz és teljes körű irányítással."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a vonalak módosításával vagy hatások alkalmazásával. Emellett az alakzatok formázása során megadhat beállításokat, amelyek szabályozzák, hogyan töltik ki a belsejüket.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for C++ felületet és metódusokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazon beállításokkal.

## **Vonalak formázása**

Az Aspose.Slides használatával egy alakzat egyéni vonalstílusát adhatja meg. Az alábbi lépések mutatják be az eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linestyle/) értékét.
1. Állítsa be a vonalvastagságot.
1. Állítsa be a [dash style](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linedashstyle/) értékét a vonalon.
1. Állítsa be a vonal színét az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázzuk a `AutoShape` téglalapot:

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy Rectangle típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Beállítja a téglalap alakzat kitöltő színét.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Formázást alkalmaz a téglalap vonalaira.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Beállítja a téglalap vonalának színét.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The formatted lines in the presentation](formatted-lines.png)

## **Csatlakozási stílusok formázása**

A csatlakozási típus három lehetősége:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat egy szögnél összekapcsol (például egy alakzat sarkán), a **Round** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Miter** lehetőséget.

![The join style in the presentation](join-style-powerpoint.png)

Az alábbi C++ kód bemutatja, hogyan hoztak létre három téglalapot (ahogy a fenti képen látható) a Miter, Bevel és Round csatlakozási típus beállításokkal:

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad három Rectangle típusú automatikus alakzatot.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Beállítja minden téglalap alakzat kitöltő színét.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Beállítja a vonalvastagságot.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Beállítja minden téglalap vonalának színét.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Beállítja a csatlakozási stílust.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Szöveget ad minden téglalaphoz.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gradient kitöltés**

A PowerPointban a Gradient kitöltés egy formázási beállítás, amely lehetővé teszi a színek folyamatos keverését egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan átmenjen a másikba.

Íme, hogyan alkalmazhat gradient kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Gradient`-re.
1. Adja hozzá a két kívánt színt a meghatározott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igradientformat/) felület által biztosított gradient stop gyűjtemény `Add` metódusaival.
1. Mentse a módosított prezentációt PPTX fájlként.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy Ellipse típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Gradient formázást alkalmaz az ellipszisre.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Beállítja a gradient irányát.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Két gradient állomást ad hozzá.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The ellipse with gradient fill](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Pattern Fill egy formázási opció, amely lehetővé teszi egy kétdomináns (két színű) minta — például pontok, csíkok, keresztvonalak vagy négyzetrács — alkalmazását egy alakzatra. A minta előtér és hátterének színét egyénileg is megadhatja.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazva javíthatja a prezentációk vizuális megjelenését. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használni szeretne.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Pattern`-re.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipatternformat/get_backcolor/) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipatternformat/get_forecolor/) értékét.
1. Mentse a módosított prezentációt PPTX fájlként.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy Rectangle típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Beállítja a kitöltés típusát Pattern-re.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Beállítja a minta stílusát.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Beállítja a minta háttér- és előtérszíneket.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The rectangle with pattern fill](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Picture Fill egy formázási opció, amely lehetővé teszi kép beillesztését egy alakzatba – a képet hatékonyan az alakzat háttérként használja.

Íme, hogyan alkalmazhat kép kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Picture`-ra.
1. Állítsa be a kép kitöltés módját `Tile`-re (vagy más kedvelt módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot a használni kívánt képből.
1. Adja át a képet az `ISlidesPicture.set_Image` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

![The lotus picture](lotus.png)

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy Rectangle típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Beállítja a kitöltés típusát Picture-re.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Beállítja a kép kitöltési módot.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Betölt egy képet és hozzáadja a prezentáció erőforrásaihoz.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Beállítja a képet.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The shape with picture fill](picture-fill.png)

### **Kép csempézése textúraként**

Ha csempézett képet szeretne beállítani textúraként, és testreszabni a csempézés viselkedését, használhatja a [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/) felület és a [PictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/picturefillformat/) osztály a következő metódusait:

- [set_PictureFillMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Megadja a csempék igazítását az alakzaton belül.
- [set_TileFlip](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Meghatározza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [set_TileOffsetX](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulópontjától.
- [set_TileOffsetY](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulópontjától.
- [set_TileScaleX](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Meghatározza a csempe vízszintes méretezését százalékban.
- [set_TileScaleY](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet bemutatja, hogyan adhatunk hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és hogyan állíthatjuk be a csempe opciókat:

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto firstSlide = presentation->get_Slide(0);

// Hozzáad egy téglalap automatikus alakzatot.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Beállítja az alakzat kitöltés típusát Picture-re.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Hozzáadja a képet az alakzathoz.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Konfigurálja a kép kitöltési módot és a csempézés tulajdonságait.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The tile options](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási opció, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín megjelenik gradientek, textúrák vagy minták nélkül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Solid`-ra.
1. Adja meg a kívánt kitöltő színt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy Rectangle típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Beállítja a kitöltés típusát Solid-ra.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Beállítja a kitöltő színt.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The shape with solid color fill](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egy alakzatra egyszínű, gradient, képes vagy textúra kitöltést alkalmaz, beállíthatja az átlátszósági szintet is, amely szabályozza a kitöltés átlátszóságát. A magasabb átlátszóság érték átlátszóbbá teszi az alakzatot, lehetővé téve, hogy a háttér vagy az alatta lévő objektumok részben láthatóak legyenek.

Az Aspose.Slides lehetővé teszi az átlátszóság szintjének beállítását a kitöltés színének alfa értékének módosításával. Íme, hogyan:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Solid`-ra.
1. Használja a `Color` osztályt átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy szilárd téglalap automatikus alakzatot.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Hozzáad egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölé.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The transparent shape](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek adott igazítási vagy tervezési igények szerinti elhelyezésénél.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy Rectangle típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Elforgatja az alakzatot 5 fokkal.
shape->set_Rotation(5);

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The shape rotation](shape-rotation.png)

## **3D Ferde hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D ferde hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/threedformat/) beállításait a ferde (bevel) paraméterek meghatározásához.
1. Mentse a prezentációt.

```cpp
// Példányosítja a Presentation osztályt.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Hozzáad egy alakzatot a diához.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Beállítja az alakzat ThreeDFormat tulajdonságait.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Mentse a prezentációt PPTX fájlként.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D Forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot a diához.
1. Használja a [set_CameraType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icamera/set_cameratype/) és [set_LightType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilightrig/set_lighttype/) metódusokat a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

```cpp
// Példányosítja a Presentation osztályt.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Mentse a prezentációt PPTX fájlként.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The 3D rotation effect](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi C++ kód bemutatja, hogyan állítható vissza egy dia formázása, és hogyan állíthatók vissza a helyzet, méret és formázás minden helykitöltővel rendelkező alakzatra a [LayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/layoutslide/) alapértelmezett beállításaival:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Visszaállítja a dián lévő minden alakzatot, amelynek helykitöltője van az elrendezésben.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**A formaformázás befolyásolja a végső prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és média foglalja a fájl legnagyobb részét, míg az alakzatok paraméterei, mint a színek, hatások és gradientek, metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan tudom felismerni a dián azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effekt beállítások. Ha az összes megfelelő érték egyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek-e egyéni alakzatstílusokat egy külön fájlba, hogy más prezentációkban is felhasználhassam őket?**

Igen. Tárolja a kívánt stílusokkal ellátott mintaalakzatokat egy sablon diakészletben vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és a kívánt helyeken alkalmazza újra a formázásukat.