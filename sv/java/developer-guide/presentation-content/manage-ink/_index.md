---
title: Hantera presentationsbläckobjekt i Java
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/java/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Hantera PowerPoint-bläckobjekt—skapa, redigera och formatera digitalt bläck med Aspose.Slides för Java. Få kodexempel för spår, penselfärg och -storlek."
---
## **Introduktion**

PowerPoint erbjuder bläckfunktionen som låter dig rita icke-standardfigurer, som kan användas för att markera andra objekt, visa samband och processer samt rikta uppmärksamheten mot specifika element på en bild. 

Aspose.Slides tillhandahåller alla Ink-typer (t.ex. [Ink](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ink/) klass) du behöver för att skapa och hantera bläckobjekt. 

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint-bild representeras vanligtvis av formobjekt. Ett formobjekt, i sin enklaste form, är en behållare som definierar objektets eget område (dess ram) tillsammans med dess egenskaper. Detta inkluderar behållarens storlek, behållarens form, behållarens bakgrund etc. För information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/java/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint hanterar ett bläckobjekt ignorerar den alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardmässiga `width`- och `height`-värdena:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape-spår**

Spår är ett grundelement eller en standard som används för att registrera pennans bana när en användare skriver digitalt bläck. Spår är inspelningar som beskriver sekvenser av sammanlänkade punkter. 

Den enklaste kodningsformen anger X- och Y-koordinaterna för varje samplingspunkt. När alla sammanlänkade punkter renderas bildas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pensel-egenskaper för ritning**

Du kan använda en pensel för att rita linjer som förbinder spårelementens punkter. Penseln har sin egen färg och storlek, motsvarande egenskaperna `Brush.Color` och `Brush.Size`. 

### **Ange bläckpenselfärg**

Denna Java-kod visar hur du anger färgen för en pensel:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ange bläckpenselstorlek** 

Denna Java-kod visar hur du anger storleken för en pensel:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

Generellt matchar inte en pensels bredd och höjd, så PowerPoint visar inte penselns storlek (datasektionen är gråtonad). Men när penselns bredd och höjd matchar visar PowerPoint dess storlek på följande sätt:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull ökar vi höjden på bläckobjektet och granskar de viktiga dimensionerna: 

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penselns storlek - den antar alltid att linjetjockleken är noll (se sista bilden). 

Därför, för att bestämma det synliga området för hela bläckobjektet, måste vi beakta spårobjektens penselstorlek. Här har målobjektet (spårobjektet för handskriven text) skalats till behållarens (ramens) storlek. När behållarens (ramens) storlek ändras förblir penselstorleken konstant och vice versa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint uppvisar samma beteende när det gäller texter:

![ink_powerpoint6](ink_powerpoint6.png)

**Vidare läsning**

* För att läsa om former i allmänhet, se avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/java/powerpoint-shapes/). 
* För mer information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/java/shape-effective-properties/#getting-effective-font-height-value).