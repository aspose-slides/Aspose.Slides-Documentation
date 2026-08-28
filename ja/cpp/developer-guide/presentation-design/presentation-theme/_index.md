---
title: C++ でプレゼンテーションテーマを管理
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
description: "Aspose.Slides for C++ でプレゼンテーションテーマをマスタリングし、一貫したブランディングで PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗り、線、効果の調和の取れたセットを定義します。テーマ対応オブジェクトは、各ビジュアルプロパティを固定値として保持するのではなく、これら共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーション レベルのテーマは [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_mastertheme/) で取得できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを保持できます。マスターは [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) でプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) を使用できます。実際には、スライドの有効テーマは次の継承チェーンで決定されます: プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/) オブジェクトは、テーマの [get_ColorScheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)、[get_FontScheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)、[get_FormatScheme()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) メソッドを公開します。変更前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイル エントリの数や内容はファイルごとに異なる可能性があります。

次の例はメインテーマのプロパティを読み取り、テーマに格納されている背景、塗り、線、効果スタイルの数をレポートします。

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

テーマ対応の塗り、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。テーマの [IColorScheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/icolorscheme/) の該当エントリを変更すると、そのテーマ色を参照しているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマ色の更新の影響を受けません。

次のエンドツーエンド例は `Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存・再読込して有効な塗り色を出力します。

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

矩形が `Accent4` にリンクされたままなので、テーマ変更後に表示色は赤になります。シェイプ上で直接色を設定してしまうと、後の `Accent4` 変更はその塗りに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマ色に色変換を適用して、明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/colortransformoperation/) で公開しています。

![メインテーマ色と追加パレットから生成された明るい・暗い色](additional-palette-colors.png)

**1** - メインテーマ色。  
**2** - メインテーマ色から生成された明るい・暗いバリエーション。

次の例は `Accent4` を基に 6 つの矩形を作成し、うち 5 つに明度変換を適用して結果を保存します。

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

これらのバリエーションはテーマ色に基づいたままです。`Accent4` が後で変更されれば、変換された色は新しい `Accent4` 値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントの変更**

テーマ フォント スキームは見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。`[FontScheme::get_Major()]` と `[FontScheme::get_Minor()]` メソッドでそれぞれのセットを取得できます。

PowerPoint 互換のテーマ フォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント ラテン (Minor Latin Font)  
* `+mj-lt` – 見出しフォント ラテン (Major Latin Font)  
* `+mn-ea` – 本文フォント 東アジア (Minor East Asian Font)  
* `+mj-ea` – 見出しフォント 東アジア (Major East Asian Font)

次の例はメジャー ラテンテーマフォントを使用した見出しと、マイナー ラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォント、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマ フォント スキームが変更されても自動的に切り替わりません。

メジャーとマイナーのフォント コレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字など、個別の書字システム向けマッピングを含めることもできます。これらのマッピングの検査、追加、置換、削除については [スクリプト固有のテーマ フォント](/slides/ja/cpp/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="ヒント" %}}
プレゼンテーション フォントの詳細については、[PowerPoint フォント](/slides/ja/cpp/powerpoint-fonts/) を参照してください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存のスライドに適用する**

PowerPoint テーマ ファイル (`.thmx`) があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) を使用します。まず、[Presentation::get_Masters](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_masters/) コレクションからマスターを選択し（このコレクションは [IMasterSlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/) を実装）、メソッドにテーマ ファイルのパスを渡します。

メソッドが実行する操作:

1. 選択したマスターを元に新しいマスター スライドを作成する。  
2. 外部テーマを新しいマスターに適用する。  
3. 以前は選択マスターに依存していたすべてのスライドに新しいマスターを割り当てる。  
4. 新しく作成された [IMasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/) を返す。

次の例は最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

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

無効、破損、またはサポートされていないテーマを使用すると、[PptxException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxexception/) やそのフォーマット系サブクラスがスローされる可能性があります。ユーザーから提供されたパスは検証し、ファイル システム アクセスの失敗に対処し、テーマの適用が成功した後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗り、線、背景、効果は外部テーマに対して解決されますが、直接割り当てられた色やフォント、塗りなどの明示的書式は変更されない場合があります。レイアウトレベルやスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマが実行環境に存在しないフォントを参照している場合があります。安定した描画とエクスポートのために、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/cpp/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/cpp/font-substitution/) を構成してください。

これはマスター レベルの直接ワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマ オーバーライドを手動で作成する必要はありません。

### **マルチマスター プレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、[ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/get_layoutslide/) と [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_masterslide/) を使って代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。各呼び出しはプレゼンテーションに新しいマスターを作成します。

次の例は 2 つのセクションのスライドからそれぞれのマスターを特定し、各グループに別々の外部テーマを適用します。

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

最初の呼び出しは `firstGroupMaster` に依存するスライドだけに影響し、2 番目の呼び出しは `secondGroupMaster` に依存するスライドだけに影響します。その他のマスターに属するスライドは再スタイル化されません。

### **スライド移動時に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/addclone/) で元のマスターをターゲット プレゼンテーションにクローンし、続いて [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) でスライドとクローンしたマスターをクローンします。これによりマスター、レイアウト、関連テーマがすべて一緒にコピーされます。

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

この方法は、ソース スライドが宛先でも同一に見える必要がある場合に推奨されるワークフローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変更されることがあります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターとレイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。`[OverrideTheme::InitColorSchemeFrom()]`、`[OverrideTheme::InitFontSchemeFrom()]`、`[OverrideTheme::InitFormatSchemeFrom()]` メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承しているテーマは変更せずに、対象スライドだけのテーマが変更されます。ローカル オーバーライドを削除して継承値に戻すには、`[OverrideTheme::Clear()]` を呼び出します。

### **レイアウトにテーマ オーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドすべてに適用されます（ただし個別スライドが独自のオーバーライドを持つ場合は例外）。同じ初期化メソッドはレイアウトの [IOverrideThemeManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ioverridethememanager/) から呼び出せます。

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

多数のレイアウトとスライドが同一の基本デザインを共有する場合はマスターまたはプレゼンテーション レベルのテーマを使用し、特定のレイアウトファミリだけが異なるスタイルを必要とする場合はレイアウト オーバーライドを、例外的なケースだけはスライド オーバーライドを使用してください。過剰なスライドレベルのオーバーライドは、後のグローバルテーマ変更を予測しにくくします。

## **テーマの背景スタイルの更新**

テーマの背景塗りは [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) に格納されます。PowerPoint の UI は、このコレクションに実際に格納されている塗り定義の数以上の背景選択肢を提示できることがあります。これは UI がテーマ塗りとテーマ色、その他のスタイル参照を組み合わせるためです。

![プレゼンテーション テーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background::get_StyleIndex()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/get_styleindex/) を検査してください。`StyleIndex` は `0` がテーマ塗りなし、正の値がテーマ背景スタイル参照を表します。これは `idx_get(0)` で最初の項目を取得する C++ コレクションのインデックスとは異なります。すべてのプレゼンテーションが同じ数の背景塗りスタイルを持つとは限らないことに注意してください。

次の例は利用可能な背景塗り数をレポートし、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果はマスターが参照するテーマ エントリと、レイアウトまたはスライドレベルの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わらないことがあります。継承後の最終背景を知りたいときは [Background::GetEffective()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/background/geteffective/) を使用してください。

{{% alert color="warning" title="警告" %}}
`StyleIndex` をゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルから取得したスタイル番号をハードコーディングして別ファイルで同じ外観になると想定しないでください。テーマ スタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="ヒント" %}}
直接的な背景書式設定や背景継承については、[プレゼンテーション背景](/slides/ja/cpp/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマット スキームは、[FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)、[FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_linestyles/)、[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) コレクションをそれぞれ保持します。一般的な Office テーマは、視覚的に「控えめ」「標準」「強調」の 3 つの主要スタイルエントリを持つことが多いですが、コード側では固定数を前提にせず各コレクションを検査すべきです。

![同一シェイプに適用された控えめ・標準・強調のテーマ効果](presentation-design_10.png)

C++ でこれらのコレクションにアクセスする場合、インデックスはゼロベースです：`idx_get(0)` が最初のスタイル、`idx_get(2)` が 3 番目です。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapestyle/) を通じて取得します。テーマ スタイルを変更すると、そのテーマ スタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例は必要なスタイルエントリが存在するか確認し、最初の線スタイルを変更し、3 番目の塗りスタイルを変更し、3 番目の効果スタイルに外側の影（距離 10pt）を有効にして結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りスタイルが濃い森の緑に、3 番目の効果スタイルに外側の影が追加されます。最終的なビジュアルは各シェイプがどのスロットを参照しているか、直接書式がテーマを書き換えているかに依存します。

![線・塗り・影設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **有効な単色塗りがテーマ色を使用しているか判定する**

塗りはオブジェクトに直接格納される場合もあれば、段落、レイアウト、マスター、テーマスタイル、その他の書式レベルから継承される場合もあります。`[IFillFormat::GetEffective]` を呼び出して階層を解決し、`[IFillFormatEffectiveData]` を取得します。まず `[IFillFormatEffectiveData::get_FillType]` を確認し、`FillType::Solid` の場合にのみ単色塗りプロパティを読み取ります。

単色塗りの場合、`[IFillFormatEffectiveData::get_SolidFillColor]` が継承、テーマ検索、色変換後の最終 RGB 値を返します。`[IFillFormatEffectiveData::get_SolidFillSchemeColor]` は対応する論理 `[SchemeColor]` スロット（例: `Text1`、`Accent6`）を返します。`SchemeColor::NotDefined` は有効単色塗りがスキーマ色に基づいていないことを意味し、直接 RGB 塗りであることを示します。

ローカルの `[IColorFormat::get_SchemeColor]` のみで塗りを分類しないでください。たとえば、テキストの一部がローカルでスキーマ色を定義していなくても、継承されたテーマ色により実際の塗りは `Text1` や `Accent6` になることがあります。逆に、`get_SolidFillSchemeColor` はどの論理テーマスロットが最終色を生成したかを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または別の階層から来たかは示しません。

次の例はプレゼンテーションを読み込み、シェイプ塗りとテキスト部分塗りの両方を監査し、最終 RGB 値と対応スキーマ色を出力し、テーマ色の変更に追従しない単色塗りをフラグ付けします。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

`NotDefined` の分岐は、テーマ色スロットの変更に反応しない単色塗りの監査リストを提供します。新しいブランド パレットに合わせてプレゼンテーションを調整する際にこれらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーマ値はその外観がテーマに結び付いているかどうかを説明します。

有効書式オブジェクトはスナップショットです。プレゼンテーション テーマ、テーマ オーバーライド、または任意の継承書式を変更した後は、再度 `GetEffective` を呼び出し、比較またはレポートの前に新しい `IFillFormatEffectiveData` を取得してください。

## **有効なテーマ値の取得**

生のテーマ オブジェクトは特定レベルで定義されている内容を示します。有効値は継承とローカル オーバーライドが解決された後、スライドやシェイプが実際に使用している値を示します。スライドの場合は `[IThemeable::CreateThemeEffective()]` を呼び出します。背景の場合は `[Background::GetEffective()]`、塗りの場合は `[FillFormat::GetEffective()]` を使用します。

次の例はスライドから有効テーマ、背景、最初のシェイプの塗りを取得します。

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

有効データは描画診断、検証、比較に使用します。`[Presentation::get_MasterTheme()]` だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。`[IMasterSlide::ApplyExternalThemeToDependingSlides]` は選択されたマスターに依存するスライドのみを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの `[IOverrideThemeManager]` を使用し、オーバーライドテーマを初期化します。変更はそのスライドにローカルに適用され、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む方法は？**

スライドを移動して元の外観を保持する場合は、[IMasterSlideCollection::AddClone()] と [ISlideCollection::AddClone()] を使用してソース マスターとスライドをターゲットにクローンします。これによりマスター、レイアウト、テーマが一体で保持されます。

**継承とオーバーライド後の有効値はどうやって確認できますか？**

スライドやレイアウトのテーマに対して `[IThemeable::CreateThemeEffective()]` を使用し、`[Background::GetEffective()]`、`[FillFormat::GetEffective()]` などの対応する有効データ メソッドを呼び出します。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。