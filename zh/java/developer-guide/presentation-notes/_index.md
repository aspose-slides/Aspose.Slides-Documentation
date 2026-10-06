---
title: 在 Java 中管理演示文稿备注
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
- 母版备注
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 定制演示文稿备注。轻松处理 PowerPoint 和 OpenDocument 备注，提高工作效率。"
---
## **概览**

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍此功能，包括如何删除备注以及如何为演示文稿中的备注幻灯片应用样式。Aspose.Slides 允许您从任意幻灯片删除备注，也可以对现有备注应用样式。开发人员可以通过以下方式删除备注：

- 从演示文稿的特定幻灯片删除备注。
- 从演示文稿的所有幻灯片删除备注。

要读取或更改备注页面尺寸、切换方向以及检查导出行为，请参阅[备注页面大小](/slides/zh/java/notes-size/)。

## **从幻灯片删除备注**
可以按照下面示例从特定幻灯片删除备注：

```java
import com.aspose.slides.*;

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

## **从演示文稿删除备注**
可以按照下面示例从演示文稿的所有幻灯片删除备注：

```java
import com.aspose.slides.*;

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
[getNotesStyle](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) 方法已分别添加到[IMasterNotesSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IMasterNotesSlide)接口和[MasterNotesSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/MasterNotesSlide)类中。此属性指定备注文本的样式。下面的示例演示了其实现。

```java
import com.aspose.slides.*;

// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // 获取 MasterNotesSlide 文本样式
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //设置符号项目符号用于第一级段落
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

备注通过幻灯片的备注管理器访问：该幻灯片有一个[NotesSlideManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/notesslidemanager/)和一个返回备注对象的[method](https://reference.aspose.com/slides/zh/java/com.aspose.slides/notesslidemanager/#getNotesSlide--)，如果没有备注则返回`null`。

**在库支持的 PowerPoint 版本之间，备注支持是否存在差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97 及更高版本）和 ODP；在这些格式中均支持备注，而无需依赖已安装的 PowerPoint 副本。