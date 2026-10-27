---
title: Use Slides from Python
description: Work with presentations from Python through a local Slides binding.
type: docs
url: /features/python-api/
weight: 370
feature_id: python-api
feature_group: languages
translationKey: slides-feature-python-api
feature_catalogue_version: 3
feature_guides:
- /slides/python-net/installation/
- /slides/python-java/installation/
---

## **Overview**

Use a Python binding to create, inspect, edit and export presentations from scripts or applications. The Python via .NET and Python via Java products use different underlying runtimes, so follow the installation and examples for the binding you choose.

## **Usage example**

This example uses **Aspose.Slides for Python via .NET**, installed in the Python environment running the script. It creates a text box on the first slide and saves *python-title.pptx* in the current directory. No presentation input or Java setup is needed. Follow [Python via .NET installation](/slides/python-net/installation/) for your operating system.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 80)
    shape.text_frame.text = "Hello from Python"
    presentation.save("python-title.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### **Can I mix examples from the two Python bindings?**

Use the guides for your selected binding. Their setup and API conventions differ even when they address the same presentation task.

### **Which Python binding does this example use?**

It uses Python via .NET and imports the commercial *aspose.slides* package. Use that binding's installation steps and API examples throughout this script.

### **How should I release presentation resources in Python via .NET?**

Use a context manager, as in the example, so presentation resources are released when the block exits, including after an error. Finish reading or updating presentation-owned objects inside that block; do not keep using them after disposal.

## **Guides**

- [Installation (Python via .NET)](/slides/python-net/installation/)
- [Installation (Python via Java)](/slides/python-java/installation/)
