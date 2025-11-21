---
title: ".NET でプレゼンテーション インク オブジェクトを管理"
linktitle: "インクの管理"
type: docs
weight: 95
url: /ja/net/manage-ink/
keywords:
- インク
- インク オブジェクト
- インク トレース
- インク の 管理
- インク を 描画
- 描画
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint のインク オブジェクトを管理します—Aspose.Slides for .NET を使用してデジタル インクの作成、編集、スタイル設定が可能です。トレース、ブラシの色とサイズのコードサンプルを取得できます。"
---

PowerPoint はインク機能を提供し、標準外の図形を描画でき、他のオブジェクトのハイライトや接続・プロセスの表示、スライド上の特定項目への注意喚起に使用できます。

Aspose.Slides は [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) インターフェイスを提供し、インク オブジェクトの作成と管理に必要な型が含まれています。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプ オブジェクトで表されます。シェイプ オブジェクトは、最も単純な形態ではオブジェクト自体（フレーム）の領域を定義するコンテナと、そのプロパティから構成されます。後者にはコンテナ領域のサイズ、コンテナの形状、コンテナの背景などが含まれます。詳細については [Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

しかし、PowerPoint がインク オブジェクトを扱う場合、サイズ以外のオブジェクト フレーム（コンテナ）のすべてのプロパティは無視されます。コンテナ領域のサイズは標準の `width` と `height` の値で決定されます：

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプトレース**

トレースは、ユーザーがデジタル インクで書く際のペンの軌跡を記録するために使用される基本要素または標準です。トレースは、接続されたポイントのシーケンスを記述する記録です。

エンコードの最も単純な形態は、各サンプルポイントの X と Y 座標を指定します。すべての接続されたポイントが描画されると、次のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシのプロパティ**

トレース要素のポイントを接続する線を描くために、ブラシを使用できます。ブラシは独自の色とサイズを持ち、`Brush.Color` および `Brush.Size` プロパティに対応します。

### **インクブラシの色を設定**

この C# コードはブラシの色を設定する方法を示しています：
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

この C# コードはブラシのサイズを設定する方法を示しています：
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


一般に、ブラシの幅と高さは一致せず、PowerPoint はブラシのサイズを表示しません（データ セクションはグレー表示されます）。しかし、ブラシの幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インク オブジェクトの高さを増やし、重要な寸法を確認しましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さはゼロであると仮定します（最後の画像を参照）。

したがって、インク オブジェクト全体の可視領域を決定するには、トレース オブジェクトのブラシ サイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキスト トレース オブジェクト）がコンテナ（フレーム）サイズにスケーリングされています。コンテナ（フレーム）のサイズが変わると、ブラシ サイズは一定のままであり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストを扱う際にも同様の動作を示します：

![ink_powerpoint6](ink_powerpoint6.png)

**さらに読む**

* シェイプ全般については、[PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/) セクションを参照してください。  
* 有効な値に関する詳細情報は、[Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value) を参照してください。