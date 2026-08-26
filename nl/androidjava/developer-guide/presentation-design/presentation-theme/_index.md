---
title: Presentatiethema's beheren op Android
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
- extra palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Hoofdpresentatiethema's in Aspose.Slides voor Android via Java om PowerPoint-bestanden te maken, aan te passen en te converteren met consistente branding."
---
## **Introductie**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypes, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten in één keer kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/). Een presentatie kan ook themabijstellingen bevatten op lagere niveaus. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterthememanager/), terwijl een lay‑out of een individuele dia haar geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/). In de praktijk wordt het effectieve thema voor een dia opgelost via deze erfketen: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Thema‑componenten: kleuren, lettertypes, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑werkstromen: een thema inspecteren, kleuren en lettertypes wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erf‑ en overschrijvingsinstellingen zijn toegepast.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/) object maakt het kleurschema, lettertypeschema en formatschema van het thema beschikbaar via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/), en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mastertheme/). Het inspecteren van deze collecties voordat ze gewijzigd worden is bijzonder nuttig wanneer een presentatie afkomstig is uit een externe bron, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de hoofd‑themagegevens en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die aan de dia is gekoppeld en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/) opsomming. Wanneer je het overeenkomstige item in de [IColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, afgeleid van de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet aangepast door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de thema‑kleur `Accent4` naar rood, slaat de presentatie op, opent deze opnieuw en drukt de effectieve vulkleur af:

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

Omdat het rechthoekje gekoppeld blijft aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vul niet meer beïnvloeden.

### **Kleuren uit het extra palet gebruiken**

PowerPoint haalt lichtere en donkerdere varianten af van een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/colortransformoperation/) opsomming.

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd uit het extra palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  
**2** – Lichtere en donkerdere varianten afgeleid van de hoofdkleuren van het thema.

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

### **`SchemeColor`‑waarden toewijzen aan `IColorScheme`‑posities**

De [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/) opsomming gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [IColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/) dezelfde themaposities blootlegt als `Dark1`, `Light1`, `Dark2` en `Light2`. De toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaposities; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Thema‑lettertypes wijzigen**

Een thema‑lettertypeschema bevat een hoofd‑lettertype‑set voor kopteksten en een secundaire lettertype‑set voor de hoofdtekst. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/) geven die sets bloot.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt in tekstopmaak:

* `+mn-lt` – Body‑lettertype Latin (Secundair Latin lettertype)
* `+mj-lt` – Koptekst‑lettertype Latin (Hoofd‑Latin lettertype)
* `+mn-ea` – Body‑lettertype Oost‑Azië (Secundair Oost‑Aziatisch lettertype)
* `+mj-ea` – Koptekst‑lettertype Oost‑Azië (Hoofd‑Oost‑Aziatisch lettertype)

Het volgende voorbeeld maakt één koptekst die het hoofd‑Latin thema‑lettertype gebruikt en één lichaamsregel die het secundair Latin thema‑lettertype gebruikt. Daarna wijzigt het de thema‑lettertypes en slaat het resultaat op:

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

