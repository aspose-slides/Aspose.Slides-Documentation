---
title: スライドの比較
type: docs
weight: 50
url: /ja/net/compare-slides/
keywords: "PowerPoint スライドの比較, 2つのスライドの比較, プレゼンテーション, C#, Csharp, .NET, Aspose.Slides"
description: "C# または .NET で PowerPoint プレゼンテーション スライドを比較する"
---

## **スライドを比較する**
Equals メソッドが [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) インターフェイスと [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide) クラスに追加されました。このメソッドは、構造と静的コンテンツが同一であるスライド/レイアウトおよびマスタースライドに対して true を返します。

すべてのシェイプ、スタイル、テキスト、アニメーションおよびその他の設定が同一である場合、2 つのスライドは等しいとみなされます。比較では、SlideId などの固有識別子の値や、日付プレースホルダーの現在の日付値などの動的コンテンツは考慮されません。
```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```


## **よくある質問**

**スライドが非表示であることは、スライド自体の比較に影響しますか？**

[Hidden status](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) はプレゼンテーション/再生レベルのプロパティであり、視覚的コンテンツではありません。2 つの特定のスライドの等価性はその構造と静的コンテンツによって決まります。スライドが非表示であるという事実だけでスライドが異なるとはみなされません。

**ハイパーリンクとそのパラメータは考慮されますか？**

はい。リンクはスライドの静的コンテンツの一部です。URL やハイパーリンクのアクションが異なる場合、通常は静的コンテンツの違いとして扱われます。

**チャートが外部の Excel ファイルを参照している場合、そのファイルの内容は考慮されますか？**

いいえ。比較はスライド自体に基づいて行われます。外部データソースは通常、比較時に読み取られず、スライドの構造と静的状態に存在するものだけが考慮されます。