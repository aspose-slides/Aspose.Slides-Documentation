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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページは、Aspose.Slides for .NET 15.7.0 APIで導入された、追加された[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/)または削除された[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/)クラス、メソッド、プロパティなど、そしてその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **Enum ImagePixelFormat が追加されました**
Enum Aspose.Slides.Export.ImagePixelFormat が追加され、生成された画像のピクセル形式を指定できるようになりました。
#### **IChartDataPoint.GetAutomaticDataPointColor() メソッドが追加されました**
Series インデックス、データポイント インデックス、ParentSeriesGroup、IsColorVaried プロパティ、およびチャート スタイルに基づいてデータポイントの自動カラーを返します。このカラーは FillType が NotDefined の場合にデフォルトで使用されます。
#### **Method RenderToGraphics が Slide に追加されました**
Method RenderToGraphics（およびそのオーバーロード）が Aspose.Slides.Slide に追加され、スライドを Graphics オブジェクトにレンダリングできるようになりました。
#### **Property PixelFormat が ITiffOptions および TiffOptions に追加されました**
Property PixelFormat が Aspose.Slides.Export.ITiffOptions および Aspose.Slides.Export.TiffOptions に追加され、生成された TIFF 画像のピクセル形式を指定できるようになりました。