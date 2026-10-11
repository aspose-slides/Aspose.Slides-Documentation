---
title: 在 PHP 中更改备注页尺寸和方向
linktitle: 备注页尺寸
type: docs
weight: 10
url: /zh/php-java/notes-size/
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
- PHP
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for PHP 中读取和更改备注页尺寸，切换方向，验证保存的尺寸，并将备注或讲义导出为 PDF 和图像。"
---
## **概述**

使用 [Presentation::getNotesSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getnotessize/) 获取演示文稿的备注页设置。它返回一个 [NotesSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notessize/) 对象，其 [setSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notessize/setsize/) 方法设置页面尺寸。虽然设置对象本身不能被替换，但可以通过此方法分配新尺寸。

宽度和高度以 **点** 为单位，1 英寸等于 72 点。例如，900 × 600 点相当于 12.5 × 8⅓ 英寸。这些设置适用于整个演示文稿，而不是单个幻灯片的备注。

| 设置 | 用途 |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getnotessize/) | 控制备注页尺寸以及用于讲义导出的页面尺寸。 |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getslidesize/) | 通过 [SlideSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesize/) 控制普通演示文稿幻灯片的尺寸。 |

更改任一设置不会自动更改另一设置。更改备注页方向也不会旋转普通幻灯片。请参阅 [Slide Size](/slides/zh/php-java/slide-size/) 了解如何调整普通幻灯片的尺寸。

下面的示例使用已有的 `sample.pptx`。对于导出示例，请使用至少包含一张带有演讲者备注的幻灯片的演示文稿。每个示例在加载 PHP/Java Bridge 和 Aspose.Slides PHP 包装器后均可独立运行。Java 返回的数值在比较或计算前需使用 `java_values` 转换为 PHP 值。

## **读取备注页尺寸和方向**

读取宽度和高度并进行比较即可确定方向：宽的页面为横向，长的页面为纵向，宽高相等则为正方形页面。此示例以点为单位打印实际尺寸，而不假设标准纸张大小。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **在不更改纸张大小的情况下切换为横向**

仅更改方向时，交换当前的宽度和高度即可。这会保持两边的长度不变，包括自定义纸张大小的情况。下面的条件可防止已是横向的页面被切换回纵向，并保持正方形页面不变。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

对于纵向方向，当 `java_values($size->getWidth()) > java_values($size->getHeight())` 时使用相同的赋值。除非您也想更改纸张大小，否则不要替换为 A4 或 Letter 尺寸。

## **设置并验证自定义备注页尺寸**

一次性同时分配两个维度，然后使用 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/save/) 将演示文稿写入磁盘。此示例将页面设为 900 × 600 点的横向页面，保存为 PPTX，并再次打开已保存的文件以检查持久化的值。比较时对浮点值容许 0.01 点的误差；这并不保证每种文件格式的精度。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

预期结果为 `900 x 600 points` 和 `Size preserved: true`。检查新打开的演示文稿可验证已保存的文件，而不仅仅是内存中的设置。

## **导出备注和讲义**

页面尺寸定义了备注或讲义布局可用的区域。它们本身并不会启用这些布局：还需配置导出选项。普通幻灯片的导出仍使用幻灯片尺寸。

### **将备注导出为 PDF 和 PNG**

将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notescommentslayoutingoptions/) 赋给 [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 以在 PDF 中包含备注。此示例还使用 [Slide::getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getImage) 和 [RenderingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/renderingoptions/) 将带备注的第一张幻灯片渲染为 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notespositions/) 模式将备注保持在单页上；不适配的备注会被截断。PDF 使用 900 × 600 点的页面。以下示例中使用的 1 × 1 图像比例，使 PNG 为 900 × 600 像素。点描述页面几何，像素描述光栅输出，其尺寸还取决于渲染比例。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

对于包含长备注的 PDF 导出，使用 [BottomFull](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notespositions/) 可以在需要时添加额外页面。不要在上述单张幻灯片的图像调用中使用该模式，因为它不支持。调整尺寸后，请检查输出中是否有被截断的备注以及现有备注母版对象的位置；仅更改页面尺寸并不保证所有内容都能适配。更多关于备注导出，请参阅 [Convert PowerPoint to PDF with Notes](/slides/zh/php-java/convert-powerpoint-to-pdf-with-notes/)。

### **将讲义导出为 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/handoutlayoutingoptions/) 可在一页上放置多个幻灯片缩略图。以下示例将页面设为 900 × 600 点，并使用 [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/zh/php-java/aspose.slides/handouttype/) 将每页安排最多四张幻灯片。水平预设控制幻灯片顺序；页面方向则取决于其宽度和高度。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

更改页面尺寸会改变讲义网格可用的面积，但不会更改源幻灯片的尺寸。对于讲义图像，请使用 [Presentation::getImages](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getimages/) 并指定讲义布局，而不是单个幻灯片的图像方法。在 Aspose.Slides 中，演示文稿级别的讲义渲染使用备注页尺寸，而单张幻灯片的图像调用不会生成讲义页。有关布局选项，请参阅 [Handout Mode](/slides/zh/php-java/convert-powerpoint-in-handout-mode/)。

## **在查看器、导出和打印中的页面尺寸**

保持存储的演示文稿尺寸、导出的页面尺寸以及打印的纸张尺寸相互独立：

- **演示文稿查看器：** 查看器可以使用自身的布局规则显示或打印备注。如果其他应用保存了文件，请重新打开并再次检查尺寸；该应用的格式转换可能会对尺寸进行标准化。
- **导出格式：** 上述备注和讲义 PDF 示例使用已配置的页面尺寸。光栅图像使用整数像素尺寸和渲染比例，因而在图像输出中可能会对小数点值进行四舍五入。导出普通幻灯片不使用备注页尺寸。
- **打印机驱动程序：** 纸张选择、自动旋转和适页设置会在不更改演示文稿或 PDF 中存储的尺寸的情况下改变实际输出。针对特定纸张大小，请匹配打印机设置并检查打印预览。

## **常见问题**

**我可以只为单张幻灯片设置备注尺寸吗？**

备注页尺寸是演示文稿级别的设置。各幻灯片可以拥有不同的备注内容，但此属性不提供每张幻灯片单独的页面尺寸。

**为什么更改备注方向没有影响我的幻灯片？**

备注页和普通幻灯片拥有独立的尺寸。若要调整幻灯片本身，请使用普通幻灯片尺寸设置。

**为什么我的保存或打印结果尺寸不同？**

首先重新打开已保存的演示文稿并比较其备注尺寸。如果已改变，检查是否在其他应用中保存或转换文件时更改了页面设置。若未改变，则检查导出布局、图像比例、查看器设置以及打印机纸张选择。