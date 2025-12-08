---
title: Python で PowerPoint スライドをクローンする
linktitle: スライドをクローン
type: docs
weight: 40
url: /ja/python-net/clone-slides/
keywords:
- スライドのクローン
- スライドのコピー
- スライドの保存
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint スライドを素早くクローンまたは複製します。明確なコード例とヒントに従って、数秒で PPT 作成を自動化し、生産性を向上させ、手作業を排除しましょう。"
---

## **概要**

クローン作成は、何かを正確にコピーまたはレプリカを作成するプロセスです。Aspose.Slides for Python via .NET を使用すると、任意のスライドをクローンし、そのクローンを現在のプレゼンテーションまたは別の開いているプレゼンテーションに挿入できます。クローン作成プロセスにより、新しいスライドが作成され、元のスライドに影響を与えることなく変更できます。

スライドをクローンする方法はいくつかあります。

- 同一プレゼンテーション内の末尾にスライドをクローンする。
- 同一プレゼンテーション内の特定の位置にスライドをクローンする。
- 別のプレゼンテーションの末尾にスライドをクローンする。
- 別のプレゼンテーションの特定の位置にスライドをクローンする。
- マスタースライドとともにスライドを別のプレゼンテーションにクローンする。

Aspose.Slides for Python via .NET では、[スライドコレクション](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) を提供する [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトが、`add_clone` と `insert_clone` メソッドを使用してこれらのスライドクローン操作を行います。

## **同一プレゼンテーション内の末尾にクローンする**

同一プレゼンテーション内でスライドをクローンし、既存のスライドの末尾に追加したい場合は、`add_clone` メソッドを使用します。手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトからスライドコレクションを取得します。
1. クローン対象のスライドを指定して、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) の `add_clone` メソッドを呼び出します。
1. 変更したプレゼンテーションを保存します。

以下の例では、最初のスライド（インデックス 0）をクローンし、プレゼンテーションの末尾に追加しています。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンします。
    presentation.slides.add_clone(presentation.slides[0])
    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **同一プレゼンテーション内の特定位置にクローンする**

同一プレゼンテーション内でスライドをクローンし、別の位置に配置したい場合は、`insert_clone` メソッドを使用します。

1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトからスライドコレクションを取得します。
1. クローン対象のスライドと新しい位置のインデックスを指定して、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) の `insert_clone` メソッドを呼び出します。
1. 変更したプレゼンテーションを保存します。

以下の例では、インデックス 0（位置 1）のスライドをインデックス 1（位置 2）にクローンしています。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 同じプレゼンテーション内の指定された位置（インデックス）に目的のスライドをクローンします。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **別のプレゼンテーションの末尾にクローンする**

別のプレゼンテーションからスライドをクローンし、そのプレゼンテーションの末尾に追加したい場合は次の手順です。

