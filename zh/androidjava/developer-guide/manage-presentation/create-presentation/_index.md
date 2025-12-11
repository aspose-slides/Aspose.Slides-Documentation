---
title: 在 Android 上创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides for Android 创建演示文稿——生成 PPT、PPTX 和 ODP 文件，受益于 OpenDocument 支持，并以编程方式保存，实现可靠的结果。"
---

## **创建 PowerPoint 演示文稿**
要在演示文稿的选定幻灯片上添加一条简单的直线，请按以下步骤操作：

1. 创建 Presentation 类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 Shapes 对象提供的 addAutoShape 方法添加 Line 类型的 AutoShape。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条线。
```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加类型为 line 的自动形状
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**可以将新演示文稿保存为什么格式？**

您可以保存为 [PPTX、PPT 和 ODP](/slides/zh/androidjava/save-presentation/)，并导出为 [PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/androidjava/convert-powerpoint-to-xps/)、[HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)、[SVG](/slides/zh/androidjava/convert-powerpoint-to-png/) 和 [图像](/slides/zh/androidjava/convert-powerpoint-to-png/)，等等。

**我可以从模板（POTX/POTM）开始并保存为普通 PPTX 吗？**

是的。加载模板后保存为所需格式；POTX、POTM、PPTM 等类似格式 [受支持](/slides/zh/androidjava/supported-file-formats/)。

**创建演示文稿时，如何控制幻灯片尺寸/宽高比？**

设置 [幻灯片大小](/slides/zh/androidjava/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

**尺寸和坐标使用什么单位测量？**

使用点（point）为单位：1 英寸等于 72 单位。

**如何处理非常大的演示文稿（包含大量媒体文件）以降低内存使用？**

使用 [BLOB 管理策略](/slides/zh/androidjava/manage-blob/)，通过临时文件限制内存中存储，并优先使用基于文件的工作流而非纯内存流。

**我可以并行创建/保存演示文稿吗？**

不能在 [多个线程](/slides/zh/androidjava/multithreading/) 中操作同一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 实例。请为每个线程或进程运行独立的实例。

**如何移除试用版水印和限制？**

在每个进程中 [应用许可证](/slides/zh/androidjava/licensing/)。许可证 XML 必须保持未修改，并且在涉及多个线程时应同步许可证设置。

**我可以对创建的 PPTX 进行数字签名吗？**

是的。支持演示文稿的 [数字签名](/slides/zh/androidjava/digital-signature-in-powerpoint/)（添加和验证）。

**在创建的演示文稿中支持宏（VBA）吗？**

是的。您可以 [创建/编辑 VBA 项目](/slides/zh/androidjava/presentation-via-vba/)，并将文件保存为启用宏的 PPTM/PPSM 等格式。