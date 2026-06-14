---
title: 從 .NET 匯出簡報中的數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/net/exporting-math-equations/
keywords:
- 匯出數學方程式
- MathML
- LaTeX
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 從 PowerPoint 無縫匯出數學方程式為 MathML—保留格式並提升相容性。"
---
## **簡介**

Aspose.Slides for .NET 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 
您可以將方程式匯出為 MathML，這是一種在網路及許多應用程式中常見的數學方程式及類似內容的熱門格式或標準。 
{{% /alert %}}

## **將數學方程式儲存為 MathML**

雖然人類可以輕鬆編寫 LaTeX 等某些方程式格式的程式碼，但編寫 MathML 的程式碼卻較為困難，因為 MathML 通常由應用程式自動產生。程式可以輕鬆讀取與解析 MathML，因為其程式碼是 XML，因此 MathML 在許多領域中常被作為輸出與列印格式使用。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **常見問題**

**到底是匯出 MathML 的段落還是單一公式區塊？**

您可以將整個數學段落 ([MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/)) 或單一區塊 ([MathBlock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathblock/)) 匯出為 MathML。這兩種型別皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式而非一般文字或圖像？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/) 中，且具有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/) 的圖像和一般文字區塊並非可匯出的公式。

**簡報中的 MathML 來源是什麼—它是 PowerPoint 專屬的還是標準？**

匯出目標為標準的 MathML（XML）。Aspose 使用的是 Presentation MathML——標準的呈現子集，廣泛應用於各種應用程式與網路上。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，只要這些物件的文字區塊包含 [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/)（即真正的 PowerPoint 公式），就會匯出。若公式以圖像形式嵌入，則不會匯出。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 只是將公式內容序列化，並不會修改簡報檔案。