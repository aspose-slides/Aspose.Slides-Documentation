---
title: JavaScript を使用したプレゼンテーションでの画像フレームの管理
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/nodejs-java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 画像の追加
- 画像の作成
- 画像の抽出
- ラスター画像
- ベクター画像
- 画像のトリミング
- トリミング領域
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
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
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを強化します。"
---

Picture frame は画像を含むシェイプです—フレーム内の写真のようなものです。

スライドに画像を Picture frame を介して追加できます。この方法では、Picture frame を書式設定することで画像を書式設定できます。

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータを提供しています—[JPEG から PowerPoint へ](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG から PowerPoint へ](https://products.aspose.app/slides/import/png-to-ppt)—これにより画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) に画像を追加し、`PPImage` オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプ オブジェクトが公開する `addPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは画像フレームの作成方法を示しています:
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
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Picture frame を使用すると、画像に基づくプレゼンテーション スライドをすばやく作成できます。Picture frame と Aspose.Slides の保存オプションを組み合わせることで、画像の入出力操作を操作し、ある形式から別の形式へ変換できます。

## **相対スケールを使用した画像フレームの作成**

画像の相対スケーリングを変更すると、より複雑な画像フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーション オブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) に画像を追加し、[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) オブジェクトを作成します。  
5. 画像フレーム内の画像の相対幅と高さを指定します。  
6. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは相対スケールを使用した画像フレームの作成方法を示しています:
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
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **画像フレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。
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

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for Node.js via Java で元のベクター画像を完全な忠実度で取得できます。スライドのシェイプ コレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) を特定し、基になる [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存します。

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

Aspose.Slides を使用すると、画像に適用された透明度効果を取得できます。この JavaScript コードはその操作を示しています:
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

Aspose.Slides は画像フレームに適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、画像フレームを特定の要件に合わせて変更できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) に画像を追加し、[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. [Shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが公開する [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 画像フレームの線の色を設定します。  
8. 画像フレームの線幅を設定します。  
9. 正の値または負の値を指定して画像フレームを回転させます。  
   * 正の値は時計回りに回転します。  
   * 負の値は反時計回りに回転します。  
10. 画像フレーム（画像を含む）をスライドに追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは画像フレームの書式設定プロセスを示しています:
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
    // PictureFrameEx にいくつかの書式設定を適用します
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Tip" color="primary" %}}

Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG または PNG 画像の [結合](https://products.aspose.app/slides/collage/jpg) や、[写真からグリッド作成](https://products.aspose.app/slides/collage/photo-grid) が必要な場合は、このサービスをご利用ください。 

{{% /alert %}}

## **リンクとして画像を追加する**

プレゼンテーションのサイズを抑えるために、画像や動画を埋め込むのではなくリンクとして追加できます。この JavaScript コードはプレースホルダーに画像と動画を追加する方法を示しています:
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


## **画像をトリミングする**

この JavaScript コードはスライド上の既存画像をトリミングする方法を示しています:
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


## **画像フレームのトリミング領域を削除する**

フレーム内の画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドは、トリミングが不要な場合は元の画像を返します。

この JavaScript コードはその操作を示しています:
```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 最初のスライドから PictureFrame を取得します
    var picFrame = slide.getShapes().get_Item(0);
    // PictureFrame 画像のトリミングされた領域を削除し、トリミングされた画像を返します
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

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションサイズを削減できます。そうでない場合は、結果として生成されるプレゼンテーションの画像数が増加します。

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 

{{% /alert %}}

## **アスペクト比を固定する**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。

この JavaScript コードはシェイプのアスペクト比を固定する方法を示しています:
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
    // 形状をリサイズ時にアスペクト比を保持するように設定します
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

この *Lock Aspect Ratio* 設定はシェイプ自体のアスペクト比のみを保持し、シェイプに含まれる画像のアスペクト比は保持しません。

{{% /alert %}}

## **StretchOff プロパティを使用する**

[PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat) クラスの [setStretchOffsetLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-)、[setStretchOffsetTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--)、[setStretchOffsetRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--)、[setStretchOffsetBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) メソッドを使用して、塗りつぶし矩形を指定できます。

画像の伸縮が指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各エッジは、シェイプのバウンディング ボックスの対応するエッジからのパーセンテージ オフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `AutoShape` の矩形を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディング ボックスの対応するエッジからの画像オフセットを指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この JavaScript コードは StretchOff プロパティを使用したプロセスを示しています:
```javascript
// PPTX ファイルを表す Prseetation クラスのインスタンスを作成します
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
    // 矩形に設定された AutoShape を追加します
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // シェイプの塗りつぶしタイプを設定します
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // シェイプの画像塗りつぶしモードを設定します
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // シェイプを塗りつぶす画像を設定します
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // シェイプの境界ボックスの対応するエッジからの画像オフセットを指定します
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // PPTX ファイルをディスクに書き込みます
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

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを介して、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクター画像（例: SVG）の両方をサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイル サイズとメモリ使用量が増加します。画像へのリンクを使用するとプレゼンテーションのサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供しており、ファイルサイズ削減に役立ちます。

**画像オブジェクトを誤って移動/リサイズしないようにロックするには？**

[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) を使用できます（例: 移動やリサイズを無効化）。このロック機構は、[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) を含むさまざまなシェイプ タイプでサポートされています。

**SVG ベクターフィデリティは PDF/画像へのエクスポート時に保持されますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。[PDF にエクスポート](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) や [ラスタ形式にエクスポート](/slides/ja/nodejs-java/convert-powerpoint-to-png/) する際、エクスポート設定に応じてラスタ化される場合がありますが、抽出動作により元の SVG がベクターとして保持されていることが確認できます。