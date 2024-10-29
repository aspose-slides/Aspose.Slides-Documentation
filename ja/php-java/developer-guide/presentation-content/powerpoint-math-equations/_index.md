---
title: PowerPoint 数学方程式
type: docs
weight: 80
url: /ja/php-java/powerpoint-math-equations/
keywords: " PowerPoint 数学方程式, PowerPoint 数学記号, PowerPoint 数式, PowerPoint 数学テキスト"
description: "PowerPoint 数学方程式, PowerPoint 数学記号, PowerPoint 数式, PowerPoint 数学テキスト"
---

## **概要**
PowerPointでは、数学の方程式や数式を書くことが可能であり、プレゼンテーションに表示できます。これを行うためには、さまざまな数学記号がPowerPointに表現されており、テキストや方程式に追加できます。それには、PowerPointで数学方程式のコンストラクタが使用され、以下のような複雑な数式を作成するのに役立ちます：

- 数学的分数
- 数学的根号
- 数学関数
- リミットおよび対数関数
- N-進演算
- 行列
- 大きな演算子
- サイン、コサイン関数

PowerPointに数学方程式を追加するには、*挿入 -> 方程式*メニューを使用します：

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、PowerPointで表示できるXML形式の数学テキストが作成されます：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPointは多くの数学記号をサポートして、数学方程式を作成します。ただし、PowerPointで複雑な数学方程式を作成すると、良好でプロフェッショナルな外観の結果を得られないことが多いです。数学プレゼンテーションを頻繁に作成する必要があるユーザーは、見栄えの良い数学の数式を作成するためにサードパーティのソリューションを利用しています。

[**Aspose.Slide API**](https://products.aspose.com/slides/php-java/)を使用することで、C#を使ってPowerPointのプレゼンテーション内の数学方程式をプログラムで操作できます。新しい数学の式を作成したり、以前に作成したものを編集したりできます。数学的構造を画像にエクスポートすることも部分的にサポートされています。

## **数学方程式の作成方法**
数学要素は、任意の入れ子レベルで任意の数学的構造を構築するために使用されます。数学要素の線形コレクションは、[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)クラスによって表現される数学ブロックを形成します。[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)クラスは、本質的に分離された数学的表現、数式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion)は、数学テキストを保持するために使用される数学部分です（[**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)と混同しないでください）。[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph)は、一連の数学ブロックを操作することを可能にします。前述のクラスは、Aspose.Slides APIを介してPowerPointの数学方程式を操作するための鍵となります。

次に、Aspose.Slides APIを介して次の数学方程式を作成する方法を見てみましょう：

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数学的表現を追加するには、まず数学テキストを含む図形を追加します：

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

作成後、図形は既にデフォルトで数学の部分を含む1つの段落を持ちます。[**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion)クラスは、内部に数学テキストを含む部分です。[**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion)の内部の数学コンテンツにアクセスするには、[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph)変数を参照します：

```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph)クラスは、数学的要素の組み合わせから構成される数学ブロック（[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)）を読み取り、追加、編集、削除することを可能にします。例えば、分数を作成し、プレゼンテーションに配置します：

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));
``` 

