---
title: Presentation via VBA
type: docs
weight: 250
url: /net/presentation-via-vba/
---

## **Add VBA Macros**
The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class previous [VbaProject](http://www.aspose.com/api/net/slides/aspose.slides.vba/vbaproject) property has been replaced. Now instead of the raw bytes of the [VbaProject](http://www.aspose.com/api/net/slides/aspose.slides.vba/vbaproject) property representation of VBA project, the new **IVbaProject** interface implementation has been added. Use **IVbaProject** to manage VBA embedded in a presentation. You can add new project references, edit existing modules and create new ones. Also, you can create a new VBA project using the **VbaProject** class which implements the **VbaProject** interface. The following example shows how to create a simple VBA project. It contains one module and adds two required references to the libraries.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Add a new VbaProject with the **Presentation.VbaProject** property.
1. Add a module to the [VbaProject](http://www.aspose.com/api/net/slides/aspose.slides.vba/vbaproject).
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the **VbaProject**.
1. Finally, write the PPTX file using the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) object.

The implementation of the above steps is demonstrated in the example below.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-VBA-AddVBAMacros-AddVBAMacros.cs" >}}
## **Remove VBA Macros**
The [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class now has included the support to remove the VBA macros inside presentation. The following example shows how to access and remove a VBA macro in presentation.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load presentation with Macro.
1. Access the Macro module and remove that
1. Finally, write the PPTX file using the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.

The implementation of the above steps is demonstrated in the example below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-VBA-RemoveVBAMacros-RemoveVBAMacros.cs" >}}
## **Extract VBA Macros**
Aspose.Slides for .NET supports extracting VBA Macros from the slide. In order to extract VBA Macros, please follow the steps below:

- Load a Presentation containing a VBA Macros
- Check if Presentation contains VBA Project
- Loop through all the modules that are contained in the VBA Project

The implementation of the above steps is demonstrated in the example below.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VBA-ExtractingVBAMacros-ExtractingVBAMacros.cs" >}}
