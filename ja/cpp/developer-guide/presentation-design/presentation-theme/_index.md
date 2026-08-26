---
title: C++でプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/cpp/presentation-theme/
keywords:
- PowerPointテーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- 外部テーマ
- THMX
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
description: "Aspose.Slides for C++ でプレゼンテーションテーマをマスターし、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **導入**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果の調和したセットを定義します。テーマ対応オブジェクトは、個々の視覚プロパティを固定値として保存する代わりに、これらの共有定義を参照します。そのため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_mastertheme/) で取得できます。プレゼンテーションは、下位レベルでもテーマのオーバーライドを保持できます。マスターは [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) でプレゼンテーションテーマを上書きでき、レイアウトや個別スライドは [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) を使用できます。実際には、スライドの有効テーマは次の継承チェーンを通じて解決されます：プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/) オブジェクトは、テーマの [get_ColorScheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)、[get_FontScheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)、[get_FormatScheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) メソッドを公開します。これらのコレクションを変更前に検査することは、外部ソースから取得したプレゼンテーションで、スタイルエントリの数や内容が変わる可能性があるため特に有用です。

次の例は、メインテーマプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。テーマの [IColorScheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/icolorscheme/) で該当エントリを変更すると、そのテーマ色を参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマ色の更新の影響を受けません。

次のエンドツーエンド例では、`Accent4` を使用したシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

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

矩形は `Accent4` にリンクされたままであるため、テーマが変更された後に表示色は赤になります。シェイプ上でスキーム色を直接カラーに置き換えると、以降の `Accent4` 変更はその塗りつぶしに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint はテーマ色から明度変換を適用して、明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/colortransformoperation/) を通じて公開しています。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - メインテーマカラー  
**2** - メインテーマカラーから生成された明るい/暗いバリエーション

次の例では、`Accent4` を基にした 6 つの矩形を作成し、うち 5 つに輝度変換を適用して結果を保存します。

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

これらのバリエーションはテーマカラーに基づいています。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/icolorscheme/) は同じスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これは同じテーマスロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme::get_Major()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/fontscheme/get_major/) と [FontScheme::get_Minor()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/fontscheme/get_minor/) メソッドでそれらのセットにアクセスできます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント ラテン文字 (Minor Latin Font)
* `+mj-lt` - 見出しフォント ラテン文字 (Major Latin Font)
* `+mn-ea` - 本文フォント 東アジア文字 (Minor East Asian Font)
* `+mj-ea` - 見出しフォント 東アジア文字 (Major East Asian Font)

