---
title: Správa témat prezentací v .NET
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/net/presentation-theme/
keywords:
- téma PowerPoint
- téma prezentace
- téma snímku
- nastavit téma
- změnit téma
- spravovat téma
- barva tématu
- další paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Hlavní témata prezentací v Aspose.Slides pro .NET pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Prezentace má téma, které představuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou si vědomy tématu, jsou přiřazeny tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je téma na úrovni prezentace dostupné přes vlastnost [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/masterthememanager/overridetheme/), rozložení může přepsat své zděděné téma pomocí [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), a individuální snímek může udělat totéž. V praxi je efektivní téma pro snímek vyřešeno touto řetězcovou dědičností: téma prezentace, přepsání masteru, přepsání rozložení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější postupy práce s tématy: prohlédnutí tématu, změnu barev a písem, kopírování nebo použití tématu, aktualizaci stylů pozadí a efektů a čtení efektivních hodnot po rozdělení dědičnosti a přepsání.

## **Prohlédnutí tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/) vystavuje [ColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/fontscheme/) a [FormatScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/mastertheme/formatscheme/). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti tématu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prohlédněte master přiřazený ke snímku a použijte postup „efektivní téma“, který je ukázán později v tomto článku, pokud mohou být přítomna přepsání rozložení nebo snímku.

## **Změna barev tématu**

Výplně, čáry a text, které jsou si vědomy tématu, mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/). Když změníte příslušnou položku v [IColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/) tématu, všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyhodnoceny proti nové hodnotě. Objektům, které používají přímou barvu RGB, se aktualizace barvy tématu neprojeví.

Následující end‑to‑end příklad vytvoří tvar používající `Accent4`, změní barvu `Accent4` v tématu na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` už tuto výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací barevných transformací. Aspose.Slides tyto transformace vystavuje přes [ColorTransformOperation](https://reference.aspose.com/slides/cs/net/aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, u pěti z nich aplikuje transformaci luminance a výsledek uloží:

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

Tyto varianty zůstávají založeny na barvě tématu. Pokud se `Accent4` později změní, transformované barvy budou přepočítány z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `IColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [IColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/) vystavuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejedná se o hodnoty, které jsou dynamicky konvertovány ze jednoho tvaru do druhého.

## **Změna písem tématu**

Schéma písma tématu obsahuje hlavní sadu písem pro nadpisy a menší sadu písem pro tělo textu. Vlastnosti [FontScheme.Major](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/major/) a [FontScheme.Minor](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/minor/) tyto sady vystavují.

Identifikátory písem kompatibilních s PowerPoint lze použít ve formátování textu:

* `+mn-lt` – Tělo písmo Latin (Minor Latin Font)
* `+mj-lt` – Nadpis písmo Latin (Major Latin Font)
* `+mn-ea` – Tělo písmo East Asian (Minor East Asian Font)
* `+mj-ea` – Nadpis písmo East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinské písmo tématu, a jednu řádku těla, která používá menší latinské písmo tématu. Pak změní písma tématu a výsledek uloží:

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

Nadpis používá hlavní písmo a tělo textu používá menší písmo. Text, který má explicitně zadáno jméno písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma písem tématu.

Hlavní a menší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou Cyrilice, Arabština, Japonština, Gruzínština a Thaana. Pro prohlížení, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmech v prezentacích viz [PowerPoint Fonts](/slides/cs/net/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití tématu**

Existují dva běžné postupy a řeší různé problémy.

### **Zachovat zdrojové téma při přenosu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní vzhled, naklonujte zdrojový master do cílové prezentace pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/), potom naklonujte snímek pomocí [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) a naklonovaný master. Tím se společně přenesou master, jeho rozložení i přidružené téma.

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

Jedná se o preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Použít hodnoty tématu na existujícím snímku**

Pokud musí cílový snímek zůstat na svém aktuálním masteru a rozložení, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initfontschemefrom/) a [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/initformatschemefrom/) zkopírují tři hlavní komponenty tématu do přepsání.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/overridetheme/clear/).

### **Použít přepsání tématu na rozložení**

Přepsání na úrovni rozložení se aplikuje na snímky, které používají toto rozložení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/layoutslidethememanager/):

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

Použijte téma na úrovni masteru nebo prezentace, když má mnoho rozložení a snímků sdílet stejný základní design, přepsání rozložení, když jedna rodina rozložení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje předpovídání následných globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Výplně pozadí tématu jsou uloženy v [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik definic výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.StyleIndex](https://reference.aspose.com/slides/cs/net/aspose.slides/background/styleindex/). `StyleIndex` používá `0` pro žádnou tématickou výplň; kladné hodnoty jsou odkazy na styl pozadí tématu. To se liší od indexování .NET kolekce přímo, kde `[0]` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše dostupný počet výplní pozadí, přiřadí odkaz na tématické pozadí prvnímu masteru a prezentaci uloží:

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

Viditelný výsledek závisí na položce tématu, na kterou odkazuje master, a na jakýchkoli přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek ovlivnit. Použijte [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte `StyleIndex` jako nulový index kolekce. Také se vyhýbejte tvrdému kódování čísla stylu z jednoho souboru s předpokladem, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/net/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátu tématu obsahuje samostatné kolekce [FillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/linestyles/) a [EffectStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/effectstyles/). Typická kancelářská témata často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl prohlédnout každou kolekci místo předpokladu pevného počtu.

![Jemné, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Když v C# přistupujete k těmto kolekcím, index kolekce je nulový: `[0]` je první uložený styl a `[2]` je třetí. Indexy odkazů stylu tvaru jsou samostatný koncept, vystavený přes [IShapeStyle](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, první styl čáry tématu se stane červeným, třetí styl výplně tématu se stane plnou lesní zelení a třetí styl efektu získá vnější stín s odstupem 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každá forma odkazuje a zda přímé formátování přepisuje téma.

![Styly efektů tématu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtení efektivních hodnot tématu**

Surové objekty tématu vám řeknou, co je definováno na konkrétní úrovni. Efektivní hodnoty vám řeknou, co snímek nebo tvar skutečně používá po rozdělení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Pro pozadí použijte [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/), a pro výplň [FillFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/geteffective/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnávání. Pokud prohlížíte jen [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/), můžete přehlédnout přepsání na úrovni masteru, rozložení, snímku nebo tvaru, které mění konečný vzhled.

## **Často kladené otázky**

**Mohu aplikovat téma na jeden snímek, aniž bych změnil master?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí své existující témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu naklonujte zdrojový master do cílové prezentace a naklonujte snímek s tímto masterem pomocí [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/) a [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/). Tím se master, rozložení i téma přenesou společně.

**Jak mohu zobrazit efektivní hodnoty po rozdělení dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) pro téma snímku nebo rozložení a odpovídající metody efektivních dat pro formátovací objekty, jako jsou [Background.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/background/geteffective/) a [FillFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/geteffective/). Tyto API vrací rozlišené hodnoty po aplikaci dědičnosti a přepsání.