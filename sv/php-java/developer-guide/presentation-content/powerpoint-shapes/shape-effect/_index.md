---
title: Tillämpa formeffekter i presentationer med PHP
linktitle: Formeffekt
type: docs
weight: 30
url: /sv/php-java/shape-effect/
keywords:
- formeffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjuk kanter-effekt
- effektformat
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Transformera dina PPT- och PPTX-filer med avancerade formeffekter med Aspose.Slides för PHP via Java — skapa slående, professionella bildspel på några sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fills](/slides/sv/php-java/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint-effekter kan du skapa övertygande reflektioner på en form, sprida en glöd runt en form osv.

![Formeffekt](shape-effect.png)

PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan tillämpa en eller flera effekter på en form.

Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen erbjuder PowerPoint alternativ under **Preset**. Preset-alternativen är kombinationer av två eller fler effekter som är kända för att se bra ut. På så sätt, genom att välja en förinställning, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en fin kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) som låter dig tillämpa samma effekter på former i PowerPoint-presentationer.

## **Tillämpa en skuggeffekt**

Aspose.Slides för PHP via Java stöder yttre och inre skuggor för former. Du kan anpassa deras färg, riktning, avstånd och suddradie för att matcha din presentations design.

### **Tillämpa en yttre skugga**

Använd en yttre skugga för att få ett kort eller panel att sticka ut mot bildens bakgrund. Skuggan sträcker sig bortom formens kanter och skapar intrycket att formen är upphöjd över bilden. Justera dess färg, riktning, avstånd och suddradie för att matcha belysning och stil i din mall.

Denna PHP-kod visar hur du tillämpar [yttre skuggeffekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) på en rektangel:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Skuggeffekt](shadow_effect.png)

### **Tillämpa en inre skugga**

När du återproducerar en mallens visuella stil, använd en inre skugga för att ge ett kort eller en panel ett nedsänkt utseende. En yttre skugga sträcker sig utanför formen och får den att framstå som upphöjd, medan en inre skugga skuggar insidan av dess kanter.

Anropa [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) och konfigurera sedan skuggan som returneras av [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Större värden på suddradie ger mjukare kanter.

Denna PHP-exempel skapar ett ljusblått kort med en mörkgrå inre skugga och sparar det som en PPTX-fil. Skuggans riktning är 225 grader, dess avstånd är 7 punkter och dess suddradie är 6 punkter:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Ljusblå rektangel med en inre skugga](inner_shadow_effect.png)

För att ta bort den inre skuggan, anropa [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) på formens effektformat.

## **Tillämpa en reflexeffekt**

För att tillämpa en reflexeffekt i Aspose.Slides för PHP via Java kan du lägga till en spegelliknande reflektion på former, justera parametrar som avstånd, transparens och storlek. Denna effekt förbättrar estetiken i dina presentationer genom att ge former ett mer polerat och sofistikerat utseende. Det är enkelt att implementera med enkel kod, vilket möjliggör snabb tillämpning över flera element för en konsekvent design.

Denna PHP-kod visar hur du tillämpar [reflektionseffekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) på en form:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Reflektionseffekt](reflection_effect.png)

## **Tillämpa en glödeffekt**

För att tillämpa en glödeffekt på en form i Aspose.Slides för PHP via Java kan du lägga till en mjuk, ljus aura runt former, justera egenskaper som färg och storlek. Denna effekt hjälper former att sticka ut och tillför ett attraktivt, iögonfallande visuellt element till din presentation. Det är enkelt att implementera med minimal kod, vilket förbättrar det övergripande utseendet på dina bilder.

Denna PHP-kod visar hur du tillämpar [glödeffekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) på en form:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Glödeffekt](glow_effect.png)

## **Tillämpa en mjuk kanter‑effekt**

För att tillämpa en mjuk kanter‑effekt i Aspose.Slides för PHP via Java kan du skapa en jämn, suddig övergång runt en forms kanter. Denna effekt ger ett mer subtilt och raffinerat utseende, perfekt för designer som kräver ett milt, mjukare intryck. Du kan enkelt justera parametrar som radie för att uppnå önskad effekt på olika former i din presentation.

Denna PHP-kod visar hur du tillämpar [mjuk kanter‑effekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) på en form:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Mjuk kanter‑effekt](soft_edges_effect.png)

## **Vanliga frågor**

**Kan jag tillämpa flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag tillämpa effekter på?**

Du kan tillämpa effekter på olika former, inklusive autoshapes, diagram, tabeller, bilder, SmartArt-objekt, OLE-objekt och mer.

**Kan jag tillämpa effekter på grupperade former?**

Ja, du kan tillämpa effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.