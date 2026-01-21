---
title: JavaでPowerPointプレゼンテーションに数式を追加する
linktitle: PowerPoint数式
type: docs
weight: 80
url: /ja/java/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数式
- 数式テキスト
- 数式を追加
- 記号を追加
- 数式を追加
- テキストを追加
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java用Aspose.SlidesでPowerPoint PPTおよびPPTXに数式を挿入・編集でき、OMML、書式設定コントロール、明確なJavaコードサンプルをサポートします。"
---

## **Overview**
PowerPoint では、数式や式を書いてプレゼンテーションに表示することが可能です。そのために、PowerPoint ではさまざまな数学記号が用意されており、テキストや式に追加できます。PowerPoint の数式コンストラクタを使用すると、次のような複雑な数式を作成できます：

- Math Fraction → 数式分数
- Math Radical → 数式根号
- Math Function → 数式関数
- Limits and log functions → 極限および対数関数
- N-ary operations → N元演算
- Matrix → 行列
- Large operators → 大型演算子
- Sin, cos functions → 正弦・余弦関数

PowerPoint で数式を追加するには、*Insert -> Equation* メニューを使用します：

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML 形式の数式テキストが作成され、PowerPoint で次のように表示されます：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint には数式作成用の多くの数学記号がサポートされていますが、複雑な数式を作成すると、見栄えの良いプロフェッショナルな結果が得られないことが多いです。頻繁に数式プレゼンテーションを作成するユーザーは、見栄えの良い数式を作るためにサードパーティ製のソリューションを利用しています。

[**Aspose.Slide API**](https://products.aspose.com/slides/java/) を使用すると、C# で PowerPoint プレゼンテーション内の数式をプログラムから操作できます。新しい数式を作成したり、既存の数式を編集したりできます。また、数式構造を画像としてエクスポートする機能も一部サポートされています。

## **数式を作成する方法**
数学要素は、任意の入れ子構造を持つあらゆる数学的構造を構築するために使用されます。線形に並んだ数学要素のコレクションは、[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) クラスによって表される数学ブロックを形成します。[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) クラスは本質的に、個別の数式、式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) は数学テキストを保持する数学ポーションであり、[**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) と混同しないでください。[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) は複数の MathBlock を操作できるようにします。上記のクラスは、Aspose.Slides API を使用して PowerPoint の数式を操作するための重要な要素です。

以下の数式を Aspose.Slides API で作成する方法を見てみましょう：

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを格納するシェイプを追加します：

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

作成後、シェイプにはデフォルトで数式ポーションを含む段落が1つ入っています。[**MathPortion**] クラスは内部に数式テキストを保持するポーションです。[**MathPortion**] 内の数式コンテンツにアクセスするには、[**MathParagraph**] 変数を参照してください：

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

[**MathParagraph**] クラスでは、数式要素の組み合わせで構成される MathBlock（[**MathBlock**]）の読み取り、追加、編集、削除が可能です。例えば、分数を作成してプレゼンテーションに配置するには以下のようにします：

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

各数学要素は [**IMathElement**] インターフェイスを実装するクラスで表されます。このインターフェイスは数式を簡単に作成する多数のメソッドを提供します。1 行のコードでかなり複雑な数式を作成できます。例えば、ピタゴラスの定理は次のようになります：

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

[**IMathElement**] インターフェイスの操作は、[**MathBlock**] を含むすべての要素タイプで実装されています。

