---
title: "JavaScript を使用してプレゼンテーションの画像フレームを管理する"
linktitle: "画像フレーム"
type: docs
weight: 10
url: /ja/nodejs-java/picture-frame/
keywords:
- "画像フレーム"
- "画像フレームを追加"
- "画像フレームを作成"
- "画像を追加"
- "画像を作成"
- "画像を抽出"
- "ラスタ画像"
- "ベクタ画像"
- "画像をトリミング"
- "トリミング領域"
- "StretchOff プロパティ"
- "画像フレームの書式設定"
- "画像フレームのプロパティ"
- "相対スケール"
- "画像効果"
- "アスペクト比"
- "画像の透明度"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---
## **はじめに**

画像フレームは画像を含むシェイプで、フレーム内の画像のようなものです。

画像フレームを介してスライドに画像を追加できます。この方法で、画像を画像フレームの書式設定することで画像自体をフォーマットできます。

{{% alert  title="ヒント" color="primary" %}} 

Aspose は無料コンバータ―を提供しています—[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) — これにより画像からプレゼンテーションをすばやく作成できます。 

{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ImageCollection) に画像を追加して `PPImage` オブジェクトを作成し、シェイプの塗りに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照したスライドに関連付けられたシェイプオブジェクトが提供する `addPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PictureFrame) を作成します。  
6. 画像フレーム（画像を含む）をスライドに追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして書き込みます。  

この JavaScript コードは画像フレームの作成方法を示しています:

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得する
    var sld = pres.getSlides().get_Item(0);
    // Image クラスのインスタンスを作成する
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 画像と同等の高さと幅で画像フレームを追加する
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PPTX ファイルをディスクに書き込む
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

画像フレームを使用すると、画像に基づいたプレゼンテーションスライドをすばやく作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、画像の入力/出力操作を操作し、形式を変換できます。

## **相対スケールで画像フレームを作成する**

画像の相対スケーリングを変更することで、より複雑な画像フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーションオブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ImageCollection) に画像を追加して [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、シェイプの塗りに使用します。  
5. 画像フレーム内で画像の相対幅と高さを指定します。  
6. 変更したプレゼンテーションを PPTX ファイルとして書き込みます。  

この JavaScript コードは相対スケールで画像フレームを作成する方法を示しています:

```javascript
// PPTX を表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得する
    var sld = pres.getSlides().get_Item(0);
    // Image クラスのインスタンスを作成する
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 画像と同等の高さと幅で画像フレームを追加する
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 相対スケールの幅と高さを設定する
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // PPTX ファイルをディスクに書き込む
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **画像フレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PictureFrame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **画像フレームから SVG 画像を抽出する**

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for Node.js via Java を使用して元のベクター画像をフルフィデリティで取得できます。スライドのシェイプコレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) を特定し、基になる [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) が SVG コンテンツを保持しているか確認した上で、画像をディスクまたはストリームにネイティブ SVG 形式で保存します。

以下のコード例は、画像フレームから SVG 画像を抽出する方法を示しています:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **画像の透明度を取得する**

Aspose.Slides は画像に適用された透明度効果を取得できます。この JavaScript コードはその操作を示しています:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **画像フレームの書式設定**

Aspose.Slides は画像フレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、画像フレームを特定の要件に合わせて変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ImageCollection) に画像を追加して [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、シェイプの塗りに使用します。  
4. 画像の幅と高さを指定します