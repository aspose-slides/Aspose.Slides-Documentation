---
title: Evaluate Aspose.Slides
type: docs
weight: 110
url: /cpp/evaluate-aspose-slides/
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
- C++
- Aspose.Slides
description: "Evaluate Aspose.Slides for C++ and explore API features for PowerPoint (PPT, PPTX) and OpenDocument (ODP) presentations—start your free trial."
---

## **Aspose.Slides Evaluation**

You can download Aspose.Slides for evaluation. The evaluation package is the same as the purchased package; it becomes licensed after you add a few lines of code to apply the license, as shown in [Licensing](/slides/cpp/licensing/).

Without a license, Aspose.Slides provides its full functionality in evaluation mode, with two limitations:

* It adds one evaluation watermark text box to the middle of every slide of each presentation it saves. Opening a presentation adds no watermark, but a watermark saved earlier is loaded as a shape on its slide. So if you open a presentation that was saved in evaluation mode and save it again, each slide has two watermarks.
* Text that your code reads from a presentation is truncated to its first few characters, followed by a notice about the evaluation limitation. This applies to every slide, and also to text that your code has just set. Text that your code writes is saved in full.

{{% alert color="info" title="Note" %}}

If you want to test Aspose.Slides without the evaluation version limitations, you can also request a 30-day Temporary License. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license)

{{% /alert %}}

## **FAQ**

### Can I test multiple presentations in parallel across different threads in evaluation mode?

Yes. You can process different documents in parallel; you should not share the same presentation object [across threads](/slides/cpp/multithreading/). Evaluation mode does not affect this.

### Do I need to install Microsoft PowerPoint to evaluate the library on a server or in CI?

No. Aspose.Slides is a standalone engine and does not require PowerPoint installed for either evaluation or production.

### Can I fully test conversion of PPT/PPTX to PDF and images in evaluation mode?

Yes. The [converters](/slides/cpp/convert-presentation/) work; the output will include a watermark.

### Can I use a temporary license for load testing without a watermark?

Yes. A 30-day temporary license removes evaluation-mode limitations and allows testing without a watermark.
