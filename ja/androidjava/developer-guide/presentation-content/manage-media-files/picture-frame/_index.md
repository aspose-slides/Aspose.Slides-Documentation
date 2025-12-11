---
title: Android上のプレゼンテーションで画像フレームを管理する
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
- ラスタ画像
- ベクタ画像
- 画像を切り抜く
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
description: "Aspose.Slides for Android via Java を使用して、PowerPoint と OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させます。"
---

Picture frame（画像フレーム）は画像を含む形状で、フレームに入った写真のようなものです。  

画像フレームを使用してスライドに画像を追加できます。この方法で、画像フレームを整形することで画像自体を整形できます。  

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料のコンバータ—[JPEG を PowerPoint に変換](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG を PowerPoint に変換](https://products.aspose.app/slides/import/png-to-ppt)—を提供しており、画像から素早くプレゼンテーションを作成できます。  
{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage]() オブジェクトを作成します。このオブジェクトはシェイプの塗りつぶしに使用されます。  
4. 画像の幅と高さを指定します。  
5. 参照スライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして書き出します。  

以下の Java コードは画像フレームの作成方法を示しています：  
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同じ高さと幅のピクチャーフレームを追加します
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
画像フレームを使用すると、画像をもとにプレゼンテーションスライドを素早く作成できます。PictureFrame と Aspose.Slides の保存オプションを組み合わせることで、画像の入出力操作を操作し、フォーマット間の変換が可能です。以下のページをご覧ください: 画像を JPG に変換、JPG を画像に変換、JPG を PNG に変換、PNG を JPG に変換、PNG を SVG に変換、SVG を PNG に変換。  
{{% /alert %}}

## **相対スケールを使用した画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。  
5. 画像フレーム内で画像の相対的な幅と高さを指定します。  
6. 変更したプレゼンテーションを PPTX ファイルとして書き出します。  

以下の Java コードは相対スケールを使用した画像フレームの作成方法を示しています：  
```java
// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 画像と同じ高さと幅のピクチャーフレームを追加します
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

[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例はドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。  
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

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for Android via Java を使用して元のベクター画像を完全に忠実に取得できます。スライドのシェイプコレクションを走査して各 [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) を特定し、基になる [IPPImage](hhttps://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存できます。  

以下のコード例は画像フレームから SVG 画像を抽出する方法を示しています：  
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

Aspose.Slides を使用すると、画像に適用された透明度効果を取得できます。以下の Java コードはその操作を示しています：  
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

Aspose.Slides は画像フレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、画像フレームを特定の要件に合わせて変更できます。  

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照スライドに関連付けられた [IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) が提供する [AddPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 画像フレームの線の色を設定します。  
8. 画像フレームの線の幅を設定します。  
9. 正または負の値を指定して画像フレームを回転させます。  
   * 正の値は時計回りに回転します。  
   * 負の値は反時計回りに回転します。  
10. 画像フレーム（画像を含む）をスライドに追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして書き出します。  

以下の Java コードは画像フレームの書式設定プロセスを示しています：  
```java
// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同じ高さと幅のピクチャーフレームを追加します
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
Aspose は最近、[無料の Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG や PNG 画像を結合したり、写真からグリッドを作成したりする必要がある場合は、このサービスをご利用ください。  
{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションの容量が大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクを介して画像（または動画）を追加できます。以下の Java コードはプレースホルダーに画像と動画を追加する方法を示しています：  
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

以下の Java コードはスライド上の既存画像を切り抜く方法を示しています：  
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


## **画像フレームの切り取られた領域を削除する**

フレーム内に含まれる画像の切り取られた領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドは切り取られた画像、または切り取りが不要な場合は元の画像を返します。  

以下の Java コードはこの操作を示しています：  
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 最初のスライドから PictureFrame を取得します
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame の画像の切り取られた領域を削除し、切り取られた画像を返します
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 結果を保存します
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドは切り取られた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) のみで使用されている場合、プレゼンテーションのサイズを削減できます。そうでない場合、結果のプレゼンテーションに含まれる画像数が増加します。  

このメソッドは切り取り操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。  
{{% /alert %}}

## **アスペクト比をロックする**

画像を含むシェイプのサイズを変更してもアスペクト比を維持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。  

以下の Java コードはシェイプのアスペクト比をロックする方法を示しています：  
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
*Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプが保持する画像のアスペクト比は保持しません。  
{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを使用して、塗りつぶし矩形を指定できます。  

画像のストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせて拡大縮小されます。塗りつぼし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット（内側）を、負のパーセンテージはアウトセット（外側）を示します。  

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentatio) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. 塗りつぶしに使用する画像を設定します。  
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして書き出します。  

以下の Java コードは StretchOff プロパティを使用したプロセスを示しています：  
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

    // 矩形の AutoShape を追加します
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // シェイプの塗りつぶしタイプを設定します
    aShape.getFillFormat().setFillType(FillType.Picture);

    // シェイプの画像塗りつぶしモードを設定します
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // シェイプを塗りつぶす画像を設定します
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します
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


## **よくある質問**

**画像フレームでサポートされている画像形式はどのように確認できますか？**  
Aspose.Slides はラスタ画像（PNG、JPEG、BMP、GIF など）とベクタ画像（例: SVG）を [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを介してサポートしています。サポートされる形式のリストは、スライドおよび画像変換エンジンの機能と概ね重なります。  

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスはどうなりますか？**  
画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像へのリンクを使用するとプレゼンテーションのサイズを抑えられますが、外部ファイルが常にアクセス可能である必要があります。Aspose.Slides はリンクで画像を追加する機能を提供しており、ファイルサイズを削減できます。  

**画像オブジェクトが誤って移動／サイズ変更されないようにロックするには？**  
[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) の [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) を使用します（例：移動やサイズ変更を無効化）。ロック機構は別の記事の [保護に関する記事](/slides/ja/androidjava/applying-protection-to-presentation/) で説明されており、様々なシェイプタイプ（ImageFrame を含む）でサポートされています。  

**SVG ベクタの忠実度は PDF／画像へのエクスポート時に保持されますか？**  
Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。PDF（/slides/androidjava/convert-powerpoint-to-pdf/）やラスタ形式（/slides/androidjava/convert-powerpoint-to-png/）へのエクスポート時、エクスポート設定に応じてラスタ化される場合がありますが、抽出動作により元の SVG がベクターとして保持されていることが確認できます。  