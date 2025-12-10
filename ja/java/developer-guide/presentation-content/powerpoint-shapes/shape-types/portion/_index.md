---
title: Java を使用したプレゼンテーションでのテキスト部分の管理
linktitle: テキスト部分
type: docs
weight: 70
url: /ja/java/portion/
keywords:
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションのテキスト部分を管理し、パフォーマンスとカスタマイズ性を向上させる方法を学びます。"
---

## **テキスト部分の座標取得**
[**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) メソッドが [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) と [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) クラスに追加され、部分の開始位置の座標を取得できるようになりました。
```java
// PPTX を表す Presentation クラスのインスタンス化
Presentation pres = new Presentation();
try {
    //    プレゼンテーションのコンテキストを再形成
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**単一の段落内のテキストの一部にだけハイパーリンクを適用できますか？**

はい、個別の部分に [ハイパーリンクを割り当て](/slides/ja/java/manage-hyperlinks/) できます。そのフラグメントだけがクリック可能で、段落全体はクリックできません。

**スタイル継承はどのように機能しますか: Portion が上書きするものは何で、Paragraph や TextFrame から継承されるものは何ですか？**

Portion レベルのプロパティが最も優先されます。プロパティが [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) で設定されていない場合、エンジンは [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) から取得します。そこでも設定されていなければ、[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) または [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/) のスタイルから取得します。

**Portion に指定されたフォントが対象のマシン/サーバーに存在しない場合はどうなりますか？**

[フォント置換ルール](/slides/ja/java/font-selection-sequence/) が適用されます。テキストが再配置される可能性があり、メトリック、ハイフネーション、幅が変わることがあり、正確な位置決めに影響します。

**Paragraph の他の部分とは独立して、Portion 固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) レベルでテキストの色、塗りつぶし、透明度を設定でき、隣接するフラグメントとは異なる設定にできます。