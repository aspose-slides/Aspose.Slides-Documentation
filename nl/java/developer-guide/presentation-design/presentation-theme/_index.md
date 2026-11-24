---
title: Beheer presentatiethema's in Java
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/java/presentation-theme/
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
- thema-lettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Master presentatiethema's in Aspose.Slides voor Java om PowerPoint-bestanden te maken, aanpassen en converteren met consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑gevoelige objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Een presentatie kan tevens thema‑overschrijvingen bevatten op lagere niveaus. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/), terwijl een layout of een individuele dia haar geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze overervingsketen: presentatiethema, master‑overschrijving, layout‑overschrijving en dia‑overschrijving.

![Thema‑onderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties laten de meest voorkomende themaworkflows zien: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overschrijvingen zijn opgelost.

## **Een Thema Inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/)‑object stelt het kleurschema, lettertypeschema en formatschema van het thema bloot via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat u ze wijzigt, is bijzonder nuttig wanneer een presentatie uit een externe bron afkomstig is, omdat het aantal en de inhoud van stijlitems kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen in het thema zijn opgeslagen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
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

Als een bestand meerdere masters gebruikt, mag u niet aannemen dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer layout‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren Wijzigen**

Themagevoelige vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/)‑enumeratie. Wanneer u het bijbehorende item in de [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog steeds naar die themakleur verwijzen, opgezocht tegen de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een thema‑kleurupdate.

Het volgende end‑to‑end‑voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de thema‑kleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve vulkleur af:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Omdat het rechthoek nog steeds gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Vervangt u de scheme‑color door een directe kleur op de vorm, dan heeft een latere wijziging van `Accent4` geen invloed meer op die vulling.

### **Kleuren Uit Het Extra Palet Gebruiken**

PowerPoint leidt lichtere en donkerdere varianten af van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties bloot via de [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/)‑enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  
**2** – Lichtere en donkerdere varianten afgeleid van de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantietransformaties toe op vijf ervan, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Wijzigt `Accent4` later, dan worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑Waarden Toewijzen Aan `IColorScheme`‑Slots**

De [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) dezelfde themaslots blootstelt als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Themalettertypen Wijzigen**

Een themalettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor body‑tekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) geven die sets bloot.

