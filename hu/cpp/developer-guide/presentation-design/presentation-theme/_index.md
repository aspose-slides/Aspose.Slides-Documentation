---
title: "Prezentációs témák kezelése C++-ban"
linktitle: "Prezentációs téma"
type: docs
weight: 10
url: /hu/cpp/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- téma szín
- kiegészítő paletta
- téma betűtípus
- téma stílus
- téma effektus
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ segítségével mesterprezentációs témák kezelése, testreszabása és PowerPoint fájlok konvertálása konzisztens márkázással."
---
## **Bevezetés**

A prezentációs téma meghatározza a tervezési elemek tulajdonságait. Amikor kiválaszt egy prezentációs témát, tulajdonképpen egy adott vizuális elemek és azok tulajdonságainak halmazát választja ki.

A PowerPointban egy téma színeket, [betűtípusok](/slides/hu/cpp/powerpoint-fonts/), [háttérstílusok](/slides/hu/cpp/presentation-background/), és effektusokat tartalmaz.

![theme-constituents](theme-constituents.png)

## **Téma színének módosítása**

A PowerPoint téma egy meghatározott színkészletet használ a dia különböző elemeihez. Ha nem tetszenek a színek, azokat a téma új színek alkalmazásával változtathatja meg. Az új témaszín kiválasztásához az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) felsorolásban értékeket biztosít.

Ez a C++ kód megmutatja, hogyan változtatható meg a kiemelés színe a témában:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

A végső szín hatékony értékét így határozhatja meg:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Szín [A=255, R=128, G=100, B=162])
```

A színváltoztatási művelet további bemutatásához létrehozunk egy másik elemet, és ráadjuk a kiinduló műveletből származó kiemelés színét. Ezután megváltoztatjuk a színt a témában:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Az új szín automatikusan alkalmazásra kerül mindkét elemen.

### **Téma színének beállítása kiegészítő palettáról**

Amikor a fő téma színére (1) luminancia‑transzformációkat alkalmaz, a kiegészítő palettáról (2) színek jönnek létre. Ezeket a témaszínek ezután beállíthatók és lekérhetők.  

![additional-palette-colors](additional-palette-colors.png)

**1**- Fő téma színek  

**2**- Színek a kiegészítő palettáról.  

Ez a C++ kód bemutatja, hogyan nyerhetők ki a kiegészítő paletta színei a fő téma színéből, majd használhatók alakzatokban:

```c++
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Kiemelés 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Kiemelés 4, világosabb 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Kiemelés 4, világosabb 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Kiemelés 4, világosabb 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Kiemelés 4, sötétebb 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Kiemelés 4, sötétebb 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor` leképezése az `IColorScheme` színekre**

Amikor a [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.schemecolor/) használatával dolgozik, észreveheti, hogy a következő témaszín‑értékeket tartalmazza: `Background1`, `Background2`, `Text1`, és `Text2`.

Azonban a `Presentation::get_MasterTheme()::get_ColorScheme()` a [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/)‑t adja vissza, amely a megfelelő színeket a következőképpen exponálja: `Dark1`, `Dark2`, `Light1`, és `Light2`.

Ez a különbség csak a névhasználatban van. Ezek az értékek ugyanazokra a téma‑színhelyekre mutatnak, és a leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus átalakítás a `Text`/`Background` és a `Dark`/`Light` között. Ezek egyszerűen alternatív nevek ugyanarra a témaszínre.

Ez a néveltérés a Microsoft Office terminológiájából ered. A régebbi Office‑verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` elnevezéseket használták, míg az újabb felhasználói felületek ugyanazokat a helyeket a `Text 1`, `Background 1`, `Text 2` és `Background 2` néven jelenítik meg.

## **Téma betűtípusának módosítása**

A témák és egyéb célok számára a betűtípusok kiválasztásához az Aspose.Slides ezeket a speciális azonosítókat használja (hasonlóan a PowerPointban használtakhoz):

* **+mn-lt** – Testbetűtípus Latin (Kisebb Latin betűtípus)
* **+mj-lt** – Fejléc betűtípusa Latin (Nagy Latin betűtípus)
* **+mn-ea** – Testbetűtípus Kelet‑Ázsiai (Kisebb Kelet‑Ázsiai betűtípus)
* **+mj-ea** – Testbetűtípus Kelet‑Ázsiai (Nagy Kelet‑Ázsiai betűtípus)

Ez a C++ kód megmutatja, hogyan rendelhető a Latin betűtípus egy témaelemhez:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Ez a C++ kód megmutatja, hogyan változtatható meg a prezentáció téma betűtípusa:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

A betűtípus minden szövegdobozban frissülni fog.

{{% alert color="info" title="TIP" %}} 
Érdemes megnézni a [PowerPoint betűtípusokat](/slides/hu/cpp/powerpoint-fonts/). 
{{% /alert %}}

## **Téma háttérstílusának módosítása**

Alapértelmezés szerint a PowerPoint alkalmazás 12 előre definiált hátteret biztosít, de ezek közül csak 3 kerül mentésre egy tipikus prezentációban.  

![todo:image_alt_text](presentation-design_8.png)

Például, ha a PowerPoint alkalmazásban elment egy prezentációt, futtathatja ezt a C++ kódot, hogy megtudja, hány előre definiált háttér található a prezentációban:

```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
A [BackgroundFillStyles](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) tulajdonságot a [FormatScheme](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme/) osztályból használva hozzáadhat vagy elérhet háttérstílusokat egy PowerPoint témában. 
{{% /alert %}}

Ez a C++ kód megmutatja, hogyan állítható be a háttér egy prezentációhoz:

```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Index útmutató**: 0 a kitöltés nélküli állapotot jelenti. Az index 1‑től kezdődik.

{{% alert color="info" title="TIP" %}} 
Érdemes megnézni a [PowerPoint háttér](/slides/hu/cpp/presentation-background/). 
{{% /alert %}}

## **Téma effektusának módosítása**

Egy PowerPoint téma általában 3 értéket tartalmaz minden stílustömbhöz. Ezeket a tömböket a három hatás – finom, közepes és intenzív – kombinálja. Például ez a kimenet, amikor a hatásokat egy konkrét alakzatra alkalmazzák:

![todo:image_alt_text](presentation-design_10.png)

A [FillStyles](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58) tulajdonságok segítségével a [FormatScheme](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme/) osztályból a téma elemeit (akár rugalmasabban is, mint a PowerPoint lehetőségei) módosíthatja.  

Ez a C++ kód megmutatja, hogyan változtatható meg egy témaeffektus az elemek részeinek módosításával:

```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Az eredményül kapott változások a kitöltőszínben, a kitöltéstípusban, az árnyék‑effektusban stb.:

![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

### Alkalmazhatok egy témát egyetlen diára a master módosítása nélkül?

Igen. Az Aspose.Slides támogatja a dia‑szintű téma‑felülírásokat, így egy helyi témát alkalmazhat kifejezetten arra a diára, miközben a master téma érintetlen marad (a [SlideThemeManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/slidethememanager/) segítségével).

### Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?

A [Clone slides](/slides/hu/cpp/clone-slides/) használata a masterrel együtt a célprezentációba. Ez megőrzi az eredeti master‑t, az elrendezéseket és a kapcsolódó témát, így a megjelenés konzisztens marad.

### Hogyan tekinthetem meg a „hatékony” értékeket az összes öröklődés és felülírás után?

Használja az API „effective” nézeteit a téma/szín/betűtípus/effektus számára (/slides/hu/cpp/shape-effective-properties/). Ezek az összes master és esetleges helyi felülírás után feloldott, végső tulajdonságokat adják vissza.