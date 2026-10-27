---
title: Highlight text with regular expressions
description: Highlight text that matches a regular expression.
type: docs
url: /features/regex-highlighting/
weight: 870
feature_id: regex-highlighting
feature_group: text
translationKey: slides-feature-regex-highlighting
feature_catalogue_version: 3
feature_guides:
- /slides/net/search-and-replace-text/
---

## **Overview**

Find matching text with a regular expression and apply highlighting. This can mark identifiers, dates or other patterns in slide text, tables and grouped shapes. Choose presentation-level or individual text-frame operations according to the content your application needs to reach.

## **Usage example**

This C# example highlights identifiers matching `ID-` followed by three digits in slide text and a table. It handles the notes text frame explicitly with the same expression. It saves `regex-highlighting.pptx`; the PNG previews slide text and the table, while the notes remain in the presentation.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Text.RegularExpressions;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 580, 100);
shape.AddTextFrame("ID-123 matches; CODE-456 stays unchanged");
var table = slide.Shapes.AddTable(40, 170, new double[] { 300 }, new double[] { 60 });
table[0, 0].TextFrame.Text = "ID-234 in a table";
var notes = slide.NotesSlideManager.AddNotesSlide();
var notesShape = notes.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 100);
notesShape.AddTextFrame("ID-345 in notes; CODE-567 stays unchanged");
shape.FillFormat.FillType = FillType.NoFill;
notesShape.FillFormat.FillType = FillType.NoFill;
table[0, 0].CellFormat.FillFormat.FillType = FillType.Solid;
table[0, 0].CellFormat.FillFormat.SolidFillColor.Color = Color.White;
foreach (var frame in new[] { shape.TextFrame, table[0, 0].TextFrame, notesShape.TextFrame })
{
    foreach (var paragraph in frame.Paragraphs)
    {
        paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    }
}
var pattern = new Regex(@"\bID-\d{3}\b");
presentation.HighlightRegex(pattern, Color.Yellow, null);
notesShape.TextFrame.HighlightRegex(pattern, Color.Yellow, null);
presentation.Save("regex-highlighting.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("regex-highlighting.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Does a presentation-wide regex pass include notes?**

Handle notes text frames explicitly. Options available on text-frame operations differ from the presentation-wide regex operation.

### **How can I control case sensitivity for a text-frame regex search?**

Supply regex options, such as case-insensitive matching, when constructing the regular expression. For string-pattern text-frame overloads, use the text-highlighting options supported by that overload.

### **Can I use text-frame highlighting options without changing the matched characters?**

Yes. Highlighting changes formatting rather than the matched characters. Text-frame operations provide their own overloads and options; choose the one matching your required search behavior.

## **Guides**

- [Search and Replace Text in PowerPoint Presentations in .NET](/slides/net/search-and-replace-text/)

Related feature: [Find and replace text](/slides/features/find-replace-text/).
