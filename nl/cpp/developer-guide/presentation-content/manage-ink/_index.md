---
title: Inktobjecten in presentaties beheren in C++
linktitle: Inkt beheren
type: docs
weight: 95
url: /nl/cpp/manage-ink/
keywords:
- inkt
- inkobject
- inkspoor
- ink beheren
- inkt tekenen
- tekenen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer PowerPoint-inkobjecten—creëer, bewerk en style digitale inkt met Aspose.Slides voor C++. Verkrijg codevoorbeelden voor sporen, penseelkleur en -grootte."
---
## **Inleiding**

PowerPoint biedt de inktfunctie die het mogelijk maakt om niet‑standaard figuren te tekenen, die gebruikt kunnen worden om andere objecten te markeren, verbindingen en processen weer te geven, en de aandacht op specifieke elementen op een dia te vestigen.  

Aspose.Slides levert de [Aspose.Slides.Ink](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ink/) interface, die de typen bevat die u nodig heeft om inktobjecten te maken en te beheren.  

## **Verschillen tussen gewone objecten en inktobjecten**

Objecten op een PowerPoint‑dia worden doorgaans weergegeven door vormobjecten. Een vormobject is in de eenvoudigste vorm een container die het gebied van het object zelf (het frame) definieert, samen met zijn eigenschappen. Daartoe behoren onder meer de grootte van het containergebied, de vorm van de container, de achtergrond van de container, enz. Voor meer informatie, zie [Shape Layout Format](https://docs.aspose.com/slides/nl/cpp/shape-manipulations/#access-layout-formats-for-shape).  

Echter, wanneer PowerPoint met een inktobject werkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaard `width`‑ en `height`‑waarden:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Sporen**

Een spoor is een basiselement of standaard die wordt gebruikt om de beweging van een pen vast te leggen terwijl een gebruiker digitale inkt schrijft. Spooropnamen beschrijven reeksen van aaneengeschakelde punten.  

De eenvoudigste vorm van codering geeft de X‑ en Y‑coördinaten van elk monsterpunt weer. Wanneer alle aaneengeschakelde punten worden gerenderd, ontstaat er een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Eigenschappen van de penseel voor tekenen**

U kunt een penseel gebruiken om lijnen te tekenen die de punten van spoor‑elementen verbinden. Het penseel heeft zijn eigen kleur en grootte, die overeenkomen met de `Brush.Color`‑ en `Brush.Size`‑eigenschappen.  

### **Stel inktpenseelkleur in**

Deze C++‑code toont hoe u de kleur van een penseel instelt:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Stel inktpenseelgrootte in**

Deze C++‑code toont hoe u de grootte van een penseel instelt:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

In het algemeen komen de breedte en hoogte van een penseel niet overeen, waardoor PowerPoint de penseelgrootte niet weergeeft (de gegevenssectie is grijs). Wanneer de breedte en hoogte van het penseel wel overeenkomen, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid verhogen we de hoogte van het inktobject en bekijken we de belangrijke afmetingen:

![ink_powerpoint4](ink_powerpoint4.png)

De container (het frame) houdt geen rekening met de grootte van de penselen — hij gaat altijd uit van een lijndikte van nul (zie de laatste afbeelding).  

Om het zichtbare gebied van het gehele inktobject te bepalen, moeten we daarom de penseelgrootte van de spoorobjecten meenemen. Hier is het doelobject (het handgeschreven tekstspoorobject) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container (frame) verandert, blijft de penseelgrootte constant en omgekeerd.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vertoont hetzelfde gedrag bij tekst:

![ink_powerpoint6](ink_powerpoint6.png)

**Verdere lectuur**

* Voor algemene informatie over vormen, zie de [PowerPoint Shapes](https://docs.aspose.com/slides/nl/cpp/powerpoint-shapes/) sectie.  
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/cpp/shape-effective-properties/#get-effective-font-height-value).