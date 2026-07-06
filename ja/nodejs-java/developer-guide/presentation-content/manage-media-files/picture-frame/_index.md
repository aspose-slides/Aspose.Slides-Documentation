---
title: JavaScript を使用したプレゼンテーションでのピクチャーフレーム管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/nodejs-java/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームを追加
- ピクチャーフレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- ラスタ画像
- ベクタ画像
- 画像をトリミング
- トリミング領域
- StretchOff プロパティ
- ピクチャーフレームの書式設定
- ピクチャーフレームのプロパティ
- 相対スケール
- 画像効果
- アスペクト比
- 画像の透明度
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションにピクチャーフレームを追加します。ワークフローを効率化し、スライドデザインを強化しましょう。"
---
## **概要**

ピクチャーフレームは画像を含むシェイプで、フレーム内の画像のようなものです。  

ピクチャーフレームを使ってスライドに画像を追加できます。この方法では、ピクチャーフレームをフォーマットすることで画像をフォーマットできます。

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータ—[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt)—を提供しており、画像からプレゼンテーションをすばやく作成できます。 

{{% /alert %}} 

## **ピクチャーフレームの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ImageCollection) に画像を追加して `PPImage` オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプ オブジェクトの `addPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PictureFrame) を作成します。  
6. ピクチャーフレーム（画像を含む）をスライドに追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードはピクチャーフレームの作成方法を示しています：

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // Image クラスのインスタンスを作成
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 画像と同等の高さと幅でピクチャーフレームを追加
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

ピクチャーフレームを使用すると、画像に基づいたプレゼンテーション スライドをすばやく作成できます。ピクチャーフレームと Aspose.Slides の保存オプションを組み合わせることで、画像の形式変換などの入出力操作を操作できます。

## **相対スケール付きピクチャーフレームの作成**

