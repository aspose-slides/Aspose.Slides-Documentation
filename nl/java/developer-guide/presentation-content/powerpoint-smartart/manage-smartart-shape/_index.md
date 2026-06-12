---
title: Beheer SmartArt-afbeeldingen in presentaties met Java
linktitle: SmartArt-afbeeldingen
type: docs
weight: 20
url: /nl/java/manage-smartart-shape/
keywords:
- SmartArt-object
- SmartArt-afbeelding
- SmartArt-stijl
- SmartArt-kleur
- SmartArt maken
- SmartArt toevoegen
- SmartArt bewerken
- SmartArt wijzigen
- SmartArt benaderen
- SmartArt lay-outtype
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Automatiseer het maken, bewerken en stylen van PowerPoint SmartArt in Java met Aspose.Slides, met beknopte codevoorbeelden en prestatiegerichte begeleiding."
---
## **Overzicht**

Aspose.Slides stelt u in staat om programmatically SmartArt-afbeeldingen te maken en te beheren in PowerPoint‑presentaties. Dit artikel legt uit hoe u een SmartArt‑vorm aan een dia toevoegt, bestaande SmartArt‑vormen benadert, SmartArt vindt op basis van een specifiek lay‑outtype, en het uiterlijk bijwerkt door de SmartArt‑stijl of kleurstijl te wijzigen.

De voorbeelden laten zien hoe u met SmartArt‑vormen werkt via de vormverzameling van de presentatiedia, controleert of een vorm SmartArt is en vervolgens de eigenschappen wijzigt of inspecteert.

## **Een SmartArt‑vorm maken**
Aspose.Slides for Java heeft een API beschikbaar gesteld om SmartArt‑vormen te maken. Om een SmartArt‑vorm in een dia te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.  
2. Verkrijg de referentie van een dia door gebruik te maken van de Index.  
3. [Add a SmartArt shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) door de [LayoutType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType) in te stellen.  
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```java
// Instantieer Presentation-klasse
Presentation pres = new Presentation();
try {
    // Haal eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voeg SmartArt-vorm toe
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
De volgende code wordt gebruikt om de SmartArt‑vormen die aan de presentatiedia zijn toegevoegd te benaderen. In de voorbeeldcode doorlopen we elke vorm op de dia en controleren of het een [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt)‑vorm is. Als de vorm van het type SmartArt is, casten we deze naar een [**SmartArt**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt)‑instantie.

```java
// Laad de gewenste presentatie
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt)
        {
            // Cast de vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een SmartArt‑vorm benaderen met een specifiek lay‑outtype**
De volgende voorbeeldcode helpt om de [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt)‑vorm met een bepaald LayoutType te benaderen. Let op dat u het LayoutType van de SmartArt niet kunt wijzigen, omdat deze alleen‑lezen is en alleen wordt ingesteld wanneer de [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt)‑vorm wordt toegevoegd.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie van de eerste dia door gebruik te maken van de Index.  
3. Doorloop elke vorm op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt indien dat zo is.  
5. Controleer de SmartArt‑vorm met het gewenste LayoutType en voer daarna uit wat er moet gebeuren.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt)
        {
            // Cast de vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Controleer SmartArt lay-out
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

## **De stijl van een SmartArt‑vorm wijzigen**
In dit voorbeeld leren we hoe we de snelle stijl voor een SmartArt‑vorm kunnen wijzigen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie van de eerste dia door gebruik te maken van de Index.  
3. Doorloop elke vorm op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt indien dat zo is.  
5. Zoek de SmartArt‑vorm met de gewenste stijl.  
6. Stel de nieuwe stijl in voor de SmartArt‑vorm.  
7. Sla de presentatie op.

```java
// Instantieer Presentation-klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Haal eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Controleer SmartArt-stijl
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Wijzig SmartArt-stijl
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

## **De kleurstijl van een SmartArt‑vorm wijzigen**
In dit voorbeeld leren we hoe we de kleurstijl voor een SmartArt‑vorm kunnen wijzigen. In de volgende voorbeeldcode benaderen we de SmartArt‑vorm met een specifieke kleurstijl en wijzigen we die stijl.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie van de eerste dia door gebruik te maken van de Index.  
3. Doorloop elke vorm op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt indien dat zo is.  
5. Zoek de SmartArt‑vorm met de gewenste kleurstijl.  
6. Stel de nieuwe kleurstijl in voor de SmartArt‑vorm.  
7. Sla de presentatie op.

```java
// Instantieer Presentation-klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Haal eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Controleer SmartArt-kleurtype
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Wijzig SmartArt-kleurtype
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

Ja. SmartArt is een vorm, dus u kunt [standard animations](/slides/nl/java/powerpoint-animation/) via de animaties‑API (invoer, uitgang, nadruk, bewegingstrajecten) toepassen, net als bij andere vormen.

**Hoe kan ik een specifieke SmartArt op een dia vinden als ik de interne ID niet ken?**

Stel de Alternatieve Tekst (AltText) in en zoek de vorm op basis van die waarde — dit is een aanbevolen manier om de gewenste vorm te lokaliseren.

**Kan ik SmartArt groeperen met andere vormen?**

Ja. U kunt SmartArt groeperen met andere vormen (afbeeldingen, tabellen, enz.) en vervolgens de [manipulate the group](/slides/nl/java/group/) gebruiken.

**Hoe krijg ik een afbeelding van een specifieke SmartArt (bijvoorbeeld voor een preview of rapport)?**

Exporteer een miniatuur/afbeelding van de vorm; de bibliotheek kan [render individual shapes](/slides/nl/java/create-shape-thumbnails/) naar rasterbestanden (PNG/JPG/TIFF).

**Wordt het uiterlijk van SmartArt behouden bij het converteren van de volledige presentatie naar PDF?**

Ja. De render‑engine streeft naar hoge getrouwe weergave voor [PDF export](/slides/nl/java/convert-powerpoint-to-pdf/), met een reeks kwaliteits‑ en compatibiliteitsopties.