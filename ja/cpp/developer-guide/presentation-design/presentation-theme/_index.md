---
title: C++ でプレゼンテーション テーマを管理する
linktitle: プレゼンテーション テーマ
type: docs
weight: 10
url: /ja/cpp/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーション テーマ
- スライド テーマ
- テーマの設定
- テーマの変更
- テーマの管理
- 外部テーマ
- THMX
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
description: "Aspose.Slides for C++ でマスターテーマを使用し、一貫したブランディングで PowerPoint ファイルを作成、カスタマイズ、変換します。"
---
## **概要**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、エフェクトの調和の取れたセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多くのオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーション レベルのテーマは [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/) から取得できます。プレゼンテーションには、下位レベルでテーマのオーバーライドを含めることもできます。マスターは [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) によってプレゼンテーションテーマをオーバーライドでき、レイアウトまたは個々のスライドは [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) を使用できます。実際には、スライドの実効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ → マスター オーバーライド → レイアウト オーバーライド → スライド オーバーライド。

![テーマ構成要素: 色、フォント、背景スタイル、エフェクト](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景とエフェクト スタイルの更新、継承とオーバーライドが解決された後の実効値の読み取りです。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) オブジェクトは、テーマの [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)、[get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)、[get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) メソッドを公開します。変更前にこれらのコレクションを検査することは、外部ソースからのプレゼンテーションの場合に特に有用です。スタイル エントリの数と内容は変わる可能性があります。

次の例は、メイン テーマ プロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、エフェクト スタイルの数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ実効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の実効テーマ フローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。テーマの [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) で該当エントリを変更すると、そのテーマ色を参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマ色の更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用したシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実効塗りつぶし色を出力します。

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

矩形は `Accent4` にリンクされたままなので、テーマが変更されると表示色は赤になります。シェイプ上でスキーム色を直接の色に置き換えると、以降の `Accent4` 変更はその塗りつぶしに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint は、テーマ色に対して色変換を適用して、明るいバリエーションや暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/) を通じて公開します。

![メインテーマ色と追加パレットから生成された明るい色と暗い色](additional-palette-colors.png)

**1** - メインテーマ色。  
**2** - メインテーマ色から生成された明るいバリエーションと暗いバリエーション。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、うち 5 つに輝度変換を適用して結果を保存します。

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

これらのバリエーションはテーマ色に基づいたままです。後で `Accent4` が変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマップする**

[SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。対応は固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同一スロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントの変更**

テーマのフォント スキームは、見出し用のメジャー フォント セットと本文用のマイナー フォント セットを含みます。[FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) と [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) メソッドがそれらのセットを公開します。

PowerPoint 互換のテーマ フォント 識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント Latin（マイナー Latin フォント）
* `+mj-lt` - 見出しフォント Latin（メジャー Latin フォント）
* `+mn-ea` - 本文フォント East Asian（マイナー East Asian フォント）
* `+mj-ea` - 見出しフォント East Asian（メジャー East Asian フォント）
* `+mn-cs` - 本文フォント Complex Script（マイナー Complex Script フォント）
* `+mj-cs` - 見出しフォント Complex Script（メジャー Complex Script フォント）

次の例は、メジャー Latin テーマフォントを使用した見出しと、マイナー Latin テーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャー フォントに従い、本文はマイナー フォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマ フォント スキームが変更されても自動的に切り替わりません。

メジャーとマイナーのフォント コレクションは、キリル文字、アラビア文字、日本語、ジョージア文字、タアナ文字など個々の書字システム用のフォント マッピングも含めることができます。これらのマッピングを検査、追加、置換、削除する方法は、[Script-Specific Theme Fonts](/slides/ja/cpp/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーション フォントの詳細情報は、[PowerPoint Fonts](/slides/ja/cpp/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

### **テーマ フォント参照の解決**

テキストを検査する際、[IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) は `+mn-lt` などのテーマ参照を含むことがあります。適切な [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) を使用して [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) を呼び出すと、その参照が解決されます。`+mj` と `+mn` プレフィックスはメジャーとマイナーのフォントセットを選択し、`-lt`、`-ea`、`-cs` サフィックスはそれぞれ Latin、East Asian、Complex Script のフォントを選択します。

対象テキストが属するオブジェクトに対して [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) を呼び出し、実効テーマを取得します。スライド上の普通のテキストであれば `slide->CreateThemeEffective()` を使用し、レイアウトやマスター自体を検査する場合はそれぞれの実効テーマを使用してください。最初のマスターのテーマがすべてのスライドに適用されると仮定しないでください。

次の例は、マイナー Latin フォントを明示的に参照するテキスト部分を作成し、[IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) でスライドのフォント スキームを初期化し、メジャーとマイナーの Latin ファミリを `Arial` と `Calibri` に設定して、入力ファイルなしでも再現可能な結果を得ます。

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto theme = slide->get_ThemeManager()->get_OverrideTheme();
theme->InitFontSchemeFromInherited();
theme->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Arial"));
theme->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Calibri"));

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 60.0f);
shape->get_TextFrame()->set_Text(u"Text using the minor theme font");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

auto font = portion->get_PortionFormat()->get_LatinFont();
auto effectiveTheme = slide->CreateThemeEffective();
auto resolvedFontName = font->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", font->get_FontName(), resolvedFontName);

auto explicitFont = MakeObject<FontData>(u"Verdana");
auto explicitFontName = explicitFont->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", explicitFont->get_FontName(), explicitFontName);
```

出力は `+mn-lt -> Calibri` に続いて `Verdana -> Verdana` となります。保存された参照は変更されず、明示的なファミリ名はそのまま返されます。もし `+mj-lt` が使用されていれば、このテーマでは `Arial` に解決されます。

テーマ参照の解決は、テーマが指定したフォント ファミリを特定します。フォントの利用可否や、レンダリング時の代替フォントや文字グリフフォールバックはチェックしません。これらの別ステップについては、[Font Selection Sequence](/slides/ja/cpp/font-selection-sequence/) および [Font Substitution](/slides/ja/cpp/font-substitution/) を参照してください。

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存スライドに適用する**

PowerPoint テーマ ファイル（`.thmx`）があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) を使用します。対象のマスターは [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) コレクション（[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) 実装）から選択し、メソッドにテーマ ファイル パスを渡します。

このメソッドが実行する操作は次のとおりです。

1. 選択したマスターを基に新しいマスター スライドを作成します。  
2. 外部テーマを新しいマスターに適用します。  
3. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。  
4. 新しく作成された [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/) を返します。

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

無効、破損、またはサポートされていないテーマを使用すると、[PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) またはその派生例外がスローされる可能性があります。ユーザーが指定したパスを検証し、ファイル システムのアクセス障害に対処し、テーマの適用が成功した後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに紐付くスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、エフェクトは外部テーマに対して解決されます。直接指定された色、フォント、塗りつぶしなどの明示的書式は変更されないままになることがあります。レイアウト レベルおよびスライド レベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマが実行環境に存在しないフォントを参照している場合があります。安定したレンダリングとエクスポートのために、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/cpp/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/cpp/font-substitution/) を構成してください。

この方法はマスター レベルの直接ワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライド レベルやレイアウト レベルのテーマ オーバーライドを手動で作成する必要はありません。

### **マルチマスター プレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、[ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) と [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/) を使用して代表的なスライドから取得し、テーマを適用する前に元のマスター参照を保存してください。各呼び出しはプレゼンテーションに新しいマスターを作成します。

次の例は、2 つのセクションのスライドからそれぞれのマスターを特定し、各グループに異なる外部テーマを適用します。

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

最初の呼び出しは `firstGroupMaster` に依存するスライドのみ、2 回目の呼び出しは `secondGroupMaster` に依存するスライドのみを対象にします。他のマスターに属するスライドは再スタイル化されません。

### **スライド移動時にソーステーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) でスライドとそのクローンマスターをクローンします。これによりマスター、レイアウト、および関連テーマが一緒にコピーされます。

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

この方法は、ソース スライドが宛先でも同一に見えることが必須な場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わる可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターやレイアウトのままに保ちつつ、ソーステーマからスライド レベルのオーバーライドを初期化します。以下のメソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

* [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)  
* [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)  
* [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/)

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

これにより、他のスライドが継承しているテーマは変更せずに、そのスライドだけのテーマが変更されます。ローカル オーバーライドを削除して継承値に戻すには、[OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/) を呼び出します。

### **レイアウトにテーマ オーバーライドを適用する**

レイアウト レベルのオーバーライドは、そのレイアウトを使用するスライドすべてに適用されます（ただし、個別スライドが独自のオーバーライドを持つ場合は例外）。同じ初期化メソッドはレイアウトの [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) を通じて使用できます。

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

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーション レベルのテーマを使用し、特定のレイアウト ファミリだけが異なるスタイルを必要とする場合はレイアウト オーバーライドを、真の例外だけを対象にする場合はスライド オーバーライドを使用してください。過度のスライド レベル オーバーライドは、後続の全体テーマ変更を予測しにくくします。

## **テーマの背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) に格納されます。PowerPoint の UI は、このコレクションに実際に格納されている塗りつぶし定義よりも多くの背景選択肢を提示できるのは、テーマ塗りつぶしとテーマ色や他のスタイル参照を組み合わせられるためです。

![プレゼンテーション テーマの PowerPoint 背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/) を検査してください。`StyleIndex` が `0` の場合はテーマ塗りつぶしなし、正の値はテーマ背景スタイル参照を意味します。これは `idx_get(0)` で最初の格納項目を取得する C++ コレクションのインデックスとは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限りません。

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

可視結果はマスターが参照するテーマエントリと、レイアウトまたはスライド レベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わらないことがあります。最終的な継承後の背景を知りたい場合は、[Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`StyleIndex` をゼロベースのコレクション インデックスとみなさないでください。また、あるファイルで使用したスタイル番号を別のファイルでハードコーディングして同じ外観になると期待しないでください。テーマ スタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/cpp/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ エフェクトの更新**

テーマ フォーマット スキームは、個別の [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)、[FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/)、[FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) コレクションを含みます。一般的な Office テーマは、視覚的に微妙、適度、強いフォーマットに対応する 3 つの主要スタイル エントリを持つことが多いですが、コード側では固定数を前提にせず各コレクションを検査してください。

![同じシェイプに適用された微妙、適度、強いテーマ エフェクト](presentation-design_10.png)

C++ でこれらのコレクションにアクセスする際、インデックスはゼロベースです：`idx_get(0)` が最初のスタイル、`idx_get(2)` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/) を通じて公開されます。テーマ スタイルを変更すると、そのテーマ スタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイル エントリが存在することを確認し、最初の線スタイル、3 番目の塗りつぶしスタイルを変更し、3 番目のエフェクト スタイルに外側の影（距離 10pt）を有効にして結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤になり、3 番目のテーマ塗りつぶしスタイルが濃い森緑（実線）になり、3 番目のエフェクトスタイルに外側の影が追加されます。最終的な視覚結果は、各シェイプがどのスロットを参照しているか、また直接書式設定がテーマを上書きしているかによって変わります。

![線、塗りつぶし、影設定を変更した後のテーマ エフェクト スタイル](presentation-design_11.png)

## **シェイプのテーマ塗りつぶしと線スタイルの選択**

シェイプは [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) と [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/) を使用して、塗りつぶしとアウトラインを独立して選択できます。どちらのセッターでも、インデックス `1` は対応するテーマ コレクションの最初のエントリ（`idx_get(0)`）を、インデックス `2` は 2 番目のエントリを選択します。

次の例は、新規プレゼンテーションのデフォルトテーマに、金色と空色の 2 つの塗りつぶしスタイル、6pt の濃い青線と 12pt の濃い赤線の 2 つの線スタイルを設定し、3 段階でスライドを保存して PowerPoint で結果を比較できるようにします。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeStyle.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto styles = presentation->get_MasterTheme()->get_FormatScheme();

auto goldFill = styles->get_FillStyles()->idx_get(0);
goldFill->set_FillType(FillType::Solid);
goldFill->get_SolidFillColor()->set_Color(Color::get_Gold());
auto blueFill = styles->get_FillStyles()->idx_get(1);
blueFill->set_FillType(FillType::Solid);
blueFill->get_SolidFillColor()->set_Color(Color::get_SkyBlue());

auto thinLine = styles->get_LineStyles()->idx_get(0);
thinLine->get_FillFormat()->set_FillType(FillType::Solid);
thinLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
thinLine->set_Width(6.0);
auto thickLine = styles->get_LineStyles()->idx_get(1);
thickLine->get_FillFormat()->set_FillType(FillType::Solid);
thickLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkRed());
thickLine->set_Width(12.0);

auto shapes = presentation->get_Slide(0)->get_Shapes();
auto left = shapes->AddAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
auto right = shapes->AddAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
auto leftStyle = left->get_ShapeStyle();
auto rightStyle = right->get_ShapeStyle();
leftStyle->set_FillStyleIndex(1);
rightStyle->set_FillStyleIndex(2);
leftStyle->set_LineStyleIndex(1);
rightStyle->set_LineStyleIndex(1);
presentation->Save(u"01-initial.pptx", SaveFormat::Pptx);

rightStyle->set_LineStyleIndex(2);
presentation->Save(u"02-line-changed.pptx", SaveFormat::Pptx);

goldFill->get_SolidFillColor()->set_Color(Color::get_SeaGreen());
presentation->Save(u"03-theme-changed.pptx", SaveFormat::Pptx);
```

| 初期スタイル | 右側のアウトラインを変更 | 最初のテーマ塗りつぶしを編集 |
|:---:|:---:|:---:|
| ![金色と空色の矩形、細い濃い青のアウトラインが一致](theme-style-initial.png) | ![空色の矩形が太い濃い赤のアウトラインに変更](theme-style-line-changed.png) | ![左側の矩形が緑に変わり、アウトラインは変わらず](theme-style-fill-changed.png) |

異なる線スタイルを選択すると、右側の矩形のアウトラインだけが変わります。最初のテーマ塗りつぶしを編集すると、それを使用しているすべてのシェイプが更新されます。この例では左側の矩形だけが緑になります。

既存シェイプにローカルな塗りつぶし色、線色、線幅が設定されていると、テーマ スタイルのその部分が上書きされます。スタイルインデックスを変更しても見た目に変化がない場合は、シェイプの [direct formatting](/slides/ja/cpp/shape-formatting/) を確認してください。

## **実効的な単色塗りつぶしがテーマ色を使用しているか判定する**

塗りつぶしはオブジェクト上に直接格納されるか、段落、レイアウト、マスター、テーマ スタイル、その他の書式レベルから継承されることがあります。[IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) を呼び出すと、その階層が不変の [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/) に解決されます。まず [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/) を確認し、`FillType::Solid` の場合にのみ単色塗りつぶしプロパティを読み取ります。

単色塗りつぶしの場合、[IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) は、継承、テーマ参照、色変換が適用された後の最終的な RGB 値を返します。[IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) は、対応する論理 [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) スロット（例: `Text1`、`Accent6`）を返します。`SchemeColor::NotDefined` は、実効単色塗りつぶしがスキーム色に基づかないことを意味します。テーマ色または直接 RGB 色のどちらかだけを使用するワークフローでは、この値が直接 RGB 塗りつぶしを識別します。

ローカルの [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/) のみを使用して塗りつぶしを分類しないでください。たとえば、テキスト部分にローカルでスキーム色が定義されていない場合、ローカル値は `NotDefined` ですが、実効塗りつぶしはテーマ色を継承して `Text1` や `Accent6` に解決されることがあります。逆に、`get_SolidFillSchemeColor` は実効色を生成した論理テーマスロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または別の階層から来たかは示しません。

次の例は、プレゼンテーションを読み込み、シェイプ塗りつぶしとテキスト部分の塗りつぶしを監査し、最終的な RGB 値と対応するスキーム色を出力し、テーマ色の変更に追随しない単色塗りつぶしをフラグ付けします。

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

`NotDefined` の分岐は、テーマ色スロットの変更に応答しない単色塗りつぶしの監査リストを提供します。新しいブランド パレットに従う必要がある場合は、これらのオブジェクトを確認してください。報告された RGB 値は現在の見た目を示し、スキーム値はその見た目がテーマに接続されているかどうかを説明します。

実効フォーマット オブジェクトはスナップショットです。プレゼンテーション テーマ、テーマ オーバーライド、または任意の継承書式を変更した後は、再度 `GetEffective` を呼び出し、新しい `IFillFormatEffectiveData` オブジェクトを取得してから比較または報告してください。

## **実効テーマ値の読み取り**

生のテーマ オブジェクトは特定レベルで定義されている内容を示します。実効値は、継承とローカル オーバーライドが解決された後にスライドやシェイプが実際に使用しているものを示します。スライドの場合は [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) を呼び出します。背景の場合は [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) を、塗りつぶしの場合は [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/) を使用します。

次の例は、スライドから実効テーマ、背景、最初のシェイプ塗りつぶしを読み取ります。

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

実効データはレンダリング診断、検証、比較に利用してください。[Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/) だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終的な外観が変わっているケースを見落とす可能性があります。

## **FAQ**

**外部テーマを適用すると、プレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) は選択したマスターに依存するスライドだけを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) を使用してオーバーライドテーマを初期化します。変更はそのスライドだけにローカルに適用され、他のスライドは既存テーマを継承し続けます。

**テーマを別のプレゼンテーションに持ち運ぶ最も安全な方法は何ですか？**

スライドを移動して元の外観を保持する場合は、[IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) と [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) を使ってソースマスターを宛先にクローンし、同じマスターでスライドをクローンしてください。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の実効値はどうやって確認できますか？**

スライドまたはレイアウトのテーマに対して [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) を使用し、[Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) や [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/) などの対応する実効データ メソッドを呼び出してください。これらの API は継承とオーバーライドが適用された後の解決値を返します。