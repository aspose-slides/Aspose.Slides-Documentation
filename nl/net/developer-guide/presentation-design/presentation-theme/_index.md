---
title: Presentatiethema's beheren in .NET
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/net/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- diathema
- thema instellen
- thema wijzigen
- thema beheren
- extern thema
- THMX
- themakleur
- extra palet
- thematisch lettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor .NET om PowerPoint-bestanden te maken, aan te passen en te converteren met een consistente huisstijl."
---
## **Introductie**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een thema‑wijziging veel objecten in één keer kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via de [Presentation.MasterTheme](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/mastertheme/)‑eigenschap. Een presentatie kan ook thema‑overschrijvingen bevatten op lagere niveaus. Een master kan het presentatiethema overschrijven via [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/masterthememanager/overridetheme/), een lay‑out kan zijn geërfde thema overschrijven via [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), en een individuele dia kan hetzelfde doen. In de praktijk wordt het effectieve thema voor een dia resolved via deze erfenisketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Themake componenten: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De secties hieronder tonen de meest voorkomende thema‑workflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfenis en overschrijvingen zijn verwerkt.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/)‑object maakt de [ColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/fontscheme/) en [FormatScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/formatscheme/) van het thema bloot. Het inspecteren van deze collecties vóór wijziging is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijlinvoeren kan variëren.

Het volgende voorbeeld leest de belangrijkste themaparameters en meldt hoeveel achtergrond‑, vullings‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die aan de dia is gekoppeld, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Thema‑kleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/)‑enumeratie. Wanneer u de bijbehorende invoer in de [IColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/icolorscheme/) van het thema wijzigt, worden alle objecten die nog naar die themakleur verwijzen, resolved tegen de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een thema‑kleurupdate.

Het volgende end‑to‑end‑voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw en drukt de effectieve vulkleur af:

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

