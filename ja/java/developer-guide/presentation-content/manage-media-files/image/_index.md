---
title: Java を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/java/image/
keywords:
- 画像を追加
- 画像を挿入
- 画像を置換
- 画像コレクション
- 図形フレーム
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションで、ラスター画像と SVG 画像の追加、再利用、リンク、置換、管理方法を学びます。"
---
## **はじめに**

Aspose.Slides for Java は画像を操作するためのさまざまな方法を提供しており、目的に応じて使い分けられます。画像をプレゼンテーションに格納したり、図形フレームに表示したり、スライドの背景として使用したり、外部画像へのリンクを作成したり、共有画像リソースを置き換えたり、SVG コンテンツを編集可能なシェイプに変換したりできます。

この記事では画像リソースとプレゼンテーション全体での使用方法に焦点を当てます。個別の図形フレームに適用されるトリミング、透明度、効果、伸縮、その他の書式設定については、[Picture Frame](/slides/ja/java/picture-frame/) を参照してください。

## **画像モデルの理解**

- The [presentation image collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iimagecollection/) はプレゼンテーションで使用される画像リソースを格納します。画像データを追加し、[IPPImage] リソースを取得するには、[ImageCollection.addImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imagecollection/) を使用します。
- A [picture frame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ipictureframe/) はスライド、レイアウト、またはマスタ上で画像を表示するシェイプです。画像リソースをスライドに配置するには、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ishapecollection/) を使用します。
- スライドの背景は画像をシェイプとしてではなくスライドの塗りつぶしの一部として使用します。そのため、図形フレームのように振る舞いません。
- [IPPImage.replaceImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/) は画像リソースを置換します。そのリソースを使用している複数のプレゼンテーション要素はすべて置換後の画像を使用します。
- SVG をシェイプに変換すると、編集可能なスライドシェイプが作成されます。変換後はコンテンツは単一の画像リソースとして管理されなくなります。

典型的なワークフローは次のとおりです。画像データを画像コレクションに追加し、[IPPImage] を取得してから、そのリソースを 1 つ以上の図形フレームや塗りつぶしで使用します。

## **埋め込み画像の追加**

ローカル画像を挿入するには、ファイルを読み込み、画像コレクションに追加し、返された `IPPImage` を使用する図形フレームを作成します。

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

この方法で追加された画像はプレゼンテーションに埋め込まれるため、結果として得られるファイルは元の画像ファイルが利用可能であるかどうかに依存しません。

### **ウェブから画像を追加**

画像が HTTP または HTTPS 経由で利用可能な場合、そのバイト列をダウンロードし、プレゼンテーションの画像コレクションに追加し、返された画像リソースをローカル画像と同様に使用します。

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

長期間実行されるアプリケーションでは、不要なネットワークインフラを繰り返し作成しないよう、適切な HTTP クライアントまたは接続管理戦略を再利用してください。また、ソースが信頼できない場合はリモート URL、レスポンスサイズ、コンテンツタイプを検証してください。

## **スライド間で画像を再利用**

同じ画像が複数回必要な場合は、プレゼンテーションに 1 回だけ追加し、追加の図形フレームを作成する際に取得した [IPPImage] を再利用します。これにより同一ソースデータの重複読み込みを回避でき、共有画像リソースとその使用箇所との関係が明示的になります。

企業ロゴなど、多くのスライドに自動的に表示させたいグラフィックは、各スライドに同等のシェイプを追加するのではなく、[slide master](/slides/ja/java/slide-master/) やレイアウト上に図形フレームを配置することを検討してください。

## **画像をスライドの背景として使用**

背景画像はスライドの塗りつぶしに割り当てられ、図形フレームとして追加されません。画像がスライド全体の背景を覆い、通常のスライドオブジェクトとして操作されないようにしたい場合に便利です。

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

マスタやレイアウトの背景を含む追加の背景オプションについては、[Presentation Background](/slides/ja/java/presentation-background/) を参照してください。

## **埋め込み画像とリンク画像**

埋め込み画像とリンク画像は、可搬性とファイルサイズに関して異なるトレードオフがあります。

- **埋め込み画像:** 画像データがプレゼンテーション内部に保存されます。プレゼンテーションは単体で完結しますが、ファイルサイズに画像データが含まれます。
- **リンク画像:** プレゼンテーションは外部画像へのパスまたは URL を保持します。これによりプレゼンテーションのサイズは削減できますが、表示またはレンダリング時に外部リソースがアクセス可能である必要があります。

リンク画像は、画像データを埋め込むのではなく、[ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ja/java/com.aspose.slides.islidespicture/) を通じて外部パスや URL を設定することで作成できます。

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

外部リソースへの確実なアクセスが保証できる展開環境でのみリンク画像を使用してください。オフラインでの利用やシステム間の移動が必要なプレゼンテーションでは、埋め込み画像の方が安全です。

## **SVG画像の操作**

SVG はベクターフォーマットであり、アイコンや図表、ラスタ画像と比べて詳細を失わずに拡大縮小できるため便利です。Aspose.Slides は SVG を画像リソースとしてだけでなく、編集可能なスライドシェイプのソースとしてもサポートします。

### **SVGを画像として追加**

[SvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.svgimage/) を作成し、画像コレクションに追加して、得られた画像リソースを図形フレームに配置します。

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

### **外部リソースを持つSVGファイル**

SVG は外部画像、スタイルシート、フォントを参照できることがあります。このような場合、[SvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.svgimage/) は [IExternalResourceResolver](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iexternalresourceresolver/) とベース URI を受け取るコンストラクタを提供します。リゾルバは相対 URI を許可された絶対 URI にマッピングし、要求されたリソースのストリームを返します。

