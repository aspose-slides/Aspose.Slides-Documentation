---
title: Hantera presentationsplatshållare på Android
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/androidjava/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- prompttext
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera enkelt platshållare i Aspose.Slides för Android via Java: ersätt text, anpassa prompttexter och ställ in bildgenomskinlighet i PowerPoint och OpenDocument."
---
## **Overview**

Aspose.Slides låter dig hantera platshållare i presentationer programmässigt. Den här artikeln förklarar hur du hittar platshållare på bilder och ändrar deras text, anger anpassad prompttext för platshållarlayouter samt justerar genomskinligheten för en bild som används som bakgrund för en platshållare. Den innehåller också en kort FAQ som klargör skillnaden mellan grundläggande platshållare och lokala former, förklarar hur ändringar av platshållare kan tillämpas via layouter eller masterbilder och pekar på hantering av huvud‑ och sidfotplatshållare.

## **Change Text in a Placeholder**
Med [Aspose.Slides for Android via Java](/slides/sv/androidjava/) kan du hitta och ändra platshållare på bilder i presentationer. Aspose.Slides låter dig göra ändringar i texten i en platshållare.

**Prerequisite**: Du behöver en presentation som innehåller en platshållare. Du kan skapa en sådan presentation i den vanliga Microsoft PowerPoint‑appen.

Så här använder du Aspose.Slides för att ersätta texten i platshållaren i den presentationen:

1. Skapa en instans av klassen [`Presentation`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) och skicka presentationen som argument.
2. Hämta en bildreferens via dess index.
3. Iterera genom formerna för att hitta platshållaren.
4. Typkonvertera platshållarformen till en [`AutoShape`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AutoShape) och ändra texten med hjälp av [`TextFrame`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrame) som är associerad med [`AutoShape`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AutoShape).
5. Spara den ändrade presentationen.

Denna Java‑kod visar hur du ändrar texten i en platshållare:

```java
// Skapar en Presentation‑klass
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Itererar genom former för att hitta platshållaren
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Ändrar texten i varje platshållare
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Sparar presentationen till disk
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Prompt Text in a Placeholder**
Standard‑ och färdigbyggda layouter innehåller prompttexter för platshållare såsom ***Click to add a title*** eller ***Click to add a subtitle***. Med Aspose.Slides kan du infoga dina föredragna prompttexter i platshållarlayouter.

Denna Java‑kod visar hur du anger prompttext i en platshållare:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Itererar genom bilden
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint visar "Click to add title" 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Lägger till undertext
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Placeholder Image Transparency**

Aspose.Slides låter dig ställa in genomskinligheten för bakgrundsbilden i en textplatshållare. Genom att justera genomskinligheten för bilden i en sådan ram kan du få texten eller bilden att sticka ut (beroende på textens och bildens färger).

Denna Java‑kod visar hur du ställer in genomskinligheten för en bildbakgrund (inuti en form):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Vad är en grundläggande platshållare, och hur skiljer den sig från en lokal form på en bild?**

En grundläggande platshållare är den ursprungliga formen på en layout eller master som bildens form ärver från — typ, position och viss formatering kommer från den. En lokal form är oberoende; om det inte finns någon grundläggande platshållare gäller ingen arv.

**Hur kan jag uppdatera alla rubriker eller bildtexter i en presentation utan att iterera över varje bild?**

Redigera den motsvarande platshållaren på layouten eller masterbilden. Bilder som baseras på dessa layouter/master kommer automatiskt att ärva förändringen.

**Hur kontrollerar jag de standardiserade huvud‑-/sidfotplatshållarna — datum och tid, bildnummer och sidfotstext?**

Använd HeaderFooter‑hanterarna i lämplig omfattning (vanliga bilder, layouter, master, anteckningar/handouts) för att slå på eller av dessa platshållare och för att ange deras innehåll.