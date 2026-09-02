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
- Dodatečná paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Hlavní motivy prezentací v Aspose.Slides pro .NET pro vytváření, přizpůsobení a konverzi souborů PowerPoint se soudržnou značkou."
---
## **Úvod**

Motiv prezentace definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objekty, které jsou motivem‑vycházející, odkazují na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je motiv na úrovni prezentace k dispozici přes vlastnost [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Master může přepsat motiv prezentace pomocí [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/masterthememanager/overridetheme/), rozvržení může přepsat svůj zděděný motiv pomocí [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), a jednotlivý snímek může udělat totéž. V praxi je efektivní motiv pro snímek vyřešen tímto řetězcem dědičnosti: motiv prezentace, přepsání masteru, přepsání rozvržení a přepsání snímku.

![Komponenty motivu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejobvyklejší pracovní postupy s motivem: prozkoumání motivu, změna barev a písem, kopírování nebo aplikace motivu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepisů.

## **Prozkoumání motivu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/) vystavuje [ColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/fontscheme/) a [FormatScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/formatscheme/). Prozkoumání těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti motivu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v motiv uložených:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejný efektivní motiv. Prozkoumejte master přiřazený ke snímku a použijte pracovní postup s efektivním motivem zobrazený později v této kapitole, pokud mohou být přítomna přepsání rozvržení nebo snímku.

## **Změna barev motivu**

Motiv‑vycházející výplně, čáry a text mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/). Když změníte odpovídající položku v [**IColorScheme**](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou vyhodnoceny vůči nové hodnotě. Objekty, které používají přímou RGB barvu, nejsou změněny aktualizací barvy motivu.

Následující end‑to‑end příklad vytvoří tvar, který používá `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použití barev z další palety**

PowerPoint odvozuje světlejší a tmavší varianty z motivu‑barvy pomocí transformací barev. Aspose.Slides tyto transformace zpřístupňuje přes [ColorTransformOperation](https://reference.aspose.com/slides/cs/net/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy generované z další palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, u pěti z nich aplikuje luminanční transformace a uloží výsledek:

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

Tyto varianty zůstávají založeny na barvě motivu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `IColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/) vystavuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejde o hodnoty, které by se dynamicky převáděly z jedné podoby do druhé.

## **Změna písem motivu**

Schéma písem motivu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu pro tělo textu. Vlastnosti [FontScheme.Major](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/major/) a [FontScheme.Minor](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/minor/) tyto sady vystavují.

Identifikátory motivu kompatibilní s PowerPointem lze použít při formátování textu:

* `+mn-lt` – tělo písmo Latin (Minor Latin Font)
* `+mj-lt` – nadpis písmo Latin (Major Latin Font)
* `+mn-ea` – tělo písmo East Asian (Minor East Asian Font)
* `+mj-ea` – nadpis písmo East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo motivu a jeden řádek těla používající vedlejší latinské písmo motivu. Pak změní písma motivu a uloží výsledek:

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

Nadpis následuje hlavní písmo a tělo textu následuje vedlejší písmo. Text, který má explicitní název písma místo identifikátoru motivu, se automaticky nepřepne, když se změní schéma písem motivu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prozkoumání, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmenech v prezentacích viz [PowerPoint Fonts](/slides/cs/net/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo aplikace motivu**

Níže uvedené pracovní postupy řeší různé problémy související s motivem.

### **Aplikovat externí motiv na snímky závislé na masteru**

Použijte [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) když máte soubor motivu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation.Masters](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/masters/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/), a jako parametr metody předávejte cestu k souboru motivu.

Metoda provede následující operace:

1. Vytvoří nový master slide založený na vybraném masteru.  
2. Aplikuje externí motiv na nový master.  
3. Přiřadí nový master všem snímkům, které dosud závisely na vybraném masteru.  
4. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/).

Následující příklad aplikuje externí motiv na snímky, které závisí na prvním masteru, uloží prezentaci a znovu otevře výsledek:

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

Neplatný, poškozený nebo nepodporovaný motiv může vyvolat [PptxException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxexception/) nebo některou z jejich podtříd vztahujících se k formátu. Ověřujte cesty zadané uživateli, ošetřete selhání přístupu k souborovému systému a prezentaci uložte až po úspěšné aplikaci motivu.

Přesunou se jen snímky, které závisely na vybraném masteru. Snímky přiřazené k jiným masterům si zachovají své stávající master a motivy. Motiva‑vycházející barvy, písma, výplně, čáry, pozadí a efekty jsou vyhodnoceny vůči externímu motivu. Přímě přiřazené barvy, písma, výplně a další explicitní formátování mohou zůstat beze změny. Přepsání na úrovni rozvržení i snímku může také převážit nad hodnotami zděděnými z nového masteru.

Motiv může odkazovat na písma, která nejsou v běhovém prostředí k dispozici. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, zpřístupněte je skrze [vlastní zdroje písem](/slides/cs/net/custom-font/), nebo nakonfigurujte [nahrazení písem](/slides/cs/net/font-substitution/).

