---
title: Aspose.Slides for .NET 15.6.0 中的公共 API 及向后不兼容的更改
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审查 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 
此页面列出所有[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)或[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)的类、方法、属性等，以及随 Aspose.Slides for .NET 15.6.0 API 引入的其他更改。
{{% /alert %}} 
## **公共 API 更改**
#### **DataLabel 构造函数签名已更改**
DataLabel 构造函数签名已更改:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **成员 IDocumentProperties.Count、.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) 已标记为过时，并引入了相应的替代方案。**
Property IDocumentProperties.Count 和 methods IDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) 已标记为过时。已添加 Property IDocumentProperties.CountOfCustomProperties 和 methods IDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name) 作为替代。
#### **已添加方法 INotesSlideManager.RemoveNotesSlide()**
已添加方法 INotesSlideManager.RemoveNotesSlide() 用于删除某个幻灯片的备注页。
#### **已在 IComment 中添加方法 Remove**
已在 IComment 中添加方法 Remove，用于从集合中删除注释。
#### **已在 ICommentAuthor 中添加方法 Remove**
已在 ICommentAuthor 中添加方法 Remove，用于从集合中删除注释作者。
#### **已在 IDocumentProperties 中添加方法 ClearCustomProperties 和 ClearBuiltInProperties**
已在 IDocumentProperties 中添加方法 ClearCustomProperties 用于删除所有自定义文档属性。
已在 IDocumentProperties 中添加方法 ClearBuiltInProperties 用于删除并将所有内置文档属性（Company、Subject、Author 等）设置为默认值。
#### **已在 ICommentAuthorCollection 中添加方法 RemoveAt、Remove 和 Clear**
已在 ICommentAuthorCollection 中添加方法 RemoveAt 用于按指定索引删除作者。
已在 ICommentAuthorCollection 中添加方法 Remove 用于从集合中删除指定作者。
已在 ICommentAuthorCollection 中添加方法 Clear 用于删除集合中的所有项。
#### **已在 IDocumentProperties 中添加属性 AppVersion**
已在 IDocumentProperties 中添加属性 AppVersion，用于获取内置文档属性，该属性表示 Microsoft 在开发期间使用的内部版本号。
#### **已在 IShape 和 Shape 中添加属性 BlackWhiteMode**
已在 IShape 和 Shape 中添加属性 BlackWhiteMode。

此属性指定形状在黑白显示模式下的呈现方式。

|**值**|**含义**|
| :- | :- |
|Color|正常颜色渲染|
|Automatic|自动颜色渲染|
|Gray|灰色渲染|
|LightGray|浅灰色渲染|
|InverseGray|反向灰色渲染|
|GrayWhite|灰白渲染|
|BlackGray|黑灰渲染|
|BlackWhite|黑白渲染|
|Black|仅黑色渲染|
|White|白色渲染|
|Hidden|不渲染|
|NotDefined|表示属性未设置|
#### **已添加属性 ISlide.NotesSlideManager。属性 ISlide.NotesSlide 和 方法 ISlide.AddNotesSlide() 已标记为过时。**
ISlide.NotesSlide、ISlide.AddNotesSlide() 已标记为过时。请改用新的属性 ISlide.NotesSlideManager。

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```