---
title: スライドを比較する
type: docs
weight: 50
url: /ja/androidjava/compare-slides/
---

## **2つのスライドを比較する**
Equals メソッドが [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) インターフェースと [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide) クラスに追加されました。このメソッドは、構造と静的コンテンツが同一であるスライド/レイアウトおよびスライド/マスタースライドに対して true を返します。

2つのスライドは、すべての図形、スタイル、テキスト、アニメーション、その他の設定が等しい場合に等しいと見なされます。比較は、スライド ID や日付プレースホルダーの現在の日付値などのユニークな識別子の値、動的コンテンツは考慮されません。

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
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d は SomePresentation2 MasterSlide#%d と等しいです", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```