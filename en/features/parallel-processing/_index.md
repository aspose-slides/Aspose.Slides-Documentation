---
title: Process separate presentations in parallel
description: Run independent presentation jobs on separate threads.
type: docs
url: /features/parallel-processing/
weight: 1570
feature_id: parallel-processing
feature_group: runtime
translationKey: slides-feature-parallel-processing
feature_catalogue_version: 3
feature_guides:
- /slides/net/multithreading/
---

## **Overview**

Process several presentations in parallel by giving each worker its own presentation instance. Your application controls scheduling, output paths and resource use. This is useful for a server that handles independent documents at the same time.

## **Usage example**

Create two input decks, then process them with at most two workers. Each worker opens its own presentation instance and writes unique PPTX/PDF filenames. North-output contains North processed and South-output contains South processed. This C# example uses Aspose.Slides for .NET; no input files are required. Initialize any required file-based licensing before starting workers. The worker limit is an application choice, not a shared-instance thread-safety guarantee.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;
using System.Threading.Tasks;

var names = new[] { "North", "South" };
foreach (var name in names)
{
    using var input = new Presentation();
    var shape = input.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 540, 100);
    shape.TextFrame.Text = name;
    input.Save(name + ".pptx", SaveFormat.Pptx);
}
// Apply your file-based license before starting workers when one is required.
var options = new ParallelOptions { MaxDegreeOfParallelism = 2 };
Parallel.ForEach(names, options, name =>
{
    using var presentation = new Presentation(name + ".pptx");
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    shape.TextFrame.Text = name + " processed";
    presentation.Save(name + "-output.pptx", SaveFormat.Pptx);
    presentation.Save(name + "-output.pdf", SaveFormat.Pdf);
});
Console.WriteLine("Processed North and South with separate presentation instances.");
```

## **FAQ**

### **Can several threads load, save or clone the same presentation instance?**

Do not share a presentation instance for those operations. Apply licensing outside concurrent work as well, since license setup is not thread-safe.

### **How should I limit worker count on a memory-constrained server?**

Choose a bounded worker count from measured peak memory and temporary-storage use for representative inputs. Two workers in this example is a starting choice, not a universal limit.

### **When should I initialize licensing relative to worker startup?**

Apply the required license during application startup before starting parallel work. Each worker should then own and dispose its own presentation instance.

## **Guides**

- [Multithreading in Aspose.Slides for .NET](/slides/net/multithreading/)

Related feature: [Process multiple presentations in a loop](/slides/features/process-multiple-files/).
