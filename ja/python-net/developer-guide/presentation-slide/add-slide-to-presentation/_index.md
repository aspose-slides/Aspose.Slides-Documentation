---
title: Pythonでプレゼンテーションにスライドを追加する
linktitle: スライドを追加
type: docs
weight: 10
url: /ja/python-net/add-slide-to-presentation/
keywords:
- スライドを追加
- スライドを作成
- 空のスライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションにスライドを簡単に追加できます。シームレスで効率的なスライド挿入が数秒で行えます。"
---

## **概要**

プレゼンテーションにスライドを追加する前に、PowerPoint がそれらをどのように整理しているかを理解すると役立ちます。各プレゼンテーションにはマスタースライド、オプションのレイアウトスライド、そして 1 つ以上の通常スライドが含まれます。すべてのスライドには一意の ID が割り当てられ、通常スライドはゼロベースのインデックスで順序付けられます。この記事では、Aspose.Slides for Python を使用してスライドを作成し、適切なレイアウトを選択する方法を示します。

## **プレゼンテーションへのスライド追加**

Aspose.Slides を使用すると、既存のレイアウトスライドに基づいて新しいスライドを追加できます。以下の例では、プレゼンテーション内の各レイアウトを反復処理し、そのレイアウトを使用したスライドを追加してからファイルを保存します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) にアクセスします。
1. `presentation.layout_slides` の各項目について、`add_empty_slide` を呼び出してそのレイアウトを使用したスライドを追加します。
1. 必要に応じて新しく追加したスライドを変更します。
1. プレゼンテーションを PPTX ファイルとして保存します。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを生成します。
with slides.Presentation() as presentation:
    # スライドコレクションにアクセスします。
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # スライドコレクションに空のスライドを追加します。
        slides.add_empty_slide(layout_slide)

    # 新しく追加されたスライドで何らかの処理を行います。

    # プレゼンテーションをディスクに保存します。
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```


## **よくある質問**

**特定の位置に新しいスライドを挿入できますか？末尾だけではありませんか？**

はい。ライブラリはスライドコレクションと [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) 操作をサポートしているため、末尾だけでなく必要なインデックスにスライドを追加できます。

**レイアウトに基づくスライドを追加すると、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトおよび関連するマスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションにはどのスライドが存在しますか？**

新しく作成されたプレゼンテーションには、インデックス 0 の空白スライドが既に 1 枚含まれています。これは挿入インデックスを計算する際に考慮すべき重要な点です。

**マスターに多数のオプションがある場合、どのレイアウトを新しいスライドに選択すればよいですか？**

通常は、必要な構造（[Title and Content、Two Content など](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)）に一致する [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) を選択します。そのようなレイアウトが存在しない場合は、[add it to the master](/slides/ja/python-net/slide-layout/) でマスターに追加し、使用してください。