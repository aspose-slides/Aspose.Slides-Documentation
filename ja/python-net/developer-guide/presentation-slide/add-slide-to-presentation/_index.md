---
title: Pythonでプレゼンテーションにスライドを追加
linktitle: スライドの追加
type: docs
weight: 10
url: /ja/python-net/add-slide-to-presentation/
keywords:
- スライドの追加
- スライドの作成
- 空のスライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションにスライドを簡単に追加できます—シームレスで効率的なスライド挿入を数秒で実現します。"
---

## **概要**

プレゼンテーションにスライドを追加する前に、PowerPoint がスライドをどのように構成しているかを理解しておくと便利です。各プレゼンテーションにはマスタースライド、オプションのレイアウトスライド、そして 1 つ以上の通常スライドが含まれます。各スライドには一意の ID が付与され、通常スライドはゼロベースのインデックスで順序付けられます。この記事では、Aspose.Slides for Python を使用してスライドを作成し、適切なレイアウトを選択する方法を示します。

## **プレゼンテーションへのスライド追加**

Aspose.Slides を使用すると、既存のレイアウトスライドに基づいて新しいスライドを追加できます。以下の例は、プレゼンテーション内の各レイアウトを繰り返し処理し、そのレイアウトを使用したスライドを追加してからファイルを保存します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) にアクセスします。
3. `presentation.layout_slides` の各項目に対して `add_empty_slide` を呼び出し、そのレイアウトを使用したスライドを追加します。
4. 必要に応じて新しく追加したスライドを修正します。
5. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the slide collection.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Add an empty slide to the slide collection.
        slides.add_empty_slide(layout_slide)

    # Do some work on the newly added slides.

    # Save the presentation to disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**スライドを末尾ではなく特定の位置に挿入できますか？**

はい。ライブラリはスライドコレクションと [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) 操作をサポートしているため、末尾だけでなく必要なインデックスにスライドを追加できます。

**レイアウトに基づくスライドを追加すると、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトおよびそれに関連付けられたマスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションにはどのスライドが存在しますか？**

新規作成されたプレゼンテーションには、インデックス 0 の空白スライドが 1 枚すでに含まれています。挿入インデックスを計算するときに考慮が必要です。

**マスターに多数のレイアウトがある場合、新しいスライドに適切なレイアウトをどう選びますか？**

通常は、必要な構造（[Title and Content, Two Content など](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)）に合致する [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) を選択します。該当レイアウトが存在しない場合は、[マスターにレイアウトを追加](/slides/ja/python-net/slide-layout/)してから使用できます。