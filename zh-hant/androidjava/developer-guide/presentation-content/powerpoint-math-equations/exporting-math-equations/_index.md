---
title: 在 Android 上從簡報匯出數學公式
linktitle: 匯出公式
type: docs
weight: 30
url: /zh-hant/androidjava/exporting-math-equations/
keywords:
- 匯出數學公式
- MathML
- LaTeX
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，輕鬆將 PowerPoint 中的數學公式匯出為 MathML——保留格式並提升相容性。"
---
## **簡介**

Aspose.Slides for Android via Java 允許您從簡報中匯出數學公式。例如，您可能需要從投影片（特定簡報）中提取數學公式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 
您可以將公式匯出為 MathML，這是一種廣受歡迎的數學公式及類似內容的格式或標準，常見於網路及許多應用程式中。 
{{% /alert %}}

## **從簡報匯出數學公式**

雖然人類能輕易撰寫 LaTeX 等公式格式的程式碼，但對於 MathML 則較為吃力，因為它本應由應用程式自動產生。程式能輕易讀取與解析 MathML，因為其程式碼採用 XML，因此 MathML 常被作為許多領域的輸出與列印格式。

This sample code shows you how to export a math equation from a presentation to MathML:

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

**匯出到 MathML 的到底是段落還是單一公式區塊？**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathblock/)）匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**如何辨別投影片上的物件是數學公式而非普通文字或影像？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathportion/) 中，且具有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathparagraph/)。沒有 [MathParagraph] 的影像或普通文字區段不是可匯出的公式。

**簡報中的 MathML 來源是什麼——它是 PowerPoint 專屬的還是標準的？**

匯出目標為標準的 MathML（XML）。Aspose 使用 Presentation MathML——標準的簡報子集，廣泛應用於各種應用程式與網路上。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，若這些物件的文字區段包含 [MathParagraph]（即真正的 PowerPoint 公式），則會被匯出。若公式以影像形式嵌入，則不會。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 只是一種將公式內容序列化的動作，並不會更改簡報檔案。