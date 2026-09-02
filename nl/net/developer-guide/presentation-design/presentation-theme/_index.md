---
title: Beheer presentatiethema's in .NET
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
- themakleur
- extra palet
- thema-lettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer masterpresentatiethema's in Aspose.Slides voor .NET om PowerPoint-bestanden te maken, aan te passen en te converteren met een consistente huisstijl."
---
## **Introductie**

Een presentatiethema definieert een gecoördineerde reeks kleuren, lettertypen, achtergrondstijlen, opvullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als vaste waarde op te slaan, zodat een themawijziging veel objecten in één keer kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via de [Presentation.MasterTheme](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/mastertheme/)‑eigenschap. Een presentatie kan ook themabewerkingen bevatten op lagere niveaus. Een master kan het presentatiethema overschrijven via [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/masterthememanager/overridetheme/), een lay‑out kan zijn geërfde thema overschrijven via [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), en een individuele dia kan hetzelfde doen. In de praktijk wordt het effectieve thema voor een dia bepaald via deze erfenisketen: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Themakelementen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑werkstromen: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfenis en overrides zijn verwerkt.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/)‑object biedt toegang tot het thema‑[ColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/fontscheme/) en [FormatScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/mastertheme/formatscheme/). Deze verzamelingen inspecteren voordat je ze wijzigt is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themaproperties en meldt hoeveel achtergrond‑, opvul‑, lijn‑ en effectstijlen in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer er lay‑out‑ of dia‑overrides aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste opvullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/)‑enumeratie. Wanneer je de overeenkomstige entry in het thema‑[IColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, herberekend op basis van de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet aangepast door een themakleur‑update.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw, en print de effectieve opvulkleur:

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

Omdat het rechthoek nog steeds gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de schemacleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen in `Accent4` die opvulling niet meer beïnvloeden.

### **Kleuren uit de aanvullende palet gebruiken**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides stelt deze transformaties beschikbaar via [ColorTransformOperation](https://reference.aspose.com/slides/nl/net/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit de aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten die zijn voortgebracht uit de hoofdkleuren van het thema.

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

De [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl [IColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/icolorscheme/) dezelfde themaslots blootstelt als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor de hoofdtekst. De [FontScheme.Major](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/fontscheme/major/) en [FontScheme.Minor](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/fontscheme/minor/)‑eigenschappen geven die sets weer.

PowerPoint‑compatibele thema‑lettertype‑identificatoren kunnen worden gebruikt bij tekstopmaak:

* `+mn-lt` – lichaamlettertype Latin (Minor Latin Font)
* `+mj-lt` – koplettertype Latin (Major Latin Font)
* `+mn-ea` – lichaamlettertype Oost‑Aziatisch (Minor East Asian Font)
* `+mj-ea` – koplettertype Oost‑Aziatisch (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één regel tekst die het secundaire Latin‑themalettertype gebruikt. Vervolgens worden de thema‑lettertypen gewijzigd en het resultaat opgeslagen:

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

De kop volgt het hoofdlettertype en de hoofdtekst volgt het secundaire lettertype. Tekst met een expliciete lettertype‑naam in plaats van een thema‑identificator zal niet automatisch omschakelen wanneer het thema‑lettertype‑schema verandert.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑mappings bevatten voor individuele schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Zie [Script‑Specific Theme Fonts](/slides/nl/net/script-specific-font-mappings/) om deze mappings te inspecteren, toe te voegen, te vervangen of te verwijderen.

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietekst, zie [PowerPoint Fonts](/slides/nl/net/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

Er zijn twee veelvoorkomende werkstromen, en ze lossen verschillende problemen op.

### **Een bron‑thema behouden bij het verplaatsen van dia's**

Wil je een dia naar een andere presentatie verplaatsen en het origineel‑ontwerp behouden, kloon dan de bron‑master in de doel­presentatie met [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/addclone/), waarna je de dia kloont met [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) en de gekloonde master. Hierdoor worden de master, de lay‑outs en het bijbehorende thema samen meegenomen.

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

Dit is de voorkeur‑werkstroom wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud op een niet‑gerelateerde doel‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseert dan een dia‑level override vanuit het bron‑thema. De methoden [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/initfontschemefrom/) en [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiëren de drie hoofd‑thema‑componenten naar de override.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat door andere dia's wordt geërfd te wijzigen. Om de lokale override te verwijderen en terug te keren naar geërfde waarden, roep je [OverrideTheme.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/overridetheme/clear/) op.

### **Een thema‑override toepassen op een lay‑out**

Een lay‑out‑level override geldt voor dia's die die lay‑out gebruiken, tenzij een specifieke dia zijn eigen override heeft. Dezelfde initialisatiemethodes kunnen worden gebruikt via de lay‑out‑[LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/layoutslidethememanager/):

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

Gebruik een master‑ of presentatie‑level thema wanneer veel lay‑outs en dia's hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑out‑familie een andere styling nodig heeft, en een dia‑override alleen voor echte uitzonderingen. Overmatig gebruik van dia‑level overrides maakt latere globale themawijzigingen moeilijker te voorspellen.

## **Thema‑achtergrondstijlen bijwerken**

De achtergrond‑opvullingen van het thema worden opgeslagen in [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint kan in de UI meer achtergrondkeuzes tonen dan het aantal feitelijk opgeslagen opvuldefinities in deze collectie, omdat de UI themapvullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.StyleIndex](https://reference.aspose.com/slides/nl/net/aspose.slides/background/styleindex/). `StyleIndex` gebruikt `0` voor geen themapvulling; positieve waarden zijn themaverwijzingen naar achtergrond‑stijlen. Dit verschilt van het indexeren van de .NET‑collectie, waar `[0]` het eerste opgeslagen item betekent. Ga niet ervan uit dat elke presentatie evenveel achtergrond‑opvullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrond‑opvullingen, kent een themaverwijzing voor de achtergrond toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themareferentie die door de master wordt gebruikt en van eventuele achtergrond‑overrides op lay‑out‑ of dia‑level. Als een dia een eigen achtergrond gebruikt, verandert alleen de master‑achtergrond die dia mogelijk niet. Gebruik [Background.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/background/geteffective/) wanneer je de definitieve achtergrond na toepassing van erfenis moet weten.

{{% alert color="warning" title="Warning" %}}
Beschouw `StyleIndex` niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het in een ander bestand dezelfde weergave heeft; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/net/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑format‑schema bevat afzonderlijke [FillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/linestyles/) en [EffectStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/effectstyles/)‑collecties. Typische Office‑thema’s bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gematigde en intense opmaak, maar de code moet elke collectie inspecteren in plaats van uit te gaan van een vast aantal.

![Subtiele, gemiddelde en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in C# benadert, is de collectie‑index nul‑gebaseerd: `[0]` is de eerste opgeslagen stijl en `[2]` de derde. De stijl‑referentie‑indexen van een vorm zijn een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

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

Voor vormen die deze slots refereren, wordt de eerste themalijn‑stijl rood, de derde themavullings‑stijl een effen bosgroen, en krijgt de derde effect‑stijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑slots elke vorm referereert en of directe opmaak de thema‑instelling overschrijft.

![Theme‑effectstijlen na het wijzigen van lijn‑, vullings‑ en schaduwinstellingen](presentation-design_11.png)

## **Effectieve thema‑waarden lezen**

Ruwe thema‑objecten vertellen wat er op een bepaald niveau is gedefinieerd. Effectieve waarden geven aan wat een dia of vorm daadwerkelijk gebruikt nadat erfenis en lokale overrides zijn verwerkt. Voor een dia roep je [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) aan. Voor een achtergrond gebruik je [Background.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/background/geteffective/), en voor een opvulling [FillFormat.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/geteffective/).

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

Gebruik effectieve data voor weergavediagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.MasterTheme](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/mastertheme/) inspecteert, kun je een master, lay‑out, dia‑ of vorm‑override missen die het uiteindelijke uiterlijk wijzigt.

## **FAQ**

**Kan ik een thema toepassen op één enkele dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/slidethememanager/) van de dia en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia's blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer je een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloon je de bron‑master naar de bestemming en kloon je de dia met die master via [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/addclone/) en [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/). Zo blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erfenis en overrides?**

Gebruik [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑data‑methoden voor format‑objecten zoals [Background.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/background/geteffective/) en [FillFormat.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/geteffective/). Deze API’s retourneren de opgeloste waarden nadat erfenis en overrides zijn toegepast.