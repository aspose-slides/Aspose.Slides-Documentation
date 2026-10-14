---
title: PowerPoint alakzatok formázása C++-ban
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/cpp/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- alakzatvonal vázlat hatás
- csatlakozási stílus formázása
- gradient kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat megjelenítés
- szürkeárnyalatos alakzat megjelenítés
- alakzat forgatása
- 3D rézsút hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan formázhatja a PowerPoint alakzatokat C++-ban az Aspose.Slides használatával—állítson be kitöltési, vonal- és hatásstílusokat PPT, PPTX és ODP fájlokhoz precízen és teljes kontrollal."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Ezen felül beállítások megadásával formázhatja az alakzatok belsejét, hogy milyen módon legyen kitöltve.

![PowerPoint alakzat formázása](format-shape-powerpoint.png)

Az Aspose.Slides for C++ interfészeket és metódusokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazon lehetőségek használatával.

## **Vonalak formázása**

Az Aspose.Slides használatával egy alakzat egyéni vonalstílusát adhatja meg. Az alábbi lépések vázolják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) értékét.
1. Állítsa be a vonal vastagságát.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) értékét.
1. Állítsa be a vonal színét az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy `AutoShape` téglalapot:

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

// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Az első diát lekéri.
auto slide = presentation->get_Slide(0);

// Egy Rectangle típusú automatikus alakzatot ad hozzá.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Beállítja a téglalap alakzat kitöltő színét.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Formázza a téglalap vonalait.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Beállítja a téglalap vonalának színét.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Elmenti a PPTX fájlt a lemezre.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Vázlat hatások alkalmazása alakzatvonalakra**

A vázlat hatás egy alakzatvonalat kézzel rajzoltként jelenít meg. Használja az [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) metódust a vonal beállításainak eléréséhez, az [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) metódust a vázlat beállításainak eléréséhez, és az [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) metódust a [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) felsorolásból való érték kiválasztásához.

Az alábbi C++ kód megmutatja, hogyan alkalmazzon egy [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) hatást, olvassa ki a kifejezetten hozzárendelt értéket, és távolítsa el a hatást a [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) használatával:

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

Az [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) által visszaadott érték közvetlenül az alakzatra beállított konfigurációt képviseli. Ha a vonal formázása öröklődik egy témából, mesterdiából vagy elrendezésdiából, használja az [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) metódust, érje el az [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) értéket, és olvassa ki az [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) értékét. A hatékony érték tükrözi a ténylegesen alkalmazott formázást az öröklődés feloldása után:

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

A három csatlakozási típus opciója:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat egy szögnél (például egy alakzat sarkán) köt össze, a **Round** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Miter** lehetőséget.

![Az illesztési stílus a prezentációban](join-style-powerpoint.png)

Az alábbi C++ kód bemutatja, hogyan hoztunk létre három téglalapot (az előző képen látható módon) a Miter, Bevel és Round csatlakozási beállításokkal:

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

// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Az első diát lekéri.
auto slide = presentation->get_Slide(0);

// Három Rectangle típusú automatikus alakzatot ad hozzá.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Beállítja az egyes téglalap alakzatok kitöltő színét.
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

// Beállítja az egyes téglalapok vonalának színét.
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

// Szöveget ad az egyes téglalapokhoz.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Elmenti a PPTX fájlt a lemezre.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gradient kitöltés**

A PowerPointban a Gradient Fill egy formázási lehetőség, amely lehetővé teszi, hogy egy alakzatot folyamatos színátmenettel töltsön ki. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan átfedje a másikat.

Íme, hogyan alkalmazzon gradient kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) értékét `Gradient`-ra.
1. Adja hozzá a két kedvenc színét a meghatározott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) interfész által biztosított gradient stop gyűjtemény `Add` metódusaival.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C++ kód bemutatja, hogyan alkalmazzon gradient kitöltési hatást egy ellipszisre:

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

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Ellipse típusú automatikus alakzatot ad hozzá.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Gradient formázást alkalmaz az ellipszisre.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Beállítja a gradient irányát.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Két gradient stopot ad hozzá.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Elmenti a PPTX fájlt a lemezre.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az ellipszis gradient kitöltéssel](gradient-fill.png)

