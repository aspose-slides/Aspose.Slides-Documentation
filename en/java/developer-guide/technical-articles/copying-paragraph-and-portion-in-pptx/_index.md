---
title: Copying Paragraph and Portion in PPTX
type: docs
weight: 70
url: /java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

In order to format presentation text we need to format that on **Paragraph** and **Portion** level. There are some text properties that can be set on Paragraph level and some are set on Portion level. If there is a paragraph or portion in the text that we need to copy to newly added paragraphs or portions, we need to copy all properties of respective paragraph or portion to newly added paragraph or portion.

{{% /alert %}} 
## **Copying a Paragraph**
The properties of the **Paragraph** can be accessed in **ParagraphFormat** instance of **Pargraph** class. We need to copy all the properties of source paragraph to target paragraph. In the following example, the **CopyParagraph** method is shared that takes paragraph to be copied as an argument. It copies all the properties of source paragraph to a temporary paragraph and return the same. The target paragraph gets the copied values.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}


## **Copying a Portion**
The properties of the **Portion** can be accessed in **PortionFormat** instance of **Portion** class. We need to copy all the properties of source portion to target portion . In the following example, the **CopyPortion** method is shared that takes portion to be copied as an argument. It copies all the properties of source portion to a temporary portion and return the same. The target portion gets the copied values.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}
