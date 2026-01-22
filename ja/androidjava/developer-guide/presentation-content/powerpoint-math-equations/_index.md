---
title: Android で PowerPoint プレゼンテーションに数式を追加する
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/androidjava/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数学式
- 数学テキスト
- 数式を追加
- 記号を追加
- 数式を追加
- テキストを追加
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint の PPT および PPTX に数式を挿入・編集できます。OMML のサポート、書式設定コントロール、分かりやすい Java コードサンプルを提供します。"
---

## **概要**
PowerPoint では、数式や式を書いてプレゼンテーションに表示することが可能です。そのために、PowerPoint ではさまざまな数学記号が表現でき、テキストや数式に追加できます。これには、PowerPoint の数式コンストラクタを使用し、次のような複雑な式を作成します。

- 数学分数
- 数学根号
- 数学関数
- 極限および対数関数
- N 進演算子
- 行列
- 大きな演算子
- sin、cos 関数

PowerPoint で数式を追加するには、*Insert → Equation* メニューを使用します。

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML 形式の数式テキストが作成され、PowerPoint で次のように表示されます。

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は多数の数学記号をサポートしていますが、複雑な数式を作成すると見栄えが必ずしも良くなりません。頻繁に数式プレゼンテーションを作成するユーザーは、見栄えの良い数式を作るためにサードパーティ製品を利用することがあります。

[**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/) を使用すれば、C# で PowerPoint の数式をプログラムから操作できます。新しい数式を作成したり、既存の数式を編集したりできます。また、数式構造を画像としてエクスポートする機能も部分的にサポートされています。

## **数式の作成方法**
数式要素は任意の入れ子構造を持つ数式構築に使用されます。線形に並んだ数式要素の集合は、[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) クラスで表される数式ブロックとなります。[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) は、分離された数式、式、または方程式を表します。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) は数式テキストを保持する要素で、[**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) とは区別してください。[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) は複数の MathBlock を操作できます。これらのクラスが、Aspose.Slides API を介した PowerPoint 数式操作の鍵となります。

以下の数式を Aspose.Slides API で作成する例を見てみましょう。

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

作成直後、このシェイプには既にデフォルトで 1 つの段落があり、数学的な Portion が含まれています。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) は数式テキストを保持する要素です。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) 内の数式コンテンツにアクセスするには、[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) 変数を参照します。

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) クラスを使って、数式要素の組み合わせからなる MathBlock ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) を読み取り、追加、編集、削除できます。たとえば、分数を作成してプレゼンテーションに配置する例です。

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

各数学要素は [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) インターフェイスを実装するクラスで表されます。このインターフェイスには、数式を簡単に作成するための多くのメソッドが用意されています。たった 1 行のコードでかなり複雑な数式を作ることができます。たとえば、ピタゴラスの定理は次のように記述できます。

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) の操作は、[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) を含むすべての要素で実装されています。

完全なサンプルコードは以下の通りです。

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
数式は数学要素のシーケンスから構成されます。要素のシーケンスは数式ブロックで表され、要素の引数はツリー状の入れ子構造になります。

多数の数学要素タイプがあり、これらは他の要素に含める（集約する）ことができます。つまり、要素は他の要素のコンテナとなり、ツリー構造を形成します。最も単純な要素は、他の要素を含まない数学テキストです。

各要素は [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) インターフェイスを実装しており、共通の数学操作セットを利用できます。

### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) クラスは、すべての数式構築の基礎となる数学テキストを表します。オペランド、演算子、変数、その他の直線テキストを表現できます。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) クラスは、分子と分母からなる分数オブジェクトを表します。分数バーは水平または斜めに設定可能です。また、分数バーなしで要素を上下に配置するスタック関数としても使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) クラスは、基底と任意の次数からなる根号関数を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) クラスは、引数を持つ関数を表します。プロパティは [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--)（関数名）と [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--)（関数の引数）です。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) クラスは、総和や積分など N 進演算子を表します。演算子、基底（またはオペランド）、任意の上限・下限から構成されます。加算や減算といった単純演算子は含まれません。単純演算子は [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) で表します。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) クラスは、上限または下限を作成します。ベースライン上のテキストと、その直上または直下に小さく表示されるテキストで構成されます。 “lim” という文字は含まれませんが、式の上部または下部にテキストを配置できます。たとえば次の式は、[**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) と [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) を組み合わせて作成します。

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

