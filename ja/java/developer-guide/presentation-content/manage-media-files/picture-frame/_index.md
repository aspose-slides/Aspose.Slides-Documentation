---
title: ピクチャーフレーム
type: docs
weight: 10
url: /ja/java/picture-frame/
keywords: "ピクチャーフレームを追加, ピクチャーフレームを作成, 画像を追加, 画像を作成, 画像を抽出, StretchOffプロパティ, ピクチャーフレームの書式設定, ピクチャーフレームのプロパティ, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションにピクチャーフレームを追加"

---

ピクチャーフレームは、画像を含む形状です。それは、額縁に入った絵のようなものです。

ピクチャーフレームを通じてスライドに画像を追加できます。この方法で、画像をそのピクチャーフレームの書式設定によってフォーマットすることができます。

{{% alert  title="ヒント" color="primary" %}} 

Asposeは無料のコンバーターを提供しています—[JPEGからPowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNGからPowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—これにより、ユーザーは画像から迅速にプレゼンテーションを作成できます。

{{% /alert %}} 

## **ピクチャーフレームの作成**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. 画像を形状を埋めるために使用するプレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection)に追加して[IPPImage]()オブジェクトを作成します。
4. 画像の幅と高さを指定します。
5. 参照されたスライドに関連付けられた形状オブジェクトによって公開される`AddPictureFrame`メソッドを通じて、画像の幅と高さに基づいて[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame)を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、ピクチャーフレームの作成方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Imageクラスをインスタンス化
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像の等価な高さと幅のピクチャーフレームを追加
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTXファイルをディスクに書き込む
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

ピクチャーフレームを使用すると、画像に基づいてプレゼンテーションスライドを迅速に作成できます。ピクチャーフレームとAspose.Slidesの保存オプションを組み合わせることで、1つの形式から別の形式に画像を変換するための入出力操作を操作できます。これらのページも参照してみてください： [画像をJPGに変換](https://products.aspose.com/slides/java/conversion/image-to-jpg/); [JPGを画像に変換](https://products.aspose.com/slides/java/conversion/jpg-to-image/); [JPGをPNGに変換](https://products.aspose.com/slides/java/conversion/jpg-to-png/); [PNGをJPGに変換](https://products.aspose.com/slides/java/conversion/png-to-jpg/); [PNGをSVGに変換](https://products.aspose.com/slides/java/conversion/png-to-svg/); [SVGをPNGに変換](https://products.aspose.com/slides/java/conversion/svg-to-png/)。

{{% /alert %}}

## **相対スケールでのピクチャーフレームの作成**

画像の相対スケーリングを変更することで、より複雑なピクチャーフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. プレゼンテーションの画像コレクションに画像を追加します。
4. 形状を埋めるために使用するプレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection)に画像を追加して[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)オブジェクトを作成します。
5. ピクチャーフレーム内の画像の相対幅と高さを指定します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、相対スケールを持つピクチャーフレームの作成方法を示しています：

```java
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Imageクラスをインスタンス化
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 画像の高さと幅に相当するピクチャーフレームを追加
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 相対スケールの幅と高さを設定
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTXファイルをディスクに書き込む
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ピクチャーフレームから画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame)オブジェクトから画像を抽出し、PNG、JPG、その他の形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG形式で保存する方法を示しています。

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

## **画像の透明度を取得する**

Aspose.Slidesを使用すると、画像の透明度を取得できます。このJavaコードは、その操作を示しています：

```java
Presentation presentation = new Presentation(folderPath + "Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("画像の透明度: " + transparencyValue);
    }
}
```

## **ピクチャーフレームの書式設定**

Aspose.Slidesは、ピクチャーフレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合うようにピクチャーフレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. 画像を形状を埋めるために使用するプレゼンテーションオブジェクトに関連付けられた[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)オブジェクトを作成します。
4. 画像の幅と高さを指定します。
5. 参照されたスライドに関連付けられた[IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)オブジェクトによって公開される[AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)メソッドを通じて、画像の幅と高さに基づいて`PictureFrame`を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. ピクチャーフレームの線の色を設定します。
8. ピクチャーフレームの線の幅を設定します。
9. ピクチャーフレームを回転させるために、正の値または負の値を与えます。
   * 正の値は画像を時計回りに回転させます。 
   * 負の値は画像を反時計回りに回転させます。
10. スライドにピクチャーフレーム（画像を含む）を追加します。
11. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、ピクチャーフレームの書式設定プロセスを示しています：

```java
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Imageクラスをインスタンス化
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像の等価な高さと幅のピクチャーフレームを追加
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameExにいくつかの書式設定を適用
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // PPTXファイルをディスクに書き込む
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ヒント" color="primary" %}}

