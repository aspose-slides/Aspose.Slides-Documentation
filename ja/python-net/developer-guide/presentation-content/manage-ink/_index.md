---
title: Pythonでプレゼンテーションのインクオブジェクトを管理する
linktitle: インクの管理
type: docs
weight: 95
url: /ja/python-net/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インクの管理
- インクの描画
- 描画
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPoint のインクオブジェクトを管理します — Aspose.Slides for Python via .NET を使用してデジタルインクを作成、編集、スタイル設定できます。トレースやブラシの色・サイズのコードサンプルを取得してください。"
---

PowerPoint はインク機能を提供し、標準的でない図形の描画を可能にします。この機能は、他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

Aspose.Slides は [aspose.slides.ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/) 名前空間を提供し、インク オブジェクトの作成と管理に必要な型が含まれています。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint のスライド上のオブジェクトは通常、シェイプ オブジェクトで表されます。シェイプ オブジェクトは、最も単純な形では、オブジェクト自体（フレーム）の領域とそのプロパティを定義するコンテナです。後者には、コンテナ領域のサイズ、コンテナの形状、コンテナの背景などが含まれます。詳細は [Shape Layout Format](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

しかし、PowerPoint がインク オブジェクトを扱う場合、サイズ以外のオブジェクト フレーム（コンテナ）のすべてのプロパティは無視されます。コンテナ領域のサイズは標準の `width` と `height` 値で決定されます：

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプ トレース**

トレースは、ユーザーがデジタル インクで文字を書く際にペンの軌跡を記録する基本要素または標準です。トレースは、接続された点のシーケンスを記述する記録です。

最も単純なエンコーディング形式は、各サンプル点の X および Y 座標を指定します。すべての接続された点が描画されると、以下のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## 描画用ブラシ プロパティ

ブラシを使用して、トレース要素の点を結ぶ線を描くことができます。ブラシは独自の色とサイズを持ち、`Brush.color` および `Brush.size` プロパティに対応します。

### **インク ブラシの色を設定**

この Python コードは、ブラシの色を設定する方法を示しています：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```


### **インク ブラシのサイズを設定**

この Python コードは、ブラシのサイズを設定する方法を示しています：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```


通常、ブラシの幅と高さは一致しないため、PowerPoint はブラシ サイズを表示しません（データ セクションはグレー表示になります）。ただし、ブラシの幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

分かりやすくするために、インク オブジェクトの高さを増やし、重要な寸法を確認しましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さはゼロであるとみなします（最後の画像を参照）。

したがって、インク オブジェクト全体の可視領域を決定するには、トレース オブジェクトのブラシ サイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストのトレース オブジェクト）がコンテナ（フレーム）サイズに合わせてスケーリングされています。コンテナ（フレーム）のサイズが変わっても、ブラシのサイズは一定のままで、その逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

テキストを扱う場合も、PowerPoint は同様の動作を示します：

![ink_powerpoint6](ink_powerpoint6.png)

**さらに読む**

* 形状全般について読むには、[PowerPoint Shapes](https://docs.aspose.com/slides/python-net/powerpoint-shapes/) セクションを参照してください。 
* 有効な値に関する詳細は、[Shape Effective Properties](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value) を参照してください。