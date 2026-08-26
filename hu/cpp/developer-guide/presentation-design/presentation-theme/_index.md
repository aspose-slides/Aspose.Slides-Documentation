---
title: Bemutatótémák kezelése C++-ban
linktitle: Prezentáció téma
type: docs
weight: 10
url: /hu/cpp/presentation-theme/
keywords:
- PowerPoint téma
- bemutató téma
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
- bemutató
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ fő bemutatótémái a PowerPoint fájlok konzisztens márkázásához való létrehozás, testreszabás és konvertálás érdekében."
---
## **Bevezetés**

A bemutató téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektus-készletet határoz meg. A téma‑tudatos objektumok ezekre a megosztott definíciókra hivatkoznak, ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma‑váltás egyszerre több objektumot is frissíthet.

Az Aspose.Slides‑ben a bemutató‑szintű téma a [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/) segítségével érhető el. Egy bemutató alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. A master a prezentáció témáját a [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) segítségével felülírhatja, míg egy elrendezés vagy egy egyedi dia a [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) segítségével használhat felülírást. Gyakorlatban egy dia hatékony témája ezen öröklődési láncon keresztül kerül feloldásra: bemutató‑téma, master‑felülírás, elrendezés‑felülírás és dia‑felülírás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektus‑stílusok frissítése, valamint a hatékony értékek kiolvasása öröklődés és felülírások feloldása után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/) objektum a téma [get_ColorScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) és [get_FormatScheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) metódusait teszi elérhetővé. Ezeknek a gyűjteményeknek a vizsgálata különösen hasznos, ha a bemutató külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

A következő példa beolvassa a fő téma tulajdonságait, és beszámolja, hány háttér‑, kitöltés‑, vonal‑ és effektus‑stílus van eltárolva a témában:

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

Ha egy fájl több master‑t használ, ne feltételezzük, hogy minden dia ugyanazt a hatékony témát használja. Ellenőrizzük a diával kapcsolatos master‑t, és használjuk az alább bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülírások léteznek.

## **Téma színeinek módosítása**

A téma‑tudatos kitöltések, vonalak és szöveg egy logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) felsorolásból. Amikor a téma [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/) megfelelő bejegyzését módosítjuk, minden objektum, amely még mindig arra a téma‑színre hivatkozik, az új érték szerint kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színnel vannak megadva, nem változnak a téma‑szín frissítésekor.

A következő vég‑től‑végig példa létrehoz egy alakzatot, amely a `Accent4` színt használja, a téma `Accent4` színét pirosra változtatja, elmenti a bemutatót, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4`-hez van kapcsolva, a téma módosítása után látható színe piros lesz. Ha a séma‑színt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4`‑változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma‑színből világosabb és sötétebb variánsokat hoz létre színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/colortransformoperation/) segítségével teszi elérhetővé.

![A fő téma színei, valamint a kiegészítő palettából származó világosabb és sötétebb színek](additional-palette-colors.png)

**1** – A fő téma színei.  
**2** – A fő téma színeiből előállított világosabb és sötétebb variánsok.

A következő példa hat téglalapot hoz létre a `Accent4` alapján, ötön luminancia‑transzformációt alkalmaz, és elmenti az eredményt:

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

