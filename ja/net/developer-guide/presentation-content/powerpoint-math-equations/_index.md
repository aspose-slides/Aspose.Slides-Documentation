---
title: PowerPoint 数学方程式
type: docs
weight: 80
url: /ja/net/powerpoint-math-equations/
keywords: " PowerPoint 数学方程式, PowerPoint 数学記号, PowerPoint 数式, PowerPoint 数学テキスト, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET における PowerPoint 数学方程式、数学記号、数式、数学テキスト"
---

## **概要**
PowerPoint では、数学方程式や数式を書くことができ、プレゼンテーション内で表示することができます。そのために、さまざまな数学記号が PowerPoint で表現され、テキストや方程式に追加できます。そのための数学方程式のコンストラクターが PowerPoint で使用され、以下のような複雑な数式を作成するのに役立ちます：

- 数学的分数
- 数学的根号
- 数学的関数
- 限界および対数関数
- N-元演算
- 行列
- 大きな演算子
- サイン、コサイン関数

PowerPoint に数学方程式を追加するには、*挿入 -> 方程式* メニューを使用します：

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、PowerPoint で以下のように表示できる XML 形式の数学テキストが作成されます：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は多くの数学記号をサポートしており、数学方程式を作成できます。しかし、PowerPoint で複雑な数学方程式を作成すると、しばしば見栄えが良く、プロフェッショナルに見える結果をもたらしません。数学的なプレゼンテーションを頻繁に作成する必要があるユーザーは、見栄えの良い数学式を作成するためにサードパーティのソリューションを利用することが多いです。

[**Aspose.Slide API**](https://products.aspose.com/slides/net/)を使用すれば、C# でプログラム的に PowerPoint プレゼンテーション内の数学方程式に対処できます。新しい数学的表現を作成したり、以前に作成されたものを編集したりできます。数学構造を画像にエクスポートすることも部分的にサポートされています。


## **数学方程式を作成する方法**
数学要素は、任意のネスト階層で数学的構造を構築するために使用されます。数学要素の線形コレクションは、[**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)クラスによって表される数学的ブロックを形成します。 [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)クラスは、実質的に分離された数学的表現、数式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)は数学的部分であり、数学的テキストを保持するために使用されます（[**Portion**](https://reference.aspose.com/slides/net/aspose.slides/portion)とは混同しないでください）。[**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)は、数学的ブロックのセットを操作できるようにします。上述のクラスは、Aspose.Slides API を介して PowerPoint 数学方程式を操作するための鍵となります。

Aspose.Slides API を使用して、次の数学方程式を作成する方法を見てみましょう：

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数学的表現を追加するには、まず数学テキストを含む形状を追加します：

``` csharp

 using (Presentation pres = new Presentation())

{

    var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

}

```


作成後、形状にはデフォルトで数学部分を含む1つの段落が含まれます。[**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)クラスは、内部に数学的テキストを含む部分です。[**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)内の数学的コンテンツにアクセスするには、[**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)変数を参照します：

``` csharp

 var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

```


[**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)クラスは、数学ブロック（[**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock））を読み取り、追加、編集、削除することを許可します。これらの数学ブロックは、数学要素の組み合わせで構成されています。例えば、分数を作成し、プレゼンテーションに配置する場合：

``` csharp

 var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));

```


各数学要素は、[**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)インターフェースを実装したクラスによって表されます。このインターフェースは、数学的表現を簡単に作成するための多くのメソッドを提供します。単一行のコードでかなり複雑な数学的表現を作成することができます。例えば、ピタゴラスの定理は次のようになります：

``` csharp

 var mathBlock = new MathematicalText("c")

    .SetSuperscript("2")

    .Join("=")

    .Join(new MathematicalText("a").SetSuperscript("2"))

    .Join("+")

    .Join(new MathematicalText("b").SetSuperscript("2"));

```



[**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)インターフェースの操作は、[**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)を含む任意の型の要素に実装されています。

完全なソースコードサンプル：

``` csharp

 using (Presentation pres = new Presentation())

{

    IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

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

    pres.Save("math.pptx", SaveFormat.Pptx);

}

```


## **数学要素の種類**
数学表現は、数学要素の列から形成されます。数学要素の列は数学ブロックとして表され、数学要素の引数は木のようなネストを形成します。

さまざまな数学要素のタイプがあり、それらを使って数学ブロックを構築できます。これらの要素のそれぞれは、他の要素に含まれたり（集約されたり）することができます。つまり、要素は実際には他の要素を含むコンテナであり、木のような構造を形成します。最も単純な要素のタイプは、他の数学テキストの要素を含まない要素です。

各数学要素のタイプは、[**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)インターフェースを実装しており、さまざまなタイプの数学要素に共通の数学操作セットを使用できるようにしています。
### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext)クラスは、数学的テキストを表します - すべての数学構造の基礎となる要素です。数学的テキストは、オペランドと演算子、変数、その他の線形テキストを表します。

例: 𝑎=𝑏+𝑐
### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction)クラスは、分子と分母を分数バーで区切った分数オブジェクトを指定します。分数バーは、分数の特性に応じて水平または対角線状であることがあります。分数オブジェクトは、1つの要素を別の要素の上に配置するスタック機能を表すためにも使用されますが、分数バーはありません。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical)クラスは、基数およびオプションの指数からなるルート関数（数学的根）を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction)クラスは、引数の関数を指定します。プロパティには、[Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) - 関数名と [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) - 関数引数が含まれます。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator)クラスは、総和や積分のような N-元数学オブジェクトを指定します。オペレーター、ベース（またはオペランド）、およびオプションの上限と下限から構成されます。N-元演算子の例には、総和、和集合、交差、積分があります。

このクラスには加算、減算などの単純な演算子は含まれていません。それらは単一のテキスト要素で表されます - [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext)。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit)クラスは、上限または下限を作成します。それは、ベースラインの上のテキストとすぐ上または下にある縮小されたサイズのテキストからなる制限オブジェクトを指定します。この要素には「lim」という単語は含まれず、表現の上部または下部にテキストを配置することができます。したがって、以下の表現が作成されます。

![todo:image_alt_text](powerpoint-math-equations_8.png)

これは、[**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction)と [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit)要素の組み合わせを使用して、このように作成されます：

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));

