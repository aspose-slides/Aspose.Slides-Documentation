---
title: Aspose.Slides for Java 15.6.0 的公共 API 及向后不兼容更改
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- 迁移
- 旧代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出了所有[added](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) 类、方法、属性等，以及随 Aspose.Slides for Java 15.6.0 API 引入的任何新限制和其他[changes](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)。

{{% /alert %}} 
## **公共 API 更改**
#### **com.aspose.slides.DataLabel 构造函数签名已更改**
构造函数的签名已从 DataLabel(com.aspose.slides.IChartSeries) 更改为 DataLabel(com.aspose.slides.IChartDataPoint)。

#### **成员 com.aspose.slides.IDocumentProperties.getCount()、.getPropertyName(int index)、.remove(String name)、.contains(String name) 已标记为过时；已引入替代方案**
IDocumentProperties.getCount()、IDocumentProperties.getPropertyName(int index)、.remove(string name) 和 .contains(string name) 方法已标记为过时。相应地，引入了 IDocumentProperties.countOfCustomProperties()、IDocumentProperties.getCustomPropertyName(int index)、.removeCustomProperty(String name) 和 .containsCustomProperty(string name) 方法。

#### **已添加方法 com.aspose.slides.INotesSlideManager.removeNotesSlide()**
已添加 com.aspose.slides.INotesSlideManager.RemoveNotesSlide() 方法，用于删除某个幻灯片的备注页。

#### **已添加方法 com.aspose.slides.ISlide.getNotesSlideManager()。 ISlide.getNotesSlide() 与 ISlide.addNotesSlide() 方法已标记为过时**
ISlide.getNotesSlide()、ISlide.addNotesSlide() 方法已标记为过时，请改用新方法 ISlide.getNotesSlideManager()。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - 已弃用

    // notes = slide.getNotesSlide(); - 已弃用

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **已在 com.aspose.slides.IDocumentProperties 中添加方法 getAppVersion()**
已添加 com.aspose.slides.IDocumentProperties.getAppVersion() 方法，用于获取内置文档属性，该属性表示 Microsoft PowerPoint 使用的内部版本号。

#### **已在 com.aspose.slides.IComment 中添加方法 remove()**
已添加 com.aspose.slides.IComment.remove() 方法，用于从集合中删除评论。

#### **已在 com.aspose.slides.ICommentAuthor 中添加方法 remove()**
已添加 ICommentAuthor.Remove 方法，用于从集合中删除评论作者。

#### **已在 com.aspose.slides.IDocumentProperties 中添加方法 clearCustomProperties() 和 clearBuiltInProperties()**
已添加 com.aspose.slides.IDocumentProperties.clearCustomProperties() 方法，用于删除所有自定义文档属性。  
已添加 com.aspose.slides.IDocumentProperties.clearBuiltInProperties() 方法，用于删除并将所有内置文档属性（公司、主题、作者等）恢复为默认值。

#### **已在 com.aspose.slides.IShape 中添加方法 getBlackWhiteMode()、setBlackWhiteMode(byte)**
已在 com.aspose.slides.IShape 中添加 getBlackWhiteMode()、setBlackWhiteMode(byte) 方法。这些方法指定形状在黑白显示模式下的渲染方式。可能的取值在 com.aspose.slides.BlackWhiteMode 类中定义。

|**值** |**含义** |
| :- | :- |
|Color |返回普通颜色 |
|Automatic |返回自动上色 |
|Gray |返回灰色 |
|LightGray |返回浅灰色 |
|InverseGray |返回反向灰色 |
|GrayWhite |返回灰白色 |
|BlackGray |返回黑灰色 |
|BlackWhite |返回黑白色 |
|Black |仅返回黑色 |
|White |返回白色 |
|Hidden |对象不渲染 |

#### **已在 com.aspose.slides.ICommentAuthorCollection 中添加方法 removeAt(int)、remove(ICommentAuthor) 和 clear()**
已添加 ICommentAuthorCollection.removeAt(int) 方法，用于按指定索引删除作者。已添加 ICommentAuthorCollection.remove(ICommentAuthor) 方法，用于从集合中删除指定作者。已添加 ICommentAuthorCollection.clear() 方法，用于删除集合中的所有项目。