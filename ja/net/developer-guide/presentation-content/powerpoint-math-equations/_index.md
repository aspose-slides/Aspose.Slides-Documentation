---
title: .NET で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/net/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数式
- 数式テキスト
- 数式を追加
- 数学記号を追加
- 数式を追加
- 数式テキストを追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides を使用して PowerPoint PPT および PPTX に数式を挿入および編集できます。OMML、書式設定コントロール、分かりやすい C# コードサンプルをサポートしています。"
---

## **概要**

PowerPointでは、数式や数式記号を書き込み、プレゼンテーションに表示できます。さまざまな数学記号が利用でき、テキストや数式に追加できます。数式コンストラクタは、次のような複雑な式の作成に使用されます。

- Math fraction
- Math radical
- Math function
- Limits and log functions
- N-ary operations
- Matrix
- Large operators
- Sin, cos functions

PowerPointで数式を追加するには、*Insert -> Equation* メニューを使用します:

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML 形式の数式テキストが作成され、PowerPoint で次のように表示されます:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は幅広い数学記号をサポートしていますが、複雑な数式を作成すると見栄えが十分でないことがあります。そのため、頻繁に数式プレゼンテーションを作成するユーザーは、より見栄えの良い数式を提供するサードパーティ製品を利用することが多いです。

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) を使用すると、C# で PowerPoint の数式をプログラム的に操作できます。新しい数式を作成したり、既存の数式を編集したりできます。数式構造を画像としてエクスポートする部分的なサポートも提供されています。

## **数式の作成方法**

数式要素は、入れ子レベルに関係なく任意の数式構造を構築するために使用されます。これらの要素の線形コレクションが数式ブロックとなり、[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) クラスで表されます。[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) クラスは、単独の数式、式、または方程式を表します。[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) は通常の [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) クラスとは別に、数式テキストを保持するために使用され、[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) は [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) オブジェクトの集合を操作できるようにします。これらのクラスは、Aspose.Slides API を介して PowerPoint の数式を操作する際に不可欠です。

以下に、Aspose.Slides API を使用して次の数式を作成する方法を示します。

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを格納するシェイプを追加します:
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


シェイプを作成すると、デフォルトで数式部分を含む段落が 1 つ含まれます。[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) クラスは数式テキストを保持する部分を表します。[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) 内の数式コンテンツにアクセスするには、[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) 変数を参照してください:
```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) クラスを使用すると、数式ブロック ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) の読み取り、追加、編集、削除が可能です。たとえば、分数を作成してプレゼンテーションに配置します:
```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


各数式要素は [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) インターフェイスを実装するクラスで表されます。このインターフェイスは多数のメソッドを提供し、数式を簡単に作成でき、1 行のコードでかなり複雑な式を構築できます。たとえば、ピタゴラスの定理は次のようになります:
```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) インターフェイスの操作は、[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) クラスを含むすべての要素タイプで実装されています。

以下に完全なサンプルコードを示します:
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


## **数式要素の種類**

数式は数式要素のシーケンスで構成されます。数式ブロックはそのシーケンスを表し、要素の引数は入れ子になったツリーストラクチャを形成します。

数式ブロックを構築できる要素タイプは多数あります。各要素は別の要素の中に集約でき、ツリー構造を形成します。最も単純な要素は、他の数式テキスト要素を含まないものです。

各要素は [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) インターフェイスを実装しており、異なる要素タイプ間で共通の数学操作を使用できます。

### **MathematicalText クラス**

[MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) クラスは、すべての数式構成の基礎要素である数式テキストを表します。数式テキストはオペランド、演算子、変数、またはその他の線形テキストを表すことができます。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**

[MathFraction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) クラスは、分子と分母を分数バーで区切った分数オブジェクトを指定します。分数バーは水平または斜めに設定できます。また、分数バーなしで要素を上下に配置するスタック関数としても使用されます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**

[MathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) クラスは、底部とオプションの次数からなる根号関数（数学的根）を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**

[MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) クラスは、引数の関数を指定します。[Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) は関数名を、[Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) は関数の引数を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**

[MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) クラスは、総和や積分などの N 項演算オブジェクトを指定します。演算子、基底（またはオペランド）およびオプションの上限・下限で構成されます。N 項演算の例としては総和、和集合、積集合、積分があります。

このクラスは加算や減算などの単純演算子は含みません。単純演算子は単一テキストの [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) で表されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**

[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) クラスは上限または下限を作成します。ベースライン上のテキストと、そのすぐ上または下に配置された縮小サイズのテキストで構成されます。この要素は「lim」という文字は含まず、式の上部または下部にテキストを配置できます。したがって、次の式は

![todo:image_alt_text](powerpoint-math-equations_8.png)

以下のように [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) と [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) 要素の組み合わせで作成されます:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**

- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

これらのクラスは下付きまたは上付きインデックスを指定します。引数の左右どちらかに下付きと上付きの両方を同時に設定できますが、右側のみ単体の下付きまたは上付きがサポートされています。[MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) は数の次数を設定するためにも使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**

[MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) クラスは、1 行以上または 1 列以上に配置された子要素からなる行列オブジェクトを指定します。行列には組み込みの区切り記号がないことに注意してください。角括弧で囲むには [IMathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter) オブジェクトを使用します。Null 引数を使用すると行列内に空白を作成できます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**

[MathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) クラスは、縦方向の配列（式や任意の数学オブジェクト）を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数式要素の書式設定**

- [MathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox) クラス: [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) の周囲に矩形または代替の枠線を描画します。

例:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- [MathBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox) クラス: 数式要素の論理的なボックス化（パッケージ化）を指定します。ボックス化されたオブジェクトは、整列ポイントの有無にかかわらず演算子エミュレータとして機能したり、改行点として動作したり、改行を防止するためにグループ化されたりします。たとえば、"==" 演算子は改行を防ぐためにボックス化すべきです。

- [MathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter) クラス: 開始文字と終了文字（丸括弧、波括弧、角括弧、縦棒など）で構成され、内部に1 つ以上の数式要素を指定文字で区切って配置します。例: (𝑥2); [𝑥2|𝑦2]。

例:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- [MathAccent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent) クラス: 基底と結合アクセント記号からなるアクセント機能を指定します。

例: 𝑎́.

- [MathBar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar) クラス: 基底引数と上バーまたは下バーからなるバー機能を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- [MathGroupingCharacter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter) クラス: 式の上部または下部に配置され、要素間の関係を強調するためのグルーピング記号を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数式操作**

各数式要素および [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) を介した数式は、[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) インターフェイスを実装しています。これにより、既存の構造に対して操作を行い、より複雑な数式を構築できます。すべての操作は、[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) または文字列引数のいずれかのセットを受け取ります。文字列引数が使用される場合、指定された文字列から [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) インスタンスが暗黙的に作成されます。Aspose.Slides が提供する数式操作は以下のとおりです。

### **Join メソッド**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

これらのメソッドは数式要素を結合し、数式ブロックを形成します。例:
```cs
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);
```


### **Divide メソッド**

- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String,MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement,MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

これらのメソッドは、指定された型の分数を分子と分母で作成します。例:
```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **Enclose メソッド**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char,Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

