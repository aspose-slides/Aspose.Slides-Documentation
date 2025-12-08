---
title: C# で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/net/powerpoint-math-equations/
keywords:
- 数式
- PowerPoint 数式
- 数学記号
- PowerPoint 数学記号
- 数学式
- PowerPoint 数学式
- 数学テキスト
- PowerPoint 数学テキスト
- PowerPoint に数式を追加
- PowerPoint に数学記号を追加
- PowerPoint に数学式を追加
- PowerPoint に数学テキストを追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides を使用して PowerPoint で数式を操作する方法を学びます。詳細な手順、コード例、プレゼンテーションの作成と編集を自動化するためのヒントを入手できます。"
---

## **概要**

PowerPointでは、数式や式を書き、プレゼンテーションに表示できます。さまざまな数学記号が利用可能で、テキストや式に追加できます。数式コンストラクタは、次のような複雑な式を作成するために使用されます。

- 分数
- ルート
- 関数
- 極限および対数関数
- 多項演算
- 行列
- 大きな演算子
- sin、cos 関数

PowerPointで数式を追加するには、*Insert -> Equation* メニューを使用します：

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML 形式の数式テキストが作成され、PowerPoint で次のように表示されます：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は幅広い数学記号をサポートしていますが、複雑な数式を生成すると必ずしも洗練されたプロフェッショナルな結果にはなりません。そのため、頻繁に数式プレゼンテーションを作成するユーザーは、見栄えの良い数式のためにサードパーティ製ソリューションを利用することが多いです。

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) を使用すれば、C# で PowerPoint プレゼンテーション内の数式をプログラムで操作できます。新しい数式を作成したり、既存の数式を編集したりできます。数式構造を画像としてエクスポートする部分的なサポートも利用可能です。

## **数式の作成方法**

数学要素は、ネストレベルに関係なく任意の数学構造を構築するために使用されます。これらの要素の線形コレクションが数式ブロックを形成し、[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) クラスで表されます。[MathBlock] クラスは、単独の数式、式、または方程式を表します。[MathPortion] は通常の [Portion] クラスとは別の、数学テキストを保持するために使用され、[MathParagraph] は [MathBlock] オブジェクトの集合を操作できるようにします。これらのクラスは、Aspose.Slides API を介して PowerPoint の数式を扱う際に不可欠です。

以下に、Aspose.Slides API を使用して次の数式を作成する方法を示します：

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを保持するシェイプを追加します：
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


シェイプを作成すると、デフォルトで 1 つの段落が数式ポーションとして含まれます。[MathPortion] クラスは数式テキストを含むポーションを表します。数式コンテンツにアクセスするには、[MathParagraph] 変数を参照してください：
```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


[MathParagraph] クラスを使用すると、数式要素の組み合わせで構成される数式ブロック（[MathBlock]）を読み取り、追加、編集、削除できます。例えば、分数を作成してプレゼンテーションに配置するには：
```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


各数学要素は [IMathElement] インターフェイスを実装するクラスで表されます。このインターフェイスは多数のメソッドを提供し、1 行のコードだけでかなり複雑な式を作成できます。たとえば、ピタゴラスの定理は次のように記述できます：
```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


[IMathElement] インターフェイスの操作はすべての要素タイプで実装されており、[MathBlock] クラスにも同様です。

以下に完全なサンプルコードを示します：
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
    var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

    var fraction = new MathematicalText("x").Divide("y");

    mathParagraph.Add(new MathBlock(fraction));

    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);

    presentation.Save("math.pptx", SaveFormat.Pptx);
}
```


## **数学要素の種類**

数式は数学要素のシーケンスで構成されます。数式ブロックはそのシーケンスを表し、要素の引数は入れ子構造のツリーを形成します。

数式ブロックを構築できる数学要素は多数あります。各要素は別の要素の内部に集約でき、ツリー構造を作ります。最も単純な要素は、他の数学テキスト要素を含まないものです。

