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
- mjuk kant-effekt
- effektformat
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Transformera dina PPT- och PPTX-filer med avancerade formeffekter med Aspose.Slides för PHP via Java — skapa iögonfallande, professionella bildspel på några sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fyllningar](/slides/sv/php-java/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd osv.

![Formeffekt](shape-effect.png)

PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan tillämpa en eller flera effekter på en form.

Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen erbjuder PowerPoint alternativ under **Förinställning**. Förinställningsalternativen är kombinationer av två eller fler effekter som är kända för att se bra ut. På så sätt, genom att välja en förinställning, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en bra kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) som låter dig tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Applicera en skuggeffekt**

Aspose.Slides för PHP via Java stödjer yttre och inre skuggor för former. Du kan anpassa deras färg, riktning, avstånd och oskärpe‑radie för att matcha din presentations design.

### **Applicera en yttre skugga**

Använd en yttre skugga för att få ett kort eller en panel att sticka ut mot bildbakgrunden. Skuggan sträcker sig utanför formens kanter och skapar intrycket att formen är upphöjd över bilden. Justera dess färg, riktning, avstånd och oskärpe‑radie för att matcha belysningen och stilen i din mall.

Denna PHP‑kod visar hur du tillämpar [yttre skuggeffekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) på en rektangel:

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

### **Applicera en inre skugga**

När du återger en mallens visuella stil, använd en inre skugga för att ge ett kort eller en panel ett nedsänkt utseende. En yttre skugga sträcker sig utanför formen och får den att se upphöjd ut, medan en inre skugga skuggar insidan av dess kanter.

Anropa [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) och konfigurera sedan den skugga som returneras av [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Större värden för oskärpe‑radie ger mjukare kanter.

Detta PHP‑exempel skapar ett ljusblått kort med en mörkgrå inre skugga och sparar det som en PPTX‑fil. Skuggans riktning är 225 grader, dess avstånd är 7 punkter och dess oskärpe‑radie är 6 punkter:

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

## **Applicera en reflektionseffekt**

För att tillämpa en reflektionseffekt i Aspose.Slides för PHP via Java kan du lägga till en spegel‑lik reflektion på former och justera parametrar som avstånd, transparens och storlek. Denna effekt förbättrar estetik i dina presentationer genom att ge former ett mer polerat och sofistikerat utseende. Den är enkel att implementera med enkel kod, vilket möjliggör snabb tillämpning över flera element för en enhetlig design.

Denna PHP‑kod visar hur du tillämpar [reflektionseffekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) på en form:

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

## **Applicera en glödeffekt**

För att tillämpa en glödeffekt på en form i Aspose.Slides för PHP via Java kan du lägga till en mjuk, lysande aura runt former och justera egenskaper som färg och storlek. Denna effekt hjälper till att få former att sticka ut och ger ett attraktivt, iögonfallande visuellt element till din presentation. Den är enkel att implementera med minimal kod och förbättrar det övergripande utseendet på dina bildspel.

Denna PHP‑kod visar hur du tillämpar [glödeffekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) på en form:

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

## **Applicera en mjuk kant‑effekt**

För att tillämpa en mjuk kant‑effekt i Aspose.Slides för PHP via Java kan du skapa en jämn, suddig övergång runt enformes kanter. Denna effekt ger ett mer subtilt och raffinerat utseende, perfekt för designer som behöver ett mjukt, mjukare intryck. Du kan enkelt justera parametrar som radie för att uppnå önskad effekt på olika former i din presentation.

Denna PHP‑kod visar hur du tillämpar [mjuk kant‑effekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) på en form:

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

![Mjuk kant‑effekt](soft_edges_effect.png)

## **Applicera en oskärpeeffekt**

Använd formoskarphet för att mjuka upp en forms fyllning och kontur samtidigt som formen förblir redigerbar. Anropa [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) på formens effektformat. Radien mäts i punkter (1/72 tum): använd ett icke‑negativt värde, där större värden ger starkare oskärpa. En radie på noll lämnar utseendet oförändrat.

Inställningen [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) styr de synliga gränserna för effekten. Med `false` beskärs oskärpan till de ursprungligt målade gränserna, inklusive konturen. Med `true` kan oskärpan sträcka sig utanför dessa gränser. Ingen av inställningarna ändrar formens position eller dimensioner.

Jämförelsen nedan använder samma fyllning, kontur och formdimensioner genomgående. Övre raden använder `grow = false`; nedre raden använder `grow = true`.

![Original rektangel jämfört med oskärperadier på 5 och 15 punkter, med grow avstängd och aktiverad](shape_blur_comparison.png)

Detta PHP‑exempel skapar en orange rektangel med en mörkblå kontur, applicerar en oskärpa på 5 punkter och uppdaterar sedan till en oskärpa på 15 punkter genom att anropa [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) igen. Det sparar båda oskärpta tillstånden, anropar sedan [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) och sparar formen utan oskärpa.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Formoskarphet påverkar både fyllning och kontur tillsammans. En mjuk kant‑effekt tonar ned formens kanter, medan skuggoskarphet mjukar bara skuggan. Bildtransformeringseffekter verkar på bildinnehållet; detta exempel applicerar oskärpa direkt på formens effektformat utan att konvertera formen till en bild.

## **FAQ**

**Kan jag tillämpa flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enskild form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autoformer, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.