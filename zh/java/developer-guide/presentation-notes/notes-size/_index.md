---
title: 在 Java 中更改备注页尺寸和方向
linktitle: 备注页尺寸
type: docs
weight: 10
url: /zh/java/notes-size/
keywords:
- 备注页尺寸
- 备注方向
- 横向备注
- 纵向备注
- 讲义尺寸
- PowerPoint
- 演示文稿
- PPT
- PPTX
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中读取和更改备注页尺寸，切换方向，验证已保存的尺寸，并将备注或讲义导出为 PDF 和图像。"
---
## **概述**

使用 [Presentation.getNotesSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getNotesSize--) 来访问演示文稿的备注页设置。它返回一个 [INotesSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/inotessize/) 对象，其 [setSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) 方法设置页面尺寸。虽然设置对象本身无法替换，但可以通过此方法分配新的尺寸。

宽度和高度以 **点** 为单位指定，1 英寸等于 72 点。例如，900 × 600 点相当于 12.5 × 8⅓ 英寸。这些设置适用于整个演示文稿，而不是单个幻灯片的备注。

| Setting | Purpose |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getNotesSize--) | 控制备注页尺寸以及用于讲义导出的页面尺寸。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSlideSize--) | 通过 [ISlideSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islidesize/) 控制普通演示文稿幻灯片的尺寸。 |

更改任一设置不会自动更改另一设置。更改备注页方向也不会旋转普通幻灯片。请参阅 [Slide Size](/slides/zh/java/slide-size/) 以调整普通幻灯片的尺寸。

以下示例使用已有的 `sample.pptx`。对于导出示例，请使用至少包含一张带有演讲者备注的幻灯片的演示文稿。每个示例均可独立运行。

## **读取备注页尺寸和方向**

读取宽度和高度并比较以确定方向：宽的页面为横向，高的页面为纵向，尺寸相等则为方形页面。此示例以点为单位打印实际尺寸，不假设标准纸张大小。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **在不更改纸张尺寸的情况下切换为横向**

若只更改方向，交换现有的宽度和高度即可。这会保留两侧的长度，包括自定义纸张尺寸。下面的条件可防止已为横向的页面被切换回纵向，并保持方形页面不变。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对于纵向方向，在 `size.getWidth() > size.getHeight()` 时使用相同的赋值。除非你也想更改纸张尺寸，否则不要替换为 A4 或 Letter 尺寸。

## **设置并验证自定义备注页尺寸**

同时分配两个尺寸，然后使用 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 保存演示文稿。此示例将页面设置为 900 × 600 点的横向页面，保存为 PPTX，并再次打开保存的文件以检查持久化的值。比较时对浮点值允许 0.01 点的容差；这并不保证每种文件格式的精度。

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

预期结果为 `900.0 x 600.0 points` 和 `Size preserved: true`。检查新打开的演示文稿可验证已保存的文件，而不仅是内存中的设置。

## **导出备注和讲义**

页面尺寸定义了备注或讲义布局的可用区域。它们本身并不会启用这些布局：还需要配置导出选项。普通幻灯片导出仍使用幻灯片尺寸。

### **导出备注为 PDF 和 PNG**

将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/notescommentslayoutingoptions/) 分配给 [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 以在 PDF 中包含备注。此示例还使用 [Slide.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) 和 [RenderingOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/renderingoptions/) 将带备注的第一张幻灯片渲染为 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh/java/com.aspose.slides/notespositions/) 模式将在单页上保留备注；不适合的备注会被截断。PDF 使用 900 × 600 点的页面。下面使用的 1 × 1 图像比例下，PNG 为 900 × 600 像素。点描述页面几何；像素描述光栅输出，其尺寸也取决于渲染比例。

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

对于带有长备注的 PDF 导出，[BottomFull](https://reference.aspose.com/slides/zh/java/com.aspose.slides/notespositions/) 可根据需要添加额外页面。不要在上述单幻灯片图像调用中使用该模式，因为它不支持。调整尺寸后，检查输出是否有被裁剪的备注以及现有 notes‑master 对象的位置；仅更改页面尺寸并不能保证所有内容都能适配。请参阅 [Convert PowerPoint to PDF with Notes](/slides/zh/java/convert-powerpoint-to-pdf-with-notes/) 了解更多备注导出信息。

### **导出讲义为 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/handoutlayoutingoptions/) 可在一页上放置多个幻灯片缩略图。下面的示例设置 900 × 600 点的页面，并使用 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/zh/java/com.aspose.slides/handouttype/) 将每页安排至多四张幻灯片。水平预设控制幻灯片顺序；页面方向由其宽度和高度决定。

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

更改页面尺寸会改变讲义网格的可用区域，但不会更改源幻灯片的尺寸。对于讲义图像，请使用带讲义布局的 [Presentation.getImages](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-)，而不是单个幻灯片的图像方法。在 Aspose.Slides 中，演示文稿级别的讲义渲染使用备注页尺寸，而单个幻灯片的图像调用不会生成讲义页面。请参阅 [Handout Mode](/slides/zh/java/convert-powerpoint-in-handout-mode/) 了解布局选项。

## **查看器、导出和打印中的页面尺寸**

保持存储的演示文稿尺寸、导出页面尺寸和打印纸张尺寸之间的区别：

- **Presentation viewers:** 查看器可以使用其自身的布局规则显示或打印备注。如果其他应用程序保存了文件，请重新打开并再次检查尺寸；该应用的格式转换可能会对其进行标准化。
- **Export formats:** 上述备注和讲义 PDF 示例使用配置的页面尺寸。光栅图像使用整数像素尺寸和渲染比例，因此在图像输出中可能会对小数点的点值进行四舍五入。导出普通幻灯片不使用备注页尺寸。
- **Printer drivers:** 纸张选择、自动旋转和适合页面设置可以在不更改演示文稿或 PDF 中存储的尺寸的情况下改变实际输出。针对特定纸张尺寸，请匹配打印机设置并检查打印预览。

## **常见问题**

**我可以仅为单张幻灯片设置备注尺寸吗？**

备注页尺寸是演示文稿级别的设置。单个幻灯片可以有不同的备注内容，但此属性不提供每张幻灯片单独的页面尺寸。

**为什么更改备注方向没有影响我的幻灯片？**

备注页和普通幻灯片的尺寸是独立的。若要调整幻灯片本身的尺寸，请使用普通幻灯片尺寸设置。

**为什么我的保存或打印结果尺寸不同？**

首先重新打开已保存的演示文稿并比较其备注尺寸。如果它们已更改，请检查是否在其他应用程序中保存或转换文件时更改了页面设置。如果没有，更检查导出布局、图像比例、查看器设置以及打印机纸张选择。