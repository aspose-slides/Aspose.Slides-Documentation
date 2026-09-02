---
title: Beheer presentatiethema's in Java
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/java/presentation-theme/
keywords:
- PowerPoint-thema
- presentatie-thema
- dia-thema
- thema instellen
- thema wijzigen
- thema beheren
- extern thema
- THMX
- thematiekleur
- aanvullend palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheers de hoofdpresentatiethema's in Aspose.Slides voor Java om PowerPoint-bestanden te maken, aanpassen en converteren met een consistente huisstijl."
---
## **Introductie**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een thema‑wijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/). Een presentatie kan ook thema‑overschrijvingen bevatten op lagere niveaus. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/masterthememanager/), terwijl een layout of een individuele dia haar geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze overervingsketen: presentatiethema, master‑overschrijving, layout‑overschrijving en dia‑overschrijving.

![Thema‑onderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De secties hieronder tonen de meest voorkomende thema‑workflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overschrijvingen zijn toegepast.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/)‑object biedt de kleuren‑, lettertype‑ en opmaakschema’s van het thema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/), en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/). Het inspecteren van deze collecties vóór wijzigingen is vooral nuttig wanneer een presentatie afkomstig is van een externe bron, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de hoofd‑thema‑eigenschappen en meldt hoeveel achtergrond‑, vulling‑, lijn‑ en effectstijlen in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer er layout‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/)‑enumeratie. Wanneer u het overeenkomstige item in de [IColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, aangepast aan de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve vulkleur af:

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

Omdat het rechthoekige object gekoppeld blijft aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulling niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint leidt lichtere en donkerdere varianten af van een themakleur door kleurtransformaties toe te passen. Aspose.Slides biedt deze transformaties via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/colortransformoperation/)‑enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren die uit het aanvullende palet zijn gegenereerd](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten die zijn afgeleid van de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantietransformaties toe op vijf van hen, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later wijzigt, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden toewijzen aan `IColorScheme`‑posities**

De [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorscheme/) dezelfde themaposities exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaposities; ze zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor de hoofdtekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/) geven die sets vrij.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt bij tekstopmaak:

* `+mn-lt` – Body‑lettertype Latin (Minor Latin Font)
* `+mj-lt` – Kop‑lettertype Latin (Major Latin Font)
* `+mn-ea` – Body‑lettertype East Asian (Minor East Asian Font)
* `+mj-ea` – Kop‑lettertype East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑thema‑lettertype gebruikt en één body‑regel die het secundaire Latin‑thema‑lettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier schakelt niet automatisch over wanneer het thema‑lettertype‑schema wijzigt.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietypen, zie [PowerPoint Fonts](/slides/nl/java/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De workflows hieronder lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die afhankelijk zijn van een master**

Gebruik [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/) wanneer u een PowerPoint‑thema‑bestand (`.thmx`) heeft en elke dia wilt restylen die afhankelijk is van een bepaalde master. Selecteer de master uit de [Presentation.getMasters](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.
2. Past het externe thema toe op de nieuwe master.
3. Ken de nieuwe master toe aan alle dia's die voorheen afhankelijk waren van de geselecteerde master.
4. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de dia's die afhankelijk zijn van de eerste master en slaat de presentatie op:

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

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestands‑systeemtoegang, en sla de presentatie pas op nadat het thema met succes is toegepast.

Alleen de dia's die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia's die aan andere masters zijn gekoppeld behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden afgeleid van het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Layout‑niveau en dia‑niveau overschrijvingen kunnen ook voorrang krijgen boven waarden die uit de nieuwe master worden geërfd.

Het thema kan lettertypen refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de benodigde lettertypen, lever ze via [custom font sources](/slides/nl/java/custom-font/), of configureer [font substitution](/slides/nl/java/font-substitution/).

Dit is een directe master‑niveau workflow: de methode accepteert een pad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑niveau of layout‑niveau thema‑overschrijvingen.

### **Verschillende externe thema's toepassen in een presentatie met meerdere masters**

Wanneer de relevante master niet op voorhand bekend is, haal deze op via een representatieve dia met [ISlide.getLayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/) en [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/). Bewaar de originele master‑referenties voordat u thema’s toepast, omdat elke oproep een extra master in de presentatie creëert.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te vinden en past een verschillend extern thema toe op elke groep:

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

De eerste oproep beïnvloedt alleen de dia's die afhankelijk waren van `firstGroupMaster`, en de tweede oproep beïnvloedt alleen de dia's die afhankelijk waren van `secondGroupMaster`. Dia's die tot een andere master behoren, worden niet restyled.

### **Bron‑thema behouden bij het verplaatsen van dia's**

Als u een dia naar een andere presentatie wilt verplaatsen en het oorspronkelijke ontwerp wilt behouden, kloon dan de bron‑master in de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/), kloon daarna de dia met [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/) en de gekloonde master. Hiermee worden de master, de layout‑samenstellingen en het bijbehorende thema meegenomen.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg kopiëren van inhoud naar een niet‑gerelateerde doel‑master kan themagebaseerde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Themawaarden toepassen op een bestaande dia**

Als de doel‑dia op zijn huidige master en layout moet blijven, initialiseert u een dia‑niveau overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/), en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) kopiëren de drie hoofd‑thema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat andere dia’s erven te veranderen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) aan.

### **Een thema‑overschrijving toepassen op een layout**

