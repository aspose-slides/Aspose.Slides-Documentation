---
title: C++でPowerPointプレゼンテーションに数式を追加
linktitle: PowerPoint数式
type: docs
weight: 80
url: /ja/cpp/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数式
- 数式テキスト
- 数式を追加
- 数学記号を追加
- 数式を追加
- 数式テキストを追加
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint PPT および PPTX に数式を挿入および編集できます。OMML をサポートし、書式設定コントロールと明確な C++ コードサンプルを提供します。"
---

## **概要**
PowerPoint では、数式や方程式を書いてプレゼンテーションに表示することができます。PowerPoint ではさまざまな数学記号が用意されており、テキストや数式に追加できます。そのために PowerPoint の数式コンストラクタが使用され、次のような複雑な数式を作成できます。

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

PowerPoint は多数の数学記号をサポートしていますが、複雑な数式を作成すると見栄えが良くないことがあります。頻繁に数学プレゼンテーションを作成するユーザーは、見栄えの良い数式を作るためにサードパーティ製品を利用します。

[**Aspose.Slide API**](https://products.aspose.com/slides/cpp/) を使用すれば、C++ で PowerPoint の数式をプログラムから操作できます。新しい数式を作成したり、既存の数式を編集したりできます。数式構造を画像にエクスポートする機能も一部サポートされています。

## **数式の作成方法**
数学要素は入れ子構造を持つ任意の数学構成を構築するために使用されます。線形に並んだ数学要素のコレクションは、[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) クラスで表される数学ブロックとなります。[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) クラスは、分離された数式、式、または方程式を表します。[**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) は数学テキストを保持する数学要素で、[**Portion**](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) と混同しないでください。[**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) は複数の MathBlock を操作できます。これらのクラスが Aspose.Slides API を介して PowerPoint の数式を操作するためのキーになります。

以下に、Aspose.Slides API を使用して次の数式を作成する方法を示します。

![todo:image_alt_text](powerpoint-math-equations_3.png)

スライドに数式を追加するには、まず数式テキストを保持するシェイプを追加します。

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

作成後、シェイプにはデフォルトで 1 つの段落が含まれ、そこに数学要素が 1 つ入ります。[**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) クラスは、内部に数学テキストを保持する要素です。[**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) 内の数学コンテンツにアクセスするには、[**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) 変数を取得します。

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) クラスは、数学ブロック（[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)）の読み取り、追加、編集、削除を行えます。たとえば、分数を作成してプレゼンテーションに配置します。

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

各数学要素は、[**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) インターフェイスを実装するクラスで表されます。このインターフェイスは、数式を簡単に作成するための多数のメソッドを提供します。たとえば、ピタゴラスの定理は次のように記述できます。

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

[**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) の操作は、すべての要素タイプ（[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) を含む）で実装されています。

完全なサンプルコード:

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
数学式は数学要素のシーケンスから構成されます。要素のシーケンスは数学ブロックで表され、要素の引数はツリー構造の入れ子になります。

多数の数学要素タイプがあり、各要素は他の要素に含めることができます。つまり、要素は他の要素のコンテナとなり、ツリー構造を形成します。最も単純な要素は他の要素を含みません。

すべての数学要素は、[**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) インターフェイスを実装しており、共通の操作セットを使用できます。

### **MathematicalText クラス**
[**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) クラスは、すべての数学構成の基礎となる数学テキストを表します。オペランド、演算子、変数、その他の線形テキストを表現できます。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**
[**MathFraction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfraction/) クラスは、分子と分母で構成される分数オブジェクトを表します。分数バーは水平または対角線になることがあります。また、分数バーなしで要素を積み重ねるスタック関数としても使用されます。

例:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
[**MathRadical**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathradical/) クラスは、基底とオプションの次数からなる根号関数を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
[**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) クラスは、引数を持つ関数を表します。メソッド: [get_Name()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_name/)（関数名） と [get_Base()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_base/)（関数引数）。

例:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
[**MathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperator/) クラスは、総和や積分などの N 進演算子を表します。演算子、基底（またはオペランド）、オプションの上限・下限から構成されます。加算や減算などの単純演算子は含まれません。単純演算子は [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) で表されます。

例:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
[**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) クラスは、上限または下限を作成します。ベースライン上のテキストと、上下に小さく表示されるテキストから構成されます。単語 “lim” は含まれず、テキストを上部または下部に配置できます。

例:

![todo:image_alt_text](powerpoint-math-equations_8.png)

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

これらのクラスは下付きまたは上付きインデックスを指定します。左側または右側に同時に下付き・上付きインデックスを設定できますが、右側単独の下付き・上付きインデックスのみがサポートされています。[MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/) は数の次数を設定することもできます。

例:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
[**MathMatrix**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) クラスは、子要素を行と列で配置した行列オブジェクトを表します。行列自体にはデリミタがありません。括弧で囲むには [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/) を使用します。null 引数で行列の空白を作れます。

例:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
[**MathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/matharray/) クラスは、縦方向の式や任意の数学オブジェクトの配列を表します。

例:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素のフォーマット**
- [**MathBorderBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathborderbox/) クラス: [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) の周囲に矩形やその他の枠線を描画します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbox/) クラス: 数学要素の論理的なボックス化（パッケージ化）を指定します。たとえば、演算子エミュレータとして、改行を防止したり、行ブレークを許可しないようにグループ化したりできます。

- [**MathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathdelimiter/) クラス: 開始文字と終了文字（丸括弧、波かっこ、角括弧、縦棒等）で構成され、内部に 1 つ以上の数学要素を含むデリミタオブジェクトを指定します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathaccent/) クラス: 基底と結合アクセント記号からなるアクセント関数を指定します。  
  例: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbar/) クラス: 基底引数に対して上バーまたは下バーを付加します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathgroupingcharacter/) クラス: 式の上または下に配置するグルーピング記号を指定し、要素間の関係を強調します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学演算**
各数学要素と数式（[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)）は、[**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) インターフェイスを実装しています。既存構造に対して操作を行い、より複雑な数式を構成できます。すべての操作は、[**IMathElement**] または文字列を引数に取ります。文字列引数が使用される場合、[**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) のインスタンスが暗黙的に生成されます。利用可能な数式操作は以下の通りです。

### **Join メソッド**
- [Join(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemstring-method)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemsharedptrimathelement-method)

数学要素を結合して数学ブロックを作ります。例:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
auto element2 = System::MakeObject<MathematicalText>(u"y");
auto block = element1->Join(element2);
``` 

### **Divide メソッド**
- [Divide(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-method)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-method)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-mathfractiontypes-method)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-mathfractiontypes-method)

指定した分子・分母で分数を作成します。例:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Enclose メソッド**
- [Enclose()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclose-method)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclosechar16_t-char16_t-method)

要素を指定文字（括弧など）で囲みます。

``` cpp
/// <summary>
– Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
– Encloses this element in specified characters such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

使用例:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Function メソッド**
- [Function(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemstring-method)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemsharedptrimathelement-method)

現在のオブジェクトを関数名として、引数付き関数を作ります。

``` cpp
/// <summary>
– Takes a function of an argument using this instance as the function name
/// </summary>
virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;
virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

使用例:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 

### **AsArgumentOfFunction メソッド**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemstring-method)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsofoneargument-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemstring-method)

現在のインスタンスを引数として指定関数を作ります。  
- 文字列で関数名を指定（例: “cos”)  
- 列挙体 [MathFunctionsOfOneArgument] または [MathFunctionsOfTwoArguments] の定数を使用（例: MathFunctionsOfOneArgument.ArcSin）  
- [IMathElement] インスタンスを使用

使用例:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);
auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");
auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);
auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft メソッド**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemstring-method)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemsharedptrimathelement-method)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemstring-method)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemsharedptrimathelement-systemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemsharedptrimathelement-systemsharedptrimathelement-method)

下付き・上付きインデックスを設定します。左側または右側に同時に設定可能ですが、右側の単独インデックスのみがサポートされています。**Superscript** は数の次数としても使用できます。

例:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Radical メソッド**
- [Radical(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemstring-method)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemsharedptrimathelement-method)

指定された次数の根号を作成します。

例:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **SetUpperLimit と SetLowerLimit メソッド**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemstring-method)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemsharedptrimathelement-method)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemstring-method)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemsharedptrimathelement-method)

上限または下限を設定します。上限・下限は基底に対する位置を示します。

例として次の式を考えます。

![todo:image_alt_text](powerpoint-math-equations_8.png)

この式は [MathFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) と [MathLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) の組み合わせで作成できます。

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **Nary と Integral メソッド**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-mathlimitlocations-method)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-mathlimitlocations-method)

**Nary** と **Integral** は共に [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathnaryoperator/) 型の N 進演算子を返します。**Nary** は総和・積分以外の N 進演算子（総和、合併、交差など）を作成し、**Integral** は積分専用です。

例:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **ToMathArray メソッド**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/) は要素を縦配列に変換します。**MathBlock** に対して呼び出すと、すべての子要素が配列に格納されます。

例:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **フォーマット操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **Accent** メソッドは要素の上にアクセント記号を付加します。
- **Overbar** と **Underbar** メソッドは要素の上部または下部にバーを付けます。
- **Group** メソッドは下付き括弧やその他のグルーピング文字で要素をまとめます。
- **ToBorderBox** メソッドは要素を枠付きボックスにします。
- **ToBox** メソッドは視覚的でない論理ボックスにします。

例:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();
auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();
auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **FAQ**

**PowerPoint のスライドに数式を追加するにはどうすればよいですか？**

数式シェイプオブジェクトを作成します。作成時に自動的に数学要素が含まれます。次に [MathParagraph] から [MathPortion] を取得し、[MathBlock] オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい。Aspose.Slides は MathBlock を入れ子にでき、[IMathElement] インターフェイスを通じて Join、Divide、Enclose などの操作で複雑な数式を構築できます。

**既存の数式を更新または修正するには？**

[MathParagraph] から既存の MathBlock を取得し、Join、Divide、Enclose などのメソッドで要素を変更します。編集後にプレゼンテーションを保存すれば変更が反映されます。