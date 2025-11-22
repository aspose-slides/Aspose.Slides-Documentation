---
title: PowerPoint 数式
type: docs
weight: 80
url: /ja/nodejs-java/powerpoint-math-equations/
keywords: " PowerPoint 数式, PowerPoint 数学記号, PowerPoint 公式, PowerPoint 数学テキスト"
description: "PowerPoint 数式, PowerPoint 数学記号, PowerPoint 公式, PowerPoint 数学テキスト"
---

## **概要**
PowerPoint では、数式や式を書いてプレゼンテーションに表示することができます。PowerPoint ではさまざまな数学記号が表現でき、テキストや数式に追加できます。そのために PowerPoint の数式コンストラクタが使用され、以下のような複雑な式を作成できます。

- 数式分数
- 数式根号
- 数式関数
- 極限 と 対数関数
- N元演算
- 行列
- 大きな演算子
- sin, cos 関数

PowerPoint で数式を追加するには、*Insert → Equation* メニューを使用します:

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML 形式の数式テキストが作成され、PowerPoint で次のように表示されます:  

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は多くの数学記号をサポートしていますが、複雑な数式を作成すると見栄えが良くないことがあります。頻繁に数学プレゼンテーションを作成するユーザーは、サードパーティ製ソリューションを利用して見栄えの良い数式を作成しています。

[**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/) を使用すると、C# で PowerPoint の数式をプログラムで操作できます。新しい数式を作成したり、既存の数式を編集したりできます。数式構造を画像にエクスポートする機能も一部サポートされています。

## **数式の作成方法**
数式要素は、任意の入れ子レベルの数式構造を構築するために使用されます。線形に配置された数式要素のコレクションが **[MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)** クラスで表されます。**MathBlock** クラスは、分離された数式、式、または方程式を表します。**[MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion)** は数式テキストを保持する要素です（**Portion** と混同しないでください）。**[MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph)** は複数の MathBlock を操作するために使用します。これらのクラスが Aspose.Slides API で PowerPoint の数式を扱う鍵となります。

以下に、Aspose.Slides API で次の数式を作成する手順を示します:

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを保持するシェイプを追加します:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

作成後、このシェイプにはデフォルトで 1 つの段落が含まれ、そこに **[MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion)** が含まれます。**MathPortion** は内部に数式テキストを保持する要素です。**MathParagraph** オブジェクトを取得するには次のようにします:

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

**MathParagraph** クラスを使用すると、数式要素の組み合わせからなる **MathBlock** を読み取り、追加、編集、削除できます。たとえば、分数を作成してプレゼンテーションに配置する例は次のとおりです:

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

各数式要素は **[MathElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement)** を実装するクラスで表されます。このクラスは数式を簡単に作成するための多くのメソッドを提供します。たとえば、ピタゴラスの定理は次のように記述できます:

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

**MathElement** の操作は **MathBlock** などのすべての要素型で実装されています。

