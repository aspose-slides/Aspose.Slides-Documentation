---
title: Správa témat prezentace v .NET
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/net/presentation-theme/
keywords:
- Téma PowerPointu
- Téma prezentace
- Téma snímku
- Nastavit téma
- Změnit téma
- Spravovat téma
- Externí téma
- THMX
- Barva tématu
- Další paleta
- Písmo tématu
- Styl tématu
- Efekt tématu
- PowerPoint
- OpenDocument
- Prezentace
- .NET
- C#
- Aspose.Slides
description: "Hlavní témata prezentací v Aspose.Slides pro .NET pro tvorbu, přizpůsobení a konverzi souborů PowerPoint s konzistentním brandováním."
---
## **Úvod**

Prezentace téma definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou si vědomy tématu, odkazuje na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je téma na úrovni prezentace dostupné přes vlastnost [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/masterthememanager/overridetheme/), rozvržení může přepsat zděděné téma pomocí [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), a jednotlivý snímek může udělat totéž. V praxi je efektivní téma pro snímek vyřešeno touto řadou dědičnosti: téma prezentace, přepsání masteru, přepsání rozvržení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s tématy: prohlížení tématu, změna barev a písem, kopírování nebo použití tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepsání.

## **Prohlédnutí tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/) vystavuje [ColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/fontscheme/) a [FormatScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/formatscheme/). Prohlédnutí těchto kolekcí před jejich úpravou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti tématu a uvádí, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prohlédněte master přiřazený ke snímku a použijte pracovní postup s efektivním tématem, který je ukázán později v tomto článku, pokud mohou existovat přepsání rozvržení nebo snímku.

## **Změna barev tématu**

