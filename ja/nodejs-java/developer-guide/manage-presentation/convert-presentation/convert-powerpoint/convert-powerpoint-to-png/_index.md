---
title: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/nodejs-java/convert-powerpoint-to-png/
keywords: PowerPoint を PNG に変換, PPT を PNG に変換, PPTX を PNG に変換, java, Node.js 用 Aspose.Slides (Java 経由)
description: PowerPoint プレゼンテーションを PNG に変換
---

## **PowerPointからPNGへの変換について**

PNG（Portable Network Graphics）フォーマットはJPEG（Joint Photographic Experts Group）ほど人気はありませんが、依然として非常に人気があります。 

**Use case:** 複雑な画像でサイズが問題でない場合、PNGはJPEGより優れた画像フォーマットです。 

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint to PNG Converters** をチェックしたいかもしれません: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらはこのページで説明されたプロセスの実装です。 {{% /alert %}}

## **PowerPointをPNGに変換**

以下の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) メソッドで返されるコレクションから、[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) クラスのスライドオブジェクトを取得します。
3. 各スライドのサムネイルを取得するために、[Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) メソッドを使用します。
4. スライドのサムネイルを PNG 形式で保存するために、[**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String%20formatName,%20int%20imageFormat)) メソッドを使用します。

この JavaScript コードは PowerPoint プレゼンテーションを PNG に変換する方法を示しています:
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

この JavaScript コードは上記の操作を示しています:
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

特定のサイズの PNG ファイルを取得したい場合、`ImageSize` に対して希望する `width` と `height` の引数を渡すことができます。 

このコードは画像のサイズを指定して PowerPoint を PNG に変換する方法を示しています: 
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

**スライド全体ではなく、特定の形状（例: グラフや画像）のみをエクスポートするにはどうすればよいですか？**  
Aspose.Slides は [個々の形状のサムネイル生成](/slides/ja/nodejs-java/create-shape-thumbnails/) をサポートしています。形状を PNG 画像としてレンダリングできます。  

**サーバーでの並列変換はサポートされていますか？**  
はい、ただし単一のプレゼンテーション インスタンスをスレッド間で共有しないでください。[共有しない](/slides/ja/nodejs-java/multithreading/)ことが重要です。スレッドまたはプロセスごとに別々のインスタンスを使用してください。  

**PNG へのエクスポート時の試用版の制限は何ですか？**  
評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/nodejs-java/licensing/) が課せられます。