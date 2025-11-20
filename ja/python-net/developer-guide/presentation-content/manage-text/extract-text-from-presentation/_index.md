---
title: Python で PowerPoint プレゼンテーションから高度なテキスト抽出
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
description: "Aspose.Slides for Python (via .NET) を使用して PowerPoint プレゼンテーションからテキストを迅速かつ簡単に抽出する方法を学びます。シンプルな段階的ガイドに従い、時間を節約し、アプリケーションでスライドコンテンツへ効率的にアクセスしましょう。"
---

## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキストデータへのアクセスと取得は、分析、 automation、インデックス作成、コンテンツ移行などの目的で重要となります。

本記事では、Aspose.Slides for Python を使用して、PPT、PPTX、ODP などさまざまなプレゼンテーション形式からテキストを効率的に抽出する方法を包括的に解説します。プレゼンテーション要素を体系的に走査し、必要なテキストコンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for Python は [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/) 名前空間を提供し、その中に [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) クラスがあります。このクラスは、プレゼンテーションまたはスライド全体のテキストを抽出するための複数のオーバーロードされた静的メソッドを公開しています。プレゼンテーション内のスライドからテキストを抽出するには、[get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) メソッドを使用します。このメソッドは [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 型のオブジェクトをパラメーターとして受け取ります。実行すると、スライド全体を走査してテキストを検出し、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 型オブジェクトの配列としてテキスト書式情報を保持したまま返します。

以下のコードスニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。
```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # PPTX ファイル内のすべてのスライドから TextFrame オブジェクトの配列を取得します。
    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)
    # テキストフレームの配列をループ処理します。
    for text_frame in text_frames:
        # 現在のテキストフレーム内の段落をループ処理します。
        for paragraph in text_frame.paragraphs:
            # 現在の段落内のテキスト部分をループ処理します。
            for portion in paragraph.portions:
                # 現在の部分のテキストを表示します。
                print(portion.text)
                # テキストのフォントサイズ（高さ）を表示します。
                print(portion.portion_format.font_height)
                # テキストのフォント名を表示します。
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **プレゼンテーション全体からテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) クラスが提供する [get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) 静的メソッドを使用します。このメソッドは 2 つのパラメーターを受け取ります。

1. テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクト。
2. プレゼンテーションのテキスト走査時にマスタースライドを含めるかどうかを示す `Boolean` 値。

メソッドは [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 型オブジェクトの配列を返し、テキスト書式情報も含まれます。以下のコードは、マスタースライドを含めてプレゼンテーションからテキストと書式情報を走査します。
```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("pres.pptx") as presentation:
    # PPTX ファイル内のすべてのスライドから TextFrame オブジェクトの配列を取得します。
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, True)
    # テキストフレームの配列をループ処理します。
    for text_frame in text_frames:
        # 現在のテキストフレーム内の段落をループ処理します。
        for paragraph in text_frame.paragraphs:
            # 現在の段落内のテキスト部分をループ処理します。
            for portion in paragraph.portions:
                # 現在の部分のテキストを表示します。
                print(portion.text)
                # テキストのフォント高さを表示します。
                print(portion.portion_format.font_height)
                # テキストのフォント名を表示します。
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **カテゴリ別かつ高速なテキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出する静的メソッドを提供しています。
```py
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```


[TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) 列挙体の引数はテキスト抽出結果の整理方法を示し、次の値に設定できます。
- `UNARRANGED` – スライド上の位置を考慮しない生テキスト。
- `ARRANGED` – スライド上の順序と同じ順序でテキストが整理されます。

速度が重要な場合は `UNARRANGED` モードを使用できます。`ARRANGED` モードよりも高速です。

[PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) はプレゼンテーションから抽出された生テキストを表します。`slides_text` プロパティは [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) 型オブジェクトの配列を返します。各オブジェクトは対応するスライドのテキストを表します。[ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) 型オブジェクトは以下のプロパティを持ちます。

- `text` – スライドのシェイプ内のテキスト。
- `master_text` – 当該スライドに関連付けられたマスタースライドのシェイプ内のテキスト。
- `layout_text` – 当該スライドに関連付けられたレイアウトスライドのシェイプ内のテキスト。
- `notes_text` – 当該スライドのノートスライドのシェイプ内のテキスト。
- `comments_text` – 当該スライドに付随するコメント内のテキスト。
```py
import aspose.slides as slides

arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory().get_presentation_text("sample.pptx", arranging_mode)
slide_text = presentation_text.slides_text[0]
print(slide_text.text)
print(slide_text.layout_text)
print(slide_text.master_text)
print(slide_text.notes_text)
```


## **FAQ**

**Aspose.Slides は大規模なプレゼンテーションのテキスト抽出時にどれくらい高速ですか？**

Aspose.Slides は高性能に最適化されており、[大規模なプレゼンテーション](/slides/ja/python-net/open-presentation/) でも効率的に処理できるため、リアルタイムまたはバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やグラフからテキストを抽出できますか？**

はい、Aspose.Slides は表、グラフ、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスは必要ですか？**

無料体験版でもテキストを抽出できますが、[特定の制限](/slides/ja/python-net/licensing/)（例：スライド数の上限）が適用されます。制限なく大規模なプレゼンテーションを扱う場合は、フルライセンスの購入を推奨します。