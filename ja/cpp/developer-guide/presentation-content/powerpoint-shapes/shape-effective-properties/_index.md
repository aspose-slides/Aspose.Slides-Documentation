---
title: C++ のプレゼンテーションからシェイプの有効プロパティを取得する
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/cpp/shape-effective-properties/
keywords:
- シェイププロパティ
- カメラプロパティ
- ライトリグ
- ベベルシェイプ
- テキストフレーム
- テキストスタイル
- フォント高さ
- 塗りつぶし書式
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ が正確な PowerPoint 表示のためにシェイプの有効プロパティをどのように計算し適用するかをご紹介します。"
---
## **概要**

このトピックでは **ローカル** と **有効** プロパティの違いについて説明します。ローカル値は、特定の書式設定レベルで直接設定された値で、次のようなものがあります:

1. スライド上の Portion プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプ形状テキストスタイル（Portion のテキストフレーム形状がある場合）。
1. プレゼンテーションのグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「レンダリング後」の書式設定を必要とする場合、継承チェーンを解決し、**有効** な値を返します。ローカル書式オブジェクトで `GetEffective` メソッドを呼び出すことで取得できます。

次の例は有効な値を取得する方法を示しています。最初のスライドの最初の図形がテキストフレームと少なくとも1つの Portion を持つ [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であると想定します。

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
有効な書式データは、継承が適用された後の現在計算された書式を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformateffectivedata/) のような一部の有効データオブジェクトが内部でキャッシュされる場合があります。親または継承された書式を変更した後に `GetEffective` を再度呼び出すと、キャッシュされたデータが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。後で再利用するために有効な値を保持する必要がある場合は、フォント高さ、塗りつぶし色、フォントスタイル、または配置などの必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの有効プロパティを取得する**

Aspose.Slides はカメラの有効プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icameraeffectivedata/) インターフェイスは、カメラの有効プロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icameraeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) の有効な値を提供します。

次のコードサンプルは、カメラの有効プロパティを取得する方法を示しています。最初のスライドの最初の図形に 3D 書式設定があると想定します。

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

## **ライトリグの有効プロパティを取得する**

Aspose.Slides はライトリグの有効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilightrigeffectivedata/) インターフェイスは、ライトリグの有効プロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilightrigeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) の有効な値を提供します。

次のコードサンプルは、ライトリグの有効プロパティを取得する方法を示しています。最初のスライドの最初の図形に 3D 書式設定があると想定します。

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

## **ベベル形状の有効プロパティを取得する**

Aspose.Slides は形状ベベルの有効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapebeveleffectivedata/) インターフェイスは、形状の有効な面彫刻プロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapebeveleffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) の有効な値を提供します。

次のコードサンプルは、形状の上部ベベルの有効プロパティを取得する方法を示しています。最初のスライドの最初の図形に 3D 書式設定があると想定します。

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

## **テキストフレームの有効プロパティを取得する**

Aspose.Slides を使用すると、テキストフレームの有効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformateffectivedata/) インターフェイスは、テキストフレームの有効な書式設定プロパティを含みます。

次のコードサンプルは、テキストフレームの有効な書式設定プロパティを取得する方法を示しています。最初のスライドの最初の図形がテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であると想定します。

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

## **テキストスタイルの有効プロパティを取得する**

Aspose.Slides を使用すると、テキストスタイルの有効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextstyleeffectivedata/) インターフェイスは、テキストスタイルの有効プロパティを含みます。

次のコードサンプルは、テキストスタイルの有効プロパティを取得する方法を示しています。最初のスライドの最初の図形がテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であると想定します。

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

## **有効フォント高さの取得**

Aspose.Slides を使用すると、有効なフォント高さを取得できます。次のコードは、プレゼンテーションのさまざまな構造レベルでローカルのフォント高さが設定された後に、Portion の有効フォント高さがどのように変化するかを示しています。

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

## **テーブルの有効塗りつぶし書式の取得**

Aspose.Slides を使用すると、テーブルのさまざまな部分の有効な塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifillformateffectivedata/) インターフェイスは、有効な塗りつぶし書式プロパティを含みます。セルの書式は行の書式よりも優先され、行の書式は列の書式よりも優先され、列の書式はテーブル全体の書式よりも優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icellformateffectivedata/) のプロパティがテーブルセルの描画に使用されます。次のコードサンプルは、テーブルのさまざまな部分の有効な塗りつぶし書式を取得する方法を示しています。最初のスライドの最初の図形が [ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) であると想定します。

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

## **よくある質問**

**`GetEffective` はスナップショットを返しますか？**

必ずしもそうではありません。有効データは継承が適用された後に計算された書式を表しますが、一部の有効データオブジェクトが内部でキャッシュされることがあります。その後の `GetEffective` 呼び出しにより書式が再計算され、キャッシュされたデータが更新される可能性があるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**有効プロパティを再度取得すべきタイミングは？**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーションレベルのデフォルトを変更した後に `GetEffective` を再度呼び出します。次の呼び出しで書式階層が再評価され、現在の有効な結果が返されます。

**レイアウト/マスタースライドを変更または削除すると、既に取得した有効プロパティに影響しますか？**

はい、ただし変更は次回の `GetEffective` 呼び出し時に反映されます。親書式ソースが変更または削除されると、以前取得した有効データは古くなる可能性があります。再度 `GetEffective` を呼び出すと、Aspose.Slides が書式ツリーを再評価し、フォントや色、サイズなどの値が変わることがあります。

**有効データオブジェクトを介して値を変更できますか？**

できません。有効データオブジェクトは計算された値のみを公開します。ローカルの書式オブジェクトで変更を行い、再度有効な値を取得してください。

**形状レベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合、どうなりますか？**

有効値はデフォルトメカニズムにより決定されます。これには PowerPoint と Aspose.Slides のデフォルトが含まれ、解決された値が現在の有効データの一部となります。

**有効フォント値から、どのレベルがサイズや書体を提供したか判断できますか？**

直接は判断できません。有効データは最終的な値だけを返します。ソースを特定するには、Portion、Paragraph、TextFrame、レイアウト、マスター、プレゼンテーションレベルのローカル値を順に確認し、最初に明示的に定義された場所を探してください。

**なぜ有効値がローカル値と同一に見えることがあるのですか？**

ローカル値が最終的な値となり、上位レベルの継承が不要だった場合です。そのようなケースでは有効値がローカル値と一致します。

**有効プロパティを使用すべき時と、ローカルだけで作業すべき時はどちらですか？**

すべての継承が適用された後の「レンダリング後」の結果が必要なときは有効データを使用します。たとえば色やインデント、サイズを揃える場合などです。後で書式変更の影響を受けずに値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて有効データを再取得して結果を確認します。