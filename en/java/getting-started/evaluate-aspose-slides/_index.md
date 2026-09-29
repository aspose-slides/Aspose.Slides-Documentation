---
title: Evaluate Aspose.Slides
type: docs
weight: 85
url: /java/evaluate-aspose-slides/
keywords:
- evaluate Aspose.Slides
- Aspose.Slides evaluation
- evaluation version
- full functionality
- evaluation watermark
- purchase Aspose.Slides
- limitation
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Evaluate Aspose.Slides for Java and explore API features for PowerPoint (PPT, PPTX) and OpenDocument (ODP) presentations—start your free trial."
---

## **Aspose.Slides Evaluation**

You can download Aspose.Slides for evaluation. The evaluation download is the same as the purchased download; it becomes licensed after you add a few lines of code to apply the license.

Without a license, Aspose.Slides provides its full functionality in evaluation mode, with two limitations: it adds an evaluation watermark text box to every slide of each presentation it saves, and text that your code reads through the API, including text it has just set, is truncated to its first few characters, followed by a notice about the evaluation limitation. Text that your code writes is saved in full. The [getPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationText-java.lang.String-int-) method, which extracts text without loading the whole presentation, returns only evaluation notices and no slide text.

![A slide with the evaluation watermark](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}

If you want to test Aspose.Slides without the evaluation version limitations, you can also request a 30-day Temporary License. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license)

{{% /alert %}}

## **FAQ**

### Can I test multiple presentations in parallel across different threads in evaluation mode?

Yes. You can process different documents in parallel; you should not share the same presentation object [across threads](/slides/java/multithreading/). Evaluation mode does not affect this.

### Do I need to install Microsoft PowerPoint to evaluate the library on a server or in CI?

No. Aspose.Slides is a standalone engine and does not require PowerPoint installed for either evaluation or production.

### Can I fully test conversion of PPT/PPTX to PDF and images in evaluation mode?

Yes. The [converters](/slides/java/convert-presentation/) work; the output will include a watermark.

### Can I use a temporary license for load testing without a watermark?

Yes. A 30-day temporary license removes evaluation-mode limitations and allows testing without a watermark.
