---
title: 以 JavaScript 從簡報匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/nodejs-java/exporting-math-equations/
keywords:
- 匯出數學方程式
- MathML
- LaTeX
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 與 Aspose.Slides for Node.js，輕鬆將 PowerPoint 中的數學方程式匯出為 MathML，保留格式並提升相容性。"
---
## **簡介**

Aspose.Slides 允許您從簡報中匯出數學方程式。例如，您可能需要擷取投影片（特定簡報）上的數學方程式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 
您可以將方程式匯出為 MathML，這是一種在網路上以及許多應用程式中常見的數學方程式與類似內容的流行格式或標準。
{{% /alert %}}

## **將數學方程式儲存為 MathML**

雖然人類可以輕鬆編寫 LaTeX 等某些方程式格式的程式碼，但對於 MathML 卻較為困難，因為後者應由應用程式自動產生。程式可以輕鬆讀取與解析 MathML，因為它的程式碼是 XML 格式，故 MathML 在許多領域普遍作為輸出與列印格式使用。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**匯出至 MathML 的實際內容是什麼—段落還是單一公式區塊？**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathblock/)）匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**我如何判斷投影片上的物件是數學公式而非普通文字或圖像？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathportion/) 中，且具有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathparagraph/)。沒有 [MathParagraph] 的圖像或普通文字區段無法匯出為公式。

**簡報中的 MathML 來源為何—是 PowerPoint 專屬還是標準？**

匯出針對的是標準的 MathML（XML）。Aspose 使用 Presentation MathML——標準的呈現子集，已廣泛於各種應用程式與網路上使用。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，若這些物件的文字區段包含 [MathParagraph]（即真正的 PowerPoint 公式），則會被匯出。若公式以影像形式嵌入，則不會被匯出。

**匯出為 MathML 會修改原始簡報檔案嗎？**

不會。寫入 MathML 只是將公式內容序列化，並不會更改簡報檔案本身。