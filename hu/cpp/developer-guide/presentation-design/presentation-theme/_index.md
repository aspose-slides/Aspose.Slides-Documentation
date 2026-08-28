---
title: Prezentációs témák kezelése C++-ban
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/cpp/presentation-theme/
keywords:
- PowerPoint-téma
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
description: "Mester prezentációs témák az Aspose.Slides C++-ban, amelyekkel PowerPoint-fájlokat hozhatsz létre, testreszabhatsz és konvertálhatsz egységes márkaarculattal."
---
## **Bevezetés**

A prezentáció témája egy összehangolt szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témára érzékeny objektumok ezekre a megosztott definíciókra hivatkoznak, ahelyett, hogy minden vizuális tulajdonságot fix értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ban a prezentáció szintű téma a [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/) metóduson keresztül érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülbírálásokat. Egy master felülbírálhatja a prezentáció témáját a [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) metódussal, míg egy elrendezés vagy egy adott dia a [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) metódust használhatja. Gyakorlatban egy dia hatékony témája a következő öröklődési láncon keresztül kerül feloldásra: prezentáció témája, master felülbírálás, elrendezés felülbírálás és dia felülbírálás.

![Téma összetevői: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint a hatékony értékek kiolvasása az öröklődés és felülbírálások feloldása után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/) objektum a téma [get_ColorScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) és [get_FormatScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) metódusait teszi elérhetővé. Ezeknek a gyűjteményeknek a vizsgálata a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hogy hány háttér‑, kitöltés‑, vonal‑ és effektusstílus tárolódik a témában:

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

Ha egy fájl több master‑t használ, ne feltételezzük, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizzük a diával kapcsolatos master‑t, és használjuk a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, amikor elrendezési vagy dia‑felülbírálások is előfordulhatnak.

## **Téma színeinek módosítása**

A témára érzékeny kitöltések, vonalak és szöveg egy logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) felsorolásból. Ha módosítjuk a megfelelő bejegyzést a téma [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/) objektumában, az összes olyan objektum, amely még mindig a téma színére hivatkozik, az új értékhez lesz rendelve. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg a téma‑szín frissítésekor.

Az alábbi vég‑végi példa létrehoz egy alakzatot, amely az `Accent4`‑et használja, megváltoztatja a téma `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is az `Accent4`‑hez van kapcsolva, a téma módosítása után látható színe piros lesz. Ha a séma‑színt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4` változások már nem befolyásolják ezt a kitöltést.

### **Színek használata a kiegészítő palettából**

A PowerPoint a téma‑színből világosabb és sötétebb változatokat hoz létre színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/colortransformoperation/) objektumon keresztül teszi elérhetővé.

![Fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – A fő téma színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az `Accent4` alapján, ötön alkalmaz lumineszcencia‑transzformációt, majd elmenti az eredményt:

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

Ezek a változatok továbbra is a téma‑színen alapulnak. Ha később az `Accent4` megváltozik, a transzformált színek az új `Accent4` értékből lesznek újraszámolva.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazoknak a témahelyeknek a különböző nevei; nem olyan értékek, amelyeket dinamikusan konvertálnának egyik formából a másikba.

## **Téma betűtípusainak módosítása**

Egy téma betűtípus‑sémája egy fő (major) betűkészletet tartalmaz a címsorokhoz és egy kisebb (minor) betűkészletet a törzsszöveghez. A [FontScheme::get_Major()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_major/) és a [FontScheme::get_Minor()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_minor/) metódusok teszik ezeket elérhetővé.

A PowerPoint‑kompatibilis téma‑betűtípus‑azonosítók a szövegformázásban használhatók:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa létrehoz egy címsort, amely a fő latin téma‑betűtípust, valamint egy törzssort, amely a kisebb latin téma‑betűtípust használja. Ezután módosítja a téma betűtípusait és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a kisebb betűtípust követi. Azok a szövegek, amelyek explicit betűtárnevet tartalmaznak a téma‑azonosító helyett, nem váltakoznak automatikusan, amikor a téma‑betűtípus‑séma megváltozik.

A fő és kisebb betűkészletek tartalmazhatnak betűtípus‑leképezéseket is egyedi írásrendszerekhez, például cirill, arab, japán, grúz vagy thaana. A leképezések megtekintéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/cpp/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tanács" %}}

További információk a prezentáció‑betűtípusokról: [PowerPoint Fonts](/slides/hu/cpp/powerpoint-fonts/).

{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑problémákat oldanak meg.

### **Külső téma alkalmazása a master‑függő diákra**

Használd a [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) metódust, ha egy PowerPoint témafájlt (`.thmx`) szeretnél alkalmazni, és az összes olyan diát újraszínezni, amely adott master‑től függ. Válaszd ki a master‑t a [Presentation::get_Masters](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_masters/) gyűjteményből, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/) interfészt valósítja meg, majd add át a témafájl elérési útját a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új master‑diát a kiválasztott master alapján.  
1. Alkalmazza a külső témát az új master‑re.  
1. Az összes korábban a kiválasztott master‑re támaszkodó diát az új master‑hez rendeli.  
1. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/) objektumot.

