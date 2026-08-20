---
title: Android でのプレゼンテーションにおけるピクチャーフレームの管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/androidjava/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームを追加
- ピクチャーフレームを作成
- 埋め込み画像
- リンク画像
- 画像を抽出
- ラスタ画像
- SVG 画像
- 画像をトリミング
- トリミング領域の削除
- 画像を圧縮
- StretchOffset
- ピクチャーフレームの書式設定
- 相対スケール
- 画像エフェクト
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、プレゼンテーション内のピクチャーフレームを作成、書式設定、リンク、トリミング、抽出、圧縮します。"
---
## **概要**

ピクチャーフレームは画像を表示するスライドシェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトとして扱われます。つまり、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) が [IImageCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagecollection/) を通じて埋め込み画像リソースを所有し、[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) が画像の位置、サイズ、線の書式設定、回転、トリミング、ピクチャーエフェクト、その他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合にこの分離は便利です。画像をプレゼンテーションに一度追加し、返された [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) を保持して、ピクチャーフレーム作成時にその画像リソースを使用します。

ピクチャーフレームは PNG や JPEG といったラスタ画像や SVG といったベクタ画像を含めることができます。また、画像バイトをプレゼンテーションに格納せずにリンク画像を参照させることもできます。選択はポータビリティ、ファイルサイズ、抽出、エクスポートの挙動に影響するため、書式設定や最適化を行う前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) でピクチャーフレームを作成します。画像はプレゼンテーションパッケージの一部となるため、別のコンピューターに移動してもプレゼンテーションは自己完結した状態を保ちます。

以下の例は JPEG 画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用しています：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

ピクチャーフレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに保存された元のピクセル寸法は変わりません。この区別は後で画像をトリミングしたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) はフレームに対して幅と高さの相対スケールを [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) で公開しています。`1.0` の値は元画像サイズの 100% に相当します。相対スケールは、最終的な寸法を手動で計算する代わりに、元画像サイズとの比率を保持したいワークフローで便利です。

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

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像をリサンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込みピクチャーは画像データをプレゼンテーション内部に格納するため、ポータビリティと予測可能な描画に最も安全な選択です。リンクピクチャーは [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) メソッドで外部の場所を参照し、同様に画像データを埋め込むことはしません。

リンク画像は PPTX に格納される画像データ量を減らすことができますが、外部依存が発生します。リンク先ファイルがアプリケーションからアクセス可能である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなると、リンク画像は期待通りに表示されなくなることがあります。メールで送付したり、アーカイブしたり、孤立した環境で描画する必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

以下の例はピクチャーフレームを作成し、ローカル画像ファイルへポイントさせます。画像リンクだけを扱い、動画リンクは別のメディアワークフローであり、今回の例には意図的に混ぜていません。

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

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替としてリンクを使用しないでください。破損した画像依存関係を持つ小さな PPTX は、容量が大きく自己完結したプレゼンテーションよりも実用性が低くなります。

## **ピクチャーフレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、対象のシェイプが実際に [IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) であり、埋め込み画像を保持しているかを確認してください。リンクされたピクチャーフレームは同様の方法で抽出できる画像バイトを持たないことがあります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) を直接使用し、従来の Java 画像ラッパーは不要です。以下の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

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

[IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) を使用すると、抽出した画像が要求された出力形式に変換されて保存されます。プレゼンテーションに格納されているエンコード済みバイト列が必要な場合は、画像リソースのバイナリデータを直接利用してください。

### **SVG 画像の抽出**

SVG ピクチャーの場合、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) が [ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/) オブジェクトを公開します。これにより、まず画像をラスタライズせずに SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内部にベクタ元が残ります。PNG や JPEG などのラスタエクスポートはベクタをピクセルにレンダリングします。PDF や SVG へのスライドエクスポートもレンダリング操作であるため、エクスポートされた画像は元の埋め込み SVG のバイト単位のコピーとはみなさず、元のベクタリソースが必要なときは埋め込み [ISvgImage.getSvgData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/#getSvgData--) を使用してください。

## **画像のトリミング**

トリミングはフレーム内で表示される画像の領域を変更します。[IPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/) のトリミング値は元画像サイズに対するパーセンテージです。トリミングは埋め込み画像から隠れたピクセルを即座に削除するわけではなく、表示領域だけを変えます。

以下の例はピクチャーフレームを安全に取得し、トリミング値を適用します：

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

隠れた画像データは依然として存在するため、後からトリミングを変更しても元のピクセルは失われません。ファイルサイズを最優先にする場合は、次のセクションで説明するようにトリミング領域を物理的に除去できます。

## **トリミングされた画像データの削除**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) は現在のトリミング矩形外の画像データを除去し、結果として得られる画像リソースを返します。これによりファイルサイズは削減できますが、破壊的な最適化となります。プレゼンテーションを保存した後は、削除されたピクセルは元に戻せなくなります。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元画像が他のピクチャーフレームでも使用されている場合、そのフレームは既存のリソースを引き続き必要とするため、トリミング領域の削除だけで画像総数が減るとは限りません。WMF や EMF コンテンツに対してこのメソッドを使用すると、トリミング結果が PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) は、画像が表示されるサイズに対してラスタ画像の解像度を低減します。圧縮時にトリミング領域を同時に除去することも可能です。画像がリサイズまたはトリミングされた場合は `true`、変更が不要だった場合は `false` を返します。

標準的な目標解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/picturescompression/) 値を使用してください：

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

