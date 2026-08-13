---
title: 從簡報中以 C++ 匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/cpp/exporting-math-equations/
keywords:
- 匯出數學方程式
- 將方程式匯出為 LaTeX
- PowerPoint 轉 LaTeX
- MathML
- LaTeX
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 直接將 PowerPoint 簡報中的數學方程式匯出為 LaTeX 或 MathML。"
---
## **簡介**

Aspose.Slides for C++ 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="info" %}} 
您可以直接將方程式匯出為 LaTeX 或 MathML，這是網路上以及許多應用程式中常用的數學內容標準。 
{{% /alert %}}

## **匯出數學方程式為 LaTeX**

Aspose.Slides 可以直接將 PowerPoint 數學方程式轉換為 LaTeX；不需要中間的 MathML 檔案或外部轉換器。數學方程式以文字框的形式儲存為 [IMathPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathportion/)。使用 [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) 取得 [IMathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathparagraph/)，然後呼叫 [IMathParagraph::ToLatex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathparagraph/tolatex/)。此方法會回傳一個字串，您可以將其保存、顯示、傳送至其他應用程式，或進一步處理。

以下範例會檢查每張投影片上的每個文字框，尋找所有數學部分，並將每個方程式寫入單獨的 `.tex` 檔案：

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/getalltextboxes/) 會傳回在投影片上找到的所有文字框。透過 [IMathPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathportion/) 的型別檢查，可將真正可編輯的方程式與一般文字與影像區分開來。

LaTeX 引擎與文件範本並非全部支援相同的指令、套件或 Unicode 字元。請使用您的應用程式所使用的 LaTeX 引擎測試回傳的字串。如果某個符號或 Office Math 元素在該環境中沒有合適的表示方式，請在回傳的字串中以專案特定的指令取代，或是略過該方程式並記錄問題以供審查。

## **將數學方程式儲存為 MathML**

雖然人類能輕易編寫 LaTeX 等某些方程式格式的程式碼，但對於 MathML 卻較為困難，因為後者應由應用程式自動產生。程式能輕鬆讀取與解析 MathML，因為其程式碼是 XML，因此 MathML 常被用作許多領域的輸出與列印格式。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **常見問題**

**實際匯出到 MathML 的是段落還是單一公式區塊？**

您可以將整個數學段落 ([MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/)) 或單一區塊 ([MathBlock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathblock/)) 匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式而非一般文字或影像？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathportion/) 中，且具備 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/)。未包含 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/) 的影像與普通文字部分並非可匯出的公式。

**簡報中的 MathML 來源是什麼——是 PowerPoint 專有還是標準？**

匯出目標為標準的 MathML（XML）。Aspose 使用的是 Presentation MathML——標準的呈現子集，廣泛應用於各種應用程式與網路上。

**支援匯出位於表格、SmartArt、群組等內的公式嗎？**

是的，只要這些物件包含具備 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/) 的文字部分（即真正的 PowerPoint 公式），就會被匯出。如果公式以影像形式嵌入，則不會匯出。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 僅是將公式內容序列化，並不會修改簡報檔案。