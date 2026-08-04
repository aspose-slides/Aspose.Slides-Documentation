---
title: HeaderFooter
type: docs
weight: 220
url: /python-net/examples/elements/header-footer/
keywords:
- header footer
- add header footer
- update header footer
- set date and time
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Control headers and footers in Python with Aspose.Slides: add or edit date/time, slide numbers, and footer text, show or hide placeholders across PPT, PPTX and ODP."
---

Shows how to add footers and update date and time placeholders using **Aspose.Slides for Python via .NET**.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

```py
import aspose.slides as slides

def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Make the footer placeholder visible first, then set its text.
        slide.header_footer_manager.set_footer_visibility(True)
        slide.header_footer_manager.set_footer_text("My footer")

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Update Date and Time**

Modify the date and time placeholder on a slide.

```py
import aspose.slides as slides

def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Make the date and time placeholder visible first, then set its text.
        slide.header_footer_manager.set_date_time_visibility(True)
        slide.header_footer_manager.set_date_time_text("01/01/2024")

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```
