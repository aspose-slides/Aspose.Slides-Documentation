---
title: Read and change slide properties
description: Read slide identities and set names, numbering and footer details.
type: docs
url: /features/slide-properties/
weight: 530
feature_id: slide-properties
feature_group: slides
translationKey: slides-feature-slide-properties
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-slide/
- /slides/net/presentation-header-and-footer/
---

## **Overview**

Access slide properties while assembling or inspecting a presentation. Give slides useful names, work with slide identities and numbers, and control footer, date or slide-number visibility. These settings help applications organize slides and apply consistent presentation details.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example gives the first slide a useful internal name and enables a footer and slide number. The name identifies the slide in application code; the footer is visible slide content.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.Name = "Quarterly summary";
slide.HeaderFooterManager.SetFooterVisibility(true);
slide.HeaderFooterManager.SetFooterText("Internal review");
slide.HeaderFooterManager.SetSlideNumberVisibility(true);
presentation.Save("slide-properties.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Is a slide's position the same as its identity?**

No. A slide can move to a different position while retaining its identity. Use the appropriate property for your application's tracking needs.

### **Is a slide name the same as its title text?**

No. A slide name is an identifying property. The visible title is text in a slide shape, often a title placeholder; changing one does not automatically replace the other.

### **How do slide-level footer settings interact with the master?**

Use a slide-level manager for a local change. Master and layout managers can propagate settings to their dependent slides, so choose the scope deliberately and apply local adjustments after shared updates.

## **Guides**

- [Manage Presentation Slides in .NET](/slides/net/presentation-slide/)
- [Manage Presentation Headers and Footers in .NET](/slides/net/presentation-header-and-footer/)

Related feature: [Add, remove and reorder slides](/slides/features/manage-slides/).
