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
description: "通过 Java 为 Android 的 Aspose.Slides 定制演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提升您的工作效率。"
---
## **概述**

Aspose.Slides 支持从演示文稿中删除备注幻灯片。本章节将介绍此功能，包括如何删除备注以及如何为演示文稿中的备注幻灯片应用样式。Aspose.Slides 允许您删除任意幻灯片的备注，也可以对现有备注应用样式。开发者可以通过以下方式删除备注：

- 删除演示文稿中特定幻灯片的备注。
- 删除演示文稿中所有幻灯片的备注。

有关读取或更改备注页尺寸、切换方向以及检查导出行为，请参阅[Notes Page Size](/slides/zh/androidjava/notes-size/)。

## **从幻灯片删除备注**
可以按以下示例删除特定幻灯片的备注：

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
可以按以下示例删除演示文稿中所有幻灯片的备注：

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
[getNotesStyle](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) 方法已分别添加到 [IMasterNotesSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IMasterNotesSlide) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/MasterNotesSlide) 类中。此属性指定备注文本的样式。下面的示例演示了实现方式。

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

备注通过幻灯片的备注管理器访问：幻灯片拥有一个 [NotesSlideManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notesslidemanager/) 和一个返回备注对象的 [method](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--)，如果没有备注则返回 `null`。

**库在不同的 PowerPoint 版本中对备注的支持是否存在差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97 及以后）和 ODP；在这些格式中均支持备注，且不依赖已安装的 PowerPoint 副本。