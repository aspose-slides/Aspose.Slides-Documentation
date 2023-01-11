---
title: Presentation via VBA
type: docs
weight: 250
url: /python-net/presentation-via-vba/
keywords: "Macro, macros, VBA, VBA macro, add macro, remove macro, add VBA, remove VBA, extract macro, extract VBA, PowerPoint macro, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add, remove, and extract VBA macros in PowerPoint presentations in Python"
---

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) constructor to add a new VBA project.
1. Add a module to the VbaProject.
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

This Python code shows you how to add a VBA macro from scratch to a presentation:

```python
import aspose.slides as slides

# Creates an instance of the presentation class
with slides.Presentation() as presentation:
    # Creates a new VBA Project
    presentation.vba_project = slides.vba.VbaProject()

    # Adds an empty module to the VBA project
    module = presentation.vba_project.modules.add_empty_module("Module")
  
    # Sets the module source code
    module.source_code = "Sub Test(oShape As Shape) MsgBox ""Test"" End Sub"

    # Creates a reference to <stdole>
    stdoleReference = slides.vba.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Creates a reference to Office
    officeReference =slides.vba.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Adds references to the VBA project
    presentation.vba_project.references.add(stdoleReference)
    presentation.vba_project.references.add(officeReference)

            
    # Saves the Presentation
    presentation.save("AddVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**

Using the [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#properties) property under the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

This Python code shows you how to remove a VBA macro:

```python
import aspose.slides as slides

# Loads the presentation containing the macro
with slides.Presentation(path + "VBA.pptm") as presentation:
    # Accesses the Vba module and removes it  
    presentation.vba_project.modules.remove(presentation.vba_project.modules[0])

    # saves the Presentation
    presentation.save("RemovedVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Extract VBA Macros**

1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This Python code shows you how to extract VBA macros from a presentation containing macros:

```python
import aspose.slides as slides

with slides.Presentation(path + "VBA.pptm") as pres:
    if pres.vba_project is not None: # Checks whether the Presentation contains a VBA Project
        for module in pres.vba_project.modules:
            print(module.name)
            print(module.source_code)
```



