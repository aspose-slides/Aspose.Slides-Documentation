---
title: Section
type: docs
weight: 90
url: /python-java/examples/elements/section/
keywords:
- code example
- section
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Manage presentation sections in Aspose.Slides for Python via Java: add, access, remove, and rename sections with Python code examples."
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for Python via Java**.

Install the package as described in [Installation](/slides/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

## **Add a Section**

Create a section that starts at a specific slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Specify the slide that marks the beginning of the section.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Access a Section**

Read section information from a presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Access a section by index.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Remove a Section**

Delete a previously added section.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Remove the first section.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Rename a Section**

Change the name of an existing section.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```
