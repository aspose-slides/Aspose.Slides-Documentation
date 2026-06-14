---
title: Aspose.Slides for .NET 14.3.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 14.3.0
type: docs
weight: 50
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
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
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
## **公共 API 與向後不相容的變更**
### **新增 Aspose.Slides.ShapeThumbnailBounds 列舉與 Aspose.Slides.IShape.GetThumbnail() 方法**
GetThumbnail() 和 GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) 方法用於建立單獨的形狀縮圖。ShapeThumbnailBounds 列舉定義了可能的形狀縮圖邊界類型。
### **已在 Aspose.Slides.IShape 中新增 Property UniqueId**
Aspose.Slides.IShape.UniqueId 屬性取得在簡報範圍內唯一的形狀識別碼。這些唯一識別碼存放於形狀的自訂標籤中。
### **IChartCategoryLevelsManager 中 SetGroupingItem 方法的簽名已變更**
IChartCategoryLevelsManager 方法的簽名

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

```

現在已過時，改為以下簽名

``` csharp

 void SetGroupingItem(int level, object value);

```

現在類似

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

```

的呼叫必須改為

``` csharp

 .SetGroupingItem(1, "Group 1");

```

傳入類似「Group 1」的值給 SetGroupingItem，而不是 IChartDataCell 類型的值。使用已定義工作表、行與列的 IChartDataCell 來建構類別層級必須符合某些要求，已在 SetGroupingItem(int, object) 方法中封裝。
### **已在 Aspose.Slides.IBaseSlide 介面中新增 SlideId 屬性**
SlideId 屬性取得唯一的投影片識別碼。
### **已在 ISlideShowTransition 中新增 SoundName 屬性**
可讀寫的字串。指定轉場音效的人類可讀名稱。必須指定 Sound 屬性才能取得或設定音效名稱。此名稱會在 PowerPoint 使用者介面中手動設定轉場音效時顯示。如果未指定 Sound 屬性，可能會拋出 PptxException。
### **ChartSeriesGroup.Type 屬性的類型已變更**
ChartSeriesGroup.Type 屬性已從 ChartType 列舉改為新的 CombinableSeriesTypesGroup 列舉。CombinableSeriesTypesGroup 列舉代表可組合系列類型的群組。
### **已支援產生個別形狀縮圖**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape、Aspose.Slides.Shape 中的新增成員：
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)