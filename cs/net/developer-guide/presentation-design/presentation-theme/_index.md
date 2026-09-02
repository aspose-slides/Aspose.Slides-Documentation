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
- Barva motivu
- Dodatečná paleta
- Font motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Hlavní motivy prezentací v Aspose.Slides pro .NET pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Motiv prezentace definuje koordinovanou sadu barev, fontů, stylů pozadí, výplní, čar a efektů. Objektům, které jsou sirotky motivu, odkazují na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je motiv na úrovni prezentace dostupný přes vlastnost [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Master může přepsat motiv prezentace pomocí [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/masterthememanager/overridetheme/), layout může přepsat svůj zděděný motiv pomocí [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) a jednotlivý snímek může udělat totéž. V praxi je efektivní motiv pro snímek rozřešený tímto řetězcem dědičnosti: motiv prezentace, přepsání masteru, přepsání layoutu a přepsání snímku.

![Komponenty motivu: barvy, fonty, styly pozadí a efekty](theme-constituents.png)

Níže jsou zobrazeny nejčastější pracovní postupy s motivem: prohlédnutí motivu, změna barev a fontů, kopírování nebo použití motivu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepsání.

## **Prohlédnutí motivu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/) poskytuje přístup k [ColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/fontscheme/) a [FormatScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/formatscheme/). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se může lišit.

Následující příklad načte hlavní vlastnosti motivu a zobrazí, kolik stylů pozadí, výplní, čar a efektů je v motivu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejný efektivní motiv. Prohlédněte master spojený se snímkem a použijte pracovní postup efektivního motivu uvedený později v tomto článku, pokud mohou být přítomny přepsání na úrovni layoutu nebo snímku.

## **Změna barev motivu**

Motivově‑vědomé výplně, čáry a text mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/). Když změníte odpovídající položku v [IColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou rozřešeny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se aktualizace barvy motivu neprojeví.

Následující end‑to‑end příklad vytvoří tvar používající `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vypíše efektivní barvu výplně:

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

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva po změně motivu bude červená. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` už tento výplň neovlivní.

### **Použití barev z dodatečné palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje přes [ColorTransformOperation](https://reference.aspose.com/slides/cs/net/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy vygenerované z dodatečné palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, pěti z nich aplikuje luminanční transformace a výsledek uloží:

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

Tyto varianty zůstávají založeny na barvě motivu. Pokud `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `IColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/) vystavuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevně dané:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejsou to hodnoty dynamicky převáděné z jednoho tvaru na druhý.

## **Změna fontů motivu**

Schéma fontů motivu obsahuje hlavní sadu fontů pro nadpisy a vedlejší sadu pro tělo textu. Vlastnosti [FontScheme.Major](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/major/) a [FontScheme.Minor](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/minor/) tyto sady zpřístupňují.

Identifikátory fontů kompatibilních s PowerPointem lze použít při formátování textu:

* `+mn-lt` – tělo (Latin) (Minor Latin Font)
* `+mj-lt` – nadpis (Latin) (Major Latin Font)
* `+mn-ea` – tělo (East Asian) (Minor East Asian Font)
* `+mj-ea` – nadpis (East Asian) (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinský font motivu a jeden řádek těla používající vedlejší latinský font motivu. Poté změní fonty motivu a výsledek uloží:

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

Nadpis používá hlavní font a tělo textu používá vedlejší font. Text, který má explicitně nastavený název fontu místo identifikátoru motivu, se automaticky nepřepne, když se změní schéma fontů motivu.

{{% alert color="info" title="Tip" %}}
Pro více informací o fontech v prezentacích viz [PowerPoint Fonts](/slides/cs/net/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití motivu**

Existují dva běžné pracovní postupy, které řeší různé problémy.

### **Zachování původního motivu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní vzhled, naklonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/), poté naklonujte snímek pomocí [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) a naklonovaný master. Tím se přenese master, jeho rozvržení i přidružený motiv.

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

### **Použití hodnot motivu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním masteru a rozvržení, inicializujte úroveň snímku přepsáním z motivu zdroje. Metody [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initfontschemefrom/) a [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initformatschemefrom/) zkopírují tři hlavní komponenty motivu do přepsání.

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

Tím se změní motiv použitý tímto snímkem, aniž by se změnil motiv zděděný ostatními snímky. Pro odebrání místního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/clear/).

### **Použití přepsání motivu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky, které používají toto rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/layoutslidethememanager/):

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

Použijte motiv na úrovni masteru nebo prezentace, když mají mnoho rozvržení a snímků sdílet stejný základní design; přepsání rozvržení, když jedna rodina rozvržení vyžaduje odlišné stylizování; a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími referencemi stylu.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.StyleIndex](https://reference.aspose.com/slides/cs/net/aspose.slides/background/styleindex/). `StyleIndex` používá `0` pro žádnou motivovou výplň; kladné hodnoty jsou reference na styl pozadí motivu. To se liší od indexování .NET kolekce přímo, kde `[0]` značí první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad uvádí počet dostupných výplní pozadí, přiřadí motivovou referenci pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na položce motivu, na kterou master odkazuje, a na případných přepsáních pozadí na úrovni layoutu nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/) když potřebujete znát konečné pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Upozornění" %}}
Nevnímejte `StyleIndex` jako index kolekce začínající nulou. Také se vyhněte pevnému kódování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/net/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátu motivu obsahuje samostatné kolekce [FillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/linestyles/) a [EffectStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/effectstyles/). Typické Office motivy často obsahují tři hlavní položky stylu, které vizuálně odpovídají subtilnímu, střednímu a intenzivnímu formátování, ale kód by měl prozkoumat každou kolekci namísto předpokladu pevného počtu.

![Jemné, střední a intenzivní efekty motivu aplikované na stejný tvar](presentation-design_11.png)

Když přistupujete k těmto kolekcím v C#, index kolekce začíná nulou: `[0]` je první uložený styl a `[2]` je třetí. Indexy odkazů stylů tvaru jsou samostatný pojem, vystupující přes [IShapeStyle](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapestyle/). Úprava stylu motivu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylu existují, změní první styl čáry, třetí styl výplně, povolí externí stín ve třetím stylu efektu a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry motivu stane červeným, třetí styl výplně motivu se změní na plnou lesní zelenou a třetí styl efektu získá externí stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, na které sloty každý tvar odkazuje a zda přímé formátování nepřepisuje motiv.

## **Čtení efektivních hodnot motivu**

Syrové objekty motivu vám řeknou, co je definováno na konkrétní úrovni. Efektivní hodnoty vám řeknou, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a místních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Pro pozadí použijte [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/), a pro výplň použijte [FillFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/geteffective/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnávání. Pokud prohlížíte jen [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/), můžete přehlédnout přepis na úrovni masteru, layoutu, snímku nebo tvaru, který mění finální vzhled.

## **Často kladené otázky**

**Mohu použít motiv na jeden snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí své stávající motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Když přesouváte snímek a chcete zachovat jeho původní vzhled, naklonujte zdrojový master do cílové prezentace a snímek s tímto masterem pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/) a [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/). Tím se master, rozvržení a motiv udrží společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) pro motiv snímku nebo layoutu a odpovídající metody efektivních dat pro formátové objekty jako [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/) a [FillFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/geteffective/). Tyto API vrací rozřešené hodnoty po aplikaci dědičnosti a přepisů.