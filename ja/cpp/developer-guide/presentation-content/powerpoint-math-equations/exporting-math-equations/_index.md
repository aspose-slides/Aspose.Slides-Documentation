---
title: C++ のプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/cpp/exporting-math-equations/
keywords:
- 数式をエクスポート
- 数式を LaTeX にエクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションから数式を直接 LaTeX または MathML にエクスポートします。"
---
## **導入**

Aspose.Slides for C++ を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーション内のスライドに含まれる数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="info" %}} 
数式は LaTeX または MathML に直接エクスポートできます。MathML はウェブや多くのアプリケーションで使用される数学コンテンツの一般的な標準です。
{{% /alert %}}

## **数式を LaTeX にエクスポート**

Aspose.Slides は PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは必要ありません。数式はテキスト フレーム内に [IMathPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathportion/) として格納されています。[IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) を使用して [IMathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathparagraph/) を取得し、次に [IMathParagraph::ToLatex](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) を呼び出します。このメソッドは文字列を返しますので、保存、表示、別のアプリケーションへの送信、またはさらに処理することができます。

次のサンプルは、各スライドのすべてのテキスト フレームを調べ、すべての数式部分を検出し、各数式を個別の `.tex` ファイルに書き出します：

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/getalltextboxes/) はスライド上で見つかったすべてのテキスト フレームを返します。[IMathPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathportion/) の型チェックにより、実際に編集可能な数式と通常のテキストや画像が区別されます。

LaTeX エンジンや文書テンプレートは、すべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列を、使用している LaTeX エンジンでテストしてください。シンボルや Office Math の要素がその環境で適切に表現できない場合は、返された文字列中でプロジェクト固有のコマンドに置き換えるか、数式をスキップして問題を記録し、後で確認できるようにしてください。

## **MathML として数式を保存**

LaTeX のような一部の数式形式は人間が容易にコードを書けますが、MathML はアプリケーションによって自動生成されることを前提としているため、コードを手書きするのは困難です。MathML のコードは XML 形式なので、プログラムは簡単に読み取りや解析が可能であり、多くの分野で出力や印刷形式として広く利用されています。

このサンプルコードは、プレゼンテーションから MathML に数式をエクスポートする方法を示しています。

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

## **よくある質問**

**MathML にエクスポートされるのは段落全体ですか、それとも個々の数式ブロックですか？**

MathML へは、全体の数式段落 ([MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/)) または個々のブロック ([MathBlock](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathblock/)) のいずれかをエクスポートできます。どちらのタイプも MathML に書き出すメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることは、どのように判別できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/) を持っています。[MathParagraph] を持たない画像や通常のテキスト部分は、エクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか？PowerPoint 固有のものですか、それとも標準ですか？**

エクスポートは標準の MathML (XML) を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、これはアプリケーションやウェブ上で広く利用されています。

**テーブル、SmartArt、グループなど内の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトに [MathParagraph] を含むテキスト部分（つまり実際の PowerPoint 数式）がある場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけであり、プレゼンテーション ファイルを変更することはありません。