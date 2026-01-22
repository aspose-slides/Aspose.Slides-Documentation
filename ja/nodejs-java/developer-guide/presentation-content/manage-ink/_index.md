---
title: JavaScriptでプレゼンテーションのインクオブジェクトを管理する
linktitle: インクの管理
type: docs
weight: 95
url: /ja/nodejs-java/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インクの管理
- インクの描画
- 描画
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPointのインクオブジェクトを管理します—Aspose.Slides for Node.js を使用してデジタルインクを作成、編集、スタイル設定できます。トレースやブラシの色・サイズの JavaScript コードサンプルを取得しましょう。"
---

PowerPoint はインク機能を提供し、標準外の図形を描くことができ、他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

Aspose.Slides は、インク オブジェクトの作成および管理に必要なすべての Ink タイプ（例: [Ink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ink/) クラス）をご提供します。

## **通常オブジェクトとインク オブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプ オブジェクトで表されます。シェイプ オブジェクトは、最も単純な形では、オブジェクト自体の領域（フレーム）とそのプロパティを定義するコンテナです。後者には、コンテナ領域のサイズ、コンテナの形状、コンテナの背景などが含まれます。詳細は [Shape Layout Format](https://docs.aspose.com/slides/nodejs-java/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

ただし、PowerPoint がインク オブジェクトを扱う場合、サイズ以外のオブジェクト フレーム（コンテナ）のすべてのプロパティは無視されます。コンテナ領域のサイズは標準の `width` と `height` の値で決まります：

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape のトレース**

トレースは、ユーザーがデジタル インクで書く際のペンの軌跡を記録するために使用される基本要素または標準です。トレースは、接続されたポイントのシーケンスを記述する録画です。

最も単純なエンコーディング形態は、各サンプルポイントの X および Y 座標を指定します。すべての接続されたポイントがレンダリングされると、次のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## 描画用ブラシ プロパティ

ブラシを使用して、トレース要素のポイントを結ぶ線を描くことができます。ブラシには `Brush.setColor` および `Brush.setSize` メソッドに対応する独自の色とサイズがあります。

### **インク ブラシの色を設定**

この JavaScript コードは、ブラシの色を設定する方法を示します：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **インク ブラシのサイズを設定**

この JavaScript コードは、ブラシのサイズを設定する方法を示します：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


一般に、ブラシの幅と高さは一致せず、PowerPoint はブラシ サイズを表示しません（データ領域は灰色表示）。しかし、幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インク オブジェクトの高さを増やして重要な寸法を確認しましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さはゼロと見なします（最後の画像をご参照ください）。

したがって、インク オブジェクト全体の可視領域を決定するには、トレース オブジェクトのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストのトレース オブジェクト）がコンテナ（フレーム）サイズに合わせてスケーリングされています。コンテナ（フレーム）のサイズが変わると、ブラシサイズは一定のままであり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストを扱う場合も同様の動作を示します：

![ink_powerpoint6](ink_powerpoint6.png)

**さらに読む**

* シェイプ全般については、[PowerPoint Shapes](https://docs.aspose.com/slides/nodejs-java/powerpoint-shapes/) セクションをご覧ください。
* 効率的な値の詳細については、[Shape Effective Properties](https://docs.aspose.com/slides/nodejs-java/shape-effective-properties/#getting-effective-font-height-value) を参照してください。