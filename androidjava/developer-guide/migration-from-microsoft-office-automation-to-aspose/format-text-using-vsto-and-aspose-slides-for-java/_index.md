---
title: Format Text using VSTO and Aspose.Slides for Java
type: docs
weight: 30
url: /androidjava/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

Sometimes, you need to format the text on slides programmatically. This article shows how to read a sample presentation with some text on the first slide using either [VSTO](/slides/androidjava/format-text-using-vsto-and-aspose-slides-for-java/) and [Aspose.Slides for Java](/slides/androidjava/format-text-using-vsto-and-aspose-slides-for-java/). The code formats the text in the third textbox on the slide to look like the text in the last textbox.

{{% /alert %}} 
## **Formatting Text**
Both the VSTO and Aspose.Slides methods take the following steps:

1. Open the source presentation.
1. Access the first slide.
1. Access the third text box.
1. Change the formatting of the text in the third text box.
1. Save the presentation to disk.

The screenshots below show the sample slide before and after the execution of the VSTO and Aspose.Slides for Java code.

**The input presentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO Code Example**
The code below shows how to reformat text on a slide using VSTO.

**The text reformatted with VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java Example**
To format text with Aspose.Slides, add the font before formatting the text.

**The output presentation created with Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}