Az alábbi példa egy külső témát alkalmaz az első master‑re támaszkodó diákra, majd elmenti a prezentációt:

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

Érvénytelen, sérült vagy nem támogatott téma [PptxException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxexception/) vagy annak formátum‑specifikus alosztályát eredményezheti. Validáld a felhasználók által megadott útvonalakat, kezeld a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentsd el a prezentációt.

Csak a kiválasztott master‑re támaszkodó diákok kapnak új hozzárendelést. A többi master‑hez kapcsolódó diák megtartja a meglévő master‑ét és témáját. A témára érzékeny színek, betűtípusok, kitöltések, vonalak, háttér‑ és effektus‑stílusok az új külső témához igazodnak. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és dia‑szintű felülbírálások szintén felülírhatják az új master‑től örökölt értékeket.

A téma hivatkozhat olyan betűtípusokra, amelyek nem érhetők el a futtatási környezetben. A következetes megjelenítés és export érdekében telepítsd a szükséges betűtípusokat, biztosítsd őket [egyedi betűtípus‑források](/slides/hu/cpp/custom-font/) révén, vagy konfiguráld a [betűtípus‑helyettesítést](/slides/hu/cpp/font-substitution/).

Ez egy közvetlen master‑szintű munkafolyamat: a metódus a `.thmx` fájl útvonalát várja, és nem igényel manuális dia‑ vagy elrendezés‑szintű téma‑felülbírálás létrehozását.

### **Különböző külső témák alkalmazása több‑masteres prezentációban**

Ha a megfelelő master előre nem ismert, szerezd be egy reprezentatív dia segítségével a [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/get_layoutslide/) és a [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_masterslide/) metódusokkal. Tárold el az eredeti master‑referenciákat a témák alkalmazása előtt, mivel minden hívás egy új master‑t hoz létre a prezentációban.

Az alábbi példa két szekcióból származó diák segítségével megkeresi a master‑eket, majd minden csoporthoz különböző külső témát alkalmaz:

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

