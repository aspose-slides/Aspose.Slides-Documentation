---
title: Presentation via VBA
type: docs
weight: 250
url: /java/presentation-via-vba/
---

## **Add VBA Macros to Presentation**
{{% alert color="primary" %}} 

Aspose.Slides for Java allows developers to manage VBA macros in a presentation. All you have to do is to add a VBA using the [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) interface associated with the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class using the [Presentation.getVbaProject()](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/presentation/methods/getVbaProject\(\)/) method.

{{% /alert %}} 

The [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class' previous **getVbaProject()** method has been replaced. Now instead of the raw bytes of the **getVbaProject()** method representation of VBA project, the new [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) interface implementation has been added.

Use [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) to manage VBA embedded in a presentation. You can add new project references, edit existing modules and create new ones.

Also, you can create a new VBA project using the [VbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VbaProject) class which implements the [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) interface.

The following example shows how to create a simple VBA project. It contains one module and adds two required references to the libraries.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Add a new [VbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VbaProject) with the [Presentation.setVbaProject()](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/presentation/methods/setVbaProject\(com.aspose.slides.IVbaProject\)/) property.
1. Add a module to the [VbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VbaProject).
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the [VbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VbaProject).
1. Finally, write the PPTX file using the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.

The implementation of the above steps is demonstrated in the example below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-VBAMacros-AddingVBAMacrosInPresentation-AddingVBAMacrosInPresentation.java" >}}
## **Remove VBA Macros from Presentation**
{{% alert color="primary" %}} 

Aspose.Slides for Java allows developers to remove VBA macros in a presentation. All you have to do is to add a VBA using the [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) interface associated with the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class using the [Presentation.getVbaProject()](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/presentation/methods/getVbaProject\(\)/) method.

{{% /alert %}} 

The [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class now has included the support to remove the VBA macros inside presentation. The following example shows how to access and remove a VBA macro in presentation.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load presentation with Macro.
1. Access the Macro module and remove that
1. Finally, write the PPTX file using the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.

The implementation of the above steps is demonstrated in the example below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-VBAMacros-RemovingVBAMacrosInPresentation-RemovingVBAMacrosInPresentation.java" >}}
## **Extract VBA Macros**
Aspose.Slides for Java supports extracting VBA Macros from the slide. In order to extract VBA Macros, please follow the steps below:

- Load a Presentation containing a VBA Macros
- Check if Presentation contains VBA Project
- Loop through all the modules that are contained in the VBA Project

The implementation of the above steps is demonstrated in the example below.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-VBAMacros-ExtractingVBAMacros-ExtractingVBAMacros.java" >}}




