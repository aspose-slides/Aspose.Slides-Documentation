---
title: Android 上的低代码演示文稿操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/androidjava/low-code-presentation-operations/
keywords:
- 低代码演示文稿 API
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
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、遍历内容、收集形状并减小演示文稿大小。"
---
## **概览**

[com.aspose.slides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/) 包提供了用于常见演示文稿操作的静态帮助类。这些帮助类将常用的对象模型工作流封装在专注的方法中，使您能够以更少的代码完成文件转换或合并、处理演示文稿元素、收集形状以及移除未使用的内容。

当操作适用于整个文件或演示文稿且默认工作流满足需求时，低代码帮助类最为有用。需要对单个幻灯片、母版、布局、形状、导出设置或演示文稿元素之间的关系进行细粒度控制时，请使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/)。

以下表格概述了可用的帮助类：

| 辅助类 | 使用场景 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/convert/) | 通过直接的文件到文件调用将演示文稿转换为其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/merger/) | 合并相同格式的完整演示文稿文件。 |
| [ForEach](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/) | 对每个幻灯片、形状、段落或文本片段执行操作。 |
| [Collect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/collect/) | 从整个演示文稿中检索形状，以便重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/) | 删除未使用的母版和布局并减少嵌入字体数据。 |

## **转换演示文稿**

当输出文件扩展名足以选择导出格式时，请使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)。该方法打开源演示文稿，从输出路径确定所需格式，并写入结果。

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/convert/) 类还提供针对 PDF、SVG、JPEG、PNG 和 TIFF 的专用输出方法。需要在导出前检查或修改演示文稿，或配置帮助类未公开的导出选项时，请使用完整的对象模型。有关特定格式的工作流和选项，请参阅 [Convert Presentation](/slides/zh/androidjava/convert-presentation/)。

## **合并演示文稿**

使用 [Merger.process](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 可以一次调用合并完整的演示文稿文件。输入的演示文稿必须具有相同的文件格式。

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

当所有幻灯片都应追加到一个结果中且不需要单独选择或重新映射时，此帮助类非常合适。需要合并选定的幻灯片、应用目标母版或布局、显式保留节，或调和不同的幻灯片尺寸时，请使用完整的对象模型。有关这些场景，请参阅 [Merge Presentations](/slides/zh/androidjava/merge-presentation/)。

## **遍历演示文稿元素**

[ForEach](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/) 类为每种请求的演示文稿元素类型调用回调。它避免了嵌套的集合循环，便于对整个演示文稿进行检查或格式更改。

以下示例使用 [ForEach.slide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)、[ForEach.shape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、以及 [ForEach.portion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 来检查相应的元素：

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

默认情况下，跨整个演示文稿的形状和文本遍历会包含普通、母版和布局幻灯片。带有 `includeNotes` 参数的重载还可以处理备注幻灯片。当遍历顺序、提前退出、在回调调用前过滤或需要详细的父子控制很重要时，请使用直接的集合循环。

## **收集形状**

当您需要获取演示文稿中所有形状的集合，而不是对每个形状使用回调时，请使用 [Collect.shapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)。这在需要对同一组形状进行多次过滤、计数或处理时非常有用。

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

如果每个形状可以立即处理且不需要保留收集结果，请改用 [ForEach.shape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)。

## **压缩演示文稿内容**

[Compress](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/) 类可以删除未使用的结构元素并减少嵌入的字体数据：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 删除没有普通幻灯片引用的布局幻灯片。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 删除不再使用的母版幻灯片。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 删除嵌入字体中未使用的字符。

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

先移除未使用的布局，再移除未使用的母版，这样在布局清理后变为未引用的母版也能被删除。如果以后可能需要原始的母版、布局或完整的嵌入字体数据，请将优化后的演示文稿保存为新文件。更多细节请参阅 [Slide Master](/slides/zh/androidjava/slide-master/) 和 [Embedded Font](/slides/zh/androidjava/embedded-font/)。

## **常见问题**

**何时应使用低代码 API 而不是完整对象模型？**  
当标准操作适用于完整文件或演示文稿且不需要对单个元素进行细致控制时，请使用低代码帮助类。需要选择特定幻灯片、控制母版和布局关系、检查中间状态或配置帮助类未公开的行为时，请使用完整对象模型。

**Merger 能够合并不同文件格式的演示文稿吗？**  
不能。[Merger.process](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 要求输入演示文稿使用相同格式。请先使用例如 [Convert.autoByExtension](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) 将输入文件转换为统一格式，然后再合并已转换的文件。

**ForEach 是否处理母版、布局和备注幻灯片？**  
[ForEach.slide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) 只遍历普通演示幻灯片。跨整个演示文稿的 [ForEach.shape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) 和 [ForEach.portion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 默认包括普通、母版和布局幻灯片。使用带有 `includeNotes` 参数并设置为 `true` 的重载可以包含备注幻灯片。

**ForEach.shape 与 Collect.shapes 有何区别？**  
使用 [ForEach.shape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) 可以通过回调立即处理每个形状。使用 [Collect.shapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) 则会得到一个可迭代的结果，您可以保留、过滤、计数或多次遍历该集合。

**Compress 总是会让演示文稿文件变小吗？**  
不一定。结果取决于演示文稿是否包含未使用的布局、未使用的母版或带有未使用字符的嵌入字体。如果这些情况都不存在，对应的 [Compress](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/) 操作可能不会减小文件大小。

**ForEach 或 Compress 所做的更改会自动保存吗？**  
不会。这些帮助类在内存中的 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 对象上工作。 在 [ForEach](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/foreach/) 回调或运行 [Compress](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/) 后，需调用 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 将结果写入文件。

## **相关文档**

- [Convert Presentation](/slides/zh/androidjava/convert-presentation/)
- [Merge Presentations](/slides/zh/androidjava/merge-presentation/)
- [Slide Master](/slides/zh/androidjava/slide-master/)
- [Manage Text Box](/slides/zh/androidjava/manage-textbox/)
- [Embedded Font](/slides/zh/androidjava/embedded-font/)