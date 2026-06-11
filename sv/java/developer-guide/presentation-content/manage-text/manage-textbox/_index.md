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
description: "Aspose.Slides for Java gör det enkelt att skapa, redigera och klona textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomatisering."
---
## **Introduktion**

Texter på bilder finns vanligtvis i textrutor eller former. Därför måste du för att lägga till text på en bild först lägga till en textruta och sedan placera lite text i textrutan. Aspose.Slides for Java tillhandahåller gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape) som låter dig lägga till en form som innehåller text.

{{% alert title="Info" color="info" %}}

Aspose.Slides erbjuder även gränssnittet [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape) som låter dig lägga till former på bilder. Alla former som läggs till via `IShape`‑gränssnittet kan dock inte innehålla text. Former som läggs till via [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape) kan innehålla text. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Därför, när du arbetar med en form som du vill lägga till text i, bör du kontrollera och bekräfta att den har kastats via `IAutoShape`‑gränssnittet. Endast då kan du arbeta med [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrame), som är en egenskap under `IAutoShape`. Se avsnittet [Update Text](https://docs.aspose.com/slides/sv/java/manage-textbox/#update-text) på den här sidan. 

{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta på en bild, gå igenom följande steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).  
2. Hämta en referens till den första bilden i den nyss skapade presentationen.  
3. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape)‑objekt med [ShapeType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IGeometryShape#setShapeType-int-) satt till `Rectangle` på en specificerad position på bilden och hämta referensen till det nyss tillagda `IAutoShape`‑objektet.  
4. Lägg till en `TextFrame`‑egenskap till `IAutoShape`‑objektet som kommer att innehålla text. I exemplet nedan lade vi till följande text: *Aspose TextBox*  
5. Slutligen skriv PPTX‑filen via `Presentation`‑objektet.  

Den här Java‑koden—en implementering av stegen ovan—visar hur du lägger till text på en bild:

```java
    // Instansierar Presentation
    Presentation pres = new Presentation();
    try {
        // Hämtar den första bilden i presentationen
        ISlide sld = pres.getSlides().get_Item(0);

        // Lägger till en AutoShape med typ satt till Rectangle
        IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

        // Lägger till ett TextFrame i rektangeln
        ashp.addTextFrame(" ");

        // Åtkommer textramen
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

Aspose.Slides tillhandahåller metoden [isTextBox](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/#isTextBox--) från gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) som låter dig undersöka former och identifiera textrutor.

![Textruta och form](istextbox.png)

Denna Java‑kod visar hur du kontrollerar om en form skapades som en textruta: 

```java
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

Observera att om du helt enkelt lägger till en autoshape med `addAutoShape`‑metoden från gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/) så returnerar `isTextBox`‑metoden `false`. Efter att du har lagt till text i autoshapen med `addTextFrame`‑metoden eller `setText`‑metoden returneras `true`.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() returnerar false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() returnerar true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() returnerar false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() returnerar true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() returnerar false
shape3.addTextFrame("");
// shape3.isTextBox() returnerar false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() returnerar false
shape4.getTextFrame().setText("");
// shape4.isTextBox() returnerar false
```

## **Lägg till kolumner i en textruta**

Aspose.Slides erbjuder egenskaperna [ColumnCount](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) och [ColumnSpacing](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (från gränssnittet [ITextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrameFormat) och klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat)) som låter dig lägga till kolumner i textrutor. Du kan ange antalet kolumner i en textruta och ange avståndet i punkter mellan kolumnerna. 

Denna Java‑kod demonstrerar den beskrivna operationen: 

```java
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape med typ satt till Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Lägg till TextFrame i rektangeln
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Hämtar textformatet för TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Anger antalet kolumner i TextFrame
    format.setColumnCount(3);

    // Anger avståndet mellan kolumnerna
    format.setColumnSpacing(10);

    // Sparar presentationen
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till kolumner i en textram**

Aspose.Slides for Java tillhandahåller egenskapen [ColumnCount](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (från gränssnittet [ITextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrameFormat)) som låter dig lägga till kolumner i textramar. Med denna egenskap kan du specificera önskat antal kolumner i en textram. 

Denna Java‑kod visar hur du lägger till en kolumn i en textram:

```java
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
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Uppdatera text**

Aspose.Slides låter dig ändra eller uppdatera texten i en textruta eller all text i en presentation. 

Denna Java‑kod demonstrerar en operation där all text i en presentation uppdateras eller ändras:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Kontrollerar om formen stödjer textram (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Itererar genom stycken i textramen
                {
                    for (IPortion portion : paragraph.getPortions()) //Itererar genom varje del i stycket
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Ändrar text
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Ändrar formatering
                    }
                }
            }
        }
    }

    //Sparar ändrad presentation
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till en textruta med hyperlänk** 

Du kan infoga en länk i en textruta. När textrutan klickas på öppnas länken för användaren. 

För att lägga till en textruta som innehåller en länk, gå igenom följande steg:

1. Skapa en instans av klassen `Presentation`.  
2. Hämta en referens till den första bilden i den nyss skapade presentationen.  
3. Lägg till ett `AutoShape`‑objekt med `ShapeType` satt till `Rectangle` på en specificerad position på bilden och hämta referensen till det nyss tillagda AutoShape‑objektet.  
4. Lägg till en `TextFrame` till `AutoShape`‑objektet som innehåller *Aspose TextBox* som standardtext.  
5. Instansiera klassen `IHyperlinkManager`.  
6. Tilldela `IHyperlinkManager`‑objektet till egenskapen [HyperlinkClick](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Shape#getHyperlinkClick--) som är kopplad till den del av `TextFrame` du vill länka.  
7. Slutligen skriv PPTX‑filen via `Presentation`‑objektet. 

Denna Java‑kod—en implementering av stegen ovan—visar hur du lägger till en textruta med hyperlänk på en bild:

```java
// Instansierar en Presentation-klass som representerar en PPTX
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till ett AutoShape-objekt med typen satt till Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Kastar formen till AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Åtkommer ITextFrame-egenskapen som är kopplad till AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Lägger till lite text i ramen
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Ställer in hyperlänken för portionstexten
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Sparar PPTX-presentationen
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en textplatshållare när du arbetar med huvudsidor?**

En [placeholder](/slides/sv/java/manage-placeholder/) ärver stil/position från [master](https://reference.aspose.com/slides/sv/java/com.aspose.slides/masterslide/) och kan åsidosättas på [layouts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/layoutslide/), medan en vanlig textruta är ett självständigt objekt på en specifik bild och ändras inte när du byter layout.

**Hur kan jag utföra en massutbyte av text i hela presentationen utan att påverka text i diagram, tabeller och SmartArt?**

Begränsa iterationen till autoshapes som har textramar och exkludera inbäddade objekt ([charts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/sv/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/smartart/)) genom att traversera deras samlingar separat eller hoppa över dessa objekttyper.