各数学要素は[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)インターフェースを実装するクラスによって表現されます。このインターフェースは、数学的表現を簡単に作成するための多くのメソッドを提供します。単一のコード行でかなり複雑な数学的表現を作成できます。例えば、ピタゴラスの定理は次のようになります：

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
``` 

[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)インターフェースの操作は、[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)を含むすべての要素に実装されています。

全ソースコードサンプル：

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
数学的表現は、数学要素のシーケンスから形成されます。数学要素のシーケンスは数学ブロックによって表現され、数学要素の引数は木構造のような入れ子を形成します。

数学ブロックを構築するために使用できる多くの数学要素のタイプがあります。これらの各要素は他の要素に含めることができます（集約することができる）。つまり、要素は実際には他の要素のコンテナであり、木構造を形成しています。最も単純な種類の要素は、他の数学テキストの要素を含まないものです。

各種の数学要素は、[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)インターフェースを実装しており、異なる種類の数学要素に対して共通の数学操作を使用できます。
### **MathematicalTextクラス**
[**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)クラスは、数学的テキストを表します - すべての数学的構造の基盤要素です。数学的テキストは、オペランドや演算子、変数、その他の任意の線形テキストを表すことができます。

例: 𝑎=𝑏+𝑐
### **MathFractionクラス**
[**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction)クラスは、分子と分母が分数バーで区切られた分数オブジェクトを指定します。分数バーは、分数のプロパティに応じて水平または対角のいずれかになります。分数オブジェクトは、分数バーのない1つの要素を別の要素の上に置くスタック関数を表すためにも使用されます。

例：

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadicalクラス**
[**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical)クラスは、基数およびオプションの指数から構成される根号関数（数学的ルート）を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction)クラスは、引数の関数を指定します。プロパティを含みます: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) - 関数名、[getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) - 関数引数。

例：

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator)クラスは、合計や積分などのN-進数学オブジェクトを指定します。演算子、基数（またはオペランド）、およびオプションの上限と下限から構成されます。N-進演算子の例としては、合計、和集合、交差点、積分などがあります。

このクラスは加算、減算などの単純な演算子を含みません。これらは単一のテキスト要素 - [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)によって表されます。

例：

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit)クラスは、上限または下限を作成します。基準線上のテキストと、その上または下にすぐに配置された小さなテキストを含むリミットオブジェクトを指定します。この要素には「lim」という単語は含まれませんが、式の上または下にテキストを配置することができます。したがって、次の式

![todo:image_alt_text](powerpoint-math-equations_8.png)

は次のように[**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction)と[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit)要素の組み合わせを使用して作成されます：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

次のクラスは下付きまたは上付きインデックスを指定します。同時に引数の左または右側に下付きおよび上付き文字を設定できますが、単一の下付きまたは上付き文字は右側のみにサポートされています。[MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)は、数値の数学的指数を設定するためにも使用できます。

例：

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix)クラスは、行と列に配置された子要素から構成される行列オブジェクトを指定します。行列には組み込みの区切り文字がないことに注意してください。行列を括弧で配置するには、区切り文字オブジェクト - [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter)を使用する必要があります。null引数は行列の間にギャップを作るために使用できます。

例：

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray)クラスは、方程式や任意の数学的オブジェクトの垂直配列を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **数学要素のフォーマット**
- [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox)クラス: [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)の周りに矩形または別の境界を描きます。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox)クラス: 数学要素の論理的ボックス（パッケージング）を指定します。例えば、ボックス化されたオブジェクトは、整列点の有無にかかわらず演算子エミュレーターとして機能したり、行のブレークポイントとして機能したり、行内での行のブレークを許可しないようにグルーピングされたりすることがあります。例えば、「==」演算子は、行のブレークを防ぐためにボックス化される必要があります。
- [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter)クラス: 開くおよび閉じる文字（例えばカッコ、波括弧、中括弧、垂直バー）からなる区切り文字オブジェクトを指定し、その中に1つ以上の数学的要素を指定された文字で区切って含めます。例: (𝑥2); [𝑥2|𝑦2]。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent)クラス: 基礎となる文字と組み合わせるダイアクリティカルマークからなるアクセント関数を指定します。

  例: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar)クラス: 基本引数とオーバーバーまたはアンダーバーからなるバー関数を指定します。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter)クラス: 要素間の関係を強調するために、通常は式の上または下に grouping 記号を指定します。
  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学演算**
各数学要素および数学的表現（[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)を介して）は、[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)インターフェースを実装しています。これにより、既存の構造で演算を使用し、より複雑な数学的表現を形成できます。すべての演算には2つのパラメータセットがあり、引数として[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)または文字列を使用できます。[**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)クラスのインスタンスは、文字列引数が使用されるときに指定された文字列から暗黙的に作成されます。Aspose.Slidesで利用可能な数学演算は以下の通りです。
### **Joinメソッド**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

数学要素を結合し、数学ブロックを形成します。例えば：

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Divideメソッド**
- [divide(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

指定されたタイプの分数を、この分子と指定された分母で作成します。例えば：

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Encloseメソッド**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

要素を指定された文字（カッコなど）で囲みます。

```php
``` 

例えば：

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Functionメソッド**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

引数の関数を、現在のオブジェクトを関数名として使用します。

```php
``` 

例えば：

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **AsArgumentOfFunctionメソッド**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

現在のインスタンスを引数として使用して指定された関数を取得します。以下のことができます：

- 例えば「cos」のように文字列を関数名として指定する。
- 列挙型[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument)または[**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments)のいずれかの事前定義された値を選択する、例えば[**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument)。[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin）。
- [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)のインスタンスを選択する。

例えば：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeftメソッド**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

下付きおよび上付き文字を設定します。引数の左または右側に下付きおよび上付き文字を同時に設定できますが、単一の下付きまたは上付き文字は右側のみにサポートされています。**上付き文字**は、数値の数学的指数を設定するためにも使用できます。

例：

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radicalメソッド**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定された引数の指定された次数の数学的ルートを指定します。

例：

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **SetUpperLimitおよびSetLowerLimitメソッド**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

上限または下限を取得します。ここで、上限と下限は単に基数に対する引数の場所を示します。

式を考えてみましょう：

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は、[MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction)および[MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit)のクラスの組み合わせと、[IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)の操作を使用して次のように作成できます：

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **NaryおよびIntegralメソッド**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary**および**integral**メソッドは、[**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator)型で表されるN-進演算子を作成して返します。naryメソッドでは、[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes)列挙型が演算子の種類を指定します：合計、和集合など、積分は含まれません。Integralメソッドでは、列挙型[**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes)を使用した特化された操作である積分があります。

例：

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **ToMathArrayメソッド**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--)は、要素を垂直配列に配置します。この操作が[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)インスタンスに呼び出されると、すべての子要素が返される配列に配置されます。

例：

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **フォーマット操作: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-)メソッドは、アクセントマーク（要素の上にある文字）を設定します。
- [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--)および[**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--)メソッドは、上または下にバーを設定します。
- [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--)メソッドは、底部の波括弧などのグルーピングキャラクターを使用してグループに配置します。
- [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--)メソッドは、ボーダーボックスに配置します。
- [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--)メソッドは、可視外のボックス（論理的グループ化）に配置します。

例：

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 