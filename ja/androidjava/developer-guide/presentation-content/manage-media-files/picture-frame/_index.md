---
title: Android でのプレゼンテーションにおけるピクチャーフレームの管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/androidjava/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームの追加
- ピクチャーフレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスター画像
- SVG 画像
- 画像のクロップ
- クロップ領域の削除
- 画像の圧縮
- StretchOffset
- ピクチャーフレームの書式設定
- 相対スケール
- 画像効果
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用した Android 用 Aspose.Slides で、プレゼンテーションのピクチャーフレームを作成、書式設定、リンク、クロップ、抽出、圧縮します。"
---
## **概要**

ピクチャーフレームは、画像を表示するスライドのシェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです。 [プレゼンテーション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) は [IImageCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagecollection/) を通じて埋め込み画像リソースを所有し、一方 [IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロップ、ピクチャー効果、その他フレームレベルの設定を制御します。

この分離は、同じ画像を複数回表示する場合に便利です。画像をプレゼンテーションに一度だけ追加し、返された [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) を保持して、ピクチャーフレームを作成するときにその画像リソースを使用します。

ピクチャーフレームは PNG や JPEG などのラスタ画像や SVG などのベクター画像を含めることができます。また、画像バイトをプレゼンテーションに保存せずにリンクされた画像を参照することもできます。選択はポータビリティ、ファイルサイズ、抽出、エクスポートの動作に影響するため、書式設定や最適化を行う前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) でピクチャーフレームを作成します。画像はプレゼンテーション パッケージの一部になるため、プレゼンテーションを別のコンピューターに移動しても自己完結した状態が保たれます。

以下の例は JPEG 画像を追加し、画像のネイティブ寸法でフレームを作成し、線の書式設定と回転を適用します。

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

ピクチャーフレームは表示される形状を制御します。フレームサイズを変更しても、埋め込み画像リソースに格納された元のピクセル寸法は変わりません。この違いは、後で画像をクロップしたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) は [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) を介してフレームの相対幅・高さスケーリングを公開します。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算する代わりに、元画像サイズとの比例関係を維持したいワークフローで有用です。

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

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像のリサンプリングや圧縮は行いません。

## **埋め込み画像とリンク画像**

埋め込みピクチャーは画像データをプレゼンテーション内部に保存するため、ポータビリティと予測可能な描画に最も安全です。リンク画像は同じ方法で画像データを埋め込む代わりに、[ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) メソッドで外部の場所を参照します。

リンク画像は PPTX に保存される画像データ量を減らすことができますが、外部依存性が発生します。リンク先ファイルはプレゼンテーションを開くまたは描画するアプリケーションからアクセス可能でなければなりません。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなった場合、リンク画像は期待通りに表示されない可能性があります。メールで送付したり、アーカイブしたり、隔離された環境で描画する必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

以下の例はピクチャーフレームを作成し、ローカル画像ファイルへのリンクを設定します。この例は画像リンクのみを扱い、動画リンクは別のメディアワークフローであり、意図的に混在させていません。

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

外部ファイル管理が意図的である場合にリンクを使用してください。圧縮の代替手段として単に使用しないでください。壊れた画像依存関係がある小さな PPTX は、自己完結した大きなプレゼンテーションよりも実用的でないことが多いです。

## **ピクチャーフレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) であり、埋め込み画像を含んでいるか確認してください。リンクされたピクチャーフレームは、同じ方法で抽出できる画像バイトを含んでいない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) を直接使用し、古い Java 画像ラッパーは不要です。以下の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

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

[IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) を使用して保存すると、抽出した画像が要求された出力形式に変換されます。プレゼンテーションに格納されたエンコード済みバイトが必要な場合は、変換されたラスタファイルではなく画像リソースのバイナリデータを使用してください。

### **SVG 画像の抽出**

