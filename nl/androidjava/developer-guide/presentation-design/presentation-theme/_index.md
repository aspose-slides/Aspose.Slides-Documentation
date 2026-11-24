---
title: Beheer presentatiethema's op Android
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/androidjava/presentation-theme/
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
- aanvullend palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor Android via Java om PowerPoint-bestanden te maken, aanpassen en converteren met consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde verzameling van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het themaniveau van de presentatie beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Een presentatie kan ook themaunderschrijvingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia opgelost via deze overervingsketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Thema‑onderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende themastromen: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overschrijvingen zijn opgelost.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/)‑object exposeert het kleurschema, lettertypeschema en formatschema van het thema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat ze gewijzigd worden is bijzonder nuttig wanneer een presentatie van een externe bron komt, omdat het aantal en de inhoud van stijlitems kan variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en rapporteert hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die aan de dia gekoppeld is, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/)‑enumeratie. Wanneer je de overeenkomstige invoer in de [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, afgehandeld met de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de thema‑`Accent4`‑kleur naar rood, slaat de presentatie op, opent deze opnieuw, en print de effectieve vulkleur:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);

    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);

    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Omdat het rechthoek nog steeds gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de schemakleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulling niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint haalt lichtere en donkere varianten af van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/)‑enumeratie.

![Hoofdkleuren van het thema en lichtere en donkere kleuren die gegenereerd zijn vanuit het aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  
**2** – Lichtere en donkere varianten gegenereerd vanuit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantie‑transformaties toe op vijf ervan, en slaat het resultaat op:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden naar `IColorScheme`‑slots toewijzen**

De [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Deze zijn alternatieve namen voor dezelfde themaslots; ze zijn geen waarden die dynamisch worden geconverteerd van de ene vorm naar de andere.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor bodytekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) geven die sets weer.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt in tekstformattering:

* `+mn-lt` – bodylettertype Latin (Minor Latin Font)
* `+mj-lt` – koplettertype Latin (Major Latin Font)
* `+mn-ea` – bodylettertype East Asian (Minor East Asian Font)
* `+mj-ea` – koplettertype East Asian (Major East Asian Font)
* `+mn-cs` – bodylettertype Complex Script (Minor Complex Script Font)
* `+mj-cs` – koplettertype Complex Script (Major Complex Script Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latijnse themalettertype gebruikt en één body‑regel die het secundaire Latijnse themalettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));

    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch wisselen wanneer het thema‑lettertype‑schema verandert.

De hoofd‑ en secundaire lettertypecollecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatie‑lettertypen, zie [PowerPoint Fonts](/slides/nl/androidjava/powerpoint-fonts/).
{{% /alert %}}

### **Themareferenties voor lettertypen oplossen**

Bij het inspecteren van tekst kan [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) een themareferentie zoals `+mn-lt` teruggeven in plaats van een lettertype‑familienaam. Roep [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) aan met de juiste [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) om die referentie op te lossen. De `+mj`‑ en `+mn`‑prefixen selecteren respectievelijk de hoofd‑ en secundaire lettertype‑sets; de `-lt`, `-ea` en `-cs`‑suffixen selecteren hun Latin, East Asian en Complex Script lettertypen.

Verkrijg het effectieve thema via [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) op het object waarvan het thema van toepassing is op de geïnspecteerde tekst. Voor gewone tekst op een dia, roep deze methode aan op de dia zodat de context het geërfde thema van die dia en lokale overschrijvingen omvat. Bij het inspecteren van een lay‑out of master zelf, gebruik zijn eigen effectieve thema. Ga er niet van uit dat het thema van de eerste master op elke dia geldt.

Het volgende voorbeeld maakt een tekstdeel dat expliciet verwijst naar het secundaire Latin‑lettertype. Het initialiseert een dia‑lettertype‑schema via [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) en stelt de hoofd‑ en secundaire Latin‑families in op `Arial` en `Calibri`, waardoor het resultaat reproduceerbaar is zonder een invoerbestand.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

