---
title: PythonでPowerPointプレゼンテーションに数式を追加する
linktitle: 数式
type: docs
weight: 80
url: /ja/python-net/powerpoint-math-equations/
keywords:
- 数式
- PowerPoint数式
- 数学記号
- PowerPoint数学記号
- 数学式
- PowerPoint数学式
- 数学テキスト
- PowerPoint数学テキスト
- PowerPointに数式を追加する
- PowerPointに数学記号を追加する
- PowerPointに数学式を追加する
- PowerPointに数学テキストを追加する
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint の数式を操作する方法を学びます。プレゼンテーションの作成と編集を自動化するための詳細な手順、コード例、ヒントが提供されています。"
---

## **概要**

PowerPoint では、数式や数式式を書き込み、プレゼンテーションに表示できます。さまざまな数学記号が利用可能で、テキストや数式に追加できます。数式コンストラクタは、次のような複雑な式を作成するために使用されます。

- 数学分数
- 数学根号
- 数学関数
- 極限および対数関数
- N 進演算子
- 行列
- 大きな演算子
- 正弦、余弦関数

PowerPoint で数式を追加するには、*Insert → Equation* メニューを使用します。

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、PowerPoint で次のように表示できる XML 形式の数式テキストが作成されます。

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は数式作成のために幅広い記号をサポートしていますが、複雑な数式を作成すると結果が必ずしも洗練されたプロフェッショナルなものになりません。そのため、頻繁に数式プレゼンテーションを作成するユーザーは、見栄えの良い数式のためにサードパーティ製ソリューションを利用することが多くなります。

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) を使用すると、Python で PowerPoint プレゼンテーション内の数式をプログラムから操作できます。新しい数式を作成したり、既存の数式を編集したりできます。数式構造を画像としてエクスポートする部分的なサポートも提供されています。

## **数式の作成方法**

数学要素は、入れ子レベルに関係なく任意の数式構造を構築するために使用されます。これらの要素の線形コレクションが数式ブロックを形成し、[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) クラスで表されます。[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) クラスは、単体の数式、式、または方程式を表します。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) は、通常の [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) クラスとは別に数学テキストを保持するために使用され、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) は [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) オブジェクトの集合を操作できるようにします。これらのクラスは、Aspose.Slides API を介して PowerPoint の数式を操作する際に不可欠です。

以下に、Aspose.Slides API を使用して次の数式を作成する方法を示します。

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式表現を追加するには、まず数式テキストを保持するシェイプを追加します。
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


シェイプを作成すると、デフォルトで 1 つの段落が数式ポーションとして含まれています。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) クラスは数式テキストを含むポーションを表します。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 内の数式コンテンツにアクセスするには、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 変数を参照してください。
```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) クラスを使用すると、数式要素の組み合わせで構成された [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) を読み取り、追加、編集、削除できます。たとえば、分数を作成してプレゼンテーションに配置します。
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


[IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) クラスの操作は、すべての要素タイプに実装されており、[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) クラスも含まれます。

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


## **数学要素の種類**

数学式は数学要素のシーケンスで構成されます。数学ブロックはそのシーケンスを表し、要素の引数は入れ子構造のツリーを形成します。

数学ブロックを構築するために使用できる要素タイプは多数あります。各要素は別の要素内に集約でき、ツリー構造を作ります。最もシンプルな要素は、他の数学テキスト要素を一切含まないものです。

各数学要素は [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) を実装しており、共通の数式操作セットをさまざまな要素に適用できます。

### **MathematicalText クラス**

[MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) クラスは、すべての数学構造の基礎要素である数学テキストを表します。数学テキストはオペランド、演算子、変数、または任意の線形テキストを表すことがあります。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**

[MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) クラスは、分子と分母が分数バーで区切られた分数オブジェクトを指定します。分数バーは水平または対角線になることがあり、分数オブジェクトはスタック関数（要素をバーなしで上下に配置）にも使用されます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**

[MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) クラスは、基数と任意の次数からなる根号（数学的ルート）関数を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**

[MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) クラスは、引数を取る関数を指定します。`name` プロパティは関数名、`base` プロパティは関数の引数を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**

[MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) クラスは、総和や積分などの N 進数学オブジェクトを指定します。演算子、基数（または被演算子）に加えて、任意の上限・下限を持ちます。例: 総和、和集合、交差、積分。

このクラスは加算や減算などの単純演算子は含みません。これらは単一のテキスト [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) で表現されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**

[MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) クラスは上限または下限を作成します。ベースライン上のテキストと、その上または下に配置される縮小テキストから構成されます。`lim` という文字列は含まれませんが、式の上部または下部にテキストを配置できます。たとえば、次の式は

![todo:image_alt_text](powerpoint-math-equations_8.png)

次のように [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) と [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) を組み合わせて作成されます。
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

これらのクラスは下付標または上付標を指定します。左または右側に同時に下付標と上付標を設定できますが、単一の下付標または上付標は右側でのみサポートされます。[MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) は数の次数を設定するためにも使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**

[MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) クラスは、子要素が1行以上の行と列に配置された行列オブジェクトを指定します。行列にはデフォルトで区切り記号がないことに注意してください。括弧で囲む場合は [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) を使用します。`null` 引数を使用して行列のギャップを作成できます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**

[MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) クラスは、垂直方向の式または任意の数学オブジェクトの配列を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素の書式設定**

- [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) クラス: [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) の周囲に矩形または代替の枠線を描画します。

例:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) クラス: 数学要素の論理的なボックス化（パッケージ化）を指定します。ボックス化されたオブジェクトは、配置ポイントの有無にかかわらず演算子エミュレータとして機能したり、改行ポイントとして使用したり、改行を防止するためにグループ化したりできます。例: `"=="` 演算子は改行を防止するためにボックス化すべきです。

- [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) クラス: 開始文字と終了文字（括弧、波かっこ、角かっこ、縦棒など）と、指定文字で区切られた 1 つ以上の数学要素からなる区切りオブジェクトを指定します。例: (𝑥²); [𝑥²|𝑦²]。

例:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) クラス: 基底と組み合わせ文字アクセントからなるアクセント機能を指定します。

例: 𝑎́。

- [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) クラス: 基底引数と上バーまたは下バーからなるバー機能を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) クラス: 式の上または下に配置され、要素間の関係を強調するためのグルーピング記号を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学操作**

各数学要素および各数学式（[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) を通じて）は、[IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) クラスを実装しています。これにより、既存の構造に対して操作を行い、より複雑な数学式を形成できます。すべての操作は 2 つのパラメータセットを受け取ります：`IMathElement` または文字列です。文字列引数が使用される場合、指定された文字列から暗黙的に [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) インスタンスが作成されます。Aspose.Slides で利用可能な数学操作は以下の通りです。

### **Join メソッド**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

これらのメソッドは数学要素を結合し、数学ブロックを形成します。例:
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

これらは指定されたタイプの分数を分子と分母で作成します。例:
```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Enclose メソッド**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char,Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

