---
title: Manage Presentation Notes in .NET
linktitle: Presentation Notes
type: docs
weight: 110
url: /net/presentation-notes/
keywords:
- notes
- notes slide
- add notes
- remove notes
- notes style
- master notes
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Remove slide notes and customize master notes text styles in PowerPoint and OpenDocument presentations with Aspose.Slides for .NET."
---

## **Overview**

Aspose.Slides for .NET lets you remove notes from individual slides or an entire presentation, customize the text style defined in the master notes slide, and remove notes and handout masters. This article shows how to perform these operations and save the updated presentation.

To read or change notes page dimensions, switch orientation, and check export behavior, see [Notes Page Size](/slides/net/notes-size/).

## **Remove Notes from a Slide**

To remove notes from a specific slide, use its [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/slide/notesslidemanager/) and call [RemoveNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/removenotesslide/). The example loads a presentation containing at least one slide and removes the notes from the first slide, accessed at index zero. Notes on other slides remain unchanged, and the updated presentation is saved in PPTX format.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesManager = presentation.Slides[0].NotesSlideManager;
notesManager.RemoveNotesSlide();

presentation.Save("presentation_without_first_slide_notes.pptx", SaveFormat.Pptx);
```

## **Remove Notes from All Slides**

To remove all slide notes, iterate through the presentation's [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection and call [RemoveNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/removenotesslide/) for each slide. This example processes every slide in an existing presentation and saves a PPTX copy without slide notes.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    slide.NotesSlideManager.RemoveNotesSlide();
}

presentation.Save("presentation_without_notes.pptx", SaveFormat.Pptx);
```

## **Remove Notes and Handout Masters**

Notes and handout masters define shared formatting and placeholders for their respective page types. Removing a master is a separate operation from removing an individual slide's notes with [RemoveNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/removenotesslide/).

### **Remove an Unused Notes Master**

When cleaning up a template that has no notes pages, you can remove its unused notes master. Access [MasterNotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/masternotesslidemanager/), check [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslidemanager/masternotesslide/), and call [RemoveMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslidemanager/removemasternotesslide/).

The following example requires a presentation to contain no notes pages. It removes the notes master if one exists, including its formatting and header/footer placeholders, and saves the template.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template_without_notes.pptx");

var manager = presentation.MasterNotesSlideManager;
if (manager.MasterNotesSlide != null)
{
    manager.RemoveMasterNotesSlide();
}

presentation.Save("template_without_notes_master.pptx", SaveFormat.Pptx);
```

After removal, [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslidemanager/masternotesslide/) returns `null`. If the master is already absent, the example skips removal and still saves the presentation.

### **Remove a Handout Master**

To remove a handout master, access [MasterHandoutSlideManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/masterhandoutslidemanager/), check [MasterHandoutSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/), and call [RemoveMasterHandoutSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterhandoutslidemanager/removemasterhandoutslide/).

For this example, use a presentation containing slide notes and customized notes and handout masters. Give the handout master a visible banner and header/footer text so that the effect of removal is easy to compare in handout output.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_custom_masters.pptx");

var manager = presentation.MasterHandoutSlideManager;
if (manager.MasterHandoutSlide != null)
{
    manager.RemoveMasterHandoutSlide();
}

presentation.Save("presentation_without_handout_master.pptx", SaveFormat.Pptx);
```

After removal, [MasterHandoutSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) returns `null`. Existing slide notes and the notes master remain unchanged. If the handout master is already absent, the example simply saves the presentation.

In handout output, the removed master's banner, formatting, and header, footer, date/time, and page-number placeholders no longer appear. The presentation slides still appear in the handout layout, including any footer or date text on the slides themselves. Slide numbers added by the handout export settings are separate from the master's page-number placeholder.

If you only want to hide handout headers or footers, change the corresponding placeholder visibility through the [handout master's header/footer manager](/slides/net/presentation-header-and-footer/#set-headers-and-footers-on-the-handout-master) instead. This keeps the master and its other formatting, such as a custom banner.

## **Add a Notes Style**

The [NotesStyle](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide/notesstyle/) property of [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide/) defines the master notes text style. The example accesses the existing [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslidemanager/masternotesslide/) and uses [GetLevel](https://reference.aspose.com/slides/net/aspose.slides/textstyle/getlevel/) with index zero to select the first paragraph level. It sets the bullet type to [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) and saves the presentation in PPTX format. The input must contain a master notes slide for the style change to take effect; otherwise, the presentation is saved without changing the notes style.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    var notesStyle = notesMaster.NotesStyle;
    var paragraphFormat = notesStyle.GetLevel(0);
    paragraphFormat.Bullet.Type = BulletType.Symbol;
}

presentation.Save("presentation_with_notes_style.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Which API provides access to the notes of a specific slide?**

Use the slide's [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/slide/notesslidemanager/) property. The manager's [NotesSlide](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/) property returns the notes slide, or `null` if the slide has no notes.

**Does working with notes require Microsoft PowerPoint to be installed?**

No. Aspose.Slides works with notes in PowerPoint and OpenDocument presentations without requiring Microsoft PowerPoint to be installed.
