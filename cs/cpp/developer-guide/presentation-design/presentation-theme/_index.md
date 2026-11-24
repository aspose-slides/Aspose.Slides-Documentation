---
title: Správa témat prezentace v C++
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/cpp/presentation-theme/
keywords:
- téma PowerPoint
- téma prezentace
- téma snímku
- nastavit téma
- změnit téma
- spravovat téma
- externí téma
- THMX
- barva tématu
- dodatečná paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Hlavní témata prezentace v Aspose.Slides pro C++ pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Téma prezentace definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou sirotky tématu, se odkazuje na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je téma na úrovni prezentace dostupné přes [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), zatímco rozložení nebo jednotlivý snímek může použít [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). V praxi je efektivní téma pro snímek řešeno touto dědickou řetězci: téma prezentace, přepsání masteru, přepis rozložení a přepis snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s tématy: prohlédnutí tématu, změna barev a písem, kopírování nebo použití tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepisů.

## **Prohlédnutí tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) vystavuje metody [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) a [get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Prohlédnutí těchto kolekcí před jejich změnou je obzvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se může lišit.

Následující příklad načte hlavní vlastnosti tématu a vykáže, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prohlédněte master přiřazený ke snímku a použijte pracovní postup s efektivním tématem uvedený později v tomto článku, když mohou být přítomny přepsání rozložení nebo snímku.

## **Změna barev tématu**

Výplně, čáry a text sirotky tématu mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/). Když změníte odpovídající položku v [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyřešeny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se změna barvy tématu neprojeví.

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

Protože obdélník zůstává spojený s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` už tento výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje přes [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.

**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich použije transformace jasu a uloží výsledek:

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

### **Mapování hodnot `SchemeColor` do slotů `IColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) vystavuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty, které by se dynamicky převáděly z jedné podoby do druhé.

## **Změna písem tématu**

Schéma písma tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu pro tělo textu. Metody [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) a [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) tyto sady vystavují.

Identifikátory písem kompatibilních s PowerPoint lze použít při formátování textu:

* `+mn‑lt` – Tělo písma Latin (Minor Latin Font)
* `+mj‑lt` – Nadpis písma Latin (Major Latin Font)
* `+mn‑ea` – Tělo písma Východní Asie (Minor East Asian Font)
* `+mj‑ea` – Nadpis písma Východní Asie (Major East Asian Font)
* `+mn‑cs` – Tělo písma Složitého skriptu (Minor Complex Script Font)
* `+mj‑cs` – Nadpis písma Složitého skriptu (Major Complex Script Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo tématu a jeden řádek těla používající vedlejší latinské písmo tématu. Poté změní písma tématu a uloží výsledek:

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

Nadpis následuje hlavní písmo a tělo textu následuje vedlejší písmo. Text, který má explicitně uvedený název písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma písem tématu.

Hlavní a vedlejší sbírky písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlédnutí, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písech prezentace viz [PowerPoint Fonts](/slides/cs/cpp/powerpoint-fonts/).
{{% /alert %}}

### **Řešení odkazů na písma tématu**

Při prohlížení textu může [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) obsahovat odkaz na téma, např. `+mn‑lt`, místo názvu rodiny písma. Zavolejte [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) s vhodnými [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) k vyřešení tohoto odkazu. Předpony `+mj` a `+mn` volí hlavní a vedlejší sadu písem; přípony `-lt`, `-ea` a `-cs` volí jejich latinské, východoasijské a složité skripty.

Získejte efektivní téma pomocí [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) na objektu, jehož téma se vztahuje k prohlíženému textu. Pro běžný text na snímku použijte `slide->CreateThemeEffective()`, aby kontext zahrnoval děděné téma snímku a místní přepsání. Při prohlížení rozložení nebo samotného masteru použijte jeho vlastní efektivní téma. Nepředpokládejte, že téma prvního masteru platí pro každý snímek.

Následující příklad vytvoří část textu, která explicitně odkazuje na vedlejší latinské písmo. Inicializuje schéma písma snímku pomocí [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) a nastaví hlavní a vedlejší latinské rodiny na `Arial` a `Calibri`, což činí výsledek reprodukovatelný bez vstupního souboru.

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

Výstup je `+mn‑lt -> Calibri` následováno `Verdana -> Verdana`. Uložený odkaz zůstává beze změny, zatímco explicitní název rodiny je vrácen tak, jak je. Kdyby část použila `+mj‑lt`, vyřešilo by se to na `Arial` v tomto tématu.

Řešení odkazu tématu identifikuje rodinu písma určenou tématem. Nekontroluje dostupnost písma ani neurčuje soubor písma, který je nakonec použit po substituci nebo záložním vykreslování. Viz [Font Selection Sequence](/slides/cs/cpp/font-selection-sequence/) a [Font Substitution](/slides/cs/cpp/font-substitution/) pro tyto samostatné kroky.

## **Kopírování nebo použití tématu**

Níže uvedené pracovní postupy řeší různé problémy související s tématy.

### **Použít externí téma na snímky závislé na masteru**

Použijte [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) když máte soubor tématu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/), a předávejte cestu k souboru tématu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master snímku založený na vybraném masteru.
1. Aplikuje externí téma na nový master.
1. Přiřadí nový master všem snímkům, které předtím závisely na vybraném masteru.
1. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/).

