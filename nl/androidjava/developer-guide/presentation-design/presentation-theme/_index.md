---
title: Beheer presentatiethema’s op Android
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
description: "Beheer masterpresentatiethema’s in Aspose.Slides voor Android via Java om PowerPoint‑bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert de eigenschappen van ontwerpelementen. Wanneer je een presentatiethema selecteert, kies je in feite een specifieke set visuele elementen en hun eigenschappen.

In PowerPoint bestaat een thema uit kleuren, [lettertypen](/slides/nl/androidjava/powerpoint-fonts/), [achtergrondstijlen](/slides/nl/androidjava/presentation-background/) en effecten.

![theme-constituents](theme-constituents.png)

## **Themakleur wijzigen**

Een PowerPoint‑thema gebruikt een specifieke set kleuren voor verschillende elementen op een dia. Als je de kleuren niet bevalt, kun je ze aanpassen door nieuwe kleuren voor het thema toe te passen. Om je een nieuwe themakleur te laten kiezen, biedt Aspose.Slides waarden aan onder de [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SchemeColor)‑enumeratie.

Deze Java‑code toont hoe je de accentkleur van een thema wijzigt:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Zo kun je de effectieve waarde van de resulterende kleur bepalen:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Om de kleuraanpassing verder te demonstreren, maken we een extra element aan en wijzen we de accentkleur (van de eerste bewerking) toe. Vervolgens wijzigen we de kleur in het thema:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

De nieuwe kleur wordt automatisch toegepast op beide elementen.

### **Themakleur instellen vanuit een extra palet**

Wanneer je luminantie‑transformaties toepast op de hoofdthemakleur(1), worden kleuren uit het extra palet(2) gevormd. Je kunt die themakleuren vervolgens instellen en ophalen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hoofdthemakleuren  
**2** - Kleuren uit het extra palet.

Deze Java‑code demonstreert een bewerking waarbij extra paletkleuren worden verkregen uit de hoofdthemakleur en vervolgens in vormen worden gebruikt:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, 80% lichter
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, 60% lichter
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, 40% lichter
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, 25% donkerder
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, 50% donkerder
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Map `SchemeColor` naar `IColorScheme`‑kleuren**

Wanneer je werkt met [SchemeColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/), merk je misschien op dat het de volgende themakleurwaarden bevat:
`Background1`, `Background2`, `Text1` en `Text2`.

Echter, `Presentation.getMasterTheme().getColorScheme()` retourneert [IColorScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/), die de overeenkomstige kleuren weergeeft als:
`Dark1`, `Dark2`, `Light1` en `Light2`.

Dit verschil zit alleen in de naamgeving. Deze waarden verwijzen naar dezelfde themakleur‑plaatsen en de mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Er is geen dynamische conversie tussen `Text`/`Background` en `Dark`/`Light`. Het zijn simpelweg alternatieve namen voor dezelfde themakleuren.

Dit verschil in naamgeving komt voort uit de terminologie van Microsoft Office. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde plaatsen tonen als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Themalettertype wijzigen**

Om je lettertypen voor thema's en andere doeleinden te laten selecteren, gebruikt Aspose.Slides deze speciale identifiers (vergelijkbaar met die in PowerPoint):
* **+mn-lt** - Body‑lettertype Latin (Minor Latin Font)
* **+mj-lt** - Kop‑lettertype Latin (Major Latin Font)
* **+mn-ea** - Body‑lettertype East Asian (Minor East Asian Font)
* **+mj-ea** - Body‑lettertype East Asian (Major East Asian Font)

Deze Java‑code toont hoe je het Latin‑lettertype aan een thema‑element toewijst:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Deze Java‑code toont hoe je het presentatiethema‑lettertype wijzigt:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Het lettertype in alle tekstvakken wordt bijgewerkt.

{{% alert color="info" title="TIP" %}} 
Je wilt misschien de [PowerPoint-lettertypen](/slides/nl/androidjava/powerpoint-fonts/) bekijken. 
{{% /alert %}}

## **Thema‑achtergrondstijl wijzigen**

Standaard biedt de PowerPoint‑app 12 voorgedefinieerde achtergronden, maar in een typische presentatie worden er slechts 3 van die 12 achtergronden opgeslagen.

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat je een presentatie hebt opgeslagen in de PowerPoint‑app, kun je deze Java‑code uitvoeren om het aantal voorgedefinieerde achtergronden in de presentatie te achterhalen:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Met de eigenschap [BackgroundFillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) van de klasse [FormatScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme) kun je de achtergrondstijl in een PowerPoint‑thema toevoegen of benaderen. 
{{% /alert %}} 

Deze Java‑code toont hoe je de achtergrond voor een presentatie instelt:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Indexgids**: 0 wordt gebruikt voor geen opvulling. De index begint bij 1.

{{% alert color="info" title="TIP" %}} 
Je wilt misschien de [PowerPoint‑achtergrond](/slides/nl/androidjava/presentation-background/) bekijken. 
{{% /alert %}}

## **Thema‑effect wijzigen**

Een PowerPoint‑thema bevat meestal 3 waarden voor elke stijl‑array. Die arrays worden gecombineerd tot deze 3 effecten: subtiel, gematigd en intens. Bijvoorbeeld, dit is het resultaat wanneer de effecten worden toegepast op een specifieke vorm:
![todo:image_alt_text](presentation-design_10.png)

Met 3 eigenschappen ([FillStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) van de klasse [FormatScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme) kun je de elementen in een thema wijzigen (nog flexibeler dan de opties in PowerPoint).

Deze Java‑code toont hoe je een thema‑effect wijzigt door onderdelen van elementen aan te passen:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

De resulterende wijzigingen in vulkleur, vultype, schaduweffect, enz.:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Kan ik een thema toepassen op een enkele dia zonder de master te wijzigen?

Ja. Aspose.Slides ondersteunt thema‑overschrijvingen op dia‑niveau, zodat je een lokaal thema kunt toepassen op die specifieke dia terwijl het master‑thema ongewijzigd blijft (via de [SlideThemeManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidethememanager/)).

### Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?

[Clone slides](/slides/nl/androidjava/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de oorspronkelijke master, lay‑outs en het bijbehorende thema, zodat de weergave consistent blijft.

### Hoe kan ik de “effectieve” waarden zien na alle overerving en overschrijvingen?

Gebruik de ["effectieve" weergaven](/slides/nl/androidjava/shape-effective-properties/) van de API voor thema/kleur/lettertype/effect. Deze geven de uiteindelijke, opgehelderde eigenschappen terug na het toepassen van de master plus eventuele lokale overschrijvingen.