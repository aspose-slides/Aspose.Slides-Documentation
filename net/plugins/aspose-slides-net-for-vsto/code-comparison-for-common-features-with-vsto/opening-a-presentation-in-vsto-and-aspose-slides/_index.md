---
title: Opening a Presentation in VSTO and Aspose.Slides
type: docs
weight: 120
url: /net/opening-a-presentation-in-vsto-and-aspose-slides/
---

### **VSTO**
Below is the code snippet for opening presentation:

{{< highlight csharp >}}

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


{{< /highlight >}}
### **Aspose.Slides**
Aspose.Slides for .NET provides **Presentation** class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of **Presentation** class to create its object based on an existing presentation.In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of Presentation class. After the file is opened, we get the total number of slides present in the presentation to print on the screen.

{{< highlight csharp >}}

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

{{< /highlight >}}
### **Download Running Code**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
### **Download Sample Code**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Opening a Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)
