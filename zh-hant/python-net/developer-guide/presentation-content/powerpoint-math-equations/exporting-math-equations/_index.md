---
title: 從簡報中以 Python 匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/python-net/exporting-math-equations/
keywords:
- 匯出數學方程式
- MathML
- LaTeX
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，將 PowerPoint 的數學方程式無縫匯出為 MathML，保留格式並提升相容性。"
---
## **簡介**

Aspose.Slides for Python via .NET 允許您從簡報中匯出數學方程式。例如，您可能需要從特定投影片中擷取方程式，並在其他程式或平台中重新使用它們。

{{% alert color="primary" %}}
您可以將方程式匯出為 MathML，這是一種廣泛使用的標準，用於在網路上以及許多應用程式中表示數學內容。
{{% /alert %}}

## **將數學方程式儲存為 MathML**

雖然人類可以輕鬆編寫 LaTeX，但 MathML 通常由應用程式自動產生。由於 MathML 基於 XML，程式能可靠地讀取與解析它，因此它在許多領域中常被作為輸出與列印格式使用。

以下範例程式碼說明如何將簡報中的數學方程式匯出為 MathML：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **常見問題**

**究竟匯出到 MathML 的是段落還是單一公式區塊？**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathblock/)）匯出為 MathML。這兩種類型皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式而非一般文字或圖片？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathportion/)，且具有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/) 的圖片與一般文字部分並非可匯出的公式。

**簡報中的 MathML 來源是什麼——是 PowerPoint 特有的還是標準？**

匯出目標為標準的 MathML（XML）。Aspose 使用 Presentation MathML——即標準的呈現子集，這在各種應用程式與網路上被廣泛使用。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，只要這些物件的文字部分包含 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/)（即真正的 PowerPoint 公式），就會被匯出。若公式以圖片形式嵌入，則不會匯出。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫出 MathML 只是將公式內容序列化，並不會更改簡報檔案。