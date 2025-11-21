---
title: Aspose.Slides for .NET 15.7.0 のパブリック API と後方互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX および ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.7.0 API で導入された、すべての [追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) または [削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) クラス、メソッド、プロパティなどを一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **Enum ImagePixelFormat が追加されました**
Enum Aspose.Slides.Export.ImagePixelFormat が追加され、生成される画像のピクセル形式を指定できます。
#### **IChartDataPoint.GetAutomaticDataPointColor() メソッドが追加されました**
シリーズインデックス、データポイントインデックス、ParentSeriesGroup、IsColorVaried プロパティ、チャートスタイルに基づいてデータポイントの自動カラーを返します。このカラーは FillType が NotDefined の場合にデフォルトで使用されます。
#### **Slide に RenderToGraphics メソッドが追加されました**
Method RenderToGraphics（およびそのオーバーロード）が Aspose.Slides.Slide に追加され、スライドを Graphics オブジェクトにレンダリングできます。
#### **ITiffOptions および TiffOptions に PixelFormat プロパティが追加されました**
Property PixelFormat が Aspose.Slides.Export.ITiffOptions および Aspose.Slides.Export.TiffOptions に追加され、生成される TIFF 画像のピクセル形式を指定できます。