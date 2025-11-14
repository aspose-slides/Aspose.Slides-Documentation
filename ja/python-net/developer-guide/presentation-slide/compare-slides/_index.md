---
title: スライドを比較する
type: docs
weight: 50
url: /ja/python-net/compare-slides/
keywords: "PowerPointスライドを比較する, 2つのスライドを比較する, プレゼンテーション, Python, Aspose.Slides"
description: "PythonでPowerPointプレゼンテーションスライドを比較する"
---

## **2つのスライドを比較する**
Equalsメソッドが[IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)インターフェースと[BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/)クラスに追加されました。これは、構造と静的コンテンツが同一のスライド/レイアウトおよびスライド/マスタースライドに対して真を返します。

すべてのシェイプ、スタイル、テキスト、アニメーションおよびその他の設定が同一であれば、2つのスライドは等しいです。比較には、ユニーク識別子値（例：SlideId）や動的コンテンツ（例：日付プレースホルダー内の現在の日付値）は考慮されません。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Presentation1 MasterSlide#{0} は Presentation2 MasterSlide#{1} と等しい".format(i,j))
```