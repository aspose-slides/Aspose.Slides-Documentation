---
title: Prezentációs témák kezelése C++‑ban
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
- külső téma
- THMX
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
description: "A Aspose.Slides for C++ fő prezentációs témái PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához következetes márkázással."
---
## **Bevezetés**

A prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet definiál. A témával kompatibilis objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy témafuttatással egyszerre sok objektum frissíthető.

Aspose.Slides‑ban a prezentáció‑szintű téma a [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/) metódussal érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy master a [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) metódussal felülírhatja a prezentáció témáját, míg egy elrendezés vagy egy adott dia a [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) metódust használhatja. Gyakorlatban egy dia hatékony témája ezen öröklődési lánc mentén kerül feloldásra: prezentációs téma, master‑felülírás, elrendezés‑felülírás és dia‑felülírás.

![Téma összetevői: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma megtekintése, színek és betűk cseréje, téma másolása vagy alkalmazása, háttér‑ és effektustílusok frissítése, valamint hatékony értékek kiolvasása az öröklődés és felülírások feloldása után.

## **Téma megtekintése**

A [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) objektum elérhetővé teszi a téma [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) és [get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) metódusait. Ezeknek a gyűjteményeknek a megtekintése a módosításuk előtt különösen hasznos, ha a prezentáció egy külső forrásból származik, mert a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa a fő téma‑tulajdonságokat olvassa be, és jelentést készít arról, hogy hány háttér‑, kitöltés‑, vonal‑ és effektus‑stílus van tárolva a témában:

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

Ha egy fájl több master‑t használ, ne feltételezzük, hogy minden dia ugyanazzal a hatékony temával rendelkezik. Ellenőrizzük a diához tartozó master‑t, és használjuk a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, ha elrendezési vagy dia‑felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témával kompatibilis kitöltések, vonalak és szöveg hivatkozhat egy logikai színre a [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) felsorolásból. Amikor a téma [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) megfelelő bejegyzését megváltoztatjuk, minden objektum, amely még mindig arra a téma‑színre hivatkozik, az új értékkel kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg egy téma‑szín frissítésekor.

Az alábbi teljes példakód létrehoz egy alakzatot, amely a `Accent4` színt használja, megváltoztatja a téma `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4`‑hez van kapcsolva, a látható színe a téma módosítása után piros lesz. Ha a séma‑színt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4` változások már nem érintik azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint világosabb és sötétebb változatokat állít elő egy téma‑színből színátalakítások alkalmazásával. Az Aspose.Slides ezeket az átalakításokat a [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/) segítségével teszi elérhetővé.

![A fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** - Fő téma színek.  
**2** - A fő téma színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre a `Accent4` alapján, ötödikre luminancia‑átalakítást alkalmaz, és elmenti az eredményt:

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

Ezek a változatok továbbra is a téma‑színen alapulnak. Ha a `Accent4` később változik, az átalakított színek az új `Accent4` értékből kerülnek újraszámításra.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) ugyanazokat a téma‑helyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés állandó:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon téma‑helyek alternatív nevei; nem dinamikusan átalakított értékek.

## **Téma betűtípusainak módosítása**

A téma‑betűkészlet egy fő betűtípus‑készletet tartalmaz a címsorokhoz és egy kisebb betűtípus‑készletet a törzsszöveghez. A [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) és a [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) metódusok teszik ezeket a készleteket elérhetővé.

PowerPoint‑kompatibilis téma‑betűazonosítók használhatók szövegformázásnál:

* `+mn-lt` - Törzsszöveg Latin (Minor Latin Font)
* `+mj-lt` - Címsor Latin (Major Latin Font)
* `+mn-ea` - Törzsszöveg Kelet‑ázsiai (Minor East Asian Font)
* `+mj-ea` - Címsor Kelet‑ázsiai (Major East Asian Font)
* `+mn-cs` - Törzsszöveg Komplex írásrendszer (Minor Complex Script Font)
* `+mj-cs` - Címsor Komplex írásrendszer (Major Complex Script Font)

Az alábbi példa létrehoz egy címsort, amely a fő latin téma‑betűtípust használ, és egy törzssorát, amely a kisebb latin téma‑betűtípust használja. Ezután megváltoztatja a téma betűtípusait, és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg pedig a kisebb betűtípust követi. Azok a szövegek, amelyek kifejezett betűnevet tartalmaznak a téma‑azonosító helyett, nem váltanak automatikusan, amikor a téma‑betűkészlet megváltozik.

A fő és a kisebb betűkészlet tartalmazhat betűtérképeket is egyedi írásrendszerekhez, például cirill, arab, japán, georgiai és thaana. Ezeknek a térképeknek a megtekintéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/cpp/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentációs betűkészletekről: lásd a [PowerPoint Fonts](/slides/hu/cpp/powerpoint-fonts/) oldalt.
{{% /alert %}}

### **Téma betűtípus hivatkozások feloldása**

Szöveget ellenőrzve a [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) tartalmazhat téma‑hivatkozást, például `+mn-lt`, a betűtípusnév helyett. A hivatkozás feloldásához hívd a [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/)‑t a megfelelő [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) objektummal. A `+mj` és `+mn` előtagok a fő és a kisebb betűkészleteket választják; a `-lt`, `-ea` és `-cs` utótagok a latin, kelet‑ázsiai és komplex írásrendszer betűket jelölik.

A hatékony témát a [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) metódussal szerezheted meg azon objektumon, amelyre a téma alkalmazva van a vizsgált szövegre. Egy normál dián a `slide->CreateThemeEffective()` használatával a kontextus tartalmazza az adott dia örökölt témáját és a helyi felülírásokat. Elrendezés vagy master ellenőrzésekor a saját hatékony témáját kell használni. Ne feltételezd, hogy az első master témája minden diára érvényes.

Az alábbi példa olyan szövegrészt hoz létre, amely kifejezetten a kisebb latin betűtípust hivatkozza. A slide‑betűkészletet a [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/)‑vel inicializálja, és a fő és a kisebb latin családokat `Arial`‑ra és `Calibri`‑ra állítja, így a példát bemeneti fájl nélkül is reprodukálhatóvá teszi.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto theme = slide->get_ThemeManager()->get_OverrideTheme();
theme->InitFontSchemeFromInherited();
theme->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Arial"));
theme->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Calibri"));

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 60.0f);
shape->get_TextFrame()->set_Text(u"Text using the minor theme font");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

auto font = portion->get_PortionFormat()->get_LatinFont();
auto effectiveTheme = slide->CreateThemeEffective();
auto resolvedFontName = font->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", font->get_FontName(), resolvedFontName);

auto explicitFont = MakeObject<FontData>(u"Verdana");
auto explicitFontName = explicitFont->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", explicitFont->get_FontName(), explicitFontName);
```

A kimenet `+mn-lt -> Calibri`, majd `Verdana -> Verdana`. A tárolt hivatkozás változatlan marad, míg a kifejezett családnevet változatlanul visszaadja. Ha a rész `+mj-lt`‑t használna, ebben a témában `Arial`‑ra oldódna fel.

A téma‑hivatkozás feloldása megmutatja a téma által megadott betűcsaládot. Nem ellenőrzi a betűk elérhetőségét vagy a renderelés során végbemenő betűcsere‑ vagy glif‑fallback folyamatot. Lásd a [Font Selection Sequence](/slides/hu/cpp/font-selection-sequence/) és a [Font Substitution](/slides/hu/cpp/font-substitution/) oldalakat a különálló lépésekhez.

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑problémákat oldanak meg.

### **Külső téma alkalmazása egy masterhez tartozó diákra**

Használd az [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) metódust, ha egy PowerPoint‑témafájl (`.thmx`) áll rendelkezésre, és minden, egy adott masterhez tartozó diát új stílusra akarsz állítani. Válaszd ki a master‑t a [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) gyűjteményből, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/)‑t valósítja meg, és add át a témafájlnak az útvonalát a metódusnak.