リゾルバは SVG 処理中に外部リソースへのアクセスを可能にしますが、SVG を自己完結型ドキュメントに書き換えることはありません。SVG を可搬性のまま保ちたい場合は、例えばリンク画像に `data:` URI を使用して必要なリソースを SVG 自体に埋め込んでください。

信頼できないソースから取得した SVG ファイルの場合、リゾルバがアクセスできるスキーム、ファイル位置、ホストを制限してください。ネットワークリゾルバにはタイムアウト、レスポンスサイズ上限、コンテンツ検証も適用すべきです。

### **SVGを編集可能なシェイプに変換**

Aspose.Slides は SVG を編集可能なスライドシェイプのグループに変換でき、PowerPoint の対応コマンドに似ています。

![PowerPoint Popup Menu](img_01_01.png)

変換を実行するには、[IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ishapecollection/) のオーバーロードで [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.isvgimage/) を受け取るものを使用します。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

個々のベクトル要素を PowerPoint シェイプとして編集する必要がある場合に SVG からシェイプへの変換を使用してください。単に表示するだけであれば、画像として保持する方がシンプルで多数のシェイプ生成を回避できます。

## **既存の画像リソースを置換**

既存の画像リソースを置き換えるには、[IPPImage.replaceImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/) を使用します。ロゴなど共有グラフィックの置換に特に有用です。

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

同一リソースを使用している複数の図形フレーム、背景、マスタ、レイアウトがある場合、リソースを置換するとそれらすべてが更新されます。1 つの図形フレームだけを変更したい場合は、共有リソースを置換せずにそのフレームに別の画像を割り当ててください。

`replaceImage` にはバイト配列や別の [IPPImage] を受け取るオーバーロードも用意されています。

## **実践的な画像管理のガイダンス**

### **プレゼンテーションサイズの管理**

大きなラスタ画像はプレゼンテーションを不要に肥大化させます。表示サイズに見合った寸法のソース画像を使用し、可能な限り共有画像リソースを再利用し、同一のフル解像度画像を埋め込むことを避けてください。

すでに図形フレームに配置されたラスタ画像については、[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ipicturefillformat/) を使用して、選択された解像度やトリミング設定に基づき画像データを圧縮できます。これは画像コレクションの管理ではなく図形フレームの処理なので、関連する書式設定操作は [Picture Frame](/slides/ja/java/picture-frame/) を参照してください。

### **埋め込みとリンクコンテンツの選択**

埋め込みはすべての画像データがファイルに同梱されるため、プレゼンテーションの可搬性が高まります。リンクはファイルサイズを削減できますが、外部依存が生じます。外部依存が許容でき、かつ安定している場合にのみリンクを使用してください。

### **共有ブランディングの再利用**

ロゴや透かし、装飾グラフィックなど繰り返し使用する画像は 1 つの画像リソースにまとめて再利用します。スライドコンテンツではなくデザイン要素である場合は、マスタまたはレイアウトに配置して該当スライドに継承させてください。

### **SVGリソースをポータブルに保つ**

自己完結型 SVG は外部ファイルやネットワークリソースに依存する SVG よりも移動やレンダリングが容易です。可能な限り、インポート前に必要なリソースを埋め込んでください。個々のベクトル要素の編集が必要なときだけ、SVG をシェイプに変換します。

### **最新のクロスプラットフォーム画像APIを使用**

新規 Java コードでは、レガシーの `java.awt.image.BufferedImage` ベースのパブリック API の代わりに、Aspose.Slides の [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iimage/) および [Images](https://reference.aspose.com/slides/ja/java/com.aspose.slides.images/) API を使用してください。移行ガイダンスは [Modern API](/slides/ja/java/modern-api/) を参照してください。

WMF および EMF は特別な考慮が必要です。これらの形式が [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iimage/) に渡されると、[ImageCollection.addImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.imagecollection/) はメタファイルをラスタ PNG に変換して挿入します。メタファイルデータを保持したい場合は、ストリームベースの [ImageCollection.addImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.imagecollection/) オーバーロードを使用してください。スプレッドシートなど他製品から EMF コンテンツを生成する場合は別途統合ワークフローが必要であり、本記事の範囲外です。

## **FAQ**

**画像コレクションと図形フレームの違いは何ですか？**

画像コレクションは再利用可能な画像リソースを格納します。図形フレームはそのリソースのうちの 1 つを表示し、トリミングや効果など画像固有の書式設定を提供するスライドシェイプです。

**ロゴをすべての場所で置き換える最良の方法は何ですか？**

ロゴが 1 つの画像リソースとして共有されている場合は、[IPPImage.replaceImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/) でそのリソースを置換します。プレゼンテーション全体のブランディングとしてロゴを配置する場合は、マスタやレイアウト上に置くことでスライドごとの重複を削減できます。

**リンク画像が別のコンピュータで消えるのはなぜですか？**

リンク画像は外部ファイルまたは URL に依存しています。そのリソースに他のコンピュータからアクセスできない場合、リンク画像は表示されません。プレゼンテーションを自己完結させる必要がある場合は、画像を埋め込んでください。

**挿入した SVG を PowerPoint のシェイプとして編集できますか？**

はい。SVG を [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ishapecollection/) で変換すると、結果のグループは 1 つの SVG 画像ではなく編集可能なスライドシェイプを含みます。

**画像が多数あるプレゼンテーションを小さく保つにはどうすればよいですか？**

共有画像リソースを再利用し、不必要に大きなラスタソースを避け、適切な場合はラスタ画像を圧縮し、繰り返し使用するブランディングはマスタやレイアウトに配置し、外部依存が許容できる場合にのみリンク画像を使用してください。