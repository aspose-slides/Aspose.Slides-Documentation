---
title: Python で PowerPoint プレゼンテーションに数式を追加する
linktitle: 数式
type: docs
weight: 80
url: /ja/python-net/powerpoint-math-equations/
keywords:
- 数式
- PowerPoint 数式
- 数学記号
- PowerPoint 数学記号
- 数式
- PowerPoint 数式
- 数式テキスト
- PowerPoint 数式テキスト
- PowerPoint に数式を追加する
- PowerPoint に数学記号を追加する
- PowerPoint に数式を追加する
- PowerPoint に数式テキストを追加する
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint の数式を操作する方法を学びます。プレゼンテーションの作成と編集を自動化するための詳細な手順、コード例、ヒントを提供します。"
---

## **概要**

PowerPoint では、数式や方程式を書いてプレゼンテーションに表示できます。さまざまな数学記号が用意されており、テキストや数式に追加できます。数式コンストラクターは、次のような複雑な式を作成するために使用されます。

- 数学分数
- 数学根号
- 数学関数
- 極限および対数関数
- N 項演算子
- 行列
- 大きな演算子
- sin、cos 関数

PowerPoint で数式を追加するには、*Insert → Equation* メニューを使用します。

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、PowerPoint で次のように表示できる XML 形式の数式テキストが作成されます。

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は数式作成のために幅広い記号をサポートしていますが、複雑な数式を作成すると、必ずしも洗練されたプロフェッショナルな結果になりません。そのため、頻繁に数式プレゼンテーションを作成するユーザーは、見栄えの良い数式のためにサードパーティ製品を利用することが多くなっています。

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) を使用すれば、Python で PowerPoint プレゼンテーション内の数式をプログラムで操作できます。新しい数式を作成したり、既存の数式を編集したりできます。数式構造を画像としてエクスポートする部分的なサポートも提供されています。

## **数式の作成方法**

数式要素は入れ子レベルに関係なく任意の数式構造を構築するために使用されます。これらの要素の線形コレクションが数式ブロックを形成し、[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) クラスで表されます。[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) クラスは単独の数式・式・方程式を表します。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) は通常の [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) クラスとは別に数式テキストを保持し、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を使用して [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) オブジェクトの集合を操作できます。これらのクラスは Aspose.Slides API を介した PowerPoint 数式操作に不可欠です。

以下の数式を Aspose.Slides API で作成する方法を見てみましょう。

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを保持するシェイプを追加します。
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


シェイプを作成すると、デフォルトで数式部分を含む段落が 1 つ含まれています。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) クラスは数式テキストを含む部分を表します。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 内の数式コンテンツにアクセスするには、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 変数を参照してください。
```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) クラスを使って、数式要素の組み合わせで構成される数式ブロック ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) を読み取り、追加、編集、削除できます。たとえば、分数を作成してプレゼンテーションに配置します。
```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
``` 

```py
math_block = (
    math.MathematicalText("c").set_superscript("2").
        join("=").
        join(math.MathematicalText("a").set_superscript("2")).
        join("+").
        join(math.MathematicalText("b").set_superscript("2")))
```


[IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) インターフェイスの操作は、すべての要素タイプで実装されており、[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) クラスにも適用されます。

以下に完全なサンプルコードを示します。
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    math_paragraph.add(math.MathBlock(fraction))

    math_block = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    math_paragraph.add(math_block)

    presentation.save("math.pptx", slides.export.SaveFormat.PPTX)
```


## **数式要素の種類**

数式は数式要素のシーケンスで構成されます。数式ブロックはこのシーケンスを表し、要素の引数は入れ子構造のツリーを形成します。

数式ブロックを構築するために使用できる要素は多数あり、各要素は別の要素の中に集約できてツリー構造を作ります。最もシンプルな要素は、他の数式テキスト要素を含まないものです。

各数式要素は [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) インターフェイスを実装しており、共通の数式操作セットをさまざまな要素タイプで使用できます。

### **MathematicalText クラス**

[MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) クラスは数式テキストを表し、すべての数式構造の基礎要素です。数式テキストはオペランドや演算子、変数、またはその他の線形テキストを表すことがあります。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**

[MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) クラスは分子と分母で構成され、分数線で区切られる分数オブジェクトを指定します。分数線は水平または斜めに設定でき、分数プロパティに依存します。また、分数線なしで要素を上下に配置するスタック関数としても使用されます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**

[MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) クラスは根号（数学的ルート）を指定し、基底とオプションの次数から構成されます。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**

[MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) クラスは引数の関数を指定します。`name` プロパティで関数名を、`base` プロパティで関数の引数を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**

[MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) クラスは総和や積分などの N 項演算子を指定します。演算子、基底（またはオペランド）、オプションの上限・下限で構成されます。例として総和、和集合、積集合、積分があります。

このクラスは単純な加算や減算などの演算子は含みません。これらは単一テキストの [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) で表されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**

[MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) クラスは上限または下限を作成します。ベースライン上のテキストと、その直上または下に配置される縮小サイズのテキストで構成されます。`lim` という文字は含まれませんが、式の上部または下部にテキストを配置できます。

例:

![todo:image_alt_text](powerpoint-math-equations_8.png)

上記は [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) と [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) 要素の組み合わせで作成されています。
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

これらのクラスは下付きインデックスまたは上付きインデックスを指定します。左側または右側で同時に下付きと上付きの両方を設定できますが、単一の下付きまたは上付きは右側のみでサポートされます。また、[MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) は数の次数を設定するためにも使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**

[MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) クラスは子要素を 1 行以上の行と列に配置した行列オブジェクトを指定します。行列自体に区切り記号は組み込まれていないため、括弧で囲む場合は [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) を使用します。空の引数で行列の隙間を作れます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**

[MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) クラスは垂直方向の配列（複数の式や任意の数式オブジェクト）を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数式要素の書式設定**

- **MathBorderBox** クラス: [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) の周囲に矩形または代替の枠を描画します。

例:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- **MathBox** クラス: 数式要素の論理的なボックス化（パッケージ化）を指定します。ボックス化されたオブジェクトは、演算子エミュレータとして機能したり、改行ポイントとして使用したり、改行を防止するためにグループ化できます。例として「==」演算子は改行を防ぐためにボックス化すべきです。

- **MathDelimiter** クラス: 開始文字と終了文字（丸括弧、波かっこ、角括弧、縦棒など）で構成され、内部に 1 個以上の数式要素を含む区切り文字オブジェクトを指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- **MathAccent** クラス: 基底と結合アクセント記号からなるアクセント機能を指定します。

例: 𝑎́.

- **MathBar** クラス: 基底引数と上棒または下棒からなるバー機能を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- **MathGroupingCharacter** クラス: 式の上または下に配置され、要素間の関係を強調するためのグループ記号を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数式操作**

各数式要素と [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) を通じた数式全体は、[IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) インターフェイスを実装しています。これにより、既存の構造に対して操作を行い、より複雑な数式を構築できます。すべての操作は、[IMathElement] または文字列引数のいずれかを受け取ります。文字列引数が使用された場合、指定された文字列から暗黙的に [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) インスタンスが作成されます。Aspose.Slides が提供する数式操作は以下のとおりです。

### **Join メソッド**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

これらのメソッドは数式要素を結合し、数式ブロックを形成します。例:
```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```


### **Divide メソッド**

