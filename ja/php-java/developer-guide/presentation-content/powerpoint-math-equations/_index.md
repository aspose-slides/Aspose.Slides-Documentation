---
title: PHPでPowerPointプレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Java経由でPHP用Aspose.Slidesを使用し、PowerPoint PPTおよびPPTXに数式を挿入・編集します。OMML、書式設定コントロール、明確なコードサンプルをサポートしています。"
---

## **概要**
PowerPointでは、数式やフォーミュラを書いてプレゼンテーションに表示することが可能です。そのために、PowerPointではさまざまな数学記号が表現され、テキストや数式に追加できます。そのためにPowerPointの数式コンストラクタが使用され、次のような複雑な式を作成できます:

- 数学分数
- 数学根号
- 数学関数
- 極限と対数関数
- N元演算
- 行列
- 大きな演算子
- サイン、コサイン関数

PowerPointで数式を追加するには、*挿入 -> 数式* メニューを使用します:

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML形式の数式テキストが作成され、PowerPointで次のように表示されます: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPointは多数の数学記号をサポートして数式を作成できますが、複雑な数式を作成すると見栄えの良いプロフェッショナルな結果が得られないことが多いです。頻繁に数学的なプレゼンテーションを作成するユーザーは、見栄えの良い数式を作るためにサードパーティ製品を利用します。

[**Aspose.Slide API**](https://products.aspose.com/slides/php-java/) を使用すると、C# で PowerPoint プレゼンテーション内の数式をプログラムで操作できます。新しい数式を作成したり、既存のものを編集したりできます。数式構造を画像としてエクスポートする機能も一部サポートされています。

## **数式の作成方法**
数学要素は、任意の入れ子構造で数学的構造を構築するために使用されます。数学要素の線形コレクションは、[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) クラスによって表される数学ブロックを形成します。[**MathBlock**] クラスは本質的に個別の数式、式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) は数学テキストを保持するための数学部分で、[**Portion**] と混同しないでください。[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) は複数の MathBlock を操作できるようにします。上記のクラスは Aspose.Slides API を介して PowerPoint の数式を扱う鍵となります。

以下の数式を Aspose.Slides API で作成する方法を見てみましょう:

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを含むシェイプを追加します:

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


作成後、シェイプにはデフォルトで数学部分を含む段落が1つ入ります。[**MathPortion**] クラスは内部に数学テキストを含む部分です。[**MathPortion**] 内の数学コンテンツにアクセスするには、[**MathParagraph**] 変数を参照してください:

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


## **数学要素の種類**
数式は数学要素のシーケンスから形成されます。数学要素のシーケンスは数学ブロックで表され、要素の引数はツリー構造の入れ子を形成します。

数学ブロックを構成するために使用できる数学要素の種類は多数あります。各要素は別の要素に含める（集約する）ことができ、要素は実質的に他の要素のコンテナとなりツリー構造を形成します。数学テキストの他要素を含まない最も単純な要素です。

各種数学要素は `MathElement` クラスを実装しており、異なるタイプの数学要素に共通の数学操作セットを使用できます。

### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) クラスは数学テキストを表し、すべての数学構造の基礎要素です。数学テキストは被演算子や演算子、変数、その他の線形テキストを表すことができます。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) クラスは分数オブジェクトを指定し、分子と分母が分数線で区切られます。分数線は横または斜めで、分数のプロパティにより決まります。このオブジェクトは、分数線なしで要素を上下に配置するスタック関数としても使用されます。

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) クラスは根号関数（数学的ルート）を指定し、基底とオプションの次数から構成されます。

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) クラスは引数の関数を指定します。プロパティは [getName] - 関数名、[getBase] - 関数の引数です。

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) クラスは総和や積分などの N 元数学オブジェクトを指定します。演算子、基底（またはオペランド）、および任意の上限・下限から構成されます。N元演算子の例は総和、合併、交差、積分です。

このクラスは加算や減算などの単純な演算子は含みません。それらは単一のテキスト要素 [MathematicalText] で表されます。

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) クラスは上限または下限を作成します。ベースライン上のテキストと、その直上または直下に小さく表示されるテキストからなる限界オブジェクトを指定します。この要素は “lim” という語を含まず、式の上部または下部にテキストを配置できます。したがって、式

![todo:image_alt_text](powerpoint-math-equations_8.png)

は以下のように [**MathFunction**] と [**MathLimit**] 要素の組み合わせで作成されます:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

以下のクラスは下付きインデックスまたは上付きインデックスを指定します。引数の左側または右側で下付きと上付きの両方を同時に設定できますが、単独の下付きまたは上付きは右側のみでサポートされます。[MathSubscriptElement] は数値の数学的次数を設定することもできます。

