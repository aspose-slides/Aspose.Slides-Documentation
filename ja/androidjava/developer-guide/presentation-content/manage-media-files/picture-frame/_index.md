---
title: Android のプレゼンテーションで画像フレームを管理する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/androidjava/picture-frame/
keywords:
- 画像フレーム
- 画像フレームを追加
- 画像フレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- ラスター画像
- ベクター画像
- 画像を切り抜く
- 切り抜き領域
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- 相対スケール
- 画像効果
- アスペクト比
- 画像の透過性
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。作業フローを合理化し、スライドデザインを向上させます。"
---

画像フレームは画像を含む形状で、フレームに入った写真のようなものです。

画像フレームを使用してスライドに画像を追加できます。これにより、画像フレームの書式設定を行うことで画像の書式設定が可能になります。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータを提供しています—[JPEGからPowerPointへ](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNGからPowerPointへ](https://products.aspose.app/slides/import/png-to-ppt) —これにより画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) に画像を追加して、[IPPImage]() オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプ オブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは画像フレームの作成方法を示しています:  
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同じ高さと幅でピクチャーフレームを追加します
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルを書き込みます
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **相対スケールを使用した画像フレームの作成**

画像の相対スケーリングを変更することで、より複雑な画像フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。  
5. 画像フレーム内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは相対スケール付き画像フレームの作成方法を示しています:  
```java
// PPTX を表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスをインスタンス化
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 画像と同等の高さと幅でピクチャーフレームを追加
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 相対スケールの幅と高さを設定
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX ファイルを書き込む
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **画像フレームからラスター画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し PNG 形式で保存する方法を示しています。  
```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```


## **画像フレームから SVG 画像を抽出する**

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for Android via Java を使用して元のベクター画像を完全な忠実度で取得できます。スライドのシェイプ コレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認したうえで、画像をディスクまたはストリームにネイティブ SVG 形式で保存します。  

以下のコード例は画像フレームから SVG 画像を抽出する方法を示しています:  
```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```


## **画像の透明度を取得する**

Aspose.Slides は画像に適用された透明度効果を取得できます。以下の Java コードがその操作を示しています:  
```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```


## **画像フレームの書式設定**

Aspose.Slides は画像フレームに適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて画像フレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [AddPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 画像フレームの線の色を設定します。  
8. 画像フレームの線の幅を設定します。  
9. 正の値または負の値を指定して画像フレームを回転させます。  
   * 正の値は時計回りに回転します。  
   * 負の値は反時計回りに回転します。  
10. 画像フレーム（画像を含む）をスライドに追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは画像フレームの書式設定プロセスを示しています:  
```java
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同等の高さと幅でピクチャーフレームを追加
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameEx にいくつかの書式設定を適用
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // PPTX ファイルを書き込む
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Tip" color="primary" %}}

Aspose は最近、[無料のコラージュメーカー](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG または PNG 画像を [結合したい](https://products.aspose.app/slides/collage/jpg) ときや、[写真からグリッドを作成したい](https://products.aspose.app/slides/collage/photo-grid) ときにこのサービスを利用できます。 
{{% /alert %}}

## **リンクとして画像を追加する**

プレゼンテーションのサイズが大きくなるのを防ぐために、ファイルを直接埋め込む代わりにリンクで画像（または動画）を追加できます。この Java コードはプレースホルダーに画像と動画を追加する方法を示しています:  
```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **画像の切り抜き**

この Java コードはスライド上の既存画像を切り抜く方法を示しています:  
```java
Presentation pres = new Presentation();
// 新しい画像オブジェクトを作成します
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // スライドに PictureFrame を追加します
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // 画像をクロップします（パーセンテージ値）
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // 結果を保存します
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **画像フレームの切り抜き領域を削除する**

フレームに含まれる画像の切り抜き領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドは、切り抜かれた画像または切り抜きが不要な場合は元の画像を返します。

この Java コードはその操作を示しています:  
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 最初のスライドから PictureFrame を取得します
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame の画像の切り抜き領域を削除し、切り抜かれた画像を返します
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 結果を保存します
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドは切り抜かれた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズを削減できます。そうでない場合、結果のプレゼンテーションの画像数が増加します。  

このメソッドは切り抜き操作中に WMF/EMF メタファイルをラスター PNG 画像に変換します。 
{{% /alert %}}

## **アスペクト比のロック**

画像の寸法を変更しても形状がアスペクト比を保持するようにしたい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。

この Java コードは形状のアスペクト比をロックする方法を示しています:  
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // サイズ変更時にアスペクト比を保持するようにシェイプを設定
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
*Lock Aspect Ratio* 設定は形状のアスペクト比のみを保持し、含まれる画像のアスペクト比は保持しません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを使用すると、塗りつぶし矩形を指定できます。

画像のストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせて拡大縮小されます。塗りつぶし矩形の各辺は、シェイプのバウンディング ボックスの対応する辺からのパーセンテージ オフセットで定義されます。正のパーセンテージはインセットを、負のパーセンテージはアウトセットを示します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 四角形の `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは StretchOff プロパティを使用したプロセスを示しています:  
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx クラスのインスタンスを作成します
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 四角形に設定された AutoShape を追加します
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // シェイプの塗りつぶしタイプを設定します
    aShape.getFillFormat().setFillType(FillType.Picture);

    // シェイプの画像塗りつぶしモードを設定します
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // 画像をシェイプの塗りつぶしに設定します
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //PPTX ファイルを書き込みます
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**画像フレームでサポートされている画像形式はどれですか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを介して、ラスタ画像（PNG、JPEG、BMP、GIF など）およびベクター画像（たとえば SVG）をサポートします。サポートされる形式の一覧は、スライドと画像変換エンジンの機能と概ね一致します。

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイル サイズとメモリ使用量が増加します。画像をリンクで追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルが引き続きアクセス可能である必要があります。Aspose.Slides はリンクで画像を追加する機能を提供し、ファイルサイズ削減に貢献します。

**画像オブジェクトが誤って移動/サイズ変更されないようにロックするにはどうすればよいですか？**

[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) を使用します（例: 移動やリサイズを無効にする）。ロック機構は [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) を含むさまざまなシェイプ タイプでサポートされています。

**SVG ベクターの忠実度は PDF/画像 へのエクスポート時に保持されますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。[PDF にエクスポート](/slides/ja/androidjava/convert-powerpoint-to-pdf/) や [ラスター形式にエクスポート](/slides/ja/androidjava/convert-powerpoint-to-png/) する際、エクスポート設定に応じて結果がラスター化されることがありますが、抽出動作により元の SVG がベクターとして保存されていることが確認できます。