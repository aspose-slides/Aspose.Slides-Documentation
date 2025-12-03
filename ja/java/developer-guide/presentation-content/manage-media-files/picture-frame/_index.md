---
title: Java を使用してプレゼンテーションの画像フレームを管理する
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
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---

Picture frame は画像を含むシェイプで、フレーム内の写真のようなものです。

スライドに画像を追加するには、Picture frame を使用できます。この方法では、Picture frame をフォーマットすることで画像をフォーマットできます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータを提供しています—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—これにより、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

## **Picture Frame の作成**

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [IPPImage]() オブジェクトを作成します。これは、プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) に画像を追加してシェイプの塗りつぶしに使用されます。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) を作成します。  
6. スライドにピクチャーフレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは、Picture frame の作成方法を示します:  
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同等の高さと幅でピクチャーフレームを追加
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルをディスクに書き込む
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
Picture frames を使用すると、画像を元にしたスライドを迅速に作成できます。Picture frame と Aspose.Slides の保存オプションを組み合わせることで、画像の入出力操作を操作し、形式を相互に変換できます。以下のページもご参照ください: 変換 [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/)；変換 [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/)；変換 [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)、変換 [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/)；変換 [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)、変換 [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)。 
{{% /alert %}} 

## **Relative Scale を使用した Picture Frame の作成**

画像の相対スケーリングを変更することで、より複雑な Picture frame を作成できます。 

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。これは、プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) に画像を追加してシェイプの塗りつぶしに使用されます。  
5. Picture frame 内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは、Relative Scale を使用した Picture frame の作成方法を示します:  
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
        
        // 相対スケールの幅と高さを設定
        pf.setRelativeScaleHeight(0.8f);
        pf.setRelativeScaleWidth(1.35f);
        
        // PPTX ファイルをディスクに書き込む
        pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
    } catch (IOException e) {
    } finally {
        if (pres != null) pres.dispose();
    }
```


## **Picture Frame からラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し PNG 形式で保存する方法を示しています。  
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


## **Picture Frame から SVG 画像を抽出する**

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for Java は元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査して各 [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、必要に応じてその画像をディスクまたはストリームにネイティブ SVG 形式で保存します。

以下のコード例は、Picture frame から SVG 画像を抽出する方法を示しています:  
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

Aspose.Slides は画像に適用された透明効果を取得できます。この Java コードはその操作を示しています:  
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


## **Picture Frame の書式設定**

Aspose.Slides は Picture frame に適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて Picture frame を変更できます。

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。これは、プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) に画像を追加してシェイプの塗りつぶしに使用されます。  
4. 画像の幅と高さを指定します。  
5. [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドにピクチャーフレーム（画像を含む）を追加します。  
7. ピクチャーフレームの線色を設定します。  
8. ピクチャーフレームの線幅を設定します。  
9. 正または負の値を指定してピクチャーフレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. ピクチャーフレーム（画像を含む）をスライドに追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは Picture frame の書式設定プロセスを示しています:  
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
    
    // PPTX ファイルをディスクに書き込む
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Tip" color="primary" %}} 
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG や PNG 画像を [結合](https://products.aspose.app/slides/collage/jpg) したり、[写真からグリッドを作成](https://products.aspose.app/slides/collage/photo-grid) したりする必要がある場合は、このサービスをご利用ください。 
{{% /alert %}} 

## **リンクとして画像を追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクを通じて画像（またはビデオ）を追加できます。この Java コードはプレースホルダーに画像とビデオを追加する方法を示しています:  
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

この Java コードは、スライド上の既存画像をトリミングする方法を示しています:  
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

    // 画像をトリミングします（パーセンテージ値）
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


## **画像のトリミング領域を削除する**

フレーム内に含まれる画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドは、トリミングが不要な場合は元の画像を、トリミングが必要な場合はトリミングされた画像を返します。  

この Java コードはその操作を示しています:  
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 最初のスライドから PictureFrame を取得
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame 画像のトリミング領域を削除し、トリミングされた画像を返す
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 結果を保存
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションサイズを削減できます。そうでない場合、結果のプレゼンテーション内の画像数が増加します。

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 
{{% /alert %}} 

## **アスペクト比を固定する**

シェイプに含まれる画像のサイズを変更した後でもアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *アスペクト比の固定* 設定を有効にできます。  

この Java コードはシェイプのアスペクト比を固定する方法を示しています:  
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
この *アスペクト比の固定* 設定はシェイプのアスペクト比のみを保持し、シェイプに含まれる画像自体には影響しません。 
{{% /alert %}} 

## **StretchOff プロパティの使用**

[StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、および [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) クラスから使用すると、塗りつぶし矩形を指定できます。  

画像のストレッチが指定されると、ソース矩形は指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディング ボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を追加します。  
8. シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは StretchOff プロパティを使用したプロセスを示しています:  
```java
// PPTX ファイルを表す Prseetation クラスのインスタンスを作成
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

    // 矩形に設定された AutoShape を追加
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // シェイプの塗りつぶしタイプを設定
    aShape.getFillFormat().setFillType(FillType.Picture);

    // シェイプの画像塗りつぶしモードを設定
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // シェイプを塗りつぶす画像を設定
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // シェイプのバウンディング ボックスの対応する辺から画像のオフセットを指定
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // PPTX ファイルをディスクに書き込む
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**PictureFrame がサポートする画像形式をどのように確認できますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを介して、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクタ画像（例: SVG）の両方をサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**大量の大きな画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像へのリンクを使用するとプレゼンテーションのサイズを抑えられますが、外部ファイルが常にアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供しており、ファイルサイズの削減に役立ちます。

**画像オブジェクトが誤って移動またはサイズ変更されるのを防ぐにはどうすればよいですか？**

[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) に対して [shape locks](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) を使用できます（例: 移動やサイズ変更を無効化）。ロック機構は別の記事の [保護に関する記事](/slides/ja/java/applying-protection-to-presentation/) で説明されており、PictureFrame を含むさまざまなシェイプタイプでサポートされています。

**プレゼンテーションを PDF や画像にエクスポートするとき、SVG のベクタ忠実度は保持されますか？**

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) から元のベクタとして SVG を抽出できます。[PDF へのエクスポート](/slides/ja/java/convert-powerpoint-to-pdf/) や [ラスタ形式へのエクスポート](/slides/ja/java/convert-powerpoint-to-png/) では、エクスポート設定に応じてラスタ化される場合がありますが、抽出時にベクタとして保存されていることが確認できます。