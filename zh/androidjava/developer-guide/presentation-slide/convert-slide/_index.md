---
title: 在 Android 上将演示文稿幻灯片转换为图像
linktitle: 幻灯片转图像
type: docs
weight: 35
url: /zh/androidjava/convert-slide/
keywords:
- 转换幻灯片
- 导出幻灯片
- 幻灯片转图像
- 将幻灯片保存为图像
- 幻灯片转 EMF
- 幻灯片转 PNG
- 幻灯片转 JPEG
- 幻灯片转位图
- 幻灯片转 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 将 PPT、PPTX 和 ODP 演示文稿的幻灯片转换为 PNG、JPEG、GIF、TIFF、EMF 等图像格式。"
---
## **介绍**

Aspose.Slides for Android via Java 可以将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片渲染为 PNG、JPEG、GIF、TIFF 等图像格式。

要将幻灯片转换为图像，请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类加载演示文稿。
2. 选择要渲染的幻灯片。
3. 如有必要，可使用 [RenderingOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/tiffoptions/) 类配置渲染。
4. 调用 [ISlide.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/#getImage--) 方法。该方法返回一个 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 对象。
5. 调用 [IImage.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 方法，并使用 [ImageFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imageformat/) 值指定输出格式。

## **将幻灯片转换为 PNG 图像**

最简单的转换使用默认渲染设置。生成的 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 对象可以在内存中处理或保存到文件。

下面的 Java 示例渲染第一张幻灯片并将其保存为 PNG 图像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **将幻灯片转换为自定义尺寸的图像**

使用接受 [Size](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.android/size/) 值的 [ISlide.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) 重载，以精确像素尺寸渲染幻灯片。

下面的示例创建一个 1820 × 1040 的 JPEG 图像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **将带有备注和评论的幻灯片转换为图像**

默认情况下，幻灯片图像不包括备注或评论。将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 对象传递给 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法，以控制备注和评论的显示位置。

下面的示例将截断的备注放在幻灯片下方，评论放在右侧：

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
对于幻灯片转图像的转换，请不要将 [BottomFull](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notespositions/) 传递给 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) 方法。备注的文本可能超过固定图像尺寸的容纳范围。请改用 [BottomTruncated](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notespositions/)。
{{% /alert %}}

## **使用 TIFF 选项将幻灯片转换为图像**

[TiffOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/tiffoptions/) 类允许您控制渲染的 TIFF 图像的大小、分辨率和其他属性。

下面的示例以 300 DPI 将第一张幻灯片渲染为 2160 × 2880 的 TIFF 图像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **将所有幻灯片转换为图像**

遍历幻灯片集合，将整个演示文稿转换为一系列图像。除非显式跳过，否则会包括隐藏的幻灯片。

下面的示例将每张幻灯片渲染为水平和垂直比例因子均为 2 的 JPEG 图像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **创建增强型图元文件（EMF）输出**

增强型图元文件（EMF）在需要将基于矢量的图形与 Microsoft Office 或其他支持 Windows 图元文件的 Windows 应用程序交换时非常有用。与基于像素的图像不同，EMF 能够保留矢量绘图操作，缩放时不会出现相同的清晰度损失。然而，EMF 主要是针对支持 Windows 图元文件的应用程序的兼容性格式，而非通用的互换格式。此外，复杂的幻灯片内容（如位图图像和某些效果）可能会以栅格化元素的形式存储在矢量图元文件容器中。

### **导出幻灯片为 EMF**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) 方法将 [ISlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/) 以 EMF 格式写入目标流。下面的示例加载演示文稿，选择第一张幻灯片，并将其写入 EMF 文件流：

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

调用方拥有传递给 [ISlide.writeAsEmf](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) 的流，并负责如上所示关闭该流。

### **将 SVG 图像转换为 EMF 并添加到演示文稿中**

使用 [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) 将 SVG 内容转换为 EMF。生成的字节可以通过 [IImageCollection.addImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) 添加到演示文稿，并使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 放置在幻灯片上。

下面的示例从 SVG 标记创建一个 [SvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/svgimage/)，将其转换为内存中的 EMF，将该图元文件插入第一张幻灯片，并保存演示文稿：

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) 不会获取目标流的所有权。 [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) 将所有生成的数据存储在内存中，因此在调用 `toByteArray` 之前无需重置位置。流关闭后返回的字节数组仍然有效。

EMF 生成在受支持的 Android 版本和设备配置上可用，但当字体或图形依赖项不可用时，渲染可能会有所不同。请安装源内容使用的字体或配置合适的替代字体，遵循 Aspose.Slides for Android via Java 的 [installation guide](/slides/zh/androidjava/install-aspose-slides-for-android-via-java/)，并在目标 EMF 使用应用中验证结果。非 Windows 平台的应用程序通常对显示和编辑 Windows 图元文件的支持有限或不一致。

## **彩色表情符号渲染**

{{% alert title="Note" color="info" %}}
在将演示文稿幻灯片转换为图像时，要正确渲染彩色表情符号，必须在执行转换的系统上安装并提供演示文稿中使用的表情符号字体。例如，如果演示文稿使用 **Segoe UI Emoji** 且该字体缺失，输出图像中的表情符号可能会以单色显示。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持渲染带有动画的幻灯片？**

不。 [ISlide.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/#getImage--) 方法渲染幻灯片的静态图像，不会导出动画。

**是否可以将隐藏的幻灯片导出为图像？**

是。隐藏的幻灯片可以像普通幻灯片一样渲染。将它们包含在处理循环中，如上面的示例所示。

**幻灯片图像是否保留阴影和其他效果？**

是。Aspose.Slides 在幻灯片图像中渲染阴影、透明度以及其他受支持的图形效果。