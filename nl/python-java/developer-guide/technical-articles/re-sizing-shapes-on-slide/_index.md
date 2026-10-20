---
title: Vormen schalen op presentatiedia's in Python via Java
type: docs
weight: 110
url: /nl/python-java/resizing-shapes-on-slide/
aliases:
  - /nl/python-java/re-sizing-shapes-on-slide/
  /python-java/re-sizing-shapes-on-slide/
keywords:
- vorm schalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Schakel eenvoudig vormen schalen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via Java—automatiseer dia-indelingsaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer u de dia‑grootte van een presentatie wijzigt, moet u mogelijk ook de vormen schalen en verplaatsen om ze aan te passen aan de nieuwe afmetingen. Dit artikel laat zien hoe u vormen handmatig schaalt en hoe u tabellen op dia's, masters en lay‑outs verwerkt.

## **Vormen schalen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldigt u de horizontale coördinaten en de breedte met de verhouding van de nieuwe dia‑breedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogteverhouding toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, wijzigt de dia‑grootte naar A4 en slaat het resultaat op. Het gebruikt [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) met [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) zodat de daaropvolgende lus de schaal regelt. De verhoudingen zijn dimensieloos; vormposities en afmetingen worden gemeten in punten. Verschillende breedte‑ en hoogteverhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

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

{{% alert color="info" title="Opmerking" %}}
Tabellen vereisen afzonderlijke behandeling: schaal de kolombreedtes en rijhoogtes in plaats van de algehele breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan gevraagd als de celinhoud meer ruimte nodig heeft.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay‑outs evenals op individuele dia's voordat de verkleinde presentatie wordt opgeslagen. De helper behandelt elke [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) door kolombreedtes te schalen met [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) en minimale rijhoogtes met [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Daarna schaalt hij de positie van de tabel zonder de algehele afmetingen afzonderlijk te schalen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # De afmetingen van de tabel worden beheerst door kolombreedtes en rijhoogtes.
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

    # Schaal vormen die gedefinieerd zijn op masters en lay‑outs evenals op individuele dia's.
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

## **FAQ**

**Waarom worden vormen vervormd of afgesneden na het wijzigen van een dia?**

Als u de dia‑grootte wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke posities en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan ook vormen vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de grenzen van de vorm rechtstreeks en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen afzonderlijk. Controleer de resulterende lay‑out, met name tekst en tabellen, omdat deze voorbeelden de lettergroottes niet schalen en de tabelinhoud de rijhoogtes kan beperken.

**Hoe schaalt u tabellen bij het wijzigen van een dia?**

Schaal de kolombreedtes met de breedte‑verhouding en de minimale rijhoogtes met de hoogte‑verhouding, en schaal vervolgens de positie van de tabel, zoals getoond in het tweede voorbeeld.

**Werkt deze herschaling voor masters en lay‑outdia's?**

Ja. Het tweede voorbeeld doorloopt [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) en voor elke master de [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) en past dezelfde herschalingslogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (portret/landschap) wijzigen samen met het verkleinen?**

Ja. Roep [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) aan nadat u de dia‑grootte hebt gewijzigd en vóór het lezen van de doelafmetingen, zodat de schaalfactoren de uiteindelijke oriëntatie weergeven.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

U kunt aangepaste dia‑afmetingen opgeven met [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). De ondersteunde afmetingen hangen ook af van het presentatieformaat en de toepassing die wordt gebruikt om het bestand te openen.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd raken?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay‑out te laten passen binnen de nieuwe dia‑afmetingen, gebruikt u de kleinste van de breedte‑ en hoogteverhoudingen voor beide dimensies en posities. Dit behoudt de verhoudingen, maar kan leiden tot ongebruikte ruimte langs één rand.