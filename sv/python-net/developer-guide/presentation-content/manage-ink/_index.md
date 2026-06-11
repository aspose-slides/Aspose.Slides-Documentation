---
title: Hantera bläckobjekt i presentationer med Python
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/python-net/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera PowerPoint‑bläckobjekt—skapa, redigera och formatera digitalt bläck med Aspose.Slides för Python via .NET. Få kodexempel för spår, penselfärg och -storlek."
---
## **Introduktion**

PowerPoint tillhandahåller bläckfunktionen som låter dig rita icke-standardfigurer, vilka kan användas för att markera andra objekt, visa samband och processer samt rikta uppmärksamheten mot specifika element på en bild. 

Aspose.Slides tillhandahåller namnrymden [aspose.slides.ink](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ink/), som innehåller de typer du behöver för att skapa och hantera bläckobjekt. 

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. Ett formobjekt, i sin enklaste form, är en behållare som definierar objektets område (dess ram) tillsammans med dess egenskaper. Detta inkluderar behållarens storlek, behållarens form, behållarens bakgrund osv. För information, se [Formlayoutformat](https://docs.aspose.com/slides/sv/python-net/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint däremot hanterar ett bläckobjekt ignorerar det alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standard `width` och `height` värdena:

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckformsspår**

Ett spår är ett grundelement eller en standard som används för att registrera en pensels bana när en användare skriver digitalt bläck. Spår är inspelningar som beskriver sekvenser av sammanhängande punkter. 

Den enklaste formen av kodning specificerar X- och Y-koordinaterna för varje sampelpunk​t. När alla sammankopplade punkter renderas bildas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## Pensel‑egenskaper för ritning

Du kan använda en pensel för att rita linjer som förbinder spårelementens punkter. Penseln har sin egen färg och storlek, vilket motsvarar egenskaperna `Brush.color` och `Brush.size`.

### **Ange bläckpenselfärg**

Denna Python‑kod visar hur du anger färgen för en pensel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Ange bläckpenselstorlek**

Denna Python‑kod visar hur du anger storleken för en pensel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Generellt matchar en pensels bredd och höjd inte, så PowerPoint visar inte penselns storlek (datasektionen är gråtonad). Men när penselns bredd och höjd matchar visar PowerPoint dess storlek så här:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull, låt oss öka höjden på bläckobjektet och granska de viktiga dimensionerna: 

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penselns storlek – den antar alltid att linjens tjocklek är noll (se den sista bilden). 

Därför måste vi för att bestämma det synliga området för hela bläckobjektet ta hänsyn till spårobjektens penselstorlek. Här har målobjektet (spårobjektet för handskriven text) skalats till behållarens (ramens) storlek. När behållarens (ramens) storlek ändras förblir penselns storlek konstant och vice versa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint visar samma beteende när det hanterar text:

![ink_powerpoint6](ink_powerpoint6.png)

**Vidare läsning**

* För att läsa om former i allmänhet, se avsnittet [PowerPoint‑former](https://docs.aspose.com/slides/sv/python-net/powerpoint-shapes/). 
* För mer information om effektiva värden, se [Formens effektiva egenskaper](https://docs.aspose.com/slides/sv/python-net/shape-effective-properties/#get-effective-font-height-value).