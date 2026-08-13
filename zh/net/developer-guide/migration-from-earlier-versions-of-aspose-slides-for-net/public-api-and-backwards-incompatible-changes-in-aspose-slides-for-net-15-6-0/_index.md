---
title: Aspose.Slides for .NET 15.6.0 的公共 API 与向后不兼容的更改
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
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 与 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出所有[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)或[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)的类、方法、属性等，以及在 Aspose.Slides for .NET 15.6.0 API 中引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **DataLabel 构造函数签名已更改**
DataLabel 构造函数签名已更改：
之前：DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
现在：DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint)。

#### **成员 IDocumentProperties.Count、.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) 已标记为过时，并引入了替代成员。**
属性 IDocumentProperties.Count 和方法 IDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) 已被标记为过时。已添加属性 IDocumentProperties.CountOfCustomProperties 和方法 IDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name) 作为替代。

#### **已添加方法 INotesSlideManager.RemoveNotesSlide()**
已添加 INotesSlideManager.RemoveNotesSlide() 方法，用于移除某张幻灯片的备注幻灯片。

#### **已向 IComment 添加 Remove 方法**
已向 IComment 添加 Remove 方法，用于从集合中移除评论。

#### **已向 ICommentAuthor 添加 Remove 方法**
已向 ICommentAuthor 添加 Remove 方法，用于从集合中移除评论作者。

#### **已向 IDocumentProperties 添加方法 ClearCustomProperties 和 ClearBuiltInProperties**
已添加 IDocumentProperties.ClearCustomProperties 方法，用于移除所有自定义文档属性。
已添加 IDocumentProperties.ClearBuiltInProperties 方法，用于移除并将所有内置文档属性（Company、Subject、Author 等）恢复为默认值。

#### **已向 ICommentAuthorCollection 添加方法 RemoveAt、Remove 和 Clear**
已添加 ICommentAuthorCollection.RemoveAt 方法，用于按指定索引移除作者。
已添加 ICommentAuthorCollection.Remove 方法，用于从集合中移除指定作者。
已添加 ICommentAuthorCollection.Clear 方法，用于清空集合中的所有项。

#### **已向 IDocumentProperties 添加属性 AppVersion**
已添加 IDocumentProperties.AppVersion 属性，可获取表示 Microsoft 在开发期间使用的内部版本号的内置文档属性。

#### **已向 IShape 和 Shape 添加属性 BlackWhiteMode**
已向 IShape 和 Shape 添加 BlackWhiteMode 属性。

此属性指定形状在黑白显示模式下的渲染方式。

|**值** |**含义** |
| :- | :- |
|Color |使用正常颜色渲染 |
|Automatic |自动着色渲染 |
|Gray |灰色渲染 |
|LightGray |浅灰色渲染 |
|InverseGray |反向灰色渲染 |
|GrayWhite |灰白渲染 |
|BlackGray |黑灰渲染 |
|BlackWhite |黑白渲染 |
|Black |仅使用黑色渲染 |
|White |使用白色渲染 |
|Hidden |不渲染 |
|NotDefined|表示属性未设置|

#### **属性 ISlide.NotesSlideManager 已添加。属性 ISlide.NotesSlide 和 方法 ISlide.AddNotesSlide() 已标记为过时。**
ISlide.NotesSlide、ISlide.AddNotesSlide() 成员已被标记为过时。请改用新属性 ISlide.NotesSlideManager。

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - 已过时
    // notes = slide.NotesSlide; - 已过时

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```