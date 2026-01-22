---
title: JavaScriptでPowerPointプレゼンテーションに数式を追加
linktitle: PowerPoint数式
type: docs
weight: 80
url: /ja/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: Node.js 用 Aspose.Slides を使用して、PowerPoint の PPT と PPTX で数式を挿入・編集でき、OMML や書式設定コントロール、わかりやすいコードサンプルをサポートします。
---

## **概要**
PowerPoint では数式や数式式を記述し、プレゼンテーションに表示できます。PowerPoint ではさまざまな数学記号が表現でき、テキストや数式に追加できます。そのために PowerPoint の数式ビルダーが使用され、次のような複雑な式を作成できます。

- Math Fraction
- Math Radical
- Math Function
- Limits and log functions
- N‑ary operations
- Matrix
- Large operators
- Sin, cos functions

PowerPoint で数式を追加するには、*Insert → Equation* メニューを使用します。

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより XML 形式の数式テキストが作成され、PowerPoint で次のように表示されます。

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は多数の数学記号をサポートしていますが、複雑な数式を作成すると見栄えが良くないことがあります。頻繁に数学プレゼンテーションを作成するユーザーは、サードパーティ製のソリューションを使用して見栄えの良い数式を作成します。

[**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/) を使用すれば、C# で PowerPoint の数式をプログラム的に操作できます。新しい数式を作成したり、既存の数式を編集したり、数式構造を画像にエクスポートすることも部分的にサポートされています。

## **数式の作成方法**
数式要素は任意のレベルの入れ子構造で数学構造を構築するために使用されます。線形に並んだ数式要素の集合が **MathBlock** クラスで表される数式ブロックを形成します。**MathBlock** クラスは本質的に独立した数式、式、または方程式です。**MathPortion** は数式テキストを保持するために使用され、**Portion** とは混同しないでください。**MathParagraph** は複数の MathBlock を操作できるセットです。上記のクラスは Aspose.Slides API を介して PowerPoint の数式を扱う鍵となります。

以下に Aspose.Slides API を使用して次の数式を作成する方法を示します。

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを含むシェイプを追加します。

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

作成後、シェイプにはデフォルトで 1 つの段落と 1 つの MathPortion が含まれます。**MathPortion** クラスは数式テキストを内部に保持するポーションです。**MathPortion** 内の数式コンテンツにアクセスするには、**MathParagraph** 変数を参照します。

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

**MathParagraph** クラスは **MathBlock**（数式ブロック）を読み取り、追加、編集、削除でき、数式要素の組み合わせで構成されます。たとえば分数を作成してプレゼンテーションに配置します。

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

各数式要素は **MathElement** を実装するクラスで表されます。このクラスは数式式を簡単に作成するための多数のメソッドを提供します。たとえばピタゴラスの定理は次のように記述できます。

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

**MathElement** の操作は **MathBlock** など任意の要素タイプで実装されています。

完全なサンプルコードは以下のとおりです。

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

## **数式要素の種類**
数式は数式要素のシーケンスから構成されます。要素のシーケンスは数式ブロックで表され、要素の引数は木構造の入れ子になります。

多数の数式要素タイプがあり、各要素は他の要素に含める（集約する）ことができます。つまり要素は他の要素のコンテナとなり、木構造を形成します。数学テキストに他の要素を含まない最も単純な要素タイプです。

各数式要素は **MathElement** クラスを実装し、共通の数式操作セットを利用できます。

### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) クラスは数式テキストを表す基本要素です。数式テキストはオペランド、演算子、変数、その他の線形テキストを表すことができます。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) クラスは分子と分母で構成される分数オブジェクトを指定します。分数バーは水平または斜めに設定できます。また、スタック関数（要素を上下に配置し、バーなし）にも使用されます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) クラスは根号（数学的ルート）を指定し、基底とオプションの次数から構成されます。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) クラスは引数を持つ関数を指定します。プロパティは [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--)（関数名）と [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--)（関数の引数）です。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) クラスは総和や積分などの N 進演算子を指定します。演算子、基底（またはオペランド）、オプションの上限・下限で構成されます。加算や減算などの単純演算子は含まれません。これらは単一のテキスト要素 **MathematicalText** で表されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) クラスは上限または下限を作成します。ベースライン上のテキストと、その上または下に配置される縮小テキストで構成されます。単語 “lim” は含まれませんが、式の上部または下部にテキストを配置できます。たとえば次の式は **MathFunction** と **MathLimit** を組み合わせて作成します。

![todo:image_alt_text](powerpoint-math-equations_8.png)

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

