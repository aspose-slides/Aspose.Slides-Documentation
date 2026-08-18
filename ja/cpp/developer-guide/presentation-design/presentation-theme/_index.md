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
- テーマを設定する
- テーマを変更する
- テーマを管理する
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマエフェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でマスタープレゼンテーションテーマを使用し、一貫したブランディングで PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
## **イントロダクション**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、エフェクトの調整されたセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーション レベルのテーマは [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_mastertheme/) で取得できます。プレゼンテーションには、下位レベルでテーマのオーバーライドを含めることもできます。マスターは [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) でプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) を使用できます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ → マスター オーバーライド → レイアウト オーバーライド → スライド オーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ ワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景とエフェクト スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/) オブジェクトは、テーマの [get_ColorScheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)、[get_FontScheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)、および [get_FormatScheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) メソッドを公開します。変更する前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合、スタイル エントリの数や内容が変わる可能性があるため、特に有用です。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、エフェクト スタイルの数をレポートします。

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマ ワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。テーマの [IColorScheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/icolorscheme/) の該当エントリを変更すると、まだそのテーマ色を参照しているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマ色の更新によって変更されません。

次のエンドツーエンドの例では、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

矩形は `Accent4` にリンクされたままであるため、テーマが変更されると表示色が赤に変わります。シェイプ上でスキーム色を直接の色に置き換えると、以降の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint は、テーマカラーに対して色変換を適用することで、明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/colortransformoperation/) を通じて提供します。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – メインテーマ色。

**2** – メインテーマ色から生成された明るい・暗いバリエーション。

次の例では、`Accent4` を基にした 6 つの矩形を作成し、うち 5 つに輝度変換を適用し、結果を保存します。

```cpp
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
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

これらのバリエーションはテーマ色に基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。対応は固定されています。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントの変更**

テーマ フォント スキーマは、見出し用のメジャーフォント セットと本文用のマイナーフォント セットを含みます。[FontScheme::get_Major()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/fontscheme/get_major/) と [FontScheme::get_Minor()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/fontscheme/get_minor/) メソッドがそれらのセットを公開します。

PowerPoint 互換のテーマ フォント 識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント Latin（マイナー Latin フォント）
* `+mj-lt` – 見出しフォント Latin（メジャー Latin フォント）
* `+mn-ea` – 本文フォント East Asian（マイナー East Asian フォント）
* `+mj-ea` – 見出しフォント East Asian（メジャー East Asian フォント）

次の例では、メジャー Latin テーマフォントを使用した見出しと、マイナー Latin テーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的にフォント名が指定されているテキストは、テーマ フォント スキーマが変更されても自動的には切り替わりません。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/cpp/powerpoint-fonts/) を参照してください。
{{% /alert %}}

## **テーマのコピーまたは適用**

一般的なワークフローは 2 つあり、解決すべき課題が異なります。

### **スライドを移動するときに元のテーマを保持する**

スライドを別のプレゼンテーションへ移動し、元のデザインを保持したい場合は、[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/addclone/) でソース マスターをターゲット プレゼンテーションにクローンし、続いて [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) でクローンしたマスターとスライドをクローンします。これにより、マスター、レイアウト、および関連テーマが一緒に持ち込まれます。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

この方法は、ソース スライドが宛先でも同一に見える必要がある場合の推奨ワークフローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わってしまうことがあります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターとレイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)、[OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

この操作により、他のスライドが継承するテーマは変わらず、対象スライドだけのテーマが変更されます。ローカル オーバーライドを削除して継承値に戻すには、[OverrideTheme::Clear()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/overridetheme/clear/) を呼び出します。

### **レイアウトにテーマ オーバーライドを適用する**

レイアウト レベルのオーバーライドは、そのレイアウトを使用するスライド全体に適用されます（個別スライドが独自のオーバーライドを持たない限り）。同じ初期化メソッドは、レイアウトの [IOverrideThemeManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ioverridethememanager/) を通じても使用できます。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

多数のレイアウトとスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーション レベルのテーマを使用し、特定のレイアウト ファミリだけ異なるスタイリングが必要な場合はレイアウト オーバーライドを、真の例外に対してのみスライド オーバーライドを使用してください。スライド レベルのオーバーライドが過剰になると、後の全体テーマ変更の予測が難しくなります。

## **テーマの背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) に格納されています。PowerPoint の UI では、実際にコレクションに格納されている塗りつぶし定義の数以上の背景オプションが提示されることがあります。これは UI がテーマ塗りつぶしとテーマ色、その他のスタイル参照を組み合わせられるためです。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、格納されているコレクションと現在の [Background::get_StyleIndex()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/get_styleindex/) を確認してください。`StyleIndex` は「0」はテーマ塗りつぶしなし、「正の値」はテーマ背景スタイル参照を意味します。これは C++ コレクションで `idx_get(0)` が最初の項目を指すゼロベースのインデックスとは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限りません。

次の例は、利用可能な背景塗りつぶし数をレポートし、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

表示結果は、マスターが参照するテーマエントリと、レイアウトまたはスライド レベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わりません。継承後の最終背景を知りたいときは、[Background::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/geteffective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`StyleIndex` をゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルから取得したスタイル番号を別のファイルで同じ外観と仮定してハードコーディングしないでください。テーマ スタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/cpp/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ エフェクトの更新**

テーマ フォーマット スキーマは、別々の [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)、[FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_linestyles/)、および [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) コレクションを含みます。一般的な Office テーマは、微妙、適度、強烈という視覚的な 3 つの主要スタイル エントリを持つことが多いですが、コード側では固定数を前提にせず、各コレクションを検査してください。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C++ でこれらのコレクションにアクセスする場合、インデックスはゼロベースです：`idx_get(0)` が最初のスタイル、`idx_get(2)` が 3 番目です。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapestyle/) で公開されます。テーマ スタイルを変更すると、そのテーマ スタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例では、必要なスタイル エントリが存在することを確認し、最初の線スタイル、3 番目の塗りつぶしスタイルを変更し、3 番目のエフェクト スタイルに外部シャドウ（距離 10pt）を有効化して結果を保存します。

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
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
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが「森林」緑の実色に、3 番目のエフェクト スタイルに外部シャドウが追加されます。最終的なビジュアルは、各シェイプが参照しているスタイル スロットと、直接書式設定がテーマを上書きしているかどうかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **有効なテーマ値の取得**

生のテーマ オブジェクトは、特定レベルで定義されている内容を示します。有効値は、継承とローカル オーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) を呼び出します。背景の場合は [Background::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/geteffective/)、塗りつぶしの場合は [FillFormat::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/geteffective/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプ塗りつぶしを読み取ります。

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

有効データは、レンダリング診断、検証、比較に利用してください。[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_mastertheme/) だけを調べると、マスター、レイアウト、スライド、シェイプのオーバーライドにより最終外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**単一スライドにだけテーマを適用し、マスターを変更しない方法はありますか？**

はい。スライドの [IOverrideThemeManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ioverridethememanager/) を使用してオーバーライドテーマを初期化します。変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最良の方法は？**

スライドを移動しつつ元の外観を保持する場合は、ソース マスターを宛先にクローンし、[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/addclone/) と [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) を使ってスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効値はどうやって確認できますか？**

スライドまたはレイアウトのテーマについては [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) を使用し、[Background::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/geteffective/) や [FillFormat::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/geteffective/) などの対応する有効データ メソッドを使って、継承とオーバーライドが適用された後の値を取得します。