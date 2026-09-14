---
title: Python でプレゼンテーションスライドを画像に変換
linktitle: スライドから画像へ
type: docs
weight: 35
url: /ja/python-java/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドを画像化
- スライドを画像として保存
- スライドを EMF に変換
- スライドを PNG に変換
- スライドを JPEG に変換
- スライドをビットマップに変換
- スライドを TIFF に変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、PPT、PPTX、ODP プレゼンテーションのスライドを PNG、JPEG、GIF、TIFF、EMF などの画像形式に Python で変換します。"
---
## **はじめに**

Aspose.Slides for Python via Java は、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを PNG、JPEG、GIF、TIFF、その他の画像形式としてレンダリングできます。

スライドを画像に変換するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. レンダリングしたいスライドを選択します。
3. 必要に応じて、[RenderingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/) または [TiffOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/) クラスでレンダリングを構成します。
4. [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) メソッドを呼び出します。このメソッドは画像オブジェクトを返します。
5. 画像を保存し、[ImageFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imageformat/) の値で出力形式を指定します。

## **スライドを PNG 画像に変換**

最も簡単な変換はデフォルトのレンダリング設定を使用します。生成された画像オブジェクトはメモリ内で処理することも、ファイルに保存することもできます。

以下の Python の例は、最初のスライドをレンダリングし、PNG 画像として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **カスタムサイズでスライドを画像に変換**

[Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) のオーバーロードを使用し、[Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 値を受け取って、スライドを正確なピクセル寸法でレンダリングします。

以下の例は、1820 × 1040 の JPEG 画像を作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **ノートとコメント付きスライドを画像に変換**

デフォルトでは、スライド画像にノートやコメントは含まれません。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) オブジェクトを [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) メソッドに渡すことで、ノートとコメントの表示位置を制御できます。

以下の例は、切り取られたノートをスライドの下に、コメントを右側に配置します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
スライドから画像への変換では、[NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) メソッドに [BottomFull](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/#BottomFull) を渡さないでください。ノートは固定された画像サイズが収容できる以上のテキストを含む場合があります。その代わりに [BottomTruncated](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/#BottomTruncated) を使用してください。
{{% /alert %}}

## **TIFF オプションを使用してスライドを画像に変換**

[TiffOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/) クラスを使用すると、レンダリングされた TIFF 画像のサイズ、解像度、その他のプロパティを制御できます。

以下の例は、最初のスライドを 2160 × 2880 の TIFF 画像として、300 DPI でレンダリングします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
TIFF のサポートは JDK 9 より前の Java バージョンでは保証されていません。
{{% /alert %}}

## **すべてのスライドを画像に変換**

スライドコレクションを反復処理して、プレゼンテーション全体を一連の画像に変換します。明示的に除外しない限り、非表示スライドも含まれます。

以下の例は、すべてのスライドを横方向・縦方向のスケール係数 2 の JPEG 画像としてレンダリングします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **拡張メタファイル出力の作成**

拡張メタファイル (EMF) は、ベクターベースのグラフィックを Microsoft Office や Windows メタファイルをサポートする他の Windows アプリケーションとやり取りする必要がある場合に便利です。ピクセルベースの画像とは異なり、EMF はベクタードローイング操作を保持でき、拡大縮小してもシャープさが失われません。ただし、EMF は主に Windows メタファイルをサポートするアプリケーション向けの互換性フォーマットであり、汎用の交換フォーマットではありません。さらに、ビットマップ画像や一部のエフェクトなど、複雑なスライドコンテンツはベクターメタファイルコンテナ内にラスタライズされた要素として保存される場合があります。

### **スライドを EMF にエクスポート**

[Slide.writeAsEmf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) メソッドは、[Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) を EMF 形式でターゲットストリームに書き込みます。以下の例は、プレゼンテーションをロードし、最初のスライドを選択し、EMF ファイルストリームに書き込むものです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

呼び出し側は [Slide.writeAsEmf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) に渡されたストリームの所有権を持ち、上記のようにストリームを閉じる責任があります。

### **SVG 画像を EMF に変換してプレゼンテーションに追加**

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) を使用して SVG コンテンツを EMF に変換します。生成されたバイト列は [ImageCollection.addImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/#addImage) を介してプレゼンテーションに追加でき、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addPictureFrame) でスライドに配置できます。

以下の例は、SVG マークアップから [SvgImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) を作成し、メモリ内の EMF に変換し、最初のスライドにメタファイルを挿入し、プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) は、宛先ストリームの所有権を取得しません。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) は生成されたすべてのデータをメモリに保持するため、[ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) を呼び出す前に位置リセットは不要です。返されたバイト配列はストリームを閉じた後も有効です。

EMF の生成は、選択された Aspose.Slides for Python via Java と JDK 構成がサポートするオペレーティングシステムで利用可能ですが、フォントやグラフィック依存関係が利用できない場合、プラットフォーム間でレンダリングが異なることがあります。ソースコンテンツで使用されているフォントをインストールするか、適切な置換を設定し、Aspose.Slides for Python via Java の [プラットフォーム要件](/slides/ja/python-java/system-requirements/) に従い、対象の EMF 使用アプリケーションで結果を検証してください。Linux や macOS のアプリケーションは、Windows メタファイルの表示や編集に対してサポートが限られているか、一貫性がないことが多いです。

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="info" %}}
プレゼンテーションのスライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが、変換を実行するシステムにインストールされ、利用可能である必要があります。たとえば、プレゼンテーションが **Segoe UI Emoji** を使用していてこのフォントが存在しない場合、出力画像の絵文字がモノクロで表示されることがあります。
{{% /alert %}}

## **よくある質問**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ。[Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) メソッドはスライドの静止画像をレンダリングし、アニメーションはエクスポートしません。

**非表示スライドを画像としてエクスポートできますか？**

はい。非表示スライドも通常のスライドと同様にレンダリングできます。上記の例のように、処理ループに含めてください。

**スライド画像に影やその他のエフェクトは保持されますか？**

はい。Aspose.Slides はスライド画像に影、透明度、その他のサポートされたグラフィック効果をレンダリングします。