---
title: 在 Android 上的簡報中管理文字方塊
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
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 與 OpenDocument 簡報中建立、識別、格式化與更新文字方塊。"
---
## **Introduction**

在 Aspose.Slides for Android via Java 中，投影片文字儲存在屬於形狀的文字框中。[IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 介面代表最常見的承載文字的形狀，並透過 [IAutoShape.getTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) 方法取得其文字。

{{% alert color="info" title="Note" %}}
每個自動形狀皆實作 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/)，但並非所有形狀都是自動形狀或支援文字框。處理現有簡報時，請先檢查形狀是否實作 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)，才可存取其文字。
{{% /alert %}}

## **Create a Text Box on a Slide**

要建立文字方塊，需要在投影片上新增自動形狀、於其文字框加入文字，然後儲存簡報。以下範例建立一個矩形文字方塊：

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

傳遞給 [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 的座標與尺寸以點 (point) 為單位。 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 會使用提供的文字初始化文字框。

## **Check for a Text Box Shape**

使用 [IAutoShape.isTextBox](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#isTextBox--) 方法判斷自動形狀是否被視為文字方塊。當簡報同時包含承載文字與純圖形的自動形狀時，這非常有用。

![A text box and a shape](istextbox.png)

以下範例會檢查簡報中的每一個自動形狀：

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

新加入的自動形狀在未包含非空文字前不會被視為文字方塊。您可以透過 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 或 [ITextFrame.setText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) 來提供文字。將空字串加入或指派給文字框會使 [IAutoShape.isTextBox](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/#isTextBox--) 回傳 `false`：

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

前兩次呼叫印出 `true`，後兩次印出 `false`。

## **Find the Shape That Owns a Text Frame**

通用的文字處理程式碼可能只取得一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)，卻不知道是哪個簡報物件擁有它。使用唯讀的 [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#getParentShape--) 方法可回溯至其所屬的 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/)。

對於由自動形狀或其他承載文字的形狀所擁有的文字框，[ITextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#getParentShape--) 會回傳擁有者，而 [ITextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#getParentCell--) 會回傳 `null`。在存取之前請先檢查回傳值。若需同時辨識形狀與表格儲存格的擁有者（包括與 SmartArt 節點相關聯的形狀），請參閱 [Search and Replace Text](/slides/zh-hant/androidjava/search-and-replace-text/)。

## **Add Columns to a Text Box**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) 方法會將文字框劃分為多個欄位，而 [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) 則以點為單位設定欄位之間的間距。這兩個設定皆屬於 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/)，可透過現有文字方塊的文字框進行變更。文字會在同一個形狀內的欄位之間重新換行，而不會流入其他形狀。

以下範例建立一個三欄文字方塊，欄間距為 10 點，儲存簡報，並從輸出檔案中讀回設定：

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

## **Extract Text from Individual Columns**

使用 [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) 可取得既有文字框中每個可視欄位的文字。此方法會依欄位閱讀順序回傳每個欄位的一個字串。單欄文字框會產生僅含一個元素的陣列，空欄位則以空字串表示。回傳的字串僅包含純文字；不會保留段落層級的格式設定。

此功能在以下情況下特別有用：

- 需要保留欄位閱讀順序的文字擷取。
- 索引或比較多欄投影片的內容。
- 將每個欄位匯出至不同檔案、資料庫欄位或其他目的地。
- 檢查在變更 [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-)、[ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-)、字型或文字框尺寸後，文字如何重新分配。

此方法僅報告目前 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 內的文字分布；不會自動將文字在不同形狀或文字方塊之間流動。欄位分布可能受可用字型與其他排版設定影響，若結果一致性很重要，請確保所需字型已安裝。

以下範例載入簡報，尋找第一個具多欄文字框的自動形狀，讀取其欄數，並將每個欄位的文字寫入個別檔案。沒有文字框的形狀會被略過。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

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
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Update Text**

若要在整本簡報中更新文字，請遍歷投影片與形狀，挑選自動形狀，然後編輯其文字段落。以段落層級操作可同時變更文字與字元格式。

以下範例將自動形狀文字中的所有 `years` 替換為 `months`，並將受影響的段落設為粗體：

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

此遍歷僅會更新自動形狀中的文字。儲存在表格、圖表、SmartArt 或群組形狀中的文字需要對那些物件各自的集合進行遍歷。

## **Add a Text Box with a Hyperlink**

超連結可以指派給特定的文字段落，只有該段文字會成為可點擊的連結。使用 [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) 可將段落與外部 URL 相關聯。

以下範例建立帶有超連結的文字，並將其儲存至簡報：

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

**What is the difference between a text box and a text placeholder on a master or layout slide?**  
占位符（[placeholder](/slides/zh-hant/androidjava/manage-placeholder/)）可以從母片投影片或版面投影片繼承位置與格式。普通的文字方塊則是建立於當前投影片上的獨立形狀，版面變更時不會取得占位符的行為。

**How can I replace text without changing text in charts, tables, or SmartArt?**  
將遍歷範圍限制在實作 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 的形狀，如「更新文字」範例所示。圖表、表格與 SmartArt 以各自的物件模型存放文字，因而不會被該迴圈修改。