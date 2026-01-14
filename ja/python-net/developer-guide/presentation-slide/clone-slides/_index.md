---
title: PythonでPowerPointスライドをクローンする
linktitle: スライドをクローン
type: docs
weight: 40
url: /ja/python-net/clone-slides/
keywords:
- スライドをクローン
- スライドをコピー
- スライドを保存
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint スライドを迅速にクローンまたは複製します。明確なコード例とヒントに従って、数秒で PPT の作成を自動化し、生産性を向上させ、手作業を排除しましょう。"
---

## **概要**

クローンとは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides for Python via .NET を使用すると、任意のスライドをクローンし、そのクローンを現在のプレゼンテーションまたは別の開いているプレゼンテーションに挿入できます。クローン作成プロセスにより、元のスライドに影響を与えずに変更できる新しいスライドが作成されます。

スライドをクローンする方法はいくつかあります:

- 同一プレゼンテーション内でスライドを最後にクローンする。
- 同一プレゼンテーション内でスライドを特定の位置にクローンする。
- 別のプレゼンテーションの最後にスライドをクローンする。
- 別のプレゼンテーションの特定の位置にスライドをクローンする。
- マスタースライドを含むスライドを別のプレゼンテーションにクローンする。

Aspose.Slides for Python via .NET では、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトが公開する[スライド コレクション](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)が、`add_clone` と `insert_clone` メソッドを提供し、これらのスライド クローン操作を実行できます。

## **同一プレゼンテーション内で最後にクローン**

同一プレゼンテーション内でスライドをクローンし、既存のスライドの最後に追加したい場合は、`add_clone` メソッドを使用します。手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトからスライド コレクションを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) の `add_clone` メソッドを呼び出し、クローン対象のスライドを渡します。
1. 変更されたプレゼンテーションを保存します。

以下の例では、最初のスライド（インデックス 0）がクローンされ、プレゼンテーションの最後に追加されます。
```py
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンします。
    presentation.slides.add_clone(presentation.slides[0])
    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **同一プレゼンテーション内で特定の位置にクローン**

同一プレゼンテーション内でスライドをクローンし、別の位置に配置したい場合は、`insert_clone` メソッドを使用します:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトからスライド コレクションを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) の `insert_clone` メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスを渡します。
1. 変更されたプレゼンテーションを保存します。

以下の例では、インデックス 0（位置 1）のスライドがインデックス 1（位置 2）にクローンされます。
```py
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 同じプレゼンテーション内の指定位置（インデックス）に目的のスライドをクローンします。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **別のプレゼンテーションの最後にクローン**

あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの最後に追加したい場合:

1. ソース プレゼンテーション（クローン対象のスライドが含まれる）の [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先 プレゼンテーション（スライドを追加する先）の [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションからスライド コレクションを取得します。
1. 宛先の [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) で `add_clone` を呼び出し、ソースプレゼンテーションのスライドを渡します。
1. 変更された宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドが宛先プレゼンテーションの最後にクローンされます。
```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # スライドがクローンされる先の PPTX 用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as target_presentation:
        # ソース プレゼンテーションから目的のスライドを取得し、先のプレゼンテーションのスライドコレクションの末尾にクローンします。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 先のプレゼンテーションをディスクに保存します。
        target_presentation.save("Asp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **別のプレゼンテーションの特定の位置にクローン**

あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの指定位置に挿入したい場合:

1. ソース プレゼンテーション（クローン対象のスライドが含まれる）の [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先 プレゼンテーション（スライドを追加する先）の [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションからスライド コレクションを取得します。
1. 宛先の [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) で `insert_clone` を呼び出し、ソースプレゼンテーションのスライドと目的インデックスを渡します。
1. 変更された宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドが宛先プレゼンテーションのインデックス 1（位置 2）にクローンされます。
```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # スライドをクローンする先の PPTX 用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # 宛先プレゼンテーションのインデックス 2 に、ソースの最初のスライドのクローンを挿入します。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 宛先プレゼンテーションをディスクに保存します。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **マスタースライドを含むスライドを別のプレゼンテーションにクローン**

スライド **とそのマスター** を別のプレゼンテーションにクローンして使用する必要がある場合、まずソースプレゼンテーションから必要なマスタースライドを宛先プレゼンテーションにクローンします。その後、宛先のマスターを使用してスライドをクローンします。`add_clone(Slide, MasterSlide)` メソッドは、**ソースではなく宛先プレゼンテーションのマスタースライド** を受け取ります。

マスタースライドを含むスライドをクローンする手順:

1. ソース プレゼンテーション（クローン対象のスライドが含まれる）の [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先 プレゼンテーションの [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. クローン対象のソーススライドとそのマスタースライドにアクセスします。
1. 宛先プレゼンテーションのマスター コレクションから [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) を取得します。
1. 宛先の [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) で `add_clone` を呼び出し、ソースマスターをクローンして宛先に追加します。
1. 宛先プレゼンテーションのスライド コレクションから [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) を取得します。
1. 宛先の [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) で `add_clone` を呼び出し、ソーススライドとクローンされた宛先マスターを渡します。
1. 変更された宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドが、ソースからクローンされたマスターを使用して宛先プレゼンテーションの最後にクローンされます。
```py
import aspose.slides as slides

# ソースプレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # スライドがクローンされる宛先プレゼンテーションのために Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as target_presentation:
        # ソースプレゼンテーションから最初のスライドを取得します。
        source_slide = source_presentation.slides[0]
        # 最初のスライドが使用しているマスタースライドを取得します。
        source_master = source_slide.layout_slide.master_slide
        # マスタースライドを宛先プレゼンテーションのマスターコレクションにクローンします。
        cloned_master = target_presentation.masters.add_clone(source_master)
        # クローンされたマスターを使用して、ソースプレゼンテーションのスライドを宛先プレゼンテーションの末尾にクローンします。
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # 宛先プレゼンテーションをディスクに保存します。
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **指定セクションの最後にクローン**

Aspose.Slides for Python via .NET を使用すると、プレゼンテーションのあるセクションからスライドをクローンし、同一プレゼンテーション内の別のセクションに挿入できます。これには、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) クラスの `add_clone(Slide, Section)` メソッドを使用します。

以下の Python 例は、スライドをクローンし、指定セクションにクローンを挿入する方法を示しています:
```py
import aspose.slides as slides

# 新しい空白のプレゼンテーションを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドのレイアウトに基づいた空のスライドを追加します。
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 新しいスライドに楕円形を追加します; このスライドは後でクローンされます。
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 最初のスライドのレイアウトに基づいた別の空のスライドを追加します。
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # slide2 から始まる "Section2" セクションを作成します。
    section = presentation.sections.add_section("Section2", slide2)
    # 先に作成したスライドを "Section2" セクションにクローンします。
    presentation.slides.add_clone(slide, section)
    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **よくある質問**

**スピーカーノートやレビュアーコメントもクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に[削除する](/slides/ja/python-net/presentation-notes/)ことができます。

**チャートとそのデータ ソースはどう扱われますか？**

チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みブック）にリンクされている場合、そのリンクは[OLE オブジェクト](/slides/ja/python-net/manage-ole/)として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライド インデックスにクローンを挿入し、選択した[セクション](/slides/ja/python-net/slide-section/)に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。