---
title: JavaScript でプレゼンテーションスライドを画像に変換する
linktitle: スライドから画像へ
type: docs
weight: 35
url: /ja/nodejs-java/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドを画像に変換
- スライドを画像として保存
- スライドを EMF に変換
- スライドを PNG に変換
- スライドを JPEG に変換
- スライドをビットマップに変換
- スライドを TIFF に変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して、PPT、PPTX、ODP プレゼンテーションのスライドを PNG、JPEG、GIF、TIFF、EMF などの画像形式に JavaScript で変換します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを PNG、JPEG、GIF、TIFF などの画像形式でレンダリングできます。

スライドを画像に変換するには、次の手順を実行します。

1. [Presentation] クラスでプレゼンテーションをロードします。
2. レンダリングしたいスライドを選択します。
3. 必要に応じて、[RenderingOptions] または [TiffOptions] クラスでレンダリング設定を構成します。
4. [Slide.getImage] メソッドを呼び出します。これは [IImage] オブジェクトを返します。
5. [IImage.save] メソッドを呼び出し、[ImageFormat] 値で出力フォーマットを指定します。

## **スライドを PNG 画像に変換する**

最も簡単な変換はデフォルトのレンダリング設定を使用します。得られた [IImage] オブジェクトはメモリ上で処理するか、ファイルに保存できます。

次の JavaScript の例は、最初のスライドをレンダリングし、PNG 画像として保存します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **カスタムサイズでスライドを画像に変換する**

正確なピクセルサイズでスライドをレンダリングするには、`java.awt.Dimension` 値を受け取る [Slide.getImage] のオーバーロードを使用します。

次の例は 1820 × 1040 の JPEG 画像を作成します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **ノートとコメントを含むスライドを画像に変換する**

既定では、スライド画像にノートやコメントは含まれません。ノートとコメントの表示位置を制御するには、[NotesCommentsLayoutingOptions] オブジェクトを [RenderingOptions.setSlidesLayoutOptions] メソッドに渡します。

次の例は、ノートをスライド下部に切り捨てて表示し、コメントを右側に配置します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
スライドから画像への変換では、[NotesCommentsLayoutingOptions.setNotesPosition] メソッドに [BottomFull] を渡さないでください。ノートは固定サイズの画像に収まりきらない場合があります。代わりに [BottomTruncated] を使用してください。
{{% /alert %}}

## **TIFF オプションを使用してスライドを画像に変換する**

[TiffOptions] クラスを使用すると、レンダリングされた TIFF 画像のサイズ、解像度、およびその他のプロパティを制御できます。

次の例は、最初のスライドを 2160 × 2880、300 DPI の TIFF 画像としてレンダリングします。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
TIFF のサポートは JDK 9 未満の Java バージョンでは保証されません。
{{% /alert %}}

## **すべてのスライドを画像に変換する**

スライドコレクションを反復処理し、プレゼンテーション全体を一連の画像に変換します。非表示スライドも、明示的に除外しない限り含まれます。

次の例は、すべてのスライドを横方向・縦方向のスケール係数 2 で JPEG 画像としてレンダリングします。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **拡張メタファイル (EMF) 出力を作成する**

EMF は、Microsoft Office や Windows メタファイルをサポートする他の Windows アプリケーションとベクターベースのグラフィックを交換する必要がある場合に便利です。ピクセルベースの画像とは異なり、EMF はスケーリング時にシャープさを保ったままベクタードローイング操作を保持できます。ただし、EMF は主に Windows メタファイルをサポートするアプリケーション向けの互換性フォーマットであり、汎用的な交換フォーマットではありません。また、ビットマップ画像や一部のエフェクトなどの複雑なスライドコンテンツは、ベクターメタファイルコンテナ内でラスタライズされた要素として保存されることがあります。

### **スライドを EMF にエクスポートする**

[Slide.writeAsEmf] メソッドは、スライドを EMF 形式でターゲットストリームに書き込みます。次の例はプレゼンテーションをロードし、最初のスライドを EMF ファイルストリームに書き込む方法を示します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

呼び出し元は [Slide.writeAsEmf] に渡したストリームの所有権を持ち、上記の例のようにストリームを閉じる責任があります。

### **SVG 画像を EMF に変換してプレゼンテーションに追加する**

[SvgImage.writeAsEmf] を使用して SVG コンテンツを EMF に変換できます。生成されたバイト列は、[ImageCollection.addImage] でプレゼンテーションに追加し、[ShapeCollection.addPictureFrame] でスライドに配置できます。

次の例は、SVG マークアップから [SvgImage] を作成し、メモリ上の EMF に変換し、最初のスライドにメタファイルを挿入してプレゼンテーションを保存します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf] は宛先ストリームの所有権を取得しません。`java.io.ByteArrayOutputStream` はすべての生成データをメモリに保持するため、`toByteArray` を呼び出す前に位置をリセットする必要はありません。返されたバイト配列はストリームが閉じられた後も有効です。

EMF の生成は、選択された Aspose.Slides for Node.js via Java と JDK の構成でサポートされている OS で利用可能ですが、フォントやグラフィック依存関係が利用できない場合、プラットフォーム間でレンダリング結果が異なることがあります。ソースコンテンツで使用されているフォントをインストールするか、適切な代替フォントを構成し、Aspose.Slides for Node.js via Java の [platform requirements](/slides/ja/nodejs-java/system-requirements/) に従って、対象の EMF 消費アプリケーションで結果を検証してください。Linux や macOS のアプリケーションは、Windows メタファイルの表示や編集に対してサポートが限定的または一貫性がありません。

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="info" %}}
プレゼンテーションのスライドを画像に変換する際にカラー絵文字を正しく表示するには、変換を実行するシステムに絵文字フォントがインストールされている必要があります。たとえば、プレゼンテーションで **Segoe UI Emoji** が使用されているがフォントが欠如している場合、絵文字は単色で出力されることがあります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ。[Slide.getImage] メソッドはスライドの静止画像をレンダリングし、アニメーションはエクスポートされません。

**非表示スライドを画像としてエクスポートできますか？**

はい。非表示スライドも通常のスライドと同様にレンダリングできます。上記の例のように処理ループに含めてください。

**スライド画像に影やその他のエフェクトは保持されますか？**

はい。Aspose.Slides はスライド画像に影、透明度、その他サポートされているグラフィックエフェクトをレンダリングします。