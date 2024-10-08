---
title: 将 PowerPoint 转换为 TIFF 并包含注释
type: docs
weight: 100
url: /androidjava/convert-powerpoint-to-tiff-with-notes/
keywords: "将 PowerPoint 转换为 TIFF 并包含注释"
description: "在 Aspose.Slides 中将 PowerPoint 转换为 TIFF 并包含注释。"
---

## **在注释幻灯片视图中将 PPT(X) 转换为 TIFF**
[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类提供的 [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法可以用于将整个演示文稿在注释幻灯片视图中转换为 TIFF。以下代码片段将示例演示文稿更新为注释幻灯片视图中的 TIFF 图像，如下所示：

```java
//实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //将演示文稿保存为 TIFF 注释
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

上述代码片段将示例演示文稿更新为注释幻灯片视图中的 TIFF 图像，如下所示：

|**带有幻灯片注释的源演示文稿视图**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**在注释幻灯片视图中生成的 TIFF 图像**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="提示" color="primary" %}}

您可能想查看 Aspose [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}