特定の目標が必要な場合は、事前定義値の代わりにカスタムの正の DPI 値を渡すことができます。

圧縮はラスタ画像を対象としています。SVG やメタファイルはこのラスタ圧縮ワークフローでは縮小されません。また、解像度を下げたりトリミング領域を削除したりした画像は最適化されたプレゼンテーションから復元できません。対象画像が実際に表示またはエクスポートされる最大サイズに合わせて目標解像度を選択し、全体的に最も低い DPI を適用するのは避けてください。

## **画像エフェクトの検査**

ピクチャーエフェクトはフレームが使用する画像に保存されます。画像変換コレクションには、透明度用の固定アルファ変調や明るさ・コントラスト用のルミナンスなどのエフェクトが含まれることがあります。以下の例はスライド上の最初のピクチャーフレームから両方のエフェクトを安全に読み取ります：

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

これらのエフェクトはフレーム内で画像が描画される方法を変更しますが、埋め込み画像バイト自体を書き換えることはありません。

## **ピクチャーフレームジオメトリのロック**

[IPictureFrameLock](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframelock/) 設定は、ピクチャーフレームに対して無効にする編集操作を制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) はリサイズ時にシェイプの縦横比を保持します。

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

ロックはピクチャーフレームのシェイプに適用されます。元画像自体がリサンプリングされたり、同じ縦横比に永続的に変更されたりするわけではありません。

## **StretchOffset 値の調整**

ピクチャーの塗りつぶしモードが stretch の場合、[IPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/) の stretch‑offset 値はピクチャーフレームのバウンディングボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを、負のパーセンテージはアウトセットを作ります。

これはトリミングとは異なります。トリミング値は元画像のどの部分を表示するかを選択しますが、stretch offset は表示される画像が伸張される矩形そのものを変更します。

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

塗りつぶし位置を調整したいときは stretch offset を使用し、元画像の端部を隠したいときはトリミングプロパティを使用してください。

## **保存、ファイルサイズ、エクスポートに関する考慮事項**

画像の保存方法とピクチャーフレームの書式設定を別々に扱うと、以下のようなトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングに最も信頼性がありますが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増大させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定パスで利用可能であることに依存します。
- **トリミング** は当初は破壊的ではありません。隠れたピクセルは削除領域が明示的に削除または圧縮されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度は失われます。スライド上での実際の表示サイズが確定した後に適用すべきです。
- **SVG 画像** はベクタの保持が重要な場合は SVG のまま残してください。ベクタリソース自体が必要なときは埋め込み SVG を直接抽出します。ラスタスライドエクスポートは常に画像をピクセルに変換します。
- **繰り返し使用される画像** は可能な限り既存の [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) リソースを再利用し、同じファイルを何度もプレゼンテーションに読み込むのを避けます。

大規模なプレゼンテーションでは、画像最適化は選択的に行うのが最も効果的です。ロゴや図はベクタコンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合のみトリミングピクセルを削除し、外部リンクは依存管理が設計に組み込まれている場合にのみ使用してください。

## **FAQ**

**ピクチャーフレームと画像リソースの違いは何ですか？**

[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) はスライド上のシェイプで、画像を表示し、サイズ、回転、トリミング値、エフェクト、ロックといったフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションをポータブルにしたり、アーカイブしたり、外部リソースにアクセスできない環境でレンダリングする必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外部に保持し、外部場所を確実に管理できる場合にのみリンク画像を使用してください。

**トリミングは PPTX のファイルサイズを減らしますか？**

単体では減りません。通常のトリミング設定は画像の一部を非表示にするだけで、基になるピクセルは残ります。ピクセルを完全に削除したい場合は [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) またはトリミング領域の除去を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、トリミング領域の削除は画像データを破棄します。後で高解像度編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーション外に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタの忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/) は直接抽出できます。スライドを PNG や JPEG などのラスタ形式にレンダリングすると、SVG はピクセルに変換されます。

**既存のスライドを読むときに安全でないキャストを防ぐには？**

シェイプの型を使用する前に必ずチェックしてください。[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) への `instanceof` 判定を行うことで、無効なキャストを回避し、ピクチャーフレームを含まないスライドでも安全に処理できます。