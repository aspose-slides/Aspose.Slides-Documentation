---
title: スライド上のシェイプサイズ変更
type: docs
weight: 100
url: /ja/cpp/re-sizing-shapes-on-slide/
keywords:
- シェイプサイズ変更
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument スライド上のシェイプを簡単にサイズ変更できます—スライドレイアウトの調整を自動化し、生産性を向上させます。"
---

## **概要**

Aspose.Slides for C++ のお客様から最もよくある質問のひとつは、スライドのサイズが変更されたときにデータが切り取られないようにシェイプのサイズを変更する方法です。この短い技術記事では、その手順を示します。

## **シェイプのサイズ変更**

スライドのサイズが変更されたときにシェイプがずれないように、各シェイプの位置とサイズを新しいスライドレイアウトに合わせて更新します。
```cpp
// プレゼンテーションファイルを読み込みます。
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // シェイプのサイズをスケーリングします。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // シェイプの位置をスケーリングします。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="primary" %}} 

スライドにテーブルが含まれている場合、上記のコードは正しく動作しません。その場合は、テーブル内の各セルをリサイズする必要があります。

{{% /alert %}} 

テーブルを含むスライドをリサイズするためのコードを以下に示します。テーブルの場合、幅や高さを設定するのは特殊ケースであり、テーブル全体のサイズを変更するには個々の行の高さと列の幅を調整する必要があります。
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 元のスライドサイズを取得します。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 既存のシェイプをスケーリングせずにスライドサイズを変更します。
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // シェイプのサイズをスケーリングします。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // シェイプの位置をスケーリングします。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // シェイプのサイズをスケーリングします。
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // シェイプの位置をスケーリングします。
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // シェイプのサイズをスケーリングします。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // シェイプの位置をスケーリングします。
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

**スライドのリサイズ後にシェイプが歪んだり切り取られたりするのはなぜですか？**

スライドをリサイズすると、スケールが明示的に変更されない限り、シェイプは元の位置とサイズを保持します。その結果、コンテンツが切り取られたりシェイプがずれたりします。

**提供されたコードはすべてのシェイプタイプで機能しますか？**

基本的な例は、テキストボックス、画像、チャートなど多くのシェイプタイプで機能します。ただし、テーブルの場合は行と列を個別に処理する必要があります。テーブルの高さと幅は個々のセルの寸法によって決まるためです。

**スライドのリサイズ時にテーブルをどのようにリサイズすればよいですか？**

テーブルのすべての行と列をループし、2 番目のコード例に示すように高さと幅を比例してリサイズする必要があります。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**

はい、マスタースライドやレイアウトスライドでも同様に [Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) と [Layout slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) をループし、シェイプに同じスケーリングロジックを適用すれば、プレゼンテーション全体で一貫性を保つことができます。

**スライドの向き（縦長/横長）をリサイズと同時に変更できますか？**

はい。[presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/set_orientation/) を使用して向きを変更できます。レイアウトを保つためにスケーリングロジックも合わせて設定してください。

**設定できるスライドサイズに上限はありますか？**

Aspose.Slides はカスタムサイズをサポートしていますが、非常に大きなサイズはパフォーマンスに影響したり、一部の PowerPoint バージョンとの互換性に問題が生じる可能性があります。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**

スケーリング前にシェイプの `get_AspectRatioLocked` メソッドを確認してください。ロックされている場合は、幅と高さを個別にスケールするのではなく、比例して調整します。