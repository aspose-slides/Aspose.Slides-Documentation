---
title: 演示文稿备注
type: docs
weight: 110
url: /zh/androidjava/presentation-notes/
keywords: "Java中的PowerPoint发言者备注"
description: "演示文稿备注，Java中的发言者备注"
---


{{% alert color="primary" %}} 

Aspose.Slides支持从演示文稿中移除备注幻灯片。在本主题中，我们将介绍此新功能，移除备注并从任何演示文稿中添加备注样式幻灯片。

{{% /alert %}} 

Aspose.Slides for Android via Java提供了移除任何幻灯片备注以及为现有备注添加样式的功能。开发人员可以通过以下方式移除备注：

* 移除演示文稿中特定幻灯片的备注。
* 移除演示文稿中所有幻灯片的备注。


## **从幻灯片中移除备注**
某些特定幻灯片的备注可以如下面的示例中所示移除：

```java
// 实例化一个表示演示文稿文件的Presentation对象
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 移除第一张幻灯片的备注
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // 将演示文稿保存到磁盘
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **从演示文稿中移除备注**
演示文稿中所有幻灯片的备注可以如下面的示例中所示移除：

```java
// 实例化一个表示演示文稿文件的Presentation对象
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 移除所有幻灯片的备注
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
[getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) 方法已添加到 [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) 类中。该属性指定备注文本的样式。其实现如下示例所示。

```java
// 实例化一个表示演示文稿文件的Presentation对象
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // 获取MasterNotesSlide文本样式
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