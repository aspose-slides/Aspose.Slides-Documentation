---
title: Android でプレゼンテーション スライドを比較
linktitle: スライドを比較
type: docs
weight: 50
url: /ja/androidjava/compare-slides/
keywords:
- スライドの比較
- スライド比較
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint と OpenDocument のプレゼンテーションをプログラムで比較します。Java コードでスライドの違いを迅速に特定します。"
---

## **2つのスライドを比較**
Equals メソッドが [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) インターフェイスと [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide) クラスに追加されました。このメソッドは、構造と静的コンテンツが同一であるスライド/レイアウトおよびスライド/マスター スライドに対して true を返します。

すべてのシェイプ、スタイル、テキスト、アニメーション、その他の設定等が同一である場合、2つのスライドは等しいとみなされます。比較では、SlideId などの一意の識別子や、日付プレースホルダーの現在の日付値などの動的コンテンツは考慮されません。
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

[Hidden status](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) はプレゼンテーション/再生レベルのプロパティであり、視覚的コンテンツではありません。2つの特定のスライドの等価性は、その構造と静的コンテンツによって決まります。スライドが非表示であるという事実だけでは、スライドは異なるものとはみなされません。

**ハイパーリンクおよびそのパラメータは考慮されますか？**

はい。リンクはスライドの静的コンテンツの一部です。URL またはハイパーリンクアクションが異なる場合、通常は静的コンテンツの違いとして扱われます。

**チャートが外部の Excel ファイルを参照している場合、そのファイルの内容は考慮されますか？**

いいえ。比較はスライド自体に基づいて実行されます。外部データ ソースは比較時に読み取られないのが一般的で、スライドの構造と静的状態に存在するものだけが考慮されます。