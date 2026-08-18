---
title: Beheer presentatiethema's in Java
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/java/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- diathema
- thema instellen
- thema wijzigen
- thema beheren
- themakleur
- aanvullend palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer de masterpresentatiethema's in Aspose.Slides voor Java om PowerPoint‑bestanden te maken, aanpassen en converteren met een consistente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde reeks kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/). Een presentatie kan ook themaunderschrijvingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia bepaald via deze erfketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Themakelementen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De secties hieronder laten de meest voorkomende thema‑workflows zien: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken en effectieve waarden lezen nadat erf‑ en overschrijvingsregels zijn toegepast.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/)‑object maakt het kleuren‑schema, lettertype‑schema en opmaak‑schema van het thema bekend via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat je ze wijzigt, is vooral nuttig wanneer een presentatie afkomstig is uit een externe bron, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en meldt hoeveel achtergrond-, vul-, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/)‑enumeratie. Wanneer je de overeenkomstige invoer in de [IColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, aangepast aan de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de themakleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw en drukt de effectieve vulkleur af:

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

Omdat het rechthoek blijft gekoppeld aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren uit het extra palet gebruiken**

PowerPoint genereert lichtere en donkere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/colortransformoperation/)‑enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  

**2** – Lichtere en donkerdere varianten die zijn geproduceerd uit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantietransformaties toe op vijf ervan en slaat het resultaat op:

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

### **`SchemeColor`‑waarden aan `IColorScheme`‑slots toewijzen**

De [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorscheme/) dezelfde themaslots blootlegt als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor body‑tekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/) maken die sets bloot.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt in tekstopmaak:

* `+mn-lt` – Body‑lettertype Latijn (Minor Latin Font)
* `+mj-lt` – Kop‑lettertype Latijn (Major Latin Font)
* `+mn-ea` – Body‑lettertype Oost‑Aziaans (Minor East Asian Font)
* `+mj-ea` – Kop‑lettertype Oost‑Aziaans (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latijn‑themalettertype gebruikt en één body‑regel die het secundaire Latijn‑themalettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de body‑tekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch veranderen wanneer het thema‑lettertype‑schema wordt aangepast.

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatie‑lettertypen, zie [PowerPoint Fonts](/slides/nl/java/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

Er zijn twee gangbare workflows, en ze lossen verschillende problemen op.

### **Bron‑thema behouden bij het verplaatsen van dia’s**

Wil je een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/), waarna je de dia kloont met [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/) en de gekloonde master. Dit draagt de master, de lay‑outs en het bijbehorende thema samen.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud op een ongekoppelde bestemmings‑master kan themagedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseert u een dia‑niveau‑overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) kopiëren de drie hoofdthema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema te veranderen dat door andere dia’s wordt geërfd. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep je [OverrideTheme.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) aan.

### **Een thema‑overschrijving toepassen op een lay‑out**

Een lay‑out‑niveau‑overschrijving geldt voor alle dia’s die die lay‑out gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/layoutslidethememanager/) worden gebruikt:

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

Gebruik een master‑ of presentatie‑niveau‑thema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑out‑familie een andere styling nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau‑overschrijvingen maken latere globale thema‑wijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrond‑vullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/). PowerPoint kan meer achtergrondkeuzes tonen in de UI dan het aantal vuldefinities dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van het indexeren van de Java‑collectie zelf, waarbij `get_Item(0)` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrond‑vulstijlen bevat.

Het volgende voorbeeld meldt het beschikbare aantal achtergrondvullingen, wijst een thematische achtergrondreferentie toe aan de eerste master en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de thema‑invoer waarnaar de master verwijst en van eventuele achtergrond‑overschrijvingen op lay‑out‑ of dia‑niveau. Als een dia zijn eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die dia eventueel niet beïnvloeden. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/) wanneer je de uiteindelijke achtergrond wilt weten na toepassing van erf‑regels.

{{% alert color="warning" title="Warning" %}}
Beschouw de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hardcoderen van een stijlnummer uit één bestand en aannemen dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/java/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑opmaakschema bevat afzonderlijke collecties voor vul‑, lijn‑ en effectstijlen, blootgesteld via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/) en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, gematigde en intense opmaak, maar code moet elke collectie inspecteren in plaats van uit te gaan van een vast aantal items.

![Subtiele, gematigde en intense themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, blootgesteld via [IShapeStyle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die naar die thema‑stijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijlitems bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenste schaduw in bij de derde effectstijl en slaat het resultaat op:

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

Voor vormen die naar deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een effen bosgroen, en de derde effectstijl krijgt een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑slots elke vorm referereert en of directe opmaak de themastijl overschrijft.

![Thema‑effectstijlen na wijziging van lijn‑, vul‑ en schaduw‑instellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een dia of vorm daadwerkelijk gebruikt nadat erf‑ en lokale overschrijvingsregels zijn toegepast. Voor een dia roep je [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruik je [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/), en voor een vul‑object gebruik je [FillFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/).

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

Gebruik effectieve gegevens voor render‑diagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) inspecteert, kun je een master‑, lay‑out‑, dia‑ of vorm‑overschrijving missen die de uiteindelijke weergave wijzigt.

## **FAQ**

**Kan ik een thema toepassen op één enkele dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidethememanager/) van de dia en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer je een dia verplaatst en de originele uitstraling wilt behouden, kloon je de bron‑master in de bestemming en kloon je de dia met die master via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/) en [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/). Dit houdt de master, lay‑outs en het thema samen.

**Hoe kan ik de effectieve waarden zien na erf‑ en overschrijvingsregels?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de bijbehorende effectieve‑data‑methoden voor opmaakobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/). Deze API’s retourneren de opgeloste waarden nadat erf‑ en overschrijvingsregels zijn toegepast.