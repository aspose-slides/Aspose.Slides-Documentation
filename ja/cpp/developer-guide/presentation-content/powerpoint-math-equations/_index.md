---
title: C++ で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/cpp/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数式
- 数式テキスト
- 数式を追加
- 記号を追加
- 数式を追加
- 数式テキストを追加
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint の PPT および PPTX に数式を挿入および編集できます。OMML、書式設定コントロールに対応し、わかりやすい C++ コードサンプルを提供します。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for C++ を使用すると、プログラムで同様の数式コンテンツ（分数、根号、関数、極限、N項演算子、行列、配列、書式設定された数式ブロック）を作成できます。

PowerPoint では、通常、**挿入 > 数式** から数式を追加します:

![数式コマンドが選択された PowerPoint の挿入タブ](powerpoint-math-equations_1.png)

結果として、スライド上に編集可能な数式テキストが表示されます:

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は、次の 3 つの主要オブジェクトを使用して数式テキストを構築します:

- 数式シェイプは、[AddMathShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapecollection/) で作成され、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathblock/) オブジェクトを含みます。

以下のほとんどの例は、コードを短く読みやすくするために、[MathematicalText](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathematicaltext/) と [IMathElement](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/) のフルエントメソッドを使用しています。

MathML エクスポートのシナリオについては、[Export Math Equations from Presentations in C++](/slides/ja/cpp/exporting-math-equations/) を参照してください。

## **数式の作成**

この例では、数式シェイプを作成し、ピタゴラスの定理を追加します:

![c の二乗 = a の二乗 + b の二乗 の数式](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
`AddMathShape` は、すでに数式段落を含むシェイプを作成します。最初の `MathPortion` にアクセスし、その `MathParagraph` を取得して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

## **分数の追加**

`Divide` を使用して分数を作成します。[MathFractionTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathfractiontypes/) で分数のスタイルを選択できます。

![1 を x で割った斜めの分数](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

積み上げ分数の場合は、`MathFractionTypes::Bar` を使用します:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **根号の追加**

`Radical` を使用して平方根、立方根、またはその他の根号を作成します。現在の要素が基底となり、引数が次数になります。

![x が根号記号の下にある n 乗根の表現](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **関数と極限の追加**

`AsArgumentOfFunction` または `Function` を使用して、`sin(x)`、`log(x)` などの関数やカスタム関数名を作成します。極限の場合は、[MathLimit](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathlimit/) に `lim` を入れるか、`SetLowerLimit` を使用します。

![x が無限大に近づくときの極限](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

カスタム関数名の場合は、関数名を現在の要素にします:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **N 項演算子と積分の追加**

和、合併、交叉などの大きな演算子には `Nary` を使用します。積分には `Integral` を使用します。どちらのメソッドも下限と上限を設定できます。

![下限と上限付きの総和](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

N 項演算子は、オプションの上下限を持つ大きな演算子用です。`+`、`-`、`=` などの単純な演算子は通常、`MathematicalText` として追加され、式に結合されます。

積分の場合は、`Integral` を使用します:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **行列の追加**

行と列には [MathMatrix](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathmatrix/) を使用します。行列はデフォルトで括弧を含まないため、必要に応じて丸括弧、角括弧、波括弧で囲んでください。

![1 つの空セルがある 2 行の数式行列](powerpoint-math-equations_10.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **数式配列の追加**

整列した数式や縦に積み重ねた式が必要な場合は、`ToMathArray` を使用します。

![x が上、y が下の縦方向の数式配列](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **三角関数の追加**

引数が現在の要素で関数名が既知の場合は、`AsArgumentOfFunction` を使用します。

![2x に適用された三角関数 cos](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **下付き文字と上付き文字の追加**

添字と指数には下付き・上付きヘルパーを使用します。添字を基底の左側に表示する必要がある場合は、`SetSubSuperscriptOnTheLeft` を使用します。

![左側に添字 1、上付き文字 n が付いた大文字 Y](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **区切り文字の追加**

式を区切り文字で囲むには `Enclose` を使用します。複数要素を含む区切り文字式には、区切り文字を設定することもできます。

![x、y、z が縦棒で区切られた区切り文字式](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **枠付きボックスの追加**

数式自体を枠で囲む場合は `ToBorderBox` を使用します。

![a の二乗が b の二乗と c の二乗の和になる枠付きの数式](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        - >ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **項のグループ化**

`Group` を使用して、式の上または下にグルーピング文字を配置します。グループ化された項にラベルを付けるには、リミットを追加します。

![x + y の式がグループ化され、下に任意のテキストラベルが付いた例](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **数式要素の書式設定**

書式設定ヘルパーは、式を明確にする場合にのみ使用してください。例として、`Overbar` は数式要素の上にバーを付けます。

![上にバーが付いた数式 ABC](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **クイックリファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathematicaltext/) |
| 要素の結合 | [IMathElement.Join](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/join/) |
| 分数の作成 | [IMathElement.Divide](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/divide/) |
| 上付き文字または下付き文字の追加 | [SetSuperscript](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| 関数の追加 | [Function](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 根号の追加 | [IMathElement.Radical](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/radical/) |
| 極限の追加 | [SetLowerLimit](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 左側添字の追加 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 総和と積分の追加 | [Nary](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/integral/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/mathmatrix/) |
| 数式配列の追加 | [ToMathArray](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| 区切り文字の追加 | [Enclose](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| バーと枠の追加 | [Overbar](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| 項のグループ化 | [Group](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathelement/group/) |

## **よくある質問**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、`MathPortion` を含むシェイプを見つけ、その `MathParagraph` を取得し、その段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX で保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。数式の [IMathParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathparagraph/) をその [IMathPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathportion/) から取得し、[IMathParagraph::ToLatex](https://reference.aspose.com/slides/ja/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) を呼び出すことで直接エクスポートできます。完全な例については、[Export Math Equations from Presentations in C++](/slides/ja/cpp/exporting-math-equations/#export-math-equations-to-latex) を参照してください。