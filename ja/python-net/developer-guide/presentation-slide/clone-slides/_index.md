---
title: Python で PowerPoint スライドを複製する
linktitle: スライドを複製する
type: docs
weight: 40
url: /ja/python-net/clone-slides/
keywords:
- スライドを複製
- スライドをコピー
- スライドを保存
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使えば、PowerPoint スライドを素早く複製・コピーできます。わかりやすいコード例とヒントに従って、数秒で PPT の作成を自動化し、生産性を高め、手作業を排除しましょう。"
---

## **プレゼンテーション内のスライドをクローンする**
クローンとは、何かの正確なコピーまたはレプリカを作成するプロセスです。Aspose.Slides for Python via .NETは、任意のスライドのコピーまたはクローンを作成し、現在のプレゼンテーションまたは他の開いているプレゼンテーションにそのクローンドスライドを挿入することを可能にします。スライドのクローンプロセスでは、元のスライドを変更せずに開発者が修正できる新しいスライドが作成されます。スライドをクローンするには、いくつかの方法があります：

- プレゼンテーションの末尾でクローンする。
- プレゼンテーション内の別の位置でクローンする。
- 別のプレゼンテーションの末尾でクローンする。
- 別のプレゼンテーションの別の位置でクローンする。
- 別のプレゼンテーションの特定の位置でクローンする。

Aspose.Slides for Python via .NETでは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)オブジェクトにより提供される（[Slide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)オブジェクトのコレクション）が、上記のタイプのスライドクローンを実行するための[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)および[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)メソッドを提供しています。