1. ソースプレゼンテーション（クローン対象スライドが含まれる）用に [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。
1. 宛先プレゼンテーション（スライドを追加する先）用に [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。
1. 宛先プレゼンテーションからスライドコレクションを取得します。
1. 宛先の [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) で `add_clone` を呼び出し、ソースプレゼンテーションのスライドを渡します。
1. 変更した宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドを宛先プレゼンテーションの末尾にクローンしています。
```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # スライドをクローンする先の PPTX（宛先プレゼンテーション）用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as target_presentation:
        # ソース プレゼンテーションから目的のスライドを宛先プレゼンテーションのスライドコレクションの末尾にクローンします。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 宛先プレゼンテーションをディスクに保存します。
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **別のプレゼンテーションの特定位置にクローンする**

別のプレゼンテーションからスライドをクローンし、特定の位置に挿入したい場合は次の手順です。

1. ソースプレゼンテーション（クローン対象スライドが含まれる）用に [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。
1. 宛先プレゼンテーション（スライドを追加する先）用に [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。
1. 宛先プレゼンテーションからスライドコレクションを取得します。
1. 宛先の [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) で `insert_clone` を呼び出し、ソーススライドと目的インデックスを渡します。
1. 変更した宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドを宛先プレゼンテーションのインデックス 1（位置 2）にクローンしています。
```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 宛先 PPTX（スライドをクローンする場所）用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # ソース の最初のスライドのクローンを宛先プレゼンテーションのインデックス 2 に挿入します。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 宛先プレゼンテーションをディスクに保存します。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **マスタースライドとともに別のプレゼンテーションへクローンする**

マスタースライドとともにスライドを別のプレゼンテーションにクローンして使用する必要がある場合、まずソースプレゼンテーションから必要なマスタースライドを宛先プレゼンテーションにクローンします。その後、クローンした宛先マスタースライドを使用してスライドをクローンします。`add_clone(Slide, MasterSlide)` メソッドは、**ソースではなく宛先プレゼンテーションのマスタースライド** を受け取ります。

マスタースライド付きでスライドをクローンする手順は次のとおりです。

1. ソースプレゼンテーション用に [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。
1. 宛先プレゼンテーション用に [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。
1. クローン対象のソーススライドとそのマスタースライドにアクセスします。
1. 宛先プレゼンテーションのマスターコレクションから [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) を取得します。
1. 宛先の [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) で `add_clone` を呼び出し、ソースマスターをクローンして宛先に追加します。
1. 宛先プレゼンテーションのスライドコレクションから [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) を取得します。
1. 宛先の [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) で `add_clone` を呼び出し、ソーススライドとクローンした宛先マスターを渡します。
1. 変更した宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドを、ソースからクローンしたマスターを使用して宛先プレゼンテーションの末尾にクローンしています。
```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # スライドをクローンする先の宛先プレゼンテーション用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as target_presentation:
        # ソースプレゼンテーションから最初のスライドを取得します。
        source_slide = source_presentation.slides[0]
        # 最初のスライドが使用しているマスタースライドを取得します。
        source_master = source_slide.layout_slide.master_slide
        # マスタースライドを宛先プレゼンテーションのマスターコレクションにクローンします。
        cloned_master = target_presentation.masters.add_clone(source_master)
        # クローンしたマスターを使用して、ソースプレゼンテーションのスライドを宛先プレゼンテーションの末尾にクローンします。
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # 宛先プレゼンテーションをディスクに保存します。
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **指定セクションの末尾にクローンする**

Aspose.Slides for Python via .NET を使用すると、プレゼンテーション内のあるセクションからスライドをクローンし、同一プレゼンテーション内の別のセクションに挿入できます。そのためには、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) インターフェイスの `add_clone(Slide, Section)` メソッドを使用します。

以下の Python 例は、スライドをクローンして指定セクションに挿入する方法を示しています。
```py
import aspose.slides as slides

# Create a new blank presentation.
with slides.Presentation() as presentation:
    # 新しい空白のプレゼンテーションを作成します。
    # Add an empty slide based on the layout of the first slide.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 最初のスライドのレイアウトに基づいて空のスライドを追加します。
    # Add an ellipse shape to the new slide; this slide will be cloned later.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 新しいスライドに楕円形を追加します。このスライドは後でクローンされます。
    # Add another empty slide based on the layout of the first slide.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 最初のスライドのレイアウトに基づいて別の空のスライドを追加します。
    # Create a section named "Section2" that starts at slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # "Section2" という名前のセクションを作成し、slide2 から開始します。
    # Clone the previously created slide into the "Section2" section.
    presentation.slides.add_clone(slide, section)
    # 以前に作成したスライドを "Section2" セクションにクローンします。
    # Save the presentation as a PPTX file.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    # プレゼンテーションを PPTX ファイルとして保存します。
```


## **FAQ**

**スピーカーノートやレビュアーコメントもクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に[削除してください](/slides/ja/python-net/presentation-notes/)。

**チャートとデータ ソースはどのように扱われますか？**

チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みブック）にリンクされている場合、そのリンクは[OLE オブジェクト](/slides/ja/python-net/manage-ole/)として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、選択した[セクション](/slides/ja/python-net/slide-section/)に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。