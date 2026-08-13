---
title: "Android でのプレゼンテーションにおけるピクチャーフレームの管理"
linktitle: "ピクチャーフレーム"
type: docs
weight: 10
url: /ja/androidjava/picture-frame/
keywords:
- "ピクチャーフレーム"
- "ピクチャーフレームの追加"
- "ピクチャーフレームの作成"
- "画像の追加"
- "画像の作成"
- "画像の抽出"
- "ラスタ画像"
- "ベクター画像"
- "画像のトリミング"
- "切り取られた領域"
- "StretchOff プロパティ"
- "ピクチャーフレームの書式設定"
- "ピクチャーフレームのプロパティ"
- "相対スケール"
- "画像効果"
- "アスペクト比"
- "画像の透明度"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument プレゼンテーションにピクチャーフレームを追加します。ワークフローを合理化し、スライドデザインを向上させます。"
---
## **導入**

Picture frame は画像を含むシェイプです—フレーム内の画像のようなものです。

Picture frame を介してスライドに画像を追加できます。この方法では、Picture frame の書式設定で画像をフォーマットできます。

{{% alert  title="Tip" color="info" %}} 

Aspose は無料のコンバータ―、[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) を提供しており、画像からプレゼンテーションを素早く作成できます。 

{{% /alert %}} 

## **Picture Frame の作成**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [IImageCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage]() オブジェクトを作成してシェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照スライドに関連付けられたシェイプ オブジェクトが公開する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/PictureFrame) を作成します。  
6. スライドにピクチャーフレーム（画像を含む）を追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは Picture Frame の作成方法を示しています。

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX ファイルを表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを生成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同じ高さと幅でピクチャーフレームを追加します
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルをディスクに保存します
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **相対スケールを使用した Picture Frame の作成**

画像の相対スケーリングを変更することで、より複雑な Picture Frame を作成できます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーション オブジェクトに関連付けられた [IImageCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成してシェイプの塗りつぶしに使用します。  
5. ピクチャーフレーム内の画像の相対幅と高さを指定します。  
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは相対スケールを使用した Picture Frame の作成方法を示しています。

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX を表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを生成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 画像と同じ高さと幅でピクチャーフレームを追加します
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

## **ピクチャーフレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/PictureFrame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。

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

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) シェイプ内に配置された SVG グラフィックが含まれる場合、Aspose.Slides for Android via Java は元のベクター画像を完全な忠実度で取得できます。[PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) に SVG コンテンツを保持する [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) がある場合、その SVG 画像を読み取り、ネイティブ SVG 形式でディスクまたはストリームに保存できます。

以下のコード例は、ピクチャーフレームから SVG 画像を抽出する方法を示しています。

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

Aspose.Slides では画像に適用された透明度効果を取得できます。この Java コードはその操作を示しています。

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

Aspose.Slides では画像に適用された明るさとコントラスト効果を取得できます。[ILuminance](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iluminance/) インターフェイスはこの画像変換効果を表します。

この Java コードはピクチャーフレームから明るさとコントラストの設定を取得する方法を示しています。

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

