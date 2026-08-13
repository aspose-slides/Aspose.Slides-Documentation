---
title: Java を使用したプレゼンテーションのピクチャーフレーム管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/java/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームを追加
- ピクチャーフレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- ラスター画像
- ベクター画像
- 画像をトリミング
- トリミング領域
- StretchOff プロパティ
- ピクチャーフレームの書式設定
- ピクチャーフレームのプロパティ
- 相対スケール
- 画像エフェクト
- アスペクト比
- 画像の透過性
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint および OpenDocument のプレゼンテーションにピクチャーフレームを追加します。ワークフローを合理化し、スライドデザインを向上させます。"
---
## **はじめに**

ピクチャーフレームは画像を含む形状であり、フレーム内の写真のようなものです。  

スライドに画像をピクチャーフレームを通じて追加できます。これにより、ピクチャーフレームをフォーマットすることで画像をフォーマットできます。  

{{% alert  title="Tip" color="info" %}} 
Aspose は無料コンバータ―[JPEG から PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG から PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) を提供しており、画像からプレゼンテーションを迅速に作成できます。  
{{% /alert %}} 

## **ピクチャーフレームの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImageCollection) に画像を追加して、シェイプの塗りつぶしに使用する [IPPImage]() オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/PictureFrame) を作成します。  
6. スライドにピクチャーフレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードはピクチャーフレームの作成方法を示しています：

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成します
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
ピクチャーフレームを使用すると、画像に基づくプレゼンテーションスライドを迅速に作成できます。ピクチャーフレームと Aspose.Slides の保存オプションを組み合わせることで、画像のフォーマット変換などの入出力操作を操作できます。以下のページをご参照ください: [画像をJPGに変換](https://products.aspose.com/slides/ja/java/conversion/image-to-jpg/); [JPGを画像に変換](https://products.aspose.com/slides/ja/java/conversion/jpg-to-image/); [JPGをPNGに変換](https://products.aspose.com/slides/ja/java/conversion/jpg-to-png/)、[PNGをJPGに変換](https://products.aspose.com/slides/ja/java/conversion/png-to-jpg/); [PNGをSVGに変換](https://products.aspose.com/slides/ja/java/conversion/png-to-svg/)、[SVGをPNGに変換](https://products.aspose.com/slides/ja/java/conversion/svg-to-png/)。  
{{% /alert %}} 

## **相対スケールを使用したピクチャーフレームの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 画像をプレゼンテーションの画像コレクションに追加します。  
4. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImageCollection) に画像を追加して、シェイプの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
5. ピクチャーフレーム内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは相対スケールを使用したピクチャーフレームの作成方法を示しています：

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成します
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