A metódus a következő lépéseket hajtja végre:

1. Létrehoz egy új master‑diát a kiválasztott master alapján.  
1. Alkalmazza a külső témát az új masterre.  
1. Az új masterhez rendeli az összes korábban a kiválasztott masterhez tartozó diát.  
1. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/) objektumot.

Az alábbi példa egy külső témát alkalmaz a első masterhez tartozó diákra, és elmenti a prezentációt:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);

auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");
Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());

presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Érvénytelen, sérült vagy nem támogatott téma [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) vagy annak formátum‑specifikus leszármazottját válthatja ki. Érvényesítsd a felhasználók által megadott útvonalakat, kezeld a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentsd a prezentációt.

Csak a kiválasztott masterhez tartozó diák kerülnek átrendelésre. Más masterhez tartozó diák megőrzik meglévő master‑ és témaismeretüket. A téma‑érzékeny színek, betűk, kitöltések, vonalak, háttér‑ és effektus‑stílusok az új külső témához igazodnak. A közvetlenül hozzárendelt színek, betűk, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és dia‑szintű felülírások szintén felülbírálhatják az új master‑től örökölt értékeket.

A téma olyan betűket is hivatkozhat, amelyek nincsenek elérhetőek a futtatási környezetben. A következetes renderelés és export érdekében telepítsd a szükséges betűkészleteket, biztosítsd őket [egyéni betűforrások](/slides/hu/cpp/custom-font/)–on keresztül, vagy konfiguráld a [font substitution](/slides/hu/cpp/font-substitution/) beállítást.

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját fogadja, és nem igényel manuális slide‑ vagy layout‑szintű téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása több‑masteres prezentációban**

