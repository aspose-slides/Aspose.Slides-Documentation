---
title: Aspose.Slides for .NET 14.3.0 的公共 API 和不兼容的更改
type: docs
weight: 50
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
---

## **公共 API 和不兼容的更改**
### **添加了 Aspose.Slides.ShapeThumbnailBounds 枚举和 Aspose.Slides.IShape.GetThumbnail() 方法**
方法 GetThumbnail() 和 GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) 用于创建一个单独的形状缩略图。ShapeThumbnailBounds 枚举定义了可能的形状缩略图边界类型。
### **Aspose.Slides.IShape 添加了 UniqueId 属性**
Aspose.Slides.IShape.UniqueId 属性获取在演示范围内的唯一形状标识符。这些唯一标识符存储在形状自定义标签中。
### **IChartCategoryLevelsManager 中 SetGroupingItem 方法的签名已更改**
IChartCategoryLevelsManager 方法的签名

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

现在已弃用，替换为签名

``` csharp

 void SetGroupingItem(int level, object value);

``` 

现在，像以下的调用

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

必须更改为像以下的调用

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

将值 "Group 1" 传递给 SetGroupingItem，而不是 IChartDataCell 类型的值。构建带有定义的工作表、行和列的 IChartDataCell 以满足类别级别的一些要求，已被封装在 SetGroupingItem(int, object) 方法中。
### **在 Aspose.Slides.IBaseSlide 接口中添加了 SlideId 属性**
SlideId 属性获取唯一的幻灯片标识符。
### **ISlideShowTransition 添加了 SoundName 属性**
可读写的字符串。指定过渡声音的人类可读名称。必须为 Sound 属性分配值以获取或设置声音名称。此名称在手动配置过渡声音时出现在 PowerPoint 用户界面中。当 Sound 属性未分配时，可能会引发 PptxException。
### **ChartSeriesGroup.Type 属性的类型已更改**
ChartSeriesGroup.Type 属性已从 ChartType枚举更改为新的 CombinableSeriesTypesGroup 枚举。CombinableSeriesTypesGroup 枚举表示可组合系列类型的组。
### **添加了生成单个形状缩略图的支持**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape、Aspose.Slides.Shape 中的新成员：
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)
