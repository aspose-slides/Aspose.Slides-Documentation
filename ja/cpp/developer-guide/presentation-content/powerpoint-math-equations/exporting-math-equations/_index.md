---
title: C++ のプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/cpp/exporting-math-equations/
keywords:
- 数式をエクスポート
- LaTeX へ数式をエクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint のプレゼンテーションから数式を LaTeX または MathML に直接エクスポートします。"
---
## **イントロダクション**

Aspose.Slides for C++ は、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーション内のスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式を LaTeX または MathML に直接エクスポートできます。MathML は Web や多数のアプリケーションで使用されている、数学コンテンツの一般的な標準です。
{{% /alert %}}

## **数式を LaTeX にエクスポート**

Aspose.Slides は、PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは不要です。数式はテキストフレーム内に [IMathPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathportion/) として格納されます。[IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) を使用して [IMathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathparagraph/) を取得し、次に [IMathParagraph::ToLatex](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) を呼び出します。このメソッドは文字列を返し、保存、表示、別のアプリケーションへの送信、またはさらに処理することができます。

次のサンプルは、各スライドのすべてのテキストフレームを調査し、すべての数式部分を見つけ出し、各数式を個別の `.tex` ファイルに書き込みます：

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/getalltextboxes/) はスライド上で見つかったすべてのテキストフレームを返します。[IMathPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathportion/) の型チェックにより、実際の編集可能な数式と通常のテキストや画像が区別されます。

LaTeX エンジンやドキュメントテンプレートはすべてが同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列をアプリケーションで使用している LaTeX エンジンでテストしてください。シンボルや Office Math 要素に適切な表現がない場合は、返された文字列中でプロジェクト固有のコマンドに置き換えるか、数式をスキップし、レビュー用に問題を記録してください。

## **数式を MathML として保存**

LaTeX のような一部の数式フォーマットのコードは人間が簡単に記述できますが、MathML のコードは自動生成を前提としているため記述が困難です。MathML はコードが XML であるため、プログラムでの読み取りや解析が容易であり、多くの分野で出力・印刷フォーマットとして一般的に使用されています。

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています：

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

## **FAQ**

**MathML にエクスポートされる対象は、段落全体ですか、それとも個々の数式ブロックですか？**

MathParagraph 全体（[MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/)）または個別のブロック（[MathBlock](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathblock/)）のいずれかを MathML にエクスポートできます。両方の型に MathML に書き出すメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることは、どうやって判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathportion/) に格納され、[MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/) を持ちます。[MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/) を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか？PowerPoint 固有ですか、標準ですか？**

エクスポート対象は標準的な MathML（XML）です。Aspose は Presentation MathML を使用します。これは標準のプレゼンテーションサブセットであり、さまざまなアプリケーションや Web で広く利用されています。

**テーブル、SmartArt、グループなど内部にある数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/) を含むテキスト部分（実際の PowerPoint 数式）がある場合はエクスポートされます。画像として埋め込まれた数式は対象外です。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイル自体は変更されません。