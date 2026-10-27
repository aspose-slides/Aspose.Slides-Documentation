---
title: Record export and rendering warnings
description: Collect warning messages from export and rendering operations.
type: docs
url: /features/export-warning-log/
weight: 1670
feature_id: export-warning-log
feature_group: warnings
translationKey: slides-feature-export-warning-log
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-warnings/
---

## **Overview**

Attach warning callbacks to the relevant export or rendering options and record the messages your application receives. Reports can include warning types and descriptions of issues such as font substitution or particular formatting losses. Use the callbacks as part of your processing log.

## **Usage example**

This C# example uses Aspose.Slides for .NET and creates *warning-input.pptx* with a deliberately unavailable font. Run it where *CatalogueMissingFont* is absent and at least one replacement font is installed. Separate callback instances label load and PDF warnings with the stage, type, and description. The policy records warnings and continues, producing *warnings.pdf*. The missing font can generate an export warning; a stage that encounters no reported issue prints nothing.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

using (var source = new Presentation())
{
    var shape = source.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 600, 100);
    shape.TextFrame.Text = "Warning log example";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("CatalogueMissingFont");
    source.Save("warning-input.pptx", SaveFormat.Pptx);
}
var loadOptions = new LoadOptions { WarningCallback = new StageWarningLog("load") };
using var presentation = new Presentation("warning-input.pptx", loadOptions);
var pdfOptions = new PdfOptions { WarningCallback = new StageWarningLog("pdf") };
presentation.Save("warnings.pdf", SaveFormat.Pdf, pdfOptions);

class StageWarningLog : IWarningCallback
{
    private readonly string stage;

    public StageWarningLog(string stage)
    {
        this.stage = stage;
    }

    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine($"[{stage}] {warning.WarningType}: {warning.Description}");
        return ReturnAction.Continue;
    }
}
```

## **FAQ**

### **Does one callback attached at load time cover later exports?**

Attach it to the options for the operation you need to observe. Coverage varies by output path, and a load callback does not automatically receive later save warnings.

### **How are warnings different from thrown exceptions?**

Warnings report recoverable conditions that the callback can accept or reject. Exceptions indicate that an operation cannot finish normally and need handling around that operation. Returning an abort action from the callback also terminates the operation through an exception.

### **How should I discard output when a warning policy aborts export?**

Write to a separate temporary output path. If the policy aborts, close any streams and delete that partial file; keep the source and any previous valid output. Promote the temporary file only after the operation succeeds and you reopen and validate the result.

## **Guides**

- [Handle Presentation Warnings in .NET](/slides/net/presentation-warnings/)

Related feature: [Handle font substitution warnings while rendering](/slides/features/font-rendering-warnings/).
