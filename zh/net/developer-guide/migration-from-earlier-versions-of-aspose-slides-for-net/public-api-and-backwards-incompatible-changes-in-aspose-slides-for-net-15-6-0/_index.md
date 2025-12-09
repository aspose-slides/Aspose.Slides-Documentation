---
title: Aspose.Slides for .NET 15.6.0 中的公共 API 与向后不兼容的更改
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
description: "回顾 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，帮助您平稳迁移 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出了所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)或[已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 15.6.0 API 引入的其他更改。

{{% /alert %}} 
## **Public API Changes**
#### **DataLabel constructor signature has been changed**
DataLabel 构造函数签名已更改：
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Members IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) have been marked as Obsolete and its substitutions have been introduced instead.**
属性 IDocumentProperties.Count 和方法 IDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) 已标记为已弃用。已添加属性 IDocumentProperties.CountOfCustomProperties 和方法 IDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name) 作为替代。
#### **Method INotesSlideManager.RemoveNotesSlide() has been added**
已添加方法 INotesSlideManager.RemoveNotesSlide() 用于删除某张幻灯片的备注幻灯片。
#### **Method Remove has been added to IComment**
已在 IComment 中添加方法 Remove，用于从集合中删除评论。
#### **Method Remove has been added to ICommentAuthor**
已在 ICommentAuthor 中添加方法 Remove，用于从集合中删除评论作者。
#### **Methods ClearCustomProperties and ClearBuiltInProperties have been added to IDocumentProperties**
已在 IDocumentProperties 中添加方法 ClearCustomProperties，用于删除所有自定义文档属性。  
已在 IDocumentProperties 中添加方法 ClearBuiltInProperties，用于删除并将所有内置文档属性（Company、Subject、Author 等）设置为默认值。
#### **Methods RemoveAt, Remove and Clear have been added to ICommentAuthorCollection**
已在 ICommentAuthorCollection 中添加方法 RemoveAt，用于按指定索引删除作者。  
已在 ICommentAuthorCollection 中添加方法 Remove，用于从集合中删除指定作者。  
已在 ICommentAuthorCollection 中添加方法 Clear，用于清除集合中的所有项。
#### **Property AppVersion has been added to IDocumentProperties**
已在 IDocumentProperties 中添加属性 AppVersion，用于获取表示 Microsoft 开发期间内部版本号的内置文档属性。
#### **Property BlackWhiteMode has been added to IShape and to Shape**
已在 IShape 和 Shape 中添加属性 BlackWhiteMode。

此属性指定形状在黑白显示模式下的渲染方式。

|**Value**|**Meaning**|
|:-|:-|
|Color|使用正常颜色渲染|
|Automatic|使用自动颜色渲染|
|Gray|使用灰色渲染|
|LightGray|使用浅灰色渲染|
|InverseGray|使用反向灰色渲染|
|GrayWhite|使用灰色和白色渲染|
|BlackGray|使用黑色和灰色渲染|
|BlackWhite|使用黑白渲染|
|Black|仅使用黑色渲染|
|White|使用白色渲染|
|Hidden|不渲染|
|NotDefined|表示属性未设置|
#### **Рroperty ISlide.NotesSlideManager has been added. Property ISlide.NotesSlide and method ISlide.AddNotesSlide() have been marked as Obsolete.**
ISlide.NotesSlide、ISlide.AddNotesSlide() 已标记为已弃用。请使用新属性 ISlide.NotesSlideManager。

```csharp
 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();
```