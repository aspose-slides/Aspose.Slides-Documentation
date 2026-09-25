---
title: 管理 Android 上的演示文稿可访问性
linktitle: 演示文稿可访问性
type: docs
weight: 30
url: /zh/androidjava/presentation-accessibility/
keywords:
- 演示文稿可访问性
- 替代文本
- 替代文本标题
- 替代文本描述
- 标记为装饰性
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android via Java 如何帮助自动化 PPT、PPTX 和 ODP 文件的演示文稿可访问性检查——提升屏幕阅读器体验并加强合规性。"
---
## **介绍**

替代文本帮助使用辅助技术的人员理解图像、图表和其他信息形状的含义。本文说明如何使用 Aspose.Slides for Android via Java 读取和更新替代文本标题和描述，区分代码中使用的形状名称与可访问性描述，并检查形状是否标记为装饰性。

这些功能支持演示文稿的可访问性，但并不能保证完全可访问。还需要检查阅读顺序、颜色对比度、文本可读性以及其他可访问性要求。

## **管理备用文本标题和描述**

使用替代文本向看不到图像的人员解释图像、图表和其他信息形状的含义。以下方法和内容各有不同用途：

| 方法或内容 | 目的 |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | 备用描述的简短标题。 |
| [getAlternativeText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | 在幻灯片上下文中，对形状内容或用途的有意义描述。 |
| [getName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getName--) | 形状的名称，代码可使用它在演示文稿中查找特定形状。 |
| 可见文本 | 在幻灯片上显示的内容，例如形状的文本或图表的标题和标签。更新备用文本不会更改此内容。 |

当演示文稿作为模板重复使用时，代码可能在更新之前通过 [getName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getName--) 返回的名称找到形状。此名称的用途与解释视觉信息给阅读者的备用文本不同。通过名称搜索使作者能够改进或翻译描述，而不影响代码定位形状的方式。名称可以编辑且不保证唯一，请检查名称是否匹配预期的形状；参见 [Identify and Find Shapes](/slides/zh/androidjava/shape-manipulations/#identify-and-find-shapes)。

以下示例需要包含 office entrance 图像的 `input.pptx`，该图像位于第一张幻灯片的第一个形状，并且未标记为装饰性。示例读取并打印其当前的备用文本标题和描述，更新这两个值，然后将演示文稿保存为 `output.pptx`。请根据实际图像及其传达的信息调整文字。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

仅添加替代文本并不能保证演示文稿的可访问性或符合可访问性标准。请审查描述的准确性和相关性，同时检查阅读顺序、颜色对比度、可读文本以及其他可访问性要求。信息性视觉元素不应标记为装饰性；下一节展示如何检查 [isDecorative](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#isDecorative--)。

## **标记为装饰性**

标记为装饰性用于纯装饰性的视觉元素，使屏幕阅读器跳过它们，减少噪音并将焦点保持在有意义的内容上。将其应用于背景、花纹和间隔符——绝不要用于传递信息的图表、图标或图像。Aspose.Slides 为此标志提供检测和验证功能，支持自动化可访问性检查和清理。

![Mark as Decorative](mark_as_decorative.png)

下面的代码示例展示如何判断形状是否标记为装饰性。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我应该在替代文本标题和描述中写什么？**

使用简短的标题标识主题，并用描述解释视觉在幻灯片上下文中传达的信息。对于图表，描述相关的趋势或比较，而不是仅写 “图表”。

**我应该使用替代文本在模板中定位形状吗？**

最好通过 [getName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getName--) 返回的名称找到形状，并确认它是预期的形状。替代文本可能被编辑或翻译，这会导致搜索精确描述的代码失效；参见 [Identify and Find Shapes](/slides/zh/androidjava/shape-manipulations/)。

**何时应将形状标记为装饰性？**

对不提供信息的视觉元素使用装饰性标志，例如装饰性花纹。传递意义的图像和图表需要相应的描述，而不是标记为装饰性。

**添加替代文本会使演示文稿完全可访问吗？**

不会。替代文本仅解决可访问性的一部分。还需审查阅读顺序、颜色对比度、文本可读性及其他相关要求，仅设置这些属性并不能确保合规。