---
title: Aspose.Slides for PHP via Java 15.7.0 の公開 API と後方互換性のない変更
type: docs
weight: 150
url: /ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 15.7.0 API で追加または削除されたすべての [added](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) または [removed](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) クラス、メソッド、プロパティなどおよび他の変更を一覧表示します。

{{% /alert %}} 
## **公開 API の変更**
#### **Enum com.aspose.slides.ImagePixelFormat が追加されました**
生成された画像のピクセル形式を指定するために、Enum com.aspose.slides.ImagePixelFormat が追加されました。
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() メソッドが追加されました**
このメソッドは、系列インデックス、データポイントインデックス、親系列グループ、isColorVaried 値、およびチャートスタイルに基づいてデータポイントの自動色を返します。fillType が NotDefined の場合、この色がデフォルトとして使用されます。
#### **メソッド getPixelFormat()、setPixelFormat(int) が com.aspose.slides.ITiffOptions に追加されました**
生成された TIFF 画像のピクセル形式を指定するために、メソッド getPixelFormat()、setPixelFormat(/ImagePixelFormat/int) が com.aspose.slides.ITiffOptions および com.aspose.slides.TiffOptions に追加されました。

```php
  $pres = new Presentation("demo.pptx");
  $options = new TiffOptions();
  $options->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
  $pres->save("demo-out.tiff", SaveFormat::Tiff, $options);
```