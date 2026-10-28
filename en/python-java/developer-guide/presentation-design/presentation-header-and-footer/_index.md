---
title: Manage Presentation Headers and Footers in Python via Java
linktitle: Header and Footer
type: docs
weight: 140
url: /python-java/presentation-header-and-footer/
keywords:
- header
- header text
- footer
- footer text
- set header
- set footer
- handout
- notes
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to manage footer, date-time, slide-number, and header placeholders on slides, notes pages, and handouts with Aspose.Slides for Python via Java."
---

## **Overview**

PowerPoint uses different header and footer placeholders depending on the page type. Aspose.Slides for Python via Java lets you control the text and visibility of these placeholders through header/footer manager classes.

The available placeholders depend on the scope:

| Scope | Header | Footer | Date/time | Slide/page number |
|---|---|---|---|---|
| Regular slide | No | Yes | Yes | Yes |
| Notes master | Yes | Yes | Yes | Yes |
| Notes slide | Yes | Yes | Yes | Yes |
| Handout master | Yes | Yes | Yes | Yes |

A regular presentation slide does not have a header placeholder. Headers are available on notes pages and handouts. For regular slides, use footer, date/time, and slide-number placeholders instead.

The scope of a change depends on the manager you use. The [SlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/slideheaderfootermanager/) class controls one regular slide. The [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/notesslideheaderfootermanager/) class controls one notes slide. Master and layout managers can also propagate settings to dependent slides, while the [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) class controls the handout master.

## **Update Header, Footer, and Date/Time Text Across a Presentation**

Use the [Presentation.getHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHeaderFooterManager) method to access [PresentationHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentationheaderfootermanager/) and apply consistent text across a presentation without updating each page or master individually.

