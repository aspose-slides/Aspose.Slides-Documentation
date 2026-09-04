---
title: ヘッダーとフッター
type: docs
weight: 220
url: /ja/python-java/examples/elements/header-footer/
keywords:
- コード例
- ヘッダー
- フッター
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してスライドのヘッダーとフッターを制御します。PPT、PPTX、ODP プレゼンテーションに日付、スライド番号、カスタムテキストを追加できます。"
---
この記事では、**Aspose.Slides for Python via Java** を使用してフッターの追加と日付および時刻プレースホルダーの更新方法を示します。

[Installation](/slides/ja/python-java/installation/) に記載されている手順に従ってパッケージをインストールします。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が起動した後に API をインポートします。

## **フッターの追加**
スライドのフッター領域にテキストを追加し、表示させます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **日付と時刻の更新**
スライド上の日付と時刻のプレースホルダーを変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```