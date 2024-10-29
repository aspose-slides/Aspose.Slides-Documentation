---
title: PowerPoint 数学方程式
type: docs
weight: 80
url: /ja/python-net/powerpoint-math-equations/
keywords: " PowerPoint 数学方程式, PowerPoint 数学記号, PowerPoint 数式, PowerPoint 数学テキスト, PowerPoint プレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでのPowerPoint 数学方程式、数学記号、数式、数学テキスト"
---

## **概要**
PowerPointでは、数学方程式や数式を作成してプレゼンテーションに表示することが可能です。そのために、さまざまな数学記号がPowerPointで表示され、テキストや方程式に追加できます。そのために、PowerPointでは数学方程式のコンストラクタが使用され、以下のような複雑な数式を作成するのに役立ちます：

- 数学分数
- 数学根号
- 数学関数
- 極限および対数関数
- N-項演算
- 行列
- 大きな演算子
- サイン、コサイン関数

PowerPointに数学方程式を追加するには、*挿入 -> 数式*メニューを使用します：

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、PowerPointで表示できるXML形式の数学テキストが作成されます：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPointは、多数の数学記号をサポートしており、数学方程式を作成できます。しかし、PowerPointで複雑な数学方程式を作成することは、しばしば良好で専門的な見た目の結果をもたらしません。数学プレゼンテーションを頻繁に作成する必要があるユーザーは、魅力的な数学式を作成するためにサードパーティのソリューションを使用することがよくあります。

[**Aspose.Slide API**](https://products.aspose.com/slides/python-net/)を使用すると、Pythonでプログラム的にPowerPointプレゼンテーション内の数学方程式に取り組むことができます。新しい数学式を作成するか、以前に作成されたものを編集します。数学構造の画像へのエクスポートも部分的にサポートされています。

## **数学方程式の作成方法**
数学要素は、任意の入れ子レベルの数学構造を構築するために使用されます。数学要素の線形コレクションは、[**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)クラスで表される数学ブロックを形成します。[**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)クラスは、本質的に分離された数学表現、数式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)は数学的な部分であり、数学テキストを保持するために使用されます（[**Portion**](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)と混同しないでください）。[**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)は、数学ブロックのセットを操作することを可能にします。前述のクラスは、Aspose.Slides APIを通じてPowerPointの数学方程式に取り組むための鍵となります。

Aspose.Slides APIを使用して次の数学方程式を作成する方法を見てみましょう：

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数学式を追加するには、最初に数学テキストが含まれるシェイプを追加します：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```

作成後、シェイプにはデフォルトで数学的な部分とともに1つの段落がすでに含まれています。[**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)クラスは、内部に数学テキストを含む部分です。[**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)内の数学的な内容にアクセスするには、[**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)変数を参照します：

```py
    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph
```

[**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)クラスは、数学要素の組み合わせから構成される数学ブロック（[**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)）を読み取り、追加し、編集し、削除することを可能にします。例えば、分数を作成してプレゼンテーションに配置します：

```py
    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))
```

各数学要素は、[**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)インターフェースを実装するクラスによって表されます。このインターフェースは、数学的表現を簡単に作成するための多数のメソッドを提供します。単一のコード行でかなり複雑な数学表現を作成できます。例えば、ピタゴラスの定理は次のようになります：

```py
    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))
```

インターフェース[**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)の操作は、[**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)を含む任意の種類の要素で実装されています。

完全なサンプルコード：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))

    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    mathParagraph.add(mathBlock)

    pres.save("math.pptx", slides.export.SaveFormat.PPTX)
```

## **数学要素の種類**
数学表現は、数学要素のシーケンスから形成されます。数学要素のシーケンスは数学ブロックとして表され、数学要素の引数は木のようなネストを形成します。

数学ブロックを構築するために使用できる数学要素の種類はたくさんあります。これらの要素のそれぞれは、他の要素に含まれる（集約される）ことができます。つまり、要素は実際には他の要素のコンテナとして機能し、木のような構造を形成します。最も単純なタイプの要素は、他の数学テキスト要素を含まない要素です。

