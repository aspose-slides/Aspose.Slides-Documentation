---
title: 在 Java 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/java/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建 PPT
- 新 PPT
- 创建 PPTX
- 新 PPTX
- 创建 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中创建演示文稿——生成 PPT、PPTX 和 ODP 文件，享受 OpenDocument 支持，并以编程方式保存以获得可靠的结果。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中创建演示文稿，在其第一张幻灯片上添加带文本的形状，并将结果保存为 PPTX 文件。要打开已有演示文稿并将其保存为其他格式，请参阅[打开演示文稿](/slides/zh/java/open-presentation/)和[保存演示文稿](/slides/zh/java/save-presentation/)。文末的简短FAQ包含了有关格式、模板、幻灯片尺寸、单位、内存使用、线程、授权、数字签名和 VBA 支持的常见问题。

开始之前，请从 Aspose 的 Maven 仓库将 Aspose.Slides for Java 添加到项目中。有关 Maven 设置以及 Linux 额外需求，请参阅[安装](/slides/zh/java/installation/)。

## **创建演示文稿**

在 Aspose.Slides for Java 中从头创建 PowerPoint 文件始于实例化[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)类。构造函数会提供一个包含单张幻灯片的空白演示文稿，可用于放置形状、文本、图表或任何其他应用程序需要的内容。修改该幻灯片或添加新幻灯片后，您可以将结果保存为 PPTX、旧版 PPT 或 OpenDocument 格式。

要创建演示文稿并在其第一张幻灯片上放置带文本的形状，请按以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)类的实例。新的演示文稿已经包含一张空幻灯片。
2. 通过其索引 0，从[getSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSlides--)返回的集合中获取该幻灯片。
3. 使用[addAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-)方法添加一个`Cloud`类型的[IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)，并使用[setText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/#setText-java.lang.String-)设置其文本。
4. 使用[save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-)方法将演示文稿保存为 PPTX 文件。

下面的示例是完整的程序。在来自[安装](/slides/zh/java/installation/)的 Maven 项目中，将其保存为*src/main/java/HelloSlides.java*并运行`mvn compile exec:java`。

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // 创建演示文稿。它已经包含一张空幻灯片。
        Presentation presentation = new Presentation();
        try {
            // 获取第一张幻灯片。
            ISlide slide = presentation.getSlides().get_Item(0);

            // 添加云形状并在其中放入文本。
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // 将演示文稿保存为 PPTX 文件。
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

云形状的左上角距幻灯片左边缘 20 点，距顶部 20 点，形状宽 200 点，高 80 点。程序将*new_presentation.pptx*保存为包含一张包含云形状及其文本的幻灯片的文件。若未授权，Aspose.Slides 还会在每个保存的幻灯片上添加评估水印；请参阅[授权](/slides/zh/java/licensing/)。

结果：
![新的演示文稿](new_presentation.png)

## **常见问题**

### 我可以将新演示文稿保存为哪些格式？

您可以保存为[PPTX、PPT 和 ODP](/slides/zh/java/save-presentation/)，并可导出为[PDF](/slides/zh/java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/java/convert-powerpoint-to-html/)、[SVG](/slides/zh/java/render-a-slide-as-an-svg-image/)以及[图像](/slides/zh/java/convert-powerpoint-to-png/)等等。

### 我可以从模板（POTX/POTM）开始并保存为普通 PPTX 吗？

可以。加载模板后保存为所需格式；POTX、POTM、PPTM 等类似格式[受支持](/slides/zh/java/supported-file-formats/)。

### 创建演示文稿时如何控制幻灯片尺寸/纵横比？

设置[幻灯片尺寸](/slides/zh/java/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

### 尺寸和坐标使用什么单位？

使用点作为单位：1 英寸等于 72 点。

### 如何处理包含大量媒体文件的大型演示文稿以降低内存使用？

使用[BLOB 管理策略](/slides/zh/java/manage-blob/)，通过使用临时文件限制内存存储，并优先选择基于文件的工作流而非纯内存流。

### 我可以并行创建/保存演示文稿吗？

不能在[多个线程](/slides/zh/java/multithreading/)中操作同一个[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)实例。请为每个线程或进程运行独立的实例。

### 如何移除试用水印和限制？

在每个进程中[应用许可证](/slides/zh/java/licensing/)。许可证 XML 必须保持未修改，且若涉及多个线程，许可证设置应同步进行。

### 我可以对创建的 PPTX 进行数字签名吗？

可以。[数字签名](/slides/zh/java/digital-signature-in-powerpoint/)（添加和验证）受到支持。

### 在创建的演示文稿中支持宏（VBA）吗？

可以。您可以[创建/编辑 VBA 项目](/slides/zh/java/presentation-via-vba/)并保存为包含宏的文件，如 PPTM/PPSM。