---
title: Hantera presentationsteman i .NET
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/net/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- ställ in tema
- ändra tema
- hantera tema
- temafärg
- extra palett
- tematypsnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera presentationsteman i Aspose.Slides för .NET för att skapa, anpassa och konvertera PowerPoint‑filer med enhetlig varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar en samordnad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Tema‑medvetna objekt refererar till dessa delade definitioner istället för att lagra varje visuellt egenskap som ett fast värde, så en temaväxling kan uppdatera många objekt samtidigt.

I Aspose.Slides är temat på presentationsnivå tillgängligt via egenskapen [Presentation.MasterTheme](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/mastertheme/). En presentation kan också innehålla temaunderskott på lägre nivåer. En master kan åsidosätta presentationstemat via [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/masterthememanager/overridetheme/), en layout kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), och en enskild bild kan göra detsamma. I praktiken löses det effektiva temat för en bild upp genom denna arvskedja: presentationstema, master‑åsåsidosättning, layout‑åsåsidosättning och bild‑åsåsidosättning.

![Temakomponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetssätten: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effekstilar samt läsa effektiva värden efter att arv och åsåsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/mastertheme/) exponerar temats [ColorScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/mastertheme/fontscheme/) och [FormatScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/mastertheme/formatscheme/). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposter kan variera.

Följande exempel läser huvudtemats egenskaper och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effekstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är kopplad till bilden, och använd arbetsflödet för effektiva teman som visas senare i artikeln när layout‑ eller bild‑åsåsidosättningar kan finnas.

## **Ändra temafärger**