Een layout‑niveau overschrijving geldt voor alle dia’s die die layout gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatie‑niveau thema wanneer veel layouts en dia’s hetzelfde basisonwerp moeten delen, een layout‑overschrijving wanneer één layout‑familie een andere styling nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau overschrijvingen maken latere globale themawijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/). PowerPoint kan in de gebruikersinterface meer achtergrondkeuzes presenteren dan het aantal vullingsdefinities dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteert u de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn thematisch‑achtergrond‑stijl‑referenties. Dit verschilt van het indexeren van de Java‑collectie zelf, waarbij `get_Item(0)` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, wijst een thematische achtergrond‑referentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themareferentie die door de master wordt gebruikt en van eventuele achtergrond‑overschrijvingen op layout‑ of dia‑niveau. Als een dia een eigen achtergrond gebruikt, verandert een wijziging van alleen de master‑achtergrond die dia mogelijk niet. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/) wanneer u de definitieve achtergrond na overerving wilt weten.

{{% alert color="warning" title="Warning" %}}
Behandel de stijl‑index niet als een nul‑gebaseerde collecties‑index. Vermijd tevens hard‑codering van een stijlnummer uit één bestand en de veronderstelling dat dit in een ander bestand er hetzelfde uitziet; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/java/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑opmaakschema bevat afzonderlijke collecties voor vulling, lijn en effect, beschikbaar via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/), en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, gematigde en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` is de derde. De stijl‑referentie‑indexen van een vorm zijn een apart concept, beschikbaar via [IShapeStyle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijn‑stijl, wijzigt de derde vulling‑stijl, activeert een buitenste schaduw in de derde effect‑stijl, en slaat het resultaat op:

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

Voor vormen die deze posities refereren, wordt de eerste themalijn‑stijl rood, de derde themavulling‑stijl een doorzichtige bosgroen, en krijgt de derde effect‑stijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijlposities elke vorm gebruikt en of directe opmaak de thema‑instelling overschrijft.

![Thema‑effectstijlen na wijziging van lijn‑, vulling‑ en schaduwinstellingen](presentation-design_11.png)

## **Bepalen of een effectieve effen vulling een themakleur gebruikt**

Een vulling kan rechtstreeks op een object worden opgeslagen of geërfd zijn van een alinea, layout, master, themastijl of een ander opmaak‑niveau. Roep [IFillFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifillformat/) aan om die hiërarchie om te zetten naar een onveranderlijke [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifillformateffectivedata/). Alleen wanneer dit `FillType.Solid` is, moet u de effen‑vullings‑eigenschappen lezen.

Voor een effen vulling geeft [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifillformateffectivedata/) de definitieve gerenderde RGB‑waarde terug na overerving, themalook‑up en kleurtransformaties. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifillformateffectivedata/) levert de overeenkomstige logische [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/) slot, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor.NotDefined` betekent dat de effectieve effen vulling niet gebaseerd is op een scheme‑kleur. In een workflow waarbij vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vulling.

Gebruik niet alleen de lokale [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorformat/)‑waarde om een vulling te classificeren. Bijvoorbeeld, een tekstdelen kan geen lokaal gedefinieerde scheme‑kleur hebben, waardoor de lokale waarde `NotDefined` is, terwijl de effectieve vulling een themakleur erft en resolveert naar `Text1` of `Accent6`. Omgekeerd geeft `getSolidFillSchemeColor` aan welke logische themaslot de effectieve kleur heeft geproduceerd, maar niet van welk niveau (object, alinea, layout, master, enz.) deze slot afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vorm‑vullingen als tekstdelen‑vullingen, drukt elke uiteindelijke RGB‑waarde en bijbehorende scheme‑kleur af, en markeert effen vullingen die geen themakleur‑wijzigingen volgen:

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

De `NotDefined`‑tak biedt een audit‑lijst van effen vullingen die niet reageren op wijzigingen in themakleur‑slots. Review deze objecten wanneer een presentatie een nieuw merk‑palet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de scheme‑waarde uitlegt of dat uiterlijk aan het thema is gekoppeld.

Effectieve‑format‑objecten zijn momentopnames. Na het wijzigen van het presentatiethema, een thema‑overschrijving, of enige geërfde opmaak, roep `getEffective` opnieuw aan en lees een nieuw `IFillFormatEffectiveData`‑object voordat u kleuren vergelijkt of rapporteert.

## **Effectieve thema‑waarden lezen**

Ruwe thema‑objecten vertellen wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen wat een dia of vorm daadwerkelijk gebruikt nadat overerving en lokale overschrijvingen zijn opgelost. Voor een dia, roep [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond, gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/), en voor een vulling, gebruik [FillFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/).

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

Gebruik effectieve data voor weergavediagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) inspecteert, kunt u een master‑, layout‑, dia‑ of vorm‑overschrijving missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/) wijst alleen de dia's opnieuw toe die afhankelijk zijn van de geselecteerde master. Dia's die andere masters gebruiken, behouden hun bestaande thema’s.

**Kan ik een thema toepassen op een enkele dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidethememanager/) van de dia en initialiseert zijn overtollige thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer u een dia verplaatst en zijn oorspronkelijke uiterlijk wilt behouden, kloont u de bron‑master in de bestemming en kloont u de dia met die master via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/) en [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/). Hiermee blijven de master, layouts en thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/) voor een dia‑ of layout‑thema en de overeenkomstige effectieve‑data‑methoden voor format‑objecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/). Deze API’s retourneren de waarden nadat overerving en overschrijvingen zijn toegepast.