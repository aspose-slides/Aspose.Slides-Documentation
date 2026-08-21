---
title: PHP 中的低代码演示文稿操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/php-java/low-code-presentation-operations/
keywords:
- 低代码演示文稿 API
- 转换演示文稿
- 合并演示文稿
- 遍历幻灯片
- 遍历形状
- 遍历文本
- 收集形状
- 压缩演示文稿
- 删除未使用的母版幻灯片
- 删除未使用的布局幻灯片
- 压缩嵌入字体
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、遍历内容、收集形状并压缩演示文稿大小。"
---
## **概述**

The [aspose.slides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/zh/php-java/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

下表概述了可用的帮助类：

| Helper | 适用场景 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/php-java/aspose.slides/convert/) | 将演示文稿直接文件到文件地转换为另一种格式。 |
| [Merger](https://reference.aspose.com/slides/zh/php-java/aspose.slides/merger/) | 合并相同格式的完整演示文稿文件。 |
| [ForEach_](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/) | 对每个幻灯片、形状、段落或文本片段运行回调。 |
| [Collect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/collect/) | 从整个演示文稿检索形状以进行重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/) | 删除未使用的母版和布局并压缩嵌入字体数据。 |

## **转换演示文稿**

Use [Convert::autoByExtension](https://reference.aspose.com/slides/zh/php-java/aspose.slides/convert/#autoByExtension) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/zh/php-java/aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/php-java/convert-presentation/) for format-specific workflows and options.

## **合并演示文稿**

Use [Merger::process](https://reference.aspose.com/slides/zh/php-java/aspose.slides/merger/#process) to combine complete presentation files with one call. The input presentations must have the same file format.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/php-java/merge-presentation/) for those scenarios.

## **遍历演示文稿元素**

The [ForEach_](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach_::slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#paragraph), and [ForEach_::portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#portion) to inspect the corresponding elements:

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

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **收集形状**

Use [Collect::shapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/collect/#shapes) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach_::shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#shape) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **压缩演示文稿内容**

The [Compress](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 删除没有普通幻灯片引用的布局幻灯片。  
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/#removeUnusedMasterSlides) 删除不再使用的母版幻灯片。  
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/#compressEmbeddedFonts) 从嵌入的字体中删除未使用的字符。  

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

先删除未使用的布局，再删除未使用的母版，这样在布局清理后变为未引用的母版也能被删除。如果以后可能需要原始的母版、布局或完整的嵌入字体数据，请将优化后的演示文稿保存为新文件。更多详情，请参阅 [Slide Master](/php-java/slide-master/) 和 [Embedded Font](/php-java/embedded-font/)。

## **常见问题**

**何时应使用低代码 API 而不是完整的对象模型？**

当标准操作适用于完整文件或演示文稿且不需要对单个元素进行细致控制时，请使用低代码帮助器。当您需要选择特定幻灯片、控制母版和布局关系、检查中间状态或配置帮助器未公开的行为时，请使用完整的对象模型。

**Merger 能否合并不同文件格式的演示文稿？**

不能。[Merger::process](https://reference.aspose.com/slides/zh/php-java/aspose.slides/merger/#process) 要求输入的演示文稿具有相同的格式。请先使用例如 [Convert::autoByExtension](https://reference.aspose.com/slides/zh/php-java/aspose.slides/convert/#autoByExtension) 将输入文件转换为统一格式，然后再合并这些已转换的文件。

**ForEach_ 是否处理母版、布局和注释幻灯片？**

[ForEach_::slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#slide) 遍历普通的演示文稿幻灯片。全局的 [ForEach_::shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#shape)、[ForEach_::paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#paragraph) 和 [ForEach_::portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#portion) 默认包括普通、母版和布局幻灯片。使用它们的重载并将 `includeNotes` 设置为 `true` 可包含注释幻灯片。

**ForEach_::shape 与 Collect::shapes 有何区别？**

使用 [ForEach_::shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/foreach_/#shape) 通过回调立即处理每个形状。需要可保留、可过滤、可计数或可多次遍历的可迭代结果时，请使用 [Collect::shapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/collect/#shapes)。

**Compress 是否总会使演示文稿文件变小？**

不一定。结果取决于演示文稿是否包含未使用的布局、未使用的母版或含有未使用字符的嵌入字体。如果这些都不存在，相应的 [Compress](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/) 操作可能不会降低文件大小。

**ForEach_ 或 Compress 所做的更改会自动保存吗？**

不会。这些帮助器在内存中操作已加载的 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 对象。在 [ForEach_] 回调中更改元素或运行 [Compress] 后，需调用 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save) 将结果写入文件。

## **相关文档**

- [转换演示文稿](/php-java/convert-presentation/)
- [合并演示文稿](/php-java/merge-presentation/)
- [幻灯片母版](/php-java/slide-master/)
- [管理文本框](/php-java/manage-textbox/)
- [嵌入字体](/php-java/embedded-font/)