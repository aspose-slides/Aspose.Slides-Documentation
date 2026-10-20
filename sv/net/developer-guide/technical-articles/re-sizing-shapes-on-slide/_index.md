---
title: Ändra storlek på former på presentationsbilder i .NET
type: docs
weight: 130
url: /sv/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /sv/net/re-sizing-shapes-on-slide/
keywords:
- ändra storlek på form
- ändra formens storlek
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Enkel ändring av storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för .NET—automatisera justering av bildlayout och öka produktiviteten."
---
## **Översikt**

När du ändrar en presentations bildstorlek kan du också behöva ändra storlek och placering på dess former för att passa de nya måtten. Denna artikel visar hur man skalar former manuellt och hur man hanterar tabeller på bilder, masterbilder och layouter.

## **Ändra storlek på former**

För att bevara varje formes relativa position och storlek multiplicerar du dess horisontella koordinater och bredd med förhållandet mellan den nya bildens bredd och den ursprungliga bredden. Tillämpa motsvarande höjdförhållande på dess vertikala koordinater och höjd.

Det första exemplet laddar en presentation vars bilder inte innehåller tabeller, ändrar bildstorleken till A4 och sparar resultatet. Det använder [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) med [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) så att den efterföljande loopen styr skalningen. Förhållandena är enhetslösa; formernas positioner och dimensioner mäts i punkter. Olika bredd- och höjdförhållanden kan förvränga former, och att ändra en formas dimensioner skalar inte dess teckenstorlekar.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Beräkna oberoende horisontella och vertikala skalningsfaktorer.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Tabeller kräver separat hantering: skala deras kolumnbredder och radhöjder i stället för att tilldela tabellens totala bredd och höjd. Radhöjder kan förbli större än begärt om cellinnehållet kräver mer utrymme.
{{% /alert %}}

Det andra exemplet stödjer tabeller och behandlar former på masterbilder och layouter samt enskilda bilder innan den sparade, storleksändrade presentationen. Dess hjälpfunktion hanterar varje [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) genom att skala [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) och [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Den skalar sedan tabellens position utan att separerat skala dess totala dimensioner.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Beräkna oberoende horisontella och vertikala skalningsfaktorer.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Ändra storlek på former definierade på masterbilder och layouter samt enskilda bilder.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Tabelldimensioner styrs av kolumnbredder och radhöjder.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **Vanliga frågor**

**Varför blir former förvrängda eller avklippta efter att en bild har ändrats i storlek?**

Om du ändrar bildstorleken utan att skala formerna behåller de sina ursprungliga positioner och dimensioner och kan sträcka sig utanför bilden. Att skala bredd och höjd med olika förhållanden kan också förvränga former.

**Fungerar den medföljande koden för alla typer av former?**

Det första exemplet ändrar formernas gränser direkt och är avsett för bilder utan tabeller. Det andra exemplet hanterar tabeller separat. Kontrollera den resulterande layouten, särskilt text och tabeller, eftersom dessa exempel inte skalar teckenstorlekar och tabellinnehåll kan begränsa radhöjder.

**Hur ändrar jag storlek på tabeller när jag ändrar bildens storlek?**

Skala kolumnbredder med breddförhållandet och minsta radhöjder med höjdförhållandet, skala sedan tabellens position, som visas i det andra exemplet.

**Fungerar denna storleksändring för masterbilder och layoutbilder?**

Ja. Det andra exemplet itererar genom [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) och varje masters [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) och tillämpar samma storleksändringslogik på deras former.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) samtidigt som jag ändrar storlek?**

Ja. Ställ in [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) efter att du ändrat bildstorleken och innan du läser målmåtten, så att skalningsfaktorerna speglar den slutgiltiga orienteringen.

**Finns det någon gräns för vilken bildstorlek jag kan ange?**

Du kan ange anpassade bilddimensioner med [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). De stödda dimensionerna beror också på presentationsformatet och det program som används för att öppna filen.

**Hur kan jag förhindra att former med ett fast bildförhållande blir förvrängda?**

Använd samma skalningsfaktor för bredd och höjd. För att passa den ursprungliga layouten inom de nya bildmåtten, använd det mindre av bredd- och höjdförhållandena för både dimensioner och positioner. Detta bevarar proportionerna men kan lämna oanvänt utrymme längs en kant.