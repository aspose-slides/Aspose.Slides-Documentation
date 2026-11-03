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
- innehållsplatshållare
- förslagstext
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du inspekterar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår platshållarvsförhållanden med Aspose.Slides för Android via Java."
---
## **Översikt**

En platshållare är en form som reserverar en plats för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel, brödtext, bild, diagram och allmänna innehålls‑platshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och övriga inställningar från en layout‑bild eller en huvud‑bild.

Aspose.Slides exponerar platshållarinformation via metoden [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) . Metoden returnerar ett [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/)‑objekt eller `null` för en normal form. Använd [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) för att bestämma vad platshållaren är avsedd att innehålla.

Form‑gränssnittet är fortfarande relevant efter att du känner till platshållartypen:

- En tom text‑, bild‑, diagram‑ eller innehålls‑platshållare representeras vanligtvis av en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
- En ifylld bild‑platshållare kan representeras av ett [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/).
- En ifylld diagram‑platshållare kan representeras av ett [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/).
- En innehålls‑platshållare kan innehålla flera typer av innehåll. Kontrollera både [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) och gränssnittet för den faktiska formen istället för att anta att varje platshållare är en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) beskriver en platshållares roll; den garanterar inte formens kör‑tids‑typ. Använd alltid en typkontroll innan du får åtkomst till text‑, bild‑, diagram‑, tabell‑ eller mediespecifika medlemmar.
{{% /alert %}}

## **Förstå platshållarvsförhållande**

Platshållare bildar en hierarki:

1. En huvud‑bild definierar återanvändbara stilar och, i vissa fall, huvud‑nivåns platshållare.
2. En layout‑bild definierar arrangemanget som används av en eller flera vanliga bilder och kan ärva från huvud‑bilden.
3. En vanlig bild innehåller platshållarna för den bilden och kan ärva från dess layout.

Anropa [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) för att gå ett nivå upp i denna hierarki. En bild‑platshållare returnerar normalt sin layout‑platshållare; en layout‑platshållare kan returnera sin huvud‑platshållare. Metoden returnerar `null` när formen saknar en bas‑platshållare.

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

Att redigera en platshållare på en vanlig bild skapar eller ändrar ett lokalt överskott för den bilden. Att redigera den relaterade layouten eller huvud‑bilden kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen bas‑platshållare och börjar inte ärva bara för att den har samma koordinater.

## **Ta bort platshållarstatus**

Vid anpassning av en mall, använd [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) för att behålla ett befintligt objekt som en vanlig form. Dess [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--)‑metod returnerar `null`, men formen förblir i bildens samling. I kontrast raderar [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) formen från den samlingen.

Följande exempel kräver `template.pptx` med minst en bild och en icke‑tom text‑platshållare på den första bilden. Använd en platshållare med formatering ärvd från dess layout eller huvud‑bild för att se effekten av att ta bort den relationen. Exemplet kontrollerar att samma form kvarstår, anropar metoden igen på den nu vanliga formen och sparar resultatet.

{{% alert color="warning" title="Warning" %}}
Att ta bort platshållarstatus bevarar inte automatiskt ärvda visuella inställningar. Exemplet nedan lämnar avsiktligt dessa inställningar oförändrade, så utdata kan se annorlunda ut. En form vars position och storlek är helt ärvda kan ha nollkoordinater och dimensioner efter anropet och bli osynlig även om den finns kvar i samlingen.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Att anropa metoden på en vanlig form har ingen effekt.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

För en matchande platshållare skriver alla tre kontroller ut `true`. Texten kvarstår, men ärvd position, storlek, rotation, typsnitt, styckejustering, marginaler för text‑ram, vertikal förankring, fyllnings‑ och linjeinställningar kan förändras när platshållarrelationen tas bort. Till exempel kan ärvd titel‑formatering fall tillbaka till vanlig text‑formatering. Se [Slide Layout](/slides/sv/androidjava/slide-layout/) för mer om layouter.

För att bevara den avsedda utseendet, fånga den lösta positionen, storleken och rotationen innan anropet, och kopiera de nödvändiga effektiva formateringsvärdena till separata variabler. Hämta dessa värden via [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), och [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--). Lita inte endast på de effektiva format‑objekten, eftersom deras text‑formateringsvärden kan förändras efter att relationen tagits bort. Applicera uttryckligen de fångade värdena på den vanliga formen efteråt, inklusive teckensnittsfamilj, storlek, stil, färg, styckeinställningar, text‑ram‑inställningar, fyllning och linje som används i din mall.

