---
title: Javaでプレゼンテーションのインクオブジェクトを管理
linktitle: インクの管理
type: docs
weight: 95
url: /ja/java/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インク管理
- インク描画
- 描画
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint のインクオブジェクトを管理します。デジタルインクの作成、編集、スタイル設定が可能です。トレース、ブラシの色とサイズのコードサンプルをご覧ください。"
---

PowerPoint はインク機能を提供し、標準的でない図形を描画でき、他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。  

Aspose.Slides は、インクオブジェクトの作成と管理に必要なすべての Ink タイプ（例: [Ink](https://reference.aspose.com/slides/java/com.aspose.slides/ink/) クラス）を提供します。  

## **通常のオブジェクトとインクオブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプオブジェクトで表されます。シェイプオブジェクトは、最も単純な形ではオブジェクト自体の領域（フレーム）とそのプロパティを定義するコンテナです。プロパティにはコンテナ領域のサイズ、シェイプの形状、コンテナの背景などが含まれます。詳細は[シェイプ レイアウト形式](https://docs.aspose.com/slides/java/shape-manipulations/#access-layout-formats-for-shape)をご参照ください。

ただし、PowerPoint がインクオブジェクトを扱う場合、サイズ以外のフレーム（コンテナ）のすべてのプロパティは無視されます。コンテナ領域のサイズは標準の `width` と `height` 値で決定されます。

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape トレース**

トレースは、ユーザーがデジタルインクで筆記する際のペンの軌跡を記録する基本要素または標準です。トレースは接続された点のシーケンスを記述する録画です。  

最も単純なエンコーディング形式は各サンプル点の X および Y 座標を指定します。すべての接続された点が描画されると、次のような画像が生成されます。

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシ プロパティ**

トレース要素の点を結ぶラインを描画するためにブラシを使用できます。ブラシは `Brush.Color` と `Brush.Size` プロパティに対応する独自の色とサイズを持ちます。  

### **インクブラシの色を設定する**

この Java コードはブラシの色を設定する方法を示しています:
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


### **インクブラシのサイズを設定する**

この Java コードはブラシのサイズを設定する方法を示しています:
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


通常、ブラシの幅と高さは一致しないため、PowerPoint はブラシサイズを表示しません（データ セクションは灰色表示）。しかし、ブラシの幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します。

![ink_powerpoint3](ink_powerpoint3.png)

わかりやすくするために、インクオブジェクトの高さを増やし、重要な寸法を確認しましょう。

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さを 0 と見なします（最後の画像参照）。  

したがって、インクオブジェクト全体の可視領域を決定するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストのトレースオブジェクト）がコンテナ（フレーム）サイズに合わせてスケーリングされています。コンテナ（フレーム）のサイズが変わると、ブラシサイズは一定のままであり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

テキストを扱う場合も PowerPoint は同様の動作を示します。

![ink_powerpoint6](ink_powerpoint6.png)

**さらに読む**

* 一般的なシェイプについては、[PowerPoint Shapes](https://docs.aspose.com/slides/java/powerpoint-shapes/) セクションをご参照ください。  
* 有効な値に関する詳細は、[シェイプ 有効プロパティ](https://docs.aspose.com/slides/java/shape-effective-properties/#getting-effective-font-height-value)をご覧ください。