## **プレゼンテーション内の末尾でクローンする**
スライドをクローンして、既存のスライドの末尾で同じプレゼンテーションファイル内で使用したい場合は、以下の手順に従って[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドを使用します：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)オブジェクトによって提供されるスライドコレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)クラスをインスタンス化します。
2. [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)オブジェクトによって提供される[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドを呼び出し、クローンするスライドを[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドのパラメーターとして渡します。
3. 修正したプレゼンテーションファイルを書き込む。

以下の例では、プレゼンテーションの最初の位置（ゼロインデックス）にあるスライドをプレゼンテーションの末尾にクローンしました。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスをインスタンス化
with slides.Presentation(path + "CloneWithinSamePresentationToEnd.pptx") as pres:
    # 同じプレゼンテーション内のスライドのコレクションの末尾に希望のスライドをクローン
    slds = pres.slides

    slds.add_clone(pres.slides[0])

    # 修正したプレゼンテーションをディスクに書き込む
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **プレゼンテーション内の別の位置でクローンする**
スライドをクローンして、同じプレゼンテーションファイル内の別の位置で使用したい場合は、[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)メソッドを使用します：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)オブジェクトによって提供される**Slides**コレクションを参照して、そのクラスをインスタンス化します。
1. [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)オブジェクトによって提供される[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)メソッドを呼び出し、クローンするスライドと新しい位置のインデックスを[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)メソッドのパラメーターとして渡します。
1. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションのゼロインデックス（位置1）にあるスライドをインデックス1（位置2）にクローンしました。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスをインスタンス化
with slides.Presentation(path + "CloneWithInSamePresentation.pptx") as pres:
    # 同じプレゼンテーション内のスライドのコレクションの末尾に希望のスライドをクローン
    slds = pres.slides

    # 同じプレゼンテーション内の指定したインデックスに希望のスライドをクローン
    slds.insert_clone(2, pres.slides[1])

    # 修正したプレゼンテーションをディスクに書き込む
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **別のプレゼンテーションの末尾でクローンする**
別のプレゼンテーションからスライドをクローンし、既存のスライドの末尾にそのスライドを使用する必要がある場合：

1. スライドをクローンする元のプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. スライドを追加する先のプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. 先のプレゼンテーションのスライドコレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)クラスをインスタンス化します。
1. [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)オブジェクトによって提供される[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドを呼び出し、ソースプレゼンテーションのスライドを[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドのパラメーターとして渡します。
1. 修正した先のプレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションの最初のインデックスからスライドを先のプレゼンテーションの末尾にクローンしました。

```py
import aspose.slides as slides

# ソースプレゼンテーションファイルを読み込むためにPresentationクラスをインスタンス化
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # スライドがクローンされるための宛先PPTXのPresentationクラスをインスタンス化
    with slides.Presentation() as destPres:
        # 元のプレゼンテーションから希望のスライドを末尾にクローン
        slds = destPres.slides
        slds.add_clone(srcPres.slides[0])

        # 宛先プレゼンテーションをディスクに書き込む
        destPres.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **別のプレゼンテーションの別の位置でクローンする**
別のプレゼンテーションからスライドをクローンし、特定の位置にそのスライドを使用する必要がある場合：

1. スライドをクローンする元のプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. スライドを追加する宛先プレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. 宛先プレゼンテーションのスライドコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)クラスをインスタンス化します。
1. [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)オブジェクトによって提供される[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)メソッドを呼び出し、ソースプレゼンテーションからスライドをクローンし、希望の位置を[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)メソッドのパラメーターとして渡します。
1. 修正した宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスからスライドを宛先プレゼンテーションのインデックス1（位置2）にクローンしました。

```py
import aspose.slides as slides

# ソースプレゼンテーションファイルを読み込むためにPresentationクラスをインスタンス化
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # スライドがクローンされるための宛先PPTXのPresentationクラスをインスタンス化
    with slides.Presentation("Aspose2_out.pptx") as destPres:
        slds = destPres.slides
        slds.insert_clone(2, srcPres.slides[0])

        # 宛先プレゼンテーションをディスクに書き込む
        destPres.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **別のプレゼンテーションの特定の位置でクローンする**
元のプレゼンテーションのマスタースライド付きのスライドをクローンし、別のプレゼンテーションに使用する必要がある場合、元のプレゼンテーションから宛先プレゼンテーションに希望するマスタースライドを最初にクローンする必要があります。その後、マスタースライドを持つスライドのクローンに使用する必要があります。**add_clone(ISlide, IMasterSlide)**は、ソースプレゼンテーションからではなく、宛先プレゼンテーションのマスタースライドを期待します。マスター付きのスライドをクローンするには、以下の手順に従ってください：

1. スライドをクローンする元のプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. スライドをクローンする宛先プレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. クローンされるスライドとマスタースライドにアクセスします。
1. 宛先プレゼンテーションの[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)オブジェクトによって提供されるマスターコレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)クラスをインスタンス化します。
1. [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)オブジェクトによって提供される[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドを呼び出し、クローンするためのソースPPTXからのマスターを[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドのパラメーターとして渡します。
1. 宛先プレゼンテーションの[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)オブジェクトによって提供されるスライドコレクションへの参照を設定して、[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)クラスをインスタンス化します。
2. [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)オブジェクトによって提供される[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドを呼び出し、ソースプレゼンテーションからクローンするスライドとマスタースライドを[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドのパラメーターとして渡します。
3. 修正した宛先プレゼンテーションファイルを書き込みます。

以下の例では、元のプレゼンテーションのゼロインデックスにあるマスタースライドを持つスライドを宛先プレゼンテーションの末尾に、ソーススライドのマスタースライドを使用してクローンしました。

```py
import aspose.slides as slides

# ソースプレゼンテーションファイルを読み込むためにPresentationクラスをインスタンス化
with slides.Presentation(path + "CloneToAnotherPresentationWithMaster.pptx") as srcPres:
    # スライドがクローンされるための宛先プレゼンテーションのPresentationクラスをインスタンス化
    with slides.Presentation() as destPres:
        # ソースプレゼンテーション内のスライドコレクションからISlideをインスタンス化し、
        # マスタースライドを伴う
        sourceSlide = srcPres.slides[0]
        sourceMaster = sourceSlide.layout_slide.master_slide

        # 宛先プレゼンテーションのマスターコレクションにソースプレゼンテーションから希望のマスタースライドをクローン
        masters = destPres.masters
        destMaster = sourceSlide.layout_slide.master_slide

        # 宛先プレゼンテーションのマスターコレクションにソースプレゼンテーションから希望のマスタースライドをクローン
        iSlide = masters.add_clone(sourceMaster)

        # 宛先プレゼンテーションのスライドコレクションにおいて欲しいマスターを伴ってソースプレゼンテーションからスライドをクローン
        slds = destPres.slides
        slds.add_clone(sourceSlide, iSlide, True)
      
        # 宛先プレゼンテーションをディスクに書き込む
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## 指定されたセクションの末尾でクローンする

Aspose.Slides for Python via .NETを使用すると、プレゼンテーションの1つのセクションからスライドをクローンし、そのスライドを同じプレゼンテーションの別のセクションに挿入できます。この場合、[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)インターフェースから[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)メソッドを使用する必要があります。

このPythonコードは、スライドをクローンし、クローンしたスライドを指定されたセクションに挿入する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100) # クローンするために
    
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    section = pres.sections.add_section("Section2", slide2)

    pres.slides.add_clone(slide, section)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```