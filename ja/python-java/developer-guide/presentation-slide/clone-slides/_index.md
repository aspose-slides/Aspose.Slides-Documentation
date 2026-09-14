---
title: Python でプレゼンテーションスライドをクローンする
linktitle: スライドをクローン
type: docs
weight: 35
url: /ja/python-java/clone-slides/
keywords:
- スライドをクローン
- スライドをコピー
- スライドを保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint スライドを迅速に複製します。明確なコード例に従い、数秒で PPT 作成を自動化し、手作業を排除しましょう。"
---
## **はじめに**

クローン作成とは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides for Python via Java では、任意のスライドのコピーまたはクローンを作成し、そのクローン化されたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成プロセスにより、元のスライドを変更せずに開発者が新しいスライドを編集できます。スライドをクローンする方法はいくつかあります：

- プレゼンテーション内の末尾にクローンを作成
- プレゼンテーション内の別の位置にクローンを作成
- 別のプレゼンテーションの末尾にクローンを作成
- 別のプレゼンテーションの別の位置にクローンを作成
- マスタースライドと共に別のプレゼンテーションにクローンを作成

Aspose.Slides for Python via Java では、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトが公開するスライドコレクション（[Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) オブジェクトのコレクション）に、上記のスライドクローン作成を実行するための [addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addClone) と [insertClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertClone) メソッドが用意されています。

## **プレゼンテーションの末尾にスライドをクローンする**

既存のスライドの末尾に同じプレゼンテーションファイル内でスライドをクローンして使用したい場合は、以下の手順に従って [addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addClone) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation] オブジェクトが公開する Slides コレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addClone) メソッドを呼び出し、クローン対象のスライドをパラメータとして渡します。
1. 変更されたプレゼンテーションファイルを書き出します。

以下の例では、プレゼンテーションの最初の位置（インデックス 0）にあるスライドをプレゼンテーションの末尾にクローンしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローン
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # 変更されたプレゼンテーションをディスクに保存
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **プレゼンテーション内の別の位置にスライドをクローンする**

同じプレゼンテーションファイル内で別の位置にスライドをクローンして使用したい場合は、[insertClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertClone) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation] オブジェクトの [getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) が返すスライドコレクションへの参照を取得します。
1. [SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトが公開する [insertClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertClone) メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメータとして渡します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションのインデックス 1（位置 2）にあるスライドをインデックス 2（位置 3）にクローンしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# プレゼンテーションファイルを表す Presentation クラスをインスタンス化
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # プレゼンテーション内のスライドコレクションを取得
    slides = presentation.getSlides()

    # 同じプレゼンテーション内の指定インデックスに目的のスライドをクローン
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # 変更されたプレゼンテーションをディスクに保存
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **別のプレゼンテーションの末尾にスライドをクローンする**

あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存スライドの末尾に挿入したい場合:

1. クローン元となるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドを追加する先のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 先のプレゼンテーションの [Presentation] オブジェクトの [getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) が返すスライドコレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addClone) メソッドを呼び出し、ソースプレゼンテーションからのスライドをパラメータとして渡します。
1. 変更された先のプレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドを先のプレゼンテーションの末尾にクローンしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# ソースプレゼンテーションファイルをロードするために Presentation クラスをインスタンス化
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
    destination_presentation = Presentation()
    try:
        # ソースプレゼンテーションから目的のスライドを先のプレゼンテーションのスライドコレクションの末尾にクローン
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # 先のプレゼンテーションをディスクに保存
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **別のプレゼンテーションの別の位置にスライドをクローンする**

あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの特定の位置に使用したい場合:

1. ソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドを追加する先のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 先のプレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトが公開する [insertClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertClone) メソッドを呼び出し、ソースプレゼンテーションからのスライドと目的の位置をパラメータとして渡します。
1. 変更された先のプレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドを先のプレゼンテーションのインデックス 1（位置 2）にクローンしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# ソースプレゼンテーションファイルをロードするために Presentation クラスをインスタンス化
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
    destination_presentation = Presentation()
    try:
        # ソースプレゼンテーションから目的のスライドを先のプレゼンテーションの指定インデックスにクローン
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # 先のプレゼンテーションをディスクに保存
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **マスタースライドと共にスライドを別のプレゼンテーションにクローンする**

マスタースライドを含むスライドを別のプレゼンテーションにクローンしたい場合、まずソースプレゼンテーションから目的のマスタースライドを先のプレゼンテーションにクローンする必要があります。その後、スライドをクローンする際にクローン化されたマスタースライドを使用します。[addClone] メソッドは、ソースプレゼンテーションではなく先のプレゼンテーションのマスタースライドを期待します。マスタースライド付きでスライドをクローンする手順は以下の通りです:

1. ソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 先のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. クローン対象のスライドとそのマスタースライドにアクセスします。
1. 先のプレゼンテーションの [Presentation] オブジェクトが公開する Masters コレクションを参照して、[MasterSlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/) オブジェクトを取得します。
1. [MasterSlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/#addClone) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメータとして渡します。
1. 先のプレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addClone) メソッドを呼び出し、ソースプレゼンテーションからのスライドとマスタースライドをパラメータとして渡します。
1. 変更された先のプレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス 0 にあるマスタースライドを使用して、スライドを先のプレゼンテーションの末尾にクローンしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# ソースプレゼンテーションファイルをロードするために Presentation クラスをインスタンス化
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # スライドをクローンする先のプレゼンテーション用に Presentation クラスをインスタンス化（スライドがクローンされる先）
    destination_presentation = Presentation()
    try:
        # ソースプレゼンテーションのスライドコレクションからスライドをインスタンス化し、
        # マスタースライドも取得
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # ソースプレゼンテーションから目的のマスタースライドを先のプレゼンテーションのマスターコレクションにクローン
        # 先のプレゼンテーション
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # ソースプレゼンテーションの目的スライドを目的のマスターと共に先のプレゼンテーションのスライドコレクションの末尾にクローン
        # 先のプレゼンテーションのスライドコレクション
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # 先のプレゼンテーションをディスクに保存
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **指定セクションの末尾にスライドをクローンする**

同じプレゼンテーション内で別のセクションにスライドをクローンして使用したい場合は、[**addClone**](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addClone) メソッドを使用します。Aspose.Slides for Python via Java は、最初のセクションからスライドをクローンし、同じプレゼンテーションの第二セクションに挿入することを可能にします。

以下のコードスニペットは、スライドをクローンして指定セクションに挿入する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # 先のプレゼンテーションをディスクに保存
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **スライドサイズの一致を保証する**

スライドを別のプレゼンテーションにクローンする際は、宛先プレゼンテーションのスライドサイズがソースと同じであることを確認してください。サイズが異なる場合、Aspose.Slides はクローンされた図形のサイズを自動的に再スケールせず、元の座標と寸法が保持されるため、コンテンツがずれたりスライド境界を超えて表示されることがあります。

クローンする前に、宛先プレゼンテーションのスライドサイズをソースに合わせて設定できます:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

クローンする前に、マスターとスライドのサイズを設定してください。

## **FAQ**

**スピーカーノートやレビュアーコメントはクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に [それらを削除する](/slides/ja/python-java/presentation-notes/)。

**チャートとそのデータソースはどのように扱われますか？**

チャートオブジェクト、書式設定、および埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みワークブック）にリンクされている場合、そのリンクは [OLE オブジェクト](/slides/ja/python-java/manage-ole/) として保持されます。ファイル間で移動した後、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、選択した [セクション](/slides/ja/python-java/slide-section/) に配置できます。対象のセクションが存在しない場合は、先に作成してからスライドを移動してください。