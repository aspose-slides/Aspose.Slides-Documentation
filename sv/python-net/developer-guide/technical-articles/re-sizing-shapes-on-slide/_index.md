---
title: Ändra storlek på former i presentationer med Python
linktitle: Ändra storlek på former
type: docs
weight: 130
url: /sv/python-net/re-sizing-shapes-on-slide/
keywords:
- ändra formstorlek
- ändra formens storlek
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Enkelt ändra storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Python via .NET—automatisera justering av bildlayout och öka produktiviteten."
---
## **Översikt**

En av de vanligaste frågorna från Aspose.Slides för Python‑kunder är hur man ändrar storlek på former så att, när bildstorleken ändras, data inte blir avklippta. Den här korta tekniska artikeln visar hur man gör det.

## **Ändra storlek på former**

För att förhindra att former blir feljusterade när bildstorleken ändras, uppdatera varje forms position och dimension så att de anpassas till den nya bildlayouten.

```py
import aspose.slides as slides

# Läs in presentationsfilen.
with slides.Presentation("sample.pptx") as presentation:
    # Hämta den ursprungliga bildstorleken.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Ändra bildstorleken utan att skala befintliga former.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Hämta den nya bildstorleken.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Ändra storlek och position på former på varje bild.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Skala formens storlek.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Skala formens position.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Om en bild innehåller en tabell fungerar koden ovan inte korrekt. I så fall måste varje cell i tabellen ändras i storlek.
{{% /alert %}} 

Använd följande kod på din sida för att ändra storlek på bilder som innehåller tabeller. För tabeller är inställning av bredd eller höjd ett specialfall: du måste justera enskilda radhöjder och kolumnbredder för att ändra tabellens totala storlek.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Hämta den ursprungliga bildstorleken.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Ändra bildstorleken utan att skala befintliga former.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Hämta den nya bildstorleken.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Skala formens storlek.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Skala formens position.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Skala formens storlek.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Skala formens position.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Skala formens storlek.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Skala formens position.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Varför blir former förvrängda eller avklippta efter att en bild har ändrats i storlek?**

När en bild ändras i storlek behåller formerna sin ursprungliga position och storlek om inte skalningen explicit ändras. Detta kan leda till att innehåll beskärs eller att former blir feljusterade.

**Fungerar den medföljande koden för alla formtyper?**

Det grundläggande exemplet fungerar för de flesta formtyper (textrutor, bilder, diagram osv.). För tabeller måste du dock hantera rader och kolumner separat, eftersom en tabells höjd och bredd bestäms av dimensionerna på enskilda celler.

**Hur ändrar jag storlek på tabeller när jag ändrar storlek på en bild?**

Du måste loopa igenom alla rader och kolumner i tabellen och ändra deras höjd och bredd proportionellt, som visas i det andra kodexemplet.

**Kommer denna storleksändring att fungera för master‑bilder och layout‑bilder?**

Ja, men du bör också loopa igenom [Masters](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/masters/) och [Layout slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/layout_slides/) och tillämpa samma skalningslogik på deras former för att säkerställa konsekvens i hela presentationen.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) samtidigt som jag ändrar storlek?**

Ja. Du kan använda [presentation.slide_size.orientation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/islidesize/orientation/) för att ändra orienteringen. Se till att du anpassar skalningslogiken därefter för att bevara layouten.

**Finns det någon begränsning för den bildstorlek jag kan ange?**

Aspose.Slides stöder anpassade storlekar, men mycket stora storlekar kan påverka prestanda eller kompatibilitet med vissa versioner av PowerPoint.

**Hur kan jag förhindra att former med fast bildförhållande blir förvrängda?**

Du kan kontrollera egenskapen `aspect_ratio_locked` för formen innan du skalar. Om den är låst, justera bredd eller höjd proportionellt istället för att skala dem individuellt.