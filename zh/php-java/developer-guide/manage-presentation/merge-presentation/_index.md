---
title: 在 PHP 中高效合并演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/php-java/merge-presentation/
keywords:
- 合并 PowerPoint
- 合并演示文稿
- 合并幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- 合并 PowerPoint
- 合并演示文稿
- 合并幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中通过克隆幻灯片、控制母版和版式、调整幻灯片内容大小、保留章节以及处理受保护或大型文件来合并 PowerPoint 和 OpenDocument 演示文稿。"
---
## **概述**

Aspose.Slides for PHP via Java 通过克隆来自一个 [演示文稿](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 的幻灯片合并演示文稿。主要操作是 [SlideCollection::addClone()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/addclone/)，它可以保留来源幻灯片的格式，或将克隆的幻灯片附加到目标演示文稿的母版或版式上。

本文档介绍最常用的合并工作流：

- 合并所有幻灯片并保留来源格式；
- 合并选定的幻灯片；
- 使用目标演示文稿的母版；
- 使用目标演示文稿的特定版式；
- 在合并前统一不同的幻灯片尺寸；
- 将克隆的幻灯片添加到章节；
- 在一个端到端的工作流中合并多个演示文稿；
- 处理母版、资源、批注、评论、媒体、字体、密码、大文件和多线程等问题。

## **幻灯片克隆对母版和版式的影响**

幻灯片的大部分外观继承自其版式和母版。因此，您选择的克隆重载决定了合并的幻灯片如何集成到目标演示文稿中。

请以以下方式使用 [SlideCollection::addClone()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/addclone/)：

- `addClone(sourceSlide)` —— 保留来源幻灯片的版式和格式。必要时，来源母版会自动克隆到目标演示文稿中。Aspose.Slides 会自动跟踪已克隆的母版，避免对同一来源母版的重复克隆。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` —— 将克隆的幻灯片附加到特定的目标 [母版幻灯片](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslide/)。Aspose.Slides 会根据版式类型或名称在该母版下寻找匹配的版式。
- `addClone(sourceSlide, destinationLayout)` —— 将克隆的幻灯片直接附加到特定的目标 [版式幻灯片](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/)。

传入 `addClone` 重载的母版或版式必须属于 **目标** 演示文稿，而不是来源演示文稿。

## **合并整个演示文稿并保留来源格式**

最简单的合并方式是将来源演示文稿的每一张幻灯片复制到目标演示文稿中。当导入的幻灯片需要保持原始主题、母版和版式关系时，这是一种合适的选择。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

如果来源和目标使用不同的设计，生成的演示文稿可能包含多个母版。这在有意保留来源格式时是预期行为。

## **合并选定的幻灯片**

并非所有幻灯片都必须克隆。下面的示例仅从来源演示文稿中导入选定的幻灯片索引。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

在克隆之前请验证幻灯片索引，尤其是这些索引来自用户输入或外部配置时。

## **使用目标母版合并幻灯片**

当导入的幻灯片应遵循已经存在于目标演示文稿中的母版时，请使用 [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/addclone/) 重载。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides 会通过匹配来源版式的类型或名称，在指定的母版下选择合适的版式。如果不存在合适的版式且 `allowCloneMissingLayout` 为 `true`，则会克隆来源版式以便添加幻灯片；如果为 `false`，则会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxeditexception/)。

当您希望合并在没有额外版式的情况下失败时，请使用 `false`。

## **使用特定目标版式合并幻灯片**

当您明确知道导入的幻灯片应使用哪一个目标版式时，请使用 [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/addclone/) 重载。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

应用目标版式会更改继承的版式关系，但不会重新设计来源幻灯片的内容。如果来源和目标版式的占位符结构不同，请检查结果以确认继承的格式和占位符行为是否符合预期。

## **合并具有不同幻灯片尺寸的演示文稿**

可以合并尺寸不同的演示文稿，但将幻灯片克隆到尺寸不同的演示文稿时，内容不会自动为新画布重新布局。形状可能会出现位置偏移、意外缩放或超出可视区域。

一种实用做法是先调整来源演示文稿的尺寸再进行克隆。使用 [SlideSize::setSize()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesize/setsize/) 方法可以在更改幻灯片尺寸的同时缩放现有内容。[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesizescaletype/) 会将内容缩放以适应请求的尺寸。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

调整尺寸会在内存中更改来源演示文稿对象。如果您需要保留原始来源演示文稿以供其他操作，请在合并时打开一个单独的实例。

## **将幻灯片合并到演示文稿章节**

基本的幻灯片克隆循环不会重新创建来源演示文稿的章节层级。如果章节在输出中很重要，请在目标演示文稿中创建或选择章节，并使用 [addClone(Slide, Section)](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/addclone/) 将幻灯片显式克隆到相应章节。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

克隆的幻灯片会追加到指定的目标章节。若要保留多个来源章节，请枚举 [Presentation::getSections](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSections)，使用 [Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getSlidesListOfSection) 获取每个来源章节的幻灯片列表，在目标演示文稿中重新创建章节，并将每张返回的幻灯片克隆到对应的目标章节。完整的章节枚举示例请参见 [管理幻灯片章节](/slides/zh/php-java/slide-section/)，其中包括空章节和结构性更改的处理。

## **安全合并多个演示文稿**

下面的端到端示例使用第一个演示文稿作为目标，统一每个额外来源的幻灯片尺寸，仅在复制期间打开每个来源，并在最后一次保存文件。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

这是保持导入幻灯片来源格式的实用基线。如果输出必须使用单一的目标主题，请将简单的 `addClone($slide)` 调用替换为前文示例中的目标母版或目标版式重载。

## **实际注意事项**

### **母版、版式和格式保真度**

默认的幻灯片克隆可以自动将所需的来源母版带入目标演示文稿。Aspose.Slides 为自动克隆的母版维护内部注册表，以避免对同一母版的重复克隆。手动克隆的母版不会被该注册表跟踪，因此除非需要对母版结构进行显式控制，否则请避免预先克隆母版。

不要假设名称相同的两个母版或版式在视觉上是等价的。如果公司模板必须控制最终外观，请显式选择目标母版或版式，并在合并后验证结果。

### **批注和评论**

演讲者备注和幻灯片评论与幻灯片内容关联，克隆幻灯片时会一起复制。Aspose.Slides 还提供了专用的 API 用于 [演示文稿备注](/slides/zh/php-java/presentation-notes/) 和 [演示文稿评论](/slides/zh/php-java/presentation-comments/)。

如果备注页的格式很重要，请验证合并后的演示文稿，因为备注母版是演示文稿级对象，可能在来源文件之间存在差异。对于审阅工作流，还需在合并来自不同作者或模板的文件后检查评论作者及线程评论。

### **图像、音频、视频、OLE 对象和外部链接**

幻灯片可以引用演示文稿级资源，例如图像、嵌入音频、嵌入视频和 OLE 数据。请克隆整个幻灯片，而不是仅复制可见形状，这样 Aspose.Slides 才能维护幻灯片与其资源的关联。

嵌入资源和链接资源的处理方式不同。链接的音频、视频、OLE 对象或超链接仍然依赖其外部目标；克隆幻灯片不会将外部链接转换为嵌入内容。请在合并后测试链接资源的路径和 URL，确保在目标环境中可用。

Aspose.Slides 明确跟踪自动克隆的母版，但这并不等同于对来自不相关来源演示文稿的相同二进制资源进行通用去重。如果文件大小是关键，请检查合并后的包并自行测量结果，而不要依赖隐式去重。

### **嵌入字体和字体可用性**

字体在演示文稿级别管理。如果需要在不同机器上保持排版一致，请不要假设仅克隆幻灯片就能保证目标环境中具备所有必需字体。您可以使用 [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/getembeddedfonts/) 检查嵌入字体，并按照 [在演示文稿中嵌入字体](/slides/zh/php-java/embedded-font/) 的说明显式管理字体嵌入。

同时请确认您有权限嵌入来源文件使用的字体。字体许可证可能限制嵌入。

### **受密码保护的演示文稿**

必须先成功打开受密码保护的来源文件，才能克隆其幻灯片。请通过 [LoadOptions::setPassword()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/setpassword/) 提供密码。

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // 使用已解密的演示文稿进行操作。
} finally {
    $source->dispose();
}
```

打开加密的来源文件并不会自动将相同的保护应用到目标演示文稿。需要时请单独配置输出保护。

### **大型演示文稿和内存使用**

包含高分辨率图像、音频、视频或其他大二进制对象的大型演示文稿会占用大量内存。[LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) 提供了对 BLOB 处理和临时文件使用的控制。有关 PHP via Java 大文件示例，请参见 [打开演示文稿](/slides/zh/php-java/open-presentation/#open-large-presentations)。

对于大文件，尽可能使用文件路径加载，合并后立即释放每个来源演示文稿，并避免频繁保存中间结果，除非工作流需要检查点。

### **线程安全性**

不要在多个线程中加载、修改、保存或克隆 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例。这些操作在 PHP via Java 中不支持多线程使用。如果需要并行合并作业，请在独立的单线程进程中运行，每个进程使用自己的演示文稿实例，并遵循 [Aspose.Slides 多线程指南](/slides/zh/php-java/multithreading/)。

## **常见问题**

**如何保留每个来源演示文稿的原始设计？**

使用 [SlideCollection::addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/addclone/) 且不提供目标母版或版式。Aspose.Slides 会在导入幻灯片需要时自动克隆来源母版。

**如何让导入的幻灯片使用目标主题？**

使用接受目标母版的重载。传入目标演示文稿中的母版，而不是来源母版。Aspose.Slides 会尝试将每个来源幻灯片映射到该母版下的适当版式。

**何时应该使用特定的目标版式而非目标母版？**

当每张导入的幻灯片都应使用同一已知版式时使用特定版式。若希望 Aspose.Slides 根据来源版式的类型或名称在母版的多个版式之间自动选择，则使用母版。

**可以合并不同幻灯片尺寸的演示文稿吗？**

可以，但幻灯片内容不会自动为目标尺寸重新设计。需要可预测布局时，请先使用 [SlideSize::setSize()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesize/setsize/) 和 [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesizescaletype/) 调整来源演示文稿的尺寸。

**可以将 PPT、PPTX 和 ODP 演示文稿合并为一个文件吗？**

可以。加载每个来源演示文稿，克隆所需幻灯片到同一个目标中，并以受支持的输出格式保存。由于不同格式的功能集合不完全相同，跨格式合并后请验证复杂内容。参见 [受支持的文件格式](/slides/zh/php-java/supported-file-formats/)。

**来源章节会自动保留吗？**

基本的仅克隆幻灯片的循环不会保留章节。请在目标中重新创建所需章节，并使用 [addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/addclone/) 的章节重载来保留结构。

**演讲者备注和评论会被保留吗？**

会随克隆的幻灯片一起复制。对于依赖于备注母版样式、评论作者或线程审阅数据的工作流，请在合并后验证结果，因为这些场景涉及演示文稿级结构以及幻灯片级内容。

**音频、视频、OLE 对象和超链接会怎样处理？**

嵌入的内容会随克隆的幻灯片的资源关联一起保留下来。外部链接仍保持外部状态，合并后其目标文件或 URL 必须依然可用。

**是否保证所有来源的嵌入字体都在合并后的演示文稿中可用？**

仅靠幻灯片克隆不能保证字体部署。请检查目标的嵌入字体，并在排版重要时显式管理字体嵌入或外部字体可用性。

**如何合并受密码保护的文件？**

使用正确的 [LoadOptions::setPassword()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/setpassword/) 打开文件，然后正常克隆其幻灯片。输出的保护需另行配置。

**如何处理非常大的演示文稿？**

当大二进制对象主导内存使用时，使用 BLOB 管理，尽量采用文件路径加载大型文件，及时释放来源演示文稿实例，并在需要时才保存最终结果。

**可以从多个线程合并幻灯片吗？**

在 PHP via Java 中不支持在多个线程中加载、保存或克隆演示文稿。若需并行工作，请使用独立的单线程进程，并在每个进程内保持演示文稿实例相互隔离。