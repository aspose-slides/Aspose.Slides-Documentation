---
title: Vormen schalen op presentatiedia's in Python
type: docs
weight: 130
url: /nl/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /nl/python-net/re-sizing-shapes-on-slide/
keywords:
  - vormen schalen
  - vormgrootte wijzigen
  - PowerPoint
  - OpenDocument
  - presentatie
  - Python
  - Aspose.Slides
description: "Schakel eenvoudig het schalen van vormen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via .NET—automatiseer dia‑lay‑outaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer u de dia‑afmeting van een presentatie wijzigt, moet u mogelijk ook de vormen aanpassen en hun positie wijzigen zodat ze passen binnen de nieuwe afmetingen. Dit artikel laat zien hoe u vormen handmatig schaalt en hoe u tabellen op dia's, masters en lay‑outs behandelt.

## **Vormen herschalen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldigt u de horizontale coördinaten en de breedte met de verhouding tussen de nieuwe dia‑breedte en de oorspronkelijke breedte. Pas de overeenkomstige hoogteverhouding toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, wijzigt de dia‑grootte naar A4 en slaat het resultaat op. Het gebruikt [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) met [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) zodat de daaropvolgende lus de schaal bepaalt. De verhoudingen zijn dimensieloos; vormposities en -afmetingen worden gemeten in punten. Verschillende breedte‑ en hoogte‑verhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Bereken onafhankelijke horizontale en verticale schaalfactoren.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Tabellen vereisen aparte verwerking: schaals hun kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan aangevraagd als de celinhoud meer ruimte nodig heeft.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay‑outs evenals individuele dia's voordat de vergrote presentatie wordt opgeslagen. De hulpfunctie behandelt elke [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) door [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) en [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) te schalen. Vervolgens schaalt het de positie van de tabel zonder de totale afmetingen afzonderlijk te schalen.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Tabelafmetingen worden gecontroleerd door kolombreedtes en rijhoogtes.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Bereken onafhankelijke horizontale en verticale schaalfactoren.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Schaal vormen die gedefinieerd zijn op masters en lay-outs evenals op individuele dia's.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Waarom worden vormen vervormd of afgesneden na het wijzigen van de dia‑grootte?**

Als u de dia‑grootte wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke posities en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan vormen eveneens vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de grenzen van vormen direct en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen apart. Controleer de resulterende lay‑out, vooral tekst en tabellen, aangezien deze voorbeelden de lettergroottes niet schalen en de inhoud van tabellen de rijhoogtes kan beperken.

**Hoe pas ik de grootte van tabellen aan bij het wijzigen van een dia?**

Schaal de kolombreedtes met de breedte‑verhouding en de minimale rijhoogtes met de hoogte‑verhouding, en schaal vervolgens de positie van de tabel, zoals getoond in het tweede voorbeeld.

**Werkt deze grootte‑aanpassing ook voor masterdia's en lay‑outdia's?**

Ja. Het tweede voorbeeld doorloopt [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) en voor elke master de [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) en past dezelfde grootte‑aanpassingslogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (staand/liggend) wijzigen samen met de grootte‑aanpassing?**

Ja. Stel [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) in nadat u de dia‑grootte hebt gewijzigd en vóór het lezen van de doeldimensies, zodat de schaalfactoren de uiteindelijke oriëntatie weerspiegelen.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

U kunt aangepaste dia‑afmetingen opgeven met [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). De ondersteunde afmetingen hangen ook af van het presentatie‑formaat en de toepassing die het bestand opent.

**Hoe kan ik voorkomen dat vormen met een vaste aspectverhouding vervormd raken?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay‑out binnen de nieuwe dia‑afmetingen te passen, gebruikt u de kleinste van de breedte‑ en hoogte‑verhoudingen voor beide dimensies en posities. Dit behoudt de verhoudingen, maar kan ongebruikte ruimte langs één rand achterlaten.