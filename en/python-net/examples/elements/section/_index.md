---
title: Section
type: docs
weight: 90
url: /python-net/examples/elements/section/
keywords:
- section
- slide section
- add section
- access section
- remove section
- rename section
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Manage slide sections in Python with Aspose.Slides: create, rename, reorder easily, move slides between sections, and control visibility for PPT, PPTX and ODP."
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for Python via .NET**.

## **Add a Section**

Create a section that starts at a specific slide.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Add a new section and specify the slide that marks the beginning of the section.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Section**

Get a section from a presentation.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Access a section by index.
        section = presentation.sections[0]
```

## **Remove a Section**

Delete a previously added section.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Remove the section.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Rename a Section**

Change the name of an existing section.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Rename the section.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```
