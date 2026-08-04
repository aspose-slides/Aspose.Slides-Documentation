---
title: PowerPoint alakzatok formázása C++-ban
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/cpp/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat effektus
- vázlat alakzatvonal
- csatlakozási stílus formázása
- átmenetes kitöltés
- mintás kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- alakzat forgatása
- 3d lekerekített effektus
- 3d forgatási effektus
- formázás visszaállítása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan formázhatja a PowerPoint alakzatokat C++-ban az Aspose.Slides használatával—állítson be kitöltési, vonal- és effektustílusokat PPT, PPTX és ODP fájlokhoz pontosan és teljes irányítás mellett."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy effektusok alkalmazásával. Emellett beállíthatja az alakzatok kitöltését szabályozó beállítások megadásával.

![alakzat formázása PowerPointban](format-shape-powerpoint.png)

Az Aspose.Slides for C++ interfészeket és metódusokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokkal a beállításokkal formázhatja az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides használatával egyéni vonalstílust adhat meg egy alakzathoz. Az alábbi lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [vonalstílusát](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linestyle/).
1. Állítsa be a vonal vastagságát.
1. Állítsa be a vonal [vonalstílusát](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linedashstyle/).
1. Állítsa be a vonal színét az alakzatra.
1. Mentse a módosított prezentációt PPTX fájlként.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy automatikus téglalap alakzatot.
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

// Mentés PPTX fájlként a lemezen.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Vázlat effektusok alkalmazása az alakzatvonalakra**

A vázlat effektus úgy teszi, hogy egy alakzatvonal kézzel rajzoltnak tűnik. Használja a [IShape::get_LineFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_lineformat/) metódust a vonalbeállítások eléréséhez, az [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilineformat/get_sketchformat/) metódust a vázlat beállításokhoz, és az [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isketchformat/set_sketchtype/) metódust a [LineSketchType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linesketchtype/) felsorolásból való érték kiválasztásához.

Az alábbi C++ kód megmutatja, hogyan alkalmazhat egy [LineSketchType::Curved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linesketchtype/) effektust, hogyan olvashatja ki a kifejezetten hozzárendelt értéket, és hogyan távolíthatja el az effektust a [LineSketchType::None](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linesketchtype/) segítségével:

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

Az [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isketchformat/get_sketchtype/) által visszaadott érték a közvetlenül az alakzatra beállított értéket jelöli. Ha a vonalformázás egy témából, mesterdiából vagy elrendezési diából örökölhető, használja az [ILineFormat::GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilineformat/geteffective/) metódust, érje el az [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) elemet, és olvassa ki az [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) értékét. A hatékony érték tükrözi a formázást, amely valóban alkalmazásra kerül az öröklődés feloldása után:

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

## **Csatlakozási stílusok formázása**

Az alábbiak a három csatlakozási típus lehetőségei:

* Kerek
* Metsző
* Levágott

Alapértelmezés szerint, amikor a PowerPoint két vonalat szöggel egyesít (például egy alakzat sarkán), a **Kerek** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Metsző** beállítást.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

Az alábbi C++ kód bemutatja, hogyan hoztak létre három téglalapot (ahogy a fenti képen látható) a Metsző, Levágott és Kerek csatlakozási típus beállítások használatával:

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad három automatikus téglalap alakzatot.
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

// Beállítja a vonal vastagságát.
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

// Hozzáad szöveget minden téglalaphoz.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Mentés PPTX fájlként a lemezen.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Átmenetes kitöltés**

A PowerPointban az Átmenetes kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például több színt is alkalmazhat úgy, hogy az egyik fokozatosan átmenjen a másikba.

Itt látható, hogyan alkalmazhat átmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/)‑ját `Gradient` értékre.
1. Adja hozzá a két kedvenc színét a meghatározott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igradientformat/)‑interfész által nyújtott gradient stop gyűjtemény `Add` metódusaival.
1. Mentse a módosított prezentációt PPTX fájlként.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy ellipszis típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Átmenetes formázást alkalmaz az ellipszisre.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Beállítja az átmenet irányát.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Két átmenet‑állomást ad hozzá.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Mentés PPTX fájlként a lemezen.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az ellipszis átmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy két színű mintát – például pontokat, csíkokat, keresztvonalakat vagy sakktáblát – alkalmazzon egy alakzatra. Egyedi színeket választhat a minta előtér és háttér számára.

Az Aspose.Slides több mint 45 előre definiált mintastílust biztosít, amelyeket az alakzatokra alkalmazva javíthatja a prezentációk vizuális vonzerejét. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket a minta használni fog.

Itt látható, hogyan alkalmazhat minta kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/)‑ját `Pattern` értékre.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [háttérszínét](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipatternformat/get_backcolor/).
1. Állítsa be a minta [előtérszínét](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipatternformat/get_forecolor/).
1. Mentse a módosított prezentációt PPTX fájlként.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy téglalap típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Beállítja a kitöltés típusát mintára.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Beállítja a minta stílusát.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Beállítja a minta háttér- és előtérszíneit.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Mentés PPTX fájlként a lemezen.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A téglalap mintás kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy egy képet illesszen be egy alakzatba – gyakorlatilag a képet alakzat háttérként használva.

