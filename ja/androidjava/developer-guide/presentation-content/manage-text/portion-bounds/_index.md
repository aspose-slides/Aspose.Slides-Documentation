---
title: Android のプレゼンテーションからテキストポーションの境界を取得する
linktitle: ポーションの境界
type: docs
weight: 47
url: /ja/androidjava/portion-bounds/
keywords:
- テキストポーションの境界
- テキストポーション
- テキスト部分
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides で PowerPoint プレゼンテーションのテキストポーションの境界を取得する方法を学びます。"
---
## **概要**

テキストポーションは、段落内の特定のテキストフラグメントを表し、そのフラグメントを周囲のコンテンツから独立して操作できるようにします。Aspose.Slides では、テキストフラグメントの境界を取得したり、段落の一部だけに書式設定を適用したり、より詳細なレベルでテキストの動作を制御したりする必要がある場合にポーションを使用できます。

この記事では、[IPortion.getRect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPortion#getRect--) を使用してポーションのバウンディング矩形を取得する方法を示します。また、[IPortion.getCoordinates](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPortion#getCoordinates--) を使用してポーションの開始座標を取得する方法も示します。さらに、単一のテキストフラグメントにハイパーリンクを適用する、書式設定がポーション、段落、テキストフレーム、テーマの継承を通じてどのように解決されるかを理解する、指定したフォントが利用できない場合の対処など、一般的なポーション関連シナリオをハイライトしています。

## **テキストポーションの境界を取得**

テキストポーションのバウンディング矩形を取得するには、[IPortion.getRect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPortion#getRect--) を使用します。

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **テキストポーションの座標取得**

テキストポーションの開始座標を取得するには、[IPortion.getCoordinates](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPortion#getCoordinates--) を使用します。

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々のポーションに[ハイパーリンクを割り当て](/slides/ja/androidjava/manage-hyperlinks/) することができます。そのフラグメントだけがクリック可能になり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか：ポーションは何をオーバーライドし、段落やテキストフレームから何が取得されますか？**

ポーションレベルのプロパティが最優先です。プロパティが[IPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/) で設定されていない場合、Aspose.Slides は[IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) から取得します。そちらでも設定されていない場合は、Aspose.Slides は[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) または[theme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/theme/) のスタイルを使用します。

**ポーションに指定されたフォントが対象のマシンまたはサーバーに存在しない場合、どうなりますか？**

[フォント置換ルール](/slides/ja/androidjava/font-selection-sequence/) が適用されます。テキストは再配置される可能性があり、メトリクス、ハイフネーション、幅が変わるため、正確な位置決めに影響します。

**段落全体とは別に、ポーション固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[IPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/) レベルでのテキストカラー、塗りつぶし、および透明度は、隣接するフラグメントと異なる設定にできます。