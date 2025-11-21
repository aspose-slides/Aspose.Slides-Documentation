---
title: Aspose.Slides for .NET 14.3.0 的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.3.0
type: docs
weight: 50
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- 迁移
- 传统代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以平稳迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

## **公共 API 和向后不兼容的更改**
### **已添加 Aspose.Slides.ShapeThumbnailBounds 枚举以及 Aspose.Slides.IShape.GetThumbnail() 方法**
GetThumbnail() 方法和 GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) 方法用于创建单独的形状缩略图。ShapeThumbnailBounds 枚举定义了可能的形状缩略图边界类型。

### **已在 Aspose.Slides.IShape 中添加 UniqueId 属性**
Aspose.Slides.IShape.UniqueId 属性获取在演示文稿范围内唯一的形状标识符。这些唯一标识符存储在形状的自定义标签中。

### **IChartCategoryLevelsManager 中 SetGroupingItem 方法的签名已更改**
IChartCategoryLevelsManager 方法的签名

```csharp
 void SetGroupingItem(int level, IChartDataCell value);
``` 

现已废弃，并替换为以下签名

```csharp
 void SetGroupingItem(int level, object value);
``` 

现在类似的调用

```csharp
 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));
``` 

必须改为如下调用

```csharp
 .SetGroupingItem(1, "Group 1");
``` 

将类似 "Group 1" 的值传递给 SetGroupingItem，而不是 IChartDataCell 类型的值。使用已定义的工作表、行和列构造 IChartDataCell 以用于类别层级需要满足一些要求，这些已在 SetGroupingItem(int, object) 方法中封装。

### **已在 Aspose.Slides.IBaseSlide 接口中添加 SlideId 属性**
SlideId 属性获取唯一的幻灯片标识符。

### **已在 ISlideShowTransition 中添加 SoundName 属性**
可读写的字符串。指定过渡效果声音的可读名称。必须先为 Sound 属性赋值后才能获取或设置声音名称。该名称在 PowerPoint 用户界面中手动配置过渡声音时显示。如果未为 Sound 属性赋值，可能会抛出 PptxException。

### **ChartSeriesGroup.Type 属性的类型已更改**
ChartSeriesGroup.Type 属性已从 ChartType 枚举更改为新的 CombinableSeriesTypesGroup 枚举。CombinableSeriesTypesGroup 枚举表示可组合系列类型的分组。

### **已添加对生成单个形状缩略图的支持**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape、Aspose.Slides.Shape 中的新成员：
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)