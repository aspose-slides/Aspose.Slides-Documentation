---
title: Aspose.Slides for .NET 15.7.0 のパブリック API と後方互換性がない変更
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページは、Aspose.Slides for .NET 15.7.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) または [削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) クラス、メソッド、プロパティ等、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **公開 API の変更**
#### **Enum ImagePixelFormat が追加されました**
生成された画像のピクセル形式を指定するために、Enum Aspose.Slides.Export.ImagePixelFormat が追加されました。
#### **IChartDataPoint.GetAutomaticDataPointColor() メソッドが追加されました**
シリーズインデックス、データポイントインデックス、ParentSeriesGroup、IsColorVaried プロパティ、およびチャートスタイルに基づいてデータポイントの自動カラーを返します。  
FillType が NotDefined の場合、この色がデフォルトで使用されます。
#### **Method RenderToGraphics が Slide に追加されました**
Aspose.Slides.Slide にメソッド RenderToGraphics（およびそのオーバーロード）が追加され、スライドを Graphics オブジェクトに描画できるようになりました。
#### **Property PixelFormat が ITiffOptions と TiffOptions に追加されました**
生成された TIFF 画像のピクセル形式を指定するために、Aspose.Slides.Export.ITiffOptions と Aspose.Slides.Export.TiffOptions に Property PixelFormat が追加されました。