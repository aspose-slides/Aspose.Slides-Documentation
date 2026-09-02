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
- thema-lettertype
- themastijl
- themaeffect
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer master-presentatiethema's in Aspose.Slides voor Android via Java om PowerPoint-bestanden te maken, aan te passen en te converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde reeks kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een thema‑wijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/). Een presentatie kan ook themaanse overschrijvingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze erfketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Themacomponenten: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende themaworkflows: inspecteer een thema, wijzig kleuren en lettertypen, kopieer of pas een thema toe, werk achtergrond‑ en effectstijlen bij, en lees effectieve waarden nadat erf‑ en overschrijvingsregels zijn toegepast.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/)‑object maakt de kleurschema‑, lettertypeschema‑ en formatschema‑definities van het thema beschikbaar via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat ze worden gewijzigd is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer er lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Thema‑kleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/). Wanneer u het overeenkomstige item in de [IColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog steeds naar die themakleur verwijzen, op basis van de nieuwe waarde bijgewerkt. Objecten die een directe RGB‑kleur gebruiken, worden niet veranderd door een thema‑kleurupdate.

Het volgende end‑to‑end‑voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de themakleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw en drukt de effectieve vulkleur af:

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

Omdat het rechthoek nog steeds gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de schematische kleur vervangt door een directe kleur op de vorm, dan zullen latere wijzigingen aan `Accent4` die vulkleur niet meer beïnvloeden.

### **Gebruik kleuren uit het aanvullende palet**

PowerPoint maakt lichtere en donkerdere varianten van een themakleur door kle Transformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de enumeratie [ColorTransformOperation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  
**2** – Lichtere en donkerdere varianten die zijn geproduceerd uit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken op basis van `Accent4`, past luminantie‑transformaties toe op vijf ervan, en slaat het resultaat op:

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

### **Map `SchemeColor`‑waarden naar `IColorScheme`‑slots**

De enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/) gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; ze zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Thema‑lettertypen wijzigen**

Een themaletterschema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor body‑tekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/) geven die sets bloot.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn‑lt` – Body‑lettertype Latin (Minor Latin Font)
* `+mj‑lt` – Kop‑lettertype Latin (Major Latin Font)
* `+mn‑ea` – Body‑lettertype East Asian (Minor East Asian Font)
* `+mj‑ea` – Kop‑lettertype East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één body‑regel die het secundaire Latin‑themalettertype gebruikt. Vervolgens worden de thema‑lettertypen gewijzigd en wordt het resultaat opgeslagen:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch omschakelen wanneer het thema‑lettertypeschema verandert.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schrijfsystemen, zoals Cyrillic, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietekst, zie [PowerPoint Fonts](/slides/nl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande workflows lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia’s die afhankelijk zijn van een master**

Gebruik [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/) wanneer u een PowerPoint‑themabestand (`.thmx`) heeft en elke dia die afhankelijk is van een bepaalde master wilt herstylen. Selecteer de master uit de collectie [Presentation.getMasters](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/), die een [IMasterSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/) implementeert, en geef het pad van het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.  
2. Past het externe thema toe op de nieuwe master.  
3. Koppelt de nieuwe master aan alle dia’s die eerder afhankelijk waren van de geselecteerde master.  
4. Retourneert de zojuist aangemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/).

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

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestands‑systeemtoegang, en sla de presentatie alleen op nadat het thema met succes is toegepast.

Alleen de dia’s die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia’s die gekoppeld zijn aan andere masters behouden hun bestaande masters en themas. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden geëvalueerd tegen het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Lay‑out‑ en dia‑overschrijvingen kunnen eveneens voorrang hebben op waarden die zijn geërfd van de nieuwe master.

Het thema kan lettertypen refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, lever ze via [custom font sources](/slides/nl/androidjava/custom-font/), of configureer [font substitution](/slides/nl/androidjava/font-substitution/).

Dit is een directe master‑level workflow: de methode accepteert een pad naar een `.thmx`‑bestand en vereist geen handmatige creatie van lay‑out‑ of dia‑thema‑overschrijvingen.

### **Verschillende externe thema’s toepassen in een presentatie met meerdere masters**

Wanneer de relevante master niet van tevoren bekend is, verkrijg deze dan via een representatieve dia met [ISlide.getLayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) en [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/). Sla de oorspronkelijke master‑referenties op voordat u thema’s toepast, omdat elke aanroep een nieuwe master in de presentatie creëert.

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

De eerste aanroep beïnvloedt alleen dia’s die afhankelijk waren van `firstGroupMaster`, en de tweede aanroep alleen dia’s die afhankelijk waren van `secondGroupMaster`. Dia’s die tot een andere master behoren, worden niet opnieuw gestyled.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wilt u een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/), kloon vervolgens de dia met [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/) en de gekloonde master. Hiermee worden de master, de lay‑outs en het bijbehorende thema samen overgebracht.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er exact hetzelfde uit moet zien in de bestemmingspresentatie. Het simpelweg klonen van de inhoud naar een niet‑gerelateerde doel‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Wanneer de doel‑dia op zijn huidige master en lay‑out moet blijven, initialiseer dan een dia‑level overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) kopiëren de drie hoofd‑thema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat die dia gebruikt zonder het thema dat andere dia’s erven te wijzigen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) aan.

### **Een thema‑overschrijving toepassen op een lay‑out**

Een lay‑out‑level overschrijving geldt voor alle dia’s die die lay‑out gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatiethema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑outfamilie een andere opmaak nodig heeft, en alleen een dia‑overschrijving voor echte uitzonderingen. Overmatige dia‑level overschrijvingen maken latere globale thema‑wijzigingen moeilijker voorspelbaar.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/). PowerPoint kan in de UI meer achtergrondkeuzes aanbieden dan er fysiek in deze collectie zijn opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteert u de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van het indexeren van de Java‑collectie zelf, waarbij `get_Item(0)` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvullingen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van het thema‑item waarnaar de master verwijst en van eventuele achtergrond‑overschrijvingen op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond heeft, verandert een wijziging alleen in de master‑achtergrond die dia mogelijk niet. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/) wanneer u de uiteindelijke achtergrond na erf‑ en overschrijvingsregels moet weten.

{{% alert color="warning" title="Waarschuwing" %}}
Beschouw de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stelnr. uit één bestand en ervan uitgaan dat dit dezelfde uitstraling heeft in een ander bestand; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondformattering en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/androidjava/presentation-background/).
{{% /alert %}}

## **Thematische effecten bijwerken**

Een thematische formatscheme bevat afzonderlijke collecties voor vul‑, lijn‑ en effectstijlen, beschikbaar via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/) en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gematigde en intense opmaak; de code dient echter elke collectie te inspecteren in plaats van een vast aantal te veronderstellen.

![Subtiele, gematigde en intense thematische effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u in Java toegang krijgt tot deze collecties, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. De indexen waarmee een vorm naar een stijl‑referentie verwijst, vormen een apart concept, beschikbaar via [IShapeStyle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt alle vormen die naar die stijl verwijzen; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buitenste schaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een effen bosgroen, en de derde effectstijl krijgt een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijl‑slots elke vorm gebruikt en of directe opmaak die thema‑instelling overschrijft.

![Thematische effectstijlen na wijziging van lijn-, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Bepalen of een effectieve effen vul een themakleur gebruikt**

Een vul kan direct op een object worden opgeslagen of worden geërfd van een alinea, lay‑out, master, themastijl of een ander formatteringsniveau. Roep [IFillFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifillformat/) aan om die hiërarchie om te vormen tot een onveranderlijke [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifillformateffectivedata/). Alleen wanneer het `FillType.Solid` is, leest u de eigenschappen van de effen vul.

Voor een effen vul geeft [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifillformateffectivedata/) de definitieve gerenderde RGB‑waarde terug na erf‑, thema‑lookup‑ en kleurgtransformaties. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifillformateffectivedata/) geeft de overeenkomstige logische [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/) slot terug, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor.NotDefined` betekent dat de effectieve effen vul niet gebaseerd is op een schemacleur. In een workflow waarin vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vul.

