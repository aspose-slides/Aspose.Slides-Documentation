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
- extern thema
- THMX
- themakleur
- extra palet
- themalettertype
- themastijl
- thema‑effect
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor .NET om PowerPoint‑bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Themabewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het themaniveau van de presentatie beschikbaar via de [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/)‑eigenschap. Een presentatie kan ook themavervormingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/), een layout kan zijn geërfde thema overschrijven via [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), en een individuele dia kan hetzelfde doen. In de praktijk wordt het effectieve thema voor een dia opgelost via deze erfenisketen: presentatiethema, master‑overschrijving, layout‑overschrijving en dia‑overschrijving.

![Themake componenten: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende themaworkflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfenis en overschrijvingen zijn verwerkt.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/)‑object maakt de [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) en [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) van het thema bloot. Het inspecteren van deze collecties voordat ze worden gewijzigd is vooral nuttig wanneer een presentatie afkomstig is uit een externe bron, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, mag u niet aannemen dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer er layout‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Themabewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/)‑enumeratie. Wanneer u het overeenkomstige item in de [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) van het thema wijzigt, worden alle objecten die nog naar die themakleur verwijzen, afgehandeld tegen de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleurupdate.

Het volgende end‑to‑end‑voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de themakleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw en print de effectieve vulkleur:

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

