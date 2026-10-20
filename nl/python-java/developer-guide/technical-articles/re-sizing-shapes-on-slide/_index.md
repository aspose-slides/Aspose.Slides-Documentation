---
title: Vormen herschalen op presentatiedia's in Python via Java
type: docs
weight: 110
url: /nl/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/her-schaal-vormen-op-dia/
  - /nl/python-java/re-sizing-shapes-on-slide/
keywords:
- vorm herschalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Schakel eenvoudig vormen op PowerPoint- en OpenDocument-dia's bij met Aspose.Slides voor Python via Java—automatiseer dia‑lay-outaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer je de diaformaat van een presentatie wijzigt, moet je mogelijk ook de vormen herschalen en opnieuw positioneren zodat ze passen binnen de nieuwe afmetingen. Dit artikel laat zien hoe je vormen handmatig schaalt en hoe je tabellen op dia's, masters en lay-outs verwerkt.

## **Vormen herschalen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldig je de horizontale coördinaten en de breedte met de verhouding van de nieuwe dia-breedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogteverhouding toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, wijzigt het diaformaat naar A4 en slaat het resultaat op. Het gebruikt [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) met [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) zodat de daaropvolgende lus de schaling regelt. De verhoudingen zijn dimensieloos; de posities en afmetingen van vormen worden gemeten in points. Verschillende breedte- en hoogteverhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Bereken onafhankelijke horizontale en verticale schaalfactoren.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Tabellen vereisen aparte behandeling: schaals de kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan gevraagd als de celinhoud meer ruimte vereist.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay-outs evenals individuele dia's voordat de herschaalde presentatie wordt opgeslagen. De helper behandelt elke [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) door kolombreedtes te schalen met [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) en minimale rijhoogtes met [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Daarna schaalt het de positie van de tabel zonder de totale afmetingen apart te schalen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # De afmetingen van de tabel worden geregeld door kolombreedtes en rijhoogtes.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Bereken onafhankelijke horizontale en verticale schaalfactoren.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Schaald vormen die gedefinieerd zijn op masters en lay-outs, evenals op individuele dia's.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Waarom worden vormen vervormd of afgesneden na het herschalen van een dia?**

Als je het diaformaat wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke posities en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan ook vormen vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de vormgrenzen direct en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen apart. Controleer de resulterende lay-out, met name tekst en tabellen, omdat deze voorbeelden de lettergroottes niet schalen en de inhoud van tabellen de rijhoogtes kan beperken.

**Hoe schaalt ik tabellen bij het herschalen van een dia?**

Schaal kolombreedtes met de breedteverhouding en minimale rijhoogtes met de hoogteverhouding, en schaals daarna de positie van de tabel, zoals getoond in het tweede voorbeeld.

**Werkt deze herschaling voor masterslides en lay-outslides?**

Ja. Het tweede voorbeeld loopt door [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) en door elke master-[MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) en past dezelfde herschaal‑logica toe op hun vormen.

**Kan ik de oriëntatie van een dia (portret/landschap) wijzigen tegelijk met het herschalen?**

Ja. Roep [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) aan nadat je het diaformaat hebt gewijzigd en vóór het uitlezen van de doelafmetingen, zodat de schaalfactoren de uiteindelijke oriëntatie weergeven.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

Je kunt aangepaste dia‑afmetingen opgeven met [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). De ondersteunde afmetingen hangen ook af van het presentatie‑formaat en de applicatie die het bestand opent.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd worden?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay-out in de nieuwe dia‑afmetingen te passen, gebruik je de kleinste van de breedte‑ en hoogteverhoudingen voor beide dimensies en posities. Dit behoudt de verhoudingen, maar kan leiden tot ongebruikte ruimte langs één rand.