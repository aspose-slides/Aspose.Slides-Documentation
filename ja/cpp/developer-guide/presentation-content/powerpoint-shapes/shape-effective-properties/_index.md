---
title: C++ でプレゼンテーションからシェイプの有効プロパティを取得
linktitle: 有効プロパティ
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
- フォントの高さ
- 塗りつぶし 書式
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ が正確な PowerPoint のレンダリングのために、シェイプの有効プロパティをどのように計算し適用するかをご紹介します。"
---
## **概要**

このトピックは **local** と **effective** プロパティの違いを説明します。ローカル値は、特定の書式設定レベルで直接設定された値で、例えば以下のようなものです：

1. スライド上の portion プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプテキストスタイル（portion のテキストフレームシェイプに設定がある場合）。
1. プレゼンテーション全体のテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「as rendered」書式設定を必要とする場合、継承チェーンを解決して **effective** 値を返します。これらはローカル書式オブジェクトの `GetEffective` メソッドを呼び出すことで取得できます。

以下の例は effective 値の取得方法を示します。最初のスライドの最初のシェイプがテキストフレームと少なくとも 1 つの portion を持つ [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であることを前提としています。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
Effective 書式データは、継承が適用された後に計算された現在の書式設定を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformateffectivedata/) などの一部の effective データオブジェクトが内部でキャッシュされる可能性があります。親や継承された書式設定を変更した後に `GetEffective` を再度呼び出すとキャッシュが更新され、以前に取得したオブジェクトは以前の状態を表さなくなることがあります。後で再利用するために effective 値を保持したい場合は、フォント高さ、塗りつぶし色、フォントスタイル、配置などの必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの Effective プロパティの取得**

Aspose.Slides はカメラの effective プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icameraeffectivedata/) インターフェイスは、変更不可能なオブジェクトで、effective カメラプロパティを格納します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icameraeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) の effective 値を提供します。

以下のコードサンプルはカメラの effective プロパティを取得する方法を示します。最初のスライドの最初のシェイプが 3D 書式設定を持つことを前提としています。

```cpp
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

## **ライトリグの Effective プロパティの取得**

Aspose.Slides はライトリグの effective プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilightrigeffectivedata/) インターフェイスは、変更不可能なオブジェクトで、effective ライトリグプロパティを格納します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilightrigeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) の effective 値を提供します。

以下のコードサンプルはライトリグの effective プロパティを取得する方法を示します。最初のスライドの最初のシェイプが 3D 書式設定を持つことを前提としています。

```cpp
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

## **シェイプベベルの Effective プロパティの取得**

Aspose.Slides はシェイプベベルの effective プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapebeveleffectivedata/) インターフェイスは、シェイプのフェイスリリーフプロパティを格納した変更不可能なオブジェクトです。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapebeveleffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) の effective 値を提供します。

以下のコードサンプルはシェイプの上部ベベルの effective プロパティを取得する方法を示します。最初のスライドの最初のシェイプが 3D 書式設定を持つことを前提としています。

```cpp
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

## **テキストフレームの Effective プロパティの取得**

Aspose.Slides を使用すると、テキストフレームの effective プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformateffectivedata/) インターフェイスは effective テキストフレーム書式設定プロパティを含みます。

以下のコードサンプルはテキストフレームの effective 書式設定プロパティを取得する方法を示します。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であることを前提としています。

```cpp
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

## **テキストスタイルの Effective プロパティの取得**

Aspose.Slides を使用すると、テキストスタイルの effective プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextstyleeffectivedata/) インターフェイスは effective テキストスタイルプロパティを含みます。

以下のコードサンプルはテキストスタイルの effective プロパティを取得する方法を示します。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であることを前提としています。

```cpp
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

## **Effective フォント高さの取得**

Aspose.Slides を使用すると、effective フォント高さを取得できます。以下のコードは、プレゼンテーション構造の異なるレベルでローカルフォント高さが設定された後に、portion の effective フォント高さがどのように変化するかを示しています。

```cpp
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

## **テーブルの Effective 塗りつぶし形式の取得**

Aspose.Slides を使用すると、テーブルの各部分に対する effective 塗りつぶし書式設定を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifillformateffectivedata/) インターフェイスは effective 塗りつぶし書式設定プロパティを含みます。セルの書式設定は行の書式設定より優先され、行の書式設定は列の書式設定より優先され、列の書式設定はテーブル全体の書式設定より優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icellformateffectivedata/) のプロパティがテーブルセルの描画に使用されます。以下のコードサンプルはテーブルの各部分に対する effective 塗りつぶし書式設定を取得する方法を示します。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) であることを前提としています。

```cpp
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

**`GetEffective` はスナップショットを返しますか？**

必ずしもそうではありません。Effective データは継承が適用された後に計算された書式設定を表しますが、一部の effective データオブジェクトは内部でキャッシュされることがあります。`GetEffective` を再度呼び出すと書式設定が再計算されキャッシュが更新されるため、以前に取得したオブジェクトは永続的なスナップショットとして扱うべきではありません。

**いつ effective プロパティを再取得すべきですか？**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーションレベルのデフォルトを変更した後に `GetEffective` を再度呼び出してください。次の呼び出しで書式階層が再評価され、現在の effective 結果が返されます。

**レイアウト/マスタースライドを変更または削除すると、すでに取得した effective プロパティに影響しますか？**

はい。ただし、変更は次回の `GetEffective` 呼び出しで反映されます。親の書式ソースが変更または削除された場合、以前に取得した effective データは古くなる可能性があります。`GetEffective` を再度呼び出すと Aspose.Slides が書式ツリーを再評価し、フォント、色、サイズ、その他の値が変わることがあります。

**effective データオブジェクトを介して値を変更できますか？**

できません。Effective データオブジェクトは計算された値を公開するだけです。ローカル書式オブジェクトで変更を行い、再度 effective 値を取得してください。

**シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

effective 値は PowerPoint と Aspose.Slides のデフォルトを含む既定のメカニズムによって決定されます。その解決された値が現在の effective データの一部となります。

**effective フォント値から、どのレベルがサイズやフォント名を提供したか判断できますか？**

直接は判断できません。Effective データは最終的な値を返すだけです。どのレベルで最初に明示的に定義されたかを知りたい場合は、portion、段落、テキストフレーム、レイアウト、マスター、プレゼンテーションレベルのローカル値を順に確認してください。

**なぜ effective 値がローカル値と同じに見えることがありますか？**

ローカル値が最終的な値となり、上位レベルからの継承が必要なかったためです。そのような場合、effective 値はローカル値と一致します。

**effective プロパティを使用すべきタイミングと、ローカルプロパティだけを使用すべきタイミングは？**

すべての継承が適用された後の「レンダリング後」結果が必要な場合は effective データを使用します（例: 色、インデント、サイズの整合）。後で書式が変更されても保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて effective データを再取得して結果を確認してください。