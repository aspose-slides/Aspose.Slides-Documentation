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
- Ställ in tema
- ändra tema
- hantera tema
- externt tema
- THMX
- temafärg
- extra palett
- temateckensnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska presentationsteman i Aspose.Slides för .NET för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentations tema definierar en koordinerad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Tema‑medvetna objekt hänvisar till dessa delade definitioner istället för att lagra varje visuellt egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt på en gång.

I Aspose.Slides finns temat på presentationsnivå tillgängligt via egenskapen [Presentation.MasterTheme](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/mastertheme/) . En presentation kan också innehålla temaarbeten på lägre nivåer. En master kan åsidosätta presentations‑temat via [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/masterthememanager/overridetheme/), en layout kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), och ett enskilt bild kan göra detsamma. I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentationstema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Temakomponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds- och effektstilar samt läsa effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/mastertheme/) visar temats [ColorScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/mastertheme/fontscheme/), och [FormatScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/mastertheme/formatscheme/). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposterna kan variera.

Följande exempel läser huvudtemaegenskaperna och rapporterar hur många bakgrunds-, fyllnings-, linje- och effektstilar som lagras i temat:

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

Om en fil använder flera masterar, anta inte att varje bild har samma effektiva tema. Inspektera den master som är associerad med bilden, och använd arbetsflödet för effektiva teman som visas senare i artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Tema‑medvetna fyllningar, linjer och text kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/net/aspose.slides/schemecolor/) . När du ändrar motsvarande post i temats [IColorScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/icolorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg påverkas inte av en temafärgsuppdatering.

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

Eftersom rektangeln förblir länkad till `Accent4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schemafärgen med en direkt färg på formen kommer senare ändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att applicera färgtransformationer. Aspose.Slides exponerar dessa transformationer via [ColorTransformOperation](https://reference.aspose.com/slides/sv/net/aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare samt mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** – Huvudtemafärger.  
**2** – Ljusare och mörkare varianter som produceras från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, applicerar luminans‑transformationer på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `IColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/net/aspose.slides/schemecolor/) använder `Text1`, `Background1`, `Text2` och `Background2`, medan [IColorScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/icolorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dessa är alternativa namn för samma temaplatser; de är inte värden som omvandlas dynamiskt från en form till en annan.

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller en huvudteckensnittssamling för rubriker och en mindre teckensnittssamling för brödtext. Egenskaperna [FontScheme.Major](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/fontscheme/major/) och [FontScheme.Minor](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/fontscheme/minor/) exponerar dessa samlingar.

PowerPoint‑kompatibla temateckensnittsidentifierare kan användas i textformatering:

* `+mn-lt` – Kroppsfont Latin (Minor Latin Font)
* `+mj-lt` – Rubrikfont Latin (Major Latin Font)
* `+mn-ea` – Kroppsfont East Asian (Minor East Asian Font)
* `+mj-ea` – Rubrikfont East Asian (Major East Asian Font)

Följande exempel skapar en rubrik som använder det stora Latin‑temateckensnittet och en brödtextlinje som använder det lilla Latin‑temateckensnittet. Det ändrar sedan temateckensnitten och sparar resultatet:

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

Rubriken följer det stora teckensnittet och brödtexten följer det lilla teckensnittet. Text som har ett explicit teckensnittsnamn istället för en temaidentifierare kommer inte automatiskt att bytas när temateckensnittsschemat ändras.

De stora och små teckensnittssamlingarna kan också innehålla teckensnittsmappningar för enskilda skriftsystem, såsom Kyrilliska, Arabiska, Japanska, Georgiska och Thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script-Specific Theme Fonts](/slides/sv/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
För mer information om presentations‑teckensnitt, se [PowerPoint Fonts](/slides/sv/net/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en masters beroende bilder**

Använd [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som är beroende av en viss master. Välj master från samlingen [Presentation.Masters](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/masters/), som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar en ny master‑bild baserad på den valda mastern.  
2. Tillämpa det externa temat på den nya mastern.  
3. Tilldelar den nya mastern till alla bilder som tidigare var beroende av den valda mastern.  
4. Returnerar den nyskapade [IMasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/).

Följande exempel tillämpar ett externt tema på de bilder som är beroende av den första mastern, sparar presentationen och öppnar resultatet igen:

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

Ett ogiltigt, korrupt eller ej stödjt tema kan orsaka [PptxException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxexception/) eller någon av dess formatrelaterade underklasser. Validera sökvägar som tillhandahålls av användare, hantera fel vid filsystemåtkomst och spara presentationen först när temat har tillämpats framgångsrikt.

Endast de bilder som var beroende av den valda mastern omplaceras. Bilder som är associerade med andra masterar behåller sina befintliga masterar och teman. Tema‑medvetna färger, teckensnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, teckensnitt, fyllningar och annan explicit formatering kan förbli oförändrade. Åsidosättningar på layout‑nivå och bild‑nivå kan också ha företräde framför värden ärvda från den nya mastern.

Temat kan referera till teckensnitt som inte är tillgängliga i körmiljön. För konsistent rendering och export, installera de erforderliga teckensnitten, tillhandahåll dem via [custom font sources](/slides/sv/net/custom-font/), eller konfigurera [font substitution](/slides/sv/net/font-substitution/).

Detta är ett direkt arbetsflöde på master‑nivå: metoden accepterar en filsökväg till en `.thmx`‑fil och kräver inte att manuellt skapa temåsåsidosättningar på bild‑ eller layout‑nivå.

### **Tillämpa olika externa teman i en presentation med flera masterar**

När den relevanta mastern inte är känd i förväg, hämta den från en representativ bild via [ISlide.LayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/layoutslide/) och [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/masterslide/). Spara de ursprungliga masterreferenserna innan du tillämpar några teman eftersom varje anrop skapar en ny master i presentationen.

Följande exempel använder bilder från två sektioner för att lokalisera deras masterar och tillämpar ett annat externt tema på varje grupp:

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

Det första anropet påverkar endast de bilder som var beroende av `firstGroupMaster`, och det andra anropet påverkar endast de bilder som var beroende av `secondGroupMaster`. Bilder som tillhör någon annan master omstylas inte.

### **Bevara ett källt tema vid flytt av bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona källmastern till mål‑presentationen med [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection/addclone/), klona sedan bilden med [ISlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/) och den klonade mastern. Detta för med sig mastern, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när källbilden måste se likadan ut i destinationen. Att bara klona innehåll till en orelaterad destination‑master kan förändra temabaserade färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa tema‑värden på en befintlig bild**

Om målbilden måste behålla sin nuvarande master och layout, initiera en bild‑nivå‑åsidosättning från källtemat. Metoderna [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/overridetheme/initfontschemefrom/) och [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopierar de tre huvudtema‑komponenterna till åsidosättningen.

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

Detta ändrar temat som den bilden använder utan att ändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.Clear](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/overridetheme/clear/).

### **Tillämpa en temåsåsidosättning på en layout**

En åsidosättning på layout‑nivå gäller för bilder som använder den layouten, såvida inte en enskild bild har sin egen åsidosättning. Samma initialiseringsmetoder kan användas via layoutens [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/layoutslidethememanager/):

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

Använd ett master‑ eller presentationsnivå‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑åsidosättning när en layoutfamilj behöver annan styling, och en bild‑åsidosättning endast för verkliga undantag. Överdriven bild‑nivå‑åsidosättning gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint kan visa fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint-galleri för bakgrundsstilar för ett presentations­tema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.StyleIndex](https://reference.aspose.com/slides/sv/net/aspose.slides/background/styleindex/). `StyleIndex` använder `0` för ingen temafyllning; positiva värden är referenser till temats bakgrundsstil. Detta skiljer sig från indexering av .NET‑samlingen direkt, där `[0]` betyder det första lagrade elementet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temabakgrundsreferens till den första mastern och sparar presentationen:

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

Det synliga resultatet beror på temaposten som mastern refererar till och eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en ändring av endast master‑bakgrunden lämna den bilden orörd. Använd [Background.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/background/geteffective/) när du behöver veta den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Warning" %}}
Behandla inte `StyleIndex` som ett nollbaserat kollektionsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastilsdefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/net/presentation-background/).
{{% /alert %}}

## **Uppdatera temaeffekter**

Ett temaformat‑schema innehåller separata samlingar för [FillStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/linestyles/), och [EffectStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/effectstyles/). Vanliga Office‑teman innehåller ofta tre huvudstilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men koden bör inspektera varje samling i stället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter applicerade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i C#, är samlingsindexet nollbaserat: `[0]` är den första lagrade stilen och `[2]` är den tredje. En forms stilreferensindex är ett separat begrepp, exponerat via [IShapeStyle](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de erforderliga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar en yttre skugga i den tredje effektstilen och sparar resultatet:

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skoggrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter att linje-, fyllnings- och skugginställningar ändrats](presentation-design_11.png)

## **Läs effektiva temavärden**

Rå temaobjekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala åsidosättningar har lösts. För en bild, anropa [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). För en bakgrund, använd [Background.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/background/geteffective/), och för en fyllning, använd [FillFormat.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/geteffective/).

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du endast inspekterar [Presentation.MasterTheme](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/mastertheme/), kan du missa en master‑, layout‑, bild‑ eller form‑åsidosättning som ändrar den slutliga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) omfördelar endast de bilder som är beroende av den valda mastern. Bilder som använder andra masterar behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra master?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/slidethememanager/) och initiera dess åsidosättning. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess källutseende, klona källmastern till destinationen och klona bilden med den mastern med hjälp av [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection/addclone/) och [ISlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/). Detta håller master, layouter och tema tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsidosättningar?**

Använd [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) för en bild‑ eller layout‑tema och motsvarande effektiva‑datametoder för formatobjekt såsom [Background.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/background/geteffective/) och [FillFormat.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/geteffective/). Dessa API:er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.