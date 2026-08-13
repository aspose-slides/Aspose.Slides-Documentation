---
title: "C++ でプレゼンテーションからシェイプの実効プロパティを取得する"
linktitle: "実効プロパティ"
type: docs
weight: 50
url: /ja/cpp/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 書式
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ が PowerPoint の正確なレンダリングのために実効シェイプ プロパティを計算および適用する方法を紹介します。"
---
## **概要**

このトピックでは **ローカル** プロパティと **実効** プロパティの違いについて説明します。ローカル値は、特定の書式設定レベルで直接設定された値で、以下のようなものがあります。

1. スライド上の部分（Portion）プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（対象の部分のテキストフレームシェイプが持っている場合）。
1. プレゼンテーション全体のグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「描画結果」としての書式設定を必要とする場合、継承チェーンを解決して **実効** 値を返します。これらはローカル書式オブジェクトの `GetEffective` メソッドを呼び出すことで取得できます。

以下の例は実効値の取得方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持ち、少なくとも1つの部分を含む [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であることを前提としています。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
実効書式データは、継承が適用された後に計算された現在の書式を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformateffectivedata/) のような一部の実効データオブジェクトが内部でキャッシュされる場合があります。親や継承された書式を変更した後に `GetEffective` を再度呼び出すとキャッシュが更新され、以前取得したオブジェクトは以前の状態を表さなくなることがあります。実効値を後で再利用する必要がある場合は、フォント高さ、塗りつぶし色、フォントスタイル、配置など必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの実効プロパティの取得**

Aspose.Slides はカメラの実効プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icameraeffectivedata/) インターフェイスは、実効カメラプロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icameraeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) の実効値を提供します。

以下のコードサンプルはカメラの実効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていることを前提としています。

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **ライトリグの実効プロパティの取得**

Aspose.Slides はライトリグの実効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilightrigeffectivedata/) インターフェイスは、実効ライトリグプロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilightrigeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) の実効値を提供します。

以下のコードサンプルはライトリグの実効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていることを前提としています。

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **ベベルシェイプの実効プロパティの取得**

Aspose.Slides はシェイプベベルの実効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapebeveleffectivedata/) インターフェイスは、シェイプの実効面リリーフプロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapebeveleffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) の実効値を提供します。

以下のコードサンプルはシェイプの上部ベベルの実効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていることを前提としています。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **テキストフレームの実効プロパティの取得**

Aspose.Slides を使用して、テキストフレームの実効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformateffectivedata/) インターフェイスは実効テキストフレーム書式プロパティを含みます。

以下のコードサンプルは実効テキストフレーム書式プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であることを前提としています。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **テキストスタイルの実効プロパティの取得**

Aspose.Slides を使用して、テキストスタイルの実効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextstyleeffectivedata/) インターフェイスは実効テキストスタイルプロパティを含みます。

以下のコードサンプルは実効テキストスタイルプロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であることを前提としています。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **実効フォント高さの取得**

Aspose.Slides を使用して、実効フォント高さを取得できます。以下のコードは、プレゼンテーション構造のさまざまなレベルでローカルフォント高さが設定された後、部分の実効フォント高さがどのように変化するかを示しています。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **テーブルの実効塗りつぶし書式の取得**

Aspose.Slides を使用して、テーブルの各部位に対する実効塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifillformateffectivedata/) インターフェイスは実効塗りつぶし書式プロパティを含みます。セル書式は行書式より優先度が高く、行書式は列書式より優先度が高く、列書式はテーブル全体の書式より優先度が高くなります。

その結果、テーブルセルの描画には [ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icellformateffectivedata/) のプロパティが使用されます。以下のコードサンプルはテーブルの各部位に対する実効塗りつぶし書式を取得する方法を示しています。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) であることを前提としています。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **FAQ**

### `GetEffective` はスナップショットを返しますか？

必ずしも返しません。実効データは継承が適用された後に計算された書式を表しますが、一部の実効データオブジェクトは内部でキャッシュされる可能性があります。`GetEffective` を再度呼び出すと書式が再計算されキャッシュが更新されるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

### 実効プロパティはいつ再取得すべきですか？

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーション全体のデフォルトを変更した後に `GetEffective` を再度呼び出します。次の呼び出しで書式階層が再評価され、現在の実効結果が返されます。

### 取得済みの実効プロパティは、レイアウト／マスタースライドを変更・削除するとどうなりますか？

変更は次回の `GetEffective` 呼び出しで反映されます。親書式ソースが変更または削除されると、以前取得した実効データは古くなる可能性があります。`GetEffective` を再度呼び出すと Aspose.Slides が書式ツリーを再評価し、フォントや色、サイズなどの値が変わることがあります。

### 実効データオブジェクトを通じて値を変更できますか？

できません。実効データオブジェクトは計算済みの値を公開するだけです。変更はローカル書式オブジェクトで行い、必要に応じて再度実効値を取得してください。

### シェイプレベルでもレイアウト／マスターでもグローバル設定でもプロパティが設定されていない場合は？

実効値は PowerPoint と Aspose.Slides のデフォルト機構によって決定されます。その解決された値が現在の実効データの一部となります。

### 実効フォント値から、どのレベルがサイズやフォント名を提供したか判別できますか？

直接は判別できません。実効データは最終的な値のみを返します。どのレベルで最初に明示的に定義されたかを知りたい場合は、部分、段落、テキストフレーム、レイアウト、マスター、プレゼンテーションの各ローカル値を順に確認してください。

### 実効値がローカル値と同じに見えるのはなぜですか？

ローカル値が最終的な値となった（上位レベルからの継承が不要だった）ためです。このような場合、実効値はローカル値と同一になります。

### 実効プロパティを使用すべきタイミングと、ローカルプロパティだけを使用すべきタイミングは？

すべての継承が適用された「描画結果」が必要なときは実効データを使用します。たとえば、色やインデント、サイズを正確に合わせる必要がある場合です。これらの値を後で変更されても保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて実効データを再取得して結果を確認します。