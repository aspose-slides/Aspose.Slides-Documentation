---
title: プレゼンテーションスライドの図形サイズ変更
type: docs
weight: 110
url: /ja/java/re-sizing-shapes-on-slide/
keywords:
- 図形のサイズ変更
- 図形サイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のスライド上の図形を簡単にサイズ変更し、スライドレイアウトの調整を自動化して生産性を向上させます。"
---

## **概要**

Aspose.Slides for Java のお客様から最もよく寄せられる質問の一つは、スライドのサイズが変更されたときにデータが切り取られないように、図形のサイズを変更する方法です。この短い技術記事では、そのやり方を示します。

## **図形のサイズ変更**

スライドのサイズが変更されたときに図形がずれないように、各図形の位置とサイズを新しいスライドレイアウトに合わせて更新します。
```java
// プレゼンテーションファイルを読み込みます。
Presentation presentation = new Presentation("sample.ppt");
try {
    // 元のスライド サイズを取得します。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 既存の図形をスケーリングせずにスライド サイズを変更します。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 新しいスライド サイズを取得します。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // すべてのスライドで図形のサイズと位置を変更します。
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // 図形のサイズをスケーリングします。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 図形の位置をスケーリングします。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}} 
スライドにテーブルが含まれている場合、上記のコードは正しく動作しません。その場合、テーブルの各セルのサイズを変更する必要があります。
{{% /alert %}} 

テーブルを含むスライドのサイズを変更するには、以下のコードを使用してください。テーブルの場合、幅や高さを設定するのは特殊なケースであり、テーブル全体のサイズを変更するために、個々の行の高さと列の幅を調整する必要があります。
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // 元のスライドサイズを取得します。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 既存の図形をスケーリングせずにスライドサイズを変更します。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // 新しいスライドサイズを取得します。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // 図形のサイズをスケーリングします。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 図形の位置をスケーリングします。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // 図形のサイズをスケーリングします。
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // 図形の位置をスケーリングします。
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // 図形のサイズをスケーリングします。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 図形の位置をスケーリングします。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


## **よくある質問**

**スライドのサイズ変更後に図形が歪んだり切り取られたりするのはなぜですか？**

スライドのサイズを変更すると、スケールを明示的に変更しない限り図形は元の位置とサイズのまま残ります。その結果、コンテンツが切り取られたり、図形がずれたりすることがあります。

**提供されたコードはすべての図形タイプで動作しますか？**

基本的な例はほとんどの図形タイプ（テキスト ボックス、画像、チャートなど）で機能します。ただし、テーブルの場合は、テーブルの高さと幅が個々のセルのサイズによって決まるため、行と列を個別に処理する必要があります。

**スライドのサイズ変更時にテーブルのサイズを変更するにはどうすればよいですか？**

テーブルのすべての行と列をループし、2 番目のコード例に示すように高さと幅を比例して変更する必要があります。

**このサイズ変更はマスタースライドやレイアウトスライドでも機能しますか？**

はい、ただし、[Masters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) と [Layout slides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) もループし、同じスケーリングロジックをそれらの図形に適用して、プレゼンテーション全体で一貫性を保つ必要があります。

**サイズ変更と同時にスライドの向き（縦向き/横向き）を変更できますか？**

はい。[presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#setOrientation-int-) を使用して向きを変更できます。レイアウトを維持するために、スケーリングロジックを適切に設定してください。

**設定できるスライドサイズに制限はありますか？**

Aspose.Slides はカスタムサイズに対応していますが、非常に大きなサイズはパフォーマンスや一部の PowerPoint バージョンとの互換性に影響を与える可能性があります。

**固定アスペクト比の図形が歪むのを防ぐにはどうすればよいですか？**

スケーリングする前に、図形の `getAspectRatioLocked` メソッドを確認できます。ロックされている場合は、幅と高さを個別にスケーリングするのではなく、比例して調整してください。