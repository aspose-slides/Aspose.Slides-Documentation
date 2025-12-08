---
title: PowerPoint を JPG に変換
type: docs
weight: 60
url: /ja/nodejs-java/convert-powerpoint-to-jpg/
keywords: "PowerPoint を JPG に変換, PPTX を JPEG に変換, PPT を JPEG に変換"
description: "PowerPoint を JPG に変換: JavaScript で PPT を JPG、PPTX を JPG"
---

## **PowerPointからJPGへの変換について**
[**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) を使用すると、PowerPoint の PPT または PPTX プレゼンテーションを JPG 画像に変換できます。PPT/PPTX を JPEG、PNG、SVG に変換することも可能です。この機能により、独自のプレゼンテーションビューアを実装したり、各スライドのサムネイルを作成したりするのが簡単になります。プレゼンテーションスライドのコピーガードや、読み取り専用モードでのデモンストレーションに役立ちます。Aspose.Slides は、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

{{% alert color="primary" %}} 
Aspose.Slides が PowerPoint を JPG 画像に変換する様子を確認したい場合は、次の無料オンラインコンバータをお試しください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 
{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX を JPG に変換する手順**
PPT/PPTX を JPG に変換する手順は以下の通りです:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 型のインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) コレクションから [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 型のスライドオブジェクトを取得します。
3. 各スライドのサムネイルを作成し、JPG に変換します。[**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) メソッドを使用してスライドのサムネイルを取得し、[Images](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images) オブジェクトが返されます。[getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) メソッドは、必要な [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 型のスライドから呼び出す必要があり、生成されるサムネイルのスケールはメソッドに渡されます。
4. スライドのサムネイルを取得したら、サムネイルオブジェクトの [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) メソッドを呼び出します。ファイル名と画像形式を渡してください。

{{% alert color="primary" %}}
**Note**: PPT/PPTX から JPG への変換は、Aspose.Slides API の他のタイプへの変換とは手順が異なります。その他のタイプでは通常 [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) メソッドを使用しますが、ここでは [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) メソッドを使用する必要があります。
{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // フルスケールの画像を作成します
        var slideImage = sld.getImage(1.0, 1.0);
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


## **カスタマイズされたサイズで PowerPoint PPT/PPTX を JPG に変換する方法**
生成されるサムネイルと JPG 画像のサイズを変更するには、[**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) メソッドに *ScaleX* と *ScaleY* の値を渡します。
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // 寸法を定義します
    var desiredX = 1200;
    var desiredY = 800;
    // X と Y のスケーリングされた値を取得します
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // フルスケールの画像を作成します
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


## **プレゼンテーションを画像に保存するときにコメントを描画する**
Aspose.Slides for Node.js via Java は、スライドを画像に変換する際にプレゼンテーションのコメントを描画できる機能を提供します。この JavaScript コードはその操作例です:
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
Aspose は [FREE Collage web app](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG to PNG 画像の結合、[photo grids](https://products.aspose.app/slides/collage/photo-grid) の作成などが可能です。

本記事で説明した原則を使って、画像を別の形式に変換することもできます。詳細は次のページをご参照ください: 画像を [JPG に変換](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/)；[JPG から画像へ変換](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/)；[JPG から PNG へ変換](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/)；[PNG から JPG へ変換](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/)；[PNG から SVG へ変換](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/)；[SVG から PNG へ変換](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/)。
{{% /alert %}}

## **See also**
PPT/PPTX を画像に変換する他のオプションは次をご覧ください:

- [PPT/PPTX to SVG conversion](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Does this method support batch conversion?**

はい、Aspose.Slides は複数のスライドを単一の操作で JPG にバッチ変換できます。

**Does the conversion support SmartArt, charts, and other complex objects?**

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどすべてのコンテンツを描画します。ただし、カスタム フォントや欠落フォントを使用した場合、PowerPoint と比較して描画精度がわずかに異なることがあります。

**Are there any limitations on the number of slides that can be processed?**

Aspose.Slides 自体は処理できるスライド数に厳格な制限を設けていません。ただし、非常に大きなプレゼンテーションや高解像度画像を扱う際に、メモリ不足エラーが発生する可能性があります。