PowerPoint‑compatibele themalettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn‑lt` – Bodylettertype Latin (Klein Latin-lettertype)
* `+mj‑lt` – Koplettertype Latin (Groot Latin-lettertype)
* `+mn‑ea` – Bodylettertype East Asian (Klein East Asian-lettertype)
* `+mj‑ea` – Koplettertype East Asian (Groot East Asian-lettertype)
* `+mn‑cs` – Bodylettertype Complex Script (Klein Complex Script-lettertype)
* `+mj‑cs` – Koplettertype Complex Script (Groot Complex Script-lettertype)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één body‑regel die het secundaire Latin‑themalettertype gebruikt. Vervolgens wijzigt het de themalettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, schakelt niet automatisch wanneer het themalettertype‑schema verandert.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schriftsoorten, zoals Cyrillic, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietypen, zie [PowerPoint Fonts](/slides/nl/java/powerpoint-fonts/).
{{% /alert %}}

### **Thema‑Lettertype‑Referenties Oplossen**

Bij het inspecteren van tekst kan [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) een thema‑referentie zoals `+mn‑lt` teruggeven in plaats van een lettertype‑familienaam. Roep [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) aan met de juiste [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) om die referentie op te lossen. De `+mj`‑ en `+mn`‑prefixen selecteren respectievelijk de hoofd‑ en secundaire lettertype‑sets; de `-lt`, `-ea` en `-cs`‑suffixen selecteren hun Latin, East Asian en Complex Script‑lettertypen.

Haal het effectieve thema op via [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) op het object waarvan het thema op de geïnspecteerde tekst van toepassing is. Voor gewone tekst op een dia roept u deze methode aan op de dia zodat de context de geërfde themagegevens en lokale overschrijvingen bevat. Bij het inspecteren van een layout of master zelf, gebruik dan het eigen effectieve thema. Neem niet aan dat het thema van de eerste master voor elke dia geldt.

Het volgende voorbeeld maakt een tekstgedeelte dat expliciet verwijst naar het secundaire Latin‑lettertype. Het initialiseert een dia‑lettertype‑schema via [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) en stelt de hoofd‑ en secundaire Latin‑families in op `Arial` en `Calibri`, zodat het resultaat reproduceerbaar is zonder invoerbestand.

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

De uitvoer is `+mn‑lt -> Calibri` gevolgd door `Verdana -> Verdana`. De opgeslagen referentie blijft ongewijzigd, terwijl een expliciete familienaam onveranderd wordt geretourneerd. Gebruikt het gedeelte `+mj‑lt`, dan zou het oplossen naar `Arial` in dit thema.

Het oplossen van een thema‑referentie identificeert de lettertype‑familie die door het thema is opgegeven. Het controleert niet of het lettertype beschikbaar is of welk lettertype‑bestand uiteindelijk wordt gebruikt na substitutie of glyph‑fallback tijdens het renderen. Zie [Font Selection Sequence](/slides/nl/java/font-selection-sequence/) en [Font Substitution](/slides/nl/java/font-substitution/) voor die afzonderlijke stappen.

## **Een Thema Kopiëren of Toepassen**

De onderstaande workflows lossen verschillende thema‑gerelateerde problemen op.

### **Een Extern Thema Toepassen Op Dia’s Die Van Een Master Afhangen**

Gebruik [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) wanneer u een PowerPoint‑thema‑bestand (`.thmx`) hebt en elke dia die van een bepaalde master afhangt, opnieuw wilt stijlen. Selecteer de master uit de [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende bewerkingen uit:

1. Maakt een nieuwe master‑dia gebaseerd op de geselecteerde master.  
1. Past het externe thema toe op de nieuwe master.  
1. Wijst de nieuwe master toe aan alle dia’s die voorheen van de geselecteerde master afhankelijk waren.  
1. Retourneert de nieuw gemaakte [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de dia’s die afhankelijk zijn van de eerste master en slaat de presentatie op:

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

Een ongeldig, corrupt of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestandssysteemtoegang, en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia’s die van de geselecteerde master afhankelijk waren, worden opnieuw toegewezen. Dia’s die aan andere masters zijn gekoppeld, behouden hun bestaande masters en thema’s. Thema‑gevoelige kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden afgehandeld ten opzichte van het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overschrijvingen op layout‑ of dia‑niveau kunnen ook voorrang krijgen boven waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, bied ze aan via [custom font sources](/slides/nl/java/custom-font/), of configureer [font substitution](/slides/nl/java/font-substitution/).

Dit is een directe master‑niveau‑workflow: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑ of layout‑thema‑overschrijvingen.

### **Verschillende Externe Thema’s Toepassen In Een Presentatie Met Meerdere Masters**

Wanneer de relevante master van tevoren niet bekend is, haal deze dan op via een representatieve dia met [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) en [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/). Sla de oorspronkelijke master‑referenties op voordat u thema’s toepast, want elke aanroep creëert een nieuwe master in de presentatie.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te lokaliseren en past een verschillend extern thema toe op elke groep:

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

De eerste aanroep beïnvloedt alleen dia’s die afhankelijk waren van `firstGroupMaster`, en de tweede aanroep beïnvloedt alleen dia’s die afhankelijk waren van `secondGroupMaster`. Dia’s die tot een andere master behoren, worden niet opnieuw gestileerd.

### **Een Bron‑Thema Behouden Bij Het Verplaatsen Van Dia’s**

Wilt u een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), kloon vervolgens de dia met [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) en de gekloonde master. Hiermee worden de master, de bijbehorende layouts en het thema samen meegenomen.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming precies gelijk uit moet zien. Het simpelweg kloont content op een ongekoppelde doel‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑Waarden Toepassen Op Een Bestaande Dia**

Moet de doel‑dia op haar huidige master en layout blijven, initialiseert u een dia‑niveau‑overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) kopiëren de drie hoofdthema‑componenten naar de overschrijving.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat andere dia’s erven te veranderen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roept u [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) aan.

### **Een Thema‑Overschrijving Op Een Layout Toepassen**

Een layout‑niveau‑overschrijving is van toepassing op dia’s die die layout gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);

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

Gebruik een master‑ of presentatieniveau‑thema wanneer veel layouts en dia’s hetzelfde basisonwerp moeten delen, een layout‑overschrijving wanneer één layout‑familie een andere styling nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatig veel dia‑niveau‑overschrijvingen maken latere globale thema‑wijzigingen moeilijker te voorspellen.

<!-- visual-explanation:presentation-theme:start -->
[![Een master‑thema voedt twee layouts; een layout‑overschrijving beïnvloedt zijn dia’s behalve een dia met een meer lokale overschrijving.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Een layout‑overschrijving is van toepassing op dia’s die die layout gebruiken tenzij een dia zelf een eigen overschrijving levert. Thema‑gebaseerde waarden volgen hun opgeloste schema; expliciet opgemaakte objecten kunnen hun lokale uiterlijk behouden. Houd overschrijvingen zo smal mogelijk, overeenkomstig de beoogde ontwerp‑uitzondering.*
<!-- visual-explanation:presentation-theme:end -->

## **Achtergrondstijlen Van Het Thema Bijwerken**

De achtergrond‑vullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). PowerPoint kan in de gebruikersinterface meer achtergrondkeuzes aanbieden dan het aantal daadwerkelijke vuldefinities in deze collectie, omdat de UI themavullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrond‑stijlgallerij voor een presentatiethema](presentation-design_8.png)

Inspecteer vóór het gebruiken van een achtergrondstijl zowel de opgeslagen collectie als de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van het indexeren van de Java‑collectie zelf, waar `get_Item(0)` het eerste opgeslagen item betekent. Neem niet aan dat elke presentatie hetzelfde aantal achtergrond‑vullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrond‑vullingen, kent een thematische achtergrond‑referentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themainterventie die door de master wordt gerefereerd en van eventuele achtergrond‑overschrijvingen op layout‑ of dia‑niveau. Gebruikt een dia een eigen achtergrond, dan kan het wijzigen van alleen de master‑achtergrond die dia niet beïnvloeden. Gebruik [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) wanneer u de uiteindelijke achtergrond na toegepast overerven wilt achterhalen.

{{% alert color="warning" title="Warning" %}}
Beschouw de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd bovendien het hard‑coderen van een stijlnummer uit één bestand en aannemen dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn specifiek voor een presentatie.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrond‑opmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/java/presentation-background/).
{{% /alert %}}

## **Thema‑Effecten Bijwerken**

Een themaschema bevat aparte collecties voor vul‑, lijn‑ en effectstijlen, bloot via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). Veel Office‑thema’s bevatten drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gemiddelde en intense opmaak, maar de code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, gemiddelde en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, bloot via [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak blijven mogelijk ongewijzigd.

Het volgende voorbeeld controleert of de vereiste stijlitems bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);

    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor vormen die deze slots refereren, wordt de eerste themalijn‑stijl rood, de derde themavul‑stijl een ondoorzichtige bosgroen, en krijgt de derde effect‑stijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhangen van welke slots elke vorm referereert en of directe opmaak de themastijl overschrijft.

![Thema‑effectstijlen na wijziging van lijn‑, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Voor Een Vorm Thema‑Vul‑ En Lijnstijlen Selecteren**

Een vorm kan onafhankelijk haar vul‑ en omtreklijn‑stijl kiezen via [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) en [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Voor beide methoden selecteert index `1` het eerste item in de bijbehorende themacollectie (`get_Item(0)`) en index `2` het tweede (`get_Item(1)`).

Het volgende voorbeeld zet twee vulstijlen (goud en hemelsblauw) en twee lijnstijlen (donkerblauw op 6 pt en donkerrood op 12 pt) op in het standaardthema van een nieuwe presentatie. Het slaat de dia in drie stadia op zodat u de resultaten in PowerPoint kunt vergelijken.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Beginstijlen | Rechteromtrek wijzigen | Eerste themavulling bewerken |
|:---:|:---:|:---:|
| ![Gouden en hemelsblauwe rechthoeken met bijpassende dunne donkerblauwe omtreklijnen](theme-style-initial.png) | ![De hemelsblauwe rechthoek heeft nu een dikke donkerrode omtrek](theme-style-line-changed.png) | ![De linkerrechthoek wordt nu groen en beide omtreklijnen blijven ongewijzigd](theme-style-fill-changed.png) |

Het selecteren van een andere lijnstijl wijzigt alleen de omtreklijn van de rechterrechthoek. Het bewerken van de eerste themavulling werkt elke vorm bij die die vulstijl gebruikt. Hier wordt alleen de linkerrechthoek groen.

Op een bestaande vorm kan een lokale vul‑, lijn‑ of lijndikte‑kleur die deel van de themastijl overschrijven. Als het wijzigen van een stijl‑index geen zichtbaar effect heeft, controleer dan de [direct formatting](/slides/nl/java/shape-formatting/) van de vorm.

## **Bepalen Of Een Effectieve Vaste Vulling Een Themakuur Gebruikt**

Een vulling kan direct op een object worden opgeslagen of geërfd zijn van een alinea, layout, master, themastijl of een ander opmaak‑niveau. Roep [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) aan om die hiërarchie te resolveren tot een onveranderlijke [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). Alleen wanneer deze `FillType.Solid` is, mag u de eigenschappen van een vaste vulling lezen.

Voor een vaste vulling geeft [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) de uiteindelijke gerenderde RGB‑waarde terug na toepassing van overerving, themalookup en kleurtransformaties. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) retourneert de bijbehorende logische [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/)‑slot, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor.NotDefined` betekent dat de effectieve vaste vulling niet op een scheme‑color is gebaseerd. In een workflow waarin vullingen ofwel thema‑kleuren of directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vulling.

