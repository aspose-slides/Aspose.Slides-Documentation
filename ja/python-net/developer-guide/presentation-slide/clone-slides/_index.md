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
description: "Python via .NET 用 Aspose.Slides で PowerPoint スライドをすばやくクローンまたは複製します。明確なコード例とヒントに従って、数秒で PPT 作成を自動化し、生産性を向上させ、手作業を排除しましょう。"
---
## **はじめに**

クローン作成は、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides でも任意のスライドをコピー（クローン）し、クローンしたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入できます。スライドのクローン作成により、元のスライドに影響を与えることなく開発者が変更できる新しいスライドが作成されます。スライドをクローンする方法はいくつかあります。

- プレゼンテーションの末尾にクローンを作成する。
- プレゼンテーション内の別の位置にクローンを作成する。
- 別のプレゼンテーションの末尾にクローンを作成する。
- 別のプレゼンテーションの別の位置にクローンを作成する。
- 別のプレゼンテーションの特定の位置にクローンを作成する。

Aspose.Slides for Python via .NET では、[スライド コレクション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) が[プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトによって公開され、`add_clone` と `insert_clone` メソッドでこれらのスライド クローン作成を行えます。

## **インストール**

```bash
pip install aspose.slides
```

## **同一プレゼンテーション内で末尾にクローン**

同一プレゼンテーション内でスライドをクローンし、既存のスライドの末尾に追加したい場合は、`add_clone` メソッドを使用します。以下の手順に従ってください。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトからスライドコレクションを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `add_clone` メソッドを呼び出し、クローンするスライドを渡します。
1. 変更されたプレゼンテーションを保存します。

以下の例では、最初のスライド（インデックス 0）をクローンし、プレゼンテーションの末尾に追加します。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンします。
    presentation.slides.add_clone(presentation.slides[0])
    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **同一プレゼンテーション内の特定位置にクローン**

同一プレゼンテーション内でスライドをクローンし、別の位置に配置したい場合は、`insert_clone` メソッドを使用します。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトからスライドコレクションを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `insert_clone` メソッドを呼び出し、クローンするスライドと新しい位置のインデックスを渡します。
1. 変更されたプレゼンテーションを保存します。

以下の例では、インデックス 1（2 番目）のスライドをインデックス 2（3 番目）にクローンします。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 同じプレゼンテーション内の指定された位置（インデックス）に目的のスライドをクローンします。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **別のプレゼンテーションの末尾にクローン**

あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの末尾に追加したい場合:

1. ソースプレゼンテーション（クローン元スライドが含まれる）のために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーション（スライドを追加する先）のために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションからスライドコレクションを取得します。
1. 宛先[SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `add_clone` を呼び出し、ソースプレゼンテーションのスライドを渡します。
1. 変更された宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドを宛先プレゼンテーションの末尾にクローンします。

```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # デスティネーション PPTX（スライドがクローンされる場所）のための Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as target_presentation:
        # ソース プレゼンテーションから目的のスライドをデスティネーション プレゼンテーションのスライドコレクションの末尾にクローンします。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # デスティネーション プレゼンテーションをディスクに保存します。
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **別のプレゼンテーションの特定位置にクローン**

あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの特定の位置に挿入したい場合:

1. ソースプレゼンテーション（クローン元スライドが含まれる）のために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーション（スライドを追加する先）のために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションからスライドコレクションを取得します。
1. 宛先[SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `insert_clone` メソッドを呼び出し、ソースプレゼンテーションのスライドと目的のインデックスを渡します。
1. 変更された宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドを宛先プレゼンテーションのインデックス 2（3 番目）にクローンします。

```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # スライドをクローンする先のデスティネーション PPTX 用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # ソースの最初のスライドをデスティネーション プレゼンテーションのインデックス 2 にクローンとして挿入します。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # デスティネーション プレゼンテーションをディスクに保存します。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドとマスタースライドを別のプレゼンテーションにクローン**

スライド **とそのマスター** を別のプレゼンテーションにクローンして使用する必要がある場合、まず必要なマスタースライドをソースプレゼンテーションから宛先プレゼンテーションにクローンします。その後、スライドをクローンする際にその宛先マスターを使用します。`add_clone(Slide, MasterSlide)` メソッドは、**ソースではなく宛先プレゼンテーションのマスタースライド** を期待します。

スライドとマスタースライドをクローンする手順:

1. ソースプレゼンテーション（クローン元スライドが含まれる）のために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションのために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. クローン対象のソーススライドとそのマスタースライドにアクセスします。
1. 宛先プレゼンテーションのマスタコレクションから[マスタースライドコレクション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/) を取得します。
1. 宛先[マスタースライドコレクション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/) で `add_clone` を呼び出し、ソースマスターをクローンして宛先に追加します。
1. 宛先プレゼンテーションのスライドコレクションから[SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) を取得します。
1. 宛先[SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `add_clone` を呼び出し、ソーススライドとクローンされた宛先マスターを渡します。
1. 変更された宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドを、ソースからクローンしたマスターを使用して宛先プレゼンテーションの末尾にクローンします。

```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # スライドがクローンされる先のデスティネーション プレゼンテーション用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as target_presentation:
        # ソース プレゼンテーションから最初のスライドを取得します。
        source_slide = source_presentation.slides[0]
        # 最初のスライドが使用しているマスタースライドを取得します。
        source_master = source_slide.layout_slide.master_slide
        # デスティネーション プレゼンテーションのマスタコレクションにマスタースライドをクローンします。
        cloned_master = target_presentation.masters.add_clone(source_master)
        # クローンしたマスタースライドを使用して、ソース プレゼンテーションからスライドをデスティネーション プレゼンテーションの末尾にクローンします。
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # デスティネーション プレゼンテーションをディスクに保存します。
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **指定されたセクションの末尾にクローン**

Aspose.Slides for Python via .NET を使用すると、プレゼンテーションのあるセクションからスライドをクローンし、同じプレゼンテーション内の別のセクションに挿入できます。その際、[SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) クラスの `add_clone(Slide, Section)` メソッドを使用します。

以下の Python 例は、スライドをクローンし、クローンを指定されたセクションに挿入する方法を示しています。

```py
import aspose.slides as slides

# 新しい空白のプレゼンテーションを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドのレイアウトに基づいて空のスライドを追加します。
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 新しいスライドに楕円形を追加します；このスライドは後でクローンされます。
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 最初のスライドのレイアウトに基づいて別の空のスライドを追加します。
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # slide2 から開始する「Section2」という名前のセクションを作成します。
    section = presentation.sections.add_section("Section2", slide2)
    # 前に作成したスライドを「Section2」セクションにクローンします。
    presentation.slides.add_clone(slide, section)
    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

### スピーカーノートやレビュアーコメントもクローンされますか？

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に[削除する](/slides/ja/python-net/presentation-notes/)ことができます。

### グラフとそのデータソースはどう扱われますか？

グラフオブジェクト、書式設定、埋め込みデータはコピーされます。グラフが外部ソース（例: OLE 埋め込みブック）にリンクされている場合、そのリンクは[OLE オブジェクト](/slides/ja/python-net/manage-ole/)として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

### クローンの挿入位置やセクションを制御できますか？

はい。スライドインデックスを指定してクローンを挿入したり、選択した[セクション](/slides/ja/python-net/slide-section/)に配置したりできます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。