---
title: Aspose.Slides for Java 15.2.0 公共 API 與向後不相容變更
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
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
description: "檢視 Aspose.Slides for Java 的公共 API 更新與重大變更，協助您順利遷移 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有 [已添加](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) 類別、方法、屬性等，任何新的限制以及其他 [變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)，這些皆隨 Aspose.Slides for Java 15.2.0 API 引入。

{{% /alert %}} {{% alert color="info" %}} 

已知某些圖片項目符號和 WordArt 物件存在問題，將在 Aspose.Slides for Java 15.2.0 中修復。

{{% /alert %}} 
## **公共 API 變更**
### **已新增 addDataPointForDoughnutSeries 方法**
已新增 IChartDataPointCollection.addDataPointForDoughnutSeries() 方法的兩個重載，用於將資料點加入環形圖系列。
### **com.aspose.slides.SmartArtShape 類別已繼承自 com.aspose.slides.GeometryShape 類別**
com.aspose.slides.SmartArtShape 類別已繼承自 com.aspose.slides.GeometryShape 類別。此變更改善了 Aspose.Slides 物件模型，並為 SmartArtShape 類別新增功能。
### **IGradientStopCollection.add(...) 與 IGradientStopCollection.insert(...) 方法已變更**
IGradientStop add(float position, int presetColor) 簽章已替換為 IGradientStop addPresetColor(float position, int presetColor) 簽章。

IGradientStopCollection 方法 IGradientStop add(float position, SchemeColor schemeColor) 簽章已替換為 IGradientStop addSchemeColor(float position, int schemeColor) 簽章。

IGradientStopCollection 方法 void insert(int index, float position, int presetColor) 簽章已替換為 void insertPresetColor(int index, float position, int presetColor) 簽章。

IGradientStopCollection 方法 void insert(int index, float position, SchemeColor schemeColor) 簽章已替換為 void insertSchemeColor(int index, float position, int schemeColor) 簽章。
### **已在 com.aspose.slides.IChartSeries 中新增 java.awt.Color getAutomaticSeriesColor() 方法**
getAutomaticSeriesColor() 方法會根據系列索引與圖表樣式返回自動顏色。如果 FillType 等於 NotDefined，則預設使用此顏色。
 

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **已新增依索引移除圖表資料點與圖表類別的方法**
已新增 IChartDataPointCollection.removeAt(int index) 方法，用於依索引移除圖表資料點。已新增 IChartCategoryCollection.removeAt(int index) 方法，用於依索引移除圖表類別。
### **已在 com.aspose.slides.PropertyType 列舉中新增 PptXPptY 值**
在修復序列化問題的範圍內，已在 com.aspose.slides.PropertyType 列舉中新增 PptXPptY 值。