---
title: PythonでPPTおよびPPTXをJPGに変換
linktitle: PowerPoint を JPG に変換
type: docs
weight: 60
url: /ja/python-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PowerPoint を JPG に変換
- PPT を JPG に変換
- PPTX を JPG に変換
- スライドを JPG として保存
- PPT を JPG にエクスポート
- PPTX を JPG にエクスポート
- Python
- Java
- Aspose.Slides
description: "Python（Java 経由）で PowerPoint（PPT、PPTX）スライドを JPG 画像に変換します。カスタム画像サイズを設定し、Aspose.Slides を使用してノートとコメントをレンダリングします。"
---
## **紹介**

Aspose.Slides for Python via Java を使用すると、PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) を JPEG 画像に変換できます。すべてのスライドまたは選択したスライドをエクスポートしてサムネイルを作成したり、プレゼンテーションビューアを構築したり、ウェブサイトやアプリケーションにスライドプレビューを埋め込んだりできます。

## **PowerPoint PPT/PPTX を JPG に変換**

1. プレゼンテーションを [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) で読み込みます。
2. [getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) を使用してスライドを取得します。
3. [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) を水平および垂直のスケール係数と共に呼び出して、各スライドをレンダリングします。
4. [ImageFormat.Jpeg](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imageformat/#Jpeg) を使用して各レンダリング画像を JPEG として保存し、画像リソースを解放します。

{{% alert color="info" title="Note" %}}
JPG にエクスポートすると、各スライドごとに個別の画像が作成されます。プレゼンテーションを直接画像形式で保存するのではなく、レンダリングされた画像を保存してください。
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **カスタムサイズで PowerPoint PPT/PPTX を JPG に変換**

目的のピクセル寸法と元のスライドサイズから水平および垂直のスケール係数を計算し、それらを [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) に渡します。以下の例は、各スライドに対して 1200 × 800 ピクセルの画像を対象としています。

異なるスケール係数を使用するとスライドが伸びる可能性があります。アスペクト比を維持するには、両軸で同じスケール係数を使用してください。その場合、結果の幅と高さは元のスライドの比率に従います。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **スライドを画像として保存する際にコメントをレンダリング**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) を使用してノートとコメントを構成し、[RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) でレイアウトを適用します。この例では、ノートを下部に配置し、収まらないノートは切り捨て、コメントは右側の 200 ピクセル幅の領域に表示します。各レンダリングされたスライドは JPG 画像として保存されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**複数のスライドやプレゼンテーションを JPG に変換できますか？**

はい。サンプルではすべてのスライドをループし、スライドごとに 1 つの JPG を保存します。複数のプレゼンテーションを処理する場合は、各入力ファイルごとに変換を繰り返し、出力フォルダーを分けるか、ファイル名を一意にして画像が上書きされないようにしてください。

**チャート、SmartArt、テーブル、図形は画像に含まれますか？**

これらのオブジェクトはスライドの一部としてレンダリングされます。フォント置換による差異を減らすため、変換環境にプレゼンテーションで使用されているフォントを利用できるようにしてください。

**大きなプレゼンテーションのエクスポート時にメモリ使用量を減らすにはどうすればよいですか？**

画像を1枚ずつ処理し、保存後に各画像を解放し、不要に大きな出力サイズを避けてください。メモリ要件はスライドの内容と画像サイズに依存します。

## **関連項目**

- [PowerPoint を PNG に変換](/slides/ja/python-java/convert-powerpoint-to-png/).
- [スライドを SVG 画像としてレンダリング](/slides/ja/python-java/render-a-slide-as-an-svg-image/).