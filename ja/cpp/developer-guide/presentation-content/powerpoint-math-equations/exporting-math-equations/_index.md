---
title: プレゼンテーションから C++ の数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/cpp/exporting-math-equations/
keywords:
- 数式のエクスポート
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint から MathML への数式エクスポートをシームレスに実現します — フォーマットを保持し、互換性を向上させます。"
---

## **プレゼンテーションから数式をエクスポートする**

Aspose.Slides for C++ を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーション内のスライドにある数式を抽出し、別のプログラムやプラットフォームで使用したい場合があります。

{{% alert color="primary" %}} 

数式を MathML にエクスポートできます。MathML は、Web や多くのアプリケーションで使用される数式や類似コンテンツの一般的なフォーマットまたは標準です。

{{% /alert %}}

人間は LaTeX のような一部の数式フォーマットのコードを書きやすいですが、MathML のコードは自動的にアプリケーションによって生成されることを想定しているため、記述が難しいです。MathML のコードは XML 形式なので、プログラムは簡単に読み取り・解析できます。そのため、MathML は多くの分野で出力および印刷フォーマットとして広く使用されています。

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています：
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        ->SetSuperscript(u"2")
        ->Join(u"+")
        ->Join(System::MakeObject<MathematicalText>(u"b")
                ->SetSuperscript(u"2"))
        ->Join(u"=")
        ->Join(System::MakeObject<MathematicalText>(u"c")
                ->SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```


## **FAQ**

**MathML にエクスポートされるのは段落全体ですか、それとも個々の数式ブロックですか？**

MathML には、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)）または個別のブロック（[MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)）のいずれかをエクスポートできます。両方のタイプに MathML へ書き出すメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることは、どのように判断できますか？**

数式は[MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/)に存在し、[MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)を持ちます。[MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか？PowerPoint 固有ですか、標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose はプレゼンテーションサブセットである Presentation MathML を使用しており、これはアプリケーションや Web で広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトに[MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)を含むテキスト部分（実際の PowerPoint 数式）がある場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイル自体は変更されません。