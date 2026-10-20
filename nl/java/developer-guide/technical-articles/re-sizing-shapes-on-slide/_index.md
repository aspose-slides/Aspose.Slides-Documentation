---
title: Vormen schalen op presentatiedia's in Java
type: docs
weight: 130
url: /nl/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /nl/java/re-sizing-shapes-on-slide/
keywords:
  - vorm formaat wijzigen
  - vormgrootte wijzigen
  - PowerPoint
  - OpenDocument
  - presentatie
  - Java
  - Aspose.Slides
description: "Eenvoudig vormen schalen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Java—automatiseer dia‑lay-outaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer je de diagrootte van een presentatie wijzigt, moet je mogelijk ook de vormen aanpassen en verplaatsen zodat ze passen binnen de nieuwe afmetingen. Dit artikel laat zien hoe je vormen handmatig kunt schalen en hoe je tabellen op dia's, masters en lay-outs kunt behandelen.

## **Vormen schalen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldig je de horizontale coördinaten en de breedte met de verhouding van de nieuwe diabreedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogtesverhouding toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, verandert de dia‑grootte naar A4 en slaat het resultaat op. Het gebruikt [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) met [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) zodat de daaropvolgende lus de schaal bepaalt. De verhoudingen zijn eenheidloos; positie‑ en afmetingswaarden van vormen worden gemeten in points. Verschillende breedte‑ en hoogtesverhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Bereken onafhankelijke horizontale en verticale schaalfactoren.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabellen vereisen een aparte behandeling: schaal hun kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan gevraagd als de celinhoud meer ruimte nodig heeft.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay-outs evenals individuele dia's vóór het opslaan van de aangepaste presentatie. De helper behandelt elke [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) door kolombreedtes te schalen met [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) en minimale rijhoogtes met [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Vervolgens wordt de positie van de tabel geschaald zonder de totale afmetingen apart te schalen.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Tabelafmetingen worden beheerd door kolombreedtes en rijhoogtes.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Bereken onafhankelijke horizontale en verticale schaalfactoren.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Schaal vormen die gedefinieerd zijn op masters en lay-outs, evenals op individuele dia's.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Waarom worden vormen vervormd of afgesneden na het aanpassen van een dia?**

Als je de dia‑grootte verandert zonder de vormen te schalen, behouden ze hun oorspronkelijke positie en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan vormen ook vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de vormgrenzen direct en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen apart. Controleer de resulterende lay-out, met name tekst en tabellen, omdat deze voorbeelden de lettergroottes niet schalen en tabelinhoud de rijhoogtes kan beperken.

**Hoe kan ik tabellen aanpassen wanneer ik een dia aanpas?**

Schaal kolombreedtes met de breedte‑verhouding en minimale rijhoogtes met de hoogte‑verhouding, en schaal vervolgens de positie van de tabel, zoals weergegeven in het tweede voorbeeld.

**Werkt deze aanpassing ook voor masterdia's en lay-outdia's?**

Ja. Het tweede voorbeeld doorloopt [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) en voor elke master de [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) en past dezelfde schaallogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (staand/liggend) aanpassen in combinatie met het schalen?**

Ja. Roep [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) aan nadat je de dia‑grootte hebt gewijzigd en vóór het uitlezen van de gewenste afmetingen, zodat de schaalfactoren de uiteindelijke oriëntatie weerspiegelen.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

Je kunt aangepaste dia‑afmetingen opgeven met [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). De ondersteunde afmetingen hangen ook af van het presentatie‑formaat en de toepassing die het bestand opent.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd raken?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay-out te laten passen binnen de nieuwe dia‑afmetingen, gebruik je de kleinste van de breedte‑ en hoogte‑verhoudingen voor zowel afmetingen als posities. Dit behoudt de proporties, maar kan leiden tot ongebruikte ruimte langs één rand.