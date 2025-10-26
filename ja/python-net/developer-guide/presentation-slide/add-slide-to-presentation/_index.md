---
title: Python でプレゼンテーションにスライドを追加する
linktitle: スライドの追加
type: docs
weight: 10
url: /ja/python-net/developer-guide/presentation-slide/add-slide-to-presentation/
keywords:
- スライドを追加
- スライドを作成
- 空のスライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションにスライドを簡単に追加できます。シームレスで効率的なスライド挿入を数秒で実現します。"
---

## **概要**

プレゼンテーションにスライドを追加する前に、PowerPoint がスライドをどのように構成しているかを理解すると役立ちます。各プレゼンテーションは、マスタースライド、オプションのレイアウトスライド、および 1 つ以上の通常スライドで構成されます。各スライドには一意の ID が割り当てられ、通常スライドは 0 から始まるインデックスで順序付けられます。本稿では、Aspose.Slides for Python を使用してスライドを作成し、適切なレイアウトを選択する方法を示します。

## **プレゼンテーションへのスライド追加**

Aspose.Slides を使用すると、既存のレイアウトスライドに基づいて新しいスライドを追加できます。以下の例は、プレゼンテーション内の各レイアウトを順に処理し、そのレイアウトを使用したスライドを追加し、最後にファイルを保存します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) にアクセスします。  
3. `presentation.layout_slides` の各項目に対して、`add_empty_slide` を呼び出し、そのレイアウトを使用するスライドを追加します。  
4. 必要に応じて、新しく追加されたスライドを変更します。  
5. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを生成
with slides.Presentation() as presentation:
    # スライドコレクションにアクセス
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # スライドコレクションに空のスライドを追加
        slides.add_empty_slide(layout_slide)

    # 新しく追加されたスライドに対して処理を実行

    # プレゼンテーションをディスクに保存
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**スライドを末尾ではなく特定の位置に挿入できますか？**  

はい。ライブラリはスライドコレクションと [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) 操作をサポートしているため、末尾だけでなく任意のインデックスにスライドを追加できます。

**レイアウトに基づくスライドを追加する際に、テーマやスタイルは保持されますか？**  

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトとそれに関連付けられたマスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションにはどのスライドが含まれていますか？**  

新規作成されたプレゼンテーションには、インデックス 0 の空白スライドが 1 枚既に含まれています。挿入インデックスを計算する際にこの点を考慮する必要があります。

**マスタに多数のオプションがある場合、新しいスライドに適切なレイアウトを選ぶにはどうすればよいですか？**  

一般的には、必要な構成（[Title and Content、Two Content など](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)）に合致する [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) を選択します。そのようなレイアウトが存在しない場合は、[マスタにレイアウトを追加](/slides/ja/python-net/slide-layout/)してから使用してください。