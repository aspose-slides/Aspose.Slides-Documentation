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
この記事では、**Aspose.Slides for Python via Java** を使用してフッターを追加し、日付と時刻のプレースホルダーを更新する方法を示します。

パッケージは[Installation](/slides/ja/python-java/installation/)に記載された手順でインストールします。各例では、JVM を開始する前に `asposeslides` をインポートし、JVM が実行中になった後に API をインポートします。

## **フッターを追加**

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