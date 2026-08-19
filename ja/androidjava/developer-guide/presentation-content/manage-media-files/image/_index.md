---
title: Android のプレゼンテーションにおける画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/androidjava/image/
keywords:
- 画像を追加
- 画像を追加
- 画像を置き換える
- 画像コレクション
- ピクチャーフレーム
- リンク画像
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- SVG をシェイプに変換
- 外部 SVG リソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションで、ラスタ画像と SVG 画像の追加、再利用、リンク、置換、管理方法を学びます。"
---
## **はじめに**

Aspose.Slides for Android via Java は画像を操作するためのさまざまな方法を提供し、各方法は異なる目的に使用されます。画像をプレゼンテーションに保存したり、ピクチャーフレームに表示したり、スライドの背景として使用したり、外部画像へのリンクを設定したり、共有画像リソースを置き換えたり、SVG コンテンツを編集可能なシェイプに変換したりできます。

本稿では画像リソースとプレゼンテーション全体での使用方法に焦点を当てます。個々のピクチャーフレームに適用されるトリミング、透過、効果、ストレッチ、その他の書式設定については、[ピクチャーフレーム](/slides/ja/androidjava/picture-frame/)をご参照ください。

## **イメージモデルを理解する**

以下の API 概念は密接に関連していますが、相互に置き換えることはできません。

- [プレゼンテーション画像コレクション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagecollection/) はプレゼンテーションで使用される画像リソースを格納します。[ImageCollection.addImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imagecollection/) を使用して画像データを追加し、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) リソースを取得します。
- [ピクチャーフレーム](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) は、スライド、レイアウト、またはマスター上に画像を表示するシェイプです。[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/) を使用して画像リソースをスライドに配置します。
- スライドの背景は画像をシェイプではなくスライドの塗りつぶしの一部として使用します。そのため、ピクチャーフレームのように振る舞いません。
- [IPPImage.replaceImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) は画像リソースを置き換えます。そのリソースを使用している複数のプレゼンテーション要素はすべて置換後のリソースを使用します。
- SVG をシェイプに変換すると、編集可能なスライドシェイプが生成されます。変換後は、コンテンツは単一の画像リソースとして管理されなくなります。

したがって、典型的なワークフローは次のとおりです。画像データを画像コレクションに追加し、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) を取得し、そのリソースを 1 つまたは複数のピクチャーフレームや塗りつぶしで使用します。

## **埋め込み画像の追加**

ローカル画像を挿入するには、ファイルを読み込み、画像コレクションに追加し、返された `IPPImage` を使用するピクチャーフレームを作成します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この方法で追加された画像はプレゼンテーションに埋め込まれるため、結果として得られるファイルは元の画像ファイルが利用可能であることに依存しません。

### **Web から画像を追加する**

画像が HTTP または HTTPS 経由で利用できる場合、そのバイト列をダウンロードし、プレゼンテーションの画像コレクションに追加し、返された画像リソースをローカル画像と同様に使用します。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

長時間実行するアプリケーションでは、不必要にネットワークインフラを繰り返し作成するのではなく、アプリケーションに適した HTTP クライアントや接続管理戦略を再利用してください。また、ソースが信頼できない場合は、リモート URL、レスポンスサイズ、コンテンツタイプを検証してください。

## **スライド間で画像を再利用する**

同じ画像が複数回必要な場合、プレゼンテーションに一度だけ追加し、返された [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) を再利用して追加のピクチャーフレームを作成します。これにより、同じソースデータの読み込みが繰り返されるのを防ぎ、共有画像リソースとその使用先の関係が明示的になります。

企業ロゴなど、多くのスライドに自動的に表示すべきグラフィックについては、各スライドに同等のシェイプを追加する代わりに、[スライドマスター](/slides/ja/androidjava/slide-master/) またはレイアウトにピクチャーフレームを配置することを検討してください。

## **画像をスライドの背景として使用する**

