---
title: Hantera presentationens bläckobjekt i PHP
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/php-java/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Hantera PowerPoint‑bläckobjekt — skapa, redigera och formatera digitalt bläck med Aspose.Slides för PHP via Java. Få kodexempel för spår, penselfärg och -storlek."
---
## **Introduktion**

PowerPoint erbjuder bläckfunktionen som låter dig rita icke‑standardfigurer, vilka kan användas för att markera andra objekt, visa samband och processer samt dra uppmärksamhet till specifika element på en bild. 

Aspose.Slides tillhandahåller alla Ink‑typer (t.ex. klassen [Ink](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ink/)) som du behöver för att skapa och hantera bläckobjekt.

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. Ett formobjekt, i sin enklaste form, är en behållare som definierar objektets område (dess ram) tillsammans med dess egenskaper. De senare omfattar storleken på behållarområdet, formens utseende, behållarens bakgrund osv. För mer information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/php-java/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint däremot hanterar ett bläckobjekt ignorerar det alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardiserade `width`‑ och `height`‑värdena:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑spår**

Ett spår är ett grundläggande element eller standard som används för att registrera en pennas bana när en användare skriver digitalt bläck. Spår är inspelningar som beskriver sekvenser av sammankopplade punkter. 

Den enklaste formen av kodning specificerar X‑ och Y‑koordinaterna för varje samplingspunkt. När alla sammankopplade punkter återges skapas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penselns egenskaper för ritning**

Du kan använda en pensel för att rita linjer som förbinder spårelementens punkter. Penseln har sin egen färg och storlek, motsvarande egenskaperna `Brush.Color` och `Brush.Size`. 

### **Ställ in bläckpenselfärg**

Denna PHP‑kod visar hur du ställer in färgen för en pensel:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ställ in bläckpenselstorlek** 

Denna PHP‑kod visar hur du ställer in storleken för en pensel:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Generellt sett matchar en pensels bredd och höjd inte, så PowerPoint visar inte penselns storlek (datasektionen är gråtonad). Men när penselns bredd och höjd matchar visar PowerPoint storleken på följande sätt:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull ökar vi höjden på bläckobjektet och går igenom de viktiga dimensionerna: 

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penslarnas storlek – den antar alltid att linjens tjocklek är noll (se den sista bilden). 

Därför måste vi, för att bestämma det synliga området för hela bläckobjektet, ta hänsyn till spårobjektens penselstorlek. Här har målobjektet (spårobjektet för handskriven text) skalats till behållarens (ramens) storlek. När storleken på behållaren (ramen) ändras förblir penselstorleken konstant och vice versa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint uppvisar samma beteende när det hanterar text:

![ink_powerpoint6](ink_powerpoint6.png)

**Vidare läsning**

* För att läsa om former i allmänhet, se avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/php-java/powerpoint-shapes/).
* För mer information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/php-java/shape-effective-properties/#getting-effective-font-height-value).