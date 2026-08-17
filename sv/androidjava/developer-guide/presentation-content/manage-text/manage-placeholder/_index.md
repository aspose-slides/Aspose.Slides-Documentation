---
title: Hantera presentationens platshållare på Android
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/androidjava/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- innehållsplatshållare
- prompttext
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du inspekterar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår ärvning av platshållare med Aspose.Slides för Android via Java."
---
## **Översikt**

En platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel, brödtext, bild, diagram och allmänna innehållsplatshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och andra inställningar från en layoutbild eller mastern.

Aspose.Slides exponerar information om platshållare via metoden [IShape.getPlaceholder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) . Metoden returnerar ett [IPlaceholder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholder/)‑objekt eller `null` för en normal form. Använd [IPlaceholder.getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholder/) för att avgöra vad platshållaren är avsedd att innehålla.

Formgränssnittet är fortfarande viktigt när du känner till platshållartypen:

- En tom text‑, bild‑, diagram‑ eller innehållsplatshållare representeras vanligtvis av en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) .
- En ifylld bildplatshållare kan representeras av en [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) .
- En ifylld diagramplatshållare kan representeras av en [IChart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/) .
- En innehållsplatshållare kan innehålla flera typer av innehåll. Kontrollera både [IPlaceholder.getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholder/) och runtime‑formgränssnittet istället för att anta att varje platshållare är en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) .

{{% alert color="warning" title="Varning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholder/) beskriver en platshållares roll; den garanterar inte formens runtime‑typ. Använd alltid en typkontroll innan du kommer åt text‑, bild‑, diagram‑, tabell‑ eller mediavarianta medlemmar.
{{% /alert %}}

## **Förstå ärvning av platshållare**

Platshållare bildar en hierarki:

1. En mastern bild definierar återanvändbara stilar och i vissa fall masternivåns platshållare.
2. En layout‑bild definierar den layout som används av en eller flera vanliga bilder och kan ärva från mastern.
3. En normal bild innehåller platshållarna för den bilden och kan ärva från sin layout.

Anropa [IShape.getBasePlaceholder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) för att gå ett nivå upp i hierarkin. En bildplatshållare returnerar normalt sin layout‑platshållare; en layout‑platshållare kan returnera sin master‑platshållare. Metoden returnerar `null` när formen saknar en bas‑platshållare.

Följande exempel listar platshållare på den första bilden och rapporterar deras bas‑platshållare:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Att redigera en platshållare på en normal bild skapar eller ändrar ett lokalt överskrifts‑värde för den bilden. Att redigera den relaterade layouten eller mastern kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen bas‑platshållare och börjar inte ärva bara för att den upptar samma koordinater.

## **Ändra text i en platshållare**

Titel‑, centrerad‑titel‑, undertitel‑, brödtext‑ och text‑platshållare stödjer normalt text. Kontrollera att det är en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) innan du använder dess [getTextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/)‑metod.

Detta exempel uppdaterar den första titel‑platshållaren på den första bilden och sparar resultatet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Detta mönster undviker att kasta bild‑, diagram‑, tabell‑ eller mediaplatshållare till [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) . Det identifierar också platshållaren efter dess syfte istället för att förlita sig på ett skört form‑index.

## **Ange prompttext på en layout**

Prompttext är den design‑tidsinstruktion som visas i en tom platshållare, till exempel *Klicka för att lägga till titel*. Ange anpassad prompttext på layout‑platshållaren istället för att försöka nå den via en normal bilds form‑samling. Åtkomst till layouten sker via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/) och iterera över samlingen som returneras av [ILayoutSlide.getShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/) .

Följande exempel ändrar titel‑ och undertitel‑promptarna på den layout som används av den första bilden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Prompttext är inte vanligt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram som PowerPoint. När en användare eller ett program tillhandahåller verkligt innehåll visas prompten inte längre. Att ändra en prompt ersätter inte heller befintlig text på bilder som använder layouten.

## **Uppdatera en bildplatshållare**

Det finns två fall att hantera:

- Om bild‑platshållaren redan är ifylld och representeras av en [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) , ersätt bilden via [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/) och [ISlidesPicture.setImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidespicture/) .
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/) och ta bort den tomma platshållaren.

Nästa exempel hanterar båda fallen och sparar presentationen:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ersättningen som skapas för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [IShape.getPlaceholder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) inte har en setter. Den behåller den reserverade positionen men ärver inte längre platshållarspecifikt beteende. Om det är viktigt att behålla platshållarrelationen, förbered och fyll i platshållaren i PowerPoint först, och uppdatera sedan den resulterande [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bildspecifika effekter, se [Manage Picture Frames](/slides/sv/androidjava/picture-frame/) . Dessa operationer gäller bildramen eller bildfyllning, inte platshållarmetadata.

## **Arbeta med diagram‑ och innehållsplatshållare**

En ifylld diagramplatshållare kan representeras av en [IChart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/) . Detta exempel hittar ett sådant diagram både via platshållartyp och runtime‑gränssnitt, ändrar dess titel och sparar filen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En allmän innehållsplatshållare har vanligtvis [PlaceholderType.Object](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholdertype/) . I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. Efter att den har fyllts i, inspektera det faktiska form‑gränssnittet för att ta reda på vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType.Chart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholdertype/) , [PlaceholderType.Table](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholdertype/) , [PlaceholderType.Picture](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholdertype/) , [PlaceholderType.Media](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholdertype/) eller [PlaceholderType.Diagram](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholdertype/) .

Aspose.Slides konverterar inte en tom [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/)‑platshållare till en [IChart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/) enbart genom att ändra [IPlaceholder.getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/placeholder/) ; typen kan inte ändras via gränssnittet. För att fylla ett tomt diagram‑ eller innehållsområde programmässigt, lägg till det erforderliga objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layout‑platshållaren. Använd de dedikerade [chart management articles](/slides/sv/androidjava/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsbok‑data.

## **Fullständigt exempel: Uppdatera text‑ eller bildinnehåll**

Följande helomfattande exempel öppnar en mall, söker på den första bilden efter antingen en titel‑ eller bildplatshållare, kontrollerar platshållar‑ och formtyper, uppdaterar lämpligt innehåll och sparar utdata. Exemplet undviker medvetet att anta ett form‑index eller att kasta varje platshållare till samma gränssnitt.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Vad är en bas‑platshållare?**

En bas‑platshållare är den motsvarande formen på layouten eller mastern som en annan platshållare ärver från. Använd [IShape.getBasePlaceholder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) för att hämta den. En vanlig lokal form returnerar `null` eftersom den inte är del av platshållar‑hierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layout‑platshållare?**

Du kan ändra ärvd formatering eller prompt‑text via en layout, men befintligt titelinnehåll lagras på de vanliga bilderna. För att ersätta den faktiska titeltexten i hela presentationen, iterera över bilderna och uppdatera varje titel‑platshållare.

**Hur hanterar jag datum‑, sidnummer‑, sidhuvud‑ och sidfot‑platshållare?**

Använd header‑ och footer‑hanterarna på lämplig bild, layout, master, anteckningar eller utdelnings‑omfång. Se [Manage Presentation Header and Footer](/slides/sv/androidjava/presentation-header-and-footer/) för kompletta exempel.