Gebruik niet alleen de lokale [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/)‑waarde om een vulling te classificeren. Een tekstgedeelte kan bijvoorbeeld geen lokaal gedefinieerde scheme‑color hebben, waardoor de lokale waarde `NotDefined` is, terwijl de effectieve vulling een themakleur erft en oplost naar `Text1` of `Accent6`. Omgekeerd vertelt `getSolidFillSchemeColor` u welke logische themaslot de effectieve kleur heeft geproduceerd, maar niet van welk niveau (object, alinea, layout, master, …) die slot afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vorm‑vullingen als tekst‑gedeelte‑vullingen, drukt elk eind‑RGB‑waarde en de bijbehorende scheme‑color af, en markeert vaste vullingen die geen thema‑kleurwijzigingen volgen:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
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

De `NotDefined`‑tak levert een audit‑lijst van vaste vullingen die niet reageren op wijzigingen in themakleurslots. Controleer die objecten wanneer een presentatie een nieuw merkgamma moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de scheme‑waarde verklaart of dat uiterlijk met het thema is verbonden.

Effectieve‑format‑objecten zijn snapshots. Nadat u het presentatiethema, een thema‑overschrijving of enige geërfde opmaak hebt gewijzigd, roep `getEffective` opnieuw aan en lees een nieuw `IFillFormatEffectiveData`‑object voordat u kleuren vergelijkt of rapporteert.