Jedná se o přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepisů motivu na úrovni snímku nebo rozvržení.

### **Aplikovat různé externí motivy v prezentaci s více mastery**

Když není konkrétní master znám předem, získejte jej z representativního snímku pomocí [ISlide.LayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/layoutslide/) a [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/masterslide/). Před aplikací motivů uložte původní reference masterů, protože každý volání vytvoří v prezentaci další master.

Následující příklad použije snímky ze dvou sekcí k nalezení jejich masterů a aplikuje na každou skupinu jiný externí motiv:

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

První volání ovlivní jen snímky, které závisely na `firstGroupMaster`, a druhé volání jen snímky, které závisely na `secondGroupMaster`. Snímky patřící k jinému masteru nebudou přeformátovány.

### **Zachovat zdrojový motiv při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, klonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/), poté klonujte snímek pomocí [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) a klonovaný master. Tím se přenese master, jeho rozvržení i související motiv.

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

Toto je preferovaný pracovní postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Aplikovat hodnoty motivu na existující snímek**

Pokud má cílový snímek zůstat na svém aktuálním masteru a rozvržení, inicializujte přepis na úrovni snímku z zdrojového motivu. Metody [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initfontschemefrom/) a [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initformatschemefrom/) zkopírují tři hlavní komponenty motivu do přepisu.

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

Tím se změní motiv použitý tímto snímkem, aniž by se změnil motiv zděděný ostatními snímky. Pro odebrání lokálního přepisu a návrat k zděděným hodnotám zavolejte [OverrideTheme.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/clear/).

### **Aplikovat přepis motivu na rozvržení**

Přepis na úrovni rozvržení se vztahuje na snímky, které používají toto rozvržení, pokud konkrétní snímek nemá vlastní přepis. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/layoutslidethememanager/) rozvržení:

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

Použijte motiv na úrovni masteru nebo prezentace, když má mnoho rozvržení a snímků sdílet stejný základní design; použijte přepis rozvržení, když jedna skupina rozvržení potřebuje odlišné formátování; a použijte přepis snímku jen pro skutečné výjimky. Nadměrné přepisy na úrovni snímku ztěžují předvídání následných globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint může v uživatelském rozhraní nabízet více možností pozadí, než je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Než použijete styl pozadí, prohlédněte si uloženou kolekci a aktuální [Background.StyleIndex](https://reference.aspose.com/slides/cs/net/aspose.slides/background/styleindex/). `StyleIndex` používá `0` pro žádnou motivovou výplň; kladné hodnoty jsou odkazy na motivové styly pozadí. To se liší od indexování .NET kolekce přímo, kde `[0]` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplně pozadí.

Následující příklad nahlásí dostupný počet výplní pozadí, přiřadí motivový odkaz na pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na motivové položce, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Varování" %}}
Nevnímejte `StyleIndex` jako nulově založený index kolekce. Také se vyhněte tvrdému zakódování čísla stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro konkrétní prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/net/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátu motivu obsahuje samostatné kolekce [FillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/linestyles/), a [EffectStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/effectstyles/). Typické office motivy často obsahují tři hlavní položky stylů, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl prozkoumat každou kolekci místo předpokladu pevného počtu.

![Jemné, střední a intenzivní efektové styly motivu aplikované na stejný tvar](presentation-design_10.png)

Když v C# přistupujete k těmto kolekcím, index kolekce je nulově založený: `[0]` je první uložený styl a `[2]` je třetí. Indexy odkazující na styl u tvaru jsou samostatný koncept, vystavený přes [IShapeStyle](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapestyle/). Změna motivového stylu ovlivní tvary, které na něj odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylů existují, změní první styl čáry, třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

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

Pro tvary, které odkazují na tyto sloty, se první motivová čára stane červenou, třetí motivová výplň se stane pevnou lesní zelenou a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každá figura používá a zda přímé formátování nepřepisuje motiv.

![Stylové efekty motivu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtení efektivních hodnot motivu**

Surové objekty motivu vám řeknou, co je definováno na konkrétní úrovni. Efektivní hodnoty vám řeknou, co snímek nebo tvar ve skutečnosti používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Pro pozadí použijte [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/), a pro výplň [FillFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/geteffective/).

Následující příklad načte efektivní motiv, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prozkoumáte jen [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/), můžete přehlédnout přepis masteru, rozvržení, snímku nebo tvaru, který mění finální vzhled.

## **Časté dotazy**

**Ovlivní aplikace externího motivu každý snímek v prezentaci?**

Ne. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) přidělí pouze snímkům, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovají své existující motivy.

**Mohu aplikovat motiv na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepis motivu. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále dědit své stávající motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu klonujte zdrojový master do cíle a klonujte snímek s tímto masterem pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/) a [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/). Tím se master, rozvržení i motiv přenesou společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) pro motiv snímku nebo rozvržení a odpovídající metody pro efektivní data formátovacích objektů, jako jsou [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/) a [FillFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/geteffective/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepisů.