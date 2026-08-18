---
title: Prezentációs Témák Kezelése C++-ban
linktitle: Prezentációs Téma
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
- téma betűkészlet
- téma stílus
- téma effekt
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fő prezentációs témák az Aspose.Slides for C++-ban a PowerPoint fájlok egységes márkaidentitással történő létrehozásához, testreszabásához és konvertálásához."
---
## **Bevezetés**

A prezentációs téma egy összehangolt szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektkészletet definiál. A témára érzékeny objektumok ezekre a közös definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre frissítheti a sok objektumot.

Az Aspose.Slides-ban a prezentáció szintű téma a [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/) segítségével érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma felülírásokat. Egy master felülírhatja a prezentációs témát a [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) segítségével, míg egy elrendezés vagy egy egyedi dia a [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) használatával. Gyakorlatban egy dia hatékony témája ezen öröklődési lánc mentén oldódik fel: prezentációs téma, master felülírás, elrendezés felülírás és dia felülírás.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűkészletek módosítása, téma másolása vagy alkalmazása, háttér- és effektstílusok frissítése, valamint az öröklődés és felülírások feloldása után kapott hatékony értékek olvasása.

## **Téma Ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/) objektum a téma [get_ColorScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) és [get_FormatScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) metódusait teszi elérhetővé. Ezeknek a gyűjteményeknek az ellenőrzése a módosításuk előtt különösen hasznos, ha a prezentáció külső forrásból származik, mert a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hogy hány háttér-, kitöltés-, vonal- és effektstílus van tárolva a témában:

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

Ha egy fájl több masterrel dolgozik, ne feltételezze, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizze a diához tartozó mastert, és használja a később ebben a cikkben bemutatott hatékony-téma munkafolyamatot, ha elrendezés- vagy diafelülírások is előfordulhatnak.

## **Téma Színeinek Módosítása**

A témára érzékeny kitöltések, vonalak és szövegek logikai színekre hivatkozhatnak a [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) felsoroltámból. Amikor a téma [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/) megfelelő bejegyzését módosítja, minden objektum, amely még mindig arra a téma színre hivatkozik, az új érték szerint kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB-színt használnak, nem változnak a téma‑szín frissítésekor.

