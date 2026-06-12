---
title: Toepassen van vormeffecten in presentaties met Java
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie‑effect
- gloeieffect
- zacht‑randen‑effect
- effectformaat
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Transformeer uw PPT‑ en PPTX‑bestanden met geavanceerde vormeffecten met Aspose.Slides voor Java – maak binnen enkele seconden opvallende, professionele dia’s."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/java/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm laten uitstralen, enzovoort.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen. 
* Sommige combinaties van effecten zien er beter uit dan andere. Daarom zijn er PowerPoint‑opties onder **Preset**. De preset‑opties zijn in feite een bekend goed uitziende combinatie van twee of meer effecten. Op deze manier hoef je bij het selecteren van een preset geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de klasse [EffectFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/EffectFormat) die je in staat stellen dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Een schaduweffect toepassen**

Deze Java‑code laat zien hoe je het buitenschaduw‑effect ([OuterShadowEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) op een rechthoek toepast:

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

## **Een reflectie‑effect toepassen**

Deze Java‑code laat zien hoe je het reflectie‑effect op een vorm toepast:

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

## **Een gloedeffect toepassen**

Deze Java‑code laat zien hoe je het gloedeffect op een vorm toepast:

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

## **Een zacht‑randen‑effect toepassen**

Deze Java‑code laat zien hoe je zachte randen op een vorm toepast:

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

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischer uiterlijk te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autoshapes, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt op de hele groep toegepast.