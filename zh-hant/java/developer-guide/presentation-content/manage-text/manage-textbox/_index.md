---
title: 使用 Java 管理簡報中的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/java/manage-textbox/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 讓您輕鬆在 PowerPoint 與 OpenDocument 檔案中建立、編輯和複製文字方塊，提升簡報自動化的效率。"
---
## **簡介**

投影片上的文字通常位於文字方塊或圖形中。因此，要在投影片上加入文字，必須先新增文字方塊，然後在文字方塊內放入文字。Aspose.Slides for Java 提供了 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape) 介面，允許您新增包含文字的圖形。

{{% alert title="資訊" color="info" %}}

Aspose.Slides 也提供了 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape) 介面，讓您可以在投影片上新增圖形。然而，透過 `IShape` 介面新增的並非所有圖形都能容納文字。但透過 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape) 介面新增的圖形可能包含文字。 

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

因此，當處理想要加入文字的圖形時，您可能需要檢查並確認它是透過 `IAutoShape` 介面轉型的。只有這樣，您才能使用屬於 `IAutoShape` 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrame)，請參閱本頁面的 [Update Text](https://docs.aspose.com/slides/zh-hant/java/manage-textbox/#update-text) 章節。 

{{% /alert %}}

## **在投影片上建立文字方塊**

若要在投影片上建立文字方塊，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。 
2. 取得新建立的簡報中第一張投影片的參照。 
3. 在投影片的指定位置新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape) 物件，將 [ShapeType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryShape#setShapeType-int-) 設為 `Rectangle`，並取得新新增的 `IAutoShape` 物件的參照。 
4. 為 `IAutoShape` 物件新增 `TextFrame` 屬性以容納文字。以下範例中，我們加入了文字：*Aspose TextBox* 
5. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。 

以下的 Java 程式碼—上述步驟的實作範例—示範如何在投影片中加入文字：

```java
// 建立 Presentation 實例
Presentation pres = new Presentation();
try {
    // 取得簡報中的第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增 AutoShape，類型設定為 Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 為 Rectangle 新增 TextFrame
    ashp.addTextFrame(" ");

    // 取得文字框
    ITextFrame txtFrame = ashp.getTextFrame();

    // 為文字框建立 Paragraph 物件
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 為段落建立 Portion 物件
    IPortion portion = para.getPortions().get_Item(0);

    // 設定文字
    portion.setText("Aspose TextBox");

    // 將簡報儲存至磁碟
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **檢查文字方塊圖形**

Aspose.Slides 透過 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 介面的 [isTextBox](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/#isTextBox--) 方法，讓您可以檢查圖形並辨識文字方塊。

![文字方塊與圖形](istextbox.png)

以下的 Java 程式碼示範如何檢查圖形是否被建立為文字方塊： 

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

請注意，如果僅使用 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/) 介面的 `addAutoShape` 方法新增自動圖形，該自動圖形的 `isTextBox` 方法會回傳 `false`。但若使用 `addTextFrame` 方法或 `setText` 方法為自動圖形加入文字，`isTextBox` 屬性則會回傳 `true`。

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() 回傳 false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() 回傳 true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() 回傳 false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() 回傳 true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() 回傳 false
shape3.addTextFrame("");
// shape3.isTextBox() 回傳 false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() 回傳 false
shape4.getTextFrame().setText("");
// shape4.isTextBox() 回傳 false
```

## **為文字方塊新增欄位**

Aspose.Slides 提供了 [ColumnCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 與 [ColumnSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) 屬性（來自 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat) 介面與 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat) 類別），讓您能在文字方塊中新增欄位。您可以指定文字方塊的欄位數量，並設定欄位間的點數間距。 

以下的 Java 程式碼示範上述操作： 

```java
Presentation pres = new Presentation();
try {
    // 取得簡報中的第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增 AutoShape，類型設定為 Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 為 Rectangle 新增 TextFrame
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // 取得 TextFrame 的文字格式
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // 指定 TextFrame 中的欄位數量
    format.setColumnCount(3);

    // 指定欄位之間的間距
    format.setColumnSpacing(10);

    // 儲存簡報
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **為文字框新增欄位**
Aspose.Slides for Java 提供了 [ColumnCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 屬性（來自 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat) 介面），讓您能在文字框中新增欄位。藉由此屬性，您可指定文字框中想要的欄位數量。 

以下的 Java 程式碼示範如何在文字框內新增欄位：

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

## **更新文字**

Aspose.Slides 允許您變更或更新文字方塊內的文字，或整份簡報中的所有文字。 

以下的 Java 程式碼示範將簡報中所有文字更新或變更的操作：

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //檢查形狀是否支援文字框 (IAutoShape)。
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //遍歷文字框中的段落
                {
                    for (IPortion portion : paragraph.getPortions()) //遍歷段落中的每個 Portion
                    {
                        portion.setText(portion.getText().replace("years", "months")); //變更文字
                        portion.getPortionFormat().setFontBold(NullableBool.True); //變更格式
                    }
                }
            }
        }
    }

    //儲存已修改的簡報
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **為文字方塊加入超連結** 

您可以在文字方塊內插入連結。當點擊文字方塊時，使用者會被導向開啟該連結。 

若要新增包含連結的文字方塊，請依照以下步驟操作：

1. 建立 `Presentation` 類別的實例。 
2. 取得新建立的簡報中第一張投影片的參照。 
3. 在投影片的指定位置新增 `AutoShape` 物件，將 `ShapeType` 設為 `Rectangle`，並取得新新增的 AutoShape 物件的參照。 
4. 為 `AutoShape` 物件新增 `TextFrame`，其預設文字為 *Aspose TextBox*。 
5. 實例化 `IHyperlinkManager` 類別。 
6. 將 `IHyperlinkManager` 物件指派給與 `TextFrame` 中您選擇的文字段落相關的 [HyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Shape#getHyperlinkClick--) 屬性。 
7. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。 

以下的 Java 程式碼—上述步驟的實作範例—示範如何在投影片中加入帶有超連結的文字方塊：

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得簡報中的第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增 AutoShape 物件，類型設定為 Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // 將形狀轉型為 AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // 取得與 AutoShape 相關的 ITextFrame 屬性
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // 為框架新增文字
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 為 Portion 文字設定超連結
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // 儲存 PPTX 簡報
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**在使用母片時，文字方塊與文字佔位符有何不同？**

文字[佔位符](/slides/zh-hant/java/manage-placeholder/)繼承自 [母片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterslide/)的樣式/位置，且可在 [版面配置](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslide/) 上被覆寫，而普通文字方塊是特定投影片上的獨立物件，切換版面配置時不會改變。 

**如何在整份簡報中批次取代文字，同時避免影響圖表、表格與 SmartArt 內的文字？**

將遍歷範圍限制於具有文字框的自動圖形，並排除嵌入式物件（[圖表](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/)、[表格](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/smartart/)），可分別遍歷它們的集合或直接跳過這些物件類型。