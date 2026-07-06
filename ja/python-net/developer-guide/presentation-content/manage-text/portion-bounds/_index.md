---
title: Python でプレゼンテーションからテキスト部分の境界を取得する
linktitle: 部分の境界
type: docs
weight: 47
url: /ja/python-net/portion-bounds/
keywords:
- テキスト部分の境界
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでテキスト部分の境界を取得する方法を学びます。"
---
## **概要**

テキストの部分は段落内の特定のテキストフラグメントを表し、周辺のコンテンツとは独立してそのフラグメントを操作できます。Aspose.Slides では、テキストフラグメントの境界を取得したり、段落の一部だけに書式設定を適用したり、テキストの動作をより詳細に制御したりする際に Portion を使用できます。

この記事では、[Portion.get_rect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/get_rect/) を使用して Portion のバウンディング矩形を取得する方法を示します。また、[Portion.get_coordinates](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/get_coordinates/) を使用して Portion の開始座標を取得する方法も示します。さらに、単一テキストフラグメントにハイパーリンクを適用する、書式が Portion、Paragraph、TextFrame、テーマの継承を通じてどのように解決されるか、指定したフォントが利用できない場合の対処方法など、一般的な Portion 関連シナリオをハイライトします。

## **テキスト部分の境界取得**

[Portion.get_rect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/get_rect/) を使用してテキスト部分のバウンディング矩形を取得します:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **テキスト部分の座標取得**

[Portion.get_coordinates](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/get_coordinates/) を使用してテキスト部分の開始座標を取得します:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々の Portion に対して[ハイパーリンクを割り当てる](/slides/ja/python-net/manage-hyperlinks/)ことができます。クリック可能になるのはそのフラグメントだけで、段落全体はクリックできません。

**スタイル継承はどのように機能しますか：Portion が上書きするものと、Paragraph や TextFrame から取得されるものは何ですか？**

Portion レベルのプロパティが最も高い優先順位を持ちます。プロパティが [Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/) に設定されていない場合、Aspose.Slides は [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) から取得します。そこにも設定がない場合は、[TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) または[theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/theme/) のスタイルが使用されます。

**Portion に指定されたフォントが対象のマシンまたはサーバーに存在しない場合、どうなりますか？**

[フォント置換ルール](/slides/ja/python-net/font-selection-sequence/) が適用されます。テキストは再フローされる可能性があり、メトリクス、ハイフネーション、幅が変化するため、正確な配置に影響します。

**Paragraph の残りの部分とは独立して、Portion 固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/) レベルでテキストの色、塗りつぶし、透明度を隣接するフラグメントと異なる設定にできます。