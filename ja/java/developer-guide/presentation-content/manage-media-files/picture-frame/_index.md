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
- ラスター画像
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
description: "Aspose.Slides for Java でプレゼンテーションの画像フレームを作成、書式設定、リンク、クロップ、抽出、圧縮できます。"
---
## **概要**

画像フレームは画像を表示するスライド形状です。Aspose.Slides では、画像リソースとそれを表示する形状は別々のオブジェクトです：[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) は埋め込み画像リソースをその [IImageCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimagecollection/) を介して所有し、一方 [IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロッピング、画像効果、その他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合、この分離は有用です。画像をプレゼンテーションに一度追加し、返された [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) を保持し、ピクチャーフレームを作成する際にその画像リソースを使用します。

ピクチャーフレームは PNG や JPEG といったラスタ画像や SVG のようなベクタ画像を含めることができます。また、プレゼンテーションに画像バイトを格納せずにリンク画像を参照することもできます。選択はポータビリティ、ファイルサイズ、抽出、エクスポートの動作に影響するため、書式設定や最適化を行う前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) でピクチャーフレームを作成します。画像はプレゼンテーションパッケージの一部になるため、別のコンピュータに移動してもプレゼンテーションは自己完結します。

次の例は JPEG 画像を追加し、画像の元のサイズでフレームを作成し、線の書式設定と回転を適用します：

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

ピクチャーフレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに格納された元のピクセル寸法は変わりません。この区別は、後で画像をクロップしたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) はフレームに対して幅と高さの相対スケーリングを [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) で公開します。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算する代わりに、元画像サイズとの関係を保持したいワークフローで便利です。

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

埋め込み画像は画像データをプレゼンテーション内に格納するため、ポータビリティと予測可能なレンダリングに最も安全です。リンク画像は [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) メソッドで外部の場所を指すため、画像データを同様に埋め込むことはありません。

リンク画像は PPTX に格納される画像データ量を減らすことができますが、外部依存性が生じます。リンク先ファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションからアクセス可能である必要があります。パスが変わったり、ファイルが移動したり、リソースが利用できなくなったりすると、リンク画像は期待通りに表示されないことがあります。メールで送信したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例はピクチャーフレームを作成し、ローカル画像ファイルへのパスを設定します。これは画像リンクのみを扱い、動画リンクは別のメディアワークフローであり、この例には意図的に混在させていません。

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

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替としてリンクを使用しないでください。壊れた画像依存関係を持つ小さな PPTX は、通常、サイズが大きい自己完結型プレゼンテーションよりも実用性が低くなります。

## **ピクチャーフレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) であり、埋め込み画像を含んでいるか確認してください。リンクされたピクチャーフレームは、同じ方法で抽出できる画像バイトを持っていない場合があります。

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

[IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/#save-java.lang.String-int-) を使用して保存すると、抽出した画像が要求された出力形式に変換されます。プレゼンテーションに格納されたエンコード済みバイトが必要な場合は、変換されたラスタファイルではなく画像リソースのバイナリデータを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) は [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) オブジェクトを提供します。これにより、画像を先にラスタライズすることなく SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内にベクタソースが保存されます。PNG や JPEG などのラスタエクスポートは、そのベクタコンテンツをピクセルにレンダリングします。PDF や SVG へのスライドエクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位コピーとはみなさないでください。元のベクタリソースが必要な場合は、埋め込み [ISvgImage.getSvgData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/#getSvgData--) データを使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/) のクロップ値は元画像寸法のパーセンテージです。クロップは埋め込み画像から隠れたピクセルを最初に削除するわけではなく、表示領域だけを変更します。

次の例はピクチャーフレームを安全に取得し、クロップ値を適用します。

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

隠れた画像データは依然として存在するため、後からクロップを変更しても元のピクセルは失われません。ファイルサイズが重要で、可逆性が不要な場合は、次のセクションで説明するようにクロップ領域を物理的に削除できます。

## **クロップした画像データの削除**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) は現在のクロップ矩形外の画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズは減りますが、破壊的な最適化です：プレゼンテーションを保存した後は、削除されたピクセルは後からのアンクロップ操作で利用できなくなります。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加することがあります。元の画像が他のピクチャーフレームでも使用されている場合、これらのフレームは既存のリソースを引き続き必要とするため、削除が必ずしも画像総数の削減につながるわけではありません。WMF や EMF コンテンツをこのメソッドでクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) は、画像が表示されるサイズに対するラスタ画像の解像度を下げます。同時にクロップ領域を削除することもできます。このメソッドは画像がリサイズまたはクロップされた場合に `true`、変更が不要な場合に `false` を返します。

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

特定のターゲットが必要なときは、事前定義値の代わりにカスタムの正の DPI 値を渡すことができます。

圧縮はラスタ画像を対象としています。SVG やメタファイルのコンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、解像度を下げたりクロップ領域を削除したりした画像は最適化されたプレゼンテーションから復元できないことを覚えておいてください。最も大きく表示またはエクスポートされるサイズに基づいてターゲット解像度を選択し、全体的に最低 DPI を適用しないようにしてください。

## **画像変換エフェクトの管理**

明るさ、コントラスト、カラー変換、ぼかし、アルファ効果、順序チェーン、検査、除去、ラウンドトリップ検証を含む完全なワークフローについては、[Image Transform Effects](/java/image-transform-effects/) を参照してください。

## **ピクチャーフレームジオメトリのロック**

[IPictureFrameLock](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframelock/) の設定は、ピクチャーフレームに対してどの編集操作が無効になるかを制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) はサイズ変更時に形状の比率を保持します。

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

