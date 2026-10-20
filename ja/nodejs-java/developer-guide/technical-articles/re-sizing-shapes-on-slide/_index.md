---
title: Node.js でプレゼンテーション スライド上のシェイプをリサイズする
type: docs
weight: 130
url: /ja/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /ja/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- シェイプをリサイズ
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、新しいサイズに合わせてシェイプのサイズや位置を調整する必要があります。この記事では、シェイプを手動で拡大縮小する方法と、スライド、マスター、レイアウト上のテーブルを扱う方法を示します。

## **シェイプのサイズ変更**

各シェイプの相対的な位置とサイズを保つには、横方向の座標と幅を「新しいスライド幅 ÷ 元の幅」の比率で乗算します。同様に、縦方向の座標と高さには高さの比率を適用します。

最初の例は、テーブルを含まないスライドを持つプレゼンテーションを読み込み、スライドサイズを A4 に変更して結果を保存します。これは [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) を [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) と組み合わせて使用し、以降のループで拡大縮小を制御します。比率は単位なしで、シェイプの位置とサイズはポイントで測定されます。幅と高さの比率が異なるとシェイプが歪み、シェイプのサイズを変更してもフォントサイズは拡大縮小されません。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // 独立した水平および垂直のスケール係数を計算します。
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
テーブルは別途処理が必要です。テーブル全体の幅と高さを設定するのではなく、列幅と行高さを個別に拡大縮小します。セルの内容が多い場合、行高さは要求されたサイズより大きくなることがあります。
{{% /alert %}}

2 番目の例はテーブルをサポートし、マスターやレイアウト上のシェイプも個々のスライドと同様に処理して、サイズ変更後のプレゼンテーションを保存します。ヘルパーは各 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) を、[Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) で列幅を、[Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) で最小行高さを拡大縮小して処理します。その後、テーブル全体のサイズを別途拡大縮小せずに位置だけを拡大縮小します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // テーブルのサイズは列幅と行高さで制御されます。
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // 独立した水平および垂直のスケール係数を計算します。
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // マスターとレイアウト、および個々のスライド上で定義されたシェイプをリサイズします。
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **よくある質問**

**スライドのサイズ変更後にシェイプが歪んだり切れたりするのはなぜですか？**

スライドサイズを変更してシェイプを拡大縮小しないと、シェイプは元の位置とサイズのままでスライドの外にはみ出すことがあります。幅と高さを異なる比率で拡大縮小すると、シェイプが歪む原因になります。

**提供されたコードはすべてのシェイプタイプで機能しますか？**

最初の例はシェイプの境界を直接変更し、テーブルを含まないスライドを対象としています。2 番目の例はテーブルを個別に処理します。これらの例はフォントサイズを拡大縮小しないため、特にテキストやテーブルのレイアウトを確認してください。テーブルの内容が行高さを制約することがあります。

**スライドのサイズ変更時にテーブルをどのようにリサイズすればよいですか？**

列幅は幅の比率で、最小行高さは高さの比率で拡大縮小し、その後テーブルの位置を拡大縮小します。これは 2 番目の例で示しています。

**このリサイズはマスター スライドやレイアウト スライドでも機能しますか？**

はい。2 番目の例は [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) を列挙し、各マスターの [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) を走査して、同じリサイズロジックをそれらのシェイプに適用します。

**スライドの向き（縦向き/横向き）をリサイズと同時に変更できますか？**

はい。スライドサイズを変更した後、ターゲットの寸法を取得する前に [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) を呼び出すことで、拡大縮小係数が最終的な向きを反映するようにできます。

**設定できるスライドサイズに上限はありますか？**

[SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) でカスタムサイズを指定できます。サポートされるサイズはプレゼンテーションの形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**

幅と高さに同じ拡大縮小係数を使用します。元のレイアウトを新しいスライドサイズに収めるには、幅と高さの比率のうち小さい方を両方の寸法と位置に使用します。これにより比率は保たれますが、片側に未使用の余白が残ることがあります。