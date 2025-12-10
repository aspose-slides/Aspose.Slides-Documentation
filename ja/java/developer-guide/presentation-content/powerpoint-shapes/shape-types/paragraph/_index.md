---
title: Javaでプレゼンテーションから段落の境界を取得
linktitle: 段落
type: docs
weight: 60
url: /ja/java/paragraph/
keywords:
- 段落の境界
- テキストポーションの境界
- 段落座標
- ポーション座標
- 段落サイズ
- テキストポーションサイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java用 Aspose.Slides で段落とテキストポーションの境界を取得し、PowerPoint プレゼンテーションのテキスト配置を最適化する方法を学びます。"
---

## **テキストフレーム内の段落とポーションの座標を取得**
Aspose.Slides for Java を使用すると、開発者は TextFrame の段落コレクション内の Paragraph の矩形座標を取得できます。また、段落のポーションコレクション内の [the coordinates of portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) を取得することも可能です。このトピックでは、サンプルを使って段落の矩形座標と段落内のポーションの位置を取得する方法を示します。
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **段落の矩形座標を取得**
[**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) メソッドを使用すると、開発者は段落のバウンド矩形を取得できます。
```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブルセルのテキストフレーム内の段落およびポーションのサイズを取得**

テーブルセルのテキストフレーム内で [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) または [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) のサイズと座標を取得するには、[IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) および [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) メソッドを使用できます。

このサンプルコードは、上記の操作を実演しています：
```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**段落およびテキストポーションの座標はどの単位で返されますか？**

ポイント単位です。1 インチ = 72 ポイントです。これはスライド上のすべての座標とサイズに適用されます。

**ワードラッピングは段落のバウンドに影響しますか？**

はい。[wrapping](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-) が [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) で有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際のバウンドが変わります。

**段落の座標はエクスポートされた画像のピクセルに確実にマッピングできますか？**

はい。ポイントをピクセルに変換するには次の式を使用します: pixels = points × (DPI / 72)。結果はレンダリング/エクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式設定パラメータを取得するにはどうすればよいですか？**

[effective paragraph formatting data structure](/slides/ja/java/shape-effective-properties/) を使用してください。インデント、間隔、ラッピング、RTL などの最終的な統合値を返します。