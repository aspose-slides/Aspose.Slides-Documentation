---
title: Správa motivů prezentací v .NET
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/net/presentation-theme/
keywords:
- Motiv PowerPoint
- Motiv prezentace
- Motiv snímku
- Nastavit motiv
- Změnit motiv
- Spravovat motiv
- Externí motiv
- THMX
- Barva motivu
- Doplňková paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- Prezentace
- .NET
- C#
- Aspose.Slides
description: "Hlavní motivy prezentací v Aspose.Slides pro .NET pro vytváření, přizpůsobování a konverzi souborů PowerPoint s jednotným brandováním."
---
## **Úvod**

Motiv prezentace definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objekty citlivé na motiv odkazují na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je motiv na úrovni prezentace dostupný prostřednictvím vlastnosti [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Hlavní snímek (master) může přepsat motiv prezentace pomocí [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/), rozvržení může přepsat svůj zděděný motiv pomocí [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), a jednotlivý snímek může učinit totéž. V praxi je účinný motiv pro snímek vyřešen touto řetězovou dědičností: motiv prezentace, přepsání hlavního snímku, přepsání rozvržení a přepsání snímku.

![Komponenty motivu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Nižší sekce ukazují nejčastější pracovní postupy s motivy: prohlédnutí motivu, změnu barev a písem, zkopírování nebo použití motivu, aktualizaci stylů pozadí a efektů a načtení účinných hodnot po vyřešení dědičnosti a přepsání.

## **Prohlédnout motiv**

Objekt [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) odhaluje [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) a [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/). Prohlížení těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti motivu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v motivu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejný účinný motiv. Prohlédněte master spojený se snímkem a použijte pracovní postup efektivního motivu uvedený později v tomto článku, pokud mohou být přítomna přepsání rozvržení nebo snímku.

## **Změna barev motivu**

Motivově citlivé výplně, čáry a text mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/). Když změníte odpovídající položku v motivu [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou přepočítány podle nové hodnoty. Objekty, které používají přímou RGB barvu, nejsou změněny aktualizací barvy motivu.

Následující end-to-end příklad vytvoří tvar, který používá `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne účinnou barvu výplně:

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

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již tuto výplň neovlivní.

### **Použít barvy z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu aplikací transformací barev. Aspose.Slides tuto transformaci zpřístupňuje přes [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich aplikuje luminanční transformace a výsledek uloží:

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

Tyto varianty zůstávají založeny na barvě motivu. Pokud se později změní `Accent4`, transformované barvy jsou přepočítány z nové hodnoty `Accent4`.

### **Mapovat hodnoty `SchemeColor` do slotů `IColorScheme`**

Seznam [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) odhaluje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapa je pevná:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejsou to hodnoty, které by se dynamicky převáděly z jedné podoby do druhé.

## **Změna fontů motivu**

Schéma fontů motivu obsahuje hlavní sadu fontů pro nadpisy a vedlejší sadu fontů pro tělo textu. Vlastnosti [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) a [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) tyto sady odhalují.

Identifikátory fontů kompatibilní s PowerPoint lze použít při formátování textu:

* `+mn-lt` – tělo písmo Latin (Minor Latin Font)
* `+mj-lt` – nadpis písmo Latin (Major Latin Font)
* `+mn-ea` – tělo písmo East Asian (Minor East Asian Font)
* `+mj-ea` – nadpis písmo East Asian (Major East Asian Font)
* `+mn-cs` – tělo písmo Complex Script (Minor Complex Script Font)
* `+mj-cs` – nadpis písmo Complex Script (Major Complex Script Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní Latin font motivu, a jeden řádek těla, který používá vedlejší Latin font motivu. Poté změní fonty motivu a výsledek uloží:

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

Nadpis se řídí hlavním fontem a tělo textu vedlejším fontem. Text, který má explicitní název fontu místo identifikátoru motivu, se automaticky nepřepne, když se změní schéma fontů motivu.

Hlavní a vedlejší kolekce fontů mohou také obsahovat mapování fontů pro jednotlivé písmo‑systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlížení, přidání, nahrazení nebo odebrání těchto mapování viz [Script-Specific Theme Fonts](/slides/cs/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o fontech v prezentacích viz [Písma PowerPoint](/slides/cs/net/powerpoint-fonts/).
{{% /alert %}}

### **Vyřešit odkazy na fonty motivu**

Při inspekci textu může [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) obsahovat odkaz na motiv jako `+mn-lt` místo názvu rodiny písma. Zavolejte [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) s odpovídajícím [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/), aby se odkaz vyřešil. Předpony `+mj` a `+mn` vybírají hlavní a vedlejší sady fontů; přípony `-lt`, `-ea` a `-cs` vybírají jejich Latin, East Asian a Complex Script fonty.

Získejte efektivní motiv pomocí [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) na objektu, jehož motiv se vztahuje k inspektovanému textu. Pro běžný text na snímku použijte `slide.CreateThemeEffective()`, aby kontext zahrnoval zděděný motiv snímku a lokální přepsání. Při inspekci rozvržení nebo samotného masteru použijte jeho vlastní efektivní motiv. Nepředpokládejte, že motiv prvního masteru se vztahuje na každý snímek.

Následující příklad vytvoří část textu, která explicitně odkazuje na vedlejší Latin font. Inicializuje schéma fontů snímku pomocí [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) a nastaví hlavní a vedlejší Latin rodiny na `Arial` a `Calibri`, což umožní reprodukovat výsledek bez vstupního souboru.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

Výstup je `+mn-lt -> Calibri` následovaný `Verdana -> Verdana`. Uložený odkaz zůstává nezměněn, zatímco explicitní název rodiny je vrácen tak, jak je. Kdyby část použila `+mj-lt`, rozložila by se na `Arial` v tomto motivu.

Vyřešení odkazu na motiv identifikuje rodinu fontu specifikovanou motivem. Nekontroluje dostupnost fontu ani neurčuje, který soubor fontu je nakonec použit po nahrazení nebo fallbacku glyfů během vykreslování. Viz [Font Selection Sequence](/slides/cs/net/font-selection-sequence/) a [Font Substitution](/slides/cs/net/font-substitution/) pro tyto samostatné kroky.

## **Kopírování nebo použití motivu**

Níže uvedené pracovní postupy řeší různé problémy související s motivy.

### **Použít externí motiv na snímky závislé na Masteru**

Použijte [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/), když máte soubor motivu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/), a předávejte cestu k souboru motivu metodě.

Metoda provádí následující operace:

1. Vytvoří nový hlavní snímek na základě vybraného masteru.  
1. Použije externí motiv na nový master.  
1. Přiřadí nový master všem snímkům, které dříve závisely na vybraném masteru.  
1. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/).

Následující příklad použije externí motiv na snímky, které závisí na prvním masteru, uloží prezentaci a výsledek znovu otevře:

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

Neplatný, poškozený nebo nepodporovaný motiv může vyvolat [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) nebo jeden z jeho formátově souvisejících podtříd. Ověřte cesty dodané uživateli, ošetřete selhání přístupu k souborovému systému a uložte prezentaci až po úspěšném aplikování motivu.

Pouze snímky, které závisely na vybraném masteru, jsou přeřazeny. Snímky spojené s jinými mastery si zachovají své stávající mastery a motivy. Motivu‑citlivé barvy, fonty, výplně, čáry, pozadí a efekty jsou řešeny proti externímu motivu. Barvy, fonty, výplně a další explicitní formátování přiřazené přímo mohou zůstat nezměněny. Přepsání na úrovni rozvržení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Motiv může odkazovat na fonty, které nejsou v prostředí běhu k dispozici. Pro konzistentní vykreslování a export nainstalujte požadované fonty, poskytněte je přes [custom font sources](/slides/cs/net/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/net/font-substitution/).

Jedná se o přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání motivu na úrovni snímku nebo rozvržení.

### **Použít různé externí motivy v prezentaci s více Mastery**

Když není relevantní master znám předem, získejte jej z reprezentativního snímku pomocí [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) a [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/). Uložte původní odkazy na master před aplikací jakýchkoli motivů, protože každé volání vytvoří v prezentaci další master.

Následující příklad použije snímky ze dvou sekcí k určení jejich masterů a na každou skupinu aplikuje jiný externí motiv:

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

První volání ovlivní jen snímky, které závisely na `firstGroupMaster`, a druhé volání jen snímky, které závisely na `secondGroupMaster`. Snímky patřící k jakémukoli jinému masteru nebudou přeformátovány.

### **Zachovat zdrojový motiv při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní vzhled, klonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/), poté klonujte snímek pomocí [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) a klonovaný master. Tím se přenese master, jeho rozvržení i související motiv společně.

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

Jedná se o preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, fonty, pozadí a efekty řízené motivem.

### **Použít hodnoty motivu na existujícím snímku**

Pokud má cílový snímek zůstat na svém aktuálním masteru a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/) a [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) zkopírují tři hlavní komponenty motivu do přepsání.

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

Tím se změní motiv použité na tomto snímku, aniž by se změnil motiv zděděný ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/).

### **Použít přepsání motivu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky, které používají toto rozvržení, ledaže by konkrétní snímek měl vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/):

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

Použijte motiv na úrovni masteru nebo prezentace, když mnoho rozvržení a snímků má sdílet stejný základní design, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje následné globální změny motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPoint pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/). `StyleIndex` používá `0` pro žádnou motivovou výplň; kladné hodnoty jsou odkazy na motivové styly pozadí. To se liší od indexování .NET kolekce přímo, kde `[0]` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

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

Viditelný výsledek závisí na položce motivu, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/), když potřebujete znát konečné pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte `StyleIndex` jako index kolekce začínající nulou. Také se vyhněte hard‑kodování čísla stylu z jednoho souboru a předpokladu, že má stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Pozadí prezentace](/slides/cs/net/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátu motivu obsahuje samostatné kolekce [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/) a [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/). Typické kancelářské motivy často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl prohlížet každou kolekci místo předpokladu pevného počtu.

![Jemné, střední a intenzivní efekty motivu aplikované na stejný tvar](presentation-design_10.png)

Když v C# přistupujete k těmto kolekcím, index kolekce začíná nulou: `[0]` je první uložený styl a `[2]` je třetí. Indexy odkazů stylu tvaru jsou samostatný koncept, odhalený přes [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/). Úprava stylu motivu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry motivu změní na červenou, třetí styl výplně motivu se změní na plnou lesní zelenou a třetí styl efektu získá vnější stín s odstupem 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každý tvar odkazuje a zda přímé formátování přepíše motiv.

![Styly efektů motivu po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Vybrat výplň a čáru motivu pro tvar**

Tvar může nezávisle vybrat výplň i obrys pomocí [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) a [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/). Pro obě vlastnosti index `1` vybírá první položku v odpovídající kolekci motivu (`FillStyles[0]` nebo `LineStyles[0]`) a index `2` vybírá druhou položku.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| Počáteční styly | Změna pravého obrysu | Úprava první výplně motivu |
|:---:|:---:|:---:|
| ![Zlaté a nebe-modré obdélníky s odpovídajícími tenkými tmavě modrými obrysy](theme-style-initial.png) | ![Nebe-modrý obdélník má nyní silný tmavě červený obrys](theme-style-line-changed.png) | ![Levý obdélník je nyní zelený a oba obrysy zůstaly nezměněny](theme-style-fill-changed.png) |

Výběr jiného stylu čáry změní pouze obrys pravého obdélníku. Úprava první výplně motivu aktualizuje každý tvar, který ji používá. Zde se pouze levý obdélník změní na zelený.

Na existujícím tvaru může lokální barva výplně, barva čáry nebo šířka čáry přepsat tuto část motivového stylu. Pokud změna indexu stylu nemá viditelný efekt, zkontrolujte [direct formatting](/slides/cs/net/shape-formatting/).

## **Zjistit, zda efektivní plná výplň používá barvu motivu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozvržení, masteru, motivového stylu nebo jiné úrovně formátování. Zavolejte [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) pro převod této hierarchie na neměnná data [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/). Nejprve zkontrolujte [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/). Pouze když je `FillType.Solid`, čtěte vlastnosti pevné výplně.

Pro pevnou výplň [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) vrací finální RGB hodnotu po dědičnosti, vyhledání motivu a aplikaci transformací barev. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/), například `Text1` nebo `Accent6`. Hodnota `SchemeColor.NotDefined` znamená, že efektivní pevná výplň není založena na schématické barvě. V pracovním postupu, kde jsou výplně buď barvy motivu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Nepoužívejte lokální hodnotu [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) samotnou k zařazení výplně. Například část textu může nemít lokálně definovanou schématickou barvu, takže její lokální hodnota je `NotDefined`, zatímco její efektivní výplň dědí barvu motivu a rozkládá se na `Text1` nebo `Accent6`. Naopak `SolidFillSchemeColor` vám říká, který logický slot motivu vytvořil efektivní barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozvržení, masteru nebo jiné úrovně hierarchie formátování.

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

Větve `NotDefined` poskytují seznam pevné výplně, která nebude reagovat na změny v motivech. Projděte tyto objekty, když má prezentace sledovat novou korporátní paletu. Hlásená RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled spojen s motivem.

Efektivní objekty jsou snímky. Po změně motivu prezentace, přepsání motivu nebo jakéhokoli děděného formátování znovu zavolejte `GetEffective` a načtěte nová data `IFillFormatEffectiveData` před porovnáním nebo hlášením barev.

## **Číst efektivní hodnoty motivu**

Surové objekty motivu vám řeknou, co je definováno na konkrétní úrovni. Efektivní hodnoty vám řeknou, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Pro pozadí použijte [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/), a pro výplň [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud kontrolujete pouze [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/), můžete přehlédnout přepsání na úrovni masteru, rozvržení, snímku nebo tvaru, které mění konečný vzhled.

## **Často kladené otázky**

**Ovlivňuje aplikace externího motivu každý snímek v prezentaci?**  
Ne. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) přidělí pouze snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovají své stávající motivy.

**Mohu použít motiv na jediný snímek bez změny masteru?**  
Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí své existující motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**  
Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový master do cílové prezentace a klonujte snímek s tímto masterem pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) a [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/). Tím se zachová master, rozvržení i motiv společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**  
Použijte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) pro motiv snímku nebo rozvržení a odpovídající metody pro formátové objekty, jako jsou [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) a [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/). Tyto API vrací rozřešené hodnoty po aplikaci dědičnosti a přepsání.