---
title: PowerPoint 数学方程式
type: docs
weight: 80
url: /ja/androidjava/powerpoint-math-equations/
keywords: "PowerPoint 数学方程式, PowerPoint 数学記号, PowerPoint 数式, PowerPoint 数学テキスト"
description: "PowerPoint 数学方程式, PowerPoint 数学記号, PowerPoint 数式, PowerPoint 数学テキスト"
---

## **概要**
PowerPointでは、数学の方程式や式を書くことができ、プレゼンテーションに表示することができます。そのためには、PowerPointにさまざまな数学記号が用意されており、テキストや方程式に追加することができます。そのために、PowerPointでは数学方程式のコンストラクタを使用し、以下のような複雑な式を作成するのに役立ちます。

- 数学の分数
- 数学の平方根
- 数学の関数
- 極限および対数関数
- N-進演算
- 行列
- 大きな演算子
- サイン、コサイン関数

PowerPointに数学方程式を追加するには、*挿入 -> 方程式*メニューを使用します。

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、PowerPointで以下のように表示できるXML形式の数学テキストが作成されます。

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPointは、多くの数学記号をサポートしており、数学方程式を作成できます。しかし、PowerPointで複雑な数学方程式を作成することは、しばしば良いプロフェッショナルな外観の結果をもたらさないことが多いです。数学のプレゼンテーションを頻繁に作成する必要があるユーザーは、見栄えの良い数学の式を作成するために、サードパーティのソリューションを利用することがあります。

[**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/)を使用すると、PowerPointプレゼンテーション内で数学方程式をC#でプログラム的に操作できます。新しい数学式を作成するか、以前に作成されたものを編集します。数学構造を画像にエクスポートすることも部分的にサポートされています。

## **数学方程式の作成方法**
数学要素は、任意の入れ子のレベルで数学的構造を構築するために使用されます。数学要素の線形コレクションは、[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)クラスによって表される数学ブロックを形成します。[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)クラスは、本質的に独立した数学的表現、式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)は、数学的な部分であり、数学テキストを保持するために使用されます（[**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)と混同しないでください）。[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)は、数学ブロックの集合を操作することを可能にします。上記のクラスは、Aspose.Slides APIを介してPowerPointの数学方程式を操作するための鍵です。

Aspose.Slides APIを介して次の数学方程式を作成する方法を見てみましょう：

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数学的表現を追加するには、まず数学テキストを含む形状を追加します：

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
```

作成後、形状にはデフォルトで数学部分を持つ1つの段落がすでに含まれています。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)クラスは、その内部に数学的テキストを含む部分です。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)内の数学的コンテンツにアクセスするには、[**MathParagraph** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)変数を参照します：

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
```

[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)クラスは、数学要素の組み合わせで構成された数学ブロック（[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)）を読み取り、追加、編集、削除することを可能にします。たとえば、分数を作成してプレゼンテーションに配置します：

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
```

各数学要素は、[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)インターフェイスを実装したいくつかのクラスによって表されます。このインターフェイスは、数学的表現を簡単に作成するための多くのメソッドを提供します。単一のコード行でかなり複雑な数学的表現を作成することができます。たとえば、ピタゴラスの定理は次のようになります：

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
```

インターフェイス[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)の操作は、[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)を含むあらゆるタイプの要素で実装されています。

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

## **数学要素タイプ**
数学的表現は、数学要素の連続から形成されます。数学要素の連続は数学ブロックとして表現され、数学要素の引数はツリーのような入れ子になります。

数学ブロックを構築するために使用できる多くの数学要素タイプがあります。これらの各要素は、他の要素に含めることができます（集約することができます）。つまり、要素は実際には他の要素のコンテナであり、ツリーのような構造を形成しています。最もシンプルなタイプの要素は、他の数学テキストの要素を含まないものです。

各タイプの数学要素は、[**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)インターフェイスを実装し、さまざまなタイプの数学要素に対して一般的な数学操作のセットを使用できるようにします。
### **MathematicalTextクラス**
[**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText)クラスは、数学的テキストを表します - すべての数学的構造の基礎要素です。数学テキストは、オペランドや演算子、変数、およびその他のすべての線形テキストを表すことができます。

例: 𝑎=𝑏+𝑐
### **MathFractionクラス**
[**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction)クラスは、分母と分子で構成される分数オブジェクトを指定します。分数バーは、分数のプロパティに応じて水平または対角的にすることができます。分数オブジェクトは、1つの要素を他の要素の上に配置するスタック関数を表すためにも使用されますが、分数バーはありません。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadicalクラス**
[**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical)クラスは、基数とオプションの次数で構成される根関数（数学の根）を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)クラスは、引数の関数を指定します。プロパティを含みます: [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) - 関数名と [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) - 関数の引数。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator)クラスは、和や積分などのN-進数学オブジェクトを指定します。操作子、基数（またはオペランド）、オプションの上限と下限で構成されます。N-進演算子の例には、和、和集合、交差、積分があります。

このクラスは、加算、減算などの単純な演算子を含みません。それらは単一のテキスト要素 - [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText)として表されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)クラスは、上限または下限を作成します。これは、基準線におけるテキストと、すぐ上または下にある縮小サイズのテキストで構成される限界オブジェクトを指定します。この要素には「lim」という単語は含まれませんが、式の上または下にテキストを配置できます。つまり、式

