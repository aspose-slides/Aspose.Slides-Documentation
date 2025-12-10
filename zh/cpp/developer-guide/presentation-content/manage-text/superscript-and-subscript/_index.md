---
title: 使用 C++ 管理演示文稿中的上标和下标
linktitle: 上标和下标
type: docs
weight: 80
url: /zh/cpp/superscript-and-subscript/
keywords:
- 上标
- 下标
- 添加上标
- 添加下标
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中精通上标和下标，使用专业的文本格式提升演示文稿的冲击力。"
---

## **管理上标和下标文本**
您可以在任意段落部分中添加上标和下标文本。要在 Aspose.Slides 文本框中添加上标或下标文本，必须使用 **Escapement** 属于 PortionFormat 类的属性。

此属性返回或设置上标或下标文本（取值范围为 -100%（下标）到 100%（上标））。例如：

- 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
- 使用索引获取幻灯片的引用。
- 向幻灯片添加矩形类型的 IAutoShape。
- 访问与 IAutoShape 关联的 ITextFrame。
- 清除现有段落。
- 创建一个用于保存上标文本的新段落对象，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的 Portion 对象。
- 将该 Portion 的 Escapement 属性设置为 0 到 100 之间，以添加上标。（0 表示无上标）
- 为 Portion 设置一些文本，然后将其添加到段落的 Portion 集合中。
- 创建一个用于保存下标文本的新段落对象，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的 Portion 对象。
- 将该 Portion 的 Escapement 属性设置为 0 到 -100 之间，以添加下标。（0 表示无下标）
- 为 Portion 设置一些文本，然后将其添加到段落的 Portion 集合中。
- 将演示文稿保存为 PPTX 文件。

以下示例展示了上述步骤的实现。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **常见问题**

**Will superscript and subscript be preserved when exporting to PDF or other formats?**  
是的，Aspose.Slides 在将演示文稿导出为 PDF、PPT/PPTX、图像以及其他支持的格式时，会正确保留上标和下标的格式。专门的格式在所有输出文件中保持完整。

**Can superscript and subscript be combined with other formatting styles such as bold or italics?**  
是的，Aspose.Slides 允许在同一 Portion 文本中混合多种文本样式。您可以通过在 [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) 中设置相应属性，同时启用粗体、斜体、下划线并应用上标或下标。

**Do superscript and subscript formatting work for text inside tables, charts, or SmartArt?**  
是的，Aspose.Slides 支持在大多数对象（包括表格和图表元素）内的文本进行格式化。对于 SmartArt，您需要访问相应的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartnode/)）及其文本容器，然后以类似方式配置 [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) 属性。