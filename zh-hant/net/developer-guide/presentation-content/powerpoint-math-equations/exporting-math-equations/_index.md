---
title: 從 .NET 簡報中匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/net/exporting-math-equations/
keywords:
- 匯出數學方程式
- 匯出方程式至 LaTeX
- PowerPoint 轉 LaTeX
- MathML
- LaTeX
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "直接使用 Aspose.Slides for .NET，將 PowerPoint 簡報中的數學方程式匯出為 LaTeX 或 MathML。"
---
## **簡介**

Aspose.Slides for .NET 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 
您可以直接將方程式匯出為 LaTeX 或 MathML，後者是網路與許多應用程式中常用的數學內容標準。
{{% /alert %}}

## **匯出數學方程式為 LaTeX**

Aspose.Slides 可以直接將 PowerPoint 數學方程式轉換為 LaTeX；不需要中間的 MathML 檔案或外部轉換器。數學方程式以 [MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/) 存放於文字框中。使用 [MathPortion.MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/mathparagraph/) 取得 [IMathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathparagraph/)，然後呼叫 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathparagraph/tolatex/)。此方法會傳回字串，您可以將其保存、顯示、傳送至其他應用程式，或進一步處理。

以下範例會檢查每張投影片上的所有文字框，找出全部數學 Portion，並將每個方程式寫入獨立的 `.tex` 檔案：

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/getalltextboxes/) 會回傳投影片上找到的所有文字框。[MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/) 類型檢查會將真正可編輯的方程式與普通文字和影像區分開來。

LaTeX 引擎與文件範本並不都支援相同的指令、套件或 Unicode 字元。請使用您應用程式使用的 LaTeX 引擎測試回傳的字串。如果某個符號或 Office Math 元素在該環境中沒有合適的表示法，請在回傳字串中以專案專屬的指令取代它，或跳過該方程式並記錄問題以供審查。

## **將數學方程式儲存為 MathML**

雖然人類很容易編寫 LaTeX 等某些方程式格式的程式碼，但對於 MathML 卻較為困難，因為後者應由應用程式自動產生。程式能輕鬆讀取與解析 MathML，因為其程式碼為 XML，因此 MathML 常被用作許多領域的輸出與列印格式。

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

**到底是匯出至 MathML 的段落還是單一公式區塊？**  
您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathblock/)）匯出為 MathML。這兩種型別皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式而非普通文字或圖像？**  
公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/)，且具有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/) 的影像與普通文字 Portion 無法匯出為公式。

**簡報中的 MathML 來源是什麼？是 PowerPoint 專有還是標準？**  
匯出目標為標準 MathML（XML）。Aspose 使用 Presentation MathML——標準的呈現子集，廣泛應用於各種應用程式與網路。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**  
是的，若這些物件的文字 Portion 內含有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/)（即真正的 PowerPoint 公式），則會被匯出。若公式以影像形式嵌入，則不會。

**匯出為 MathML 會修改原始簡報嗎？**  
不會。寫入 MathML 只是將公式內容序列化，並不會修改簡報檔案。