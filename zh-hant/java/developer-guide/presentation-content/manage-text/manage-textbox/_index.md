---
title: 使用 Java 管理簡報中的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/java/manage-textbox/
keywords:
- 文字方塊
- 文字框架
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
description: "Aspose.Slides for Java 讓您輕鬆在 PowerPoint 與 OpenDocument 檔案中建立、編輯與複製文字方塊，提升簡報自動化的效率。"
---
## **簡介**

投影片上的文字通常存在於文字方塊或圖形中。因此，要在投影片上加入文字，必須先新增文字方塊，然後在文字方塊中放入文字。Aspose.Slides for Java 提供的[IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)介面，允許您新增包含文字的圖形。

{{% alert title="Info" color="info" %}}
Aspose.Slides 也提供[IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape)介面，允許您向投影片新增圖形。然而，透過`IShape`介面新增的圖形並非全部都能容納文字。但透過[IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)介面新增的圖形可能包含文字。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
因此，當處理想要加入文字的圖形時，您可能需要檢查並確認它是透過`IAutoShape`介面轉型的。只有這樣才可以使用屬於`IAutoShape`的[TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrame)。請參閱本頁面的[Update Text](https://docs.aspose.com/slides/zh-hant/java/manage-textbox/#update-text)部分。 
{{% /alert %}}

## **在投影片上建立文字方塊**

若要在投影片上建立文字方塊，請依照以下步驟：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation)類別的實例。 
2. 取得新建立簡報中第一張投影片的參考。 
3. 在投影片上指定位置新增一個將[ShapeType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryShape#setShapeType-int-)設定為`Rectangle`的[IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)物件，並取得新新增的`IAutoShape`物件的參考。 
4. 在`IAutoShape`物件上新增`TextFrame`屬性以容納文字。在下例中，我們加入的文字為：*Aspose TextBox* 
5. 最後，透過`Presentation`物件寫入 PPTX 檔案。 

```java
import com.aspose.slides.*;

// 建立 Presentation 實例
Presentation pres = new Presentation();
try {
    // 取得簡報中的第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增型別設定為 Rectangle 的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 為 Rectangle 新增 TextFrame
    ashp.addTextFrame(" ");

    // 取得文字框架
    ITextFrame txtFrame = ashp.getTextFrame();

    // 為文字框架建立 Paragraph 物件
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

## **檢查是否為文字方塊圖形**

Aspose.Slides 從[IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)介面提供[isTextBox](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/#isTextBox--)方法，讓您能檢查圖形並辨識文字方塊。

![Text box and shape](istextbox.png)

以下 Java 程式碼示範如何檢查圖形是否以文字方塊建立：

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

請注意，如果僅使用[IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/)介面的`addAutoShape`方法新增自動圖形，該自動圖形的`isTextBox`方法會回傳`false`。但是，若使用`addTextFrame`方法或`setText`方法為自動圖形新增文字，`isTextBox`屬性會回傳`true`。

```java
import com.aspose.slides.*;

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

## **找出擁有 TextFrame 的圖形**

在一般的文字處理程式碼中，您可能會取得一個[ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)而尚未知道是哪個簡報物件所擁有。使用[ITextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentShape--)方法可回溯至擁有它的[IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/)。

對於屬於[IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)或其他包含文字的圖形的文字框，[ITextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentShape--)會回傳擁有者，而[ITextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentCell--)會回傳`null`。這兩個方法僅提供唯讀的導覽，因此呼叫它們不會改變所有權。存取圖形前務必先檢查回傳值是否為`null`。

欲取得完整範例以辨識圖形與表格儲存格的擁有者（包括與 SmartArt 節點相關的圖形），請參考[Search and Replace Text](/slides/zh-hant/java/search-and-replace-text/)。

## **在文字方塊中新增欄**

Aspose.Slides 提供[ColumnCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)與[ColumnSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-)屬性（來自[ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat)介面與[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat)類別），允許您在文字方塊中新增欄。您可以指定文字方塊的欄數，並設定欄與欄之間的點數間距。

以下 Java 程式碼示範上述操作：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 取得簡報中的第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增型別設定為 Rectangle 的 AutoShape
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 為 Rectangle 新增 TextFrame
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // 取得 TextFrame 的文字格式
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // 指定 TextFrame 中的欄數
    format.setColumnCount(3);

    // 指定欄之間的間距
    format.setColumnSpacing(10);

    // 儲存簡報
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在文字框中新增欄**
Aspose.Slides for Java 提供[ColumnCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)屬性（來自[ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormat)介面），允許您在文字框中加入欄。透過此屬性，您可以指定文字框中希望的欄數。

以下 Java 程式碼示範如何在文字框內新增欄：

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
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
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **更新文字**

Aspose.Slides 允許您變更或更新文字方塊中的文字，或整個簡報中所有的文字。

以下 Java 程式碼示範一次更新或變更簡報中所有文字的操作：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // 檢查形狀是否支援文字框 (IAutoShape)。
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // 遍歷文字框中的段落
                {
                    for (IPortion portion : paragraph.getPortions()) // 遍歷段落中的每個 portion
                    {
                        portion.setText(portion.getText().replace("years", "months")); // 更改文字
                        portion.getPortionFormat().setFontBold(NullableBool.True); // 更改格式
                    }
                }
            }
        }
    }

    // 儲存已修改的簡報
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在文字方塊中加入超連結** 

您可以在文字方塊中插入連結。點擊文字方塊時，使用者會被導向開啟該連結。

若要新增含有連結的文字方塊，請依照以下步驟：

1. 建立`Presentation`類別的實例。 
2. 取得新建立簡報中第一張投影片的參考。 
3. 在投影片上指定位置新增一個將`ShapeType`設為`Rectangle`的`AutoShape`物件，並取得新新增的 AutoShape 物件的參考。 
4. 在`AutoShape`物件上新增`TextFrame`，其預設文字為*Aspose TextBox*。 
5. 實例化`IHyperlinkManager`類別。 
6. 將`IHyperlinkManager`物件指派給與您在`TextFrame`中選取部分相關的[HyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Shape#getHyperlinkClick--)屬性。 
7. 最後，透過`Presentation`物件寫入 PPTX 檔案。 

```java
import com.aspose.slides.*;

// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得簡報中的第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增型別設定為 Rectangle 的 AutoShape 物件
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // 將形狀轉型為 AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // 取得與 AutoShape 相關聯的 ITextFrame 屬性
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // 在框架中加入文字
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 為文字 portion 設定超連結
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // 儲存 PPTX 簡報
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**在使用母片時，文字方塊與文字佔位符有何差異？**

[placeholder](/slides/zh-hant/java/manage-placeholder/) 繼承自[master](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterslide/)的樣式/位置，且可在[layouts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslide/)上覆寫；相較之下，普通的文字方塊是特定投影片上的獨立物件，切換版面配置時不會改變。

**如何在整個簡報中批次取代文字，且不影響圖表、表格與 SmartArt 內的文字？**

將迭代限制在具有文字框的自動圖形，並透過分別遍歷或跳過以下嵌入物件（[charts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/smartart/)）的集合，以排除圖表、表格與 SmartArt 內的文字。