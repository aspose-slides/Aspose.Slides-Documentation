---
title: Android のプレゼンテーションで画像フレームを管理する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/androidjava/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスタ画像
- SVG 画像
- 画像のトリミング
- トリミング領域の削除
- 画像の圧縮
- ストレッチオフセット
- 画像フレームの書式設定
- 相対スケール
- 画像エフェクト
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android (Java) を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、トリミング、抽出、圧縮します。"
---
## **概要**

画像フレームは画像を表示するスライド シェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトとして扱われます。`[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/)` は埋め込み画像リソースを `[IImageCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagecollection/)` を介して所有し、`[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/)` が画像の位置、サイズ、線の書式設定、回転、トリミング、画像効果、およびその他のフレームレベル設定を制御します。

この分離により、同じ画像を複数回表示する場合に便利です。画像をプレゼンテーションに一度だけ追加し、返された `[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/)` を保持し、画像リソースを使用して画像フレームを作成します。

画像フレームは PNG や JPEG のようなラスタ画像、SVG のようなベクタ画像の両方を含めることができます。また、画像バイトをプレゼンテーションに保存せずにリンク画像を参照することもできます。選択は移植性、ファイル サイズ、抽出、エクスポート動作に影響するため、書式設定や最適化を行う前に画像の保存方法を決定しておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、`[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)` で画像フレームを作成します。画像はプレゼンテーション パッケージの一部になるため、プレゼンテーションは別のコンピューターに移動しても自己完結しています。

次の例は JPEG 画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用します。

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

画像フレームは表示されるジオメトリを制御します。フレームのサイズを変更しても、埋め込み画像リソースに保存されている元のピクセル寸法は変わりません。この区別は、後で画像をトリミングまたは圧縮する際に重要になります。

## **相対スケールの使用**

`[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/)` は `[setRelativeScaleWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-)` と `[setRelativeScaleHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-)` を介してフレームの相対幅・高さスケーリングを公開します。`1.0` の値は元画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算せずに元画像サイズとの関係を保持したいワークフローに便利です。

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

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像を再サンプルしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内部に保存するため、移植性と予測可能なレンダリングに最も安全です。リンク画像は `[ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-)` メソッドで外部パスを設定し、画像データを埋め込む代わりに参照します。

リンク画像は PPTX 内の画像データ量を減らせますが、外部依存が発生します。リンク先ファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションからアクセス可能である必要があります。パスが変更されたり、ファイルが移動したり、リソースが利用できなくなったりすると、リンク画像は期待通りに表示されない可能性があります。メールで送付したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例は画像フレームを作成し、ローカル画像ファイルへのパスを設定します。この例は画像リンクのみを扱い、動画リンクは別のメディア ワークフローであり、意図的に混在させていません。

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

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替としてリンクを使用しないでください。破損した画像依存関係を持つ小さな PPTX は、サイズが大きい自己完結型プレゼンテーションよりも実用的でないことが多いです。

## **画像フレームからの画像抽出**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に `[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/)` であり、埋め込み画像を含んでいるか確認してください。リンクされた画像フレームは同じ方法で抽出できるバイトを持たない可能性があります。

### **ラスタ画像の抽出**

最新の画像 API は `[IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/)` を直接使用し、従来の Java 画像ラッパーは必要ありません。次の例はスライド上の最初の埋め込みラスタ画像を検索し、PNG として保存します。

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

`[IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)` を通して保存すると、抽出された画像が要求された出力形式に変換されます。プレゼンテーションに保存されているエンコード済みバイトが必要な場合は、変換後のラスタファイルではなく画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、`[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/)` は `[ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/)` オブジェクトを公開します。これにより、画像をラスタライズせずに SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内にベクタ ソースが残ります。PNG や JPEG などのラスタ エクスポートはベクタ コンテンツをピクセルにレンダリングします。PDF や SVG のスライド エクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のビット単位のコピーとして扱わず、元のベクタ リソースが必要な場合は埋め込み `[ISvgImage.getSvgData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/#getSvgData--)` データを使用してください。

## **画像のトリミング**

トリミングはフレーム内で画像のどの部分が表示されるかを変更します。`[IPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/)` のトリミング値は元画像寸法のパーセンテージです。トリミングは埋め込み画像から隠れたピクセルを削除するわけではなく、表示領域のみを変更します。

次の例は画像フレームを安全に取得し、トリミング値を適用します。

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

隠れた画像データはまだ存在するため、後でトリミングを変更しても元のピクセルは失われません。ファイル サイズが重要で、可逆性が不要な場合は、次のセクションで説明するようにトリミング領域を物理的に削除できます。

## **トリミングされた画像データの削除**

