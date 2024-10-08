---
title: 在幻灯片上调整形状大小
type: docs
weight: 110
url: /java/re-sizing-shapes-on-slide/
---

## **在幻灯片上调整形状大小**
Aspose.Slides for Java 客户最常问的问题之一是如何调整形状大小，以便在更改幻灯片大小时数据不会被截断。这条简短的技术提示展示了如何实现这一点。

为了避免形状偏离，每个形状需要根据新的幻灯片大小进行更新。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

如果幻灯片中有任何表格，则上述代码可能无法完美执行。在这种情况下，需要调整表格的每个单元格大小。

{{% /alert %}} 

如果您需要调整包含表格的幻灯片，请使用以下代码。设置表格的宽度或高度是形状中的一个特例，您需要更改单独行的高度和列的宽度来调整表格的高度和宽度。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}