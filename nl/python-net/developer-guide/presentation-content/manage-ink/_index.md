---
title: Inkobjecten beheren in presentaties met Python
linktitle: Ink beheren
type: docs
weight: 95
url: /nl/python-net/manage-ink/
keywords:
- inkt
- inktobject
- inktspoor
- inkt beheren
- inkt tekenen
- tekenen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer PowerPoint-inktobjecten—maak, bewerk en style digitale inkt met Aspose.Slides voor Python via .NET. Ontvang codevoorbeelden voor sporen, penseelkleur en -grootte."
---
## **Introductie**

PowerPoint biedt de inkt‑functie waarmee u niet‑standaard figuren kunt tekenen, die kunnen worden gebruikt om andere objecten te markeren, verbindingen en processen weer te geven, en de aandacht te vestigen op specifieke items op een dia. 

Aspose.Slides biedt de namespace [aspose.slides.ink](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ink/) , die de typen bevat die u nodig heeft om inktobjecten te maken en te beheren. 

## **Verschillen tussen reguliere objecten en inktobjecten**

Objecten op een PowerPoint‑dia worden doorgaans weergegeven door vormobjecten. Een vormobject is in zijn eenvoudigste vorm een container die het gebied van het object zelf (het kader) definieert, samen met zijn eigenschappen. Dit omvat onder meer de grootte van het containergebied, de vorm van de container, de achtergrond van de container, enz. Voor meer informatie, zie [Shape Layout Format](https://docs.aspose.com/slides/nl/python-net/shape-manipulations/#access-layout-formats-for-shape).

Wanneer PowerPoint echter een inktobject behandelt, negeert het alle eigenschappen van het objectkader (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaardwaarden `width` en `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktvormsporen**

Een spoor is een basis‑element of standaard die wordt gebruikt om de trajectory van een pen vast te leggen wanneer een gebruiker digitale inkt schrijft. Sporen zijn opnames die reeksen van verbonden punten beschrijven. 

De eenvoudigste vorm van codering specificeert de X‑ en Y‑coördinaten van elk monsterpunt. Wanneer alle verbonden punten worden gerenderd, produceren ze een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## Penselen-eigenschappen voor tekenen 

U kunt een penseel gebruiken om lijnen te tekenen die de punten van spoorelementen verbinden. Het penseel heeft zijn eigen kleur en grootte, overeenkomend met de eigenschappen `Brush.color` en `Brush.size`. 

### **Inktpenseelkleur instellen**

Deze Python‑code laat zien hoe u de kleur voor een penseel instelt:

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

### **Inktpenseelgrootte instellen** 

Deze Python‑code laat zien hoe u de grootte voor een penseel instelt:

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

Over het algemeen komen de breedte en hoogte van een penseel niet overeen, waardoor PowerPoint de penseelgrootte niet weergeeft (de gegevenssectie is grijs). Wanneer de breedte en hoogte van het penseel wel overeenkomen, toont PowerPoint de grootte op de volgende manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid verhogen we de hoogte van het inktobject en bekijken we de belangrijke afmetingen: 

![ink_powerpoint4](ink_powerpoint4.png)

De container (kader) houdt geen rekening met de grootte van de penselen – hij gaat altijd uit van een lijndikte van nul (zie de laatste afbeelding). 

Daarom moeten we, om het zichtbare gebied van het gehele inktobject te bepalen, de penseelgrootte van de spoobjecten in overweging nemen. Hier is het doelobject (het handgeschreven tekstspoorobject) geschaald naar de grootte van de container (kader). Wanneer de grootte van de container (kader) verandert, blijft de penseelgrootte constant en omgekeerd. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vertoont hetzelfde gedrag bij het omgaan met tekst:

![ink_powerpoint6](ink_powerpoint6.png)

**Verdere lectuur**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/python-net/powerpoint-shapes/). 
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/python-net/shape-effective-properties/#get-effective-font-height-value).