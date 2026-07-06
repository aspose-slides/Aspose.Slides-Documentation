---
title: JavaScript でプレゼンテーションから段落境界を取得する
linktitle: 段落境界
type: docs
weight: 43
url: /ja/nodejs-java/paragraph-bounds/
keywords:
- 段落境界
- 段落座標
- 段落サイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js で Java を介して段落境界を取得し、PowerPoint プレゼンテーションのテキスト配置を最適化する方法を学びます。"
---
## **概要**

この記事では、Aspose.Slides で段落の境界、サイズ、および座標を取得する方法について説明します。[Paragraph.getRect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/getrect/) を使用して [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) から段落の矩形を取得する方法、テーブルセルの TextFrame 内の段落座標の取得方法、測定単位、テキスト折り返しが境界に与える影響、ピクセル変換、および実効段落書式値などの重要なポイントを紹介します。

## **段落の矩形座標を取得する**

[Paragraph.getRect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/getrect/) を使用して、段落のバウンディング矩形を取得します。

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **テーブルセルの TextFrame 内の段落のサイズを取得する**

テーブルセルの TextFrame 内の [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) のサイズと座標を取得するには、[Paragraph.getRect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/getrect/) を使用します。戻り値の矩形はテーブルセルの TextFrame に対して相対的であるため、スライド全体の座標が必要な場合はテーブルの位置とセルのオフセットを加算してください。

次の例は、テーブルセル内の段落の境界を取得し、スライド上に矩形を描画してその境界を可視化します。

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**段落座標はどの単位で測定されますか？**

ポイントで測定されます。1 インチは 72 ポイントに相当します。これはスライド上のすべての座標と寸法に適用されます。

**テキスト折り返しは段落の境界に影響しますか？**

はい。[TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/setwraptext/) が [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) に対して有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変化します。

**段落座標をエクスポート画像のピクセルに確実にマッピングできますか？**

はい。ポイントをピクセルに変換する式は次の通りです。pixels = points × (DPI / 72)。結果はレンダリングまたはエクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式パラメータを取得するにはどうすればよいですか？**

[実効段落書式データ構造](/slides/ja/nodejs-java/shape-effective-properties/) を使用します。これにより、インデント、間隔、折り返し、RTL などの最終的な統合値が返されます。