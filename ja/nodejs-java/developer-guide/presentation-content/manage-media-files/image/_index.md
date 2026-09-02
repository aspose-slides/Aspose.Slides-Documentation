---
title: JavaScript を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/nodejs-java/image/
keywords:
- 画像を追加
- 画像を挿入
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーションでラスタ画像と SVG 画像を追加、再利用、リンク、置き換え、管理する方法を学びます。"
---
## **はじめに**

Aspose.Slides for Node.js via Java は画像を扱ういくつかの方法を提供し、各方法は異なる目的に使用されます。画像をプレゼンテーションに保存したり、ピクチャーフレームに表示したり、スライドの背景として使用したり、外部画像へのリンクを設定したり、共有画像リソースを置き換えたり、SVG コンテンツを編集可能なシェイプに変換したりできます。

本記事では画像リソースとそれがプレゼンテーション全体でどのように使用されるかに焦点を当てます。個々のピクチャーフレームに適用されるクロッピング、透明度、エフェクト、伸縮、およびその他の書式設定については、[Picture Frame](/slides/ja/nodejs-java/picture-frame/) を参照してください。

## **画像モデルの理解**

以下の API 概念は密接に関連していますが、相互に置き換えることはできません。

- [presentation image collection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagecollection/) は、プレゼンテーションで使用される画像リソースを格納します。画像データを追加し、[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) リソースを取得するには、[ImageCollection.addImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagecollection/) を使用します。
- [picture frame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) は、スライド、レイアウト、またはマスター上で画像を表示するシェイプです。画像リソースをスライドに配置するには、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/) を使用します。
- スライドの背景は、シェイプではなくスライドの塗りつぶしの一部として画像を使用します。そのため、ピクチャーフレームのように動作しません。
- [PPImage.replaceImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) は画像リソースを置き換えます。そのリソースを複数のプレゼンテーション要素が使用している場合、すべてが置換後のリソースを使用します。
- SVG をシェイプに変換すると、編集可能なスライドシェイプが作成されます。変換後は、コンテンツは単一の画像リソースとしては管理されません。

典型的なワークフローは次のとおりです。画像データを画像コレクションに追加し、[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) を取得し、そのリソースを1つ以上のピクチャーフレームまたは塗りつぶしで使用します。

## **埋め込み画像の追加**

ローカル画像を挿入するには、ファイルを読み込み、画像コレクションに追加し、返された [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) リソースを使用するピクチャーフレームを作成します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この方法で追加された画像はプレゼンテーションに埋め込まれるため、結果として得られるファイルは元の画像ファイルが利用可能であることに依存しません。

### **Web から画像を追加**

画像が HTTP または HTTPS で取得できる場合、バイトデータをダウンロードし、プレゼンテーションの画像コレクションに追加し、返された画像リソースをローカル画像と同様に使用します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

長時間実行されるアプリケーションでは、不要なネットワークインフラを繰り返し作成するのではなく、アプリケーションに適した HTTP クライアントや接続管理戦略を再利用してください。また、ソースが信頼できない場合は、リモート URL、レスポンスサイズ、コンテンツタイプを検証してください。

## **スライド間で画像を再利用**

同じ画像が複数回必要な場合、プレゼンテーションに1回だけ追加し、追加のピクチャーフレームを作成する際に返された [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) を再利用します。これにより同一のソースデータの読み込みを繰り返すことを防ぎ、共有画像リソースとその使用箇所の関係が明示的になります。

会社ロゴなど、多くのスライドに自動的に表示すべきグラフィックについては、各スライドに同等のシェイプを追加する代わりに、[slide master](/slides/ja/nodejs-java/slide-master/) またはレイアウトにピクチャーフレームを配置することを検討してください。

## **画像をスライドの背景として使用**

背景画像はスライドの塗りつぶしに割り当てられ、ピクチャーフレームのシェイプとして追加されません。画像がスライド全体を覆い、通常のスライドオブジェクトとして操作されない方が適切な場合に便利です。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

