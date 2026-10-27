---
title: Recommend opening a presentation as read-only
description: Suggest that a presentation be opened as read-only.
type: docs
url: /features/read-only-recommendation/
weight: 1320
feature_id: read-only-recommendation
feature_group: security
translationKey: slides-feature-read-only-recommendation
feature_catalogue_version: 3
feature_guides:
- /slides/net/read-only-presentation/
---

## **Overview**

Set the read-only recommendation flag to ask readers to avoid editing the original presentation. The flag can be read, changed and preserved when the file is saved. It is useful for a review copy where an editing prompt is enough.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Save a generated review deck with the read-only recommendation enabled. This is a presentation setting, so the example reopens the output and prints True.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
presentation.ProtectionManager.ReadOnlyRecommended = true;
presentation.Save("source.pptx", SaveFormat.Pptx);
using var opened = new Presentation("source.pptx");
Console.WriteLine(opened.ProtectionManager.ReadOnlyRecommended);
```

## **FAQ**

### **Does this prevent someone from changing the file?**

It is a recommendation, not encryption or a password requirement. Choose a protection mechanism appropriate to the intended behavior.

### **Can I clear the read-only recommendation on a loaded presentation?**

Yes. Clear the recommendation flag and save the updated deck.

### **Can I combine the recommendation with password protection?**

Yes. The recommendation and password settings serve different purposes; a recommendation alone does not require a password.

## **Guides**

- [Save Presentations in Read-Only Mode in .NET](/slides/net/read-only-presentation/)

Related feature: [Set a password for editing](/slides/features/write-protection/).
