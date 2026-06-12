---
title: Vormen schalen op presentatiedia's
type: docs
weight: 110
url: /nl/java/re-sizing-shapes-on-slide/
keywords:
- vorm schalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Schaal eenvoudig vormen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Java - automatiseer dia-indelingaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Een van de meest voorkomende vragen van Aspose.Slides for Java‑klanten is hoe vormen te schalen zodat, wanneer de dia‑grootte verandert, de gegevens niet worden afgekapt. Dit korte technische artikel laat zien hoe u dat doet.

## **Vormen schalen**

Om te voorkomen dat vormen scheef komen te staan wanneer de dia‑grootte verandert, werkt u de positie en afmetingen van elke vorm bij zodat ze overeenkomen met de nieuwe dia‑indeling.

```java
// Laad het presentatiebestand.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Haal de oorspronkelijke dia‑grootte op.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Verander de dia‑grootte zonder bestaande vormen te schalen.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Haal de nieuwe dia‑grootte op.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Schaaf en verplaats vormen op elke dia.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Schaal de vormgrootte.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Schaal de vormpositie.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}} 
Als een dia een tabel bevat, werkt de bovenstaande code niet correct. In dat geval moet elke cel in de tabel worden geschaald.
{{% /alert %}} 

Gebruik de volgende code aan uw kant om dia's die tabellen bevatten te schalen. Voor tabellen is het instellen van de breedte of hoogte een speciaal geval: u moet de hoogte van individuele rijen en de breedte van individuele kolommen aanpassen om de totale afmeting van de tabel te wijzigen.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Haalt de oorspronkelijke dia-grootte op.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Verandert de dia-grootte zonder bestaande vormen te schalen.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Haalt de nieuwe dia-grootte op.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Schaal de vormgrootte.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Schaal de vormpositie.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Schaal de vormgrootte.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Schaal de vormpositie.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Schaal de vormgrootte.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Schaal de vormpositie.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Waarom raken vormen vervormd of worden ze afgekapt nadat een dia is geschaald?**  
Wanneer een dia wordt geschaald, behouden vormen hun oorspronkelijke positie en grootte, tenzij de schaal expliciet wordt aangepast. Dit kan ertoe leiden dat inhoud wordt bijgesneden of dat vormen scheef komen te staan.

**Werkt de meegeleverde code voor alle type vormen?**  
Het basisvoorbeeld werkt voor de meeste vormtypes (tekstvakken, afbeeldingen, grafieken, enz.). Voor tabellen moet u echter rijen en kolommen afzonderlijk behandelen, omdat de hoogte en breedte van een tabel worden bepaald door de afmetingen van individuele cellen.

**Hoe schaal ik tabellen bij het schalen van een dia?**  
U moet door alle rijen en kolommen van de tabel lopen en hun hoogte en breedte proportioneel aanpassen, zoals weergegeven in het tweede code‑voorbeeld.

**Werkt deze schaalaanpassing voor masterdia’s en lay-outdia’s?**  
Ja, maar u moet ook door de [masterdia’s](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getMasters--) en de [lay-outdia’s](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getLayoutSlides--) lopen en dezelfde schaallogica toepassen op hun vormen om consistentie in de volledige presentatie te waarborgen.

**Kan ik de oriëntatie van een dia (portret/landschap) wijzigen tegelijk met het schalen?**  
Ja. U kunt [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidesize/#setOrientation-int-) gebruiken om de oriëntatie te wijzigen. Zorg ervoor dat u de schaallogica dienovereenkomstig aanpast om de lay-out te behouden.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**  
Aspose.Slides ondersteunt aangepaste groottes, maar zeer grote afmetingen kunnen de prestaties of de compatibiliteit met sommige versies van PowerPoint beïnvloeden.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormen?**  
U kunt de `getAspectRatioLocked`‑methode van de vorm controleren voordat u schaalt. Als deze vergrendeld is, past u de breedte of hoogte proportioneel aan in plaats van ze afzonderlijk te schalen.