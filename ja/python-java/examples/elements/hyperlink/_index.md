---
title: ハイパーリンク
type: docs
weight: 130
url: /ja/python-java/examples/elements/hyperlink/
keywords:
- コード例
- ハイパーリンク
- ハイパーリンクの追加
- ハイパーリンクの取得
- ハイパーリンクの削除
- ハイパーリンクの更新
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java でハイパーリンクを追加および管理します：PPT、PPTX、ODP プレゼンテーションでリンクを作成、取得、削除、更新します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用して、図形上のハイパーリンクの追加、取得、削除、更新を示します。

[Installation](/slides/ja/python-java/installation/) に記載されている手順でパッケージをインストールしてください。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になった後で API をインポートします。

## **Add a Hyperlink**
外部ウェブサイトへリンクするハイパーリンクを持つ長方形の形状を作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Access a Hyperlink**
形状のテキスト部分からハイパーリンク情報を取得します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Remove a Hyperlink**
形状のテキストからハイパーリンクをクリアします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Update a Hyperlink**
既存のハイパーリンクの対象を変更します。[HyperlinkManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hyperlinkmanager/) を使用して、すでにハイパーリンクを含むテキストを安全に更新できる PowerPoint のハイパーリンク更新方法を模倣します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # 既存のテキスト内のハイパーリンクを変更する場合は、以下を使用して行う必要があります
    # HyperlinkManager を使用し、プロパティを直接設定しないでください。
    # これは、PowerPoint がハイパーリンクを安全に更新する方法を模倣しています。
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```