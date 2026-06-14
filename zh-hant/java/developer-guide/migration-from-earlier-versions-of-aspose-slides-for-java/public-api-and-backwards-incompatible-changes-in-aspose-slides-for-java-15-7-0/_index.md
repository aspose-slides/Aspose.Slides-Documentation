---
title: Aspose.Slides for Java 15.7.0 公共 API 與向後相容性不相容變更
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- 遷移
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢閱 Aspose.Slides for Java 中的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/)或已移除](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/)的類別、方法、屬性等，及 Aspose.Slides for Java 15.7.0 API 所帶來的其他變更。

{{% /alert %}} 
## **公共 API 變更**
#### **已新增 Enum com.aspose.slides.ImagePixelFormat**
已新增 Enum com.aspose.slides.ImagePixelFormat，用於指定產生圖像的像素格式。
#### **已新增 com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() 方法**
此方法根據系列索引、資料點索引、parentSeriesGroup、isColorVaried 值以及圖表樣式，返回資料點的自動顏色。若 fillType 為 NotDefined，則預設使用此顏色。
#### **已將 getPixelFormat()、setPixelFormat(int) 方法新增至 com.aspose.slides.ITiffOptions**
已將 getPixelFormat()、setPixelFormat(/ImagePixelFormat/int) 方法新增至 com.aspose.slides.ITiffOptions 及 com.aspose.slides.TiffOptions，用於指定產生 TIFF 圖像的像素格式。

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```