これらのクラスは下付き文字または上付き文字を指定します。左または右側に同時に下付・上付を設定できますが、単独の下付・上付は右側のみサポートされます。**MathSubscriptElement** は数の次数を設定することも可能です。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) クラスは子要素を行と列に配置した行列オブジェクトを指定します。行列にはデフォルトの区切り文字がありません。括弧で囲む場合は **MathDelimiter** を使用します。NULL 引数を使用して行列内に空白を作ることができます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) クラスは縦方向の数式や任意の数学オブジェクトの配列を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素の書式設定**
- [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox) クラス: **MathElement** の周囲に矩形やその他の枠を描画します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox) クラス: 数学要素の論理的なボックス化（パッケージ化）を指定します。たとえば “==” 演算子をボックス化して改行を防げます。

- [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter) クラス: 開始文字と終了文字（丸括弧、波括弧、角括弧、縦棒など）で囲む区切り文字オブジェクトを指定し、内部に 1 つ以上の数学要素を含めます。例: (𝑥²); [𝑥²|𝑦²]。  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent) クラス: 基底と結合アクセント記号からなるアクセント関数を指定します。  
  例: 𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar) クラス: 基底引数と上棒または下棒からなるバー関数を指定します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter) クラス: 式の上部または下部に配置するグルーピング記号を指定し、要素間の関係を強調します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学操作**
各数学要素と **MathBlock** を介した数式は **MathElement** クラスを実装しています。既存の構造に対して操作を行い、より複雑な数式を構成できます。すべての操作は **MathElement** または文字列を引数に取ります。文字列引数が使用される場合、**MathematicalText** インスタンスが暗黙的に作成されます。利用可能な数式操作は以下のとおりです。

### **Join メソッド**
- `join(String)`
- `join(MathElement)`

要素を結合して数式ブロックを作成します。例:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Divide メソッド**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

指定した分子と分母で分数を作成します。例:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Enclose メソッド**
- `enclose()`
- `enclose(Char, Char)`

要素を括弧や任意の文字で囲みます。

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
- `function(MathElement)`

現在のオブジェクト名を関数名として、引数付き関数を作成します。

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(MathElement functionArgument);

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
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

現在のインスタンスを引数として指定関数に使用します。文字列として関数名（例: “cos”）を指定したり、列挙型 **MathFunctionsOfOneArgument** や **MathFunctionsOfTwoArguments** の定数を選択したりできます。

例:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft メソッド**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

下付き文字と上付き文字を設定します。左側または右側に同時に設定可能ですが、単独の下付き・上付きは右側のみサポートされます。**Superscript** は数の次数設定にも使用できます。

例:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical メソッド**
- `radical(String)`
- `radical(MathElement)`

指定した引数の次数の根号を作成します。

例:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

上限または下限を設定します。上限・下限は基底に対する位置を示します。

例として先ほどの式を作成します。

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary と Integral メソッド**
- `nary(MathNaryOperatorTypes, MathElement, MathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

**nary** と **integral** は **MathNaryOperator** タイプの N 進演算子を生成して返します。**nary** は **MathNaryOperatorTypes** 列挙体で演算子種別（総和、和集合など）を指定し、積分は含みません。**integral** は **MathIntegralTypes** 列挙体で積分タイプを指定します。

例:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray メソッド**
**toMathArray** は要素を縦方向の配列に変換します。**MathBlock** インスタンスに対して呼び出すと、子要素すべてが配列に格納されます。

例:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **書式設定操作: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **accent** メソッド: 要素の上にアクセント記号を付加します。  
- **overbar** と **underbar** メソッド: 要素の上または下にバーを付けます。  
- **group** メソッド: 下側の波括弧などのグルーピング文字で要素をグループ化します。  
- **toBorderBox** メソッド: 要素を枠付きボックスに配置します。  
- **toBox** メソッド: 可視的でない論理ボックスに配置します。

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

数式を追加するには `MathShape` オブジェクトを作成します。`MathShape` には自動的に数式ポーションが含まれます。次に `MathPortion` から `MathParagraph` を取得し、`MathBlock` オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい。Aspose.Slides は MathBlock を入れ子にして複雑な数式を作成できます。各数式要素は `MathElement` を継承しており、Join、Divide、Enclose などの操作で要素を組み合わせて構造を構築できます。

**既存の数式を更新または変更するにはどうすればよいですか？**

`MathParagraph` から既存の `MathBlock` を取得し、Join、Divide、Enclose などのメソッドで個々の要素を変更します。編集後にプレゼンテーションを保存すれば変更が反映されます。