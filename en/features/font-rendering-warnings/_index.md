---
title: Handle font substitution warnings while rendering
description: Receive reports when rendering substitutes a missing font.
type: docs
url: /features/font-rendering-warnings/
weight: 1250
feature_id: font-rendering-warnings
feature_group: rendering
translationKey: slides-feature-font-rendering-warnings
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-warnings/
---

## **Overview**

Attach a rendering warning callback to receive information about reported font substitutions. The message can name the original font and the replacement choices, allowing your application to record what happened or decide how to continue.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Use a deliberately nonexistent font name so the renderer reports substitution. Attach the callback to the PDF export itself; a load callback has a different lifetime. The PDF is still written when the callback continues.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("CatalogueMissingFont");
var warnings = new FontWarnings();
var options = new PdfOptions { WarningCallback = warnings };
presentation.Save("output.pdf", SaveFormat.Pdf, options);
presentation.Save("source.pptx", SaveFormat.Pptx);
Console.WriteLine("Reported warnings: " + warnings.Count);
class FontWarnings : IWarningCallback
{
    public int Count { get; private set; }
    public ReturnAction Warning(IWarningInfo warning)
    {
        Count++;
        Console.WriteLine(warning.WarningType + ": " + warning.Description);
        return ReturnAction.Continue;
    }
}
```

## **FAQ**

### **Does this report every change made during rendering?**

No. Do not treat the callback as a complete list of omitted media, objects or effects. It reports the warnings exposed by that rendering path.

### **When should I register the warning callback?**

Attach it to the options for the operation you want to observe, before that operation starts. A callback used while loading does not automatically cover later exports.

### **Can a callback choose to abort processing after a warning?**

Yes. A callback can return the abort action. Treat any resulting partial file as unusable and remove it according to your application policy.

## **Guides**

- [Handle Presentation Warnings in .NET](/slides/net/presentation-warnings/)

Related feature: [Record export and rendering warnings](/slides/features/export-warning-log/).
