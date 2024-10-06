---
title: ピクチャーフレーム
type: docs
weight: 10
url: /ja/androidjava/picture-frame/
keywords: "ピクチャーフレームを追加、ピクチャーフレームを作成、画像を追加、画像を作成、画像を抽出、StretchOffプロパティ、ピクチャーフレームフォーマット、ピクチャーフレームプロパティ、PowerPointプレゼンテーション、Java、Aspose.Slides for Android via Java"
description: "JavaでPowerPointプレゼンテーションにピクチャーフレームを追加"

---

ピクチャーフレームは、画像を含むシェイプであり、フレームに入った写真のようなものです。

ピクチャーフレームを通じてスライドに画像を追加できます。これにより、ピクチャーフレームをフォーマットすることで画像を整形できます。

{{% alert title="ヒント" color="primary" %}} 

Asposeは、[JPEGからPowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)や[PNGからPowerPoint](https://products.aspose.app/slides/import/png-to-ppt)など、画像から迅速にプレゼンテーションを作成できる無料のコンバーターを提供しています。 

{{% /alert %}} 

## **ピクチャーフレームを作成**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection)に画像を追加して[IPPImage]()オブジェクトを作成します。このオブジェクトは、シェイプを埋めるために使用されます。
4. 画像の幅と高さを指定します。
5. 参照されたスライドに関連付けられたシェイプオブジェクトによって公開された`AddPictureFrame`メソッドを通じて、画像の幅と高さに基づいて[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame)を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、ピクチャーフレームを作成する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 画像クラスを生成
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像の高さと幅に相当するピクチャーフレームを追加
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTXファイルをディスクに書き込む
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

ピクチャーフレームを使用すると、画像に基づいてプレゼンテーションスライドを迅速に作成できます。Aspose.Slidesの保存オプションと組み合わせると、画像を異なる形式に変換する入出力操作を操作できます。次のページもご覧ください：[画像をJPGに変換](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); [JPGを画像に変換](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); [JPGをPNGに変換](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/); [PNGをJPGに変換](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); [PNGをSVGに変換](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/); [SVGをPNGに変換](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/)。

{{% /alert %}}

## **相対比率でピクチャーフレームを作成**

画像の相対スケーリングを変更することで、より複雑なピクチャーフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. プレゼンテーション画像コレクションに画像を追加します。
4. [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection)に関連付けられたプレゼンテーションオブジェクトに画像を追加して、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)オブジェクトを作成します。
5. ピクチャーフレームで画像の相対的な幅と高さを指定します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、相対スケールでピクチャーフレームを作成する方法を示しています：

```java
// PPTXを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 画像クラスを生成
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

## **ピクチャーフレームから画像を抽出**

[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame)オブジェクトから画像を抽出し、PNG、JPG、その他の形式で保存することができます。以下のコード例は、"sample.pptx"ドキュメントから画像を抽出し、PNG形式で保存する方法を示します。

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

## **画像の透明度を取得**

Aspose.Slidesを使用すると、画像の透明度を取得できます。このJavaコードはその操作を示しています：

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

## **ピクチャーフレームフォーマット**

Aspose.Slidesは、ピクチャーフレームに適用できる多くのフォーマットオプションを提供しています。これらのオプションを使用することで、特定の要件に合わせてピクチャーフレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection)に関連付けられたプレゼンテーションオブジェクトに画像を追加して[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)オブジェクトを作成します。
4. 画像の幅と高さを指定します。
5. [IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)オブジェクトに関連付けられたピクチャーフレームに基づいて`AddPictureFrame`メソッドを通じて、画像の幅と高さに基づいて`PictureFrame`を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. ピクチャーフレームの線の色を設定します。
8. ピクチャーフレームの線の幅を設定します。
9. ピクチャーフレームを回転させ、正または負の値を与えます。
   * 正の値は画像を時計回りに回転させます。 
   * 負の値は画像を反時計回りに回転させます。
10. ピクチャーフレーム（画像を含む）をスライドに追加します。
11. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、ピクチャーフレームのフォーマットプロセスを示しています：

```java
// PPTXを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 画像クラスを生成
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像の高さと幅に相当するピクチャーフレームを追加
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameExにいくつかのフォーマットを適用
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

Asposeは最近、[無料コラージュメーカー](https://products.aspose.app/slides/collage)を開発しました。JPG/JPEG画像を[結合](https://products.aspose.app/slides/collage/jpg)したり、[写真からグリッドを作成](https://products.aspose.app/slides/collage/photo-grid)したりするときに、このサービスを利用できます。 

{{% /alert %}}

## **リンクとして画像を追加**

大きなプレゼンテーションサイズを避けるために、画像（または動画）をファイルに直接埋め込む代わりにリンクを通じて追加できます。このJavaコードは、プレースホルダに画像と動画を追加する方法を示しています：

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

## **画像をトリミング**

このJavaコードは、スライド上の既存の画像をトリミングする方法を示しています：

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

    // スライドにピクチャーフレームを追加
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

## 画像の切り取られた部分を削除

フレーム内の画像の切り取られた部分を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)メソッドを使用できます。このメソッドは、切り取られた画像または切り取りが不要な場合は元の画像を返します。

このJavaコードは、その操作を示しています：

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 最初のスライドからピクチャーフレームを取得
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ピクチャーフレーム画像の切り取られた部分を削除し、切り取られた画像を返す
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 結果を保存
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)メソッドは、切り取られた画像をプレゼンテーション画像コレクションに追加します。画像が処理された[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/)のみで使用される場合、この設定によりプレゼンテーションのサイズを削減できます。さもなければ、生成されたプレゼンテーション内の画像の数が増加します。

このメソッドは、切り取り操作でWMF/EMFメタファイルをラスタPNG画像に変換します。 

{{% /alert %}}

## **アスペクト比を固定**

画像を含むシェイプが画像の寸法を変更してもアスペクト比を保持する場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)メソッドを使用して*アスペクト比を固定*設定を行うことができます。

このJavaコードは、シェイプのアスペクト比を固定する方法を示しています：

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

{{% alert title="注意" color="warning" %}} 

この*アスペクト比を保持*設定は、シェイプのアスペクト比を保持するものであり、シェイプに含まれる画像のアスペクト比を保持するものではありません。

{{% /alert %}}

## **StretchOffプロパティの使用**

[StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)および[StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-)プロパティを使用すると、[IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat)インターフェースと[PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat)クラスから、フィル矩形を指定できます。

画像に伸縮が指定されると、ソース矩形は指定されたフィル矩形に適合するようにスケーリングされます。フィル矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットによって定義されます。正のパーセンテージはインセットを指定し、負のパーセンテージはアウトセットを指定します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentatio)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 矩形`AutoShape`を追加します。 
4. 画像を作成します。
5. シェイプのフィルタイプを設定します。
6. シェイプのピクチャーフィルモードを設定します。
7. 形状を埋めるために画像を追加します。
8. シェイプのバウンディングボックスの対応するエッジからの画像オフセットを指定します。
9. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、StretchOffプロパティを使用するプロセスを示します：

```java
// PPTXファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // 画像クラスを生成
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 矩形に設定されたAutoShapeを追加
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // シェイプのフィルタイプを設定
    aShape.getFillFormat().setFillType(FillType.Picture);

    // シェイプのピクチャーフィルモードを設定
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // 形状を埋めるための画像を設定
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // シェイプのバウンディングボックスの対応するエッジからの画像オフセットを指定
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