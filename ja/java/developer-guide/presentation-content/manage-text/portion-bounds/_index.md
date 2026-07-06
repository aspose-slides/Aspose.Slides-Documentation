---
title: Java でプレゼンテーションからテキストポーションの境界を取得
linktitle: ポーションの境界
type: docs
weight: 47
url: /ja/java/portion-bounds/
keywords:
- テキストポーション境界
- テキストポーション
- テキスト部分
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションのテキストポーションの境界を取得する方法を学びます。"
---
## **概要**

テキストのポーションは段落内の特定のテキストフラグメントを表し、周囲のコンテンツとは独立してそのフラグメントを操作できるようにします。Aspose.Slides では、テキストフラグメントの境界を取得したり、段落の一部だけに書式設定を適用したり、テキストの動作をより詳細に制御したりする必要がある場合にポーションを使用できます。

この記事では、[IPortion.getRect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPortion#getRect--) を使用してポーションのバウンディング矩形を取得する方法を示します。また、[IPortion.getCoordinates](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPortion#getCoordinates--) を使用してポーションの開始位置の座標を取得する方法も示します。さらに、単一テキストフラグメントへのハイパーリンク適用、ポーション・段落・テキストフレーム・テーマの継承による書式決定、指定フォントが利用できない場合の処理など、一般的なポーション関連シナリオも取り上げます。

## **テキストポーションの境界取得**

[IPortion.getRect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPortion#getRect--) を使用してテキストポーションのバウンディング矩形を取得します:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **テキストポーションの座標取得**

[IPortion.getCoordinates](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPortion#getCoordinates--) を使用してテキストポーションの開始位置の座標を取得します:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**単一段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々のポーションに[assign a hyperlink](/slides/ja/java/manage-hyperlinks/) を割り当てることができます。そのフラグメントだけがクリック可能になり、段落全体は対象になりません。

**スタイル継承はどのように機能しますか: ポーションが上書きするものと、段落やテキストフレームから取得するものは何ですか？**

ポーションレベルのプロパティが最も高い優先順位を持ちます。プロパティが[IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/)で設定されていない場合、Aspose.Slides は[IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/)から取得します。そちらでも設定されていない場合は、[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) または[theme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/theme/) のスタイルが使用されます。

**ポーションに指定されたフォントが対象マシンやサーバーに存在しない場合はどうなりますか？**

[Font substitution rules](/slides/ja/java/font-selection-sequence/) が適用されます。テキストの再フローが発生する可能性があり、メトリクス・ハイフネーション・幅が変わり、正確な配置に影響を与えることがあります。

**ポーション固有のテキスト塗りつぶし透過性やグラデーションを、段落全体とは別に設定できますか？**

はい、[IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/) レベルでテキストの色、塗りつぶし、透過性を隣接するフラグメントとは異なる設定にできます。