すべての数学要素は [IMathElement] インターフェイスを実装しており、異なる要素タイプに共通の数学操作セットを使用できます。

### **MathematicalText クラス**

[MathematicalText] クラスは、すべての数学構造の基礎要素である数学テキストを表します。数学テキストはオペランドや演算子、変数、または任意の線形テキストを表すことができます。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**

[MathFraction] クラスは、分子と分母が分数バーで区切られた分数オブジェクトを指定します。分数バーは水平または斜めに設定でき、分数プロパティに依存します。また、分数バーなしで要素を上下に配置するスタック関数としても使用されます。

例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**

[MathRadical] クラスは、基底とオプションの次数からなる根（ラジカル）関数を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**

[MathFunction] クラスは、引数の関数を指定します。関数名を表す [Name] プロパティや、関数引数を表す [Base] プロパティがあります。

例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**

[MathNaryOperator] クラスは、総和や積分などの N 変数数学オブジェクトを指定します。演算子、基底（またはオペランド）、およびオプションの上限・下限で構成されます。例として総和、和集合、積集合、積分があります。

このクラスは、加算や減算などの単純演算子は含みません。これらは単一のテキスト [MathematicalText] で表されます。

例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**

[MathLimit] クラスは上限または下限を作成します。基線上のテキストと、その直上または直下に配置された縮小テキストで構成されます。\"lim\" という文字は含まず、式の上部または下部にテキストを配置できます。

例：

![todo:image_alt_text](powerpoint-math-equations_8.png)

は、[MathFunction] と [MathLimit] 要素の組み合わせで次のように作成されます：
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**

- [MathSubscriptElement]
- [MathSuperscriptElement]
- [MathRightSubSuperscriptElement]
- [MathLeftSubSuperscriptElement]

これらのクラスは下添え字または上添え字を指定します。左または右側に同時に下添え字と上添え字を設定できますが、単一の下添え字または上添え字は右側のみサポートされます。[MathSubscriptElement] は数値の次数を設定することも可能です。

例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**

[MathMatrix] クラスは、子要素が 1 行以上の行と列に配置された行列オブジェクトを指定します。行列にはデフォルトの区切り記号がないことに注意してください。角括弧で囲むには [IMathDelimiter] を使用します。NULL 引数を使用して行列内に空白を作成できます。

例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**

[MathArray] クラスは、垂直配列の式または任意の数学オブジェクトを指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素の書式設定**

- [MathBorderBox] クラス: [IMathElement] の周囲に矩形または代替の枠を描画します。

例：

![todo:image_alt_text](powerpoint-math-equations_12.png)

- [MathBox] クラス: 数学要素の論理的な箱詰めを指定します。箱詰めオブジェクトは、配置点の有無にかかわらず演算子エミュレータとして機能したり、改行位置として使用したり、改行を防止するためにグループ化したりできます。例として \"==\" 演算子は改行を防ぐために箱詰めすべきです。

- [MathDelimiter] クラス: 開始文字と終了文字（括弧、波かっこ、角かっこ、縦棒など）と、その内部に 1 つ以上の数学要素を含む区切りオブジェクトを指定します。例: (𝑥2); [𝑥2|𝑦2]。

例：

![todo:image_alt_text](powerpoint-math-equations_13.png)

- [MathAccent] クラス: 基底と結合アクセント記号からなるアクセント機能を指定します。

例: 𝑎́.

- [MathBar] クラス: 基底引数と上バーまたは下バーからなるバー機能を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_14.png)

- [MathGroupingCharacter] クラス: 式の上または下に配置され、要素間の関係を強調するグルーピング記号を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学操作**

各数学要素と各数学式（[MathBlock] 経由）はすべて [IMathElement] インターフェイスを実装しています。これにより、既存の構造に対して操作を行い、より複雑な式を構築できます。すべての操作は、[IMathElement] または文字列引数の 2 種類のパラメータを受け取ります。文字列引数が使用される場合、指定された文字列から [MathematicalText] インスタンスが暗黙的に生成されます。Aspose.Slides で利用できる数学操作は以下のとおりです。