背景画像はスライドの塗りつぶしとして割り当てられ、ピクチャーフレームのシェイプとして追加されません。画像がスライド全体の背景を覆い、通常のスライドオブジェクトとして操作されないようにしたい場合に便利です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

マスターやレイアウトの背景を含む追加の背景オプションについては、[プレゼンテーションの背景](/slides/ja/androidjava/presentation-background/)をご参照ください。

## **埋め込み画像とリンク画像**

埋め込み画像とリンク画像は、移植性とファイルサイズに異なるトレードオフがあります。

- **埋め込み画像:** 画像データがプレゼンテーション内部に保存されます。プレゼンテーションは自己完結型ですが、ファイルサイズには画像データが含まれます。
- **リンク画像:** プレゼンテーションは外部画像へのパスまたは URL を保存します。これによりプレゼンテーションのサイズは縮小できますが、開くまたはレンダリングする際に外部リソースにアクセス可能である必要があります。

リンク画像は、画像データを埋め込む代わりに、[ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidespicture/) を使用して外部パスまたは URL を割り当てることで作成できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

外部リソースに確実にアクセスできるデプロイ環境の場合のみリンク画像を使用してください。オフラインで動作させる必要がある、またはシステム間で移動させるプレゼンテーションでは、埋め込み画像の方が安全です。

## **SVG 画像の操作**

SVG はベクター形式であるため、アイコン、図、その他ラスター画像と同様の詳細損失なしに拡大縮小できるグラフィックに役立ちます。Aspose.Slides は SVG を画像リソースとして、また編集可能なスライドシェイプのソースとしてサポートします。

### **SVG を画像として追加する**

[SvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/svgimage/) を作成し、画像コレクションに追加し、得られた画像リソースをピクチャーフレームに配置します。

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **外部リソースを含む SVG ファイル**

SVG は外部画像、スタイルシート、フォントを参照できる場合があります。そのようなケースでは、[SvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/svgimage/) は [IExternalResourceResolver](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iexternalresourceresolver/) とベース URI を受け取るコンストラクタを提供します。リゾルバは相対 URI を許可された絶対 URI にマッピングし、要求されたリソースのストリームを返すことができます。

リゾルバは Aspose.Slides が SVG を処理する間に外部リソースを利用可能にしますが、SVG を自己完結ドキュメントに書き換えることはしません。SVG をポータブルに保つ必要がある場合は、たとえばリンク画像に `data:` URI を使用して、必要なリソースを SVG 自体に埋め込んでください。

信頼できないソースからの SVG ファイルの場合、リゾルバがアクセスできるスキーム、ファイル位置、ホストを制限してください。ネットワークリゾルバはタイムアウト、レスポンスサイズ制限、コンテンツ検証も適用すべきです。

### **SVG を編集可能なシェイプに変換する**

Aspose.Slides は SVG を編集可能なスライドシェイプのグループに変換できます。これは対応する PowerPoint のコマンドと同様です。

![PowerPoint ポップアップメニュー](img_01_01.png)

変換を実行するには、[ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/) を受け取る [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/) のオーバーロードを使用します。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

個々のベクター要素を PowerPoint のシェイプとして編集する必要がある場合に SVG → シェイプ変換を使用してください。SVG を表示するだけでよい場合は、画像として保持する方がシンプルで、複数のシェイプを作成する手間が省けます。

## **既存の画像リソースを置き換える**

既存の画像リソースを置き換える場合は、[IPPImage.replaceImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) を使用してください。ロゴなどの共有グラフィックに特に便利です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

複数のピクチャーフレーム、背景、マスター、レイアウトが同じ画像リソースを使用している場合、そのリソースを置き換えるとすべての使用箇所が更新されます。1 つのピクチャーフレームだけを変更したい場合は、共有リソースを置き換えるのではなく、そのフレームに別の画像を割り当ててください。

`replaceImage` には、バイト配列または別の [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) を受け取るオーバーロードも用意されています。

## **実践的な画像管理ガイダンス**

### **プレゼンテーションサイズの管理**

