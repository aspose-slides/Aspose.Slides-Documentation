---
title: Add custom document properties
description: Store named text, number, date and Boolean properties in a presentation.
type: docs
url: /features/custom-properties/
weight: 1420
feature_id: custom-properties
feature_group: metadata
translationKey: slides-feature-custom-properties
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-properties/
---

## **Overview**

Add application-specific metadata as custom name/value properties. You can list the properties, read their values, update them or remove ones that are no longer needed. Typed values help keep a document identifier, report date or workflow flag with the file.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Store a string, number, date and Boolean as named metadata. Remove a temporary field before saving, leaving the four typed fields in source.pptx.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
var properties = presentation.DocumentProperties;
properties["ReportId"] = "Demo-42";
properties["Amount"] = 12.5;
properties["ReportDate"] = new DateTime(2026, 1, 15);
properties["Reviewed"] = true;
properties["Temporary"] = "discard";
properties.RemoveCustomProperty("Temporary");
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Is this suitable for a larger structured XML payload?**

For structured XML, use custom XML parts. Custom properties are a simpler choice for individual named values.

### **Which value types can custom properties hold?**

Custom properties can hold supported scalar values such as text, numbers, dates and Boolean flags.

### **How can I check whether a property exists before adding it?**

Check the custom-property names before setting a value; assigning a name that already exists updates its value.

## **Guides**

- [Manage Presentation Properties in .NET](/slides/net/presentation-properties/)

Related feature: [Work with custom XML parts](/slides/features/custom-xml/).
