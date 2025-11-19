---
title: Manage VBA Projects in Presentations with Python
linktitle: Presentation via VBA
type: docs
weight: 250
url: /python-net/presentation-via-vba/
keywords:
- macro
- VBA
- VBA macro
- add macro
- remove macro
- extract macro
- add VBA
- remove VBA
- extract VBA
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Discover how to generate and manipulate PowerPoint and OpenDocument presentations via VBA with Aspose.Slides for Python via .NET to streamline your workflow."
---

## **Overview**

This article examines the key capabilities of Aspose.Slides for Python via .NET for working with macros in PowerPoint presentations. The library provides convenient tools for adding, removing, and extracting macros, which enables you to automate the creation and modification of presentations.

With Aspose.Slides, you can:

- Accelerate presentation development—the automation of routine tasks reduces the time needed to prepare materials.
- Ensure flexibility—the ability to manage macros allows you to tailor presentations to specific tasks and scenarios.
- Integrate data—simple integration with external data sources helps keep slide content up to date.
- Simplify maintenance—centralized macro management makes it easier to apply changes and update presentations.

The article goes on to present practical examples of how to use Aspose.Slides to work effectively with macros in PowerPoint.

The [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) namespace provides classes for working with macros and VBA code.

{{% alert title="Note" color="warning" %}}

When you convert a presentation that contains macros to another format (PDF, HTML, etc.), Aspose.Slides ignores the macros—they are not transferred to the output file.

When you add macros to a presentation or resave a presentation that contains macros, Aspose.Slides writes the macro bytes as-is.

Aspose.Slides **never** executes macros in a presentation.

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) class to create VBA projects (and project references) and to edit existing modules.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) constructor to add a new VBA project.
1. Add a module to the VBA project.
1. Set the module’s source code.
1. Add a reference to `<stdole>`.
1. Add a reference to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

The following Python code shows how to add a VBA macro from scratch to a presentation:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Create a new VBA project.
    presentation.vba_project = slides.vba.VbaProject()

    # Add an empty module to the VBA project.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Set the module source code.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Create a reference to <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Create a reference to Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Add the references to the VBA project.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Save the presentation.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

You may want to try the **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), a free web app for removing macros from PowerPoint, Excel, and Word documents.

{{% /alert %}}

## **Remove VBA Macros**

Using the [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) property of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation that contains the macro.
1. Access the macro module and remove it.
1. Save the modified presentation.

The following Python code shows how to remove a VBA macro:

```python
import aspose.slides as slides

# Load the presentation that contains the macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Access the VBA module.
    vba_module = presentation.vba_project.modules[0]

    # Remove the VBA module.
    presentation.vba_project.modules.remove(vba_module)

    # Save the presentation.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Extract VBA Macros**

Using the `modules` property in the [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) class, you can access all modules of a VBA project. The [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) class can be used to extract module properties such as the name and the code.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation that contains the macro.
1. Check whether the presentation contains a VBA project.
1. Loop through all modules in the VBA project to view the macros.

The following Python code shows how to extract VBA macros from a presentation:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Check Whether a VBA Project Is Password-Protected**

Using the [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) property, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load a presentation that contains a macro.
1. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
1. Check whether the VBA project is password-protected to view its properties.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**What happens to macros if I save the presentation as PPTX?**

Macros will be removed because PPTX does not support VBA. To keep macros, choose PPTM, PPSM, or POTM.

**Can Aspose.Slides run macros inside a presentation to, for example, refresh data?**

No. The library never executes VBA code; execution is only possible inside PowerPoint with the appropriate security settings.

**Is working with ActiveX controls linked to VBA code supported?**

Yes, you can access existing [ActiveX controls](/slides/python-net/activex/), modify their properties, and remove them. This is useful when macros interact with ActiveX.
