---
title: Android でプレゼンテーション インク オブジェクトを管理する
linktitle: インクの管理
type: docs
weight: 95
url: /ja/androidjava/manage-ink/
keywords:
- インク
- インク オブジェクト
- インク トレース
- インク の管理
- インク を描画
- 描画
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "PowerPoint のインク オブジェクトを管理し、Aspose.Slides for Android を使用してデジタル インクを作成、編集、スタイル設定します。トレース、ブラシの色とサイズに関する Java コードサンプルを取得できます。"
---

PowerPoint はインク機能を提供し、標準外の図形を描画できるようにします。これにより、他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くことができます。

Aspose.Slides は、インク オブジェクトの作成と管理に必要なすべての Ink タイプ（例: [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) クラス）を提供します。

## **通常オブジェクトとインク オブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプ オブジェクトで表されます。シェイプ オブジェクトは、最も単純な形では、オブジェクト自体（フレーム）の領域とそのプロパティを定義するコンテナです。これには、コンテナ領域のサイズ、コンテナの形状、コンテナの背景などが含まれます。詳細は [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

しかし、PowerPoint がインク オブジェクトを扱う場合、サイズ以外のオブジェクト フレーム（コンテナ）のすべてのプロパティは無視されます。コンテナ領域のサイズは標準の `width` と `height` 値で決まります。

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape トレース**

トレースは、ユーザーがデジタル インクで書く際のペンの軌跡を記録するための基本要素または標準です。トレースは、接続された点のシーケンスを記述した記録です。

最も単純なエンコード形式は、各サンプル点の X および Y 座標を指定します。すべての接続点が描画されると、次のような画像が生成されます。

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシ プロパティ**

トレース要素の点を結ぶ線を描くためにブラシを使用できます。ブラシには `Brush.Color` と `Brush.Size` プロパティに対応する独自の色とサイズがあります。

### **インク ブラシの色を設定する**

この Java コードは、ブラシの色を設定する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```


### **インク ブラシのサイズを設定する**

この Java コードは、ブラシのサイズを設定する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```


通常、ブラシの幅と高さは一致せず、PowerPoint はブラシ サイズを表示しません（データ セクションがグレー表示されます）。しかし、ブラシの幅と高さが一致すると、PowerPoint は次のようにサイズを表示します。

![ink_powerpoint3](ink_powerpoint3.png)

分かりやすくするために、インク オブジェクトの高さを増やし、重要な寸法を確認しましょう。

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さがゼロであるとみなします（最後の画像を参照）。

したがって、インク オブジェクト全体の表示領域を決定するには、トレース オブジェクトのブラシ サイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストのトレース オブジェクト）がコンテナ（フレーム）サイズに合わせてスケーリングされています。コンテナ（フレーム）のサイズが変わると、ブラシ サイズは一定のまま変わらず、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

テキストを扱う場合も、PowerPoint は同じ動作を示します。

![ink_powerpoint6](ink_powerpoint6.png)

**さらに読む**

* シェイプ全般については、[PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/) セクションをご覧ください。
* 有効な値の詳細については、[Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value) を参照してください。