Omdat het rechthoekje gekoppeld blijft aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen van `Accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren uit het extra palet gebruiken**

PowerPoint genereert lichtere en donkere varianten van een themakleur door kleurovergangen toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  
**2** – Lichtere en donkere varianten die uit de hoofdkleuren zijn afgeleid.

Het volgende voorbeeld maakt zes rechthoeken op basis van `Accent4`, past luminantie‑transformaties toe op vijf van hen, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend vanuit de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden naar `IColorScheme`‑slots mappen**

De [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene naar de andere vorm worden geconverteerd.

## **Themalettertypen wijzigen**

Een themaletterschema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor de hoofdtekst. De eigenschappen [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) en [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) exposen die sets.

PowerPoint‑compatibele themaletterspecifieke identificatoren kunnen worden gebruikt in tekstopmaak:

* `+mn-lt` – Body‑lettertype Latin (Minor Latin Font)
* `+mj-lt` – Heading‑lettertype Latin (Major Latin Font)
* `+mn-ea` – Body‑lettertype East Asian (Minor East Asian Font)
* `+mj-ea` – Heading‑lettertype East Asian (Major East Asian Font)
* `+mn-cs` – Body‑lettertype Complex Script (Minor Complex Script Font)
* `+mj-cs` – Heading‑lettertype Complex Script (Major Complex Script Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één body‑regel die het secundaire Latin‑themalettertype gebruikt. Vervolgens worden de themaletters gewijzigd en wordt het resultaat opgeslagen:

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

De kop volgt het hoofdlettertype en de hoofdtekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een themaspecificatie, zal niet automatisch wisselen wanneer het themaletterschema verandert.

De hoofd‑ en secundaire lettertypecollecties kunnen ook lettertype‑mappings bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Zie [Script‑Specific Theme Fonts](/slides/nl/net/script-specific-font-mappings/) voor inspectie, toevoeging, vervanging of verwijdering van deze mappings.

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatieteksttypes, zie [PowerPoint‑lettertypen](/slides/nl/net/powerpoint-fonts/).
{{% /alert %}}

### **Themaletterreferenties oplossen**

Bij het inspecteren van tekst kan [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) een themareferentie bevatten, bijvoorbeeld `+mn-lt`, in plaats van een lettertype‑familienaam. Roep [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) aan met de juiste [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) om die referentie op te lossen. De prefixen `+mj` en `+mn` selecteren respectievelijk de hoofd‑ en secundaire lettertype‑sets; de suffixen `-lt`, `-ea` en `-cs` selecteren hun Latin, East Asian en Complex Script‑lettertypen.

Verkrijg het effectieve thema via [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) op het object dat het thema toepast op de geïnspecteerde tekst. Voor gewone tekst op een dia, gebruik `slide.CreateThemeEffective()` zodat de context de geërfde thema‑ en lokale overschrijvingen van die dia omvat. Bij inspectie van een layout of master zelf, gebruik diens eigen effectieve thema. Ga niet uit van het thema van de eerste master voor elke dia.

Het volgende voorbeeld maakt een tekstgedeelte dat expliciet verwijst naar het secundaire Latin‑lettertype. Het initialiseert een dia‑lettertypeschema via [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) en stelt de hoofd‑ en secundaire Latin‑families in op `Arial` en `Calibri`, zodat het resultaat reproduceerbaar is zonder invoerbestand.

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

De uitvoer is `+mn-lt -> Calibri` gevolgd door `Verdana -> Verdana`. De opgeslagen referentie blijft ongewijzigd, terwijl een expliciete familienaam ongewijzigd wordt geretourneerd. Als het gedeelte `+mj-lt` zou gebruiken, zou dit naar `Arial` in dit thema oplossen.

Het oplossen van een themareferentie identificeert het lettertype‑familie‑attribuut dat door het thema is gespecificeerd. Het controleert geen beschikbaarheid van het lettertype en bepaalt niet het uiteindelijke lettertypebestand dat na substitutie of glyph‑fallback tijdens het renderen wordt gebruikt. Zie [Font Selection Sequence](/slides/nl/net/font-selection-sequence/) en [Font Substitution](/slides/nl/net/font-substitution/) voor die afzonderlijke stappen.

## **Een thema kopiëren of toepassen**

De onderstaande workflows lossen verschillende themagerelateerde problemen op.

### **Een extern thema toepassen op dia’s die van een master afhankelijk zijn**

Gebruik [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wanneer u een PowerPoint‑thema‑bestand (`.thmx`) heeft en elke dia die van een bepaalde master afhangt opnieuw wilt stijlen. Selecteer de master uit de [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/)‑collectie, die een [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/) implementeert, en geef het themabestandspad door aan de methode.

De methode voert de volgende bewerkingen uit:

1. Maakt een nieuwe master‑dia gebaseerd op de geselecteerde master.  
1. Past het externe thema toe op de nieuwe master.  
1. Wijs de nieuwe master toe aan alle dia’s die voorheen van de geselecteerde master afhankelijk waren.  
1. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/).

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

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) of een van zijn opmaakgerelateerde subklassen veroorzaken. Valideer paden die door gebruikers worden opgegeven, handel fouten in bestands‑systeem‑toegang af, en sla de presentatie alleen op nadat het thema succesvol is toegepast.

Alleen de dia’s die van de geselecteerde master afhankelijk waren, worden opnieuw toegewezen. Dia’s die bij andere masters horen, behouden hun bestaande masters en thema’s. Themabewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden afgehandeld tegen het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Layout‑‑ en dia‑overschrijvingen kunnen ook voorrang krijgen boven waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, bied ze aan via [custom font sources](/slides/nl/net/custom-font/), of configureer [font substitution](/slides/nl/net/font-substitution/).

Dit is een directe master‑niveau‑workflow: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑‑ of layout‑overschrijvingen.

### **Verschillende externe thema’s toepassen in een multi‑master presentatie**

Wanneer de relevante master niet vooraf bekend is, haal deze dan op via een representatieve dia met [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) en [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/). Bewaar de oorspronkelijke master‑referenties voordat u thema’s toepast, want elke aanroep creëert een nieuwe master in de presentatie.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te lokaliseren en past een verschillend extern thema toe op elke groep:

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

De eerste aanroep beïnvloedt alleen dia’s die afhankelijk zijn van `firstGroupMaster`, en de tweede aanroep beïnvloedt alleen dia’s die afhankelijk zijn van `secondGroupMaster`. Dia’s die bij een andere master horen, worden niet gestyled.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Als u een dia naar een andere presentatie wilt verplaatsen en het oorspronkelijke ontwerp wilt behouden, kloon dan de bron‑master in de doeldocument met [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/), kloon vervolgens de dia met [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) en de gekloonde master. Hiermee wordt de master, de layouts en het bijbehorende thema meegenomen.

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

Dit is de geprefereerde workflow wanneer de bron‑dia er identiek uit moet zien in de bestemming. Alleen het klonen van inhoud naar een ongekoppelde bestemmings‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Als de doel‑dia op zijn huidige master en layout moet blijven, initialiseert u een dia‑niveau‑overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/) en [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiëren de drie hoofd‑themake componenten naar de overschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat andere dia’s erven te veranderen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/) aan.

### **Een thema‑overschrijving op een layout toepassen**

Een layout‑niveau‑overschrijving geldt voor dia’s die die layout gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de layout‑specifieke [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/):

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

Gebruik een master‑ of presentatiethema wanneer veel layouts en dia’s eenzelfde basisontwerp moeten delen, een layout‑overschrijving wanneer één layout‑familie een andere stijl nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau‑overschrijvingen maken latere globale themawijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrond‑vullingen van het thema worden opgeslagen in [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint kan in de UI meer achtergrondkeuzes tonen dan het aantal feitelijk opgeslagen vuldefinities in deze collectie, omdat de UI themavullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteer dan de opgeslagen collectie en de huidige [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/). `StyleIndex` gebruikt `0` voor geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van het indexeren van de .NET‑collectie zelf, waar `[0]` het eerste opgeslagen item betekent. Ga niet uit van eenzelfde aantal achtergrondvullingen in elke presentatie.

Het volgende voorbeeld meldt het beschikbare aantal achtergrondvullingen, kent een themabackground‑referentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van het themaitem dat door de master wordt gerefereerd en van eventuele achtergrond‑overschrijvingen op layout‑ of dia‑niveau. Als een dia zijn eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die dia ongewijzigd laten. Gebruik [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) wanneer u de uiteindelijke achtergrond na erfenis moet weten.

{{% alert color="warning" title="Waarschuwing" %}}
Beschouw `StyleIndex` niet als een nul‑gebaseerde collectiesindex. Vermijd ook hard‑coded stijl‑nummers uit één bestand en de aanname dat ze er hetzelfde uitzien in een ander bestand; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/net/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een themaformat‑schema bevat afzonderlijke collecties voor [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/) en [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, gematigde en intensieve themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in C# benadert, is de collectie‑index nul‑gebaseerd: `[0]` is de eerste opgeslagen stijl en `[2]` is de derde. De indexen die een vorm naar een stijl‑referentie gebruiken zijn een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die naar die themastijl verwijzen; vormen met directe opmaak blijven mogelijk ongewijzigd.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buiten‑schaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots gebruiken, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een effen bosgroen, en de derde effectstijl krijgt een buiten‑schaduw met een afstand van 10 pt. Het exacte visuele resultaat hangt nog steeds af van welke stijl‑slots elke vorm refereert en of directe opmaak de thema‑instelling overschrijft.

![Thema‑effectstijlen na wijziging van lijn, vul en schaduwinstellingen](presentation-design_11.png)

## **Thema‑vul‑ en lijnstijlen voor een vorm selecteren**

Een vorm kan zijn vul‑ en omtreklijn onafhankelijk selecteren via [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) en [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/). Voor beide eigenschappen selecteert index `1` het eerste item in de bijbehorende themacollectie (`FillStyles[0]` of `LineStyles[0]`), en selecteert index `2` het tweede item.

Het volgende voorbeeld stelt twee vulstijlen (goud en hemelsblauw) en twee lijnstijlen (donkerblauw op 6 pt en donkerrood op 12 pt) in het standaardthema van een nieuwe presentatie in. Het slaat de dia op drie momenten op zodat u de resultaten in PowerPoint kunt vergelijken.

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

| Initiële stijlen | Rechts omtrek wijzigen | Eerste themavulling bewerken |
|:---:|:---:|:---:|
| ![Gouden en hemelsblauwe rechthoeken met bijpassende dunne donkerblauwe omtrek](theme-style-initial.png) | ![De hemelsblauwe rechthoek heeft nu een dikke donkerrode omtrek](theme-style-line-changed.png) | ![De linkse rechthoek is nu groen en beide omtrekken blijven ongewijzigd](theme-style-fill-changed.png) |

Het kiezen van een andere lijnstijl verandert alleen de omtrek van de rechthoek rechts. Het bewerken van de eerste themavulling werkt elke vorm bij die deze vult. Hier wordt alleen de linkse rechthoek groen.

Op een bestaande vorm kan een lokale vulkleur, lijnkleur of lijndikte die themastijl overschrijven. Als het wijzigen van een stijl‑index geen zichtbaar effect heeft, controleer dan de [directe opmaak](/slides/nl/net/shape-formatting/) van de vorm.

## **Bepalen of een effectieve effen vul een themakleur gebruikt**

Een vul kan rechtstreeks op een object worden opgeslagen of geërfd worden van een alinea, layout, master, themastijl of een ander opmaak‑niveau. Roep [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) aan om die hiërarchie op te lossen tot een onveranderlijk [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/). Alleen wanneer deze `FillType.Solid` is, moet u de eigenschappen van de effen vul lezen.

Voor een effen vul retourneert [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) de uiteindelijke gerenderde RGB‑waarde na erfenis, thema‑opzoeking en kleurovergangen. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) geeft de overeenkomstige logische [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/)‑slot, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor.NotDefined` betekent dat de effectieve effen vul niet op een schema‑kleur is gebaseerd. In een workflow waarin vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vul.

