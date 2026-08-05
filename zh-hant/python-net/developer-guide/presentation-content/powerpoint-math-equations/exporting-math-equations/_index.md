---
title: 從 Python 匯出簡報中的數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/python-net/exporting-math-equations/
keywords:
- 匯出數學方程式
- 匯出方程式至 LaTeX
- PowerPoint 轉 LaTeX
- MathML
- LaTeX
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，直接將 PowerPoint 簡報中的數學方程式匯出為 LaTeX 或 MathML。"
---
## **簡介**

Aspose.Slides for Python via .NET 允許您從簡報中匯出數學方程式。例如，您可能需要從特定投影片中提取方程式，並在其他程式或平台上重複使用它們。

{{% alert color="primary" %}}
您可以直接將方程式匯出為 LaTeX 或 MathML，後者是網路及許多應用程式常用的數學內容標準。
{{% /alert %}}

## **將數學方程式匯出為 LaTeX**

Aspose.Slides 可直接將 PowerPoint 數學方程式轉換為 LaTeX；不需要中間的 MathML 檔案或外部轉換器。方程式以 [MathPortion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathportion/) 形式儲存在文字框中。使用 [MathPortion.math_paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) 取得 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/)，然後呼叫 [MathParagraph.to_latex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/to_latex/)。此方法會傳回字串，您可以將其儲存、顯示、傳送至其他應用程式，或進一步處理。

以下範例會檢查每張投影片的所有文字框，找出所有數學區段，並將每個方程式寫入各自的 `.tex` 檔案：

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) 會回傳投影片上找到的所有文字框。透過對 [MathPortion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathportion/) 進行型別檢查，可將真正可編輯的方程式與普通文字或圖片區分開來。

LaTeX 引擎與文件範本並非全部支援相同的指令、套件或 Unicode 字元。請使用您的應用程式所採用的 LaTeX 引擎測試回傳的字串。若某個符號或 Office Math 元素在該環境中沒有適當的表示方式，請在回傳的字串中以專案特定的指令取代，或跳過該方程式並記錄問題以供檢查。

## **將數學方程式儲存為 MathML**

雖然人類撰寫 LaTeX 較為便利，MathML 通常由應用程式自動產生。由於 MathML 基於 XML，程式可以可靠地讀取與解析它，因此在許多領域中普遍作為輸出與列印格式使用。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

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

## **常見問與答**

**究竟匯出到 MathML 的是整段文字還是單一公式區塊？**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathblock/)）匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**怎麼判斷投影片上的物件是數學公式而非普通文字或圖片？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathportion/) 中，且具有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/) 的圖片或普通文字區段並非可匯出的公式。

**簡報中的 MathML 來源是 PowerPoint 專屬的還是標準的？**

匯出目標是標準的 MathML（XML）。Aspose 使用的是 Presentation MathML——標準的呈現子集，廣泛應用於各種應用程式與網路。

**是否支援匯出位於表格、SmartArt、群組等物件內的公式？**

支援，只要這些物件內含有帶有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/) 的文字區段（即真正的 PowerPoint 公式），就會被匯出。若公式以圖片形式嵌入，則不會匯出。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 只是對公式內容的序列化，並不會更改簡報檔案本身。