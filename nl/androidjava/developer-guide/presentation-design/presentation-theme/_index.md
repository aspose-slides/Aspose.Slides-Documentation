---
title: "Beheer presentatiethema's op Android"
linktitle: "Presentatie‑thema"
type: docs
weight: 10
url: /nl/androidjava/presentation-theme/
keywords:
- PowerPoint‑thema
- presentatiethema
- slide‑thema
- thema instellen
- thema wijzigen
- thema beheren
- themakleur
- extra palet
- thema‑lettertype
- thema‑stijl
- thema‑effect
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer masterpresentatiethema's in Aspose.Slides voor Android via Java om PowerPoint‑bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, opvullingen, lijnen en effect­schakelingen. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/). Een presentatie kan ook thema‑overschrijvingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele slide zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een slide opgelost via deze ervaringsketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en slide‑overschrijving.

![Thema‑onderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑werkstromen: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfelijkheid en overschrijvingen zijn verwerkt.

## **Een Thema Inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/)‑object maakt het kleurschema, lettertypeschema en formatschema van het thema beschikbaar via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/). Deze collecties inspecteren voordat je ze wijzigt is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste themaproperties en meldt hoeveel achtergrond‑, opvul‑, lijn‑ en effectstijlen in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet vanuit dat elke slide hetzelfde effectieve thema heeft. Inspecteer de master die bij de slide hoort, en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer lay‑out‑ of slide‑overschrijvingen aanwezig kunnen zijn.

## **Thema‑kleuren Wijzigen**

Thema‑bewuste opvullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/)‑enumeratie. Wanneer je het overeenkomstige item in de [IColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, bijgewerkt naar de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve opvulkleur af:

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

Omdat het rechthoek blijft gekoppeld aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de scheme‑color vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die opvulling niet meer beïnvloeden.

### **Kleuren Gebruiken uit het Extra Palet**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/colortransformoperation/)‑enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  

**2** – Lichtere en donkerdere varianten die zijn afgeleid van de hoofdkleuren.

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

### **`SchemeColor`‑Waarden Aan `IColorScheme`‑Slots Toewijzen**

De [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Thema‑lettertypen Wijzigen**

Een thema‑lettertypeschema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor de lopende tekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/) maken die sets beschikbaar.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin thema‑lettertype gebruikt en één body‑regel die het secundaire Latin thema‑lettertype gebruikt. Vervolgens worden de thema‑lettertypen gewijzigd en wordt het resultaat opgeslagen:

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

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatie‑lettertypen, zie [PowerPoint Fonts](/slides/nl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Een Thema Kopiëren of Toepassen**

Er zijn twee veelvoorkomende werkstromen, en ze lossen verschillende problemen op.

### **Bron‑thema Behouden bij Het Verplaatsen van Slides**

Wil je een slide naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, dan clone je de bron‑master naar de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/), en clone je daarna de slide met [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/) en de geklonde master. Hiermee worden de master, de lay‑outs en het bijbehorende thema samen gekopieerd.

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

Dit is de voorkeurs‑werkstroom wanneer de bron‑slide er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud op een onbehorende doel‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden Toepassen op een Bestaande Slide**

Moet de doel‑slide op zijn huidige master en lay‑out blijven, initialiseert u een slide‑niveau‑overschrijving van het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) kopiëren de drie belangrijkste themacomponenten naar de overschrijving.

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

Dit wijzigt het thema dat door die slide wordt gebruikt zonder het thema dat andere slides erven te veranderen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep je [OverrideTheme.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) aan.

### **Een Thema‑Overschrijving Toepassen op een Lay‑out**

Een lay‑out‑niveau‑overschrijving geldt voor alle slides die die lay‑out gebruiken, tenzij een specifieke slide een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden aangeroepen via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatieniveau‑thema wanneer veel lay‑outs en slides hetzelfde basisonwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑outfamilie een andere styling nodig heeft, en een slide‑overschrijving alleen voor echte uitzonderingen. Overmatig veel slide‑niveau‑overschrijvingen maken latere globale themawijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het Thema Bijwerken**

De achtergrond‑opvullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/). PowerPoint kan meer achtergrondkeuzes aanbieden in de UI dan er fysiek opvuldefinities in deze collectie staan, omdat de UI thema‑opvullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint galerij met achtergrondstijlen voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/). Een stijl‑index van `0` betekent geen thematische opvulling; positieve waarden zijn referenties naar thema‑achtergrondstijlen. Dit verschilt van het indexeren van de Java‑collectie zelf, waar `get_Item(0)` het eerste opgeslagen item betekent. Ga niet ervan uit dat elke presentatie evenveel achtergrond‑opvullingsstijlen bevat.

Het volgende voorbeeld meldt het beschikbare aantal achtergrond‑opvullingen, kent een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van het themapunt dat de master referentieert en van eventuele achtergrond‑overschrijvingen op lay‑out‑ of slide‑niveau. Als een slide een eigen achtergrond heeft, verandert het wijzigen van alleen de master‑achtergrond die slide mogelijk niet. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/) wanneer je de definitieve achtergrond na erfelijkheid wilt weten.

{{% alert color="warning" title="Waarschuwing" %}}
Beschouw de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stilennummer uit één bestand en ervan uitgaan dat het er in een ander bestand hetzelfde uitziet; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfelijkheid, zie [Presentation Background](/slides/nl/androidjava/presentation-background/).
{{% /alert %}}

## **Thema‑effecten Bijwerken**

Een thema‑formatschema bevat afzonderlijke collecties voor opvul‑, lijn‑ en effectstijlen, beschikbaar via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/) en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd­stijlen die visueel overeenkomen met subtiele, gematigde en intense opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, gematigde en intense thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak blijven mogelijk onveranderd.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde opvulstijl, activeert een buitenste schaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themapopvulstijl solid forest green, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhangen van welke stijl‑slots elke vorm gebruikt en of directe opmaak de themastijl overschrijft.

![Thema‑effectstijlen na wijziging van lijn‑, opvul‑ en schaduwinstellingen](presentation-design_11.png)

## **Effectieve Themawaarden Lezen**

Ruwe thema‑objecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een slide of vorm werkelijk gebruikt nadat erfelijkheid en lokale overschrijvingen zijn verwerkt. Voor een slide roep je [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond gebruik je [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/), en voor een opvulling [FillFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond, en de eerste vorm‑opvulling van een slide:

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

Gebruik effectieve data voor render‑diagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) inspecteert, kun je een master‑, lay‑out‑, slide‑ of vorm‑overschrijving missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Kan ik een thema toepassen op één slide zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidethememanager/) van de slide en initialiseert zijn overschrijvingsthema. De wijziging blijft lokaal voor die slide; andere slides blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer je een slide verplaatst en het oorspronkelijke uiterlijk wilt behouden, clone je de bron‑master naar de bestemming en clone je de slide met die master via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/) en [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/). Hiermee blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erfelijkheid en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/) voor een slide‑ of lay‑out‑thema en de overeenkomstige effectieve‑data‑methoden voor formatobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/). Deze API’s retourneren de opgeloste waarden nadat erfelijkheid en overschrijvingen zijn toegepast.