SVG ピクチャーの場合、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) は [ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/) オブジェクトを公開します。これにより、先にラスタライズせずに SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内部にベクタ―ソースが保存されます。PNG や JPEG などのラスタエクスポートは、そのベクタ―コンテンツをピクセルにレンダリングします。PDF や SVG へのスライドエクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとはみなさず、元のベクタ―リソースが必要なときは埋め込み [ISvgImage.getSvgData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/#getSvgData--) データを使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。[IPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/) のクロップ値はソース画像寸法に対するパーセンテージです。クロップは埋め込み画像から隠れたピクセルを即座に削除するわけではなく、表示領域だけを変更します。

以下の例はピクチャーフレームを安全に取得し、クロップ値を適用します。

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

隠れた画像データは依然として存在するため、後でクロップを変更しても元のピクセルは失われません。ファイルサイズを重視し、元に戻す必要がない場合は、次のセクションで説明するようにクロップ領域を物理的に削除できます。

## **クロップした画像データの削除**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) は現在のクロップ矩形外の画像データを削除し、結果となる画像リソースを返します。これによりファイルサイズが削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは後からのアンクロップ操作では利用できません。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元画像が他のピクチャーフレームでも使用されている場合、これらのフレームは既存のリソースを必要とするため、クロップ領域の削除が必ずしも画像総数の削減につながるわけではありません。WMF や EMF コンテンツをこのメソッドでクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) は、画像が表示されるサイズに対してラスタ画像の解像度を低減します。同時にクロップ領域を削除することもできます。画像がリサイズまたはクロップされた場合は `true`、変更が不要だった場合は `false` を返します。

標準的な目標解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/picturescompression/) 値を使用してください。

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

圧縮はラスタ画像を対象としています。SVG やメタファイルのコンテンツはこのラスタ圧縮ワークフローでは削減されません。また、解像度を下げたりクロップ領域を削除したりすると、最適化されたプレゼンテーションからは回復できなくなることを忘れないでください。最も大きく表示またはエクスポートされるサイズに基づいて目標解像度を選択し、全体的に最低 DPI を適用するのは避けましょう。

## **画像変換エフェクトの管理**

明るさ、コントラスト、カラー変換、ぼかし、アルファ効果、順序付けられたチェーン、検査、削除、往復検証をカバーする完全なワークフローについては、[Image Transform Effects](/slides/ja/androidjava/image-transform-effects/) を参照してください。

## **ピクチャーフレームのジオメトリをロックする**

[IPictureFrameLock](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframelock/) 設定は、ピクチャーフレームに対して無効化する編集操作を制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) はリサイズ時にシェイプの比率を保持します。

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

ロックはピクチャーフレームのシェイプに適用されます。ソース画像がリサンプリングされたり、同じアスペクト比に永久に変更されたりすることは強制されません。

## **StretchOffset の値を調整する**

ピクチャーの塗りつぶしモードが stretch の場合、[IPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/) の stretch‑offset 値はピクチャーフレームの境界ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを、負のパーセンテージはアウトセットを作ります。

これはクロップとは異なります。クロップ値はソース画像のどの部分が表示されるかを選択しますが、stretch offset は表示されたピクチャー塗りつぶしが伸張される矩形を変更します。

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

塗りつぶし位置の調整には stretch offset を使用し、ソース画像の端を隠す目的にはクロッププロパティを使用してください。

## **保存、ファイルサイズ、エクスポートに関する考慮事項**

画像の保存方法とピクチャーフレームの書式設定を別々に扱うと、以下のようなトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングに最も信頼性がありますが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが保存されたパスまたは場所に依存します。
- **クロップ** は最初は非破壊的です。隠れたピクセルはクロップ領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上での実際の表示サイズが決まってから適用すべきです。
- **SVG 画像** はベクターの保持が重要な場合は SVG のままにすべきです。ベクターリソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスタスライドエクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は可能な限り既存の [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) リソースを再利用し、同じファイルを何度もロードしないようにしてください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施することで最も効果的です。ロゴや図はベクタ―コンテンツのまま保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみクロップピクセルを削除し、外部リンクは依存管理がデプロイ設計の一部である場合にのみ使用してください。

## **FAQ**

**ピクチャーフレームと画像リソースの違いは何ですか？**

[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) はスライド上のシェイプで、画像を表示し、サイズ、回転、クロップ値、エフェクト、ロックなどフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションをポータブルに、アーカイブ可能に、外部リソースなしで描画する必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外に保持し、外部の場所を確実に管理できる場合にのみリンク画像を使用してください。

**クロップだけで PPTX のファイルサイズは減りますか？**

クロップ自体はサイズを減らしません。通常のクロップ設定は画像の一部を非表示にしますが、基になるピクセルは保持されます。ピクセルを永続的に削除したい場合は、[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) またはクロップ領域削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、クロップ領域の削除は画像データを破棄します。後で高解像度の編集が必要になる可能性がある場合は、オリジナルのソース画像をプレゼンテーションの外部に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクターの忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/) は直接抽出できます。PNG や JPEG などのラスタ形式にスライドをエクスポートすると、SVG はスライド画像の一部としてピクセルにラスタライズされます。

**既存スライドを読み込む際に安全でないキャストを回避するには？**

シェイプの型を使用する前に確認してください。[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) に対する `instanceof` チェックを行うことで、無効なキャストを防ぎ、ピクチャーフレームを含まないスライドでも安全に処理できます。