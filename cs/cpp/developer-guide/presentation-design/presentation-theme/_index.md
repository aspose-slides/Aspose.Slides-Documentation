---
title: Správa témat prezentace v C++
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/cpp/presentation-theme/
keywords:
- PowerPoint téma
- téma prezentace
- téma snímku
- nastavit téma
- změnit téma
- spravovat téma
- externí téma
- THMX
- barva tématu
- doplňková paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Hlavní témata prezentací v Aspose.Slides pro C++ pro vytváření, přizpůsobení a konverzi souborů PowerPoint s konzistentním brandováním."
---
## **Úvod**

Téma prezentace definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objektům „tématicky‑vědomým“ se odkazuje na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je téma na úrovni prezentace k dispozici přes [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_mastertheme/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), zatímco rozložení nebo jednotlivý snímek může použít [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). V praxi se efektivní téma pro snímek vyhodnocuje podle tohoto řetězce dědičnosti: téma prezentace, přepsání masteru, přepsání rozložení a přepsání snímku.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Níže jsou uvedeny nejčastější pracovní postupy s tématy: prozkoumat téma, změnit barvy a písma, zkopírovat nebo použít téma, aktualizovat styly pozadí a efektů a přečíst efektivní hodnoty po vyřešení dědičnosti a přepsání.

## **Prozkoumání tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/mastertheme/) zpřístupňuje metody [get_ColorScheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) a [get_FormatScheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Prozkoumání těchto kolekcí před jejich úpravou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti tématu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prozkoumejte master přiřazený ke snímku a použijte workflow efektivního tématu uvedené později v článku, pokud mohou být přítomna přepsání rozložení nebo snímku.

## **Změna barev tématu**

