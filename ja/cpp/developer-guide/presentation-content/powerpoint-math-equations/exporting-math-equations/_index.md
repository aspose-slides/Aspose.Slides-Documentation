---
title: C++ のプレゼンテーションから数式をエクスポート
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
description: "Aspose.Slides for C++ を使用して PowerPoint から MathML へ数式をシームレスにエクスポートし、書式を保持しながら互換性を向上させます。"
---
## **イントロダクション**

Aspose.Slides for C++ は、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
MathML は、ウェブや多くのアプリケーションで使用されている数式や類似コンテンツのための一般的なフォーマットまたは標準です。数式を MathML にエクスポートできます。 
{{% /alert %}}

## **数式を MathML として保存**

LaTeX のような一部の数式フォーマットは人間が簡単にコードを書けますが、MathML のコードは手で書くのが難しいです。なぜなら MathML はアプリケーションによって自動生成されることを想定しているからです。MathML のコードは XML 形式なので、プログラムは容易に読み取り・解析できます。そのため、MathML は多くの分野で出力や印刷フォーマットとして広く使用されています。

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示します。

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

## **よくある質問**

**MathML にエクスポートされるのは正確には何ですか―段落全体ですか、個々の数式ブロックですか？**

MathML へは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/)）または個々のブロック（[MathBlock](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathblock/)）のいずれかをエクスポートできます。どちらのタイプも MathML に書き出すメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どのように判別できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/) を持ちます。[MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/) を持たない画像や通常のテキスト部分は、エクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか―PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準の MathML (XML) を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、これはアプリケーションやウェブ全体で広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/) を含むテキスト部分（すなわち本物の PowerPoint 数式）がある場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーションファイルは変更されません。