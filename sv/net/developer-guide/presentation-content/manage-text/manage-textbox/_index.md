---
title: Hantera textrutor i presentationer i .NET
linktitle: Hantera textruta
type: docs
weight: 20
url: /sv/net/manage-textbox/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides för .NET gör det enkelt att skapa, redigera och klona textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomatisering."
---
## **Introduktion**

Texter på bilder finns vanligtvis i textrutor eller former. Därför måste du först lägga till en textruta för att kunna lägga till text på en bild och sedan placera text i textrutan. 

För att låta dig lägga till en form som kan innehålla text tillhandahåller Aspose.Slides för .NET gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides tillhandahåller också gränssnittet [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape) för att låta dig lägga till former på bilder. Dock kan inte alla former som läggs till via `IShape`-gränssnittet innehålla text. Former som läggs till via gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape) innehåller vanligtvis text. 

Därför, när du hanterar en befintlig form som du vill lägga till text i, kan du vilja kontrollera och bekräfta att den kastades via `IAutoShape`-gränssnittet. Endast då kan du arbeta med [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/properties/textframe), som är en egenskap under `IAutoShape`. Se avsnittet [Update Text](https://docs.aspose.com/slides/sv/net/manage-textbox/#update-text) på den här sidan. 

{{% /alert %}}

## **Skapa en textruta på en bild**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation). 
2. Hämta referensen till den första bilden via dess index. 
3. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape)-objekt med [ShapeType](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape/properties/shapetype) satt till `Rectangle` på en angiven position på bilden och erhåll referensen till det nyss tillagda `IAutoShape`-objektet. 
4. Lägg till egenskapen `TextFrame` till `IAutoShape`-objektet som kommer att innehålla text. I exempel nedan lade vi till följande text: *Aspose TextBox*
5. Skriv slutligen PPTX-filen via `Presentation`-objektet. 

Den här C#-koden - en implementation av stegen ovan - visar hur du lägger till text på en bild:

```c#
// Instansierar PresentationEx
using (Presentation pres = new Presentation())
{

    // Hämtar den första bilden i presentationen
    ISlide sld = pres.Slides[0];

    // Lägger till en AutoShape med typ satt till Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Lägger till TextFrame till rektangeln
    ashp.AddTextFrame(" ");

    // Åtkommer textramen
    ITextFrame txtFrame = ashp.TextFrame;

    // Skapar Paragraph-objektet för textramen
    IParagraph para = txtFrame.Paragraphs[0];

    // Skapar ett Portion-objekt för paragrafen
    IPortion portion = para.Portions[0];

    // Sätter texten
    portion.Text = "Aspose TextBox";

    // Sparar presentationen till disk
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Kontrollera om en form är en textruta**

Aspose.Slides tillhandahåller egenskapen [IsTextBox](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/istextbox/) från gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) som låter dig undersöka former och identifiera textrutor.

![Text box and shape](istextbox.png)

Den här C#-koden visar hur du kontrollerar om en form skapades som en textruta: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

Observera att om du bara lägger till en autoshape med metoden `AddAutoShape` från gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/), kommer `IsTextBox`-egenskapen för autoshapen att returnera `false`. Men efter att du har lagt till text till autoshapen med metoden `AddTextFrame` eller egenskapen `Text` returnerar `IsTextBox`-egenskapen `true`.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox är falskt
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox är sant

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox är falskt
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox är sant

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox är falskt
    shape3.AddTextFrame("");
    // shape3.IsTextBox är falskt

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox är falskt
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox är falskt
}
```

## **Lägg till kolumner i en textruta**

Aspose.Slides tillhandahåller egenskaperna [ColumnCount](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/properties/columncount) och [ColumnSpacing](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat/properties/columnspacing) (från gränssnittet [ITextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat) och klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat)) för att låta dig lägga till kolumner i textrutor. Du kan ange antalet kolumner i en textruta och sedan specificera avståndet i punkter mellan kolumnerna. 

Den här C#‑koden demonstrerar den beskrivna operationen: 

```c#
using (Presentation presentation = new Presentation())
{
	// Hämtar den första bilden i presentationen
	ISlide slide = presentation.Slides[0];

	// Lägger till en AutoShape med typ satt till Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Lägger till TextFrame till rektangeln
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Hämtar textformatet för TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Anger antalet kolumner i TextFrame
	format.ColumnCount = 3;

	// Anger avståndet mellan kolumnerna
	format.ColumnSpacing = 10;

	// Sparar presentationen
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Lägg till kolumner i en textram**
Aspose.Slides för .NET tillhandahåller egenskapen [ColumnCount](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/properties/columncount) (från gränssnittet [ITextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat)) som låter dig lägga till kolumner i textramar. Med denna egenskap kan du ange önskat antal kolumner i en textram. 

Den här C#‑koden visar hur du lägger till en kolumn i en textram:

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Uppdatera text**

Aspose.Slides låter dig ändra eller uppdatera texten som finns i en textruta eller all text i en presentation. 

Den här C#‑koden demonstrerar en operation där all text i en presentation uppdateras eller ändras:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Kontrollerar om formen stöder textram (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Itererar genom stycken i textram
               {
                   foreach (IPortion portion in paragraph.Portions) //Itererar genom varje del i stycket
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Ändrar text
                       portion.PortionFormat.FontBold = NullableBool.True; //Ändrar formatering
                   }
               }
           }
       }
   }
  
   //Sparar den ändrade presentationen
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Lägg till en textruta med en hyperlänk** 

Du kan infoga en länk i en textruta. När textrutan klickas på, öppnas länken för användaren. 

1. Skapa en instans av klassen `Presentation`. 
2. Hämta referensen till den första bilden via dess index.  
3. Lägg till ett `AutoShape`‑objekt med `ShapeType` satt till `Rectangle` på en angiven position på bilden och erhåll en referens till det nyss tillagda AutoShape‑objektet.
4. Lägg till ett `TextFrame` till `AutoShape`‑objektet som innehåller *Aspose TextBox* som standardtext. 
5. Instansiera klassen `IHyperlinkManager`. 
6. Tilldela `IHyperlinkManager`‑objektet till egenskapen [HyperlinkClick](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/properties/hyperlinkclick) som är associerad med den önskade delen av `TextFrame`. 
7. Skriv slutligen PPTX-filen via `Presentation`‑objektet. 

Den här C#‑koden - en implementation av stegen ovan - visar hur du lägger till en textruta med en hyperlänk på en bild:

```c#
// Instansierar en Presentation-klass som representerar en PPTX
Presentation pptxPresentation = new Presentation();

// Hämtar den första bilden i presentationen
ISlide slide = pptxPresentation.Slides[0];

// Lägger till ett AutoShape-objekt med typ satt till Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Kastar formen till AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Åtkommer ITextFrame-egenskapen som är associerad med AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Lägger till lite text i ramen
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Ställer in hyperlänken för deltexten
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Sparar PPTX-presentationen
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en textplatshållare när du arbetar med masterbilder?**

En [placeholder](/slides/sv/net/manage-placeholder/) ärver stil/position från [master](https://reference.aspose.com/slides/sv/net/aspose.slides/masterslide/) och kan åsidosättas på [layouts](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutslide/), medan en vanlig textruta är ett självständigt objekt på en specifik bild och förändras inte när du byter layout.

**Hur kan jag göra en massutbyte av text i hela presentationen utan att ändra text i diagram, tabeller och SmartArt?**

Begränsa din iteration till auto‑former som har textramar och exkludera inbäddade objekt ([charts](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/sv/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/smartart/)) genom att traversera deras samlingar separat eller hoppa över dessa objekttyper.