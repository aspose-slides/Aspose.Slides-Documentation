---
title: JavaでPowerPointプレゼンテーションに数式を追加
linktitle: PowerPoint数式
type: docs
weight: 80
url: /ja/java/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数学式
- 数学テキスト
- 数式を追加
- 記号を追加
- 式を追加
- テキストを追加
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint の PPT および PPTX に数式を挿入・編集できます。OMML、書式設定コントロールに対応し、わかりやすい Java コードサンプルを提供します。"
---

## **概要**
PowerPoint では、数式や式を書いてプレゼンテーションに表示できます。そのために PowerPoint にはさまざまな数学記号が用意されており、テキストや数式に追加できます。これには PowerPoint の数式コンストラクタを使用し、以下のような複雑な式を作成できます。

- Math Fraction
- Math Radical
- Math Function
- Limits and log functions
- N-ary operations
- Matrix
- Large operators
- Sin, cos functions

PowerPoint で数式を追加するには、*挿入 → 数式* メニューを使用します。

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、PowerPoint で次のように表示される XML の数式テキストが作成されます。

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は多数の数学記号をサポートしていますが、複雑な数式を作成すると見栄えが良くないことがあります。頻繁に数式プレゼンテーションを作成するユーザーは、サードパーティ製のソリューションを利用して綺麗な数式を作成しています。

[**Aspose.Slide API**](https://products.aspose.com/slides/java/) を使用すると、C# で PowerPoint の数式をプログラムから操作できます。新しい数式を作成したり、既存の数式を編集したりできます。また、数式構造を画像にエクスポートする機能も部分的にサポートされています。

## **数式の作成方法**
数学要素は任意の入れ子レベルで数学構造を構築するために使用されます。線形に並んだ数学要素の集合は、[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) クラスで表される数学ブロックとなります。[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) クラスは、分離された数式、式、または方程式を表します。[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) は数式テキストを保持する数学要素であり、[**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) とは混同しません。[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) は MathBlock の集合を操作できるクラスです。これらのクラスは Aspose.Slides API を介して PowerPoint の数式を操作する鍵となります。

以下の数式を Aspose.Slides API で作成する例です。

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを保持するシェイプを追加します。

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

作成後、シェイプにはデフォルトで 1 つの段落が含まれ、その段落には数学要素が 1 つ入った MathPortion が含まれます。MathPortion クラスは数式テキストを保持する要素です。MathPortion 内の数式コンテンツにアクセスするには、[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) 変数を参照します。

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) クラスは、数学要素の組み合わせで構成される MathBlock ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) を読み取り、追加、編集、削除できます。たとえば、分数を作成してプレゼンテーションに配置する例です。

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

各数学要素は [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) インターフェイスを実装するクラスで表されます。このインターフェイスは数式を簡単に作成する多数のメソッドを提供します。たとえば、次のコードでピタゴラスの定理を 1 行で作成できます。

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) の操作は、[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) を含むすべての要素タイプで実装されています。

完全なサンプルコード:

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
数学式は数学要素のシーケンスから構成されます。要素のシーケンスは数学ブロックで表され、要素の引数はツリー状に入れ子になります。

使用できる数学要素は多数あり、各要素は別の要素に含める（集約する）ことができます。つまり、要素は他の要素のコンテナとなり、ツリー構造を形成します。最もシンプルな要素は、他の数学テキスト要素を含まないものです。

すべての数学要素は [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) インターフェイスを実装し、共通の数式操作セットを利用できます。

### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) クラスは、すべての数学構造の基礎要素である数学テキストを表します。オペランド、演算子、変数、その他の線形テキストを表現できます。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) クラスは、分子と分母からなる分数オブジェクトを表します。分数棒は水平または斜めに設定できます。また、分数棒なしで要素を上下に配置するスタック機能としても使用されます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) クラスは、基底とオプションの次数からなる根（ラジカル）関数を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) クラスは、引数を持つ関数を表します。プロパティは getName（関数名）と getBase（引数）です。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) クラスは、総和や積分などの N 変数演算子を表します。演算子、基底（またはオペランド）、オプションの上下限から構成されます。加算や減算などの単純演算子は含まれず、[MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) で表されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) クラスは上下限を作成します。ベースライン上のテキストと、上下に小さく表示されるテキストから構成されます。 “lim” という文字は含まず、テキストを上部または下部に配置できます。

