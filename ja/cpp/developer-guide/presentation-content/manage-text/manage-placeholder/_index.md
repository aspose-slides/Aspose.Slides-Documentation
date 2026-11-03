---
title: C++ でプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーを管理する
type: docs
weight: 10
url: /ja/cpp/manage-placeholder/
keywords:
- プレースホルダー
- テキスト プレースホルダー
- 画像 プレースホルダー
- グラフ プレースホルダー
- コンテンツ プレースホルダー
- プロンプト テキスト
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、テキスト、画像、グラフ、コンテンツのプレースホルダーを検査および編集し、プレースホルダーの継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。代表的な例として、タイトル、本文、画像、グラフ、汎用コンテンツのプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides は、[IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) メソッドを通じてプレースホルダー情報を公開します。このメソッドは通常のシェイプに対しては `nullptr` を返す [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) オブジェクトを返します。プレースホルダーが何を保持することを想定しているかは、[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) で確認してください。

プレースホルダーの種類が分かっても、シェイプ インターフェイスは依然として重要です。

- 空のテキスト、画像、グラフ、またはコンテンツ プレースホルダーは、一般に [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) で表されます。
- 内容が設定された画像プレースホルダーは、[IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) で表されます。
- 内容が設定されたグラフプレースホルダーは、[IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) で表されます。
- コンテンツ プレースホルダーは複数の種類のコンテンツを保持できます。[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) とランタイムのシェイプ インターフェイスの両方を確認し、すべてのプレースホルダーが [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) であると想定しないでください。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) はプレースホルダーの役割を示しますが、シェイプのランタイム型を保証するものではありません。テキスト、画像、グラフ、テーブル、メディア固有のメンバーにアクセスする前に、必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダー 継承の理解**

プレースホルダーは階層を形成します。

1. マスタースライドは再利用可能なスタイルと、場合によってはマスターレベルのプレースホルダーを定義します。
2. レイアウトスライドは 1 つ以上の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承できます。

[IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) を呼び出すと、この階層で 1 つ上のレベルに移動します。スライドのプレースホルダーは通常、レイアウトのプレースホルダーを返し、レイアウトのプレースホルダーはマスターのプレースホルダーを返すことができます。シェイプに基底プレースホルダーがない場合、メソッドは `nullptr` を返します。

以下の例は、最初のスライド上のプレースホルダーを列挙し、それらの基底プレースホルダーを報告します：

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

通常スライド上のプレースホルダーを編集すると、そのスライド用のローカル オーバーライドが作成または変更されます。関連するレイアウトやマスターを編集すると、まだその設定を継承しているすべてのスライドに影響が及びます。ローカルの通常シェイプは基底プレースホルダーを持たず、同じ座標に配置されているだけで継承が始まるわけではありません。

## **プレースホルダー ステータスの削除**

テンプレートを変更する際は、[IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) を使用して、既存のオブジェクトを普通のシェイプとして残します。その [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) メソッドは `nullptr` を返しますが、シェイプはスライドのコレクションに残ります。これに対し、[IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) はコレクションからシェイプ自体を削除します。

以下の例は、最初のスライドに少なくとも 1 枚のスライドと空でないテキスト プレースホルダーがある `template.pptx` を前提としています。レイアウトまたはマスターから継承された書式設定を持つプレースホルダーを使用して、関係を削除したときの影響を確認してください。例は同じシェイプが残っていることを確認し、普通のシェイプになった後にメソッドを再度呼び出し、結果を保存します。

{{% alert color="warning" title="Warning" %}}
プレースホルダー ステータスを削除しても、継承された外観設定が自動的に保持されるわけではありません。下の例は意図的にこれらの設定を変更せずに残しているため、出力が異なる見た目になる可能性があります。位置とサイズが完全に継承されていたシェイプは、呼び出し後に座標と寸法が 0 になることがあり、コレクション内に残っていても見えなくなることがあります。
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // 普通のシェイプに対してメソッドを呼び出しても効果はありません。
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

一致するプレースホルダーについては、3 つのチェックすべてが `True` を出力します。テキストは残りますが、位置、サイズ、回転、フォント、段落の配置、テキストフレームの余白、垂直アンカー、塗りつぶし、線の設定などの継承された属性は、プレースホルダー関係が削除されると変わる可能性があります。たとえば、継承されたタイトル書式は通常のテキスト書式に戻ります。レイアウトの詳細については [Slide Layout](/slides/ja/cpp/slide-layout/) を参照してください。

意図した外観を維持するには、呼び出し前に解決済みの位置、サイズ、回転を取得し、必要な有効書式値を別々の変数にコピーします。これらの値は、[IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/)、[IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/)、[ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/)、[IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/)、[ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) で取得できます。有効書式オブジェクトだけに依存しないでください。関係を削除した後にテキスト書式の値が変わる可能性があります。取得した値を普通のシェイプに明示的に適用し、フォントファミリ、サイズ、スタイル、色、段落設定、テキストフレーム設定、塗りつぶし、線をテンプレートと同じように設定します。

