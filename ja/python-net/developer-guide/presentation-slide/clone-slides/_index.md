---
title: Python で PowerPoint スライドをクローンする
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
description: "Aspose.Slides for Python via .NET を使用して PowerPoint スライドを迅速にクローンまたは複製します。明確なコード例とヒントに従って、数秒で PPT 作成を自動化し、生産性を向上させ、手作業を排除します。"
---
## **イントロダクション**

クローンとは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides では、任意のスライドをコピー (クローン) し、そのクローンされたスライドを現在のプレゼンテーションまたは別の開いているプレゼンテーションに挿入することができます。スライドのクローン作成により、元のスライドに影響を与えることなく、開発者が変更できる新しいスライドが作成されます。スライドをクローンする方法は複数あります。

- プレゼンテーションの末尾にクローンする。
- プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの末尾にクローンする。
- 別のプレゼンテーションの別の位置にクローンする。
- 別のプレゼンテーションの特定の位置にクローンする。

Aspose.Slides for Python via .NET では、[スライドコレクション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) を公開している [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトが、これらのスライドクローン操作を実行するための `add_clone` と `insert_clone` メソッドを提供します。

## **インストール**

```bash
pip install aspose.slides
```

## **同じプレゼンテーション内で末尾にクローンする**

同じプレゼンテーション内でスライドをクローンし、既存のスライドの末尾に追加したい場合は `add_clone` メソッドを使用します。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトからスライドコレクションを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `add_clone` メソッドを呼び出し、クローンするスライドを渡します。
1. 変更されたプレゼンテーションを保存します。

以下の例では、最初のスライド (インデックス 0) がクローンされ、プレゼンテーションの末尾に追加されます。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンします。
    presentation.slides.add_clone(presentation.slides[0])
    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **同じプレゼンテーション内の特定の位置にクローンする**

同じプレゼンテーション内でスライドをクローンし、別の位置に配置したい場合は `insert_clone` メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトからスライドコレクションを取得します。
1. [SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `insert_clone` メソッドを呼び出し、クローンするスライドと新しい位置のインデックスを渡します。
1. 変更されたプレゼンテーションを保存します。

以下の例では、インデックス 1 (位置 2) のスライドがインデックス 2 (位置 3) にクローンされます。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 同じプレゼンテーション内の指定された位置 (インデックス) に目的のスライドをクローンします。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **別のプレゼンテーションの末尾にクローンする**

あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの末尾に追加したい場合の手順です。

1. ソースプレゼンテーション (クローン対象スライドが含まれる) 用に [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーション (スライドを追加する先) 用に [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションからスライドコレクションを取得します。
1. 宛先 [SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `add_clone` を呼び出し、ソースプレゼンテーションのスライドを渡します。
1. 変更された宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドが宛先プレゼンテーションの末尾にクローンされます。

```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # スライドがクローンされる先の PPTX 用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as target_presentation:
        # ソース プレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションのスライドコレクションの末尾にクローンします。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 宛先プレゼンテーションをディスクに保存します。
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **別のプレゼンテーション内の特定の位置にクローンする**

あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの特定の位置に挿入したい場合の手順です。

1. ソースプレゼンテーション用に [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーション用に [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションからスライドコレクションを取得します。
1. 宛先 [SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `insert_clone` メソッドを呼び出し、ソースプレゼンテーションのスライドと目的のインデックスを渡します。
1. 変更された宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドが宛先プレゼンテーションのインデックス 2 (位置 3) にクローンされます。

```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # スライドがクローンされる先の PPTX 用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # ソースの最初のスライドを宛先プレゼンテーションのインデックス 2 にクローンとして挿入します。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 宛先プレゼンテーションをディスクに保存します。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **マスタースライド付きスライドを別のプレゼンテーションにクローンする**

マスタースライド付きのスライドを別のプレゼンテーションで使用したい場合、まずソースプレゼンテーションから必要なマスタースライドを宛先プレゼンテーションにクローンします。その後、クローンしたマスターを使用してスライドをクローンします。`add_clone(Slide, MasterSlide)` メソッドは、**ソースではなく宛先プレゼンテーションのマスタースライド** を受け取ります。

マスタースライド付きスライドをクローンする手順:

1. ソースプレゼンテーション用に [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 宛先プレゼンテーション用に [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. クローン対象のソーススライドとそのマスタースライドにアクセスします。
1. 宛先プレゼンテーションのマスターコレクションから [MasterSlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/) を取得します。
1. 宛先 [MasterSlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/) で `add_clone` を呼び出し、ソースマスターをクローンして宛先に追加します。
1. 宛先プレゼンテーションのスライドコレクションから [SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) を取得します。
1. 宛先 [SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) で `add_clone` を呼び出し、ソーススライドとクローンした宛先マスターを渡します。
1. 変更された宛先プレゼンテーションを保存します。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドが、ソースからクローンしたマスターを使用して宛先プレゼンテーションの末尾にクローンされます。

```py
import aspose.slides as slides

# ソース プレゼンテーション ファイルを表すために Presentation クラスのインスタンスを作成します。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # スライドがクローンされる先のプレゼンテーション用に Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as target_presentation:
        # ソース プレゼンテーションから最初のスライドを取得します。
        source_slide = source_presentation.slides[0]
        # 最初のスライドで使用されているマスタースライドを取得します。
        source_master = source_slide.layout_slide.master_slide
        # マスタースライドを宛先プレゼンテーションのマスターコレクションにクローンします。
        cloned_master = target_presentation.masters.add_clone(source_master)
        # クローンしたマスターを使用して、ソース プレゼンテーションのスライドを宛先プレゼンテーションの末尾にクローンします。
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # 宛先プレゼンテーションをディスクに保存します。
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **指定セクションの末尾にクローンする**

Aspose.Slides for Python via .NET では、プレゼンテーションのあるセクションからスライドをクローンし、同じプレゼンテーション内の別のセクションに挿入することができます。その際は [SlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) クラスの `add_clone(Slide, Section)` メソッドを使用します。

以下の Python 例は、スライドをクローンして指定セクションに挿入する方法を示しています。

```py
import aspose.slides as slides

# 新しい空白のプレゼンテーションを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドのレイアウトに基づいて空のスライドを追加します。
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 新しいスライドに楕円形シェイプを追加します。このスライドは後でクローンされます。
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 最初のスライドのレイアウトに基づいて別の空のスライドを追加します。
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # "Section2" という名前のセクションを作成し、slide2 から開始します。
    section = presentation.sections.add_section("Section2", slide2)
    # 以前に作成したスライドを "Section2" セクションにクローンします。
    presentation.slides.add_clone(slide, section)
    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドサイズの一致を確保する**

スライドを別のプレゼンテーションにクローンする場合、宛先プレゼンテーションのスライドサイズがソースと同じであることを確認してください。サイズが異なると、Aspose.Slides はクローンされたシェイプのサイズを自動的に再スケーリングせず、元の座標と寸法が保持されたままになるため、コンテンツがずれたりスライド境界を超えて表示されたりする可能性があります。

マスターとスライドをクローンする前に、宛先プレゼンテーションのスライドサイズをソースに合わせて設定できます。

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

クローンする前にマスターとスライドのサイズを合わせてください。

## **FAQ**

**スピーカーノートやレビューコメントはクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に [remove them](/slides/ja/python-net/presentation-notes/) してください。

**チャートとそのデータソースはどのように扱われますか？**

チャートオブジェクト、書式設定、および埋め込みデータはコピーされます。チャートが外部ソース (例: OLE 埋め込みワークブック) にリンクされている場合、そのリンクは [OLE object](/slides/ja/python-net/manage-ole/) として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、選択した [section](/slides/ja/python-net/slide-section/) に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。