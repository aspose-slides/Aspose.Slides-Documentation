---
title: Android で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/androidjava/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数式
- 数学テキスト
- 数式を追加
- 数学記号を追加
- 数式を追加
- 数学テキストを追加
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint の PPT および PPTX に数式を挿入および編集できます。OMML のサポート、書式設定コントロール、わかりやすい Java コードサンプルが含まれています。"
---

## **概要**
PowerPoint では、数式やフォーミュラを書き込み、プレゼンテーションに表示することが可能です。これを実現するために、PowerPoint ではさまざまな数学記号が表現でき、テキストや数式に追加できます。そのために PowerPoint の数式コンストラクタが使用され、次のような複雑な数式を作成できます。

- Math Fraction
- Math Radical
- Math Function
- Limits and log functions
- N-ary operations
- Matrix
- Large operators
- Sin, cos functions

PowerPoint で数式を追加するには、*Insert -> Equation* メニューを使用します。

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML 形式の数式テキストが作成され、PowerPoint で以下のように表示されます。

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は多数の数学記号をサポートしていますが、複雑な数式を作成すると見栄えが十分でないことがあります。頻繁に数式付きプレゼンテーションを作成するユーザーは、サードパーティ製のソリューションを利用して見栄えの良い数式を作成しています。

[**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/) を使用すれば、C# で PowerPoint の数式をプログラムから操作できます。新しい数式を作成したり、既存の数式を編集したりできます。数式構造を画像へエクスポートする機能も部分的にサポートされています。

## **数式の作成方法**
数学要素は任意のレベルの入れ子構造で数学構造を構築するために使用されます。線形に並んだ数学要素のコレクションは、[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) クラスで表されます。[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) クラスは、分離された数式、フォーミュラ、または方程式を表します。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) は数学テキストを保持する要素で、[**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) と混同しないでください。[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) は複数の MathBlock を操作できます。上記のクラスは Aspose.Slides API を通じて PowerPoint の数式を操作するためのキーになります。

以下の数式を Aspose.Slides API で作成する例をご覧ください。

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

作成後、シェイプにはデフォルトで 1 つの段落と 1 つの MathPortion が含まれます。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) は内部に数学テキストを保持する要素です。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) から [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) 変数へアクセスします。

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) は数学ブロック（[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)）の読み取り、追加、編集、削除を行うことができます。たとえば分数を作成してスライドに配置するには次のようにします。

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

各数学要素は [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) インターフェイスを実装するクラスで表されます。このインターフェイスは、数学式を簡単に作成するための多くのメソッドを提供します。たとえば、次のコードでピタゴラスの定理を 1 行で生成できます。

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) の操作は、[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) を含むすべての要素タイプで実装されています。

完全なサンプルコードは以下のとおりです。

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
数学式は数学要素のシーケンスから構成されます。要素のシーケンスは数学ブロックで表現され、要素の引数はツリー構造のように入れ子になります。

多数の数学要素タイプがあり、各要素は別の要素に集約できます。つまり要素は他の要素のコンテナであり、ツリー構造を形成します。数学テキストに他の要素を含まない最もシンプルな要素もあります。

各数学要素は [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) インターフェイスを実装しており、共通の数式操作を使用できます。
### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) クラスは、すべての数学構造の基礎要素である数学テキストを表します。オペランド、演算子、変数、その他の直線テキストを表すことができます。

例: 𝑎=𝑏+𝑐
### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) クラスは、分子と分母で構成され、分数棒で区切られた分数オブジェクトを表します。分数棒は水平または斜めに設定可能です。また、分数棒なしで要素を上下に配置するスタック関数としても使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) クラスは、基底と省略可能な次数からなる根（ラジカル）関数を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) クラスは引数を取る関数を表します。プロパティは [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--)（関数名）と [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--)（関数の引数）です。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) クラスは、総和や積分などの N 元数学オブジェクトを表します。演算子、基底（またはオペランド）、省略可能な上限・下限で構成されます。例として総和、和集合、積集合、積分があります。

このクラスは加算や減算などの単純演算子を含みません。単純演算子は [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) で表されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) クラスは上限または下限を作成します。ベースライン上のテキストと、すぐ上または下に配置される縮小テキストで構成されます。単語 “lim” は含まず、式の上部または下部にテキストを配置できます。たとえば、

![todo:image_alt_text](powerpoint-math-equations_8.png)

は [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) と [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) の組み合わせで次のように作成します。

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 
### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

