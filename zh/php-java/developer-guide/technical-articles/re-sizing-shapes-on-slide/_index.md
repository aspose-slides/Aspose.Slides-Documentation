---
title: 在幻灯片上调整形状大小
type: docs
weight: 110
url: /zh/php-java/re-sizing-shapes-on-slide/
---

## **在幻灯片上调整形状大小**
Aspose.Slides for PHP via Java 的客户经常问的一个问题是如何调整形状的大小，以便在更改幻灯片大小时数据不会被切断。这个简短的技术提示展示了如何实现这一点。

为了避免形状错位，幻灯片上的每个形状需要根据新的幻灯片大小进行更新。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

如果幻灯片中有任何表格，那么上述代码将不能完美工作。在这种情况下，表格的每个单元格都需要重新调整大小。

{{% /alert %}} 

如果您需要调整带有表格的幻灯片大小，则需要在您这边使用以下代码。设置表格的宽度或高度是形状中的一个特殊情况，您需要调整单独的行高和列宽以改变表格的高度和宽度。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}