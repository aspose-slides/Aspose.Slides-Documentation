---
title: Adding and Editing Slides
type: docs
weight: 10
url: /cpp/adding-and-editing-slides/
---

## **Adding Slides to Presentation**
Before talking about adding slides to the presentation files, let us discuss some facts about the slides. Each PowerPoint presentation file contains Master / Layout slide and other Normal slides. It means that a presentation file contains at least one or more slides. It is important to know that presentation files without slides are not supported by Aspose.Slides for C++. Each slide has unique Id and all the Normal Slides are arranged in an order specified by the zero based index. Aspose.Slides for C++ allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Instantiate [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) class by setting a reference to the Slides (collection of content Slide objects) property exposed by the Presentation object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the AddEmptySlide methods exposed by ISlideCollection object
- Do some work with the newly added empty slide.
- Finally, write the presentation file using the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) object.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}
### **Adding or Removing section**
Aspose.Slides for C++ now allows developers to add section or remove section where group of slides can be added or removed. Developers can also add section on any desired location in presentation. The code snippet below demonstrates how to use this feature.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSlidesSections-ManageSlidesSections.cpp" >}}
## **Accessing Slides of a Presentation**
In this topic, we will introduce the possible ways to access a slide from a presentation file. Each slide in a presentation has a unique Id. On the other hand, all the slides in the presentation are arranged in the order of the slide position starting from 0, that is, slide at position 1 will be accessible through 0 index of [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) associated with a [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) object.

