---
title: Find and replace text
description: Find text in slides, masters and tables and replace it.
type: docs
url: /features/find-replace-text/
weight: 220
feature_id: find-replace-text
feature_group: operations
translationKey: slides-feature-find-replace-text
feature_catalogue_version: 3
feature_guides:
- /slides/net/search-and-replace-text/
---

## **Overview**

Update repeated text such as a report period or product name across a presentation. The find-and-replace operation can reach slide text, master content and table cells. Use it for targeted substitutions while keeping the surrounding presentation structure.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It places *Draft* in a slide shape, table cell, master shape and notes. The presentation pass changes slide and table text to *Final*. An explicit pass over master text shapes updates the master; notes are handled separately and keep *Draft*.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
title.TextFrame.Text = "Draft";
var table = slide.Shapes.AddTable(40, 160, new double[] { 240 }, new double[] { 60 });
table[0, 0].TextFrame.Text = "Draft";
var masterText = presentation.Masters[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 300, 500, 80);
masterText.TextFrame.Text = "Draft";
var notes = slide.NotesSlideManager.AddNotesSlide();
notes.NotesTextFrame.Text = "Draft";
var options = new TextSearchOptions { CaseSensitive = true, WholeWordsOnly = true };
presentation.ReplaceText("Draft", "Final", options, null);
foreach (var master in presentation.Masters)
{
    foreach (var shape in master.Shapes)
    {
        if (shape is IAutoShape textShape)
            textShape.TextFrame.ReplaceText("Draft", "Final", options, null);
    }
}
presentation.Save("replaced.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does one replacement pass include speaker notes?**

Handle notes separately. A match spanning differently formatted text portions can also change the replacement's formatting, so choose the replacement style deliberately.

### **Can I restrict replacement to one text frame?**

Yes. Apply replacement to the chosen text frame instead of the entire presentation. That lets you target one shape or table cell.

### **How do I control formatting when a match spans text portions?**

Review the match’s text portions and deliberately set the replacement formatting. A match spanning portions with different styles may not retain every original style; see the [replacement guide](/slides/net/search-and-replace-text/).

## **Guides**

- [Search and Replace Text in PowerPoint Presentations in .NET](/slides/net/search-and-replace-text/)

Related feature: [Format text within slides](/slides/features/text-formatting/).
