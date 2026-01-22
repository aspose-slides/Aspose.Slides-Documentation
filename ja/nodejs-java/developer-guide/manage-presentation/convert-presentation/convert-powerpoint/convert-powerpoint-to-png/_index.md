---
title: JavaScript で PowerPoint スライドを PNG に変換
linktitle: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/nodejs-java/convert-powerpoint-to-png/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、JavaScript で PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を実現します。"
---

## **PowerPoint から PNG への変換について**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として非常に人気があります。

**Use case:** 複雑な画像でサイズが問題にならない場合、PNG は JPEG よりも優れた画像形式です。

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint to PNG Converters** を確認したいかもしれません: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらはこのページで説明したプロセスの実際の実装です。 {{% /alert %}}

## **PowerPoint を PNG に変換**

以下の手順に従ってください：

1. インスタンス化する [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラス。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) メソッドが返すコレクションからスライドオブジェクトを取得し、[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) クラスで使用します。
3. [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) メソッドを使用して各スライドのサムネイルを取得します。
4. [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) メソッドを使用してスライドサムネイルを PNG 形式で保存します。

この JavaScript コードは PowerPoint プレゼンテーションを PNG に変換する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カスタム寸法で PowerPoint を PNG に変換**

特定のスケールの PNG ファイルを取得したい場合、結果のサムネイルの寸法を決定する `desiredX` と `desiredY` の値を設定できます。

この JavaScript コードは上記の操作を示しています：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カスタムサイズで PowerPoint を PNG に変換**

特定のサイズの PNG ファイルを取得したい場合、`ImageSize` のために希望する `width` と `height` の引数を渡すことができます。

このコードは画像のサイズを指定しながら PowerPoint を PNG に変換する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**スライド全体ではなく、特定のシェイプ（例: チャートや画像）だけをエクスポートするにはどうすればよいですか？**  
Aspose.Slides は [個々のシェイプのサムネイル生成](/slides/ja/nodejs-java/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバー上で並列変換はサポートされていますか？**  
はい、ただしスレッド間で単一のプレゼンテーション インスタンスを [共有しない](/slides/ja/nodejs-java/multithreading/) でください。スレッドまたはプロセスごとに別々のインスタンスを使用します。

**PNG へのエクスポート時の体験版の制限は何ですか？**  
評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/nodejs-java/licensing/) が適用されます。