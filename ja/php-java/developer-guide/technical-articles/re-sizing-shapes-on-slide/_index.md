---
title: PHPでプレゼンテーションスライドのシェイプをリサイズする
type: docs
weight: 130
url: /ja/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /ja/php-java/re-sizing-shapes-on-slide/
keywords:
- シェイプのリサイズ
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP向けのAspose.Slides for Javaを使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、新しいサイズに合わせてシェイプのサイズ変更と位置調整が必要になる場合があります。本記事では、シェイプを手動でスケーリングする方法と、スライド、マスター、レイアウト上のテーブルの処理方法を紹介します。

## **シェイプのサイズ変更**

各シェイプの相対的な位置とサイズを保持するには、横方向の座標と幅に新しいスライド幅と元の幅の比率を掛けます。同様に、縦方向の座標と高さには対応する高さの比率を適用します。

最初の例では、テーブルを含まないスライドを持つプレゼンテーションを読み込み、スライドサイズを A4 に変更し、結果を保存します。スケーリングを後続のループで制御できるように、[SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) と [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) を使用します。比率は単位なしで、シェイプの位置と寸法はポイントで測定されます。幅と高さの比率が異なるとシェイプが歪む可能性があり、シェイプの寸法を変更してもフォントサイズはスケーリングされません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // 独立した水平および垂直のスケール係数を計算します。
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
テーブルは別途処理が必要です。テーブル全体の幅と高さを設定するのではなく、列幅と行高さをスケーリングします。セルの内容がより多くのスペースを必要とする場合、行の高さは要求されたサイズより大きくなることがあります。
{{% /alert %}}

2 番目の例はテーブルに対応し、リサイズしたプレゼンテーションを保存する前に、マスターやレイアウト、個々のスライド上のシェイプも処理します。そのヘルパーは、[Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) を対象に、[Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) で列幅を、[Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) で最小行高さをスケーリングして処理します。その後、テーブル全体の寸法を別途スケーリングせずにテーブルの位置をスケーリングします。
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // テーブルのサイズは列幅と行高さで制御されます。
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // 独立した水平および垂直のスケール係数を計算します。
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // マスターとレイアウト、および個々のスライドで定義されたシェイプをリサイズします。
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **よくある質問**

**スライドのサイズ変更後にシェイプが歪んだり切り取られたりするのはなぜですか？**

スライドサイズを変更してもシェイプをスケーリングしないと、シェイプは元の位置と寸法のままで、スライドの範囲を超えてはみ出すことがあります。また、幅と高さの比率を異なる数値でスケーリングするとシェイプが歪むことがあります。

**提供されたコードはすべてのシェイプタイプで機能しますか？**

最初の例はシェイプの境界を直接変更し、テーブルのないスライドを対象としています。2 番目の例はテーブルを別途処理します。これらの例はフォントサイズをスケーリングせず、テーブルの内容が行の高さを制限する可能性があるため、特にテキストやテーブルのレイアウトを確認してください。

**スライドのリサイズ時にテーブルをどのようにサイズ変更すればよいですか？**

列幅を幅の比率で、最小行高さを高さの比率でスケーリングし、テーブルの位置をスケーリングします。これらは 2 番目の例で示されています。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**

はい。2 番目の例は [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) と各マスターの [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) を反復し、シェイプに同じリサイズロジックを適用します。

**リサイズと同時にスライドの向き（縦横）を変更できますか？**

はい。スライドサイズを変更した後、対象のサイズを取得する前に [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) を呼び出すことで、スケール係数が最終的な向きに反映されます。

**設定できるスライドサイズに上限はありますか？**

[SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) でカスタムスライドサイズを指定できます。サポートされるサイズはプレゼンテーションの形式や、ファイルを開くアプリケーションにも依存します。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**

幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライドサイズに収めるには、幅と高さの比率のうち小さい方を幅・高さ・位置すべてに適用します。これにより比率は保たれますが、片側に未使用の余白が残る場合があります。