## **Effectieve Thema‑Waarden Lezen**

Ruwe thema‑objecten vertellen u wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen u wat een dia of vorm daadwerkelijk gebruikt nadat overerving en lokale overschrijvingen zijn opgelost. Voor een dia roept u [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruikt u [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/), en voor een vulling [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vorm‑vulling van een dia:

```java
import com.aspose.slides.*;

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
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Gebruik effectieve data voor renderdiagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) inspecteert, kunt u een master‑, layout‑, dia‑ of vorm‑overschrijving missen die de uiteindelijke weergave wijzigt.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**  
Nee. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) wijst alleen de dia’s opnieuw toe die afhankelijk waren van de geselecteerde master. Dia’s die andere masters gebruiken, behouden hun bestaande thema’s.

**Kan ik een thema op één enkele dia toepassen zonder de master te wijzigen?**  
Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) van de dia en initialiseert haar override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**  
Wanneer u een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloon dan de bron‑master in de bestemmingspresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) en kloon vervolgens de dia met die master via [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/). Zo blijven master, layouts en thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overschrijvingen?**  
Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) voor een dia‑ of layout‑thema en de overeenkomstige effectieve‑data‑methoden voor format‑objecten zoals [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/). Deze API’s retourneren de opgeloste waarden na toepassing van overerving en overschrijvingen.