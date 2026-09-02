---
title: C++でプレゼンテーションの図形を管理する
linktitle: 図形操作
type: docs
weight: 40
url: /ja/cpp/shape-manipulations/
keywords:
- PowerPoint 図形
- プレゼンテーション図形
- スライド上の図形
- 図形の検索
- 図形のクローン作成
- 図形の削除
- 図形の非表示
- 図形の順序変更
- Interop 図形 ID の取得
- 図形の代替テキスト
- 図形のレイアウト書式
- SVG としての図形
- 図形を SVG に変換
- 図形の整列
- 図形のフリップ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、プレゼンテーションの図形を識別、クローン、削除、非表示、再配置、エクスポート、整列、フリップする方法を学びます。"
---
## **概要**

Aspose.Slides for C++ は、スライド上の図形を順序付けられた [IShapeCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/) として表します。コレクションは図形を検索・変更する場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面の図形で、最後のインデックスが最前面の図形です。

このドキュメントはそのモデルに従います。まず図形を確実に特定する方法を説明し、次に図形のクローン作成、削除、非表示、順序変更の方法を示します。最終セクションではレイアウトレベルの書式設定、SVG へのエクスポート、整列、フリップ設定を取り上げます。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **図形の識別と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。図形の追加、削除、順序変更によりインデックスは変わります。プレゼンテーションの作成方法や保守方法に合わせて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_name/) は開発者が管理するテンプレートに便利で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能で一意性は保証されないため、コードが名前に依存する場合は命名規則を定めてください。
- [AlternativeText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_alternativetext/) は、アクセシビリティの説明や作者が付与したタグで図形が既に識別されているときに有用です。ユーザーに表示され、ローカライズやアクセシビリティ向上のために書き換えられる可能性があり、一意であるとは限りません。意味のあるアクセシビリティテキストをデータベースキーとして安易に再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_officeinteropshapeid/) は読み取り専用の識別子で、スライド内で一意であり PowerPoint の Interop が使用する shape ID に対応しています。PowerPoint との連携や、図形の存続期間中に曖昧でない参照が必要な場合に使用します。クローンまたは再生成された図形は別の図形となり、独自の ID が付与されます。

関連する [UniqueId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_uniqueid/) プロパティはプレゼンテーション全体で一意ですが、アドイン向けに意図されており再割り当て可能です。永続的な外部キーとして扱うべきではありません。長期的な同一性が重要な場合は、アプリケーションデータにマッピングを保持し、期待する図形が依然として存在するか検証してください。

以下の例は `Name` で検索し、スライドスコープの Interop ID を報告します。テンプレートに期待する図形が存在しない場合、コードはその結果を報告し、誤ったオブジェクトで続行しません。

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

## **図形コレクションの操作**

追加、クローン、削除、順序変更のメソッドはコレクションに即座に反映されます。操作により図形数や順序が変わった場合、操作前に取得したインデックスに依存し続けないでください。

### **図形のクローン作成**

[AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addclone/) は独立したコピーを作成し、対象コレクションの末尾に追加します。[InsertClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/insertclone/) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標のみを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅・高さを受け取るオーバーロードはリサイズも可能です。

この例は目的スライドを作成し、ラベル付き矩形を前面にクローンし、別のクローンを背面に挿入します。どちらのクローンに対する変更も元の図形を変更しません。

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

[Remove](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/remove/) は特定の図形オブジェクトをそのコレクションから削除します。インデックス付きイテレーション中に複数の一致を削除する場合は、残りのインデックスが有効なままになるように末尾から走査してください。

この例は指定された名前を持つすべての図形を削除します。固定のコレクション項目ではなく現在のインデックス付き図形を取得し、不要なキャストも行っていません。

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

削除後は図形数と後続のインデックスが変わります。影響を受けない図形への参照は保存したインデックスより信頼性が高くなります。また、コネクタやアニメーションなど、削除対象オブジェクトを参照しているプレゼンテーション機能も考慮してください。可視図形を削除するとスライドの外観以上の変更が生じることがあります。

