---
title: 数学方程式のエクスポート
type: docs
weight: 30
url: /ja/cpp/exporting-math-equations/

---

# プレゼンテーションからの数学方程式のエクスポート

Aspose.Slides for C++ を使用すると、プレゼンテーションから数学方程式をエクスポートできます。たとえば、スライド上の数学的方程式を抽出して、他のプログラムやプラットフォームで使用する必要があるかもしれません。

{{% alert color="primary" %}} 

方程式を MathML 形式にエクスポートできます。これは、ウェブや多くのアプリケーションで見られる数学方程式や同様のコンテンツのための一般的な形式または標準です。

{{% /alert %}}

人間は LaTeX のような方程式形式のコードを簡単に書きますが、MathML のコードを書くのには苦労します。なぜなら、MathML はアプリケーションによって自動的に生成されることを意図しているからです。プログラムは MathML を簡単に読み取り解析できます。なぜなら、そのコードは XML で記述されており、MathML は多くの分野で出力および印刷フォーマットとして一般的に使用されています。

このサンプルコードでは、プレゼンテーションから MathML に数学方程式をエクスポートする方法を示します。

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