各タイプの数学要素は、[**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)インターフェースを実装しており、さまざまなタイプの数学要素に対して共通の数学操作セットを使用することを可能にします。
### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)クラスは、数学的なテキスト - すべての数学構造の基盤となる要素を表します。数学的なテキストは、オペランド、演算子、変数、および任意の他の線形テキストを表すことができます。

例：𝑎=𝑏+𝑐
### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/)クラスは、分子と分母を分数バーで区切った分数オブジェクトを指定します。分数バーは、分数のプロパティに応じて水平または対角線的になることがあります。分数オブジェクトは、1つの要素を他の要素の上に配置するスタック関数を表すためにも使用され、分数バーはありません。

例：

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/)クラスは、基底とオプションの指数から構成される根号関数を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/)クラスは、引数の関数を指定します。プロパティを含みます：[Name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - 関数名と[Base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - 関数引数。

例：

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/)クラスは、総和や積分などのN-項数学オブジェクトを指定します。演算子、基底（またはオペランド）、およびオプションの上限と下限から構成されます。N-項演算子の例には、総和、和、交差、積分があります。

このクラスには、加算、減算などの単純な演算子は含まれていません。それらは、単一のテキスト要素 - [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)で表されます。

例：

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/)クラスは、上限または下限を作成します。ベースライン上のテキストとその直上または下に小さくなったテキストから構成される制限オブジェクトを指定します。この要素には「lim」という単語は含まれていませんが、式の上または下にテキストを配置することができます。したがって、式

![todo:image_alt_text](powerpoint-math-equations_8.png)

は、[**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/)と[**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/)要素の組み合わせを使用してこのように作成されます：

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
    mathFunc = math.MathFunction(funcName, math.MathematicalText("𝑥"))
```

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

以下のクラスは、下付きインデックスまたは上付きインデックスを指定します。引数の左または右側で同時に下付きおよび上付き文字を設定できますが、単一の下付きまたは上付き文字は右側でのみサポートされています。[MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)は、数値の数学的な指数を設定するためにも使用できます。

例：

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/)クラスは、1つ以上の行と列に配置された子要素から成る行列オブジェクトを指定します。行列には組み込みの区切り文字がないことに注意することが重要です。行列を括弧で囲むには、区切り文字オブジェクト - [**IMathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/)を使用する必要があります。null引数は、行列にギャップを作成するために使用できます。

例：

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/)クラスは、方程式または任意の数学オブジェクトの縦の配列を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **数学要素のフォーマット**
- [**MathBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/)クラス： 表示要素の周りに矩形または他の境界を描画します。
  
  例： ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/)クラス：数学的要素の論理的ボックス化（パッケージング）を指定します。たとえば、ボックス化されたオブジェクトは、整列ポイントの有無にかかわらず演算子エミュレーターとして機能したり、行の改行を防ぐためにグループ化されたりします。たとえば、「==」演算子は、改行を防ぐためにボックス化される必要があります。
- [**MathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/)クラス：開閉文字（括弧、波括弧、角括弧、垂直バーなど）からなる区切り文字オブジェクトを指定し、その内部に1つ以上の数学要素を指定した文字で区切って含めます。例：(𝑥2); [𝑥2|𝑦2].
  
  例： ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/)クラス： 基底と結合ダイアクリティカルマークからなるアクセント関数を指定します。 

  例： 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/)クラス： 基底引数とオーバーバーまたはアンダーバーからなるバー関数を指定します。
  
  例： ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/)クラス： 表現の上または下に群れのシンボルを指定し、通常は要素間の関係を強調します。
  
  例： ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学操作**
各数学要素および数学表現（[**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)を介して）は、[**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)インターフェースを実装します。これにより、既存の構造に対して操作を使用し、より複雑な数学表現を形成できます。すべての操作には、引数として[**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)または文字列の2つのパラメータセットが存在します。文字列引数が使用されている場合、[**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)クラスのインスタンスは明示的に指定された文字列から作成されます。Aspose.Slidesで利用可能な数学操作は以下の通りです。
### **Join メソッド**
- [Join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

数学要素を結合し、数学ブロックを形成します。たとえば：

```py
    element1 = math.MathematicalText("x")
    element2 = math.MathematicalText("y")
    block = element1.join(element2)
