---
title: チャートのエクスポート
type: docs
weight: 90
url: /ja/cpp/export-chart/
keywords:
- チャート
- チャート画像
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides for C++
description: "C++でPowerPointプレゼンテーションからチャート画像を取得する"
---

## **チャート画像を取得する**
Aspose.Slides for C++は、特定のチャートの画像を抽出するためのサポートを提供します。以下にサンプル例を示します。

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```