---
title: "Pythonでのプレゼンテーションからの高度なテキスト抽出"
linktitle: "テキスト抽出"
type: docs
weight: 90
url: /ja/python-net/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPointからテキスト抽出
- OpenDocumentからテキスト抽出
- PPTからテキスト抽出
- PPTXからテキスト抽出
- ODPからテキスト抽出
- テキスト取得
- スライドからテキスト取得
- プレゼンテーションからテキスト取得
- PowerPointからテキスト取得
- OpenDocumentからテキスト取得
- PPTからテキスト取得
- PPTXからテキスト取得
- ODPからテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルでステップバイステップのガイドに従って、時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライド コンテンツを扱う開発者にとって一般的でありながら重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキスト データへのアクセスと取得は、分析、Automation、インデックス作成、またはコンテンツ移行の目的で重要になることがあります。

この記事では、Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP などのさまざまなプレゼンテーション形式からテキストを効率的に抽出するための包括的な手順を紹介します。プレゼンテーション要素を体系的に走査し、必要なテキスト コンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for Python via .NET は、[aspose.slides.util] 名前空間を提供し、[SlideUtil] クラスが含まれます。このクラスは、プレゼンテーションまたはスライドからすべてのテキストを抽出するためのいくつかのオーバーロードされた静的メソッドを公開しています。プレゼンテーション内のスライドからテキストを抽出するには、[get_all_text_boxes] メソッドを使用します。このメソッドは、[BaseSlide] 型のオブジェクトをパラメータとして受け取ります。実行すると、メソッドはスライド全体を走査してテキストを検出し、[TextFrame] 型のオブジェクトの配列を返し、テキストの書式情報を保持します。

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **プレゼンテーションからテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil] クラスが公開している [get_all_text_frames] 静的メソッドを使用します。 このメソッドは 2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出したい PowerPoint または OpenDocument プレゼンテーションを表す [Presentation] オブジェクト。
2. 2 番目に、プレゼンテーションからテキストを走査する際にマスタ スライドを含めるかどうかを示す `Boolean` 値。

このメソッドは、テキストの書式情報を含む [TextFrame] 型オブジェクトの配列を返します。以下のコードは、マスタ スライドを含めてプレゼンテーションのテキストと書式情報を走査します。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **カテゴリ別かつ高速なテキスト抽出**

[