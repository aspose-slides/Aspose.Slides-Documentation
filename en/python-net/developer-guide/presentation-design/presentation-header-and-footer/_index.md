---
title: Manage Presentation Headers and Footers with Python
linktitle: Header and Footer
type: docs
weight: 140
url: /python-net/presentation-header-and-footer/
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
- presentation
- Python
- Aspose.Slides
description: "Use Aspose.Slides for Python via .NET to add and customize headers and footers in PowerPoint and OpenDocument presentations for a professional look."
---

## **Overview**

Aspose.Slides for Python lets you control header and footer placeholders across a presentation with precise scope. Footer text, date/time, and slide numbers on slides are managed from the master level and can be applied globally or adjusted per slide. Headers are supported on notes and handouts, where you can toggle visibility and set text for header, footer, date/time, and page numbers through the dedicated header & footer manager on the master notes slide or individual notes slides. This article outlines the key patterns for updating these placeholders and propagating changes consistently throughout your deck.

## **Manage Header and Footer Text**

In this section, you’ll learn how to manage header and footer content in a presentation—enable or modify the footer, date and time, and slide numbers. We’ll briefly outline the scopes for applying these settings (the entire presentation, individual slides, and notes/handout views) and show how to use the Aspose.Slides API to update them quickly and consistently.

The code example below opens a presentation, enables and sets the footer text, updates the header text on the master notes slide, and saves the file.

```py
import aspose.slides as slides

# Function to set the header text.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # Set the footer.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Access and update the header.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Manage Header and Footer on Notes Slides**

In this section, you’ll learn how to manage headers and footers specifically for notes slides in Aspose.Slides. We’ll cover enabling the relevant placeholders, setting text for footers, date/time, and page numbers, and applying these changes consistently across the notes master and individual notes pages.

Follow the steps below:

1. Load a presentation file.
1. Get the master notes slide and its [header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
1. On the master notes slide, enable visibility of Header, Footer, Slide number, and Date-time for the master and all child notes slides.
1. On the master notes slide, set text for Header, Footer, and Date-time for the master and all child notes slides.
1. Get the notes slide for the first presentation slide and its [header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
1. For this first notes slide only, ensure Header, Footer, Slide number, and Date-time are visible (turn on any that are off).
1. For this first notes slide only, set the text for Header, Footer, and Date-time.
1. Save the presentation in PPTX format.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Make the master notes slide and all child header, footer, slide number, and date/time placeholders visible.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Set text on the master notes slide and all child header, footer, and date/time placeholders.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Change header, footer, slide number, and date/time settings for the first notes slide only.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Ensure the header, footer, slide number, and date/time placeholders are visible.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Set text on the notes slide header, footer, and date/time placeholders.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I add a "header" to regular slides?**

In PowerPoint, "Header" exists only for notes and handouts; on regular slides, the supported elements are the footer, date/time, and slide number. In Aspose.Slides this matches the same limitations: header only for Notes/Handout, and on slides—Footer/DateTime/SlideNumber.

**What if the layout doesn’t contain a footer area—can I "turn on" its visibility?**

Yes. Check the visibility via the header/footer manager and enable it if needed. These API indicators and methods are designed for cases when the placeholder is missing or hidden.

**How do I make the slide number start from a value other than 1?**

Set the presentation’s [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/); after that, all numbering is recalculated. For example, you can start at 0 or 10, and hide the number on the title slide.

**What happens to headers/footers when exporting to PDF/images/HTML?**

They are rendered as regular text elements of the presentation. That is, if the elements are visible on slides/notes pages, they will also appear in the output format along with the rest of the content.
