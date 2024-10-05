---
title: インクの管理
type: docs
weight: 95
url: /androidjava/manage-ink/
keywords: "PowerPointのインク, インクツール, Javaインク, PowerPointでの描画, PowerPointプレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "インクツールを使用してPowerPoint Javaでオブジェクトを描画する"
---

PowerPointは、他のオブジェクトを強調表示したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できる非標準の図形を描画するためのインク機能を提供します。

Aspose.Slidesは、インクオブジェクトを作成および管理するために必要なすべてのインクタイプ（例：[Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/)クラス）を提供します。

## **通常のオブジェクトとインクオブジェクトの違い**

PowerPointスライド上のオブジェクトは通常、シェイプオブジェクトとして表現されます。シェイプオブジェクトは、最も単純な形で、オブジェクト自体の範囲（そのフレーム）とそのプロパティを定義するコンテナです。後者には、コンテナの面積サイズ、コンテナの形状、コンテナの背景などが含まれます。詳細については、[Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape)を参照してください。

ただし、PowerPointがインクオブジェクトを扱う場合、そのサイズを除いてオブジェクトフレーム（コンテナ）のすべてのプロパティを無視します。コンテナの面積のサイズは、標準の`width`および`height`値によって決まります：

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプトレース**

トレースは、ユーザーがデジタルインクを書き込むときにペンの軌道を記録するために使用される基本要素または標準です。トレースは、接続されたポイントのシーケンスを記述する記録です。

エンコーディングの最も単純な形式は、各サンプルポイントのXおよびY座標を指定します。すべての接続されたポイントがレンダリングされると、次のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## 描画のためのブラシプロパティ

ブラシを使用して、トレース要素のポイントを結ぶ線を描くことができます。ブラシには`Brush.Color`および`Brush.Size`プロパティに対応する独自の色とサイズがあります。

### **インクブラシの色を設定する**

このJavaコードは、ブラシの色を設定する方法を示しています：

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

このJavaコードは、ブラシのサイズを設定する方法を示しています：

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

一般に、ブラシの幅と高さは一致しないため、PowerPointはブラシサイズを表示しません（データセクションはグレーアウトされます）。ただし、ブラシの幅と高さが一致する場合、PowerPointは次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インクオブジェクトの高さを増やし、重要な寸法をレビューしましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮しないため、線の太さがゼロであると仮定します（最後の画像を参照）。 

したがって、全体のインクオブジェクトの可視領域を判断するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここでは、ターゲットオブジェクト（手書きのテキストトレースオブジェクト）がコンテナ（フレーム）サイズにスケーリングされています。コンテナ（フレーム）のサイズが変更されると、ブラシサイズは一定のままであり、その逆も然りです。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPointは、テキストを扱う際にも同様の動作を示します：

![ink_powerpoint6](ink_powerpoint6.png)

**さらなる読み込み**

* シェイプに関する一般的な情報については、[PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/)のセクションを参照してください。
* 有効な値に関する詳細は、[Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value)を参照してください。