Vyplněné objekty, čáry a text, které jsou si vědomy tématu, mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/). Když změníte odpovídající položku v [IColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyhodnoceny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, změna barvy tématu neovlivní.

Následující end-to-end příklad vytvoří tvar, který používá `Accent4`, změní barvu `Accent4` v tématu na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Protože obdélník zůstává propojen s `Accent4`, po změně tématu se jeho viditelná barva stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje přes [ColorTransformOperation](https://reference.aspose.com/slides/cs/net/aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.

**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, u pěti z nich použije luminanční transformace a výsledek uloží:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Tyto varianty zůstávají založeny na barvě tématu. Pokud se `Accent4` později změní, transformované barvy jsou přepočítány z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `IColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/) vystavuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty, které by se dynamicky převáděly z jedné formy do druhé.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Vlastnosti [FontScheme.Major](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/major/) a [FontScheme.Minor](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/minor/) tyto sady vystavují.

Identifikátory písem kompatibilních s PowerPointem lze použít při formátování textu:

* `+mn-lt` – tělo písma Latin (Minor Latin Font)
* `+mj-lt` – nadpis písma Latin (Major Latin Font)
* `+mn-ea` – tělo písma East Asian (Minor East Asian Font)
* `+mj-ea` – nadpis písma East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinské písmo tématu, a jeden řádek těla, který používá vedlejší latinské písmo tématu. Poté změní písma tématu a výsledek uloží:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Nadpis používá hlavní písmo a tělo textu používá vedlejší písmo. Text, který má explicitně nastavený název písma místo identifikátoru tématu, se automaticky nepřepne při změně schématu písem tématu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psaní systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlédnutí, přidání, nahrazení nebo odstranění těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmch v prezentacích viz [PowerPoint Fonts](/slides/cs/net/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití tématu**

Níže uvedené pracovní postupy řeší různé problémy související s tématy.

### **Použití externího tématu na snímky závislé na masteru**

Použijte [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/), když máte soubor tématu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation.Masters](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/masters/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/), a předávejte cestu k souboru tématu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master snímek založený na vybraném masteru.
1. Aplikuje externí téma na nový master.
1. Přiřadí nový master všem snímkům, které předtím závisely na vybraném masteru.
1. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/).

Následující příklad aplikuje externí téma na snímky, které závisí na prvním masteru, uloží prezentaci a znovu otevře výsledek:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Neplatné, poškozené nebo nepodporované téma může způsobit [PptxException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxexception/) nebo některou z jeho podtříd souvisejících s formátem. Ověřte cesty dodané uživateli, ošetřete selhání přístupu k souborovému systému a uložte prezentaci až po úspěšném aplikování tématu.

Přesunuty jsou jen snímky, které závisely na vybraném masteru. Snímky přiřazené k jiným masterům si ponechají své stávající mastery a témata. Barvy, písma, výplně, čáry, pozadí a efekty, které jsou si vědomy tématu, jsou vyhodnoceny vůči externímu tématu. Barvy, písma, výplně a další explicitní formátování přiřazené přímo mohou zůstávat nezměněny. Přepsání na úrovni rozvržení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Téma může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte potřebná písma, zpřístupněte je přes [vlastní zdroje písem](/slides/cs/net/custom-font/), nebo nakonfigurujte [nahrazování písem](/slides/cs/net/font-substitution/).

Toto je přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání tématu na úrovni rozvržení nebo snímku.

### **Použití různých externích témat v prezentaci s více mastery**

Když není předem známý relevantní master, získejte jej z reprezentativního snímku přes [ISlide.LayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/layoutslide/) a [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/masterslide/). Uložte původní reference masterů před aplikací jakýchkoli témat, protože každý volání vytvoří v prezentaci další master.

Následující příklad používá snímky ze dvou sekcí k nalezení jejich masterů a aplikuje na každou skupinu jiné externí téma:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

První volání postihne jen snímky, které závisí na `firstGroupMaster`, a druhé volání postihne jen snímky, které závisí na `secondGroupMaster`. Snímky patřící k jakémukoli jinému masteru nebudou přeformátovány.

### **Zachování zdrojového tématu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, naklonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/), poté naklonujte snímek pomocí [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) a naklonovaný master. Tím se přenesou master, jeho rozvržení a přidružené téma společně.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Toto je preferovaný postup, když musí zdrojový snímek v cílovém souboru vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Aplikace hodnot tématu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním masteru a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initfontschemefrom/) a [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initformatschemefrom/) zkopírují tři hlavní komponenty tématu do přepsání.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Tím se změní téma použité tímto snímkem bez změny tématu zděděného ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/clear/).

### **Aplikace přepsání tématu na rozvržení**

Přepsání na úrovni rozvržení se aplikuje na snímky, které používají dané rozvržení, pokud konkrétní snímek nemá své vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/layoutslidethememanager/) rozvržení:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Použijte téma na úrovni masteru nebo prezentace, když mnoho rozvržení a snímků má sdílet stejný základní design, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné formátování, a přepsání snímku jen pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje předvídání následných globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Výplně pozadí tématu jsou uloženy v [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint může ve svém UI nabízet více možností pozadí, než kolik výplňových definic je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazovanými styly.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.StyleIndex](https://reference.aspose.com/slides/cs/net/aspose.slides/background/styleindex/). `StyleIndex` používá `0` pro žádnou tematickou výplň; kladné hodnoty jsou reference na tématické styly pozadí. To se liší od indexování .NET kolekce přímo, kde `[0]` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad uvádí počet dostupných výplní pozadí, přiřadí tematickou referenci pozadí prvnímu masteru a uloží prezentaci:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Viditelný výsledek závisí na tématické položce, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna jen master pozadí nemusí tento snímek změnit. Použijte [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte `StyleIndex` jako nulový index kolekce. Také se vyhněte pevně zakódovanému číslu stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro konkrétní prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/net/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátu tématu obsahuje samostatné kolekce [FillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/linestyles/) a [EffectStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/effectstyles/). Typické kancelářské témata často obsahují tři hlavní položky stylů, které vizuálně odpovídají subtilnímu, střednímu a intenzivnímu formátování, ale kód by měl prohlížet každou kolekci místo předpokladu pevného počtu.

![Subtilní, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Když v C# přistupujete k těmto kolekcím, index kolekce je nulový: `[0]` je první uložený styl a `[2]` je třetí. Indexy stylových referencí tvaru jsou samostatný koncept, vystavený přes [IShapeStyle](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylů existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Pro tvary, které tyto sloty používají, se první styl čáry tématu stane červeným, třetí styl výplně tématu se stane plnou lesní zelení a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každý tvar odkazuje a zda přímé formátování nepřepíše téma.

![Styly efektů tématu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Určení, zda používá efektivní plná výplň barvu tématu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozvržení, masteru, stylu tématu nebo jiné úrovně formátování. Zavolejte [IFillFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformat/geteffective/), abyste vyřešili tuto hierarchii do neměnného [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformateffectivedata/). Nejprve zkontrolujte [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformateffectivedata/filltype/). Pouze pokud je `FillType.Solid`, měli byste číst vlastnosti pevné výplně.

Pro pevnou výplň [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) vrací konečnou vykreslenou RGB hodnotu po dědičnosti, vyhledání v tématu a aplikaci transformací barev. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/), např. `Text1` nebo `Accent6`. Hodnota `SchemeColor.NotDefined` znamená, že efektivní pevná výplň není založena na schématu barvy. V pracovním postupu, kde jsou výplně buď barvy tématu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Nekombinujte jen lokální hodnotu [IColorFormat.SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/icolorformat/schemecolor/) pro klasifikaci výplně. Například část textu může nemít lokálně definovanou barvu schématu, takže její lokální hodnota je `NotDefined`, zatímco její efektivní výplň zdědí barvu tématu a vyřeší se na `Text1` nebo `Accent6`. Naopak `SolidFillSchemeColor` vám říká, který logický slot tématu vytvořil efektivní barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozvržení, masteru nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, provede audit výplní tvarů i výplní částí textu, vytiskne každou konečnou RGB hodnotu a přidruženou barvu schématu a označí pevné výplně, které nebudou sledovat změny barvy tématu:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

Větev `NotDefined` poskytuje seznam pevné výplně, která nebudou reagovat na změny slotů barvy tématu. Přezkoumejte tyto objekty, když prezentace musí sledovat novou paletu značky. Reportovaná RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled spojen s tématem.

Objekty s efektivním formátem jsou snímky. Po změně tématu prezentace, přepsání tématu nebo jakéhokoli zděděného formátování znovu zavolejte `GetEffective` a načtěte nový objekt `IFillFormatEffectiveData` před porovnáním nebo hlášením barev.

## **Čtení efektivních hodnot tématu**

Surové objekty tématu vám říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Pro pozadí použijte [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/), a pro výplň [FillFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/geteffective/).

Následující příklad načte efektivní téma, pozadí a první výplň tvaru ze snímku:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/), můžete přehlédnout master, rozvržení, snímek nebo přepsání tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivňuje použití externího tématu všechny snímky v prezentaci?**

Ne. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) přiřadí jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si ponechají své stávající témata.

**Mohu aplikovat téma na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky i nadále zdědí své existující témata.

**Jaký je nejn bezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu naklonujte zdrojový master do cíle a klonujte snímek s tímto masterem pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/) a [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/). Tím se master, rozvržení a téma přenesou společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) pro téma snímku nebo rozvržení a odpovídající metody efektivních dat pro objekty formátu, jako jsou [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/) a [FillFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/geteffective/). Tyto API vracejí vyřešené hodnoty po aplikaci dědičnosti a přepsání.