---
title: Java を使用したプレゼンテーションでの画像フレームの管理
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
- ストレッチオフセット
- 画像フレームの書式設定
- 相対スケール
- 画像エフェクト
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、クロップ、抽出、圧縮します。"
---
## **概要**

Picture frame は画像を表示するスライド シェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです。a [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) は埋め込み画像リソースをその [IImageCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimagecollection/) を介して所有し、[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロップ、画像効果、およびその他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合にこの分離は便利です。画像をプレゼンテーションに一度追加し、返された [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) を保持し、画像フレームを作成する際にその画像リソースを使用します。

Picture frames は PNG や JPEG といったラスタ画像や SVG といったベクタ画像を含めることができます。また、プレゼンテーションに画像バイトを格納せずにリンク画像を参照することもできます。選択はポータビリティ、ファイルサイズ、抽出、エクスポートの挙動に影響するため、書式設定や最適化を適用する前に画像の保存方法を決定しておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) で画像フレームを作成します。画像はプレゼンテーション パッケージの一部になるため、別のコンピューターに移動してもプレゼンテーションは自己完結型のままです。

以下の例は JPEG 画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用します。

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

画像フレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに格納された元のピクセル寸法は変わりません。この区別は、後で画像をクロップしたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) は [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) によってフレームの相対幅・高さスケーリングを公開します。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算する代わりに、元画像サイズとの関係を保持したいワークフローで便利です。

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

相対スケールはフレームのスケール設定を変更します。埋め込み画像そのものをリサンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内部に保存するため、ポータビリティと予測可能なレンダリングの観点から最も安全な選択です。リンク画像は [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) メソッドで外部の場所を指し示し、画像データを同様に埋め込むことはしません。

リンク画像は PPTX に保存される画像データ量を減らすことができますが、外部依存が発生します。リンク先ファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションからアクセス可能である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなると、リンク画像は期待通りに表示されない可能性があります。メールで送信したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

以下の例は画像フレームを作成し、ローカル画像ファイルを指し示します。画像のリンクにのみ焦点を当てており、動画のリンクは別のメディア ワークフローで扱うため、この例には混在させていません。

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

外部ファイル管理が意図的である場合にリンクを使用してください。単に圧縮の代替として使用しないでください。壊れた画像依存関係を持つ小さな PPTX は、サイズが大きく自己完結型のプレゼンテーションほど有用ではありません。

## **画像フレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) であり、埋め込み画像を含んでいるかを確認してください。リンク画像フレームは同じ方法で抽出できる画像バイトを持たない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) を直接使用し、従来の Java 画像ラッパーは不要です。以下の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

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

[IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/#save-java.lang.String-int-) を使用すると、抽出した画像が要求された出力形式に変換されます。プレゼンテーションに格納されているエンコードされたバイトが必要な場合は、変換後のラスタファイルではなく画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) は [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) オブジェクトを公開します。これにより、まず画像をラスタライズすることなく SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内にベクタ ソースが保存されます。PNG や JPEG といったラスタ エクスポートは、そのベクタ コンテンツをピクセルにレンダリングします。PDF や SVG へのスライド エクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとはみなさないでください。元のベクタ リソースが必要なときは埋め込み [ISvgImage.getSvgData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/#getSvgData--) データを使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/) のクロップ値は、元画像の寸法に対するパーセンテージです。クロップは埋め込み画像から隠れたピクセルを即座に削除するわけではなく、表示領域だけを変更します。

以下の例は画像フレームを安全に取得し、クロップ値を適用します。

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

隠れた画像データはまだ存在するため、後から元のピクセルを失うことなくクロップを変更できます。ファイルサイズが重要で、元に戻す必要がない場合は、次のセクションで説明するようにクロップ領域を物理的に除去できます。

## **クロップされた画像データの削除**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) は現在のクロップ矩形の外側にある画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズが削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは後からのアンクロップ操作で利用できなくなります。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加することがあります。元の画像が他の画像フレームでも使用されている場合、それらのフレームは既存のリソースを必要とするため、クロップ領域の削除が必ずしも画像総数の減少につながるわけではありません。WMF や EMF コンテンツをこのメソッドでクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) は、画像が表示されるサイズに対するラスタ画像の解像度を低減します。同時にクロップ領域を削除することもできます。メソッドは画像がリサイズまたはクロップされた場合に `true`、変更が不要だった場合に `false` を返します。

標準的なターゲット解像度が十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/java/com.aspose.slides/picturescompression/) 値を使用してください。

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

