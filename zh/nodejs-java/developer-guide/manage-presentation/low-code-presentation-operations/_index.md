---
title: JavaScript 中的低代码演示文稿操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/nodejs-java/low-code-presentation-operations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、遍历内容、收集形状并减小演示文稿大小。"
---
## **概览**

`aspose.slides` 命名空间提供用于常见演示文稿操作的静态辅助类。这些辅助类将常用的对象模型工作流封装为专注的方法，您可以更少的代码实现文件转换或合并、处理演示元素、收集形状以及删除未使用的内容。

低代码辅助在操作适用于整个文件或演示文稿且默认工作流满足需求时最为有用。当您需要对单个幻灯片、母版、布局、形状、导出设置或演示元素之间的关系进行细粒度控制时，请使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/)。

下表概述了可用的辅助类：

| 辅助类 | 使用场景 |
| --- | --- |
| [转换](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/convert/) | 通过直接的文件到文件调用将演示文稿转换为另一种格式。 |
| [合并](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/merger/) | 合并相同格式的完整演示文件。 |
| [遍历](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/) | 对每个幻灯片、形状、段落或文本片段执行操作。 |
| [收集](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/collect/) | 从整个演示文稿中检索形状，以便重复处理或分析。 |
| [压缩](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/) | 删除未使用的母版和布局并压缩嵌入的字体数据。 |

## **转换演示文稿**

当输出文件扩展名足以选择导出格式时，请使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/convert/#autoByExtension)。该方法打开源演示文稿，根据输出路径确定所需格式并写入结果。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Convert 类还提供针对 PDF、SVG、JPEG、PNG 和 TIFF 输出的专用方法。当您需要在导出前检查或修改演示文稿，或配置未在所选辅助类中公开的导出选项时，请使用完整的对象模型。请参阅 [转换演示文稿](/nodejs-java/convert-presentation/) 了解特定格式的工作流和选项。

## **合并演示文稿**

使用 [Merger.process](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/merger/#process) 可一次调用合并完整的演示文件。输入的演示文稿必须具有相同的文件格式。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

当所有幻灯片应直接追加到一个结果而无需单独选择或重新映射时，适合使用此辅助。当您需要合并选定的幻灯片、应用目标母版或布局、显式保留章节，或调和不同的幻灯片尺寸时，请使用完整的对象模型。请参阅 [合并演示文稿](/nodejs-java/merge-presentation/) 了解这些场景。

## **遍历演示文稿元素**

[ForEach](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/) 类会为每种请求的演示元素类型调用回调。它避免了嵌套的集合循环，并便于对整个演示进行检查或格式更改。在 Node.js 中，可使用 `java.newProxy` 创建回调接口的实现。

以下示例使用 [ForEach.slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#slide)、[ForEach.shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#paragraph) 和 [ForEach.portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#portion) 来检查相应元素：

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

默认情况下，跨整个演示的形状和文本遍历包括普通、母版和布局幻灯片。带有 `includeNotes` 参数的重载还可以处理备注幻灯片。当遍历顺序、提前退出、在回调调用前过滤或需要详细的父子控制重要时，请使用直接的集合循环。

## **收集形状**

当您需要获取演示文稿中所有形状的集合，而不是为每个形状提供回调时，请使用 [Collect.shapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/collect/#shapes)。这在相同的集合需要多次过滤、计数或处理时非常有用。

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

如果每个形状可以立即处理且不需要保留收集结果，请改用 [ForEach.shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#shape)。

## **压缩演示文稿内容**

[Compress](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/) 类可以删除未使用的结构元素并压缩嵌入的字体数据：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 删除未被普通幻灯片引用的布局幻灯片。  
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

请先删除未使用的布局，再删除未使用的母版，这样在布局清理后变为未引用的母版也能被移除。如果以后可能需要原始的母版、布局或完整的嵌入字体数据，请将优化后的演示保存为新文件。有关更多细节，请参阅 [Slide Master](/nodejs-java/slide-master/) 和 [Embedded Font](/nodejs-java/embedded-font/)。

## **常见问题**

**何时应使用低代码 API 而不是完整的对象模型？**  
当标准操作适用于整个文件或演示文稿且不需要对单个元素进行细粒度控制时，请使用低代码辅助。当您需要选择特定幻灯片、控制母版和布局关系、检查中间状态或配置辅助类未公开的行为时，请使用完整的对象模型。

**Merger 能否合并不同文件格式的演示文稿？**  
不能。[Merger.process](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/merger/#process) 要求输入演示文稿具有相同的格式。请先使用例如 [Convert.autoByExtension](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/convert/#autoByExtension) 将输入文件转换为统一格式，然后再合并转换后的文件。

**ForEach 会处理母版、布局和备注幻灯片吗？**  
[ForEach.slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#slide) 仅遍历普通演示幻灯片。跨整个演示的 [ForEach.shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#paragraph) 和 [ForEach.portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#portion) 默认包括普通、母版和布局幻灯片。使用带有 `includeNotes` 参数设为 `true` 的重载可包括备注幻灯片。

**ForEach.shape 与 Collect.shapes 有何区别？**  
使用 [ForEach.shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/#shape) 可通过回调立即处理每个形状。使用 [Collect.shapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/collect/#shapes) 则在需要可保留、过滤、计数或多次遍历的可迭代结果时使用。

**Compress 总是使演示文稿文件更小吗？**  
不一定。结果取决于演示文稿是否包含未使用的布局、未使用的母版或包含未使用字符的嵌入字体。如果这些都不存在，相应的 [Compress](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/) 操作可能不会减小文件大小。

**ForEach 或 Compress 所做的更改会自动保存吗？**  
不会。这些辅助在内存中的 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 对象上工作。更改元素后，需要在 [ForEach](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/foreach/) 回调或运行 [Compress](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/) 后，调用 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save) 将结果写入磁盘。

## **相关文章**

- [转换演示文稿](/nodejs-java/convert-presentation/)
- [合并演示文稿](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)