Gebruik niet alleen de lokale [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorformat/)‑waarde om een vul te classificeren. Een tekstgedeelte kan bijvoorbeeld geen lokaal gedefinieerde schemacleur hebben, waardoor de lokale waarde `NotDefined` is, terwijl de effectieve vul een themakleur erft en wordt geresolveerd naar `Text1` of `Accent6`. Omgekeerd vertelt `getSolidFillSchemeColor` u welke logische themaslot de effectieve kleur heeft geproduceerd, maar niet van welk niveau (object, alinea, lay‑out, master of een andere formatteringslaag) deze afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vorm‑vullingen als tekst‑deel‑vullingen, drukt elke uiteindelijke RGB‑waarde en bijbehorende schemacleur af, en markeert effen vullingen die geen thema‑kleurwijzigingen volgen:

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

De `NotDefined`‑tak levert een auditlijst op van effen vullingen die niet reageren op wijzigingen in themakleur‑slots. Bekijk die objecten wanneer een presentatie een nieuw merkpallet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de schemacleur aangeeft of dat uiterlijk met het thema is verbonden.

Effectieve formatteringsobjecten zijn momentopnames. Na het wijzigen van het presentatiethema, een themaverschrijving of enige geërfde opmaak, roep `getEffective` opnieuw aan en lees een nieuw `IFillFormatEffectiveData`‑object voordat u kleuren vergelijkt of rapporteert.

## **Effectieve thema‑waarden lezen**

Ruwe thema‑objecten geven aan wat op een bepaald niveau is gedefinieerd. Effectieve waarden laten zien wat een dia of vorm daadwerkelijk gebruikt na erf‑ en lokale overschrijvingsregels. Voor een dia roep [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/), en voor een vul [FillFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/).

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

Gebruik effectieve gegevens voor weergave‑diagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑overschrijving missen die de uiteindelijke weergave verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/) wijzigt alleen de dia’s die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken, behouden hun bestaande thema’s.

**Kan ik een thema toepassen op één enkele dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidethememanager/) van de dia en initialiseert de overschrijvende thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloon dan de bron‑master naar de bestemming en kloon de dia met die master via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/) en [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/). Hiermee blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erf‑ en overschrijvingsregels?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de corresponderende effectieve‑datamethoden voor format‑objecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/). Deze API’s retourneren de opgeloste waarden na erf‑ en overschrijvingsregels.