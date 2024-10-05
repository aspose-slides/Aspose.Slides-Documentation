---
title: スライドの比較
type: docs
weight: 50
url: /net/compare-slides/
keywords: "PowerPointスライドの比較, 2つのスライドの比較, プレゼンテーション, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでPowerPointプレゼンテーションスライドを比較する"
---

## **2つのスライドを比較する**
Equalsメソッドが[IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide)インターフェイスと[BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide)クラスに追加されました。このメソッドは、構造と静的コンテンツが同一であるスライド/レイアウトおよびスライド/マスタースライドに対してtrueを返します。

2つのスライドは、すべての図形、スタイル、テキスト、アニメーションおよびその他の設定が等しい場合に等しいです。比較は、スライドIDや動的コンテンツ（例：日付プレースホルダーの現在日付値）などのユニークな識別子の値を考慮しません。

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} は SomePresentation2 MasterSlide#{1} に等しい", i, j));
        }
    }
}
```