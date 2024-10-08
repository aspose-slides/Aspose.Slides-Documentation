---
title: 复制 PPTX 中的段落和部分
type: docs
weight: 70
url: /php-java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

为了格式化演示文稿文本，我们需要在 **段落** 和 **部分** 级别上进行格式化。一些文本属性可以在段落级别上设置，而一些则在部分级别上设置。如果文本中有需要复制到新添加的段落或部分的段落或部分，我们需要将相应段落或部分的所有属性复制到新添加的段落或部分。

{{% /alert %}} 
## **复制段落**
**段落** 的属性可以通过 **Paragraph** 类的 **ParagraphFormat** 实例访问。我们需要将源段落的所有属性复制到目标段落。在以下示例中，分享了 **CopyParagraph** 方法，该方法将要复制的段落作为参数。它将源段落的所有属性复制到一个临时段落并返回该段落。目标段落获取复制的值。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}


## **复制部分**
**部分** 的属性可以通过 **Portion** 类的 **PortionFormat** 实例访问。我们需要将源部分的所有属性复制到目标部分。在以下示例中，分享了 **CopyPortion** 方法，该方法将要复制的部分作为参数。它将源部分的所有属性复制到一个临时部分并返回该部分。目标部分获取复制的值。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}