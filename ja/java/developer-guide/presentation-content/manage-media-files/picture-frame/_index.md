---
title: Java を使用してプレゼンテーションで画像フレームを管理する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスタ画像
- SVG 画像
- 画像のクロップ
- クロップ領域の削除
- 画像の圧縮
- StretchOffset
- 画像フレームの書式設定
- 相対スケール
- 画像効果
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、クロップ、抽出、圧縮する。"
---
## **概要**

画像フレームは画像を表示するスライド形状です。Aspose.Slides では、画像リソースとそれを表示する形状は別々のオブジェクトです。 [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) はその [IImageCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimagecollection/) を介して埋め込み画像リソースを所有し、[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロップ、画像効果、その他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合にこの分離は便利です。画像をプレゼンテーションに一度だけ追加し、返される [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) を保持し、画像リソースを使用して画像フレームを作成します。

画像フレームは PNG や JPEG などのラスタ画像や SVG などのベクタ画像を含めることができます。また、画像バイトをプレゼンテーションに格納せずにリンク画像を参照することも可能です。選択は移植性、ファイルサイズ、抽出、エクスポートの挙動に影響するため、書式設定や最適化を行う前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) で画像フレームを作成します。画像はプレゼンテーション パッケージの一部になるため、別のコンピューターに移動してもプレゼンテーションは自己完結しています。

次の例は JPEG 画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

画像フレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに格納された元のピクセル寸法は変わりません。この区別は後で画像をクロップしたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) は [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) によってフレームの相対幅・高さスケーリングを提供します。値 `1.0` は元画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算せずに元画像サイズとの関係を保つ必要があるワークフローで便利です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像をリサンプルしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内部に保存するため、移植性と予測可能なレンダリングに最も安全です。リンク画像は [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) メソッドで外部パスを設定し、画像データを埋め込む代わりに参照します。

リンク画像は PPTX の画像データ量を減らすことができますが、外部依存性が生じます。リンクされたファイルはプレゼンテーションを開く／レンダリングするアプリケーションからアクセスできる状態でなければなりません。パスが変わったり、ファイルが移動したり、リソースが利用できなくなったりすると、リンク画像は期待通りに表示されません。メールで送付したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例は画像フレームを作成し、ローカル画像ファイルへのパスを設定します。画像リンクのみを扱い、動画リンクは別のメディア ワークフローになるためこの例には混在させていません。

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替としてリンクを使用しないでください。リンクが切れた小さな PPTX は、サイズが大きく自己完結したプレゼンテーションほど有用ではありません。

## **画像フレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、対象のシェイプが実際に [IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) であり、埋め込み画像を保持しているかを確認してください。リンク画像フレームは同じ方法で抽出できるバイトを持っていない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) を直接使用し、古い Java 画像ラッパーは不要です。次の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

[IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/#save-java.lang.String-int-) を使用すると、抽出した画像が要求された出力形式に変換されます。プレゼンテーションに格納されているエンコード済みバイトが必要な場合は、変換されたラスタファイルではなく画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) が [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) オブジェクトを公開します。これにより、最初に画像をラスタライズせずに SVG データを直接取得できます。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内部でベクタソースが保存されます。PNG や JPEG などのラスタエクスポートはベクタコンテンツをピクセルにレンダリングします。PDF や SVG スライドエクスポートもレンダリング操作になるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとはみなさないでください。元のベクタリソースが必要な場合は、埋め込み [ISvgImage.getSvgData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/#getSvgData--) データを使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/) のクロップ値は元画像寸法のパーセンテージです。クロップは埋め込み画像から隠れたピクセルを削除するのではなく、表示領域を変更するだけです。

次の例は画像フレームを安全に取得し、クロップ値を適用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

隠れた画像データは依然として残っているため、後からクロップを変更しても元のピクセルは失われません。ファイルサイズが重要で、可逆性が不要な場合は、次節で説明するようにクロップ領域を物理的に削除できます。

## **クロップされた画像データの削除**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) は現在のクロップ矩形の外側にある画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズが削減できますが、破壊的な最適化となります。プレゼンテーションを保存した後は、削除されたピクセルは以後のアンクロップ操作で利用できなくなります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元の画像が他の画像フレームでも使用されている場合、これらのフレームは既存のリソースを必要とするため、クロップ領域を削除しても画像総数が減少するとは限りません。WMF や EMF コンテンツをこのメソッドでクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) は、画像が表示されるサイズに対するラスタ画像の解像度を低減します。同時にクロップ領域を削除することもできます。画像がリサイズまたはクロップされた場合は `true`、変更が不要な場合は `false` を返します。

標準的なターゲット解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/java/com.aspose.slides/picturescompression/) 値を使用してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

