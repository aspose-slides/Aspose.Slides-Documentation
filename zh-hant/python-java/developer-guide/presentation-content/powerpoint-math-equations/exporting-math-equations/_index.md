---
title: 從 Python 匯出簡報中的數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/python-java/exporting-math-equations/
keywords:
- 匯出數學方程式
- 匯出方程式至 LaTeX
- PowerPoint 至 LaTeX
- MathML
- LaTeX
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，直接將 PowerPoint 簡報中的數學方程式匯出為 LaTeX 或 MathML。"
---
## **簡介**

Aspose.Slides 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="info" title="Note" %}} 
您可以直接將方程式匯出為 LaTeX 或 MathML，這是一種在網路和許多應用程式中使用的流行數學內容標準。
{{% /alert %}}

## **匯出數學方程式為 LaTeX**

Aspose.Slides 可以直接將 PowerPoint 數學方程式轉換為 LaTeX；不需要中介的 MathML 檔案或外部轉換器。數學方程式儲存在文字方塊中，作為 [MathPortion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathportion/)。使用 [MathPortion.getMathParagraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathportion/#getMathParagraph) 取得 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathparagraph/)，然後呼叫 [MathParagraph.toLatex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathparagraph/#toLatex)。此方法傳回一個字串，您可以儲存、顯示、傳送至其他應用程式或進一步處理。

以下範例會檢查每一張投影片上的每個文字方塊，找出所有數學部分，並將每個方程式寫入單獨的 `.tex` 檔案：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/#getAllTextBoxes) 會傳回投影片上找到的所有文字方塊。[MathPortion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathportion/) 型別檢查可將真正可編輯的方程式與普通文字和圖像分開。

LaTeX 引擎與文件範本並非全部支援相同的指令、套件或 Unicode 字元。請使用您的應用程式所使用的 LaTeX 引擎測試傳回的字串。如果某個符號或 Office Math 元素在該環境中沒有合適的表示方式，請在傳回的字串中以專案特定的指令取代，或跳過該方程式並記錄問題以供檢閱。

## **將數學方程式儲存為 MathML**

雖然人們可以輕鬆為某些方程式格式（例如 LaTeX）撰寫程式碼，但 MathML 因設計為由應用程式自動產生，手動編寫較為困難。由於 MathML 基於 XML，程式可以輕鬆讀取與解析它，因此 MathML 常被作為許多領域的輸出與列印格式。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **常見問題**

**到底匯出到 MathML 的是段落還是單一公式區塊？**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathblock/)）匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式，而不是普通文字或圖像？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathportion/) 中，且具有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathparagraph/)。沒有 [MathParagraph] 的圖像和普通文字部分並非可匯出的公式。

**簡報中的 MathML 來源是什麼？是 PowerPoint 專屬還是標準？**

匯出目標為標準 MathML（XML）。Aspose 使用的是 Presentation MathML——標準的呈現子集，已廣泛應用於各種應用程式與網路上。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，若這些物件的文字部分包含 [MathParagraph]（即真正的 PowerPoint 公式），則會被匯出。若公式以圖像形式嵌入，則不會匯出。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 只是將公式內容序列化，並不會修改簡報檔案。