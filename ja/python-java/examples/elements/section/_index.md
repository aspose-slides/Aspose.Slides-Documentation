---
title: セクション
type: docs
weight: 90
url: /ja/python-java/examples/elements/section/
keywords:
- コード例
- セクション
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java でプレゼンテーションのセクションを管理します: Python コード例でセクションの追加、アクセス、削除、名前変更を行います。"
---
プレゼンテーションのセクションを管理する例 — 追加、アクセス、削除、名前変更をプログラムで **Aspose.Slides for Python via Java** を使用して行います。

パッケージは[Installation](/slides/ja/python-java/installation/)に記載の手順でインストールします。各例では JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。

## **セクションの追加**

特定のスライドから始まるセクションを作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # セクションの開始を示すスライドを指定します。
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **セクションへのアクセス**

プレゼンテーションからセクション情報を読み取ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # インデックスでセクションにアクセスします。
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **セクションの削除**

以前に追加したセクションを削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # 最初のセクションを削除します。
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **セクションの名前変更**

既存のセクションの名前を変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```