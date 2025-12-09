---
title: 演示文稿备注
type: docs
weight: 110
url: /zh/nodejs-java/presentation-notes/
keywords: "PowerPoint 演讲者备注在 JavaScript 中"
description: "演示文稿备注，演讲者备注在 JavaScript 中"
---

{{% alert color="primary" %}} 

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍此新功能，即删除备注以及向任意演示文稿添加备注样式幻灯片。 

{{% /alert %}} 

Aspose.Slides for Node.js via Java 提供了删除任意幻灯片备注以及为现有备注添加样式的功能。开发者可以通过以下方式删除备注：

* 删除演示文稿中特定幻灯片的备注。
* 删除演示文稿中所有幻灯片的备注。


## **从幻灯片中删除备注**
可以删除某个特定幻灯片的备注，如下例所示：
```javascript
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


## **从演示文稿中删除备注**
可以删除演示文稿中所有幻灯片的备注，如下例所示：
```javascript
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
[getNotesStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) 方法已添加到 [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) 类中。此属性指定备注文本的样式。下面的示例演示了其实现。
```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // 获取 MasterNotesSlide 文本样式
        var notesStyle = notesMaster.getNotesStyle();
        // 为第一级段落设置符号项目符号
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
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

备注通过幻灯片的备注管理器访问：幻灯片拥有一个 [NotesSlideManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/) 和一个返回备注对象的 [method](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/)，如果没有备注则返回 `null`。

**库在不同 PowerPoint 版本中的备注支持是否存在差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97 及以上）以及 ODP；在这些格式中均支持备注，而无需依赖已安装的 PowerPoint 副本。