## **ピクチャーフレームからラスター画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/PictureFrame) オブジェクトからラスター画像を抽出し、PNG、JPG、その他の形式で保存できます。以下のコード例は、ドキュメント "sample.pptx" から画像を抽出し、PNG 形式で保存する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;

        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **ピクチャーフレームから SVG 画像を抽出する**

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) シェイプ内に配置された SVG グラフィックが含まれている場合、Aspose.Slides for Java は元のベクター画像をフルフィデリティで取得できます。スライドのシェイプコレクションを走査することで、各 [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、そしてその画像をディスクまたはストリームにネイティブな SVG 形式で保存できます。  

次のコード例は、ピクチャーフレームから SVG 画像を抽出する方法を示しています：

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        // getSvgImage は画像がラスター画像の場合に null を返します。
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **画像の透過性を取得する**

Aspose.Slides を使用すると、画像に適用された透過効果を取得できます。この Java コードはその操作を示しています：

```java
import com.aspose.slides.*;

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

Aspose.Slides を使用すると、画像に適用された明るさとコントラストの効果を取得できます。[ILuminance](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iluminance/) インターフェイスはこの画像変換効果を表します。

この Java コードは、ピクチャーフレームから明るさとコントラストの設定を取得する方法を示しています：

```java
import com.aspose.slides.*;

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

## **ピクチャーフレームの書式設定**

Aspose.Slides はピクチャーフレームに適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせてピクチャーフレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImageCollection) に画像を追加して、シェイプの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. [IShapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [AddPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドにピクチャーフレーム（画像を含む）を追加します。  
7. ピクチャーフレームの線カラーを設定します。  
8. ピクチャーフレームの線幅を設定します。  
9. ピクチャーフレームを正または負の値で回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. スライドにピクチャーフレーム（画像を含む）を追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードはピクチャーフレームの書式設定プロセスを示しています：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成します
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

{{% alert title="Tip" color="info" %}} 
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/ja/collage) を開発しました。JPG/JPEG や PNG 画像を[結合](https://products.aspose.app/slides/ja/collage/jpg)したり、[写真からグリッドを作成](https://products.aspose.app/slides/ja/collage/photo-grid)したい場合は、このサービスを利用できます。  
{{% /alert %}} 

## **画像をリンクとして追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクを介して画像（またはビデオ）を追加できます。この Java コードは、プレースホルダーに画像とビデオを追加する方法を示しています：

```java
import com.aspose.slides.*;
import java.util.ArrayList;

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

この Java コードは、スライド上の既存画像をトリミングする方法を示しています：

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

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
} finally {
    if (pres != null) pres.dispose();
}
```

## **ピクチャーのトリミング領域を削除する**

フレーム内に含まれる画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドは、トリミングが不要な場合はトリミングされた画像または元の画像を返します。  

この Java コードはその操作を示しています：

```java
import com.aspose.slides.*;

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
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドは、トリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズを縮小できます。そうでなければ、結果として得られるプレゼンテーションの画像数が増加します。  

このメソッドは、トリミング操作で WMF/EMF メタファイルをラスター PNG 画像に変換します。  
{{% /alert %}}

## **画像の圧縮**

プレゼンテーション内の画像を [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) メソッドを使用して圧縮できます。このメソッドは、シェイプのサイズと指定された解像度に基づいて画像のサイズを縮小し、トリミング領域を削除するオプションがあります。

PowerPoint の **Picture Format -> Compress Pictures -> Resolution** 機能と同様に、画像のサイズと解像度を調整します。  

以下の Java 例は、対象解像度を指定し、必要に応じてトリミング領域を削除することで、プレゼンテーション内の画像を圧縮する方法を示しています：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 画像を目標解像度150 DPI（Web 解像度）で圧縮し、トリミング領域を削除します。
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

または、カスタム DPI 値を直接使用する場合:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 画像を150 DPI（Web 解像度）に圧縮し、トリミング領域を削除します。
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
このメソッドは、シェイプのサイズと指定された DPI に基づいて画像を低解像度に変換します。ファイルサイズの最適化のためにトリミング領域も削除できます。  

画像がメタファイル（WMF/EMF）または SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて維持またはわずかに低下します。これは PowerPoint が高解像度 JPEG を処理する方法と同様です。  
{{% /alert %}}

## **アスペクト比のロック**

画像を含むシェイプのサイズを変更した後でもアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を行うことができます。  

この Java コードは、シェイプのアスペクト比をロックする方法を示しています：

```java
import com.aspose.slides.*;

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
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // リサイズ時にアスペクト比を保持するようにシェイプを設定します
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
この *Lock Aspect Ratio* 設定は、シェイプのアスペクト比のみを保持し、シェイプに含まれる画像そのもののアスペクト比は保持しません。  
{{% /alert %}}

## **StretchOffset プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを使用して、塗りつぶし矩形を指定できます。  

画像に対して伸縮が指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各エッジは、シェイプのバウンディングボックスの対応するエッジからのパーセンテージオフセットで定義されます。正のパーセンテージはインセット（内側）を、負のパーセンテージはアウトセット（外側）を表します。  

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 矩形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディングボックスの対応するエッジからの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この Java コードは、StretchOffset プロパティを使用したプロセスを示しています：

```java
import com.aspose.slides.*;

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

    // シェイプを塗りつぶす画像を設定します
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // シェイプのバウンディングボックスの対応するエッジからの画像オフセットを指定します
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //PPTX ファイルをディスクに書き込みます
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **よくある質問**

### PictureFrame がサポートする画像フォーマットを確認する方法は？

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを通じて、ラスター画像（PNG、JPEG、BMP、GIF など）およびベクター画像（例: SVG）をサポートします。サポートされているフォーマットの一覧は、スライドおよび画像変換エンジンの機能と概ね重複します。

### 大量の大きな画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加すればプレゼンテーションのサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides は、ファイルサイズ削減のためにリンクで画像を追加する機能を提供しています。

### 画像オブジェクトが誤って移動・リサイズされるのを防ぐには？

[PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) に対して [shape locks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) を使用します（例: 移動やリサイズを無効化）。ロック機構の詳細は、別記事の [保護に関する記事](/slides/ja/java/applying-protection-to-presentation/) に記載されており、[PictureFrame] を含むさまざまなシェイプタイプでサポートされています。

### プレゼンテーションを PDF / 画像へエクスポートする際、SVG ベクトルの忠実度は保たれますか？

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。[PDF へエクスポート](/slides/ja/java/convert-powerpoint-to-pdf/) や [ラスター形式](/slides/ja/java/convert-powerpoint-to-png/) する際、エクスポート設定に応じて結果がラスタライズされることがありますが、抽出時に元の SVG がベクターとして保存されていることが確認できます。