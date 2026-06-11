---
title: Hantera presentationens bläckobjekt i .NET
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/net/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera PowerPoint‑bläckobjekt—skapa, redigera och formatera digitalt bläck med Aspose.Slides för .NET. Få kodexempel för spår, penselfärg och storlek."
---
## **Introduktion**

PowerPoint tillhandahåller bläckfunktionen för att låta dig rita icke‑standardfigurer, som kan användas för att markera andra objekt, visa anslutningar och processer, samt rikta uppmärksamheten mot specifika objekt på en bild. 

Aspose.Slides tillhandahåller gränssnittet [Aspose.Slides.Ink](https://reference.aspose.com/slides/sv/net/aspose.slides.ink/) som innehåller de typer du behöver för att skapa och hantera bläckobjekt. 

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. Ett formobjekt, i sin enklaste form, är en behållare som definierar området för själva objektet (dess ram) tillsammans med dess egenskaper. De senare inkluderar behållarens område storlek, formens form, behållarens bakgrund osv. För information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/net/shape-manipulations/#access-layout-formats-for-shape).

Men när PowerPoint hanterar ett bläckobjekt ignorerar det alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standard `width` och `height` värdena:

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckspår**

Ett spår är ett grundläggande element eller en standard som används för att registrera en pennas bana när en användare skriver digitalt bläck. Spår är inspelningar som beskriver sekvenser av sammankopplade punkter. 

Den enklaste formen av kodning specificerar X‑ och Y‑koordinaterna för varje samplingspunkt. När alla sammankopplade punkter renderas bildas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penselns egenskaper för ritning**

Du kan använda en pensel för att rita linjer som förbinder spårelementens punkter. Penseln har sin egen färg och storlek, motsvarande egenskaperna `Brush.Color` och `Brush.Size`. 

### **Ställ in bläckpenselfärg**

Denna C#‑kod visar hur du anger färgen för en pensel:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **Ställ in bläckpenselstorlek** 

Denna C#‑kod visar hur du anger storleken för en pensel:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

Generellt matchar inte en pensels bredd och höjd, så PowerPoint visar inte penselns storlek (datasektionen är gråtonad). Men när penselns bredd och höjd matchar visar PowerPoint dess storlek på följande sätt:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull, låt oss öka höjden på bläckobjektet och granska de viktiga dimensionerna: 

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penslarnas storlek – den antar alltid att linjetjockleken är noll (se den sista bilden). 

Därför, för att bestämma det synliga området för hela bläckobjektet, måste vi beakta spårobjektens penselstorlek. Här har målobjektet (spårobjektet för handskriven text) skalats till behållarens (ramens) storlek. När storleken på behållaren (ramen) förändras förblir penselns storlek konstant och vice versa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint uppvisar samma beteende när det hanterar text:

![ink_powerpoint6](ink_powerpoint6.png)

**Vidare läsning**

* För läsning om former i allmänhet, se avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/net/powerpoint-shapes/). 
* För mer information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/net/shape-effective-properties/#get-effective-font-height-value).