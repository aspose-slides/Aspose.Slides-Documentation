---
title: 公共 API 與 Aspose.Slides for .NET 14.8.0 的向後不相容變更
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- 遷移
- 舊有程式碼
- 現代程式碼
- 舊有方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與破壞性變更，順利將您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案遷移。"
---
{{% alert color="info" %}} 
此頁面列出所有在 Aspose.Slides for .NET 14.8.0 API 中[added](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)或[removed](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)的類別、方法、屬性等，及其他變更。
{{% /alert %}} 
## **Public API Changes**
### **Changed Properties**
#### **Added the IVbaProject Interface, Changed the Presentation.VbaProject Property**
Presentation 類別的 VbaProject 屬性已被取代。原本以原始位元組表示 VBA 專案的 VbaProject 屬性，已改為使用新的 IVbaProject 介面實作。

使用 IVbaProject 屬性可管理嵌入於簡報中的 VBA 專案。您可以新增專案參考、編輯現有模組，並建立新模組。

同時，您也可以使用實作 IVbaProject 介面的 VbaProject 類別來建立新的 VBA 專案。

以下範例示範建立包含一個模組且加入兩個必要函式庫參考的簡易 VBA 專案。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // 建立新的 VBA 專案
    pres.VbaProject = new VbaProject();

    // 將空的模組加入 VBA 專案
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // 設定模組來源程式碼
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // 建立對 <stdole> 的參照
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // 建立對 Office 的參照
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // 將參照加入 VBA 專案
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);
    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

此範例示範如何將 VBA 專案從現有簡報複製至新簡報。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **Added the Aspose.Slides.Charts.IChartSeries.Overlap Property**
Aspose.Slides.Charts.IChartSeries.Overlap 屬性指定 2D 圖表中的條形與柱狀圖之重疊程度（範圍為 -100 到 100）。

此屬性不僅適用於此系列，也適用於父系列群組中的所有系列——它是對應群組屬性的投射。因此此屬性為唯讀。

- 使用 ParentSeriesGroup 屬性取得父系列群組。
- 使用 ParentSeriesGroup.Overlap 可讀寫屬性變更數值。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap 屬性指定 2D 圖表中的條形與柱狀圖的重疊程度（範圍 -100 到 100）。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
此形狀縮圖產生方法可在形狀外觀的範圍內生成縮圖，會考慮所有形狀效果。產生的形狀縮圖受投影片範圍限制。

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```