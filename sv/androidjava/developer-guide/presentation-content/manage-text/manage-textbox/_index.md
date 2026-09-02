---
title: "Hantera textrutor i presentationer på Android"
linktitle: "Hantera textruta"
type: docs
weight: 20
url: /sv/androidjava/manage-textbox/
keywords:
- textruta
- textram
- lägga till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägga till textkolumn
- lägga till hyperlänk
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides för Android via Java gör det enkelt att skapa, redigera och duplicera textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomatisering."
---
## **Introduktion**

Texter på bilder finns vanligtvis i textrutor eller former. Därför måste du, för att lägga till text på en bild, lägga till en textruta och sedan placera text i textrutan. Aspose.Slides för Android via Java tillhandahåller [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape)-gränssnittet som låter dig lägga till en form som innehåller text.

{{% alert title="Info" color="info" %}}
Aspose.Slides tillhandahåller även [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape)-gränssnittet som låter dig lägga till former på bilder. Dock kan inte alla former som läggs till via `IShape`‑gränssnittet innehålla text. Former som läggs till via [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape)-gränssnittet kan däremot innehålla text.
{{% /alert %}}

{{% alert title="Obs" color="warning" %}}
Därför, när du arbetar med en form som du vill lägga till text i, bör du kontrollera och bekräfta att den har kastats till `IAutoShape`‑gränssnittet. Endast då kan du arbeta med [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrame), en egenskap under `IAutoShape`. Se avsnittet [Update Text](https://docs.aspose.com/slides/sv/androidjava/manage-textbox/#update-text) på den här sidan.
{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta på en bild, följ dessa steg:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-klassen.  
2. Hämta en referens till den första bilden i den nyskapade presentationen.  
3. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape)-objekt med [ShapeType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) satt till `Rectangle` på en specificerad position på bilden och hämta referensen till det nyss tillagda `IAutoShape`‑objektet.  
4. Lägg till en `TextFrame`‑egenskap på `IAutoShape`‑objektet som kommer att innehålla text. I exemplet nedan lade vi till följande text: *Aspose TextBox*  
5. Skriv slutligen PPTX‑filen via `Presentation`‑objektet.  

Den här Java‑koden—en implementering av stegen ovan—visar hur du lägger till text på en bild:

```java
import com.aspose.slides.*;

// Instansierar Presentation
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägger till en AutoShape med typ satt till Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Lägger till TextFrame till rektangeln
    ashp.addTextFrame(" ");

    // Åtkomst till textramen
    ITextFrame txtFrame = ashp.getTextFrame();

    // Skapar Paragraph-objektet för textramen
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Skapar ett Portion-objekt för paragrafen
    IPortion portion = para.getPortions().get_Item(0);

    // Sätter text
    portion.setText("Aspose TextBox");

    // Sparar presentationen till disk
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kontrollera om en form är en textruta**

Aspose.Slides tillhandahåller metoden [isTextBox](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/#isTextBox--) från [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/)-gränssnittet, vilket låter dig undersöka former och identifiera textrutor.

![Text box and shape](istextbox.png)

Den här Java‑koden visar hur du kontrollerar om en form skapades som en textruta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Observera att om du bara lägger till en autoshape med `addAutoShape`‑metoden från [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/)-gränssnittet, kommer `isTextBox`‑metoden för autoshapen att returnera `false`. Efter att du har lagt till text i autoshapen med `addTextFrame`‑metoden eller `setText`‑metoden, returnerar `isTextBox`‑egenskapen `true`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() returnerar falskt
shape1.addTextFrame("shape 1");
// shape1.isTextBox() returnerar sant

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() returnerar falskt
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() returnerar sant

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() returnerar falskt
shape3.addTextFrame("");
// shape3.isTextBox() returnerar falskt

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() returnerar falskt
shape4.getTextFrame().setText("");
// shape4.isTextBox() returnerar falskt
```

## **Hitta formen som äger en TextFrame**

I generisk textbearbetningskod kan du få en [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) utan att redan veta vilken presentationsobjekt som innehåller den. Använd [ITextFrame.getParentShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#getParentShape--)‑metoden för att navigera tillbaka till den ägande [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/).

För en textram som tillhör en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) eller en annan textinnehållande form, returnerar `ITextFrame.getParentShape` ägaren och `ITextFrame.getParentCell` returnerar `null`. Båda metoderna ger skrivskyddad navigering, så att anropa dem förändrar inte ägandet. Kontrollera alltid det returnerade värdet för `null` innan du får åtkomst till formen.

För ett komplett exempel som identifierar ägare av former och tabellceller, inklusive former kopplade till SmartArt‑noder, se [Sök och ersätt text](/slides/sv/androidjava/search-and-replace-text/).

## **Lägg till kolumner i en textruta**

Aspose.Slides tillhandahåller egenskaperna [ColumnCount](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) och [ColumnSpacing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (från [ITextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat)-gränssnittet och [TextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat)-klassen) som låter dig lägga till kolumner i textrutor. Du kan ange antalet kolumner i en textruta och ställa in avståndet i punkter mellan kolumnerna.

Denna kod i Java demonstrerar den beskrivna operationen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape med typ satt till Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Lägg till TextFrame till rektangeln
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Hämtar textformatet för TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Anger antalet kolumner i TextFrame
    format.setColumnCount(3);

    // Anger avståndet mellan kolumner
    format.setColumnSpacing(10);

    // Sparar presentationen
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till kolumner i en TextFrame**

Aspose.Slides för Android via Java tillhandahåller egenskapen [ColumnCount](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (från [ITextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat)-gränssnittet) som låter dig lägga till kolumner i TextFrames. Genom denna egenskap kan du ange önskat antal kolumner i en TextFrame.

Denna Java‑kod visar hur du lägger till en kolumn i en TextFrame:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Uppdatera text**

Aspose.Slides låter dig ändra eller uppdatera texten som finns i en textruta eller all text i en presentation.

Denna Java‑kod demonstrerar en operation där all text i en presentation uppdateras eller ändras:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // Kontrollerar om formen stödjer textram (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // Itererar genom stycken i textram
                {
                    for (IPortion portion : paragraph.getPortions()) // Itererar genom varje del i stycket
                    {
                        portion.setText(portion.getText().replace("years", "months")); // Ändrar text
                        portion.getPortionFormat().setFontBold(NullableBool.True); // Ändrar formatering
                    }
                }
            }
        }
    }

    // Sparar ändrad presentation
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till en textruta med en hyperlänk**

