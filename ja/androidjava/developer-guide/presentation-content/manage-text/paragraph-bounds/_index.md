---
title: Androidでプレゼンテーションから段落の境界を取得する
linktitle: 段落の境界
type: docs
weight: 43
url: /ja/androidjava/paragraph-bounds/
keywords:
- 段落の境界
- 段落座標
- 段落サイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides で段落の境界を取得し、PowerPoint プレゼンテーションのテキスト配置を最適化する方法を学びます。"
---
## **概要**

この記事では、Aspose.Slides で段落の境界、サイズ、および座標を取得する方法を説明します。[IParagraph.getRect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraph#getRect--) を使用して [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) から段落の矩形を取得する方法、テーブルセルの TextFrame 内の段落座標を取得する方法、測定単位、テキスト折り返しが境界に与える影響、ピクセル変換、効果的な段落書式設定値などの重要な詳細について解説します。

## **段落の矩形座標を取得する**

[IParagraph.getRect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraph#getRect--) を使用して段落のバウンディング矩形を取得します。

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **テーブルセル TextFrame 内の段落のサイズを取得する**

テーブルセルの TextFrame 内の [IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) のサイズと座標を取得するには、[IParagraph.getRect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraph#getRect--) を使用します。返される矩形はテーブルセルの TextFrame に対して相対的であるため、スライドレベルの座標が必要な場合はテーブル位置とセルオフセットを加算します。

次の例は、テーブルセル内の段落の境界を取得し、スライド上に矩形を描画してその境界を可視化します。

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

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**段落の座標はどの単位で測定されますか？**

ポイントで測定されます。1 インチは 72 ポイントに相当します。これはスライド上のすべての座標と寸法に適用されます。

**単語折り返しは段落の境界に影響しますか？**

はい。[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) の [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) が有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標をエクスポート画像のピクセルへ確実に変換できますか？**

はい。ポイントをピクセルに変換する式は次のとおりです。pixels = points × (DPI / 72)。結果はレンダリングまたはエクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式設定パラメータを取得するにはどうすればよいですか？**

[実効段落書式設定データ構造](/slides/ja/androidjava/shape-effective-properties/) を使用します。インデント、間隔、折り返し、RTL などの最終的な統合値を返します。