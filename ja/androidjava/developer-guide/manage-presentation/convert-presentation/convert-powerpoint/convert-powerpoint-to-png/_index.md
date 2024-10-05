---
title: PowerPointをPNGに変換
type: docs
weight: 30
url: /androidjava/convert-powerpoint-to-png/
keywords: PowerPoint to PNG, PPT to PNG, PPTX to PNG, java, Aspose.Slides for Android via Java
description: PowerPointプレゼンテーションをPNGに変換
---

## **PowerPointからPNGへの変換について**

PNG（Portable Network Graphics）フォーマットはJPEG（Joint Photographic Experts Group）ほど人気ではありませんが、依然として非常に人気があります。

**ユースケース:** 複雑な画像があり、サイズが問題でない場合、PNGはJPEGよりも優れた画像フォーマットです。

{{% alert title="ヒント" color="primary" %}} Asposeの無料 **PowerPoint to PNG Converters** をチェックしてみてください: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらは、このページで説明されているプロセスのライブ実装です。 {{% /alert %}}

## **PowerPointをPNGに変換**

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスをインスタンス化します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) コレクションから [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) インターフェースのスライドオブジェクトを取得します。
3. [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) メソッドを使用して、各スライドのサムネイルを取得します。
4. [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドを使用して、スライドのサムネイルをPNGフォーマットで保存します。

このJavaコードは、PowerPointプレゼンテーションをPNGに変換する方法を示しています。

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

## **カスタム寸法でPowerPointをPNGに変換**

特定のスケールに沿ったPNGファイルを取得したい場合は、結果のサムネイルの寸法を決定する `desiredX` および `desiredY` の値を設定できます。

このJavaコードは、説明した操作を示しています。

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

## **カスタムサイズでPowerPointをPNGに変換**

特定のサイズに沿ったPNGファイルを取得したい場合は、`ImageSize` に対して好みの `width` および `height` 引数を渡すことができます。

このコードは、画像のサイズを指定しながらPowerPointをPNGに変換する方法を示しています。

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