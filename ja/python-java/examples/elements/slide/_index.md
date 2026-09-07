---
title: スライド
type: docs
weight: 10
url: /ja/python-java/examples/elements/slide/
keywords:
- コード例
- スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java でスライドを管理します：PowerPoint と OpenDocument プレゼンテーション用の Python コード例を使用して、スライドの追加、アクセス、クローン、並び替え、削除を行います。"
---
この記事では、**Aspose.Slides for Python via Java** を使用してスライドを追加、アクセス、クローン、並び替え、削除する方法を示す例を提供します。

パッケージは[Installation](/slides/ja/python-java/installation/) に記載されている手順でインストールします。各例では、JVM を開始する前に `asposeslides` をインポートし、JVM が起動した後に API をインポートします。

## **スライドの追加**

新しいスライドを追加するには、まずレイアウトを選択します。この例では、空白レイアウトを使用してプレゼンテーションに空のスライドを追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
各スライドレイアウトはマスタースライドから派生しており、全体的なデザインとプレースホルダー構造が定義されています。下の画像は、PowerPoint でマスタースライドとそれに関連付けられたレイアウトがどのように構成されているかを示しています。
{{% /alert %}}

![マスタースライドとレイアウトの関係](master-layout-slide.png)

## **インデックスでスライドにアクセス**

スライドはゼロベースのインデックスでアクセスでき、また参照からスライドのインデックスを取得することもできます。これは、スライドを反復処理したり特定のスライドを変更したりする際に便利です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # 別の空のスライドを追加します。
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # インデックスでスライドにアクセスします。
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # 参照からスライドのインデックスを取得し、インデックスでアクセスします。
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **スライドのクローン**

既存のスライドをクローンします。クローンされたスライドは自動的にスライドコレクションの末尾に追加されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **スライドの並び替え**

スライドの順序を変更するには、スライドを新しいインデックスに移動します。この例では、クローンされたスライドを最初の位置に移動します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **スライドの削除**

スライドコレクションにスライドの参照を渡すことでスライドを削除します。この例では、2枚目のスライドを追加し、元のスライドを削除して新しいスライドだけが残ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```