```


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

これらのクラスは、下付きインデックスや上付きインデックスを指定します。引数の左側または右側に同時に下付き文字と上付き文字を設定できますが、単一の下付きまたは上付き文字は右側のみにサポートされています。[MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)は、数の数学的指数を設定するためにも使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix)クラスは、子要素が1つまたはそれ以上の行と列に配置された行列オブジェクトを指定します。行列には構built-in デリミタはありません。行列を括弧に配置するには、デリミタオブジェクト - [**IMathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter)を使用する必要があります。Null 引数を使用して行列にギャップを作成できます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray)クラスは、数式や任意の数学的オブジェクトの垂直配列を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **数学要素の書式設定**
- [**MathBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox)クラス: [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)の周りに矩形または他のボーダーを描画します。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox)クラス: 数学要素の論理ボックス（パッケージング）を指定します。たとえば、ボックス化されたオブジェクトは、整列ポイントの有無にかかわらずオペレーターエミュレーターとして機能したり、行のブレークポイントとして機能したり、行内で行のブレークを許可しないようにグループ化されたりすることができます。たとえば、「==」演算子は行のブレークを防ぐためにボックス化されるべきです。
- [**MathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter)クラス: 開括弧と閉括弧（括弧、波括弧、角括弧、垂直バーなど）からなるデリミタオブジェクトを指定し、その内部に1つ以上の数学的要素を指定された文字で区切って含めます。例: (𝑥2); [𝑥2|𝑦2].
  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent)クラス: 基数と結合されたダイアクリティカルマークからなるアクセント関数を指定します。

  例: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar)クラス: 基数引数と上バーまたは下バーからなるバー関数を指定します。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter)クラス: 要素の間の関係を強調表示するために、式の上または下にグルーピングシンボルを指定します。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **数学的操作**
各数学要素および数学表現（[**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)を介して）は、[**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)インターフェースを実装しています。これにより、既存の構造に対して操作を行い、より複雑な数学的表現を形成できます。すべての操作には、2つのパラメータセットがあります：引数として [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)または文字列を使用できます。文字列引数が使用される場合、[**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText)クラスのインスタンスは明示的に指定されている文字列から作成されます。Aspose.Slidesで利用できる数学操作は以下のとおりです。
### **Join メソッド**
- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

数学要素を結合して数学ブロックを形成します。例えば：

``` csharp

 IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);

