---
title: Spravovat motivy prezentace v C++
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/cpp/presentation-theme/
keywords:
- Motiv PowerPoint
- Motiv prezentace
- Motiv snímku
- Nastavit motiv
- Změnit motiv
- Spravovat motiv
- Barva motivu
- Dodatečná paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- Prezentace
- C++
- Aspose.Slides
description: "Hlavní motivy prezentace v Aspose.Slides pro C++ pro vytváření, přizpůsobování a převod souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Prezentační motiv definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou si vědomy motivu, se odkazuje na tyto sdílené definice místo uložení každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je motiv na úrovni prezentace dostupný přes [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_mastertheme/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Master může přepsat motiv prezentace pomocí [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), zatímco rozložení nebo jednotlivý snímek může použít [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). V praxi je efektivní motiv pro snímek vyřešen pomocí tohoto řetězce dědičnosti: motiv prezentace, přepsání masteru, přepsání rozložení a přepsání snímku.

![Komponenty motivu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s motivem: prohlédnout motiv, změnit barvy a písma, zkopírovat nebo použít motiv, aktualizovat styly pozadí a efektů a přečíst efektivní hodnoty po vyřešení dědičnosti a přepisů.

## **Prohlédnutí motivu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/mastertheme/) poskytuje metody [get_ColorScheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) a [get_FormatScheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se mohou lišit.

Následující příklad načte hlavní vlastnosti motivu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v motiv uložených:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejný efektivní motiv. Prohlédněte master přiřazený ke snímku a použijte pracovní postup efektivního motivu uvedený později v tomto článku, pokud mohou být přítomna přepsání rozložení nebo snímku.

## **Změna barev motivu**

Vyplněná místa, čáry a text, které jsou si vědomy motivu, mohou odkazovat na logickou barvu z enumerace [SchemeColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ IColorScheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou rozděleny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se při aktualizaci barvy motivu nic nezmění.

Následující end‑to‑end příklad vytvoří tvar používající `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává spojen s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použití barev z dodatečné palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu aplikací transformačních operací. Aspose.Slides tato transformace exponuje prostřednictvím [ColorTransformOperation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy vygenerované z dodatečné palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.

**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich aplikuje transformaci luminance a výsledek uloží:

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

Tyto varianty zůstávají založeny na barvě motivu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `IColorScheme`**

Enumerace [SchemeColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/icolorscheme/) vystavuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevně dané:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejedná se o hodnoty dynamicky převáděné z jedné formy do druhé.

## **Změna písem motivu**

Schéma písem motivu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu pro tělo textu. Metody [FontScheme::get_Major()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/fontscheme/get_major/) a [FontScheme::get_Minor()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/fontscheme/get_minor/) tyto sady vystavují.

Identifikátory písem kompatibilních s PowerPoint mohou být použity při formátování textu:

* `+mn-lt` – tělo písma Latin (Minor Latin Font)
* `+mj-lt` – nadpis písma Latin (Major Latin Font)
* `+mn-ea` – tělo písma East Asian (Minor East Asian Font)
* `+mj-ea` – nadpis písma East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo motivu a jeden řádek těla používající vedlejší latinské písmo. Poté změní písma motivu a výsledek uloží:

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

Nadpis následuje hlavní písmo a tělo textu následuje vedlejší písmo. Text, který má explicitní název písma místo identifikátoru motivu, se automaticky nepřepne, když se změní schéma písem motivu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlédnutí, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmenech v prezentacích viz [PowerPoint Fonts](/slides/cs/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití motivu**

Existují dva běžné pracovní postupy a řeší odlišné problémy.

### **Zachování zdrojového motivu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, naklonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/addclone/), poté naklonujte snímek pomocí [ISlideCollection::AddClone()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) a naklonovaného masteru. Tím se přenese master, jeho rozložení i související motiv.

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

Toto je preferovaný postup, když zdrojový snímek musí v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Použití hodnot motivu na existující snímek**

Pokud musí cílový snímek zůstat na svém současném masteru a rozložení, inicializujte přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) a [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) zkopírují tři hlavní komponenty motivu do přepsání.

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

Tím se změní motiv používaný tímto snímkem, aniž by se změnil motiv děděný ostatními snímky. Pro odebrání lokálního přepsání a návrat k děděným hodnotám zavolejte [OverrideTheme::Clear()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/overridetheme/clear/).

### **Použití přepsání motivu na rozložení**

Přepsání na úrovni rozložení se vztahuje na snímky, které používají toto rozložení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [IOverrideThemeManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ioverridethememanager/) rozložení:

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

Použijte motiv na úrovni masteru nebo prezentace, když má mnoho rozložení a snímků sdílet stejný základní design, přepsání rozložení, když jedna rodina rozložení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání pozdějších globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background::get_StyleIndex()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` používá `0` pro žádnou tematickou výplň; kladné hodnoty jsou odkazy na styl pozadí motivu. To se liší od indexování C++ kolekce přímo pomocí `idx_get(0)`, kde `0` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše dostupný počet výplní pozadí, přiřadí tematický odkaz na pozadí k prvnímu masteru a prezentaci uloží:

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

Viditelný výsledek závisí na motivové položce, na kterou master odkazuje, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/background/geteffective/), když potřebujete znát konečné pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Varování" %}}
Nevnímejte `StyleIndex` jako nulově‑indexovaný index kolekce. Také se vyhněte hardcodování čísla stylu z jednoho souboru s předpokladem, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/cpp/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátů motivu obsahuje samostatné kolekce [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/formatscheme/get_linestyles/) a [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typické Office motivy často obsahují tři hlavní položky stylu, které vizuálně odpovídají subtilním, středním a intenzivním formátům, ale kód by měl kontrolovat každou kolekci místo předpokladu pevného počtu.

![Subtilní, střední a intenzivní efekty motivu aplikované na stejný tvar](presentation-design_10.png)

Když v C++ přistupujete k těmto kolekcím, index kolekce je nulově‑založený: `idx_get(0)` je první uložený styl a `idx_get(2)` je třetí. Indexy referencí stylu tvaru jsou samostatný koncept, vystavený prostřednictvím [IShapeStyle](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapestyle/). Změna stylu motivu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylu existují, změní první styl čáry, třetí styl výplně, povolí vnější stín ve třetím stylu efektu a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry motivu stane červeným, třetí styl výplně motivu se změní na plnou lesní zelenou a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každá forma používá a zda přímé formátování nepřepisuje motiv.

![Styly efektů motivu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtení efektivních hodnot motivu**

Surové objekty motivu vám řeknou, co je definováno na konkrétní úrovni. Efektivní hodnoty vám řeknou, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Pro pozadí použijte [Background::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/background/geteffective/), a pro výplň [FillFormat::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/geteffective/).

Následující příklad načte efektivní motiv, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnávání. Pokud prohlížíte pouze [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_mastertheme/), můžete přehlédnout přepsání na úrovni masteru, rozložení, snímku nebo tvaru, které mění konečný vzhled.

## **Často kladené otázky**

**Mohu použít motiv na jediný snímek bez změny masteru?**

Ano. Použijte [IOverrideThemeManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ioverridethememanager/) snímku a inicializujte jeho motiv přepsání. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále dědit své existující motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu naklonujte zdrojový master do cíle a naklonujte snímek s tímto masterem pomocí [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/addclone/) a [ISlideCollection::AddClone()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/). Tím se udrží master, rozložení i motiv společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) pro motiv snímku nebo rozložení a odpovídající metody efektivních dat pro formátové objekty, např. [Background::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/background/geteffective/) a [FillFormat::GetEffective()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/geteffective/). Tyto API vrací rozřešené hodnoty po aplikaci dědičnosti a přepisů.