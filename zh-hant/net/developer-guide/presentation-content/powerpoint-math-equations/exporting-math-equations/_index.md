---
title: 在 .NET 中從簡報匯出數學方程式
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
## **Introduction**

Aspose.Slides for .NET 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中擷取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="info" %}}
您可以直接將方程式匯出為 LaTeX 或 MathML，MathML 是網路上以及許多應用程式中使用的熱門數學內容標準。
{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides 可以直接將 PowerPoint 數學方程式轉換為 LaTeX；不需要中介的 MathML 檔案或外部轉換器。數學方程式以 [MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/) 的形式儲存在文字框中。使用 [MathPortion.MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/mathparagraph/) 取得 [IMathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathparagraph/)，然後呼叫 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathparagraph/tolatex/)。此方法會回傳一個字串，您可以將其儲存、顯示、傳送至其他應用程式，或進一步處理。

以下範例會檢查每一張投影片上的所有文字框，找出所有數學區段，並將每個方程式寫入獨立的 `.tex` 檔案：

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/getalltextboxes/) 會傳回投影片上找到的所有文字框。[MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/) 的型別檢查會將真正可編輯的方程式與普通文字和圖片區分開來。

LaTeX 引擎和文件範本並不全部支援相同的指令、套件或 Unicode 字元。請使用您應用程式所使用的 LaTeX 引擎測試回傳的字串。如果某個符號或 Office Math 元素在該環境中沒有合適的表示方式，請在回傳的字串中以專案特定的指令取代，或跳過該方程式並記錄問題以供檢閱。

## **Save Math Equations as MathML**

雖然人類可以輕易編寫像 LaTeX 這類方程式格式的程式碼，但對於 MathML 卻較為困難，因為後者本應由應用程式自動產生。程式能輕鬆讀取與解析 MathML，因其程式碼為 XML，所以 MathML 在許多領域常被用作輸出與列印格式。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **FAQ**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathblock/)）匯出為 MathML。這兩種型別皆提供寫入 MathML 的方法。

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/) 中，且擁有一個 [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/) 的圖片與普通文字區段並非可匯出的公式。

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

匯出目標為標準 MathML（XML）。Aspose 使用 Presentation MathML——標準的展示子集，廣泛應用於各種應用程式與網路上。

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

是的，若這些物件的文字區段包含 [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/)（即真正的 PowerPoint 公式），則會被匯出。若公式以圖片形式嵌入，則不會匯出。

**Does exporting to MathML modify the original presentation?**

不會。寫入 MathML 只是將公式內容序列化，並不會更改簡報檔案。