---
title: JavaでPowerPointスライドをPNGに変換
linktitle: PowerPointからPNGへ
type: docs
weight: 30
url: /ja/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---

## **PowerPointからPNGへの変換について**

PNG（Portable Network Graphics）形式はJPEG（Joint Photographic Experts Group）ほど普及していませんが、依然として非常に人気があります。

**使用例:** 複雑な画像でサイズが問題でない場合、PNGはJPEGよりも優れた画像形式です。

{{% alert title="ヒント" color="primary" %}} Asposeの無料**PowerPointからPNGへのコンバーター**をご覧になると良いでしょう: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらはこのページで説明されているプロセスの実装例です。 {{% /alert %}}

## **PowerPointをPNGに変換**

以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスをインスタンス化します。  
2. [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) コレクションから [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) インターフェイスの下にあるスライドオブジェクトを取得します。  
3. 各スライドのサムネイルを取得するには、[ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) メソッドを使用します。  
4. スライドのサムネイルをPNG形式で保存するには、[**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドを使用します。

このJavaコードは、PowerPointプレゼンテーションをPNGに変換する方法を示しています:
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

特定のスケールに合わせたPNGファイルを取得したい場合、結果のサムネイルの寸法を決定する `desiredX` と `desiredY` の値を設定できます。

このコードは、上記の操作をJavaで示しています:
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

特定のサイズに合わせたPNGファイルを取得したい場合、`ImageSize` 用に希望する `width` と `height` 引数を渡すことができます。

このコードは、画像のサイズを指定しながらPowerPointをPNGに変換する方法を示しています:
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
