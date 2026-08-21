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
- alakzatvonal vázlat
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat renderelés
- szürkeskála alakzat renderelés
- alakzat forgatása
- 3D rézsút hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat C++-ban az Aspose.Slides segítségével – állítson be kitöltés, vonal és effektus stílusokat PPT, PPTX és ODP fájlokhoz pontossággal és teljes irányítással."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy effektusok alkalmazásával. Emellett beállíthatja az alakzatok kitöltését szabályozó beállítások megadásával.

![PowerPoint alakzat formázása](format-shape-powerpoint.png)

Az Aspose.Slides for C++ felületeket és metódusokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a beállításokkal.

## **Vonalak formázása**

Az Aspose.Slides segítségével egy alakzat egyéni vonalstílusát adhatja meg. Az alábbi lépések ismertetik az eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linestyle/) tulajdonságát.
1. Állítsa be a vonal szélességét.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linedashstyle/) tulajdonságát.
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy téglalap `AutoShape`‑ot:

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

// Hozzon létre egy Presentation osztályt, amely egy bemutató fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Szerezze meg az első diát.
auto slide = presentation->get_Slide(0);

// Adjon hozzá egy automatikus alakzatot Rectangle típusú.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Állítsa be a téglalap alakzat kitöltő színét.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Alkalmazzon formázást a téglalap vonalaira.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Állítsa be a téglalap vonalának színét.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A formázott vonalak a bemutatóban](formatted-lines.png)

## **Vázlat effektusok alkalmazása az alakzat vonalakra**

A vázlat effektus úgy mutatja a vonalat, mintha kézzel rajzolták volna. Használja a [IShape::get_LineFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_lineformat/) metódust a vonal beállításainak eléréséhez, a [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilineformat/get_sketchformat/) metódust a vázlat beállításainak eléréséhez, és a [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isketchformat/set_sketchtype/) metódust a [LineSketchType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linesketchtype/) felsorolásból egy érték kiválasztásához.

Az alábbi C++ kód megmutatja, hogyan alkalmazzon egy [LineSketchType::Curved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linesketchtype/) effektust, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el az effektust a [LineSketchType::None](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linesketchtype/) segítségével:

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

A [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isketchformat/get_sketchtype/) által visszaadott érték az alakzatra közvetlenül hozzárendelt beállítást jelöli. Ha a vonalformázás egy témából, mester‑diaszablonból vagy elrendezési diából örökölhető, használja a [ILineFormat::GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilineformat/geteffective/) metódust, érje el a [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) tulajdonságot, és olvassa ki az [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) értékét. A hatékony érték a ténylegesen alkalmazott formázást tükrözi, miután az öröklődés feloldódott:

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

A három csatlakozási típus lehetőség a következő:

* Kerek
* Éles
* Levágott

Alapértelmezés szerint, amikor a PowerPoint két vonalat szöggel illeszt össze (például egy alakzat sarkán), a **Kerek** beállítást használja. Azonban, ha éles szögekkel rendelkező alakzatot rajzol, a **Miter** opció lehet előnyösebb.

![A csatlakozási stílus a bemutatóban](join-style-powerpoint.png)

Az alábbi C++ kód bemutatja, hogyan hoztak létre három téglalapot (a fenti képen látható módon) a Miter, Bevel és Round csatlakozási típusok beállításaival:

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

// Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Szerezze meg az első diát.
auto slide = presentation->get_Slide(0);

// Adjon hozzá három automatikus alakzatot Rectangle típusú.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Állítsa be a kitöltő színt minden téglalap alakzatra.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Állítsa be a vonal vastagságát.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Állítsa be a vonal színét minden téglalaphoz.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Állítsa be a csatlakozási stílust.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Adjon szöveget minden téglalaphoz.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Színátmenetes kitöltés**

A PowerPointban a Gradient Fill egy formázási lehetőség, amely folyamatos színátmenetet alkalmaz egy alakzatra. Például két vagy több színt helyezhet el úgy, hogy az egyik fokozatosan elhalványul a másikba.

