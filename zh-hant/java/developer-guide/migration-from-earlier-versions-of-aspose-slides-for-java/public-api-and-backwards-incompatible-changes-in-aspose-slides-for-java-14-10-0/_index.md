---
title: Aspose.Slides for Java 14.10.0 的公開 API 與向後不相容變更
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
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
description: "檢閱 Aspose.Slides for Java 的公開 API 更新與重大變更，順利將您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案遷移。"
---
{{% alert color="primary" %}} 
此頁面列出所有[新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) 類別、方法、屬性等，任何新的限制以及其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) 隨 Aspose.Slides for Java 14.10.0 API 引入的內容。
{{% /alert %}} 
## **Public API Changes**
### **com.aspose.slides.FieldType.getFooter() method has been added**
getFooter() 方法回傳頁腳欄位類型。此方法已新增，以支援建立此類型的欄位並確保簡報的有效序列化。

### **Element com.aspose.slides.ShapeElementFillSource.Own has been deleted**
元素 com.aspose.slides.ShapeElementFillSource.Own 已被刪除。元素 ShapeElementFillSource.Own 因為重複而被刪除。請改用 ShapeElementFillSource.Shape 取代 ShapeElementFillSource.Own。

### **Methods for chart data points, categories removing have been added**
**以下方法允許從圖表資料點集合中移除圖表資料點，已新增：**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()

**以下方法允許從所在集合中移除圖表類別，已新增：**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // 使用 ChartCategory.remove() 移除

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // 使用 ChartCategoryCollection.remove() 移除

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // 使用 ChartDataPoint.remove() 移除

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // 使用 ChartDataPointCollection.remove() 移除

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Obsolete Aspose.Slides.ParagraphFormat methods have been removed**
已移除方法 getBulletChar()、getBulletColor()、getBulletColorFormat()、getBulletFont()、getBulletHeight()、getBulletType()、isBulletHardColor()、isBulletHardFont()、getNumberedBulletStartWith()、getNumberedBulletStyle() 以及相應的 set 方法。這些方法早已標記為過時。

### **Un-useful and obsolete constructors have been removed**
以下建構函式已被移除：

com.aspose.slides.AlphaBiLevel(float)  
com.aspose.slides.AlphaModulateFixed(float)  
com.aspose.slides.AlphaReplace(float)  
com.aspose.slides.BiLevel(float)  
com.aspose.slides.Blur(double, boolean)  
com.aspose.slides.HSL(float, float, float)  
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)  
com.aspose.slides.Luminance(float, float)  
com.aspose.slides.Tint(float, float)  
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)  
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)  
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)