Následující příklad aplikuje externí téma na snímky, které závisí na prvním masteru, a uloží prezentaci:

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

Neplatné, poškozené nebo nepodporované téma může vyvolat [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) nebo některou z jeho podtříd souvisejících s formátem. Ověřte cesty dodané uživateli, ošetřete selhání přístupu k souborovému systému a uložte prezentaci až po úspěšné aplikaci tématu.

Pouze snímky, které závisely na vybraném masteru, jsou přemapovány. Snímky přiřazené k jiným masterům zachovávají své existující mastery a témata. Barvy, písma, výplně, čáry, pozadí a efekty sirotky tématu jsou řešeny vůči externímu tématu. Přímě přiřazené barvy, písma, výplně a další explicitní formátování mohou zůstat nezměněny. Přepsání na úrovni rozložení a snímku může také mít přednost před hodnotami děděnými z nového masteru.

Téma může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytněte je přes [custom font sources](/slides/cs/cpp/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/cpp/font-substitution/).

Jedná se o přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepisů tématu na úrovni snímku či rozložení.

### **Použít různá externí témata v prezentaci s více mastery**

Když není předem známý relevantní master, získejte jej z reprezentativního snímku pomocí [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) a [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). Uložte původní odkazy na mastery před aplikací jakýchkoli témat, protože každý volání vytvoří další master v prezentaci.

Následující příklad použije snímky ze dvou sekcí k určení jejich masterů a aplikuje na každou skupinu jiné externí téma:

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

První volání ovlivní jen snímky, které závisely na `firstGroupMaster`, a druhé volání ovlivní jen snímky, které závisely na `secondGroupMaster`. Snímky patřící k jakémukoliv jinému masteru nebudou přeformátovány.

### **Zachovat zdrojové téma při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, klonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/), poté klonujte snímek pomocí [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) a klonovaný master. Tím se přenesou master, jeho rozvržení i související téma.

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

Toto je preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Použít hodnoty tématu na existujícím snímku**

Pokud cílový snímek musí zůstat na svém současném masteru a rozložení, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) a [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) zkopírují tři hlavní komponenty tématu do přepsání.

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

Tím se změní téma používané tímto snímkem, aniž by se změnilo téma děděné ostatními snímky. Pro odebrání místního přepsání a návrat k děděným hodnotám zavolejte [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/).

### **Použít přepsání tématu na rozložení**

Přepsání na úrovni rozložení se vztahuje na snímky, které používají toto rozložení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) rozložení:

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

