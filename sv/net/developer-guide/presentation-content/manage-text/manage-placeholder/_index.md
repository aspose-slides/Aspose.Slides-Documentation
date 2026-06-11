---
title: Hantera presentationsplatshållare i .NET
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/net/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- prompttext
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera enkelt platshållare i Aspose.Slides för .NET: ersätt text, anpassa prompts och ställ in bildgenomskinlighet i PowerPoint och OpenDocument."
---
## **Översikt**

Aspose.Slides låter dig hantera presentationsplatshållare programatiskt. Denna artikel förklarar hur du hittar platshållare på bilder, ändrar deras text, ställer in anpassade prompttexter för platshållarlayouter och justerar genomskinligheten för en bild som används som bakgrund för en platshållare. Den innehåller också en kort FAQ som klargör skillnaden mellan grundplatshållare och lokala former, förklarar hur ändringar av platshållare kan tillämpas via layouter eller masterbilder, och pekar på hantering av sidhuvud- och sidfotplatshållare.

## **Ändra text i en platshållare**
Med [Aspose.Slides for .NET](/slides/sv/net/) kan du hitta och ändra platshållare på bilder i presentationer. Aspose.Slides låter dig göra ändringar i texten i en platshållare.

**Förutsättning**: Du behöver en presentation som innehåller en platshållare. Du kan skapa en sådan presentation i standardprogrammet Microsoft PowerPoint.

Så här använder du Aspose.Slides för att ersätta texten i platshållaren i den presentationen:

1. Skapa en instans av klassen [`Presentation`](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) och skicka presentationen som argument.
2. Hämta en bildreferens via dess index.
3. Iterera genom formerna för att hitta platshållaren.
4. Typkonvertera platshållarformen till en [`AutoShape`](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) och ändra texten med hjälp av [`TextFrame`](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/) som är associerad med [`AutoShape`](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/). 
5. Spara den ändrade presentationen.

Denna C#-kod visar hur du ändrar texten i en platshållare:

```c#
// Skapar en instans av Presentation-klassen
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Hämtar den första bilden
    ISlide sld = pres.Slides[0];

    // Itererar genom former för att hitta platshållaren
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Ändrar texten i varje platshållare
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Sparar presentationen till disk
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Ange prompttext i en platshållare**
Standard- och förbyggda layouter innehåller prompttexter för platshållare såsom ***Click to add a title*** eller ***Click to add a subtitle***. Med Aspose.Slides kan du infoga dina önskade prompttexter i platshållarlayouter.

Denna C#-kod visar hur du anger prompttexten i en platshållare:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Itererar genom bilden
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint visar "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Lägger till bildtext
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Ställ in bildgenomskinlighet för platshållare**

Aspose.Slides låter dig ställa in genomskinligheten för bakgrundsbilden i en textplatshållare. Genom att justera bildens genomskinlighet i ett sådant ramverk kan du få texten eller bilden att sticka ut (beroende på textens och bildens färger).

Denna C#-kod visar hur du ställer in genomskinligheten för en bildbakgrund (inom en form):

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**Vad är en grundplatshållare och hur skiljer den sig från en lokal form på en bild?**

En grundplatshållare är den ursprungliga formen i en layout eller master som bildens form ärver från – typ, position och viss formatering kommer från den. En lokal form är oberoende; om det inte finns någon grundplatshållare gäller ingen arv.

**Hur kan jag uppdatera alla titlar eller bildtexter i en presentation utan att iterera över varje bild?**

Redigera den motsvarande platshållaren i layouten eller i mastern. Bilder som är baserade på dessa layouter/mastern kommer automatiskt att ärva ändringen.

**Hur styr jag de standardiserade sidhuvud-/sidfotplatshållarna – datum & tid, bildnummer och sidfotstext?**

Använd HeaderFooter‑hanterarna på rätt nivå (vanliga bilder, layouter, master, anteckningar/handouts) för att slå på eller av dessa platshållare och för att ange deras innehåll.