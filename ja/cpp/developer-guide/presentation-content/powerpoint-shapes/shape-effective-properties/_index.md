---
title: C++ でプレゼンテーションからシェイプの効果的プロパティを取得する
linktitle: 効果的プロパティ
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
description: "PowerPoint プレゼンテーションにおけるシェイプのローカル、継承、効果的な書式設定を区別する方法を、C++ 用 Aspose.Slides を使用して学びます。"
---
## **ローカル、継承、効果的なプロパティの理解**

PowerPoint の書式設定は複数の場所から取得できます。オブジェクトに直接格納されている値は **ローカル値** です。その値が設定されていない場合、PowerPoint は段落のデフォルト、テキスト スタイル、レイアウトまたはマスタースライド、テーマ、プレゼンテーション レベルのデフォルトなど、親の書式設定ソースを参照します。これらの値は **継承値** と呼ばれます。階層全体が解決された後に残る値が **効果的な値** で、オブジェクトの描画に使用される値です。

たとえば、テキストの一部がフォントの高さを独自に定義していない場合があります。そのローカルの[フォントの高さ](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/)は `std::numeric_limits<float>::quiet_NaN()` で、これは「ここでは設定されていない」ことを意味します。この部分は段落やプレゼンテーションのデフォルトテキストスタイル、または他の適用可能なソースから高さを継承できます。部分の書式に対して[GetEffective](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/)を呼び出すと、最終的に解決された高さが返されます。

異なる目的で 2 種類の書式データを使用します:

- 値がどこで定義されているかを制御する必要がある場合は、[IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/) のようなローカル書式オブジェクトを読み取ったり変更したりします。
- 最終的なレンダリング結果が必要な場合は、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformateffectivedata/) のような効果的データオブジェクトを読み取ります。効果的データは読み取り専用です。

## **ローカル、継承、効果的な値の比較**

以下の完全な例では、シェイプを作成し、プレゼンテーション、段落、部分レベルでフォントの高さを適用します。各ステップでそれらのレベルで定義された値と、同じテキスト部分の結果として得られる効果的な値を出力します。また、書式設定の変更後に効果的データを再度読み取る必要がある理由も示しています。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// 2 つの異なるレベルで継承された値を定義します。
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // 前の変更後に効果的なデータを読み取ります。
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// 部分のローカル値が両方の継承値を上書きします。
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// 継承値を変更しても、既存のローカル値は上書きされません。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// ローカル値をクリアします。部分は再び段落から継承します。
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// 段落の値をクリアします。プレゼンテーションのデフォルトが結果を提供します。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

この例では、優先順位はまず部分のローカル書式、次に段落書式、最後にプレゼンテーションのデフォルトです。他のオブジェクトは異なる継承チェーンを持つことがありますが、原則は同じです。より具体的な明示的な値が勝ち、[GetEffective](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/) が最終結果を返します。

## **効果的なテキストプロパティの取得**

テキストの書式設定は複数のオブジェクトに分割されています:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/) は、余白、アンカリング、オートフィット、縦書き方向などのテキストフレームのプロパティを解決します。
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextstyle/) は、各テキストスタイルレベルの段落書式を解決します。
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/) は、配置、インデント、箇条書きなどの段落プロパティを解決します。
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/) は、フォントの高さ、書体、色、太字、イタリックなどの文字プロパティを解決します。

次の例では、`text-formatting.pptx` に少なくとも 1 枚のスライドと、空でないテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) が 1 つ含まれている必要があります。IAutoShape はシェイプコレクション内の任意の位置に存在する可能性があるため、コードは適切なオブジェクトを検索し、使用前に検証します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **効果的な 3D プロパティの取得**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) は、すべての解決された 3D 設定をまとめた [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformateffectivedata/) オブジェクトを返します。その [camera](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icameraeffectivedata/)、[light rig](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilightrigeffectivedata/)、[top bevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapebeveleffectivedata/)、[bottom bevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapebeveleffectivedata/) データは、対応する効果的設定を公開します。これらの関連設定を一緒に読み取ることで、シェイプの最終的な 3D 外観を理解しやすくなります。