継承されたシェイプのジオメトリも、[IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/) を使用して明示的に割り当てる必要がある場合があります。矩形テキスト プレースホルダーの場合、[ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) を設定することを意味します。塗りつぶしと線だけを復元しても、視覚的な矩形が復元されないことがあります。追加のエフェクトや複雑な書式設定を持つテンプレートでは、これらの設定も同様に処理する必要があります。

## **プレースホルダー内のテキスト変更**

タイトル、センタリングタイトル、サブタイトル、本文、テキスト プレースホルダーは通常テキストをサポートします。使用する前に [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) かどうかを確認し、[get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) メソッドを使用してください。

この例は、最初のスライド上の最初のタイトル プレースホルダーを更新し、結果を保存します：

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

このパターンは、画像、グラフ、テーブル、メディア プレースホルダーを [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) にキャストすることを回避します。また、脆弱なシェイプインデックスに依存せず、目的でプレースホルダーを特定します。

## **レイアウト上のプロンプトテキスト設定**

プロンプトテキストは、空のプレースホルダーに表示されるデザイン時の指示で、例として *Click to add title* があります。通常スライドのシェイプコレクションを介さずに、レイアウト プレースホルダーにカスタム プロンプトテキストを設定してください。[ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) でレイアウトにアクセスし、[IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/) を反復処理します。

以下の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します：

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

プロンプトテキストは通常スライドのコンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに表示される指示です。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、レイアウトを使用しているスライド上の既存テキストは置き換わりません。

## **画像 プレースホルダーの更新**

処理すべきケースは 2 つあります。

- 画像プレースホルダーがすでに内容を持ち、[IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) で表されている場合は、[IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) と [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) を使って画像を置き換えます。
- まだ空のプレースホルダーである場合は、[IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースに対応し、プレゼンテーションを保存します：

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

空のプレースホルダーに対して作成された置き換えはローカル 画像フレームであり、新しいプレースホルダーではありません。これは [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) が読み取り専用であるためです。位置は保持されますが、プレースホルダー固有の振る舞いは継承されなくなります。プレースホルダー関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを作成・設定し、Aspose.Slides で生成された [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) を更新してください。

画像の透明度、トリミング、その他画像固有の効果については、[Manage Picture Frames](/slides/ja/cpp/picture-frame/) を参照してください。これらの操作はプレースホルダーのメタデータではなく、画像フレームまたは画像塗りつぶしに対して行われます。

## **グラフおよびコンテンツ プレースホルダーの操作**

内容が設定されたグラフ プレースホルダーは、[IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) で表されます。この例は、プレースホルダーの種類とランタイム インターフェイスの両方でグラフを検索し、タイトルを変更してファイルを保存します：

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

汎用コンテンツ プレースホルダーは通常 [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) を持ちます。PowerPoint では、グラフ、テーブル、ダイアグラム、画像、メディアなど複数のコンテンツタイプのランチャーとして機能します。内容が設定された後は、実際のシェイプ インターフェイスを調べて何が含まれているかを判断してください。特化したレイアウトは、[PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) を公開することもあります。

Aspose.Slides は、[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) を変更するだけで、空の [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) プレースホルダーを [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) に変換しません。型は読み取り専用です。空のグラフやコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。以下の例は、グラフに対してこれを実行します：

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

追加されたグラフは普通のローカル グラフです。プレースホルダーの領域を占有しますが、レイアウト プレースホルダーから継承はしません。カテゴリ、系列、ブックデータの置き換えが必要な場合は、専用の [chart management articles](/slides/ja/cpp/powerpoint-charts/) を使用してください。

## **完全なサンプル: テキストまたは画像コンテンツの更新**

以下のエンドツーエンド例は、テンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプの型を確認して適切なコンテンツを更新し、結果を保存します。この例はシェイプインデックスに依存したり、すべてのプレースホルダーを同じインターフェイスにキャストしたりすることを意図的に回避しています。

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ベース プレースホルダーとは何ですか？**

ベース プレースホルダーは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応するシェイプです。取得するには [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) を使用します。通常のローカル シェイプはプレースホルダー階層の一部ではないため `nullptr` を返します。

**レイアウト プレースホルダーを編集してすべてのスライド タイトルを変更できますか？**

レイアウトを通じて継承された書式設定やプロンプトテキストは変更できますが、実際のタイトルコンテンツは通常スライドに保存されています。プレゼンテーション全体のタイトルテキストを置き換えるには、スライドを走査して各タイトル プレースホルダーを更新する必要があります。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどのように管理しますか？**

適切なスライド、レイアウト、マスター、ノート、配布資料のスコープでヘッダーおよびフッターマネージャーを使用してください。完全な例については [Manage Presentation Header and Footer](/slides/ja/cpp/presentation-header-and-footer/) を参照してください。