これらのクラスは下付きまたは上付きインデックスを指定します。左側または右側に同時に下付き・上付きインデックスを設定可能ですが、右側単体の下付き・上付きインデックスのみサポートします。[MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) は数値の次数を設定することもできます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) クラスは、子要素を行と列で配置した行列オブジェクトを表します。行列にはデフォルトの区切り記号がなく、括弧で囲む場合は [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter) を使用します。null 引数を渡すと行列に空白を作れます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) クラスは、縦方向に並んだ式や任意の数学オブジェクトの配列を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素の書式設定**
- [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox) クラス: [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) の周囲に矩形やその他の枠線を描画します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox) クラス: 数学要素の論理的なボックス化を指定します。たとえば、演算子をボックス化して改行を防止したり、ラインブレークを許可しないグループ化に使用します。

- [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter) クラス: 開閉文字（丸括弧、波括弧、角括弧、縦棒など）と、その内部に含まれる 1 つ以上の数学要素で構成されます。例: (𝑥²); [𝑥²|𝑦²]。  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent) クラス: 基底と結合アクセント記号からなるアクセント関数を指定します。  
  例: 𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar) クラス: 基底引数と上バーまたは下バーからなるバー関数を指定します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter) クラス: 式の上または下に配置するグルーピング記号で、要素間の関係を強調します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学演算**
各数学要素および数式（[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) を通じて）は [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) インターフェイスを実装しています。既存の構造に対して操作を行い、より複雑な数式を作成できます。すべての操作は、[**IMathElement**] または文字列を引数に取ります。文字列を使用した場合、内部で自動的に [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) インスタンスが生成されます。利用可能な数式操作は以下の通りです。

### **Join メソッド**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

数学要素を結合して MathBlock を作成します。例:

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

指定した分子と分母で特定タイプの分数を作成します。例:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose メソッド**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

要素を指定した文字（例: 丸括弧）で囲みます。

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

現在のオブジェクトを関数名として、引数を受け取る関数を作成します。

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

現在のインスタンスを引数として関数を作成します。使用例:

- 文字列で関数名を指定（例: “cos”）
- 列挙型 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) や [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments) の定数を使用
- [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) のインスタンスを使用

例:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft メソッド**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

下付き・上付きインデックスを設定します。左側または右側に同時に設定可能ですが、右側単体の下付き・上付きのみサポートします。**Superscript** は数値の次数設定にも利用できます。

例:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical メソッド**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定した次数の根号を作成します。

例:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

上限または下限を設定します。上部・下部は基底に対する相対位置を示します。

例として次の式を考えます:

![todo:image_alt_text](powerpoint-math-equations_8.png)

この式は [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) と [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) の組み合わせで作成できます。

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

**nary** と **integral** の両メソッドは、[**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator) 型の N 進演算子を生成して返します。**nary** メソッドでは、[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) 列挙体で総和・和集合などのタイプを指定します（積分は除く）。**integral** メソッドは積分に特化し、[**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes) 列挙体で積分タイプを指定します。

例:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray メソッド**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) は要素を縦配列に変換します。**MathBlock** インスタンスに対して呼び出すと、すべての子要素が配列に配置されます。

例:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **書式設定操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-) メソッドは、要素の上にアクセント記号（文字）を付加します。
- [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--) と [**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--) は、要素の上部または下部にバーを付加します。
- [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--) メソッドは、下部の波括弧などのグルーピング文字で要素をまとめます。
- [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--) メソッドは、要素を枠付きボックスに変換します。
- [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--) メソッドは、視覚的でない論理ボックスに変換します。

例:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **よくある質問**

**PowerPoint のスライドに数式を追加するにはどうすればよいですか？**

数式シェイプオブジェクトを作成すると、デフォルトで数学的な Portion が含まれます。次に、[MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) を [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) から取得し、[MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) オブジェクトを追加します。

**複雑な入れ子数式を作成できますか？**

はい。Aspose.Slides は MathBlock を入れ子にすることで複雑な数式を構築できます。すべての数学要素は [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) インターフェイスを実装しており、Join、Divide、Enclose などの操作で要素を組み合わせられます。

**既存の数式を更新または修正するには？**

数式を更新するには、[MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) 経由で既存の MathBlock にアクセスします。その後、Join、Divide、Enclose などのメソッドを使用して個々の要素を変更します。編集後にプレゼンテーションを保存すれば変更が反映されます。