Omdat het rechthoek nog gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de schemakleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides stelt deze transformaties bloot via [ColorTransformOperation](https://reference.aspose.com/slides/nl/net/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten geproduceerd uit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantietransformaties toe op vijf ervan, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later wijzigt, worden de getransformeerde kleuren opnieuw berekend vanaf de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden toewijzen aan `IColorScheme`‑posities**

De [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl [IColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/icolorscheme/) dezelfde themaposities blootlegt als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaposities; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor body‑tekst. De eigenschappen [FontScheme.Major](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/fontscheme/major/) en [FontScheme.Minor](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/fontscheme/minor/) exposeren die sets.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt in tekstopmaak:

* `+mn-lt` – Body‑lettertype Latin (Minor Latin Font)
* `+mj-lt` – Kop‑lettertype Latin (Major Latin Font)
* `+mn-ea` – Body‑lettertype East Asian (Minor East Asian Font)
* `+mj-ea` – Kop‑lettertype East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één body‑regel die het secundaire Latin‑themalettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst met een expliciete lettertype‑naam in plaats van een thema‑identifier zal niet automatisch omschakelen wanneer het thema‑lettertype‑schema wijzigt.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Voor meer informatie over presentatie‑lettertypen, zie [PowerPoint Fonts](/slides/nl/net/powerpoint-fonts/).

{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande workflows lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die afhankelijk zijn van een master**

Gebruik [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wanneer u een PowerPoint‑thema‑bestand (`.thmx`) heeft en elke dia die afhankelijk is van een specifieke master wilt herstylen. Selecteer de master uit de [Presentation.Masters](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/masters/)‑collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Wijst de nieuwe master toe aan alle dia’s die eerder afhankelijk waren van de geselecteerde master.
1. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de dia’s die afhankelijk zijn van de eerste master, slaat de presentatie op en opent het resultaat opnieuw:

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

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxexception/) of een van zijn op‑formaat gerelateerde subklassen veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestands‑systeemtoegang, en sla de presentatie alleen op nadat het thema met succes is toegepast.

Alleen de dia’s die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia’s die aan andere masters zijn gekoppeld behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden resolved tegen het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Lay‑out‑niveau en dia‑niveau overschrijvingen kunnen ook voorrang krijgen boven waarden die van de nieuwe master zijn geërfd.

Het thema kan verwijzen naar lettertypen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de benodigde lettertypen, lever ze via [custom font sources](/slides/nl/net/custom-font/), of configureer [font substitution](/slides/nl/net/font-substitution/).

Dit is een directe master‑niveau workflow: de methode accepteert een bestands‑pad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑niveau of lay‑out‑niveau thema‑overschrijvingen.

### **Verschillende externe thema’s toepassen in een presentatie met meerdere masters**

Wanneer de relevante master vooraf niet bekend is, haal deze dan op via een representatieve dia met [ISlide.LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/layoutslide/) en [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/masterslide/). Sla de oorspronkelijke master‑referenties op voordat u thema’s toepast, want elke aanroep creëert een nieuwe master in de presentatie.

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

De eerste aanroep beïnvloedt alleen dia’s die afhankelijk waren van `firstGroupMaster`, en de tweede aanroep beïnvloedt alleen dia’s die afhankelijk waren van `secondGroupMaster`. Dia’s die aan een andere master zijn gekoppeld, worden niet hergestyled.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wil u een dia naar een andere presentatie verplaatsen en het origineel design behouden, kloon dan de bron‑master naar de doelpresentatie met [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/addclone/), en kloon vervolgens de dia met [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) en de gekloonde master. Hierdoor worden de master, de lay‑outs en het bijbehorende thema samen meegenomen.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er exact hetzelfde uit moet zien in de bestemming. Het simpelweg klonen van inhoud naar een ongerelateerde doel‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseert u dan een dia‑niveau overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/initfontschemefrom/) en [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiëren de drie hoofd‑thema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat die dia gebruikt zonder het thema te wijzigen dat door andere dia’s wordt geërfd. Om de lokale overschrijving te verwijderen en terug te gaan naar geërfde waarden, roep [OverrideTheme.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/clear/) aan.

### **Een thema‑overschrijving toepassen op een lay‑out**

Een lay‑out‑niveau overschrijving geldt voor dia’s die die lay‑out gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/layoutslidethememanager/) van de lay‑out:

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

Gebruik een master‑ of presentatie‑niveau thema wanneer veel lay‑outs en dia’s hetzelfde basisonderdeel moeten delen, een lay‑out‑overschrijving wanneer één lay‑out‑familie een andere styling nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau overschrijvingen maken latere globale thema‑wijzigingen moeilijker te voorspellen.

## **Thema‑achtergrondstijlen bijwerken**

De achtergrond‑vullingen van het thema worden opgeslagen in [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint kan in de UI meer achtergrondkeuzes presenteren dan het aantal vullingdefinities dat fysiek in deze collectie is opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint galerij voor achtergrondstijlen van een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteer de opgeslagen collectie en de huidige [Background.StyleIndex](https://reference.aspose.com/slides/nl/net/aspose.slides/background/styleindex/). `StyleIndex` gebruikt `0` voor geen thema‑vulling; positieve waarden zijn referenties naar thema‑achtergrondstijlen. Dit verschilt van indexering van de .NET‑collectie zelf, waarbij `[0]` het eerste opgeslagen item betekent. Ga niet ervan uit dat elke presentatie evenveel achtergrond‑vullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, wijst een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themainvoer die door de master wordt gerefereerd en van eventuele achtergrond‑overschrijvingen op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die dia ongewijzigd laten. Gebruik [Background.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/background/geteffective/) wanneer u de uiteindelijke achtergrond na erfenis wilt weten.

{{% alert color="warning" title="Waarschuwing" %}}

Behandeld `StyleIndex` niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en veronderstel dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatiespecifiek.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Voor directe achtergrond‑opmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/net/presentation-background/).

{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑format‑schema bevat afzonderlijke collecties voor [FillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/linestyles/) en [EffectStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/effectstyles/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijl‑invoeren die visueel overeenkomen met subtiele, matige en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van uitgaan van een vast aantal.

![Subtiele, matige en intensieve themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in C# benadert, is de collectie‑index nul‑gebaseerd: `[0]` is de eerste opgeslagen stijl en `[2]` is de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak blijven mogelijk ongewijzigd.

Het volgende voorbeeld controleert of de vereiste stijl‑invoeren bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl een egale bosgroene kleur, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijl‑slots elke vorm referereert en of directe opmaak de thema‑instelling overschrijft.

![Thema‑effectstijlen na wijziging van lijn, vul en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten vertellen wat er op een bepaald niveau is gedefinieerd. Effectieve waarden tonen wat een dia of vorm daadwerkelijk gebruikt nadat erfenis en lokale overschrijvingen zijn verwerkt. Voor een dia, roep [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) aan. Voor een achtergrond, gebruik [Background.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/background/geteffective/), en voor een vulstijl, gebruik [FillFormat.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/geteffective/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvulling van een dia:

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

Gebruik effectieve gegevens voor render‑diagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.MasterTheme](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/mastertheme/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑overschrijving missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Zorgt het toepassen van een extern thema ervoor dat elke dia in de presentatie wordt beïnvloed?**

Nee. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wijzigt alleen de dia’s die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken behouden hun bestaande thema’s.

**Kan ik een thema op één dia toepassen zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/slidethememanager/) van de dia en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer u een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloon dan de bron‑master naar de bestemming en kloon de dia met die master via [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/addclone/) en [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/). Dit houdt de master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erfenis en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) voor een dia‑ of lay‑out‑thema en de bijbehorende effectieve‑data‑methoden voor format‑objecten zoals [Background.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/background/geteffective/) en [FillFormat.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/geteffective/). Deze API’s retourneren de opgeloste waarden na toepassing van erfenis en overschrijvingen.