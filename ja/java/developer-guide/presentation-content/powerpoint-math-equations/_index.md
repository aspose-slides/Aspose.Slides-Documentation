---
title: PowerPoint 数学方程式
type: docs
weight: 80
url: /java/powerpoint-math-equations/
keywords: " PowerPoint 数学方程式, PowerPoint 数学シンボル, PowerPoint 数式, PowerPoint 数学テキスト"
description: "PowerPoint 数学方程式, PowerPoint 数学シンボル, PowerPoint 数式, PowerPoint 数学テキスト"
---

## **概要**
PowerPointでは、数学方程式や数式を書いてプレゼンテーションに表示することが可能です。そのために、さまざまな数学シンボルがPowerPointに表示され、テキストや方程式に追加できます。そのために、PowerPointでは数学方程式のコンストラクタを使用し、以下のような複雑な数式を作成します。

- 数学的分数
- 数学的根
- 数学的関数
- 極限および対数関数
- N-元演算
- 行列
- 大きな演算子
- サイン、コサイン関数

PowerPointに数学方程式を追加するには、*挿入 -> 方程式* メニューを使用します：

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、PowerPointで表示できるXML形式の数学テキストが作成されます：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPointは、数学方程式を作成するための多くの数学シンボルをサポートしています。ただし、PowerPointで複雑な数学方程式を作成することは、しばしば見栄えが良く、プロフェッショナルな結果をもたらさないことがあります。数学プレゼンテーションを頻繁に作成する必要があるユーザーは、外部のソリューションを利用して良い見栄えの数学式を作成する傾向があります。

[**Aspose.Slide API**](https://products.aspose.com/slides/java/)を使用することで、C#でPowerPointプレゼンテーション内の数学方程式をプログラム的に操作できます。新しい数学式を作成したり、以前に作成したものを編集したりできます。数学構造の画像へのエクスポートも部分的にサポートされています。


## **数学方程式の作成方法**
数学的要素は、任意のレベルのネストで数学的構造を構築するために使用されます。数学的要素の線形コレクションは、[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) クラスで表される数学ブロックを形成します。[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) クラスは本質的に分離された数学的表現、数式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) は数学的部分で、数学テキストを保持するために使用されます（[**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) と混合しないでください）。[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) は、一連の数学ブロックを操作することを可能にします。上記のクラスは、Aspose.Slides APIを介してPowerPoint数学方程式を操作する鍵です。

次の数学方程式をAspose.Slides APIを使用して作成する方法を見てみましょう：

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数学式を追加するには、最初に数学テキストを含む形状を追加します：

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

作成後、形状には既にデフォルトで1つの段落が数学的部分として含まれています。[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) クラスは、内部に数学テキストを含む部分です。[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) 内の数学的コンテンツにアクセスするには、[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) 変数を参照します：

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) クラスは、数学的要素の組み合わせから構成される数学ブロック（[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)）を読み取り、追加し、編集し、削除することを可能にします。例えば、分数を作成し、それをプレゼンテーションに配置します：

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

各数学的要素は、[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) インタフェースを実装するいくつかのクラスで表されます。このインタフェースは、数学的表現を簡単に作成するための多くのメソッドを提供します。1行のコードで比較的複雑な数学式を作成することができます。例えば、ピタゴラスの定理は次のように表現されます：

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) インタフェースの操作は、[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) を含む任意の要素のタイプに実装されています。

完全なソースコードサンプル：

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

## **数学的要素タイプ**
数学的表現は、数学的要素の配列から形成されます。数学的要素の配列は数学的ブロックで表され、数学的要素の引数は木のようなネストを形成します。

数学ブロックを構築するために使用できる数学要素のタイプはたくさんあります。これらの要素の各々は、他の要素に含めることができ（集約され）、実際には他の要素のコンテナとして機能し、木のような構造を形成します。最も単純なタイプの要素は、他の数学テキストの要素を含まないものです。

各数学要素タイプは、[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) インタフェースを実装しており、さまざまなタイプの数学要素に共通の数学操作を使用できるようにします。
### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) クラスは、数学的テキスト - すべての数学的構造の基本要素を表します。数学的テキストは、オペランド、演算子、変数、およびその他の任意の線形テキストを表すことができます。

例：𝑎=𝑏+𝑐
### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) クラスは、分子と分母が分数バーで区切られた分数オブジェクトを指定します。分数バーは、分数の特性に応じて水平または斜めにすることができます。分数オブジェクトは、分数バーなしで一つの要素を他の要素の上に置くスタック関数を表すためにも使用されます。

例：

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) クラスは、基数とオプションの指数を持つ根関数を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) クラスは、引数の関数を指定します。プロパティを含みます：[getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) - 関数名および[getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) - 関数引数。

例：

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) クラスは、総和や積分のようなN元の数学的オブジェクトを指定します。それは、演算子、基数（またはオペランド）、およびオプションの上限と下限から構成されます。N元の演算子の例として、総和、和、交差点、積分などがあります。

このクラスには、加算、減算などの単純な演算子は含まれません。それらは単一のテキスト要素 - [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) で表されます。