- [divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str)
- [divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement)
- [divide(String,MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str-mathfractiontypes)
- [divide(IMathElement,MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement-mathfractiontypes)

これらは指定されたタイプの分数を作成し、分子と分母を設定します。例:
```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Enclose メソッド**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char,Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

要素を指定した文字で囲むメソッドです（例: 丸括弧）。例:
```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **Function メソッド**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

現在のオブジェクトを関数名として、引数関数を作成します。例:
```py
function = math.MathematicalText("sin").function("x")
```


### **AsArgumentOfFunction メソッド**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

現在のインスタンスを引数として、指定された関数を適用します。たとえば:

- 関数名を文字列で指定（例: "cos"）
- 列挙型 [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) または [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/) から選択（例: `MathFunctionsOfOneArgument.ARC_SIN`）
- [IMathElement] のインスタンスを使用

例:
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
func1 = math.MathematicalText("2x").as_argument_of_function(function_name)
func2 = math.MathematicalText("x").as_argument_of_function("sin")
func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```


### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft メソッド**

- [set_subscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#str)
- [set_subscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#imathelement)
- [set_superscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#str)
- [set_superscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#imathelement)
- [set_sub_superscript_on_the_right(String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#str-str)
- [set_sub_superscript_on_the_right(IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#imathelement-imathelement)
- [set_sub_superscript_on_the_left(String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#str-str)
- [set_sub_superscript_on_the_left(IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#imathelement-imathelement)

これらは下付き・上付きインデックスを設定します。左右どちら側でも同時に設定可能ですが、単一の下付きまたは上付きは右側のみでサポートされます。**Superscript** は数の次数を設定することもできます。

例:
```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Radical メソッド**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

指定された引数に基づき、指定された次数の数学的根を設定します。

例:
```py
radical = math.MathematicalText("x").radical("3")
```


### **SetUpperLimit と SetLowerLimit メソッド**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

これらは上限または下限を設定します。"upper" と "lower" は基底に対する位置を示します。

例として次の式を考えます。

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) と [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/) クラス、および [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) の操作で作成できます。
```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```


### **Nary と Integral メソッド**

- [nary(MathNaryOperatorTypes,IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-imathelement-imathelement)
- [nary(MathNaryOperatorTypes,String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-str-str)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes)
- [integral(MathIntegralTypes,IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement)
- [integral(MathIntegralTypes,String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str)
- [integral(MathIntegralTypes,IMathElement,IMathElement,MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement-mathlimitlocations)
- [integral(MathIntegralTypes,String,String,MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str-mathlimitlocations)

`nary` と `integral` はいずれも [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) タイプのオブジェクトを生成して返します。`nary` メソッドでは [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) 列挙体で演算子の種類（総和や和集合など）を指定し、積分は除外されます。`integral` メソッドは積分専用の操作を提供し、[MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/) 列挙体で種類を指定します。

例:
```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **ToMathArray メソッド**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) は要素を垂直配列に配置します。これを [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) インスタンスで呼び出すと、すべての子要素が返された配列に配置されます。

例:
```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **書式設定操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**

- [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) メソッドは要素の上部にアクセント記号（文字）を付加します。
- [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) と [underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) メソッドはそれぞれ要素の上または下にバーを設定します。
- [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) メソッドは下部の波かっこなどのグルーピング文字で要素をまとめます。
- [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) メソッドは要素を枠付きボックスに配置します。
- [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) メソッドは視覚的でないボックス（論理的グルーピング）に配置します。

例:
```py
accent = math.MathematicalText("x").accent(chr(0x0303))
bar = math.MathematicalText("x").overbar()
group_chr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
        math.MathTopBotPositions.BOTTOM, 
        math.MathTopBotPositions.TOP)
border_box = math.MathematicalText("x+y+z").to_border_box()
boxed_operator = math.MathematicalText(":=").to_box()
```


## **FAQ**

**PowerPoint のスライドに数式を追加するにはどうすればよいですか？**

数式シェイプを作成するには、[create a math shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) メソッドでオブジェクトを作成します。作成されたシェイプは自動的に数式部分を含みます。次に、[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) から [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を取得し、[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) オブジェクトを追加します。

**複雑な入れ子数式を作成できますか？**

はい。Aspose.Slides は [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) を入れ子にすることで複雑な数式を作成できます。各数式要素は Join、Divide、Enclose などの操作を適用して、より複雑な構造に組み合わせられます。

**既存の数式を更新または変更するにはどうすればよいですか？**

数式を更新するには、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) から既存の [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) にアクセスします。その後、Join、Divide、Enclose などのメソッドを使用して数式の個々の要素を変更します。編集後にプレゼンテーションを保存すれば変更が適用されます。