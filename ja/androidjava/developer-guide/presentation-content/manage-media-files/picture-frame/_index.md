---
title: Android でのプレゼンテーションにおける画像枠の管理
linktitle: 画像枠
type: docs
weight: 10
url: /ja/androidjava/picture-frame/
keywords:
- 画像枠
- 画像枠の追加
- 画像枠の作成
- 画像の追加
- 画像の作成
- 画像の抽出
- ラスタ画像
- ベクタ画像
- 画像のトリミング
- トリミング領域
- StretchOff プロパティ
- 画像枠の書式設定
- 画像枠のプロパティ
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
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像枠を追加します。ワークフローを効率化し、スライドデザインを向上させます。"
---

画像枠は画像を含むシェイプで、フレーム内の写真のようなものです。  

スライドに画像を画像枠を通して追加できます。このように、画像枠の書式設定を行うことで画像をフォーマットできます。  

{{% alert  title="Tip" color="primary" %}}  
Aspose は無料コンバータ―、[JPEG から PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG から PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) を提供しており、画像からプレゼンテーションをすばやく作成できます。  
{{% /alert %}}  

## **画像枠の作成**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. [IPPImage]() オブジェクトを作成するには、プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) に画像を追加し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) を作成します。  
6. スライドに画像枠（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは画像枠の作成方法を示します。  
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを生成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像の幅と高さに合わせたピクチャーフレームを追加します
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルをディスクに保存します
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}}  
画像枠を使用すると、画像に基づいたプレゼンテーションスライドをすばやく作成できます。画像枠と Aspose.Slides の保存オプションを組み合わせることで、入力/出力操作を操作し、画像を別の形式に変換できます。以下のページもご覧ください：[画像を JPG に変換](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/)；[JPG を画像に変換](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/)；[JPG を PNG に変換](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/)、[PNG を JPG に変換](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/)；[PNG を SVG に変換](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/)、[SVG を PNG に変換](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/)。  
{{% /alert %}}  

## **相対スケールで画像枠を作成**

画像の相対的なスケーリングを変更することで、より複雑な画像枠を作成できます。  

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成するには、プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) に画像を追加し、シェイプの塗りつぶしに使用します。  
5. 画像枠内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

以下のコードは相対スケールで画像枠を作成する方法を示します。  
```java
// PPTX を表す Presentation クラスをインスタンス化します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスをインスタンス化します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 画像と同等の高さと幅でピクチャーフレームを追加します
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 相対スケールの幅と高さを設定します
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX ファイルをディスクに保存します
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **画像枠からラスタ画像を抽出**

[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) オブジェクトからラスタ画像を抽出し、PNG、JPG、その他の形式で保存できます。以下のコード例は、ドキュメント "sample.pptx" から画像を抽出し、PNG 形式で保存する方法を示しています。  
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


## **画像枠から SVG 画像を抽出**

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) シェイプ内に配置された SVG グラフィックが含まれる場合、Java を使用した Aspose.Slides for Android は元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査することで、各 [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) を特定し、基になる [IPPImage](hhttps://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、画像をディスクまたはストリームにネイティブな SVG 形式で保存できます。  

以下のコード例は画像枠から SVG 画像を抽出する方法を示しています。  
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


## **画像の透過性を取得**

Aspose.Slides を使用すると、画像に適用された透過効果を取得できます。この Java コードはその操作を示しています。  
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


## **画像枠の書式設定**

Aspose.Slides は画像枠に適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、画像枠を特定の要件に合わせて変更できます。  

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成するには、プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) に画像を追加し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた[IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [AddPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像枠（画像を含む）を追加します。  
7. 画像枠の線の色を設定します。  
8. 画像枠の線幅を設定します。  
9. 正または負の値を指定して画像枠を回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. スライドに画像枠（画像を含む）を追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは画像枠の書式設定プロセスを示しています。  
```java
// PPTX を表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを生成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同等の高さと幅でピクチャーフレームを追加します
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameEx にいくつかの書式設定を適用します
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // PPTX ファイルをディスクに保存します
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Tip" color="primary" %}}  
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG を[結合]（https://products.aspose.app/slides/collage/jpg）または PNG 画像を[結合]（https://products.aspose.app/slides/collage/jpg）したり、[写真からグリッドを作成](https://products.aspose.app/slides/collage/photo-grid)したりする必要がある場合は、このサービスを利用できます。  
{{% /alert %}}  

## **リンクとして画像を追加**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンク経由で画像（または動画）を追加できます。この Java コードはプレースホルダーに画像と動画を追加する方法を示しています。  
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

この Java コードはスライド上の既存画像をトリミングする方法を示しています。  
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


## **画像のトリミング領域を削除**

フレームに含まれる画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドは、トリミングが不要な場合はトリミングされた画像または元の画像を返します。  

この Java コードは操作を示しています。  
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
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) のみで使用されている場合、この設定でプレゼンテーションのサイズを削減できます。そうでない場合、結果のプレゼンテーションの画像数が増加します。  

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。  
{{% /alert %}}  

## **アスペクト比をロック**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合、[setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を行えます。  

この Java コードはシェイプのアスペクト比をロックする方法を示します。  
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

    // シェイプがリサイズ時にアスペクト比を保持するように設定します
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}}  
この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプが含む画像のアスペクト比は保持しません。  
{{% /alert %}}  

## **StretchOff プロパティの使用**

[StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) クラスから使用すると、塗りつぶし矩形を指定できます。  

画像に対してストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせて拡大縮小されます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセットを、負のパーセンテージはアウトセットを示します。  

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentatio) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. `AutoShape` の矩形を追加します。  
4. 画像を作成します。  
5. シェイプの塗りタイプを設定します。  
6. シェイプの画像塗りモードを設定します。  
7. 塗りつぶし用に画像を設定します。  
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは StretchOff プロパティを使用するプロセスを示しています。  
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

    // Rectangle に設定された AutoShape を追加します
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // シェイプの塗りつぶしタイプを設定します
    aShape.getFillFormat().setFillType(FillType.Picture);

    // シェイプの画像塗りつぶしモードを設定します
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // シェイプを埋める画像を設定します
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // PPTX ファイルをディスクに保存します
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**PictureFrame がサポートする画像形式をどのように確認できますか？**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを介して、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクタ画像（例: SVG）の両方をサポートします。サポートされている形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。  

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**  
大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクで画像を追加する機能を提供しており、ファイルサイズ削減に役立ちます。  

**画像オブジェクトが誤って移動/サイズ変更されないようにロックするにはどうすればよいですか？**  
[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) を使用できます（例: 移動やサイズ変更を無効化）。このロック機構は、さまざまなシェイプタイプに対して別途解説した [保護に関する記事](/slides/ja/androidjava/applying-protection-to-presentation/) でも説明されています。  

**プレゼンテーションを PDF/画像にエクスポートする際、SVG のベクター忠実度は保持されますか？**  
Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。PDF へのエクスポート（/slides/androidjava/convert-powerpoint-to-pdf/）やラスタ形式へのエクスポート（/slides/androidjava/convert-powerpoint-to-png/）では、エクスポート設定に応じてラスタ化されることがありますが、抽出動作により元の SVG がベクターとして保持されていることが確認できます。