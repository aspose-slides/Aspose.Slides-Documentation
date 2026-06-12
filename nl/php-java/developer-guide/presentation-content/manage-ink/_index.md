---
title: Beheer presentatie‑inkobjecten in PHP
linktitle: Beheer Inkt
type: docs
weight: 95
url: /nl/php-java/manage-ink/
keywords:
- inkt
- inktobject
- inktspoor
- ink beheren
- ink tekenen
- tekenen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer PowerPoint-inkobjecten — maak, bewerk en style digitale inkt met Aspose.Slides voor PHP via Java. Verkrijg codevoorbeelden voor sporen, penseelkleur en -grootte."
---
## **Introductie**

PowerPoint biedt de ink‑functie waarmee u niet‑standaard figuren kunt tekenen, die gebruikt kunnen worden om andere objecten te markeren, verbindingen en processen weer te geven, en de aandacht te vestigen op specifieke items op een dia.  

Aspose.Slides levert alle Ink‑types (bijv. de klasse [Ink](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ink/)) die u nodig hebt om ink‑objecten te maken en te beheren.

## **Verschillen tussen reguliere objecten en ink‑objecten**

Objecten op een PowerPoint‑dia worden meestal weergegeven door vormobjecten. Een vormobject is in de eenvoudigste vorm een container die het gebied van het object zelf (het frame) definieert, samen met de eigenschappen ervan. Laatstgenoemde omvat de grootte van het containergebied, de vorm van de container, de achtergrond van de container, enz. Voor meer informatie, zie [Shape Layout Format](https://docs.aspose.com/slides/nl/php-java/shape-manipulations/#access-layout-formats-for-shape).

Wanneer PowerPoint echter met een ink‑object werkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaard `width`‑ en `height`‑waarden:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑traces**

Een trace is een basiselement of standaard die de trajectorie van een pen vastlegt terwijl een gebruiker digitale inkt schrijft. Traces zijn opnamen die reeksen van verbonden punten beschrijven.  

De eenvoudigste coderingsvorm specificeert de X‑ en Y‑coördinaten van elk monsterpunt. Wanneer alle verbonden punten worden gerenderd, ontstaat er een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penseleigenschappen voor tekenen**

U kunt een penseel gebruiken om lijnen te tekenen die de punten van trace‑elementen met elkaar verbinden. Het penseel heeft zijn eigen kleur en grootte, overeenkomend met de eigenschappen `Brush.Color` en `Brush.Size`.  

### **Ink‑penseelkleur instellen**

Deze PHP‑code laat zien hoe u de kleur voor een penseel instelt:

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

### **Ink‑penseelgrootte instellen**  

Deze PHP‑code laat zien hoe u de grootte voor een penseel instelt:

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

Over het algemeen komen de breedte en hoogte van een penseel niet overeen, waardoor PowerPoint de penseelgrootte niet weergeeft (de gegevenssectie is grijs). Maar wanneer de breedte en hoogte van het penseel wel overeenkomen, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid vergroten we de hoogte van het ink‑object en bekijken we de belangrijke afmetingen:

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de penselen — hij gaat ervan uit dat de lijndikte nul is (zie de laatste afbeelding).  

Om het zichtbare gebied van het volledige ink‑object te bepalen, moeten we de penseelgrootte van de trace‑objecten in aanmerking nemen. Hier is het doelobject (het trace‑object van handgeschreven tekst) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container (frame) verandert, blijft de penseelgrootte constant en vice‑versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vertoont hetzelfde gedrag bij het omgaan met tekst:

![ink_powerpoint6](ink_powerpoint6.png)

**Meer lezen**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/php-java/powerpoint-shapes/).
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/php-java/shape-effective-properties/#getting-effective-font-height-value).