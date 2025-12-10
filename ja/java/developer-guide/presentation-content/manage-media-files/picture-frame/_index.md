---
title: Java を使用したプレゼンテーションにおける画像フレームの管理
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
- ベクター画像
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
description: "Aspose.Slides for Java を使用して、PowerPoint と OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを強化します。"
---

Picture Frame は画像を含むシェイプで、フレーム内の写真のようなものです。  

スライドに画像を追加するには Picture Frame を使用します。この方法では、Picture Frame を書式設定することで画像を同時に書式設定できます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ―を提供しています—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—これにより画像からプレゼンテーションをすばやく作成できます。 
{{% /alert %}} 

## **Picture Frame の作成**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage]() オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照スライドに関連付けられたシェイプ オブジェクトが提供する `AddPictureFrame` メソッドを使用して、幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) を作成します。  
6. スライドに Picture Frame（画像を含む）を追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

以下の Java コードは Picture Frame の作成方法を示しています:  
```java
// Presentation クラス（PPTX ファイルを表す）をインスタンス化します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスをインスタンス化します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同等の高さと幅でピクチャーフレームを追加します
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
Picture Frame を使用すると、画像に基づくスライドを素早く作成できます。Picture Frame と Aspose.Slides の保存オプションを組み合わせることで、画像形式の変換などの入出力操作を操作できます。次のページも参照してください: 変換 [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/)；変換 [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/)；変換 [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)；変換 [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/)；変換 [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)；変換 [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)。 
{{% /alert %}}

## **相対スケール付き Picture Frame の作成**

画像の相対スケーリングを変更することで、より複雑な Picture Frame を作成できます。  

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
5. Picture Frame 内で画像の相対的な幅と高さを指定します。  
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

以下の Java コードは相対スケール付き Picture Frame の作成方法を示しています:  
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
    
    // PPTX ファイルをディスクに書き込みます
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Picture Frame からラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。  
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

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for Java は元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) を確認し、基になる [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) が SVG コンテンツを保持しているかどうかを調べ、必要に応じてディスクまたはストリームにネイティブ SVG 形式で保存します。

以下のコード例は、Picture Frame から SVG 画像を抽出する方法を示しています:  
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

Aspose.Slides では、画像に適用された透明度効果を取得できます。以下の Java コードがその操作を示しています:  
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

Aspose.Slides は Picture Frame に適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて Picture Frame を変更できます。  

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. プレゼンテーションに関連付けられた [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに Picture Frame（画像を含む）を追加します。  
7. Picture Frame の線の色を設定します。  
8. Picture Frame の線の幅を設定します。  
9. 正または負の値を指定して Picture Frame を回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. Picture Frame（画像を含む）をスライドに再度追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

以下の Java コードは Picture Frame の書式設定プロセスを示しています:  
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
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG や PNG 画像を [結合](https://products.aspose.app/slides/collage/jpg) したり、[写真からグリッドを作成](https://products.aspose.app/slides/collage/photo-grid) したりしたい場合にこのサービスを利用できます。 
{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションのサイズを抑えるために、画像（または動画）を直接埋め込むのではなく、リンクを介して追加できます。この Java コードはプレースホルダーに画像と動画を追加する方法を示しています:  
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

この Java コードはスライド上の既存画像をトリミングする方法を示しています:  
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


## **Picture Frame のトリミング領域を削除する**

フレームに含まれる画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドはトリミングされた画像、またはトリミングが不要な場合は元画像を返します。  

以下の Java コードがその操作を示しています:  
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 最初のスライドから PictureFrame を取得します
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame の画像のトリミング領域を削除し、トリミングされた画像を返します
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 結果を保存します
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズを削減できます。そうでない場合、結果として生成されるプレゼンテーションの画像数は増加します。  

このメソッドはトリミング操作で WMF/EMF メタファイルをラスタ PNG 画像に変換します。 
{{% /alert %}}

## **アスペクト比ロック**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。  

以下の Java コードはシェイプのアスペクト比をロックする方法を示しています:  
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
この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプが保持する画像のアスペクト比は保持しません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを使用して、塗りつぶし矩形を指定できます。  

画像の伸縮が指定されると、ソース矩形が指定された塗りつぶし矩形に合わせて拡大縮小されます。塗りつぶし矩形の各辺は、シェイプのバウンディング ボックスの対応する辺からのパーセンテージ オフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。  

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. 矩形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. 塗りつぶし用に画像を設定します。  
8. シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

以下の Java コードは StretchOff プロパティを使用したプロセスを示しています:  
```java
// PPTX ファイルを表す Presentation クラスをインスタンス化します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx クラスをインスタンス化します
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

    // シェイプに画像を設定して塗りつぶします
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

**Picture Frame がサポートする画像形式はどれですか？**  

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じて、ラスタ画像 (PNG、JPEG、BMP、GIF など) とベクター画像 (例: SVG) の両方をサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね一致します。  

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**  

大きな画像を埋め込むとファイル サイズとメモリ使用量が増加します。画像をリンクとして追加すればプレゼンテーションのサイズを抑えられますが、外部ファイルが常に利用可能である必要があります。Aspose.Slides はリンクで画像を追加する機能を提供し、ファイルサイズの削減を支援します。  

**画像オブジェクトが誤って移動・サイズ変更されないようにロックするには？**  

[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) を使用します (例: 移動やサイズ変更を無効にする)。ロック機構の詳細は別の [保護に関する記事](/slides/ja/java/applying-protection-to-presentation/) に記載されており、PictureFrame を含むさまざまなシェイプ タイプでサポートされています。  

**SVG ベクターの忠実度は PDF や画像へのエクスポート時に保持されますか？**  

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。PDF ({{/slides/java/convert-powerpoint-to-pdf/}}) やラスタ形式 ({{/slides/java/convert-powerpoint-to-png/}}) へエクスポートする際は、エクスポート設定に応じてラスタ化されることがありますが、抽出時の動作により元の SVG がベクターとして保持されていることが確認できます。