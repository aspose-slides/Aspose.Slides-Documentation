---
title: Beheer presentatiethema's in JavaScript
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer presentatiethema's in JavaScript met Aspose.Slides voor Node.js om PowerPoint‑bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Introductie**

Een presentatiethema definieert de eigenschappen van ontwerpelementen. Wanneer je een presentatiethema selecteert, kies je in feite een specifieke set visuele elementen en hun eigenschappen.

In PowerPoint bestaat een thema uit kleuren, [lettertypen](/slides/nl/nodejs-java/powerpoint-fonts/), [achtergrondstijlen](/slides/nl/nodejs-java/presentation-background/), en effecten.

![theme-constituents](theme-constituents.png)

## **Thema Kleur Wijzigen**

Een PowerPoint‑thema gebruikt een specifieke set kleuren voor verschillende elementen op een dia. Als je de kleuren niet bevalt, wijzig je ze door nieuwe kleuren toe te passen op het thema. Om je een nieuwe thema‑kleur te laten kiezen, levert Aspose.Slides waarden via de [SchemeColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SchemeColor)‑enumeratie.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Zo kun je de effectieve waarde van de resulterende kleur bepalen:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Om de kleurwijzigingsoperatie verder te demonstreren, maken we een ander element aan en wijzen we de accentkleur (van de eerste operatie) toe. Vervolgens wijzigen we de kleur in het thema:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

De nieuwe kleur wordt automatisch op beide elementen toegepast.

### **Thema Kleur Instellen vanuit Extra Palet**

Wanneer je luminantietransformaties toepast op de hoofdthemakleur(1), ontstaan kleuren uit het extra palet(2). Je kunt die themakleuren vervolgens instellen en ophalen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hoofdthemakleuren  
**2** - Kleuren uit het extra palet.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Accent 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Accent 4, 80% lichter
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Accent 4, 60% lichter
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Accent 4, 40% lichter
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Accent 4, 25% donkerder
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Accent 4, 50% donkerder
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **`SchemeColor` naar `ColorScheme`‑kleuren mappen**

Wanneer je werkt met [SchemeColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/schemecolor/), merk je misschien op dat het de volgende themakleurwaarden bevat:
`Background1`, `Background2`, `Text1`, and `Text2`.

Echter, `Presentation.getMasterTheme().getColorScheme()` retourneert [ColorScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/colorscheme/), die de overeenkomstige kleuren toont als:
`Dark1`, `Dark2`, `Light1`, and `Light2`.

Dit verschil zit alleen in de naamgeving. Deze waarden verwijzen naar dezelfde themakleur‑posities en de toewijzing is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Er is geen dynamische conversie tussen `Text`/`Background` en `Dark`/`Light`. Het zijn eenvoudigweg alternatieve namen voor dezelfde themakleuren.

Deze naamgevingsverschillen komen voort uit Microsoft Office‑terminologie. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde posities weergeven als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Thema Lettertype Wijzigen**

Om je in staat te stellen lettertypen voor thema's en andere doeleinden te kiezen, gebruikt Aspose.Slides deze speciale identificatoren (vergelijkbaar met die in PowerPoint):

* **+mn-lt** - Body‑lettertype Latin (Minor Latin Font)  
* **+mj-lt** - Heading‑lettertype Latin (Major Latin Font)  
* **+mn-ea** - Body‑lettertype East Asian (Minor East Asian Font)  
* **+mj-ea** - Body‑lettertype East Asian (Major East Asian Font)

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Deze JavaScript‑code laat zien hoe je het presentatiethema‑lettertype wijzigt:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Het lettertype in alle tekstvakken wordt bijgewerkt.

{{% alert color="primary" title="TIP" %}} 
Je wilt misschien de [PowerPoint lettertypen](/slides/nl/nodejs-java/powerpoint-fonts/) bekijken.
{{% /alert %}}

## **Thema Achtergrondstijl Wijzigen**

Standaard biedt de PowerPoint‑app 12 voorgedefinieerde achtergronden, maar in een typische presentatie worden er slechts 3 van die 12 achtergronden opgeslagen.

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat je een presentatie hebt opgeslagen in de PowerPoint‑app, kun je deze JavaScript‑code uitvoeren om het aantal voorgedefinieerde achtergronden in de presentatie te achterhalen:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
Met de [BackgroundFillStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--)‑eigenschap van de [FormatScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FormatScheme)‑klasse kun je de achtergrondstijl in een PowerPoint‑thema toevoegen of benaderen.
{{% /alert %}} 

Deze JavaScript‑code laat zien hoe je de achtergrond voor een presentatie instelt:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Indexgids**: 0 wordt gebruikt voor geen vulling. De index begint bij 1.

{{% alert color="primary" title="TIP" %}} 
Je wilt misschien de [PowerPoint‑achtergrond](/slides/nl/nodejs-java/presentation-background/) bekijken.
{{% /alert %}}

## **Thema‑effect Wijzigen**

Een PowerPoint‑thema bevat meestal 3 waarden voor elke stijlaray. Die arrays worden gecombineerd tot deze 3 effecten: subtiel, gematigd en intens. Bijvoorbeeld, dit is het resultaat wanneer de effecten op een specifieke vorm worden toegepast:

![todo:image_alt_text](presentation-design_10.png)

Met 3 eigenschappen ([FillStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) van de [FormatScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FormatScheme)‑klasse kun je de elementen in een thema wijzigen (nog flexibeler dan de opties in PowerPoint).

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

De resulterende wijzigingen in vulkleur, vultype, schaduweffect, enz.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kan ik een thema toepassen op een enkele dia zonder de master te wijzigen?**  
Ja. Aspose.Slides ondersteunt thema‑overschrijvingen op dia‑niveau, zodat je een lokaal thema kunt toepassen op slechts die dia terwijl je het master‑thema intact houdt (via de [SlideThemeManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidethememanager/)).

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**  
[Kloon dia's](/slides/nl/nodejs-java/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de originele master, lay‑outs en het bijbehorende thema zodat het uiterlijk consistent blijft.

**Hoe kan ik de "effectieve" waarden zien na alle overerving en overschrijvingen?**  
Gebruik de ["effectieve" weergaven](/slides/nl/nodejs-java/shape-effective-properties/) voor thema/kleur/lettertype/effect. Deze geven de opgeloste, uiteindelijke eigenschappen terug na het toepassen van de master plus eventuele lokale overschrijvingen.