この例では、`shape-3d.pptx` の最初のスライドに少なくとも 1 つのシェイプが含まれている必要があります。デフォルト以外の値を出力に含めたい場合は、そのシェイプに 3D カメラ、照明、またはベベル設定を適用してください。

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **効果的なテーブル書式の取得**

テーブルの書式設定は、テーブルスタイルおよびテーブル全体、列、行、個々のセルに適用された書式から取得されます。明示的に定義された塗りつぶしが競合する場合、優先順位はセル、行、列、そしてテーブル全体の順です。セルの効果的な書式は、そのセルを描画する際に使用される最終的な書式です。

この例では、`table-formatting.pptx` の最初のスライドに少なくとも 1 つのテーブルが含まれている必要があります。テーブルは少なくとも 1 行と 1 列を持っている必要があります。コードは、最初のシェイプがテーブルであると仮定する代わりに、[ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) を検索します。

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

塗りつぶしのタイプだけでなく色が必要な場合は、まず効果的な [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifillformateffectivedata/) を確認し、そのタイプに適用されるプロパティを読み取ります。たとえば、塗りつぶしが単色の場合は [SolidFillColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifillformateffectivedata/) を使用します。

## **変更後に効果的なデータを再読込**

効果的なデータは、解決時点での書式階層を示します。その階層に関与できるものを変更した後は、`GetEffective` を再度呼び出してください。対象は以下を含みます:
- オブジェクトのローカル書式；
- 段落またはテキストフレームのデフォルト；
- テーブルスタイル、テーブル、列、行、またはセルの書式；
- レイアウトまたはマスタースライドの書式；
- テーマデータまたはプレゼンテーションレベルのデフォルト；
- スライドに割り当てられたレイアウトまたはマスター；

効果的なデータオブジェクトを永続的なスナップショットとして保持しないでください。Aspose.Slides は内部でいくつかの効果的データをキャッシュする可能性があり、後で `GetEffective` を呼び出すとデータが更新されます。変更前後の値を比較する必要がある場合は、変更を加える前にフォントの高さ、色、配置、ベベル幅などのスカラー値を自分の変数にコピーしてください。

値を変更するには、適切なローカル書式オブジェクトを更新し、`GetEffective` を呼び出して結果を確認します。効果的なデータオブジェクト自体は読み取り専用です。

## **FAQ**

**どのレベルが効果的な値を提供したかを判断するには？**

効果的なデータは最終的な値を含んでおり、そのソースは示しません。最も具体的なレベルから外側へ、該当するローカルオブジェクトを調べます。テキストの場合、対象は部分、段落、テキストフレーム、レイアウト、マスター、テーマ、プレゼンテーションのデフォルトなどです。`std::numeric_limits<float>::quiet_NaN()` や `nullptr` のように未定義の値は、検索が別のレベルへ続くことを示しています。

**どのレベルでもプロパティが定義されていない場合はどうなりますか？**

Aspose.Slides は適切な PowerPoint またはライブラリのデフォルトを解決します。その解決された値は、ローカルオブジェクトが明示的に定義していなくても効果的なデータに表示されます。

**なぜ効果的な値がローカル値と同じになることがあるのですか？**

ローカル値が継承計算で勝ったためです。プロパティがオブジェクトに明示的に設定され、より具体的な規則で上書きされない場合にこのようになります。

**ローカルデータを使用すべき時と効果的データを使用すべき時はいつですか？**

特定の書式レベルを検査または編集する場合はローカルデータを使用します。継承、テーマ規則、適用可能なスタイルが解決された後の最終的な外観が必要な場合は効果的データを使用します。[完全な比較例](#compare-local-inherited-and-effective-values) は同じワークフローで両方を示しています。