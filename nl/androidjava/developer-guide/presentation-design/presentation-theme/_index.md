---
title: Beheer presentatiethema's op Android
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
- thema-lettertype
- thema-stijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor Android via Java om PowerPoint-bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Introductie**

Een presentatiethema definieert de eigenschappen van ontwerpelementen. Wanneer u een presentatiethema selecteert, kiest u in wezen een specifieke set visuele elementen en hun eigenschappen.

In PowerPoint bestaat een thema uit kleuren, [lettertypen](/slides/nl/androidjava/powerpoint-fonts/), [achtergrondstijlen](/slides/nl/androidjava/presentation-background/) en effecten.

![theme-constituents](theme-constituents.png)

## **Themakleur wijzigen**

Een PowerPoint-thema gebruikt een specifieke set kleuren voor verschillende elementen op een dia. Als u de kleuren niet bevalt, kunt u ze wijzigen door nieuwe kleuren op het thema toe te passen. Om u een nieuwe themakleur te laten kiezen, biedt Aspose.Slides waarden onder de [SchemeColor] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SchemeColor) enumeratie.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

U kunt de effectieve waarde van de resulterende kleur op deze manier bepalen:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Om de kleuraanpassing nog meer te demonstreren, maken we een ander element aan en wijzen we de accentkleur (van de eerste bewerking) eraan toe. Vervolgens wijzigen we de kleur in het thema:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

De nieuwe kleur wordt automatisch toegepast op beide elementen.

### **Themakleur instellen vanaf een extra palet**

Wanneer u luminantietransformaties toepast op de hoofdkleur van het thema (1), ontstaan er kleuren uit het extra palet (2). U kunt vervolgens die themakleuren instellen en ophalen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hoofdkleuren van het thema

**2** - Kleuren van het extra palet.

Deze Java-code demonstreert een bewerking waarbij extra paletkleuren worden verkregen vanuit de hoofdkleur van het thema en vervolgens in vormen worden gebruikt:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, Lichter 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, Lichter 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, Lichter 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, Donkerder 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, Donkerder 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor` naar `IColorScheme`-kleuren mappen**

Wanneer u werkt met [SchemeColor] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/schemecolor/), merkt u mogelijk dat het de volgende themakleurwaarden bevat:

`Background1`, `Background2`, `Text1` en `Text2`.

De `Presentation.getMasterTheme().getColorScheme()` retourneert echter [IColorScheme] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorscheme/) die de bijbehorende kleuren weergeeft als:

`Dark1`, `Dark2`, `Light1` en `Light2`.

Dit verschil zit alleen in de benaming. Deze waarden verwijzen naar dezelfde themakleur‑posities en de mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Er is geen dynamische conversie tussen `Text`/`Background` en `Dark`/`Light`. Het zijn simpelweg alternatieve namen voor dezelfde themakleuren.

Dit naamverschil komt voort uit de terminologie van Microsoft Office. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde posities weergeven als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Themalettertype wijzigen**

Om u lettertypen voor thema’s en andere doeleinden te laten selecteren, gebruikt Aspose.Slides deze speciale identificatoren (vergelijkbaar met die in PowerPoint):

* **+mn-lt** - Lichaamslettertype Latijn (Klein Latin Lettertype)
* **+mj-lt** - Koplettertype Latijn (Groot Latin Lettertype)
* **+mn-ea** - Lichaamslettertype Oost‑Aziatisch (Klein Oost‑Aziatisch Lettertype)
* **+mj-ea** - Koplettertype Oost‑Aziatisch (Groot Oost‑Aziatisch Lettertype)

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Deze Java‑code toont hoe u het Latijnse lettertype aan een themaelement toewijst:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Het lettertype in alle tekstvakken wordt bijgewerkt.

{{% alert color="primary" title="TIP" %}} 
U wilt misschien de [PowerPoint-lettertypen](/slides/nl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Achtergrondstijl van thema wijzigen**

Standaard levert de PowerPoint‑app 12 vooraf gedefinieerde achtergronden, maar slechts 3 van die 12 achtergronden worden opgeslagen in een typische presentatie. 

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat u een presentatie hebt opgeslagen in de PowerPoint‑app, kunt u deze Java‑code uitvoeren om het aantal vooraf gedefinieerde achtergronden in de presentatie te achterhalen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Met de eigenschap [BackgroundFillStyles] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) van de klasse [FormatScheme] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme), kunt u de achtergrondstijl in een PowerPoint‑thema toevoegen of benaderen.
{{% /alert %}} 

Deze Java‑code toont hoe u de achtergrond voor een presentatie instelt:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Indexgids**: 0 wordt gebruikt voor geen opvulling. De index begint bij 1.

{{% alert color="primary" title="TIP" %}} 
U wilt misschien de [PowerPoint‑achtergrond](/slides/nl/androidjava/presentation-background/).
{{% /alert %}}

## **Thema‑effect wijzigen**

Een PowerPoint‑thema bevat doorgaans 3 waarden voor elke stijl‑array. Die arrays worden gecombineerd tot deze 3 effecten: subtiel, gematigd en intens. Bijvoorbeeld, dit is het resultaat wanneer de effecten worden toegepast op een specifieke vorm:

![todo:image_alt_text](presentation-design_10.png)

Door gebruik te maken van 3 eigenschappen ([FillStyles] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) van de klasse [FormatScheme] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FormatScheme) kunt u de elementen in een thema wijzigen (nog flexibeler dan de opties in PowerPoint).

Deze Java‑code toont hoe u een thema‑effect wijzigt door delen van elementen aan te passen:

```java
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

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**

Ja. Aspose.Slides ondersteunt thema‑overrides op dia‑niveau, zodat u een lokaal thema kunt toepassen op die specifieke dia terwijl het masterthema onaangetast blijft (via de [SlideThemeManager] (https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidethememanager/)).

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

[Dupliceer dia's](/slides/nl/androidjava/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de oorspronkelijke master, lay-outs en het bijbehorende thema zodat het uiterlijk consistent blijft.

**Hoe kan ik de "effectieve" waarden zien nadat alle overerving en overrides zijn toegepast?**

Gebruik de "effectieve" weergaven van de API [/slides/nl/androidjava/shape-effective-properties/] voor thema/kleur/lettertype/effect. Deze geven de opgeloste, definitieve eigenschappen weer na het toepassen van de master en eventuele lokale overrides.