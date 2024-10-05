---
title: スライドの比較
type: docs
weight: 50
url: /java/compare-slides/
---

## **2つのスライドを比較する**
Equalsメソッドが[IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide)インターフェイスと[BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide)クラスに追加されました。このメソッドは、構造と静的コンテンツが同一のスライド/レイアウトとスライド/マスタースライドに対してtrueを返します。

すべての図形、スタイル、テキスト、アニメーション、その他の設定などが等しい場合、2つのスライドは等しいです。比較は、スライドIDや日付プレースホルダー内の現在の日付値などの一意の識別子の値を考慮しません。

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
                    System.out.println(String.format("SomePresentation1のマスタースライド#%dはSomePresentation2のマスタースライド#%dに等しいです", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```