例：

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) クラスは、上限または下限を作成します。基準線上のテキストとそのすぐ上または下に小さくされたテキストから構成される制限オブジェクトを指定します。この要素には「lim」という単語は含まれませんが、式の上または下にテキストを配置できます。したがって、式

![todo:image_alt_text](powerpoint-math-equations_8.png)

は、このようにして[**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) と[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) 要素の組み合わせによって作成されます：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

次のクラスは下付き文字または上付き文字を指定します。引数の左側または右側に下付き文字と上付き文字を同時に設定できますが、単一の下付き文字または上付き文字は右側のみに対応しています。[MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) は数値の数学的指数を設定するためにも使用できます。

例：

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) クラスは、行と列にレイアウトされた子要素から構成される行列オブジェクトを指定します。行列には組み込みの区切り文字がないことに注意することが重要です。行列を括弧に入れるには、区切り文字オブジェクト - [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter) を使用する必要があります。null引数を使用して行列の隙間を作成できます。

例：

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) クラスは、方程式または任意の数学的オブジェクトの垂直配列を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **数学要素のフォーマット**
- [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox) クラス： [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)の周りに矩形またはその他の境界を描画します。
  
  例： ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox) クラス：数学要素の論理ボックス化（パッケージ化）を指定します。例えば、ボックス化されたオブジェクトは、整列点の有無にかかわらず演算子エミュレータとして機能したり、行の折り返しを防ぐためのラインブレークポイントとして機能したりできます。例えば、「==」演算子は行の折り返しを防ぐためにボックス化する必要があります。
- [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter) クラス：開閉文字（括弧、波かっこ、ブラケット、および縦棒など）で構成され、指定された文字で区切られた1つ以上の数学的要素を含む区切り文字オブジェクトを指定します。例：(𝑥2); [𝑥2|𝑦2]。
  
  例： ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent) クラス：基本と組み合わさったダイアクリティカルマークで構成されるアクセント関数を指定します。 

  例：𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar) クラス：ベース引数とオーバーバーまたはアンダーバーで構成されるバー関数を指定します。
  
  例： ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter) クラス：通常は要素間の関係を強調するために、式の上または下にグルーピング記号を指定します。
  
  例： ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **数学演算**
各数学要素と数学表現（[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)経由）は、[**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)インタフェースを実装しています。これにより、既存の構造に対して操作を使用し、より複雑な数学表現を形成できます。すべての操作には、2つのパラメータセットがあります：引数として[**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)または文字列。文字列引数が使用されると、[**MathematicalText** ](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) クラスのインスタンスは暗黙的に指定された文字列から作成されます。Aspose.Slidesで利用できる数学演算は以下に示す通りです。
### **Join メソッド**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

数学要素を結合し、数学ブロックを形成します。例えば：

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

指定された分子と指定された分母で指定されたタイプの分数を作成します。例えば：

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose メソッド**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

要素を括弧や他のキャラクターといった指定された文字で囲みます。

```java
/**
 * <p>
 * 数学要素を括弧で囲みます
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * この要素を括弧または他のフレーミング用の指定文字で囲みます
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 


例えば：

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function メソッド**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

このインスタンスを関数名として使用して引数の関数を取ります。

```java
/**
 * <p>
 * このインスタンスを関数名として使用して引数の関数を取ります
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * このインスタンスを関数名として使用して引数の関数を取ります
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 


例えば：

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction メソッド**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

現在のインスタンスを引数として指定された関数を取ります。あなたは：

- 関数名として文字列を指定できます。例えば「cos」。
- 列挙体のうち、[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument)または[**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments)のいずれかを選択できます。例えば、[**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin)。
- [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)のインスタンスを選択できます。

例えば：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft メソッド**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

下付き文字と上付き文字を設定します。引数の左側または右側に下付き文字と上付き文字を同時に設定できますが、単一の下付き文字または上付き文字は右側にのみ対応しています。**Superscript** は数字の数学的指数を設定するためにも使用できます。

例：

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical メソッド**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定された引数の指定された次数の数学的根を指定します。

例：

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

上限または下限を取得します。ここで、上限と下限は引数の基準に対する位置を示します。

式を考えてみましょう：

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は、[MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) および [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) クラスの組み合わせと、[IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) の操作を通じて次のように作成できます：

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

**nary** と **integral** メソッドの両方は、[**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator)タイプで表されるN-元演算子を作成して返します。naryメソッドでは、[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) 列挙型が演算子のタイプを指定します：和、和など、積分を含まない。Integralメソッドでは、[**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes)列挙型による特化された操作である積分があります。

例：

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray メソッド**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) は、要素を垂直配列に配置します。この操作が[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)インスタンスに対して呼び出されると、すべての子要素が返された配列に配置されます。

例：

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **フォーマット操作：Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) メソッドは、アクセントマーク（要素の上部に置くキャラクター）を設定します。
- [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) および [**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) メソッドは、上部または下部にバーを設定します。
- [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) メソッドは、ボトムカールブラケットなどのグルーピングキャラクターを使用してグループ化します。
- [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) メソッドはボーダーボックスに配置します。
- [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) メソッドは、非視覚ボックス（論理的グルーピング）に配置します。

例：

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 