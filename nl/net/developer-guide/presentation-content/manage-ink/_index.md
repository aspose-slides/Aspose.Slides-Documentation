---
title: Beheer presentatie-inkobjecten in .NET
linktitle: Beheer Inkt
type: docs
weight: 95
url: /nl/net/manage-ink/
keywords:
- inkt
- inktobject
- inktspoor
- inkt beheren
- inkt tekenen
- tekenen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer PowerPoint-inkobjecten--maak, bewerk en style digitale inkt met Aspose.Slides voor .NET. Krijg code-voorbeelden voor sporen, penseelkleur en -grootte."
---
## **Introductie**

PowerPoint biedt de inktfunctie waarmee u niet‑standaard figuren kunt tekenen, die gebruikt kunnen worden om andere objecten te markeren, verbindingen en processen weer te geven, en de aandacht te vestigen op specifieke items op een dia.  

Aspose.Slides biedt de [Aspose.Slides.Ink](https://reference.aspose.com/slides/nl/net/aspose.slides.ink/) interface, die de typen bevat die u nodig heeft om inktobjecten te maken en te beheren.  

## **Verschillen tussen gewone objecten en inktobjecten**

Objecten op een PowerPoint‑dia worden doorgaans weergegeven als vormobjecten. Een vormobject, in zijn eenvoudigste vorm, is een container die het gebied van het object zelf (het frame) definieert, samen met zijn eigenschappen. De laatste omvat onder meer de grootte van het containergebied, de vorm van de container, de achtergrond van de container, enzovoort. Voor meer informatie, zie [Shape Layout Format](https://docs.aspose.com/slides/nl/net/shape-manipulations/#access-layout-formats-for-shape).

Wanneer PowerPoint echter met een inktobject werkt, negeert het alle eigenschappen van het object‑frame (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaard `width`‑ en `height`‑waarden:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑sporen**

Een spoor is een basis‑element of standaard die wordt gebruikt om de trajectorie van een pen vast te leggen terwijl een gebruiker digitale inkt schrijft. Sporen zijn opnames die reeksen van verbonden punten beschrijven.  

De eenvoudigste vorm van codering specificeert de X‑ en Y‑coördinaten van elk bemonsteringspunt. Wanneer alle verbonden punten worden gerenderd, ontstaat er een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penseleigenschappen voor tekenen**

U kunt een penseel gebruiken om lijnen te tekenen die de punten van spoor‑elementen met elkaar verbinden. Het penseel heeft zijn eigen kleur en grootte, overeenkomend met de eigenschappen `Brush.Color` en `Brush.Size`.  

### **Ink‑penseelkleur instellen**

Deze C#‑code toont hoe u de kleur voor een penseel instelt:

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

### **Ink‑penseelgrootte instellen** 

Deze C#‑code toont hoe u de grootte voor een penseel instelt:

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

Over het algemeen komen de breedte en hoogte van een penseel niet overeen, zodat PowerPoint de penseelgrootte niet weergeeft (de gegevenssectie wordt grijs). Wanneer de breedte en hoogte van het penseel wel overeenkomen, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid vergroten we de hoogte van het inktobject en bekijken we de belangrijke afmetingen:

![ink_powerpoint4](ink_powerpoint4.png)

De container (het frame) houdt geen rekening met de grootte van de pennen — hij gaat er altijd van uit dat de lijndikte nul is (zie de laatste afbeelding).  

Om dus het zichtbare gebied van het volledige inktobject te bepalen, moeten we de penseelgrootte van de spoorobjecten in beschouwing nemen. Hier is het doelobject (het handgeschreven tekstspoor) geschaald naar de grootte van de container (het frame). Wanneer de grootte van de container (het frame) verandert, blijft de penseelgrootte constant en omgekeerd.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vertoont hetzelfde gedrag bij tekst:

![ink_powerpoint6](ink_powerpoint6.png)

**Verder lezen**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/net/powerpoint-shapes/).  
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/net/shape-effective-properties/#get-effective-font-height-value).