例:

![todo:image_alt_text](powerpoint-math-equations_8.png)

以下のように [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) と [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) を組み合わせます。

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

これらのクラスは下添字または上添字を指定します。左側または右側の引数に同時に下添字と上添字を設定できますが、右側のみ単独の添字がサポートされています。[MathSubscriptElement] は数値の次数設定にも使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) クラスは、子要素を行と列で配置した行列オブジェクトを表します。行列自体にはデリミタが組み込まれていないため、括弧で囲む場合は [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter) を使用します。NULL 引数でギャップを作れます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) クラスは、垂直に並んだ式や任意の数学オブジェクトの配列を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素の書式設定**
- [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox) クラス: [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) の周囲に矩形などの枠を描画します。

  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox) クラス: 数学要素の論理的なボックス化（パッケージ化）を指定します。たとえば “==” 演算子をボックス化して改行を防止できます。

- [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter) クラス: 開始文字と終了文字（括弧、波括弧、ブラケット、縦棒など）と内部の数学要素を組み合わせたデリミタオブジェクトを指定します。

  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent) クラス: 基底と結合ダイアクリティカルマークからなるアクセント関数を指定します。

  例: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar) クラス: 基底引数に上棒または下棒を付加します。

  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter) クラス: 式の上または下に配置するグルーピング記号を指定し、要素間の関係を強調します。

  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学操作**
各数学要素と数式（[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)）は [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) インターフェイスを実装しています。これにより既存構造に対して操作を行い、より複雑な数式を構成できます。すべての操作は、[**IMathElement**] または文字列を引数に取ります。文字列引数が使用された場合、[**MathematicalText**] のインスタンスが暗黙的に生成されます。利用可能な数式操作は以下の通りです。

### **Join メソッド**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

要素を結合して MathBlock を作成します。

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

分子と指定された分母で分数を作成します。

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose メソッド**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

要素を指定文字で囲みます（例: 括弧）。

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

現在のオブジェクトを関数名として、引数に対する関数を作成します。

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

現在のインスタンスを引数として、指定関数を適用します。

- 文字列で関数名を指定（例: “cos”）
- 列挙型 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) または [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments) の定数を使用
- [**IMathElement**] のインスタンスを使用

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

添字と上付き文字を設定します。左側または右側に同時に設定可能ですが、単独の添字/上付きは右側のみサポートされます。**Superscript** は数値の次数設定にも使用できます。

例:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical メソッド**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定した次数で根（ラジカル）を作成します。

例:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

上下限を設定します。上限と下限は基底に対する位置を示します。

例として次の式を作成します。

![todo:image_alt_text](powerpoint-math-equations_8.png)

以下のコードで作成できます。

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

**nary** と **integral** はどちらも [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator) 型のオブジェクトを返します。**nary** は **MathNaryOperatorTypes** 列挙体で総和・和集合などを指定し、積分は含みません。**integral** は **MathIntegralTypes** 列挙体で積分タイプを指定します。

例:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray メソッド**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) は要素を垂直配列に配置します。[**MathBlock**] インスタンスに対して呼び出すと、すべての子要素が配列にまとめられます。

例:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **書式設定操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **accent**: 上付文字を設定します。
- **overbar** と **underbar**: 上下にバーを付加します。
- **group**: 下括弧などのグルーピング文字で要素をまとめます。
- **toBorderBox**: ボーダーボックスに配置します。
- **toBox**: 非表示の論理ボックスに配置します。

例:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **FAQ**

**PowerPoint のスライドに数式を追加するにはどうすればよいですか？**

数式シェイプオブジェクトを作成すると自動的に MathPortion が含まれます。その後、MathPortion から MathParagraph を取得し、MathBlock オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい。Aspose.Slides は MathBlock を入れ子にすることで複雑な数式を作成できます。すべての数学要素は [**IMathElement**] インターフェイスを実装しており、Join、Divide、Enclose などの操作で組み合わせられます。

**既存の数式を更新または修正するには？**

MathParagraph から既存の MathBlock にアクセスし、Join、Divide、Enclose などのメソッドで要素を変更します。編集後にプレゼンテーションを保存すれば変更が反映されます。