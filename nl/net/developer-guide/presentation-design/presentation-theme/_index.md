---
title: "Beheer presentatiethema's in .NET"
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/net/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- dia-thema
- thema instellen
- thema wijzigen
- thema beheren
- extern thema
- THMX
- themakleur
- extra palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor .NET om PowerPoint-bestanden te creëren, aanpassen en converteren met consistente branding."
---
## **Introductie**

Een presentatie‑thema definieert een gecoördineerde verzameling kleuren, lettertypen, achtergrondstijlen, opvullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via de eigenschap [Presentation.MasterTheme](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/mastertheme/). Een presentatie kan ook themabijschrijvingen op lagere niveaus bevatten. Een master kan het presentatie‑thema overschrijven via [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/masterthememanager/overridetheme/), een lay‑out kan zijn geërfde thema overschrijven via [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), en een individuele dia kan hetzelfde doen. In de praktijk wordt het effectieve thema voor een dia bepaald via deze overervingsketen: presentatie‑thema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑werkstromen: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en bijschrijvingen zijn toegepast.

## **Inspecteer een thema**

Het object [MasterTheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/) exposeert het [ColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/fontscheme/) en [FormatScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/formatscheme/) van het thema. Het inspecteren van deze collecties voordat ze worden gewijzigd is vooral nuttig wanneer een presentatie afkomstig is uit een externe bron, omdat het aantal en de inhoud van stijleinvoer kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themaproperties en rapporteert hoeveel achtergrond‑, opvul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet vanuit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑bijschrijvingen aanwezig kunnen zijn.

## **Thema‑kleuren wijzigen**

