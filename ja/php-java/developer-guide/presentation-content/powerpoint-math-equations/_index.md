---
title: PHP で PowerPoint プレゼンテーションに数式を追加する
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/php-java/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数式
- 数式テキスト
- 数式を追加
- 記号を追加
- 式を追加
- テキストを追加
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java を介した PHP 用 Aspose.Slides で PowerPoint PPT および PPTX の数式を挿入・編集でき、OMML、書式設定コントロール、分かりやすいコードサンプルをサポートしています。"
---

## **概要**
PowerPoint では、数式や数式式を書き込み、プレゼンテーションに表示することができます。これを行うために、PowerPoint にはさまざまな数学記号が用意されており、テキストや数式に追加できます。そのために PowerPoint の数式コンストラクタが使用され、次のような複雑な式を作成できます。

- 数学分数
- 数学根号
- 数学関数
- 限界および対数関数
- N元演算
- 行列
- 大きな演算子
- 正弦・余弦関数

PowerPoint で数式を追加するには、*Insert -> Equation* メニューを使用します。

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML 形式の数式テキストが作成され、PowerPoint で次のように表示されます。

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は多数の数学記号をサポートしていますが、PowerPoint で複雑な数式を作成すると、見栄えの良いプロフェッショナルな結果が得られないことがよくあります。頻繁に数式プレゼンテーションを作成するユーザーは、サードパーティ製のソリューションを利用して見栄えの良い数式を作成しています。

[**Aspose.Slide API**](https://products.aspose.com/slides/php-java/) を使用すると、C# で PowerPoint プレゼンテーション内の数式をプログラムから操作できます。新しい数式を作成したり、既存の数式を編集したりできます。また、数式構造を画像としてエクスポートする機能も一部サポートされています。

## **数式の作成方法**
数式要素は、任意の入れ子レベルで数式構造を構築するために使用されます。線形コレクションの数式要素が、[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) クラスで表される数式ブロックを形成します。[**MathBlock**] クラスは本質的に分離された数式、式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) は数式テキストを保持するために使用される数式部分です（[**Portion**] と混同しないでください）。[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) は複数の数式ブロックを操作できます。これらのクラスは、Aspose.Slides API 経由で PowerPoint の数式を操作するためのキーとなります。

以下の数式を Aspose.Slides API で作成する方法を見てみましょう。

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを格納するシェイプを追加します。

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


作成後、シェイプにはデフォルトで 1 つの段落と数式部分が含まれます。**MathPortion** クラスは数式テキストを内部に保持する部分です。**MathPortion** の数式コンテンツにアクセスするには、**MathParagraph** 変数を参照してください。

```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

The [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) class allows to read, add, edit and delete math blocks ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));
``` 

