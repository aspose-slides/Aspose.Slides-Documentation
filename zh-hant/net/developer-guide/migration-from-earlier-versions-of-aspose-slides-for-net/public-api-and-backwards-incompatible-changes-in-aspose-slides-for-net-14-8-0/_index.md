---
title: Aspose.Slides for .NET 14.8.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢閱 Aspose.Slides for .NET 的公共 API 更新與重大變更，協助您順利將 PowerPoint PPT、PPTX 與 ODP 簡報解決方案進行遷移。"
---
{{% alert color="primary" %}} 

此頁面列出所有已新增或已移除的類別、方法、屬性等，以及隨 Aspose.Slides for .NET 14.8.0 API 引入的其他變更。

{{% /alert %}} 
## **公開 API 變更**
### **已變更的屬性**
#### **新增 IVbaProject 介面，變更 Presentation.VbaProject 屬性**
Presentation 類別的 VbaProject 屬性已被取代。原本直接以 VBA 專案的原始位元組表示的 VbaProject 屬性，現在已改為使用新的 IVbaProject 介面實作。

使用 IVbaProject 介面來管理嵌入於簡報中的 VBA 專案。您可以新增專案參考、編輯現有模組並建立新模組。

此外，您亦可使用實作 IVbaProject 介面的 VbaProject 類別來建立新的 VBA 專案。

以下範例示範建立一個包含單一模組且新增兩個必要函式庫參考的簡易 VBA 專案。

``` csharp

 using (Presentation pres = new Presentation())

{

    // 建立新的 VBA 專案

    pres.VbaProject = new VbaProject();

    // 將空白模組新增至 VBA 專案

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // 設定模組來源程式碼

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // 建立對 <stdole> 的參考

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // 建立對 Office 的參考

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // 將參考新增至 VBA 專案

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

此範例說明如何將現有簡報中的 VBA 專案複製到新簡報中。

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **新增的介面、屬性與列舉選項**
#### **新增 Aspose.Slides.Charts.IChartSeries.Overlap 屬性**
Aspose.Slides.Charts.IChartSeries.Overlap 屬性指定在 2D 圖表中條形與柱形的重疊程度（範圍為 -100 到 100）。

此屬性不僅適用於該系列，亦適用於父系列群組中的所有系列——它是對相應群組屬性的投影。因此此屬性為唯讀。

- 使用 ParentSeriesGroup 屬性存取父系列群組。
- 使用 ParentSeriesGroup.Overlap 可讀寫屬性來變更值。

``` csharp

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
#### **新增 Aspose.Slides.Charts.IChartSeriesGroup.Overlap 屬性**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap 屬性指定在 2D 圖表中條形與柱形的重疊程度（範圍為 -100 到 100）。

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **新增 ShapeThumbnailBounds.Appearance 列舉值**
此形狀縮圖產生方法可依其外觀範圍產生縮圖，會考慮所有形狀效果，且產生的縮圖受投影片邊界限制。

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```