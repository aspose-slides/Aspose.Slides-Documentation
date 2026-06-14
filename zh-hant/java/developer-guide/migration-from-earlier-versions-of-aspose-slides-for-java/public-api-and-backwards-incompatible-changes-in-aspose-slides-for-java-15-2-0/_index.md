---
title: Aspose.Slides for Java 15.2.0 的公開 API 以及相容性中斷變更
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- 移植
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢閱 Aspose.Slides for Java 的公開 API 更新與相容性中斷變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有[新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)的類別、方法、屬性等，任何新限制以及其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) ，這些皆為 Aspose.Slides for Java 15.2.0 API 所引入。

{{% /alert %}} {{% alert color="primary" %}} 

已知部份影像項目符號與 WordArt 物件存在問題，將在 Aspose.Slides for Java 15.2.0 中修復。

{{% /alert %}} 
## **公開 API 變更**
### **已新增 addDataPointForDoughnutSeries 方法**
已新增 IChartDataPointCollection.addDataPointForDoughnutSeries() 方法的兩個重載，用於將資料點加入 Doughnut 類型的系列中。
### **com.aspose.slides.SmartArtShape 類別已從 com.aspose.slides.GeometryShape 類別繼承**
com.aspose.slides.SmartArtShape 類別已從 com.aspose.slides.GeometryShape 類別繼承。此變更改善了 Aspose.Slides 物件模型，並為 SmartArtShape 類別加入新功能。
### **IGradientStopCollection.add(...) 與 IGradientStopCollection.insert(...) 方法已變更**
IGradientStop add(float position, int presetColor) 簽名已改為 IGradientStop addPresetColor(float position, int presetColor) 簽名。

IGradientStopCollection 方法 IGradientStop add(float position, SchemeColor schemeColor) 簽名已改為 IGradientStop addSchemeColor(float position, int schemeColor) 簽名。

IGradientStopCollection 方法 void insert(int index, float position, int presetColor) 簽名已改為 void insertPresetColor(int index, float position, int presetColor) 簽名。

IGradientStopCollection 方法 void insert(int index, float position, SchemeColor schemeColor) 簽名已改為 void insertSchemeColor(int index, float position, int schemeColor) 簽名。
### **已在 com.aspose.slides.IChartSeries 中新增 java.awt.Color getAutomaticSeriesColor() 方法**
getAutomaticSeriesColor() 方法根據系列索引和圖表樣式返回自動系列顏色。如果 FillType 為 NotDefined，則預設使用此顏色。
 
``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **已新增依索引移除圖表資料點與圖表類別的方法**
已新增 IChartDataPointCollection.removeAt(int index) 方法，用於依索引移除圖表資料點。
已新增 IChartCategoryCollection.removeAt(int index) 方法，用於依索引移除圖表類別。
### **已在 com.aspose.slides.PropertyType 列舉型別中新增 PptXPptY 值**
為了解決序列化問題，已在 com.aspose.slides.PropertyType 列舉型別中加入 PptXPptY 值。