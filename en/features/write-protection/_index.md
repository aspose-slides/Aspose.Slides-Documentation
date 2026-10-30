---
title: Set a password for editing
description: Set or remove password-based write protection.
type: docs
url: /features/write-protection/
weight: 1310
feature_id: write-protection
feature_group: security
translationKey: slides-feature-write-protection
feature_catalogue_version: 3
feature_guides:
- /slides/net/write-protected-presentation/
---

## **Overview**

Apply write protection when a presentation should open for reading but require a password for the protected editing workflow. Your application can inspect the protection, check a supplied password and remove the protection when appropriate.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Set a dummy editing password, save the file, then check that password on the reopened presentation. The deck remains readable without an opening password.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
presentation.ProtectionManager.SetWriteProtection("demo-edit-123");
presentation.Save("source.pptx", SaveFormat.Pptx);
using var opened = new Presentation("source.pptx");
Console.WriteLine(opened.ProtectionManager.CheckWriteProtection("demo-edit-123"));
```

## **FAQ**

### **Does write protection encrypt the presentation contents?**

No. The file can still open for reading. Use an opening password when the document itself needs encryption.

### **How can I check whether a supplied write-protection password is correct?**

Use the password-check operation on the protection manager; a protected-state flag alone does not verify a supplied password.

### **How can I remove write protection with the correct password?**

After checking the password in your application, remove write protection and save the result. Removing this setting does not decrypt a file.

## **Guides**

- [Write-Protect Presentations in .NET](/slides/net/write-protected-presentation/)

Related feature: [Protect a presentation with a password](/slides/features/presentation-password/).

## Runnable .NET examples

- [Set Editing Protection](/slides/net/examples/protection-signatures/write-protection/)
