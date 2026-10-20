---
title: Vormen herschalen op presentatiedia's in Node.js
type: docs
weight: 130
url: /nl/nodejs-java/resizing-shapes-on-slide/
aliases:
  /nodejs-java/re-sizing-shapes-on-slide/
keywords:
- vorm herschalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Verklein gemakkelijk vormen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Node.js via Java—automatiseer aanpassingen van dia‑lay-outs en verhoog de productiviteit."
---
## **Overzicht**

Wanneer u de diaformaat van een presentatie wijzigt, moet u mogelijk ook de vormen aanpassen en opnieuw positioneren zodat ze passen binnen de nieuwe afmetingen. Dit artikel laat zien hoe u vormen handmatig schaalt en hoe u tabellen behandelt op dia's, masters en lay-outs.

## **Vormen herschalen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldigt u de horizontale coördinaten en de breedte met de verhouding van de nieuwe dia-breedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogteverhouding toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, wijzigt de dia-grootte naar A4 en slaat het resultaat op. Het gebruikt [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) met [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) zodat de daaropvolgende lus de schaal regelt. De verhoudingen zijn dimensieloos; de positie en afmetingen van vormen worden gemeten in punten. Verschillende breedte- en hoogteverhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

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

{{% alert color="info" title="Note" %}}
Tabellen vereisen afzonderlijke verwerking: schaal hun kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijkhoogtes kunnen groter blijven dan gevraagd als de celinhoud meer ruimte nodig heeft.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay-outs evenals individuele dia's vóór het opslaan van de herschaalde presentatie. De hulpfunctie verwerkt elke [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) door de kolombreedtes te schalen met [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) en de minimale rijhoogtes met [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Vervolgens schaalt het de positie van de tabel zonder de totale afmetingen apart te schalen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Tabelafmetingen worden beheerd door kolombreedtes en rijhoogtes.
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

    // Vormen herschalen die gedefinieerd zijn op masters en lay-outs, evenals individuele dia's.
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

## **FAQ**

**Waarom worden vormen vervormd of afgesneden na het wijzigen van de dia‑grootte?**

Als u de dia‑grootte wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke posities en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan ook vormen vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de grenzen van vormen direct en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen apart. Controleer de resulterende lay‑out, met name tekst en tabellen, omdat deze voorbeelden de lettergroottes niet schalen en de tabelinhoud de rijhoogtes kan beperken.

**Hoe schaalt ik tabellen bij het wijzigen van een dia?**

Schaal de kolombreedtes met de breedteverhouding en de minimale rijhoogtes met de hoogteverhouding, en schaal vervolgens de positie van de tabel, zoals getoond in het tweede voorbeeld.

**Werkt deze herschaling voor masterdia's en lay‑outdia's?**

Ja. Het tweede voorbeeld doorloopt [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) en de [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) van elke master en past dezelfde herschalingslogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (staand/liggend) samen met de herschaling wijzigen?**

Ja. Roep [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) aan na het wijzigen van de dia‑grootte en vóór het uitlezen van de doelafmetingen, zodat de schaalfactoren de uiteindelijke oriëntatie weerspiegelen.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

U kunt aangepaste dia‑afmetingen opgeven met [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). De ondersteunde afmetingen zijn ook afhankelijk van het presentatieformaat en de applicatie die wordt gebruikt om het bestand te openen.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd raken?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay‑out binnen de nieuwe dia‑afmetingen te laten passen, gebruikt u de kleinste van de breedte‑ en hoogteverhoudingen voor zowel afmetingen als posities. Dit behoudt de verhoudingen, maar kan onbenutte ruimte langs één rand achterlaten.