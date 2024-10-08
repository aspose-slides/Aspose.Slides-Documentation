---
title: 使用 VSTO 和 Aspose.Slides for PHP 通过 Java 格式化文本
type: docs
weight: 30
url: /zh/php-java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

有时，您需要以编程方式格式化幻灯片上的文本。本文展示了如何使用 [VSTO](/slides/zh/php-java/format-text-using-vsto-and-aspose-slides-for-java/) 和 [Aspose.Slides for PHP 通过 Java](/slides/zh/php-java/format-text-using-vsto-and-aspose-slides-for-java/) 阅读一个第一个幻灯片上有一些文本的示例演示文稿。代码将第三个文本框中的文本格式化为最后一个文本框中的文本样式。

{{% /alert %}} 
## **格式化文本**
VSTO 和 Aspose.Slides 方法都遵循以下步骤：

1. 打开源演示文稿。
1. 访问第一个幻灯片。
1. 访问第三个文本框。
1. 更改第三个文本框中文本的格式。
1. 将演示文稿保存到磁盘。

下面的截图显示了在执行 VSTO 和 Aspose.Slides for PHP 通过 PHP 代码之前和之后的示例幻灯片。

**输入演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO 代码示例**
下面的代码展示了如何使用 VSTO 重新格式化幻灯片上的文本。

**使用 VSTO 重新格式化的文本** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for PHP 通过 Java 示例**
要使用 Aspose.Slides 格式化文本，请在格式化文本之前添加字体。

**使用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}