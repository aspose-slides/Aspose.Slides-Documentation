---
title: Tillämpa formseffekter i presentationer på Android
linktitle: Formseffekt
type: docs
weight: 30
url: /sv/androidjava/shape-effect/
keywords:
- formseffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjuka kanter effekt
- effektformat
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Omvandla dina PPT- och PPTX-filer med avancerade formseffekter med Aspose.Slides för Android via Java—skapa slående, professionella bildspel på några sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fyllningar](/slides/sv/androidjava/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd osv.

<img src="shape-effect.png" alt="shape-effekt" style="zoom:50%;" />

* PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan applicera en eller flera effekter på en form.  
* Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen finns PowerPoint‑alternativ under **Preset**. Preset‑alternativen är i huvudsak en beprövad kombination av två eller fler effekter. På så sätt, genom att välja en förinställning, slipper du slösa tid på att testa eller kombinera olika effekter för att hitta en bra kombination.

Aspose.Slides erbjuder egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/EffectFormat) som låter dig tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Tillämpa en skuggeffekt**

Denna Java‑kod visar hur du tillämpar den yttre skuggeffekten ([OuterShadowEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) på en rektangel:

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

## **Tillämpa en reflektionseffekt**

Denna Java‑kod visar hur du tillämpar reflektionseffekten på en form:

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

## **Tillämpa en glödeffekt**

Denna Java‑kod visar hur du tillämpar glödeffekten på en form:

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

## **Tillämpa en mjuka kanter‑effekt**

Denna Java‑kod visar hur du tillämpar mjuka kanter på en form:

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

**Kan jag tillämpa flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag tillämpa effekter på?**

Du kan applicera effekter på olika former, inklusive autoshapes, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag tillämpa effekter på grupperade former?**

Ja, du kan tillämpa effekter på grupperade former. Effekten kommer att gälla för hela gruppen.