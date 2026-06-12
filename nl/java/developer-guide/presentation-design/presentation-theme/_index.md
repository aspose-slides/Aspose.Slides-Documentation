---
title: Beheer presentatiethema's in Java
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
- themakleur
- extra palet
- themalettertype
- themastijl
- themaeffect
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer masterpresentatiethema's in Aspose.Slides voor Java om PowerPoint‑bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert de eigenschappen van ontwerpelementen. Wanneer u een presentatiethema selecteert, kiest u in wezen een specifieke set visuele elementen en hun eigenschappen.

In PowerPoint bestaat een thema uit kleuren, [fonts](/slides/nl/java/powerpoint-fonts/), [background styles](/slides/nl/java/presentation-background/), en effecten.

![theme-constituents](theme-constituents.png)

## **Themakleur wijzigen**

Een PowerPoint‑thema gebruikt een specifieke reeks kleuren voor verschillende elementen op een dia. Als u de kleuren niet bevalt, kunt u ze wijzigen door nieuwe kleuren op het thema toe te passen. Om u in staat te stellen een nieuwe themakleur te selecteren, biedt Aspose.Slides waarden onder de [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SchemeColor)‑enumeratie.

Deze Java‑code laat zien hoe u de accentkleur van een thema wijzigt:

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

Zo kunt u de effectieve waarde van de resulterende kleur bepalen:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Om de kleuraanpassing verder te demonstreren, maken we een ander element en wijzen de accentkleur (van de eerste bewerking) eraan toe. Vervolgens wijzigen we de kleur in het thema:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

De nieuwe kleur wordt automatisch toegepast op beide elementen.

### **Themakleur instellen vanaf een extra palet**

Wanneer u luminantietransformaties toepast op de hoofdthemakleur(1), ontstaan er kleuren uit het extra palet(2). U kunt die themakleuren vervolgens instellen en ophalen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hoofdthemakleuren  
**2** - Kleuren van het extra palet.

Deze Java‑code demonstreert een bewerking waarbij extra paletkleuren worden verkregen uit de hoofdthemakleur en vervolgens in vormen worden gebruikt:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, lichter 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, lichter 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, lichter 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, donkerder 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, donkerder 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor` koppelen aan `IColorScheme`-kleuren**

Wanneer u werkt met [SchemeColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/schemecolor/), merkt u misschien op dat het de volgende themakleurwaarden bevat:

`Background1`, `Background2`, `Text1`, en `Text2`.

Echter, `Presentation.getMasterTheme().getColorScheme()` retourneert [IColorScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorscheme/), die de overeenkomstige kleuren exposeert als:

`Dark1`, `Dark2`, `Light1`, en `Light2`.

Dit verschil zit alleen in de naamgeving. Deze waarden verwijzen naar dezelfde themakleur‑slots en de koppeling is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Er is geen dynamische conversie tussen `Text`/`Background` en `Dark`/`Light`. Het zijn gewoon alternatieve namen voor dezelfde themakleuren.

Dit naamgevingsverschil komt voort uit de Microsoft Office‑terminologie. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde slots tonen als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Themalettertype wijzigen**

Om u in staat te stellen lettertypen voor thema’s en andere doeleinden te selecteren, gebruikt Aspose.Slides deze speciale identifiers (vergelijkbaar met die in PowerPoint):

* **+mn-lt** – Lichaamslettertype Latin (Minor Latin Font)
* **+mj-lt** – Koplettertype Latin (Major Latin Font)
* **+mn-ea** – Lichaamslettertype Oost-Aziatisch (Minor East Asian Font)
* **+mj-ea** – Koplettertype Oost-Aziatisch (Major East Asian Font)

Deze Java‑code laat zien hoe u het Latin‑lettertype aan een thema‑element toewijst:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Deze Java‑code laat zien hoe u het presentatiethema‑lettertype wijzigt:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Het lettertype in alle tekstvakken wordt bijgewerkt.

{{% alert color="primary" title="TIP" %}} 
U wilt misschien [PowerPoint-lettertypen](/slides/nl/java/powerpoint-fonts/).
{{% /alert %}}

## **Thema‑achtergrondstijl wijzigen**

Standaard biedt de PowerPoint‑app 12 voorgedefinieerde achtergronden, maar in een typische presentatie worden slechts 3 van die 12 achtergronden opgeslagen.

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat u een presentatie in de PowerPoint‑app hebt opgeslagen, kunt u deze Java‑code uitvoeren om het aantal voorgedefinieerde achtergronden in de presentatie te achterhalen:

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
Met de [BackgroundFillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--)‑eigenschap van de [FormatScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FormatScheme)‑klasse kunt u de achtergrondstijl in een PowerPoint‑thema toevoegen of benaderen. 
{{% /alert %}} 

Deze Java‑code laat zien hoe u de achtergrond voor een presentatie instelt:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Indexgids**: 0 wordt gebruikt voor geen vulling. De index begint bij 1.

{{% alert color="primary" title="TIP" %}} 
U wilt misschien [PowerPoint‑achtergrond](/slides/nl/java/presentation-background/).
{{% /alert %}}

## **Thema‑effect wijzigen**

Een PowerPoint‑thema bevat meestal 3 waarden voor elke stijlaray. Die arrays worden gecombineerd tot deze 3 effecten: subtiel, gemiddeld en intens. Bijvoorbeeld, dit is het resultaat wanneer de effecten op een specifieke vorm worden toegepast:

![todo:image_alt_text](presentation-design_10.png)

Met de 3 eigenschappen ([FillStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FormatScheme#getEffectStyles--)) van de [FormatScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FormatScheme)‑klasse kunt u de elementen in een thema wijzigen (nog flexibeler dan de opties in PowerPoint).

Deze Java‑code laat zien hoe u een thema‑effect wijzigt door delen van elementen aan te passen:

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

Ja. Aspose.Slides ondersteunt thema‑overschrijvingen op dia‑niveau, zodat u een lokaal thema kunt toepassen op alleen die dia terwijl het master‑thema onaangetast blijft (via de [SlideThemeManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidethememanager/)).

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

[Slides klonen](/slides/nl/java/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de oorspronkelijke master, lay-outs en het bijbehorende thema zodat het uiterlijk consistent blijft.

**Hoe kan ik de “effectieve” waarden zien na alle overerving en overschrijvingen?**

Gebruik de API‑["effectieve"](/slides/nl/java/shape-effective-properties/) weergaven voor thema/kleur/lettertype/effect. Deze geven de uiteindelijke, berekende eigenschappen weer nadat de master en eventuele lokale overschrijvingen zijn toegepast.