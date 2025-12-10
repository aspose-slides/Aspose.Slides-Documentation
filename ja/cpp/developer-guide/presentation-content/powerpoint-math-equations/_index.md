---
title: PowerPointプレゼンテーションにC++で数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/cpp/powerpoint-math-equations/
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
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides で PowerPoint PPT および PPTX の数式を挿入・編集でき、OMML、書式設定コントロールをサポートし、明確な C++ コードサンプルを提供します。"
---

## **概要**
PowerPoint では、数式や式を書いてプレゼンテーションに表示することができます。そのために、PowerPoint ではさまざまな数学記号が用意されており、テキストや式に追加できます。そのために、PowerPoint の数式コンストラクタが使用され、次のような複雑な数式を作成できます:

- 分数
- 根号
- 関数
- 極限および対数関数
- N元演算
- 行列
- 大演算子
- 正弦・余弦関数

PowerPoint で数式を追加するには、*挿入 -> 数式* メニューを使用します:

![todo:image_alt_text](powerpoint-math-equations_1.png)

これにより、XML 形式の数式テキストが作成され、PowerPoint で次のように表示されます:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint は多数の数学記号をサポートしていますが、複雑な数式を作成すると見栄えが良く専門的な結果にならないことがよくあります。頻繁に数学プレゼンテーションを作成するユーザーは、見栄えの良い数式を作るためにサードパーティ製品を利用しています。

[**Aspose.Slide API**](https://products.aspose.com/slides/cpp/) を使用すると、C++ で PowerPoint プレゼンテーション内の数式をプログラムで操作できます。新しい数式を作成したり、既存のものを編集したりできます。数式構造を画像としてエクスポートする機能も一部サポートされています。

## **数式の作成方法**
数学要素は、入れ子構造を伴う任意の数式構築に使用されます。数学要素の一次的なコレクションは、[**MathBlock** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)クラスで表される数式ブロックを形成します。[**MathBlock**] クラスは本質的に個別の数式・式・方程式です。[**MathPortion**] は数式テキストを保持するための数学的部分であり、[**Portion**] と混同しないでください。[**MathParagraph**] は数式ブロックのセットを操作できます。上記のクラスは、Aspose.Slides API を通じて PowerPoint の数式を操作する鍵となります。

以下の数式を Aspose.Slides API で作成する方法を見てみましょう:

![todo:image_alt_text](powerpoint-math-equations_3.png)

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

作成後、シェイプにはデフォルトで数式テキストを含む段落が1つ含まれます。[**MathPortion**] クラスは内部に数式テキストを保持する部分です。[**MathPortion**] 内の数式コンテンツにアクセスするには、[**MathParagraph**] 変数を参照してください:

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

[**MathParagraph**] クラスは、数学要素の組み合わせで構成される数式ブロック（[**MathBlock**]）を読み取り、追加、編集、削除できます。たとえば、分数を作成してプレゼンテーションに配置するには次のようにします:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

各数学要素は、[**IMathElement**] インターフェイスを実装するクラスで表されます。このインターフェイスは、数式を簡単に作成するための多数のメソッドを提供します。1 行のコードだけでかなり複雑な数式を作成できます。例えば、ピタゴラスの定理は次のようになります:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

[**IMathElement**] インターフェイスの操作は、[**MathBlock**] を含むすべての要素タイプで実装されています。

完全なサンプルコードは以下のとおりです:

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

## **数式要素の種類**
数式は数学要素のシーケンスから構成されます。数学要素のシーケンスは数式ブロックで表され、数学要素の引数はツリー構造の入れ子になります。

多数の数学要素タイプがあります。これらの要素は他の要素に含める（集約）ことができます。つまり、要素は他の要素のコンテナであり、ツリー構造を形成します。数学テキストの他要素を含まない最もシンプルな要素タイプです。

各数学要素タイプは [**IMathElement**] インターフェイスを実装し、さまざまな要素タイプに共通の数学操作セットを使用できます。

### **MathematicalText クラス**
[**MathematicalText**] クラスは数学テキストを表し、すべての数式構築の基礎要素です。数学テキストはオペランドや演算子、変数、その他の線形テキストを表すことがあります。

例: 𝑎=𝑏+𝑐

### **MathFraction クラス**
[**MathFraction**] クラスは、分子と分母が分数線で区切られた分数オブジェクトを指定します。分数線はプロパティに応じて水平または斜めになることがあります。また、分数オブジェクトはスタック関数（要素を上下に配置し、分数線なし）を表すためにも使用されます。

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical クラス**
[**MathRadical**] クラスは、基底とオプションの次数からなる根号（数学的根）関数を指定します。

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction クラス**
[**MathFunction**] クラスは引数を取る関数を指定します。メソッドとして [get_Name() ]（関数名） と [get_Base()]（関数引数） を持ちます。

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator クラス**
[**MathNaryOperator**] クラスは、総和や積分などの N 元演算子を指定します。演算子、基底（またはオペランド）およびオプションの上限・下限から構成されます。N 元演算子の例として総和、和集合、積集合、積分があります。

このクラスは加算、減算などの単純な演算子は含みません。それらは単一のテキスト要素である [MathematicalText] で表されます。

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit クラス**
[**MathLimit**] クラスは上限または下限を作成します。ベースライン上のテキストと、そのすぐ上または下に小さく表示されるテキストからなるリミットオブジェクトを指定します。この要素は「lim」という語は含まず、式の上部または下部にテキストを配置できます。したがって、式は次のように [**MathFunction**] と [**MathLimit**] 要素の組み合わせで作成されます:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement クラス**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

以下のクラスは下添字または上添字を指定します。引数の左側または右側で同時に下添字と上添字を設定できますが、単一の下添字または上添字は右側のみでサポートされます。[MathSubscriptElement] は数値の次数を設定するためにも使用できます。

例:  

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix クラス**
[**MathMatrix**] クラスは、子要素が1つ以上の行と列に配置された行列オブジェクトを指定します。行列には組み込みの区切り記号がないことに注意してください。行列を括弧で囲むには、区切りオブジェクト [**IMathDelimiter**] を使用します。null 引数を使用して行列内に空白を作ることができます。

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray クラス**
[**MathArray**] クラスは、式や任意の数学オブジェクトの縦方向の配列を指定します。

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学要素の書式設定**
- [**MathBorderBox**] クラス: [**IMathElement**] の周囲に矩形またはその他の枠を描画します。  
  例: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**] クラス: 数学要素の論理的なボックス化（パッケージ化）を指定します。例えば、ボックス化されたオブジェクトは整列点の有無にかかわらず演算子エミュレータとして機能したり、改行点として使用したり、内部で改行を許可しないようにグループ化したりできます。例として、"==" 演算子は改行を防ぐためにボックス化すべきです。

