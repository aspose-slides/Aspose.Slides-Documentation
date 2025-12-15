---
title: Android のプレゼンテーションから段落の境界を取得
linktitle: 段落
type: docs
weight: 60
url: /ja/androidjava/paragraph/
keywords:
  - 段落境界
  - テキストポーション境界
  - 段落座標
  - ポーション座標
  - 段落サイズ
  - テキストポーションサイズ
  - テキストフレーム
  - PowerPoint
  - プレゼンテーション
  - Android
  - Java
  - Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides で段落およびテキストポーションの境界を取得し、PowerPoint プレゼンテーションのテキスト配置を最適化する方法を学びます。"
---

## **テキストフレーム内の段落およびポーションの座標取得**
Java 経由で Aspose.Slides for Android を使用すると、開発者はテキストフレームの段落コレクション内の Paragraph の矩形座標を取得できるようになりました。また、段落のポーションコレクション内のポーションの座標を取得することもできます。[ポーションの座標](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--)。このトピックでは、例を用いて段落の矩形座標と、段落内のポーションの位置を取得する方法を示します。
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **段落の矩形座標の取得**
[**getRect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--) メソッドを使用すると、開発者は段落の境界矩形を取得できます。
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


## **テーブルセルのテキストフレーム内の段落とポーションのサイズ取得**
テーブルセルのテキストフレーム内で [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) または [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) のサイズと座標を取得するには、[IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getRect--) と [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--) メソッドを使用できます。

このサンプルコードは上記の操作を示しています。
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

ポイント単位です。1インチ＝72ポイントです。これはスライド上のすべての座標と寸法に適用されます。

**ワードラップは段落の境界に影響しますか？**

はい。[wrapping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) が [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) で有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標はエクスポートされた画像のピクセルに確実に変換できますか？**

はい。ポイントをピクセルに変換するには、pixels = points × (DPI / 72) の式を使用します。結果はレンダリング/エクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式設定パラメータはどう取得しますか？**

[effective paragraph formatting data structure](/slides/ja/androidjava/shape-effective-properties/) を使用します。これにより、インデント、間隔、ラッピング、RTL などの最終的に統合された値が返されます。