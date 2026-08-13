---
title: Evaluate Aspose.Slides
type: docs
weight: 120
url: /net/evaluate-aspose-slides/
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
- .NET
- C#
- Aspose.Slides
description: "Evaluate Aspose.Slides for .NET and explore API features for PowerPoint (PPT, PPTX) and OpenDocument (ODP) presentations—start your free trial."
---

## **Aspose.Slides Evaluation**

You can easily download Aspose.Slides for evaluation. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to apply the license. 

The evaluation version of Aspose.Slides (without a license specified) provides full product functionality, but it inserts an evaluation watermark at the top of the document on open and save. You are also limited to one slide when extracting texts from presentation slides.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 

If you want to test Aspose.Slides without evaluation version limitations, you can request a **30 Day Temporary License**. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for more information.

{{% /alert %}}

## **Install the Evaluation Package**

```bash
dotnet add package Aspose.Slides.NET
```

## **Apply a License**

These are the "few lines of code" that turn the evaluation package into a licensed one. Apply the
license once at application start-up, before any `Presentation` object is created — a presentation
constructed earlier keeps the evaluation watermark.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` also accepts a `Stream`, which is the better option when the license ships as an embedded
resource rather than a file on disk. If the path is wrong or the file has expired the call throws, so
failures surface immediately at start-up instead of silently reverting to evaluation mode.

Once the license is applied the watermark disappears and the one-slide text-extraction limit is lifted.

## **FAQ**

### Can I test multiple presentations in parallel across different threads in evaluation mode?

Yes. You can process different documents in parallel; you should not share the same presentation object [across threads](/slides/net/multithreading/). Evaluation mode does not affect this.

### Do I need to install Microsoft PowerPoint to evaluate the library on a server or in CI?

No. Aspose.Slides is a standalone engine and does not require PowerPoint installed for either evaluation or production.

### Can I fully test conversion of PPT/PPTX to PDF and images in evaluation mode?

Yes. The [converters](/slides/net/convert-presentation/) work; the output will include a watermark.

### Can I use a temporary license for load testing without a watermark?

Yes. A 30-day temporary license removes evaluation-mode limitations and allows testing without a watermark.
