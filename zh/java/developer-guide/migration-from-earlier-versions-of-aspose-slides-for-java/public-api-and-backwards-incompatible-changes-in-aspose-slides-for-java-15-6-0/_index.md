---
title: Aspose.Slides for Java 15.6.0 的公共 API 和向后不兼容的更改
type: docs
weight: 140
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 15.6.0 API 中添加的 [类](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)、方法、属性等，以及所有新限制和其他 [更改](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)。

{{% /alert %}} 
## **公共 API 更改**
#### **com.aspose.slides.DataLabel 构造函数签名已更改**
构造函数的签名已从 DataLabel(com.aspose.slides.IChartSeries) 更改为 DataLabel(com.aspose.slides.IChartDataPoint)。
#### **成员 com.aspose.slides.IDocumentProperties.getCount()、.getPropertyName(int index)、.remove(String name)、.contains(String name) 已标记为弃用；已引入替代方法**
方法 IDocumentProperties.getCount()、IDocumentProperties.getPropertyName(int index)、.remove(string name)、.contains(string name) 已标记为弃用。已引入替代方法 IDocumentProperties.countOfCustomProperties()、IDocumentProperties.getCustomPropertyName(int index)、.removeCustomProperty(String name)、.containsCustomProperty(string name)。
#### **已添加方法 com.aspose.slides.INotesSlideManager.removeNotesSlide()**
已添加方法 com.aspose.slides.INotesSlideManager.RemoveNotesSlide() 用于移除某个幻灯片的备注幻灯片。
#### **已添加方法 com.aspose.slides.ISlide.getNotesSlideManager()，方法 ISlide.getNotesSlide() 和 ISlide.addNotesSlide() 已标记为弃用**
ISlide.getNotesSlide()、ISlide.addNotesSlide() 方法已标记为弃用。请改用新方法 ISlide.getNotesSlideManager()。

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - 已弃用

// notes = slide.getNotesSlide(); - 已弃用

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **已向 com.aspose.slides.IDocumentProperties 添加 getAppVersion() 方法**
已添加方法 com.aspose.slides.IDocumentProperties.getAppVersion() 以获取内置文档属性，该属性代表 Microsoft PowerPoint 使用的内部版本号。
#### **已向 com.aspose.slides.IComment 添加 remove() 方法**
已添加方法 com.aspose.slides.IComment.remove() 用于从集合中移除评论。
#### **已向 com.aspose.slides.ICommentAuthor 添加 remove() 方法**
已添加方法 ICommentAuthor.Remove 用于从集合中移除评论作者。
#### **已向 com.aspose.slides.IDocumentProperties 添加 clearCustomProperties() 和 clearBuiltInProperties() 方法**
已添加方法 com.aspose.slides.IDocumentProperties.clearCustomProperties() 用于移除所有自定义文档属性。
已添加方法 com.aspose.slides.IDocumentProperties.clearBuiltInProperties() 用于移除并为所有内置文档属性（公司、主题、作者等）设置默认值。
#### **已向 com.aspose.slides.IShape 添加 getBlackWhiteMode() 和 setBlackWhiteMode(byte) 方法**
已向 com.aspose.slides.IShape 添加 getBlackWhiteMode() 和 setBlackWhiteMode(byte) 方法。
这些方法指定形状在黑白显示模式下的渲染方式。可能的值在 com.aspose.slides.BlackWhiteMode 类中定义。

|**值** |**含义** |
| :- | :- |
|Color |正常着色的返回 |
|Automatic |自动着色的返回 |
|Gray |灰色着色的返回 |
|LightGray |浅灰色着色的返回 |
|InverseGray |反向灰色着色的返回 |
|GrayWhite |灰色和白色着色的返回 |
|BlackGray |黑色和灰色着色的返回 |
|BlackWhite |黑色和白色着色的返回 |
|Black |仅返回黑色着色 |
|White |返回白色着色 |
|Hidden |对象未被渲染 |
#### **已向 com.aspose.slides.ICommentAuthorCollection 添加 removeAt(int)、remove(ICommentAuthor) 和 clear() 方法**
已添加方法 ICommentAuthorCollection.removeAt(int) 以通过指定索引移除作者。已添加方法 ICommentAuthorCollection.remove(ICommentAuthor) 以从集合中移除指定的作者。已添加方法 ICommentAuthorCollection.clear() 以从集合中移除所有项。