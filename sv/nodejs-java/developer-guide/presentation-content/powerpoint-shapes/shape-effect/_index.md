---
title: Applicera formseffekter i presentationer med JavaScript
linktitle: Formseffekt
type: docs
weight: 30
url: /sv/nodejs-java/shape-effect/
keywords:
- formseffekt
- skuggeffekt
- reflektionseffekt
- glödseffekt
- mjuka kantseffekt
- effektformat
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Transformera dina PPT- och PPTX-filer med avancerade formseffekter med hjälp av JavaScript och Aspose.Slides för Node.js - skapa slående, professionella bilder på sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fyllningar](/slides/sv/nodejs-java/shape-formatting/#gradient-fill) eller konturer. Genom att använda PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan applicera en eller flera effekter på en form. 
* Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen finns PowerPoint‑alternativ under **Preset**. Preset‑alternativen är i grund och botten en beprövad kombination av två eller fler effekter som ser bra ut. På så sätt, genom att välja ett förinställt alternativ, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en fin kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/EffectFormat) som låter dig applicera samma effekter på former i PowerPoint‑presentationer.

## **Applicera skuggeffekt**

Denna JavaScript‑kod visar hur du applicerar yttre skuggeffekten ([getOuterShadowEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) på en rektangel:

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

## **Applicera reflektionseffekt**

Denna JavaScript‑kod visar hur du applicerar reflektionseffekten på en form:

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

## **Applicera glödseffekt**

Denna JavaScript‑kod visar hur du applicerar glöd‑effekten på en form:

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

## **Applicera mjuka kantseffekt**

Denna JavaScript‑kod visar hur du applicerar mjuka kanter på en form:

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

## **Vanliga frågor**

**Kan jag applicera flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enskild form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autoshapes, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.