De uitvoer is `+mn-lt -> Calibri` gevolgd door `Verdana -> Verdana`. De opgeslagen referentie blijft ongewijzigd, terwijl een expliciete familienaam ongewijzigd wordt teruggegeven. Als het deel `+mj-lt` zou gebruiken, zou dat in dit thema naar `Arial` worden opgelost.

Het oplossen van een themareferentie identificeert de lettertype‑familie die door het thema is gespecificeerd. Het controleert niet de beschikbaarheid van het lettertype of bepaalt het uiteindelijke lettertype‑bestand dat na substitutie of glyph‑fallback tijdens het renderen wordt gebruikt. Zie [Font Selection Sequence](/slides/nl/androidjava/font-selection-sequence/) en [Font Substitution](/slides/nl/androidjava/font-substitution/) voor die afzonderlijke stappen.

## **Een thema kopiëren of toepassen**

De onderstaande werkstromen lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die afhankelijk zijn van een master**

Gebruik [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) wanneer je een PowerPoint‑themabestand (`.thmx`) hebt en elke dia die van een bepaalde master afhankelijk is, wilt herontwerpen. Selecteer de master uit de [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.  
2. Past het externe thema toe op de nieuwe master.  
3. Wijs de nieuwe master toe aan alle dia's die eerder van de geselecteerde master afhankelijk waren.  
4. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de dia's die van de eerste master afhankelijk zijn en slaat de presentatie op:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/) veroorzaken. Valideer door gebruikers opgegeven paden, behandel fouten bij bestands‑systeemtoegang, en sla de presentatie alleen op nadat het thema succesvol is toegepast.

Alleen de dia's die van de geselecteerde master afhankelijk waren, worden opnieuw toegewezen. Dia's die aan andere masters gekoppeld zijn, behouden hun bestaande masters en thema's. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden afgehandeld ten opzichte van het externe thema. Direct toegekende kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Lay‑out‑niveau en dia‑niveau overschrijvingen kunnen ook voorrang krijgen boven waarden die van de nieuwe master zijn geërfd.

Het thema kan naar lettertypen verwijzen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, lever ze via [custom font sources](/slides/nl/androidjava/custom-font/), of configureer [font substitution](/slides/nl/androidjava/font-substitution/).

Dit is een directe master‑niveau workflow: de methode accepteert een bestandspad naar een `.thmx`-bestand en vereist geen handmatige creatie van dia‑niveau of lay‑out‑niveau themaoverschrijvingen.

### **Verschillende externe thema's toepassen in een presentatie met meerdere masters**

Wanneer de relevante master niet van tevoren bekend is, haal deze dan op van een representatieve dia via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) en [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). Sla de oorspronkelijke master‑referenties op vóór het toepassen van thema's, omdat elke oproep een extra master in de presentatie creëert.

Het volgende voorbeeld gebruikt dia's uit twee secties om hun masters te lokaliseren en past een verschillend extern thema toe op elke groep:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

De eerste oproep heeft alleen invloed op dia's die van `firstGroupMaster` afhankelijk waren, en de tweede oproep heeft alleen invloed op dia's die van `secondGroupMaster` afhankelijk waren. Dia's die tot een andere master behoren, worden niet opnieuw gestyled.

### **Een bronthema behouden bij het verplaatsen van dia's**

Als je een dia naar een andere presentatie wilt verplaatsen en het oorspronkelijke ontwerp wilt behouden, kloon dan de bron‑master in de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), en kloon vervolgens de dia met [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) en de gekloonde master. Dit brengt de master, zijn lay‑outs en het bijbehorende thema samen.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);

        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);

        target.getSlides().addClone(sourceSlide, clonedMaster, true);

        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Dit is de voorkeurs‑workflow wanneer de bron‑dia er identiek uit moet zien in de bestemming. Het simpelweg klonen van inhoud op een ongekoppelde bestemmings‑master kan themagerelateerde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Als de doeldia op zijn huidige master en lay‑out moet blijven, initialiseert dan een dia‑niveau overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) kopiëren de drie hoofd‑thema‑componenten naar de overschrijving.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);

        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());

        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het door andere dia's geërfde thema te wijzigen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) aan.

### **Een themaoverschrijving toepassen op een lay‑out**

