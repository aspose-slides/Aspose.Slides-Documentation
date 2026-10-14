---
title: 在 Android 上将 PowerPoint 幻灯片转换为 PNG
linktitle: PowerPoint 转 PNG
type: docs
weight: 30
url: /zh/androidjava/convert-powerpoint-to-png/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PNG
- 演示文稿转 PNG
- 幻灯片转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- 将 PPT 保存为 PNG
- 将 PPTX 保存为 PNG
- 导出 PPT 为 PNG
- 导出 PPTX 为 PNG
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 将 PowerPoint 演示文稿快速转换为高质量 PNG 图像，确保精确、自动化的结果。"
---
## **概述**

本文说明如何使用 Aspose.Slides for Android via Java 将演示文稿幻灯片转换为 PNG 图像。您可以加载 PPT、PPTX、ODP 等格式的演示文稿，渲染每张幻灯片，并将其保存为单独的 PNG 图像。

下面的示例演示了默认比例渲染、放大比例渲染、以像素指定输出尺寸以及选择渐变渲染样式。

## **将 PowerPoint 转换为 PNG**

使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类加载演示文稿，并通过 [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) 集合访问其幻灯片。示例使用不带参数的 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) 为每张幻灯片渲染缩略图。随后调用 [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 并使用 [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) 将每张渲染后的幻灯片保存为 PNG 图像。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
无参数的 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) 重载以 0.2 的比例进行渲染。例如，尺寸为 720 × 540 点的幻灯片会生成 144 × 108 像素的缩略图。若需控制输出尺寸，请使用带比例因子或显式图像尺寸的重载，如下所示。
{{% /alert %}}

## **将 PowerPoint 转换为 PNG（自定义比例）**

将水平和垂直比例因子传递给 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-)，以控制渲染后的尺寸。在本例中，两个因子均为 2，因此尺寸为 720 × 540 点的幻灯片会生成 1440 × 1080 像素的图像。相同比例因子可保持幻灯片的宽高比。每张图像使用 [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 以 PNG 格式保存。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **将 PowerPoint 转换为 PNG（自定义尺寸）**

若要以像素指定输出尺寸，请将尺寸对象传递给 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-)，而不是使用比例因子。此示例将每张幻灯片渲染为 960 × 720 像素，并使用 [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 保存结果。请选择与幻灯片宽高比相匹配的尺寸，以避免图像拉伸。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **选择渐变渲染样式**

假设幻灯片包含渐变填充，但导出的 PNG 中的渐变过渡比 PowerPoint 中显得更浅或有所不同。您可以使用由 [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) 继承的 [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) 方法来选择渐变的渲染方式。

下载 [gradient-styles.pptx](gradient-styles.pptx) 并将其放置在应用程序的工作目录中。其第一张幻灯片包含两个线性渐变：顶部从青色到橙色，底部从蓝色到黄色。每个渐变有两个止点，分别位于 0% 和 100%。

以下示例加载此演示文稿，并使用 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) 在两种模式下渲染同一第一张幻灯片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

下面的图像展示了同一幻灯片的输出，两种模式各包含两个渐变：

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

在本例中，`Default` 产生较浅的中间颜色，而 `PowerPointUI` 产生较暗的中间颜色。差异取决于渐变的颜色和止点。

当标准的 Aspose.Slides 输出符合需求时请选择 `Default`；当您希望匹配 PowerPoint 中的外观时请选择 `PowerPointUI`。请将两种输出与您的预期结果进行对比，二者均无绝对优劣。

## **常见问题解答**

**如何导出特定形状（例如图表或图片），而不是整个幻灯片？**

Aspose.Slides 支持 [generating thumbnails for individual shapes](/slides/zh/androidjava/create-shape-thumbnails/)，您可以将单个形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

支持。为每个线程或进程使用独立的演示文稿实例；请 [do not share a single instance across threads](/slides/zh/androidjava/multithreading/)。

**以 PNG 导出时评估模式有什么限制？**

评估模式会在输出图像上添加水印，并在使用许可证之前施加 [other restrictions](/slides/zh/androidjava/licensing/)。