---
title: Vormgrootte aanpassen op presentatiedia's op Android
type: docs
weight: 130
url: /nl/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
keywords:
- vorm vergroten
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Aspose.Slides
description: "Vergroot eenvoudig vormen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Android via Java—automatiseer dia‑lay‑outaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer u de afmeting van een presentatie‑dia wijzigt, moet u mogelijk ook de vormen herschalen en hun positie aanpassen zodat ze passen binnen de nieuwe afmetingen. Dit artikel laat zien hoe u vormen handmatig schaalt en hoe u tabellen op dia’s, masters en indelingen behandelt.

## **Vormgroottes aanpassen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldigt u de horizontale coördinaten en de breedte met de verhouding tussen de nieuwe dia‑breedte en de oorspronkelijke breedte. Pas de overeenkomstige hoogteligging toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia’s geen tabellen bevatten, wijzigt de dia‑grootte naar A4 en slaat het resultaat op. Het gebruikt [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) met [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) zodat de daaropvolgende lus de schaal regelt. De verhoudingen zijn zonder eenheid; vormposities en afmetingen worden gemeten in punten. Verschillende breedte‑ en hoogte‑verhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt niet de lettergroottes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Bereken onafhankelijke horizontale en verticale schaalfactoren.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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

Tabellen vereisen aparte behandeling: schaalt hun kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan gevraagd wanneer de celinhoud meer ruimte nodig heeft.

{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en indelingen evenals op individuele dia’s voordat de vergrote presentatie wordt opgeslagen. De helper behandelt elke [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) door kolombreedtes te schalen met [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) en minimale rijhoogtes met [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Vervolgens schaalt hij de positie van de tabel zonder de totale afmetingen apart te schalen.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // De afmetingen van de tabel worden bepaald door kolombreedtes en rijhoogtes.
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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Schaam vormen gedefinieerd op masters en lay-outs, evenals op individuele dia's.
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

Als u de dia‑grootte wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke posities en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan ook vormen vervormen.

**Werkt de meegeleverde code voor alle soorten vormen?**

Het eerste voorbeeld wijzigt de vormgrenzen direct en is bedoeld voor dia’s zonder tabellen. Het tweede voorbeeld behandelt tabellen apart. Controleer de resulterende lay‑out, met name tekst en tabellen, omdat deze voorbeelden de lettergroottes niet schalen en tabelinhoud de rijhoogtes kan beperken.

**Hoe schaalt ik tabellen bij het aanpassen van een dia?**

Schaal kolombreedtes met de breedte‑verhouding en minimale rijhoogtes met de hoogte‑verhouding, en schaalt vervolgens de positie van de tabel, zoals getoond in het tweede voorbeeld.

**Werkt dit herschalen ook voor master‑dia’s en layout‑dia’s?**

Ja. Het tweede voorbeeld doorloopt [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) en voor elke master de [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) en past dezelfde herschaal‑logica toe op hun vormen.

**Kan ik de oriëntatie van een dia (staand/liggend) wijzigen samen met het herschalen?**

Ja. Roep [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) aan nadat u de dia‑grootte heeft gewijzigd en vóór het lezen van de doelafmetingen, zodat de schaalfactoren de uiteindelijke oriëntatie weergeven.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

U kunt aangepaste dia‑afmetingen opgeven met [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). De ondersteunde afmetingen hangen ook af van het presentatie‑formaat en de applicatie die het bestand opent.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd raken?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke layout binnen de nieuwe dia‑afmetingen te passen, gebruikt u de kleinste van de breedte‑ en hoogte‑verhoudingen voor zowel afmetingen als posities. Dit behoudt de verhoudingen, maar kan leiden tot ongebruikte ruimte langs één rand.