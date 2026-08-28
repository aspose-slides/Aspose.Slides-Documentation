---
title: Javaでプレゼンテーションスライドを画像に変換
linktitle: スライドから画像へ
type: docs
weight: 35
url: /ja/java/convert-slide/
keywords:
- スライド変換
- スライドエクスポート
- スライド画像変換
- スライドを画像として保存
- スライドをEMFに変換
- スライドをPNGに変換
- スライドをJPEGに変換
- スライドをビットマップに変換
- スライドをTIFFに変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java で PPT、PPTX、ODP プレゼンテーションのスライドを PNG、JPEG、GIF、TIFF、EMF などの画像形式に変換します。"
---
## **概要**

Aspose.Slides for Java は、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを PNG、JPEG、GIF、TIFF、その他の画像形式でレンダリングできます。

スライドを画像に変換するには、次の手順を実行します。

1. プレゼンテーションを [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスでロードします。
2. レンダリングしたいスライドを選択します。
3. 必要に応じて、[RenderingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/renderingoptions/) または [TiffOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tiffoptions/) クラスでレンダリングを構成します。
4. [ISlide.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#getImage--) メソッドを呼び出します。これにより [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) オブジェクトが返されます。
5. [IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/#save-java.lang.String-int-) メソッドを呼び出し、[ImageFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imageformat/) の値で出力フォーマットを指定します。

## **スライドを PNG 画像に変換**

最も簡単な変換はデフォルトのレンダリング設定を使用します。結果として得られる [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) オブジェクトはメモリ内で処理することも、ファイルに保存することもできます。

以下の Java の例は、最初のスライドをレンダリングし、PNG 画像として保存します。

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **カスタムサイズでスライドを画像に変換**

正確なピクセル寸法でスライドをレンダリングするには、[Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 値を受け取る [ISlide.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) のオーバーロードを使用します。

以下の例は 1820 × 1040 の JPEG 画像を作成します。

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **ノートとコメント付きのスライドを画像に変換**

デフォルトでは、スライド画像にノートやコメントは含まれません。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notescommentslayoutingoptions/) オブジェクトを [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) メソッドに渡すことで、ノートとコメントの表示位置を制御できます。

以下の例では、切り詰められたノートをスライドの下に、コメントを右側に配置します。

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
スライドから画像への変換では、[NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) メソッドに [BottomFull](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notespositions/) を渡さないでください。ノートは固定画像サイズが収めきれないほどのテキストを含む可能性があります。その代わりに [BottomTruncated](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notespositions/) を使用してください。
{{% /alert %}}

## **TIFF オプションを使用してスライドを画像に変換**

[TiffOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tiffoptions/) クラスを使用すると、レンダリングされた TIFF 画像のサイズ、解像度、その他のプロパティを制御できます。

以下の例は、最初のスライドを 2160 × 2880 の TIFF 画像として、300 DPI でレンダリングします。

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
JDK 9 より前の Java バージョンでは TIFF のサポートが保証されません。
{{% /alert %}}

## **すべてのスライドを画像に変換**

スライドコレクションを反復処理して、プレゼンテーション全体を一連の画像に変換します。特にスキップしない限り、非表示スライドも含まれます。

以下の例は、すべてのスライドを水平方向・垂直方向のスケール係数 2 の JPEG 画像としてレンダリングします。

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **拡張メタファイル出力を作成**

拡張メタファイル (EMF) は、ベクトルベースのグラフィックを Microsoft Office や Windows メタファイルをサポートする他の Windows アプリケーションとやり取りする必要がある場合に便利です。ピクセルベースの画像とは異なり、EMF はベクトル描画操作を保持でき、拡大縮小してもシャープさが同程度に保たれます。ただし、EMF は主に Windows メタファイルをサポートするアプリケーション向けの互換性フォーマットであり、汎用的な交換フォーマットではありません。さらに、ビットマップ画像や一部のエフェクトなどの複雑なスライドコンテンツは、ベクトルメタファイルコンテナ内にラスタライズされた要素として格納されることがあります。

### **スライドを EMF にエクスポート**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) メソッドは、[ISlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/) を EMF 形式でターゲットストリームに書き込みます。以下の例は、プレゼンテーションをロードし、最初のスライドを選択し、EMF ファイルストリームに書き出します。

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

呼び出し元は [ISlide.writeAsEmf](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) に渡されたストリームの所有権を持ち、上記のようにストリームを閉じる責任があります。

### **SVG 画像を EMF に変換し、プレゼンテーションに追加**

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) を使用して SVG コンテンツを EMF に変換します。生成されたバイト列は [IImageCollection.addImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) を介してプレゼンテーションに追加でき、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) でスライド上に配置できます。

以下の例は、SVG マークアップから [SvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgimage/) を作成し、メモリ内の EMF に変換し、最初のスライドにメタファイルを挿入し、プレゼンテーションを保存します。

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) は宛先ストリームの所有権を取得しません。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) は生成されたデータをすべてメモリに保持するため、`toByteArray` を呼び出す前に位置リセットは必要ありません。ストリームが閉じられた後も返されたバイト配列は有効です。

EMF の生成は、選択された Aspose.Slides for Java と JDK 構成がサポートするオペレーティングシステム上で利用可能ですが、フォントやグラフィックの依存関係が利用できない場合、プラットフォーム間でレンダリングが異なることがあります。ソースコンテンツで使用されているフォントをインストールするか、適切な代替フォントを設定し、Aspose.Slides for Java の [platform requirements](/slides/ja/java/system-requirements/) に従って、対象の EMF 使用アプリケーションで結果を検証してください。Linux や macOS のアプリケーションは、Windows メタファイルの表示や編集に対するサポートが限定的または一貫性がないことが多いです。

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="info" %}}
プレゼンテーションのスライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが変換を実行するシステムにインストールされ、利用可能である必要があります。例として、プレゼンテーションが **Segoe UI Emoji** を使用しているがフォントが存在しない場合、出力画像の絵文字はモノクロで表示される可能性があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ。[ISlide.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#getImage--) メソッドはスライドの静止画像をレンダリングし、アニメーションはエクスポートされません。

**非表示スライドを画像としてエクスポートできますか？**

はい。非表示スライドも通常のスライドと同様にレンダリングできます。上記の例のように、処理ループに含めてください。

**スライド画像に影やその他のエフェクトは保持されますか？**

はい。Aspose.Slides は影、透明度、その他サポートされているグラフィックエフェクトをスライド画像にレンダリングします。