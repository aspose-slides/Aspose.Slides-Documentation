---
title: "Beheer presentatiethema's op Android"
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/androidjava/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- diathema
- thema instellen
- thema wijzigen
- thema beheren
- themakleur
- extra palet
- themalettertype
- themastijl
- themabeeld
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer hoofdpresentatiethema's in Aspose.Slides voor Android via Java om PowerPoint-bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde reeks kleuren, lettertypen, achtergrondstijlen, opvullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten in één keer kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/). Een presentatie kan ook themabewerkingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze erf‑keten: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Themakelementen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑workflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en de effectieve waarden lezen nadat erf‑ en overschrijvingsregels zijn toegepast.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/)‑object maakt het kleurenschema, lettertypeschema en formaat‑schema van het thema beschikbaar via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/). Het inspecteren van deze collecties vóór wijziging is vooral nuttig wanneer een presentatie uit een externe bron afkomstig is, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en rapporteert hoeveel achtergrond‑, opvul‑, lijn‑ en effectstijlen er in het thema opgeslagen zijn:

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

Als een bestand meerdere masters gebruikt, mag u niet aannemen dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overwrites mogelijk zijn.

## **Themakleuren wijzigen**

Thema‑bewuste opvullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/)‑enumeratie. Wanneer u de overeenkomstige invoer in de [IColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, bijgewerkt met de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het onderstaande end‑to‑end‑voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw en drukt de effectieve opvulkleur af:

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

Omdat het rechthoek nog steeds gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is aangepast. Als u de schematische kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die opvulling niet meer beïnvloeden.

### **Kleuren uit het extra palet gebruiken**

PowerPoint leidt lichtere en donkerdere varianten af van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/colortransformoperation/)‑enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten die zijn gegenereerd uit de hoofdkleuren van het thema.

Het onderstaande voorbeeld maakt zes rechthoeken op basis van `Accent4`, past luminantie‑transformaties toe op vijf ervan en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later wijzigt, worden de getransformeerde kleuren opnieuw berekend vanaf de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden aan `IColorScheme`‑slots toewijzen**

De [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Themalettertypen wijzigen**

Een thema‑lettertypeschema bevat een hoofdlettertype‑set voor koppen en een secundaire set voor de body‑tekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/) exposeren die sets.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen gebruikt worden in tekstopmaak:

* `+mn-lt` – Body‑lettertype Latin (Minor Latin Font)
* `+mj-lt` – Kop‑lettertype Latin (Major Latin Font)
* `+mn-ea` – Body‑lettertype East Asian (Minor East Asian Font)
* `+mj-ea` – Kop‑lettertype East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één body‑regel die het secundaire Latin‑themalettertype gebruikt. Vervolgens worden de thema‑lettertypen gewijzigd en het resultaat opgeslagen:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst met een expliciete lettertype‑naam in plaats van een thema‑identifier zal niet automatisch wisselen wanneer het thema‑lettertypeschema wordt gewijzigd.

De hoofd‑ en secundaire lettertypecollecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatietekst, zie [PowerPoint Fonts](/slides/nl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

Er zijn twee veelvoorkomende workflows, en ze lossen verschillende problemen op.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wilt u een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloont u de bron‑master naar de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/), en daarna kloont u de dia met [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/) en de gekloonde master. Hiermee worden de master, de lay‑outs en het bijbehorende thema samen meegenomen.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud op een niet‑gerelateerde doel‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseert u een dia‑niveau‑override vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) kopiëren de drie hoofd‑thema‑componenten naar de override.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat andere dia’s erven te veranderen. Om de lokale override te verwijderen en terug te gaan naar de geërfde waarden, roept u [OverrideTheme.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) aan.

### **Een thema‑override toepassen op een lay‑out**

Een lay‑out‑niveau‑override geldt voor dia’s die die lay‑out gebruiken, tenzij een specifieke dia een eigen override heeft. Dezelfde initialisatiemethoden kunnen gebruikt worden via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Gebruik een thema op master‑ of presentatieniveau wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑out‑familie een andere styling nodig heeft, en een dia‑override alleen voor echte uitzonderingen. Overmatige dia‑niveau‑overwrites maken latere globale themawijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrond‑opvullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/). PowerPoint kan in de gebruikersinterface meer achtergrondkeuzes tonen dan het aantal fysiek opgeslagen opvuldefinities in deze collectie, omdat de UI thema‑opvullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteert u de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/). Een stijl‑index van `0` betekent geen thematische opvulling; positieve waarden zijn verwijzingen naar thema‑achtergrondstijlen. Dit verschilt van het indexeren van de Java‑collectie zelf, waarbij `get_Item(0)` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondopvullingsstijlen bevat.

Het onderstaande voorbeeld meldt het beschikbare aantal achtergrondopvullingen, kent een thematische achtergrondreferentie toe aan de eerste master en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de door de master gerefereerde thema‑entry en van eventuele achtergrond‑overwrites op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die dia niet beïnvloeden. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/) wanneer u de uiteindelijke achtergrond na erf‑toepassing moet weten.

{{% alert color="warning" title="Warning" %}}
Behandel de stijl‑index niet als een nul‑gebaseerde collecties‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/androidjava/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑formaatschema bevat afzonderlijke collecties voor opvul‑, lijn‑ en effectstijlen, beschikbaar via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/) en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gematigde en intense opmaak, maar code moet elke collectie inspecteren i.p.v. een vaste telling aan te nemen.

![Subtiele, gematigde en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, beschikbaar via [IShapeStyle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het onderstaande voorbeeld controleert of de vereiste stijlitems bestaan, wijzigt de eerste lijn‑stijl, wijzigt de derde opvul‑stijl, schakelt een buiten­schaduw in bij de derde effect‑stijl en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijn‑stijl rood, de derde themapvul‑stijl een effen bosgroen en krijgt de derde effect‑stijl een buiten­schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑slots elke vorm referereert en of directe opmaak de themastijl overschrijft.

![Thema‑effectstijlen na wijziging van lijn‑, opvul‑ en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten tonen wat op een bepaald niveau is gedefinieerd. Effectieve waarden tonen wat een dia of vorm daadwerkelijk gebruikt na erf‑ en lokale overrides. Voor een dia roept u [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruikt u [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/), en voor een opvulling [FillFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vorm‑opvulling van een dia:

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

Gebruik effectieve data voor weergavediagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑override missen die de uiteindelijke weergave verandert.

## **FAQ**

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidethememanager/) van de dia en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en zijn oorspronkelijke uiterlijk wilt behouden, kloont u de bron‑master naar de bestemming en kloont u de dia met die master via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/) en [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/). Hiermee blijven de master, lay‑outs en het thema samen.

**Hoe kan ik de effectieve waarden zien na erf‑ en overrides?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑data‑methoden voor formatobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/). Deze API’s geven de opgeloste waarden terug nadat erf‑ en overrides zijn toegepast.