Ha a gradient a kiexportált képen másként jelenik meg, mint a PowerPointban, lásd a [Choose a Gradient Rendering Style](/slides/hu/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) oldalt. Kiválaszthat egy megjelenítési stílust anélkül, hogy megváltoztatná a prezentációban tárolt gradient kitöltést.

## **Minta kitöltés**

A PowerPointban a Pattern Fill egy formázási lehetőség, amely lehetővé teszi két színű minta – például pontok, csíkok, keresztvonalkák vagy négyzethálók – alkalmazását egy alakzatra. A minta előtér és háttér színét egyénileg is beállíthatja.

Az Aspose.Slides több mint 45 előre definiált minta stílust kínál, amelyeket alakzatokra alkalmazhat a prezentációk megjelenésének javításához. Még előre definiált minta kiválasztása után is meghatározhatja a pontos színeket, amelyeket a minta használjon.

Íme, hogyan alkalmazzon pattern kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) értékét `Pattern`-re.
1. Válasszon egy minta stílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) értékét.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C++ kód bemutatja, hogyan alkalmazzon pattern kitöltést egy téglalapra:

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

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Rectangle típusú automatikus alakzatot ad hozzá.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Beállítja a kitöltés típusát Pattern-re.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Beállítja a minta stílusát.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Beállítja a minta háttér- és előtérszíneit.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Elmenti a PPTX fájlt a lemezre.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Picture Fill egy formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzat belsejében – lényegében a képet az alakzat háttérként használja.

Íme, hogyan használja az Aspose.Slides‑t képek kitöltésére egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) értékét `Picture`-re.
1. Állítsa be a kép kitöltés módját `Tile`‑ra (vagy egy másik kívánt módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) objektumot a használni kívánt képből.
1. Adja át a képet az `ISlidesPicture.set_Image` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy „lotus.png” fájlunk a következő képpel:

![A lótusz kép](lotus.png)

Az alábbi C++ kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

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

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Rectangle típusú automatikus alakzatot ad hozzá.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Beállítja a kitöltés típusát Picture-re.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Beállítja a kép kitöltés módját.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Betölt egy képet és hozzáadja a prezentáció erőforrásaihoz.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Beállítja a képet.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Elmenti a PPTX fájlt a lemezre.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Csempe kép textúraként**

