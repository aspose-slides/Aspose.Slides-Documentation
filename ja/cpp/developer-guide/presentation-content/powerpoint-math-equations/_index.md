---
title: PowerPoint 数学方程式
type: docs
weight: 80
url: /cpp/powerpoint-math-equations/
keywords: " PowerPoint 数学方程式, PowerPoint 数学記号, PowerPoint 数式, PowerPoint 数学テキスト"
description: "PowerPoint 数学方程式, PowerPoint 数学記号, PowerPoint 数式, PowerPoint 数学テキスト"
---

## **概要**
PowerPointでは、数学の方程式や数式を書くことができ、プレゼンテーションに表示することができます。そのために、さまざまな数学記号がPowerPointで表現され、テキストや方程式に追加できます。そのために、PowerPointでは数学方程式のコンストラクタが使用され、以下のような複雑な数式を作成するのに役立ちます：

- 数学的分数
- 数学的根号
- 数学関数
- 極限と対数関数
- N-進演算
- 行列
- 大きな演算子
- サイン、コサイン関数

PowerPointに数学方程式を追加するには、*挿入 -> 数式* メニューを使用します：

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、PowerPointで次のように表示できるXML形式の数学テキストが作成されます：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPointは、数学方程式を作成するための多くの数学記号をサポートしています。しかし、PowerPointで複雑な数学方程式を作成することは、しばしば良好でプロフェッショナルな見た目の結果をもたらしません。数学プレゼンテーションを頻繁に作成する必要があるユーザーは、見栄えの良い数式を作成するためにサードパーティのソリューションを利用することがよくあります。

[**Aspose.Slide API**](https://products.aspose.com/slides/cpp/)を使用すると、C++でプログラム的にPowerPointプレゼンテーション内の数学方程式を操作できます。新しい数学表現を作成するか、以前に作成したものを編集します。数学構造の画像へのエクスポートも部分的にサポートされています。

## **数学方程式の作成方法**
数学要素は、あらゆるレベルのネスティングを持つ数学的構成を構築するために使用されます。数学要素の線形コレクションは、[**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)クラスで表される数学ブロックを形成します。[**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)クラスは、本質的に独立した数学的表現、数式、または方程式です。[**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion)は数学的部分で、数学テキストを保持するために使用されます（[**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)とは混同しないでください）。[**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)は、一連の数学ブロックを操作することを可能にします。上記のクラスは、Aspose.Slides APIを介してPowerPointの数学方程式で作業するための鍵です。

Aspose.Slides APIを使用して、以下の数学方程式を作成する方法を見てみましょう：

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数学的表現を追加するには、まず数学テキストを含む形状を追加します：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

作成後、形状にはデフォルトで数学的部分を持つ1つの段落が含まれています。[**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion)クラスは、内部に数学テキストを含む部分です。[**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion)内の数学的内容にアクセスするには、[**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)変数を参照します：

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)クラスは、数学要素の組み合わせから構成される数学ブロック（[**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)）を読み取ったり、追加したり、編集したり削除したりすることを可能にします。たとえば、分数を作成してプレゼンテーションに配置する：

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

各数学要素は、[**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)インターフェイスを実装するいくつかのクラスによって表されます。このインターフェイスはいくつかのメソッドを提供し、数学表現を簡単に作成できます。1行のコードでかなり複雑な数学表現を作成できます。たとえば、ピタゴラスの定理は以下のようになります：

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

インターフェイス[**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)の操作は、[**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)を含む任意のタイプの要素に実装されています。

完全なソースコードサンプル：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
mathParagraph->Add(mathBlock);

