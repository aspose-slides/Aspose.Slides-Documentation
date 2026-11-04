---
title: Toepassen van vormeffecten in presentaties met PHP
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/php-java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloeieffect
- zachte randen effect
- effectformaat
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten met Aspose.Slides voor PHP via Java — maak verbluffende, professionele dia's in seconden."
---
## **Introductie**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/php-java/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enzovoort.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meerdere effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Daarom biedt PowerPoint opties onder **Preset**. De Preset‑opties zijn combinaties van twee of meer effecten die bekend staan om er goed uit te zien. Op deze manier hoef je bij het selecteren van een preset geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/)‑klasse die je in staat stellen dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Een schaduweffect toepassen**

Aspose.Slides for PHP via Java ondersteunt buiten- en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsradius aanpassen zodat ze passen bij het ontwerp van je presentatie.

### **Buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en vervagingsradius aan zodat ze overeenkomen met de belichting en styling van je sjabloon.

Deze PHP‑code laat zien hoe je het [buitenste schaduweffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) op een rechthoek kunt toepassen:
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

### **Binnenste schaduw toepassen**

Wanneer je de visuele styling van een sjabloon nabootst, gebruik je een binnenste schaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze verhoogd lijken, terwijl een binnenste schaduw de binnenkant van de randen verduistert.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) aan en configureer vervolgens de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Grotere waarden voor de vervagingsradius geven zachtere randen.

Dit PHP‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenste schaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten en de vervagingsradius is 6 punten:
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

![Lichtblauwe rechthoek met een binnenste schaduw](inner_shadow_effect.png)

Om de binnenste schaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) aan op het effectformaat van de vorm.

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor PHP via Java, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert het esthetische van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met simpele code, waardoor een snelle toepassing over meerdere elementen mogelijk is voor een consistent ontwerp.

Deze PHP‑code laat zien hoe je het [reflectie‑effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) op een vorm kunt toepassen:
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

## **Een gloed‑effect toepassen**

Om een gloed‑effect toe te passen op een vorm in Aspose.Slides voor PHP via Java, kun je een zachte, lumineuze aura rond vormen toevoegen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het geheel van je dia's verbetert.

Deze PHP‑code laat zien hoe je het [gloed‑effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) op een vorm kunt toepassen:
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

![Gloed‑effect](glow_effect.png)

## **Een zacht‑rand‑effect toepassen**

Om een zacht‑rand‑effect toe te passen in Aspose.Slides voor PHP via Java, kun je een gladde, vervaagde overgang rond de randen van een vorm creëren. Dit effect geeft een subtieler en verfijnder uiterlijk, perfect voor ontwerpen die een zachte, subtiele uitstraling nodig hebben. Je kunt eenvoudig parameters zoals radius aanpassen om het gewenste effect te bereiken op verschillende vormen in je presentatie.

Deze PHP‑code laat zien hoe je het [zacht‑rand‑effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) op een vorm kunt toepassen:
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

![Zacht‑rand‑effect](soft_edges_effect.png)

## **Een vervagings‑effect toepassen**

Gebruik vervaging van een vorm om de vulling en omtrek van een vorm zachter te maken terwijl de vorm bewerkbaar blijft. Roep [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) aan op het effectformaat van de vorm. De radius wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging geven. Een radius van nul laat het uiterlijk ongewijzigd.

De instelling [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) bepaalt de zichtbare grenzen van het effect. Bij `false` wordt de vervaging bijgesneden tot de oorspronkelijke geschilderde grenzen, inclusief de omtrek. Bij `true` kan de vervaging zich buiten die grenzen uitbreiden. Geen van beide instellingen wijzigt de positie of afmetingen van de vorm.

De vergelijking hieronder gebruikt overal dezelfde vulling, omtrek en vormafmetingen. De bovenste rij gebruikt `grow = false`; de onderste rij gebruikt `grow = true`.

![Originele rechthoek vergeleken met vervagingsradii van 5 en 15 punten, met grow uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit PHP‑voorbeeld maakt een oranje rechthoek met een donkerblauwe omtrek, past een vervaging van 5 punten toe en werkt deze vervolgens bij naar een vervaging van 15 punten door opnieuw [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) aan te roepen. Het slaat beide vervaagde toestanden op, roept vervolgens [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) aan en slaat de vorm op zonder vervaging.
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

Vervaging van een vorm beïnvloedt zowel de vulling als de omtrek samen. Een zacht‑rand‑effect vervaagt de randen van de vorm, terwijl schaduw‑vervaging alleen de schaduw verzacht. Beeldtransformatie‑effecten werken op beeldinhoud; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm naar een afbeelding te converteren.

## **Veelgestelde vragen**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één enkele vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autoshapes, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de hele groep.