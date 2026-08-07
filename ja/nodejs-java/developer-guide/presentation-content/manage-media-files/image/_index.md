---
title: JavaScript を使用したプレゼンテーションにおける画像管理の最適化
linktitle: 画像管理
type: docs
weight: 10
url: /ja/nodejs-java/image/
keywords:
- 画像を追加
- 画像を追加
- ビットマップを追加
- 画像を置換
- 画像を置換
- Web から
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- 外部 SVG リソース
- SVG リゾルバ
- リンクされた SVG 画像
- SVG フォント
- EMF を追加
- WMF を追加
- TIFF を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Java 経由の Node.js 用 Aspose.Slides を使用して、PowerPoint と OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---
## **紹介**

画像はプレゼンテーションをより魅力的で視覚的に訴えるものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他のソースからスライドに画像を挿入できます。同様に、Aspose.Slides でも画像をプレゼンテーションのスライドに追加する方法がいくつか用意されています。

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータ―、[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) を提供しており、画像からすばやくプレゼンテーションを作成できます。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

画像をピクチャーフレームとして追加したい場合（特にサイズ変更、効果の適用、その他標準の書式設定オプションを使用する予定がある場合）は、[Picture Frame](/slides/ja/nodejs-java/picture-frame/) を参照してください。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

