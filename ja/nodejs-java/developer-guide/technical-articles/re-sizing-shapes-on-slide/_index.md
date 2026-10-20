---
title: Node.js のプレゼンテーション スライド上のシェイプをリサイズする
type: docs
weight: 130
url: /ja/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /ja/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- シェイプのリサイズ
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js（Java）を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライド サイズを変更すると、シェイプを新しい寸法に合わせてサイズ変更および位置変更する必要がある場合があります。本記事では、シェイプを手動でスケーリングする方法と、スライド、マスター、レイアウト上のテーブルの扱い方を示します。

## **シェイプのサイズ変更**

各シェイプの相対的な位置とサイズを保持するには、横座標と幅を新しいスライド幅と元の幅の比率で乗算します。縦座標と高さには対応する高さの比率を適用します。

最初の例は、テーブルを含まないスライドを持つプレゼンテーションを読み込み、スライド サイズを A4 に変更し、結果を保存します。スケーリングを後続のループで制御できるように、[SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) と [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) を使用します。比率は単位を持たず、シェイプの位置と寸法はポイントで測定されます。幅と高さの比率が異なるとシェイプが歪み、シェイプの寸法を変更してもフォントサイズはスケーリングされません。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // 独立した水平および垂直方向のスケール係数を計算します。
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
テーブルは別途処理が必要です。テーブル全体の幅と高さを設定するのではなく、列幅と行高さをスケーリングします。セルの内容が多い場合、要求された高さよりも行の高さが大きくなることがあります。
{{% /alert %}}

2 番目の例はテーブルをサポートし、リサイズされたプレゼンテーションを保存する前に、マスター、レイアウト、個々のスライド上のシェイプを処理します。ヘルパーは各 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) を、[Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) で列幅を、[Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) で最小行高さをスケーリングして処理します。その後、テーブル全体の寸法を別途スケーリングせずに、テーブルの位置だけをスケーリングします。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // テーブルの寸法は列幅と行高さで制御されます。
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
    // 独立した水平および垂直方向のスケール係数を計算します。
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // マスターとレイアウト、および個々のスライドに定義されたシェイプをリサイズします。
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

## **FAQ**

**スライドのサイズ変更後にシェイプが歪んだり切り取られたりするのはなぜですか？**  
スライド サイズを変更してシェイプをスケーリングしないと、シェイプは元の位置とサイズのままでスライドの外にまで伸びてしまうことがあります。幅と高さの比率を異なる値でスケーリングすると、シェイプが歪むこともあります。

**提供されたコードはすべてのシェイプタイプで機能しますか？**  
最初の例はシェイプの境界を直接変更し、テーブルがないスライドを対象としています。2 番目の例はテーブルを別途処理します。これらの例はフォントサイズをスケーリングせず、テーブルの内容が行の高さを制限する可能性があるため、結果のレイアウト（特にテキストとテーブル）を確認してください。

**スライドのサイズ変更時にテーブルのサイズを変更するにはどうすればよいですか？**  
幅の比率で列幅を、高さの比率で最小行高さをスケーリングし、その後テーブルの位置をスケーリングします（2 番目の例を参照）。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**  
はい。2 番目の例は [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) と各マスターの [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) を反復し、それらのシェイプにも同じリサイズロジックを適用します。

**リサイズと同時にスライドの向き（縦向き/横向き）を変更できますか？**  
はい。スライド サイズを変更した後、対象となる寸法を取得する前に [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) を呼び出すことで、スケール係数が最終的な向きを反映するようにします。

**設定できるスライドサイズに制限はありますか？**  
[SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) を使用してカスタムスライド寸法を指定できます。サポートされる寸法は、プレゼンテーションの形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**  
幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライド寸法に合わせるには、幅と高さの比率のうち小さい方を両方の寸法と位置に使用します。これにより比率は保たれますが、片側に未使用のスペースが残ることがあります。