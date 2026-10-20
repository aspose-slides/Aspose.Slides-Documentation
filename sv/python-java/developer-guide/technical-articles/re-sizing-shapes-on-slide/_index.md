---
title: Ändra storlek på former i presentationsbilder i Python via Java
type: docs
weight: 110
url: /sv/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/omstorla-former-paa-bild/
  - /sv/python-java/re-sizing-shapes-on-slide/
keywords:
- ändra storlek på form
- ändra formstorlek
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lätt att ändra storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Python via Java—automatisera layoutjusteringar av bilder och öka produktiviteten."
---
## **Översikt**

När du ändrar en presentations bildstorlek kan du också behöva ändra storlek på och flytta dess former så att de passar de nya dimensionerna. Den här artikeln visar hur man skalar former manuellt och hur man hanterar tabeller på bilder, master‑bilder och layout‑bilder.

## **Ändra storlek på former**

För att bevara varjeformes relativa position och storlek multiplicerar du dess horisontella koordinater och bredd med förhållandet mellan den nya bildbredden och den ursprungliga bredden. Applicera motsvarande höjdförhållande på dess vertikala koordinater och höjd.

Det första exemplet laddar en presentation vars bilder inte innehåller några tabeller, ändrar bildstorleken till A4 och sparar resultatet. Det använder [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) med [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) så att den efterföljande loopen styr skalningen. Förhållandena är enhetslösa; formernas positioner och dimensioner mäts i punkter. Olika bredd‑ och höjdförhållanden kan förvränga former, och att ändra en forms dimensioner skalar inte dess teckenstorlek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Beräkna oberoende horisontella och vertikala skalningsfaktorer.
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

{{% alert color="info" title="Obs" %}}
Tabeller kräver separat hantering: skala deras kolumnbredder och radhöjder istället för att tilldela tabellens totala bredd och höjd. Radhöjder kan förbli större än begärt om cellinnehållet kräver mer utrymme.
{{% /alert %}}

Det andra exemplet stöder tabeller och behandlar former på master‑bilder och layout‑bilder samt enskilda bilder innan den sparade, omdimensionerade presentationen. Dess hjälpfunktion hanterar varje [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) genom att skala kolumnbredder med [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) och minimala radhöjder med [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Den skalar sedan tabellens position utan att separat skala dess totala dimensioner.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Tabellens dimensioner styrs av kolumnbredder och radhöjder.
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
    # Beräkna oberoende horisontella och vertikala skalningsfaktorer.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Ändra storlek på former som definierats på master‑bilder och layouter samt enskilda bilder.
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

## **Vanliga frågor**

**Varför blir former förvrängda eller avklippta efter att en bild har ändrats i storlek?**

Om du ändrar bildens storlek utan att skala formerna behåller de sina ursprungliga positioner och dimensioner och kan sträcka sig utanför bilden. Att skala bredd och höjd med olika förhållanden kan också förvränga former.

**Fungerar den medföljande koden för alla typer av former?**

Det första exemplet ändrar formens gränser direkt och är avsett för bilder utan tabeller. Det andra exemplet hanterar tabeller separat. Kontrollera den resulterande layouten, särskilt text och tabeller, eftersom dessa exempel inte skalar teckenstorlekar och tabellinnehåll kan begränsa radhöjder.

**Hur ändrar jag storlek på tabeller när jag ändrar en bilds storlek?**

Skala kolumnbredder med breddförhållandet och minimala radhöjder med höjdförhållandet, skala sedan tabellens position, som visas i det andra exemplet.

**Fungerar denna omdimensionering för master‑bilder och layout‑bilder?**

Ja. Det andra exemplet itererar genom [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) och varje masters [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) och tillämpar samma omdimensioneringslogik på deras former.

**Kan jag ändra orienteringen på en bild (stående/liggande) samtidigt som jag ändrar storlek?**

Ja. Anropa [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) efter att du ändrat bildstorleken och innan du läser mål‑dimensionerna, så att skalningsfaktorerna återspeglar den slutgiltiga orienteringen.

**Finns det en gräns för vilken bildstorlek jag kan ange?**

Du kan ange anpassade bilddimensioner med [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). De stödda dimensionerna beror också på presentationsformatet och den applikation som används för att öppna filen.

**Hur kan jag förhindra att former med fast bildförhållande blir förvrängda?**

Använd samma skalningsfaktor för bredd och höjd. För att få den ursprungliga layouten att passa inom de nya bilddimensionerna, använd den mindre av bredd‑ och höjdförhållandena för både dimensioner och positioner. Detta bevarar proportionerna men kan lämna oanvänt utrymme längs en kant.