### **Join メソッド**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

これらのメソッドは数学要素を結合し、数学ブロックを形成します。例：
```cs
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);
```


### **Divide メソッド**

- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

これらのメソッドは指定されたタイプの分数を作成します。例：
```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **Enclose メソッド**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

これらのメソッドは要素を指定した文字で囲みます（例: 括弧）。例：
```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **Function メソッド**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

これらのメソッドは現在のオブジェクト名を関数名として、引数の関数を作成します。例：
```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **AsArgumentOfFunction メソッド**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

これらのメソッドは現在のインスタンスを引数として指定された関数に渡します。使用例：

- 文字列として関数名を指定（例: "cos"）
- 列挙型 [MathFunctionsOfOneArgument] または [MathFunctionsOfTwoArguments] の事前定義値を選択（例: `MathFunctionsOfOneArgument.ArcSin`）
- [IMathElement] インスタンスを渡す

例：
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);
var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");
var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);
var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")
```


### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft メソッド**

- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

これらのメソッドは下添え字と上添え字を設定します。左側または右側の両方に同時に設定可能ですが、単一の下添え字または上添え字は右側のみサポートされます。**Superscript** は数値の次数を設定するためにも使用できます。

例：
```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **Radical メソッド**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

これらのメソッドは、指定された引数に基づき次数付き根を指定します。

例：
```cs
var radical = new MathematicalText("x").Radical("3");
```


### **SetUpperLimit と SetLowerLimit メソッド**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

これらのメソッドは上限または下限を設定します。\"upper\" と \"lower\" は基底に対する位置を示します。

次の式を考えてみましょう：

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は、[MathFunction] と [MathLimit] クラスを組み合わせ、[IMathElement] の操作を使用して次のように作成できます：
```cs
var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");
```


### **Nary と Integral メソッド**

- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

**Nary** と **Integral** の両メソッドは、[INaryOperator] タイプの N 変数演算子を作成して返します。Nary メソッドでは、[MathNaryOperatorTypes] 列挙型が総和や和集合などの演算子タイプを指定し、積分は除外されます。Integral メソッドは積分専用の操作を提供し、[MathIntegralTypes] 列挙型で種類を指定します。

例：
```cs
IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **ToMathArray メソッド**

[ToMathArray] は要素を垂直配列に配置します。これを [MathBlock] インスタンスで呼び出すと、すべての子要素が返された配列に配置されます。

例：
```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **書式設定操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**

- [Accent] メソッドは要素の上にアクセント記号（文字）を設定します。
- [Overbar] と [Underbar] メソッドはそれぞれ上部または下部にバーを設定します。
- [Group] メソッドは下側の波かっこなどのグルーピング文字を使用して要素をグループ化します。
- [ToBorderBox] メソッドは要素を枠付きボックスに配置します。
- [ToBox] メソッドは要素を非表示の論理ボックス（論理的なグループ化）に配置します。

例：
```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **FAQ**

**PowerPoint スライドに数式を追加するにはどうすればよいですか？**

数式を追加するには、`MathShape` オブジェクトを作成します。これには自動的に数式ポーションが含まれます。次に、`MathPortion` から `MathParagraph` を取得し、`MathBlock` オブジェクトを追加します。

**複雑な入れ子数式を作成できますか？**

はい。Aspose.Slides は MathBlock を入れ子にすることで複雑な数式を作成できます。各数学要素は `IMathElement` インターフェイスを実装しており、Join、Divide、Enclose などの操作で要素を組み合わせてより複雑な構造を構築できます。

**既存の数式を更新または変更するにはどうすればよいですか？**

数式を更新するには、`MathParagraph` を介して既存の MathBlock にアクセスします。その後、Join、Divide、Enclose などのメソッドを使用して式の個々の要素を変更できます。編集後にプレゼンテーションを保存して変更を適用します。