Így alkalmazhat színátmenetes kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Gradient`‑ra.
1. Adja meg a két kívánt színt meghatározott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igradientformat/) interfész által nyújtott gradient‑stop gyűjtemény `Add` metódusaival.
1. Mentse a módosított bemutatót PPTX fájlként.

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

// Hozzon létre egy Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Szerezze meg az első diát.
auto slide = presentation->get_Slide(0);

// Adjon hozzá egy automatikus alakzatot Ellipszis típusú.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Alkalmazzon színátmenetes formázást az ellipszisre.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Állítsa be a színátmenet irányát.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Adjon hozzá két színátmenet‑állomást.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Pattern Fill egy formázási lehetőség, amely lehetővé teszi egy két színű minta – például pontok, csíkok, keresztvonalak vagy négyzethálók – alkalmazását egy alakzatra. A minta előtér- és háttérszínét egyénileg is megadhatja.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazva szebbé teheti a prezentációkat. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket.

Az alábbiakban bemutatjuk, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Pattern`‑ra.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipatternformat/get_backcolor/) tulajdonságát.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipatternformat/get_forecolor/) tulajdonságát.
1. Mentse a módosított bemutatót PPTX fájlként.

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

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Szerezze meg az első diát.
auto slide = presentation->get_Slide(0);

// Adjon hozzá egy automatikus alakzatot Rectangle típusú.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Állítsa be a kitöltés típusát Pattern-re.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Állítsa be a mintastílust.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Állítsa be a minta háttér- és előtérszínét.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Picture Fill egy formázási lehetőség, amely lehetővé teszi kép beillesztését egy alakzatba – lényegében a képet a háttérként használva.