Een lay‑out‑niveau overschrijving is van toepassing op dia's die die lay‑out gebruiken, tenzij een specifieke dia zijn eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);

        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());

        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Gebruik een master‑ of presentatie‑niveau thema wanneer veel lay‑outs en dia's hetzelfde basisonwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑out‑familie een andere styling nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau overschrijvingen maken latere globale themawijzigingen moeilijker te voorspellen.

<!-- visual-explanation:presentation-theme:start -->
[![Een mastermenu levert twee lay‑outs; een lay‑out‑overschrijving beïnvloedt zijn dia's, behalve een dia met een meer lokale overschrijving.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Een lay‑out‑overschrijving is van toepassing op dia's die die lay‑out gebruiken, tenzij een dia zijn eigen overschrijving heeft. Thema‑gebaseerde waarden volgen hun opgeloste schema; expliciet opgemaakte objecten kunnen hun lokale uiterlijk behouden. Houd overschrijvingen net zo beperkt als de beoogde ontwerp‑uitzondering.*
<!-- visual-explanation:presentation-theme:end -->

## **Themabackground‑stijlen bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). PowerPoint kan meer achtergrondkeuzes weergeven in de UI dan het aantal feitelijk opgeslagen vuldefinities in deze collectie, omdat de UI themavullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint achtergrondstijlgalerie voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van het direct indexeren van de Java‑collectie, waarbij `get_Item(0)` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie hetzelfde aantal achtergrondvullingen bevat.

Het volgende voorbeeld rapporteert het beschikbare aantal achtergrondvullingen, wijst een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);

    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het zichtbare resultaat hangt af van de temareferentie die door de master wordt gebruikt en van eventuele achtergrondoverschrijvingen op lay‑out‑ of dia‑niveau. Als een dia zijn eigen achtergrond gebruikt, verandert alleen de master‑achtergrond die dia mogelijk niet. Gebruik [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) wanneer je de uiteindelijke achtergrond wilt weten nadat overerving is toegepast.

{{% alert color="warning" title="Warning" %}}
Behandel de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijl‑nummer uit één bestand en aannemen dat het dezelfde weergave heeft in een ander bestand; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondformattering en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/androidjava/presentation-background/).
{{% /alert %}}

## **Thematische effecten bijwerken**

Een thema‑formatschema bevat afzonderlijke collectie‑verzamelingen voor vullingen, lijnen en effectstijlen, toegankelijk via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Typische Office‑thema's bevatten vaak drie belangrijke stijlitems die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van een vaste telling aan te nemen.