これらのクラスは下付きインデックスまたは上付きインデックスを指定します。左側または右側に同時に下付き・上付きインデックスを設定できますが、右側単独の下付き・上付きインデックスのみがサポートされます。[MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) は数値の次数を設定することもできます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) クラスは、子要素が行と列に配置された行列オブジェクトを表します。行列にはデフォルトで区切り記号が付かないため、角括弧などで囲む場合は [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter) を使用します。null 引数を渡すと行列内に空白を作れます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) クラスは、垂直に配置された方程式や任意の数学オブジェクトの配列を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **数学要素の書式設定**
- [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox) クラス: [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) の周囲に長方形やその他の枠線を描画します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox) クラス: 数学要素の論理的な箱詰め（パッケージ化）を指定します。たとえば、箱詰めされたオブジェクトは演算子エミュレータとして使用したり、改行を防止したりできます。

- [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter) クラス: 開始文字と終了文字（括弧、波かっこ、角括弧、縦棒など）で囲む区切り記号オブジェクトを指定し、内部に 1 つ以上の数学要素を含めます。例: (𝑥2); [𝑥2|𝑦2]。  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent) クラス: 基底と結合アクセント記号からなるアクセント関数を指定します。  
  例: 𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar) クラス: 基底引数と上バーまたは下バーからなるバー関数を指定します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter) クラス: 式の上または下に配置するグルーピング記号を指定し、要素間の関係を強調します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学演算**
各数学要素および数学式（[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)）は [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) インターフェイスを実装しています。既存の構造に対して操作を行い、より複雑な式を構成できます。すべての操作は、[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) または文字列のいずれかを引数に取ります。文字列引数が使用された場合、[**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) のインスタンスが暗黙的に作成されます。利用可能な数式操作は以下のとおりです。
### **Join メソッド**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

数学要素を結合し、数学ブロックを作成します。例:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 
### **Divide メソッド**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

指定した分子と分母で特定のタイプの分数を作成します。例:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 
### **Enclose メソッド**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

指定した文字（例えば括弧）で要素を囲みます。

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
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

現在のオブジェクトを関数名として、引数付き関数を作成します。

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
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

現在のインスタンスを引数として、指定した関数を適用します。  
- 関数名を文字列で指定（例: “cos”）  
- 列挙体 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) または [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments) の定義済み値を使用  
- [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) のインスタンスを使用  

例:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft メソッド**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

下付きと上付きインデックスを設定します。左側または右側に同時に設定可能ですが、右側単独の設定のみがサポートされています。**Superscript** は数の次数を設定する際にも使用できます。

例:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 
### **Radical メソッド**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定した次数の根（ラジカル）を作成します。

例:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 
### **SetUpperLimit と SetLowerLimit メソッド**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

上限または下限を設定します。上限・下限は基底に対する相対位置を示します。

例として次の式を考えます。

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) と [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) の組み合わせで次のように作成できます。

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 
### **Nary と Integral メソッド**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary** と **integral** はどちらも [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator) 型のオブジェクトを返します。**nary** メソッドでは、[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) 列挙体で演算子の種類（総和、和集合など）を指定し、積分は含まれません。**integral** メソッドは積分専用で、[**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes) 列挙体で積分の種類を指定します。

例:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 
### **ToMathArray メソッド**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) は要素を縦方向の配列に配置します。 [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) インスタンスに対して呼び出すと、子要素すべてが配列に配置されます。

例:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 
### **書式設定操作: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-) メソッドは要素の上にアクセント記号（文字）を付加します。
- [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--) と [**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--) メソッドはそれぞれ上部または下部にバーを付加します。
- [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--) メソッドはグルーピング文字（例: 下側の波かっこ）で要素をまとめます。
- [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--) メソッドは要素を枠付きボックスに配置します。
- [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--) メソッドは視覚的でないボックス（論理的グルーピング）に配置します。

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

数式シェイプオブジェクトを作成すると、内部に数式部分が自動的に含まれます。その後、[MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) から [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) を取得し、そこに [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい。Aspose.Slides は MathBlock を入れ子にすることで複雑な数式を作成できます。各数学要素は [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) を実装しており、Join、Divide、Enclose などの操作で要素を組み合わせてより複雑な構造を構築できます。

**既存の数式を更新または変更するにはどうすればよいですか？**

既存の MathBlock は [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) を介して取得できます。Join、Divide、Enclose などのメソッドを使用して個々の要素を変更し、編集後にプレゼンテーションを保存すれば変更が反映されます。