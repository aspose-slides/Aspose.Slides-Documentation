---
title: Java でプレゼンテーションから段落の境界を取得
linktitle: 段落の境界
type: docs
weight: 43
url: /ja/java/paragraph-bounds/
keywords:
- 段落の境界
- 段落の座標
- 段落のサイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で段落の境界を取得し、PowerPoint プレゼンテーションのテキスト配置を最適化する方法を学びます。"
---
## **Overview**

この記事では、Aspose.Slides の段落の境界、サイズ、座標を取得する方法を説明します。[IParagraph.getRect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IParagraph#getRect--) を使用して [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) から段落の矩形を取得する方法、テーブルセルのテキストフレーム内の段落座標を取得する方法、測定単位、テキスト折り返しが境界に与える影響、ピクセル変換、実際の段落書式設定値などの重要な詳細について強調しています。

## **Get Rectangular Coordinates of a Paragraph**

[IParagraph.getRect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IParagraph#getRect--) を使用して段落のバウンディング矩形を取得します。

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Get the Size of a Paragraph Inside a Table Cell TextFrame**

テーブルセルのテキストフレーム内の [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) のサイズと座標を取得するには、[IParagraph.getRect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IParagraph#getRect--) を使用します。返される矩形はテーブルセルのテキストフレームに対して相対的であるため、スライドレベルの座標が必要な場合はテーブルの位置とセルのオフセットを加算してください。

以下の例は、テーブルセル内の段落境界を取得し、スライド上に矩形を描画してその境界を視覚化します：

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**In what units are paragraph coordinates measured?**  
ポイントで測定されます。1インチは 72 ポイントです。この単位はスライド上のすべての座標と寸法に適用されます。

**Does word wrapping affect a paragraph's bounds?**  
はい。[ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) が [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) に対して有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変わります。

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**  
はい。この式を使用してポイントをピクセルに変換します: pixels = points x (DPI / 72)。結果はレンダリングまたはエクスポート時に選択した DPI に依存します。

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**  
[effective paragraph formatting data structure](/slides/ja/java/shape-effective-properties/) を使用します。インデント、間隔、折り返し、RTL などの最終的に統合された値を返します。