Ezek a variánsok továbbra is a téma‑színen alapulnak. Ha a `Accent4` később megváltozik, a transzformált színek az új `Accent4` értékből kerülnek újraszámításra.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` bejegyzéseket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven exponálja. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan konvertált értékek.

## **Téma betűtípusainak módosítása**

Egy téma‑betűtípus‑készlet fő betűkészletet (fejléc) és kisebb betűkészletet (szöveg) tartalmaz. A [FontScheme::get_Major()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_major/) és a [FontScheme::get_Minor()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_minor/) metódusok ezeket a készleteket biztosítják.

PowerPoint‑kompatibilis téma‑betűtípus‑azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Test betűtípus Latin (Minor Latin Font)
* `+mj-lt` – Fejléc betűtípusa Latin (Major Latin Font)
* `+mn-ea` – Test betűtípus Kelet‑Ázsiai (Minor East Asian Font)
* `+mj-ea` – Fejléc betűtípusa Kelet‑Ázsiai (Major East Asian Font)

A következő példa egy fejlécet hoz létre, amely a fő Latin téma‑betűtípust használja, valamint egy testsort, amely a kisebb Latin téma‑betűtípust használja. Ezután módosítja a téma betűtípusait, és elmenti az eredményt:

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

A fejléc a fő betűtípust, a test szövege pedig a kisebb betűtípust követi. Az explicit betűtípus‑névvel rendelkező szöveg nem vált automatikusan, ha a téma‑betűtípus‑készlet megváltozik.

A fő és kisebb betűkészletek tartalmazhatnak betűtípus‑leképezéseket is egyéni írásrendszerekhez, például cirill, arab, japán, grúz vagy thaana. Ezek ellenőrzéséhez, hozzáadásához, cseréjéhez vagy eltávolításához tekintse meg a [Szkript‑specifikus téma‑betűtípusok](/slides/hu/cpp/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tipp" %}}
További információk a bemutató‑betűtípusokról: [PowerPoint betűtípusok](/slides/hu/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolódó problémákat oldanak meg.

### **Külső téma alkalmazása egy master‑függő diáknak**

Használja a [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) metódust, ha egy PowerPoint témafájl (`.thmx`) áll rendelkezésre, és minden, egy adott master‑től függő diát új stílusba szeretne hozni. Válassza ki a master‑t a [Presentation::get_Masters](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_masters/) gyűjteményből, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/) interfészt valósítja meg, majd adja át a témafájl elérési útját a metódusnak.

A metódus a következő lépéseket hajtja végre:

1. Létrehoz egy új master‑diát a kiválasztott master alapján.  
1. Alkalmazza a külső témát az új master‑re.  
1. Az új master‑t hozzárendeli minden diához, amely korábban a kiválasztott master‑re támaszkodott.  
1. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/) objektumot.

A következő példa egy külső témát alkalmaz az első master‑től függő diákra, majd elmenti a bemutatót:

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

Érvénytelen, sérült vagy nem támogatott téma [PptxException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxexception/) vagy annak formátum‑specifikus alosztályait idézheti elő. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentse a bemutatót.

Csak azok a diák kerülnek átállításra, amelyek a kiválasztott master‑től függtek. Más master‑hez tartozó diák megtartják meglévő master‑jüket és témájukat. A téma‑tudatos színek, betűtípusok, kitöltések, vonalak, háttér‑ és effektus‑stílusok az új témához igazodnak. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és dia‑szintű felülírások szintén felülbírálhatják az új master‑től örökölt értékeket.

A téma olyan betűtípusokra hivatkozhat, amelyek nincsenek telepítve a futtatókörnyezetben. A következetes megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket [egyedi betűforrásokon](/slides/hu/cpp/custom-font/) keresztül, vagy konfigurálja a [betűcserét](/slides/hu/cpp/font-substitution/).

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl útvonalát várja, és nem igényel dia‑ vagy elrendezés‑szintű téma‑felülírások kézi létrehozását.

### **Különböző külső témák alkalmazása több‑masteres bemutatóban**

Ha a releváns master előre nem ismert, szerezze be egy reprezentatív dia segítségével a [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/get_layoutslide/) és a [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_masterslide/) metódusokkal. Tárolja el az eredeti master‑referenciákat, mielőtt bármilyen témát alkalmazna, mert minden hívás egy új master‑t hoz létre a bemutatóban.

A következő példa két szekció diáit használja a master‑ek megtalálásához, és minden csoporthoz más-más külső témát alkalmaz:

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

Az első hívás csak az `firstGroupMaster`‑től függő diákra hat, a második pedig csak a `secondGroupMaster`‑től függőkre. A többi master‑hez tartozó diák nem változik.

### **Forrástéma megtartása dia áthelyezésekor**

Ha egy diát egy másik bemutatóba szeretne áthelyezni, és az eredeti megjelenését megőrizni, klónozza a forrás‑master‑t a cél‑bemutatóba a [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/) segítségével, majd a diát a [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) és a klónozott master segítségével. Így a master, a layoutok és a kapcsolódó téma együtt kerülnek átvitelre.

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

Ez a preferált megközelítés, ha a forrásdia megjelenését a célban pontosan meg akarja őrizni. Az egyszerű tartalomklónozás egy nem kapcsolódó cél‑masterre megváltoztathatja a téma‑alapú színeket, betűtípusokat, hátteret és effektusokat.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél‑dia a jelenlegi master‑en és elrendezésén marad, inicializáljon egy dia‑szintű felülírást a forrástémából. Az [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) és [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok a három fő téma‑komponenst másolják a felülírásba.

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

Ez a dia által használt témát módosítja anélkül, hogy a többi dia által örökölt témát megváltoztatná. A helyi felülírás eltávolításához és a visszatéréshez az örökölt értékekhez hívja meg az [OverrideTheme::Clear()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma‑felülírás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás az arra a layout‑ra hivatkozó diákra vonatkozik, kivéve, ha egy adott diának saját felülírása van. Az ugyanazok a inicializáló metódusok használhatók a layout `[IOverrideThemeManager]`‑jén keresztül:

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

Használjon master‑ vagy bemutató‑szintű témát, ha sok layout és dia ugyanazt az alap‑dizájnt kell, hogy használja; layout‑felülírást, ha egy adott layout‑családnak eltérő stílusra van szüksége; és dia‑felülírást csak a valódi kivételekhez. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttér‑stílusainak frissítése**

A téma háttér‑kitöltései a [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) metódussal érhetők el. A PowerPoint az UI‑jában több háttér‑választást kínál, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mivel az UI kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílus‑referenciákkal.

![PowerPoint háttér‑stílus galéria egy bemutató témához](presentation-design_8.png)

Mielőtt háttér‑stílust használna, ellenőrizze a tárolt gyűjteményt és az aktuális [Background::get_StyleIndex()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/get_styleindex/) értéket. A `StyleIndex` a `0`‑t jelöli „nincs téma‑kitöltés”; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér attól, amikor a C++ gyűjteményt közvetlenül az `idx_get(0)`‑val indexeljük, ahol a `0` az első tárolt elemet jelenti. Ne feltételezze, hogy minden bemutató ugyanannyi háttér‑kitöltési stílussal rendelkezik.

A következő példa kiírja a rendelkezésre álló háttér‑kitöltések számát, egy téma‑háttér‑referenciát rendeli az első master‑hez, majd elmenti a bemutatót:

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

A látható eredmény a master‑által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját hátteret használ, a csak a master háttér módosítása nem biztos, hogy megváltoztatja azt a diát. Használja a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/) metódust, ha a végső, örökölt után alkalmazott hátteret szeretné megtudni.

{{% alert color="warning" title="Figyelmeztetés" %}}
Ne keverje össze a `StyleIndex`‑et a nulláról induló gyűjtemény‑indexeléssel. Kerülje a stílusszámok hard‑kódolását egy fájlból, és feltételezni, hogy egy másik fájlban ugyanúgy fog kinézni; a téma‑stílus‑definíciók bemutató‑specifikusak.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Közvetlen háttér‑formázáshoz és háttér‑öröklődéshez tekintse meg a [Bemutató háttér](/slides/hu/cpp/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátum‑sémája különálló [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_linestyles/) és [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a visszafogott, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy fix számot feltételezne.

![Visszafogott, közepes és intenzív téma‑effektusok egyetlen alakzaton alkalmazva](presentation-design_10.png)

C++‑ban ezeknek a gyűjteményeknek a indexelése nulla‑alapú: az `idx_get(0)` az első tárolt stílus, az `idx_get(2)` a harmadik. Egy alakzat stílus‑referencia‑indexei egy külön fogalom, amely a [IShapeStyle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapestyle/)‑n keresztül érhető el. Egy téma‑stílus módosítása az arra hivatkozó alakzatokat érinti; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

A következő példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltő‑stílust, engedélyezi egy külső árnyékot a harmadik effektus‑stílusban, majd elmenti az eredményt:

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

A hivatkozott slotokkal rendelkező alakzatok esetén az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltő‑stílus szilárd erdei zöldre, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékra változik. A pontos vizuális eredmény továbbra is attól függ, hogy az egyes alakzatok melyik slotra hivatkoznak, illetve hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok módosítás után (vonal, kitöltés, árnyék)](presentation-design_11.png)

## **Hatékony témaértékek kiolvasása**

A nyers témaobjektumok azt mutatják, mi van egy adott szinten definiálva. A hatékony értékek azt mutatják, amit egy dia vagy alakzat valójában használ az öröklődés és a helyi felülírások feloldása után. Dia esetén hívja meg a [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) metódust. Háttérhez használja a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/), kitöltéshez pedig a [FillFormat::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/geteffective/) metódust.

A következő példa kiolvassa a hatékony témát, a háttér‑stílust és az első alakzat kitöltését egy diáról:

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

Használja a hatékony adatokat megjelenítési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/)‑t ellenőrzi, könnyen kihagyhat egy master, layout, dia vagy alakzat felülírását, amely megváltoztatja a végső megjelenést.

## **GYIK**

**A külső téma alkalmazása minden diára hat?**

Nem. Az [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) csak azokat a diákat rendeli hozzá újra, amelyek a kiválasztott master‑től függnek. A más master‑t használó diák megtartják meglévő témáikat.

**Alkalmazhatok témát egyetlen diára anélkül, hogy a master‑t módosítanám?**

Igen. Használja a dia [IOverrideThemeManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ioverridethememanager/)‑ét, és inicializálja annak felülírási témáját. A módosítás csak arra a diára vonatkozik; a többi dia a meglévő témáit továbbra is örökli.

**Mi a legbiztonságosabb módja a téma átvitelének egyik bemutatóból a másikba?**

Dia áthelyezésekor és eredeti megjelenésének megőrzésekor klónozza a forrás‑master‑t a cél‑bemutatóba, majd a diát is klónozza a master‑rel együtt a [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/) és a [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) segítségével. Így a master, az elrendezések és a téma együtt maradnak.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használja az [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) metódust egy dia vagy elrendezés téma‑hatékony lekéréséhez, valamint a formátum‑objektumok megfelelő hatékony‑adat‑metódusait, például a [Background::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/background/geteffective/) és a [FillFormat::GetEffective()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/geteffective/) metódusokat. Ezek az API‑k a öröklődés és felülírások után feloldott értékeket adják vissza.