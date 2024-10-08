---
title: 使用 VSTO 和 Aspose.Slides for Java 格式化文本
type: docs
weight: 30
url: /java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

有时，您需要以编程方式格式化幻灯片上的文本。本文展示了如何使用 [VSTO](/slides/java/format-text-using-vsto-and-aspose-slides-for-java/) 和 [Aspose.Slides for Java](/slides/java/format-text-using-vsto-and-aspose-slides-for-java/) 读取带有一些文本的示例演示文稿的第一页。代码将幻灯片上第三个文本框中的文本格式化为与最后一个文本框中的文本相同的样式。

{{% /alert %}} 
## **格式化文本**
VSTO 和 Aspose.Slides 方法都执行以下步骤：

1. 打开源演示文稿。
1. 访问第一页幻灯片。
1. 访问第三个文本框。
1. 更改第三个文本框中文本的格式。
1. 将演示文稿保存到磁盘。

以下截图展示了在执行 VSTO 和 Aspose.Slides for Java 代码之前和之后的示例幻灯片。

**输入演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO 代码示例**
以下代码展示了如何使用 VSTO 重新格式化幻灯片上的文本。

**使用 VSTO 重新格式化的文本** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java 示例**
要使用 Aspose.Slides 格式化文本，请在格式化文本之前添加字体。

**使用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}