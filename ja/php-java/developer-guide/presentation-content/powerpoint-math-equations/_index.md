---
title: PowerPoint プレゼンテーションに PHP で数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/php-java/powerpoint-math-equations/
keywords:
- 数式
- 数記号
- 数式
- 数式テキスト
- 数式を追加
- 数記号を追加
- 数式を追加
- 数式テキストを追加
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint の PPT および PPTX に数式を挿入および編集でき、OMML、書式設定コントロール、明確なコードサンプルをサポートします。"
---

## **概要**
PowerPoint では、数式や数式を記述してプレゼンテーションに表示することができます。そのために、さまざまな数学記号が PowerPoint で表現され、テキストや式に追加できます。そのために、PowerPoint では数式コンストラクタが使用され、次のような複雑な式の作成に役立ちます：

- 数式分数
- 数式根号
- 数式関数
- リミットと対数関数
- N 変数演算
- 行列
- 大型演算子
- 正弦、余弦関数

PowerPoint で数式を追加するには、*Insert -> Equation* メニューを使用します：

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML 形式の数式テキストが作成され、PowerPoint で以下のように表示されます：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint には多数の数学記号が用意されており、数式の作成が可能です。ただし、PowerPoint で複雑な数式を作成すると、見栄えの良いプロフェッショナルな結果が得られないことが多いです。頻繁に数学プレゼンテーションを作成するユーザーは、見栄えの良い数式を作るためにサードパーティのソリューションを利用しています。

[**Aspose.Slide API**](https://products.aspose.com/slides/php-java/) を使用すると、C# で PowerPoint プレゼンテーション内の数式をプログラムで操作できます。新しい数式を作成したり、既存の数式を編集したりできます。数式構造を画像へエクスポートする機能も部分的にサポートされています。

## **数式の作成方法**
数学要素は、任意のレベルの入れ子構造を持つ数学構築を構築するために使用されます。数学要素の線形コレクションは、[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) クラスで表される数学ブロックを形成します。[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) クラスは、実質的に分離された数学式、数式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) は、数学テキストを保持するために使用される数学部分です（[**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) と混同しないでください）。[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) は、数学ブロックのセットを操作できるようにします。上述のクラスは、Aspose.Slides API を介して PowerPoint の数式を扱う際の鍵となります。

以下の数式を Aspose.Slides API で作成する方法を見てみましょう：

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを含むシェイプを追加します：

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


作成後、シェイプにはデフォルトで数学部分を含む段落が 1 つ含まれます。[**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) クラスは内部に数学テキストを含む部分です。[**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) 内の数学コンテンツにアクセスするには、[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) 変数を参照してください：

```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

The [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) class allows to read, add, edit and delete math blocks ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

``` 

Each mathematical element is represented by some class that implements the [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) interface. This interface provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

