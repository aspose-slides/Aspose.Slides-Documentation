---
title: 從簡報匯出 C++ 數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/cpp/exporting-math-equations/
keywords:
- 匯出數學方程式
- 匯出方程式至 LaTeX
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

Aspose.Slides for C++ 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並將其用於其他程式或平台。

{{% alert color="primary" %}} 
您可以直接將方程式匯出為 LaTeX 或 MathML，這是網路及多種應用程式中常用的數學內容標準。
{{% /alert %}}

## **匯出數學方程式為 LaTeX**

Aspose.Slides 可以直接將 PowerPoint 數學方程式轉換為 LaTeX；不需要中介的 MathML 檔案或外部轉換器。數學方程式儲存在文字框中，作為 [IMathPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathportion/)。使用 [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) 取得 [IMathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathparagraph/)，然後呼叫 [IMathParagraph::ToLatex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathparagraph/tolatex/)。此方法會回傳一個字串，您可以將其儲存、顯示、傳送至其他應用程式，或進一步處理。

以下範例會檢查每張投影片上的所有文字框，找出所有數學部分，並將每個方程式寫入各自的 `.tex` 檔案：

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/getalltextboxes/) 會回傳投影片上找到的所有文字框。[IMathPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/imathportion/) 類型檢查可將真正可編輯的方程式與普通文字和圖像分開。

LaTeX 引擎和文件範本並非全部支援相同的指令、套件或 Unicode 字元。請使用您的應用程式所採用的 LaTeX 引擎測試回傳的字串。如果某個符號或 Office Math 元素在該環境中沒有合適的表示方式，請在回傳的字串中以專案特定的指令取代，或跳過該方程式並記錄問題以供檢視。

## **將數學方程式儲存為 MathML**

雖然人類能輕易編寫像 LaTeX 這樣的方程式格式程式碼，但對於 MathML 卻較為困難，因為後者本應由應用程式自動產生。程式能輕鬆讀取並解析 MathML，因為其程式碼是 XML，所以 MathML 常被用作許多領域的輸出與列印格式。

此範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

``` cpp
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

**究竟匯出到 MathML 的是整段還是單獨的公式區塊？**  
您可以匯出整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathblock/)），兩者皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式而非普通文字或圖像？**  
公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathportion/) 並且擁有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/) 的圖像或普通文字部分無法匯出為公式。

**簡報中的 MathML 來源是 PowerPoint 專屬還是標準格式？**  
匯出目標是標準的 MathML（XML）。Aspose 使用 Presentation MathML——標準的呈現子集——在各種應用程式和網站上廣泛使用。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**  
支援，只要這些物件包含帶有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/) 的文字部分（即真正的 PowerPoint 公式），就會被匯出。如果公式以圖像形式嵌入，則不會匯出。

**匯出為 MathML 會修改原始簡報嗎？**  
不會。寫入 MathML 只是公式內容的序列化，不會改變簡報檔案。