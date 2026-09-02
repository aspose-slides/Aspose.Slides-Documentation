---
title: PHP 中的低代码演示操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/php-java/low-code-presentation-operations/
keywords:
- 低代码演示 API
- 转换演示文稿
- 合并演示文稿
- 遍历幻灯片
- 遍历形状
- 遍历文本
- 收集形状
- 压缩演示文稿
- 移除未使用的母版幻灯片
- 移除未使用的布局幻灯片
- 压缩嵌入字体
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、遍历内容、收集形状，并降低演示文稿大小。"
---
## **概览**

The [aspose.slides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/) 命名空间提供用于常见演示操作的静态帮助类。这些帮助类将常用的对象模型工作流封装在专注的方法中，使您可以更少的代码完成转换或合并文件、处理演示元素、收集形状以及删除未使用的内容。

低代码帮助程序在操作适用于整个文件或演示且默认工作流满足需求时最为有用。当您需要对单个幻灯片、母版、布局、形状、导出设置或演示元素之间的关系进行细粒度控制时，请使用完整的[Aspose.Slides对象模型](https://reference.aspose.com/slides/zh/php-java/aspose.slides/)。

下表概括了可用的帮助程序：

| 帮助程序 | 适用场景 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/php-java/aspose.slides/convert/) | 通过直接的文件到文件调用将演示文稿转换为另一种格式。 |
| [Merger](https://reference.aspose.com/slides/zh/php-java/aspose.slides/merger/) | 合并相同格式的完整演示文件。 |
| [ForEach_](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/) | 对每个幻灯片、形状、段落或文本片段运行回调。 |
| [Collect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/collect/) | 从整个演示文稿检索形状，以便重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/) | 删除未使用的母版和布局并减少嵌入字体数据。 |

## **转换演示文稿**

当输出文件扩展名足以确定导出格式时，请使用[Convert::autoByExtension](https://reference.aspose.com/slides/zh/php-java/aspose.slides/convert/#autoByExtension)。该方法打开源演示文稿，根据输出路径确定所需格式并写入结果。

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh/php-java/aspose.slides/convert/) 类还提供针对 PDF、SVG、JPEG、PNG 和 TIFF 输出的专用方法。当您需要在导出前检查或修改演示文稿，或配置选定帮助程序未公开的导出选项时，请使用完整的对象模型。有关特定格式的工作流和选项，请参见[Convert Presentation](/slides/zh/php-java/convert-presentation/)。

## **合并演示文稿**

使用[Merger::process](https://reference.aspose.com/slides/zh/php-java/aspose.slides/merger/#process)一次调用即可合并完整的演示文件。输入的演示文稿必须具有相同的文件格式。

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

当所有幻灯片应直接追加到一个结果中，而无需单独选择或重新映射时，此帮助程序适用。当您需要合并选定的幻灯片、应用目标母版或布局、显式保留章节，或协调不同的幻灯片尺寸时，请使用完整的对象模型。有关这些情形，请参见[Merge Presentations](/slides/zh/php-java/merge-presentation/)。

## **遍历演示元素**

[ForEach_](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/) 类对每种请求的演示元素类型调用回调。它避免了嵌套的集合循环，便于对整个演示进行检查或格式更改。

以下示例使用[ForEach_::slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#slide)、[ForEach_::shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#shape)、[ForEach_::paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#paragraph)和[ForEach_::portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#portion)检查相应的元素：

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

默认情况下，遍历整个演示的形状和文本会包括普通、母版和布局幻灯片。带有`includeNotes`参数的重载还可以处理备注幻灯片。当遍历顺序、提前退出、回调前的过滤或对父子关系的细粒度控制重要时，请使用直接的集合循环。

## **收集形状**

当您需要获取演示文稿中所有形状的集合，而不是对每个形状进行回调时，请使用[Collect::shapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/collect/#shapes)。当同一批形状会被多次过滤、计数或处理时，这很有用。

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

如果每个形状可以立即处理且不需要保留收集的结果，请改用[ForEach_::shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#shape)。

## **压缩演示内容**

[Compress](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/) 类可以删除未使用的结构元素并减少嵌入字体数据：

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 移除没有普通幻灯片引用的布局幻灯片。
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/#removeUnusedMasterSlides) 移除不再使用的母版幻灯片。
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/#compressEmbeddedFonts) 从嵌入字体中删除未使用的字符。

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

先删除未使用的布局，再删除未使用的母版，这样在布局清理后变为未引用的母版也能被移除。如果稍后可能需要原始的母版、布局或完整的嵌入字体数据，请将优化后的演示保存为新文件。更多细节，请参见[Slide Master](/slides/zh/php-java/slide-master/)和[Embedded Font](/slides/zh/php-java/embedded-font/)。

## **常见问题**

**何时应该使用低代码 API 而不是完整对象模型？**

当标准操作适用于完整文件或演示且不需要对各个元素进行细致控制时，请使用低代码帮助程序。当需要选择特定幻灯片、控制母版和布局的关系、检查中间状态，或配置帮助程序未公开的行为时，请使用完整的对象模型。

**Merger 能够合并不同文件格式的演示文稿吗？**

不能。[Merger::process](https://reference.aspose.com/slides/zh/php-java/aspose.slides/merger/#process)要求输入演示文稿使用相同的格式。请先使用如[Convert::autoByExtension](https://reference.aspose.com/slides/zh/php-java/aspose.slides/convert/#autoByExtension)等方法将输入文件转换为统一格式，然后再合并这些已转换的文件。

**ForEach_ 是否处理母版、布局和备注幻灯片？**

[ForEach_::slide]遍历普通演示幻灯片。范围覆盖的[ForEach_::shape]、[ForEach_::paragraph]和[ForEach_::portion]操作默认包括普通、母版和布局幻灯片。使用带有`includeNotes`参数设为`true`的重载即可包含备注幻灯片。

**ForEach_::shape 与 Collect::shapes 有何区别？**

使用[ForEach_::shape]通过回调立即处理每个形状。使用[Collect::shapes]则在需要保留、过滤、计数或多次遍历的可迭代结果时使用。

**Compress 总是会使演示文件变小吗？**

不一定。结果取决于演示文稿是否包含未使用的布局、未使用的母版或含有未使用字符的嵌入字体。如果这些都不存在，相应的[Compress]操作可能不会缩小文件大小。

**ForEach_ 或 Compress 所做的更改会自动保存吗？**

不会。这些帮助程序在内存中操作已加载的[Presentation]对象。在[ForEach_]回调中更改元素或运行[Compress]后，需要调用[Presentation::save]来写入结果。

## **相关文档**

- [转换演示文稿](/slides/zh/php-java/convert-presentation/)
- [合并演示文稿](/slides/zh/php-java/merge-presentation/)
- [幻灯片母版](/slides/zh/php-java/slide-master/)
- [管理文本框](/slides/zh/php-java/manage-textbox/)
- [嵌入字体](/slides/zh/php-java/embedded-font/)