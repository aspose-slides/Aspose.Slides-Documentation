---
title: 從簡報中以 Java 匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/java/exporting-math-equations/
keywords:
- 匯出數學方程式
- MathML
- LaTeX
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "利用 Aspose.Slides for Java，輕鬆將 PowerPoint 中的數學方程式匯出為 MathML——保留格式並提升相容性。"
---
## **簡介**

Aspose.Slides 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中擷取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 

您可以將方程式匯出為 MathML，這是一種在網路和許多應用程式中常見的數學方程式及類似內容的流行格式或標準。 

{{% /alert %}}

## **將數學方程式儲存為 MathML**

雖然人類可以輕鬆撰寫 LaTeX 等某些方程式格式的程式碼，但對於 MathML 則較為困難，因為它應由應用程式自動產生。程式能輕鬆讀取與解析 MathML，因為其程式碼採用 XML，因此 MathML 常被用作許多領域的輸出與列印格式。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**到底是匯出整段 MathML（段落）還是單一公式區塊？**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathblock/)）匯出為 MathML。這兩種類型皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式而非一般文字或影像？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathportion/) 中，並具備 [MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/) 的影像與一般文字區段並非可匯出的公式。

**簡報中的 MathML 來源是什麼——是 PowerPoint 專屬的還是標準的？**

匯出的目標是標準的 MathML（XML）。Aspose 使用 Presentation MathML——即標準的簡報子集，廣泛應用於各種應用程式與網路上。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，若這些物件包含帶有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/) 的文字區段（即真正的 PowerPoint 公式），則會匯出。若公式以影像形式嵌入，則不會匯出。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 只是將公式內容序列化，並不會更改簡報檔案。