pres->Save(u"math.pptx", SaveFormat::Pptx);
``` 

## **数学要素の種類**
数学的表現は、数学要素の配列から形成されます。数学要素の配列は数学ブロックとして表され、数学要素の引数は木のようなネスティングを形成します。

数学ブロックを構築するために使用できる数学要素の種類はたくさんあります。これらの要素のそれぞれは、他の要素に含めることができます（集約）。つまり、要素は実際には他の要素のコンテナとなり、木のような構造を形成します。最も単純なタイプの要素は、他の数学テキスト要素を含まないものです。

各タイプの数学要素は、[**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)インターフェイスを実装しており、異なる種類の数学要素に対して共通の数学操作セットを使用できるようにしています。
### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)クラスは数学テキストを表し、すべての数学構造の基本要素です。数学テキストは、オペランドや演算子、変数、その他の任意の線形テキストを表すことができます。

例：𝑎=𝑏+𝑐
### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction)クラスは分数オブジェクトを指定し、分子と分母が分数バーで区切られています。分数バーは分数プロパティに応じて水平または斜めになります。分数オブジェクトは、1つの要素を他の上に配置するスタック関数を表すためにも使用されます。

例：

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical)クラスは、基数とオプションの次数からなる根号関数（数学的根）を指定します。

例：

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)クラスは引数の関数を指定します。メソッドが含まれています：[get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3) - 関数名および[get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) - 関数引数。

例：

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator)クラスは、総和や積分といったN-進数学オブジェクトを指定します。これはオペレーター、基数（またはオペランド）、およびオプションの上限と下限から構成されます。N-進演算子の例には、総和、和集合、交差、積分があります。

このクラスには加算、減算などの単純な演算子は含まれていません。それらは単一のテキスト要素 - [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)として表されます。

例：

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit)クラスは上限または下限を作成します。それは、ベースライン上のテキストと、そのすぐ上または下にある小さいサイズのテキストで構成される限界オブジェクトを指定します。この要素は「lim」という単語を含まず、テキストを式の上または下に配置できるようにします。したがって、式 

![todo:image_alt_text](powerpoint-math-equations_8.png)

は以下のように[**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)および[**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit)要素の組み合わせを使用して作成されます：

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

以下のクラスは下付きインデックスまたは上付きインデックスを指定します。引数の左または右側に同時に下付き文字と上付き文字を設定できますが、単一の下付き文字または上付き文字は右側のみにサポートされています。[MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)は、数の数学的次数を設定するためにも使用できます。

例： 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix)クラスは、子要素が1つまたは複数の行と列に配置されたマトリックスオブジェクトを指定します。行列には組み込みのデリミタがないことに注意が必要です。行列を括弧に置くには、デリミタオブジェクト - [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter)を使用する必要があります。ヌル引数は行列の隙間を作成するために使用できます。

例： 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array)クラスは、方程式や任意の数学オブジェクトの垂直配列を指定します。

例： 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **数学要素の書式設定**
- [**MathBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box)クラス：数学要素の周りに矩形または他の境界を描画します。
  
  例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box)クラス：数学的要素の論理的ボックス化（パッケージ化）を指定します。たとえば、ボックス化したオブジェクトは、整列ポイントの有無にかかわらず演算子エミュレータとして機能したり、行のブレークポイントとして機能したり、一緒にグループ化して行のブレークを許可しないことができます。たとえば、「==」オペレーターは行のブレークを防ぐためにボックス化する必要があります。
- [**MathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter)クラス：開くおよび閉じる文字（括弧、波括弧、ブラケット、垂直バーなど）で構成される区切りオブジェクト、およびその内部に1つ以上の数学要素を指定する、指定された文字で区切られます。例：（𝑥2）； [𝑥2|𝑦2]。
  
  例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent)クラス：ベースと結合ダイアクリティカルマークから構成されるアクセント関数を指定します。

  例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar)クラス：ベース引数と上バーまたは下バーから構成されるバー関数を指定します。
  
  例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character)クラス：通常、要素間の関係を強調するために、式の上または下にグルーピングシンボルを指定します。
  
  例：![todo:image_alt_text](powerpoint-math-equations_15.png)


## **数学的操作**
各数学要素および数学的表現（[**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)経由）は、[**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)インターフェイスを実装しています。これは、既存の構造に対して操作を使用し、より複雑な数学表現を形成することを可能にします。すべての操作には2つのパラメータセットがあります：[**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)または文字列を引数として使用します。[**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)クラスのインスタンスは、文字列引数が使用されるときに暗黙的に指定された文字列から作成されます。Aspose.Slidesで利用可能な数学操作は以下の通りです。
### **Join メソッド**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

数学要素を結合し、数学ブロックを形成します。たとえば：

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 

### **Divide メソッド**
- [Divide(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae3175481538f5a0a2d6bd3606e7ecfb6)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae1b231db04fff125e5e8c96fd18e608a)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2a1029bda3a198390da3f1b6cb0f677d)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4a19fcb4fcc3a09327793f0ac823e19a)

指定のタイプでこの分子と指定の分母の分数を作成します。たとえば：

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 
### **Enclose メソッド**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

要素を指定された文字（括弧や他のキャラクター）で囲みます。

``` cpp
/// <summary>
/// 数学要素を括弧で囲みます
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// この要素を指定された文字で囲まれます
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

