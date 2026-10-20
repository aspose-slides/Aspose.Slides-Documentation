---
title: Android のプレゼンテーション スライド上のシェイプをリサイズ
type: docs
weight: 130
url: /ja/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/スライド上の形状リサイズ/
keywords:
- シェイプのリサイズ
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、新しいサイズに合わせてシェイプのサイズ変更や位置調整が必要になる場合があります。本記事では、シェイプを手動で拡大縮小する方法と、スライド、マスタ、レイアウト上のテーブルを扱う方法を説明します。

## **シェイプのリサイズ**

各シェイプの相対的な位置とサイズを保持するには、横方向の座標と幅を「新しいスライド幅 ÷ 元の幅」の比率で乗算します。同様に、縦方向の座標と高さには高さの比率を適用します。

最初の例では、テーブルを含まないスライドを持つプレゼンテーションを読み込み、スライドサイズを A4 に変更し、結果を保存します。ここでは[SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) と[SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) を使用して、以降のループで拡大縮小を制御します。比率は単位なしで、シェイプの位置とサイズはポイントで測定されます。幅と高さの比率が異なるとシェイプが歪み、シェイプのサイズを変更してもフォントサイズは拡大縮小されません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 水平方向と垂直方向の独立したスケール係数を計算します。
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
テーブルは別途処理が必要です。テーブル全体の幅と高さを設定するのではなく、列幅と行高さを個別に拡大縮小します。セルの内容が多い場合、要求した高さよりも行の高さが大きくなることがあります。
{{% /alert %}}

二番目の例はテーブルをサポートし、個々のスライドだけでなくマスタやレイアウト上のシェイプも処理してからリサイズされたプレゼンテーションを保存します。ヘルパーは各[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) を[IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) で列幅を、[IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) で最小行高さを拡大縮小して処理します。その後、テーブル全体のサイズを個別に拡大縮小せずに位置だけを拡大縮小します。

```java
import com.aspose.slides.*;

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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // マスターとレイアウト、そして個々のスライド上に定義されたシェイプをリサイズします。
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

## **FAQ**

**スライドをリサイズした後、シェイプが歪んだり切り取られたりするのはなぜですか？**

スライドサイズを変更してシェイプを拡大縮小しないと、シェイプは元の位置とサイズのままでスライドの外側に伸びてしまうことがあります。また、幅と高さを異なる比率で拡大縮小するとシェイプが歪むことがあります。

**提供されているコードはすべてのシェイプタイプで動作しますか？**

最初の例はシェイプの境界を直接変更し、テーブルを含まないスライドを対象としています。二番目の例はテーブルを別途処理します。これらの例はフォントサイズを拡大縮小しないため、テキストやテーブルのレイアウトを確認してください。テーブルの内容が行の高さを制約することがあります。

**スライドをリサイズする際、テーブルはどのようにリサイズすればよいですか？**

列幅は幅の比率で、行の最小高さは高さの比率で拡大縮小し、最後にテーブル全体の位置を拡大縮小します。これは二番目の例で示されています。

**このリサイズはマスタスライドやレイアウトスライドでも機能しますか？**

はい。二番目の例は[Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) を介してすべてのマスタを走査し、各マスタの[IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) を走査して、同じリサイズロジックをシェイプに適用します。

**スライドの向き（縦/横）もリサイズと同時に変更できますか？**

はい。スライドサイズを変更した後、[SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) を呼び出し、ターゲット寸法を取得する前に設定してください。これによりスケール係数が最終的な向きを反映します。

**設定できるスライドサイズに上限はありますか？**

[SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) を使用してカスタムスライド寸法を指定できます。サポートされる寸法はプレゼンテーションの形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比を持つシェイプが歪むのを防ぐにはどうすればよいですか？**

幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライドサイズに収めるには、幅と高さの比率のうち小さい方を両方の寸法と位置に適用します。これにより比率は保たれますが、片側に未使用の余白が残る場合があります。