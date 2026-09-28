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
description: "使用 Aspose.Slides for Android 在 Java 中创建演示文稿——生成 PPT、PPTX 和 ODP 文件，支持 OpenDocument，并以编程方式保存以获得可靠的结果。"
---
## **概述**

本文展示了如何使用 Java 在 Aspose.Slides for Android 中创建演示文稿，向其第一张幻灯片添加文本框，并将结果保存为应用存储中的文件。要打开现有演示文稿或以其他格式保存，请参阅[打开演示文稿](/slides/zh/androidjava/open-presentation/)和[保存演示文稿](/slides/zh/androidjava/save-presentation/)。文末的简短 FAQ 包括了关于格式、模板、幻灯片大小、单位、内存使用、线程、授权、数字签名和 VBA 支持的常见问题。

在开始之前，请从 Aspose 的 Maven 仓库将 Aspose.Slides 添加到您的 Android 项目中。参见[安装](/slides/zh/androidjava/install-aspose-slides-for-android-via-java/)。

## **创建 PowerPoint 演示文稿**

要创建演示文稿并在其第一张幻灯片上放置文本框，请按下列步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。新演示文稿默认包含一张空白幻灯片。
2. 通过索引 0 从[幻灯片集合](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/)中获取该幻灯片。
3. 使用[形状集合](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/)的[addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 方法添加矩形，并使用其[text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)的[setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) 方法设置文本。
4. 使用[save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法将演示文稿以 PPTX 文件保存，格式为[SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)。

代码在 `Activity` 中运行，例如在其 `onCreate` 方法里。它会将文件保存到由[getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) 方法返回的目录：即应用的私有存储，写入此目录无需任何权限。

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

矩形的左上角距离幻灯片左边缘和上边缘各 50 点，宽度为 400 点，高度为 100 点。保存的文件包含一张带有该矩形及其文本的幻灯片。未授权时，Aspose.Slides 还会在每张保存的幻灯片上添加评估水印；请参阅[授权](/slides/zh/androidjava/licensing/)。

要查看文件，请打开 Android Studio 的[Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) 并在 *data/data/* 下的 *files* 文件夹中找到 *hello.pptx*。在实际应用中，请在后台线程中处理演示文稿，以保持用户界面响应。

## **FAQ**

### 我可以将新演示文稿保存为哪些格式？

您可以保存为 [PPTX、PPT 和 ODP](/slides/zh/androidjava/save-presentation/)，并导出为 [PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/androidjava/convert-powerpoint-to-xps/)、[HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)、[SVG](/slides/zh/androidjava/render-a-slide-as-an-svg-image/) 和[图片](/slides/zh/androidjava/convert-powerpoint-to-png/) 等格式。

### 我能否从模板（POTX/POTM）开始并保存为普通 PPTX？

可以。加载模板后保存为所需格式；POTX/POTM/PPTM 等格式[受支持](/slides/zh/androidjava/supported-file-formats/)。

### 创建演示文稿时如何控制幻灯片尺寸/宽高比？

设置[幻灯片大小](/slides/zh/androidjava/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

### 尺寸和坐标使用什么单位？

使用点（points）：1 英寸等于 72 单位。

### 如何处理包含大量媒体文件的超大演示文稿以降低内存使用？

采用[BLOB 管理策略](/slides/zh/androidjava/manage-blob/)，通过临时文件限制内存存储，并优先使用基于文件的工作流而非纯内存流。

### 我能并行创建/保存演示文稿吗？

不能从[multiple threads](/slides/zh/androidjava/multithreading/)操作同一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 实例。请为每个线程或进程使用独立的实例。

### 如何去除试用水印和功能限制？

在每个进程中[应用授权](/slides/zh/androidjava/licensing/)。授权 XML 必须保持未修改，若涉及多线程，授权设置应进行同步。

### 我可以为创建的 PPTX 添加数字签名吗？

可以。[数字签名](/slides/zh/androidjava/digital-signature-in-powerpoint/)（添加和验证）在演示文稿中受支持。

### 创建的演示文稿是否支持宏（VBA）？

支持。您可以[创建/编辑 VBA 项目](/slides/zh/androidjava/presentation-via-vba/)并保存为支持宏的文件，如 PPTM/PPSM。