大きなラスター画像はプレゼンテーションを不必要に大きくする可能性があります。表示サイズに適した寸法の元画像を使用し、可能な限り共有画像リソースを再利用し、同一のフル解像度グラフィックの重複埋め込みを避けてください。

ピクチャーフレームにすでに配置されたラスター画像については、[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/) を使用して、選択された解像度やトリミング設定に基づき画像データを縮小できます。これは画像コレクション管理ではなくピクチャーフレームの処理であるため、関連する書式設定操作については [ピクチャーフレーム](/slides/ja/androidjava/picture-frame/) を参照してください。

### **埋め込みコンテンツとリンクコンテンツの選択**

埋め込みは、必要な画像データがすべてファイルに含まれるため、プレゼンテーションのポータビリティを高めます。リンクはファイルサイズを削減できますが、外部依存性が生じます。依存性が許容でき、かつ安定している場合にのみリンクを使用してください。

### **共有ブランディングの再利用**

ロゴ、透かし、装飾グラフィックを繰り返し使用する場合は、1 つの画像リソースを使用して再利用してください。グラフィックがスライドコンテンツではなくプレゼンテーションデザインに属する場合は、マスターまたはレイアウトに配置し、該当スライドに継承させます。

### **SVG リソースをポータブルに保つ**

自己完結型の SVG は、外部ファイルやネットワークリソースに依存する SVG よりも移動や一貫したレンダリングが容易です。可能な限り、SVG をインポートする前に必要なリソースを埋め込んでください。個々のベクター要素を編集する必要がある場合にのみ、SVG をシェイプに変換してください。

### **最新のクロスプラットフォーム画像 API を使用する**

新しい Android via Java のコードでは、従来の `android.graphics.Bitmap` ベースのパブリック API の代わりに、Aspose.Slides の [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) と [Images](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/images/) API を使用してください。移行ガイダンスについては、[Modern API](/slides/ja/androidjava/modern-api/) を参照してください。

WMF と EMF は特別な考慮が必要です。これらの形式が [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) を介して渡されると、[ImageCollection.addImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imagecollection/) はメタファイルをラスタ PNG 表現に変換して挿入します。メタファイルデータを保持することが重要な場合は、ストリームベースの [ImageCollection.addImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imagecollection/) オーバーロードを使用してください。スプレッドシートや他の製品から EMF コンテンツを生成することは別の統合ワークフローであり、本稿の対象外です。

## **FAQ**

**画像コレクションとピクチャーフレームの違いは何ですか？**

画像コレクションは再利用可能な画像リソースを格納します。ピクチャーフレームは、そのリソースの 1 つを表示し、トリミングや効果などのピクチャー固有の書式設定を提供するスライドシェイプです。

**同じロゴをすべて置き換える最適な方法は何ですか？**

ロゴがすでに 1 つの画像リソースとして共有されている場合は、[IPPImage.replaceImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) でそのリソースを置き換えてください。プレゼンテーション全体のブランディングの場合は、ロゴをマスターやレイアウトに配置することでも重複したスライドコンテンツを削減できます。

**リンク画像が別のコンピュータで消えるのはなぜですか？**

リンク画像は外部ファイルまたは URL に依存します。そのリソースが別のコンピュータから到達できないと、リンク画像は利用できなくなります。プレゼンテーションを自己完結させる必要がある場合は、画像を埋め込んでください。

**挿入した SVG を PowerPoint のシェイプとして編集できますか？**

はい。SVG は [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/) を使用して変換できます。変換後のグループは 1 つの SVG ピクチャーではなく、編集可能なスライドシェイプを含みます。

**大量の画像を含むプレゼンテーションを小さく保つにはどうすればよいですか？**

共有画像リソースを再利用し、不要に大きなラスター画像を使用しないようにし、適切な場合はラスター画像を圧縮し、繰り返し使用するロゴや装飾はマスターやレイアウトに配置し、外部依存が許容できる場合にのみリンク画像を使用してください。