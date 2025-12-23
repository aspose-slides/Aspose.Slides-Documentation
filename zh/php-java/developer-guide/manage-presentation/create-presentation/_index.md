---
title: 在 PHP 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/php-java/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建 PPT
- 新建 PPT
- 创建 PPTX
- 新建 PPTX
- 创建 ODP
- 新建 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 创建演示文稿 — 生成 PPT、PPTX 和 ODP 文件并以编程方式保存，确保可靠的结果。"
---

## **创建演示文稿**

要在演示文稿的选定幻灯片中添加一条简单的直线，请按照以下步骤操作：

1. 创建 Presentation 类的实例。
1. 使用索引获取幻灯片的引用。
1. 通过 Shapes 对象提供的 addAutoShape 方法，添加类型为 Line 的 AutoShape。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条直线。
```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加类型为 line 的 AutoShape
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以将新的演示文稿保存为什么格式？**

您可以保存为 [PPTX, PPT, and ODP](/slides/zh/php-java/save-presentation/)，并导出为 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/php-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/php-java/convert-powerpoint-to-html/)、[SVG](/slides/zh/php-java/convert-powerpoint-to-png/)，以及 [images](/slides/zh/php-java/convert-powerpoint-to-png/)，等。

**我可以从模板（POTX/POTM）开始并保存为普通的 PPTX 吗？**

可以。加载模板并保存为所需格式；POTX/POTM/PPTM 等类似格式 [are supported](/slides/zh/php-java/supported-file-formats/)。

**在创建演示文稿时，如何控制幻灯片尺寸/宽高比？**

设置 [slide size](/slides/zh/php-java/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

**尺寸和坐标使用什么单位测量？**

使用点（points）单位：1 英寸等于 72 单位。

**如何处理包含大量媒体文件的超大型演示文稿以降低内存使用？**

使用 [BLOB management strategies](/slides/zh/php-java/manage-blob/)；通过使用临时文件限制内存存储；并倾向于基于文件的工作流，而非纯内存流。

**我可以并行创建/保存演示文稿吗？**

不能在 [多个线程](/slides/zh/php-java/multithreading/) 中操作同一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 实例。请为每个线程或进程运行独立的实例。

**如何移除试用版水印和限制？**

每个进程只需 [Apply a license](/slides/zh/php-java/licensing/) 一次。许可证 XML 必须保持未修改；如果涉及多个线程，则应同步许可证设置。

**我可以对创建的 PPTX 进行数字签名吗？**

可以。支持对演示文稿进行 [Digital signatures](/slides/zh/php-java/digital-signature-in-powerpoint/)（添加和验证）。

**在创建的演示文稿中是否支持宏（VBA）？**

可以。您可以 [create/edit VBA projects](/slides/zh/php-java/presentation-via-vba/) 并保存为支持宏的文件，如 PPTM/PPSM。