Tématicky‑vědomé výplně, čáry a text mohou odkazovat na logickou barvu z enumerace [SchemeColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/schemecolor/). Když změníte odpovídající položku v [tématu IColorScheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyhodnoceny vůči nové hodnotě. Objekty používající přímou barvu RGB nejsou změněny aktualizací barvy tématu.

Následující end‑to‑end příklad vytvoří tvar používající `Accent4`, změní barvu tématu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává propojen s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použití barev z dodatečné palety**

PowerPoint odvozuje světlejší a tmavší varianty z téma‑barvy aplikací transformací barev. Aspose.Slides tyto transformace zpřístupňuje přes [ColorTransformOperation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Hlavní barvy tématu.

**2** – Světlejší a tmavší varianty generované z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, aplikuje na pět z nich luminanční transformace a uloží výsledek:

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

Tyto varianty zůstávají založeny na barvě tématu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `IColorScheme`**

Enumerace [SchemeColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/icolorscheme/) zpřístupňuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty, které by se dynamicky převáděly z jedné podoby do druhé.

## **Změna písma tématu**

Schéma písma tématu obsahuje hlavní sadu písma pro nadpisy a vedlejší sadu pro tělo textu. Metody [FontScheme::get_Major()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/fontscheme/get_major/) a [FontScheme::get_Minor()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/fontscheme/get_minor/) zpřístupňují tyto sady.

Identifikátory písma kompatibilní s PowerPointem lze použít ve formátování textu:

* `+mn-lt` – tělo písma Latin (Minor Latin Font)
* `+mj-lt` – nadpis písma Latin (Major Latin Font)
* `+mn-ea` – tělo písma East Asian (Minor East Asian Font)
* `+mj-ea` – nadpis písma East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo tématu a jeden řádek těla používající vedlejší latinské písmo tématu. Pak změní písma tématu a uloží výsledek:

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

Nadpis používá hlavní písmo a tělo textu používá vedlejší písmo. Text, který má explicitně nastavený název písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma písma tématu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psané systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prozkoumání, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmech v prezentaci viz [PowerPoint Fonts](/slides/cs/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití tématu**

Níže uvedené workflow řeší různé problémy související s tématy.

### **Použití externího tématu na snímcích závislých na masteru**

Použijte [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/), když máte soubor tématu PowerPoint (`.thmx`) a chcete přestylovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation::get_Masters](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_masters/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/), a předávejte cestu k souboru tématu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master‑snímek na základě vybraného masteru.
1. Použije externí téma na nový master.
1. Přiřadí nový master všem snímkům, které předtím závisely na vybraném masteru.
1. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/).

Následující příklad použije externí téma na snímcích, které závisí na prvním masteru, a uloží prezentaci:

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

Neplatné, poškozené nebo nepodporované téma může vyvolat [PptxException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxexception/) nebo některou z jeho podtříd souvisejících s formátem. Ověřujte cesty zadané uživateli, ošetřete selhání přístupu k systému souborů a uložte prezentaci až po úspěšném použití tématu.

Přesunuty jsou jen snímky, které závisely na vybraném masteru. Snímky přiřazené k jiným masterům si zachovají své stávající mastery a témata. Barvy, písma, výplně, čáry, pozadí a efekty, které jsou tématicky‑vědomé, jsou vyhodnoceny vůči externímu tématu. Přímé přiřazení barev, písem, výplní a jiného explicitního formátování může zůstat nezměněno. Přepsání na úrovni rozložení i snímku může mít také přednost před hodnotami zděděnými z nového masteru.

Téma může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytněte je přes [custom font sources](/slides/cs/cpp/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/cpp/font-substitution/).

Toto je přímý workflow na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání na úrovni snímku nebo rozložení.

### **Použití různých externích témat v prezentaci s více mastery**

Když není relevantní master znám předem, získejte jej z reprezentativního snímku pomocí [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/get_layoutslide/) a [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_masterslide/). Před aplikací jakýchkoli témat uložte původní odkazy na master, protože každé volání vytvoří v prezentaci další master.

Následující příklad použije snímky ze dvou sekcí k nalezení jejich masterů a aplikuje na každou skupinu jiné externí téma:

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

První volání ovlivní jen snímky, které závisely na `firstGroupMaster`, a druhé volání jen snímky, které závisely na `secondGroupMaster`. Snímky patřící k jiným masterům nebudou přestylovány.

### **Zachování zdrojového tématu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní návrh, klonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/addclone/), poté klonujte snímek pomocí [ISlideCollection::AddClone()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) a klonovaný master. Tím se přenese master, jeho rozložení i související téma.

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

Jedná se o preferovaný workflow, když musí zdrojový snímek vypadat stejně v cíli. Pouhé klonování obsahu na nekompatibilní master cílové prezentace může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Aplikace hodnot tématu na existující snímek**

Když cílový snímek musí zůstat na svém současném masteru a rozložení, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) a [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) zkopírují tři hlavní komponenty tématu do přepsání.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme::Clear()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/overridetheme/clear/).

### **Aplikace přepsání tématu na rozložení**

Přepsání na úrovni rozložení se použije na snímky, které dané rozložení používají, pokud nemá konkrétní snímek vlastní přepsání. Stejné inicializační metody lze použít přes [IOverrideThemeManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ioverridethememanager/) rozložení:

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