Each mathematical element is represented by some class that implements the `MathElement` class. This class provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
``` 

Operations of the class `MathElement` are implemented in any type of element, including the [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

The full source code sample:

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $fraction = new MathematicalText("x")->divide("y");
    $mathParagraph->add(new MathBlock($fraction));
    $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
    $mathParagraph->add($mathBlock);
    $pres->save("math.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **数式要素の種類**
数式は数式要素のシーケンスから構成されます。数式要素のシーケンスは数式ブロックで表され、要素の引数はツリー状に入れ子になります。

数式ブロックを構成するために使用できる数式要素の種類は多数あります。各要素は別の要素に含める（集約する）ことができ、実際には他の要素のコンテナとして機能し、ツリー構造を形成します。最も単純な要素は、他の数式テキスト要素を含まないものです。

各数式要素は `MathElement` クラスを継承しており、異なる種類の要素に共通の数式操作セットを使用できます。

### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) クラスは、すべての数式構築の基礎要素である数式テキストを表します。数式テキストはオペランドや演算子、変数、その他の線形テキストを表すことができます。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) クラスは、分子と分母が分数バーで区切られた分数オブジェクトを指定します。分数バーは水平または斜めに設定でき、分数プロパティに依存します。また、分数バーなしで要素を上下に配置するスタック関数としても使用されます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) クラスは、根号（数学的ルート）を指定します。基底とオプションの次数から構成されます。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) クラスは引数の関数を指定します。プロパティは `getName`（関数名）と `getBase`（関数引数）です。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) クラスは、総和や積分などの N 元演算子を指定します。演算子、基底（またはオペランド）およびオプションの上限・下限から構成されます。例としては総和、和集合、積集合、積分があります。

このクラスは加算・減算などの単純演算子を含みません。単純演算子は単一のテキスト要素 **MathematicalText** で表されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) クラスは上限または下限を作成します。基線上のテキストと、その直上または直下に配置される縮小テキストから構成されます。この要素は “lim” という語を含まず、式の上部または下部にテキストを配置するために使用されます。したがって、次の式は

![todo:image_alt_text](powerpoint-math-equations_8.png)

以下のように **MathFunction** と **MathLimit** の組み合わせで作成されます。

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

以下のクラスは下付きまたは上付きインデックスを指定します。左側または右側に同時に下付き・上付きインデックスを設定できますが、単一の下付き・上付きは右側のみでサポートされます。**MathSubscriptElement** は数値の次数を設定するためにも使用できます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) クラスは、子要素を 1 行以上の行と列に配置した行列オブジェクトを指定します。行列には既定の区切り文字がないことに注意してください。括弧で囲む場合は区切りオブジェクト **MathDelimiter** を使用します。`null` 引数を使用して行列の空白を作成できます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) クラスは、垂直方向の式または任意の数式オブジェクトの配列を指定します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数式要素の書式設定**
- [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox) クラス: `MathElement` の周囲に長方形またはその他の枠線を描画します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox) クラス: 数式要素の論理的なボックス化（パッケージ化）を指定します。たとえば、ボックス化されたオブジェクトは整列点の有無にかかわらず演算子エミュレータとして機能したり、改行ブレークポイントとして機能したり、改行を許可しないようにグループ化されたりします。例として “==” 演算子は改行を防ぐためにボックス化する必要があります。

- [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter) クラス: 開始文字と終了文字（丸括弧、波括弧、角括弧、縦棒など）で構成され、内部に 1 つ以上の数式要素を含む区切りオブジェクトを指定します。例: (𝑥2); [𝑥2|𝑦2]。  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent) クラス: 基底と結合アクセント記号からなるアクセント関数を指定します。  
  例: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar) クラス: 基底引数と上バーまたは下バーからなるバー関数を指定します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter) クラス: 式の上または下に配置されるグルーピング記号を指定し、要素間の関係を強調します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数式演算**
各数式要素および数式式（[**MathBlock**] を介して）は `MathElement` クラスを継承しています。既存の構造に対して操作を行い、より複雑な数式を形成できます。すべての操作は 2 つのパラメータセット（`MathElement` または文字列）を受け取ります。文字列引数が使用される場合、指定された文字列から暗黙的に **MathematicalText** インスタンスが作成されます。Aspose.Slides で利用できる数式操作は以下のとおりです。

### **Join メソッド**
- `join(String)`
- `join(MathElement)`

数式要素を結合し、数式ブロックを形成します。例:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Divide メソッド**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

指定された分子と分母で指定タイプの分数を作成します。例:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Enclose メソッド**
- `enclose()`
- `enclose(Char, Char)`

要素を括弧やその他の文字で囲みます。

例:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Function メソッド**
- `function(String)`
- `function(MathElement)`

現在のオブジェクトを関数名として、引数の関数を作成します。

例:

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **AsArgumentOfFunction メソッド**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

現在のインスタンスを引数として指定関数を作成します。例:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
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

下付き・上付き、または左右同時設定を行います。**Superscript** は数の次数を設定することもできます。

例:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical メソッド**
- `radical(String)`
- `radical(MathElement)`

指定した次数の根号を作成します。

例:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

上限または下限を設定します。以下の式を例にします。

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は **MathFunction** と **MathLimit** の組み合わせ、および `MathElement` の操作で作成できます。

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Nary と Integral メソッド**
- `nary(MathNaryOperatorTypes, MathElement, MathElement`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

**nary** と **integral** はそれぞれ **MathNaryOperator** 型のオペレータを生成して返します。**nary** は総和・和集合などの N 元演算子を、**integral** は積分を表す専用の列挙型 **MathIntegralTypes** を使用します。

例:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **ToMathArray メソッド**
`MathElement.toMathArray` は要素を垂直配列に配置します。**MathBlock** インスタンスに対して呼び出すと、すべての子要素が返された配列に入ります。

例:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **書式設定操作: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- `accent` メソッドは要素の上部にアクセント記号を設定します。
- `overbar` と `underbar` メソッドはそれぞれ上バー・下バーを設定します。
- `group` メソッドは下括弧や他のグルーピング文字で要素をグループ化します。
- `toBorderBox` メソッドは要素を枠付きボックスに配置します。
- `toBox` メソッドは視覚的でない論理ボックスに配置します。

例:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **FAQ**

**PowerPoint のスライドに数式を追加するにはどうすればよいですか？**

数式シェイプオブジェクトを作成すると、自動的に数式部分が含まれます。その後、**MathPortion** から **MathParagraph** を取得し、**MathBlock** オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい。Aspose.Slides は MathBlock を入れ子にすることで複雑な数式を作成できます。各数式要素は Join、Divide、Enclose などの操作で組み合わせて、より高度な構造を構築できます。

**既存の数式を更新または変更するにはどうすればよいですか？**

**MathParagraph** を介して既存の MathBlock にアクセスし、Join、Divide、Enclose などのメソッドを使用して要素を変更します。編集後にプレゼンテーションを保存すれば変更が適用されます。