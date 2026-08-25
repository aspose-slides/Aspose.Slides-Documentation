---
title: Java 中的低代码演示文稿操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/java/low-code-presentation-operations/
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
- 删除未使用的版式幻灯片
- 压缩嵌入字体
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、遍历内容、收集形状，并减小演示文稿的大小。"
---
## **概述**

[com.aspose.slides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/) 包提供用于常见演示文稿操作的静态帮助类。这些帮助类将常用的对象模型工作流封装在专注的方法中，使您能够在更少的代码量下转换或合并文件、处理演示文稿元素、收集形状以及删除未使用的内容。

低代码帮助器在操作适用于整个文件或演示文稿且默认工作流符合您的需求时最为有用。当您需要对单个幻灯片、母版、版式、形状、导出设置或演示文稿元素之间的关系进行细粒度控制时，请使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh/java/com.aspose.slides/)。

下表概述了可用的帮助器：

| 帮助器 | 适用场景 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/java/com.aspose.slides/convert/) | 使用直接的文件到文件调用将演示文稿转换为另一种格式。 |
| [Merger](https://reference.aspose.com/slides/zh/java/com.aspose.slides/merger/) | 合并相同格式的完整演示文稿文件。 |
| [ForEach](https://reference.aspose.com/slides/zh/java/com.aspose.slides/foreach/) | 对每个幻灯片、形状、段落或文本片段运行操作。 |
| [Collect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/collect/) | 从整个演示文稿中检索形状以进行重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compress/) | 删除未使用的母版和版式并减少嵌入字体数据。 |

## **转换演示文稿**

当输出文件扩展名足以选择导出格式时，请使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)。该方法打开源演示文稿，根据输出路径确定所需格式，并写入结果。

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert] 类还提供针对 PDF、SVG、JPEG、PNG 和 TIFF 输出的专用方法。当您需要在导出前检查或修改演示文稿，或配置所选帮助器未公开的导出选项时，请使用完整的对象模型。有关特定格式的工作流和选项，请参阅 [转换演示文稿](/slides/zh/java/convert-presentation/)。

## **合并演示文稿**

使用 [Merger.process](https://reference.aspose.com/slides/zh/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 可一次调用合并完整的演示文稿文件。输入的演示文稿必须具有相同的文件格式。

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

当所有幻灯片应直接追加到一个结果且无需单独选择或重新映射时，此帮助器适用。当您需要合并选定的幻灯片、应用目标母版或版式、显式保留章节，或调和不同的幻灯片尺寸时，请使用完整的对象模型。有关这些场景，请参阅 [合并演示文稿](/slides/zh/java/merge-presentation/)。

## **遍历演示文稿元素**

[ForEach] 类为每种请求的演示文稿元素类型调用回调。它避免了嵌套的集合循环，方便进行全局检查或格式更改。

以下示例使用 [ForEach.slide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)、[ForEach.shape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/zh/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、和 [ForEach.portion](https://reference.aspose.com/slides/zh/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 来检查相应的元素：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

默认情况下，跨整个演示文稿的形状和文本遍历包括普通、母版和版式幻灯片。带有 `includeNotes` 参数的重载还可以处理备注幻灯片。当遍历顺序、提前退出、在回调调用前过滤或需要详细的父子控制很重要时，请使用直接的集合循环。

## **收集形状**

当您需要获取演示文稿中所有形状的集合而不是为每个形状提供回调时，请使用 [Collect.shapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)。当同一集合需要多次过滤、计数或处理时，这很有用。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

如果每个形状可以立即处理且不需要保留收集的结果，请改用 [ForEach.shape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)。

## **压缩演示文稿内容**

[Compress] 类可以删除未使用的结构元素并降低嵌入字体数据：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 删除没有普通幻灯片引用的版式幻灯片。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 删除不再使用的母版幻灯片。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 删除嵌入字体中未使用的字符。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在删除未使用的母版之前先删除未使用的版式，这样在版式清理后变为未引用的母版也可以被删除。如果以后可能需要原始的母版、版式或完整的嵌入字体数据，请将优化后的演示文稿保存为新文件。有关更多细节，请参阅 [幻灯片母版](/slides/zh/java/slide-master/) 和 [嵌入字体](/slides/zh/java/embedded-font/)。

## **常见问题**

**何时应使用低代码 API 而不是完整的对象模型？**

当标准操作适用于完整文件或演示文稿且无需对单个元素进行详细控制时，请使用低代码帮助器。当您需要选择特定幻灯片、控制母版和版式关系、检查中间状态或配置帮助器未公开的行为时，请使用完整的对象模型。

**Merger 能否合并不同文件格式的演示文稿？**

不能。[Merger.process] 要求输入的演示文稿具有相同的格式。请先使用例如 [Convert.autoByExtension] 将输入文件转换为统一格式，然后再合并已转换的文件。

**ForEach 是否处理母版、版式和备注幻灯片？**

[ForEach.slide] 遍历普通演示幻灯片。全局的 [ForEach.shape]、[ForEach.paragraph] 和 [ForEach.portion] 操作默认包括普通、母版和版式幻灯片。使用带有 `includeNotes` 设置为 `true` 的重载即可包含备注幻灯片。

**ForEach.shape 与 Collect.shapes 有何区别？**

使用 [ForEach.shape] 可以通过回调立即处理每个形状。需要可保留、可过滤、可计数或可多次遍历的可迭代结果时，请使用 [Collect.shapes]。

**Compress 总是会使演示文稿文件变小吗？**

不一定。结果取决于演示文稿是否包含未使用的版式、未使用的母版或嵌入字体中未使用的字符。如果这些都不存在，相应的 [Compress] 操作可能不会减小文件大小。

**ForEach 或 Compress 所做的更改会自动保存吗？**

不会。这些帮助器在内存中的加载的 [Presentation] 对象上操作。在 [ForEach] 回调中更改元素或运行 [Compress] 后，需调用 [Presentation.save] 将结果写入文件。

## **相关文章**

- [转换演示文稿](/slides/zh/java/convert-presentation/)
- [合并演示文稿](/slides/zh/java/merge-presentation/)
- [幻灯片母版](/slides/zh/java/slide-master/)
- [管理文本框](/slides/zh/java/manage-textbox/)
- [嵌入字体](/slides/zh/java/embedded-font/)