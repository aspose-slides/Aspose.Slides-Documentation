---
title: "Pythonでプレゼンテーション スライドを画像に変換"
linktitle: "スライドから画像へ"
type: docs
weight: 41
url: /ja/python-net/convert-slide/
keywords:
- "スライドを変換"
- "スライドをエクスポート"
- "スライドから画像へ"
- "スライドを画像として保存"
- "スライドから EMF へ"
- "スライドから PNG へ"
- "スライドから JPEG へ"
- "スライドからビットマップへ"
- "スライドから TIFF へ"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides を使用して、Python で PPT、PPTX、ODP プレゼンテーションのスライドを PNG、JPEG、GIF、TIFF、EMF などの画像形式に変換します。"
---
## **概要**

Aspose.Slides for Python via .NET は、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを PNG、JPEG、GIF、TIFF、その他の画像形式でレンダリングできます。

スライドを画像に変換する手順:

1. プレゼンテーションを [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスでロードします。
2. レンダリングしたいスライドを選択します。
3. 必要に応じて、[RenderingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/renderingoptions/) または [TiffOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/tiffoptions/) クラスでレンダリングを構成します。
4. [Slide.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/) メソッドを呼び出します。これにより [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) オブジェクトが返されます。
5. [IImage.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/save/) メソッドを呼び出し、[ImageFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imageformat/) 値で出力形式を指定します。

## **スライドを PNG 画像に変換**

最も簡単な変換はデフォルトのレンダリング設定を使用します。結果として得られる [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) オブジェクトはメモリ内で処理することも、ファイルに保存することもできます。

以下の Python サンプルは最初のスライドをレンダリングし、PNG 画像として保存します:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **カスタムサイズでスライドを画像に変換**

正確なピクセルサイズでスライドをレンダリングするために、[Size](https://reference.aspose.com/slides/ja/python-net/aspose.pydrawing/size/) 値を受け取る [Slide.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) のオーバーロードを使用します。

以下の例は 1820 × 1040 の JPEG 画像を作成します:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **ノートとコメント付きスライドを画像に変換**

デフォルトでは、スライド画像にノートやコメントは含まれません。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/notescommentslayoutingoptions/) オブジェクトを [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) プロパティに割り当てて、ノートとコメントの表示位置を制御します。

以下の例は、切り詰められたノートをスライドの下に、コメントを右側に配置します:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="警告" color="warning" %}}
スライドから画像への変換では、[NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) プロパティを [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/notespositions/) に設定しないでください。ノートは固定された画像サイズが収めきれないほどのテキストを含む可能性があります。その代わりに [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/notespositions/) を使用してください。
{{% /alert %}}

## **TIFF オプションを使用してスライドを画像に変換**

[TiffOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/tiffoptions/) クラスを使用すると、レンダリングされた TIFF 画像のサイズ、解像度、その他のプロパティを制御できます。

以下の例は、最初のスライドを 2160 × 2880 ピクセル、300 DPI の TIFF 画像としてレンダリングします:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **すべてのスライドを画像に変換**

スライド コレクションを走査して、プレゼンテーション全体を画像の系列に変換します。非表示スライドは、明示的にスキップしない限り含まれます。

以下の例は、すべてのスライドを水平・垂直倍率 2 の JPEG 画像としてレンダリングします:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **拡張メタファイル出力を作成**

拡張メタファイル (EMF) は、ベクター ベースのグラフィックを Microsoft Office や Windows メタファイルをサポートする他の Windows アプリケーションとやり取りする必要がある場合に有用です。ピクセルベースの画像とは異なり、EMF はベクター描画操作を保持でき、拡大縮小してもシャープさが失われません。ただし、EMF は主に Windows メタファイルをサポートするアプリケーション向けの互換性フォーマットであり、汎用の交換フォーマットではありません。さらに、ビットマップ画像や一部のエフェクトなど、複雑なスライド コンテンツはベクターメタファイル コンテナ内でラスタライズされた要素として格納される場合があります。

### **スライドを EMF にエクスポート**

[Slide.write_as_emf](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/write_as_emf/) メソッドは、[Slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/) を EMF 形式のターゲット ストリームに書き込みます。以下の例はプレゼンテーションをロードし、最初のスライドを選択して EMF ファイル ストリームに書き込む手順を示します:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

呼び出し元は [Slide.write_as_emf](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/write_as_emf/) に渡されたストリームの所有権を持ち、使用後に閉じる必要があります。Aspose.Slides はストリームの現在位置から書き込みを行い、ストリームは開いたまま残ります。

### **SVG 画像を EMF に変換し、プレゼンテーションに追加**

[SvgImage.write_as_emf](https://reference.aspose.com/slides/ja/python-net/aspose.slides/svgimage/write_as_emf/) を使用して SVG コンテンツを EMF に変換します。生成されたバイト列は [ImageCollection.add_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/add_image/) でプレゼンテーションに追加でき、[ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_picture_frame/) でスライド上に配置できます。

以下の例は SVG マークアップから [SvgImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/svgimage/) を作成し、インメモリ EMF に変換して最初のスライドにメタファイルを挿入し、プレゼンテーションを保存します:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/ja/python-net/aspose.slides/svgimage/write_as_emf/) は宛先ストリームの所有権を取得しません。書き込み後、ストリーム位置は生成データの終端になります。上記のように `getvalue` を呼び出して現在のストリーム位置に関係なく完全なバッファを取得してください。データを読み終えるまでストリームを開いたままにし、読み取り後に閉じてください。

EMF の生成は Aspose.Slides for Python via .NET がサポートする OS で利用可能ですが、フォントやネイティブ グラフィック依存関係が利用できない場合、プラットフォーム間でレンダリング結果が異なることがあります。元コンテンツで使用されているフォントをインストールするか、適切な代替フォントを構成し、Aspose.Slides の [platform requirements](/slides/ja/python-net/system-requirements/) に従い、対象の EMF 消費アプリケーションで結果を検証してください。Linux や macOS のアプリケーションは、Windows メタファイルの表示・編集に限られたサポートしか提供しないことがあります。

## **カラー絵文字のレンダリング**

{{% alert title="注" color="info" %}}
プレゼンテーション スライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが変換を実行するシステムにインストールされ、利用可能である必要があります。たとえば、プレゼンテーションが **Segoe UI Emoji** を使用していてこのフォントが存在しない場合、出力画像の絵文字はモノクロで表示されることがあります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ。[Slide.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/) メソッドはスライドの静止画像をレンダリングし、アニメーションはエクスポートされません。

**非表示スライドを画像としてエクスポートできますか？**

はい。非表示のスライドも通常のスライドと同様にレンダリングできます。上記の例のように処理ループに含めてください。

**スライド画像に影やその他のエフェクトは保持されますか？**

はい。Aspose.Slides は影、透明度、その他サポートされているグラフィック効果をスライド画像にレンダリングします。