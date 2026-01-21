---
title: Java を使用してプレゼンテーションのピクチャーフレームを管理する
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/java/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームの追加
- ピクチャーフレームの作成
- 画像の追加
- 画像の作成
- 画像の抽出
- ラスタ画像
- ベクトル画像
- 画像のトリミング
- トリミング領域
- StretchOff プロパティ
- ピクチャーフレームの書式設定
- ピクチャーフレームのプロパティ
- 相対スケール
- 画像エフェクト
- アスペクト比
- 画像の透明度
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションにピクチャーフレームを追加します。ワークフローを合理化し、スライドデザインを強化します。"
---

Picture frame は画像を含むシェイプで、フレームに入った写真のようなものです。

スライドに画像を Picture frame 経由で追加できます。この方法では、Picture frame をフォーマットすることで画像自体をフォーマットできます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータを提供しています—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—これにより画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

## **Picture frame の作成**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage]() オブジェクトを作成してシェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照スライドに関連付けられたシェイプオブジェクトの `AddPictureFrame` メソッドを使用して、画像の幅と高さで [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは Picture frame の作成方法を示しています：  
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを生成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同等の高さと幅でピクチャーフレームを追加します
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルをディスクに保存します
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
Picture frame を使用すると、画像ベースのスライドを迅速に作成できます。Picture frame と Aspose.Slides の保存オプションを組み合わせることで、画像の入出力操作を操作し、フォーマット間の変換が可能です。以下のページも参考になります：画像を [JPG に変換](https://products.aspose.com/slides/java/conversion/image-to-jpg/)、[JPG から画像へ変換](https://products.aspose.com/slides/java/conversion/jpg-to-image/)、[JPG から PNG へ変換](https://products.aspose.com/slides/java/conversion/jpg-to-png/)、[PNG から JPG へ変換](https://products.aspose.com/slides/java/conversion/png-to-jpg/)、[PNG から SVG へ変換](https://products.aspose.com/slides/java/conversion/png-to-svg/)、[SVG から PNG へ変換](https://products.aspose.com/slides/java/conversion/svg-to-png/)。 
{{% /alert %}}

## **相対スケール付き Picture frame の作成**

画像の相対スケーリングを変更することで、より複雑な Picture frame を作成できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成してシェイプの塗りつぶしに使用します。  
5. Picture frame 内で画像の相対幅と相対高さを指定します。  
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは相対スケール付き Picture frame の作成方法を示しています：  
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


## **Picture frame からラスタ画像を抽出する**

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


## **Picture frame から SVG 画像を抽出する**

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for Java を使用して元のベクター画像をフルフィデリティで取得できます。スライドのシェイプコレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存します。

以下のコード例は、Picture frame から SVG 画像を抽出する方法を示しています：  
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

Aspose.Slides を使用すると、画像に適用された透明度効果を取得できます。この Java コードはその操作を示しています：  
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


## **Picture frame の書式設定**

Aspose.Slides は Picture frame に適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、Picture frame を特定の要件に合わせて調整できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照スライドに関連付けられた [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) オブジェクトの [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さで `PictureFrame` を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. Picture frame の線色を設定します。  
8. Picture frame の線幅を設定します。  
9. 正または負の値を指定して Picture frame を回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. 画像フレーム（画像を含む）をスライドに再度追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Java コードは Picture frame の書式設定プロセスを示しています：  
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
    
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Tip" color="primary" %}} 
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG や PNG 画像を結合したり、写真からグリッドを作成したりしたい場合は、このサービスをご利用ください。 
{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションのサイズ増大を防ぐために、ファイルを直接埋め込む代わりにリンク経由で画像（または動画）を追加できます。この Java コードはプレースホルダーに画像と動画を追加する方法を示しています：  
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


## **Picture frame のトリミング領域を削除する**

フレーム内の画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドはトリミングされた画像、またはトリミングが不要な場合は元画像を返します。

この Java コードはその操作を示しています：  
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 最初のスライドから PictureFrame を取得します
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame 画像のトリミングされた領域を削除し、トリミングされた画像を返します
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 結果を保存します
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理対象の [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) のみで使用されている場合、この設定はプレゼンテーションのサイズ削減につながります。そうでない場合、結果のプレゼンテーション内の画像数は増加します。

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 
{{% /alert %}}

## **アスペクト比のロック**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合、[setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。

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

    // リサイズ時にアスペクト比を維持するようにシェイプを設定します
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプに含まれる画像自体の比率は保持しません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを使用すると、塗りつぶし矩形を指定できます。

画像の伸縮が指定されると、ソース矩形は指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディング ボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

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

    // AutoShape を矩形に設定して追加します
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
    
    // PPTX ファイルをディスクに書き込みます
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Picture frame がサポートする画像形式はどのように確認できますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを通じて、ラスタ画像 (PNG、JPEG、BMP、GIF など) とベクトル画像 (例: SVG) の両方をサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね一致します。

**多数の大容量画像を追加すると PPTX のサイズとパフォーマンスにどう影響しますか？**

画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供しており、ファイルサイズを削減できます。

**画像オブジェクトが誤って移動／リサイズされないようにロックする方法はありますか？**

[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) に対しては [shape locks](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) を使用できます（例: 移動やリサイズを無効化）。ロック機構は別記事の [プロテクションの適用](/slides/ja/java/applying-protection-to-presentation/) で説明されており、PictureFrame を含むさまざまなシェイプタイプでサポートされています。

**SVG ベクトルの忠実度は PDF/画像へのエクスポート時に保持されますか？**

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) から SVG を元のベクトルとして抽出できます。PDF (/slides/ja/java/convert-powerpoint-to-pdf/) やラスタ形式 (/slides/ja/java/convert-powerpoint-to-png/) にエクスポートする際は、エクスポート設定に応じてラスタ化されることがありますが、抽出時には元の SVG がベクトルとして保持されていることが確認できます。