``` 

Operations of the interface [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) are implemented in any type of element, including the [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

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


## **数学要素のタイプ**
数式は数学要素のシーケンスから構成されます。数学要素のシーケンスは数学ブロックで表され、数学要素の引数はツリー状の入れ子構造を形成します。

数学ブロックを構成するために使用できる数学要素のタイプは多数あります。これらの要素はそれぞれ他の要素に含める（集約）ことができます。つまり、要素は他の要素のコンテナであり、ツリー状の構造を形成します。数学テキストの他の要素を含まない最も単純な要素タイプです。

各種数学要素は[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) インターフェイスを実装しており、異なるタイプの数学要素に共通の数学操作セットを使用できます。

### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) クラスは数学テキストを表します。これはすべての数学構築の基礎要素です。数学テキストはオペランドや演算子、変数、およびその他の線形テキストを表すことができます。  

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) クラスは、分子と分母が分数バーで区切られた分数オブジェクトを指定します。分数バーは水平または対角線で、分数プロパティに応じて決まります。このオブジェクトは、分数バーなしで一つの要素を別の要素の上に配置するスタック関数としても使用されます。  

例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) クラスは、根号（数学的ルート）関数を指定します。基底とオプションの次数から構成されます。  

例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) クラスは、引数の関数を指定します。プロパティは [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--)（関数名）と [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--)（関数引数）です。  

例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) クラスは、総和や積分などの N 変数数学オブジェクトを指定します。演算子、基底（またはオペランド）、およびオプションの上限・下限で構成されます。例として総和、和集合、交差、積分があります。  

このクラスは加算や減算などの単純な演算子を含みません。単純な演算子は単一のテキスト要素—[MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)—で表されます。  

例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) クラスは上限または下限を作成します。ベースライン上のテキストと、その直上または直下に配置された縮小サイズのテキストからなるリミットオブジェクトを指定します。この要素は “lim” という文字列を含まず、式の上部または下部にテキストを配置できるようにします。したがって、式  

![todo:image_alt_text](powerpoint-math-equations_8.png)

は [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) と [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) を組み合わせて次のように作成します：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

以下のクラスは下付や上付を指定します。左側または右側の引数に対して同時に下付と上付を設定できますが、右側単体での下付または上付のみがサポートされます。[MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) は数の次数を設定する際にも使用できます。  

例：  

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) クラスは、子要素を1 行または複数行・列に配置した行列オブジェクトを指定します。行列には組み込みの区切り文字はありません。区切り文字オブジェクト—[**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter)—を使用して括弧で囲む必要があります。NULL 引数を使用して行列内に空白を作ることができます。  

例：  

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) クラスは、縦方向に配列された式や任意の数学オブジェクトを指定します。  

例：  

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素の書式設定**
- [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox) クラス： [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) の周囲に長方形やその他の枠線を描画します。  

  例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox) クラス：数学要素の論理的なボックス化（パッケージ化）を指定します。例えば、ボックス化されたオブジェクトは、配置点の有無にかかわらず演算子エミュレータとして機能したり、行の改行点として機能したり、改行を許可しないようにグループ化したりできます。例えば、"==" 演算子は行の改行を防ぐためにボックス化すべきです。

- [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter) クラス：開閉文字（括弧、波括弧、角括弧、縦棒など）と、内部に1 個以上の数学要素を含む区切り文字オブジェクトを指定します。例：(𝑥²); [𝑥²|𝑦²]。  

  例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent) クラス：基底と結合アクセント記号からなるアクセント関数を指定します。  

  例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar) クラス：基底引数と上バーまたは下バーからなるバー関数を指定します。  

  例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter) クラス：式の上または下に配置されるグルーピング記号を指定し、要素間の関係を強調します。  

  例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学演算**
各数学要素と [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) を介した数学式は、[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) インターフェイスを実装しています。既存の構造に対して操作を行い、より複雑な式を形成できます。すべての操作は、[**IMathElement**] または文字列を引数に取ります。文字列引数が使用された場合、指定された文字列から暗黙的に [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) インスタンスが作成されます。Aspose.Slides が提供する数学操作は以下の通りです。

### **Join メソッド**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

数学要素を結合して数学ブロックを形成します。例：

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Divide メソッド**
- [divide(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

指定した分子と分母から特定のタイプの分数を作成します。例：

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Enclose メソッド**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

要素を指定した文字（括弧など）で囲みます。

例：

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Function メソッド**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

現在のオブジェクトを関数名として、引数関数を作成します。

例：

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **AsArgumentOfFunction メソッド**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

現在のインスタンスを引数として、指定した関数を適用します。  
- 関数名を文字列で指定（例: “cos”）  
- 列挙型 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) や [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments) の定数を使用（例: [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**]）  
- [**IMathElement**] のインスタンスを使用  

例：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft メソッド**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

下付と上付を設定します。左側または右側の引数に対して同時に下付と上付を設定できますが、右側単体での下付または上付のみがサポートされます。**Superscript** は数の次数を設定する際にも使用できます。

例：

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical メソッド**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定した引数から、指定した次数の数学的根号を設定します。

例：

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

上限または下限を設定します。上限・下限は、基底に対する位置（上または下）を示すだけです。

例として次の式を考えます：

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) と [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) の組み合わせ、および [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) の操作で作成できます：

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Nary と Integral メソッド**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary** と **integral** はどちらも [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator) 型のオブジェクトを生成して返します。**nary** メソッドでは、演算子の種類（総和、和集合など）を示す列挙型 [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) を使用し、積分は含まれません。**integral** メソッドは積分専用で、積分のタイプを表す列挙型 [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes) を使用します。

例：

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **ToMathArray メソッド**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) は要素を縦方向の配列に配置します。これを [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) インスタンスに対して呼び出すと、すべての子要素が返された配列に配置されます。

例：

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **Formatting Operations: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) メソッドは要素の上にアクセント記号（文字）を付加します。
- [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) と [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) メソッドはそれぞれ要素の上部または下部にバーを付加します。
- [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) メソッドは、下括弧やその他の記号を使用して要素をグループ化します。
- [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) メソッドは要素を枠付きボックスに配置します。
- [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) メソッドは要素を非表示の箱（論理的グルーピング）に配置します。

例：

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **FAQ**

**PowerPoint のスライドに数式を追加するにはどうすればよいですか？**

数式シェイプオブジェクトを作成します。これには自動的に数学部分が含まれます。その後、[MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) から [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) を取得し、[MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい。Aspose.Slides では MathBlock を入れ子にすることで複雑な数式を作成できます。各数学要素に対して Join、Divide、Enclose などの操作を適用して、より複雑な構造に組み合わせることが可能です。

**既存の数式を更新または変更するにはどうすればよいですか？**

[MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) を介して既存の MathBlock にアクセスします。Join、Divide、Enclose などのメソッドを使用して式の個々の要素を変更できます。編集後にプレゼンテーションを保存すれば変更が適用されます。