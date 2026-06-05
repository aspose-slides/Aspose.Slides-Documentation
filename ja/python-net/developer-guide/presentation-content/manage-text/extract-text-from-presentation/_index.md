---  
title: Python でプレゼンテーションから高度なテキスト抽出  
linktitle: テキスト抽出  
type: docs  
weight: 90  
url: /ja/python-net/extract-text-from-presentation/  
keywords:  
- テキスト抽出  
- スライドからテキスト抽出  
- プレゼンテーションからテキスト抽出  
- PowerPoint からテキスト抽出  
- OpenDocument からテキスト抽出  
- PPT からテキスト抽出  
- PPTX からテキスト抽出  
- ODP からテキスト抽出  
- テキスト取得  
- スライドからテキスト取得  
- プレゼンテーションからテキスト取得  
- PowerPoint からテキスト取得  
- OpenDocument からテキスト取得  
- PPT からテキスト取得  
- PPTX からテキスト取得  
- ODP からテキスト取得  
- PowerPoint  
- OpenDocument  
- プレゼンテーション  
- Python  
- Aspose.Slides  
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションからテキストを迅速に抽出します。シンプルなステップバイステップガイドで時間を節約しましょう。"  
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキストデータへのアクセスと取得は、分析、Automation、インデックス作成、コンテンツ移行などの目的で不可欠です。

本記事では、Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP などさまざまなプレゼンテーション形式からテキストを効率的に抽出する包括的な手順をご紹介します。プレゼンテーション要素を体系的に列挙し、必要なテキストコンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for Python via .NET は、[aspose.slides.util](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/) 名前空間を提供し、その中に [SlideUtil](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/) クラスがあります。このクラスは、プレゼンテーションまたはスライド全体からテキストを抽出するためのオーバーロードされた静的メソッドを複数公開しています。スライド内のテキストを抽出するには、[get_all_text_boxes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) メソッドを使用します。このメソッドは、[BaseSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/) 型のオブジェクトをパラメーターとして受け取ります。実行時にスライド全体を走査し、テキストを検出して [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) 型オブジェクトの配列として返し、テキストの書式情報を保持します。

以下のコードスニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。

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

## **プレゼンテーション全体からテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/) クラスが提供する [get_all_text_frames](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/get_all_text_frames/) 静的メソッドを使用します。このメソッドは 2 つのパラメーターを受け取ります。

1. 最初に、テキストを抽出する対象となる PowerPoint または OpenDocument のプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクト。
2. 次に、プレゼンテーションのテキスト走査時にマスタースライドを含めるかどうかを示す `Boolean` 値。

メソッドは、テキスト書式情報を含む [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) 型オブジェクトの配列を返します。以下のコードは、プレゼンテーションとマスタースライドのテキストおよび書式情報を走査します。

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

## **分類された高速テキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するメソッドを提供します。

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textextractionarrangingmode/) 列挙体の引数は、テキスト抽出結果の整理方法を示し、以下の値に設定できます。
- `UNARRANGED` – スライド上の位置を考慮しない生のテキスト。
- `ARRANGED` – スライド上の順序と同じ順序でテキストが整理されます。

速度が重要な場合は `UNARRANGED` モードを使用できます。このモードは `ARRANGED` モードよりも高速です。

[PresentationText](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationtext/) は、プレゼンテーションから抽出された生テキストを表します。その `slides_text` プロパティはスライドテキストオブジェクトの配列を返します。各オブジェクトは対応するスライドのテキストを表し、以下のプロパティを持ちます。

- `text` – スライドのシェイプ内のテキスト。
- `master_text` – 当該スライドに関連付けられたマスタースライドのシェイプ内のテキスト。
- `layout_text` – 当該スライドに関連付けられたレイアウトスライドのシェイプ内のテキスト。
- `notes_text` – 当該スライドのノートスライドのシェイプ内のテキスト。
- `comments_text` – 当該スライドに付随するコメント内のテキスト。

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **FAQ**

**Aspose.Slides は大規模プレゼンテーションのテキスト抽出時にどれくらい高速ですか？**

Aspose.Slides は高性能に最適化されており、[大規模プレゼンテーション](/slides/ja/python-net/open-presentation/) も処理できるため、リアルタイムまたはバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内のテーブルやチャートからテキストを抽出できますか？**

はい。Aspose.Slides はテーブルやチャート関連オブジェクトを含む多くのスライド要素からテキストを抽出できるため、一般的なプレゼンテーション構造のテキストコンテンツにアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

無料トライアル版でもテキスト抽出は可能ですが、[特定の制限](/slides/ja/python-net/licensing/)（例: スライド数の上限）が適用されます。無制限に使用し、より大きなプレゼンテーションを扱う場合はフルライセンスの購入が推奨されます。