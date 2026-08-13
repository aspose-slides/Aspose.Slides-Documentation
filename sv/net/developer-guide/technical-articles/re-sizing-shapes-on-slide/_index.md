---
title: Ändra storlek på former på presentationsbilder i .NET
type: docs
weight: 130
url: /sv/net/re-sizing-shapes-on-slide/
keywords:
- ändra storlek på form
- ändra formens storlek
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Enkelt ändra storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för .NET - automatisera justeringar av bildlayout och öka produktiviteten."
---
## **Översikt**

En av de vanligaste frågorna från Aspose.Slides för .NET‑kunder är hur man ändrar storlek på former så att datan inte kapas när bildstorleken ändras. Denna korta tekniska artikel visar hur man gör det.

## **Ändra storlek på former**

För att förhindra att former blir feljusterade när bildstorleken ändras, uppdatera varje forms position och dimensioner så att de anpassas till den nya bildlayouten.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Ladda presentationsfilen.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Hämta original bildstorlek.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Ändra bildstorleken utan att skala befintliga former.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Hämta den nya bildstorleken.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Ändra storlek och ompositionera former på varje bild.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Skala formens storlek.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Skala formens position.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Om en bild innehåller en tabell fungerar koden ovan inte korrekt. I så fall måste varje cell i tabellen ändras i storlek.
{{% /alert %}}

Använd följande kod på din sida för att ändra storlek på bilder som innehåller tabeller. För tabeller skalas de enskilda radhöjderna och kolumnbredderna istället för formens bredd och höjd — att tillämpa båda skulle skala tabellen två gånger och skjuta den ur bilden.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Hämta original bildstorlek.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Ändra bildstorleken utan att skala befintliga former.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Hämta den nya bildstorleken.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Skala formens storlek.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Skala formens position.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Skala formens storlek.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Skala formens position.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // Skala tabellens storlek via dess rader och kolumner.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // Skala formens storlek.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Skala formens position.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Varför blir former förvrängda eller avklippta efter att en bild har ändrats i storlek?

När en bild ändras i storlek behåller formerna sin ursprungliga position och storlek om inte skalningen ändras uttryckligt. Detta kan leda till att innehåll kapas eller att former blir feljusterade.

### Fungerar den medföljande koden för alla formtyper?

Det grundläggande exemplet fungerar för de flesta formtyper (textrutor, bilder, diagram osv.). För tabeller måste du dock hantera rader och kolumner separat, eftersom en tabells höjd och bredd bestäms av dimensionerna på de enskilda cellerna.

### Hur ändrar jag storlek på tabeller när en bild ändras i storlek?

Du måste iterera igenom alla rader och kolumner i tabellen och ändra deras höjd och bredd proportionellt, som visas i det andra kodexemplet.

### Kommer denna storleksändring att fungera för masterbilder och layoutbilder?

Ja, men du bör också iterera igenom [Masters](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/masters/) och [LayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/layoutslides/) och tillämpa samma skalningslogik på deras former för att säkerställa konsekvens i hela presentationen.

### Kan jag ändra orienteringen på en bild (porträtt/landskap) samtidigt som jag ändrar storlek?

Ja. Du kan sätta [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/sv/net/aspose.slides/islidesize/orientation/) för att ändra orienteringen. Se till att du anpassar skalningslogiken därefter för att bevara layouten.

### Finns det någon gräns för den bildstorlek jag kan ange?

Aspose.Slides stödjer anpassade storlekar, men mycket stora storlekar kan påverka prestanda eller kompatibilitet med vissa versioner av PowerPoint.

### Hur kan jag förhindra att former med fast bildförhållande blir förvrängda?

Du kan kontrollera egenskapen `AspectRatioLocked` för formen innan du skalar. Om den är låst, justera bredden eller höjden proportionellt istället för att skala dem individuellt.