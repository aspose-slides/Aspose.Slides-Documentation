---
title: Presentation via VBA
type: docs
weight: 250
url: /python-net/presentation-via-vba/
keywords: "Macro, macros, VBA, VBA macro, add macro, remove macro, add VBA, remove VBA, extract macro, extract VBA, PowerPoint macro, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add, remove, and extract VBA macros in PowerPoint presentations in Python"
---

## **Add VBA Macros**
The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class previous [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) property has been replaced. Now instead of the raw bytes of the [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) property representation of VBA project, the new **IVbaProject** interface implementation has been added. Use **IVbaProject** to manage VBA embedded in a presentation. You can add new project references, edit existing modules and create new ones. Also, you can create a new VBA project using the **VbaProject** class which implements the **VbaProject** interface. The following example shows how to create a simple VBA project. It contains one module and adds two required references to the libraries.

1. Create an instance of the `Presentation` class.
1. Add a new VbaProject with the **Presentation.VbaProject** property.
1. Add a module to the [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the **VbaProject**.
1. Finally, write the PPTX file using the `Presentation` object.

The implementation of the above steps is demonstrated in the example below.

```py
import aspose.slides as slides

# Instantiate Presentation
with slides.Presentation() as presentation:
    # Create new VBA Project
    presentation.vba_project = slides.vba.VbaProject()

    # add empty module to the VBA project
    module = presentation.vba_project.modules.add_empty_module("Module")
  
    # Set module source code
    module.source_code = "Sub Test(oShape As Shape) MsgBox ""Test"" End Sub"

    # Create reference to <stdole>
    stdoleReference = slides.vba.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Create reference to Office
    officeReference =slides.vba.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # add references to the VBA project
    presentation.vba_project.references.add(stdoleReference)
    presentation.vba_project.references.add(officeReference)

            
    # save Presentation
    presentation.save("AddVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**
The `Presentation` class now has included the support to remove the VBA macros inside presentation. The following example shows how to access and remove a VBA macro in presentation.

1. Create an instance of the `Presentation` class and load presentation with Macro.
1. Access the Macro module and remove that
1. Finally, write the PPTX file using the `Presentation` class object.

The implementation of the above steps is demonstrated in the example below.

```py
import aspose.slides as slides

# Instantiate Presentation
with slides.Presentation(path + "VBA.pptm") as presentation:
    # Access the Vba module and remove 
    presentation.vba_project.modules.remove(presentation.vba_project.modules[0])

    # save Presentation
    presentation.save("RemovedVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Extract VBA Macros**
Aspose.Slides for Python via .NET supports extracting VBA Macros from the slide. In order to extract VBA Macros, please follow the steps below:

- Load a Presentation containing a VBA Macros
- Check if Presentation contains VBA Project
- Loop through all the modules that are contained in the VBA Project

The implementation of the above steps is demonstrated in the example below.

```py
import aspose.slides as slides

with slides.Presentation(path + "VBA.pptm") as pres:
    if pres.vba_project is not None: # check if Presentation contains VBA Project
        for module in pres.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