- [**MathDelimiter**] クラス: 開始文字と終了文字（括弧、波括弧、角括弧、縦棒など）からなる区切りオブジェクトを指定し、内部に1つ以上の数学要素を含み、指定文字で区切ります。例: (𝑥2); [𝑥2|𝑦2]  
  ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**] クラス: 基底と結合アクセント記号からなるアクセント関数を指定します。  
  例: 𝑎́.

- [**MathBar**] クラス: 基底引数と上バーまたは下バーからなるバー関数を指定します。  
  ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**] クラス: 式の上または下に配置されるグルーピング記号を指定し、通常は要素間の関係を強調します。  
  ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学演算**
[**MathBlock**] を介した各数式要素・数式は [**IMathElement**] インターフェイスを実装します。既存の構造に対して操作を行い、より複雑な数式を構成できます。すべての操作は 2 つのパラメータ形態を持ち、[**IMathElement**] または文字列を引数に取ります。文字列引数が使用される場合、[**MathematicalText**] クラスのインスタンスが暗黙的に作成されます。Aspose.Slides で利用可能な数式操作は以下のとおりです。

### **Join メソッド**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

数学要素を結合して数式ブロックを形成します。例:

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

指定されたタイプの分数を、分子と分母から作成します。例:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Enclose メソッド**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

要素を括弧や別の文字で囲みます。

``` cpp
/// <summary>
/// Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Encloses this element in specified characters such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

例:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Function メソッド**
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

現在のオブジェクト名を関数名として、引数の関数を取得します。

``` cpp
/// <summary>
/// Takes a function of an argument using this instance as the function name
/// </summary>
/// <param name="functionArgument">An argument of the function</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

例:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 

### **AsArgumentOfFunction メソッド**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

現在のインスタンスを引数として、指定された関数を取得します。以下が可能です:
- 関数名を文字列で指定（例: “cos”）。
- 列挙型 [**MathFunctionsOfOneArgument**] または [**MathFunctionsOfTwoArguments**] の事前定義値から選択（例: **MathFunctionsOfOneArgument.ArcSin**）。
- [**IMathElement**] のインスタンスを選択。

例:

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

下添字と上添字を設定します。引数の左側または右側で同時に下添字と上添字を設定できますが、単一の下添字または上添字は右側のみでサポートされます。**Superscript** は数値の次数を設定するためにも使用できます。

例:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Radical メソッド**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

指定された引数から指定された次数の数学的根を設定します。

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **SetUpperLimit および SetLowerLimit メソッド**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

上限または下限を設定します。ここで、上限・下限は単に引数が基底に対して上か下かの位置を示します。

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **Nary および Integral メソッド**
**Nary** と **Integral** の両メソッドは、[**IMathNaryOperator**] タイプで表される N 元演算子を作成して返します。Nary メソッドでは、[**MathNaryOperatorTypes**] 列挙型で演算子のタイプ（総和、和集合など）を指定し、積分は含まれません。Integral メソッドでは、積分専用の操作であり、[**MathIntegralTypes**] 列挙型で積分タイプを指定します。

例:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **ToMathArray メソッド**
[**ToMathArray**] は要素を縦方向の配列に配置します。この操作が **MathBlock** インスタンスに対して呼び出されると、すべての子要素が返される配列に配置されます。

例:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **書式設定操作: Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **Accent** メソッドはアクセント記号（要素の上部に付く文字）を設定します。
- **Overbar** および **Underbar** メソッドは上部または下部にバーを設定します。
- **Group** メソッドは、下カール括弧などのグルーピング文字を使用して要素をグループ化します。
- **ToBorderBox** メソッドは要素を枠付きボックスに配置します。
- **ToBox** メソッドは非表示ボックス（論理的なグルーピング）に配置します。

例:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **FAQ**

**PowerPoint スライドに数式を追加するにはどうすればよいですか？**

数式を追加するには、数式シェイプオブジェクトを作成します。このシェイプはデフォルトで数式部分を含みます。次に、[MathPortion] から [MathParagraph] を取得し、そこに [MathBlock] オブジェクトを追加します。

**複雑な入れ子構造の数式を作成できますか？**

はい、Aspose.Slides は MathBlock を入れ子にすることで複雑な数式を作成できます。各数学要素は [IMathElement] インターフェイスを実装しており、Join、Divide、Enclose などの操作で要素を組み合わせてより複雑な構造を作成できます。

**既存の数式を更新または変更するにはどうすればよいですか？**

数式を更新するには、[MathParagraph] を介して既存の MathBlock にアクセスします。その後、Join、Divide、Enclose などのメソッドを使用して数式の個々の要素を変更できます。編集後、プレゼンテーションを保存して変更を適用します。