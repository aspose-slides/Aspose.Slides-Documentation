---
title: Aspose.Slides for .NET 16.2.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
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
description: "檢閱 Aspose.Slides for .NET 的公共 API 更新與重大變更，協助您順利遷移 PowerPoint PPT、PPTX 以及 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有[added](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)或[removed](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)的類別、方法、屬性等，以及 Aspose.Slides for .NET 16.2.0 API 所引入的其他變更。

{{% /alert %}} 
## **公共 API 變更**
#### **已移除屬性 UpdateDateTimeFields 與 UpdateSlideNumberFields**
屬性 UpdateDateTimeFields 與 UpdateSlideNumberFields 已從 Aspose.Slides.Presentation 類別以及 Aspose.Slides.IPresentation 介面中移除。  
Aspose.Slides.TextFrame、Paragraph、Portion 類別以及 Aspose.Slides.ITextFrame、IParagraph、IPortion 介面的 Text 屬性會回傳已更新「datetime」欄位的文字。  
此外，Presentation.DocumentProperties.CreatedTime、LastSavedTime 與 LastPrinted 屬性已變為唯讀。  

#### **列舉 Slides.Charts.CategoryAxisType 已切換為 public**
用於 IAxis.CategoryAxisType 與 Axis.CategoryAxisType 屬性，以決定類別軸的類型。  
CategoryAxisType.Auto - 類別軸類型將於序列化時自動決定（此行為目前尚未實作）  
CategoryAxisType.Text - 類別軸類型為文字  
CategoryAxisType.Date - 類別軸類型為日期時間  

#### **快速文字擷取**
已在 Presentation 類別中加入新的靜態方法 GetPresentationText。此方法有兩個重載版本：

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode 列舉參數指示文字結果的組織模式，可設定為以下值：  
Unarranged - 原始文字，未考慮投影片上的位置  
Arranged - 文字依投影片上的順序排列  

在對速度有嚴格要求時可使用 Unarranged 模式，它比 Arranged 模式更快。  

PresentationText 代表從簡報中擷取的原始文字。它包含來自 Aspose.Slides.Util 命名空間的 SlidesText 屬性，該屬性回傳 ISlideText 物件的陣列。每個物件代表相應投影片上的文字。ISlideText 物件具有以下屬性：  

ISlideText.Text - 投影片形狀上的文字  
ISlideText.MasterText - 此投影片母版頁面形狀上的文字  
ISlideText.LayoutText - 此投影片版面配置頁面形狀上的文字  
ISlideText.NotesText - 此投影片備註頁面形狀上的文字  

此外，還有實作 ISlideText 介面的 SlideText 類別。  

新 API 可這樣使用：

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **已加入 ILegacyDiagram 介面與 LegacyDiagram 類別**
已新增 Aspose.Slides.ILegacyDiagram 介面與 Aspose.Slides.LegacyDiagram 類別，用以表示舊版圖表物件。舊版圖表是 PowerPoint 97‑2003 時期的圖表格式。  
此類別提供方法，可將舊版圖表轉換為可編輯的現代 SmartArt 物件或可編輯的 GroupShape。  

#### **新增 Aspose.Slides.TextAlignment 列舉成員 (JustifyLow)**
已新增 TextAlignment 列舉成員：  
JustifyLow - 低階 Kashida 兩端對齊。  

#### **為 Aspose.Slides.IOleObjectFrame 與 OleObjectFrame 新增屬性**
已在 IOleObjectFrame 介面及實作此介面的 OleObjectFrame 類別中加入新屬性，這些屬性用於提供嵌入簡報之物件的資訊：  
EmbeddedFileExtension - 回傳目前嵌入物件的檔案副檔名；若物件不是連結則回傳空字串  
EmbeddedFileLabel - 回傳嵌入 OLE 物件的檔案名稱  
EmbeddedFileName - 回傳嵌入 OLE 物件的路徑  

#### **已於 IAxis 與 Axis 類別新增屬性 CategoryAxisType**
CategoryAxisType 屬性指定類別軸的類型。

``` csharp

 using (Presentation pres = new Presentation(sourcePptxFileName))

{

   IChart chart = pres.Slides[0].Shapes[0] as IChart;

   chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;

   chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;

   chart.Axes.HorizontalAxis.MajorUnit = 1;

   chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

   pres.Save(pptxOutPath, SaveFormat.Pptx);

}

``` 
#### **已於 DataLabelFormat 類別與 IDataLabelFormat 介面新增屬性 ShowLabelAsDataCallout**
ShowLabelAsDataCallout 屬性決定指定圖表的資料標籤是顯示為資料標註（callout）還是顯示為資料標籤本身。

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **已於 PdfOptions 與 XpsOptions 新增屬性 DrawSlidesFrame**
布林屬性 DrawSlidesFrame 已加入至介面 Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions 以及相關類別 Aspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptions。  
若此屬性設為 true，則會在每張投影片周圍繪製黑色框線。

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```