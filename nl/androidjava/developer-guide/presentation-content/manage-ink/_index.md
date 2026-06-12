---
title: Inktobjecten in presentaties beheren op Android
linktitle: Inkt beheren
type: docs
weight: 95
url: /nl/androidjava/manage-ink/
keywords:
- inkt
- inkobject
- inkspoor
- inkt beheren
- inkt tekenen
- tekenen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer PowerPoint‑inktobjecten—maak, bewerk en stijl digitale inkt met Aspose.Slides voor Android. Ontvang Java‑codevoorbeelden voor sporen, penseelkleur en -grootte."
---
## **Introductie**

PowerPoint biedt de inkt‑functie waarmee je niet‑standaard figuren kunt tekenen, die je kunt gebruiken om andere objecten te markeren, verbindingen en processen te tonen, en de aandacht op specifieke elementen op een dia te vestigen.  

Aspose.Slides levert alle Ink‑typen (bijv. de klasse [Ink](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ink/) ) die je nodig hebt om inkt‑objecten te maken en te beheren.

## **Verschillen tussen reguliere objecten en inkt‑objecten**

Objecten op een PowerPoint‑dia worden doorgaans weergegeven als vorm‑objecten. Een vorm‑object is in zijn eenvoudigste vorm een container die het gebied van het object zelf (het frame) definieert, samen met zijn eigenschappen. Deze omvatten onder andere de afmetingen van het container‑gebied, de vorm van de container, de achtergrond van de container, enzovoort. Zie voor meer informatie [Shape Layout Format](https://docs.aspose.com/slides/nl/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Echter, wanneer PowerPoint met een inkt‑object werkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De afmeting van het container‑gebied wordt bepaald door de standaard `width`‑ en `height`‑waarden:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktvorm‑sporen**

Een trace is een basiselement of standaard die wordt gebruikt om de traject van een pen vast te leggen terwijl een gebruiker digitale inkt schrijft. Traces zijn opnames die reeksen van verbonden punten beschrijven.  

De eenvoudigste vorm van codering geeft de X‑ en Y‑coördinaten van elk bemonsteringspunt op. Wanneer alle verbonden punten worden gerenderd, ontstaat een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penseel‑eigenschappen voor tekenen**

Je kunt een penseel gebruiken om lijnen te tekenen die de punten van trace‑elementen verbinden. Het penseel heeft zijn eigen kleur en grootte, overeenkomend met de eigenschappen `Brush.Color` en `Brush.Size`.

### **Ink‑penseelkleur instellen**

Deze Java‑code laat zien hoe je de kleur voor een penseel instelt:

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

### **Ink‑penseelgrootte instellen** 

Deze Java‑code laat zien hoe je de grootte voor een penseel instelt:

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

Over het algemeen komen de breedte en hoogte van een penseel niet overeen, waardoor PowerPoint de penseelgrootte niet weergeeft (de datasectie is grijs). Maar wanneer de breedte en hoogte wel overeenkomen, toont PowerPoint de grootte als volgt:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid verhogen we de hoogte van het inkt‑object en bekijken we de belangrijke afmetingen: 

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de penselen – hij gaat er altijd van uit dat de lijndikte nul is (zie de laatste afbeelding).  

Daarom moeten we, om het zichtbare gebied van het volledige inkt‑object te bepalen, de penseelgrootte van de trace‑objecten in aanmerking nemen. Hier is het doelobject (het handgeschreven tekst‑trace‑object) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container (frame) verandert, blijft de penseelgrootte constant en vice‑versa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vertoont hetzelfde gedrag bij tekst:

![ink_powerpoint6](ink_powerpoint6.png)

**Verdere lectuur**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/androidjava/powerpoint-shapes/).
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/androidjava/shape-effective-properties/#getting-effective-font-height-value).