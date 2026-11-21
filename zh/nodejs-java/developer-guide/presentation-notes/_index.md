---
title: 在 JavaScript 中管理演示文稿备注
linktitle: 演示文稿备注
type: docs
weight: 110
url: /zh/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中自定义演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提高工作效率。"
---
## **概述**

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍此功能，包括如何删除备注以及如何对演示文稿中的备注幻灯片应用样式。Aspose.Slides 允许您从任意幻灯片删除备注，也可以对现有备注应用样式。开发者可以通过以下方式删除备注：

- 删除演示文稿中特定幻灯片的备注。
- 删除演示文稿中所有幻灯片的备注。

有关读取或更改备注页面尺寸、切换方向以及检查导出行为，请参阅[Notes Page Size](/slides/zh/nodejs-java/notes-size/)。

## **从幻灯片删除备注**
可以按如下示例删除特定幻灯片的备注：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // 删除第一张幻灯片的备注
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // 将演示文稿保存到磁盘
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **从演示文稿删除备注**
可以按如下示例删除演示文稿中所有幻灯片的备注：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // 删除所有幻灯片的备注
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // 将演示文稿保存到磁盘
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **添加 NotesStyle**
已在 [MasterNotesSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/MasterNotesSlide) 类中添加了 [getNotesStyle](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) 方法。此属性指定备注文本的样式。以下示例演示了其实现。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // 获取 MasterNotesSlide 文本样式
        var notesStyle = notesMaster.getNotesStyle();
        // 为第一级段落设置符号项目符号
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常见问题**

**哪个 API 实体提供对特定幻灯片备注的访问？**

备注通过幻灯片的备注管理器访问：该幻灯片拥有一个 [NotesSlideManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notesslidemanager/) 以及一个返回备注对象的 [method](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/)，若没有备注则返回 `null`。

**库在不同 PowerPoint 版本中的备注支持是否存在差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97 版及更高）以及 ODP；在这些格式中均支持备注，且不依赖已安装的 PowerPoint 副本。