`[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)` は現在のトリミング矩形外の画像データを削除し、結果として得られた画像リソースを返します。これによりファイル サイズを削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは元に戻せなくなります。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加することがあります。元の画像が他の画像フレームでも使用されている場合、これらのフレームは既存のリソースを必要とするため、削除が必ずしも画像総数の削減につながるわけではありません。WMF や EMF コンテンツをこのメソッドでトリミングすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

`[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-)` は画像が表示されるサイズに対する解像度を下げます。同時にトリミング領域を削除することも可能です。画像がリサイズまたはトリミングされた場合は `true`、変更が不要な場合は `false` を返します。

標準的なターゲット解像度で十分な場合は、事前定義された `[PicturesCompression](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/picturescompression/)` 値を使用してください。

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

特定のターゲットが必要な場合は、事前定義値の代わりに正の DPI 値をカスタムで渡すことができます。

圧縮はラスタ画像を対象としています。SVG やメタファイルのコンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、解像度を下げたりトリミング領域を削除したりした場合は、最適化されたプレゼンテーションから復元できないことを忘れないでください。最も大きく表示またはエクスポートされるサイズに基づいてターゲット解像度を選択し、全体的に最小 DPI を適用しないようにしてください。

## **画像変形エフェクトの管理**

明るさ、コントラスト、カラー変換、ぼかし、アルファ効果、順序付けられたチェーン、検査、削除、往復検証を網羅する完全なワークフローについては、`[Image Transform Effects](/androidjava/image-transform-effects/)` を参照してください。

## **画像フレームジオメトリのロック**

`[IPictureFrameLock](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframelock/)` 設定は画像フレームに対してどの編集操作を無効にするかを制御します。例として `[setAspectRatioLocked](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)` はリサイズ時に形状の比率を保持します。

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

ロックは画像フレームのシェイプに適用されます。ソース画像が再サンプリングされたり、同じアスペクト比に永久に変更されたりすることは強制されません。

## **StretchOffset 値の調整**

画像の塗りつぶしモードがストレッチの場合、`[IPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/)` の StretchOffset 値は画像フレームのバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを、負のパーセンテージはアウトセットを作ります。

これはトリミングとは異なります。トリミング値は元画像のどの部分が表示されるかを選択し、StretchOffset は表示される画像塗りつぶしが伸縮される矩形を変更します。

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

塗りつぶし配置には StretchOffset を使用し、ソース画像の端を隠す目的にはトリミング プロパティを使用してください。

## **保管、ファイル サイズ、エクスポート上の考慮点**

画像の保管と画像フレームの書式設定を別々に扱うと、主なトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングに最も信頼性がありますが、大きなラスタ画像は PPTX サイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定されたパスまたは場所に残っていることに依存します。
- **トリミング** は最初は非破壊的です。トリミング領域が明示的に削除されるか、圧縮中に除去されるまで、隠れたピクセルは埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイル サイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上の実際の表示サイズが決まってから適用すべきです。
- **SVG 画像** はベクタ保存が重要な場合は SVG のままにすべきです。ベクタ リソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスタ スライド エクスポートは常にレンダリング結果をピクセルに変換します。
- **繰り返し使用される画像** は可能な限り既存の `[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/)` リソースを再利用し、同じファイルを何度もプレゼンテーション ワークフローにロードしないでください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施するのが効果的です。ロゴや図はベクタ コンテンツのまま保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみトリミングされたピクセルを削除し、外部リンクは依存関係管理がデプロイ設計の一部である場合にのみ使用してください。

## **FAQ**

**画像フレームと画像リソースの違いは何ですか？**

`[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/)` はプレゼンテーションに関連付けられた画像リソースを表し、`[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/)` は画像を表示し、サイズ、回転、トリミング値、エフェクト、ロックなどのフレームレベルのジオメトリと書式設定を保持するスライド上のシェイプです。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションを移植可能、アーカイブ、または外部リソースなしでレンダリングする必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外部に保持し、外部場所を信頼できる形で管理できる場合のみリンク画像を使用してください。

**トリミングは PPTX のファイル サイズを削減しますか？**

単体では削減しません。通常のトリミング設定は画像の一部を非表示にしますが、基になるピクセルは保持されます。ピクセルを永久に削除したい場合は `[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)` またはトリミング領域削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、トリミング領域の削除は画像データを破棄します。後で高解像度編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーション外に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタ の忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み `[ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/)` は直接抽出できます。スライドを PNG や JPEG などのラスタ形式にレンダリングすると、SVG はスライド画像の一部としてピクセルに変換されます。

**既存スライドを読み取るときに安全でないキャストを回避するには？**

シェイプの型を使用する前に確認してください。`instanceof` を使って `[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/)` かどうかを判定すれば、無効なキャストを防ぎ、画像フレームを含まないスライドでも安全に処理できます。