画像の相対スケーリングを変更することで、より複雑なピクチャーフレームを作成できます。  

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーション オブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ImageCollection) に画像を追加して [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
5. ピクチャーフレーム内で画像の相対幅と高さを指定します。  
6. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは相対スケール付きピクチャーフレームの作成方法を示しています：

```javascript
// PPTX を表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // Image クラスをインスタンス化
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 画像と同等の高さと幅でピクチャーフレームを追加
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 相対スケールの幅と高さを設定
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

## **ピクチャーフレームからラスタ画像を抽出**

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

## **ピクチャーフレームから SVG 画像を抽出**

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) シェイプ内に配置された SVG グラフィックが含まれている場合、Aspose.Slides for Node.js via Java を使用して元のベクタ画像を完全な忠実度で取得できます。スライドのシェイプ コレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) を特定し、基になる [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存します。

以下のコード例は、ピクチャーフレームから SVG 画像を抽出する方法を示しています：

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

Aspose.Slides では画像に適用された透明度効果を取得できます。この JavaScript コードは操作を示しています：

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

## **画像の明るさとコントラスト取得**

Aspose.Slides では画像に適用された明るさとコントラスト効果を取得できます。[Luminance](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/luminance/) クラスがこの画像変換効果を表します。

この JavaScript コードはピクチャーフレームから明るさとコントラスト設定を取得する方法を示しています：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **ピクチャーフレームの書式設定**

Aspose.Slides はピクチャーフレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせてピクチャーフレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ImageCollection) に画像を追加して [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [Shapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ShapeCollection) オブジェクトの [addPictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. ピクチャーフレーム（画像を含む）をスライドに追加します。  
7. ピクチャーフレームの線の色を設定します。  
8. ピクチャーフレームの線の幅を設定します。  
9. 正または負の値を指定してピクチャーフレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. ピクチャーフレーム（画像を含む）をスライドに再度追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードはピクチャーフレームの書式設定プロセスを示しています：

```javascript
// PPTX を表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // Image クラスのインスタンスを作成
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 画像と同等の高さと幅でピクチャーフレームを追加
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PictureFrameEx にいくつかの書式設定を適用
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // PPTX ファイルをディスクに書き込む
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose は最近、無料の [Collage Maker](https://products.aspose.app/slides/ja/collage) を開発しました。JPG/JPEG や PNG 画像を結合したり、写真からグリッドを作成したりする必要がある場合は、このサービスをご利用ください。 

{{% /alert %}}

## **リンクとして画像を追加**

プレゼンテーションのサイズを大きくしないために、ファイルを直接埋め込む代わりにリンクを介して画像（または動画）を追加できます。この JavaScript コードはプレースホルダーに画像と動画を追加する方法を示しています：

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

この JavaScript コードはスライド上の既存画像をトリミングする方法を示しています：

```javascript
var pres = new aspose.slides.Presentation();
// 新しい画像オブジェクトを作成
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
    // スライドにピクチャーフレームを追加
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // 画像をトリミング（パーセンテージ値）
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // 結果を保存
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ピクチャーフレームのトリミング領域を削除**

フレーム内の画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドはトリミングされた画像またはトリミングが不要な場合は元の画像を返します。

この JavaScript コードは操作を示しています：

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 最初のスライドから PictureFrame を取得
    var picFrame = slide.getShapes().get_Item(0);
    // PictureFrame 画像のトリミング領域を削除し、トリミングされた画像を返す
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // 結果を保存
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズが削減できます。そうでない場合、結果として生成されるプレゼンテーションの画像数は増加します。

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 

{{% /alert %}}

## **画像の圧縮**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) メソッドを使用してプレゼンテーション内の画像を圧縮できます。このメソッドはシェイプのサイズと指定された解像度に基づいて画像サイズを縮小し、トリミング領域を削除するオプションも提供します。

PowerPoint の **Picture Format → Compress Pictures → Resolution** 機能と同様に、画像のサイズと解像度を調整します。

以下の JavaScript 例は、対象解像度を指定し、必要に応じてトリミング領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています：

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // ターゲット解像度 150 DPI（Web 解像度）で画像を圧縮し、トリミング領域を削除します。
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // 圧縮の結果を確認します。
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

または別の事前定義 DPI 値を使用する場合：

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 画像を 96 DPI（メール解像度）に圧縮し、トリミング領域を削除します。
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

このメソッドはシェイプのサイズと提供された DPI に基づいて画像を低解像度に変換します。トリミング領域も削除してファイルサイズを最適化できます。画像がメタファイル（WMF/EMF）または SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて維持またはわずかに低下します（PowerPoint の動作と同様）。 

{{% /alert %}}

## **アスペクト比の固定**

画像を含むシェイプのアスペクト比を、画像サイズを変更した後も保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。

この JavaScript コードはシェイプのアスペクト比をロックする方法を示しています：

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
    // リサイズ時にアスペクト比を保持するようにシェイプを設定
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

この *Lock Aspect Ratio* 設定はシェイプ自体のアスペクト比のみを保持し、シェイプが保持する画像のアスペクト比は保持しません。 

{{% /alert %}}

## **StretchOff プロパティの使用**

[PictureFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PictureFillFormat) クラスの [setStretchOffsetLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-)、[setStretchOffsetTop](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--)、[setStretchOffsetRight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--)、[setStretchOffsetBottom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) メソッドを使用して、塗りつぶし矩形を指定できます。

画像のストレッチが指定されている場合、ソース矩形は指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺はシェイプのバウンディング ボックスの対応する辺からのパーセンテージ オフセットで定義されます。正のパーセンテージはインセットを、負のパーセンテージはアウトセットを表します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは StretchOff プロパティを使用したプロセスを示しています：

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var slide = pres.getSlides().get_Item(0);
    // ImageEx クラスのインスタンスを作成
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 矩形に設定された AutoShape を追加
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // シェイプの塗りつぶしタイプを設定
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // シェイプの画像塗りつぶしモードを設定
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // 画像をシェイプの塗りつぶしに設定
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // PPTX ファイルをディスクに書き込む
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**PictureFrame がサポートする画像形式はどのように確認できますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを通じて、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクタ画像（例: SVG）の両方をサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**多数の大きな画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルへのアクセスが必要です。Aspose.Slides はリンクによる画像追加機能を提供し、ファイルサイズ削減を支援します。

**画像オブジェクトを誤って移動・サイズ変更しないようにロックできますか？**

[shape locks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) を使用して [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) をロックできます（例: 移動やサイズ変更を無効化）。ロック機構はさまざまなシェイプ タイプでサポートされています。

**SVG ベクタの忠実度は PDF/画像へのエクスポート時に保たれますか？**

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) から元のベクタとして SVG を抽出できます。[PDF へのエクスポート](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) や [ラスタ形式へのエクスポート](/slides/ja/nodejs-java/convert-powerpoint-to-png/) 時の設定に応じて、結果はラスタ化される場合がありますが、元の SVG がベクタとして保存されていることは抽出動作で確認できます。