### **図形の非表示**

[Hidden](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/set_hidden/) を `true` に設定すると、図形はコレクション内に残りますが通常のスライドショーには表示されません。インデックス、書式、コンテンツはコードから引き続き利用可能なため、後で復元できるオプション要素に対して非表示は適切です。

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

非表示は削除でもセキュリティでもありません。オブジェクトはユーザーやコードによって再度発見・表示解除でき、プレゼンテーションファイルの一部として残ります。

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

矩形は最初に作成され、最初は楕円の背面に配置されます。最終インデックスへ移動すると前面に来ます。すべての関連図形を追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を末尾または指定位置に挿入し、意図したスタックを変更する可能性があります。

## **レイアウトスライド上の図形を検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別々の図形コレクションを持ちます。レイアウトコレクションの図形は、同じ位置にある通常スライドの図形と同一オブジェクトではありません。レイアウトが提供する書式を理解または変更する必要がある場合は、レイアウト図形を検査してください。

以下の例は、各レイアウト図形の [FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_fillformat/) と [LineFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_lineformat/) を取得します。すべての図形が `AutoShape` であると仮定してはいません。

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

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響が及びます。レイアウト図形を変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを判断し、レイアウトを使用しているすべてのスライドでテストしてください。

## **図形を SVG にエクスポート**

[WriteAsSvg](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/writeassvg/) は単一図形の描画内容をストリームに書き出します。結果にはその図形のみが含まれ、スライド全体の背景や隣接図形は含まれません。

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

レンダリング中はプレゼンテーションを開いたままにしてください。出力は図形の書式設定とフォントや画像といったリソースに依存します。全体構成が必要な場合は個別図形ではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、閉じるまたは破棄する必要があります。

## **図形の整列**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/alignshapes/) のオーバーロードは、すべての図形または選択されたコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapesalignmenttype/) はエッジ、中心線、または分布モードを指定します。`alignToSlide` を `true` に設定するとスライドのエッジに合わせ、`false` にすると選択図形同士の相対位置に合わせます。

この例は 3 つの図形をスライドの上端に整列させます。返された図形参照は整列直前に現在のインデックスへ変換されます。

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

整列は位置を変更しますが Z オーダー は変わりません。相対整列は通常最低 2 つの図形が必要で、水平または垂直の分布には間隔を定義できるだけの図形が必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **図形のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `FlipH` と `FlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/cpp/aspose.slides/nullablebool/) を使用し、`True` でフリップ有効、`False` で無効、`NotDefined` で未指定/デフォルト状態を保持します。

以下の入力プレゼンテーションはフリップされていない図形を 1 つ含みます。

![The shape before flipping](shape_to_be_flipped.png)

この例は他のすべてのフレーム値は保持し、フリップ設定のみを置き換えます。これは新しい [Frame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/set_frame/) を割り当てるとフレーム全体が置き換わるため重要です。

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

保存された図形は水平・垂直に鏡像化されますが、位置、サイズ、回転はそのままです。

![The shape after flipping](flipped_shape.png)

## **FAQ**

**コレクションインデックスを図形の識別子として使用すべきですか？**

短時間の処理でコレクションが変更されないことが確実な場合にのみ使用してください。テンプレートが作者管理の場合は検証済みの `Name` または `AlternativeText` を、スライドスコープの Interop 作業の場合は `OfficeInteropShapeId` を推奨します。

**図形を非表示にすると Z オーダーから除外されますか？**

いいえ。非表示の図形は同じインデックスでコレクションに残り、検索、順序変更、編集、再表示が可能です。

**クローンした図形が別の図形の前面に現れたのはなぜですか？**

`AddClone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z オーダーの前面です。初期インデックスを指定したい場合は `InsertClone` を使用するか、すべての図形を追加した後に `Reorder` で位置を調整してください。