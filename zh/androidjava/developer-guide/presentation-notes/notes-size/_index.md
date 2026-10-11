---
title: 更改 Android 上的备注页尺寸和方向
linktitle: 备注页尺寸
type: docs
weight: 10
url: /zh/androidjava/notes-size/
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
- Android
- Java
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for Android 中读取并更改备注页尺寸，切换方向，验证保存的尺寸，并将备注或讲义导出为 PDF 和图像。"
---
## **概述**

使用 [Presentation.getNotesSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getNotesSize--) 访问演示文稿的备注页设置。它返回一个 [INotesSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/inotessize/) 对象，其 [setSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) 方法设置页面尺寸。虽然设置对象本身不能被替换，但可以通过此方法分配新尺寸。

宽度和高度使用 **点** 指定，每英寸 72 点。例如，900 × 600 点等于 12.5 × 8⅓ 英寸。这些设置适用于整个演示文稿，而不是单个幻灯片的备注。

| 设置 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getNotesSize--) | 控制备注页的尺寸以及用于讲义导出的页面尺寸。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getSlideSize--) | 通过 [ISlideSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islidesize/) 控制常规演示文稿幻灯片的尺寸。 |

更改任一设置不会自动更改另一个。更改备注页方向也不会旋转常规幻灯片。参见 [Slide Size](/slides/zh/androidjava/slide-size/) 以调整常规幻灯片的尺寸。

下面的示例使用现有的 `sample.pptx`。对于导出示例，请使用至少包含一张带有演讲者备注的幻灯片的演示文稿。每个示例均可独立运行。

## **读取备注页尺寸和方向**

读取宽度和高度并比较以确定方向：宽的页面为横向，高的页面为纵向，尺寸相等则为方形页面。本例以点为单位打印实际尺寸，而不假设标准纸张大小。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

要仅更改方向，只需交换现有的宽度和高度。这会保留两侧的长度，包括自定义纸张尺寸的长度。下面的条件可防止已为横向的页面被切换回纵向，并保持方形页面不变。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对于纵向方向，当 `size.getWidth() > size.getHeight()` 时使用相同的赋值。除非您也想更改纸张尺寸，否则不要替换为 A4 或 Letter 尺寸。

## **设置并验证自定义备注页尺寸**

同时分配两个维度，然后使用 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 保存演示文稿。本例将页面设置为 900 × 600 点的横向页面，保存为 PPTX，并再次打开已保存的文件以检查持久化值。比较允许 0.01 点的误差容限，以容忍浮点值；这并不能保证每种文件格式的精度。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

预期结果为 `900.0 x 600.0 points` 和 `Size preserved: true`。检查新打开的演示文稿可验证已保存的文件，而不仅仅是内存中的设置。

## **导出备注和讲义**

页面尺寸定义了备注或讲义布局的可用区域。它们本身并不会启用这些布局：还需配置导出选项。常规幻灯片导出仍使用幻灯片尺寸。

### **导出备注为 PDF 和 PNG**

将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 分配给 [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 以在 PDF 中包含备注。本例还使用 [Slide.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) 和 [RenderingOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/renderingoptions/) 将带备注的第一张幻灯片渲染为 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notespositions/) 模式将备注保持在一页上；不适合的备注会被截断。PDF 使用 900 × 600 点的页面。以下使用的 1 × 1 图像比例下，PNG 为 900 × 600 像素。点描述页面几何，像素描述光栅输出，其尺寸也取决于渲染比例。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

对于包含长备注的 PDF 导出，[BottomFull](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notespositions/) 可根据需要添加额外页面。不要在上述单幻灯片图像调用中使用该模式，因为它不支持。调整尺寸后，检查输出是否有被截断的备注以及现有 notes‑master 对象的放置；仅更改页面尺寸并不能保证所有内容适配。有关备注导出的更多信息，请参阅 [Convert PowerPoint to PDF with Notes](/slides/zh/androidjava/convert-powerpoint-to-pdf-with-notes/)。

### **导出讲义为 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/handoutlayoutingoptions/) 在一页上放置多个幻灯片缩略图。以下示例将页面设置为 900 × 600 点，并使用 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/handouttype/) 将每页安排最多四张幻灯片。水平预设控制幻灯片顺序；页面方向取决于其宽度和高度。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

更改页面尺寸会改变讲义网格的可用面积，但不会更改源幻灯片的尺寸。对于讲义图像，请使用带有讲义布局的 [Presentation.getImages](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-)，而不是单个幻灯片的图像方法。在 Aspose.Slides 中，演示文稿级别的讲义渲染使用备注页尺寸，而单个幻灯片的图像调用不产生讲义页面。有关布局选项，请参阅 [Handout Mode](/slides/zh/androidjava/convert-powerpoint-in-handout-mode/)。

## **查看器、导出和打印中的页面尺寸**

保持存储的演示文稿尺寸、导出的页面尺寸以及打印的纸张尺寸彼此独立：

- **Presentation viewers:** 查看器可以使用自身的布局规则显示或打印备注。如果其他应用保存了文件，请重新打开并再次检查尺寸；该应用的格式转换可能会对其进行标准化。
- **Export formats:** 上述备注和讲义 PDF 示例使用已配置的页面尺寸。光栅图像使用整数像素尺寸和渲染比例，因此在图像输出中可能会对小数点的点值进行四舍五入。导出常规幻灯片时不应用备注页尺寸。
- **Printer drivers:** 纸张选择、自动旋转以及适合页面设置可能会更改实际输出，而不改变演示文稿或 PDF 中存储的尺寸。对于特定纸张尺寸，请匹配打印机设置并检查打印预览。

## **常见问题**

**我可以仅为单个幻灯片设置备注尺寸吗？**

备注页尺寸是演示文稿级别的设置。单个幻灯片可以拥有不同的备注内容，但此属性不提供每张幻灯片单独的页面尺寸。

**为什么更改备注方向没有影响我的幻灯片？**

备注页和常规幻灯片具有独立的尺寸。想要调整幻灯片本身的大小时，请使用常规幻灯片尺寸设置。

**为什么我的已保存或打印的结果尺寸不同？**

首先重新打开已保存的演示文稿并比较其备注尺寸。如果已改变，请检查在其他应用中保存或转换文件时是否更改了页面设置。如果没有，请检查导出布局、图像比例、查看器设置以及打印机的纸张选择。