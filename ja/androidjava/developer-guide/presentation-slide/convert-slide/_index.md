---
title: Android でプレゼンテーションスライドを画像に変換
linktitle: スライドから画像へ
type: docs
weight: 35
url: /ja/androidjava/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドから画像へ
- スライドを画像として保存
- スライドから EMF へ
- スライドから PNG へ
- スライドから JPEG へ
- スライドからビットマップへ
- スライドから TIFF へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Android 上で PPT、PPTX、ODP プレゼンテーションのスライドを PNG、JPEG、GIF、TIFF、EMF などの画像形式に変換します。"
---
## **導入**

Aspose.Slides for Android via Java は、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを PNG、JPEG、GIF、TIFF などの画像形式でレンダリングできます。

スライドを画像に変換するには、次の手順に従います。

1. プレゼンテーションを [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスでロードします。
2. レンダリングしたいスライドを選択します。
3. 必要に応じて、[RenderingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/renderingoptions/) または [TiffOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/) クラスでレンダリングを構成します。
4. [ISlide.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#getImage--) メソッドを呼び出します。このメソッドは [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) オブジェクトを返します。
5. [IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) メソッドを呼び出し、[ImageFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imageformat/) の値で出力形式を指定します。

## **スライドを PNG 画像に変換**

最も簡単な変換はデフォルトのレンダリング設定を使用します。生成された [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) オブジェクトはメモリ内で処理するか、ファイルに保存できます。

以下の Java の例は最初のスライドをレンダリングし、PNG 画像として保存します：

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

[Size](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.android/size/) の値を受け取る [ISlide.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) のオーバーロードを使用して、正確なピクセル寸法でスライドをレンダリングします。

以下の例は 1820 × 1040 の JPEG 画像を作成します：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

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

## **ノートとコメント付きスライドを画像に変換**

デフォルトでは、スライド画像にノートやコメントは含まれません。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notescommentslayoutingoptions/) オブジェクトを [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) メソッドに渡すことで、ノートやコメントの表示位置を制御できます。

以下の例は、切り捨てられたノートをスライドの下に、コメントを右側に配置します：

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

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
スライドから画像への変換では、[NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) メソッドに [BottomFull](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notespositions/) を渡さないでください。ノートは固定された画像サイズが収容できる以上のテキストを含む場合があります。その代わりに [BottomTruncated](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notespositions/) を使用してください。
{{% /alert %}}

## **TIFF オプションを使用したスライドの画像変換**

[TiffOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/) クラスを使用すると、レンダリングされた TIFF 画像のサイズ、解像度、その他のプロパティを制御できます。

以下の例は、最初のスライドを 2160 × 2880 の TIFF 画像として 300 DPI でレンダリングします：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

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

## **すべてのスライドを画像に変換**

スライドコレクションを反復処理して、プレゼンテーション全体を一連の画像に変換します。非表示スライドは、明示的にスキップしない限り含まれます。

以下の例は、すべてのスライドを水平・垂直倍率 2 の JPEG 画像としてレンダリングします：

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

拡張メタファイル（EMF）は、ベクトルベースのグラフィックスを Microsoft Office や Windows メタファイルをサポートする他の Windows アプリケーションとやり取りする必要がある場合に役立ちます。ピクセルベースの画像とは異なり、EMF はベクトル描画操作を保持でき、拡大縮小しても同じく鮮明さが失われません。ただし、EMF は主に Windows メタファイルをサポートするアプリケーション向けの互換性フォーマットであり、汎用的な交換フォーマットではありません。さらに、ビットマップ画像や一部のエフェクトなどの複雑なスライドコンテンツは、ベクトルメタファイルのコンテナ内にラスタライズされた要素として格納される場合があります。

### **スライドを EMF にエクスポート**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) メソッドは、[ISlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/) を EMF 形式でターゲットストリームに書き込みます。以下の例はプレゼンテーションをロードし、最初のスライドを選択して、EMF ファイルストリームに書き込むものです：

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

呼び出し側は [ISlide.writeAsEmf](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) に渡したストリームの所有権を持ち、上記のようにストリームを閉じる責任があります。

### **SVG 画像を EMF に変換してプレゼンテーションに追加**

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) を使用して SVG コンテンツを EMF に変換します。生成されたバイト列は [IImageCollection.addImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) でプレゼンテーションに追加でき、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) でスライドに配置できます。

以下の例は SVG マークアップから [SvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/svgimage/) を作成し、インメモリの EMF に変換して、最初のスライドにメタファイルを挿入し、プレゼンテーションを保存します：

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) は宛先ストリームの所有権を取得しません。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) は生成されたデータをすべてメモリに格納するため、`toByteArray` を呼び出す前に位置のリセットは不要です。返されたバイト配列はストリームが閉じた後も有効です。

EMF の生成は対応する Android バージョンおよびデバイス構成で利用可能ですが、フォントやグラフィックスの依存関係が利用できない場合、レンダリングが異なることがあります。ソースコンテンツで使用されているフォントをインストールするか、適切な代替フォントを設定し、Aspose.Slides for Android via Java の [installation guide](/slides/ja/androidjava/install-aspose-slides-for-android-via-java/) に従って、ターゲットの EMF 消費アプリケーションで結果を検証してください。非 Windows プラットフォームのアプリケーションは、Windows メタファイルの表示や編集に対するサポートが限定的または一貫性がないことが多いです。

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="info" %}}
プレゼンテーションのスライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが変換を実行するシステムにインストールされ、利用可能である必要があります。例として、プレゼンテーションが **Segoe UI Emoji** を使用していてそのフォントが存在しない場合、絵文字は出力画像でモノクロで表示される可能性があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ。[ISlide.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#getImage--) メソッドはスライドの静的画像をレンダリングし、アニメーションはエクスポートされません。

**非表示スライドを画像としてエクスポートできますか？**

はい。非表示スライドも通常のスライドと同様にレンダリングできます。上記の例のように処理ループに含めてください。

**スライド画像に影やその他のエフェクトは保持されますか？**

はい。Aspose.Slides はスライド画像に影、透明度、その他のサポートされているグラフィック効果をレンダリングします。