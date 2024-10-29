---
title: PowerPointをPNGに変換する
type: docs
weight: 30
url: /ja/java/convert-powerpoint-to-png/
keywords: PowerPoint to PNG, PPT to PNG, PPTX to PNG, java, Aspose.Slides for Java
description: PowerPointプレゼンテーションをPNGに変換する
---

## **PowerPointをPNGに変換するについて**

PNG（ポータブルネットワークグラフィックス）形式はJPEG（ジョイントフォトグラフィックエキスパートグループ）ほど一般的ではありませんが、依然として非常に人気があります。

**ユースケース:** 複雑な画像があり、サイズが問題でない場合は、PNGはJPEGよりも優れた画像形式です。

{{% alert title="ヒント" color="primary" %}} Asposeの無料の**PowerPoint to PNG変換ツール**をチェックしてみてください: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png)と[PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらは、このページで説明されているプロセスのライブ実装です。 {{% /alert %}}

## **PowerPointをPNGに変換する**

以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスをインスタンス化します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)コレクションから、[ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)インターフェイスを使用してスライドオブジェクトを取得します。
3. [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)メソッドを使用して、各スライドのサムネイルを取得します。
4. [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat))メソッドを使用して、スライドのサムネイルをPNG形式で保存します。

このJavaコードは、PowerPointプレゼンテーションをPNGに変換する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタム寸法でPowerPointをPNGに変換する**

特定のスケールでPNGファイルを取得したい場合は、結果のサムネイルの寸法を決定するための`desiredX`および`desiredY`の値を設定できます。

このJavaコードは、説明した操作を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタムサイズでPowerPointをPNGに変換する**

特定のサイズでPNGファイルを取得したい場合は、`ImageSize`のために好ましい`width`および`height`引数を渡すことができます。

このコードは、画像のサイズを指定しながらPowerPointをPNGに変換する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```