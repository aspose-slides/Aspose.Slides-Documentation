---
title: Read and edit document properties
description: Read and update title, author and other built-in metadata.
type: docs
url: /features/document-properties/
weight: 1410
feature_id: document-properties
feature_group: metadata
translationKey: slides-feature-document-properties
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-properties/
---

## **Overview**

Work with built-in presentation properties such as title, subject, author, keywords and category. These values help applications organize documents or prepare generated reports with consistent metadata. Some properties are managed by the writer or require the document-information workflow.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Set nonpersonal built-in metadata on a new deck. The values are stored in source.pptx and can be read again after opening it.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
presentation.DocumentProperties.Title = "Demo report";
presentation.DocumentProperties.Author = "Example team";
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Where should I store an application-specific field?**

Use a custom document property when the value does not correspond to one of the built-in fields.

### **Can I read properties without opening every slide?**

Yes. Use the presentation-information workflow to read document properties without loading the complete slide model.

### **Which built-in properties should I update when generating a new deck?**

Set fields relevant to the document, such as title, subject, author and keywords. Avoid carrying over stale metadata from a template.

## **Guides**

- [Manage Presentation Properties in .NET](/slides/net/presentation-properties/)

Related feature: [Add custom document properties](/slides/features/custom-properties/).
