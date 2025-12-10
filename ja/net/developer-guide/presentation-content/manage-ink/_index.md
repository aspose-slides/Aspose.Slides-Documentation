---
title: .NET でプレゼンテーションのインクオブジェクトを管理する
linktitle: インクの管理
type: docs
weight: 95
url: /ja/net/manage-ink/
keywords:
- インク
- インク オブジェクト
- インク トレース
- インクの管理
- インクの描画
- 描画
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint のインクオブジェクトを管理し、.NET 用 Aspose.Slides でデジタルインクの作成、編集、スタイル設定を行います。トレース、ブラシの色とサイズのコードサンプルをご覧ください。"
---

PowerPoint はインク機能を提供し、標準外の図形を描くことができ、他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。  

Aspose.Slides は、インク オブジェクトの作成と管理に必要な型を含む [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) インターフェイスを提供します。  

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプ オブジェクトで表されます。シェイプ オブジェクトは、最もシンプルな形では、オブジェクト自体の領域（フレーム）とそのプロパティを定義するコンテナです。これにはコンテナ領域のサイズ、コンテナの形状、コンテナの背景などが含まれます。詳細は [Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape) を参照してください。  

しかし、PowerPoint がインク オブジェクトを扱う場合、コンテナのサイズ以外のすべてのフレーム（コンテナ）プロパティは無視されます。コンテナ領域のサイズは標準の `width` と `height` の値で決まります：  

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプ トレース**

トレースは、ユーザーがデジタル インクで書く際のペンの軌跡を記録するための基本要素または標準です。トレースは、接続された点のシーケンスを記述する記録です。  

最も単純なエンコード形式は、各サンプル点の X および Y 座標を指定します。すべての接続された点がレンダリングされると、次のような画像が生成されます：  

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシ プロパティ**

ブラシを使用して、トレース要素の点を結ぶ線を描画できます。ブラシには `Brush.Color` と `Brush.Size` プロパティに対応する独自の色とサイズがあります。  

### **インク ブラシの色を設定**

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


### **インク ブラシのサイズを設定**  

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


一般に、ブラシの幅と高さは一致せず、PowerPoint はブラシサイズを表示しません（データ セクションはグレー表示）。ただし、ブラシの幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します：  

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インク オブジェクトの高さを増やして重要な寸法を確認しましょう：  

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さがゼロであると見なします（最後の画像を参照）。  

したがって、インク オブジェクト全体の表示領域を決定するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここで、対象オブジェクト（手書きテキスト トレース オブジェクト）はコンテナ（フレーム）サイズに合わせてスケーリングされています。コンテナ（フレーム）のサイズが変わると、ブラシサイズは一定のままであり、逆も同様です。  

![ink_powerpoint5](ink_powerpoint5.png)

テキストを扱う場合も、PowerPoint は同様の挙動を示します：  

![ink_powerpoint6](ink_powerpoint6.png)

**さらに読む**

* 一般的なシェイプについて読むには、[PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/) セクションを参照してください。  
* 効果的な値に関する詳細は、[Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value) を参照してください。