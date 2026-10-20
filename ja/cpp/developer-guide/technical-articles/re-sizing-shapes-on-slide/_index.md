---
title: C++ のプレゼンテーション スライド上で形状をリサイズする
type: docs
weight: 130
url: /ja/cpp/resizing-shapes-on-slide/
aliases:
  - /ja/cpp/re-sizing-shapes-on-slide/
  /cpp/re-sizing-shapes-on-slide/
keywords:
  - 形状のリサイズ
  - 形状のサイズ変更
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - C++
  - Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のスライド上の形状を簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、形状を新しいサイズに合わせてリサイズおよび再配置する必要がある場合があります。本記事では、形状を手動でスケーリングする方法と、スライド、マスター、レイアウト上のテーブルを処理する方法を示します。

## **形状のリサイズ**

各形状の相対的な位置とサイズを保つには、水平座標と幅を新しいスライド幅と元の幅の比率で乗算します。垂直座標と高さには対応する高さの比率を適用します。

最初の例は、テーブルを含まないスライドを持つプレゼンテーションを読み込み、スライドサイズをA4に変更し、結果を保存します。これは[SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) と[SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) を使用し、後続のループでスケーリングを制御します。比率は単位なしで、形状の位置とサイズはポイントで測定されます。幅と高さの比率が異なると形状が歪み、形状のサイズを変更してもフォントサイズはスケールされません。

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

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
テーブルは別途処理が必要です。テーブル全体の幅と高さを設定するのではなく、列幅と行高さをスケーリングします。セルの内容がより多くのスペースを必要とする場合、行高さは要求されたサイズより大きくなることがあります。
{{% /alert %}}

2番目の例はテーブルをサポートし、リサイズされたプレゼンテーションを保存する前にマスターやレイアウト、個々のスライド上の形状も処理します。そのヘルパーは[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) をそれぞれ処理し、[IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) と[IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) をスケーリングします。その後、テーブル全体のサイズを個別にスケーリングせずにテーブルの位置をスケーリングします。
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
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 独立した水平および垂直スケール係数を計算します。
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // テーブルのサイズは列幅と行高さで制御されます。
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// マスターとレイアウト、および個々のスライドで定義された形状をリサイズします。
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **よくある質問**

**スライドのリサイズ後に形状が歪んだり切り取られたりするのはなぜですか？**

スライドサイズを変更しても形状をスケーリングしないと、形状は元の位置とサイズのままでスライドの外にはみ出すことがあります。幅と高さを異なる比率でスケーリングすると、形状が歪むこともあります。

**提供されたコードはすべての形状タイプで機能しますか？**

最初の例は形状の境界を直接変更し、テーブルのないスライドを対象としています。2番目の例はテーブルを別途処理します。これらの例はフォントサイズをスケーリングせず、テーブルの内容が行の高さを制約する可能性があるため、結果のレイアウト、特にテキストとテーブルを確認してください。

**スライドのリサイズ時にテーブルをどのようにリサイズしますか？**

列幅を幅の比率で、最小行高さを高さの比率でスケーリングし、次にテーブルの位置をスケーリングします。これは第2の例に示されています。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**

はい。第2の例は[Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) と各マスターの[IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) を反復し、形状に同じリサイズロジックを適用します。

**リサイズと同時にスライドの向き（縦/横）を変更できますか？**

はい。スライドサイズを変更した後、ターゲットの寸法を取得する前に[SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) を設定すると、スケール係数が最終的な向きを反映します。

**設定できるスライドサイズに制限はありますか？**

[SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) でカスタムスライドサイズを指定できます。サポートされる寸法はプレゼンテーション形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比の形状が歪むのを防ぐにはどうすればよいですか？**

幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライドサイズに収めるには、幅と高さの比率のうち小さい方をサイズと位置の両方に使用します。これにより比率は保持されますが、一方の端に未使用スペースが残ることがあります。