次の例では、メジャー ラテンテーマフォントを使用した見出しと、マイナー ラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォント、本文はマイナーフォントに従います。テーマ識別子ではなく明示的にフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャー・マイナーフォントコレクションは、キリル文字、アラビア文字、日本語、ジョージア文字、タナ文字など、個々の文字体系向けのフォントマッピングも保持できます。これらのマッピングを検査、追加、置換、削除する方法は、[スクリプト固有のテーマフォント](/slides/ja/cpp/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細は、[PowerPoint フォント](/slides/ja/cpp/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存スライドに適用する**

PowerPoint のテーマファイル (`.thmx`) があり、特定のマスターに依存するすべてのスライドの外観を変更したい場合は、[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) を使用します。対象マスターは [Presentation::get_Masters](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_masters/) コレクション（[IMasterSlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/) が実装）から選択し、テーマファイルのパスをメソッドに渡します。

メソッドは次の操作を行います。

1. 選択したマスターを基に新しいマスタースライドを作成する。  
2. 外部テーマを新しいマスターに適用する。  
3. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てる。  
4. 新しく作成された [IMasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/) を返す。

次の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

無効、破損、またはサポートされていないテーマは [PptxException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxexception/) またはその派生例外をスローすることがあります。ユーザーが提供したパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマの適用が正常に完了した後にだけプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに属するスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、効果は外部テーマに対して解決されます。直接割り当てられた色やフォントなどの明示的書式設定は変更されない場合があります。レイアウトレベルやスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマは実行環境にインストールされていないフォントを参照することがあります。レンダリングとエクスポートの一貫性を保つため、必要なフォントをインストールするか、[カスタムフォント ソース](/slides/ja/cpp/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/cpp/font-substitution/) を構成してください。

これはマスター単位の直接ワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスタープレゼンテーションで異なる外部テーマを適用する**

事前に対象マスターが分からない場合は、[ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/get_layoutslide/) と [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_masterslide/) を使って代表的なスライドから取得します。テーマ適用前に元のマスター参照を保存してください。各呼び出しはプレゼンテーションに新しいマスターを作成します。

次の例は、2 つのセクションからスライドを取得してそれぞれのマスターを特定し、各グループに別々の外部テーマを適用します。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

最初の呼び出しは `firstGroupMaster` に依存するスライドのみを対象とし、2 回目の呼び出しは `secondGroupMaster` に依存するスライドのみを対象とします。他のマスターに属するスライドは変更されません。

### **スライド移動時に元テーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/addclone/) でソースマスターをターゲットにコピーし、続いて [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) でスライドとクローンマスターをコピーします。これにより、マスター、レイアウト、および関連テーマが一緒に転送されます。

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

この方法は、ソーススライドが宛先でも同じ外観になることが最も重要な場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わる可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターとレイアウトのままに保ちたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。次のメソッドで 3 つの主要テーマコンポーネントをオーバーライドにコピーできます。

* [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)  
* [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)  
* [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/)

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

この操作はそのスライドだけのテーマを変更し、他のスライドが継承しているテーマには影響しません。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme::Clear()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/overridetheme/clear/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライド全体に適用されます（ただし、個々のスライドが独自のオーバーライドを持っている場合は例外です）。同じ初期化メソッドをレイアウトの [IOverrideThemeManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ioverridethememanager/) を通じて使用できます。

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

多数のスライドやレイアウトが同じ基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけが異なるスタイリングを必要とする場合はレイアウトオーバーライドを、真の例外のみを対象にする場合はスライドオーバーライドを使用してください。過剰なスライドレベルのオーバーライドは、後からの全体テーマ変更を予測しにくくします。

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) に格納されています。PowerPoint の UI では、実際にコレクションに保存されている塗りつぶし定義よりも多くの背景選択肢を提示できるのは、テーマ塗りつぶしとテーマカラーや他のスタイル参照を組み合わせて表示できるためです。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、保存されているコレクションと現在の [Background::get_StyleIndex()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/get_styleindex/) を検査してください。`StyleIndex` はテーマ塗りつぶしが無い場合に `0`、正の値はテーマ背景スタイル参照を意味します。これは C++ コレクションを `idx_get(0)` で直接取得するインデックス（`0` が最初のアイテム）とは異なります。プレゼンテーションごとに背景塗りつぶしスタイル数が同じとは限らないことに注意してください。

次の例は、利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わりません。継承後の最終背景が必要なときは、[Background::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/geteffective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`StyleIndex` をゼロベースのコレクションインデックスとみなさないでください。また、あるファイルから取得したスタイル番号をハードコードして別ファイルで同じ外観になると期待しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[プレゼンテーション背景](/slides/ja/cpp/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマットスキームは、[FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)、[FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_linestyles/)、[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) の 3 つのコレクションを保持します。一般的な Office テーマは、控えめ、標準、強調という 3 つの主要スタイルエントリを持つことが多いですが、コード側では固定数を前提にせず各コレクションを走査してください。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C++ でこれらのコレクションにアクセスする場合、インデックスはゼロベースです。`idx_get(0)` が最初のスタイル、`idx_get(2)` が 3 番目のスタイルとなります。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapestyle/) で公開されています。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイル、3 番目の塗りつぶしスタイル、3 番目の効果スタイルに外側のシャドウ（距離 10 ポイント）を設定して結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初の線スタイルが赤に、3 番目の塗りつぶしスタイルが濃い森林緑に、3 番目の効果スタイルに外側シャドウが適用されます。最終的な見た目は、各シェイプがどのスロットを参照しているか、直接書式設定がテーマを上書きしているかによって変わります。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **有効なテーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は、継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) を呼び出します。背景の場合は [Background::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/geteffective/)、塗りつぶしの場合は [FillFormat::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/geteffective/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプの塗りつぶしを取得します。

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

有効データは描画診断、検証、比較に使用してください。単に [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_mastertheme/) を検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドによって最終外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) は選択したマスターに依存するスライドだけを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの [IOverrideThemeManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ioverridethememanager/) を使用してオーバーライドテーマを初期化します。変更はそのスライドに限定され、他のスライドは引き続き既存テーマを継承します。

**テーマを別のプレゼンテーションに安全に持ち込むにはどうすればよいですか？**

スライドを移動して元の外観を保持したい場合は、[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/addclone/) でソースマスターを宛先にクローンし、続いて [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) でそのマスターを使用してスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライド後の有効値を確認するには？**

スライドやレイアウトのテーマについては [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) を、[Background::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/geteffective/) や [FillFormat::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/geteffective/) などのフォーマットオブジェクト向け有効データメソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。