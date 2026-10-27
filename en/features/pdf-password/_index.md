---
title: Protect PDF output with a password
description: Set a password and access permissions for PDF output.
type: docs
url: /features/pdf-password/
weight: 1350
feature_id: pdf-password
feature_group: security
translationKey: slides-feature-pdf-password
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-pdf/
---

## **Overview**

Protect an exported PDF with a password and choose the access-permission settings associated with that encryption. Configure these options as part of saving the presentation to PDF, so the generated document carries the selected protection.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Export a PDF with a dummy opening password and printing permission. Copying is not granted by this permission mask. Reader enforcement varies; use your own secret in production.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
var options = new PdfOptions
{
    Password = "demo-pdf-123",
    AccessPermissions = PdfAccessPermissions.PrintDocument
};
presentation.Save("output.pdf", SaveFormat.Pdf, options);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I restrict printing while leaving the opening password empty?**

This export workflow requires a password for the permissions to take effect. It does not provide a separate permissions-only password mode.

### **How do I set PDF printing and copying permissions?**

Choose the access-permission flags on the PDF export options together with a nonempty password. These flags describe allowed reader actions.

### **Does this export setting let me choose the encryption algorithm?**

No. This export setting exposes a password and permission flags, not a selectable encryption algorithm.

## **Guides**

- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](/slides/net/convert-powerpoint-to-pdf/)

Related feature: [Export presentations to PDF](/slides/features/pdf-export/).
