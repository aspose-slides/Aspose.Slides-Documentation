---
title: 在 .NET 中管理簡報的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/net/manage-textbox/
keywords:
- 文字方塊
- 文字框
- 新增文字
- 更新文字
- 建立文字方塊
- 檢查文字方塊
- 新增文字欄
- 新增超連結
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 可以輕鬆在 PowerPoint 和 OpenDocument 檔案中建立、編輯和複製文字方塊，提升您的簡報自動化流程。"
---
## **簡介**

投影片上的文字通常存在於文字方塊或圖形中。因此，要在投影片上新增文字，必須先新增文字方塊，然後在文字方塊內放入文字。

為了讓您能新增可容納文字的圖形，Aspose.Slides for .NET 提供了[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)介面。

{{% alert title="Note" color="warning" %}} 
Aspose.Slides 也提供了[IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape)介面，讓您可以將圖形新增至投影片。然而，並非所有透過`IShape`介面新增的圖形都能容納文字。透過[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)介面新增的圖形通常會包含文字。

因此，當您處理已存在且想要加入文字的圖形時，可能需要檢查並確認該圖形已透過`IAutoShape`介面轉型。只有這樣，您才能使用[TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/properties/textframe)，此屬性屬於`IAutoShape`。請參閱本頁面的[Update Text](https://docs.aspose.com/slides/zh-hant/net/manage-textbox/#update-text)章節。
{{% /alert %}}

## **在投影片上建立文字方塊**

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)類別的實例。  
2. 透過索引取得第一張投影片的參考。  
3. 在投影片的指定位置加入一個[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)物件，將[ShapeType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/properties/shapetype)設定為`Rectangle`，並取得新加入的`IAutoShape`物件的參考。  
4. 為`IAutoShape`物件加入`TextFrame`屬性以容納文字。以下範例加入的文字為：*Aspose TextBox*。  
5. 最後，使用`Presentation`物件寫入 PPTX 檔案。  

此 C# 程式碼—上述步驟的實作範例—示範如何在投影片上新增文字：

```c#
// 實例化 PresentationEx
using (Presentation pres = new Presentation())
{

    // 取得簡報中的第一張投影片
    ISlide sld = pres.Slides[0];

    // 新增類型為 Rectangle 的 AutoShape
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 為 Rectangle 添加 TextFrame
    ashp.AddTextFrame(" ");

    // 存取文字框
    ITextFrame txtFrame = ashp.TextFrame;

    // 為文字框建立 Paragraph 物件
    IParagraph para = txtFrame.Paragraphs[0];

    // 為段落建立 Portion 物件
    IPortion portion = para.Portions[0];

    // 設定文字
    portion.Text = "Aspose TextBox";

    // 儲存簡報至磁碟
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **檢查是否為文字方塊圖形**

Aspose.Slides 提供了[IsTextBox](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/istextbox/)屬性（來自[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)介面），讓您能檢查圖形並辨識文字方塊。

![文字方塊與圖形](istextbox.png)

此 C# 程式碼示範如何檢查圖形是否被建立為文字方塊：

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

請注意，如果僅使用[IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/)介面的`AddAutoShape`方法新增自動圖形，則該自動圖形的`IsTextBox`屬性會回傳`false`。然而，在使用`AddTextFrame`方法或`Text`屬性為自動圖形加入文字後，`IsTextBox`屬性會回傳`true`。

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox 為 false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox 為 true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox 為 false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox 為 true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox 為 false
    shape3.AddTextFrame("");
    // shape3.IsTextBox 為 false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox 為 false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox 為 false
}
```

## **在文字方塊中新增欄位**

Aspose.Slides 提供了[ColumnCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/columncount)與[ColumnSpacing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/properties/columnspacing)屬性（分別來自[ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat)介面與[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat)類別），讓您能在文字方塊中加入欄位。您可以指定文字方塊的欄位數量，並設定欄位之間的點數間距。

以下 C# 程式碼示範上述操作：

```c#
using (Presentation presentation = new Presentation())
{
	// 取得簡報中的第一張投影片
	ISlide slide = presentation.Slides[0];

	// 新增類型為 Rectangle 的 AutoShape
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// 為 Rectangle 加入 TextFrame
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// 取得 TextFrame 的文字格式
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// 指定 TextFrame 中的欄位數量
	format.ColumnCount = 3;

	// 指定欄位之間的間距
	format.ColumnSpacing = 10;

	// 儲存簡報
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **在文字框中新增欄位**

Aspose.Slides for .NET 提供了[ColumnCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/columncount)屬性（來自[ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat)介面），讓您能在文字框中加入欄位。透過此屬性，您可指定文字框中希望的欄位數量。

此 C# 程式碼示範如何在文字框內加入欄位：

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

## **更新文字**

Aspose.Slides 允許您變更或更新文字方塊中的文字，或整個簡報中所有的文字。

此 C# 程式碼示範如何在簡報中更新或變更所有文字：

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //檢查形狀是否支援文字框 (IAutoShape)。
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //遍歷文字框中的段落
               {
                   foreach (IPortion portion in paragraph.Portions) //遍歷段落中的每個 Portion
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //變更文字
                       portion.PortionFormat.FontBold = NullableBool.True; //變更格式
                   }
               }
           }
       }
   }
  
   //儲存已修改的簡報
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **新增帶有超連結的文字方塊**

您可以在文字方塊內插入連結。當使用者點擊文字方塊時，將會導向並開啟該連結。

1. 建立`Presentation`類別的實例。  
2. 透過索引取得第一張投影片的參考。  
3. 在投影片的指定位置加入一個`AutoShape`物件，將`ShapeType`設定為`Rectangle`，並取得新加入的 AutoShape 物件的參考。  
4. 為 `AutoShape` 物件加入 `TextFrame`，其預設文字為 *Aspose TextBox*。  
5. 實例化 `IHyperlinkManager` 類別。  
6. 將 `IHyperlinkManager` 物件指派給與您在 `TextFrame` 中選取的文字部分相關的[HyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/properties/hyperlinkclick)屬性。  
7. 最後，使用 `Presentation` 物件寫入 PPTX 檔案。  

此 C# 程式碼—上述步驟的實作範例—示範如何在投影片上新增帶有超連結的文字方塊：

```c#
// 實例化代表 PPTX 的 Presentation 類別
Presentation pptxPresentation = new Presentation();

// 取得簡報中的第一張投影片
ISlide slide = pptxPresentation.Slides[0];

// 新增類型為 Rectangle 的 AutoShape 物件
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// 將形狀轉型為 AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// 存取與 AutoShape 關聯的 ITextFrame 屬性
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// 向框架添加一些文字
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// 設定 Portion 文字的超連結
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// 儲存 PPTX 簡報
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **常見問答**

**在使用母版投影片時，文字方塊與文字佔位符的差異是什麼？**

[placeholder](/slides/zh-hant/net/manage-placeholder/)會從[master](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masterslide/)繼承樣式/位置，且可在[layouts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutslide/)上被覆寫；相較之下，普通文字方塊是特定投影片上的獨立物件，切換版面配置時不會改變。

**如何在不影響圖表、表格與 SmartArt 內文字的情況下，對整份簡報執行批次文字取代？**

將遍歷限制在具有文字框的自動圖形上，並於遍歷時排除嵌入物件（如[charts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/smartart/)），可分別走訪其集合或直接跳過這些物件類型。