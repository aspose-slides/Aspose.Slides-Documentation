---
title: Java でプレゼンテーション スライドのシェイプをリサイズする
type: docs
weight: 130
url: /ja/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /ja/java/re-sizing-shapes-on-slide/
keywords:
  - シェイプをリサイズ
  - シェイプのサイズを変更
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、新しいサイズに合わせてシェイプのサイズ変更や位置調整が必要になることがあります。本稿ではシェイプを手動で拡大縮小する方法と、スライド、マスター、レイアウト上のテーブルの処理方法を示します。

## **シェイプのサイズ変更**

各シェイプの相対的な位置とサイズを保持するには、水平座標と幅に新しいスライド幅と元の幅の比率を掛けます。垂直座標と高さには対応する高さの比率を適用します。

最初の例では、テーブルを含まないスライドを持つプレゼンテーションをロードし、スライドサイズをA4に変更して結果を保存します。これには[SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-)を[SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale)と組み合わせて使用し、以降のループで拡大縮小を制御します。比率は単位なしで、シェイプの位置とサイズはポイントで測定されます。幅と高さの比率が異なるとシェイプが歪み、シェイプのサイズを変更してもフォントサイズは拡大縮小されません。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 独立した水平および垂直のスケール係数を計算します。
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
テーブルは個別に処理する必要があります。テーブル全体の幅と高さを設定するのではなく、列幅と行高さをそれぞれ拡大縮小します。セルの内容が多い場合、行の高さは要求されたサイズより大きくなることがあります。
{{% /alert %}}

2 番目の例はテーブルをサポートし、リサイズされたプレゼンテーションを保存する前に、マスターやレイアウト上のシェイプだけでなく個々のスライドも処理します。そのヘルパーは各[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/)を処理し、列幅は[IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-)で、行の最小高さは[IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-)で拡大縮小します。その後、テーブル全体のサイズを別途拡大縮小することなく、テーブルの位置を拡大縮小します。

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
    // 独立した水平および垂直のスケール係数を計算します。
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // マスターとレイアウト、および個々のスライドに定義されたシェイプをリサイズします。
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

**スライドのサイズ変更後にシェイプが歪んだり切り取られたりするのはなぜですか？**  
スライドサイズを変更してもシェイプを拡大縮小しないと、シェイプは元の位置とサイズのままでスライドからはみ出すことがあります。また、幅と高さの比率を異なる値で拡大縮小するとシェイプが歪むことがあります。

**提供されたコードはすべてのシェイプタイプで機能しますか？**  
最初の例はシェイプの境界を直接変更し、テーブルを含まないスライドを対象としています。2 番目の例はテーブルを別途処理します。これらの例はフォントサイズを拡大縮小せず、テーブルの内容が行の高さを制約する可能性があるため、結果のレイアウト（特にテキストとテーブル）を確認してください。

**スライドのサイズ変更時にテーブルをどのようにリサイズしますか？**  
列幅を幅の比率で、行の最小高さを高さの比率で拡大縮小し、最後にテーブルの位置を拡大縮小します（2 番目の例を参照）。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**  
はい。2 番目の例は[Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)と各マスターの[IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--)を順に処理し、シェイプに同じリサイズロジックを適用します。

**リサイズと同時にスライドの向き（縦向き/横向き）を変更できますか？**  
はい。スライドサイズを変更した後、目標サイズを取得する前に[SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-)を呼び出すことで、スケール係数が最終的な向きを反映します。

**設定できるスライドサイズに制限はありますか？**  
[SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-)でカスタムスライド寸法を指定できます。サポートされる寸法は、プレゼンテーションの形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**  
幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライド寸法に合わせるには、幅と高さの比率のうち小さい方を両方の寸法と位置に使用します。これにより比率は維持されますが、片側に未使用のスペースが残る場合があります。