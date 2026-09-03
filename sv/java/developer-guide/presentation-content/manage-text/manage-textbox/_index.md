---
title: Hantera textrutor i presentationer med Java
linktitle: Hantera textruta
type: docs
weight: 20
url: /sv/java/manage-textbox/
keywords:
- textruta
- textram
- lägg till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägg till textkolumn
- lägg till hyperlänk
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa, identifiera, formatera och uppdatera textrutor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java."
---
## **Introduktion**

I Aspose.Slides för Java lagras bildtext i textramar som tillhör former. Gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) representerar den vanligaste textbärande formen och exponerar dess text via metoden [IAutoShape.getTextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#getTextFrame--) .

{{% alert color="info" title="Note" %}}

Varje autoform implementerar [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/), men inte varje form är en autoform eller stöder en textram. När du bearbetar en befintlig presentation, kontrollera att en form implementerar [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) innan du kommer åt dess text.

{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta, lägg till en autoform på en bild, lägg till text i dess textram och spara presentationen. Följande exempel skapar en rektangulär textruta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Koordinaterna och dimensionerna som skickas till [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) mäts i punkter. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) initierar textramen med den medföljande texten.

## **Kontrollera om en form är en textruta**

Använd metoden [IAutoShape.isTextBox](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#isTextBox--) för att avgöra om en autoform behandlas som en textruta. Detta är användbart när en presentation innehåller både textbärande och enbart grafiska autoformer.

![En textruta och en form](istextbox.png)

Följande exempel inspekterar varje autoform i en presentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

En nylagd autoform betraktas inte som en textruta förrän den innehåller icke‑tom text. Du kan leverera den texten via [IAutoShape.addTextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) eller [ITextFrame.setText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#setText-java.lang.String-). Att lägga till eller tilldela en tom sträng får [IAutoShape.isTextBox](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#isTextBox--) att returnera `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

De två första anropen skriver ut `true`; de två sista skriver ut `false`.

## **Hitta den form som äger en textram**

Generisk textbearbetningskod kan få en [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) utan att veta vilket presentationsobjekt som innehåller den. Använd den skrivskyddade metoden [ITextFrame.getParentShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#getParentShape--) för att navigera tillbaka till dess ägande [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/).

För en textram som ägs av en autoform eller en annan textbärande form, returnerar [ITextFrame.getParentShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#getParentShape--) ägaren och [ITextFrame.getParentCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#getParentCell--) returnerar `null`. Kontrollera det returnerade värdet innan du använder det. För att identifiera både form‑ och cellägare, inklusive former kopplade till SmartArt‑noder, se [Search and Replace Text](/slides/sv/java/search-and-replace-text/).

## **Lägg till kolumner i en textruta**

Metoden [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) delar textramen i kolumner, medan [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) anger avståndet mellan kolumner i punkter. Båda inställningarna tillhör [ITextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/) och kan ändras via textramen i en befintlig textruta. Text flödar om inom kolumnerna i samma form; den fortsätter inte i en annan form.

Följande exempel skapar en tre‑kolumners textruta med 10 punkters avstånd mellan kolumnerna, sparar presentationen och läser de lagrade inställningarna från utdatafilen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extrahera text från enskilda kolumner**

Använd [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#splitTextByColumns--) för att hämta texten som tilldelats varje visuell kolumn i en befintlig textram. Metoden returnerar en sträng för varje kolumn, i kolumnbaserad läsordning. En en‑kolumns textram ger en array med ett element, och en tom kolumn representeras av en tom sträng. Strängarna innehåller endast vanlig text; formatering på nivå med deltext bevaras inte.

Detta är användbart när du behöver:

- Extrahera text samtidigt som du bevarar dess kolumnbaserade läsordning.  
- Indexera eller jämföra innehållet i bilder med flera kolumner.  
- Exportera varje kolumn till en separat fil, databassfält eller annan destination.  
- Undersöka hur text distribueras efter att du ändrat kolumnantalet med [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), avståndet med [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), teckensnittet eller textramens storlek.

Metoden rapporterar den text som fördelats inom den aktuella [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/); den flyttar inte automatiskt text mellan separata former eller textrutor. Kolumndistribution kan bero på tillgängliga teckensnitt och andra layoutinställningar, så se till att de nödvändiga teckensnitten finns tillgängliga när konsekventa resultat är viktiga.

Följande exempel laddar en presentation, hittar den första autoformen med flera kolumner och en textram, läser dess konfigurerade kolumnantal och skriver texten från varje kolumn till en separat fil. Former som inte har en textram hoppas över.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Uppdatera text**

För att uppdatera text i hela presentationen, iterera genom bilderna och formerna, välj autoformer och redigera sedan deras textdelar. Att arbeta på deltextnivå låter dig ändra både text och teckenformatering.

Följande exempel ersätter varje förekomst av `years` med `months` i autoformens text och gör varje berörd del fetstil:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Denna traversal uppdaterar endast text i autoformer. Text som lagras i tabeller, diagram, SmartArt eller grupperade former kräver traversal av respektive objekts egna samlingar.

## **Lägg till en textruta med hyperlänk**

En hyperlänk kan tilldelas en specifik textdel, så att bara den texten fungerar som den klickbara länken. Använd [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) för att binda delen till en extern URL.

Följande exempel skapar länkad text och sparar den i en presentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en textplatshållare på en master‑ eller layout‑bild?**

En [platshållare](/slides/sv/java/manage-placeholder/) kan ärva sin position och formatering från en [master‑bild](https://reference.aspose.com/slides/sv/java/com.aspose.slides/masterslide/) eller en [layout‑bild](https://reference.aspose.com/slides/sv/java/com.aspose.slides/layoutslide/). En vanlig textruta är en självständig form på den bild där den skapades och får inte platshållarbeteende när layouten ändras.

**Hur kan jag ersätta text utan att ändra text i diagram, tabeller eller SmartArt?**

Begränsa traverseringen till former som implementerar [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/), som i Exempel för Uppdatera text. Diagram, tabeller och SmartArt lagrar text i sina egna objektsmodeller, så de ändras inte av den loopen.