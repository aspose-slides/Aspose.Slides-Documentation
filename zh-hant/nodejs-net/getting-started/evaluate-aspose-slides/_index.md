---
title: 評估 Aspose.Slides
type: docs
weight: 120
url: /zh-hant/nodejs-net/evaluate-aspose-slides/
keywords:
- 評估 Aspose.Slides
- 評估版
- 評估浮水印
- 試用限制
- 暫時授權
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET 的評估版限制說明，並提供示範腳本展示兩項限制以及如何透過授權移除它們。"
---
## **概觀**

Aspose.Slides for Node.js via .NET 的評估版與授權版使用相同的 npm 套件。未取得授權時，它會以評估模式執行：所有功能皆可使用，但已儲存的簡報與大多數匯出檔案會帶有浮水印，且程式讀回的文字會被截斷。本文說明這兩項限制，並展示如何移除它們。

## **評估限制**

**每張投影片都有評估浮水印。** 當您在未授權的情況下儲存簡報時，Aspose.Slides 會在已儲存檔案的每張投影片中間加入一個文字方塊。該文字方塊被鎖定，內容為「Evaluation only.」後接產品行與版權行。浮水印寫入已儲存的檔案，而不是記憶體中的簡報，開啟簡報時不會新增浮水印。但已在評估模式儲存過的檔案本身已包含此文字方塊，若再次開啟並儲存，則每張投影片會再多出第二個浮水印。

相同的浮水印也會在匯出為 PDF、XPS 或 HTML，或將投影片渲染為影像時繪製。如果渲染的簡報本身已在評估模式儲存過，影像會同時顯示已儲存的浮水印與渲染時產生的浮水印。

**程式讀取文字時被截斷。** 透過文字框、段落或部份的 `text` 屬性讀取的文字會被截斷為前五個字元，後接「... text has been truncated due to evaluation version limitation.」的通知。五個字元或以下的文字會完整返回。此限制適用於每張投影片，甚至您剛剛指派的文字也會被截斷。Markdown 與 HTML5 匯出同樣會被截斷。

程式寫入的文字會完整保存：PPTX 檔案、PDF 頁面與投影片影像皆包含完整文字。

## **在腳本中查看限制**

以下腳本示範兩項限制。它假設您已依照[安裝](/slides/zh-hant/nodejs-net/installation/)說明安裝套件，且從專案資料夾執行。腳本會在第一張投影片加入一個帶有句子的矩形，讀回該句子，將簡報另存為 `evaluation.pptx`，然後重新開啟檔案以計算投影片上的圖形數量。

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // 未取得授權時，只會返回前五個字元。
    console.log("Text read back:", rectangle.textFrame.text);

    // 儲存時會在檔案的每張投影片上加入評估浮水印。
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // 投影片現在包含矩形與浮水印文字方塊。
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

未取得授權時，腳本會輸出：

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

第二個圖形即為浮水印文字方塊。開啟 `evaluation.pptx` 可看到矩形內的完整句子以及投影片中間的浮水印。

## **移除限制**

要同時移除這兩項限制，請於建立任何 `Presentation` 物件之前先套用授權。請參閱[授權](/slides/zh-hant/nodejs-net/licensing/)了解如何套用授權檔案。

{{% alert color="success" title="Tip" %}}
若想在購買前測試 Aspose.Slides 且不受評估限制影響，可申請免費的**30 天暫時授權**。細節請見[如何取得暫時授權？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **常見問題**

**評估模式會限制投影片數量嗎？**

不會。簡報會完整建立、開啟與儲存，所有投影片皆保留。浮水印與文字截斷會套用於每張投影片。

**為什麼匯出的投影片影像會顯示兩次浮水印？**

因為在渲染之前，簡報已在評估模式儲存過，內部已包含一個浮水印文字方塊；渲染時未授權會再繪製一次浮水印，故出現兩次。

**我可以在評估模式下檢查程式產生的文字是否正確嗎？**

可以。開啟已儲存的檔案或匯出的 PDF，裡面的文字都是完整的。只有程式讀回的文字，以及 Markdown 或 HTML5 輸出會被截斷。