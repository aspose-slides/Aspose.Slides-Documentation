---
title: 在 JavaScript 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 创建演示文稿—生成 PPT、PPTX 和 ODP 文件，支持 OpenDocument，程序化保存以获得可靠的结果。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中创建演示文稿、在其首张幻灯片上添加文本框，并将结果保存为文件。

在开始之前，使用 npm 安装 `aspose.slides.via.java` 包，并安装其所需的 JDK、Python 和 C++ 构建工具。参见[Installation](/slides/zh/nodejs-java/installation/)。

## **创建 PowerPoint 演示文稿**

要创建演示文稿并在其首张幻灯片上放置文本框，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。新演示文稿默认包含一张空白幻灯片。  
2. 通过索引 0 从[slide collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/)中获取该幻灯片。  
3. 使用 [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) 方法添加矩形，并使用 [setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/) 设置其文本。  
4. 使用 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 方法将演示文稿保存为 PPTX 文件。  
5. 使用 [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/) 方法释放演示文稿，并结束进程。

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides 在 Java 虚拟机中运行，该虚拟机会保持 Node.js 继续运行，因此需要显式结束进程。
process.exit(0);
```

矩形的左上角距离幻灯片左边缘 50 点，距离顶部 50 点，宽度为 400 点，高度为 100 点。将代码保存为 *hello.js* 并放入项目文件夹，然后运行 `node hello.js`：它会在当前文件夹生成 *hello.pptx*，其中包含一张带有该矩形及其文本的幻灯片。

Aspose.Slides 在 `java` 包启动的 Java 虚拟机中运行，该虚拟机位于 Node.js 进程内部。虚拟机会阻止 Node.js 在脚本结束后自动退出，因此示例以 `process.exit(0)` 结束。

如果没有许可证，Aspose.Slides 还会在每张保存的幻灯片上添加评估水印；参见[Licensing](/slides/zh/nodejs-java/licensing/)。

## **常见问题**

### 我可以将新演示文稿保存为何种格式？

您可以保存为 [PPTX、PPT 和 ODP](/slides/zh/nodejs-java/save-presentation/)，并导出为 [PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/nodejs-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/)、[SVG](/slides/zh/nodejs-java/render-a-slide-as-an-svg-image/) 和 [images](/slides/zh/nodejs-java/convert-powerpoint-to-png/) 等格式。

### 能否从模板（POTX/POTM）开始并保存为普通 PPTX？

可以。加载模板后保存为所需格式；POTX、POTM、PPTM 等类似格式[受支持](/slides/zh/nodejs-java/supported-file-formats/)。

### 创建演示文稿时如何控制幻灯片大小/宽高比？

设置[slide size](/slides/zh/nodejs-java/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

### 大小和坐标使用何种单位？

使用点（points）：1 英寸等于 72 点。

### 如何处理包含大量媒体文件的超大型演示文稿以降低内存使用？

使用[BLOB 管理策略](/slides/zh/nodejs-java/manage-blob/)，通过临时文件限制内存存储，并倾向于基于文件的工作流而非纯内存流。

### 能否并行创建/保存演示文稿？

不能在[multiple threads](/slides/zh/nodejs-java/multithreading/)中对同一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 实例进行操作。请为每个线程或进程使用独立的实例。

### 如何去除试用水印和限制？

在每个进程中[Apply a license](/slides/zh/nodejs-java/licensing/)。许可证 XML 必须保持原样，且在多线程环境下应同步许可证设置。

### 能否对创建的 PPTX 进行数字签名？

可以。支持[Digital signatures](/slides/zh/nodejs-java/digital-signature-in-powerpoint/)（添加和验证）用于演示文稿。

### 创建的演示文稿是否支持宏（VBA）？

支持。您可以[create/edit VBA projects](/slides/zh/nodejs-java/presentation-via-vba/)并保存为支持宏的文件，如 PPTM、PPSM。