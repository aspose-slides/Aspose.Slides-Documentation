---
title: 從簡報匯出 C++ 數學方程式
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，將 PowerPoint 中的數學方程式無縫匯出為 MathML，保留格式並提升相容性。"
---
## **簡介**

Aspose.Slides for C++ 允許您從簡報匯出數學方程式。例如，您可能需要從特定簡報的投影片中提取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 
您可以將方程式匯出為 MathML，這是一種在 Web 及許多應用程式中常見的數學方程式與類似內容的格式或標準。
{{% /alert %}}

## **將數學方程式儲存為 MathML**

雖然人類可以輕鬆編寫 LaTeX 等某些方程式格式的程式碼，但他們在編寫 MathML 程式碼時會感到困難，因為後者應由應用程式自動產生。由於 MathML 的程式碼採用 XML，程式可以輕鬆讀取與解析它，因此 MathML 在許多領域中常被用作輸出與列印格式。

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

**究竟是匯出什麼至 MathML——整段數學段落或單一公式區塊？**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathblock/)）匯出為 MathML。這兩種型別皆提供寫入 MathML 的方法。

**如何辨識投影片上的物件是數學公式而非一般文字或影像？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathportion/) 中，且具有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/) 的影像與一般文字區段並非可匯出的公式。

**簡報中的 MathML 來源為何——它是 PowerPoint 專屬的還是標準？**

此匯出以標準 MathML（XML）為目標。Aspose 使用 Presentation MathML——標準的簡報子集，已廣泛應用於各種應用程式與 Web。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，若這些物件的文字區段包含 [MathParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.mathtext/mathparagraph/)（即真正的 PowerPoint 公式），則會被匯出。若公式以影像形式嵌入，則不會被匯出。

**匯出至 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 只是將公式內容序列化，並不會修改簡報檔案。