Asposeは最近、[無料コラージュメーカー](https://products.aspose.app/slides/collage)を開発しました。JPG/JPEGを[マージ](https://products.aspose.app/slides/collage/jpg)したり、[写真からグリッドを作成](https://products.aspose.app/slides/collage/photo-grid)したりする必要がある場合、このサービスを利用できます。

{{% /alert %}}

## **リンクとして画像を追加**

プレゼンテーションサイズを大きくしないために、ファイルをプレゼンテーションに直接埋め込むのではなく、画像（または動画）をリンクを通じて追加できます。このJavaコードは、プレースホルダーに画像と動画を追加する方法を示しています：

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

## **画像を切り抜く**

このJavaコードは、スライド上の既存の画像を切り抜く方法を示しています：

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

    // スライドにPictureFrameを追加
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // 画像を切り抜く（パーセンテージ値）
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

## **画像の切り抜かれた領域を削除**

フレーム内に含まれる画像の切り抜かれた領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)メソッドを使用できます。このメソッドは、切り抜かれた画像または切り抜きが不要な場合は元の画像を返します。

このJavaコードは、その操作を示しています：

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 最初のスライドからPictureFrameを取得
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame画像の切り抜かれた領域を削除し、切り抜かれた画像を返す
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 結果を保存
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)メソッドは、切り抜かれた画像をプレゼンテーション画像コレクションに追加します。画像が処理された[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)にのみ使用される場合、この設定によりプレゼンテーションサイズを減少させることができます。そうでなければ、結果のプレゼンテーション内の画像の数が増加します。

このメソッドは、切り抜き操作でWMF/EMFメタファイルをラスタPNG画像に変換します。 

{{% /alert %}}

## **アスペクト比をロックする**

画像を含む形状のアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)メソッドを使用して*アスペクト比をロック*の設定を行うことができます。

このJavaコードは、形状のアスペクト比をロックする方法を示しています：

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

    // サイズ変更時のアスペクト比を保持するように形状を設定
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

この*アスペクト比をロック*する設定は、形状のアスペクト比を保持するだけであり、その中に含まれる画像のアスペクト比は保持しません。

{{% /alert %}}

## **StretchOffプロパティを使用する**

[StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) および [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-)プロパティを使用して、[IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat)インターフェースと[PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat)クラスから、フィルの長方形を指定できます。

画像のストレッチが指定されていると、ソースの長方形が指定されたフィルの長方形に合わせてスケールされます。フィルの長方形の各辺は、形状のバウンディングボックスの対応する辺からのパーセントオフセットによって定義されます。正のパーセントはインセットを指定し、負のパーセントはアウトセットを指定します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 長方形の`AutoShape`を追加します。 
4. 画像を作成します。
5. 形状のフィルタイプを設定します。
6. 形状のピクチャーフィルモードを設定します。
7. 形状を埋める画像を追加します。
8. 形状のバウンディングボックスから対応する辺までの画像オフセットを指定します。
9. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、StretchOffプロパティを使用するプロセスを示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageExクラスをインスタンス化
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 長方形に設定されたAutoShapeを追加
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 形状のフィルタイプを設定
    aShape.getFillFormat().setFillType(FillType.Picture);

    // 形状のピクチャーフィルモードを設定
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // 形状を埋めるための画像を設定
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 形状のバウンディングボックスから対応する辺までの画像オフセットを指定
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // PPTXファイルをディスクに書き込む
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```