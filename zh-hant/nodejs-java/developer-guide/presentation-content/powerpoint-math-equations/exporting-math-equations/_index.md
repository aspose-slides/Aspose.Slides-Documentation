---
title: 在 JavaScript 中從簡報匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/nodejs-java/exporting-math-equations/
keywords:
- 匯出數學方程式
- 將方程式匯出為 LaTeX
- PowerPoint 轉 LaTeX
- MathML
- LaTeX
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 直接將 PowerPoint 簡報中的數學方程式匯出為 LaTeX 或 MathML（透過 Java）。"
---
## **簡介**

Aspose.Slides 允許您從簡報匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 
您可以直接將方程式匯出為 LaTeX 或 MathML，這是用於 Web 和許多應用程式的流行數學內容標準。
{{% /alert %}}

## **匯出數學方程式為 LaTeX**

Aspose.Slides 可以直接將 PowerPoint 數學方程式轉換為 LaTeX；不需要中間的 MathML 檔案或外部轉換器。數學方程式儲存在文字框中，作為 [MathPortion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathportion/)。使用 [MathPortion.getMathParagraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) 取得 [MathParagraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathparagraph/)，然後呼叫 [MathParagraph.toLatex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathparagraph/#toLatex--)。此方法會回傳一個字串，您可以將其儲存、顯示、傳送至其他應用程式，或進一步處理。

以下範例會檢查每一張投影片上的每個文字框，找出所有數學部分，並將每個方程式寫入單獨的 `.tex` 檔案：

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) 會返回投影片上找到的所有文字框。[MathPortion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathportion/) 類型檢查會將真正可編輯的方程式與普通文字和影像分離。

LaTeX 引擎與文件範本並非全部支援相同的指令、套件或 Unicode 字元。請使用您應用程式所使用的 LaTeX 引擎測試回傳的字串。若某個符號或 Office Math 元素在該環境中沒有合適的表示，請在回傳的字串中以專案特定的指令取代，或跳過該方程式並記錄問題以供檢閱。

## **將數學方程式儲存為 MathML**

雖然人類可以輕鬆編寫 LaTeX 等方程式格式的程式碼，但對於 MathML 卻很困難，因為後者原本應由應用程式自動產生。程式可以輕鬆讀取和解析 MathML，因為其程式碼是 XML，故 MathML 常被用作許多領域的輸出與列印格式。

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

**到底匯出到 MathML 的是段落還是單一公式區塊？**

您可以將整個數學段落 ([MathParagraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathparagraph/)) 或單一區塊 ([MathBlock](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathblock/)) 匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式而非一般文字或圖像？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathportion/) 中，且擁有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathparagraph/) 的影像與一般文字部分不是可匯出的公式。

**簡報中的 MathML 來源是什麼——是 PowerPoint 專用的還是標準？**

匯出目標為標準 MathML（XML）。Aspose 使用 Presentation MathML——標準的呈現子集，廣泛應用於各種應用程式與網路。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，若這些物件包含具有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathparagraph/) 的文字部分（即真正的 PowerPoint 公式），則會被匯出。若公式以影像形式嵌入，則不會。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 只是將公式內容序列化，並不會修改簡報檔案。