---
title: 上标和下标
type: docs
weight: 80
url: /zh/cpp/superscript-and-subscript/
---

## **管理上标和下标文本**
您可以在任何段落部分中添加上标和下标文本。要在 Aspose.Slides 文本框中添加上标或下标文本，必须使用 **Escapement** 属性，属于 PortionFormat 类。

该属性返回或设置上标或下标文本（值在 -100%（下标）到 100%（上标）之间）。例如：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 向幻灯片添加一个矩形类型的 IAutoShape。
- 访问与 IAutoShape 关联的 ITextFrame。
- 清除现有的段落。
- 创建一个新的段落对象用于保存上标文本，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的部分对象。
- 设置该部分的 Escapement 属性为 0 到 100 之间的值以添加上标。（0 表示没有上标）
- 为部分设置一些文本，然后将其添加到段落的部分集合中。
- 创建一个新的段落对象用于保存下标文本，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的部分对象。
- 设置该部分的 Escapement 属性为 0 到 -100 之间的值以添加下标。（0 表示没有下标）
- 为部分设置一些文本，然后将其添加到段落的部分集合中。
- 将演示文稿保存为 PPTX 文件。

上述步骤的实现如下所示。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}