Ha csempézett képet szeretne textúraként beállítani, és testre szabni a csempe viselkedését, használja a [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) osztály következő metódusait:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): A kép kitöltés módját állítja – `Tile` vagy `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): A csempék alakzaton belüli igazítását adja meg.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): A csempe vízszintes, függőleges vagy mindkét irányú tükrözését szabályozza.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): A csempe vízszintes eltolását (pontban) az alakzat kiindulási pontjától állítja.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): A csempe függőleges eltolását (pontban) az alakzat kiindulási pontjától állítja.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): A csempe vízszintes méretezését százalékban adja meg.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): A csempe függőleges méretezését százalékban adja meg.

Az alábbi kódrészlet megmutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és hogyan konfigurálja a csempe beállításait:

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

// Hozzárendeli a képet az alakzathoz.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Beállítja a kép kitöltés módját és a csempézési tulajdonságokat.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Elmenti a PPTX fájlt a lemezre.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A csempe beállítások](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban a Solid Color Fill egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez a sík háttérszín fokozatok, textúrák vagy minták nélkül kerül alkalmazásra.

A solid színű kitöltés alkalmazásához az Aspose.Slides segítségével kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) értékét `Solid`-ra.
1. Rendelje hozzá a kívánt kitöltő színt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C++ kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra egy PowerPoint dián:

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

// Elmenti a PPTX fájlt a lemezre.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egy alakzatra egyszínű, gradient, kép vagy textúra kitöltést alkalmaz, beállíthat átlátszósági szintet a kitöltés átlátszatlanságának szabályozásához. Magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, lehetővé téve a háttér vagy az alatta lévő elemek részleges láthatóságát.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását az alfa komponens módosításával a kitöltéshez használt színben. Íme, hogyan teheti ezt:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) értékét `Solid`-ra.
1. Használja a `Color` típusú objektumot, hogy átlátszóságot tartalmazó színt definiáljon (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

Az alábbi C++ kód bemutatja, hogyan alkalmazzon átlátszó kitöltő színt egy téglalapra:

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

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy szilárd téglalap automatikus alakzatot.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Hozzáad egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölött.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Elmenti a PPTX fájlt a lemezre.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet vizuális elemek pozicionálásakor, ha meghatározott igazításra vagy dizájnra van szükség.

Alakzat forgatásához a dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

Az alábbi C++ kód bemutatja, hogyan forgassunk egy alakzatot 5 fokkal:

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

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Lekéri az első diát.
auto slide = presentation->get_Slide(0);

// Hozzáad egy Rectangle típusú automatikus alakzatot.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Forgatja az alakzatot 5 fokkal.
shape->set_Rotation(5);

// Elmenti a PPTX fájlt a lemezre.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D rézsút hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D rézsút hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D rézsút hatások hozzáadásához egy alakzatra kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályt.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) tulajdonságait a rézsút beállítások meghatározásához.
1. Mentse a prezentációt.

Az alábbi C++ kód mutatja, hogyan alkalmazzon 3D rézsút hatást egy alakzatra:

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

// A Presentation osztály egy példányát hozza létre.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Alakzatot ad a diához.
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

// A prezentációt PPTX fájlként menti.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A 3D rézsút hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diához.
1. Használja a [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) és a [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) metódusokat a 3D forgatás definiálásához.
1. Mentse a prezentációt.

Az alábbi C++ kód bemutatja, hogyan alkalmazzon 3D forgatási hatást egy alakzatra:

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

// Példányosítja a Presentation osztályt.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// A prezentációt PPTX fájlként menti.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés vezérlése alakzatokhoz**

Az [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) metódus határozza meg, hogyan jelenik meg egy egyedi alakzat, amikor a prezentációt fekete-fehér módban tekintik meg vagy dolgozzák fel. Nem kapcsol be önmagában a fekete-fehér megjelenítést, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színes módban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) felsorolásból a kívánt viselkedés kiválasztásához. Például az `Automatic` lehetővé teszi, hogy a renderelő alkalmazás válassza a konverziót, a `Gray` és a `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak fekete‑fehér színt használ, a `Black` és a `White` egyetlen színt kényszerít, a `Color` megőrzi a normál színezést, a `Hidden` pedig elrejti az alakzatot fekete‑fehér módban. A `NotDefined` azt jelenti, hogy nincs alakzatra vonatkozó mód beállítva.

Az alábbi C++ kód létrehoz egy színes alakzatot, és fekete‑fehér megjelenítésben szürke színnel jeleníti meg:

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

// Tartsa az narancssárga kitöltést színes módban, de a alakzatot szürke színezéssel jelenítse meg fekete-fehér módban.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Normál színes módban a téglalap megőrzi narancssárga kitöltését. Fekete‑fehér megjelenítési munkafolyamatban szürke színt használ, mivel a módja `Gray`‑ra van állítva. Ez lehetővé teszi, hogy egy teljes színű diát megőrizzen, miközben külön megjelenést definiál a nyomtatáshoz, előnézethez vagy más, a prezentáció fekete‑fehér beállításait figyelembe vevő folyamatokhoz.

## **Formázás visszaállítása**

Az alábbi C++ kód megmutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa vissza az összes alakzat pozícióját, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) helyőrzőivel az alapértelmezett beállításokra:

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
    // Állítsa vissza a dián lévő minden alakzatot, amelynek helyőrzője van az elrendezésen.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**Milyen hatással van az alakzat formázása a végső prezentáció fájlméretére?**

Csak minimálisan. A beágyazott képek és médiafájlok teszik ki a fájl legnagyobb részét, míg az alakzatok paraméterei, például a színek, hatások és gradientek metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan tudom felismerni a dián azon alakzatokat, amelyek azonos formázással rendelkeznek, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és hatás beállítások. Ha minden megfelelő érték megegyezik, tekintse őket azonos stílusú alakzatoknak, és logikailag csoportosítsa őket, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek-e egy egyéni alakzatstílus‑készletet külön fájlba a későbbi használatra más prezentációkban?**

Igen. Tárolja a kívánt stílusokkal ellátott mintaalakzatokat egy sablon‑diakészletben vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stilizált alakzatokat, és alkalmazza újra a formázásukat ahol szükséges.