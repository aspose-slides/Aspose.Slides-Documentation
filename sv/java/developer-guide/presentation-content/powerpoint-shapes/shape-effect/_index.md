---
title: Tillämpa formseffekter i presentationer med Java
linktitle: Formseffekt
type: docs
weight: 30
url: /sv/java/shape-effect/
keywords:
- formseffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjuk kant-effekt
- effektformat
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Transformera dina PPT- och PPTX-filer med avancerade formseffekter med Aspose.Slides för Java—skapa slående, professionella bilder på några sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fills](/slides/sv/java/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd osv.

<img src="shape-effect.png" alt="form-effekt" style="zoom:50%;" />

* PowerPoint tillhandahåller sex effekter som kan tillämpas på former. Du kan applicera en eller flera effekter på en form. 

* Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen finns PowerPoint‑alternativ under **Preset**. Preset‑alternativen är i princip en beprövad bra kombination av två eller flera effekter. På så sätt, genom att välja en förinställning, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en fin kombination.

Aspose.Slides erbjuder egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/EffectFormat) som låter dig applicera samma effekter på former i PowerPoint‑presentationer.

## **Applicera en skuggeffekt**

Denna Java‑kod visar hur du applicerar den yttre skuggeffekten ([OuterShadowEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) på en rektangel:

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

## **Applicera en reflektionseffekt**

Denna Java‑kod visar hur du applicerar reflektionseffekten på en form:

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

## **Applicera en glöd‑effekt**

Denna Java‑kod visar hur du applicerar glödeffekten på en form:

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

## **Applicera en mjuk kant‑effekt**

Denna Java‑kod visar hur du applicerar mjuka kanter på en form:

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

**Kan jag applicera flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autogestalter, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt med mera.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effektensen gäller för hela gruppen.