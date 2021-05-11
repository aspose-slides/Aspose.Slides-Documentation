---
title: Create a New Presentation
type: docs
weight: 10
url: /net/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO was developed to let developers build applications that could run inside Microsoft Office. VSTO is COM-based but it's wrapped inside a .NET object so that it can be used in .NET applications. VSTO needs .NET framework support as well as Microsoft Office CLR-based runtime. Although it can be used for making Microsoft Office add-ins it is nearly impossible to use as a server-side component. It also has serious deployment problems.

Aspose.Slides for .NET is a component that can be used to manipulate Microsoft PowerPoint presentations, just like VSTO, but it has several advantages:

- Aspose.Slides contains managed code only and doesn’t require Microsoft Office runtime to be installed.
- It can be used as a client-side component or as a server side component.
- Deployment is easy since Aspose.Slides is contained in a single DLL.

{{% /alert %}} 
## **Creating a Presentation**
Below are two code examples that illustrate how VSTO and Aspose.Slides for .NET can be used to achieve the same goal. The first example is [VSTO](/slides/net/create-a-new-presentation/); [the second example](/slides/net/create-a-new-presentation/) uses Aspose.Slides.
### **VSTO Example**
**The VSTO output** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
  //Note: PowerPoint is a namespace which has been defined above like this
            //using PowerPoint = Microsoft.Office.Interop.PowerPoint;

            //Create a presentation
            PowerPoint.Presentation pres = Globals.ThisAddIn.Application
                .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

            //Get the title slide layout
            PowerPoint.CustomLayout layout = pres.SlideMaster.
                CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

            //Add a title slide.
            PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

            //Set the title text
            slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

            //Set the sub title text
            slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

            //Write the output to disk
            pres.SaveAs("c:\\outVSTO.ppt",
                PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
                Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET Example**
**The output from Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//Create a presentation
Presentation pres = new Presentation();

//Add the title slide
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Set the title text
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Set the sub title text
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Write output to disk
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```