| Method | Affected objects |
|---|---|
| [setAllHeadersText](https://reference.aspose.com/slides/python-java/aspose.slides/presentationheaderfootermanager/#setAllHeadersText) | Existing notes pages, notes master, and handout master |
| [setAllFootersText](https://reference.aspose.com/slides/python-java/aspose.slides/presentationheaderfootermanager/#setAllFootersText) | Regular slides, layouts, slide masters, existing notes pages, notes master, and handout master |
| [setAllDateTimesText](https://reference.aspose.com/slides/python-java/aspose.slides/presentationheaderfootermanager/#setAllDateTimesText) | Regular slides, layouts, slide masters, existing notes pages, notes master, and handout master |

Headers apply only to notes pages and handouts; regular slides do not support header placeholders. Handout settings are updated through the handout master.

Setting text does not make a placeholder visible. First use [setAllHeadersVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/presentationheaderfootermanager/#setAllHeadersVisibility), [setAllFootersVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/presentationheaderfootermanager/#setAllFootersVisibility), and [setAllDateTimesVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/presentationheaderfootermanager/#setAllDateTimesVisibility) to enable the corresponding placeholders, then set their text. These visibility methods have the same scope as the corresponding text methods.

The following example assumes that a presentation contains regular slides, notes pages, a notes master, and a handout master. It applies corporate text and a fixed date label, then saves the result.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    manager = presentation.getHeaderFooterManager()

    manager.setAllHeadersVisibility(True)
    manager.setAllFootersVisibility(True)
    manager.setAllDateTimesVisibility(True)

    manager.setAllHeadersText("Contoso")
    manager.setAllFootersText("Internal use only")
    manager.setAllDateTimesText("October 2026")

    presentation.save("updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The text methods skip missing placeholders. Enabling visibility first creates the required placeholders on existing pages and masters. Neither the text methods nor the visibility methods create missing notes pages, notes masters, or handout masters. The date/time text is a fixed label, not an automatically updating date/time field.

For narrower changes, see the examples for [regular slides](#set-footer-datetime-and-slide-numbers-on-regular-slides), the [notes master](#set-headers-and-footers-on-the-notes-master), an [individual notes page](#set-headers-and-footers-on-an-individual-notes-slide), and the [handout master](#set-headers-and-footers-on-the-handout-master). See [Presentation Notes](/slides/python-java/presentation-notes/) for removing notes and managing notes masters.

## **Set Footer, Date/Time, and Slide Numbers on Regular Slides**

For regular slides, the basic workflow is to access each slide's header/footer manager, set the footer and date/time text, enable the required placeholders, and save the presentation. Slide numbers are generated by the presentation, so you only need to control their visibility.

Use [setFooterText](https://reference.aspose.com/slides/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) and [setDateTimeText](https://reference.aspose.com/slides/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) to set text, and use [setFooterVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility), and [setSlideNumberVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) to show the corresponding placeholders.

The following end-to-end example applies the same footer, date/time text, and slide-number visibility to all regular slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

If you need to update only one slide, access that slide directly through the [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) method instead of iterating through the entire collection.

## **Set Headers and Footers on the Notes Master**

The notes master defines common formatting and placeholder behavior for notes pages. Use the [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/) class when you want to change only the notes master itself.

The following example sets header, footer, and date/time text on the notes master and makes all supported placeholders visible on that master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The `getMasterNotesSlide` method returns `None` when the presentation does not contain a notes master. To clean up a template without notes pages, see [Remove an Unused Notes Master](/slides/python-java/presentation-notes/#remove-an-unused-notes-master).

## **Apply Notes Master Settings to Child Notes Slides**

A notes master can apply header and footer settings to itself and to all dependent notes slides. Use the dedicated propagation methods on [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/) when the same settings should be applied across the notes hierarchy.

For example, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) and [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) update the notes master header and all child headers. Equivalent methods are available for footers, date/time, and slide numbers.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The propagation methods used above are [setFooterAndChildFootersText](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), and [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Set Headers and Footers on an Individual Notes Slide**

A notes slide belongs to a specific regular slide. Use its [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/notesslideheaderfootermanager/) class when you want to customize only that notes page.

The [addNotesSlide](https://reference.aspose.com/slides/python-java/aspose.slides/notesslidemanager/#addNotesSlide) method returns the notes slide for the current slide and creates one if it does not already exist. The following example configures the notes page associated with the first presentation slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

If you first propagate settings from the notes master and then change an individual notes slide, the later per-slide settings let you customize that notes page independently.

## **Set Headers and Footers on the Handout Master**

Handout pages use the handout master for their header, footer, date/time, and page-number placeholders. Unlike notes pages, handout settings are managed through the handout master rather than through individual handout slides.

Use the `getMasterHandoutSlide` method to access the handout master. If it is not present, call `setDefaultMasterHandoutSlide` to create the default handout master.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

To remove the entire handout master, including its formatting and placeholders, see [Remove a Handout Master](/slides/python-java/presentation-notes/#remove-a-handout-master). If you only need to hide a header or footer, change its visibility instead to preserve the master's other formatting.

## **Understand Scope and Inheritance**

Choose the header/footer manager that matches the scope you want to change:

- [PresentationHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentationheaderfootermanager/) updates supported placeholders throughout the presentation, as shown in the [presentation-wide example](#update-header-footer-and-datetime-text-across-a-presentation).

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/slideheaderfootermanager/) changes footer, date/time, and slide-number settings for one regular slide.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslideheaderfootermanager/) controls a layout slide and can propagate supported settings to dependent slides.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/masterslideheaderfootermanager/) controls a regular slide master and can propagate supported settings to dependent slides.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslideheaderfootermanager/) controls the notes master and can propagate settings to all dependent notes slides.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/notesslideheaderfootermanager/) changes one notes slide and supports a header placeholder in addition to footer, date/time, and slide number.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) changes the handout master and supports all four placeholder types.

Use propagation from a master or layout when the same setting should apply throughout its hierarchy. Use an individual slide or notes-slide manager when you need a local setting for one page.

## **FAQ**

**Can I add a header to a regular slide?**

No. PowerPoint does not define a header placeholder for regular slides. On regular slides, use the footer, date/time, and slide-number placeholders. Header placeholders are available on notes pages and handouts.

**What if a footer, date/time, or slide-number placeholder is not visible?**

Use the corresponding header/footer manager to check its visibility and enable it when needed. For example, [isFooterVisible](https://reference.aspose.com/slides/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) reports whether a footer placeholder is present, and [setFooterVisibility](https://reference.aspose.com/slides/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) changes its visibility.

**How do I start slide numbering from a value other than 1?**

Call the presentation's [setFirstSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#setFirstSlideNumber) method. The slide-number placeholders then use the updated numbering sequence.

**What happens to headers and footers when exporting to PDF, images, or HTML?**

Visible header and footer elements are rendered with the rest of the presentation content in the output format. Their appearance depends on the page type being exported and the corresponding placeholder visibility settings.
