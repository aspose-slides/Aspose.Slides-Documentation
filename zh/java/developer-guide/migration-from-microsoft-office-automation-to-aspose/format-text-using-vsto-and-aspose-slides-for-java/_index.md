---
title: 使用 VSTO 和 Aspose.Slides for Java 格式化文本
linktitle: 格式化文本
type: docs
weight: 30
url: /zh/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- 格式化文本
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "将 Microsoft Office 自动化迁移至 Aspose.Slides for Java，并在 PowerPoint（PPT、PPTX）演示文稿中以精确控制方式格式化文本。"
---
{{% alert color="info" %}} 
有时，您需要以编程方式格式化幻灯片上的文本。本文演示如何使用[VSTO](/slides/zh/java/format-text-using-vsto-and-aspose-slides-for-java/)或[Aspose.Slides for Java](/slides/zh/java/format-text-using-vsto-and-aspose-slides-for-java/)读取一个在首张幻灯片上带有文本的示例演示文稿。代码将幻灯片中第三个文本框的文本格式化为与最后一个文本框的文本相同。
{{% /alert %}} 
## **格式化文本**
VSTO 和 Aspose.Slides 方法均遵循以下步骤：

1. 打开源演示文稿。
1. 访问第一张幻灯片。
1. 访问第三个文本框。
1. 更改第三个文本框中文本的格式。
1. 将演示文稿保存到磁盘。

下面的截图展示了执行 VSTO 和 Aspose.Slides for Java 代码前后的示例幻灯片。

**输入演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO 代码示例**
下面的代码演示如何使用 VSTO 重新格式化幻灯片上的文本。

**使用 VSTO 重新格式化的文本** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}

### **Aspose.Slides for Java 示例**
要使用 Aspose.Slides 格式化文本，请在格式化文本之前添加字体。

**使用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}