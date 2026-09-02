---
title: JavaScript 中的低代码演示文稿操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/nodejs-java/low-code-presentation-operations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、遍历内容、收集形状并减小演示文稿大小。"
---
## **概述**

`aspose.slides` 命名空间提供用于常见演示文稿操作的静态帮助类。这些帮助类将常用的对象模型工作流封装在专注的方法中，使您能够以更少的代码转换或合并文件、处理演示文稿元素、收集形状以及删除未使用的内容。

低代码帮助器在操作适用于整个文件或演示文稿且默认工作流符合您的需求时最为有用。当您需要对单个幻灯片、母版、布局、形状、导出设置或演示元素之间的关系进行细粒度控制时，请使用完整的 [Aspose.Slides 对象模型](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/)。

下表概述了可用的帮助器：

| 帮助器 | 使用场景 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/convert/) | 将演示文稿转换为另一种格式，使用直接的文件到文件调用。 |
| [Merger](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/merger/) | 合并相同格式的完整演示文稿文件。 |
| [ForEach](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/) | 对每个幻灯片、形状、段落或文字块运行操作。 |
| [Collect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/collect/) | 从整个演示文稿检索形状，以便重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/) | 删除未使用的母版和布局并减少嵌入的字体数据。 |

## **转换演示文稿**

当输出文件扩展名足以选择导出格式时，请使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/convert/#autoByExtension)。该方法打开源演示文稿，根据输出路径确定所需格式并写入结果。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/convert/) 类还提供针对 PDF、SVG、JPEG、PNG 和 TIFF 输出的专用方法。当您需要在导出前检查或修改演示文稿，或配置选定帮助器未公开的导出选项时，请使用完整的对象模型。有关特定格式的工作流和选项，请参阅 [Convert Presentation](/slides/zh/nodejs-java/convert-presentation/)。

## **合并演示文稿**

使用 [Merger.process](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/merger/#process) 可一次调用合并完整的演示文稿文件。输入的演示文稿必须具有相同的文件格式。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

当所有幻灯片应直接追加到一个结果而无需单独选择或重新映射时，该帮助器适用。当您需要合并选定的幻灯片、应用目标母版或布局、显式保留章节，或协调不同的幻灯片尺寸时，请使用完整的对象模型。有关这些场景，请参阅 [Merge Presentations](/slides/zh/nodejs-java/merge-presentation/)。

## **遍历演示文稿元素**

[ForEach](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/) 类为每种请求的演示文稿元素类型调用回调。它避免了嵌套的集合循环，便于全局检查或格式更改。在 Node.js 中，可使用 `java.newProxy` 创建回调接口的实现。

以下示例使用 [ForEach.slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#slide)、[ForEach.shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#paragraph) 和 [ForEach.portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#portion) 来检查相应的元素：

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

默认情况下，整个演示文稿的形状和文本遍历包括普通、母版和布局幻灯片。带有 `includeNotes` 参数的重载还可以处理备注幻灯片。当遍历顺序、提前退出、在回调调用前进行过滤或需要详细的父子控制重要时，请使用直接的集合循环。

## **收集形状**

当您需要获取演示文稿中所有形状的集合而不是对每个形状的回调时，请使用 [Collect.shapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/collect/#shapes)。当同一集合需要多次过滤、计数或处理时，这很有用。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

如果每个形状可以立即处理且不需要保留收集的结果，请改用 [ForEach.shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#shape)。

## **压缩演示文稿内容**

[Compress](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/) 类可以删除未使用的结构元素并减少嵌入的字体数据：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 删除没有普通幻灯片引用的布局幻灯片。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) 删除不再使用的母版幻灯片。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) 删除嵌入字体中未使用的字符。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

先删除未使用的布局，再删除未使用的母版，这样在布局清理后变为未引用的母版也能被删除。如果您以后可能需要原始的母版、布局或完整的嵌入字体数据，请将优化后的演示文稿保存为新文件。更多细节，请参阅 [Slide Master](/slides/zh/nodejs-java/slide-master/) 和 [Embedded Font](/slides/zh/nodejs-java/embedded-font/)。

## **常见问题**

**何时应该使用低代码 API 而不是完整的对象模型？**

当标准操作适用于完整文件或演示文稿且不需要对单个元素进行细粒度控制时，请使用低代码帮助器。当您需要选择特定幻灯片、控制母版和布局关系、检查中间状态或配置帮助器未公开的行为时，请使用完整的对象模型。

**Merger 能否合并不同文件格式的演示文稿？**

不可以。[Merger.process](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/merger/#process) 要求输入的演示文稿具有相同的格式。请先使用例如 [Convert.autoByExtension](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/convert/#autoByExtension) 将输入文件转换为统一格式，然后再合并转换后的文件。

**ForEach 会处理母版、布局和备注幻灯片吗？**

[ForEach.slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#slide) 仅遍历普通演示幻灯片。全局的 [ForEach.shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#paragraph) 和 [ForEach.portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#portion) 操作默认包括普通、母版和布局幻灯片。将它们的重载参数 `includeNotes` 设置为 `true` 可包含备注幻灯片。

**ForEach.shape 与 Collect.shapes 有何区别？**

使用 [ForEach.shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#shape) 可通过回调立即处理每个形状。当您需要可保留、过滤、计数或多次遍历的可迭代结果时，请使用 [Collect.shapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/collect/#shapes)。

**Compress 总是能使演示文稿文件更小吗？**

不一定。结果取决于演示文稿是否包含未使用的布局、未使用的母版或包含未使用字符的嵌入字体。如果这些都不存在，相应的 [Compress](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/) 操作可能不会减小文件大小。

**ForEach 或 Compress 所做的更改会自动保存吗？**

不会。这些帮助器在内存中操作已加载的 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 对象。更改 [ForEach](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/) 回调中的元素或运行 [Compress](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/) 后，需要调用 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save) 将结果写入文件。

## **相关文章**

- [转换演示文稿](/slides/zh/nodejs-java/convert-presentation/)
- [合并演示文稿](/slides/zh/nodejs-java/merge-presentation/)
- [幻灯片母版](/slides/zh/nodejs-java/slide-master/)
- [管理文本框](/slides/zh/nodejs-java/manage-textbox/)
- [嵌入字体](/slides/zh/nodejs-java/embedded-font/)