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
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten via JavaScript en Aspose.Slides voor Node.js — maak verbluffende, professionele dia's in enkele seconden."
---
## **Introductie**

Terwijl effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/nodejs-java/shape-formatting/#gradient-fill) of omtreklijnen. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm maken, de gloed van een vorm verspreiden, enz.

<img src="shape-effect.png" alt="vorm-effect" style="zoom:50%;" />

* PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meerdere effecten op een vorm toepassen. 

* Sommige combinaties van effecten zien er beter uit dan andere. Daarom staan de PowerPoint‑opties onder **Voorinstelling**. De Voorinstelling‑opties zijn in wezen een bekende, goed uitziende combinatie van twee of meer effecten. Op deze manier hoef je bij het kiezen van een voorinstelling niet meer tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/EffectFormat)‑klasse die je toestaan dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Schaduw‑effect toepassen**

Deze JavaScript‑code laat zien hoe je het buitenste schaduw‑effect ([getOuterShadowEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) op een rechthoek toepast:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Reflectie‑effect toepassen**

Deze JavaScript‑code laat zien hoe je het reflectie‑effect op een vorm toepast:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gloed‑effect toepassen**

Deze JavaScript‑code laat zien hoe je het gloed‑effect op een vorm toepast:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zachte randen‑effect toepassen**

Deze JavaScript‑code laat zien hoe je de zachte randen op een vorm toepast:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder auto‑shapes, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt dan toegepast op de gehele groep.