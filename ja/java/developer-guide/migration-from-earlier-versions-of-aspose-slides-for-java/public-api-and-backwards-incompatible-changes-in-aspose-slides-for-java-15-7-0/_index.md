---
title: Aspose.Slides for Java 15.7.0における公開APIと後方互換性のない変更
type: docs
weight: 150
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.7.0 APIで追加または削除されたすべての[追加された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/)クラス、メソッド、プロパティなど、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **公開APIの変更**
#### **Enum com.aspose.slides.ImagePixelFormatが追加されました**
生成された画像のピクセル形式を指定するために、Enum com.aspose.slides.ImagePixelFormatが追加されました。
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()メソッドが追加されました**
このメソッドは、系列インデックス、データポイントインデックス、親系列グループ、isColorVaried値、およびチャートスタイルに基づいてデータポイントの自動色を返します。この色は、fillTypeがNotDefinedの場合にデフォルトで使用されます。
#### **メソッドgetPixelFormat()、setPixelFormat(int)がcom.aspose.slides.ITiffOptionsに追加されました**
生成されたTIFF画像のピクセル形式を指定するために、メソッドgetPixelFormat()、setPixelFormat(/ImagePixelFormat/int)がcom.aspose.slides.ITiffOptionsおよびcom.aspose.slides.TiffOptionsに追加されました。

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```