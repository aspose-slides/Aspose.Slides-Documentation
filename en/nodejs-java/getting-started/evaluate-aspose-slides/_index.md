---
title: Evaluate Aspose.Slides
type: docs
weight: 120
url: /nodejs-java/evaluate-aspose-slides/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Evaluate Aspose.Slides for Node.js via Java and explore API features for PowerPoint (PPT, PPTX) and OpenDocument (ODP) presentations—start your free trial."
---

## **Aspose.Slides Evaluation**

You can download Aspose.Slides for evaluation. The evaluation package is the same as the purchased package; it becomes licensed after you add a few lines of code to apply the license. To install it, see [Installation](/slides/nodejs-java/installation/).

Without a license, Aspose.Slides provides its full functionality in evaluation mode, with two limitations: it adds an evaluation watermark text box to every slide of each presentation it saves, and text longer than five characters that your code reads from a presentation is cut to its first five characters, followed by `... text has been truncated due to evaluation version limitation.` Text of five characters or fewer is returned unchanged, and text that your code writes is saved in full. Each save adds a watermark, so a presentation that is opened and saved again in evaluation mode carries one watermark per save on every slide.

{{% alert color="info" title="Note" %}}

If you want to test Aspose.Slides without evaluation version limitations, you can request a **30 Day Temporary License**. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for more information.

{{% /alert %}}

## **FAQ**

### Can I test multiple presentations in parallel across different threads in evaluation mode?

Yes. You can process different documents in parallel; you should not share the same presentation object [across threads](/slides/nodejs-java/multithreading/). Evaluation mode does not affect this.

### Do I need to install Microsoft PowerPoint to evaluate the library on a server or in CI?

No. Aspose.Slides is a standalone engine and does not require PowerPoint installed for either evaluation or production.

### Can I fully test conversion of PPT/PPTX to PDF and images in evaluation mode?

Yes. The [converters](/slides/nodejs-java/convert-presentation/) work; the output will include a watermark.

### Can I use a temporary license for load testing without a watermark?

Yes. A 30-day temporary license removes evaluation-mode limitations and allows testing without a watermark.
