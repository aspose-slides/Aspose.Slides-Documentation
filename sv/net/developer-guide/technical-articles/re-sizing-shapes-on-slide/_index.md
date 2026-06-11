---
title: Ändra storlek på former i presentationsbilder i .NET
type: docs
weight: 130
url: /sv/net/re-sizing-shapes-on-slide/
keywords:
- ändra formstorlek
- ändra formens storlek
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Enkelt ändra storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för .NET—automatisera justeringar av bildlayout och öka produktiviteten."
---
## **Översikt**

En av de vanligaste frågorna från Aspose.Slides för .NET-kunder är hur man ändrar storlek på former så att data inte klipps av när bildens storlek ändras. Denna korta tekniska artikel visar hur man gör det.

## **Ändra storlek på former**

För att förhindra att former blir felplacerade när bildens storlek ändras, uppdatera varje formas position och dimension så att de följer den nya bildlayouten.

```c#
// Ladda presentationsfilen.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Hämta den ursprungliga bildstorleken.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Ändra bildstorleken utan att skala befintliga former.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Hämta den nya bildstorleken.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Ändra storlek och position på former på varje bild.
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

{{% alert color="primary" %}}
Om en bild innehåller en tabell fungerar koden ovan inte korrekt. I så fall måste varje cell i tabellen ändras i storlek.
{{% /alert %}}

Använd följande kod på din sida för att ändra storlek på bilder som innehåller tabeller. För tabeller är inställning av bredd eller höjd ett specialfall: du måste justera enskilda radhöjder och kolumnbredder för att ändra tabellens totala storlek.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Hämta den ursprungliga bildstorleken.
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
            // Skala formens storlek.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Skala formens position.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Varför blir former förvrängda eller avkapade efter att en bild har ändrats i storlek?**

När du ändrar storlek på en bild behåller former sina ursprungliga position och storlek om inte skalan ändras explicit. Detta kan leda till att innehåll beskärs eller att former blir felplacerade.

**Fungerar den medföljande koden för alla formtyper?**

Det grundläggande exemplet fungerar för de flesta formtyper (textrutor, bilder, diagram osv.). För tabeller måste du dock hantera rader och kolumner separat, eftersom höjden och bredden på en tabell bestäms av dimensionerna på enskilda celler.

**Hur ändrar jag storlek på tabeller när jag ändrar storlek på en bild?**

Du måste loopa igenom alla rader och kolumner i tabellen och ändra deras höjd och bredd proportionellt, enligt det andra kodexemplet.

**Fungerar denna storleksändring för masterbilder och layoutbilder?**

Ja, men du bör också loopa igenom [Masters](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/masters/) och [LayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/layoutslides/) och tillämpa samma skalningslogik på deras former för att säkerställa konsistens i hela presentationen.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) samtidigt som jag ändrar storlek?**

Ja. Du kan sätta [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/sv/net/aspose.slides/islidesize/orientation/) för att ändra orienteringen. Se till att du anpassar skalningslogiken därefter för att bevara layouten.

**Finns det någon begränsning för den bildstorlek jag kan ange?**

Aspose.Slides stöder anpassade storlekar, men mycket stora storlekar kan påverka prestanda eller kompatibilitet med vissa versioner av PowerPoint.

**Hur kan jag förhindra att former med fast bildförhållande blir förvrängda?**

Du kan kontrollera egenskapen `AspectRatioLocked` för formen innan du skalar. Om den är låst, justera bredd eller höjd proportionellt i stället för att skala dem individuellt.