これらのメソッドは要素を指定文字（括弧など）で囲みます。例:
```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **Function メソッド**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

これらのメソッドは、現在のオブジェクトを関数名として使用し、引数の関数を作成します。例:
```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **AsArgumentOfFunction メソッド**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments,IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

これらのメソッドは、現在のインスタンスを引数として指定された関数を適用します。可能な操作例:

- 関数名を文字列で指定（例: "cos"）
- 列挙体 [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) または [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments) の既定値を選択（例: `MathFunctionsOfOneArgument.ArcSin`）
- [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) インスタンスを選択

例:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);
var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");
var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);
var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")
```


### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft メソッド**

- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement,IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement,IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

これらのメソッドは下付きと上付き文字を設定します。左右どちらかに同時に設定できますが、右側のみ単体の下付きまたは上付きがサポートされています。**Superscript** は数の次数を設定するためにも使用できます。

例:
```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **Radical メソッド**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

これらのメソッドは、指定された引数に基づき、指定次数の数学的根を設定します。

例:
```cs
var radical = new MathematicalText("x").Radical("3");
```


### **SetUpperLimit と SetLowerLimit メソッド**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

これらのメソッドは上限または下限を設定し、"upper" と "lower" は基底に対する引数の位置を示します。

式の例:

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は、[MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) と [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit) クラスの組み合わせ、および [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) インターフェイスの操作で作成できます:
```cs
var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");
```


### **Nary と Integral メソッド**

- [Nary(MathNaryOperatorTypes,IMathElement,IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes,String,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes,IMathElement,IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes,String,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes,IMathElement,IMathElement,MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes,String,String,MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

**Nary** と **Integral** の両メソッドは、[INaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator) タイプで表される N 項演算子を作成して返します。Nary メソッドでは、[MathNaryOperatorTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) 列挙体で演算子のタイプ（総和や和集合など）を指定し、積分は除外されます。Integral メソッドでは、[MathIntegralTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes) 列挙体を使用した積分専用の操作が提供されます。

例:
```cs
IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **ToMathArray メソッド**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) は要素を縦方向の配列に配置します。この操作を [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) インスタンスで呼び出すと、すべての子要素が返された配列に配置されます。

例:
```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **書式設定操作: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- [Accent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) メソッドは、要素の上部にアクセント記号（文字）を設定します。
- [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) と [Underbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) メソッドは、上部または下部にバーを設定します。
- [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) メソッドは、下括弧などのグルーピング文字を使用して要素をグループ化します。
- [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) メソッドは、要素を枠付きボックスに配置します。
- [ToBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) メソッドは、視覚的でないボックス（論理的グルーピング）に要素を配置します。

例:
```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **FAQ**

**PowerPoint スライドに数式を追加するにはどうすればよいですか？**

数式を追加するには、`MathShape` オブジェクトを作成します。このオブジェクトは自動的に数式部分を含みます。次に、`MathPortion` から `MathParagraph` を取得し、`MathBlock` オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい。Aspose.Slides は MathBlock を入れ子にすることで複雑な数式を作成できます。各数式要素は `IMathElement` インターフェイスを実装しており、Join、Divide、Enclose などの操作で要素を組み合わせてより複雑な構造にできます。

**既存の数式を更新または変更するにはどうすればよいですか？**

数式を更新するには、`MathParagraph` を介して既存の MathBlock にアクセスします。その後、Join、Divide、Enclose などのメソッドを使用して個々の要素を変更できます。編集後にプレゼンテーションを保存して変更を適用します。