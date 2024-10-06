---
title: Aspose.Slides for Java 15.7.0におけるパブリックAPIと互換性のない変更
type: docs
weight: 150
url: /ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.7.0 APIで導入されたすべての[class added](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/)または[class removed](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/)のクラス、メソッド、プロパティなど、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリックAPIの変更**
#### **Enum com.aspose.slides.ImagePixelFormatが追加されました**
生成された画像のピクセルフォーマットを指定するために、Enum com.aspose.slides.ImagePixelFormatが追加されました。
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()メソッドが追加されました**
このメソッドは、シリーズインデックス、データポイントインデックス、parentSeriesGroup、isColorVariedの値、及びチャートスタイルに基づいてデータポイントの自動カラーを返します。fillTypeがNotDefinedの場合、このカラーがデフォルトで使用されます。
#### **メソッドgetPixelFormat()、setPixelFormat(int)がcom.aspose.slides.ITiffOptionsに追加されました**
生成されたTIFF画像のピクセルフォーマットを指定するために、メソッドgetPixelFormat()、setPixelFormat(/ImagePixelFormat/int)がcom.aspose.slides.ITiffOptionsおよびcom.aspose.slides.TiffOptionsに追加されました。

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```