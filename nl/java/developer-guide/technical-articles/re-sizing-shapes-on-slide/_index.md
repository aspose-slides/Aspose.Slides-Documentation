---
title: Vormen aanpassen op presentatiedia's
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
description: "Pas eenvoudig vormen aan op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Java - automatiseer dia-indelingsaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Een van de meest voorkomende vragen van Aspose.Slides for Java‑klanten is hoe je vormen kunt aanpassen zodat, wanneer het diaformaat verandert, de gegevens niet worden afgesneden. Dit korte technische artikel laat zien hoe je dat doet.

## **Vormen aanpassen**

Om te voorkomen dat vormen scheef gaan staan wanneer het diaformaat verandert, werk je de positie en afmetingen van elke vorm bij zodat ze passen bij de nieuwe dia‑indeling.

```java
import com.aspose.slides.*;

// Laad het presentatiebestand.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Haal de oorspronkelijke dia-grootte op.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Wijzig de dia-grootte zonder bestaande vormen te schalen.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Haal de nieuwe dia-grootte op.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Pas de grootte aan en verplaats vormen op elke dia.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Schaam de vormgrootte.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Schaam de vormpositie.
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

{{% alert color="info" %}} 

Tabellen hebben geen speciale behandeling nodig: het instellen van de breedte en hoogte van een tabel schaalt de kolommen en rijen evenredig, dus het nogmaals schalen van de rijhoogtes en kolombreedtes zou de verhouding tweemaal toepassen.

{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Haal de oorspronkelijke dia-grootte op.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Wijzig de dia-grootte zonder bestaande vormen te schalen.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Haal de nieuwe dia-grootte op.
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
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

### Waarom zijn vormen vervormd of afgesneden na het aanpassen van een dia?

Bij het aanpassen van een dia behouden vormen hun oorspronkelijke positie en grootte, tenzij de schaal expliciet wordt gewijzigd. Dit kan er toe leiden dat inhoud wordt bijgesneden of vormen scheef staan.

### Werkt de meegeleverde code voor alle type vormen?

Ja. Het instellen van de hoogte en breedte werkt zowel voor tekstvakken, afbeeldingen, diagrammen als tabellen.

### Hoe schaalt ik tabellen bij het aanpassen van een dia?

Schaal de tabelvorm zelf, precies zoals elke andere vorm. De rijen en kolommen volgen evenredig, dus schaal ze daarna niet opnieuw.

### Werkt deze aanpassing ook voor masterdia’s en lay‑outdia’s?

Ja, maar je moet ook door de [Masters](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getMasters--) en [Layout slides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getLayoutSlides--) itereren en dezelfde schaallogica op hun vormen toepassen om consistentie door de presentatie te garanderen.

### Kan ik de oriëntatie van een dia (portret/landschap) wijzigen samen met het aanpassen van de grootte?

Ja. Je kunt [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidesize/#setOrientation-int-) gebruiken om de oriëntatie te wijzigen. Zorg ervoor dat je de schaallogica dienovereenkomstig aanpast om de lay‑out te behouden.

### Is er een limiet aan de diagrootte die ik kan instellen?

Aspose.Slides ondersteunt aangepaste formaten, maar zeer grote formaten kunnen de prestaties of de compatibiliteit met bepaalde versies van PowerPoint beïnvloeden.

### Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormen?

Je kunt de `getAspectRatioLocked`-methode van de vorm controleren vóór het schalen. Als deze vergrendeld is, pas je de breedte of hoogte evenredig aan in plaats van ze afzonderlijk te schalen.