Tema‑medvetna fyllningar, linjer och text kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/net/aspose.slides/schemecolor/). När du ändrar motsvarande post i temats [IColorScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/icolorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

Följande end‑to‑end‑exempel skapar en form som använder `Accent4`, ändrar temats `Accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den effektiva fyllningsfärgen:

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

Eftersom rektangeln fortfarande är länkad till `Accent4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schemafärgen med en direkt färg på formen, kommer senare ändringar av `Accent4` inte längre påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att applicera färgtransformeringar. Aspose.Slides exponerar dessa transformationer via [ColorTransformOperation](https://reference.aspose.com/slides/sv/net/aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare och mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** - Huvudtemafärger.  
**2** - Ljusare och mörkare varianter producerade från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, applicerar luminans‑transformeringar på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare, beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `IColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/net/aspose.slides/schemecolor/) använder `Text1`, `Background1`, `Text2` och `Background2`, medan [IColorScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/icolorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dessa är alternativa namn för samma temaplatser; de är inte värden som konverteras dynamiskt från en form till en annan.

## **Ändra tematypsnitt**

Ett tematypsnittsschema innehåller ett huvudtypsnitt för rubriker och ett mindre typsnitt för brödtext. Egenskaperna [FontScheme.Major](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/fontscheme/major/) och [FontScheme.Minor](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/fontscheme/minor/) exponerar dessa uppsättningar.

PowerPoint‑kompatibla tematypsnittsidenterare kan användas i textformatering:

* `+mn-lt` - Kroppstypsnitt Latin (Minor Latin Font)
* `+mj-lt` - Rubrikstypsnitt Latin (Major Latin Font)
* `+mn-ea` - Kroppstypsnitt East Asian (Minor East Asian Font)
* `+mj-ea` - Rubrikstypsnitt East Asian (Major East Asian Font)

Följande exempel skapar en rubrik som använder huvud‑Latin‑tematypsnittet och en brödtextlinje som använder det mindre Latin‑tematypsnittet. Därefter ändras tematypsnitten och resultatet sparas:

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

Rubriken följer huvudtypsnittet och brödtexten följer det mindre typsnittet. Text som har ett explicit typsnittsnamn istället för en temaidentifierare byter inte automatiskt när tematypsnittsschemat ändras.

{{% alert color="info" title="Tips" %}}
För mer information om presentationstypsnitt, se [PowerPoint-typsnitt](/slides/sv/net/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Det finns två vanliga arbetsflöden, och de löser olika problem.

### **Bevara ett källtema när du flyttar bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑mastern in i mål‑presentationen med [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection/addclone/), klona sedan bilden med [ISlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/) och den klonade mastern. Detta bär med sig mastern, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när käll‑bilden måste se likadan ut i destinationen. Att bara klona innehåll på en orelaterad destinations‑master kan förändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål‑bilden måste stanna på sin nuvarande master och layout, initiera ett bild‑nivå‑underskott från källtemat. Metoderna [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/overridetheme/initfontschemefrom/) och [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopierar de tre huvudsakliga temakomponenterna till underskottet.

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

Detta ändrar temat som används av den bilden utan att ändra temat som ärvs av andra bilder. För att ta bort det lokala underskottet och återgå till ärvda värden, anropa [OverrideTheme.Clear](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/overridetheme/clear/).

### **Tillämpa ett temaunderskott på en layout**

Ett layout‑nivå‑underskott gäller för bilder som använder den layouten, såvida inte en specifik bild har sitt eget underskott. Samma initieringsmetoder kan användas via layoutens [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑nivå‑tema när många layouter och bilder ska dela samma grunddesign, ett layout‑underskott när en layoutfamilj behöver annan stil, och ett bild‑underskott endast för egentliga undantag. Överdrivna bild‑nivå‑underskott gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint kan visa fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint bakgrundsstilsgalleri för ett presentationstema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.StyleIndex](https://reference.aspose.com/slides/sv/net/aspose.slides/background/styleindex/). `StyleIndex` använder `0` för ingen temat fyllning; positiva värden är temabakgrund‑stilreferenser. Detta skiljer sig från indexering av .NET‑samlingen direkt, där `[0]` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temat bakgrundsreferens till den första mastern och sparar presentationen:

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

Det synliga resultatet beror på temaposten som refereras av mastern och på eventuella bakgrundsunderskott på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund, kan en förändring av endast master‑bakgrunden lämna den bilden oförändrad. Använd [Background.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/background/geteffective/) när du behöver veta den slutliga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Varning" %}}
Behandla inte `StyleIndex` som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastilsdefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tips" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Bakgrund](/slides/sv/net/presentation-background/).
{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temaformatschema innehåller separata samlingar för [FillStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/linestyles/) och [EffectStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/effectstyles/). Vanliga Office‑teman innehåller ofta tre huvudstilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men koden bör inspektera varje samling i stället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter tillämpade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i C# är samlingsindexet nollbaserat: `[0]` är den första lagrade stilen och `[2]` är den tredje. En formes stilreferensindex är ett separat koncept, exponerat via [IShapeStyle](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de nödvändiga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar en yttre skugga i den tredje effekstilen och sparar resultatet:

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

För former som refererar dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen solid skoggrön och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och huruvida direkt formatering åsidosätter temat.

![Temaeffektstilar efter ändring av linje-, fyllnings- och skugginställningar](presentation-design_11.png)

## **Läs effektiva temavärden**

Råa temaobjekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala underskott har lösts. För en bild, anropa [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). För en bakgrund, använd [Background.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/background/geteffective/), och för en fyllning, använd [FillFormat.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/geteffective/).

Följande exempel läser det effektiva temat, bakgrunden och den första formens fyllning från en bild:

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

Använd effektiv data för renderingsdiagnostik, validering och jämförelser. Om du endast inspekterar [Presentation.MasterTheme](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/mastertheme/), kan du missa en master‑, layout‑, bild‑ eller form‑underskott som förändrar den slutgiltiga framtoningen.

## **FAQ**

**Kan jag tillämpa ett tema på en enskild bild utan att ändra mastern?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/slidethememanager/) och initiera dess underskottstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess ursprungliga utseende, klona käll‑mastern in i destinationen och klona bilden med den mastern med [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection/addclone/) och [ISlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/). Detta behåller master, layouter och tema tillsammans.

**Hur kan jag se de effektiva värdena efter arv och underskott?**

Använd [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) för en bild‑ eller layout‑tema och de motsvarande effektiva‑datametoderna för formatobjekt som [Background.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/background/geteffective/) och [FillFormat.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/geteffective/). Dessa API‑er returnerar de lösta värdena efter att arv och underskott har tillämpats.