---
title: Javaでプレゼンテーションスライドを比較
linktitle: スライドを比較
type: docs
weight: 50
url: /ja/java/compare-slides/
keywords:
- スライドを比較
- スライド比較
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint と OpenDocument のプレゼンテーションをプログラムで比較します。コード内でスライドの違いをすばやく特定できます。"
---

## **2つのスライドを比較**
Equals メソッドが [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) インターフェイスと [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide) クラスに追加されました。このメソッドは、構造と静的コンテンツが同一であるスライド/レイアウトおよびマスタースライドに対して true を返します。

すべてのシェイプ、スタイル、テキスト、アニメーション、その他の設定などがすべて等しい場合、2つのスライドは等しいとみなされます。比較では、SlideId のような一意の識別子や、日付プレースホルダーの現在の日付値のような動的コンテンツは考慮されません。
```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **よくある質問**

**スライドが非表示であることは、スライド自体の比較に影響しますか？**

[Hidden status](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getHidden--) はプレゼンテーション/再生レベルのプロパティであり、ビジュアルコンテンツではありません。特定の2つのスライドの等価性は、その構造と静的コンテンツによって決定されます。スライドが非表示であるだけでは、スライドが異なるとはみなされません。

**ハイパーリンクとそのパラメータは考慮されますか？**

はい。リンクはスライドの静的コンテンツの一部です。URL やハイパーリンクのアクションが異なる場合、通常は静的コンテンツの違いとして扱われます。

**チャートが外部の Excel ファイルを参照している場合、そのファイルの内容は考慮されますか？**

いいえ。比較はスライド自体に基づいて行われます。外部データソースは通常、比較時に読み取られず、スライドの構造と静的状態に存在するものだけが考慮されます。