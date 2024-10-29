---
title: 在PPTX中复制段落和部分
type: docs
weight: 70
url: /zh/java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

为了格式化演示文稿文本，我们需要在**段落**和**部分**级别进行格式化。有些文本属性可以在段落级别设置，而有些则在部分级别设置。如果文本中有需要复制到新添加的段落或部分的段落或部分，我们需要将相应段落或部分的所有属性复制到新添加的段落或部分中。

{{% /alert %}} 
## **复制段落**
**Paragraph**的属性可以通过**Paragraph**类的**ParagraphFormat**实例访问。我们需要将源段落的所有属性复制到目标段落。在下面的示例中，分享了**CopyParagraph**方法，该方法将要复制的段落作为参数。它将源段落的所有属性复制到一个临时段落并返回相同的内容。目标段落获得复制的值。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}


## **复制部分**
**Portion**的属性可以通过**Portion**类的**PortionFormat**实例访问。我们需要将源部分的所有属性复制到目标部分。在下面的示例中，分享了**CopyPortion**方法，该方法将要复制的部分作为参数。它将源部分的所有属性复制到一个临时部分并返回相同的内容。目标部分获得复制的值。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}