完全なサンプルコード:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
    var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    var fraction = new aspose.slides.MathematicalText("x").divide("y");
    mathParagraph.add(new aspose.slides.MathBlock(fraction));
    var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);
    pres.save("math.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

## **数式要素タイプ**
数式は数式要素のシーケンスから構成されます。要素のシーケンスは数式ブロックで表され、要素の引数はツリー構造の入れ子になります。

多数の数式要素タイプがあり、各要素は他の要素に含めることができます。つまり要素は他の要素のコンテナとなり、ツリー構造を形成します。最もシンプルな要素は、他の要素を含まない数式テキストです。

各要素は **[MathElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement)** を実装し、共通の数式操作を利用できます。

### **MathematicalText クラス**
**[MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText)** クラスは、すべての数式構築の基礎となる数式テキストを表します。オペランド、演算子、変数、その他の線形テキストを表現できます。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**
**[MathFraction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction)** クラスは、分子と分母からなる分数オブジェクトを表します。分数バーは水平または斜めに設定できます。また、バーなしで要素を上下に配置するスタック関数としても使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
**[MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical)** クラスは、根号（数学的ルート）を表し、基底とオプションの指数から構成されます。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
**[MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction)** クラスは、引数を持つ関数を表します。プロパティは **getName**（関数名） と **getBase**（関数の引数） です。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
**[MathNaryOperator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator)** クラスは、総和や積分などの N 元演算子を表します。演算子、基底（またはオペランド）およびオプションの上限・下限から構成されます。単純な加算・減算などは **MathematicalText** で表されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
**[MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit)** クラスは上限または下限を作成します。ベースライン上のテキストと、上または下に小さく配置されたテキストから構成されます。単語 “lim” は含まれませんが、式の上部または下部にテキストを配置できます。例えば次のように **MathFunction** と **MathLimit** を組み合わせます:

![todo:image_alt_text](powerpoint-math-equations_8.png)

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**
- **[MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)**
- **[MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)**
- **[MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)**
- **[MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)**

これらのクラスは下付きインデックスまたは上付きインデックスを指定します。左側または右側に同時に設定でき、右側単独でも下付きまたは上付きインデックスをサポートします。**MathSubscriptElement** は数値の次数設定にも使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
**[MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix)** クラスは、子要素を行と列で配置した行列オブジェクトを表します。行列自体に括弧はありません。括弧で囲む場合は **[MathDelimiter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter)** を使用します。null 引数で空白を作れます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
**[MathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray)** クラスは、垂直方向に配置された式や任意の数式オブジェクトの配列を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数式要素の書式設定**
- **[MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox)** クラス: **MathElement** の周囲に矩形やその他の枠線を描画します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- **[MathBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox)** クラス: 数式要素の論理的なボックス化（パッケージ化）を指定します。たとえば “==” 演算子を改行禁止にする際に使用します。

- **[MathDelimiter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter)** クラス: 開始文字と終了文字（括弧、波括弧、角括弧、縦棒など）で囲むデリミタオブジェクトを指定し、内部に 1 つ以上の数式要素を配置します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- **[MathAccent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent)** クラス: 基底と結合アクセント記号からなるアクセント関数を指定します。  
  例: 𝑎́.

- **[MathBar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar)** クラス: 基底引数に上棒または下棒を付けるバー関数を指定します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- **[MathGroupingCharacter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter)** クラス: 式の上部または下部にグルーピング記号を配置し、要素間の関係を強調します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数式演算**
各数式要素および **[MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)** で表される数式は **[MathElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement)** を実装しており、既存の構造に対して操作を行い、より複雑な数式を構成できます。すべての操作は **MathElement** または文字列のいずれかを引数に取ります。文字列が渡された場合は内部で **MathematicalText** が暗黙的に生成されます。

### **Join メソッド**
- `join(String)`
- `join(IMathElement)`

要素を結合して数式ブロックを作成します。例:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Divide メソッド**
- `divide(String)`
- `divide(IMathElement)`
- `divide(String, MathFractionTypes)`
- `divide(IMathElement, MathFractionTypes)`

分子と分母から指定されたタイプの分数を作成します。例:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Enclose メソッド**
- `enclose()`
- `enclose(Char, Char)`

要素を括弧などの指定文字で囲みます。

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

```javascript
var delimiter = new aspose.slides.MathematicalText("x").enclose('[', ']');
var delimiter2 = new aspose.slides.MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function メソッド**
- `function(String)`
- `function(IMathElement)`

現在のオブジェクト名を関数名として、引数を持つ関数を作成します。

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

```javascript
var func = new aspose.slides.MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction メソッド**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(IMathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

現在のインスタンスを関数の引数として使用します。文字列で関数名を指定したり、列挙型で事前定義された関数を選択したりできます。

例:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft メソッド**
- `setSubscript(String)`
- `setSubscript(IMathElement)`
- `setSuperscript(String)`
- `setSuperscript(IMathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(IMathElement, IMathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(IMathElement, IMathElement)`

下付き・上付きインデックスを設定します。左側または右側に同時に設定可能ですが、単独の下付き・上付きは右側のみでサポートされます。**Superscript** は数の次数設定にも使用できます。

例:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical メソッド**
- `radical(String)`
- `radical(IMathElement)`

指定した次数の根号を作成します。

例:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- `setUpperLimit(String)`
- `setUpperLimit(IMathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(IMathElement)`

上限または下限を設定します。上限・下限は基底に対する位置を示します。

例として次の式を作成します:

![todo:image_alt_text](powerpoint-math-equations_8.png)

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary と Integral メソッド**
- `nary(MathNaryOperatorTypes, IMathElement, IMathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, IMathElement, IMathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

**nary** と **integral** はそれぞれ **MathNaryOperator** タイプのオブジェクトを返します。**nary** は総和・和集合などの N 元演算子を、**integral** は積分演算子を表します。

例:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray メソッド**
**toMathArray** は要素を垂直配列に配置します。**MathBlock** インスタンスに対して呼び出すと、子要素すべてが配列に入ります。

例:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **書式設定操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- `accent` メソッドは要素の上部にアクセント記号を付加します。
- `overbar` と `underbar` メソッドはそれぞれ上棒・下棒を付加します。
- `group` メソッドはグルーピング文字（例: 下側波括弧）で要素をまとめます。
- `toBorderBox` メソッドは枠線付きボックスに配置します。
- `toBox` メソッドは非表示の論理ボックスに配置します。

例:

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **FAQ**

**PowerPoint スライドに数式を追加するにはどうすればよいですか？**

数式テキストを保持する `MathShape` オブジェクトを作成します。このオブジェクトには自動的に数式部分が含まれます。次に `MathPortion` から `MathParagraph` を取得し、`MathBlock` オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい。Aspose.Slides は `MathBlock` を入れ子にすることで複雑な数式を構築できます。各数式要素は `IMathElement` を実装しており、Join、Divide、Enclose などの操作で組み合わせられます。

**既存の数式を更新または修正するにはどうすればよいですか？**

`MathParagraph` から既存の `MathBlock` を取得し、Join、Divide、Enclose などのメソッドを使用して要素を変更します。編集後にプレゼンテーションを保存すれば変更が反映されます。