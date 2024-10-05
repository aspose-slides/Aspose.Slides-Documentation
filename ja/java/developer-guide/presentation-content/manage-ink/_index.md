---
title: インクの管理
type: docs
weight: 95
url: /java/manage-ink/
keywords: "PowerPointのインク, インクツール, Javaインク, PowerPointでの描画, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "インクツールを使用してPowerPoint Javaでオブジェクトを描画する"
---

PowerPointは、非標準の図形を描画できるインク機能を提供しており、これを使用して他のオブジェクトを強調表示したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くことができます。

Aspose.Slidesは、インクオブジェクトを作成および管理するために必要なすべてのインクタイプ（例：[Ink](https://reference.aspose.com/slides/java/com.aspose.slides/ink/)クラス）を提供します。

## **通常のオブジェクトとインクオブジェクトの違い**

PowerPointスライド上のオブジェクトは通常、シェイプオブジェクトとして表されます。シェイプオブジェクトは、その最も単純な形において、オブジェクト自体の領域（そのフレーム）とそのプロパティを定義するコンテナです。後者には、コンテナの領域サイズ、コンテナの形状、コンテナの背景などが含まれます。詳細については、[シェイプレイアウトフォーマット](https://docs.aspose.com/slides/java/shape-manipulations/#access-layout-formats-for-shape)を参照してください。

しかし、PowerPointがインクオブジェクトを扱うとき、オブジェクトフレーム（コンテナ）のサイズを除くすべてのプロパティを無視します。コンテナエリアのサイズは、標準の`width`と`height`の値によって決まります:

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプのトレース**

トレースは、ユーザーがデジタルインクを書き込むときのペンの軌跡を記録するために使用される基本要素または標準です。トレースは、接続されたポイントのシーケンスを記述する記録です。

エンコーディングの最も単純な形式は、各サンプルポイントのXおよびY座標を指定します。すべての接続されたポイントがレンダリングされると、このような画像が生成されます:

![ink_powerpoint2](ink_powerpoint2.png)

## 描画のためのブラシプロパティ

ブラシを使用して、トレース要素のポイントをつなぐ線を描画できます。ブラシには、`Brush.Color`および`Brush.Size`プロパティに対応する独自の色とサイズがあります。

### **インクブラシの色を設定する**

このJavaコードは、ブラシの色を設定する方法を示しています:

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

このJavaコードは、ブラシのサイズを設定する方法を示しています:

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

一般的に、ブラシの幅と高さは一致しないため、PowerPointはブラシサイズを表示しません（データセクションはグレーアウトされています）。しかし、ブラシの幅と高さが一致すると、PowerPointはこのようにサイズを表示します:

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インクオブジェクトの高さを増やし、重要な寸法を確認しましょう: 

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮しません--常に線の太さがゼロであると仮定します（最後の画像を参照）。

したがって、インクオブジェクト全体の可視領域を決定するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここで、ターゲットオブジェクト（手書きテキストトレースオブジェクト）は、コンテナ（フレーム）のサイズにスケーリングされています。コンテナ（フレーム）のサイズが変わると、ブラシサイズは一定のままであり、その逆も同様です。 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPointは、テキストを扱うときに同様の動作を示します:

![ink_powerpoint6](ink_powerpoint6.png)

**さらに読む**

* シェイプ一般については、[PowerPointシェイプ](https://docs.aspose.com/slides/java/powerpoint-shapes/)セクションを参照してください。
* 実効値に関する詳細については、[シェイプ実効プロパティ](https://docs.aspose.com/slides/java/shape-effective-properties/#getting-effective-font-height-value)を参照してください。