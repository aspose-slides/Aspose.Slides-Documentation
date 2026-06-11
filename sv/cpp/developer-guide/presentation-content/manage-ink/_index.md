---
title: Hantera presentationsbläckobjekt i C++
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/cpp/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Hantera PowerPoint-bläckobjekt – skapa, redigera och formatera digitalt bläck med Aspose.Slides för C++. Få kodexempel för spår, penselfärg och -storlek."
---
## **Introduktion**

PowerPoint erbjuder bläckfunktionen så att du kan rita icke‑standardfigurer, som kan användas för att markera andra objekt, visa anslutningar och processer samt rikta uppmärksamheten mot specifika element på en bild. 

Aspose.Slides tillhandahåller gränssnittet [Aspose.Slides.Ink](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ink/), som innehåller de typer du behöver för att skapa och hantera bläckobjekt. 

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras normalt av form‑objekt. Ett form‑objekt, i sin enklaste form, är en behållare som definierar objektets område (dess ram) samt dess egenskaper. Det senare inkluderar storleken på behållarområdet, formens kontur, behållarens bakgrund osv. För information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/cpp/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint däremot hanterar ett bläckobjekt ignoreras alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardiserade `width`‑ och `height`‑värdena:

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckformsspår**

Ett spår är ett grundläggande element eller en standard som används för att spela in en penna‑bana när en användare skriver digitalt bläck. Spår är inspelningar som beskriver sekvenser av anslutna punkter. 

Den enklaste kodningsformen specificerar X‑ och Y‑koordinaterna för varje samplingspunkt. När alla anslutna punkter återges bildas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penselinställningar för ritning**

Du kan använda en pensel för att rita linjer som förbinder spårets elementpunkter. Penseln har sin egen färg och storlek, motsvarande egenskaperna `Brush.Color` och `Brush.Size`. 

### **Ställ in bläckpenselfärg**

Detta C++‑kodexempel visar hur du ställer in färgen för en pensel:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Ställ in bläckpenselstorlek** 

Detta C++‑kodexempel visar hur du ställer in storleken för en pensel:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

I allmänhet matchar inte en pensels bredd och höjd, så PowerPoint visar inte penselns storlek (datasektionen är gråtonad). När penselns bredd och höjd däremot matchar visar PowerPoint dess storlek så här:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull, låt oss öka höjden på bläckobjektet och gå igenom de viktiga dimensionerna: 

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penslarnas storlek – den antar alltid att linjens tjocklek är noll (se den sista bilden). 

För att bestämma det synliga området för hela bläckobjektet måste vi beakta spårobjektens penselstorlek. Här har målobjektet (spårobjektet för handskriven text) skalats till behållarens (ramens) storlek. När behållarens (ramens) storlek ändras förblir penselstorleken konstant och vice versa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint uppvisar samma beteende när det gäller texter:

![ink_powerpoint6](ink_powerpoint6.png)

**Vidare läsning**

* För att läsa om former i allmänhet, se avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/cpp/powerpoint-shapes/). 
* För mer information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/cpp/shape-effective-properties/#get-effective-font-height-value).