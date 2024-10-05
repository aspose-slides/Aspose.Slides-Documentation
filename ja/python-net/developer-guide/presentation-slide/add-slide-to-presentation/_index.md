---
title: プレゼンテーションにスライドを追加する
type: docs
weight: 10
url: /python-net/add-slide-to-presentation/
keywords: "プレゼンテーションにスライドを追加, Python, Aspose.Slides"
description: "Pythonでプレゼンテーションにスライドを追加する"
---

## **プレゼンテーションにスライドを追加する**
プレゼンテーションファイルにスライドを追加することについて話す前に、スライドに関するいくつかの事実を説明しましょう。各PowerPointプレゼンテーションファイルには、マスター/レイアウトスライドとその他の通常スライドが含まれています。つまり、プレゼンテーションファイルには少なくとも1つ以上のスライドが含まれています。スライドのないプレゼンテーションファイルは、Aspose.Slides for Python via .NETではサポートされていないことを知っておくことが重要です。各スライドには一意のIDがあり、すべての通常スライドはゼロベースのインデックスで指定された順序で配置されています。Aspose.Slides for Python via .NETでは、開発者がプレゼンテーションに空のスライドを追加することができます。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- Presentationオブジェクトが公開するSlides（コンテンツスライドオブジェクトのコレクション）プロパティを参照して[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)クラスのインスタンスを生成します。
- ISlideCollectionオブジェクトによって公開されるAddEmptySlideメソッドを呼び出して、コンテンツスライドコレクションの最後に空のスライドを追加します。
- 新しく追加された空のスライドで作業を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)オブジェクトを使用してプレゼンテーションファイルを書き込みます。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成します
with slides.Presentation() as pres:
    # SlideCollectionクラスのインスタンスを生成します
    slds = pres.slides

    for i in range(len(pres.layout_slides)):
        # Slidesコレクションに空のスライドを追加します
        slds.add_empty_slide(pres.layout_slides[i])
        
    # 新しく追加したスライドで作業を行います

    # PPTXファイルをディスクに保存します
    pres.save("EmptySlide.pptx", slides.export.SaveFormat.PPTX)
```