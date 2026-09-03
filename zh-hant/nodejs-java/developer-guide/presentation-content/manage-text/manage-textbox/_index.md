---
title: 使用 JavaScript 管理簡報中的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/nodejs-java/manage-textbox/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 與 OpenDocument 簡報中建立、辨識、格式化與更新文字方塊。"
---
## **簡介**

在 Aspose.Slides for Node.js via Java 中，投影片文字儲存在屬於形狀的文字框中。AutoShape 類別表示最常見的帶文字形狀，並透過 AutoShape.getTextFrame 方法公開其文字。

{{% alert color="info" title="Note" %}}
每個自動形狀皆繼承自 Shape，但並非所有形狀都是自動形狀或支援文字框。在處理現有簡報時，請先確認形狀是 AutoShape 的實例，再存取其文字。
{{% /alert %}}

## **在投影片上建立文字方塊**

若要建立文字方塊，先在投影片上加入自動形狀，於其文字框中加入文字，然後儲存簡報。以下範例建立一個矩形文字方塊：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

傳遞給 ShapeCollection.addAutoShape 的座標與尺寸以點 (points) 為單位。AutoShape.addTextFrame 會以提供的文字初始化文字框。

## **檢查文字方塊形狀**

使用 AutoShape.isTextBox 方法判斷自動形狀是否被視為文字方塊。當簡報同時包含帶文字的自動形狀與純圖形自動形狀時，此方法相當有用。

![文字方塊與形狀](istextbox.png)

以下範例會檢查簡報中的每個自動形狀：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

新加入的自動形狀在未包含非空文字之前不會被視為文字方塊。您可以透過 AutoShape.addTextFrame 或 TextFrame.setText 來提供文字。將空字串指定給文字框會使 AutoShape.isTextBox 傳回 `false`：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

前兩次呼叫會印出 `true`；最後兩次則印出 `false`。

## **找出擁有文字框的形狀**

通用的文字處理程式碼可能只收到一個 TextFrame，卻不知道是哪個簡報物件擁有它。使用唯讀的 TextFrame.getParentShape 方法即可回到其擁有者 Shape。

對於由自動形狀或其他帶文字形狀擁有的文字框，TextFrame.getParentShape 會回傳擁有者，而 TextFrame.getParentCell 會回傳 `null`。在存取之前請先檢查返回值。若要辨識形狀與表格儲存格的擁有者（包括與 SmartArt 節點相關的形狀），請參閱 [Search and Replace Text](/slides/zh-hant/nodejs-java/search-and-replace-text/)。

## **為文字方塊新增欄位**

TextFrameFormat.setColumnCount 方法可將文字框分割成多個欄位，而 TextFrameFormat.setColumnSpacing 則設定欄位之間的間距（以點為單位）。這兩個設定屬於 TextFrameFormat，可透過現有文字方塊的文字框進行變更。文字會在同一形狀內於欄位之間重新排列；不會流向其他形狀。

以下範例建立一個三欄文字方塊，欄位間距為 10 點，儲存簡報後再讀取輸出檔案中的設定：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **從各欄位中擷取文字**

使用 TextFrame.splitTextByColumns 可取得現有文字框中每個視覺欄位所分配的文字。此方法會依欄位閱讀順序回傳每個欄位的字串。單欄文字框會產生僅含一個元素的陣列，空欄位則以空字串表示。回傳的字串僅包含純文字，不保留段落層級的格式設定。

此功能適用於以下情境：

- 以欄位閱讀順序擷取文字。
- 索引或比較多欄投影片的內容。
- 將每個欄位匯出至單獨的檔案、資料庫欄位或其他目的地。
- 觀察在變更欄位數 (TextFrameFormat.setColumnCount)、欄位間距 (TextFrameFormat.setColumnSpacing)、字型或文字框大小後，文字如何重新分配。

此方法僅回報目前 TextFrame 內的文字分布，不會自動在不同形狀或文字方塊之間流動。欄位分布可能受可用字型與其他文字版面設定影響，若結果的一致性很重要，請確保所需字型已安裝。

以下範例載入簡報，找到第一個具有多欄文字框的自動形狀，讀取其設定的欄位數，並將每個欄位的文字寫入單獨檔案。未提供文字框的形狀會被略過。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **更新文字**

若要在整份簡報中更新文字，請遍歷投影片與形狀，選取自動形狀，然後編輯其文字段落。於段落層級進行操作可同時變更文字與字元格式。

以下範例將所有自動形狀文字中的 `years` 替換為 `months`，並將受影響的段落設為粗體：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此遍歷僅會更新自動形狀內的文字。表格、圖表、SmartArt 或群組形狀中儲存的文字需自行遍歷其對應的集合。

## **新增帶超連結的文字方塊**

超連結可指派給特定文字段落，僅讓該段文字具備可點擊的連結。使用 HyperlinkManager.setExternalHyperlinkClick 可將段落與外部 URL 連結。

以下範例建立帶超連結的文字並儲存至簡報：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**文字方塊與母版或版面投影片上的文字佔位符有何差異？**

[placeholder](/slides/zh-hant/nodejs-java/manage-placeholder/) 可以繼承自 [master slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) 或 [layout slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/) 的位置與格式。一般的文字方塊則是獨立於建立所在投影片的形狀，版面變更時不會取得佔位符行為。

**如何在不更動圖表、表格或 SmartArt 文字的情況下替換文字？**

如同「更新文字」範例所示，將遍歷限制在 AutoShape 實例上。圖表、表格與 SmartArt 皆在各自的物件模型中儲存文字，故不會被此迴圈修改。