De koptekst volgt het hoofdlettertype en de hoofdtekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identificator, zal niet automatisch veranderen wanneer het thema‑lettertypeschema wijzigt.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgiaans en Thaana. Voor het inspecteren, toevoegen, vervangen of verwijderen van deze toewijzingen, zie [Script‑Specific Theme Fonts](/slides/nl/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatieteksten, zie [PowerPoint Fonts](/slides/nl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande werkstromen lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die afhankelijk zijn van een master**

Gebruik [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/) wanneer je een PowerPoint‑thema‑bestand (`.thmx`) hebt en elke dia die afhankelijk is van een bepaalde master opnieuw wilt opmaken. Selecteer de master uit de [Presentation.getMasters](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia aan op basis van de geselecteerde master.  
2. Past het externe thema toe op de nieuwe master.  
3. Wijs de nieuwe master toe aan alle dia's die eerder afhankelijk waren van de geselecteerde master.  
4. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/).

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

Een ongeldige, corrupte of niet‑ondersteunde themabestand kan een [PptxReadException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestandsysteemtoegang, en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia's die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia's die bij andere masters horen behouden hun bestaande masters en thema's. Thema‑bewuste kleuren, lettertypes, vullingen, lijnen, achtergronden en effecten worden afgeleid van het externe thema. Direct toegewezen kleuren, lettertypes, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overschrijvingen op lay‑out‑ of dia‑niveau kunnen ook voorrang krijgen boven de waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypes refereren die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypes, lever ze via [custom font sources](/slides/nl/androidjava/custom-font/), of configureer [font substitution](/slides/nl/androidjava/font-substitution/).

Dit is een directe master‑niveau werkstroom: de methode accepteert een pad naar een `.thmx`‑bestand en vereist niet dat er handmatig dia‑ of lay‑out‑thema‑overschrijvingen worden aangemaakt.

### **Verschillende externe thema's toepassen in een presentatie met meerdere masters**

Wanneer de relevante master niet vooraf bekend is, verkrijg deze dan via een representatieve dia met [ISlide.getLayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) en [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/). Sla de oorspronkelijke master‑referenties op voordat je thema’s toepast, omdat elke aanroep een extra master in de presentatie creëert.

Het volgende voorbeeld gebruikt dia's uit twee secties om hun masters te vinden en past een verschillend extern thema toe op elke groep:

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

De eerste oproep heeft alleen invloed op de dia's die afhankelijk waren van `firstGroupMaster`, en de tweede oproep heeft alleen invloed op de dia's die afhankelijk waren van `secondGroupMaster`. Dia's die bij een andere master horen, worden niet opnieuw opgemaakt.

### **Een bron‑thema behouden bij het verplaatsen van dia's**

Als je een dia naar een andere presentatie wilt verplaatsen en het oorspronkelijke ontwerp wilt behouden, kloon dan de bron‑master naar de doelpresentatie met [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/), kloon vervolgens de dia met [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/) en de gekloonede master. Hiermee wordt de master, de lay‑outs en het bijbehorende thema samen meegenomen.

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

Dit is de voorkeur‑werkstroom wanneer de bron‑dia er in de bestemming exact hetzelfde uit moet zien. Het simpelweg klonen van inhoud naar een niet‑gerelateerde doel‑master kan thema‑gedreven kleuren, lettertypes, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Als de doel‑dia op zijn huidige master en lay‑out moet blijven, initialiseert u een dia‑niveau‑overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/), en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) kopiëren de drie hoofd‑thema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat andere dia's erven te veranderen. Om de lokale overschrijving te verwijderen en terug te keren naar de geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/overridetheme/) aan.

### **Een thema‑overschrijving toepassen op een lay‑out**

Een lay‑out‑niveau‑overschrijving geldt voor dia's die die lay‑out gebruiken, tenzij een specifieke dia zijn eigen overschrijving heeft. Dezelfde initialisatiemethodes kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatie‑niveau‑thema wanneer veel lay‑outs en dia's hetzelfde basisontwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑out‑familie een andere stijl nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Te veel dia‑niveau‑overschrijvingen maken latere globale thema‑wijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/). PowerPoint kan meer achtergrondkeuzes tonen in de UI dan het aantal vullingen dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en andere stijloverzichten.

![PowerPoint galerij van achtergrondstijlen voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteer de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn verwijzingen naar themabackground‑stijlen. Dit verschilt van het direct indexeren van de Java‑collectie, waar `get_Item(0)` het eerste opgeslagen item betekent. Ga niet ervan uit dat elke presentatie hetzelfde aantal achtergrondvullingsstijlen bevat.

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

Het zichtbare resultaat hangt af van de themaverwijzing die de master gebruikt en van eventuele achtergrond‑overschrijvingen op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond gebruikt, zal het wijzigen van alleen de master‑achtergrond die dia mogelijk niet wijzigen. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/) wanneer u de uiteindelijke achtergrond wilt weten nadat erf‑ en overschrijvingsregels zijn toegepast.

{{% alert color="warning" title="Warning" %}}
Beschouw de stijl‑index niet als een nulgebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het er in een ander bestand hetzelfde uitziet; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/androidjava/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑formatschema bevat afzonderlijke collecties voor vul‑, lijn‑ en effectstijlen, toegankelijk via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/), en [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iformatscheme/). Typische Office‑thema's bevatten vaak drie hoofd­stijlelementen die visueel overeenkomen met subtiele, matige en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van een vaste telling aan te nemen.

![Subtiele, matige en intensieve themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in Java benadert, is de collectie‑index nulgebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` is de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, toegankelijk via [IShapeStyle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die naar die themastijl verwijzen; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de benodigde stijlelementen bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die naar deze posities verwijzen, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt een solide bosgroen, en de derde effectstijl krijgt een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijlposities elke vorm refereert en of directe opmaak de themastijl overschrijft.

![Thema‑effectstijlen na wijziging van lijn-, vul- en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe themobjecten geven aan wat er op een bepaald niveau gedefinieerd is. Effectieve waarden geven aan wat een dia of vorm daadwerkelijk gebruikt nadat erf‑ en lokale overschrijvingen zijn toegepast. Voor een dia, roep [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/) aan. Voor een achtergrond, gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/), en voor een vulling, gebruik [FillFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/).

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

Gebruik effectieve gegevens voor weergavediagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑overschrijving missen die de uiteindelijke weergave wijzigt.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/) wijst alleen de dia's opnieuw toe die afhankelijk zijn van de geselecteerde master. Dia's die andere masters gebruiken, behouden hun bestaande thema's.

**Kan ik een thema toepassen op één enkele dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidethememanager/) van de dia en initialiseert zijn overschrijvings‑thema. De wijziging blijft lokaal voor die dia; andere dia's blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en de oorspronkelijke weergave wilt behouden, kloont u de bron‑master naar de bestemming en kloont u de dia met die master via [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/) en [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/). Hiermee blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erf‑ en overschrijvingsregels?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseoverridethememanager/) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑datamethodes voor formatobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/background/) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/). Deze API's geven de berekende waarden terug nadat erf‑ en overschrijvingsregels zijn toegepast.