---
title: 将 PowerPoint 转换为 TIFF 及备注
type: docs
weight: 100
url: /zh/php-java/convert-powerpoint-to-tiff-with-notes/
keywords: "将 PowerPoint 转换为 TIFF 并附带备注"
description: "在 Aspose.Slides 中将 PowerPoint 转换为 TIFF 并附带备注。"
---

## **在备注幻灯片视图中将 PPT(X) 转换为 TIFF**
[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类提供的 [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法可用于将整个演示文稿转换为 TIFF 格式的备注幻灯片视图。以下代码片段将示例演示文稿更新为备注幻灯片视图中的 TIFF 图像，如下所示：

```php
//实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("demo.pptx");
  try {
    $opts = new TiffOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # 保存演示文稿为 TIFF 备注
    $pres->save("Tiff-Notes.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

上述代码片段将示例演示文稿更新为备注幻灯片视图中的 TIFF 图像，如下所示：

|**带备注的源演示文稿视图**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**备注幻灯片视图中生成的 TIFF 图像**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="提示" color="primary" %}}

您可能想要查看 Aspose [免费的 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}