Du kan infoga en länk i en textruta. När textrutan klickas, omdirigeras användaren för att öppna länken.

För att lägga till en textruta som innehåller en länk, gå igenom följande steg:

1. Skapa en instans av `Presentation`‑klassen.  
2. Hämta en referens till den första bilden i den nyskapade presentationen.  
3. Lägg till ett `AutoShape`‑objekt med `ShapeType` satt till `Rectangle` på en specificerad position på bilden och hämta en referens till det nyss tillagda AutoShape‑objektet.  
4. Lägg till ett `TextFrame` till `AutoShape`‑objektet och ange texten för dess första del. I exemplet nedan använde vi texten: *Aspose.Slides*  
5. Hämta [IHyperlinkManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkmanager/)-objektet från `PortionFormat` för den del av `TextFrame` som du vill länka.  
6. Anropa [setExternalHyperlinkClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) på det objektet för att ange länken som ska öppnas när texten klickas.  
7. Skriv slutligen PPTX‑filen via `Presentation`‑objektet.  

Den här Java‑koden—en implementering av stegen ovan—visar hur du lägger till en textruta med en hyperlänk på en bild:

```java
import com.aspose.slides.*;

// Instansierar en Presentation-klass som representerar en PPTX
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till ett AutoShape-objekt med typen satt till Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Kastar formen till AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Åtkommer ITextFrame-egenskapen som är associerad med AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Lägger till någon text i ramen
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Ställer in hyperlänken för deltexten
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Sparar PPTX-presentationen
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Vad är skillnaden mellan en textruta och en textplatshållare när du arbetar med masterbilder?**

En [placeholder](/slides/sv/androidjava/manage-placeholder/) ärver stil/position från [master](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/masterslide/) och kan åsidosättas på [layouts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/layoutslide/), medan en vanlig textruta är ett självständigt objekt på en specifik bild och ändras inte när du byter layout.

**Hur kan jag utföra en massersättning av text i hela presentationen utan att påverka text i diagram, tabeller och SmartArt?**

Begränsa iterationen till autoshapes som har TextFrames och exkludera inbäddade objekt ([charts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/smartart/)) genom att traversera deras samlingar separat eller hoppa över dessa objekttyper.