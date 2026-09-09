---
title: Python via Javaでプレゼンテーションのハイパーリンクを管理
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/python-java/manage-hyperlinks/
keywords:
- URLを追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- 動画ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを手軽に管理し、数分でインタラクティブ性とワークフローを向上させます。"
---
## **はじめに**

ハイパーリンクは、オブジェクト、データ、または場所への参照です。PowerPoint プレゼンテーションで一般的なハイパーリンクには次のものがあります：

* テキスト、図形、またはメディア内のウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for Python via Java を使用すると、プレゼンテーション内のハイパーリンクに関するさまざまなタスクを実行できます。 

{{% alert color="info" title="Note" %}} 
Aspose のシンプルな、[無料オンライン PowerPoint エディター](https://products.aspose.app/slides/ja/editor) をご確認ください。 
{{% /alert %}} 

## **URL ハイパーリンクの追加**

### **テキストへの URL ハイパーリンクの追加**

この Python コードは、テキストに Web サイトのハイパーリンクを追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **図形またはフレームへの URL ハイパーリンクの追加**

この Python via Java のサンプルコードは、図形に Web サイトのハイパーリンクを追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **メディアへの URL ハイパーリンクの追加**

Aspose.Slides を使用すると、画像、音声、動画ファイルにハイパーリンクを追加できます。

このサンプルコードは、**画像**にハイパーリンクを追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # プレゼンテーションに画像を追加
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # スライド1に、以前追加した画像を基に画像フレームを作成
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

このサンプルコードは、**音声ファイル**にハイパーリンクを追加する方法を示しています。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

このサンプルコードは、**動画**にハイパーリンクを追加する方法を示しています。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}} 
*[Manage OLE](/slides/ja/python-java/manage-ole/)* をご覧になることをお勧めします。 
{{% /alert %}}

## **ハイパーリンクを使用した目次の作成**

ハイパーリンクはオブジェクトや場所への参照を追加できるため、目次の作成に利用できます。

このサンプルコードは、ハイパーリンク付きの目次を作成する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ハイパーリンクの書式設定**

### **色**

[Hyperlink.setColorSource](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setColorSource) プロパティを使用すると、[Hyperlink](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/) クラスでハイパーリンクの色を設定したり、ハイパーリンクから色情報を取得したりできます。この機能は PowerPoint 2019 で初めて導入されたため、プロパティに関する変更は旧バージョンの PowerPoint には適用されません。

このサンプルコードは、同じスライドに異なる色のハイパーリンクを追加する操作を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **プレゼンテーションからハイパーリンクを削除**

### **テキストからハイパーリンクを削除**

この Python コードは、プレゼンテーションのスライド上のテキストからハイパーリンクを削除する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **図形またはフレームからハイパーリンクを削除**

この Python コードは、プレゼンテーションのスライド上の図形からハイパーリンクを削除する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **可変ハイパーリンク**

[Hyperlink](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/) クラスは可変です。このクラスを使用すると、次のプロパティの値を変更できます：

- [setTargetFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

このコードスニペットは、スライドにハイパーリンクを追加し、後でツールチップを編集する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # 既に追加されているハイパーリンクのツールチップを変更する
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HyperlinkQueries のサポートされているプロパティ**

ハイパーリンクが定義されているプレゼンテーション、スライド、またはテキストから [HyperlinkQueries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/) にアクセスできます。

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#getHyperlinkQueries)

[HyperlinkQueries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/) クラスは、以下のメソッドとプロパティをサポートしています：

- [getHyperlinkClicks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**スライドだけでなく「セクション」やセクションの最初のスライドへ内部ナビゲーションを作成するにはどうすればよいですか？**

PowerPoint のセクションはスライドのグループ化です。ナビゲーションは技術的には特定のスライドを対象とします。「セクションへ移動」する場合、通常はその最初のスライドへリンクします。

**マスタースライド要素にハイパーリンクを付けて、すべてのスライドで機能させることはできますか？**

はい。マスタースライドとレイアウト要素はハイパーリンクをサポートしています。そのようなリンクは子スライドに表示され、スライドショー中にクリック可能です。

**PDF、HTML、画像、動画へのエクスポート時にハイパーリンクは保持されますか？**

PDF（[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)）および HTML（[HTML](/slides/ja/python-java/convert-powerpoint-to-html/)）へのエクスポートでは、一般的にリンクは保持されます。画像（[images](/slides/ja/python-java/convert-powerpoint-to-png/)）や動画（[video](/slides/ja/python-java/convert-powerpoint-to-video/)）へのエクスポートでは、これらの形式はラスターフレーム/動画でハイパーリンクをサポートしないため、クリック可能性は引き継がれません。