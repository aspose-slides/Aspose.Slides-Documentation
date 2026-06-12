---
title: Vormeffecten toepassen in presentaties op Android
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/androidjava/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloeieffect
- zachte randen effect
- effectformaat
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten via Aspose.Slides voor Android met Java—maak in enkele seconden opvallende, professionele dia's."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/androidjava/shape-formatting/#gradient-fill) of contouren. Met PowerPoint-effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.  
* Sommige combinaties van effecten zien er beter uit dan andere. Om die reden vind je PowerPoint‑opties onder **Preset**. De preset‑opties zijn in wezen een reeds goed uitziende combinatie van twee of meer effecten. Op deze manier hoef je door het selecteren van een preset geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de klasse [EffectFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/EffectFormat) die je in staat stellen dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Schaduw-effect toepassen**

Deze Java‑code toont hoe je het buitenste schaduweffect ([OuterShadowEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) op een rechthoek toepast:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Reflectie-effect toepassen**

Deze Java‑code toont hoe je het reflectie‑effect op een vorm toepast:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gloed-effect toepassen**

Deze Java‑code toont hoe je het gloed‑effect op een vorm toepast:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zachte randen-effect toepassen**

Deze Java‑code toont hoe je zachte randen op een vorm toepast:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, op één vorm combineren om een dynamischer uiterlijk te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autoshapes, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de hele groep.