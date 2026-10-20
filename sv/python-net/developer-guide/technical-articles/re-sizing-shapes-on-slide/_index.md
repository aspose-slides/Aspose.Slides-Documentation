---
title: Ändra storlek på former på presentationsbilder i Python
type: docs
weight: 130
url: /sv/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /sv/python-net/re-sizing-shapes-on-slide/
keywords:
  - ändra storlek på form
  - ändra formens storlek
  - PowerPoint
  - OpenDocument
  - presentation
  - Python
  - Aspose.Slides
description: "Enkel ändring av storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Python via .NET—automatisera justering av bildlayout och öka produktiviteten."
---
## **Översikt**

När du ändrar en presentations bildstorlek kan du också behöva ändra storlek på och flytta dess former så att de passar de nya dimensionerna. Den här artikeln visar hur du skalar former manuellt och hur du hanterar tabeller på bilder, masterbilder och layouter.

## **Ändra storlek på former**

För att bevara varje formes relativa position och storlek multiplicerar du dess horisontella koordinater och bredd med förhållandet mellan den nya bildens bredd och den ursprungliga bredden. Tillämpa motsvarande höjdförhållande på dess vertikala koordinater och höjd.

Det första exemplet läser in en presentation vars bilder inte innehåller några tabeller, ändrar bildstorleken till A4 och sparar resultatet. Det använder [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) med [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) så att den efterföljande loopen styr skalningen. Förhållandena är enhetslösa; formernas positioner och dimensioner mäts i punkter. Olika bredd- och höjdförhållanden kan förvränga former, och att ändra en formes dimensioner skalar inte dess typsnittsstorlekar.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Beräkna oberoende horisontella och vertikala skalningsfaktorer.
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
Tabeller kräver separat hantering: skala deras kolumnbredder och radhöjder istället för att tilldela tabellens totala bredd och höjd. Radhöjder kan förbli större än begärt om cellinnehållet kräver mer utrymme.
{{% /alert %}}

Det andra exemplet stöder tabeller och bearbetar former på masterbilder och layouter samt individuella bilder innan den sparar den omskalade presentationen. Dess hjälpfunktion hanterar varje [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) genom att skala [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) och [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Den skalar sedan tabellens position utan att separat skala dess totala dimensioner.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Tabellens dimensioner styrs av kolumnbredder och radhöjder.
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
    # Beräkna oberoende horisontella och vertikala skalningsfaktorer.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Ändra storlek på former som definieras på masterbilder och layouter samt individuella bilder.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Varför blir former förvrängda eller avklippta efter att en bild har ändrats i storlek?**

Om du ändrar bildens storlek utan att skala formerna behåller de sina ursprungliga positioner och dimensioner och kan sträcka sig utanför bilden. Att skala bredd och höjd med olika förhållanden kan också förvränga former.

**Fungerar den medföljande koden för alla typer av former?**

Det första exemplet ändrar formernas gränser direkt och är avsett för bilder utan tabeller. Det andra exemplet hanterar tabeller separat. Kontrollera den resulterande layouten, särskilt text och tabeller, eftersom dessa exempel inte skalar typsnittsstorlekar och tabellens innehåll kan begränsa radhöjder.

**Hur ändrar jag storlek på tabeller när jag ändrar storlek på en bild?**

Skala kolumnbredder med breddförhållandet och minsta radhöjder med höjdförhållandet, skala sedan tabellens position, som visas i det andra exemplet.

**Kommer denna storleksändring att fungera för masterbilder och layoutbilder?**

Ja. Det andra exemplet itererar genom [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) och varje masters [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) och tillämpar samma storleksändringslogik på deras former.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) tillsammans med storleksändringen?**

Ja. Ställ in [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) efter att du har ändrat bildstorleken och innan du läser måldimensionerna, så att skalfaktorerna återspeglar den slutgiltiga orienteringen.

**Finns det en gräns för den bildstorlek jag kan ange?**

Du kan ange anpassade bilddimensioner med [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). De stödjade dimensionerna beror också på presentationsformatet och programmet som används för att öppna filen.

**Hur kan jag förhindra att former med ett fast bildförhållande blir förvrängda?**

Använd samma skalfaktor för bredd och höjd. För att anpassa den ursprungliga layouten till de nya bilddimensionerna, använd den mindre av bredd- och höjdförhållandena för både dimensioner och positioner. Detta bevarar proportionerna men kan lämna oanvänt utrymme längs en kant.