例: 

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) クラスは行列オブジェクトを指定し、子要素が1つ以上の行と列に配置されます。行列には組み込みの区切り記号がないことに注意してください。括弧で囲むには区切りオブジェクト [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/) を使用します。Null 引数は行列の隙間作成に使用できます。

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) クラスは垂直配列の方程式または任意の数学オブジェクトを指定します。

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素の書式設定**
- [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox) クラス: `MathElement` の周囲に長方形またはその他の枠線を描画します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox) クラス: 数学要素の論理的なボックス化（パッケージ化）を指定します。例えば、ボックス化されたオブジェクトは整列ポイントの有無にかかわらず演算子のエミュレータとして、行分割点として、または行分割を許可しないようにグループ化することができます。例として、"==" 演算子は行分割を防ぐためにボックス化すべきです。

- [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter) クラス: 開始文字と終了文字（括弧、波かっこ、角括弧、縦棒など）からなる区切りオブジェクトを指定し、内部に1つ以上の数学要素を、指定文字で区切って配置します。例: (𝑥2); [𝑥2|𝑦2].  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent) クラス: 基底と結合アクセント記号からなるアクセント機能を指定します。例: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar) クラス: 基底引数と上バーまたは下バーからなるバー機能を指定します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter) クラス: 式の上または下に配置されるグルーピング記号を指定し、要素間の関係を強調します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学的操作**
各数学要素と数学式（[**MathBlock**] 経由）は `MathElement` クラスを継承します。これにより、既存の構造に対して操作を適用し、より複雑な数学式を形成できます。すべての操作は2つのパラメータセットを持ち、`MathElement` または文字列を引数として受け取ります。文字列引数が使用される場合、指定された文字列から暗黙的に [**MathematicalText**] クラスのインスタンスが作成されます。Aspose.Slides で利用可能な数式操作を以下に示します。

### **Join メソッド**
- `join(String)`
- `join(MathElement)`

数学要素を結合して数学ブロックを形成します。例:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Divide メソッド**
- `[divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

指定された分子と分母で、指定されたタイプの分数を作成します。例:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Enclose メソッド**
- `enclose()`
- `enclose(Char, Char)`

要素を指定した文字（括弧など）で囲みます。

```php

``` 

例:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Function メソッド**
- `function(String)`
- `function(MathElement)`

現在のオブジェクトを関数名として、引数の関数を取得します。

```php

``` 

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

現在のインスタンスを引数として、指定された関数を取得します。以下が可能です:
- 関数名を文字列で指定（例: “cos”）。
- 列挙型 [**MathFunctionsOfOneArgument**] または [**MathFunctionsOfTwoArguments**] の事前定義値を選択（例: [**MathFunctionsOfOneArgument::ArcSin**]）。
- `MathElement` のインスタンスを選択。

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft メソッド**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

下付きと上付き文字を設定します。引数の左側または右側で同時に設定可能ですが、単独の下付きまたは上付きは右側のみでサポートされます。**Superscript** は数の次数を設定することもできます。

例:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical メソッド**
- `radical(String)`
- `radical(MathElement)`

指定された引数の次数の数学的根号を指定します。

例:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

上限または下限を取得します。ここで、上限と下限は基底に対する引数の位置を示します。

以下の式を考えます:

![todo:image_alt_text](powerpoint-math-equations_8.png)

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

**nary** と **integral** の両メソッドは [**MathNaryOperator**] タイプの N元演算子を作成して返します。nary メソッドでは、[**MathNaryOperatorTypes**] 列挙型が演算子タイプ（総和、合併など）を指定し、積分は含みません。Integral メソッドでは、積分専用の列挙型 [**MathIntegralTypes**] を使用します。

例:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **ToMathArray メソッド**
`MathElement.toMathArray` は要素を垂直配列に配置します。[**MathBlock**] インスタンスに対して呼び出すと、すべての子要素が返された配列に配置されます。

例:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **書式設定操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **`accent`** メソッドは要素の上にアクセント記号（文字）を設定します。
- **`overbar`** と **`underbar`** メソッドは上部または下部にバーを設定します。
- **`group`** メソッドは下部の波かっこなどのグルーピング文字を使用して要素をグループ化します。
- **`toBorderBox`** メソッドは要素を枠線付きボックスに配置します。
- **`toBox`** メソッドは要素を非表示のボックス（論理グループ）に配置します。

例:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **FAQ**
**PowerPoint スライドに数式を追加するにはどうすればよいですか？**

数式を追加するには、数学シェイプオブジェクトを作成します。このオブジェクトは自動的に数学部分を含みます。次に、[MathParagraph] から [MathPortion] を取得し、[MathBlock] オブジェクトを追加します。

**複雑な入れ子数式を作成できますか？**

はい、Aspose.Slides は MathBlock を入れ子にすることで複雑な数式を作成できます。各数学要素は Join、Divide、Enclose などの操作を適用して、より複雑な構造に結合できます。

**既存の数式を更新または修正するにはどうすればよいですか？**

数式を更新するには、[MathParagraph] を通じて既存の MathBlock にアクセスします。その後、Join、Divide、Enclose などのメソッドを使用して要素を変更し、プレゼンテーションを保存して変更を適用します。