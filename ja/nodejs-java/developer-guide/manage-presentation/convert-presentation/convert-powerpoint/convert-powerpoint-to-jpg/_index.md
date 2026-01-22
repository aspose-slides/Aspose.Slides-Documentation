---
title: JavaScriptでPPTおよびPPTXをJPGに変換
linktitle: PowerPointをJPGに変換
type: docs
weight: 60
url: /ja/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を JPG に変換
- プレゼンテーションを JPG に変換
- スライドを JPG に変換
- PPT を JPG に変換
- PPTX を JPG に変換
- PowerPoint を JPG として保存
- プレゼンテーションを JPG として保存
- スライドを JPG として保存
- PPT を JPG として保存
- PPTX を JPG として保存
- PPT を JPG にエクスポート
- PPTX を JPG にエクスポート
- Node.js
- JavaScript
- Aspose.Slides
description: "高速で信頼性の高いコード例を使用し、Node.js via Java 用の Aspose.Slides で JavaScript において PowerPoint (PPT、PPTX) スライドを高品質な JPG 画像に変換します。"
---

## **PowerPoint を JPG に変換するについて**
Aspose.Slides API を使用すると、PowerPoint の PPT または PPTX プレゼンテーションを JPG 画像に変換できます。PPT/PPTX を JPEG、PNG、SVG に変換することも可能です。この機能を使用すれば、独自のプレゼンテーション ビューアを実装したり、各スライドのサムネイルを作成したりするのが簡単です。プレゼンテーション スライドをコピーから保護したり、読み取り専用モードでデモンストレーションしたりする場合に便利です。Aspose.Slides を使用すると、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

{{% alert color="primary" %}} 
PowerPoint を JPG 画像に変換する Aspose.Slides の動作を確認したい場合は、次の無料オンライン コンバーターを試してみてください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。
{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX を JPG に変換する**
PPT/PPTX を JPG に変換する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 型のインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) コレクションから [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 型のスライド オブジェクトを取得します。
3. 各スライドのサムネイルを作成し、JPG に変換します。[**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) メソッドを使用してスライドのサムネイルを取得し、結果として [Images](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images) オブジェクトが返されます。必要な [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 型のスライドから [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) メソッドを呼び出し、結果のサムネイルのスケールをメソッドに渡します。
4. スライドのサムネイルを取得したら、サムネイル オブジェクトの [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) メソッドを呼び出します。ファイル名と画像形式を指定してください。

{{% alert color="primary" %}}

**注**: PPT/PPTX から JPG への変換は、Aspose.Slides API の他の形式への変換とは異なります。他の形式へ変換する場合は通常 [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) メソッドを使用しますが、ここでは [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) メソッドを使用する必要があります。

{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // フルスケール画像を作成
        var slideImage = sld.getImage(1.0, 1.0);
        // 画像を JPEG 形式でディスクに保存
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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


## **カスタマイズされたサイズで PowerPoint PPT/PPTX を JPG に変換する**
結果となるサムネイルおよび JPG 画像のサイズを変更するには、[**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) メソッドに *ScaleX* と *ScaleY* の値を渡して設定します。
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // 寸法を定義します
    var desiredX = 1200;
    var desiredY = 800;
    // X と Y のスケール値を取得します
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // フルスケール画像を作成します
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // 画像を JPEG 形式でディスクに保存します
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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


## **プレゼンテーションを画像に保存するときのコメントのレンダリング**
Aspose.Slides for Node.js via Java は、スライドを画像に変換する際にプレゼンテーションのスライド内のコメントをレンダリングする機能を提供します。以下の JavaScript コードはその操作例を示しています。
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
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


{{% alert title="Tip" color="primary" %}}
Aspose は [無料の Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンライン サービスを使用して、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG to PNG 画像を結合したり、[フォト グリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。
{{% /alert %}}

## **関連項目**

PPT/PPTX を画像に変換する他のオプションを参照してください:

- [PPT/PPTX から SVG への変換](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/)。

## **FAQ**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は複数のスライドを単一の操作で JPG にバッチ変換できます。

**変換は SmartArt、チャート、その他の複雑なオブジェクトをサポートしていますか？**

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどすべてのコンテンツをレンダリングします。ただし、カスタムフォントや欠損フォントを使用した場合、PowerPoint と比較して若干の精度差が生じることがあります。

**処理できるスライド数に制限はありますか？**

Aspose.Slides 自体はスライド数に厳格な制限を設けていません。ただし、巨大なプレゼンテーションや高解像度画像を扱う際にはメモリ不足エラーが発生する可能性があります。