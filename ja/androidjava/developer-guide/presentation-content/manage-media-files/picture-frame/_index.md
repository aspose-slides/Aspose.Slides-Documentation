---
title: Android でのプレゼンテーションにおける画像フレームの管理
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/androidjava/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 画像の追加
- 画像の作成
- 画像の抽出
- ラスター画像
- ベクター画像
- 画像の切り取り
- 切り取られた領域
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させます。"
---
## **イントロダクション**

Picture frame は画像を含むシェイプで、フレーム内の画像のようなものです。  

スライドに画像を Picture Frame を介して追加できます。この方法で、Picture Frame をフォーマットすることで画像をフォーマットできます。  

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータ―、[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) を提供しており、画像から迅速にプレゼンテーションを作成できます。  

{{% /alert %}} 

## **Picture Frame の作成**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IImageCollection) に画像を追加して、[IPPImage]() オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/PictureFrame) を作成します。  
6. スライドに画像を含む Picture Frame を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは Picture Frame の作成方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同等の高さと幅で画像フレームを追加
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルをディスクに保存
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **相対スケール付き Picture Frame の作成**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IImageCollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。  
5. 画像の相対幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは相対スケール付き Picture Frame の作成方法を示しています：

```java
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 画像と同等の高さと幅で Picture Frame を追加
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 相対スケール幅と高さを設定
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX ファイルをディスクに保存
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Picture Frame からラスター画像を抽出**

[PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/PictureFrame) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出して PNG 形式で保存する方法を示しています。

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

## **Picture Frame から SVG 画像を抽出**

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) シェイプ内に配置された SVG グラフィックが含まれている場合、Aspose.Slides for Android via Java を使用すると、元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存できます。

以下のコード例は Picture Frame から SVG 画像を抽出する方法を示しています：

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

## **画像の透明度を取得**

Aspose.Slides では画像に適用された透明度効果を取得できます。この Java コードはその操作を示しています：

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

## **画像の明るさとコントラストを取得**

Aspose.Slides では画像に適用された明るさとコントラストの効果を取得できます。[ILuminance](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iluminance/) インターフェイスはこの画像変換効果を表します。

この Java コードは Picture Frame から明るさとコントラストの設定を取得する方法を示しています：

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Picture Frame の書式設定**

Aspose.Slides は Picture Frame に適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて Picture Frame を変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IImageCollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [IShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [AddPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像を含む Picture Frame を追加します。  
7. Picture Frame の線の色を設定します。  
8. Picture Frame の線の幅を設定します。  
9. 正または負の値で Picture Frame を回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. Picture Frame（画像を含む）をスライドに追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは Picture Frame の書式設定プロセスを示しています：

```java
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同等の高さと幅で Picture Frame を追加
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameEx にいくつかの書式設定を適用
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // PPTX ファイルをディスクに書き出し
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/ja/collage) を開発しました。JPG/JPEG や PNG 画像を [結合](https://products.aspose.app/slides/ja/collage/jpg) したり、[写真からグリッドを作成](https://products.aspose.app/slides/ja/collage/photo-grid) したりする必要がある場合は、このサービスを利用できます。  

{{% /alert %}}

## **リンクとして画像を追加**

プレゼンテーションのサイズが大きくなるのを防ぐために、ファイルを直接埋め込む代わりにリンクで画像（または動画）を追加できます。この Java コードはプレースホルダーに画像と動画を追加する方法を示しています：

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

## **画像の切り取り**

この Java コードはスライド上の既存画像を切り取る方法を示しています：

```java
Presentation pres = new Presentation();
// 新しい画像オブジェクトを作成
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // スライドに PictureFrame を追加
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // 画像をトリミング（パーセンテージ値）
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // 結果を保存
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Picture の切り取られた領域を削除**

フレームに含まれる画像の切り取られた領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドは、切り取りが不要な場合は元の画像、切り取られた画像を返します。

この Java コードはその操作を示しています：

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 最初のスライドから PictureFrame を取得
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame 画像の切り取られた領域を削除し、切り取られた画像を返す
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 結果を保存
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドは、切り取られた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズを削減できます。そうでなければ、結果のプレゼンテーションに含まれる画像数が増加します。

このメソッドは、切り取り操作で WMF/EMF メタファイルをラスター PNG 画像に変換します。 

{{% /alert %}}

## **画像の圧縮**

プレゼンテーション内の画像を [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) メソッドを使用して圧縮できます。このメソッドは、シェイプのサイズと指定された解像度に基づいて画像のサイズを縮小し、切り取られた領域を削除するオプションを提供します。

PowerPoint の **Picture Format > Compress Pictures > Resolution** 機能と同様に、画像のサイズと解像度を調整します。

以下の Java 例は、目標解像度を指定し、必要に応じて切り取られた領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています：

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 画像を目標解像度 150 DPI（Web 解像度）で圧縮し、切り取られた領域を削除します。
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // 圧縮の結果を確認します。
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

またはカスタム DPI 値を直接使用する場合：

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 画像を 150 DPI（Web 解像度）に圧縮し、切り取られた領域を削除します。
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

このメソッドは、シェイプのサイズと指定された DPI に基づいて画像を低解像度に変換します。ファイルサイズを最適化するために、切り取られた領域も削除できます。  
画像がメタファイル (WMF/EMF) または SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて維持またはわずかに低下します。これは PowerPoint が高解像度 JPEG を扱う方法と同様です。 

{{% /alert %}}

## **アスペクト比ロック**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。

この Java コードはシェイプのアスペクト比をロックする方法を示しています：

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

    // リサイズ時にアスペクト比を保持するようにシェイプを設定
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、含まれる画像のアスペクト比は保持しません。 

{{% /alert %}}

## **StretchOff プロパティの使用**

[StretchOffsetLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを [IPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat) クラスから使用して、塗りつぶし矩形を指定できます。

画像に対してストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせて拡大縮小されます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット（内側）を、負のパーセンテージはアウトセット（外側）を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. 矩形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは StretchOff プロパティが使用されるプロセスを示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx クラスのインスタンスを作成
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Rectangle に設定された AutoShape を追加
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // シェイプの塗りつぶしタイプを設定
    aShape.getFillFormat().setFillType(FillType.Picture);

    // シェイプの画像塗りつぶしモードを設定
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // シェイプを埋める画像を設定
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // シェイプのバウンディングボックスの対応する辺から画像のオフセットを指定
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // PPTX ファイルをディスクに書き出し
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**PictureFrame がサポートする画像形式はどのように確認できますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じて、ラスター画像（PNG、JPEG、BMP、GIF など）とベクター画像（例: SVG）の両方をサポートしています。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**大量の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクで追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクで画像を追加する機能を提供し、ファイルサイズを削減できます。

**画像オブジェクトが誤って移動/サイズ変更されないようにロックするにはどうすればよいですか？**

[shape locks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) を [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) に使用します（例: 移動やサイズ変更を無効にする）。ロック機構は、[PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) を含むさまざまなシェイプタイプでサポートされています。

**プレゼンテーションを PDF/画像にエクスポートする際、SVG ベクターの忠実度は保たれますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) から SVG を元のベクトルとして抽出できます。PDF やラスター形式へのエクスポート時には、エクスポート設定に応じて結果がラスター化されることがありますが、元の SVG がベクトルとして保存されていることは抽出動作で確認できます。