Itt látható, hogyan használhatja az Aspose.Slides‑t egy kép kitöltés alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/)‑ját `Picture` értékre.
1. Állítsa be a kép kitöltési módot `Tile`‑re (vagy egy másik kedvenc módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot a kívánt képből.
1. Adja át a képet az `ISlidesPicture.set_Image` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy „lotus.png” fájlunk a következő képpel:

![A lotus kép](lotus.png)

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy téglalap típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Beállítja a kitöltés típusát Képre.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Beállítja a kép kitöltési módot.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Betölt egy képet és hozzáadja a prezentáció erőforrásaihoz.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Beállítja a képet.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Mentés PPTX fájlként a lemezen.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Kép csempézése textúraként**

Ha egy csempézett képet szeretne textúraként beállítani, és testre szabni a csempézés viselkedését, a következő [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/) interfész és [PictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/picturefillformat/) osztály metódusait használhatja:

- [set_PictureFillMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Beállítja a kép kitöltési módot — `Tile` vagy `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Megadja a csempék igazítását az alakzaton belül.
- [set_TileFlip](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Kezeli, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [set_TileOffsetX](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Beállítja a csempe vízszintes eltolását (pontban) az alakzat origójától.
- [set_TileOffsetY](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Beállítja a csempe függőleges eltolását (pontban) az alakzat origójától.
- [set_TileScaleX](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Meghatározza a csempe vízszintes méretezését százalékban.
- [set_TileScaleY](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódminta megmutatja, hogyan adhat hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és hogyan konfigurálhatja a csempe beállításait:

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto firstSlide = presentation->get_Slide(0);

// Hozzáad egy téglalap automatikus alakzatot.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Beállítja az alakzat kitöltés típusát Képre.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Kiosztja a képet az alakzatra.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Konfigurálja a kép kitöltési módot és a csempézési beállításokat.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Mentés PPTX fájlként a lemezen.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A csempe beállítások](tile-options.png)

## **Egy színű kitöltés**

A PowerPointban az Egy színű kitöltés egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín alkalmazásra kerül anélkül, hogy bármilyen átmenet, textúra vagy minta lenne.

Az Aspose.Slides segítségével egy színű kitöltést alkalmazhat egy alakzatra a következő lépésekkel:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/)‑ját `Solid` értékre.
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy téglalap típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Beállítja a kitöltés típusát Szilárdra.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Beállítja a kitöltő színt.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Mentés PPTX fájlként a lemezen.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az alakzat egy színű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egy alakzatra egyszínű, átmenetes, kép‑ vagy textúrakitöltést alkalmaz, beállíthat egy átlátszósági szintet is, amely a kitöltés átlátszatlanságát szabályozza. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, lehetővé téve, hogy a háttér vagy az alatta lévő objektumok részben láthatóak legyenek.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltéshez használt szín alfa komponensének módosításával. Íme, hogyan teheti meg:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/)‑t `Solid` értékre.
1. Használja a `Color`‑t egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy szilárd téglalap automatikus alakzatot.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Hozzáad egy átlátszó téglalap automatikus alakzatot a szilárd alakzat felett.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Mentés PPTX fájlként a lemezen.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi az alakzatok forgatását a PowerPoint‑prezentációkban. Ez hasznos lehet a vizuális elemek pontos elhelyezésénél vagy speciális tervezési igények esetén.

Az alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy téglalap típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Forgatja az alakzatot 5 fokkal.
shape->set_Rotation(5);

// Mentés PPTX fájlként a lemezen.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D lekerekített hatások hozzáadása**

Az Aspose.Slides lehetővé teszi, hogy 3D lekerekített hatásokat alkalmazzon az alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

A 3D lekerekített hatások egy alakzatra való hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/threedformat/)‑ját a lekerekítési beállítások meghatározásához.
1. Mentse a prezentációt.

```cpp
// Létrehoz egy példányt a Presentation osztályból.
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

// Mentés a prezentációt PPTX fájlként.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A 3D lekerekített hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi, hogy 3D forgatási hatásokat alkalmazzon az alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

A 3D forgatási hatás egy alakzatra:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Használja a [set_CameraType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icamera/set_cameratype/) és [set_LightType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilightrig/set_lighttype/) metódusokat a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

```cpp
// Létrehoz egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Mentés a prezentációt PPTX fájlként.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi C++ kód bemutatja, hogyan állíthatja vissza egy dia formázását, és hogyan állíthatja vissza az összes helykitöltővel rendelkező alakzat pozícióját, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/layoutslide/) alapértelmezett beállításaiba:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Állítsa vissza a dián lévő minden alakzatot, amelynek helykitöltője van az elrendezésen.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**A formázott alakzatok befolyásolják a kész prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a legtöbb helyet, míg az alakzatparaméterek, például színek, effektusok és átmenetek metaadatként tárolódnak, és gyakorlatilag nem növelik a fájlméretet.

**Hogyan tudom felismerni a dián azon alakzatokat, amelyek azonos formázást használnak, hogy csoportosíthassam őket?**

Használja az egyes alakzatok kulcsfontosságú formázási tulajdonságainak – kitöltés, vonal és effektus – összehasonlítását. Ha minden megfelelő érték egyezik, tekintse ezeket a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ami leegyszerűsíti a későbbi stíluskezelést.

**Menthetek-e egyedi alakzatstílusok készletét egy külön fájlba, hogy más prezentációkban újra felhasználhassam?**

Igen. Tárolja a kívánt stílusokkal ellátott mintaalakzatokat egy sablon‑diakönyvtárban vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázásukat a megfelelő helyeken.