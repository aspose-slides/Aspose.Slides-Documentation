---
title: 画像フレーム
type: docs
weight: 10
url: /ja/nodejs-java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームを追加
- 画像フレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- 画像をトリミング
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- 画像効果
- アスペクト比
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "JavaScript で PowerPoint プレゼンテーションに画像フレームを追加"
---

画像フレームは画像を含む形状で、フレーム内の画像のようなものです。

画像フレームを介してスライドに画像を追加できます。この方法では、画像フレームの書式設定により画像の書式設定が可能になります。

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータ（[JPEGからPowerPointへ](https://products.aspose.app/slides/import/jpg-to-ppt) および [PNGからPowerPointへ](https://products.aspose.app/slides/import/png-to-ppt)）を提供しており、画像からプレゼンテーションをすばやく作成できます。 

{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) に画像を追加して `PPImage` オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプ オブジェクトが公開する `addPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) を作成します。  
6. 画像フレーム（画像を含む）をスライドに追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは画像フレームの作成方法を示しています。  
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します
    var sld = pres.getSlides().get_Item(0);
    // Image クラスのインスタンスを作成します
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 画像と同等の高さと幅でピクチャーフレームを追加します
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PPTX ファイルをディスクに保存します
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 

画像フレームを使用すると、画像に基づいたスライドをすばやく作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、入力/出力操作を操作して画像を別の形式に変換できます。以下のページもご参照ください：変換 [画像からJPGへ](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/)；変換 [JPGから画像へ](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/)；変換 [JPGからPNGへ](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/)、変換 [PNGからJPGへ](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/)；変換 [PNGからSVGへ](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/)、変換 [SVGからPNGへ](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/)。

{{% /alert %}}

## **相対スケール付き画像フレームの作成**

画像の相対スケーリングを変更することで、より複雑な画像フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーション オブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) に画像を追加して [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
5. 画像フレーム内で画像の相対幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは相対スケール付き画像フレームの作成方法を示しています。  
```javascript
// PPTX を表す Presentation クラスをインスタンス化します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します
    var sld = pres.getSlides().get_Item(0);
    // Image クラスをインスタンス化します
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 画像と同等の高さと幅でピクチャーフレームを追加します
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 相対スケールの幅と高さを設定します
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // PPTX ファイルをディスクに保存します
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **画像フレームからラスター画像を抽出**

[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。  
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


## **画像フレームから SVG 画像を抽出**

プレゼンテーション内に SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) シェイプに配置されている場合、Node.js 用 Aspose.Slides は元のベクター画像をフルフィデリティで取得できます。スライドのシェイプ コレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) を特定し、基になる [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存できます。

次のコード例は画像フレームから SVG 画像を抽出する方法を示しています。  
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


## **画像の透明度取得**

Aspose.Slides では画像に適用された透明度効果を取得できます。この JavaScript コードは操作を示しています。  
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

Aspose.Slides は画像フレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて画像フレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) に画像を追加して [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [Shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが公開する [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. 画像フレーム（画像を含む）をスライドに追加します。  
7. 画像フレームの線の色を設定します。  
8. 画像フレームの線幅を設定します。  
9. 正または負の値で画像フレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. 画像フレーム（画像を含む）をスライドに追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは画像フレームの書式設定プロセスを実演します。  
```javascript
// PPTX を表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します
    var sld = pres.getSlides().get_Item(0);
    // Image クラスのインスタンスを作成します
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 画像と同等の高さと幅でピクチャーフレームを追加します
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PictureFrameEx にいくつかの書式設定を適用します
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // PPTX ファイルを書き出します
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Tip" color="primary" %}}

Aspose は最近、無料の [Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG または PNG 画像を結合したり、写真からグリッドを作成したりする必要がある場合は、このサービスを利用できます。 

{{% /alert %}}

## **リンクとして画像を追加**

プレゼンテーションのサイズを大きくしないように、ファイルを直接埋め込む代わりにリンクを介して画像（や動画）を追加できます。この JavaScript コードはプレースホルダーに画像と動画を追加する方法を示しています。  
```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **画像のトリミング**

この JavaScript コードはスライド上の既存画像をトリミングする方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
// 新しい画像オブジェクトを作成します
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // スライドに PictureFrame を追加します
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // 画像をトリミングします（パーセンテージ値）
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // 結果を保存します
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **画像フレームのトリミング領域を削除**

フレームに含まれる画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドはトリミングされた画像またはトリミングが不要な場合は元の画像を返します。

この JavaScript コードは操作を実演します。  
```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 最初のスライドから PictureFrame を取得します
    var picFrame = slide.getShapes().get_Item(0);
    // PictureFrame の画像のトリミングされた領域を削除し、トリミング後の画像を返します
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // 結果を保存します
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズが削減されます。そうでない場合、結果として得られるプレゼンテーションの画像数は増加します。

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスター PNG 画像に変換します。 

{{% /alert %}}

## **アスペクト比ロック**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。

この JavaScript コードはシェイプのアスペクト比をロックする方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // リサイズ時にアスペクト比を保持するようにシェイプを設定します
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

*Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプに含まれる画像のアスペクト比は保持しません。

{{% /alert %}}

## **StretchOff プロパティの使用**

[PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat) クラスの [setStretchOffsetLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-)、[setStretchOffsetTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--)、[setStretchOffsetRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) および [setStretchOffsetBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) メソッドを使用して、塗りつぶし矩形を指定できます。

画像のストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各エッジは、シェイプのバウンディング ボックスの対応するエッジからのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを示します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentatio) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディング ボックスの対応するエッジからの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは StretchOff プロパティを使用したプロセスを実演します。  
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します
    var slide = pres.getSlides().get_Item(0);
    // ImageEx クラスのインスタンスを作成します
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 四角形になる AutoShape を追加します
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // シェイプの塗りつぶしタイプを設定します
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // シェイプの画像塗りつぶしモードを設定します
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // シェイプを埋める画像を設定します
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // シェイプのバウンディングボックスの対応するエッジから画像のオフセットを指定します
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // PPTX ファイルをディスクに書き出します
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**画像フレームでサポートされている画像形式はどのように確認できますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを介して、ラスター画像（PNG、JPEG、BMP、GIF など）およびベクター画像（たとえば SVG）をサポートします。サポートされている形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供してサイズ削減を支援します。

**画像オブジェクトが誤って移動・サイズ変更されないようにロックするには？**

[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) を使用します（例：移動やサイズ変更の無効化）。ロック機構は別記事の [保護に関する記事](/slides/ja/nodejs-java/applying-protection-to-presentation/) に記載されており、さまざまなシェイプ タイプ（[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) を含む）でサポートされています。

**SVG ベクターの忠実度は PDF/画像へのエクスポート時に保持されますか？**

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。[PDF へのエクスポート](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) や [ラスター形式へのエクスポート](/slides/ja/nodejs-java/convert-powerpoint-to-png/) 時の結果はエクスポート設定に依存し、場合によってはラスター化されます。抽出動作により元の SVG がベクターとして保持されていることが確認できます。