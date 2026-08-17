---
title: C++ でプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーの管理
type: docs
weight: 10
url: /ja/cpp/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- チャートプレースホルダー
- コンテンツプレースホルダー
- プロンプトテキスト
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、テキスト、画像、チャート、コンテンツ プレースホルダーを検査・編集し、プレースホルダーの継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保する図形です。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツのプレースホルダーがあります。普通の図形とは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides はプレースホルダー情報を [IShape::get_Placeholder](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_placeholder/) メソッドで公開します。このメソッドは [IPlaceholder](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iplaceholder/) オブジェクトを返すか、通常の図形の場合は `nullptr` を返します。プレースホルダーが何を保持することを意図しているかは [IPlaceholder::get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iplaceholder/get_type/) で判定します。

プレースホルダーの種類が分かった後でも、図形インターフェイスは依然として重要です。

- 空のテキスト、画像、チャート、またはコンテンツプレースホルダーは通常、[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) で表されます。
- 内容が設定された画像プレースホルダーは [IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) で表されます。
- 内容が設定されたチャートプレースホルダーは [IChart](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/) で表されます。
- コンテンツプレースホルダーはさまざまな種類のコンテンツを保持できます。すべてのプレースホルダーが [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) であると仮定せず、[IPlaceholder::get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iplaceholder/get_type/) と実行時の図形インターフェイスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iplaceholder/get_type/) はプレースホルダーの役割を示しますが、図形の実行時型を保証するものではありません。テキスト、画像、チャート、テーブル、メディア固有のメンバーにアクセスする前に、必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダーの継承を理解する**

プレースホルダーは階層構造を持ちます。

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスターレベルのプレースホルダーも定義します。
2. レイアウトスライドは 1 つまたは複数の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承できます。

この階層を上に 1 レベル移動するには [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/getbaseplaceholder/) を呼び出します。スライドのプレースホルダーは通常、レイアウトプレースホルダーを返し、レイアウトプレースホルダーはマスタープレースホルダーを返すことがあります。図形に基底プレースホルダーが存在しない場合は `nullptr` が返ります。

以下の例は、最初のスライド上のプレースホルダーを列挙し、それらの基底プレースホルダーを報告します。

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

通常スライド上でプレースホルダーを編集すると、そのスライドだけのローカル上書きが作成または変更されます。関連するレイアウトやマスターを編集すると、まだその設定を継承しているすべてのスライドに影響を与えます。ローカルの普通の図形は基底プレースホルダーを持たず、同じ座標にあるからといって継承が開始されるわけではありません。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングタイトル、サブタイトル、本文、テキストプレースホルダーは通常テキストをサポートします。`[IAutoShape]` かどうかを確認し、`[get_TextFrame]` メソッドを使用してください。

この例は、最初のスライド上の最初のタイトルプレースホルダーを更新し、結果を保存します。

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

このパターンは画像、チャート、テーブル、メディアプレースホルダーを `[IAutoShape]` にキャストすることを防ぎます。また、脆弱な図形インデックスに依存せず、目的でプレースホルダーを特定します。

## **レイアウト上でプロンプトテキストを設定する**

プロンプトテキストは、空のプレースホルダーに表示されるデザイン時の指示で、例として「クリックしてタイトルを追加」などがあります。通常スライドの図形コレクションを介さずに、レイアウトプレースホルダーにカスタムプロンプトテキストを設定してください。レイアウトは `[ISlide::get_LayoutSlide]` で取得し、`[IBaseSlide::get_Shapes]` を列挙します。

以下の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します。

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

プロンプトテキストは通常スライドのコンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに対して表示されます。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。また、プロンプトを変更しても、そのレイアウトを使用しているスライド上の既存テキストは置き換わりません。

## **画像プレースホルダーを更新する**

対処すべきケースは 2 つあります。

- 画像プレースホルダーがすでに設定されていて `[IPictureFrame]` で表されている場合、`[IPictureFillFormat::get_Picture]` と `[ISlidesPicture::set_Image]` を使って画像を置き換えます。
- まだ空のプレースホルダーである場合、`[IShapeCollection::AddPictureFrame]` でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースに対応し、プレゼンテーションを保存します。

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

空のプレースホルダー用に作成された置き換えはローカル画像フレームであり、新しいプレースホルダーではありません。`[IShape::get_Placeholder]` が読み取り専用であるためです。位置は保持されますが、プレースホルダー固有の継承動作は失われます。プレースホルダーとの関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを用意してから、Aspose.Slides で生成された `[IPictureFrame]` を更新してください。

画像の透明度、トリミング、その他画像固有の効果については、[Manage Picture Frames](/slides/ja/cpp/picture-frame/) を参照してください。これらの操作は画像フレームまたは画像フィルに対して行い、プレースホルダーのメタデータには関係しません。

## **チャートおよびコンテンツプレースホルダーの操作**

設定済みのチャートプレースホルダーは `[IChart]` で表されます。この例はプレースホルダーのタイプと実行時インターフェイスの両方でチャートを見つけ、タイトルを変更してファイルを保存します。

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

一般的なコンテンツプレースホルダーは通常 `[PlaceholderType::Object]` を持ちます。PowerPoint ではチャート、テーブル、ダイアグラム、画像、メディアなど複数のコンテンツタイプの起動点として機能します。内容が設定された後は、実際の図形インターフェイスを調べて何が含まれているかを判断してください。特化したレイアウトは `[PlaceholderType::Chart]`、`[PlaceholderType::Table]`、`[PlaceholderType::Picture]`、`[PlaceholderType::Media]`、`[PlaceholderType::Diagram]` を公開することもあります。

Aspose.Slides は空の `[IAutoShape]` プレースホルダーを `[IChart]` に単に `[IPlaceholder::get_Type]` を変更しただけで変換しません。タイプは読み取り専用です。空のチャートやコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。以下の例はチャートに対してそれを実行します。

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

追加されたチャートは普通のローカルチャートです。プレースホルダーの領域を占有しますが、レイアウトプレースホルダーからは継承しません。カテゴリ、系列、ブックデータの置き換えが必要な場合は、専用の [chart management articles](/slides/ja/cpp/powerpoint-charts/) を参照してください。

## **完全な例: テキストまたは画像コンテンツの更新**

以下のエンドツーエンド例はテンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーと図形のタイプを確認して適切なコンテンツを更新し、出力を保存します。この例は図形インデックスに依存したり、すべてのプレースホルダーを同一インターフェイスにキャストしたりしないよう意図的に設計されています。

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

**基底プレースホルダーとは何ですか？**

基底プレースホルダーは、レイアウトまたはマスター上の対応する図形で、別のプレースホルダーが継承する元となります。`[IShape::GetBasePlaceholder]` を使用して取得します。普通のローカル図形はプレースホルダー階層の一部ではないため `nullptr` を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを介して継承された書式設定やプロンプトテキストは変更できますが、既存のタイトルコンテンツは普通のスライドに保存されています。プレゼンテーション全体のタイトルテキストを置き換えるには、スライドを列挙し各タイトルプレースホルダーを個別に更新する必要があります。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどう管理しますか？**

対象となるスライド、レイアウト、マスター、ノート、ハンドアウトのスコープでヘッダーおよびフッターマネージャーを使用します。完全な例は [Manage Presentation Header and Footer](/slides/ja/cpp/presentation-header-and-footer/) を参照してください。