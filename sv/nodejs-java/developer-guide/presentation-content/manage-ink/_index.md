---
title: Hantera presentationsbläckobjekt i JavaScript
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/nodejs-java/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera PowerPoint-bläckobjekt—skapa, redigera och formatera digitalt bläck med Aspose.Slides för Node.js. Få JavaScript-kodexempel för spår, penselfärg och -storlek."
---
## **Introduktion**

PowerPoint erbjuder ink-funktionen som låter dig rita icke‑standardfigurer, vilka kan användas för att markera andra objekt, visa kopplingar och processer samt dra uppmärksamhet till specifika element på en bild. 

Aspose.Slides tillhandahåller alla Ink-typer (t.ex. [Ink](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ink/) klass) som du behöver för att skapa och hantera ink-objekt.

## **Skillnader mellan vanliga objekt och ink‑objekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. Ett formobjekt, i sin enklaste form, är en behållare som definierar objektets eget område (dess ram) tillsammans med dess egenskaper. Det senare inkluderar behållarens storlek, behållarens form, behållarens bakgrund osv. För information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Men när PowerPoint hanterar ett ink‑objekt ignorerar det alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standard `width` och `height` värdena:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑spår**

Ett spår är ett grundläggande element eller en standard som används för att registrera en pennas bana när en användare skriver digitalt bläck. Spår är inspelningar som beskriver sekvenser av sammankopplade punkter. 

Den enklaste formen av kodning specificerar X‑ och Y‑koordinaterna för varje sampelpunkt. När alla sammankopplade punkter renderas skapas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## Pensleegenskaper för ritning

Du kan använda en pensel för att rita linjer som förbinder spårelementens punkter. Penseln har sin egen färg och storlek, motsvarande `Brush.setColor` och `Brush.setSize` metoderna. 

### **Ange färg för ink‑pensel**

Denna JavaScript‑kod visar hur du ställer in färgen för en pensel:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ange storlek för ink‑pensel** 

Denna JavaScript‑kod visar hur du ställer in storleken för en pensel:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Generellt matchar en pensels bredd och höjd inte, så PowerPoint visar inte penselns storlek (datasektionen är gråtonad). Men när penselns bredd och höjd matchar visar PowerPoint dess storlek på följande sätt:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull, låt oss öka höjden på ink‑objektet och gå igenom de viktiga dimensionerna: 

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penselns storlek – den antar alltid att linjetjockleken är noll (se den sista bilden). 

Därför måste vi, för att bestämma det synliga området för hela ink‑objektet, ta hänsyn till spårobjektens penselstorlek. Här har målobjektet (spårobjektet för handskriven text) skalats till behållarens (ramens) storlek. När behållarens (ramens) storlek ändras förblir penselns storlek konstant och vice versa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint uppvisar samma beteende när det hanterar text:

![ink_powerpoint6](ink_powerpoint6.png)

**Vidare läsning**

* För att läsa om former i allmänhet, se avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/nodejs-java/powerpoint-shapes/).
* För mer information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).