Ha a releváns master előre nem ismert, szerezd be egy reprezentatív dia segítségével az [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) és a [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/) metódusokkal. Tárold az eredeti master‑referenciákat, mielőtt bármilyen témát alkalmaznál, mivel minden hívás egy új master‑t hoz létre a prezentációban.

Az alábbi példa két szekció diáit használja a master‑ek meghatározásához, és minden csoporthoz különböző külső témát alkalmaz:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());

        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

Az első hívás csak a `firstGroupMaster`‑hez tartozó diákra hat, a második pedig csak a `secondGroupMaster`‑hez tartozó diákra. Bármely más masterhez tartozó diák nem kap új stílust.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretnél áthelyezni, és meg akarod őrizni az eredeti megjelenését, klónozd a forrás‑master‑t a cél‑prezentációba a [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) metódussal, majd a diát a [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) és a klónozott master‑rel. Ez a master‑t, annak elrendezéseit és a hozzákapcsolt témát együtt szállítja.

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

Ez a preferált munkafolyamat, amikor a forrás‑diának ugyanolyannak kell lennie a cél‑prezentációban. Ha egyszerűen csak a tartalmat klónozod egy nem kapcsolódó cél‑master‑re, a téma‑vezérelt színek, betűk, háttér‑ és effektus‑stílusok megváltozhatnak.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél‑diának a jelenlegi master‑en és elrendezésen kell maradnia, inicializálj egy dia‑szintű felülírást a forrástémából. A [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), a [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) és a [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok a három fő téma‑komponenst másolják a felülírásba.

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

Ez a dia által használt témát módosítja anélkül, hogy más diák örökölt témáját befolyásolná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívd a [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma felülírás alkalmazása elrendezéshez**

Az elrendezés‑szintű felülírás minden olyan diához tartozik, amely az adott elrendezést használja, kivéve ha egy konkrét dia saját felülírást tartalmaz. Az ugyanazok a inicializációs metódusok használhatók az elrendezés [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/)‑én keresztül:

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

Használj master‑ vagy prezentáció‑szintű témát, amikor sok elrendezésnek és diáknak közös alap‑tervet kell követnie, elrendezés‑felülírást, ha egy elrendezés‑családnak eltérő stílusra van szüksége, és dia‑felülírást csak valódi kivételek esetén. A túlzott dia‑szintű felülírások nehezebbé teszik a későbbi globális téma‑módosítások előrejelzését.

## **Téma háttérstílusainak frissítése**

A téma háttér‑kitöltései a [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) gyűjteményben vannak tárolva. A PowerPoint a felhasználói felületen több háttér‑választási lehetőséget jeleníthet meg, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mert a UI kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílus‑referenciákkal.

![PowerPoint háttér‑stílus galéria egy prezentáció‑témához](presentation-design_8.png)

Mielőtt háttér‑stílust használnál, ellenőrizd a tárolt gyűjteményt és a jelenlegi [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/) értéket. A `StyleIndex` a `0` értéket használja „nincs téma‑kitöltés” esetén; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez más, mint a C++ gyűjtemény közvetlen indexelése `idx_get(0)` esetén, ahol a `0` az első tárolt elem. Ne feltételezd, hogy minden prezentáció ugyanannyi háttér‑kitöltési stílust tartalmaz.

Az alábbi példa jelenti a rendelkezésre álló háttér‑kitöltések számát, egy téma‑háttér‑referenciát rendel az első masterhez, és elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma‑bejegyzéstől és az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a master háttér módosítása nem feltétlenül befolyásolja azt a diát. Használd a [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/)‑t, ha a végleges háttérre van szükséged az öröklődés után.

{{% alert color="warning" title="Warning" %}}
A `StyleIndex` nem egy nullára indexelt gyűjteményindex. Kerüld a stílusszámok hard‑kódolását egy fájlból, és a másik fájlban való felhasználását, mivel a téma‑stílusdefiníciók prezentáció‑specifikusak.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttér‑formázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/cpp/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusainak frissítése**

A téma formátum‑sémája különálló [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/) és [FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell az állandó szám feltételezése helyett.

![Finom, közepes és intenzív téma‑effektek ugyanazon alakzaton](presentation-design_10.png)

C++‑ban a gyűjtemény indexelése nullára indul: az `idx_get(0)` az első tárolt stílus, az `idx_get(2)` a harmadik. Az alakzat‑stílus‑referenciák indexei egy külön fogalom, amely a [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/)‑n keresztül érhető el. Egy téma‑stílus módosítása azokra az alakzatokra van hatással, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltő‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, és elmenti az eredményt:

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

Az ezekre a helyekre hivatkozó alakzatoknál az első téma‑vonal‑stílus piros lesz, a harmadik téma‑kitöltő‑stílus szilárd erdei zöld, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílushelyet hivatkozza az egyes alakzat, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok módosítása vonal, kitöltés és árnyék beállítások után](presentation-design_11.png)

## **Kitöltési és vonal‑stílusok kiválasztása egy alakzathoz**

Egy alakzat a [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) és a [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/) metódusokkal függetlenül választhatja ki a kitöltést és a körvonalt. Mindkét setter esetén az `1` index a megfelelő téma‑gyűjtemény első bejegyzését (`idx_get(0)`) választja, a `2` index a második bejegyzést.

Az alábbi példa két kitöltési stílust (arany és égkék) és két vonal‑stílust (sötétkék, 6 pt, és sötétvörös, 12 pt) hoz létre egy új prezentáció alap‑témájában. A diát három szakaszban menti, hogy a PowerPoint‑ban össze tudd hasonlítani az eredményeket.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeStyle.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto styles = presentation->get_MasterTheme()->get_FormatScheme();

auto goldFill = styles->get_FillStyles()->idx_get(0);
goldFill->set_FillType(FillType::Solid);
goldFill->get_SolidFillColor()->set_Color(Color::get_Gold());
auto blueFill = styles->get_FillStyles()->idx_get(1);
blueFill->set_FillType(FillType::Solid);
blueFill->get_SolidFillColor()->set_Color(Color::get_SkyBlue());

auto thinLine = styles->get_LineStyles()->idx_get(0);
thinLine->get_FillFormat()->set_FillType(FillType::Solid);
thinLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
thinLine->set_Width(6.0);
auto thickLine = styles->get_LineStyles()->idx_get(1);
thickLine->get_FillFormat()->set_FillType(FillType::Solid);
thickLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkRed());
thickLine->set_Width(12.0);

auto shapes = presentation->get_Slide(0)->get_Shapes();
auto left = shapes->AddAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
auto right = shapes->AddAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
auto leftStyle = left->get_ShapeStyle();
auto rightStyle = right->get_ShapeStyle();
leftStyle->set_FillStyleIndex(1);
rightStyle->set_FillStyleIndex(2);
leftStyle->set_LineStyleIndex(1);
rightStyle->set_LineStyleIndex(1);
presentation->Save(u"01-initial.pptx", SaveFormat::Pptx);

rightStyle->set_LineStyleIndex(2);
presentation->Save(u"02-line-changed.pptx", SaveFormat::Pptx);

goldFill->get_SolidFillColor()->set_Color(Color::get_SeaGreen());
presentation->Save(u"03-theme-changed.pptx", SaveFormat::Pptx);
```

| Kezdeti stílusok | A jobb körvonal módosítása | Az első téma‑kitöltés szerkesztése |
|:---:|:---:|:---:|
| ![Arany és égkék téglalapok, egyező vékony sötétkék körvonalakkal](theme-style-initial.png) | ![Az égkék téglalap most vastag sötétvörös körvonallal rendelkezik](theme-style-line-changed.png) | ![A bal téglalap most zöld, és mindkét körvonal változatlan](theme-style-fill-changed.png) |

Eltérő vonal‑stílus kiválasztása csak a jobb téglalap körvonalát változtatja. Az első téma‑kitöltés szerkesztése minden arra a kitöltésre hivatkozó alakzatot frissít. Itt csak a bal téglalap válik zöldé.

Egy meglévő alakzat esetén egy helyi kitöltő‑szín, vonal‑szín vagy vonal‑szélesség felülírhatja a téma‑stílus ezen részét. Ha egy stílus‑index módosítása nem hoz látható változást, ellenőrizd az alakzat [közvetlen formázását](/slides/hu/cpp/shape-formatting/).

## **Hatékony szilárd kitöltés téma‑szín használatának meghatározása**

Egy kitöltés tárolható közvetlenül az objektumon, vagy öröklődhet egy bekezdés, elrendezés, master, téma‑stílus vagy más formázási szintből. Hívd a [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/)‑t, hogy ez a hierarchia immutábilis [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/) objektummá legyen feloldva. Először ellenőrizd a [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/)‑t. Csak akkor, ha ez `FillType::Solid`, olvasd a szilárd‑kitöltés tulajdonságait.

Szilárd kitöltés esetén a [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) visszaadja az öröklődés, téma‑lekérdezés és színátalakítások után megjelenített RGB‑értéket. A [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) slotot adja vissza, például `Text1` vagy `Accent6`. A `SchemeColor::NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy séma‑színen alapul. Egy olyan munkafolyamatban, ahol a kitöltések csak téma‑színek vagy közvetlen RGB‑színek, ez az érték egy közvetlen RGB‑kitöltést jelöl.

Ne csak a helyi [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/) értéket használd a kitöltés osztályozásához. Például egy szövegrésznek lehet helyi séma‑színe `NotDefined`, míg a hatékony kitöltése egy téma‑színből származik, és `Text1` vagy `Accent6`‑ra oldódik fel. Ezzel szemben a `get_SolidFillSchemeColor` megmutatja, mely logikai téma‑hely ez a szín, de nem mondja meg, hogy ez a hely az objektumból, bekezdésből, elrendezésből, master‑ből vagy egy másik szintből származik.

Az alábbi példa betölti egy prezentációt, ellenőrzi mind az alakzat‑kitöltéseket, mind a szövegrész‑kitöltéseket, kiírja minden végső RGB‑értéket és a kapcsolódó séma‑színt, és megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín változását:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

A `NotDefined` ágból származó auditlista a szilárd kitöltéseket mutatja, amelyek nem reagálnak a téma‑szín slotok változására. Ezeket az objektumokat akkor érdemes áttekinteni, amikor egy prezentációnak új márkás palettát kell követnie. A jelentett RGB‑érték még mindig a jelenlegi megjelenést mutatja, a séma‑érték pedig elmagyarázza, hogy a megjelenés a témához kapcsolódik‑e.

A hatékony‑formátum objektumok pillanatfelvételek. A prezentáció téma, egy téma‑felülírás vagy bármely öröklődő formázás módosítása után hívd újra a `GetEffective`‑et, és olvasd be az új `IFillFormatEffectiveData` objektumot a színek összehasonlítása vagy jelentése előtt.

## **Hatékony témaértékek kiolvasása**

A nyers témaobjektumok azt mutatják, mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, mit használ valójában egy dia vagy alakzat az öröklődés és a helyi felülírások feloldása után. Diára a [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) hívásával, háttérre a [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/)‑vel, kitöltésre pedig a [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/)‑vel.

Az alábbi példa egy dia hatékony témáját, háttérét és első alakzat‑kitöltését olvassa be:

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

Használd a hatékony adatokat renderelés‑diagnosztikához, ellenőrzéshez és összehasonlításokhoz. Ha csak a [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/)‑et ellenőrzöd, lemaradhatsz a master, layout, slide vagy shape felülírásairól, amelyek megváltoztatják a végső megjelenést.

## **GYIK**

**Befolyásolja egy külső téma alkalmazása a prezentáció minden diaját?**

Nem. Az [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) csak a kiválasztott masterhez tartozó diákra alkalmazza a változást. Más master‑hez tartozó diák megtartják meglévő témájukat.

**Alkalmazhatok-e egy témát egyetlen diára a master módosítása nélkül?**

Igen. Használd a dia [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/)‑ét, és inicializáld a felülírásos témáját. A változás csak arra a diára vonatkozik; a többi dia a meglévő témáját örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Amikor egy diát áthelyezel és meg akarod őrizni a forrás‑megjelenését, klónozd a forrás‑master‑t a cél‑prezentációba, majd a diát a [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) és a [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) segítségével. Ez megőrzi a master‑t, az elrendezéseket és a témát együtt.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használd a [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)‑t egy dia vagy layout téma esetén, valamint a megfelelő hatékony‑adat metódusokat formátumobjektumokhoz, például a [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) és a [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/) metódusokat. Ezek az API‑k a öröklődés és felülírások után feloldott értékeket adják vissza.