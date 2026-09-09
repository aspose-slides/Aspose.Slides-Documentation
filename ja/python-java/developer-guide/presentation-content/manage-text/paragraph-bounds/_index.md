---
title: Python（Java経由）でプレゼンテーションから段落の境界を取得する
linktitle: 段落の境界
type: docs
weight: 43
url: /ja/python-java/paragraph-bounds/
keywords:
- 段落の境界
- 段落座標
- 段落サイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python（Java経由）用 Aspose.Slides で段落の境界を取得し、PowerPoint プレゼンテーションのテキスト配置を最適化する方法を学びます。"
---
## **概要**

この記事では、Aspose.Slides の段落の境界、サイズ、座標の取得方法について説明します。[Paragraph.getRect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/#getRect) を使用して[TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) から段落の矩形を取得する方法、テーブルセルのテキストフレーム内の段落座標の取得方法を示し、測定単位、テキスト折り返しが境界に与える影響、ピクセル変換、効果的な段落書式設定値などの重要な詳細を強調します。

## **段落の矩形座標を取得する**

段落の境界矩形を取得するには、[Paragraph.getRect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/#getRect) を使用します。

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
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **テーブルセルのテキストフレーム内の段落のサイズを取得する**

テーブルセルのテキストフレーム内の[Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/)のサイズと座標を取得するには、[Paragraph.getRect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/#getRect) を使用します。返される矩形はテーブルセルのテキストフレームに対して相対的であるため、スライドレベルの座標が必要な場合はテーブルの位置とセルのオフセットを加算します。

以下の例は、テーブルセル内の段落の境界を取得し、スライド上に矩形を描画してその境界を可視化します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**段落の座標はどの単位で測定されますか？**  
ポイント単位で測定されます。1インチは 72 ポイントに相当します。この単位はスライド上のすべての座標と寸法に適用されます。

**ワードラッピングは段落の境界に影響しますか？**  
はい。[TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setWrapText) が[TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/)で有効になっている場合、テキストは領域の幅に合わせて改行され、段落の実際の境界が変わります。

**段落の座標をエクスポートされた画像のピクセルに確実にマッピングできますか？**  
はい。ポイントをピクセルに変換するには、次の式を使用します。pixels = points x (DPI / 72)。結果はレンダリングまたはエクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式設定パラメータはどのように取得しますか？**  
[effective paragraph formatting data structure](/slides/ja/python-java/shape-effective-properties/) を使用します。インデント、間隔、折り返し、RTL などの最終的に統合された値が返されます。