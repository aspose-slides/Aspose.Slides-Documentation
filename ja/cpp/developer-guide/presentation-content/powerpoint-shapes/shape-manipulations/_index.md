---
title: C++ でプレゼンテーションの図形を管理する
linktitle: 図形操作
type: docs
weight: 40
url: /ja/cpp/shape-manipulations/
keywords:
- PowerPoint の図形
- プレゼンテーションの図形
- スライド上の図形
- 図形の検索
- 図形のクローン作成
- 図形の削除
- 図形の非表示
- 図形の順序変更
- Interop 図形 ID の取得
- 図形の代替テキスト
- 図形の調整ポイント
- プリセット図形の調整
- 図形ジオメトリ
- 図形レイアウト書式
- SVG 形式の図形
- 図形を SVG に変換
- 図形の配置
- 図形のフリップ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、プレゼンテーションの図形を特定、調整、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップする方法を学びます。"
---
## **概要**

Aspose.Slides for C++ は、スライド上の図形を順序付けられた [IShapeCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/) として表します。このコレクションは、図形を検索・変更する場所であると同時に、スタック順序のソースでもあります。インデックス `0` が最背面の図形で、最後のインデックスが最前面の図形です。

本記事はこのモデルに従います。まず図形を確実に特定し、プリセットの調整ポイントを変更する方法を説明し、次に図形のクローン作成、削除、非表示、順序変更の手順を示します。最後のセクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定について解説します。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **図形の特定と検索**

コレクションインデックスは既知のファイルを処理するときに便利ですが、安定した識別子ではありません。図形の追加・削除・順序変更によりインデックスは変わります。プレゼンテーションの作成・管理方法に応じて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_name/) は開発者が管理するテンプレートに有用で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能で一意である保証はないため、コードが名前に依存する場合は命名規則を設けてください。
- [AlternativeText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_alternativetext/) は、アクセシビリティ用の説明や作者が付与したタグで既に図形を識別できる場合に有用です。ユーザーに見えるためローカライズやアクセシビリティ用に書き換えられることがあり、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして静かに再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_officeinteropshapeid/) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint Interop が使用する形状 ID に対応します。PowerPoint 連携や、図形の存続期間中に曖昧でない参照が必要なときに使用してください。クローンまたは再作成された図形は別の図形となり、別の ID が付与されます。

関連する [UniqueId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_uniqueid/) プロパティはプレゼンテーション全体で有効ですが、アドイン向けで再割り当て可能です。永続的な外部キーとして扱うべきではありません。長期的な同一性が必要な場合は、アプリケーションデータにマッピングを保持し、期待する図形がまだ存在するか検証してください。

以下の例は `Name` で検索し、スライドスコープの Interop ID を報告します。テンプレートに期待した図形が存在しない場合、コードはその結果を報告し、誤ったオブジェクトで処理を続行しません。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

操作が特定の図形タイプに限定される場合は、型固有メンバーを使用する前にインターフェイスを確認してください。この例は、名前付きオブジェクトが [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) である場合にのみテキストと代替テキストを更新します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **プリセット図形調整の特定と変更**

プリセットジオメトリ図形は、コーナーサイズ、矢印の比率、円弧角度などを制御する調整ポイントを公開することがあります。これらは読み取り専用の [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igeometryshape/get_adjustments/) コレクションを介して取得します。コレクション自体は図形が提供しますが、各 [IAdjustValue](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iadjustvalue/) が変更可能な値を保持しています。

固定インデックスのみに依存しないでください。調整項目を列挙し、読み取り専用の [IAdjustValue::get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iadjustvalue/get_type/) プロパティを確認します。このプロパティの [ShapeAdjustmentType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapeadjustmenttype/) 値が、調整が何を制御するかを示します。読み取り専用の [IAdjustValue::get_Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iadjustvalue/get_name/) プロパティは追加の識別情報を提供し、同じセマンティックタイプの調整が複数ある場合に特に有用です。

