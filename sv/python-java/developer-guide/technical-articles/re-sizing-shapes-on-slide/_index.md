---
title: Ändra storlek på former på presentationsbilder i Python via Java
type: docs
weight: 110
url: /sv/python-java/re-sizing-shapes-on-slide/
keywords:
- ändra storlek på form
- ändra formens storlek
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Ändra enkelt storlek på former på PowerPoint- och OpenDocument-bilder med Aspose.Slides för Python via Java – automatisera justeringar av bildlayout och öka produktiviteten."
---
## **Översikt**

En av de vanligaste frågorna från Aspose.Slides för Python via Java‑kunder är hur man ändrar storlek på former så att, när bildstorleken ändras, data inte blir avklippt. Denna korta tekniska artikel visar hur man gör det.

## **Ändra storlek på former**

För att förhindra att former blir feljusterade när bildstorleken ändras, uppdatera varje forms position och dimensioner så att de anpassas till den nya bildlayouten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Ladda presentationsfilen.
presentation = Presentation("sample.ppt")
try:
    # Hämta den ursprungliga bildstorleken.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Ändra bildstorleken utan att skala befintliga former.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Hämta den nya bildstorleken.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Ändra storlek och position på former på varje bild.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Skala formens storlek.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Skala formens position.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Tabeller kräver ingen speciell behandling: att ange en tabs bredde och höjd skalar om dess kolumner och rader proportionellt, så att skala radhöjder och kolumnbredder igen skulle applicera förhållandet två gånger.

{{% /alert %}} 

Koden ovan ändrar endast formerna på bilderna. Masternbilder och layoutbilder behåller sina egna former, så skala även dem när du vill att hela presentationen ska följa den nya bildstorleken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Hämta den ursprungliga bildstorleken.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Ändra bildstorleken utan att skala befintliga former.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Hämta den nya bildstorleken.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Skala formens storlek.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Skala formens position.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Skala formens storlek.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Skala formens position.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Skala formens storlek.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Skala formens position.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Varför blir former förvrängda eller avklippta efter att en bild har ändrat storlek?**

När en bild ändras i storlek behåller formerna sin ursprungliga position och storlek om inte skalan ändras explicit. Detta kan leda till att innehåll blir beskuret eller att former blir feljusterade.

**Fungerar den medföljande koden för alla typer av former?**

Ja. Att ange höjd och bredd fungerar för textrutor, bilder, diagram och tabeller lika väl.

**Hur ändrar jag storlek på tabeller när jag ändrar storlek på en bild?**

Skala själva tabellformen, exakt som vilken annan form som helst. Dess rader och kolumner följer proportionellt, så skala dem inte igen efteråt.

**Kommer denna storleksändring att fungera för masternbilder och layoutbilder?**

Ja, men du bör också iterera genom [Presentation.getMasters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasters) och [Presentation.getLayoutSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getLayoutSlides) och tillämpa samma skalningslogik på deras former för att säkerställa konsekvens i hela presentationen.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) tillsammans med storleksändringen?**

Ja. Du kan använda [SlideSize.setOrientation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesize/#setOrientation) för att ändra orienteringen. Se till att du anpassar skalningslogiken därefter för att bevara layouten.

**Finns det någon gräns för vilken bildstorlek jag kan ange?**

Aspose.Slides stödjer anpassade storlekar, men mycket stora storlekar kan påverka prestanda eller kompatibilitet med vissa versioner av PowerPoint.

**Hur kan jag förhindra att former med fast bildförhållande blir förvrängda?**

Du kan kontrollera metoden [getAspectRatioLocked](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) för formens lås innan skalning. Om den är låst, justera bredd eller höjd proportionellt istället för att skala dem individuellt.