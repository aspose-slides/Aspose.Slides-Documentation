---
title: Prezentációs témák kezelése C++-ban
linktitle: Prezentációs téma
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
description: "Mester prezentációs témák az Aspose.Slides for C++-ban a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához egységes márkajelzéssel."
---
## **Bevezetés**

A prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témaérzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre több objektumot is frissíthet.

Az Aspose.Slides esetében a prezentáció szintű témát a [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/) biztosítja. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy mester a [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) segítségével felülírhatja a prezentáció témáját, míg egy elrendezés vagy egy adott dia a [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) használatával. Gyakorlatban a dia tényleges témája ezen öröklődési lánc alapján kerül feloldásra: prezentáció témája, mester felülírás, elrendezés felülírás és dia felülírás.

![Téma összetevők: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma megtekintése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint a hatékony értékek olvasása az öröklődés és felülírások feloldása után.

## **Téma megtekintése**

A [MasterTheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/) objektum a téma [get_ColorScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) és [get_FormatScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) metódusait teszi elérhetővé. Ezeknek a gyűjteményeknek a megtekintése a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma‑tulajdonságokat, és jelentést készít arról, hogy hány háttér-, kitöltés-, vonal- és effektus‑stílus van tárolva a témában:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Ha egy fájl több mestert használ, ne feltételezze, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Tekintse meg a diával kapcsolatos mestert, és használja a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A téma‑érzékeny kitöltések, vonalak és szövegek logikai színekre hivatkozhatnak a [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) felsorolásból. Amikor a téma [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/) megfelelő bejegyzését módosítja, minden, még mindig az adott téma‑színre hivatkozó objektum az új értékkel kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak a téma‑szín frissítésekor.

Az alábbi végponttól‑végpontig tartó példa létrehoz egy alakzatot, amely az `Accent4` színt használja, megváltoztatja a téma `Accent4` színét pirosra, menti a prezentációt, újból megnyitja, és kiírja a hatékony kitöltési színt:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Mivel a téglalap továbbra is az `Accent4`-hez van kapcsolva, látható színe piros lesz a téma módosítása után. Ha a séma‑színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4`‑változások már nem befolyásolják azt a kitöltést.

### **A kiegészítő palettáról származó színek használata**

A PowerPoint a téma‑színből világosabb és sötétebb változatokat színátalakítások alkalmazásával állít elő. Az Aspose.Slides ezeket az átalakításokat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/colortransformoperation/) segítségével teszi elérhetővé.

![A fő téma színei és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színei.

**2** – A fő téma színeiből előállított világosabb és sötétebb variánsok.

Az alábbi példa hat téglalapot hoz létre az `Accent4` alapján, ötökre luminancia‑átalakítást alkalmaz, és elmenti az eredményt:

```cpp
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
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Ezek a variánsok továbbra is a téma‑színen alapulnak. Ha később az `Accent4` megváltozik, a transzformált színek újra lesznek számítva az új `Accent4` értékből.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/) a ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven exponálja. A leképezés fix:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazoknak a témahelyeknek alternatív nevei; nem olyan értékek, amelyeket dinamikusan konvertálnának egyik formából a másikba.

## **Téma betűtípusainak módosítása**

Egy téma‑betűtípus‑séma fő (major) betűkészletet tartalmaz a címsorokhoz és kisebb (minor) betűkészletet a törzsszöveghez. A [FontScheme::get_Major()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_major/) és a [FontScheme::get_Minor()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_minor/) metódusok ezeket a készleteket teszik elérhetővé.

A PowerPoint‑kompatibilis téma‑betűtípus‑azonosítók a szövegformázásban használhatók:

* `+mn-lt` – Testbetű Latin (Minor Latin Font)
* `+mj-lt` – Címsorbetű Latin (Major Latin Font)
* `+mn-ea` – Testbetű Kelet-Ázsiai (Minor East Asian Font)
* `+mj-ea` – Címsorbetű Kelet-Ázsiai (Major East Asian Font)

Az alábbi példa létrehoz egy címsort, amely a fő Latin téma‑betűtípust használja, és egy törzssort, amely a kisebb Latin téma‑betűtípust használja. Ezután megváltoztatja a téma betűtípusait és elmenti az eredményt:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

A címsor a fő betűtípust, a törzsszöveg a kisebb betűtípust követi. Az a szöveg, amelynek explicit betűtípus‑neve van egy téma‑azonosító helyett, nem vált automatikusan, ha a téma betűtípus‑sémája megváltozik.

A fő és kisebb betűtárak tartalmazhatnak betűtípus‑leképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. A leképezések megtekintéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script-Specific Theme Fonts](/slides/hu/cpp/script-specific-font-mappings/) oldalat.

{{% alert color="info" title="Tip" %}}
További információkért a prezentációs betűtípusokról lásd a [PowerPoint Fonts](/slides/hu/cpp/powerpoint-fonts/) oldalt.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, és különböző problémákat oldanak meg.

