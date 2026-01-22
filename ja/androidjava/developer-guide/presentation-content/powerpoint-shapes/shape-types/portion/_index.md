---
title: Android でのプレゼンテーションにおけるテキスト部分の管理
linktitle: テキスト部分
type: docs
weight: 70
url: /ja/androidjava/portion/
keywords:
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用して、PowerPoint プレゼンテーションのテキスト部分を管理し、パフォーマンスとカスタマイズ性を向上させる方法を学びます。"
---

## **テキスト部分の座標取得**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) メソッドは [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) と [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) クラスに追加され、部分の開始位置の座標を取得できるようになりました。
```java
// PPTX を表す Presentation クラスをインスタンス化します
Presentation pres = new Presentation();
try {
    // プレゼンテーションのコンテキストを再形成します
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

はい、個々の Portion に[ハイパーリンクを割り当て](/slides/ja/androidjava/manage-hyperlinks/)ことができます。そのフラグメントだけがクリック可能になり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか: Portion が上書きするものと、Paragraph/TextFrame から取得するものは何ですか？**

Portion レベルのプロパティが最も優先されます。プロパティが [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) に設定されていない場合、エンジンは [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) から取得します。そちらにも設定がない場合は、[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) または [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/) のスタイルから取得します。

**Portion に指定されたフォントが対象のマシン/サーバーに存在しない場合はどうなりますか？**

[フォント置換規則](/slides/ja/androidjava/font-selection-sequence/) が適用されます。テキストが再配置される可能性があり、メトリクス、ハイフネーション、幅が変わることがあり、正確な位置決めに影響します。

**Portion 固有のテキスト塗りつぶしの透明度やグラデーションを、段落全体とは独立して設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) レベルでテキストの色、塗りつぶし、透明度を隣接するフラグメントとは異なる設定にできます。