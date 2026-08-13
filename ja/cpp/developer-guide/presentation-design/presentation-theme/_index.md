---
title: C++ でプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/cpp/presentation-theme/
keywords:
  - PowerPoint テーマ
  - プレゼンテーションテーマ
  - スライドテーマ
  - テーマの設定
  - テーマの変更
  - テーマの管理
  - テーマカラー
  - 追加パレット
  - テーマフォント
  - テーマスタイル
  - テーマ効果
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - C++
  - Aspose.Slides
description: "Aspose.Slides for C++ でプレゼンテーションのマスターテーマを管理し、一貫したブランディングで PowerPoint ファイルを作成、カスタマイズ、変換します。"
---
## **はじめに**

プレゼンテーションのテーマはデザイン要素のプロパティを定義します。プレゼンテーションのテーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選んでいることになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/cpp/powerpoint-fonts/)、[背景スタイル](/slides/ja/cpp/presentation-background/)、および効果で構成されます。

![theme-constituents](theme-constituents.png)

## **テーマカラーの変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更します。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) 列挙体で値を提供します。

この C++ コードは、テーマのアクセントカラーを変更する方法を示しています:
```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

この方法で、結果として得られる色の実際の値を決定できます:
```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (カラー [A=255, R=128, G=100, B=162])
```

色変更操作をさらに示すために、別の要素を作成し、アクセントカラー（最初の操作から）を割り当てます。その後、テーマ内の色を変更します:
```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

メインテーマカラー(1)に輝度変換を適用すると、追加パレット(2)から色が生成されます。その後、これらのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1**- メインテーマカラー  
**2**- 追加パレットからのカラー  

この C++ コードは、追加パレットのカラーをメインテーマカラーから取得し、シェイプで使用する操作を示しています:
```c++
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// アクセント 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// アクセント 4、明るさ 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// アクセント 4、明るさ 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// アクセント 4、明るさ 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// アクセント 4、暗さ 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// アクセント 4、暗さ 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor` を `IColorScheme` のカラーにマッピング**

[SchemeColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/schemecolor/) を使用すると、次のテーマカラー値が含まれていることに気付くかもしれません:
`Background1`, `Background2`, `Text1`, and `Text2`.

しかし、`Presentation::get_MasterTheme()::get_ColorScheme()` は [IColorScheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/icolorscheme/) を返し、対応するカラーを次のように公開します:
`Dark1`, `Dark2`, `Light1`, and `Light2`.

この違いは名前だけです。これらの値は同じテーマカラーのスロットを指しており、マッピングは固定されています:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` と `Dark`/`Light` の間に動的な変換はありません。これらは同じテーマカラーの別名にすぎません。

この命名の違いは Microsoft Office の用語から来ています。古い Office バージョンでは `Dark 1`、`Light 1`、`Dark 2`、`Light 2` が使用されていましたが、新しい UI バージョンでは同じスロットが `Text 1`、`Background 1`、`Text 2`、`Background 2` と表示されます。

## **テーマフォントの変更**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides はこれらの特別な識別子（PowerPoint で使用されるものに似ています）を使用します:

* **+mn-lt** - 本文フォント Latin（マイナー Latin フォント）
* **+mj-lt** - 見出しフォント Latin（メジャー Latin フォント）
* **+mn-ea** - 本文フォント 東アジア（マイナー 東アジア フォント）
* **+mj-ea** - 本文フォント 東アジア（メジャー 東アジア フォント）

この C++ コードは、Latin フォントをテーマ要素に割り当てる方法を示しています:
```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

この C++ コードは、プレゼンテーションのテーマフォントを変更する方法を示しています:
```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

すべてのテキストボックスのフォントが更新されます。

{{% alert color="info" title="TIP" %}} 
[PowerPoint フォント](/slides/ja/cpp/powerpoint-fonts/) を見ると便利です。
{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 の事前定義された背景を提供しますが、典型的なプレゼンテーションに保存されるのはそのうちの 3 つだけです。

![todo:image_alt_text](presentation-design_8.png)

例えば、PowerPoint アプリでプレゼンテーションを保存した後、次の C++ コードを実行してプレゼンテーション内の事前定義された背景の数を確認できます:
```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) プロパティを [FormatScheme](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.theme.i_format_scheme/) クラスから使用すると、PowerPoint のテーマで背景スタイルを追加またはアクセスできます。 
{{% /alert %}}

この C++ コードは、プレゼンテーションの背景を設定する方法を示しています:
```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**インデックスガイド**: 0 は塗りなしに使用されます。インデックスは 1 から始まります。

{{% alert color="info" title="TIP" %}} 
[PowerPoint 背景](/slides/ja/cpp/presentation-background/) を見ると便利です。
{{% /alert %}}

## **テーマ効果の変更**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を含みます。その配列は 3 つの効果（サブトル、モデレート、インテンス）に結合されます。例えば、特定のシェイプに効果を適用した結果は以下の通りです:

![todo:image_alt_text](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563)、[LineStyles](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd)、[EffectStyles](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58) の 3 つのプロパティを [FormatScheme](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.theme.i_format_scheme/) クラスから使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

この C++ コードは、要素の一部を変更してテーマ効果を変更する方法を示しています:
```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

結果としての塗りの色、塗りタイプ、影効果などの変更は次の通りです:
![todo:image_alt_text](presentation-design_11.png)

## **よくある質問**

### マスターを変更せずに単一スライドにテーマを適用できますか？

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、マスターテーマをそのままに保ちながら、対象スライドにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/slidethememanager/) 経由）。

### テーマをあるプレゼンテーションから別のプレゼンテーションへ安全に持ち込む最適な方法は何ですか？

[Clone slides](/slides/ja/cpp/clone-slides/) とそのマスターを対象のプレゼンテーションにコピーすると、元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫します。

### 継承やオーバーライド後の「実際の」値を確認するにはどうすればよいですか？

API の ["effective" views](/slides/ja/cpp/shape-effective-properties/)（テーマ/カラー/フォント/効果）を使用してください。これらはマスターとローカルオーバーライドを適用した後の解決済みの最終プロパティを返します。