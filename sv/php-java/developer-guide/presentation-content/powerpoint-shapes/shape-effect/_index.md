---
title: Applicera formeffekter i presentationer med PHP
linktitle: Formeffekt
type: docs
weight: 30
url: /sv/php-java/shape-effect/
keywords:
- formeffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjuka kanter effekt
- effektformat
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Transformera dina PPT- och PPTX-filer med avancerade formeffekter med Aspose.Slides för PHP via Java - skapa iögonfallande, professionella bilder på sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fyllningar](/slides/sv/php-java/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd, osv.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan tillämpa en eller flera effekter på en form. 

* Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen erbjuder PowerPoint alternativ under **Preset**. Preset‑alternativen är i princip en bepränkt attraktiv kombination av två eller fler effekter. På så sätt, genom att välja ett förinställt alternativ, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en bra kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/EffectFormat) som låter dig tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Applicera en skuggeffekt**

Denna PHP‑kod visar hur du tillämpar den yttre skuggeffekten ([OuterShadowEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) på en rektangel:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Applicera en reflektionseffekt**

Denna PHP‑kod visar hur du tillämpar reflektionseffekten på en form:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Applicera en glödeffekt**

Denna PHP‑kod visar hur du tillämpar glödeffekten på en form:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Applicera en mjukkantseffekt**

Denna PHP‑kod visar hur du tillämpar mjuka kanter på en form:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Kan jag tillämpa flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag tillämpa effekter på?**

Du kan tillämpa effekter på olika former, inklusive autoshapes, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag tillämpa effekter på grupperade former?**

Ja, du kan tillämpa effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.