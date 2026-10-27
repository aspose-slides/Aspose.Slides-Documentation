---
title: Open password-protected presentations
description: Open encrypted presentations with a supplied password.
type: docs
url: /features/open-protected-presentations/
weight: 1360
feature_id: open-protected-presentations
feature_group: security
translationKey: slides-feature-open-protected-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/password-protected-presentation/
---

## **Overview**

Supply the correct password when loading a protected presentation, then work with its slides and content. You can keep encryption for the output or remove it before saving when your workflow calls for an unencrypted copy. Password checks are also available through presentation information.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Generate a harmless encrypted input, then open it with a dummy password passed in the load options. The printed count is 1.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
presentation.ProtectionManager.Encrypt("demo-open-123");
presentation.Save("protected.pptx", SaveFormat.Pptx);
var options = new LoadOptions { Password = "demo-open-123" };
using var opened = new Presentation("protected.pptx", options);
Console.WriteLine(opened.Slides.Count);
```

## **FAQ**

### **Does removing encryption change the original file immediately?**

No. Save the result to write the change. Use another output path when the encrypted source should remain unchanged.

### **Where do I supply the opening password?**

Supply it through the password setting on the load options used when opening the file.

### **Can I inspect whether a file is encrypted before opening it?**

Yes. Presentation information exposes whether the input is encrypted; it does not recover the password.

## **Guides**

- [Password-Protect Presentations in .NET](/slides/net/password-protected-presentation/)

Related feature: [Protect a presentation with a password](/slides/features/presentation-password/).