Az alábbiakban bemutatjuk, hogyan használja az Aspose.Slides‑t a kép kitöltés alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Picture`‑ra.
1. Állítsa be a kép kitöltési módot `Tile`‑re (vagy egy másik kedvenc módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot a használni kívánt képből.
1. Adja át a képet az `ISlidesPicture.set_Image` metódusnak.
1. Mentse a módosított bemutatót PPTX fájlként.

![A lotus kép](lotus.png)

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

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Szerezze meg az első diát.
auto slide = presentation->get_Slide(0);

// Adjon hozzá egy automatikus alakzatot Rectangle típusú.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Állítsa be a kitöltés típusát Picture-re.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Állítsa be a kép kitöltési módot.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Töltsön be egy képet és adja hozzá a prezentáció erőforrásaihoz.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Állítsa be a képet.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az alakzat képpel kitöltve](picture-fill.png)

### **Kép mozaikmintaként textúra**

Ha egy mozaikmintás képet szeretne textúraként beállítani, és testreszabni a mozaik viselkedését, használja a [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/picturefillformat/) osztály következő metódusait:

- [set_PictureFillMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Beállítja a képpel való kitöltés módját—`Tile` vagy `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Megadja a csempék igazítását az alakzaton belül.
- [set_TileFlip](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőben tükröződjön.
- [set_TileOffsetX](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Beállítja a csempe vízszintes eltolását (pontban) az alakzat eredetétől.
- [set_TileOffsetY](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Beállítja a csempe függőleges eltolását (pontban) az alakzat eredetétől.
- [set_TileScaleX](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Meghatározza a csempe vízszintes méretezését százalékban.
- [set_TileScaleY](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Meghatározza a csempe függőleges méretezését százalékban.

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

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Szerezze meg az első diát.
auto firstSlide = presentation->get_Slide(0);

// Adjon hozzá egy téglalap auto alakzatot.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Állítsa be a kitöltés típusát Picture-re.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Töltsön be egy képet és adja hozzá a prezentáció erőforrásaihoz.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Rendelje hozzá a képet az alakzathoz.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Állítsa be a kép kitöltési módot és a csempe tulajdonságait.
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

![A csempe beállítások](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban a Solid Color Fill egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín nincs befolyással semmilyen színátmenetre, textúrára vagy mintára.

Az egyszínű kitöltés alkalmazásához egy alakzatra az Aspose.Slides‑el kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Solid`‑ra.
1. Rendelje hozzá a kívánt kitöltő színt az alakzathoz.
1. Mentse a módosított bemutatót PPTX fájlként.

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

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Szerezze meg az első diát.
auto slide = presentation->get_Slide(0);

// Adjon hozzá egy automatikus alakzatot Rectangle típusú.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Állítsa be a kitöltés típusát Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Állítsa be a kitöltő színt.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egy alakzatra egyszínű, színátmenetes, képes vagy textúras kitöltést alkalmaz, megadhatja az átlátszósági szintet is, amely szabályozza a kitöltés átlátszatlanságát. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, lehetővé téve, hogy a háttér vagy az alatta lévő objektumok részben láthatóak legyenek.

Az Aspose.Slides a kitöltéshez használt szín alfa komponensének módosításával teszi lehetővé az átlátszóság szintjének beállítását. Így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Solid`‑ra.
1. Használja a `Color`‑t egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a bemutatót.

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

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Szerezze meg az első diát.
auto slide = presentation->get_Slide(0);

// Adjon hozzá egy egyszínű téglalap auto alakzatot.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Adjon hozzá egy átlátszó téglalap auto alakzatot a tömör alakzat fölött.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását a PowerPoint bemutatókban. Ez hasznos lehet vizuális elemek meghatározott igazítási vagy tervezési igények szerinti elhelyezésénél.

Az alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögértékre.
1. Mentse a bemutatót.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Szerezze meg az első diát.
auto slide = presentation->get_Slide(0);

// Adjon hozzá egy automatikus alakzatot Rectangle típusú.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Forgassa el az alakzatot 5 fokkal.
shape->set_Rotation(5);

// Mentse a PPTX fájlt a lemezre.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D rézsút hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D rézsút hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D rézsút hatások hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályt.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/threedformat/) beállításait a rézsút paraméterek megadásához.
1. Mentse a bemutatót.

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

// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Adjon hozzá egy alakzatot a diára.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Állítsa be az alakzat ThreeDFormat tulajdonságait.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Mentse a bemutatót PPTX fájlként.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A 3D rézsút hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D forgatás alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Használja a [set_CameraType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icamera/set_cameratype/) és a [set_LightType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilightrig/set_lighttype/) metódusokat a 3D forgatás meghatározásához.
1. Mentse a bemutatót.

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

// Hozzon létre egy példányt a Presentation osztályból.
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

Az eredmény:

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés szabályozása az alakzatoknál**

Az [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_blackwhitemode/) metódus meghatározza, hogyan jelenik meg egy adott alakzat, amikor a bemutatót fekete-fehér módban tekintik vagy dolgozzák fel. Ez a metódus önmagában nem kapcsol be fekete-fehér megjelenítést, és nem módosítja az alakzat kitöltését, vonalát vagy egyéb formázását normál színes módban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/blackwhitemode/) felsorolásból a kívánt viselkedés kiválasztásához. Például az `Automatic` lehetővé teszi az alkalmazás számára a konverzió kiválasztását, a `Gray` és a `LightGray` szürke árnyalatot alkalmaz, a `BlackWhite` csak fekete‑fehér színt, a `Black` és a `White` egyetlen színt erőltet, a `Color` megőrzi a normál színezést, a `Hidden` elrejti az alakzatot fekete‑fehér módban, a `NotDefined` pedig azt jelenti, hogy nincs alakzat‑szintű mód beállítva.

Az alábbi C++ kód egy színes alakzatot hoz létre, és fekete‑fehér megjelenítésben szürke színnel jeleníti meg:

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

// Tartsa meg a narancssárga kitöltést színes módban, de a alakzatot szürke színnel jelenítse meg fekete-fehér módban.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Normál színes módban a téglalap narancssárga kitöltésű marad. Fekete‑fehér megjelenítési munkafolyamat során szürke színt kap, mert a módja `Gray`‑re van állítva. Így megőrizheti a teljes színű diát, miközben a nyomtatásra, előnézetre vagy egyéb, a bemutató fekete‑fehér megjelenítési beállításait tiszteletben tartó munkafolyamatokra külön megjelenést definiál.

## **Formázás visszaállítása**

Az alábbi C++ kód megmutatja, hogyan állíthatja vissza egy dia formázását, és hogyan állíthatja vissza az összes alakzat (helyőrzőkkel együtt) pozícióját, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/layoutslide/) alapértelmezett beállításaira:

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
    // Állítsa vissza a dián lévő minden alakzatot, amelynek helyőrzője van az elrendezésben.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**A forma formázása befolyásolja a végső bemutató fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a fájl legtöbb helyét, míg a formák paraméterei – színek, effektusok, színátmenetek – metaadatként tárolódnak, és gyakorlatilag nem növelik jelentősen a méretet.

**Hogyan tudom észlelni a dián lévő alakzatokat, amelyek azonos formázást használnak, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságát – kitöltés, vonal és effektus beállítások. Ha az összes megfelelő érték megegyezik, tekintse őket azonos stílusúnak, és logikailag csoportosítsa az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek saját egyéni alakzatstílusok halmazát egy külön fájlba, hogy más prezentációkban újra felhasználjam őket?**

Igen. Tárolja a kívánt stílusú mintaalakzatokat egy sablon‑diakönyvtárban vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázást ott, ahol szükséges.