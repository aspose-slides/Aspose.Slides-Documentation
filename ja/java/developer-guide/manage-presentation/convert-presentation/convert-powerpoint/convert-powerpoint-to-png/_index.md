---
title: JavaでPowerPointスライドをPNGに変換
linktitle: PowerPointからPNGへ
type: docs
weight: 30
url: /ja/java/convert-powerpoint-to-png/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをPNGに変換
- プレゼンテーションをPNGに変換
- スライドをPNGに変換
- PPTをPNGに変換
- PPTXをPNGに変換
- PPTをPNGとして保存
- PPTXをPNGとして保存
- PPTをPNGにエクスポート
- PPTXをPNGにエクスポート
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---
## **概要**

この記事では、Aspose.Slides for Java を使用してプレゼンテーション スライドを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP などの形式のプレゼンテーションを読み込み、各スライドを描画し、個別の PNG 画像として保存できます。

以下の例は、デフォルト スケールでの描画、スケールの拡大、ピクセル単位での出力サイズの指定、そしてグラデーション描画スタイルの選択を示しています。

## **PowerPoint を PNG に変換**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスでプレゼンテーションをロードし、[Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) コレクションからスライドにアクセスします。例では、パラメータなしで [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) を呼び出してサムネイルを作成し、各スライドを描画します。その後、[IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) に [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) を指定して、描画されたスライドを PNG 画像として保存します。

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
パラメータなしの [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) オーバーロードは 0.2 のスケールで描画します。たとえば、720 × 540 ポイントのスライドは 144 × 108 ピクセルのサムネイルになります。出力サイズを制御するには、下記のようにスケール ファクターまたは明示的な画像サイズのオーバーロードを使用します。
{{% /alert %}}

## **カスタム寸法で PowerPoint を PNG に変換**

水平および垂直のスケール ファクターを [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) に渡して、描画サイズを制御します。この例では両方のファクターが 2 なので、720 × 540 ポイントのスライドは 1440 × 1080 ピクセルの画像になります。スケール ファクターが等しい場合、スライドのアスペクト比が保持されます。各画像は [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) を使用して PNG 形式で保存されます。

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

ピクセル単位で出力サイズを指定するには、スケール ファクターの代わりにサイズを [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) に渡します。この例ではすべてのスライドを 960 × 720 ピクセルで描画し、[IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) で結果を保存します。画像が伸びないように、スライドのアスペクト比に合ったサイズを選択してください。

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

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

## **グラデーション描画スタイルの選択**

スライドにグラデーション塗りが含まれていても、エクスポートされた PNG の遷移が PowerPoint で見えるものより明るくなる、または別の違いがあるとします。その場合、[RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) が継承する [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) メソッドを使用して、グラデーションの描画方法を選択できます。

[gradient-styles.pptx](gradient-styles.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには 2 つの線形グラデーションがあり、上部はシアンからオレンジ、下部は青から黄へ変化します。各グラデーションは 0% と 100% の 2 つのストップを持ちます。

以下の例はこのプレゼンテーションを読み込み、[ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) を使用して同じ最初のスライドを両方のモードで描画します。

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
| ![デフォルトで描画されたシアンからオレンジ、青から黄へのグラデーション](gradient-Default.png) | ![PowerPointUI で描画された同じグラデーション](gradient-PowerPointUI.png) |

この例では、`Default` は中間色が明るく、`PowerPointUI` は中間色が暗くなります。差異はグラデーションの色とストップに依存します。

標準の Aspose.Slides 出力で問題なければ `Default` を選択してください。PowerPoint の外観と一致させることが優先事項であれば `PowerPointUI` を試してください。両方の出力を目的の結果と比較し、どちらのモードが適切か判断してください。

## **よくある質問**

**特定の図形（チャートや画像など）だけをエクスポートしたい場合はどうすればよいですか？**

Aspose.Slides は [個々の図形のサムネイル生成](/slides/ja/java/create-shape-thumbnails/) をサポートしており、図形を PNG 画像として描画できます。

**サーバーでの並列変換はサポートされていますか？**

はい。各スレッドまたはプロセスごとに別々のプレゼンテーション インスタンスを使用してください；[スレッド間で単一インスタンスを共有しないでください](/slides/ja/java/multithreading/)。

**PNG エクスポート時の評価版の制限は何ですか？**

評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/java/licensing/) が適用されます。