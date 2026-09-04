---
title: レイアウト スライド
type: docs
weight: 20
url: /ja/python-java/examples/elements/layout-slide/
keywords:
- コード例
- レイアウト スライド
- レイアウト スライドの追加
- レイアウト スライドへのアクセス
- レイアウト スライドの削除
- 未使用のレイアウト スライド
- レイアウト スライドのクローン作成
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してレイアウト スライドを管理します：PowerPoint および OpenDocument プレゼンテーションでレイアウトの追加、アクセス、削除、クリーンアップ、クローン作成を行います。"
---
この記事では、Aspose.Slides for Python via Java を使用して **レイアウト スライド** を操作する方法を示します。レイアウト スライドは、通常のスライドが継承するデザインと書式を定義します。レイアウト スライドの追加、アクセス、クローン作成、削除、そして未使用のスライドをクリーンアップしてプレゼンテーションのサイズを削減できます。

[Installation](/slides/ja/python-java/installation/) に記載された手順でパッケージをインストールします。各サンプルは JVM を起動する前に `asposeslides` をインポートし、JVM が起動した後に API をインポートします。

## **レイアウト スライドの追加**

再利用可能な書式を定義するカスタム レイアウト スライドを作成します。以下の例では、新しいレイアウトにテキスト ボックスを追加し、そのレイアウトを使用するスライドを2枚作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # 空白のレイアウトタイプとカスタム名でレイアウト スライドを作成します。
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # レイアウト スライドにテキスト ボックスを追加します。
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # レイアウトからテキストを継承するスライドを2枚追加します。
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **注 1:** レイアウト スライドは個々のスライドのテンプレートとして機能します。共通要素を一度定義すれば、多くのスライドで再利用できます。

> 💡 **注 2:** レイアウト スライドにシェイプやテキストを追加すると、そのレイアウトに基づくすべてのスライドで共有コンテンツが自動的に表示されます。  
> 以下のスクリーンショットは、同じレイアウト スライドからテキスト ボックスを継承した2枚のスライドを示しています。

![レイアウト コンテンツを継承するスライド](layout-slide-result.png)

## **レイアウト スライドへのアクセス**

インデックスやレイアウトの種類（空白、タイトル、セクション ヘッダーなど）でレイアウト スライドにアクセスします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # インデックスでレイアウト スライドにアクセスします。
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # タイプでレイアウト スライドにアクセスします。
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **レイアウト スライドの削除**

不要になった特定のレイアウト スライドを削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **未使用のレイアウト スライドの削除**

通常のスライドで使用されていないレイアウト スライドを削除し、プレゼンテーションのサイズを削減します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **レイアウト スライドのクローン作成**

レイアウト スライドを複製し、レイアウト スライド コレクションの末尾に追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **要約:** レイアウト スライドはプレゼンテーション全体で一貫した書式を保つのに役立ちます。Aspose.Slides を使用すれば、レイアウトの作成、管理、再利用、クリーンアップを必要に応じて行えます。