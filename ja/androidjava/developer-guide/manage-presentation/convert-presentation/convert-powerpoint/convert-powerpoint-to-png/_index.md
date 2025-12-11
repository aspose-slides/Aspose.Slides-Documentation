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
description: "Aspose.Slides for Android を使用して Java で PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---

## **PowerPoint の PNG 変換について**

PNG (Portable Network Graphics) 形式は JPEG (Joint Photographic Experts Group) ほど一般的ではありませんが、依然として非常に人気があります。  

**使用例:** 画像が複雑でサイズが問題とならない場合、PNG は JPEG よりも優れた画像形式です。  

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint to PNG コンバータ** をチェックしてみてください: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) and [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). これらはこのページで説明したプロセスのライブ実装です。 {{% /alert %}}

## **PowerPoint を PNG に変換**

以下の手順に従ってください:

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
2. ISlide インターフェイスの下にある [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) コレクションからスライドオブジェクトを取得します。
3. ISlide.getImage() メソッドを使用して各スライドのサムネイルを取得します。[ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)
4. IImage.save(String formatName, int imageFormat) メソッドを使用してスライドのサムネイルを PNG 形式で保存します。[**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat))

この Java コードは PowerPoint プレゼンテーションを PNG に変換する方法を示しています:
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

特定のスケールの PNG ファイルを取得したい場合、結果のサムネイルのサイズを決定する `desiredX` と `desiredY` の値を設定できます。  

この Java コードは上記の操作を示しています:
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

特定のサイズの PNG ファイルを取得したい場合、`ImageSize` に対して希望の `width` と `height` 引数を渡すことができます。  

このコードは画像のサイズを指定して PowerPoint を PNG に変換する方法を示しています: 
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

**スライド全体ではなく、特定のシェイプ（例：チャートや画像）だけをエクスポートするにはどうすればよいですか？**

Aspose.Slides は個々のシェイプ用サムネイルの生成をサポートしており、シェイプを PNG 画像としてレンダリングできます。  

**サーバーでの並列変換はサポートされていますか？**

はい、ただし単一のプレゼンテーションインスタンスをスレッド間で共有しないでください。スレッドまたはプロセスごとに別々のインスタンスを使用します。  

**PNG へのエクスポート時のトライアル版の制限は何ですか？**

評価モードでは出力画像に透かしが付加され、ライセンスが適用されるまで他の制限が適用されます。