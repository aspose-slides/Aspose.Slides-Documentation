---
title: 演示文稿笔记
type: docs
weight: 110
url: /java/presentation-notes/
keywords: "Java中的PowerPoint发言人笔记"
description: "演示文稿笔记，Java中的发言人笔记"
---


{{% alert color="primary" %}} 

Aspose.Slides支持从演示文稿中删除笔记幻灯片。在本主题中，我们将介绍移除笔记以及从任何演示文稿中添加笔记样式幻灯片的这一新功能。

{{% /alert %}} 

Aspose.Slides for Java提供了删除任何幻灯片的笔记以及为现有笔记添加样式的功能。开发人员可以通过以下方式删除笔记：

* 删除演示文稿中特定幻灯片的笔记。
* 删除演示文稿中所有幻灯片的笔记。


## **从幻灯片中移除笔记**
可以通过下面的示例删除某个特定幻灯片的笔记：

```java
// 实例化一个表示演示文稿文件的Presentation对象
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 删除第一页幻灯片的笔记
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // 将演示文稿保存到磁盘
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **从演示文稿中移除笔记**
可以通过下面的示例删除演示文稿中所有幻灯片的笔记：

```java
// 实例化一个表示演示文稿文件的Presentation对象
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 删除所有幻灯片的笔记
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // 将演示文稿保存到磁盘
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **添加笔记样式**
[getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--)方法已添加到[IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide)接口和[MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide)类中。该属性指定笔记文本的样式。实现示例如下。

```java
// 实例化一个表示演示文稿文件的Presentation对象
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // 获取MasterNotesSlide文本样式
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // 为第一级段落设置符号项目符号
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```