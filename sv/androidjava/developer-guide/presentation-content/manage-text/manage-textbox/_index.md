---
title: Hantera textrutor i presentationer på Android
linktitle: Hantera textruta
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
description: "Aspose.Slides för Android via Java gör det enkelt att skapa, redigera och klona textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomatisering."
---
## **Introduktion**

Texter på bilder finns vanligtvis i textrutor eller former. Därför måste du, för att lägga till text på en bild, lägga till en textruta och sedan placera lite text i textrutan. Aspose.Slides för Android via Java tillhandahåller gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape) som låter dig lägga till en form som innehåller text.

{{% alert title="Info" color="info" %}}

Aspose.Slides tillhandahåller också gränssnittet [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape) som låter dig lägga till former på bilder. Dock kan inte alla former som läggs till via `IShape`‑gränssnittet innehålla text. Men former som läggs till via [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape)‑gränssnittet kan innehålla text.

{{% /alert %}}

{{% alert title="Obs" color="warning" %}} 

Därför, när du arbetar med en form som du vill lägga till text i, kan du vilja kontrollera och bekräfta att den har kastats via `IAutoShape`‑gränssnittet. Endast då kan du arbeta med [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrame), som är en egenskap under `IAutoShape`. Se avsnittet [Update Text](https://docs.aspose.com/slides/sv/androidjava/manage-textbox/#update-text) på den här sidan.

{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta på en bild, gå igenom dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en referens till den första bilden i den nyskapade presentationen. 
3. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape)‑objekt med [ShapeType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) satt till `Rectangle` på en specificerad position på bilden och hämta referensen till det nyskapade `IAutoShape`‑objektet.
4. Lägg till en `TextFrame`‑egenskap till `IAutoShape`‑objektet som kommer att innehålla text. I exemplet nedan lade vi till följande text: *Aspose TextBox*
5. Skriv slutligen PPTX‑filen genom `Presentation`‑objektet. 

Denna Java‑kod – en implementering av stegen ovan – visar hur du lägger till text på en bild:

```java
// Instansierar Presentation
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägger till en AutoShape med typ satt till Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Lägger till TextFrame till rektangeln
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

## **Kontrollera en textrutaform**

Aspose.Slides tillhandahåller metoden [isTextBox](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/#isTextBox--) från [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/)‑gränssnittet, vilket låter dig undersöka former och identifiera textrutor.

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

Observera att om du helt enkelt lägger till en autoshape med metoden `addAutoShape` från [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/)‑gränssnittet, så kommer `isTextBox`‑metoden för autoshapen att returnera `false`. Men efter att du har lagt till text i autoshapen med metoden `addTextFrame` eller `setText`, så returnerar `isTextBox`‑egenskapen `true`.

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

Aspose.Slides tillhandahåller egenskaperna [ColumnCount](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) och [ColumnSpacing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (från [ITextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat)-gränssnittet och klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat)) som låter dig lägga till kolumner i textrutor. Du kan ange antalet kolumner i en textruta och ställa in avståndet i punkter mellan kolumnerna.

Denna kod i Java demonstrerar den beskrivna operationen: 

```java
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till en AutoShape med typ satt till Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Lägger till TextFrame till rektangeln
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

## **Lägg till kolumner i ett textfält**

Aspose.Slides för Android via Java tillhandahåller egenskapen [ColumnCount](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (från [ITextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrameFormat)-gränssnittet) som låter dig lägga till kolumner i textfält. Med denna egenskap kan du ange önskat antal kolumner i ett textfält.

Denna Java‑kod visar hur du lägger till en kolumn i ett textfält:

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

Aspose.Slides låter dig ändra eller uppdatera texten som finns i en textruta eller alla texter i en presentation.

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
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Itererar genom paragrafer i textramen
                {
                    for (IPortion portion : paragraph.getPortions()) //Itererar genom varje del i paragrafen
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Ändrar text
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Ändrar formatering
                    }
                }
            }
        }
    }

    //Sparar modifierad presentation
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till en textruta med hyperlänk** 

Du kan infoga en länk i en textruta. När textrutan klickas på, dirigeras användarna till att öppna länken. 

För att lägga till en textruta som innehåller en länk, gå igenom dessa steg:

1. Skapa en instans av klassen `Presentation`. 
2. Hämta en referens till den första bilden i den nyskapade presentationen. 
3. Lägg till ett `AutoShape`‑objekt med `ShapeType` satt till `Rectangle` på en specificerad position på bilden och hämta en referens till det nyskapade AutoShape‑objektet.
4. Lägg till ett `TextFrame` till `AutoShape`‑objektet som innehåller *Aspose TextBox* som standardtext. 
5. Skapa en instans av klassen `IHyperlinkManager`. 
6. Tilldela `IHyperlinkManager`‑objektet till egenskapen [HyperlinkClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) som är kopplad till den önskade delen av `TextFrame`.
7. Skriv slutligen PPTX‑filen genom `Presentation`‑objektet. 

Denna Java‑kod – en implementering av stegen ovan – visar hur du lägger till en textruta med en hyperlänk på en bild:

```java
// Instansierar en Presentation-klass som representerar en PPTX
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till ett AutoShape-objekt med typ satt till Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Kastar formen till AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Åtkommer ITextFrame‑egenskapen som är associerad med AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Lägger till lite text i ramen
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Ställer in hyperlänken för textdelen
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

**Vad är skillnaden mellan en textruta och en platshållare för text när du arbetar med masterslides?**

En [platshållare](/slides/sv/androidjava/manage-placeholder/) ärver stil/position från [mastern](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/masterslide/) och kan åsidosättas på [layouter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/layoutslide/), medan en vanlig textruta är ett självständigt objekt på en specifik bild och ändras inte när du byter layout.

**Hur kan jag göra en massutbyte av text i hela presentationen utan att påverka text i diagram, tabeller och SmartArt?**

Begränsa din iteration till autosformer som har textramar och exkludera inbäddade objekt ([diagram](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/), [tabeller](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/smartart/)) genom att traversera deras samlingar separat eller hoppa över dessa objekttyper.