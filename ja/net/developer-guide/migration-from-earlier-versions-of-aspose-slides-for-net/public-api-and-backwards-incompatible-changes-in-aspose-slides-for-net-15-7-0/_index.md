---
title: .NET用Aspose.Slides 15.7.0における公開APIと後方互換性のない変更
type: docs
weight: 180
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.7.0 APIで追加または削除されたすべての[追加された](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/)または[削除された](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/)クラス、メソッド、プロパティなど、及びその他の変更を一覧表示しています。

{{% /alert %}} 
## **公開APIの変更**
#### **Enum ImagePixelFormatが追加されました**
生成される画像のピクセル形式を指定するためのEnum Aspose.Slides.Export.ImagePixelFormatが追加されました。
#### **IChartDataPoint.GetAutomaticDataPointColor()メソッドが追加されました**
系列のインデックス、データポイントのインデックス、ParentSeriesGroup、IsColorVariedプロパティ、およびチャートスタイルに基づいてデータポイントの自動色を返します。
FillTypeがNotDefinedの場合、この色がデフォルトで使用されます。
#### **メソッドRenderToGraphicsがSlideに追加されました**
スライドをGraphicsオブジェクトにレンダリングするためのメソッドRenderToGraphics（およびそのオーバーロード）がAspose.Slides.Slideに追加されました。
#### **プロパティPixelFormatがITiffOptionsおよびTiffOptionsに追加されました**
生成されたTIFF画像のピクセル形式を指定するためのプロパティPixelFormatがAspose.Slides.Export.ITiffOptionsおよびAspose.Slides.Export.TiffOptionsに追加されました。