Thema‑bewuste opvullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/). Wanneer je de overeenkomstige invoer in het themathema’s [IColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, bijgewerkt naar de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet veranderd door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de themakleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve opvulkleur af:

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

Omdat het rechthoekige object nog aan `Accent4` is gekoppeld, wordt de zichtbare kleur rood nadat het thema is veranderd. Als je de schemakleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die opvulling niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides exposeert deze transformaties via [ColorTransformOperation](https://reference.aspose.com/slides/nl/net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Hoofdkleuren van het thema.

**2** - Lichtere en donkerdere varianten die zijn geproduceerd uit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantie‑transformaties toe op vijf ervan, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden toewijzen aan `IColorScheme`‑slots**

De enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/) gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl [IColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; ze zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een sublettertype‑set voor de hoofdtekst. De eigenschappen [FontScheme.Major](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/fontscheme/major/) en [FontScheme.Minor](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/fontscheme/minor/) geven die sets weer.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt bij tekstopmaak:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑thema‑lettertype gebruikt en één regel hoofdtekst die het sub‑Latin‑thema‑lettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de hoofdtekst volgt het sublettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier zal niet automatisch wisselen wanneer het thema‑lettertype‑schema verandert.

De collecties voor hoofd‑ en sublettertypes kunnen ook lettertype‑toewijzingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatie‑lettertypen, zie [PowerPoint Fonts](/slides/nl/net/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande werkstromen lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia’s die afhankelijk zijn van een master**

Gebruik [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wanneer je een PowerPoint‑themabestand (`.thmx`) hebt en elke dia die afhankelijk is van een bepaalde master wilt herontwerpen. Selecteer de master uit de collectie [Presentation.Masters](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/masters/) die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia gebaseerd op de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Wijst de nieuwe master toe aan alle dia’s die voorheen afhankelijk waren van de geselecteerde master.
1. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de dia’s die afhankelijk zijn van de eerste master, slaat de presentatie op, en opent het resultaat opnieuw:

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

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxexception/) of een van zijn formaat‑gerelateerde subklassen veroorzaken. Valideer door gebruikers opgegeven paden, beheer fouten bij bestandoverzicht, en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia’s die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia’s die aan andere masters zijn gekoppeld behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, opvullingen, lijnen, achtergronden en effecten worden afgehandeld ten opzichte van het externe thema. Direct toegekende kleuren, lettertypen, opvullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Bijschrijvingen op lay‑out‑ of dia‑niveau kunnen eveneens voorrang krijgen op waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen verwijzen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, stel ze beschikbaar via [custom font sources](/slides/nl/net/custom-font/), of configureer [font substitution](/slides/nl/net/font-substitution/).

Dit is een directe master‑niveau werkstroom: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist niet dat handmatig dia‑ of lay‑out‑thema‑bijschrijvingen worden gecreëerd.

### **Verschillende externe thema’s toepassen in een presentatie met meerdere masters**

Wanneer de relevante master van tevoren niet bekend is, haal deze dan op via een representatieve dia met [ISlide.LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/layoutslide/) en [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/masterslide/). Sla de oorspronkelijke master‑referenties op voordat je thema’s toepast, omdat elke oproep een nieuwe master in de presentatie creëert.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te vinden en past een verschillend extern thema toe op elke groep:

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

De eerste oproep heeft alleen effect op dia’s die afhankelijk waren van `firstGroupMaster`, en de tweede oproep alleen op dia’s die afhankelijk waren van `secondGroupMaster`. Dia’s die tot een andere master behoren worden niet herontworpen.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wil je een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/addclone/), kloon vervolgens de dia met [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) en de gekloonde master. Hiermee worden de master, zijn lay‑outs en het bijbehorende thema samen overgebracht.

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

Dit is de aanbevolen werkstroom wanneer de bron‑dia er identiek uit moet zien in de bestemming. Het simpelweg klonen van inhoud naar een niet‑gerelateerde doelmaster kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Wanneer de doel‑dia op zijn huidige master en lay‑out moet blijven, initialiseert u een dia‑niveau bijschrijving vanuit het bron‑thema. De methoden [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/initfontschemefrom/) en [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiëren de drie hoofd‑thema‑componenten naar de bijschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat andere dia’s erven te veranderen. Om de lokale bijschrijving te verwijderen en terug te gaan naar geërfde waarden, roep [OverrideTheme.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/clear/) aan.

### **Een thema‑bijschrijving toepassen op een lay‑out**

Een lay‑out‑niveau bijschrijving is van toepassing op dia’s die die lay‑out gebruiken, tenzij een specifieke dia zijn eigen bijschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de lay‑out‑manager [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/layoutslidethememanager/):

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

Gebruik een master‑ of presentatie‑niveau thema wanneer veel lay‑outs en dia’s hetzelfde basisonderdeel moeten delen, een lay‑out‑bijschrijving wanneer één lay‑outfamilie een andere vormgeving nodig heeft, en een dia‑bijschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau bijschrijvingen bemoeilijken latere globale thema‑wijzigingen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrond‑opvullingen van het thema worden opgeslagen in [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint kan meer achtergrondkeuzes tonen in de gebruikersinterface dan het aantal opvuldefinities dat fysiek in deze collectie is opgeslagen, omdat de UI thema‑opvullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.StyleIndex](https://reference.aspose.com/slides/nl/net/aspose.slides/background/styleindex/). `StyleIndex` gebruikt `0` voor geen thematische opvulling; positieve waarden zijn referenties naar thematische achtergrondstijlen. Dit verschilt van het indexeren van de .NET‑collectie zelf, waar `[0]` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrond‑opvullingsstijlen bevat.

Het volgende voorbeeld meldt het beschikbare aantal achtergrond‑opvullingen, wijst een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de thema‑invoer die door de master wordt gerefereerd en van eventuele achtergrond‑bijschrijvingen op lay‑out‑ of dia‑niveau. Als een dia zijn eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die dia niet beïnvloeden. Gebruik [Background.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/background/geteffective/) wanneer je de uiteindelijke achtergrond na toepassen van overerving wilt weten.

{{% alert color="warning" title="Warning" %}}
Beschouw `StyleIndex` niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en veronderstel dat het dezelfde weergave heeft in een ander bestand; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/net/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑format‑schema bevat aparte collecties voor [FillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/linestyles/) en [EffectStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/effectstyles/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlinvoeren die visueel overeenkomen met subtiele, matige en intensieve opmaak, maar de code moet elke collectie inspecteren in plaats van uit te gaan van een vast aantal.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Wanneer je deze collecties benadert in C#, is de collectie‑index nul‑gebaseerd: `[0]` is de eerste opgeslagen stijl en `[2]` de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak blijven eventueel ongewijzigd.

Het volgende voorbeeld controleert of de vereiste stijlinvoeren bestaan, wijzigt de eerste lijnstijl, wijzigt de derde opvulstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themapopvulstijl een effen bosgroen, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑slots elke vorm referreert en of directe opmaak de thema‑instelling overschrijft.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Bepalen of een effectieve effen opvulling een thema‑kleur gebruikt**

Een opvulling kan direct op een object worden opgeslagen of geërfd van een alinea, lay‑out, master, themastijl of een andere opmaak‑laag. Roep [IFillFormat.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformat/geteffective/) aan om die hiërarchie om te zetten in een onwijzigbare [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformateffectivedata/filltype/). Alleen wanneer dit `FillType.Solid` is, mag je de effen‑opvullingseigenschappen lezen.

Voor een effen opvulling geeft [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) de uiteindelijke gerenderde RGB‑waarde terug na overerving, themazoek en kleurtransformaties. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) geeft de bijbehorende logische [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/) slot terug, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor.NotDefined` betekent dat de effectieve effen opvulling niet op een schemakleur is gebaseerd. In een werkstroom waarin opvullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑opvulling.

Gebruik niet alleen de lokale [IColorFormat.SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/icolorformat/schemecolor/)‑waarde om een opvulling te classificeren. Bijvoorbeeld, een tekstdeel kan geen lokaal gedefinieerde schemakleur hebben, waardoor de lokale waarde `NotDefined` is, terwijl de effectieve opvulling een themakleur erft en resolveert naar `Text1` of `Accent6`. Omgekeerd vertelt `SolidFillSchemeColor` je welke logische themaslot de effectieve kleur heeft voortgebracht, maar niet of die slot afkomstig is van het object, de alinea, lay‑out, master of een andere niveau van de opmaak‑hiërarchie.

Het volgende voorbeeld laadt een presentatie, controleert zowel vorm‑opvullingen als tekst‑deel‑opvullingen, drukt elke uiteindelijke RGB‑waarde en bijbehorende schemakleur af, en markeert effen opvullingen die geen thema‑kleurwijzigingen volgen:

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

De `NotDefined`‑tak levert een audit‑lijst van effen opvullingen die geen respons geven op wijzigingen in themakleur‑slots. Beoordeel die objecten wanneer een presentatie een nieuw merkschema moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de schema‑waarde uitlegt of dat uiterlijk verbonden is met het thema.

Effectieve‑format‑objecten zijn momentopnames. Na het wijzigen van het presentatiethema, een thema‑bijschrijving of enige geërfde opmaak, roep opnieuw `GetEffective` aan en lees een nieuwe `IFillFormatEffectiveData`‑object voordat je kleuren vergelijkt of rapporteert.

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een dia of vorm daadwerkelijk gebruikt na overerving en lokale bijschrijvingen. Voor een dia roep je [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) aan. Voor een achtergrond gebruik je [Background.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/background/geteffective/), en voor een opvulling [FillFormat.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/geteffective/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vorm‑opvulling van een dia:

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

Gebruik effectieve data voor weergavediagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.MasterTheme](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/mastertheme/) inspecteert, kun je een master‑, lay‑out‑, dia‑ of vorm‑bijschrijving missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wijzigt alleen de dia’s die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken behouden hun bestaande thema’s.

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/slidethememanager/) van de dia en initialiseert zijn bijschrift‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s overerven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer je een dia verplaatst en de oorspronkelijke opmaak wilt behouden, kloon je de bron‑master naar de bestemming en kloon je de dia met die master via [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/addclone/) en [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/). Dit houdt de master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en bijschrijvingen?**

Gebruik [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑data‑methoden voor format‑objecten zoals [Background.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/background/geteffective/) en [FillFormat.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/geteffective/). Deze API’s retourneren de opgeloste waarden na toepassing van overerving en bijschrijvingen.