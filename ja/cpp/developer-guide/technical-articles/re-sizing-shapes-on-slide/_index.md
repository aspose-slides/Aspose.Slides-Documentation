---
title: C++ でプレゼンテーションスライド上のシェイプをリサイズする
type: docs
weight: 130
url: /ja/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /ja/cpp/re-sizing-shapes-on-slide/
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

プレゼンテーションのスライドサイズを変更すると、新しいサイズに合わせてシェイプのサイズ変更や位置の再調整が必要になることがあります。この記事では、シェイプを手動で拡大縮小する方法と、スライド、マスター、レイアウト上のテーブルの処理方法を示します。

## **シェイプのサイズ変更**

各シェイプの相対的な位置とサイズを保つには、横座標と幅を新しいスライド幅と元の幅の比率で乗算します。同様に、縦座標と高さには対応する高さの比率を適用します。

最初の例では、テーブルを含まないスライドを持つプレゼンテーションをロードし、スライドサイズを A4 に変更して結果を保存します。スケーリングは後続のループで制御できるように、[SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) と [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) を使用します。比率は単位なしで、シェイプの位置とサイズはポイントで測定されます。幅と高さの比率が異なるとシェイプが歪み、シェイプのサイズを変更してもフォントサイズは拡大縮小されません。

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

// 独立した水平および垂直のスケール係数を計算します。
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
テーブルは個別に処理する必要があります。テーブル全体の幅と高さを設定するのではなく、列幅と行高さをそれぞれ拡大縮小します。セルの内容がより多くのスペースを必要とする場合、行高さは要求されたサイズよりも大きくなることがあります。
{{% /alert %}}

2 番目の例では、テーブルをサポートし、リサイズされたプレゼンテーションを保存する前に、マスターやレイアウト、個々のスライド上のシェイプも処理します。ヘルパーは各 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) を、[IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) と [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) を拡大縮小して処理します。その後、テーブル全体のサイズを別個に拡大縮小することなく、テーブルの位置を拡大縮小します。

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

// 独立した水平および垂直のスケール係数を計算します。
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

// マスターとレイアウト、そして個々のスライド上で定義されたシェイプをリサイズします。
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

**スライドのサイズ変更後にシェイプが歪んだり切り取られたりするのはなぜですか？**

スライドサイズを変更してもシェイプを拡大縮小しない場合、シェイプは元の位置とサイズのままでスライドの外にはみ出すことがあります。また、幅と高さの比率が異なるとシェイプが歪むこともあります。

**提供されたコードはすべてのシェイプタイプで機能しますか？**

最初の例はシェイプの境界を直接変更し、テーブルを含まないスライドを対象としています。2 番目の例はテーブルを別途処理します。これらの例はフォントサイズを拡大縮小しないため、特にテキストやテーブルのレイアウトを確認してください。テーブルの内容によっては行の高さが制限されることがあります。

**スライドのサイズ変更時にテーブルをどのようにリサイズしますか？**

列幅は幅の比率で、最小行高さは高さの比率で拡大縮小し、最後にテーブルの位置を拡大縮小します（2 番目の例を参照）。

**このリサイズはマスタースライドとレイアウトスライドでも機能しますか？**

はい。2 番目の例では、[Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) と各マスターの [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) を走査し、シェイプに対して同じリサイズロジックを適用します。

**リサイズと同時にスライドの向き（縦/横）を変更できますか？**

はい。スライドサイズを変更した後、ターゲット寸法を取得する前に [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) を設定すると、スケール係数が最終的な向きを反映します。

**設定できるスライドサイズに制限はありますか？**

カスタムスライド寸法は [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) で指定できます。サポートされる寸法はプレゼンテーションの形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**

幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライドサイズに収めるには、幅と高さの比率のうち小さい方を両方の寸法と位置に適用します。これにより比例が保たれますが、片側に未使用のスペースが残ることがあります。