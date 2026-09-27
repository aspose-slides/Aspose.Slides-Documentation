---
title: Licensing
description: "Apply a license file to Aspose.Slides for Node.js via .NET, see what the evaluation version limits, and get a free 30-day temporary license for testing."
type: docs
weight: 80
url: /nodejs-net/licensing/
---

## **Overview**

Aspose.Slides for Node.js via .NET is one npm package for both evaluation and production. Without a license, it runs in evaluation mode. After you buy a license, or get a free 30-day temporary license, you apply it with a few lines of code, and the evaluation limitations no longer apply.

{{% alert color="info" title="Note" %}}

General policies on how to evaluate, license and purchase Aspose products are collected in [Purchase Policies and FAQ](https://purchase.aspose.com/policies). Prices are listed on the [Pricing Information](https://purchase.aspose.com/pricing/slides/family) page.

{{% /alert %}}

## **Evaluation Version Limitations**

The evaluation version provides the full functionality of the product, with two limitations:

- **Watermark.** Every slide of each presentation that you save gets an evaluation watermark: a locked text box in the middle of the slide that reads "Evaluation only." The same watermark is drawn on PDF, XPS and HTML exports and on slide images.
- **Truncated text.** Text that your code reads back from a text frame, paragraph or portion is cut to its first five characters, followed by the notice "... text has been truncated due to evaluation version limitation." Markdown and HTML5 exports are truncated the same way. The text that your code writes is saved in full.

[Evaluate Aspose.Slides](/slides/nodejs-net/evaluate-aspose-slides/) describes both limitations in detail and includes a script that shows them.

{{% alert color="success" title="Tip" %}}

To test Aspose.Slides without the evaluation limitations, request a free **30-day temporary license**. See [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for details.

{{% /alert %}}

## **About the License**

The license is a plain-text XML file that contains details such as the product name, the number of developers it is licensed to, and the subscription expiry date. The file is digitally signed, so do not modify it: even an extra line break added by mistake invalidates it.

## **Apply a License**

Apply the license with the `setLicense` method of the `License` class. Call it once per process, before you create any `Presentation` object. Calling it again does no harm, but it repeats work that is already done.

The following script applies a license from a file named `Aspose.Slides.lic`. Replace the name with the name or full path of your license file; the file can have any name.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

A file name or relative path is resolved against the current folder, the one you run `node` from. Keep the license file in your project folder and run your scripts from there, or pass the full path.

If the file cannot be found, or is not a valid license, `setLicense` throws an error, and Aspose.Slides stays in evaluation mode. The script catches the error and prints its message. For a missing file, the message begins with `License "Aspose.Slides.lic" doesn't exist or access is restricted.` and lists every location that was searched.

In this package, a license is applied from a file only. `License` does not accept a stream, and the package does not expose metered licensing. For the class that the package wraps, see [License](https://reference.aspose.com/slides/net/aspose.slides/license/) in the Aspose.Slides for .NET API reference.