Az első hívás csak a `firstGroupMaster`‑re támaszkodó diákon hat, a második hívás csak a `secondGroupMaster`‑re.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretnél áthelyezni, miközben megőrzöd az eredeti megjelenést, klónozd a forrás‑master‑t a célprezentációba a [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/) metódussal, majd a diát a [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódussal és a klónozott master‑rel. Ez együtt mozgatja a master‑t, az elrendezéseket és a hozzá kapcsolódó témát.

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

Ez a preferált munkafolyamat, ha a forrásdia megjelenése a célban is pontosan ugyanaz kell legyen. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑master‑re módosíthatja a téma‑alapú színeket, betűtípusokat, háttereket és effektusokat.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél‑dia a jelenlegi master‑en és elrendezésen marad, inicializálj egy dia‑szintű felülbírálást a forrástémából. A [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) és [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok másolják a három fő téma‑komponenst a felülbírálásba.

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

Ez megváltoztatja az adott dia által használt témát anélkül, hogy a többi dia örökölt témáját módosítaná. A helyi felülbírálás eltávolításához és az örökölt értékek visszaállításához hívd meg a [OverrideTheme::Clear()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma felülbírálás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülbírálás az adott elrendezést használó diákra hat, hacsak a konkrét dia nem rendelkezik saját felülbírálással. Ugyanezeket az inicializáló metódusokat a layout `[IOverrideThemeManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/)` segítségével is használhatod:

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

Használj master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alaptervezést kell megosztania; használj elrendezés‑felülbírálást, ha egy elrendezés‑családnak más stílusra van szüksége; és csak dia‑felülbírálást, ha valódi kivételt kell kezelni. A túlzott dia‑szintű felülbírálások megnehezítik a későbbi globális téma‑változások előrejelzését.

## **Téma háttérstílusainak frissítése**

A téma háttér‑kitöltései a [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) metódusban tárolódnak. A PowerPoint a felhasználói felületén több háttér‑választást is megjeleníthet, mint amennyi kitöltés‑definíció ténylegesen szerepel ebben a gyűjteményben, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílus‑referenciákkal.

![PowerPoint háttérstílus galéria a prezentáció‑témához](presentation-design_8.png)

Mielőtt háttérstílust használnál, vizsgáld meg a tárolt gyűjteményt és a jelenlegi [Background::get_StyleIndex()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/get_styleindex/) értéket. A `StyleIndex` a `0`‑t használja „nincs téma‑kitöltés” esetén; a pozitív értékek a téma háttér‑stílus‑referenciákat jelölik. Ez eltér a C++ gyűjtemény közvetlen `idx_get(0)` indexelésétől, ahol a `0` az első tárolt elem. Ne feltételezd, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílust tartalmaz.

Az alábbi példa kiírja a rendelkezésre álló háttér‑kitöltések számát, egy téma‑hivatkozást rendel az első master‑hez, majd elmenti a prezentációt:

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

A látható eredmény a master által referenciázott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülbírálásoktól függ. Ha egy dia saját háttérrel rendelkezik, a master háttér módosítása nem biztos, hogy változtatja azt a diát. Használd a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/) metódust, amikor a végső háttérre van szükséged az öröklődés után.

{{% alert color="warning" title="Figyelmeztetés" %}}

Ne kezeld a `StyleIndex`‑et nullával kezdődő gyűjtemény‑indexnek. Kerüld el a stílus számának kódba írását egy fájlból, és ne feltételezd, hogy ugyanolyan lesz egy másik fájlban; a téma‑stílusdefiníciók prezentációnként eltérnek.

{{% /alert %}}

{{% alert color="info" title="Tippek" %}}

A közvetlen háttér‑formázáshoz és a háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/cpp/presentation-background/) oldalt.

{{% /alert %}}

## **Téma effektusainak frissítése**

A téma formátumsémája különálló [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_linestyles/) és [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, mérsékelt és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy rögzített darabszámot feltételezne.

![Finom, mérsékelt és intenzív téma‑effektek ugyanarra az alakzatra alkalmazva](presentation-design_10.png)

C++‑ban a gyűjtemény indexelése nullával kezdődik: `idx_get(0)` az első tárolt stílus, `idx_get(2)` a harmadik. Egy alakzat stílus‑referencia indexei egy külön koncepció, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra hivatkoznak; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek‑e, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, és elmenti az eredményt:

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

Az ezekre a helyekre hivatkozó alakzatok esetén az első téma‑vonal‑stílus pirosra változik, a harmadik téma‑kitöltés‑stílus szilárd erdőzöld lesz, a harmadik effektus‑stílus pedig 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, melyik stílushelyre hivatkozik az adott alakzat, illetve hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok a vonal, kitöltés és árnyék beállítások módosítása után](presentation-design_11.png)

## **Megállapítás, hogy egy hatékony szilárd kitöltés téma‑színt használ-e**

Egy kitöltés közvetlenül egy objektumon tárolható vagy öröklődhet bekezdésből, elrendezésből, master‑ből, téma‑stílusból vagy más formázási szintből. A [IFillFormat::GetEffective](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformat/geteffective/) meghívásával a hierarchia egy változhatatlan [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformateffectivedata/) objektummá alakul. Először ellenőrizd a [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformateffectivedata/get_filltype/) értékét. Csak ha ez `FillType::Solid`, olvasd a szilárd kitöltés tulajdonságait.

Szilárd kitöltés esetén a [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) a végleges megjelenített RGB‑értéket adja vissza az öröklődés, téma‑keresés és szín‑transzformációk után. A [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) helyet adja vissza, például `Text1` vagy `Accent6`. A `SchemeColor::NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy séma‑színen alapul. Egy olyan munkafolyamatban, ahol a kitöltések vagy téma‑színek, vagy közvetlen RGB‑színek, ez az érték egy közvetlen RGB‑kitöltést jelöl.

Ne csak a helyi [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icolorformat/get_schemecolor/) értéket használd a kitöltés besorolásához. Például egy szövegrésznek lehet helyi séma‑színe `NotDefined`, miközben a hatékony kitöltés egy téma‑színt örököl és `Text1`‑re vagy `Accent6`‑ra feloldódik. Ezzel szemben a `get_SolidFillSchemeColor` megmondja, mely logikai téma‑helyből származik a hatékony szín, de nem jelzi, hogy az a hely az objektumból, bekezdésből, elrendezésből, master‑ből vagy egy másik szintből származik.

Az alábbi példa betölt egy prezentációt, auditálja az alakzat‑ és szövegrész‑kitöltéseket, kiírja minden végleges RGB‑értéket és a hozzá tartozó séma‑színt, majd megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín változásait:

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

A `NotDefined` ág egy auditlistát ad a szilárd kitöltésekről, amelyek nem reagálnak a téma‑színhelyek változására. Ezeket az objektumokat akkor ellenőrizd, amikor egy prezentációnak egy új márkaszínt kell követnie. A jelentett RGB‑érték még mindig a jelenlegi megjelenést mutatja, míg a séma‑érték elmagyarázza, hogy ez a megjelenés kapcsolódik‑e a témához.

A hatékony‑formátum objektumok pillanatképek. A prezentáció téma, egy téma‑felülbírálás vagy bármely örökölt formázás módosítása után hívd újra a `GetEffective`‑et, és olvasd ki az új `IFillFormatEffectiveData` objektumot, mielőtt összehasonlítanád vagy jelentened a színeket.

## **Hatékony témaértékek kiolvasása**

A nyers témaobjektumok megmutatják, mi van definiálva egy adott szinten. A hatékony értékek megmutatják, mit használ egy dia vagy alakzat az öröklődés és a helyi felülbírálások feloldása után. Egy dia esetén hívd a [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) metódust. Háttér esetén használd a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/), kitöltés esetén a [FillFormat::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/geteffective/) metódust.

Az alábbi példa kiolvassa a hatékony témát, hátteret és az első alakzat kitöltését egy diáról:

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

Használd a hatékony adatokat renderelési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/) objektumot nézed, kihagyhatsz egy master, elrendezés, dia vagy alakzat felülbírálást, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Az externális téma alkalmazása minden diára hat a prezentációban?**

Nem. A [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) csak azokat a diákot rendeli újra, amelyek a kiválasztott master‑re támaszkodnak. A más master‑t használó diák megőrzik meglévő témájukat.

**Alkalmazhatok témát egyetlen diára anélkül, hogy a master‑t módosítanám?**

Igen. Használd a dia [IOverrideThemeManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/)‑ét, és inicializáld a felülbíráló témát. A változtatás csak arra a diára lesz lokális; a többi dia a meglévő témáját örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Amikor egy diát áthelyezel és az eredeti megjelenést meg akarod őrizni, klónozd a forrás‑master‑t a célba, majd a diát a `[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/)` és `[ISlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/)` segítségével. Így a master, az elrendezések és a téma együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és a felülbírálások után?**

Használd a [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) metódust egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat metódusokat formátumobjektumokhoz, például a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/) és a [FillFormat::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/geteffective/) hívásával. Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülbírálások alkalmazása után.