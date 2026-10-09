---
title: Vormeffecten toepassen in presentaties met PHP
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/php-java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie‑effect
- gloeieffect
- zachte randen effect
- effectformaat
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Transformeer uw PPT‑ en PPTX‑bestanden met geavanceerde vormeffecten met Aspose.Slides voor PHP via Java — maak in enkele seconden opvallende, professionele dia's."
---
## **Introductie**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/php-java/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt een of meer effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Daarom biedt PowerPoint opties onder **Voorinstelling**. De voorinstellingsopties zijn combinaties van twee of meer effecten die bekend staan als goed uitziend. Op deze manier hoef je bij het selecteren van een voorinstelling geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) klasse die het mogelijk maken om dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Schaduw‑effect toepassen**

Aspose.Slides voor PHP via Java ondersteunt buiten‑ en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en onscherpte‑radius aanpassen om overeen te komen met het ontwerp van je presentatie.

### **Buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en onscherpte‑radius aan om overeen te komen met de belichting en stijl van je sjabloon.

Deze PHP‑code toont hoe je het [buiten schaduw effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) op een rechthoek toepast:

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

![Schaduweffect](shadow_effect.png)

### **Binnen schaduw toepassen**

Wanneer je de visuele stijl van een sjabloon reproduceert, gebruik dan een binnen schaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze verhoogd lijken, terwijl een binnen schaduw de binnenkant van de randen verduistert.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) aan en configureer vervolgens de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Grotere waarden voor de onscherpte‑radius geven zachtere randen.

Deze PHP‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnen schaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten en de onscherpte‑radius is 6 punten:

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

![Lichtblauwe rechthoek met een binnenschaduw](inner_shadow_effect.png)

Om de binnen schaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) aan op het effect‑formaat van de vorm.

## **Reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor PHP via Java, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor je het snel kunt toepassen op meerdere elementen voor een consistent ontwerp.

Deze PHP‑code toont hoe je het [reflectie effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) op een vorm toepast:

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

![Reflectie‑effect](reflection_effect.png)

## **Gloed‑effect toepassen**

Om een gloed‑effect toe te passen op een vorm in Aspose.Slides voor PHP via Java, kun je een zachte, lumineuze aura rond vormen toevoegen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code en verbetert de algehele look van je dia’s.

Deze PHP‑code toont hoe je het [gloed effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) op een vorm toepast:

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

![Gloeieffect](glow_effect.png)

## **Zachte randen‑effect toepassen**

Om een zachte randen‑effect toe te passen in Aspose.Slides voor PHP via Java, kun je een soepele, vervaagde overgang rond de randen van een vorm creëren. Dit effect voegt een subtieler en verfijnder uiterlijk toe, perfect voor ontwerpen die een zachte, zachtere uitstraling nodig hebben. Je kunt eenvoudig parameters zoals de radius aanpassen om het gewenste effect te bereiken voor verschillende vormen in je presentatie.

Deze PHP‑code toont hoe je het [zachte randen effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) op een vorm toepast:

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

![Zachte randen‑effect](soft_edges_effect.png)

## **FAQ**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischer uiterlijk te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autoshapes, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt dan op de gehele groep toegepast.