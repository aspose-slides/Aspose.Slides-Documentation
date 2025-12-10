---
title: Aspose.Slides for .NET 15.6.0 中的公共 API 及向后不兼容的更改
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有已[添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)或已[删除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 15.6.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **DataLabel 构造函数签名已更改**
DataLabel 构造函数签名已更改：
之前：DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
现在：DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint)。
#### **成员 IDocumentProperties.Count、.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) 已标记为过时，并已引入其替代方案。**
属性 IDocumentProperties.Count 与方法 IDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) 已标记为过时。已添加属性 IDocumentProperties.CountOfCustomProperties 与方法 IDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name) 作为替代。
#### **已添加 INotesSlideManager.RemoveNotesSlide() 方法**
已添加 INotesSlideManager.RemoveNotesSlide() 方法，用于删除某张幻灯片的备注幻灯片。
#### **已向 IComment 添加 Remove 方法**
已向 IComment 添加 Remove 方法，用于从集合中删除注释。
#### **已向 ICommentAuthor 添加 Remove 方法**
已向 ICommentAuthor 添加 Remove 方法，用于从集合中删除注释作者。
#### **已向 IDocumentProperties 添加 ClearCustomProperties 和 ClearBuiltInProperties 方法**
已添加 IDocumentProperties.ClearCustomProperties 方法，用于删除所有自定义文档属性。
已添加 IDocumentProperties.ClearBuiltInProperties 方法，用于删除并为所有内置文档属性（Company、Subject、Author 等）设置默认值。
#### **已向 ICommentAuthorCollection 添加 RemoveAt、Remove 和 Clear 方法**
已添加 ICommentAuthorCollection.RemoveAt 方法，用于按指定索引删除作者。
已添加 ICommentAuthorCollection.Remove 方法，用于从集合中删除指定作者。
已添加 ICommentAuthorCollection.Clear 方法，用于删除集合中的全部项。
#### **已向 IDocumentProperties 添加 AppVersion 属性**
已添加 IDocumentProperties.AppVersion 属性，以获取表示 Microsoft 开发期间内部版本号的内置文档属性。
#### **已向 IShape 和 Shape 添加 BlackWhiteMode 属性**
已向 IShape 和 Shape 添加 BlackWhiteMode 属性。

此属性指定形状在黑白显示模式下的渲染方式。

|**值** |**含义** |
| :- | :- |
|Color |使用正常颜色渲染 |
|Automatic |使用自动颜色渲染 |
|Gray |使用灰色渲染 |
|LightGray |使用浅灰色渲染 |
|InverseGray |使用反向灰色渲染 |
|GrayWhite |使用灰白色渲染 |
|BlackGray |使用黑灰色渲染 |
|BlackWhite |使用黑白色渲染 |
|Black |仅使用黑色渲染 |
|White |使用白色渲染 |
|Hidden |不渲染 |
|NotDefined|表示属性未设置|
#### **已添加 ISlide.NotesSlideManager 属性。ISlide.NotesSlide 属性和 ISlide.AddNotesSlide() 方法已标记为过时。**
ISlide.NotesSlide、ISlide.AddNotesSlide() 已标记为过时。请使用新属性 ISlide.NotesSlideManager。

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```