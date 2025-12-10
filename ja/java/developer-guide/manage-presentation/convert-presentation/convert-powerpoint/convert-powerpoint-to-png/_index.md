---
title: Java で PowerPoint スライドを PNG に変換
linktitle: PowerPoint から PNG へ
type: docs
weight: 30
url: /ja/java/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から PNG へ
- プレゼンテーションから PNG へ
- スライドから PNG へ
- PPT から PNG へ
- PPTX から PNG へ
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を実現します。"
---

## **PowerPoint から PNG への変換について**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として非常に人気があります。

**使用例:** 複雑な画像でサイズが問題とならない場合、PNG は JPEG よりも優れた画像形式です。

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint to PNG コンバータ** を確認したいかもしれません: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらはこのページで説明されているプロセスの実装例です。 {{% /alert %}}

## **PowerPoint を PNG に変換**

以下の手順を実行してください:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) コレクションから [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) インターフェイスのスライドオブジェクトを取得します。
3. [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) メソッドを使用して各スライドのサムネイルを取得します。
4. [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドを使用してスライドのサムネイルを PNG 形式で保存します。

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

`desiredX` と `desiredY` の値を設定すると、特定のスケールに合わせた PNG ファイルを取得でき、これらは生成されるサムネイルの寸法を決定します。

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

`ImageSize` に対して希望する `width` と `height` 引数を渡すことで、特定のサイズの PNG ファイルを取得できます。

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

**スライド全体ではなく、特定の形状（例：チャートや画像）だけをエクスポートするにはどうすればよいですか？**  
Aspose.Slides は [個別の形状のサムネイル生成](/slides/ja/java/create-shape-thumbnails/) をサポートしており、形状を PNG 画像としてレンダリングできます。

**サーバー上での並列変換はサポートされていますか？**  
はい、サポートされていますが、スレッド間で単一のプレゼンテーション インスタンスを [共有しない](/slides/ja/java/multithreading/) でください。各スレッドまたはプロセスごとに別々のインスタンスを使用してください。

**PNG へのエクスポート時の評価版の制限は何ですか？**  
評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/java/licensing/) が適用されます。