Gebruik de lokale [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) niet alleen om een vul te classificeren. Bijvoorbeeld, een tekstgedeelte kan geen lokaal gedefinieerde scheme‑color hebben, waardoor de lokale waarde `NotDefined` is, terwijl de effectieve vul een themakleur erft en oplost tot `Text1` of `Accent6`. Omgekeerd geeft `SolidFillSchemeColor` aan welke logische themaslot de effectieve kleur heeft opgeleverd, maar niet van welk hiërarchisch niveau (object, alinea, layout, master, …) die slot afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vormvullingen als tekstgedeelte‑vullingen, print elke uiteindelijke RGB‑waarde en de bijbehorende schema‑kleur, en markeert effen vullingen die geen themakleur‑wijzigingen volgen:

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

De `NotDefined`‑tak levert een auditlijst op van effen vullingen die niet reageren op wijzigingen in themakleur‑slots. Controleer die objecten wanneer een presentatie een nieuw merkkleurpalet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de schema‑waarde uitlegt of dat uiterlijk verbonden is met het thema.

Effectieve‑formatobjecten zijn momentopnames. Na het wijzigen van het presentatiethema, een thema‑overschrijving of enige geërfde opmaak, roep opnieuw `GetEffective` aan en lees een nieuw `IFillFormatEffectiveData`‑object voordat u kleuren vergelijkt of rapporteert.

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten vertellen u wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen u wat een dia of vorm feitelijk gebruikt nadat erfenis en lokale overschrijvingen zijn verwerkt. Voor een dia, roep [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) aan. Voor een achtergrond, gebruik [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/), en voor een vul, gebruik [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/).

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

Gebruik effectieve gegevens voor renderdiagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) inspecteert, kunt u een master, layout, dia of vorm‑overschrijving missen die de uiteindelijke weergave verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) wijst alleen de dia’s opnieuw toe die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken, behouden hun bestaande thema’s.

**Kan ik een thema op één enkele dia toepassen zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) van de dia en initialiseert zijn overschrijvings‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en de bron‑uitstraling wilt behouden, kloont u de bron‑master naar de bestemming en kloont u de dia met die master via [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) en [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/). Hiermee blijven de master, layouts en het thema samen.

**Hoe kan ik de effectieve waarden zien na erfenis en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) voor een dia‑ of layout‑thema en de overeenkomstige effectieve‑data‑methoden voor formatobjecten zoals [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) en [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/). Deze API’s retourneren de opgeloste waarden na erfenis en overschrijving.