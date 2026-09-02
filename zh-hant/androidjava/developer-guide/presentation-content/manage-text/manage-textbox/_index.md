---
title: 在 Android 上管理簡報中的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java 讓您輕鬆在 PowerPoint 和 OpenDocument 檔案中建立、編輯與複製文字方塊，提升簡報自動化的效能。"
---
## **簡介**

投影片上的文字通常位於文字方塊或圖形中。因此，要在投影片上新增文字，必須先加入文字方塊，然後將文字放入該文字方塊。Aspose.Slides for Android via Java 提供了 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape) 介面，允許您新增包含文字的圖形。

{{% alert title="Info" color="info" %}}

Aspose.Slides 也提供了 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape) 介面，允許您將圖形新增至投影片。但並非所有透過 `IShape` 介面新增的圖形都能容納文字。而透過 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape) 介面新增的圖形可能包含文字。

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

因此，當處理想要加入文字的圖形時，您可能需要檢查並確認它是透過 `IAutoShape` 介面轉型的。只有這樣，您才能使用 `IAutoShape` 下的屬性 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrame)。請參閱本頁面的 [Update Text](https://docs.aspose.com/slides/zh-hant/androidjava/manage-textbox/#update-text) 章節。

{{% /alert %}}

## **在投影片上建立文字方塊**

建立文字方塊的步驟如下：

1. 建立 `Presentation` 類別的實例。  
2. 取得新建立的簡報中第一張投影片的參照。  
3. 在投影片的指定位置加入一個 `ShapeType` 設為 `Rectangle` 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape) 物件，並取得新加入的 `IAutoShape` 物件的參照。  
4. 為 `IAutoShape` 物件新增 `TextFrame` 屬性以容納文字。以下範例中，我們加入的文字為 *Aspose TextBox*。  
5. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。  

以下 Java 程式碼實作上述步驟，示範如何在投影片上加入文字：

```java
import com.aspose.slides.*;

// 建立 Presentation 實例
Presentation pres = new Presentation();
try {
    // 取得簡報中的第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增一個類型為 Rectangle 的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 為 Rectangle 新增 TextFrame
    ashp.addTextFrame(" ");

    // 存取文字框
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

Aspose.Slides 透過 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 介面提供 [isTextBox](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#isTextBox--) 方法，讓您檢視圖形並辨識文字方塊。

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

請注意，如果您僅使用 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/) 介面的 `addAutoShape` 方法加入自動圖形，該自動圖形的 `isTextBox` 方法會傳回 `false`。但在使用 `addTextFrame` 方法或 `setText` 方法為自動圖形加入文字後，`isTextBox` 屬性會傳回 `true`。

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

## **尋找擁有 TextFrame 的圖形**

在一般文字處理程式碼中，您可能會收到一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)，卻不知道它屬於哪個簡報物件。請使用 [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#getParentShape--) 方法回溯至擁有者 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/)。

對於屬於 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 或其他含文字圖形的文字框，`ITextFrame.getParentShape` 會傳回擁有者，而 `ITextFrame.getParentCell` 會傳回 `null`。兩個方法皆提供唯讀的導向功能，不會改變所有權。存取圖形前請先檢查回傳值是否為 `null`。

欲取得完整範例，包含識別圖形與表格儲存格擁有者（亦涵蓋與 SmartArt 節點相關的圖形），請參考 [搜尋與取代文字](/slides/zh-hant/androidjava/search-and-replace-text/)。

## **為文字方塊加入欄位**

Aspose.Slides 提供了來自 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrameFormat) 介面與 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat) 類別的 [ColumnCount](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 與 [ColumnSpacing](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) 屬性，允許您為文字方塊新增欄位。您可以指定文字方塊的欄位數量，並設定欄位間的點距。

以下 Java 程式碼示範上述操作：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 取得簡報中的第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增一個類型為 Rectangle 的 AutoShape
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

## **為文字框加入欄位**

Aspose.Slides for Android via Java 提供了來自 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrameFormat) 介面的 [ColumnCount](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 屬性，允許您在文字框中加入欄位。透過此屬性，您可以指定文字框的欄位數量。

以下 Java 程式碼示範如何在文字框內加入欄位：

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

## **更新文字**

Aspose.Slides 允許您變更或更新文字方塊中的文字，或是整份簡報中所有的文字。

以下 Java 程式碼示範一次性更新簡報中所有文字的操作：

```java
import com.aspose.slides.*;

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
                    for (IPortion portion : paragraph.getPortions()) //遍歷段落中的每個部分
                    {
                        portion.setText(portion.getText().replace("years", "months")); //變更文字
                        portion.getPortionFormat().setFontBold(NullableBool.True); //變更格式
                    }
                }
            }
        }
    }

    //儲存修改後的簡報
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **為文字方塊加入超連結** 

您可以在文字方塊內插入連結。當使用者點擊文字方塊時，會導向開啟該連結。

要建立包含連結的文字方塊，請依照以下步驟執行：

1. 建立 `Presentation` 類別的實例。  
2. 取得新建立的簡報中第一張投影片的參照。  
3. 在投影片的指定位置加入 `ShapeType` 設為 `Rectangle` 的 `AutoShape` 物件，並取得新加入的 AutoShape 物件的參照。  
4. 為 `AutoShape` 物件新增 `TextFrame`，並設定其第一段文字的內容。以下範例使用的文字為 *Aspose.Slides*。  
5. 從目標段落的 `PortionFormat` 取得 [IHyperlinkManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkmanager/) 物件。  
6. 在該物件上呼叫 [setExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)，設定點擊文字時要開啟的連結。  
7. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。  

以下 Java 程式碼實作上述步驟，示範如何為投影片加入含超連結的文字方塊：

```java
import com.aspose.slides.*;

// 實例化一個代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得簡報中的第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增一個類型為 Rectangle 的 AutoShape 物件
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // 將形狀轉型為 AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // 存取與 AutoShape 相關聯的 ITextFrame 屬性
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // 在文字框中加入一些文字
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 設定文字段落的超連結
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

**在使用主投影片時，文字方塊與文字占位符有何差異？**

[placeholder](/slides/zh-hant/androidjava/manage-placeholder/) 會從 [master](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/masterslide/) 繼承樣式/位置，且可在 [layouts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/layoutslide/) 上覆寫；而一般文字方塊則是特定投影片上的獨立物件，切換版面配置時不會變化。

**如何在不影響圖表、表格與 SmartArt 內文字的前提下，批次取代簡報中的文字？**

將遍歷範圍限制於具有文字框的自動圖形，並排除嵌入式物件（如 [charts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/smartart/)），可分別遍歷其集合或直接跳過這些類型的物件。