```
### **Divide メソッド**
- [Divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

指定された型の分数を、この分子と指定された分母で作成します。たとえば：

```py
    numerator = math.MathematicalText("x")
    fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```
### **Enclose メソッド**
- [Enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

要素を指定された文字（括弧など）で囲みます。

```py
# 数学要素を括弧で囲みます
MathDelimiter enclose()

# 指定された文字でこの要素を囲みます
MathDelimiter enclose(char beginningCharacter, char endingCharacter)
```

たとえば：

```py
    delimiter = math.MathematicalText("x").enclose('[', ']')
    delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```
### **Function メソッド**
- [Function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

関数名として現在のオブジェクトを使って引数の関数を取得します。

たとえば：

```py
func = math.MathematicalText("sin").function("x")
```
### **AsArgumentOfFunction メソッド**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

指定された関数を使用して、現在のインスタンスを引数として扱います。次のことができます：

- 関数名として文字列を指定します。例えば「cos」。
- 列挙値[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/)のいずれかを選びます。例えば**MathFunctionsOfOneArgument.ArcSin.**
- [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)のインスタンスを選択します。

たとえば：

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
    func1 = math.MathematicalText("2x").as_argument_of_function(funcName)
    func2 = math.MathematicalText("x").as_argument_of_function("sin")
    func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
    func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```
### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft メソッド**
- [SetSubscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

下付き文字と上付き文字を設定します。引数の左または右側で同時に下付きおよび上付き文字を設定できますが、単一の下付きまたは上付き文字は右側でのみサポートされています。**Superscript**は、数値の数学的な指数を設定するためにも使用できます。

例：

```py
    script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```
### **Radical メソッド**
- [Radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

指定された引数から指定された次数の数学的な根を指定します。

例：

```py
    radical = math.MathematicalText("x").radical("3")
```
### **SetUpperLimit および SetLowerLimit メソッド**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

上限または下限を取得します。ここで、上限と下限は単にベースに対する引数の位置を示します。

式を考えます：

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は、[MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/)と[MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/)クラスの組み合わせおよび[IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)の操作を使用して次のように作成できます：

```py
mathExpression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```
### **Nary および Integral メソッド**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

**Nary**と**Integral**メソッドは、[**INaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathnaryoperator/)タイプで表されたN-項演算子を作成して返します。Naryメソッドでは、[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/)列挙が演算子のタイプを指定し、総和、和など、積分を含めません。Integralメソッドでは、積分型の列挙[**MathIntegralTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/)を使用した特別な操作が存在します。 

例：

```py
    baseArg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
    integral = baseArg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```
### **ToMathArray メソッド**
[**ToMathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)は要素を縦の配列に配置します。この操作が**MathBlock**インスタンスに対して呼び出されると、すべての子要素が返された配列に配置されます。

例：

```py
    arrayFunction = math.MathematicalText("x").join("y").to_math_array()
```
### **フォーマット操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- [**Accent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)メソッドは、アクセントマーク（要素の上にある文字）を設定します。
- [**Overbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)および[**Underbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)メソッドは、上または下にバーを設定します。
- [**Group**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)メソッドは、底のカールブレースや他のグループ化文字を使用してグループ化します。
- [**ToBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)メソッドは、ボーダーボックスに配置します。
- [**ToBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)メソッドは、非視覚的ボックス（論理的グループ化）に配置します。

例：

```py
    accent = math.MathematicalText("x").accent(chr(0x0303))
    bar = math.MathematicalText("x").overbar()
    groupChr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
            math.MathTopBotPositions.BOTTOM, 
            math.MathTopBotPositions.TOP)
    borderBox = math.MathematicalText("x+y+z").to_border_box()
    boxedOperator = math.MathematicalText(":=").to_box()
```