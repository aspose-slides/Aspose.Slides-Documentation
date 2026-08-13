---
title: Aspose.Slides for Java 15.7.0 のパブリック API と下位互換性がない変更
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- 旧来のアプローチ
- 最新のアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for Java 15.7.0 APIで導入された、追加されたまたは削除されたクラス、メソッド、プロパティなど、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **Enum com.aspose.slides.ImagePixelFormat が追加されました**
Enum com.aspose.slides.ImagePixelFormat が、生成される画像のピクセル形式を指定するために追加されました。
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() メソッドが追加されました**
このメソッドは、系列インデックス、データポイントインデックス、parentSeriesGroup、isColorVaried の値、およびチャートスタイルに基づいてデータポイントの自動カラーを返します。fillType が NotDefined の場合、このカラーがデフォルトで使用されます。
#### **メソッド getPixelFormat()、setPixelFormat(int) が com.aspose.slides.ITiffOptions に追加されました**
生成される TIFF 画像のピクセル形式を指定するために、メソッド getPixelFormat()、setPixelFormat(/ImagePixelFormat/int) が com.aspose.slides.ITiffOptions および com.aspose.slides.TiffOptions に追加されました。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```