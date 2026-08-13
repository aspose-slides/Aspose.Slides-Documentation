---
title: Aspose.Slides for Java 15.7.0 的公開 API 與向後不相容變更
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公開 API 更新與重大變更，順利遷移您的 PowerPoint PPT、PPTX 以及 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有在 Aspose.Slides for Java 15.7.0 API 中新增或移除的類別、方法、屬性等，以及其他變更。

{{% /alert %}} 
## **Public API Changes**
#### **Enum com.aspose.slides.ImagePixelFormat has been added**
已新增 Enum com.aspose.slides.ImagePixelFormat，用於指定產生圖像的像素格式。
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() method has been added**
此方法根據系列索引、資料點索引、parentSeriesGroup、isColorVaried 值以及圖表樣式，返回資料點的自動顏色。若 fillType 等於 NotDefined，則預設使用此顏色。
#### **Methods getPixelFormat(), setPixelFormat(int) have been added to com.aspose.slides.ITiffOptions**
已在 com.aspose.slides.ITiffOptions 以及 com.aspose.slides.TiffOptions 中新增 Methods getPixelFormat()、setPixelFormat(/ImagePixelFormat/int)，用於指定產生 TIFF 圖像的像素格式。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```