これらは要素を指定した文字（括弧など）で囲みます。例:
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

現在のインスタンスを引数として、指定された関数を適用します。例:

- 関数名を文字列で指定（例: "cos"）;
- 列挙型 [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) または [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/) の事前定義値を使用（例: `MathFunctionsOfOneArgument.ARC_SIN`）;
- [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) のインスタンスを使用。

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

これらは下付標と上付標を設定します。左側または右側のどちらでも同時に設定可能ですが、単一の下付標または上付標は右側でのみサポートされます。**Superscript** は数の次数を設定するためにも使用できます。

例:
```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Radical メソッド**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

指定した引数の次数に基づく数学的根号を設定します。

例:
```py
radical = math.MathematicalText("x").radical("3")
```


### **SetUpperLimit と SetLowerLimit メソッド**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

上限または下限を設定します。"upper" と "lower" は基底に対する位置を示します。

次の式を考えてみます。

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は、[MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) と [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/) クラスの組み合わせ、および [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) の操作で作成できます。
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

`nary` と `integral` の両メソッドは、[MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) 型で表される N 進演算子を生成して返します。`nary` メソッドでは、`MathNaryOperatorTypes` 列挙型で総和や和集合などの演算子タイプを指定し、積分は除外されます。`integral` メソッドは積分専用の操作を提供し、`MathIntegralTypes` 列挙型で種類を指定します。

例:
```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **ToMathArray メソッド**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) は要素を垂直配列に配置します。この操作を [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) インスタンスで呼び出すと、すべての子要素が配列に入ります。

例:
```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **書式設定操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**

- [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) メソッドは、要素の上にアクセント記号（文字）を設定します。
- [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) と [underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) メソッドは、要素の上部または下部にバーを設定します。
- [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) メソッドは、下側の波かっこなどのグルーピング文字を使用して要素をグループ化します。
- [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) メソッドは、要素を境界ボックスに配置します。
- [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) メソッドは、視覚的ではなく論理的なボックス（グルーピング）に配置します。

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

数式シェイプを作成するには、[create a math shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) オブジェクトを作成します。このシェイプは自動的に数式ポーションを含みます。次に、[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) から [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を取得し、[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい。Aspose.Slides は [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) を入れ子にすることで、複雑な数式を作成できます。各数学要素は Join、Divide、Enclose などの操作を適用でき、より高度な構造に組み合わせられます。

**既存の数式を更新または変更するにはどうすればよいですか？**

数式を更新するには、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を介して既存の [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) にアクセスします。その後、Join、Divide、Enclose などのメソッドを使用して式の個々の要素を変更し、編集後にプレゼンテーションを保存して変更を適用します。