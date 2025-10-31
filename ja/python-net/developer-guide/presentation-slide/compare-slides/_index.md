---
title: Python でプレゼンテーション スライドを比較する
linktitle: スライドを比較
type: docs
weight: 50
url: /ja/python-net/compare-slides/
keywords:
- スライドを比較
- スライド比較
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションをプログラムで比較します。コード内でスライドの違いを迅速に特定できます。"
---

## **2 つのスライドを比較**
Equals メソッドが [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) インターフェイスと [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) クラスに追加されました。構造と静的コンテンツが同一であるスライド/レイアウトおよびマスタースライドに対して true を返します。

すべてのシェイプ、スタイル、テキスト、アニメーションおよびその他の設定が同じである場合、2 つのスライドは等しいとみなされます。比較では、SlideId のような一意の識別子や、日付プレースホルダーの現在の日付値などの動的コンテンツは考慮されません。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **FAQ**

**スライドが非表示であることは、スライド自体の比較に影響しますか？**

[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) はプレゼンテーション/再生レベルのプロパティであり、視覚的コンテンツではありません。特定の 2 つのスライドの等価性は構造と静的コンテンツによって決定され、スライドが非表示であるという事実だけではスライドが異なるとはみなされません。

**ハイパーリンクおよびそのパラメータは考慮されますか？**

はい。リンクはスライドの静的コンテンツの一部です。URL やハイパーリンクアクションが異なる場合、通常は静的コンテンツの違いとして扱われます。

**チャートが外部の Excel ファイルを参照している場合、そのファイルの内容は考慮されますか？**

いいえ。比較はスライド自体に基づいて実行されます。外部データ ソースは比較時に読み取られず、スライドの構造と静的状態に存在するものだけが考慮されます。