ロックはピクチャーフレームの形状に適用されます。ソース画像がリサンプリングされたり、同じアスペクト比に永久に変更されたりすることはありません。

## **StretchOffset 値の調整**

ピクチャーの塗りつぶしモードが stretch の場合、[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/) の stretch‑offset 値はピクチャーフレームの境界ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを作り、負のパーセンテージはアウトセットを作ります。

これはクロップとは異なります。クロップ値は元画像のどの部分が表示されるかを選択しますが、stretch offset は表示されるピクチャー塗りつぶしが伸張される矩形を変更します。

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

塗りつぶし位置を設定する場合は stretch offset を使用し、ソース画像の端を非表示にしたい場合はクロッププロパティを使用してください。

## **保存、ファイルサイズ、エクスポートに関する考慮事項**

画像の保存とピクチャーフレームの書式設定を別々に扱うと、主なトレードオフが管理しやすくなります：

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングに最も信頼性がありますが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定されたパスや場所に存在し続けることに依存します。
- **クロップ** は最初は非破壊的です。隠れたピクセルはクロップ領域が明示的に削除されるか、圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上での最終表示サイズが決まってから適用すべきです。
- **SVG 画像** はベクタの保存が重要な場合は SVG のまま保持すべきです。ベクタリソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスタスライドエクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は、同じファイルを何度もロードする代わりに、可能な限り既存の [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) リソースを再利用してください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施するのが最も効果的です。ロゴや図はベクタコンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみクロップしたピクセルを削除し、外部リンクは依存管理がデプロイ設計の一部でない限り避けてください。

## **FAQ**

**ピクチャーフレームと画像リソースの違いは何ですか？**

[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) はスライド上の形状で、画像を表示し、サイズ、回転、クロップ値、エフェクト、ロックなどフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションがポータブルである必要がある、アーカイブする、または外部リソースなしでレンダリングする必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外に保持することが意図的で、外部場所を確実に管理できる場合にのみリンク画像を使用してください。

**クロップは PPTX のファイルサイズを減らしますか？**

単体では減りません。通常のクロップ設定は元画像のピクセルを隠すだけで保持します。ピクセルを完全に削除したい場合は [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) またはクロップ領域削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、クロップ領域の削除は画像データを破棄します。後で高解像度編集が必要な場合は、元のソース画像をプレゼンテーションの外部に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタの忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) は直接抽出できます。PNG や JPEG などのラスタ形式へのスライド出力は、SVG をスライド画像の一部としてラスタライズします。

**既存のスライドを読み込むときに安全でないキャストを回避するには？**

ピクチャーフレーム固有のメンバーを使用する前にシェイプの型を確認してください。[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) に対する `instanceof` チェックは無効なキャストを防ぎ、ピクチャーフレームを含まないスライドでもコードが適切に対処できるようにします。