![Subtiele, gematigde en intense themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` is de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, toegankelijk via [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijlitems bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenste slagschaduw in de derde effectstijl in, en slaat het resultaat op:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);

    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een effen bosgroen, en de derde effectstijl krijgt een buitenste slagschaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑slots elke vorm referereert en of directe opmaak de thema‑instelling overschrijft.

![Thematische effectstijlen na het wijzigen van lijn-, vul- en slagschaduwinstellingen](presentation-design_11.png)

## **Themavullings‑ en lijntijlen kiezen voor een vorm**

Een vorm kan zijn vulling en omtrek onafhankelijk kiezen via [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) en [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Voor beide methoden selecteert index `1` het eerste item in de overeenkomstige themacollectie (`get_Item(0)`), en selecteert index `2` het tweede (`get_Item(1)`).

Het volgende voorbeeld stelt twee vullingsstijlen (goud en hemelsblauw) en twee lijntijlen (donkerblauw op 6 pt en donkerrood op 12 pt) in het standaardthema van een nieuwe presentatie in. Het slaat de dia op drie momenten op zodat je de resultaten in PowerPoint kunt vergelijken.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Beginstijlen | Rechteromtrek wijzigen | Eerste themavulling bewerken |
|:---:|:---:|:---:|
| ![Gouden en hemelsblauwe rechthoeken met overeenkomende dunne donkerblauwe omtrekken](theme-style-initial.png) | ![De hemelsblauwe rechthoek heeft nu een dikke donkerrrode omtrek](theme-style-line-changed.png) | ![De linkse rechthoek is nu groen en beide omtrekken blijven ongewijzigd](theme-style-fill-changed.png) |

Het selecteren van een andere lijntstijl wijzigt alleen de omtrek van de rechterrechthoek. Het bewerken van de eerste themavulling werkt elke vorm bij die deze gebruikt. Hier wordt alleen de linkse rechthoek groen.

Bij een bestaande vorm kan een lokale vulkleur, lijnkleur of lijndikte dat deel van de themastijl overschrijven. Als het wijzigen van een stijl‑index geen zichtbaar effect heeft, controleer dan de [directe opmaak](/slides/nl/androidjava/shape-formatting/) van de vorm.

## **Bepalen of een effectieve effen vulling een themakleur gebruikt**

Een vulling kan direct op een object worden opgeslagen of geërfd zijn van een alinea, lay‑out, master, themastijl of een ander opmaakniveau. Roep [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) aan om die hiërarchie om te zetten naar een onveranderlijke [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Alleen wanneer deze `FillType.Solid` is, mag je de eigenschappen van de effen vulling lezen.

Voor een effen vulling geeft [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) de uiteindelijke gerenderde RGB‑waarde terug na overerving, themazoeken en kleurtransformaties. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) retourneert de overeenkomstige logische [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/)‑slot, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor.NotDefined` betekent dat de effectieve effen vulling niet gebaseerd is op een schemakleur. In een workflow waarin vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vulling.

Gebruik de lokale [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/)‑waarde niet alleen om een vulling te classificeren. Bijvoorbeeld, een tekstdeel kan geen lokaal gedefinieerde schemakleur hebben, waardoor de lokale waarde `NotDefined` is, terwijl zijn effectieve vulling een themakleur erft en oplost naar `Text1` of `Accent6`. Omgekeerd vertelt `getSolidFillSchemeColor` je welke logische themaslot de effectieve kleur heeft geproduceerd, maar het zegt niet of die slot afkomstig is van het object, de alinea, lay‑out, master, of een ander niveau van de opmaakhiërarchie.

Het volgende voorbeeld laadt een presentatie, controleert zowel vormvullingen als tekstdeelvullingen, drukt elke uiteindelijke RGB‑waarde en bijbehorende schemakleur af, en markeert effen vullingen die geen themakleur‑wijzigingen volgen:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

De `NotDefined`‑tak biedt een audit‑lijst van effen vullingen die niet reageren op veranderingen in themakleur‑slots. Beoordeel die objecten wanneer een presentatie een nieuw merk‑palet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de scheme‑waarde aangeeft of dat uiterlijk aan het thema gekoppeld is.

Effectieve‑formatobjecten zijn momentopnames. Na het wijzigen van het presentatiethema, een themaoverschrijving, of enige geërfde opmaak, roep `getEffective` opnieuw aan en lees een nieuw `IFillFormatEffectiveData`‑object voordat je kleuren vergelijkt of rapporteert.

## **Effectieve themawaarden lezen**

Ruwe themobjecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een dia of vorm daadwerkelijk gebruikt nadat overerving en lokale overschrijvingen zijn opgelost. Voor een dia roep je [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruik je [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), en voor een vulling gebruik je [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvulling van een dia:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();

    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());

    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Gebruik effectieve data voor renderingsdiagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) inspecteert, kun je een master‑, lay‑out‑, dia‑ of vorm‑overschrijving missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) wijst alleen de dia's opnieuw toe die van de geselecteerde master afhankelijk zijn. Dia's die andere masters gebruiken behouden hun bestaande thema's.

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) van de dia en initialiseert zijn overschrijving‑thema. De wijziging blijft lokaal voor die dia; andere dia's blijven hun bestaande thema's erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer je een dia verplaatst en de oorspronkelijke weergave wilt behouden, kloon je de bron‑master naar de bestemming en kloon je de dia met die master via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) en [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). Dit houdt de master, lay‑outs en het thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de bijbehorende effectieve‑datamethoden voor formatobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Deze API's geven de opgeloste waarden terug nadat overerving en overschrijvingen zijn toegepast.