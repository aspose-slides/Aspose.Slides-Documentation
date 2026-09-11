---
title: Python via Javaでプレゼンテーションのアクセシビリティを管理
linktitle: プレゼンテーションアクセシビリティ
type: docs
weight: 30
url: /ja/python-java/presentation-accessibility/
keywords:
- プレゼンテーションアクセシビリティ
- 装飾としてマーク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java が PPT、PPTX、ODP ファイルのプレゼンテーションアクセシビリティチェックを自動化し、スクリーンリーダー体験を向上させ、コンプライアンスを強化します。"
---
## **はじめに**

プレゼンテーションのアクセシビリティは、スクリーンリーダー、点字ディスプレイ、キーボードのみの操作などの支援技術を使用する人々が、視覚がありマウスを使用する観客と同様に、スライドを理解し操作できるように保証します。適切な実践では、明確な読み順、情報画像に対する意味のある代替テキスト、十分な色のコントラスト、読みやすいタイポグラフィ、説明的なリンクテキスト、そして色や位置だけで意味を伝えないことに重点を置きます。アクセシビリティを最初から計画すると、構造がすっきりし、ビジュアルがより一貫し、回避策なしで全ての視聴者に届くコンテンツが実現します。

## **装飾としてマーク**

装飾としてマークは、純粋に装飾的なビジュアルにフラグを付け、スクリーンリーダーがそれらをスキップするようにし、ノイズを減らし、意味のあるコンテンツに集中させます。背景や装飾、スペーサーに適用し、情報を伝えるチャート、アイコン、画像には決して適用しません。Aspose.Slides はこのフラグを検出および検証のために公開しており、自動アクセシビリティチェックとクリーンアップを可能にします。

![装飾としてマーク](mark_as_decorative.png)

以下のコードサンプルは、シェイプが装飾としてマークされているかどうかを判定する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```