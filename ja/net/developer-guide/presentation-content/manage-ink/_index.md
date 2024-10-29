---
title: インクの管理
type: docs
weight: 95
url: /ja/net/manage-ink/
keywords: "PowerPoint のインク、インクツール、C# インク、PowerPoint での描画、PowerPoint プレゼンテーション、C#、Csharp、Aspose.Slides for .NET "
description: "C# で PowerPoint のオブジェクトを描画するためのインクツールを使用します。"
---

PowerPoint は、標準でない図形を描画するためのインク機能を提供します。これにより、他のオブジェクトを強調表示したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くことができます。

Aspose.Slides は、インクオブジェクトを作成・管理するために必要なタイプを含む [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) インターフェイスを提供します。

## **通常のオブジェクトとインクオブジェクトの違い**

PowerPoint のスライド上のオブジェクトは通常、シェイプオブジェクトで表されます。シェイプオブジェクトは、その最も単純な形では、オブジェクト自体の領域（フレーム）とそのプロパティを定義するコンテナです。これには、コンテナの領域サイズ、コンテナの形状、コンテナの背景などが含まれます。詳細については、[シェイプレイアウト形式](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape)を参照してください。

しかし、PowerPoint がインクオブジェクトを扱う場合、オブジェクトフレーム（コンテナ）のプロパティはサイズを除いてすべて無視されます。コンテナ領域のサイズは標準の `width` と `height` の値によって決定されます:

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプのトレース**

トレースは、ユーザーがデジタルインクを描く際にペンの軌跡を記録するために使用される基本的な要素または標準です。トレースは、接続された点のシーケンスを説明する記録です。

エンコーディングの最も単純な形は、各サンプルポイントの X と Y 座標を指定します。すべての接続されたポイントが描画されると、このような画像が生成されます:

![ink_powerpoint2](ink_powerpoint2.png)

## 描画のためのブラシプロパティ 

ブラシを使ってトレース要素のポイントを結ぶ線を描画できます。ブラシには独自の色とサイズがあり、`Brush.Color` と `Brush.Size` プロパティに対応しています。

### **インクブラシの色を設定**

この C# コードは、ブラシの色を設定する方法を示しています:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **インクブラシのサイズを設定** 

この C# コードは、ブラシのサイズを設定する方法を示しています:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

一般に、ブラシの幅と高さは一致しないため、PowerPoint はブラシのサイズを表示しません（データセクションはグレーアウトされます）。ただし、ブラシの幅と高さが一致する場合、PowerPoint はこのようにサイズを表示します:

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インクオブジェクトの高さを増やし、重要な寸法を確認しましょう: 

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さがゼロであると仮定します（最後の画像を参照）。

したがって、全インクオブジェクトの可視領域を決定するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここで、ターゲットオブジェクト（手書きテキストのトレースオブジェクト）は、コンテナ（フレーム）サイズにスケーリングされています。コンテナ（フレーム）のサイズが変更されるとブラシサイズは一定のままですが、その逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストを扱う場合も同様の動作を示します:

![ink_powerpoint6](ink_powerpoint6.png)

**さらなる読み物**

* シェイプ全般について読むには、[PowerPoint シェイプ](https://docs.aspose.com/slides/net/powerpoint-shapes/) セクションを参照してください。
* 有効な値についての詳細は、[シェイプの有効プロパティ](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value)を参照してください。