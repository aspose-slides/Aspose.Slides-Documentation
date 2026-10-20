---
title: Javaでプレゼンテーションスライドのシェイプサイズを変更する
type: docs
weight: 130
url: /ja/java/resizing-shapes-on-slide/
aliases:
  - /ja/java/re-sizing-shapes-on-slide/
keywords:
  - シェイプのサイズ変更
  - シェイプサイズの変更
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、新しいサイズに合わせてシェイプのサイズ変更と位置調整が必要になる場合があります。本記事では、シェイプを手動でスケーリングする方法と、スライド、マスター、レイアウト上のテーブルの処理方法について説明します。

## **シェイプのサイズ変更**

各シェイプの相対的な位置とサイズを保持するには、水平座標と幅を新しいスライド幅と元の幅の比率で掛け算します。同様に、垂直座標と高さには対応する高さの比率を適用します。

最初の例では、スライドにテーブルが含まれていないプレゼンテーションを読み込み、スライドサイズをA4に変更し、結果を保存します。その際、[SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) と [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) を使用し、後続のループでスケーリングを制御します。比率は単位を持たず、シェイプの位置とサイズはポイントで測定されます。幅と高さの比率が異なるとシェイプが歪む可能性があり、シェイプのサイズを変更してもフォントサイズはスケーリングされません。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 独立した水平方向と垂直方向のスケール係数を計算します。
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
テーブルは個別に処理する必要があります。テーブル全体の幅と高さを設定するのではなく、列幅と行高さをスケーリングします。セルの内容がスペースを必要とする場合、行の高さは要求されたサイズより大きくなることがあります。
{{% /alert %}}

2 番目の例では、テーブルをサポートし、リサイズされたプレゼンテーションを保存する前に、マスターやレイアウト、個別のスライド上のシェイプを処理します。このヘルパーは、[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) の各テーブルに対して、[IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) で列幅を、[IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) で最小行高さをスケーリングして処理します。その後、テーブル全体のサイズを別途スケーリングせずに、テーブルの位置だけをスケーリングします。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // テーブルのサイズは列幅と行高さで制御されます。
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // 水平方向と垂直方向の独立したスケール係数を計算します。
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // マスターとレイアウト、個々のスライド上に定義されたシェイプをリサイズします。
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **よくある質問**

**スライドのリサイズ後にシェイプが歪んだり切り取られたりするのはなぜですか？**

シェイプをスケーリングせずにスライドサイズを変更すると、シェイプは元の位置とサイズを保持したままスライドの外にはみ出すことがあります。また、幅と高さを異なる比率でスケーリングするとシェイプが歪む可能性があります。

**提供されたコードはすべてのシェイプタイプで機能しますか？**

最初の例はシェイプの境界を直接変更し、テーブルのないスライドを対象としています。2 番目の例はテーブルを別途処理します。これらの例はフォントサイズをスケーリングせず、テーブルの内容が行の高さを制約する可能性があるため、結果のレイアウト（特にテキストとテーブル）を確認してください。

**スライドのリサイズ時にテーブルのサイズを変更するにはどうすればよいですか？**

幅の比率で列幅を、高さの比率で最小行高さをスケーリングし、最後にテーブルの位置をスケーリングします（2 番目の例参照）。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**

はい。2 番目の例では、[Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) と各マスターの [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) を走査し、シェイプに同じリサイズロジックを適用します。

**リサイズと同時にスライドの向き（縦／横）を変更できますか？**

はい。スライドサイズを変更した後、対象の寸法を取得する前に [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) を呼び出すことで、スケール係数が最終的な向きを反映します。

**設定できるスライドサイズに制限はありますか？**

[SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) を使用してカスタムのスライド寸法を指定できます。サポートされる寸法は、プレゼンテーションの形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**

幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライドサイズに合わせるには、幅と高さの比率のうち小さい方を、サイズと位置の両方に使用します。これにより比例が保たれますが、片側に未使用のスペースができることがあります。