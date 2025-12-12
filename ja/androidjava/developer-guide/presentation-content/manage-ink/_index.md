---
title: Android でプレゼンテーションのインクオブジェクトを管理
linktitle: インクの管理
type: docs
weight: 95
url: /ja/androidjava/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インクの管理
- インクを描く
- 描画
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides で PowerPoint のインクオブジェクトを管理—デジタルインクの作成、編集、スタイル設定。トレース、ブラシの色とサイズの Java コードサンプルを取得。"
---

PowerPoint はインク機能を提供し、標準的でない図形の描画を可能にします。この機能は、他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

Aspose.Slides では、インクオブジェクトの作成と管理に必要なすべての Ink タイプ (例: [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) クラス) が提供されています。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint のスライド上のオブジェクトは、通常、シェイプオブジェクトで表されます。シェイプオブジェクトは、最も単純な形では、オブジェクト自体の領域（フレーム）とそのプロパティを定義するコンテナです。これにはコンテナ領域のサイズ、コンテナの形状、コンテナの背景などが含まれます。詳しくは [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

しかし、PowerPoint がインクオブジェクトを扱う場合、サイズ以外のオブジェクトフレーム（コンテナ）のすべてのプロパティは無視されます。コンテナ領域のサイズは標準の `width` と `height` の値で決まります：

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプ トレース**

トレースは、ユーザーがデジタルインクで書く際のペンの軌跡を記録する基本要素または標準です。トレースは、連続した点のシーケンスを記述した記録です。

エンコードの最も単純な形式は、各サンプル点の X と Y 座標を指定します。すべての連続点が描画されると、以下のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシプロパティ**

ブラシを使用して、トレース要素の点を結ぶ線を描画できます。ブラシには `Brush.Color` および `Brush.Size` プロパティに対応する独自の色とサイズがあります。

### **インクブラシの色を設定**

以下の Java コードは、ブラシの色を設定する方法を示しています：
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


### **インクブラシのサイズを設定**

以下の Javaコードは、ブラシのサイズを設定する方法を示しています：
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


通常、ブラシの幅と高さは一致しないため、PowerPoint はブラシサイズを表示しません（データ セクションはグレー表示）。ただし、ブラシの幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

分かりやすくするため、インクオブジェクトの高さを増やして重要な寸法を確認しましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さはゼロであるとみなします（最後の画像を参照）。

したがって、インクオブジェクト全体の表示領域を決定するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストトレースオブジェクト）がコンテナ（フレーム）のサイズに合わせてスケーリングされています。コンテナ（フレーム）のサイズが変わると、ブラシサイズは一定のままであり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

テキストを扱う場合も、PowerPoint は同じ動作を示します：

![ink_powerpoint6](ink_powerpoint6.png)

**さらに読む**

* 形状全般については、[PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/) セクションを参照してください。
* 有効値に関する詳細は、[Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value) を参照してください。