完全なサンプルコードは以下の通りです：

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);

    IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
    
    IMathFraction fraction = new MathematicalText("x").divide("y");

    mathParagraph.add(new MathBlock(fraction));

    IMathBlock mathBlock = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);

    pres.save("math.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
``` 

## **数学要素の種類**
数式は数学要素のシーケンスから構成されます。数学要素のシーケンスは数学ブロックで表され、要素の引数はツリー状の入れ子構造を形成します。

数学ブロックを構築するために使用できる多くの数学要素タイプがあります。各要素は他の要素に含める（集約）ことができ、要素は実質的に他の要素のコンテナとなり、ツリー構造を形成します。数学テキストの他の要素を含まない最も単純な要素タイプです。

各種数学要素は [**IMathElement**] インターフェイスを実装しており、異なるタイプの数学要素に共通の数式操作を利用できます。

### **MathematicalText クラス**
[**MathematicalText**] クラスは数学テキストを表すクラスで、すべての数学構造の基底要素です。数学テキストはオペランドや演算子、変数、その他の線形テキストを表すことができます。

**Example:** 𝑎=𝑏+𝑐

### **MathFraction クラス**
[**MathFraction**] クラスは分子と分母を分数バーで区切った分数オブジェクトを指定します。分数バーはプロパティに応じて水平または対角に設定できます。また、分数オブジェクトはスタック関数として使用でき、分数バーなしで要素を上下に配置します。

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
[**MathRadical**] クラスは根号関数（数学的ルート）を指定し、基底と任意の次数から構成されます。

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
[**MathFunction**] クラスは引数を取る関数を指定します。プロパティは [getName]（関数名） と [getBase]（関数の引数） です。

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
[**MathNaryOperator**] クラスは総和や積分などの N 元数学オブジェクトを指定します。演算子、基底（またはオペランド）、オプションの上限および下限から構成されます。N 元演算子の例として総和、合併、交差、積分があります。

このクラスには加算や減算などの単純な演算子は含まれません。これらは単一のテキスト要素である [MathematicalText] で表されます。

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
[**MathLimit**] クラスは上限または下限を作成します。ベースライン上のテキストと、その直上または直下に配置された縮小サイズのテキストからなるリミットオブジェクトを指定します。この要素は “lim” という文字は含まれませんが、式の上部または下部にテキストを配置できます。そのため、式は [**MathFunction**] と [**MathLimit**] 要素の組み合わせで次のように作成されます：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

以下のクラスは下添字または上添字を指定します。引数の左側または右側に同時に添字と上付き文字を設定できますが、単一の添字または上付き文字は右側のみでサポートされます。[MathSubscriptElement] は数値の指数を設定することもできます。

**例：**

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
[**MathMatrix**] クラスは、子要素が1つまたは複数の行・列に配置された行列オブジェクトを指定します。行列には組み込みのデリミタがないことに注意してください。行列を括弧で囲むには、デリミタオブジェクト [**IMathDelimiter**] を使用します。null 引数を使用して行列内に空白を作ることができます。

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
[**MathArray**] クラスは、式や任意の数学オブジェクトの垂直配列を指定します。

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素の書式設定**
- [**MathBorderBox**] クラス: [**IMathElement**] の周囲に矩形またはその他の枠線を描画します。  
  **例：** ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**] クラス: 数学要素の論理的なボックス化（パッケージ化）を指定します。例えば、ボックス化されたオブジェクトは整列点の有無にかかわらず演算子エミュレータとして使用でき、改行点として機能したり、行内改行を許可しないようにグループ化したりできます。例として、"==" 演算子は改行を防ぐためにボックス化すべきです。

- [**MathDelimiter**] クラス: 開始文字と終了文字（括弧、波かっこ、角括弧、縦棒など）で構成され、内部に1つ以上の数学要素を指定文字で区切って配置するデリミタオブジェクトを指定します。例: (𝑥2); [𝑥2|𝑦2]。  
  ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**] クラス: 基底と結合アクセント記号からなるアクセント関数を指定します。  
  **例：** 𝑎́.

- [**MathBar**] クラス: 基底引数と上バーまたは下バーからなるバー関数を指定します。  
  ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**] クラス: 式の上または下に配置され、要素間の関係を強調するためのグルーピング記号を指定します。  
  ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学操作**
各数学要素および数学式（[**MathBlock**] を介して）は [**IMathElement**] インターフェイスを実装しています。既存の構造に対して操作を行い、より複雑な数式を作成できます。すべての操作は 2 つのパラメータセットを持ち、[**IMathElement**] または文字列を引数として使用できます。文字列引数が使用される場合、[**MathematicalText**] クラスのインスタンスが暗黙的に作成されます。Aspose.Slides が提供する数式操作は以下の通りです。

### **Join メソッド**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

数学要素を結合して数学ブロックを形成します。例:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Divide メソッド**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

指定したタイプの分数を、分子と指定した分母で作成します。例:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose メソッド**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

要素を括弧やその他の文字で囲みます。

```java
/**
 * <p>
 * Enclose a math element in parenthesis
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Encloses this element in specified characters such as parenthesis or another characters as framing
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

例:

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function メソッド**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

現在のオブジェクトを関数名として、引数の関数を取得します。

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 

例:

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction メソッド**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

現在のインスタンスを引数として、指定した関数を取得します。次が可能です：

- 関数名を文字列で指定（例: "cos"）。
- 列挙型 [**MathFunctionsOfOneArgument**] または [**MathFunctionsOfTwoArguments**] の事前定義された値のいずれかを選択します。例: [**MathFunctionsOfOneArgument**] の [**ArcSin**]。
- [**IMathElement**] のインスタンスを選択します。

例:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft メソッド**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

下付き文字と上付き文字を設定します。引数の左側または右側に同時に下付き文字と上付き文字を設定できますが、単独の下付き文字または上付き文字は右側のみでサポートされます。**Superscript** は数値の指数を設定することもできます。

例:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical メソッド**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定した引数から、指定された次数の数学的根を設定します。

例:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

上限または下限を取得します。ここで、上限と下限は単に引数の基底に対する位置を示します。

以下の式を考えてみます：

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は、[MathFunction] と [MathLimit] クラスの組み合わせと [IMathElement] の操作で次のように作成できます：

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary と Integral メソッド**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary** と **integral** の両メソッドは、[**IMathNaryOperator**] タイプの N 元演算子を作成して返します。nary メソッドでは、[**MathNaryOperatorTypes**] 列挙体で演算子のタイプ（総和、合併など）を指定し、積分は含まれません。Integral メソッドでは、積分用の列挙体 [**MathIntegralTypes**] を使用します。

例:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray メソッド**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) は要素を垂直配列に配置します。[**MathBlock**] インスタンスに対してこの操作を呼び出すと、すべての子要素が返された配列に配置されます。

例:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **書式設定操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- [**accent**] メソッドは要素の上にアクセント記号（文字）を設定します。
- [**overbar**] と [**underbar**] メソッドは、要素の上部または下部にバーを設定します。
- [**group**] メソッドは、下括弧やその他のグルーピング文字を使用して要素をグループ化します。
- [**toBorderBox**] メソッドは要素を枠線ボックスに配置します。
- [**toBox**] メソッドは要素を非表示のボックス（論理的なグループ）に配置します。

例:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **よくある質問**

**PowerPoint スライドに数式を追加するにはどうすればよいですか？**

数式を追加するには、数式ポーションを自動的に含む MathShape オブジェクトを作成します。その後、[MathPortion] から [MathParagraph] を取得し、[MathBlock] オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい、Aspose.Slides を使用すれば MathBlock を入れ子にして複雑な数式を作成できます。各数学要素は [IMathElement] インターフェイスを実装しており、Join、Divide、Enclose などの操作で要素を組み合わせてより複雑な構造にできます。

**既存の数式を更新または変更するにはどうすればよいですか？**

数式を更新するには、[MathParagraph] を介して既存の MathBlock にアクセスします。その後、Join、Divide、Enclose などのメソッドを使用して数式の個々の要素を変更し、編集後にプレゼンテーションを保存して変更を適用します。