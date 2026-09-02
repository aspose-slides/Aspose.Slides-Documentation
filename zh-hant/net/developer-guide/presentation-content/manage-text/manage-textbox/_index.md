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
- 新增文字欄位
- 新增超連結
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 讓您輕鬆在 PowerPoint 與 OpenDocument 檔案中建立、編輯與複製文字方塊，提升簡報自動化的效率。"
---
## **介紹**

投影片上的文字通常存在於文字方塊或圖形中。因此，要在投影片上加入文字，必須先新增文字方塊，然後把文字放入該文字方塊中。

為了讓您能新增可容納文字的圖形，Aspose.Slides for .NET 提供了[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)介面。

{{% alert title="Note" color="warning" %}} 

Aspose.Slides 也提供了[IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape)介面，以便您向投影片中新增圖形。然而，透過`IShape`介面新增的圖形並不一定能容納文字。透過[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)介面新增的圖形通常會包含文字。

因此，當處理已存在且您想加入文字的圖形時，您可能需要檢查並確認它是以`IAutoShape`介面轉型的。只有這樣，您才能使用屬於`IAutoShape`的[TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/properties/textframe)。請參閱本頁面的[Update Text](https://docs.aspose.com/slides/zh-hant/net/manage-textbox/#update-text)章節。

{{% /alert %}}

## **在投影片上建立文字方塊**

1. 建立一個[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)類別的實例。  
2. 透過索引取得第一張投影片的參考。  
3. 在投影片的指定位置新增一個[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape)物件，將[ShapeType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/properties/shapetype)設定為`Rectangle`，並取得新加入的`IAutoShape`物件的參考。  
4. 為`IAutoShape`物件新增一個`TextFrame`屬性，以容納文字。在下列範例中，我們加入的文字為 *Aspose TextBox*。  
5. 最後，透過`Presentation`物件寫入 PPTX 檔案。  

以下 C# 程式碼示範了上述步驟，說明如何在投影片上加入文字：

```c#
using Aspose.Slides;

// 建立 PresentationEx 實例
using (Presentation pres = new Presentation())
{

    // 取得簡報中的第一張投影片
    ISlide sld = pres.Slides[0];

    // 新增類型設定為 Rectangle 的 AutoShape
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 為矩形新增 TextFrame
    ashp.AddTextFrame(" ");

    // 取得文字框
    ITextFrame txtFrame = ashp.TextFrame;

    // 為文字框建立 Paragraph 物件
    IParagraph para = txtFrame.Paragraphs[0];

    // 為段落建立 Portion 物件
    IPortion portion = para.Portions[0];

    // 設定文字
    portion.Text = "Aspose TextBox";

    // 將簡報儲存至磁碟
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **檢查是否為文字方塊圖形**

Aspose.Slides 從[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)介面提供了[IsTextBox](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/istextbox/)屬性，讓您檢查圖形並辨識文字方塊。

![文字方塊與圖形](istextbox.png)

以下 C# 程式碼示範了如何檢查圖形是否為文字方塊：

```c#
using Aspose.Slides;

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

請注意，如果您僅使用[IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/)介面的`AddAutoShape`方法新增自動圖形，該自動圖形的`IsTextBox`屬性會回傳`false`。但在使用`AddTextFrame`方法或`Text`屬性為自動圖形加入文字後，`IsTextBox`屬性會回傳`true`。

```cs
using Aspose.Slides;

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

## **尋找擁有 TextFrame 的圖形**

在一般的文字處理程式碼中，您可能會收到一個[ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)，卻不知道它屬於哪個投影片物件。請使用[ITextFrame.ParentShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/parentshape/)屬性，返回擁有它的[IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)。

對於屬於[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)或其他可容納文字的圖形的文字框，[ITextFrame.ParentShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/parentshape/) 會被設定，而[ITextFrame.ParentCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/parentcell/) 會是 `null`。這兩個屬性皆為唯讀導覽屬性，讀取它們不會改變擁有權。存取圖形前，務必先檢查回傳值是否為 `null`。

欲取得完整的範例，說明如何辨識圖形與表格儲存格的擁有者（包括與 SmartArt 節點相關的圖形），請參閱[Search and Replace Text](/slides/zh-hant/net/search-and-replace-text/)。

## **為文字方塊加入欄位**

Aspose.Slides 提供了[ColumnCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/columncount)和[ColumnSpacing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/properties/columnspacing)屬性（分別來自[ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat)介面與[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat)類別），讓您能在文字方塊中加入欄位。您可以指定文字方塊的欄位數量，並設定欄位之間的點距。

以下 C# 程式碼示範了此操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// 取得簡報中的第一張投影片
	ISlide slide = presentation.Slides[0];

	// 新增類型設定為 Rectangle 的 AutoShape
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// 為矩形新增 TextFrame
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

## **為文字框加入欄位**

Aspose.Slides for .NET 從[ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat)介面提供了[ColumnCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/columncount)屬性，讓您能在文字框中加入欄位。透過此屬性，您可以指定文字框中希望的欄位數量。

以下 C# 程式碼示範了如何在文字框內加入欄位：

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

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
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
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

Aspose.Slides 允許您變更或更新文字方塊中的文字，或是整個投影片中的所有文字。

以下 C# 程式碼示範了如何更新或變更投影片中所有的文字：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //檢查形狀是否支援文字框 (IAutoShape)。
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //迭代文字框中的段落
               {
                   foreach (IPortion portion in paragraph.Portions) //迭代段落中的每個 Portion
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

## **在文字方塊中加入超連結**

您可以在文字方塊內插入連結。當使用者點擊文字方塊時，會導向該連結。

1. 建立`Presentation`類別的實例。  
2. 透過索引取得第一張投影片的參考。  
3. 在投影片的指定位置新增一個`AutoShape`物件，將`ShapeType`設定為`Rectangle`，並取得新加入的 AutoShape 物件的參考。  
4. 為該`AutoShape`物件新增一個`TextFrame`，其預設文字為 *Aspose TextBox*。  
5. 建立`IHyperlinkManager`類別的實例。  
6. 將`IHyperlinkManager`物件指派給您在`TextFrame`中選取的文字段落所對應的[HyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/properties/hyperlinkclick)屬性。  
7. 最後，透過`Presentation`物件寫入 PPTX 檔案。  

以下 C# 程式碼示範了如何在投影片上加入帶有超連結的文字方塊：

```c#
using Aspose.Slides;

// 實例化代表 PPTX 的 Presentation 類別
Presentation pptxPresentation = new Presentation();

// 取得簡報中的第一張投影片
ISlide slide = pptxPresentation.Slides[0];

// 新增類型設定為 Rectangle 的 AutoShape 物件
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// 將形狀轉型為 AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// 取得與 AutoShape 相關聯的 ITextFrame 屬性
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// 向框架加入一些文字
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// 為 Portion 文字設定超連結
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// 儲存 PPTX 簡報
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **常見問題**

**在使用母片時，文字方塊與文字佔位符有何不同？**

[placeholder](/slides/zh-hant/net/manage-placeholder/)會從[master](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masterslide/)繼承樣式/位置，且可在[layouts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutslide/)上覆寫；相較之下，一般的文字方塊是特定投影片上的獨立物件，切換版面配置時不會改變。

**如何在整份投影片中執行大量文字取代，同時不觸及圖表、表格與 SmartArt 內的文字？**

只遍歷具有文字框的自動圖形，並排除嵌入物件（[charts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/smartart/)），可透過分別遍歷其集合或跳過這些物件類型來達成。