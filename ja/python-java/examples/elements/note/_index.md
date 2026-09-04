---
title: ノート
type: docs
weight: 240
url: /ja/python-java/examples/elements/note/
keywords:
- コード例
- ノート
- スピーカーノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java でスライドノートを操作します：PowerPoint および OpenDocument プレゼンテーションのスピーカーノートを追加、読み取り、削除、更新します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用してノート スライドを追加、読み取り、削除、更新する方法を示します。

[Installation](/slides/ja/python-java/installation/) に記載されている手順でパッケージをインストールします。各サンプルは JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。

## **ノート スライドを追加**

ノート スライドを作成し、テキストを割り当てます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **ノート スライドにアクセス**

既存のノート スライドからテキストを読み取ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **ノート スライドを削除**

スライドに紐付いたノート スライドを削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **ノート テキストを更新**

ノート スライドのテキストを変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```