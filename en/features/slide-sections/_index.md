---
title: Organize slides into sections
description: Group slides into named sections and rearrange them together.
type: docs
url: /features/slide-sections/
weight: 440
feature_id: slide-sections
feature_group: slides
translationKey: slides-feature-slide-sections
feature_catalogue_version: 3
feature_guides:
- /slides/net/slide-section/
---

## **Overview**

Use sections to organize a presentation into parts such as an introduction, results and appendix. Create or read section names, associate slides with sections, and move a section together with its slides. Sections help keep larger decks organized as content changes.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates four named slides and two sections. Each section starts at a specific slide and includes the following slides up to the next section. The saved PPTX keeps Introduction on slides 1–2 and Results on slides 3–4.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides[0].Name = "Opening";
for (var i = 1; i < 4; i++)
{
    var slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    slide.Name = "Page " + (i + 1);
}
presentation.Sections.AddSection("Introduction", presentation.Slides[0]);
presentation.Sections.AddSection("Results", presentation.Slides[2]);
presentation.Save("slide-sections.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can a section move with its slides?**

Yes. Use the section-reordering workflow when you want to move the group rather than rearrange each slide separately.

### **What happens to a section when its slides are removed?**

Removing only a section definition retains its slides; removing a section together with its slides deletes both. After editing slides, query the section again rather than assuming its old range still applies.

### **How do I identify the first slide in a section?**

Read the section’s starting slide. An empty section has no starting slide, so check for that case before reading slide properties.

## **Guides**

- [Manage Slide Sections in Presentations in .NET](/slides/net/slide-section/)

Related feature: [Add, remove and reorder slides](/slides/features/manage-slides/).
