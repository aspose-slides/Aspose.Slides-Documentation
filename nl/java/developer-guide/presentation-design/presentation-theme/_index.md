---
title: Beheer presentatiethema’s in Java
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
description: "Hoofd‑presentatiethema’s in Aspose.Slides voor Java om PowerPoint‑bestanden te maken, aanpassen en converteren met een consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/). Een presentatie kan ook thema‑overschrijvingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia haar geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze erfenisketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Thema‑onderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De secties hieronder tonen de meest voorkomende themaworkflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfenis en overschrijvingen zijn opgelost.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/) object maakt het kleurenschema, lettertypeschema en opmaakschema van het thema bloot via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/), en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat ze worden gewijzigd is vooral nuttig wanneer een presentatie afkomstig is van een externe bron, omdat het aantal en de inhoud van stijl‑items kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/) enumeratie. Wanneer je de overeenkomstige entry in de [IColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, opgelost aan de hand van de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw, en print de effectieve vulkleur:

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

Omdat het rechthoekje gekoppeld blijft aan `Accent4`, wordt zijn zichtbare kleur rood nadat het thema is gewijzigd. Als je de schemakleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen van `Accent4` die vul niet meer beïnvloeden.

### **Kleuren uit het extra palet gebruiken**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides biedt deze transformaties via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/colortransformoperation/) enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten geproduceerd uit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantietransformaties toe op vijf daarvan, en slaat het resultaat op:

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

### **`SchemeColor`‑waarden toewijzen aan `IColorScheme`‑slots**

