---
title: Vormen schalen op presentatiedia's in Node.js
type: docs
weight: 130
url: /nl/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /nl/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- vorm schalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Schakel eenvoudig vormen op PowerPoint- en OpenDocument-dia's bij met Aspose.Slides voor Node.js via Java—automatiseer dia‑lay‑outaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer je de dia‑grootte van een presentatie verandert, moet je mogelijk ook de vormen verkleinen en opnieuw positioneren zodat ze passen binnen de nieuwe afmetingen. Dit artikel laat zien hoe je vormen handmatig kunt schalen en hoe je tabellen op dia's, masters en lay‑outs kunt behandelen.

## **Vormen schalen**

Om de relatieve positie en grootte van elke vorm te bewaren, vermenigvuldig je de horizontale coördinaten en de breedte met de verhouding van de nieuwe dia‑breedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogteligging toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, wijzigt de dia‑grootte naar A4 en slaat het resultaat op. Het gebruikt [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) met [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) zodat de daaropvolgende lus de schaal bepaalt. De verhoudingen zijn dimensieloos; positie‑ en afmetingen van vormen worden gemeten in punten. Verschillende breedte‑ en hoogte‑verhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Bereken onafhankelijke horizontale en verticale schaalfactoren.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Opmerking" %}}
Tabellen vereisen een aparte behandeling: schaal hun kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan gevraagd wanneer de celinhoud meer ruimte vereist.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay‑outs evenals individuele dia's voordat de verkleinde presentatie wordt opgeslagen. De helper behandelt elke [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) door kolombreedtes te schalen met [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) en minimale rijhoogtes met [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Vervolgens wordt de positie van de tabel geschaald zonder de totale afmetingen apart te schalen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Tabelafmetingen worden geregeld door kolombreedtes en rijhoogtes.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Bereken onafhankelijke horizontale en verticale schaalfactoren.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Vormen schalen die gedefinieerd zijn op masters en lay‑outs evenals individuele dia's.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Waarom worden vormen vervormd of afgekapt na het verkleinen van een dia?**

Als je de dia‑grootte wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke positie en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan vormen ook vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de grenzen van vormen direct en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen apart. Controleer de resulterende lay-out, met name tekst en tabellen, omdat deze voorbeelden geen lettergroottes schalen en de tabelinhoud de rijhoogtes kan beperken.

**Hoe verklein ik tabellen bij het aanpassen van de dia‑grootte?**

Schaal de kolombreedtes met de breedte‑ratio en de minimale rijhoogtes met de hoogte‑ratio, en schaal vervolgens de positie van de tabel, zoals getoond in het tweede voorbeeld.

**Werkt deze verkleining voor masterdia's en lay‑outdia's?**

Ja. Het tweede voorbeeld doorloopt [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) en voor elke master de [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) en past dezelfde verkleiningslogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (portret/landschap) veranderen samen met het verkleinen?**

Ja. Roep [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) aan na het wijzigen van de dia‑grootte en vóór het lezen van de doelafmetingen, zodat de schaalfactoren de uiteindelijke oriëntatie weerspiegelen.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

Je kunt aangepaste dia‑afmetingen opgeven met [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). De ondersteunde afmetingen hangen ook af van het presentatie‑formaat en de applicatie die wordt gebruikt om het bestand te openen.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd raken?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay-out in de nieuwe dia‑afmetingen te passen, gebruik je de kleinere van de breedte‑ en hoogte‑ratio voor zowel afmetingen als posities. Dit behoudt de verhoudingen, maar kan leiden tot ongebruikte ruimte langs één rand.