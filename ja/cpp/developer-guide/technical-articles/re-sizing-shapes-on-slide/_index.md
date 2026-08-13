---
title: スライド上のシェイプのサイズ変更
type: docs
weight: 100
url: /ja/cpp/re-sizing-shapes-on-slide/
keywords:
- シェイプのリサイズ
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

Aspose.Slides for C++ の顧客から最もよくある質問のひとつは、スライドサイズが変更されたときにデータが切り取られないようにシェイプをリサイズする方法です。この短い技術記事では、その方法を示します。

## **シェイプのサイズ変更**

スライドサイズが変更された際にシェイプが位置ずれしないように、各シェイプの位置とサイズを新しいスライドレイアウトに合わせて更新します。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイルを読み込む。
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// 元のスライドサイズを取得。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 既存のシェイプをスケーリングせずにスライドサイズを変更。
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// 新しいスライドサイズを取得。
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// 各スライドのシェイプをリサイズおよび再配置。
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
            // シェイプのサイズをスケール。
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // シェイプの位置をスケール。
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
スライドにテーブルが含まれる場合、上記のコードは正しく機能しません。その場合、テーブルの各セルをサイズ変更する必要があります。
{{% /alert %}} 

テーブルを含むスライドのサイズを変更するには、以下のコードを使用してください。テーブルの場合、幅や高さを設定するのは特殊なケースであり、テーブル全体のサイズを変更するためには個々の行の高さと列の幅を調整する必要があります。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 元のスライドサイズを取得.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 既存のシェイプをスケールせずにスライドサイズを変更.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// 新しいスライドサイズを取得.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // シェイプのサイズをスケール.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // シェイプの位置をスケール.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // シェイプのサイズをスケール.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // シェイプの位置をスケール.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // シェイプのサイズをスケール.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // シェイプの位置をスケール.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **よくある質問**

### スライドのリサイズ後にシェイプが歪んだり切り取られたりするのはなぜですか？

スライドをリサイズすると、スケールが明示的に変更されていない限り、シェイプは元の位置とサイズを保持します。そのため、コンテンツが切り取られたりシェイプが位置ずれしたりすることがあります。

### 提供されたコードはすべてのシェイプタイプで機能しますか？

基本的な例はほとんどのシェイプタイプ（テキストボックス、画像、チャートなど）で機能します。ただし、テーブルの場合は、テーブルの高さと幅が個々のセルのサイズで決まるため、行と列を別々に処理する必要があります。

### スライドをリサイズする際にテーブルのサイズを変更するにはどうすればよいですか？

テーブルのすべての行と列をループし、二番目のコード例に示すように高さと幅を比例的にリサイズする必要があります。

### このリサイズはマスタースライドやレイアウトスライドでも機能しますか？

はい、ただし、[Masters](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_masters/) と [Layout slides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_layoutslides/) もループし、同じスケーリングロジックをそれらのシェイプに適用して、プレゼンテーション全体の一貫性を確保する必要があります。

### リサイズと同時にスライドの向き（縦/横）を変更できますか？

はい。[presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidesize/set_orientation/) を使用して向きを変更できます。レイアウトを維持するために、スケーリングロジックをそれに合わせて設定してください。

### 設定できるスライドサイズに制限はありますか？

Aspose.Slides はカスタムサイズをサポートしていますが、非常に大きなサイズはパフォーマンスや PowerPoint の一部バージョンとの互換性に影響を与える可能性があります。

### 固定アスペクト比のシェイプが歪むのを防ぐには？

`get_AspectRatioLocked` メソッドでシェイプの固定アスペクト比がロックされているか確認できます。ロックされている場合は、幅や高さを個別にスケーリングするのではなく、比例的に調整してください。