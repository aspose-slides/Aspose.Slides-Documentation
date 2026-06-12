---
title: Beheer SmartArt‑grafieken in presentaties op Android
linktitle: SmartArt‑grafieken
type: docs
weight: 20
url: /nl/androidjava/manage-smartart-shape/
keywords:
- SmartArt‑object
- SmartArt‑grafiek
- SmartArt‑stijl
- SmartArt‑kleur
- SmartArt maken
- SmartArt toevoegen
- SmartArt bewerken
- SmartArt wijzigen
- SmartArt benaderen
- SmartArt‑lay-outtype
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Automatiseer het maken, bewerken en stijlen van PowerPoint‑SmartArt met Aspose.Slides voor Android, met beknopte Java‑codevoorbeelden en prestatiegerichte begeleiding."
---
## **Overzicht**

Aspose.Slides stelt je in staat om programmatically SmartArt‑grafieken te maken en te beheren in PowerPoint‑presentaties. Dit artikel legt uit hoe je een SmartArt‑vorm aan een dia toevoegt, bestaande SmartArt‑vormen benadert, SmartArt vindt op basis van een specifiek layouttype en het visuele uiterlijk bijwerkt door de SmartArt‑stijl of kleurstijl te wijzigen.

De voorbeelden laten zien hoe je met SmartArt‑vormen werkt via de vormverzameling van de presentatiedia, controleert of een vorm SmartArt is en vervolgens de eigenschappen wijzigt of inspecteert.

## **Een SmartArt‑vorm maken**
Aspose.Slides voor Android via Java biedt een API om SmartArt‑vormen te maken. Volg de onderstaande stappen om een SmartArt‑vorm in een dia te maken:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Verkrijg de referentie van een dia door de index ervan te gebruiken.
1. [Voeg een SmartArt‑vorm toe](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) door de [LayoutType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtLayoutType) in te stellen.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```java
// Instantieer Presentatie‑klasse
Presentation pres = new Presentation();
try {
    // Krijg eerste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voeg Smart Art‑vorm toe
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Sla presentatie op
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figuur: SmartArt‑vorm toegevoegd aan de dia**|

## **Een SmartArt‑vorm op een dia benaderen**
De volgende code wordt gebruikt om de SmartArt‑vormen die aan een presentatiedia zijn toegevoegd te benaderen. In de voorbeeldcode lopen we door elke vorm in de dia en controleren we of het een [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt)‑vorm is. Als de vorm van het type SmartArt is, casten we deze naar een **SmartArt**‑instantie.

```java
// Laad de gewenste presentatie
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Loop door elke vorm in de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt)
        {
            // Cast vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een SmartArt‑vorm met een bepaald layouttype benaderen**
De volgende voorbeeldcode helpt om de [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt)‑vorm met een specifiek LayoutType te benaderen. Let op dat je het LayoutType van de SmartArt niet kunt wijzigen; het is alleen-lezen en wordt ingesteld wanneer de [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt)‑vorm wordt toegevoegd.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse en laad de presentatie met de SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia door de index ervan te gebruiken.
1. Loop door elke vorm in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt wanneer dat het geval is.
1. Controleer de SmartArt‑vorm met het specifieke LayoutType en voer de benodigde acties uit.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Loop door elke vorm in de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt)
        {
            // Cast de vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Controle van SmartArt layout
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Stijl van een SmartArt‑vorm wijzigen**
In dit voorbeeld leren we de snelle stijl van een willekeurige SmartArt‑vorm te wijzigen.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse en laad de presentatie met de SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia door de index ervan te gebruiken.
1. Loop door elke vorm in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt wanneer dat het geval is.
1. Zoek de SmartArt‑vorm met de gewenste stijl.
1. Stel de nieuwe stijl in voor de SmartArt‑vorm.
1. Sla de presentatie op.

```java
// Instantieer Presentatie‑klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Haal eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Loop door elke vorm in de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Controle van SmartArt‑stijl
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Wijzig SmartArt‑stijl
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Sla presentatie op
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figuur: SmartArt‑vorm met gewijzigde stijl**|

## **Kleurstijl van een SmartArt‑vorm wijzigen**
In dit voorbeeld leren we de kleurstijl van een willekeurige SmartArt‑vorm te wijzigen. In de onderstaande voorbeeldcode wordt de SmartArt‑vorm met een specifieke kleurstijl benaderd en wordt de stijl aangepast.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse en laad de presentatie met de SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia door de index ervan te gebruiken.
1. Loop door elke vorm in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt wanneer dat het geval is.
1. Zoek de SmartArt‑vorm met de gewenste kleurstijl.
1. Stel de nieuwe kleurstijl in voor de SmartArt‑vorm.
1. Sla de presentatie op.

```java
// Instantieer Presentatie-klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Haal eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Loop door elke vorm in de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Controle van SmartArt kleurtype
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Wijzig SmartArt kleurtype
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Sla presentatie op
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figuur: SmartArt‑vorm met gewijzigde kleurstijl**|

## **FAQ**

**Kan ik SmartArt animeren als één enkel object?**

Ja. SmartArt is een vorm, dus je kunt [standaardanimaties](/slides/nl/androidjava/powerpoint-animation/) toepassen via de animatie‑API (invoer, uitgang, nadruk, bewegingspaden) net als bij andere vormen.

**Hoe vind ik een specifieke SmartArt op een dia als ik de interne ID niet ken?**

Stel de Alternatieve Tekst (AltText) in en zoek de vorm op basis daarvan – dit wordt aanbevolen om de gewenste vorm te lokaliseren.

**Kan ik SmartArt groeperen met andere vormen?**

Ja. Je kunt SmartArt groeperen met andere vormen (afbeeldingen, tabellen, enz.) en vervolgens de [groep manipuleren](/slides/nl/androidjava/group/).

**Hoe krijg ik een afbeelding van een specifieke SmartArt (bijvoorbeeld voor een preview of rapport)?**

Exporteer een miniatuur/afbeelding van de vorm; de bibliotheek kan [individuele vormen renderen](/slides/nl/androidjava/create-shape-thumbnails/) naar rasterbestanden (PNG/JPG/TIFF).

**Wordt het uiterlijk van SmartArt behouden bij het converteren van de volledige presentatie naar PDF?**

Ja. De renderengine streeft naar hoge getrouwheid voor [PDF‑export](/slides/nl/androidjava/convert-powerpoint-to-pdf/), met een reeks kwaliteit‑ en compatibiliteitsopties.