調整の意味に合った値プロパティを使用してください。

| 調整タイプ | 用途 | 変更する値 |
|---|---|---|
| `CornerSize` | 丸めコーナーのサイズ | [RawValue](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | 矢尻の太さ | `RawValue` |
| `ArrowheadLength` | 矢尻の長さ | `RawValue` |
| `ArrowheadWidth` | 矢尻の幅 | `RawValue` |
| `StartAngle` | 円弧または扇形の開始角度 | [AngleValue](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | 円弧または扇形の終了角度 | `AngleValue` |

`Type` と `Name` は代入できません。`RawValue` はプリセット固有のジオメトリ単位の読み書き可能な整数で、`AngleValue` は度単位の読み書き可能な角度です。調整の数・順序・意味・有効範囲はプリセットの [ShapeType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igeometryshape/get_shapetype/) に依存します。あるプリセットで有効な値が別のプリセットでは無効、あるいは別の効果を持つことがあります。

`Type` が `ShapeAdjustmentType::Custom` の場合、API は標準的な意味を認識しません。`Name`、プリセットタイプ、既存の値を確認し、期待する意味と範囲が分からない限り調整は変更しないでください。認識できるタイプであっても、同じタイプが複数回出現するか確認してから値を選択します。コネクタの曲げ調整に関する例は [Connector](/slides/ja/cpp/connector/) 記事をご覧ください。

以下の完全な例は、3 つのプリセット図形のデフォルト版と変更版を作成します。すべての調整を列挙し、`Name` と `Type` を報告し、サイズ関連の値は `RawValue`、角度は `AngleValue` で変更し、結果を保存します。左列はデフォルトジオメトリ、右列は調整された角丸矩形、四方向矢印、円弧です。

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// デフォルトと調整済みの図形列のヘッダーを追加します。
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

値を変更する前にセマンティックタイプを確認すると、コードの意図が明確になり、異なるプリセット図形間で同じインデックスが同じ意味を持つと仮定するリスクを回避できます。

## **図形コレクションの変更**

追加、クローン、削除、再順序付けメソッドはコレクションに即座に作用します。操作により図形の数や順序が変わった場合、操作前に取得したインデックスに依存し続けないでください。

### **図形のクローン作成**

[AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addclone/) は独立したコピーを作成し、対象コレクションの末尾に追加します。[InsertClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/insertclone/) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標のみを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはリサイズも可能です。

以下の例は、宛先スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入します。どちらのクローンを変更しても元の図形には影響しません。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

クローンは図形の内容と書式、名前、代替テキストをコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複雑な図形が使用するリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目として新しい図形 ID を持ちます。

### **図形の削除**

[Remove](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/remove/) は特定の図形オブジェクトをそのコレクションから削除します。インデックス付き反復中に複数の一致を削除する場合は、後方から走査して残りのインデックスが有効なままになるようにしてください。

この例は、指定された名前を持つすべての図形を削除します。固定のコレクション項目ではなく、現在のインデックス付き図形を取得し、不要なキャストも行っていません。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

削除後、図形数と後続のインデックスは変化します。影響を受けない図形への参照は、保存したインデックスよりも信頼性が高くなります。また、コネクタ、アニメーション、その他のプレゼンテーション機能が削除対象オブジェクトを参照している可能性があることに留意してください。可視図形を削除すると、スライドの見た目以外にも影響が及ぶことがあります。

### **図形の非表示**

[Hidden](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/set_hidden/) を `true` に設定すると、図形はコレクションに残りますが、通常のスライドショーには表示されません。インデックス、書式、内容はコードから引き続き利用可能なので、後で復元できるオプション要素に適しています。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

非表示は削除やセキュリティではありません。ユーザーやコードによって再度発見・非表示解除が可能で、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合う図形はコレクション順に描画されます。[Reorder](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/reorder/) は既存の図形をクローンせずに対象インデックスへ移動します。インデックス `0` が背面、`Count - 1` が前面です。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

矩形は最初に作成され、最初は楕円の背面に配置されています。最終インデックスへ移動すると前面に来ます。関連図形をすべて追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順序を変更する可能性があります。

## **レイアウトスライド上の図形の検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別の図形コレクションを持ちます。レイアウトコレクション内の図形は、同じ位置にある通常スライド上の図形とは別オブジェクトです。レイアウトが提供する書式を理解・変更する必要があるときは、レイアウト図形を検査してください。

以下の例は、各レイアウト図形の [FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_fillformat/) と [LineFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_lineformat/) を、すべてが `AutoShape` であると仮定せずに読み取ります。

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響が及びます。レイアウト図形を変更する前に、通常スライドがそのオブジェクトを継承しているかローカルに上書きしているかを判断し、該当レイアウトを使用しているすべてのスライドでテストしてください。

## **図形を SVG へエクスポート**

[WriteAsSvg](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/writeassvg/) は、1 つの図形のレンダリング結果をストリームに書き込みます。出力には図形そのものだけが含まれ、スライド全体の背景や隣接図形は含まれません。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

レンダリング中はプレゼンテーションを開いたままにしてください。出力は図形の書式設定やフォント・画像などのリソースに依存します。全体の構成が必要な場合は、個別図形ではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、クローズまたは破棄する必要があります。

## **図形の配置**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/alignshapes/) のオーバーロードは、すべての図形または選択したコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapesalignmenttype/) はエッジ、中心線、または配置モードを指定します。`alignToSlide` を `true` に設定するとスライドのエッジに合わせ、`false` に設定すると選択図形同士の相対位置で整列します。

この例は、3 つの図形をスライド上部エッジに揃えます。返された図形参照は、整列直前に現在のインデックスへ変換されます。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

整列は位置を変更しますが、Z オーダーは変わりません。相対整列は通常少なくとも 2 つの図形が必要で、水平または垂直の等間隔配置には間隔を定義できるだけの図形が必要です。メソッド呼び出し前にコレクションを変更した場合は、インデックスを再計算してください。

## **図形のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `FlipH` と `FlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/cpp/aspose.slides/nullablebool/) を使用し、`True` がフリップを有効、`False` が無効、`NotDefined` が未指定/デフォルト状態を保持します。

以下の入力プレゼンテーションには、フリップされていない図形が 1 つ含まれています。

![フリップ前の図形](shape_to_be_flipped.png)

この例は、他のフレーム値はすべて保持し、フリップ設定の 2 つだけを置き換えます。新しい [Frame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/set_frame/) を割り当てるとフレーム全体が置き換えられるため、重要なポイントです。

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

保存された図形は水平・垂直に鏡像化されますが、位置・サイズ・回転はそのままです。

![フリップ後の図形](flipped_shape.png)

## **FAQ**

**コレクションインデックスを図形の識別子として使用すべきですか？**

コレクションが操作中に変わらない短期間の処理に限り使用できます。作成されたテンプレートでは検証済みの `Name` や `AlternativeText` の規約を、スライドスコープの Interop 作業では `OfficeInteropShapeId` を推奨します。

**図形を非表示にすると Z オーダーから除外されますか？**

いいえ。非表示の図形は同じインデックスでコレクションに残り、検索、再順序付け、編集、再表示が可能です。

**クローンした図形が別の図形の前に表示されたのはなぜですか？**

`AddClone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z オーダーの前面になるためです。初期インデックスを指定したい場合は `InsertClone` を、すべての図形追加後に位置を調整したい場合は `Reorder` を使用してください。

**プリセット図形の調整項目を固定インデックスで識別してもよいですか？**

正確なプリセットとコレクション構成を検証した場合に限り可能です。`IGeometryShape::get_Adjustments` を列挙し、`IAdjustValue::get_Type` を確認する方法を推奨します。同一のセマンティックタイプが複数出現する場合は、追加情報として `IAdjustValue::get_Name` を利用してください。