画像を別の形式に変換できます。以下のページをご覧ください: 変換 [image to JPG](https://products.aspose.com/slides/ja/nodejs-java/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/ja/nodejs-java/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/ja/nodejs-java/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/ja/nodejs-java/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/ja/nodejs-java/conversion/png-to-svg/)、および [SVG to PNG](https://products.aspose.com/slides/ja/nodejs-java/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides は JPEG、PNG、BMP、GIF などの一般的な形式の画像をサポートしています。 

## **ローカルに保存された画像をスライドに追加する**

コンピューターに保存されている 1 つ以上の画像をプレゼンテーションのスライドに追加できます。以下の JavaScript サンプルコードは、スライドに画像を追加する方法を示しています。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Web から画像をスライドに追加する**

スライドに追加したい画像がコンピューターに保存されていない場合、Web から直接追加できます。 

以下の JavaScript サンプルコードは、Web から画像をスライドに追加する方法を示しています。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **スライドマスターに画像を追加する**

スライドマスターは、テーマやレイアウトなど、マスターを使用するスライドの情報を保持および制御します。スライドマスターに画像を追加すると、そのマスターに基づくすべてのスライドに画像が表示されます。 

以下の JavaScript サンプルコードは、スライドマスターに画像を追加する方法を示しています。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **画像をスライドの背景として追加する**

1 つまたは複数のスライドの背景として画像を使用できます。詳細は *[Setting Images as Backgrounds for Slides](/slides/ja/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **SVG をプレゼンテーションに追加する**

SVG コンテンツは、[SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) クラスを使用してプレゼンテーションに追加できます。生成された SVG 画像オブジェクトは、プレゼンテーションの画像コレクションに追加され、ピクチャーフレームを作成するために使用できます。

以下の JavaScript の例は、自己完結型 SVG 文字列をインポートします。この SVG で使用されるすべての画像、スタイル、その他のリソースは SVG コンテンツに直接埋め込まれています。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **外部リソースを含む SVG コンテンツのインポート**

デザインツール、ダイアグラムエディタ、アイコンシステム、Web パイプラインからエクスポートされた SVG ファイルは、SVG ドキュメントの外部に保存されたリソースを参照することがあります。たとえば、SVG に `images/photo.png` のような画像リンク、CSS の `url(...)` 値、またはフォント URL が含まれることがあります。

このような SVG コンテンツをインポートするには、外部リソースリゾルバを提供し、ベース URI とともに適切な [SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) コンストラクタに渡します。ベース URI は SVG ドキュメントの場所を識別し、相対リンクの解決に使用されます。

`SvgImage` クラスはインポートされた SVG に関する情報へのアクセスを提供します。

- `getSvgContent()` は SVG のマークアップを文字列として返します。
- `getSvgData()` は SVG コンテンツをバイト配列として返します。
- `getBaseUri()` は相対リンクに使用されたベース URI を返します。
- `getExternalResourceResolver()` は SVG 画像に割り当てられたリゾルバを返します。

### **外部リソースリゾルバを実装する**

リゾルバには 2 つのメソッドがあります。

- `resolveUri` はベース URI と相対リソースリンクを結合し、絶対 URI を返します。リンクを解決できない、または許可されていない場合は `null` を返します。
- `getEntity` は絶対リソース URI に対する読み取り可能な Java ストリームを返します。リソースが存在しない、ブロックされている、または利用できない場合は `null` を返します。必要に応じてフォールバックストリームを返すこともできます。

以下のヘルパーは、許可されたローカルディレクトリからのみリンクされたリソースをロードするリゾルバを作成します。ネットワークリソースや許可ディレクトリ外のパスはブロックされ、解決できない画像リンクに対してはオプションのフォールバック画像が返されます。

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // このリゾルバは意図的にローカルファイルのみを許可します。
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // 画像リソースに対してのみフォールバックを使用します。欠落したフォントやスタイルシートに対して画像ストリームを返すことは無効です。
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **SVG インポート時にリンクされたリソースを解決する**

`assets/diagram.svg` が次のような相対参照を含んでいるとします。

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下の JavaScript の例は、SVG ファイルの URI をベース URI として渡し、カスタムリゾルバを提供します。リゾルバは相対画像リンクを絶対 URI に変換し、リンクされたリソースを含むストリームを返しながら Aspose.Slides が SVG を処理します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// ベース URI は SVG ドキュメントの場所を表します。
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage はソースコンテンツ、バイナリ データ、ベース URI、そしてリゾルバを公開します。
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` クラスは、バイト配列として SVG データを受け取るオーバーロードや、ストリームベースのファクトリーメソッド、外部リソースリゾルバとベース URI を組み合わせたものも提供しています。

{{% alert title="Important" color="warning" %}}

リソースリゾルバは、Aspose.Slides が SVG を処理およびレンダリングする間に外部リソースを利用可能にしますが、元の SVG マークアップを変更したり、解決されたリソースを自動的に埋め込んだりはしません。

SVG 画像がプレゼンテーションの画像コレクションに追加されると、PPTX ファイルは元の SVG 表現とラスター形式のフォールバック画像の両方を保持できます。リンクされたリソースは生成されたフォールバック画像に現れることがありますが、`images/photo.png` のような相対リンクは保存された SVG 内では変更されません。ネイティブ SVG 表現をレンダリングするアプリケーションは、元の外部リソースが利用できない場合にリンクされたコンテンツを省略する可能性があります。

{{% /alert %}}

### **ポータブルな SVG ピクチャーを作成する**

外部ファイルに依存しない SVG ピクチャーを作成するには、`SvgImage` を作成する前に SVG を自己完結型にします。たとえば、リンクされた画像 URL を画像データを含む `data:` URI に置き換えます。

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

必要なすべてのリソースが SVG コンテンツに埋め込まれたら、`SvgImage` を作成し、プレゼンテーションの画像コレクションに追加し、前述の例と同様にピクチャーフレームに挿入します。

### **不足またはブロックされたリソースの処理**

`resolveUri` からは、リソース URI が無効、禁止、または解決不能な場合に `null` を返します。`getEntity` からは、リソースが読み取れない場合に `null` を返します。可能な限り、Aspose.Slides はそのリソースがなくても SVG の処理を続行します。

不足したリソースに対してフォールバックストリームを返すことはできますが、その内容は要求されたリソースタイプと互換性がある必要があります。たとえば、画像が欠如している場合にのみ画像ストリームを返し、フォントやスタイルシートに対しては返さないでください。

{{% alert title="Security" color="warning" %}}

信頼できない SVG ファイルから任意のファイルパスや制限のないネットワーク URL を解決しないでください。許可されるスキーム、ディレクトリ、ホストを制限し、ネットワークリソースの場合は接続タイムアウト、応答サイズ制限、コンテンツ検証も適用してください。

{{% /alert %}}

## **SVG を形状セットに変換する**

Aspose.Slides は、PowerPoint の同等機能と同様に、SVG を形状のセットに変換できます。

![PowerPoint ポップアップ メニュー](img_01_01.png)

この機能は、SVG 画像オブジェクトを最初の引数として受け取る [addGroupShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) メソッドのオーバーロードによって提供されます。

以下の JavaScript サンプルコードは、このメソッドを使用して SVG ファイルを形状のセットに変換する方法を示しています。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// ソース SVG ファイル名。
const svgFileName = "sample.svg";

// 出力プレゼンテーション ファイル名。
const outPptxPath = "presentation.pptx";

// 新しいプレゼンテーションを作成。
const presentation = new aspose.slides.Presentation();
try {
    // SVG ファイルの内容を読み取ります。
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // SvgImage オブジェクトを作成。
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // スライドサイズを取得。
    const slideSize = presentation.getSlideSize().getSize();

    // SVG 画像を形状のグループに変換し、スライドサイズに合わせてスケールします。
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // プレゼンテーションを PPTX 形式で保存。
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **EMF として画像をスライドに追加する**

Aspose.Slides for Node.js via Java を使用すると、Aspose.Cells で Excel ワークシートから EMF 画像を生成し、プレゼンテーションのスライドに追加できます。

以下の JavaScript サンプルコードは、その手順を示しています。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// ワークブックをストリームに保存します。
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // ファイルをそのまま追加し、画像がベクター EMF のままでラスタライズされないようにします。
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **画像コレクション内の画像を置換する**

Aspose.Slides では、スライド形状で使用されている画像を含む、プレゼンテーションの画像コレクションに格納された画像を置換できます。このセクションでは、コレクション内の画像を更新する複数の方法を説明します。画像は、生のバイト データ、[IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して置換できます。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスを使用して、画像を含むプレゼンテーション ファイルをロードします。
1. ファイルから新しい画像をバイト配列にロードします。
1. バイト配列を使用して対象画像を新しい画像に置換します。
1. 2 番目の方法では、画像を [IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置換します。
1. 3 番目の方法では、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き込みます。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 最初の方法。
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // 2 番目の方法。
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // 3 番目の方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // プレゼンテーションをファイルに保存します。
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose の無料 [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータを使用すれば、テキストを簡単にアニメーション化し、GIF に変換できます。 

{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度は保持されますか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/nodejs-java/picture-frame/) がどのようにスケーリングされるか、保存時に適用される圧縮に依存します。

**多数のスライドにわたって同じロゴを一括で置換する最適な方法は？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換してください。更新はそのリソースを使用しているすべての要素に伝播します。

**挿入した SVG を編集可能な形状に変換できますか？**

はい。SVG を形状のグループに変換でき、その後個々のパーツは標準の形状プロパティで編集可能になります。

**複数のスライドに対して一括で画像を背景として設定するには？**

マスタースライドまたは該当レイアウトで画像を背景として割り当ててください（[Assign the image as the background](/slides/ja/nodejs-java/presentation-background/)）。そのマスター/レイアウトを使用しているすべてのスライドが背景を継承します。

**画像が多くてプレゼンテーションが大きくなりすぎるのを防ぐには？**

画像を重複させずに単一リソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、可能な限りマスターに繰り返し使用するグラフィックを配置してください。