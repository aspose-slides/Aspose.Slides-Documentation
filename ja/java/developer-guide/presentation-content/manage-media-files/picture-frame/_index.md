---
title: Java を使用したプレゼンテーションでの画像フレームの管理
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームを追加
- 画像フレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- ラスタ画像
- ベクタ画像
- 画像をトリミング
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---
## **概要**

画像フレームは画像を含む図形で、フレーム内の写真のようなものです。  

スライドに画像フレームを介して画像を追加できます。この方法で、画像フレームの書式設定により画像をフォーマットできます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ—[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt)—を提供しており、画像からプレゼンテーションを素早く作成できます。 
{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [IImageCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImageCollection) に画像を追加して、シェイプの塗りつぶしに使用する [IPPImage]() オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプ オブジェクトが公開する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/PictureFrame) を作成します。  
6. 画像フレーム（画像を含む）をスライドに追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは画像フレームの作成方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを生成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同等の高さと幅で画像フレームを追加します
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
画像フレームを使用すると、画像に基づくプレゼンテーション スライドを迅速に作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、入力/出力操作を操作して画像を別の形式に変換できます。次のページも参考になります：画像を [JPG に変換](https://products.aspose.com/slides/ja/java/conversion/image-to-jpg/)；[JPG から画像に変換](https://products.aspose.com/slides/ja/java/conversion/jpg-to-image/)；[JPG から PNG に変換](https://products.aspose.com/slides/ja/java/conversion/jpg-to-png/)、[PNG から JPG に変換](https://products.aspose.com/slides/ja/java/conversion/png-to-jpg/)；[PNG から SVG に変換](https://products.aspose.com/slides/ja/java/conversion/png-to-svg/)、[SVG から PNG に変換](https://products.aspose.com/slides/ja/java/conversion/svg-to-png/)。 
{{% /alert %}}

## **相対スケール付き画像フレームの作成**

画像の相対スケーリングを変更することで、より複雑な画像フレームを作成できます。  

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーション オブジェクトに関連付けられた [IImageCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImageCollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
5. 画像フレーム内の画像の相対幅と相対高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは相対スケール付き画像フレームの作成方法を示しています：

```java
// PPTX を表す Presentation クラスをインスタンス化します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスをインスタンス化します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 画像と同等の高さと幅で画像フレームを追加します
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 相対スケールの幅と高さを設定します
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **画像フレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/PictureFrame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し PNG 形式で保存する方法を示しています。

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

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) シェイプ内に配置された SVG グラフィックが含まれる場合、Aspose.Slides for Java は元のベクタ画像を完全な忠実度で取得できます。スライドのシェイプ コレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、必要に応じてその画像をネイティブ SVG 形式でディスクまたはストリームに保存します。

以下のコード例は、画像フレームから SVG 画像を抽出する方法を示しています：

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

Aspose.Slides は画像に適用された透明度効果を取得できます。この Java コードが操作を示しています：

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

## **画像の明るさとコントラストを取得する**

Aspose.Slides は画像に適用された明るさとコントラストの効果を取得できます。[ILuminance](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iluminance/) インターフェイスがこの画像変換効果を表します。

この Java コードは画像フレームから明るさとコントラストの設定を取得する方法を示しています：

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

## **画像フレームの書式設定**

Aspose.Slides は画像フレームに適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、画像フレームを特定の要件に合わせて変更できます。  

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [IImageCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImageCollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [IShapeCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection) オブジェクトが公開する [AddPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. 画像フレーム（画像を含む）をスライドに追加します。  
7. 画像フレームの線の色を設定します。  
8. 画像フレームの線幅を設定します。  
9. 正または負の値を指定して画像フレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. 画像フレーム（画像を含む）をスライドに追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは画像フレームの書式設定プロセスを示しています：

```java
// PPTX を表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを生成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同等の高さと幅で画像フレームを追加します
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameEx にいくつかの書式設定を適用します
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose は最近、無料の [Collage Maker](https://products.aspose.app/slides/ja/collage) を開発しました。JPG/JPEG や PNG 画像を [結合](https://products.aspose.app/slides/ja/collage/jpg) したり、[写真からグリッドを作成](https://products.aspose.app/slides/ja/collage/photo-grid) したりする場合にこのサービスを利用できます。 
{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクを介して画像（またはビデオ）を追加できます。この Java コードはプレースホルダーに画像とビデオを追加する方法を示しています：

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

## **画像のトリミング**

この Java コードはスライド上の既存画像をトリミングする方法を示しています：

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

    // 画像をトリミングします（パーセンテージ値）
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

## **画像フレームのトリミング領域を削除する**

フレームに含まれる画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドはトリミングされた画像、またはトリミングが不要な場合は元画像を返します。

この Java コードは操作を示しています：

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 最初のスライドから PictureFrame を取得します
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame 画像のトリミング領域を削除し、トリミングされた画像を返します
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 結果を保存します
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズを削減できます。そうでない場合、結果として生成されるプレゼンテーションの画像数は増加します。  

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 
{{% /alert %}}

## **画像の圧縮**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) メソッドを使用して、プレゼンテーション内の画像を圧縮できます。このメソッドはシェイプのサイズと指定された解像度に基づいて画像サイズを縮小し、トリミング領域を削除するオプションも提供します。  

PowerPoint の **Picture Format → Compress Pictures → Resolution** 機能と同様に、画像のサイズと解像度を調整します。  

以下の Java 例は、ターゲット解像度を指定し、必要に応じてトリミング領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています：

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 画像をターゲット解像度 150 DPI（ウェブ解像度）で圧縮し、トリミング領域を削除します。
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

またはカスタム DPI 値を直接指定する場合：

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 画像を 150 DPI（ウェブ解像度）に圧縮し、トリミング領域を削除します。
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
このメソッドはシェイプのサイズと指定された DPI に基づいて画像を低解像度に変換します。トリミング領域も削除でき、ファイル サイズの最適化が可能です。  
画像がメタファイル（WMF/EMF）または SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて保持または若干低下します（PowerPoint の高解像度 JPEG の取り扱いと同様）。 
{{% /alert %}}

## **アスペクト比ロック**

画像を含むシェイプのサイズを変更した後でもアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。  

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

    // リサイズ時にアスペクト比を保持するようにシェイプを設定します
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプ内の画像そのものは影響を受けません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを使用すると、塗りつぶし矩形を指定できます。  

画像が伸縮指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺はシェイプのバウンディング ボックスの対応する辺からのパーセンテージ オフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを示します。  

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 四角形の `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. 画像を設定してシェイプを塗りつぶします。  
8. 画像のオフセットをシェイプのバウンディング ボックスの対応する辺から指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは StretchOff プロパティを使用したプロセスを示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx クラスのインスタンスを生成します
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 矩形に設定された AutoShape を追加します
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // シェイプの塗りつぶしタイプを設定します
    aShape.getFillFormat().setFillType(FillType.Picture);

    // シェイプの画像塗りつぶしモードを設定します
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // シェイプを埋める画像を設定します
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //PPTX ファイルをディスクに書き込みます
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**画像フレームでサポートされている画像形式を確認するにはどうすればよいですか？**

Aspose.Slides は、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクタ画像（例: SVG）を、[PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを介してサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。  

**多数の大きな画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイル サイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルが常にアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供しており、ファイル サイズ削減に役立ちます。  

**画像オブジェクトを誤って移動／リサイズしないようにロックするには？**

[PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) に対して [shape locks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) を使用できます（例: 移動やリサイズを無効化）。ロック機構は別の [保護に関する記事](/slides/ja/java/applying-protection-to-presentation/) で説明されており、さまざまなシェイプタイプ、包括的に [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) でもサポートされています。  

**SVG ベクタの忠実度は PDF/画像へのエクスポート時に保持されますか？**

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) から SVG を元のベクタとして抽出できます。[PDF にエクスポート](/slides/ja/java/convert-powerpoint-to-pdf/) や [ラスタ形式に変換](/slides/ja/java/convert-powerpoint-to-png/) する際、エクスポート設定に応じて結果がラスタ化される可能性がありますが、抽出動作により元の SVG がベクタとして保持されていることが確認できます。