De [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/) enumeratie maakt gebruik van `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorscheme/) dezelfde themaslots blootlegt als `Dark1`, `Light1`, `Dark2` en `Light2`. De koppeling is vaste:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Themalelettertypen wijzigen**

Een thema‑lettertypeschema bevat een hoofdlettertype voor koppen en een sublettertype voor de hoofdtekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/) geven die sets bloot.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt in tekstopmaak:

* `+mn-lt` – Body Font Latin (Sublettertype Latin)
* `+mj-lt` – Heading Font Latin (Hoofdlettertype Latin)
* `+mn-ea` – Body Font East Asian (Sublettertype East Asian)
* `+mj-ea` – Heading Font East Asian (Hoofdlettertype East Asian)

Het volgende voorbeeld maakt één kop die het hoofdlettertype Latin van het thema gebruikt en één body‑regel die het sublettertype Latin van het thema gebruikt. Vervolgens wijzigt het de themalelettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het sublettertype. Tekst met een expliciete lettertypenaam in plaats van een thema‑identifier zal niet automatisch wisselen wanneer het thema‑lettertypeschema verandert.

De hoofd‑ en sublettertypecollecties kunnen ook lettertype‑mappingen bevatten voor individuele schrijfsystemen, zoals Cyrillic, Arabisch, Japans, Georgisch en Thaana. Om deze mappings te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietekst, zie [PowerPoint Fonts](/slides/nl/java/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De workflows hieronder lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia’s die van een master afhangen**

Gebruik [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/) wanneer je een PowerPoint‑themabestand (`.thmx`) hebt en elke dia die van een bepaalde master afhankelijk is, opnieuw wilt stijlen. Selecteer de master uit de [Presentation.getMasters](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Koppelt de nieuwe master aan alle dia’s die voorheen van de geselecteerde master afhankelijk waren.
1. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de dia’s die afhangen van de eerste master en slaat de presentatie op:

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

Een ongeldige, corrupte of niet‑ondersteunde thema‑file kan een [PptxReadException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, handel fouten bij bestandssysteemtoegang af, en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia’s die van de geselecteerde master afhankelijk waren, worden opnieuw toegewezen. Dia’s die gekoppeld zijn aan andere masters behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden opgelost ten opzichte van het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overschrijvingen op lay‑out‑ en dia‑niveau kunnen ook voorrang krijgen boven waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, lever ze via [custom font sources](/slides/nl/java/custom-font/), of configureer [font substitution](/slides/nl/java/font-substitution/).

Dit is een directe workflow op master‑niveau: de methode accepteert een bestands‑pad naar een `.thmx`‑bestand en vereist geen handmatige aanmaak van thema‑overschrijvingen op dia‑ of lay‑out‑niveau.

### **Verschillende externe thema’s toepassen in een multi‑master presentatie**

Wanneer de relevante master niet van tevoren bekend is, verkrijg deze dan via een representatieve dia met [ISlide.getLayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/) en [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/). Bewaar de oorspronkelijke master‑referenties vóór het toepassen van thema’s, want elke aanroep creëert een nieuwe master in de presentatie.

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

De eerste aanroep beïnvloedt alleen de dia’s die afhankelijk waren van `firstGroupMaster`, en de tweede alleen de dia’s die afhankelijk waren van `secondGroupMaster`. Dia’s die tot een andere master behoren, worden niet opnieuw gestyled.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wil je een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/), kloon vervolgens de dia met [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/) en de gekloonde master. Dit draagt de master, zijn lay‑outs en het gekoppelde thema mee.

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

Dit is de voorkeur‑workflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud naar een ongerelateerde bestemmings‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Themawaarde toepassen op een bestaande dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseert u een dia‑niveau overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/), en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) kopiëren de drie hoofd‑thema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat door andere dia’s wordt geërfd te wijzigen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) aan.

### **Een thema‑overschrijving op een lay‑out toepassen**

Een lay‑out‑niveau overschrijving geldt voor dia’s die die lay‑out gebruiken, tenzij een specifieke dia haar eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatie‑niveau thema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑out‑familie een andere stijl nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau overschrijvingen maken latere globale themawijzigingen moeilijker voorspelbaar.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrond‑vullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/). PowerPoint kan in de UI meer achtergrondkeuzes tonen dan het aantal vuldefinities dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en andere stijlreferenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/). Een stijlin index van `0` betekent geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit is anders dan het indexeren van de Java‑collectie rechtstreeks, waar `get_Item(0)` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvullingen bevat.

Het volgende voorbeeld meldt het beschikbare aantal achtergrondvullingen, wijst een themareferentie voor de achtergrond toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de thema‑entry die door de master wordt gerefereerd en van eventuele achtergrond‑overschrijvingen op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond heeft, verandert alleen de master‑achtergrond die dia mogelijk niet. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/) wanneer je de uiteindelijke achtergrond wilt weten na toepassing van erfenis.

{{% alert color="warning" title="Waarschuwing" %}}
Beschouw de stijlin index niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/java/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑formaatschema bevat aparte vul‑, lijn‑ en effectstijlencollecties die verkrijgbaar zijn via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/), en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijl‑items die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van uit te gaan van een vaste telling.

![Subtiele, gematigde en intensieve themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die naar die themastijl verwijzen; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buitenschaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl een egale bosgroen, en de derde effectstijl krijgt een buitenschaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijl‑slots elke vorm referereert en of directe opmaak de thema‑instelling overschrijft.

![Thema‑effectstijlen na wijziging van lijn-, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Rauwe thema‑objecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een dia of vorm werkelijk gebruikt nadat erfenis en lokale overschrijvingen zijn opgelost. Voor een dia, roep [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond, gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/), en voor een vul, gebruik [FillFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvulling van een dia:

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

Gebruik effectieve data voor weergave‑diagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) inspecteert, kun je een master‑, lay‑out‑, dia‑ of vorm‑overschrijving missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/) wijst alleen de dia’s opnieuw toe die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken, behouden hun bestaande thema’s.

**Kan ik een thema op één dia toepassen zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidethememanager/) van de dia en initialiseert zijn overschrijvings‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer je een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloon dan de bron‑master in de bestemming en kloon de dia met die master via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/) en [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/). Dit houdt master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erfenis en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑data‑methoden voor opmaakobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/). Deze API’s retourneren de opgeloste waarden na toepassing van erfenis en overschrijvingen.