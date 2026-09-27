---
title: 在 Node.js via .NET 中管理簡報文字
linktitle: 管理文字
type: docs
weight: 50
url: /zh-hant/nodejs-net/manage-text/
keywords:
- 文字
- 文字方塊
- 新增文字
- 變更文字
- 格式化文字
- 字型大小
- 粗體文字
- 文字框
- 段落
- 部分
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides for Node.js via .NET，於投影片新增文字方塊，然後變更其文字、字型大小與粗體樣式。"
---
## **概觀**

在 Aspose.Slides 中，投影片上的文字屬於形狀。自動形狀（例如矩形）具有文字框；文字框包含段落，而每個段落包含部分（portion），即具有相同格式的文字片段。您透過文字框變更文字，透過部分的格式屬性變更字型。

本範例會在投影片上新增文字方塊並儲存簡報，然後開啟已儲存的檔案，變更文字方塊的文字、字型大小與粗體樣式。

範例需要依照 [Installation](/slides/zh-hant/nodejs-net/installation/) 中的說明設定專案。將每個範例儲存為 `.js` 檔案於專案資料夾，並在該資料夾使用 `node` 執行。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET 沒有自己的 API 參考文件。它以 camelCase 名稱鏡射 Aspose.Slides for .NET API，因此本文中的 API 連結會指向相對應的類別與成員於 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/)。
{{% /alert %}}

## **新增文字方塊**

若要新增文字方塊，使用 [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) 方法在投影片上加入自動形狀，並使用 [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/) 方法設定文字。以下範例會在新簡報的第一張投影片加入一個矩形，並將簡報儲存為 `text-box.pptx`：

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置 (x, y) 與 大小 (width, height) 的單位為點。
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

`text-box.pptx` 中的投影片包含一個寬 500 點、高 80 點的矩形，文字為「Quarterly report」，使用預設字型與大小。下一個範例會變更此文字方塊。

## **變更文字及其格式設定**

以下範例會開啟先前建立的 `text-box.pptx`，取得第一張投影片的第一個形狀。圖片與表格等形狀沒有文字框， therefore 範例會先檢查形狀是否為 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) 再使用其 [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/)。接著執行以下操作：

1. 透過文字框的 [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) 屬性取代文字。此後，文字框只包含一個段落與一個部分。
2. 從 [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) 與 [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) 集合中取得該部分，並讀取其 [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/)。
3. 設定 [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)，即字型點數大小；以及 [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/)，其接受一個 [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 值。

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

在 `text-box-updated.pptx` 中，文字方塊顯示「Quarterly report: third quarter」，字型為粗體 32 點。由於新文字只是一個部分，兩個格式屬性會套用於全部文字。未授權時，每次儲存都會加入評估水印。因為 `text-box.pptx` 本身已以評估模式儲存，`text-box-updated.pptx` 會包含兩個水印；詳情請參閱 [Evaluate Aspose.Slides](/slides/zh-hant/nodejs-net/evaluate-aspose-slides/)。

## **常見問題**

**為什麼 `fontBold` 需要 `NullableBool` 值，而不是 `true` 或 `false`？**

部分可以保留屬性未定義，並從段落、形狀或投影片的版面配置與母片繼承。`NullableBool.NotDefined` 代表「繼承」，而 `NullableBool.True` 與 `NullableBool.False` 則會覆寫繼承值。直接指定 `true` 或 `false` 會拋出錯誤。出於相同原因，當部分繼承字型大小時，`fontHeight` 會回傳 `NaN`。

**如何變更文字顏色？**

設定部分格式的填充：將 `FillType.Solid` 指派給 `portionFormat.fillFormat.fillType`，再將顏色（例如 `"#FF0000"`）指派給 `portionFormat.fillFormat.solidFillColor.color`。別忘了在匯入套件時加入 `FillType`。

**如何只格式化文字的一部份？**

格式屬於部分，因此將想要格式化的文字放入獨立的部分。使用 `Portion.CreatePortionFromText` 建立部分，透過段落的 `portions` 集合的 `add` 方法加入段落，然後設定新部分的 `portionFormat`。匯入套件時請加入 `Portion`。

**為什麼讀取文字時會出現「... text has been truncated due to evaluation version limitation」？**

未授權時，Aspose.Slides 僅會回傳任意較長文字的前五個字元，例如 `textFrame.text`，其後會附加此訊息。寫入的文字會完整儲存。請依照 [Licensing](/slides/zh-hant/nodejs-net/licensing/) 中的說明套用授權，以讀取完整文字。