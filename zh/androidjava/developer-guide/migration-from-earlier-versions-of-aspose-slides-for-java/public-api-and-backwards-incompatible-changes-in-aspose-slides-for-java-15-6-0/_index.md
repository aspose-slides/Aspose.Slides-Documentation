---
title: Aspose.Slides for Java 15.6.0 的公共 API 和不兼容的变化
type: docs
weight: 140
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 15.6.0 API 中添加的 [类](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)、方法、属性等，以及任何新的限制和其他 [更改](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) 。

{{% /alert %}} 
## **公共 API 变更**
#### **com.aspose.slides.DataLabel 构造函数签名已更改**
构造函数的签名已从 DataLabel(com.aspose.slides.IChartSeries) 更改为 DataLabel(com.aspose.slides.IChartDataPoint)。
#### **成员 com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) 已被标记为过时；已引入替代方法**
方法 IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name) 已被标记为过时。引入了方法 IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name)。
#### **方法 com.aspose.slides.INotesSlideManager.removeNotesSlide() 已添加**
方法 com.aspose.slides.INotesSlideManager.RemoveNotesSlide() 已添加，用于删除某个幻灯片的备注幻灯片。
#### **方法 com.aspose.slides.ISlide.getNotesSlideManager() 已添加。方法 ISlide.getNotesSlide() 和 ISlide.addNotesSlide() 已被标记为过时**
ISlide.getNotesSlide(), ISlide.addNotesSlide() 方法已被标记为过时。请改用新方法 ISlide.getNotesSlideManager()。

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - 已过时

// notes = slide.getNotesSlide(); - 已过时

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **方法 getAppVersion() 已添加到 com.aspose.slides.IDocumentProperties**
方法 com.aspose.slides.IDocumentProperties.getAppVersion() 已添加，以获取表示 Microsoft PowerPoint 使用的内部版本号的内置文档属性。
#### **方法 remove() 已添加到 com.aspose.slides.IComment**
方法 com.aspose.slides.IComment.remove() 已添加，用于从集合中删除注释。
#### **方法 remove() 已添加到 com.aspose.slides.ICommentAuthor**
方法 ICommentAuthor.Remove 已添加，用于从集合中删除注释的作者。
#### **方法 clearCustomProperties() 和 clearBuiltInProperties() 已添加到 com.aspose.slides.IDocumentProperties**
方法 com.aspose.slides.IDocumentProperties.clearCustomProperties() 已添加，用于删除所有自定义文档属性。
方法 com.aspose.slides.IDocumentProperties.clearBuiltInProperties() 已添加，用于删除并设置所有内置文档属性（公司、主题、作者等）的默认值。
#### **方法 getBlackWhiteMode(), setBlackWhiteMode(byte) 已添加到 com.aspose.slides.IShape**
方法 getBlackWhiteMode(), setBlackWhiteMode(byte) 已添加到 com.aspose.slides.IShape。
这些方法指定形状在黑白显示模式下的渲染方式。可能的值在 com.aspose.slides.BlackWhiteMode 类中指定。

|**值** |**含义** |
| :- | :- |
|Color |正常着色返回 |
|Automatic |自动着色返回 |
|Gray |灰色着色返回 |
|LightGray |浅灰色着色返回 |
|InverseGray |反向灰色着色返回 |
|GrayWhite |灰色和白色着色返回 |
|BlackGray |黑色和灰色着色返回 |
|BlackWhite |黑色和白色着色返回 |
|Black |仅黑色返回 |
|White |白色着色返回 |
|Hidden |对象未渲染 |
#### **方法 removeAt(int), remove(ICommentAuthor) 和 clear() 已添加到 com.aspose.slides.ICommentAuthorCollection**
方法 ICommentAuthorCollection.removeAt(int) 已添加，用于通过指定索引删除作者。方法 ICommentAuthorCollection.remove(ICommentAuthor) 已添加，用于从集合中删除指定的作者。方法 ICommentAuthorCollection.clear() 已添加，用于从集合中删除所有项目。