---
title: Beheer Inktobjecten in Presentaties in Java
linktitle: Beheer Inkt
type: docs
weight: 95
url: /nl/java/manage-ink/
keywords:
- inkt
- inktobject
- inkspoor
- beheer inkt
- teken inkt
- tekenen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Beheer PowerPoint-inktobjecten—maak, bewerk en style digitale inkt met Aspose.Slides voor Java. Verkrijg codevoorbeelden voor sporen, kwastkleur en -grootte."
---
## **Introductie**

PowerPoint biedt de inktfunctie zodat je niet‑standaard figuren kunt tekenen, die kunnen worden gebruikt om andere objecten te accentueren, verbindingen en processen weer te geven, en de aandacht te vestigen op specifieke items op een dia. 

Aspose.Slides levert alle Ink‑typen (bijv. de [Ink](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ink/) klasse) die je nodig hebt om inktobjecten te maken en te beheren. 

## **Verschillen tussen reguliere objecten en inktobjecten**

Objecten op een PowerPoint‑dia worden doorgaans weergegeven door vormobjecten. Een vormobject is in zijn eenvoudigste vorm een container die het gebied van het object zelf (het frame) definieert, samen met zijn eigenschappen. Het laatste omvat de grootte van het containergebied, de vorm van de container, de achtergrond van de container, enz. Voor informatie, zie [Shape Layout Format](https://docs.aspose.com/slides/nl/java/shape-manipulations/#access-layout-formats-for-shape).

Wanneer PowerPoint echter met een inktobject werkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaard `width`- en `height`‑waarden:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktvorm‑sporen**

Een trace is een basiselement of standaard die wordt gebruikt om de beweging van een pen vast te leggen terwijl een gebruiker digitale inkt schrijft. Traces zijn opnames die reeksen van aaneengeschakelde punten beschrijven. 

De eenvoudigste vorm van codering geeft de X‑ en Y‑coördinaten van elk monsterpunt op. Wanneer alle aaneengeschakelde punten worden gerenderd, ontstaat er een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Kwast‑eigenschappen voor tekenen**

Je kunt een kwast gebruiken om lijnen te tekenen die de punten van trace‑elementen verbinden. De kwast heeft zijn eigen kleur en grootte, overeenkomend met de `Brush.Color`‑ en `Brush.Size`‑eigenschappen. 

### **Stel inkt‑kwastkleur in**

Deze Java‑code laat zien hoe je de kleur voor een kwast instelt:

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

### **Stel inkt‑kwastgrootte in** 

Deze Java‑code laat zien hoe je de grootte voor een kwast instelt:

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

Over het algemeen komen de breedte en hoogte van een kwast niet overeen, waardoor PowerPoint de kwastgrootte niet toont (de datasectie is grijs). Wanneer de breedte en hoogte van de kwast wel overeenkomen, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid vergroten we de hoogte van het inktobject en bekijken we de belangrijke afmetingen: 

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de kwasten — hij gaat er altijd van uit dat de lijndikte nul is (zie de laatste afbeelding). 

Daarom moeten we, om het zichtbare gebied van het volledige inktobject te bepalen, de kwastgrootte van de trace‑objecten in beschouwing nemen. Hier is het doelobject (het handgeschreven tekst‑trace‑object) geschaald naar de container‑ (frame‑)grootte. Wanneer de grootte van de container (frame) verandert, blijft de kwastgrootte constant en omgekeerd. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vertoont hetzelfde gedrag bij teksten:

![ink_powerpoint6](ink_powerpoint6.png)

**Verdere lectuur**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/java/powerpoint-shapes/). 
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/java/shape-effective-properties/#getting-effective-font-height-value).