---
title: Aspose.Slides for Java 14.8.0 的公共 API 及向後不相容變更
linktitle: Aspose.Slides for Java 14.8.0
type: docs
weight: 70
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
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
description: "檢視 Aspose.Slides for Java 的公共 API 更新與重大變更，協助您順利遷移 PowerPoint PPT、PPTX 以及 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)類別、方法、屬性等，任何新的限制以及隨 Aspose.Slides for Java 14.8.0 API 引入的其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)。

{{% /alert %}} 
## **公共 API 變更**
### **新增 Aspose.Slides.Charts.IChartSeries.getOverlap()、IChartSeriesGroup.getOverlap() 以及 setOverlap(byte) 方法**
Aspose.Slides.Charts.IChartSeries.getOverlap() 取得 2D 圖表中長條與柱狀圖的重疊程度（範圍從 -100 到 100）。  
此方法不僅適用於特定資料列，而是適用於父資料列群組的所有資料列——這是對相應群組屬性的投影。

- 使用 IChartSeries.getParentSeriesGroup() 方法以存取父資料列群組。  
- 使用 IChartSeriesGroup.getOverlap() 與 setOverlap(byte) 方法來管理該值。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **新增 ShapeThumbnailBounds.Appearance 列舉值**
此建立形狀縮圖的方法允許開發人員在其外觀的範圍內產生形狀縮圖，會考慮所有形狀效果。產生的形狀縮圖受到投影片範圍的限制。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **新增 VbaProject 類別與 IVbaProject 介面，變更 Presentation.getVbaProject() 與 setVbaProject(VbaProject) 方法**
此新功能允許開發人員在簡報中建立與編輯 VBA 專案。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// 建立新的 VBA 專案

pres.setVbaProject(new VbaProject());

// 為 VBA 專案新增空的模組

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// 設定模組原始碼

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// 建立對 <stdole> 的參考

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// 建立對 Office 的參考

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// 為 VBA 專案新增參考

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);

```