Použijte téma na úrovni masteru nebo prezentace, když mají mnoho rozložení a snímků sdílet stejný základní design; přepsání rozložení, když jedna rodina rozložení vyžaduje odlišné stylování; a přepsání snímku pouze pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje předvídání následných globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Styly pozadí tématu jsou uloženy v [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí než je fyzicky uloženo ve sbírce výplní, protože UI může kombinovat výplně tématu s barvami tématu a dalšími referencemi stylů.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Před použitím stylu pozadí prozkoumejte uloženou sbírku a aktuální [Background::get_StyleIndex()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` používá `0` pro žádnou tématickou výplň; kladné hodnoty jsou odkazy na styly pozadí tématu. To se liší od indexování C++ sbírky přímo pomocí `idx_get(0)`, kde `0` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše dostupný počet výplní pozadí, přiřadí tématický odkaz na pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na položce tématu, na kterou odkazuje master, a na případných přepsáních pozadí v rozložení nebo na úrovni snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/background/geteffective/), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nepožívejte `StyleIndex` jako nulový index kolekce. Také se vyhněte hard‑kódování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylu tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/cpp/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátování tématu obsahuje samostatné sbírky [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/formatscheme/get_linestyles/) a [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typické Office témata často obsahují tři hlavní položky stylu, které vizuálně odpovídají subtilnímu, střednímu a intenzivnímu formátování, ale kód by měl kontrolovat každou sbírku místo předpokládání pevného počtu.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Když v C++ přistupujete k těmto sbírkám, indexování je nulové: `idx_get(0)` je první uložený styl a `idx_get(2)` je třetí. Indexy odkazů stylu tvaru jsou samostatný koncept, zpřístupněný přes [IShapeStyle](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které na něj odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, zda požadované položky stylu existují, změní první styl čáry, třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí styl výplně tématu se stane plnou lesní zelení a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, který slot stylu každá figura používá a zda přímé formátování nepřepíše téma.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Určení, zda efektivní plná výplň používá barvu tématu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozložení, masteru, stylu tématu či jiné úrovně formátování. Zavolejte [IFillFormat::GetEffective](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformat/geteffective/), aby se tato hierarchie přeměnila na neměnný [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformateffectivedata/). Nejprve zkontrolujte [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Pouze když je `FillType::Solid`, čtěte vlastnosti plné výplně.

Pro plnou výplň [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) vrací konečnou renderovanou hodnotu RGB po aplikaci dědičnosti, vyhledání v tématu a transformací barev. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/schemecolor/), např. `Text1` nebo `Accent6`. Hodnota `SchemeColor::NotDefined` znamená, že efektivní plná výplň není založena na barvě schématu. V workflow, kde jsou výplně buď barvy tématu, nebo přímé barvy RGB, tato hodnota identifikuje přímou RGB výplň.

Nepoužívejte pouze lokální hodnotu [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icolorformat/get_schemecolor/) k klasifikaci výplně. Například část textu může mít lokálně nedefinovanou barvu schématu, takže její lokální hodnota je `NotDefined`, zatímco její efektivní výplň zdědí barvu tématu a vyřeší se na `Text1` nebo `Accent6`. Naopak `get_SolidFillSchemeColor` vám řekne, který logický slot tématu vytvořil efektivní barvu, ale neříká, ze které úrovně (objekt, odstavec, rozložení, master nebo jiná úroveň) tento slot pochází.

Následující příklad načte prezentaci, prověří výplně tvarů i výplně částí textu, vytiskne každou konečnou RGB hodnotu a příslušnou barvu schématu a označí plné výplně, které nebudou sledovat změny barvy tématu:

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

Větev `NotDefined` poskytuje auditní seznam plných výplní, které nebudou reagovat na změny slotů barvy tématu. Přezkoumejte tyto objekty, když prezentace musí odpovídat nové paletě značky. Hlášená RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled spojen s tématem.

Objekty efektivního formátu jsou snímky. Po změně tématu prezentace, přepsání tématu nebo jakéhokoli zděděného formátování znovu zavolejte `GetEffective` a načtěte nový objekt `IFillFormatEffectiveData`, než budete porovnávat nebo hlásit barvy.

## **Čtení efektivních hodnot tématu**

Surová témata vám říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty vám říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Pro pozadí použijte [Background::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/background/geteffective/), pro výplň [FillFormat::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/geteffective/).

Následující příklad načte efektivní téma, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a srovnání. Pokud prozkoumáte jen [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_mastertheme/), můžete přehlédnout přepsání masteru, rozložení, snímku nebo tvaru, které mění finální vzhled.

## **Časté otázky**

**Ovlivňuje aplikace externího tématu všechny snímky v prezentaci?**

Ne. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) přepíše jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovají své stávající témata.

**Mohu použít téma na jediný snímek bez změny masteru?**

Ano. Použijte [IOverrideThemeManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ioverridethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále zdědit své stávající témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový master do cíle a klonujte snímek s tímto masterem pomocí [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/addclone/) a [ISlideCollection::AddClone()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/). Tím se master, rozložení a téma přenesou společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) pro snímek nebo rozložení tématu a odpovídající metody efektivních dat pro formátovací objekty, jako jsou [Background::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/background/geteffective/) a [FillFormat::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/geteffective/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepsání.