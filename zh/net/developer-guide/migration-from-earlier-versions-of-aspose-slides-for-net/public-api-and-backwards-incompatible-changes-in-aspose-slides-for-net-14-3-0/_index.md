---
title: "Aspose.Slides for .NET 14.3.0 中的公共 API 及向后不兼容的更改"
linktitle: "Aspose.Slides for .NET 14.3.0"
type: docs
weight: 50
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 的公共 API 更新和不兼容的更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

## **公共 API 和 向后不兼容的更改**
### **Aspose.Slides.ShapeThumbnailBounds 枚举 和 Aspose.Slides.IShape.GetThumbnail() 方法已添加**
GetThumbnail() 和 GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) 方法用于创建单独的形状缩略图。ShapeThumbnailBounds 枚举定义了可能的形状缩略图边界类型。
### **已向 Aspose.Slides.IShape 添加 UniqueId 属性**
Aspose.Slides.IShape.UniqueId 属性获取在演示文稿范围内唯一的形状标识符。这些唯一标识符存储在形状自定义标签中。
### **IChartCategoryLevelsManager 中 SetGroupingItem 方法的签名已更改**

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

已过时，已替换为以下签名

``` csharp

 void SetGroupingItem(int level, object value);

``` 

现在的调用方式如

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

必须更改为如下调用方式

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

请向 SetGroupingItem 传入诸如 "Group 1" 之类的字符串值，而不是 IChartDataCell 类型的值。使用已定义的工作表、行和列构造 IChartDataCell 以用于类别层级需要满足某些要求，这些已在 SetGroupingItem(int, object) 方法中封装。
### **已在 Aspose.Slides.IBaseSlide 接口中添加 SlideId 属性**
SlideId 属性获取唯一的幻灯片标识符。
### **已在 ISlideShowTransition 中添加 SoundName 属性**
可读写的字符串。指定用于过渡效果的声音的可读名称。必须为 Sound 属性赋值才能获取或设置声音名称。当手动配置过渡声音时，此名称会显示在 PowerPoint 用户界面中。如果未为 Sound 属性赋值，可能会抛出 PptxException。
### **ChartSeriesGroup.Type 属性的类型已更改**
ChartSeriesGroup.Type 属性已从 ChartType 枚举更改为新的 CombinableSeriesTypesGroup 枚举。CombinableSeriesTypesGroup 枚举表示可组合系列类型的分组。
### **已添加 对生成单个形状缩略图 的支持**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape、Aspose.Slides.Shape 中的新成员：
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)