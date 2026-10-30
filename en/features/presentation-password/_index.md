---
title: Protect a presentation with a password
description: Require a password to open a presentation.
type: docs
url: /features/presentation-password/
weight: 1300
feature_id: presentation-password
feature_group: security
translationKey: slides-feature-presentation-password
feature_catalogue_version: 3
feature_guides:
- /slides/net/password-protected-presentation/
---

## **Overview**

Encrypt a presentation before saving it so opening the file requires a password. Your application chooses the password and supplies it again when loading the protected file. Use this when the presentation's contents should not be accessible merely by opening the document.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Create an encrypted copy with a dummy demonstration password. The in-memory deck is saved only to a new file; use a real secret supplied by your application in production.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
presentation.ProtectionManager.Encrypt("demo-open-123");
presentation.Save("protected.pptx", SaveFormat.Pptx);
using var opened = new Presentation("protected.pptx", new LoadOptions { Password = "demo-open-123" });
Console.WriteLine(opened.Slides.Count);
```

## **FAQ**

### **Is an opening password the same as write protection?**

No. An opening password protects access to the file's contents. Write protection is a separate setting for editing behavior.

### **Can I save an encrypted copy while leaving the source presentation unchanged?**

Yes. Save the encrypted deck to a different path so the original file is retained.

### **Can I remove encryption after opening with the correct password?**

Yes. Open it with the correct password, remove encryption and save a new copy.

## **Guides**

- [Password-Protect Presentations in .NET](/slides/net/password-protected-presentation/)

Related feature: [Set a password for editing](/slides/features/write-protection/).

## Runnable .NET examples

- [Open and Encrypt Presentations](/slides/net/examples/protection-signatures/passwords/)
