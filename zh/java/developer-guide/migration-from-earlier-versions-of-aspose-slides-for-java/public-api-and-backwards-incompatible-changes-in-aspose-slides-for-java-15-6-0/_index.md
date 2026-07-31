---
title: Aspose.Slides for Java 15.6.0 的公共 API 与向后不兼容更改
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以平稳迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="primary" %}} 

此页面列出了所有[新增](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) 类、方法、属性等，以及随 Aspose.Slides for Java 15.6.0 API 引入的任何新限制和其他[更改](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)。

{{% /alert %}} 
## **公共 API 更改**
#### **com.aspose.slides.DataLabel 构造函数签名已更改**
已将构造函数签名从 DataLabel(com.aspose.slides.IChartSeries) 更改为 DataLabel(com.aspose.slides.IChartDataPoint)。
#### **成员 com.aspose.slides.IDocumentProperties.getCount()、.getPropertyName(int index)、.remove(String name) 和 .contains(String name) 已标记为不推荐使用；已引入替代方法**
IDocumentProperties.getCount()、IDocumentProperties.getPropertyName(int index)、.remove(string name) 和 .contains(string name) 已标记为不推荐使用。已引入 IDocumentProperties.countOfCustomProperties()、IDocumentProperties.getCustomPropertyName(int index)、.removeCustomProperty(String name) 和 .containsCustomProperty(string name) 作为替代。
#### **已添加方法 com.aspose.slides.INotesSlideManager.removeNotesSlide()**
已添加方法 com.aspose.slides.INotesSlideManager.RemoveNotesSlide() 用于删除某个幻灯片的备注幻灯片。
#### **已添加方法 com.aspose.slides.ISlide.getNotesSlideManager()；方法 ISlide.getNotesSlide() 和 ISlide.addNotesSlide() 已标记为不推荐使用**
已将 ISlide.getNotesSlide()、ISlide.addNotesSlide() 标记为不推荐使用。请改用新方法 ISlide.getNotesSlideManager()。

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - 已弃用

// notes = slide.getNotesSlide(); - 已弃用

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **已在 com.aspose.slides.IDocumentProperties 中添加方法 getAppVersion()**
已在 com.aspose.slides.IDocumentProperties 中添加方法 getAppVersion()，用于获取内置文档属性，该属性表示 Microsoft PowerPoint 使用的内部版本号。
#### **已在 com.aspose.slides.IComment 中添加方法 remove()**
已在 com.aspose.slides.IComment 中添加方法 remove()，用于从集合中删除评论。
#### **已在 com.aspose.slides.ICommentAuthor 中添加方法 remove()**
已在 ICommentAuthor 中添加方法 Remove，用于从集合中删除评论的作者。
#### **已在 com.aspose.slides.IDocumentProperties 中添加方法 clearCustomProperties() 和 clearBuiltInProperties()**
已在 com.aspose.slides.IDocumentProperties 中添加方法 clearCustomProperties()，用于删除所有自定义文档属性。
已在 com.aspose.slides.IDocumentProperties 中添加方法 clearBuiltInProperties()，用于删除所有内置文档属性并将其设置为默认值（公司、主题、作者等）。
#### **已在 com.aspose.slides.IShape 中添加方法 getBlackWhiteMode()、setBlackWhiteMode(byte)**
已在 com.aspose.slides.IShape 中添加方法 getBlackWhiteMode()、setBlackWhiteMode(byte)。这些方法指定形状在黑白显示模式下的渲染方式。可能的取值在 com.aspose.slides.BlackWhiteMode 类中定义。

|**Value**|**Meaning**|
| :- | :- |
|Color|返回正常颜色|
|Automatic|返回自动颜色|
|Gray|返回灰色|
|LightGray|返回浅灰色|
|InverseGray|返回反向灰色|
|GrayWhite|返回灰白色|
|BlackGray|返回黑灰色|
|BlackWhite|返回黑白色|
|Black|仅返回黑色|
|White|返回白色|
|Hidden|对象不渲染|
#### **已在 com.aspose.slides.ICommentAuthorCollection 中添加方法 removeAt(int)、remove(ICommentAuthor) 和 clear()**
已在 ICommentAuthorCollection 中添加方法 removeAt(int)，用于按指定索引删除作者。已在 ICommentAuthorCollection 中添加方法 remove(ICommentAuthor)，用于从集合中删除指定作者。已在 ICommentAuthorCollection 中添加方法 clear()，用于删除集合中的所有项。