### **Forrástéma megőrzése a diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti megjelenését, klónozza a forrás‑mestert a cél‑prezentációba a [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/) segítségével, majd klónozza a diát a [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) és a klónozott mesterrel. Ez együtt szállítja a mestert, az elrendezéseket és a kapcsolódó témát.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Ez a preferált munkafolyamat, ha a forrás‑díát ugyanúgy kell megjeleníteni a célhelyen. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑mesterre megváltoztathatja a téma‑vezérelt színeket, betűtípusokat, háttér‑ és effektus‑beállításokat.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél‑díát a jelenlegi mesterén és elrendezésén kell hagyni, inicializáljon egy dia‑szintű felülírást a forrástémából. A [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) és [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok átmásolják a három fő téma‑komponenst a felülírásba.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Ez a dia által használt témát módosítja, anélkül hogy a többi dia örökölt témáját megváltoztatná. A helyi felülírás eltávolításához, és az örökölt értékek visszaállításához hívja meg a [OverrideTheme::Clear()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma felülírás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás az arra épülő diákra hat, hacsak egy adott dia saját felülírást nem tartalmaz. Ugyanezeket az inicializáló metódusokat a layout [IOverrideThemeManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/) segítségével is használhatja:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Használjon mester‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak ugyanazt az alaptervet kell megosztania, egy elrendezés‑felülírást, ha egy elrendezéscsaládnak más stílusra van szüksége, és csak dia‑felülírást valósítsen meg valós kivételek esetén. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttérstílusainak frissítése**

A téma háttér‑kitöltései a [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) metódusban tárolódnak. A PowerPoint a felhasználói felületen több háttérválasztási lehetőséget mutathat meg, mint a gyűjteményben fizikailag tárolt kitöltések száma, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és más stílus‑referenciákkal.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust használna, tekintse meg a tárolt gyűjteményt és az aktuális [Background::get_StyleIndex()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/get_styleindex/) értéket. A `StyleIndex` a `0`‑t használja „nincs téma‑kitöltés” esetén; a pozitív értékek téma‑háttér‑stílusra mutatnak. Ez eltér a C++ gyűjtemény közvetlen indexelésétől, ahol az `idx_get(0)` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttér‑kitöltési stílussal rendelkezik.

Az alábbi példa jelentést készít a rendelkezésre álló háttér‑kitöltések számáról, a tematikus háttérreferenciát az első mesterhez rendeli, és elmenti a prezentációt:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a mester háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/) metódust, ha a végleges háttérre van szüksége az öröklődés alkalmazása után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a `StyleIndex`‑et nulla‑bázisú gyűjtemény‑indexként. Kerülje a stílusszám egy fájlból való hard‑kódolását és feltételezést, hogy ugyanúgy jelenik meg egy másik fájlban; a téma‑stílusdefiníciók prezentáció‑specifikusak.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázáshoz és a háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/cpp/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusainak frissítése**

A téma formátumsémája különálló [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_linestyles/) és [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy rögzített számra támaszkodna.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzatra alkalmazva](presentation-design_10.png)

C++‑ban ezekhez a gyűjteményekhez való hozzáféréskor a gyűjtemény indexe nulla‑bázisú: az `idx_get(0)` az első tárolt stílus, az `idx_get(2)` a harmadik. Az alakzat‑stílus‑referencia indexek egy külön fogalom, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, és elmenti az eredményt:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
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
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Azoknál az alakzatoknál, amelyek ezekre a helyekre hivatkoznak, az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus szilárd erdőzöldre, a harmadik effektus‑stílus pedig 10 pont távolságú külső árnyékra változik. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus‑helyre hivatkozik az egyes alakzat, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok a vonal‑, kitöltés‑ és árnyék‑beállítások módosítása után](presentation-design_11.png)

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok megmutatják, mi van definiálva egy adott szinten. A hatékony értékek megmutatják, mit használ egy dia vagy alakzat az öröklődés és a helyi felülírások feloldása után. Diára vonatkozóan hívja meg a [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) metódust. Háttérhez használja a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/)‑t, kitöltéshez pedig a [FillFormat::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/geteffective/)‑t.

Az alábbi példa beolvassa a hatékony témát, a hátteret és az első alakzat kitöltését egy diáról:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Használja a hatékony adatokat renderelési diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/)‑t tekinti meg, lemaradhat egy mester, elrendezés, dia vagy alakzat felülírásáról, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok témát egyetlen diára a mester megváltoztatása nélkül?**

Igen. Használja a dia [IOverrideThemeManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/)‑ét, és inicializálja annak felülírási témáját. A módosítás lokálisan marad azon a dián; a többi dia továbbra is a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációról a másikra?**

Amikor egy diát mozgat és meg akarja őrizni a forrás megjelenését, klónozza a forrás‑mestert a célba, majd a diát klónozza azzal a mesterrel a [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/) és a [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) segítségével. Ez együtt tartja a mestert, az elrendezéseket és a témát.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használja az [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)‑t egy dia vagy elrendezés témájához, és a megfelelő hatékony‑adat‑metódusokat a formátumobjektumokhoz, például a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/)‑t és a [FillFormat::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/geteffective/)‑t. Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülírások alkalmazása után.