Arvda form‑geometrier kan också behöva tilldelas explicit via [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-). För en rektangulär text‑platshållare innebär detta att tilldela [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle); att bara återställa fyllning och linje kanske inte återställer den synliga rektangeln. Mallar med ytterligare effekter eller mer komplex formatering kräver att dessa inställningar hanteras också.

## **Ändra text i en platshållare**

Titel-, centrerad‑titel‑, undertitel‑, brödtext‑ och text‑platshållare stödjer normalt text. Kontrollera efter [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) innan du använder dess [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)‑metod.

Det här exemplet uppdaterar den första titel‑platshållaren på den första bilden och sparar resultatet:

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

Detta mönster undviker att kasta bild‑, diagram‑, tabell‑ eller medie‑platshållare till [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Det identifierar också platshållaren efter dess syfte istället för att förlita sig på ett bräckligt form‑index.

## **Ställ in förslagstext på en layout**

Förslagstext är den design‑tids‑instruktion som visas i en tom platshållare, till exempel *Klicka för att lägga till titel*. Ange anpassad förslagstext på layout‑platshållaren snarare än att försöka nå den via en vanlig bilds form‑samling. Åtkomst till layouten sker via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) och iterera över samlingen som returneras av [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/).

Följande exempel ändrar titel‑ och undertitel‑förslagstexterna på den layout som används av den första bilden:

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

Förslagstext är inte normalt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram som PowerPoint. När en användare eller ett program tillhandahåller verkligt innehåll visas förslaget inte längre. Att ändra ett förslag ersätter inte heller befintlig text på bilder som använder layouten.

## **Uppdatera en bild‑platshållare**

Det finns två fall att hantera:

- Om bild‑platshållaren redan är ifylld och representeras av ett [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), ersätt bilden via [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) och [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) och ta bort den tomma platshållaren.

Nästa exempel stöder båda fallen och sparar presentationen:

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

Ersättningen som skapas för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) inte har någon setter. Den behåller den reserverade positionen men ärver inte längre platshållarspecifik beteende. Om det är viktigt att behålla platshållarrelationen, förbered och fyll i platshållaren i PowerPoint först, uppdatera sedan den resulterande [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bild‑specifika effekter, se [Manage Picture Frames](/slides/sv/androidjava/picture-frame/). Dessa operationer tillhör bildramen eller bildfyllningen, inte platshållar‑metadata.

## **Arbeta med diagram‑ och innehålls‑platshållare**

En ifylld diagram‑platshållare kan representeras av ett [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/). Detta exempel hittar ett sådant diagram både via platshållartyp och kör‑gränssnitt, ändrar dess titel och sparar filen:

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

En generell innehålls‑platshållare har vanligtvis [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. Efter att den har fyllts i, inspektera det faktiska form‑gränssnittet för att ta reda på vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), eller [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides konverterar inte en tom [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)‑platshållare till ett [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) enbart genom att ändra [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); typen kan inte ändras via gränssnittet. För att fylla ett tomt diagram‑ eller innehållsområde programmässigt, lägg till det erforderliga objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

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

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layout‑platshållaren. Använd de dedikerade [chart management articles](/slides/sv/androidjava/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsboksdata.

## **Fullständigt exempel: Uppdatera text‑ eller bildinnehåll**

Följande helhets‑exempel öppnar en mall, söker den första bilden efter antingen en titel‑ eller bild‑platshållare, kontrollerar platshållar‑ och form‑typer, uppdaterar lämpligt innehåll, och sparar utdata. Exemplet undviker medvetet att anta ett form‑index eller kasta varje platshållare till samma gränssnitt.

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

En bas‑platshållare är den motsvarande formen på layouten eller huvud‑bilden som en annan platshållare ärver från. Använd [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) för att hämta den. En vanlig lokal form returnerar `null` eftersom den inte är en del av platshållar‑hierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layout‑platshållare?**

Du kan ändra ärvd formatering eller förslagstext via en layout, men befintligt titel‑innehåll lagras på de vanliga bilderna. För att ersätta faktisk titeltext i hela en presentation, iterera över bilderna och uppdatera varje titel‑platshållare.

**Hur hanterar jag datum‑, bild‑nummer‑, sidhuvud‑ och sidfot‑platshållare?**

Använd header‑ och footer‑hanterarna på rätt bild, layout, huvud‑bild, anteckningar eller utdelnings‑omfång. Se [Manage Presentation Header and Footer](/slides/sv/androidjava/presentation-header-and-footer/) för kompletta exempel.