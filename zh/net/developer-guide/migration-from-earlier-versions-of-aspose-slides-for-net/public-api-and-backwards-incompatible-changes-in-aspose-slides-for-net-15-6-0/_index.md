---
title: Aspose.Slides for .NET 15.6.0 的公共 API 和不兼容更改
type: docs
weight: 170
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
---

{{% alert color="primary" %}} 

此页面列出了 Aspose.Slides for .NET 15.6.0 API 中所有 [新增](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) 或 [移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) 的类、方法、属性等以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **DataLabel 构造函数签名已更改**
DataLabel 构造函数签名已更改：
之前：DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
现在：DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint)。
#### **成员 IDocumentProperties.Count，.GetPropertyName(int index)，.Remove(string name)，.Contains(string name) 已标记为过时，并引入了替代项。**
属性 IDocumentProperties.Count 和方法 IDocumentProperties.GetPropertyName(int index)，.Remove(string name)，.Contains(string name) 已标记为过时。属性 IDocumentProperties.CountOfCustomProperties 和方法 IDocumentProperties.GetCustomPropertyName(int index)，.RemoveCustomProperty(string name)，.ContainsCustomProperty(string name) 已被添加作为替代。
#### **已添加方法 INotesSlideManager.RemoveNotesSlide()**
已添加方法 INotesSlideManager.RemoveNotesSlide() 来移除某个幻灯片的备注幻灯片。
#### **已添加方法 Remove 到 IComment**
已添加方法 IComment.Remove 用于从集合中移除评论。
#### **已添加方法 Remove 到 ICommentAuthor**
已添加方法 ICommentAuthor.Remove 用于从集合中移除评论作者。
#### **已添加方法 ClearCustomProperties 和 ClearBuiltInProperties 到 IDocumentProperties**
已添加方法 IDocumentProperties.ClearCustomProperties 用于移除所有自定义文档属性。
已添加方法 IDocumentProperties.ClearBuiltInProperties 用于移除并设置所有内置文档属性（公司、主题、作者等）的默认值。
#### **已添加方法 RemoveAt、Remove 和 Clear 到 ICommentAuthorCollection**
已添加方法 ICommentAuthorCollection.RemoveAt 用于通过指定索引移除作者。
已添加方法 ICommentAuthorCollection.Remove 用于从集合中移除指定作者。
已添加方法 ICommentAuthorCollection.Clear 用于从集合中移除所有项。
#### **已添加属性 AppVersion 到 IDocumentProperties**
已添加属性 IDocumentProperties.AppVersion 用于获取表示 Microsoft 开发期间使用的内部版本号的内置文档属性。
#### **已添加属性 BlackWhiteMode 到 IShape 和 Shape**
已添加属性 BlackWhiteMode 到 IShape 和 Shape。

该属性指定形状在黑白显示模式下的渲染方式。

|**值** |**含义** |
| :- | :- |
|Color |正常颜色渲染 |
|Automatic |自动颜色渲染 |
|Gray |灰色渲染 |
|LightGray |淡灰色渲染 |
|InverseGray |反向灰色渲染 |
|GrayWhite |灰白色渲染 |
|BlackGray |黑灰色渲染 |
|BlackWhite |黑白色渲染 |
|Black |仅黑色渲染 |
|White |白色渲染 |
|Hidden |不渲染 |
|NotDefined|表示该属性未设置|
#### **已添加属性 ISlide.NotesSlideManager。属性 ISlide.NotesSlide 和方法 ISlide.AddNotesSlide() 已标记为过时。**
ISlide.NotesSlide、ISlide.AddNotesSlide() 成员已标记为过时。请改用新属性 ISlide.NotesSlideManager。

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - 过时

// notes = slide.NotesSlide; - 过时

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

``` 