特定のターゲットが必要なときは、事前定義値の代わりにカスタムの正の DPI 値を渡すこともできます。

圧縮はラスタ画像を対象としています。SVG やメタファイル コンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、低解像度化および削除されたクロップ領域は最適化されたプレゼンテーションから復元できないことに留意してください。画像が実際に表示またはエクスポートされる最大サイズに基づいてターゲット解像度を選択し、全体的に最低 DPI を適用しないようにしてください。

## **画像変換エフェクトの管理**

明度、コントラスト、カラー変換、ぼかし、アルファ効果、順序チェーン、検査、除去、ラウンドトリップ検証を網羅した完全なワークフローについては、[Image Transform Effects](/slides/ja/java/image-transform-effects/) を参照してください。

## **画像フレーム ジオメトリのロック**

[IPictureFrameLock](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframelock/) の設定は、画像フレームに対して無効化する編集操作を制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) はリサイズ時にシェイプの比率を保持します。

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

ロックは画像フレームのシェイプに適用されます。ソース画像をリサンプリングしたり、恒久的に同じアスペクト比に変更したりすることは強制されません。

## **StretchOffset 値の調整**

画像の塗りつぶしモードが stretch の場合、[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/) の stretch‑offset 値は画像フレームのバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを作り、負のパーセンテージはアウトセットを作ります。

これはクロップとは異なります。クロップ値は元画像のどの部分が表示されるかを選択しますが、stretch offset は表示される画像塗りつぶしが伸縮される矩形を変更します。

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

塗りつぶしの配置には stretch offset を使用し、ソース画像の端を隠す目的にはクロップ プロパティを使用してください。

## **保存、ファイルサイズ、エクスポート上の考慮点**

画像の保存方法と画像フレームの書式設定を分離して考えると、主要なトレードオフが管理しやすくなります：

- **Embedded images** はプレゼンテーションを自己完結型にし、共有やサーバー側レンダリングで最も信頼性が高いですが、ラスタ画像が大きいと PPTX のサイズとメモリ使用量が増加します。
- **Linked images** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが保存されたパスまたは場所に残っていることに依存します。
- **Cropping** は当初は非破壊的です。隠れたピクセルはクロップ領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **Compression** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上での最終サイズが判明した後に適用すべきです。
- **SVG images** はベクタの保持が重要な場合は SVG のままにすべきです。ベクタリソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスタスライド エクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **Repeated images** は可能な限り既存の [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) リソースを再利用し、同じファイルを何度もプレゼンテーション ワークフローに読み込むのを避けてください。

大規模なプレゼンテーションでは、画像最適化は選択的に行うと最も効果的です。ロゴや図表はベクタ コンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみクロップされたピクセルを削除し、外部リンクは依存関係管理がデプロイ設計に組み込まれている場合にのみ使用してください。

## **FAQ**

**画像フレームと画像リソースの違いは何ですか？**

[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) はスライド上のシェイプで、画像を表示し、サイズ、回転、クロップ値、エフェクト、ロックなどフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションをポータブルにしたり、アーカイブしたり、外部リソースにアクセスできずにレンダリングする必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外部に保持し、外部場所を確実に管理できる場合にのみリンク画像を使用してください。

**クロップは PPTX のファイルサイズを減らしますか？**

単体では減らしません。通常のクロップ設定は画像の一部を隠すだけで、基になるピクセルは保持されたままです。ピクセルを永久に削除したい場合は [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) またはクロップ領域削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を元に戻すことはできますか？**

できません。圧縮は格納されたラスタ解像度を低下させ、クロップ領域の削除は画像データを破棄します。後で高解像度の編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーションの外部に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタ の忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) は直接抽出できます。PNG や JPEG へのスライド レンダリングは SVG をラスタ化します。

**既存スライドを読むときに安全でないキャストを回避するには？**

シェイプが画像フレームかどうかを使用する前に確認してください。[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) への `instanceof` チェックを行うことで、無効なキャストを防ぎ、画像フレームを含まないスライドにも対応できます。