特定のターゲットが必要なときは、事前定義値の代わりに正の DPI 値を指定できます。

圧縮はラスタ画像を対象としています。SVG やメタファイルのコンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、解像度を下げたりクロップ領域を削除したりした場合、最適化されたプレゼンテーションからは元に戻せません。最も大きく表示またはエクスポートされるサイズに基づいてターゲット解像度を選択し、全体的に最低 DPI を適用しないようにしてください。

## **画像効果の確認**

画像効果はフレームが使用する画像に保存されます。画像変換コレクションには、透明度用の固定アルファ変調や明るさ・コントラスト用のルミナンスなどの効果が含まれることがあります。以下の例はスライド上の最初の画像フレームから両方の効果を安全に読み取ります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

これらの効果はフレーム内で画像がどのように描画されるかを変更しますが、元の埋め込み画像バイトを書き換えることはありません。

## **画像フレームジオメトリのロック**

[IPictureFrameLock](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframelock/) の設定は、画像フレームに対してどの編集操作を無効にするかを制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) はリサイズ時に形状の比率を保持します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ロックは画像フレームの形状に適用されます。ソース画像がリサンプルされたり、同じアスペクト比に永久に変更されたりすることはありません。

## **StretchOffset 値の調整**

画像の塗りつぶしモードが stretch の場合、[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/) の stretch-offset 値は画像フレームのバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを作り、負のパーセンテージはアウトセットを作ります。

これはクロップとは異なります。クロップ値は元画像のどの部分が表示されるかを選択し、stretch offset は表示される画像塗りつぶしが伸ばされる矩形を変更します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

塗りつぶし位置の調整には stretch offset を使用し、ソース画像の端を隠す目的の場合はクロップ プロパティを使用してください。

## **ストレージ、ファイルサイズ、エクスポートに関する考慮事項**

画像の保存と画像フレームの書式設定を別々に扱うと、以下のようなトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングに最も信頼性がありますが、ラスタ画像が大きいと PPTX サイズとメモリ使用量が増加します。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定されたパスで利用可能であることに依存します。
- **クロップ** は最初は非破壊的です。隠れたピクセルは明示的に削除するか、圧縮時に削除するまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を失います。スライド上での最終表示サイズが確定した後に適用すべきです。
- **SVG 画像** はベクタの保持が重要な場合は SVG のままにしてください。ベクタリソース自体が必要なときは埋め込み SVG を直接抽出します。ラスタスライドのエクスポートは常に画像をピクセルに変換します。
- **繰り返し使用される画像** は、同じファイルを何度もロードする代わりに、可能な限り既存の [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) リソースを再利用してください。

大規模なプレゼンテーションでは、画像最適化は選択的に行うと最も効果的です。ロゴや図はベクタコンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみクロップされたピクセルを除去し、外部リンクは依存関係管理が展開設計の一部でない限り避けてください。

## **FAQ**

**画像フレームと画像リソースの違いは何ですか？**

[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) はプレゼンテーションに関連付けられた画像リソースを表し、[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) は画像を表示し、サイズ、回転、クロップ値、効果、ロックなどフレームレベルのジオメトリと書式設定を保持するスライド上の形状です。

**画像は埋め込むべきかリンクにすべきか？**

プレゼンテーションの移植性、アーカイブ、外部リソースへのアクセスなしでのレンダリングが必要な場合は埋め込み画像を使用してください。画像ファイルを PPTX の外部に置き、外部場所を確実に管理できる場合にのみリンク画像を使用してください。

**クロップは PPTX のファイルサイズを減らしますか？**

単体では減りません。通常のクロップ設定は画像の一部を非表示にするだけで、基になるピクセルは残ります。ピクセルを永続的に削除したい場合は、[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) またはクロップ領域削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、クロップ領域の削除は画像データを破棄します。後で高解像度編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーション外に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタの忠実性が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) は直接抽出できます。PNG や JPEG などのラスタ形式へのスライドエクスポートは SVG をピクセルにラスタライズします。

**既存スライドを読むときに安全でないキャストを回避するには？**

シェイプのタイプを確認してから画像フレーム固有のメンバーを使用してください。[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) に対する `instanceof` チェックは無効なキャストを防ぎ、画像フレームを含まないスライドでもコードが安全に動作するようにします。