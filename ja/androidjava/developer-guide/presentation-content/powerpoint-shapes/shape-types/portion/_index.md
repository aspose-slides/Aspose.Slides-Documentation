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
description: "Java を使用して Android 用 Aspose.Slides で PowerPoint プレゼンテーションのテキスト部分を管理し、パフォーマンスとカスタマイズ性を向上させる方法を学びます。"
---

## **テキスト部分の座標取得**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) メソッドが [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPortion) と [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) クラスに追加され、部分の開始位置の座標を取得できるようになりました。
```java
// PPTX を表す Presentation クラスのインスタンス化
Presentation pres = new Presentation();
try {
    // プレゼンテーションのコンテキストを再形成
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


## **FAQ**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々の部分に[ハイパーリンクを割り当て](/slides/ja/androidjava/manage-hyperlinks/)することができます。そのフラグメントだけがクリック可能になり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか：Portion が上書きするもの、Paragraph や TextFrame から取得するものは何ですか？**

Portion レベルのプロパティが最も高い優先順位を持ちます。プロパティが [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) で設定されていない場合、エンジンは [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) から取得します。そこでも設定されていなければ、[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) または [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/) スタイルから取得します。

**Portion に指定されたフォントが対象のマシン/サーバーに存在しない場合、どうなりますか？**

[フォント置換ルール](/slides/ja/androidjava/font-selection-sequence/) が適用されます。テキストは再フローする可能性があり、メトリック、ハイフネーション、幅が変わることがあり、正確な位置決めに影響します。

**Portion 固有のテキスト塗りつぶしの透明度やグラデーションを段落全体とは独立して設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) レベルでテキストの色、塗りつぶし、透明度を隣接するフラグメントとは異なる設定にすることができます。