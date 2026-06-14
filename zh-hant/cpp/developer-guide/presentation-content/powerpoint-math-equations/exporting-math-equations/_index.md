---
title: 從簡報中以 С++ 匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/cpp/exporting-math-equations/
keywords:
- 匯出數學方程式
- MathML
- LaTeX
- PowerPoint
- 簡報
- С++
- Aspose.Slides
description: "使用 Aspose.Slides for С++，輕鬆將 PowerPoint 中的數學方程式匯出為 MathML，保留格式並提升相容性。"
---
## **簡介**

Aspose.Slides for C++ 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 
您可以將方程式匯出為 MathML，這是一種在網路及許多應用程式中常見的數學方程式及類似內容的流行格式或標準。 
{{% /alert %}}

## **將數學方程式儲存為 MathML**

雖然人類可以輕鬆編寫 LaTeX 等方程式格式的程式碼，但編寫 MathML 的程式碼卻較為困難，因為 MathML 應由應用程式自動產生。程式可以輕鬆讀取和解析 MathML，因為其程式碼採用 XML，因此 MathML 常被用作許多領域的輸出和列印格式。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

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

**實際匯出到 MathML 的是段落還是單一公式區塊？**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathblock/)）匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**我要如何判斷投影片上的物件是數學公式而非一般文字或圖片？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathportion/) 中，並具備 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/) 的圖片或一般文字區段並非可匯出的公式。

**簡報中的 MathML 來源是什麼——是 PowerPoint 專屬的還是標準？**

匯出目標為標準 MathML（XML）。Aspose 使用的是 Presentation MathML——此標準的簡報子集，已廣泛應用於各種應用程式與網路上。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，若這些物件包含帶有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/) 的文字區段（即真正的 PowerPoint 公式），則會被匯出。若公式是以圖片形式嵌入，則不會匯出。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 只是將公式內容序列化，並不會修改簡報檔案。