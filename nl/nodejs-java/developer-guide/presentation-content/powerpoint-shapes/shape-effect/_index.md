---
title: Vormeffecten toepassen in presentaties met JavaScript
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/nodejs-java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloed-effect
- zachte randen effect
- effectformaat
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten met JavaScript en Aspose.Slides voor Node.js - maak verbluffende, professionele dia's in enkele seconden."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/nodejs-java/shape-formatting/#gradient-fill) of omtrekken. Met PowerPoint-effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Vorm effect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meerdere effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Daarom biedt PowerPoint opties onder **Preset**. De Preset‑opties zijn combinaties van twee of meer effecten die bekend staan als aantrekkelijk. Op deze manier hoef je bij het kiezen van een preset geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/)‑klasse die je toelaten dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Een schaduweffect toepassen**

Aspose.Slides voor Node.js via Java ondersteunt buiten- en binnen schaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsstraal aanpassen aan het ontwerp van je presentatie.

### **Een buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de slide‑achtergrond. De schaduw strekt zich uit buiten de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de slide zweeft. Pas de kleur, richting, afstand en vervagingsstraal aan om te passen bij de belichting en stijl van je sjabloon.

Deze JavaScript‑code laat zien hoe je het [buitenste schaduw‑effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) op een rechthoek toepast:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Schaduw‑effect](shadow_effect.png)

### **Een binnenste schaduw toepassen**

Wanneer je de visuele stijl van een sjabloon nabootst, gebruik je een binnenste schaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buitenste schaduw strekt zich uit buiten de vorm en laat deze verhoogd lijken, terwijl een binnenste schaduw de binnenkant van de randen verduistert.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) aan en configureer vervolgens de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Grotere waarden voor de vervagingsstraal geven zachtere randen.

Dit JavaScript‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenste schaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten, en de vervagingsstraal is 6 punten:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Lichtblauw rechthoek met een binnenste schaduw](inner_shadow_effect.png)

Om de binnenste schaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) aan op het effectformaat van de vorm.

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor Node.js via Java, kun je een spiegelachtige reflectie aan vormen toevoegen, waarbij je parameters zoals afstand, transparantie en grootte aanpast. Dit effect verbetert het uiterlijk van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor je het snel kunt toepassen op meerdere elementen voor een consistent ontwerp.

Deze JavaScript‑code laat zien hoe je het [reflectie‑effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) op een vorm toepast:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflectie‑effect](reflection_effect.png)

## **Een gloed‑effect toepassen**

Om een gloed‑effect toe te passen op een vorm in Aspose.Slides voor Node.js via Java, kun je een zachte, lichtgevende aura rond vormen toevoegen, waarbij je eigenschappen zoals kleur en grootte aanpast. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor de algehele uitstraling van je dia’s wordt verbeterd.

Deze JavaScript‑code laat zien hoe je het [gloed‑effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) op een vorm toepast:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gloed‑effect](glow_effect.png)

## **Een zacht‑randen‑effect toepassen**

Om een zacht‑randen‑effect toe te passen in Aspose.Slides voor Node.js via Java, kun je een gladde, onscherpe overgang rond de randen van een vorm creëren. Dit effect geeft een subtielere en verfijndere uitstraling, perfect voor ontwerpen die een zachte, zachtere look behoeven. Je kunt eenvoudig parameters zoals radius aanpassen om het gewenste effect te bereiken voor verschillende vormen in je presentatie.

Deze JavaScript‑code laat zien hoe je het [zacht‑randen‑effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) op een vorm toepast:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Zacht‑randen‑effect](soft_edges_effect.png)

## **FAQ**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een meer dynamische uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder auto‑shapes, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt op de gehele groep toegepast.