Aspose.Slides はピクチャーフレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせてピクチャーフレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. プレゼンテーション オブジェクトに関連付けられた [IImageCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IImageCollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成してシェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照スライドに関連付けられた [IShapeCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection) が公開する [AddPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドにピクチャーフレーム（画像を含む）を追加します。  
7. ピクチャーフレームの線の色を設定します。  
8. ピクチャーフレームの線の太さを設定します。  
9. 正または負の値を指定してピクチャーフレームを回転させます。  
   * 正の値は時計回りに回転します。  
   * 負の値は反時計回りに回転します。  
10. ピクチャーフレーム（画像を含む）をスライドに追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この Java コードはピクチャーフレームの書式設定プロセスを示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX を表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを生成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同じ高さと幅でピクチャーフレームを追加します
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

{{% alert title="Tip" color="info" %}}

Aspose は最近、無料の [Collage Maker](https://products.aspose.app/slides/ja/collage) を開発しました。JPG/JPEG または PNG 画像の結合、写真からのグリッド作成が必要な場合は、このサービスをご利用ください。 

{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションのサイズを大きくしないために、画像（またはビデオ）をファイルとして埋め込む代わりにリンク経由で追加できます。この Java コードはプレースホルダーに画像とビデオを追加する方法を示しています。

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

## **画像の切り取り**

この Java コードはスライド上の既存画像を切り取る方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// 新しい画像オブジェクトを作成します
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
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
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ピクチャーの切り取られた領域を削除する**

フレーム内に含まれる画像の切り取られた領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドは、切り取られた画像または切り取りが不要な場合は元の画像を返します。

この Java コードはその操作を示しています。

```java
import com.aspose.slides.*;

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

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドは切り取られた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズが削減されます。そうでない場合、結果のプレゼンテーションの画像数は増加します。

このメソッドは切り取り操作で WMF/EMF メタファイルをラスタ PNG 画像に変換します。 

{{% /alert %}}

## **画像を圧縮する**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) メソッドを使用して、プレゼンテーション内の画像を圧縮できます。このメソッドはシェイプのサイズと指定された解像度に基づいてサイズを縮小し、必要に応じて切り取られた領域を削除します。

PowerPoint の **Picture Format > Compress Pictures > Resolution** 機能と同様に、画像のサイズと解像度を調整します。

以下の Java 例は、対象解像度を指定し、必要に応じて切り取られた領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ターゲット解像度 150 DPI（Web 解像度）で画像を圧縮し、切り取られた領域を削除します。
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

またはカスタム DPI 値を直接使用する例:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 画像を 150 DPI（ウェブ解像度）に圧縮し、切り取られた領域を削除します。
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

このメソッドはシェイプのサイズと提供された DPI に基づいて画像を低解像度に変換します。切り取られた領域も削除してファイルサイズを最適化できます。  
画像がメタファイル（WMF/EMF）または SVG の場合、圧縮は適用されません。JPEG の品質は解像度に応じて維持またはわずかに低下し、PowerPoint の高解像度 JPEG の取り扱いと同様です。

{{% /alert %}}

## **アスペクト比をロックする**

画像を含むシェイプのサイズを変更した後もアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を行います。

この Java コードはシェイプのアスペクト比をロックする方法を示しています。

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
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプが保持する画像のアスペクト比は保持しません。

{{% /alert %}}

## **StretchOff プロパティを使用する**

[IPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを使用すると、塗りつぶし矩形を指定できます。

画像のストレッチが指定されると、ソース矩形は指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディング ボックスの対応する辺からのパーセンテージ オフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを意味します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶすために画像を設定します。  
8. シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは StretchOff プロパティを使用したプロセスを示しています。

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

    // シェイプを画像で塗りつぶすように設定します
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // PPTX ファイルをディスクに保存します
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### PictureFrame がサポートする画像形式はどのように確認できますか？

Aspose.Slides はラスタ画像（PNG、JPEG、BMP、GIF など）とベクター画像（例: SVG）を、[PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを通じてサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね一致します。

### 大量の大きな画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供しており、ファイルサイズを削減できます。

### 画像オブジェクトが誤って移動・サイズ変更されないようにロックするには？

[PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) に対して [shape locks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) を使用できます（例: 移動やサイズ変更を無効化）。このロック機構は、PictureFrame を含むさまざまなシェイプタイプでサポートされています。

### SVG ベクターの忠実度は PDF/画像へのエクスポート時に保持されますか？

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。PDF（/slides/ja/androidjava/convert-powerpoint-to-pdf/）やラスタ形式（/slides/ja/androidjava/convert-powerpoint-to-png/）へのエクスポート時、エクスポート設定に応じてラスタ化される場合がありますが、元の SVG がベクターとして保存されていることは抽出動作で確認できます。