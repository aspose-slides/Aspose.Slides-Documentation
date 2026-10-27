---
title: Export presentations to Markdown
description: Export presentation text, tables and lists to Markdown.
type: docs
url: /features/markdown-export/
weight: 140
feature_id: markdown-export
feature_group: formats
translationKey: slides-feature-markdown-export
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-markdown/
---

## **Overview**

Save a presentation as Markdown for a text-based workflow. The output can contain slide separators, headings, tables and lists. Use the Markdown save options to control the export, then keep the original presentation when you also need its visual design.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates a title, a two-cell table and an explicitly formatted bullet, then exports *slides.md* using GitHub-style Markdown. Speaker notes are kept in *source.pptx* but are not exported by this workflow.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Stock";
var table = slide.Shapes.AddTable(40, 120, new double[] { 200, 100 }, new double[] { 50 });
table[0, 0].TextFrame.Text = "Pens";
table[1, 0].TextFrame.Text = "12";
var list = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 220, 500, 80);
list.TextFrame.Text = "Order";
var paragraph = list.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
paragraph.ParagraphFormat.Bullet.Char = '•';
var notes = slide.NotesSlideManager.AddNotesSlide();
notes.NotesTextFrame.Text = "Hidden notes marker";
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.Github,
    ExportType = MarkdownExportType.TextOnly,
    ShowSlideNumber = true,
    SlideNumberFormat = "## Slide {0}"
};
presentation.Save("source.pptx", SaveFormat.Pptx);
presentation.Save("slides.md", SaveFormat.Md, options);
```

## **FAQ**

### **Are speaker notes included in the Markdown output?**

No. Read speaker notes separately when you need them. Lists whose bullets come from a master or layout may also need attention in the exported Markdown.

### **How can I control slide separators in Markdown?**

Enable slide-number headings and select their heading format in the Markdown save options. The exporter also writes slide separators; inspect the generated Markdown before post-processing it.

### **What happens to bullets inherited from a layout?**

Inherited bullet settings may not export as an explicit Markdown list. Set the paragraph’s bullet formatting explicitly when list structure matters, and inspect the exported Markdown.

## **Guides**

- [Convert PowerPoint Presentations to Markdown in .NET](/slides/net/convert-powerpoint-to-markdown/)

Related feature: [Extract text from presentations](/slides/features/extract-text/).
