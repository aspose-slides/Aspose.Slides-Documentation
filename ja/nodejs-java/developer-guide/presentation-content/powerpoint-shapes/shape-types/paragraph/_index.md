---
title: 段落
type: docs
weight: 60
url: /ja/nodejs-java/paragraph/
---

## **TextFrame の段落とポーション座標を取得**

Aspose.Slides for Node.js via Java を使用すると、開発者は TextFrame の段落コレクション内の Paragraph の矩形座標を取得できるようになりました。また、段落のポーションコレクション内の [ポーションの座標](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) を取得することも可能です。このトピックでは、例を使って段落の矩形座標と段落内のポーションの位置を取得する方法を示します。
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **Paragraph の矩形座標を取得**

開発者は [**getRect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) メソッドを使用して、段落の境界矩形を取得できます。
```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テーブルセルの TextFrame 内の段落とポーションのサイズを取得**

テーブルセルの TextFrame 内で [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) や [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) のサイズと座標を取得するには、[Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getRect--) と [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) メソッドを使用できます。

このサンプルコードは上記の操作を示しています：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**段落およびテキスト ポーションの座標はどの単位で返されますか？**

ポイント単位です。1インチ = 72 ポイントです。この単位はスライド上のすべての座標と寸法に適用されます。

**ワードラッピングは段落の境界に影響しますか？**

はい。[wrapping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) が [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) で有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標をエクスポートされた画像のピクセルに信頼性を持ってマッピングできますか？**

はい。ポイントをピクセルに変換するには、pixels = points × (DPI / 72) の式を使用します。結果はレンダリング/エクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式設定パラメータを取得するにはどうすればよいですか？**

[effective paragraph formatting data structure](/slides/ja/nodejs-java/shape-effective-properties/) を使用します。これにより、インデント、間隔、ラッピング、RTL などの最終的な統合値が返されます。