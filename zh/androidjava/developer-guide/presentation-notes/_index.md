---
title: 管理 Android 上的演示文稿备注
linktitle: 演示文稿备注
type: docs
weight: 110
url: /zh/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 自定义演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提高工作效率。"
---

{{% alert color="primary" %}} 

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍此新功能，即删除备注以及为任意演示文稿添加备注样式幻灯片。 

{{% /alert %}} 

Aspose.Slides for Android via Java 提供了删除任意幻灯片备注以及为现有备注添加样式的功能。开发者可以通过以下方式删除备注：

* 删除演示文稿中特定幻灯片的备注。
* 删除演示文稿中所有幻灯片的备注。


## **从幻灯片中删除备注**
可以按以下示例删除特定幻灯片的备注：
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


## **从演示文稿中删除备注**
可以按以下示例删除演示文稿中所有幻灯片的备注：
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


## **添加备注样式**
[getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) 方法已添加到 [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) 类中。此属性指定备注文本的样式。下面的示例演示了实现。
```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // 获取 MasterNotesSlide 文本样式
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //设置第一层段落的符号项目符号
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**哪个 API 实体提供对特定幻灯片备注的访问？**

备注可通过幻灯片的备注管理器访问：该幻灯片拥有一个 [NotesSlideManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/)，以及一个返回备注对象的 [method](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--)，如果没有备注则返回 `null`。

**在库支持的 PowerPoint 版本之间，备注支持是否有差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97 版及更高）和 ODP；这些格式中均支持备注，且无需依赖已安装的 PowerPoint 副本。