```
### **Divide メソッド**
- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

指定された型の分数を、この分子および指定された分母で作成します。例えば：

``` csharp

 IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);

```
### **Enclose メソッド**
- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

要素を指定された文字（括弧など）で囲みます。

``` csharp

 /// <summary>

/// 数学要素を括弧で囲みます。

/// </summary>

IMathDelimiter Enclose();

/// <summary>

/// この要素を括弧などの他の指定された文字で囲みます。

/// </summary>

IMathDelimiter Enclose(char beginningCharacter, char endingCharacter);

```


例えば：

``` csharp

 IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();

```
### **Function メソッド**
- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

現在のオブジェクトを関数名として使用して引数の関数を取得します。

``` csharp

 /// <summary>

/// このインスタンスを関数名として使用して引数の関数を取得します。

/// </summary>

/// <param name="functionArgument">関数の引数</param>

IMathFunction Function(IMathElement functionArgument);

IMathFunction Function(string functionArgument);

```


例えば：

``` csharp

 IMathFunction func = new MathematicalText("sin").Function("x");

```
### **AsArgumentOfFunction メソッド**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

現在のインスタンスを引数として使用して指定された関数を取得します。次のことができます：

- 文字列を関数名として指定します。たとえば、「cos」。
- 列挙体 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument)または [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments)の定義済み値のいずれかを選択します。たとえば、**MathFunctionsOfOneArgument.ArcSin.**
- [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)のインスタンスを選択します。

例えば：

``` csharp

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
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

下付き文字と上付き文字を設定します。引数の左側または右側に同時に下付き文字と上付き文字を設定できますが、単一の下付きまたは上付き文字は右側のみにサポートされています。**上付き文字**は、数の数学的指数を設定するためにも使用できます。

例：

``` csharp

 var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");

```
### **Radical メソッド**
- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

指定された引数から指定された指数の数学的根を指定します。

例：

``` csharp

 var radical = new MathematicalText("x").Radical("3");

```
### **SetUpperLimit と SetLowerLimit メソッド**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

上限または下限を取得します。ここで、上限と下限は引数がベースに対してどの位置にあるかを示します。

次の式を考えます： 

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような表現を [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction)と[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit)クラスの組み合わせを通じて、そして [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)の操作で作成できます：

``` csharp

 var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");

```
### **N-元および積分メソッド**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

**N-元**メソッドと**Integral**メソッドは、[**INaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator)タイプで表される N-元演算子を作成して返します。N-元メソッドでは、[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes)列挙体が演算子のタイプを指定します：総和、和集合など、積分は含まれません。積分メソッドでは、積分型の列挙体 [**MathIntegralTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes)を使用した特化した演算積分があります。 

例：

``` csharp

 IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());

IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");

```
### **ToMathArray メソッド**
[**ToMathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray)は、要素を垂直配列に配置します。この操作が **MathBlock** インスタンスに対して呼び出されると、すべての子要素が返された配列に配置されます。

例：

``` csharp

 var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();

```
### **書式設定操作: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**Accent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent)メソッド：アクセントマーク（要素の上部にある文字）を設定します。
- [**Overbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar)および [**Underbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar)メソッド：上部または下部にバーを設定します。
- [**Group**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group)メソッド：ボトムカールブラケットや他のグルーピング文字などを使用してグループに配置します。
- [**ToBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox)メソッド：ボーダーボックスに配置します。
- [**ToBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox)メソッド：非視覚ボックス（論理グループ化）に配置します。

例：

``` csharp

 var accent = new MathematicalText("x").Accent('\u0303');

var bar = new MathematicalText("x").Overbar();

var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

var borderBox = new MathematicalText("x+y+z").ToBorderBox();

var boxedOperator = new MathematicalText(":=").ToBox();

```