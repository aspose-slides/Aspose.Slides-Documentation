---
title: Manage Presentation Notes in Python
linktitle: Presentation Notes
type: docs
weight: 110
url: /python-net/presentation-notes/
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
- Python
- Aspose.Slides
description: "Remove slide notes and customize master notes text styles in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET."
---

## **Overview**

Aspose.Slides for Python via .NET lets you remove notes from individual slides or an entire presentation, customize the text style defined in the master notes slide, and remove notes and handout masters. This article shows how to perform these operations and save the updated presentation.

To read or change notes page dimensions, switch orientation, and check export behavior, see [Notes Page Size](/slides/python-net/notes-size/).

## **Remove Notes from a Slide**

To remove notes from a specific slide, use its [notes_slide_manager](https://reference.aspose.com/slides/python-net/aspose.slides/slide/notes_slide_manager/) and call [remove_notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/remove_notes_slide/). The example loads a presentation containing at least one slide and removes the notes from the first slide, accessed at index zero. Notes on other slides remain unchanged, and the updated presentation is saved in PPTX format.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_manager = presentation.slides[0].notes_slide_manager
    notes_manager.remove_notes_slide()

    presentation.save("presentation_without_first_slide_notes.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Notes from All Slides**

To remove all slide notes, iterate through the presentation's [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collection and call [remove_notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/remove_notes_slide/) for each slide. This example processes every slide in an existing presentation and saves a PPTX copy without slide notes.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        slide.notes_slide_manager.remove_notes_slide()

    presentation.save("presentation_without_notes.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Notes and Handout Masters**

Notes and handout masters define shared formatting and placeholders for their respective page types. Removing a master is a separate operation from removing an individual slide's notes with [remove_notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/remove_notes_slide/).

### **Remove an Unused Notes Master**

When cleaning up a template that has no notes pages, you can remove its unused notes master. Access [master_notes_slide_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_notes_slide_manager/), check [master_notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslidemanager/master_notes_slide/), and call [remove_master_notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslidemanager/remove_master_notes_slide/).

The following example requires a presentation to contain no notes pages. It removes the notes master if one exists, including its formatting and header/footer placeholders, and saves the template.

```python
import aspose.slides as slides

with slides.Presentation("template_without_notes.pptx") as presentation:
    manager = presentation.master_notes_slide_manager
    if manager.master_notes_slide is not None:
        manager.remove_master_notes_slide()

    presentation.save("template_without_notes_master.pptx", slides.export.SaveFormat.PPTX)
```

After removal, [master_notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslidemanager/master_notes_slide/) returns `None`. If the master is already absent, the example skips removal and still saves the presentation.

### **Remove a Handout Master**

To remove a handout master, access [master_handout_slide_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_handout_slide_manager/), check [master_handout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/), and call [remove_master_handout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterhandoutslidemanager/remove_master_handout_slide/).

For this example, use a presentation containing slide notes and customized notes and handout masters. Give the handout master a visible banner and header/footer text so that the effect of removal is easy to compare in handout output.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_custom_masters.pptx") as presentation:
    manager = presentation.master_handout_slide_manager
    if manager.master_handout_slide is not None:
        manager.remove_master_handout_slide()

    presentation.save("presentation_without_handout_master.pptx", slides.export.SaveFormat.PPTX)
```

After removal, [master_handout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) returns `None`. Existing slide notes and the notes master remain unchanged. If the handout master is already absent, the example simply saves the presentation.

In handout output, the removed master's banner, formatting, and header, footer, date/time, and page-number placeholders no longer appear. The presentation slides still appear in the handout layout, including any footer or date text on the slides themselves. Slide numbers added by the handout export settings are separate from the master's page-number placeholder.

If you only want to hide handout headers or footers, change the corresponding placeholder visibility through the [handout master's header/footer manager](/slides/python-net/presentation-header-and-footer/#set-headers-and-footers-on-the-handout-master) instead. This keeps the master and its other formatting, such as a custom banner.

## **Add a Notes Style**

The [notes_style](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/notes_style/) property of [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) defines the master notes text style. The example accesses the existing [master_notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslidemanager/master_notes_slide/) and uses [get_level](https://reference.aspose.com/slides/python-net/aspose.slides/textstyle/get_level/) with index zero to select the first paragraph level. It sets the bullet type to [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) and saves the presentation in PPTX format. The input must contain a master notes slide for the style change to take effect; otherwise, the presentation is saved without changing the notes style.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_style = notes_master.notes_style
        paragraph_format = notes_style.get_level(0)
        paragraph_format.bullet.type = slides.BulletType.SYMBOL

    presentation.save("presentation_with_notes_style.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Which API provides access to the notes of a specific slide?**

Use the slide's [notes_slide_manager](https://reference.aspose.com/slides/python-net/aspose.slides/slide/notes_slide_manager/) property. The manager's [notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) property returns the notes slide, or `None` if the slide has no notes.

**Does working with notes require Microsoft PowerPoint to be installed?**

No. Aspose.Slides works with notes in PowerPoint and OpenDocument presentations without requiring Microsoft PowerPoint to be installed.
