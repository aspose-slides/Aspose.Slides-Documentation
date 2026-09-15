---
title: Manage VBA Projects in Presentations Using Python
linktitle: Presentation via VBA
type: docs
weight: 250
url: /python-java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Discover how to generate and manipulate PowerPoint and OpenDocument presentations via VBA with Aspose.Slides for Python via Java to streamline your workflow."
---

## **Introduction**

Aspose.Slides provides classes and interfaces for working with macros and VBA code.

{{% alert title="Warning" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/python-java/aspose.slides/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [VbaProject](https://reference.aspose.com/slides/python-java/aspose.slides/vbaproject/) class to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/python-java/aspose.slides/vbaproject/#vbaproject) constructor to add a new VBA project.
1. Add a module to the VBA project.
1. Set the module source code.
1. Add references to `stdole`.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

This Python code shows you how to add a VBA macro from scratch to a presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Create a new VBA project.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Add an empty module and set its source code.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Create references to stdole and Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Add references to the VBA project.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Save the presentation.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), which is a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**

Using the [getVbaProject](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getvbaproject) method of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing the macro.
1. Access the macro module and remove it.
1. Save the modified presentation.

This Python code shows you how to remove a VBA macro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Load the presentation containing the macro.
presentation = Presentation("VBA.pptm")
try:
    # Access the VBA module and remove it.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Save the presentation.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Extract VBA Macros**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This Python code shows you how to extract VBA macros from a presentation containing macros:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Load the presentation containing the macro.
presentation = Presentation("VBA.pptm")
try:
    # Check whether the presentation contains a VBA project.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Check Whether a VBA Project Is Password-Protected**

Using the [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/python-java/aspose.slides/vbaproject/#ispasswordprotected) method, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load a presentation that contains a macro.
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/python-java/aspose.slides/vbaproject/).
3. Check whether the VBA project is password-protected to view its properties.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Check whether the presentation contains a VBA project.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**What happens to macros if I save the presentation as PPTX?**

Macros will be removed because PPTX does not support VBA. To keep macros, choose PPTM, PPSM, or POTM.

**Can Aspose.Slides run macros inside a presentation to, for example, refresh data?**

No. The library never executes VBA code; execution is only possible inside PowerPoint with the appropriate security settings.

**Is working with ActiveX controls linked to VBA code supported?**

Yes, you can access existing [ActiveX controls](/slides/python-java/activex/), modify their properties, and remove them. This is useful when macros interact with ActiveX.
