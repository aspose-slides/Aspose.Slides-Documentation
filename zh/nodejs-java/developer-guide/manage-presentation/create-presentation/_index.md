---
title: 用 JavaScript 创建 PowerPoint 演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/nodejs-java/create-presentation/
keywords: 用 JavaScript 创建 PPT, 用 JavaScript 创建 PPT 演示文稿, 用 JavaScript 创建 PPTX
description: 学习如何使用 JavaScript 从头创建 PowerPoint 演示文稿，例如 PPT、PPTX。
---

## **创建 PowerPoint 演示文稿**

要向演示文稿的选定幻灯片添加一条简单的直线，请按以下步骤操作：

1. 创建 Presentation 类的实例。
1. 通过其 Index 获取幻灯片的引用。
1. 使用 Shapes 对象公开的 addAutoShape 方法添加 Line 类型的 AutoShape。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一条直线。
```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加类型为线的自动形状
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以将新演示文稿保存为何种格式？**

您可以保存为 [PPTX, PPT, and ODP](/slides/zh/nodejs-java/save-presentation/)，并导出为 [PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/nodejs-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/)、[SVG](/slides/zh/nodejs-java/convert-powerpoint-to-png/) 和 [images](/slides/zh/nodejs-java/convert-powerpoint-to-png/)，等等。

**我可以从模板（POTX/POTM）开始并保存为普通 PPTX 吗？**

可以。加载模板并保存为所需格式；POTX/POTM/PPTM 等类似格式 [受支持](/slides/zh/nodejs-java/supported-file-formats/)。

**创建演示文稿时，如何控制幻灯片尺寸/宽高比？**

设置 [slide size](/slides/zh/nodejs-java/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

**尺寸和坐标使用何种单位？**

使用点（point）：1 英寸等于 72 单位。

**如何处理包含大量媒体文件的超大型演示文稿以降低内存使用？**

使用 [BLOB management strategies](/slides/zh/nodejs-java/manage-blob/)，通过利用临时文件限制内存中存储，并优先使用基于文件的工作流而非纯内存流。

**我可以并行创建/保存演示文稿吗？**

不能在 [multiple threads](/slides/zh/nodejs-java/multithreading/) 中对同一 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 实例进行操作。请为每个线程或进程运行独立的实例。

**如何移除试用版水印和限制？**

[Apply a license](/slides/zh/nodejs-java/licensing/) 每个进程一次。许可 XML 必须保持未修改，如果涉及多个线程，许可设置应同步进行。

**我可以对创建的 PPTX 进行数字签名吗？**

可以。[Digital signatures](/slides/zh/nodejs-java/digital-signature-in-powerpoint/)（添加和验证）在演示文稿中受支持。

**在创建的演示文稿中是否支持宏（VBA）？**

可以。您可以 [create/edit VBA projects](/slides/zh/nodejs-java/presentation-via-vba/) 并保存为支持宏的文件，例如 PPTM/PPSM。