Aspose.Slides for C++ provides [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class that can be used to find and access any desired slide present in the presentation. Currently, developers can access a slide in following two ways.

1. Access Slide by Index.
1. Access Slide by ID.
### **Access Slide by Index**
[Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class represents a presentation file and exposes all slides in it as a [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) collection (that is a collection of [ISlide](http://www.aspose.com/api/net/slides/aspose.slides/islide) objects). All of these slides can be accessed from this Slides collection using a slide index as shown below in the example.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSlidebyIndex-AccessSlidebyIndex.cpp" >}}
### **Access Slide by ID**
Every slide in presentation has a unique ID associated with it. The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class exposes the [GetSlideById(id)](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/getslidebyid) method that can be used to access the slide by ID. All you need to do is to provide the valid slide ID and access that slide using [GetSlideById(id)](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/getslidebyid) method as shown below in the example.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSlidebyID-AccessSlidebyID.cpp" >}}
## **Removing Slides from a Presentation**
Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for C++ offers few methods to do so. In this topic, we will explore these methods to accomplish this task. We know that [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class in Aspose.Slides for C++ represents a presentation file. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class encapsulates a [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this Slides collection in two ways:

1. Using Slide Reference
1. Using Slide Index
### **Using Slide Reference**
To remove a slide using its reference, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Id or Index.
1. Remove the referenced slide from the presentation.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSlides-RemoveSlideUsingReference.cpp" >}}
### **Using Slide Index**
To remove a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Remove the slide from the presentation by using its index position.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSlides-RemoveSlideUsingIndex.cpp" >}}
## **Working With Slide Size and Layout**
In this topic, we will introduce the possible ways to set size and type of a slide from a presentation file. Also, we will discuss how to set the page size when presentation is converted to PDF file. Aspose.Slides for C++ provides the feature of setting the size and type of any slide as it is in the source presentation. Developers can set these properties while cloning the slides from different presentation files:

- Setting Slide Size and Type.
- Setting the page size when generating PDF.
### **Setting the Size and Type of a slide**
[SlideSize.Type](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/type) and [SlideSize.Size](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithSetSizeAndType-CloneToAnotherPresentationWithSetSizeAndType.cpp" >}}
### **Setting Footer Visibility Inside Slide**
To set footer in a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide by its reference index.
1. Set Footer visible by making slide footer placeholder visible.
1. Set date-time placeholder visible by using SetDateTime method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-HeaderFooterManager-HeaderFooterManager.cpp" >}}
### **Setting Child Footer Visibility Inside Slide**
To set footer and child footer a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the master slide by using its index.
1. Set Footer and child footer visibility by making master slide and all child footer placeholder visible.
1. Set text to master slide and all child footer placeholder by using SetFooterAndChildFootersText method.
1. Set text to master slide and all child date-time placeholder by using SetDateTimeAndChildDateTimesText method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetChildFooter-SetChildFooter.cpp" >}}
### **Compare two slides**
Equals method has been added to IBaseSlide interface and BaseSlide class. It returns true for the slides / layout slides / master slides which identical by its structure and static content.

Two slides are equal if all shapes, styles, texts, animation and other settings. etc. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}
### **Setting the Slide Size with respect to Content Scaling**
You can also set the slide size by using it with different ways of content scaling.[ SlideSize.Type](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/type) and [SlideSize.Size](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetSlideSizeScale-SetSlideSizeScale.cpp" >}}
### **Setting the page size when generating PDF**
Slides in presentation could be set as different paper sizes. The [SlideSize.Type](http://www.aspose.com/api/net/slides/aspose.slides/slidesize/properties/type) property and [SlideSizeScaleType ](https://apireference.aspose.com/net/slides/aspose.slides/slidesizescaletype)enumeration can be used to set the slide size. Developers can set size of slide as shown below in the example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ManageSlideSize-SetPDFPageSize.cpp" >}}
## **Removing and Adding Slide Notes From a Presentation**
Aspose.Slides now supports removing notes slides from presentation. In this topic, we will introduce this new feature of removing Notes also adding notes style slides from any presentation. Aspose.Slides for C++ provides the feature of removing notes of any slide as well as add style to existing notes. Developers can remove notes in following ways:

- Removing Notes of a Specific Slide of a presentation.
- Removing Notes of All Slides of a Presentation.
### **Removing Notes of a Specific Slide**
Notes of some specific slide could be removed as shown in example below:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
### **Removing Notes of All Slides**
Notes of all the slides of a presentation could be removed as shown in example below:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
### **Adding NotesStyle**
NotesStyle property has been added to IMasterNotesSlide interface and MasterNotesSlide class respectively. This property specifies the style of a notes text.  The implementation is demonstrated in the example below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}
## **Working with ActiveX Controls**
ActiveX control are used in presentations. Aspose.Slides for C++ lets you manage ActiveX controls, but managing them is bit trickier and different from normal presentation shapes. From Aspose.Slides for C++ 6.9.0, the component supports managing ActiveX controls. At the moment, you can access already added ActiveX control in your presentation and modify or delete it by using its various properties. Remember, ActiveX controls are not shapes and are not part of the presentation's IShapeCollection but the separate IControlCollection. This article shows how to work with them.
### **Modifying ActiveX Controls**
To manage a simple ActiveX control like a text box and simple command button on a slide:

1. Create an instance of the Presentation class and load the presentation with ActiveX controls in it.
1. Obtain a slide reference by its index.
1. Access the ActiveX controls in the slide by accessing the IControlCollection.
1. Access the TextBox1 ActiveX control using the ControlEx object.
1. Change the different properties of the TextBox1 ActiveX control including text, font, font height and frame position.
1. Access the second access control called CommandButton1.
1. Change the button caption, font and position.
1. Shift the position of the ActiveX controls frames.
1. Write the modified presentation to a PPTX file.

The code snippet below updates the ActiveX controls on the presentation slides to the slide as shown below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-ActiveX-ManageActiveXControl-ManageActiveXControl.cs" >}}
### **Adding Media Player ActiveX Controls**
ActiveX control are used in presentations. Aspose.Slides for C++ lets you add and manage ActiveX controls, but managing them is bit trickier and different from normal presentation shapes. From Aspose.Slides for C++ 7.3.1, the support for adding Media Player ActiveX control has been added in Aspose.Slides. Remember, ActiveX controls are not shapes and are not part of the presentation's IShapeCollection but the separate IControlExCollection. This article shows how to work with them. To manage a Media Player ActiveX control, please perform following steps:

1. Create an instance of the Presentation class and load the sample presentation with Media Player ActiveX controls in it.
1. Create an instance of target Presentation class and generate empty presentation instance.
1. Clone the slide with Media Player ActiveX control in template presentation to target Presentation.
1. Access the cloned slide in target Presentation.
1. Access the ActiveX controls in the slide by accessing the IControlCollection.
1. Access the Media Player ActiveX control and set the video path by using its properties.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-ActiveX-LinkingVideoActiveXControl-LinkingVideoActiveXControl.cs" >}}
## **Working With VBA Macros**
### **Add VBA Macros**
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



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddVBAMacros-AddVBAMacros.cpp" >}}
### **Remove VBA Macros**
The [Presentation](/pages/createpage.action?spaceKey=slidescpp&title=Aspose.Slides.Presentation+Class&linkCreation=true&fromPageId=60228390) class now has included the support to remove the VBA macros inside presentation. The following example shows how to access and remove a VBA macro in presentation.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load presentation with Macro.
1. Access the Macro module and remove that
1. Finally, write the PPTX file using the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.

The implementation of the above steps is demonstrated in the example below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveVBAMacros-RemoveVBAMacros.cpp" >}}
### **Extract VBA Macros**
Aspose.Slides for C++ supports extracting VBA Macros from the slide. In order to extract VBA Macros, please follow the steps below:

- Load a Presentation containing a VBA Macros
- Check if Presentation contains VBA Project
- Loop through all the modules that are contained in the VBA Project

The implementation of the above steps is demonstrated in the example below.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ExtractingVBAMacros-ExtractingVBAMacros.cpp" >}}
