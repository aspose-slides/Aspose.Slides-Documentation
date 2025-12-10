---
title: 管理 Java 中的演示文稿备注
linktitle: 演示文稿备注
type: docs
weight: 110
url: /zh/java/presentation-notes/
keywords:
- 备注
- 备注幻灯片
- 添加备注
- 删除备注
- 备注样式
- 主备注
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 定制演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提高工作效率。"
---

{{% alert color="primary" %}} 
Aspose.Slides 支持从演示文稿中删除备注幻灯片。本章节将介绍删除备注以及为任意演示文稿添加备注样式的全新功能。 
{{% /alert %}} 
Aspose.Slides for Java 提供删除任意幻灯片备注以及为现有备注添加样式的功能。开发者可以通过以下方式删除备注：

* 删除演示文稿中特定幻灯片的备注。
* 删除演示文稿中所有幻灯片的备注。

## **Remove Notes from a Slide**
可以如下面示例所示删除某个特定幻灯片的备注：
```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 删除第一张幻灯片的备注
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // 将演示文稿保存到磁盘
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Remove Notes from a Presentation**
可以如下面示例所示删除演示文稿中所有幻灯片的备注：
```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 删除所有幻灯片的备注
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


## **Add a Notes Style**
[getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) 方法已分别添加到 [IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) 类中。此属性指定备注文本的样式。下面的示例演示了其实现。
```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // 获取 MasterNotesSlide 文本样式
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // 为第一层段落设置符号项目符号
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Which API entity provides access to the notes of a specific slide?**  
备注可通过幻灯片的备注管理器访问：该幻灯片拥有一个 [NotesSlideManager](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/) 和一个 [method](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/#getNotesSlide--)，该方法返回备注对象，如果没有备注则返回 `null`。

**Are there differences in notes support across the PowerPoint versions the library works with?**  
该库支持广泛的 Microsoft PowerPoint 格式（97 及以后版本）以及 ODP；在这些格式中均支持备注，无需依赖已安装的 PowerPoint。