たとえば：

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Function メソッド**
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

このインスタンスを関数名として使用し、引数の関数を取得します。

``` cpp
/// <summary>
/// このインスタンスを関数名とし、引数の関数を取得します
/// </summary>
/// <param name="functionArgument">関数の引数</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

たとえば：

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 
### **AsArgumentOfFunction メソッド**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

指定された関数を取得し、現在のインスタンスを引数として使用します。以下のことができます：

- 文字列を関数名として指定することができます。たとえば「cos」。
- 列挙体[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415)または[**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b)の事前定義された値の1つを選択することができます。たとえば **MathFunctionsOfOneArgument.ArcSin.**
- [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)のインスタンスを選択することができます。

たとえば：

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft メソッド**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a1610efd629e0fef10f46397c3c671829)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a747a756f05c3a5ebaf96ae4b9853d300)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a3e3613e5c07f1b9df5f59c533d5430d0)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aed4ce1bd63e756b9585214ad832d174a)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acedc512b9952ca9ae6750ff75fd10b1d)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aba884260e8d8b434cbe666444bcb7cdc)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad3a3850ed28e26b627a46a6e7198228f)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afb8cea063303a9e81b6d7f50d9ce8c7c)

下付き文字と上付き文字を設定します。引数の左または右側に同時に下付き文字と上付き文字を設定できますが、単一の下付き文字または上付き文字は右側のみでサポートされています。**上付き文字**は数の数学的次数を設定するためにも使用できます。

例：

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 
### **Radical メソッド**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

指定された引数から指定された次数の数学的根を指定します。

例：

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 
### **SetUpperLimit と SetLowerLimit メソッド**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

上限または下限を取得します。ここで、上限と下限は単に引数の基準に対する位置を示しています。

次の式を考えてみましょう： 

![todo:image_alt_text](powerpoint-math-equations_8.png)

このような式は、[MathFunction](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)と[MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit)のクラスの組み合わせ、および[IMathElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)の操作を使用して次のように作成できます：

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 
### **Nary と Integral メソッド**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab850b5a7244cf71b89810555e5f55e26)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a667e2c89d5d77aacc51599177f543f75)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad2a93a7e43548d38e23552f480c85c01)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afed3647d15dc6bd636f5bfa111dfd726)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a27d1ee66c5a31ed7ac1b2d9cc1f6af7d)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aef3e63bdeb956c428b7b1ea385bcdad5)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a16a7f1cd3aa5d09543dfbf0b18bb024e)

**Nary**および**Integral**メソッドは、[**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator)型で表されるN-進オペレーターを作成して返します。Naryメソッドでは、[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167)列挙が演算子の型（総和、和集合など）を指定しますが、積分は含みません。Integralメソッドには、積分型の列挙[**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607)が含まれています。

例：

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 
### **ToMathArray メソッド**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1)は、要素を垂直配列に配置します。この操作が**MathBlock**インスタンスに対して呼び出されると、すべての子要素が返された配列に配置されます。

例：

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 
### **書式設定操作：Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**Accent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acd0f38691b52fb83294c0da9f3690483)メソッドは、エレメントの上にキャラクターを設定します。
- [**Overbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5d4780f9be6d0709465f50f5d830d4e3)および[**Underbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a97d93a1fc79a31f4ffd20d233e06c5a5)メソッドは、上または下にバーを設定します。
- [**Group**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4662589060e34723455b8164ce556546)メソッドは、底の波括弧などのグルーピングキャラクターを使用してグループに配置します。
- [**ToBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aa32771655d8931aa8e0b5d3c1c7e160b)メソッドは、ボーダーボックスに配置します。
- [**ToBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac18b6b70362303cb307862a9aaa7dce2)メソッドは、視覚的でないボックス（論理グループ化）に配置します。

例：

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
```