---
title: "Beheer presentatiethema's in Java"
linktitle: "Presentatiethema"
type: docs
weight: 10
url: /nl/java/presentation-theme/
keywords:
- "PowerPoint-thema"
- "presentatiethema"
- "dia-thema"
- "thema instellen"
- "thema wijzigen"
- "thema beheren"
- "themakleur"
- "aanvullend palet"
- "themalettertype"
- "themastijl"
- "thema-effect"
- "PowerPoint"
- "OpenDocument"
- "presentatie"
- "Java"
- "Aspose.Slides"
description: "Beheer presentatiethema's in Aspose.Slides voor Java om PowerPoint-bestanden te maken, aan te passen en te converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/). Een presentatie kan ook themabijstellingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/masterthememanager/), terwijl een layout of een individuele dia haar geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia opgelost via deze overervingsketen: presentatiethema, master‑overschrijving, layout‑overschrijving en dia‑overschrijving.

![Thema‑onderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑workflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overschrijvingen zijn verwerkt.

## **Een Thema Inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/) object biedt toegang tot het kleurschema, lettertypeschema en formatschema van het thema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat ze worden gewijzigd is vooral nuttig wanneer een presentatie van een externe bron afkomstig is, omdat het aantal en de inhoud van style‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste thema‑eigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

## **Themakleuren Wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/) enumeratie. Wanneer je de overeenkomstige entry in de [IColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, geëvalueerd tegen de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

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

Omdat de rechthoek gekoppeld blijft aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de schemakleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren uit het Aanvullende Palet Gebruiken**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides exposeert deze transformaties via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/colortransformoperation/) enumeratie.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten die zijn gegenereerd uit de hoofdkleuren van het thema.

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑Waarden Toewijzen aan `IColorScheme`‑Slots**

De [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/) enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorscheme/) dezelfde themaslots exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaslots; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Themalettertypen Wijzigen**

Een thema‑lettertypeschema bevat een hoofdlettertype‑set voor koppen en een minor‑lettertype‑set voor de hoofdtekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/) exposeren die sets.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn-lt` – Body‑lettertype Latin (Minor Latin Font)
* `+mj-lt` – Kop‑lettertype Latin (Major Latin Font)
* `+mn-ea` – Body‑lettertype East Asian (Minor East Asian Font)
* `+mj-ea` – Kop‑lettertype East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één koptekst die het hoofd‑Latin thema‑lettertype gebruikt en één lichaamstekst die het minor‑Latin thema‑lettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de hoofdtekst volgt het minorlettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch wisselen wanneer het thema‑lettertype‑schema verandert.

De hoofd‑ en minor‑lettertypecollecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Voor meer informatie over presentatielettertypen, zie [PowerPoint‑lettertypen](/slides/nl/java/powerpoint-fonts/).

{{% /alert %}}

## **Een Thema Kopiëren of Toepassen**

Er zijn twee gangbare workflows, en ze lossen verschillende problemen op.

### **Een Bron‑thema Behouden bij Het Verplaatsen van Dia’s**

Als je een dia naar een andere presentatie wilt verplaatsen en het oorspronkelijke ontwerp wilt behouden, kloon je de bron‑master in de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/), en kloon je vervolgens de dia met [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/) en de gekloonde master. Dit draagt de master, de layouts en het bijbehorende thema mee.

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

### **Thema‑Waarden Toepassen op een Bestaande Dia**

Als de doel‑dia op zijn huidige master en layout moet blijven, initialiseert u een dia‑niveau‑overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) kopiëren de drie hoofd‑thema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema te wijzigen dat door andere dia’s wordt geërfd. Om de locale overschrijving te verwijderen en terug te gaan naar de geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/overridetheme/) aan.

### **Een Thema‑Overschrijving Toepassen op een Layout**

Een layout‑niveau‑overschrijving geldt voor dia’s die die layout gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatiethema wanneer veel layouts en dia’s hetzelfde basisontwerp moeten delen, een layout‑overschrijving wanneer één layout‑familie een andere styling nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatig veel dia‑niveau‑overschrijvingen maken latere globale themawijzigingen moeilijk te voorspellen.

## **Achtergrondstijlen van het Thema Bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/). PowerPoint kan in de UI meer achtergrondkeuzes presenteren dan het aantal vuldefinities dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en andere style‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/). Een style‑index van `0` betekent geen thema‑vulling; positieve waarden zijn referenties naar thema‑achtergrondstijlen. Dit verschilt van het indexeren van de Java‑collectie zelf, waar `get_Item(0)` het eerst opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvullingsstijlen bevat.

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

Het zichtbare resultaat hangt af van de thema‑entry waar de master naar verwijst en van eventuele achtergrond‑overschrijvingen op layout‑ of dia‑niveau. Als een dia een eigen achtergrond gebruikt, verandert alleen de master‑achtergrond die dia mogelijk niet. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/) wanneer je de definitieve achtergrond na overerving moet weten.

{{% alert color="warning" title="Waarschuwing" %}}

Beschouw de style‑index niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stilenummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastyledefinities zijn presentatiespecifiek.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/java/presentation-background/).

{{% /alert %}}

## **Thema‑Effecten Bijwerken**

Een themaschema voor formats bevat afzonderlijke collecties voor vul‑, lijn‑ en effectstijlen, toegankelijk via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/) en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iformatscheme/). Typische Office‑thema’s bevatten vaak drie hoofd‑style‑items die visueel overeenkomen met subtiele, matige en intense opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, matige en intense themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer je deze collecties in Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerst opgeslagen stijl en `get_Item(2)` is de derde. Een vorm‑style‑referentie‑index is een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak blijven ongewijzigd.

Het volgende voorbeeld controleert of de vereiste style‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buitenste schaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl solid forest green, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke style‑slots elke vorm referereert en of directe opmaak de thema‑overschrijving overrijdt.

![Thema‑effectstijlen na wijziging van lijn‑, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Effectieve Thema‑Waarden Lezen**

Ruwe thema‑objecten laten zien wat er op een bepaald niveau is gedefinieerd. Effectieve waarden laten zien wat een dia of vorm daadwerkelijk gebruikt na overerving en lokale overschrijvingen. Voor een dia, roep [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond, gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/), en voor een vul, gebruik [FillFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond, en de eerste vormvulling van een dia:

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

Gebruik effectieve gegevens voor renderdiagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) inspecteert, kun je een master-, layout-, dia‑ of vorm‑overschrijving missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidethememanager/) van de dia en initialiseert zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer je een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloon je de bron‑master in de bestemming en kloon je de dia met die master via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/) en [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/). Dit houdt de master, layouts en het thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseoverridethememanager/) voor een dia‑ of layout‑thema en de corresponderende effectieve‑datamethoden voor format‑objecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/). Deze API’s retourneren de opgeloste waarden na toepassing van overerving en overschrijvingen.