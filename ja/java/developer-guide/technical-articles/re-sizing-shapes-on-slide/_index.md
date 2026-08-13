---
title: プレゼンテーション スライドのシェイプをリサイズする
type: docs
weight: 110
url: /ja/java/re-sizing-shapes-on-slide/
keywords:
- シェイプをリサイズ
- シェイプサイズを変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

Aspose.Slides for Java の顧客から最もよくある質問の一つは、スライドサイズが変更されたときにデータが切り取られないようにシェイプのサイズを変更する方法です。この短い技術記事では、その方法を示します。

## **シェイプのサイズ変更**

スライドサイズが変更されたときにシェイプがずれないように、各シェイプの位置とサイズを新しいスライドレイアウトに合わせて更新します。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを読み込む。
Presentation presentation = new Presentation("sample.ppt");
try {
    // 元のスライドサイズを取得。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 既存のシェイプをスケーリングせずにスライドサイズを変更。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 新しいスライドサイズを取得。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 各スライドのシェイプをリサイズおよび再配置。
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // シェイプのサイズをスケーリング。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // シェイプの位置をスケーリング。
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

{{% alert color="info" %}} 
テーブルは特別な処理は不要です。テーブルの幅と高さを設定すると、列と行が比例的にリスケールされるため、行の高さや列の幅を再度スケールすると比率が二重に適用されます。
{{% /alert %}} 

上記のコードはスライド上のシェイプのみを変更します。マスタースライドとレイアウトスライドは独自のシェイプを保持しているため、プレゼンテーション全体を新しいスライドサイズに合わせたい場合は、それらも同様にスケールしてください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 元のスライドサイズを取得。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 既存のシェイプをスケーリングせずにスライドサイズを変更。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // 新しいスライドサイズを取得。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // シェイプのサイズをスケーリング。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // シェイプの位置をスケーリング。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // シェイプのサイズをスケーリング。
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // シェイプの位置をスケーリング。
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // シェイプのサイズをスケーリング。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // シェイプの位置をスケーリング。
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

## **FAQ**

### スライドのサイズ変更後にシェイプが歪んだり切り取られたりするのはなぜですか？

スライドのサイズを変更すると、スケールが明示的に変更されない限り、シェイプは元の位置とサイズを保持します。その結果、コンテンツが切り取られたりシェイプがずれたりすることがあります。

### 提供されたコードはすべてのシェイプタイプで機能しますか？

はい。高さと幅を設定することで、テキストボックス、画像、チャート、テーブルすべてで同様に機能します。

### スライドをリサイズする際、テーブルのサイズはどう変更すればよいですか？

テーブルシェイプ自体を他のシェイプと同様にスケールしてください。行と列は比例して調整されるため、後で再度スケールしないでください。

### このリサイズはマスタースライドとレイアウトスライドでも機能しますか？

はい、ただし、[マスター](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getMasters--) と [レイアウト スライド](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getLayoutSlides--) をループし、同じスケーリングロジックをそれらのシェイプに適用して、プレゼンテーション全体の一貫性を確保してください。

### リサイズと同時にスライドの向き（縦/横）を変更できますか？

はい。[presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidesize/#setOrientation-int-) を使用して向きを変更できます。レイアウトを保持するために、スケーリングロジックもそれに合わせて設定してください。

### 設定できるスライドサイズに上限はありますか？

Aspose.Slides はカスタムサイズをサポートしていますが、非常に大きなサイズはパフォーマンスや一部の PowerPoint バージョンとの互換性に影響を与える可能性があります。

### 固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？

スケールする前にシェイプの `getAspectRatioLocked` メソッドを確認できます。ロックされている場合は、幅または高さを個別にスケールするのではなく、比例的に調整してください。