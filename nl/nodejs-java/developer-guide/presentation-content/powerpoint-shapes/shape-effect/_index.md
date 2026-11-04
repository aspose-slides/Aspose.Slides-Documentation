---
title: Toepassen van vormeffecten in presentaties met JavaScript
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/nodejs-java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie‑effect
- gloeieffect
- zachte randen effect
- effectformaat
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Transformeer uw PPT‑ en PPTX‑bestanden met geavanceerde vormeffecten met JavaScript en Aspose.Slides voor Node.js—creëer verbluffende, professionele dia's in enkele seconden."
---
## **Inleiding**

Hoewel effecten in PowerPoint gebruikt kunnen worden om een vorm te laten opvallen, verschillen ze van [opvullingen](/slides/nl/nodejs-java/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen toegepast kunnen worden. Je kunt één of meerdere effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Daarom biedt PowerPoint opties onder **Voorinstelling**. De opties voor Voorinstelling zijn combinaties van twee of meer effecten die bekend staan om er goed uit te zien. Op die manier hoef je bij het selecteren van een voorinstelling geen tijd meer te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden in de klasse [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) die je in staat stellen dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Schaduweffect toepassen**

Aspose.Slides voor Node.js via Java ondersteunt buiten- en binnen schaduwen voor vormen. Je kunt hun kleur, richting, afstand en onscherpte‑radius aanpassen aan het ontwerp van je presentatie.

### **Buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen ten opzichte van de dia‑achtergrond. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm uit de dia omhoog komt. Pas de kleur, richting, afstand en onscherpte‑radius aan om overeen te komen met de verlichting en stijl van je sjabloon.

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

![Schaduweffect](shadow_effect.png)

### **Binnenste schaduw toepassen**

Bij het reproduceren van de visuele stijl van een sjabloon, gebruik je een binnenste schaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buitenste schaduw strekt zich buiten de vorm uit en maakt deze verhoogd lijken, terwijl een binnenste schaduw de binnenkant van de randen verduistert.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) aan en configureer vervolgens de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Grotere onscherpte‑radiuswaarden zorgen voor zachtere randen.

Dit JavaScript‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenste schaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten en de onscherpte‑radius is 6 punten:

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

![Lichtblauwe rechthoek met een binnenste schaduw](inner_shadow_effect.png)

Om de binnenste schaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) aan op het effectformaat van de vorm.

## **Reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor Node.js via Java, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert het esthetische uiterlijk van je presentaties door vormen een meer gepolijste en verfijnde look te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor snelle toepassing over meerdere elementen mogelijk is voor een consistente vormgeving.

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

## **Gloed‑effect toepassen**

Om een gloed‑effect toe te passen op een vorm in Aspose.Slides voor Node.js via Java, kun je een zachte, lichtgevende aura rond vormen toevoegen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algehele uiterlijk van je dia's wordt verbeterd.

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

## **Zachte‑randen‑effect toepassen**

Om een zachte‑randen‑effect toe te passen in Aspose.Slides voor Node.js via Java, kun je een gladde, vervaagde overgang rondom de randen van een vorm creëren. Dit effect voegt een subtieler en verfijnder uiterlijk toe, perfect voor ontwerpen die een zachte, subtiele uitstraling nodig hebben. Je kunt eenvoudig parameters zoals radius aanpassen om het gewenste effect te behalen op verschillende vormen in je presentatie.

Deze JavaScript‑code laat zien hoe je het [zachte‑randen‑effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) op een vorm toepast:

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

![Zachte‑randen‑effect](soft_edges_effect.png)

## **Vervagingseffect toepassen**

Gebruik vormvervaging om de opvulling en contour van een vorm te verzachten terwijl de vorm bewerkbaar blijft. Roep [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) aan op het effectformaat van de vorm. De radius wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging produceren. Een radius van nul laat het uiterlijk onveranderd.

De instelling [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) bepaalt de zichtbare grenzen van het effect. Met `false` wordt de vervaging bijgesneden tot de oorspronkelijk geschilderde grenzen, inclusief de contour. Met `true` kan de vervaging buiten die grenzen uitbreiden. Geen van beide instellingen wijzigt de positie of afmetingen van de vorm.

De onderstaande vergelijking gebruikt overal dezelfde opvulling, contour en vormafmetingen. De bovenste rij gebruikt `grow = false`; de onderste rij gebruikt `grow = true`.

![Originele rechthoek vergeleken met vervagingsradii van 5 en 15 punten, met grow uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit JavaScript‑voorbeeld maakt een oranje rechthoek met een donkerblauwe contour, past een vervaging van 5 punten toe en werkt deze vervolgens bij naar een vervaging van 15 punten door opnieuw [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) aan te roepen. Het slaat beide vervaagde toestanden op, roept daarna [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) aan en slaat de vorm op zonder vervaging.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vormvervaging beïnvloedt zowel de opvulling als de contour gezamenlijk. Een zachte‑randen‑effect vervaagt de randen van de vorm, terwijl schaduw‑vervaging alleen de schaduw verzacht. Beeldtransformatie‑effecten werken op de afbeeldinginhoud; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm naar een afbeelding te converteren.

## **FAQ**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischer uiterlijk te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autoshapes, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de gehele groep.