マスターやレイアウトの背景を含むその他の背景オプションについては、[Presentation Background](/slides/ja/nodejs-java/presentation-background/) を参照してください。

## **埋め込み画像とリンク画像**

埋め込み画像とリンク画像は、ポータビリティとファイルサイズに関して異なるトレードオフがあります：

- **埋め込み画像:** 画像データがプレゼンテーション内部に保存されます。プレゼンテーションは自己完結型ですが、ファイルサイズには画像データが含まれます。
- **リンク画像:** プレゼンテーションは外部画像へのパスまたは URL を保存します。これによりプレゼンテーションのサイズを削減できますが、開くまたはレンダリングする際に外部リソースがアクセス可能である必要があります。

リンク画像は、画像データを埋め込む代わりに、[Picture.setLinkPathLong](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/) を使用して外部パスまたは URL を割り当てることで作成できます。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

リンク画像は、デプロイ環境が外部リソースに確実にアクセスできる場合にのみ使用してください。オフラインで動作させる必要がある、またはシステム間で移動させるプレゼンテーションでは、埋め込み画像の方が通常は安全です。

## **SVG 画像の操作**

SVG はベクターフォーマットであるため、アイコン、図、その他ラスタ画像と同様のディテール損失なく拡大縮小できるグラフィックに便利です。Aspose.Slides は SVG を画像リソースとして、また編集可能なスライドシェイプのソースとしてサポートします。

### **SVG を画像として追加**

[SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) を作成し、画像コレクションに追加し、得られた画像リソースをピクチャーフレームに配置します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **外部リソースを持つ SVG ファイル**

SVG は外部画像、スタイルシート、フォントを参照できます。このような場合、[SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) は [ExternalResourceResolver](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/externalresourceresolver/) とベース URI を受け取るコンストラクタを提供します。リゾルバは相対 URI を許可された絶対 URI にマッピングし、要求されたリソースのストリームを返すことができます。

リゾルバは Aspose.Slides が SVG を処理する間、外部リソースを利用可能にしますが、SVG を自己完結型ドキュメントに書き換えることはしません。SVG をポータブルに保つ必要がある場合は、必要なリソースを SVG 内に埋め込んでください。たとえば、リンク画像に `data:` URI を使用する方法があります。

SVG ファイルが信頼できないソースから来る場合、リゾルバがアクセスできるスキーム、ファイル位置、ホストを制限してください。ネットワークリゾルバはタイムアウト、レスポンスサイズ制限、コンテンツの検証も適用すべきです。

### **SVG を編集可能なシェイプに変換**

Aspose.Slides は SVG を PowerPoint の対応コマンドと同様に、編集可能なスライドシェイプのグループに変換できます。

![PowerPoint Popup Menu](img_01_01.png)

SVG 画像を受け取るオーバーロードの [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/) を使用して変換を実行します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

個々のベクトル要素を PowerPoint のシェイプとして編集する必要がある場合に、SVG からシェイプへの変換を使用してください。SVG を表示するだけでよい場合は、画像として保持した方がシンプルで、多数の個別シェイプの生成を回避できます。

## **既存の画像リソースを置き換える**

既存の画像リソースを置き換える場合は、[PPImage.replaceImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) を使用してください。特にロゴなどの共有グラフィックに有用です。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

複数のピクチャーフレーム、背景、マスター、またはレイアウトが同じ画像リソースを使用している場合、そのリソースを置き換えるとすべての使用箇所が更新されます。1つのピクチャーフレームだけを変更したい場合は、共有リソースを置き換えるのではなく、そのフレームに別の画像を割り当ててください。

[PPImage.replaceImage] は、バイト配列または別の [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) を受け取るオーバーロードも提供しています。

## **実践的な画像管理のガイダンス**

### **プレゼンテーションサイズの管理**