Az alábbi végponttól végpontig tartó példa egy olyan alakzatot hoz létre, amely az `Accent4` színt használja, megváltoztatja a téma `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is az `Accent4`-hez van linkelve, a látható színe pirosra változik a téma módosítása után. Ha a téma színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **Használjon Színeket a Kiegészítő Palettáról**

A PowerPoint könnyebb és sötétebb variánsokat származtat a téma színéből színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/colortransformoperation/) segítségével teszi elérhetővé.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Fő téma színek.

**2** – A fő téma színekből származtatott könnyebb és sötétebb variánsok.

Az alábbi példa hat téglalapot hoz létre az `Accent4` alapján, ötötön luminancia‑transzformációt alkalmaz, és elmenti az eredményt:

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

Ezek a variánsok továbbra is a téma szín alapján vannak. Ha később az `Accent4` megváltozik, a transzformált színek újra lesznek számítva az új `Accent4` értékből.

### **Térképezze a `SchemeColor` Értékeket az `IColorScheme` Helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) felsoroltáma a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/) ugyanazon témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan konvertált értékek.

## **Téma Betűkészletek Módosítása**

A téma betűkészlete egy fő betűkészletet tartalmaz a címsorokhoz és egy másodlagos betűkészletet a törzsszöveghez. A [FontScheme::get_Major()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_major/) és a [FontScheme::get_Minor()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_minor/) metódusok teszik elérhetővé ezeket a készleteket.

PowerPoint‑kompatibilis téma‑betűazonosítókat használhat a szövegformázásnál:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő latin téma‑betűt használja, valamint egy törzssort, amely a másodlagos latin téma‑betűt használja. Ezután megváltoztatja a téma betűkészleteit és elmenti az eredményt:

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

A címsor a fő betűt, a törzsszöveg a másodlagos betűt követi. Azok a szövegek, amelyek kifejezett betűnevet tartalmaznak a témaazonosító helyett, nem váltanak automatikusan, amikor a téma‑betűkészlet megváltozik.

{{% alert color="info" title="Tip" %}}
További információkért a prezentáció betűiről, lásd a [PowerPoint Fonts](/slides/hu/cpp/powerpoint-fonts/) oldalt.
{{% /alert %}}

## **Téma Másolása vagy Alkalmazása**

Két gyakori munkafolyamat létezik, amelyek különböző problémákat oldanak meg.

### **Forrás Téma Megőrzése Diák Áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti megjelenését, klónozza a forrás mastert a célprezentációba a [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/) segítségével, majd a diát a [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) és a klónozott master segítségével klónozza. Ez a mastert, az elrendezéseket és a kapcsolódó témát együtt szállítja.

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

Ez a leginkább ajánlott munkafolyamat, ha a forrás dia ugyanúgy kell, hogy kinézzen a célban. Az egyszerű klónozás egy nem kapcsolódó cél‑masterre megváltoztathatja a téma‑alapú színeket, betűket, háttereket és effektusokat.

### **Témaértékek Alkalmazása Létező Diára**

Ha a cél‑dia a jelenlegi masterén és elrendezésén kell maradjon, inicializáljon egy dia‑szintű felülírást a forrás témából. A [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) és [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok lemásolják a három fő témaelemet a felülírásba.

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

Ez megváltoztatja a dia által használt témát anélkül, hogy a többi dia örökölt témáját befolyásolná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg a [OverrideTheme::Clear()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma Felülírás Alkalmazása Elrendezésre**

Az elrendezés‑szintű felülírás az az elrendezést használó diákra vonatkozik, hacsak egy adott dia nem rendelkezik saját felülírással. Ugyanezeket az inicializáló metódusokat használhatja az elrendezés [IOverrideThemeManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/) segítségével:

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

Használjon master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alaptervezésre van szüksége; elrendezés‑felülírást, ha egy elrendezéscsaládnak eltérő stílusra van szüksége; és dia‑felülírást csak valós kivételek esetén. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változások előrejelzését.

## **Téma Háttérstílusok Frissítése**

A téma háttérkitöltései a [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) metódusban tárolódnak. A PowerPoint több háttérválasztást jeleníthet meg a felhasználói felületen, mint amennyi kitöltés‑definíció fizikailag tárolódik ebben a gyűjteményben, mert a felület kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílusreferenciákkal.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Mielőtt háttérstílust használna, ellenőrizze a tárolt gyűjteményt és a jelenlegi [Background::get_StyleIndex()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/get_styleindex/)-t. A `StyleIndex` a `0`‑t használja, ha nincs témás kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér attól, amikor egy C++ gyűjteményt közvetlenül indexelünk `idx_get(0)`‑val, ahol a `0` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttérkitöltési stílussal rendelkezik.

Az alábbi példa jelentést készít a rendelkezésre álló háttérkitöltések számáról, egy témás háttérreferenciát rendel az első masterhez, és elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a master háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/) metódust, ha a végső, öröklődés után alkalmazott háttérre van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a `StyleIndex`‑et nullára alapozott gyűjtemény‑indexnek. Emellett kerüld a stílus‑számok hard‑kódolását egy fájlból, és annak feltételezését, hogy ugyanúgy jelenik meg egy másik fájlban; a téma‑stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázásért és a háttér‑öröklődésért lásd a [Presentation Background](/slides/hu/cpp/presentation-background/) oldalt.
{{% /alert %}}

## **Téma Effektusok Frissítése**

A téma formátumsémája különálló [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_linestyles/) és [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy állandó számra építene.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C++‑ban ezeknek a gyűjteményeknek az indexelése nullára alapozott: `idx_get(0)` az első tárolt stílus, `idx_get(2)` a harmadik. Egy alakzat stílus‑referencia‑indexei külön koncepciót képeznek, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapestyle/) szolgáltat. Egy téma‑stílus módosítása olyan alakzatokat érint, amelyek hivatkoznak arra a téma‑stílusra; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, megváltoztatja az első vonalstílust, a harmadik kitöltőstílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, majd elmenti az eredményt:

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

Azoknál az alakzatoknál, amelyek ezekre a helyekre hivatkoznak, az első téma‑vonalstílus pirosra, a harmadik téma‑kitöltőstílus szilárd erdei zöldre, a harmadik effektus‑stílus pedig külső árnyékra változik, távolsága 10 pont. A pontos vizuális eredmény továbbra is attól függ, melyik stílus‑helyet hivatkozza az adott alakzat, és hogy a közvetlen formázás felülírja‑e a témát.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Hatékony Témaértékek Olvasása**

A nyers témaobjektumok megmutatják, hogy mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Diára a [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) metódust hívja. Háttérhez használja a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/)-t, kitöltéshez pedig a [FillFormat::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/geteffective/)-t.

Az alábbi példa beolvassa a hatékony témát, a háttért és az első alakzat kitöltését egy diáról:

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

Használja a hatékony adatokat diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/) objektumot ellenőrzi, lemaradhat egy master, elrendezés, dia vagy alakzat felülírásáról, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok-e témát egyetlen diára anélkül, hogy a mastert megváltoztatnám?**

Igen. Használja a dia [IOverrideThemeManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/)‑ét, és inicializálja a felülírási témát. A módosítás csak arra a diára marad helyi; a többi dia a meglévő témákat örökli.

**Mi a legbiztonságosabb módja a téma egyik prezentációból a másikba való átvitelének?**

Amikor egy diát áthelyez és meg akarja őrizni az eredeti megjelenését, klónozza a forrás mastert a célba, majd a diát a klónozott masterrel a [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/) és a [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) segítségével. Ez a mastert, az elrendezéseket és a témát együtt tartja.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használja a [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) metódust egy dia vagy elrendezés témájához, valamint a megfelelő hatékony‑adat metódusokat formátumobjektumok, például a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/) és a [FillFormat::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/geteffective/) esetén. Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülírások alkalmazása után.