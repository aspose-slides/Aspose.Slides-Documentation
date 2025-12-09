---
title: コネクタ
type: docs
weight: 190
url: /ja/net/examples/elements/connector/
keywords:
- コネクタ例
- コネクタを追加
- コネクタにアクセス
- コネクタを削除
- シェイプを再接続
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して C# でコネクタを描画および制御します。追加、ルーティング、再ルーティング、接続ポイント、矢印、スタイルを設定して、PPT、PPTX、ODP のシェイプをリンクします。"
---

**Aspose.Slides for .NET** を使用して、シェイプをコネクタで接続し、ターゲットを変更する方法を示します。

## コネクタを追加

スライド上の2点間にコネクタ形状を挿入します。
```csharp
static void Add_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```


## コネクタにアクセス

スライドに追加された最初のコネクタ形状を取得します。
```csharp
static void Access_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```


## コネクタを削除

スライドからコネクタを削除します。
```csharp
static void Remove_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(conn);
}
```


## シェイプを再接続

開始ターゲットと終了ターゲットを割り当てて、コネクタを2つのシェイプに接続します。
```csharp
static void Reconnect_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    conn.StartShapeConnectedTo = shape1;
    conn.EndShapeConnectedTo = shape2;
}
```
