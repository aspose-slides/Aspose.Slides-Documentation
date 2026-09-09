---
title: Python（Java経由）でプレゼンテーションからテキスト部分の境界を取得
linktitle: 部分の境界
type: docs
weight: 47
url: /ja/python-java/portion-bounds/
keywords:
- テキスト部分の境界
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションのテキスト部分の境界を取得する方法を学びます。"
---
## **概要**

テキストの部分は、段落内の特定のテキストフラグメントを表し、周囲のコンテンツとは別にそのフラグメントを操作できます。Aspose.Slides では、テキストフラグメントの境界を取得したり、段落の一部だけに書式設定を適用したり、テキストの動作をより詳細に制御したりする際に、部分を使用できます。

この記事では、[Portion.getRect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getRect) を使用して部分のバウンディング矩形を取得する方法を示します。また、[Portion.getCoordinates](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getCoordinates) を使用して部分の開始座標を取得する方法も示します。さらに、単一のテキストフラグメントにハイパーリンクを適用する、部分、段落、テキストフレーム、テーマの継承を通じて書式設定がどのように解決されるかを理解する、指定されたフォントが利用できない場合の処理など、一般的な部分関連シナリオをハイライトします。

## **テキスト部分の境界を取得**

テキスト部分のバウンディング矩形を取得するには、[Portion.getRect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getRect) を使用します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **テキスト部分の開始座標を取得**

テキスト部分の開始座標を取得するには、[Portion.getCoordinates](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getCoordinates) を使用します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **よくある質問**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々の部分に対して[ハイパーリンクを割り当て](/slides/ja/python-java/manage-hyperlinks/)ことができます。そのフラグメントだけがクリック可能になり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか？部分がオーバーライドするものと、段落やテキストフレームから取得されるものは何ですか？**

部分レベルのプロパティが最も高い優先順位を持ちます。プロパティが[Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/)で設定されていない場合、Aspose.Slides は[Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/)から取得します。そこでも設定されていなければ、[TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/)または[theme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/theme/) のスタイルが使用されます。

**部分に指定されたフォントが対象のマシンまたはサーバーに存在しない場合、どうなりますか？**

[フォント置換ルール](/slides/ja/python-java/font-selection-sequence/)が適用されます。テキストは再フローする可能性があり、メトリクス、ハイフネーション、幅が変わることがあり、正確な位置決めに影響します。

**段落の他の部分とは別に、部分固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/)レベルでのテキストカラー、塗りつぶし、透明度は隣接するフラグメントと異なる設定が可能です。