大きなラスタ画像はプレゼンテーションを不必要に大きくします。表示サイズに適した寸法のソース画像を使用し、可能な限り共有画像リソースを再利用し、同じフル解像度グラフィックの重複埋め込みを避けてください。

すでにピクチャーフレームに配置されたラスタ画像については、[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/) を使用して、選択された解像度やトリミング設定に基づき画像データを圧縮できます。これは画像コレクションの管理ではなくピクチャーフレームの処理なので、関連する書式設定操作については [Picture Frame](/slides/ja/nodejs-java/picture-frame/) を参照してください。

### **埋め込みコンテンツとリンクコンテンツの選択**

埋め込みは、必要な画像データがファイルに同梱されるため、プレゼンテーションをポータブルにします。リンクはファイルサイズを削減できますが、外部依存関係が発生します。依存関係が許容でき、安定している場合にのみリンクを使用してください。

### **共有ブランディングの再利用**

繰り返し使用されるロゴ、透かし、装飾グラフィックには、1つの画像リソースを使用して再利用してください。グラフィックがスライドコンテンツではなくプレゼンテーションデザインに属する場合は、マスターまたはレイアウトに配置し、対象スライドに継承させます。

### **SVG リソースをポータブルに保つ**

自己完結型の SVG は、外部ファイルやネットワークリソースに依存する SVG よりも移動や一貫したレンダリングが容易です。可能な限り、SVG をインポートする前に必要なリソースを埋め込んでください。個々のベクトル要素を編集する必要がある場合にのみ、SVG をシェイプに変換してください。

### **モダンなクロスプラットフォーム画像 API を使用**

新しい Node.js via Java のコードでは、従来の `java.awt.image.BufferedImage` ベースのパブリック API の代わりに、Aspose.Slides の [IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) と [Images](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/images/) API を使用してください。移行ガイドについては、[Modern API](/slides/ja/nodejs-java/modern-api/) を参照してください。

WMF と EMF は特別な考慮が必要です。これらの形式が [IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) を介して渡されると、[ImageCollection.addImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagecollection/) がメタファイルをラスタ PNG 表現に変換して挿入します。メタファイルデータを保持することが重要な場合は、ストリームベースの [ImageCollection.addImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagecollection/) オーバーロードを使用してください。スプレッドシートや他の製品から EMF コンテンツを生成することは別の統合ワークフローであり、本記事の範囲外です。

## **FAQ**

**画像コレクションとピクチャーフレームの違いは何ですか？**

画像コレクションは再利用可能な画像リソースを格納します。ピクチャーフレームは、これらのリソースの1つを表示し、クロッピングやエフェクトなど画像固有の書式設定を提供するスライドシェイプです。

**同じロゴをすべての場所で置き換える最適な方法は何ですか？**

ロゴがすでに1つの画像リソースとして共有されている場合は、[PPImage.replaceImage] でそのリソースを置き換えてください。プレゼンテーション全体のブランディングの場合、マスターまたはレイアウトにロゴを配置することで、スライド内容の重複を減らすこともできます。

**別のコンピュータでリンク画像が消えるのはなぜですか？**

リンク画像は外部ファイルまたは URL に依存しています。そのリソースが別のコンピュータからアクセスできない場合、リンク画像は利用できなくなることがあります。プレゼンテーションを自己完結させる必要がある場合は、画像を埋め込んでください。

**挿入した SVG を PowerPoint のシェイプとして編集できますか？**

はい。[ShapeCollection.addGroupShape] で SVG を変換できます。結果として得られるグループは、単一の SVG 画像ではなく、編集可能なスライドシェイプを含みます。

**多数の画像を含むプレゼンテーションを小さく保つにはどうすればよいですか？**

共有画像リソースを再利用し、不要に大きなラスタソースを避け、適切な場合はラスタ画像を圧縮し、繰り返し使用するブランディングはマスターやレイアウトに保持し、外部依存が許容できる場合にのみリンク画像を使用してください。