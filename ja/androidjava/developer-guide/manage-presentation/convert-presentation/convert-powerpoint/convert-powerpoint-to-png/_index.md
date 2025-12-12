---
title: Android 上で PowerPoint スライドを PNG に変換
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
description: "Aspose.Slides for Android を Java で使用し、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---

## **PowerPoint の PNG 変換について**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として非常に人気があります。

**Use case:** 複雑な画像でサイズが問題とならない場合、PNG は JPEG よりも優れた画像形式です。

{{% alert title="Tip" color="primary" %}}Aspose の無料 **PowerPoint to PNG コンバータ** をチェックしたいかもしれません: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらはこのページで説明されたプロセスの実装例です。{{% /alert %}}

## **PowerPoint を PNG に変換**

以下の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) コレクションから [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) インターフェイスのスライドオブジェクトを取得します。
3. [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) メソッドを使用して各スライドのサムネイルを取得します。
4. [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドを使用してスライドのサムネイルを PNG 形式で保存します。

この Java コードは PowerPoint プレゼンテーションを PNG に変換する方法を示しています：
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


## **カスタム寸法で PowerPoint を PNG に変換**

特定のスケールの PNG ファイルを取得したい場合、生成されるサムネイルの寸法を決定する `desiredX` と `desiredY` の値を設定できます。

以下の Java コードは上記の操作を示しています：
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


## **カスタムサイズで PowerPoint を PNG に変換**

特定のサイズの PNG ファイルを取得したい場合、`ImageSize` の `width` と `height` 引数に希望の値を渡すことができます。

このコードは、画像サイズを指定して PowerPoint を PNG に変換する方法を示しています：
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


## **FAQ**

**How can I export only a specific shape (e.g., chart or picture) rather than the whole slide?**  
Aspose.Slides は [generating thumbnails for individual shapes](/slides/ja/androidjava/create-shape-thumbnails/) をサポートしており、形状を PNG 画像としてレンダリングできます。

**Is parallel conversion supported on a server?**  
はい、ただし単一のプレゼンテーション インスタンスをスレッド間で共有しないでください。スレッドまたはプロセスごとに別々のインスタンスを使用してください。[don’t share](/slides/ja/androidjava/multithreading/)。

**What are the trial-version limitations when exporting to PNG?**  
評価モードでは出力画像に透かしが付加され、ライセンスが適用されるまで [other restrictions](/slides/ja/androidjava/licensing/) が適用されます。