Použijte téma na úrovni masteru nebo prezentace, když mají mnoho rozložení a snímků sdílet stejný základní design, přepsání rozložení, když jedna rodina rozložení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání pozdějších globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Výplně pozadí tématu jsou uloženy v [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint může v UI nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` používá `0` pro žádnou tématickou výplň; kladné hodnoty jsou odkazy na téma stylu pozadí. To se liší od indexování C++ kolekce přímo pomocí `idx_get(0)`, kde `0` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vykáže dostupný počet výplní pozadí, přiřadí odkaz na tématické pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na tématické položce, na kterou odkazuje master, a na jakýchkoli přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze master pozadí nemusí tento snímek změnit. Použijte [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) pokud potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Upozornění" %}}
Nevnímejte `StyleIndex` jako nulově založený index kolekce. Také se vyhněte tvrdému kódování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/cpp/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátování tématu obsahuje samostatné kolekce [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/) a [FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typické kancelářské témata často obsahují tři hlavní položky stylu, které vizuálně odpovídají subtilnímu, střednímu a intenzivnímu formátování, ale kód by měl kontrolovat každou kolekci místo předpokladu pevného počtu.

![Subtilní, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Když v C++ přistupujete k těmto kolekcím, index kolekce je nulově založený: `idx_get(0)` je první uložený styl a `idx_get(2)` je třetí. Indexy odkazů stylu tvaru jsou odlišný koncept, vystavený přes [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/). Modifikace stylu tématu ovlivní tvary, které na něj odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí styl výplně tématu se stane plnou lesní zelenou a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každý tvar odkazuje a zda přímé formátování nepřepisuje téma.

![Styly efektů tématu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Výběr výplní a stylů čar tématu pro tvar**

Tvar může nezávisle zvolit výplň a obrys pomocí [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) a [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/). Pro oba nastavitela index `1` vybírá první položku ve odpovídající kolekci tématu (`idx_get(0)`) a index `2` vybírá druhou položku.

Následující příklad nastaví dva styly výplně (zlatý a nebesky modrý) a dva styly čar (tmavě modrá 6 pt a tmavě červená 12 pt) ve výchozím tématu nové prezentace. Uloží snímek ve třech fázích, abyste mohli porovnat výsledky v PowerPointu.

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

| Počáteční styly | Změnit pravý obrys | Upravit první výplň tématu |
|:---:|:---:|:---:|
| ![Zlaté a nebesky modré obdélníky s odpovídajícími tenkými tmavě modrými obrysy](theme-style-initial.png) | ![Nebešsky modrý obdélník nyní má silný tmavě červený obrys](theme-style-line-changed.png) | ![Levý obdélník je nyní zelený a oba obrysy zůstávají nezměněny](theme-style-fill-changed.png) |

Výběr jiného stylu čáry mění jen obrys pravého obdélníku. Úprava první výplně tématu aktualizuje každý tvar, který ji používá. Zde se pouze levý obdélník změní na zelenou.

Na existujícím tvaru může lokální barva výplně, barva čáry nebo šířka čáry přepsat tuto část stylu tématu. Pokud změna indexu stylu nemá viditelný efekt, zkontrolujte [direct formatting](/slides/cs/cpp/shape-formatting/) tvaru.

## **Určení, zda efektivní plná výplň používá barvu tématu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozložení, masteru, stylu tématu nebo jiné úrovně formátování. Zavolejte [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) k rozložení této hierarchie do neměnného [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/). Nejprve zkontrolujte [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Pouze pokud je `FillType::Solid`, byste měli číst vlastnosti plné výplně.

Pro plnou výplň [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) vrací finální RGB hodnotu po dědičnosti, vyhledání tématu a aplikaci transformací barev. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/), např. `Text1` nebo `Accent6`. Hodnota `SchemeColor::NotDefined` znamená, že efektivní plná výplň není založena na schématické barvě. V pracovním postupu, kde jsou výplně buď barvy tématu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Nevyužívejte jen lokální hodnotu [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/) k zařazení výplně. Například část textu může mít žádnou lokálně definovanou schématickou barvu, takže její lokální hodnota je `NotDefined`, zatímco její efektivní výplň dědí barvu tématu a vyřeší se na `Text1` nebo `Accent6`. Naopak `get_SolidFillSchemeColor` vám říká, který logický slot tématu vytvořil efektivní barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozložení, masteru nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, auditne výplně tvarů i výplně částí textu, vytiskne každou finální RGB hodnotu a související schématickou barvu a označí plné výplně, které nebudou sledovat změny barvy tématu:

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

Větev `NotDefined` poskytuje auditní seznam plných výplní, které nebudou reagovat na změny v tématických slotech. Přezkoumejte tyto objekty, když musí prezentace následovat novou firemní paletu. Vykázaná RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled spojen s tématem.

Objekty s efektivním formátem jsou snímky. Po změně tématu prezentace, přepsání tématu nebo jakéhokoliv děděného formátování, znovu zavolejte `GetEffective` a přečtěte nový objekt `IFillFormatEffectiveData` před porovnáním nebo hlášením barev.

## **Čtení efektivních hodnot tématu**

Surová objektová témata vám říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty vám říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a místních přepisů. Pro snímek zavolejte [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Pro pozadí použijte [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), a pro výplň [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/), můžete přehlédnout master, rozložení, snímek nebo přepsání tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivňuje aplikace externího tématu každý snímek v prezentaci?**

Ne. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) přemapuje jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery zachovávají své existující témata.

**Mohu použít téma na jediný snímek bez změny masteru?**

Ano. Použijte [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí svá existující témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový master do cílové prezentace a klonujte snímek s tímto masterem pomocí [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) a [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). Tím se zachová master, rozložení i téma.

**Jak mohu vidět efektivní hodnoty po dědičnosti a přepsání?**

Použijte [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) pro snímek nebo rozložení a odpovídající metody efektivních dat pro formátovací objekty, jako [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) a [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). Tyto API vracejí vyřešené hodnoty po aplikaci dědičnosti a přepsání.