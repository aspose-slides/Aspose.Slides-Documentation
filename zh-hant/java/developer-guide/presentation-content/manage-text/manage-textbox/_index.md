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
description: "在 PowerPoint 和 OpenDocument 簡報中使用 Aspose.Slides for Java 建立、識別、格式化與更新文字方塊。"
---
## **Introduction**

在 Aspose.Slides for Java 中，投影片文字儲存在屬於圖形的文字框中。 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 介面代表最常見的承載文字的圖形，並透過 [IAutoShape.getTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#getTextFrame--) 方法公開其文字。

{{% alert color="info" title="Note" %}}
每個自動圖形皆實作 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/)，但並非所有圖形都是自動圖形或支援文字框。處理現有簡報時，請先確認圖形是否實作 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 再存取其文字。
{{% /alert %}}

## **Create a Text Box on a Slide**

若要建立文字方塊，請在投影片上加入自動圖形，將文字加入其文字框，並儲存簡報。以下範例建立一個矩形文字方塊：

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

傳遞給 [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 的座標與尺寸以點為單位。 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 會以提供的文字初始化文字框。

## **Check for a Text Box Shape**

使用 [IAutoShape.isTextBox](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#isTextBox--) 方法可判斷自動圖形是否被視為文字方塊。當簡報同時包含承載文字與純圖形的自動圖形時，這很有用。

![文字方塊與圖形](istextbox.png)

以下範例檢查簡報中的每個自動圖形：

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

新加入的自動圖形在未含非空文字前不會被視為文字方塊。可透過 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 或 [ITextFrame.setText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#setText-java.lang.String-) 提供文字。加入或指派空字串會使 [IAutoShape.isTextBox](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/#isTextBox--) 回傳 `false`：

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

前兩次呼叫會輸出 `true`；最後兩次會輸出 `false`。

## **Find the Shape That Owns a Text Frame**

通用的文字處理程式碼可能會取得一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 而不知道它屬於哪個簡報物件。使用唯讀的 [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentShape--) 方法可返回其擁有者 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/)。

若文字框屬於自動圖形或其他承載文字的圖形，則 [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentShape--) 會回傳擁有者，而 [ITextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentCell--) 會回傳 `null`。在存取之前請先檢查返回值。若想同時辨識圖形與表格儲存格的擁有者（包括與 SmartArt 節點相關的圖形），請參閱 [Search and Replace Text](/slides/zh-hant/java/search-and-replace-text/)。

## **Add Columns to a Text Box**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) 方法將文字框分割為多欄，而 [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) 則設定欄與欄之間的間距（以點為單位）。這兩項設定屬於 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/)，可透過現有文字方塊的文字框進行變更。文字會在同一圖形內的欄之間重新排版；不會延伸至其他圖形。

以下範例建立一個三欄文字方塊，欄間距為 10 點，儲存簡報，並從輸出檔案讀回儲存的設定：

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

使用 [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#splitTextByColumns--) 可取得既有文字框中每個可視欄位的文字。此方法會依欄位的閱讀順序為每個欄位回傳一個字串。單欄的文字框會產生僅含一個元素的陣列，空欄位則以空字串表示。回傳的字串僅包含純文字，段落層級的格式不會保留。

此功能在需要以下情況時相當有用：

- 在保留欄位閱讀順序的同時擷取文字。
- 索引或比較多欄投影片的內容。
- 將每個欄位匯出至不同的檔案、資料庫欄位或其他目的地。
- 檢查在使用 [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) 更改欄數、[ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) 調整間距、修改字型或文字框大小後，文字如何重新分配。

此方法回報的是目前 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 內的文字分布；不會自動將文字流向不同的圖形或文字方塊。欄位的分布可能受可用字型及其他文字排版設定影響，若需一致的結果，請確保必要的字型已安裝。

以下範例載入簡報，找出第一個具有文字框的多欄自動圖形，讀取其設定的欄數，並將每個欄位的文字寫入個別檔案。未提供文字框的圖形會被略過。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
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

若要在整個簡報中更新文字，請遍歷投影片與圖形，選取自動圖形，然後編輯其文字段落。於段落層級操作可同時變更文字與字元格式。

以下範例將自動圖形文字中所有出現的 `years` 替換為 `months`，並將每個受影響的段落設為粗體：

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

此遍歷僅更新自動圖形中的文字。儲存在表格、圖表、SmartArt 或群組圖形中的文字需遍歷各自的集合。

## **Add a Text Box with a Hyperlink**

可將超連結指派給特定的文字段落，僅該段文字會成為可點擊的連結。使用 [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) 可將段落與外部 URL 相關聯。

以下範例建立帶有連結的文字並將其儲存至簡報：

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

**文字方塊與母片或版面投影片上的文字佔位符有何差異？**

[placeholder](/slides/zh-hant/java/manage-placeholder/) 可以從 [master slide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterslide/) 或 [layout slide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslide/) 繼承其位置與格式。一般的文字方塊則是建立於所在投影片的獨立圖形，版面變更時不會取得佔位符的行為。

**如何在不更改圖表、表格或 SmartArt 文字的情況下取代文字？**

將遍歷限制在實作 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 的圖形上，如同「Update Text」範例所示。圖表、表格與 SmartArt 在各自的物件模型中儲存文字，因此不會受到此迴圈的影響。