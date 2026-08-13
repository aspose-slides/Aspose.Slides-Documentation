---
title: Aspose.Slides for Java 14.10.0 的公共 API 及向後不相容變更
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
description: "檢視 Aspose.Slides for Java 的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)類別、方法、屬性等，任何新的限制以及其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)，這些皆是隨 Aspose.Slides for Java 14.10.0 API 引入的。

{{% /alert %}} 
## **公共 API 變更**
### **已新增 com.aspose.slides.FieldType.getFooter() 方法**
getFooter() 方法會回傳頁腳欄位類型。此方法的加入是為了實作可建立此類型欄位的功能，以及確保簡報的有效序列化。
### **已刪除元素 com.aspose.slides.ShapeElementFillSource.Own**
元素 ShapeElementFillSource.Own 已被刪除，因為它是重複的。請改用 ShapeElementFillSource.Shape 取代 ShapeElementFillSource.Own。
### **已新增移除圖表資料點與類別的方法**
**已新增以下方法，可從圖表資料點集合中移除圖表資料點：**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**已新增以下方法，可從所屬集合中移除圖表類別：**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


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
### **已移除過時的 Aspose.Slides.ParagraphFormat 方法**
已移除以下方法 getBulletChar()、getBulletColor()、getBulletColorFormat()、getBulletFont()、getBulletHeight()、getBulletType()、isBulletHardColor()、isBulletHardFont()、getNumberedBulletStartWith()、getNumberedBulletStyle() 以及對應的 set 方法。這些方法早已被標示為過時。
### **已移除無用且過時的建構函式**
已移除以下建構函式：

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