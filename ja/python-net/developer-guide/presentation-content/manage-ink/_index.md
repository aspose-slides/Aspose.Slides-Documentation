---
title: インクの管理
type: docs
weight: 95
url: /ja/python-net/manage-ink/
keywords: "PowerPointのインク, インクツール, Pythonインク, PowerPointで描画, PowerPointプレゼンテーション, Python, .NET経由のAspose.Slides for Python"
description: "PythonでPowerPointのオブジェクトを描画するためにインクツールを使用する"
---

PowerPointはインク機能を提供しており、非標準の図形を描画して他のオブジェクトを強調表示したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くことができます。

Aspose.Slidesは、インクオブジェクトを作成および管理するために必要なタイプを含む[Aspose.Slides.Ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/)インターフェイスを提供します。

## **通常のオブジェクトとインクオブジェクトの違い**

PowerPointのスライド上のオブジェクトは通常、シェイプオブジェクトによって表されます。シェイプオブジェクトは、最も単純な形では、オブジェクト自体の領域（そのフレーム）とそのプロパティを定義するコンテナです。後者には、コンテナ領域のサイズ、コンテナの形状、コンテナの背景などが含まれます。詳細については、[シェイプレイアウトフォーマット](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape)を参照してください。

しかし、PowerPointがインクオブジェクトを処理する場合、サイズを除くすべてのオブジェクトフレーム（コンテナ）のプロパティは無視されます。コンテナ領域のサイズは、標準の`width`と`height`の値によって決まります:

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプのトレース**

トレースは、ユーザーがデジタルインクを書く際のペンの軌跡を記録するための基本的な要素または標準です。トレースは、接続された点のシーケンスを説明する記録です。

エンコーディングの最も単純な形式は、各サンプルポイントのXおよびY座標を指定します。接続されたすべての点が描画されると、次のような画像が生成されます:

![ink_powerpoint2](ink_powerpoint2.png)

## 描画のためのブラシプロパティ

トレース要素のポイントを接続する線を描くためにブラシを使用できます。ブラシは、その`Brush.Color`および`Brush.Size`プロパティに対応する独自の色とサイズを持っています。

### **インクブラシの色を設定する**

このPythonコードは、ブラシの色を設定する方法を示しています:

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

### **インクブラシのサイズを設定する**

このPythonコードは、ブラシのサイズを設定する方法を示しています:

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

一般的に、ブラシの幅と高さは一致しないため、PowerPointはブラシサイズを表示しません（データセクションはグレー表示されます）。しかし、ブラシの幅と高さが一致する場合、PowerPointはそのサイズを次のように表示します:

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インクオブジェクトの高さを増やし、重要な次元を確認しましょう:

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さはゼロであると仮定します（最後の画像を参照）。

したがって、インクオブジェクト全体の可視領域を決定するためには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここで、対象オブジェクト（手書きのテキストトレースオブジェクト）はコンテナ（フレーム）サイズにスケールされました。コンテナ（フレーム）のサイズが変更されると、ブラシサイズは一定のままであり、逆もまた同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPointはテキストを扱うときも同じ動作を示します:

![ink_powerpoint6](ink_powerpoint6.png)

**さらなる学習**

* 形状について全般的に読むには、[PowerPointの形状](https://docs.aspose.com/slides/python-net/powerpoint-shapes/)セクションを参照してください。
* 効果的な値についての詳細は、[シェイプの効果的プロパティ](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value)を参照してください。