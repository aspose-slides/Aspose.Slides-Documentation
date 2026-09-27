---
title: 在 PHP 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/php-java/create-presentation/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 创建演示文稿——可编程生成 PPT、PPTX 和 ODP 文件并可靠地保存。"
---
## **概述**

本文展示如何在 Aspose.Slides 中创建演示文稿、向其第一张幻灯片添加文本框并将结果保存为文件。还演示了如何创建并保存空演示文稿，以及如何打开已支持格式的现有演示文稿并以另一种格式保存。文末的简短 FAQ 覆盖了有关格式、模板、幻灯片尺寸、单位、内存使用、线程、授权、数字签名和 VBA 支持的常见问题。

在开始之前，请使用 Composer 安装 Aspose.Slides for PHP via Java 并在 Apache Tomcat 中启动 PHP/Java Bridge。完整的安装请参阅[Installation](/slides/zh/php-java/installation/)。下面的示例假设 Tomcat 正在 `localhost:8080` 上运行，Composer 的 `vendor` 文件夹位于脚本旁边。

## **创建 PowerPoint 演示文稿**

要创建演示文稿并在其第一张幻灯片上放置文本框，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。新演示文稿已经包含一张空幻灯片。
2. 通过索引 0，从 [Presentation::getSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getslides/) 返回的集合中获取该幻灯片。
3. 使用 [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addautoshape/) 方法添加一个矩形，并使用 [TextFrame::setText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/settext/) 设置其文本。
4. 使用 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/save/) 方法将演示文稿保存为 PPTX 文件。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

这两行 `require_once` 从 Tomcat 加载 PHP/Java Bridge 客户端，并从 Composer 包加载 Aspose.Slides 类。矩形的左上角距幻灯片左边缘 50 点，距顶部 50 点，矩形宽 400 点，高 100 点。保存的文件包含一张带有该矩形及其文本的幻灯片。未授权时，Aspose.Slides 会在保存的每张幻灯片上添加评估水印；请参阅[Licensing](/slides/zh/php-java/licensing/)。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在 Tomcat 内部读取和写入文件，而不是在 PHP 进程中，因此相对路径如 `"hello.pptx"` 会相对于 Tomcat 的工作文件夹解析。本页的示例使用 `__DIR__` 构建绝对路径，因此文件会在脚本所在目录旁读取和保存。
{{% /alert %}}

## **创建并保存演示文稿**

要创建空演示文稿并保存，实例化 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类并使用 [SaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/) 枚举中的任意格式保存。结果是一个包含一张空幻灯片的演示文稿。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **打开并保存演示文稿**

要将演示文稿从一种格式转换为另一种格式，先将文件路径传递给 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 构造函数打开，然后以目标格式保存。Aspose.Slides 会从文件本身检测输入格式，如 PPT、PPTX 或 ODP。

下面的示例假设脚本旁有名为 *Sample.odp* 的 OpenDocument 演示文稿，并将其保存为 PPTX。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### 我可以将新演示文稿保存为什么格式？

您可以保存为 [PPTX、PPT 和 ODP](/slides/zh/php-java/save-presentation/)，并导出为 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/php-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/php-java/convert-powerpoint-to-html/)、[SVG](/slides/zh/php-java/render-a-slide-as-an-svg-image/)，以及 [images](/slides/zh/php-java/convert-powerpoint-to-png/)，等等。

### 我可以从模板（POTX/POTM）开始并保存为普通 PPTX 吗？

可以。加载模板后保存为所需格式；POTX/POTM/PPTM 等类似格式 [are supported](/slides/zh/php-java/supported-file-formats/)。

### 创建演示文稿时如何控制幻灯片尺寸/宽高比？

设置 [slide size](/slides/zh/php-java/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

### 尺寸和坐标使用什么单位？

使用点（point）作为单位：1 英寸等于 72 点。

### 如何处理包含大量媒体文件的超大演示文稿以降低内存使用？

使用 [BLOB management strategies](/slides/zh/php-java/manage-blob/)，通过临时文件限制内存存储，并优先使用基于文件的工作流而非纯内存流。

### 我可以并行创建/保存演示文稿吗？

不能在 [multiple threads](/slides/zh/php-java/multithreading/) 中操作同一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例。请为每个线程或进程运行独立的实例。

### 如何去除试用水印和限制？

在每个进程中 [Apply a license](/slides/zh/php-java/licensing/)。许可证 XML 必须保持未修改，且在多线程情况下应同步许可证设置。

### 我可以对创建的 PPTX 进行数字签名吗？

可以。演示文稿支持 [Digital signatures](/slides/zh/php-java/digital-signature-in-powerpoint/)（添加和验证）。

### 创建的演示文稿是否支持宏（VBA）？

支持。您可以 [create/edit VBA projects](/slides/zh/php-java/presentation-via-vba/) 并保存为支持宏的文件，如 PPTM/PPSM。