![todo:image_alt_text](powerpoint-math-equations_8.png)

は、[**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)と[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)要素を組み合わせて次のように作成されます：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElementクラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

以下のクラスは、小文字または大文字のインデックスを指定します。引数の左または右側に同時に下付き文字と上付き文字を設定できますが、単一の下付き文字または上付き文字は右側のみでサポートされます。[MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)は、数の数学的次数を設定するためにも使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrixクラス**
[**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix)クラスは、1つ以上の行と列に配置された子要素からなる行列オブジェクトを指定します。行列には組み込みの区切り文字がないことに注意することが重要です。行列を括弧で置くには、区切り文字オブジェクト - [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter)を使用する必要があります。null引数を使用して、行列にギャップを作成できます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArrayクラス**
[**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray)クラスは、方程式または任意の数学オブジェクトの垂直配列を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **数学要素のフォーマッティング**
- [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox)クラス: [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)の周りに四角形またはその他の境界を描きます。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox)クラス: 数学要素の論理的なボクシング（パッケージング）を指定します。たとえば、ボックス化されたオブジェクトは、整列点の有無にかかわらず演算子エミュレーターとして機能したり、行のブレークポイントとして機能したり、行内で改行を許可しないようにグループ化されたりします。たとえば、「==」演算子は行のブレークを防ぐためにボックス化する必要があります。
- [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter)クラス: 開始および終了文字（丸括弧、波括弧、角括弧、縦線など）で構成され、その内側に1つ以上の数学要素があり、指定された文字で区切られています。例: (𝑥2); [𝑥2|𝑦2]。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent)クラス: 基盤と組み合わさる発音記号を持つアクセント関数を指定します。

  例: 𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar)クラス: 基盤引数と上バーまたは下バーを持つバー関数を指定します。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter)クラス: 通常、要素間の関係を強調表示するために、表現の上または下にグルーピングシンボルを指定します。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学演算**
各数学要素および数学表現（[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)を介して）は、[**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)インターフェイスを実装しています。これにより、既存の構造に対して操作を使用し、より複雑な数学的表現を形成できます。すべての操作には2つのパラメータセットがあります: 引数として[**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)または文字列のいずれか。文字列引数が使用されると、[**MathematicalText** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText)クラスのインスタンスが指定された文字列から暗黙的に作成されます。Aspose.Slidesで使用できる数学操作は以下に示されています。
### **結合メソッド**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

数学要素を結合して数学ブロックを形成します。たとえば：

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **割り算メソッド**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

指定された分子と指定された分母を使用して、指定されたタイプの分数を作成します。たとえば：

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **括弧メソッド**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

指定された文字（丸括弧やその他の文字）で要素を囲みます。

```java
/**
 * <p>
 * 数学要素を丸括弧で囲む
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * 指定された文字（丸括弧やその他の文字）でこの要素を囲む
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

たとえば：

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **関数メソッド**
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

このインスタンスを関数名として使用して、引数の関数を取得します。

```java
/**
 * <p>
 * このインスタンスを関数名として使用して引数の関数を取得する
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * このインスタンスを関数名として使用して引数の関数を取得する
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 

たとえば：

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **関数の引数としてメソッド**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

現在のインスタンスを引数として特定の関数を取得します。次のことができます：

- 文字列を関数名として指定することができます。たとえば「cos」。
- 列挙型[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument)または[**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments)の事前定義された値の1つを選択することができます。たとえば、[**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin)。
- [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)のインスタンスを選択することができます。

たとえば：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **下付き文字、上付き文字、右側に上付き下付き文字、左側に上付き下付き文字を設定するメソッド**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

下付き文字と上付き文字を設定します。引数の左または右側に同時に下付き文字と上付き文字を設定できますが、単一の下付き文字または上付き文字は右側のみに対してサポートされます。**上付き文字**は、数の数学的次数を設定するためにも使用できます。

例:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **平方根メソッド**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定された引数の指定された次数の数学的根を指定します。

例:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **上限設定および下限設定メソッド**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

上限または下限を取得します。ここで、上限および下限は、引数の基準に対する位置を単に示します。

式を考えてみましょう：

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は、[MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)と[MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)のクラスを組み合わせて作成でき、[IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)の操作は次のようになります：

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **N進および積分メソッド**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary**および**integral**メソッドは、[**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator)タイプによって表されるN-進オペレーターを作成して返します。naryメソッドでは、[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes)列挙体が演算子のタイプを指定します: 和、和集合など、積分を含まない。integralメソッドでは、積分型の列挙体[**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes)を持つ専門的な操作が行われます。

例：

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArrayメソッド**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--)は、要素を垂直配列に配置します。この操作が[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)インスタンスに対して呼び出されると、すべての子要素が返される配列に配置されます。

例：

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **フォーマッティング操作: アクセント、上バー、下バー、グループ、ボーダーボックスにする、ボックスにする**
- [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-)メソッドは、アクセントマーク（要素の上にある文字）を設定します。
- [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--)および[**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--)メソッドは、上または下にバーを設定します。
- [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--)メソッドは、下側の波括弧など、グルーピング文字を使用してグループに配置します。
- [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--)メソッドは、ボーダーボックスに配置します。
- [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--)メソッドは、非視覚的ボックス（論理的グループ化）に配置します。

例：

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
```