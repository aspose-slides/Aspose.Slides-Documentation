---
title: Android で PowerPoint スライドを PNG に変換
linktitle: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- Android
- Java
- Aspose.Slides
description: "Java 経由で Aspose.Slides for Android を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を実現します。"
---
## **概要**

この記事では、Aspose.Slides for Android を Java 経由で使用してプレゼンテーションスライドを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP などの形式のプレゼンテーションを読み込み、各スライドをレンダリングし、個別の PNG 画像として保存できます。

以下の例では、既定のスケールでのレンダリング、スケールの拡大、ピクセル単位で出力サイズを指定する方法、そしてグラデーションレンダリングスタイルの選択を示します。

## **PowerPoint を PNG に変換**

プレゼンテーションは [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスでロードし、[Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) コレクションを介してスライドにアクセスします。この例では、パラメーターなしで [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) を使用して各スライドをサムネイルとしてレンダリングします。その後、[IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) に [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) を指定して、レンダリングされた各スライドを PNG 画像として保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
パラメーターなしの [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) オーバーロードはスケール 0.2 でレンダリングします。たとえば、720 × 540 ポイントのスライドは 144 × 108 ピクセルのサムネイルが生成されます。出力サイズを制御するには、以下に示すスケール ファクターを使用したオーバーロードまたは明示的な画像サイズを使用してください。 
{{% /alert %}}

## **カスタムサイズで PowerPoint を PNG に変換**

水平および垂直のスケール ファクタを [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) に渡すことで、レンダリングサイズを制御できます。この例では、両方のファクタが 2 になるため、720 × 540 ポイントのスライドは 1440 × 1080 ピクセルの画像が生成されます。スケール ファクタが等しい場合、スライドのアスペクト比が維持されます。各画像は [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) で PNG 形式で保存されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **カスタムサイズで PowerPoint を PNG に変換**

ピクセル単位で出力サイズを指定するには、スケール ファクタの代わりにサイズを [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) に渡します。この例では、各スライドを 960 × 720 ピクセルでレンダリングし、[IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) で結果を保存します。画像の伸びを防ぐため、スライドのアスペクト比に合ったサイズを選択してください。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **グラデーションレンダリング スタイルの選択**

スライドにグラデーション塗りつぶしが含まれているが、エクスポートされた PNG のグラデーション遷移が PowerPoint で見えるものよりも明るくなる、あるいは異なる場合があります。そのような場合は、[RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) が継承する [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) メソッドを使用して、グラデーションのレンダリング方法を選択できます。

[gradient-styles.pptx](gradient-styles.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには 2 つのリニア グラデーションが含まれており、上部はシアンからオレンジ、下部は青から黄色へと変化します。各グラデーションは 0% と 100% の 2 つのストップを持ちます。

以下の例では、このプレゼンテーションを読み込み、[ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) を使用して同じ最初のスライドを両方のモードでレンダリングします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| デフォルト | PowerPointUI |
| --- | --- |
| ![デフォルトでレンダリングされたシアンからオレンジ、青から黄色のグラデーション](gradient-Default.png) | ![PowerPointUI でレンダリングされた同じグラデーション](gradient-PowerPointUI.png) |

この例では、`Default` は中間色が明るくなり、`PowerPointUI` は中間色が暗くなります。差異はグラデーションの色とストップに依存します。

標準の Aspose.Slides 出力が目的に合う場合は `Default` を選択してください。PowerPoint の外観と一致させることが優先事項の場合は `PowerPointUI` を試してください。両方の出力を期待する結果と比較してください。どちらのモードが常に優れているわけでもありません。

## **FAQ**

**スライド全体ではなく、チャートや画像など特定のシェイプだけをエクスポートするにはどうすればよいですか？**

Aspose.Slides は、[個々のシェイプのサムネイル生成](/slides/ja/androidjava/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバーでの並列変換はサポートされていますか？**

はい。各スレッドまたはプロセスごとに別々の Presentation インスタンスを使用してください；[スレッド間で単一のインスタンスを共有しないでください](/slides/ja/androidjava/multithreading/)。

**PNG にエクスポートする際の評価版の制限は何ですか？**

評価モードでは、出力画像に透かしが付加され、ライセンスが適用されるまで [その他の制限](/slides/ja/androidjava/licensing/) が適用されます。