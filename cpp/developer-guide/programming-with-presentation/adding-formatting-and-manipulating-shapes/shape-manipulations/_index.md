---
title: Shape Manipulations
type: docs
weight: 50
url: /cpp/shape-manipulations/
---

## **Shape Manipulations**
### **Finding a Shape in a Slide**
This topic will describe a simple technique to make it easier for developers to find a specific shape on a slide without using its internal Id. It is important to know that PowerPoint Presentation files do not have any way to identify shapes on a slide except an internal unique Id. It seems to be difficult for developers to find a shape using its internal unique Id. All shapes added to the slides have some Alt Text. We suggest developers to use alternative text for finding a specific shape. You can use MS PowerPoint to define the alternative text for objects which you are planning to change in the future.

After setting the alternative text of any desired shape, you can then open that presentation using Aspose.Slides for C++ and iterate through all shapes added to a slide. During each iteration, you can check the alternative text of the shape and the shape with the matching alternative text would be the shape required by you. To demonstrate this technique in a better way, we have created a method, [FindShape](http://www.aspose.com/api/net/slides/aspose.slides.util/slideutil/methods/findshape/index) that does the trick to find a specific shape in a slide and then simply returns that shape.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}
### **Applying Animation Effects**
Animation is one of the most important parts of the presentations that make them more attractive and meaningful. Aspose.Slides for C++ also allows developers to apply different kinds of animation effects on different kinds of shapes. There is a separate namespace [Aspose.Slides.Animation](http://www.aspose.com/api/net/slides/aspose.slides.animation/) that provides classes to handle the animations on PPTX presentations. In this topic, we will show how to apply animation effects on shapes.

Here we will apply the PathFootball effect (one of more than 150 available effects) on a TextBox that will be activated on clicking the bevel shape (some sort of button). To apply such animation effect, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type.
- Add an IAutoShape of [Bevel type](http://www.aspose.com/api/net/slides/aspose.slides/shapetype) (clicking on which, animations will take effect).
- Create a sequence of effects on this Bevel shape.
- Create a custom User Path.
- Add commands to the Path for moving.
- Write the presentation to the disk as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimationsOnShapes-AnimationsOnShapes.cpp" >}}
### **Picture Frame Formatting**
The picture frame that we created in the above section is simple. We can also control the formatting of a picture frame according to the requirement. There are many formatting settings that can be applied on a picture frame. To control the formatting of a picture frame in a slide, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its index.
- Create an [IPPImage](http://www.aspose.com/api/net/slides/aspose.slides/ippimage) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Calculate the width and height of the image.
- Create a PictureFrame according to the width and height of the image by using the [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) method exposed by the [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) object associated with the referenced slide.
- Add the picture frame (containing the picture) to the slide.
- Set the picture frame's line color.
- Set the picture frame's line width.
- Rotate the picture frame by giving it either a positive or negative value.
- A positive value rotates it clockwise; a negative value rotates it anti-clockwise.
- Add the picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PictureFrameFormatting-PictureFrameFormatting.cpp" >}}
### **Add StretchOff Property**
The Properties StretchOffsetLeft, StretchOffsetTop, StretchOffsetRight and StretchOffsetBottom has been added to IPictureFillFormat interface and PictureFillFormat class respectively. These properties specify a filled rectangle. When stretching of an image is specified, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset, while a negative percentage specifies an outset.

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its index.
- Add an AutoShape of Rectangle type.
- Create Image.
- Set shape's fill type.
- Set shape's picture fill mode.
- Add Set image to fill the shape.
- Specify image offsets from the corresponding edge of the shape's bounding box
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Shapes-AddStretchOffsetForImageFill-AddStretchOffsetForImageFill.cs" >}}
### **Cloning Shapes**
To clone a shape to a slide using Aspose.Slides for C++:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access the source slide shape collection.
1. Add a new slide to the presentation.
1. Clone shapes from the source slide shape collection to the new slide.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}
### **Adding Group Shape**
Aspose.Slides support working with group shapes on slides. This feature helps developers support richer presentations. Aspose.Slides for C++ supports adding or accessing group shapes. It is possible to add shapes to an added group shape to populate it or access any property of group shape. To add a group shape to a slide using Aspose.Slides for C++:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index
1. Add a group shape to the slide.
1. Add the shapes to the added group shape.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}
### **Accessing AltText Property**
This topic shows simple steps, complete with code examples, for adding a group shape and accessing AltText property of group shapes on slides. To access AltText of a group shape in a slide using Aspose.Slides for C++:

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class that represents a PPTX file.
1. Obtain the reference of a slide by using its Index.
1. Accessing the shape collection of slides.
1. Accessing the group shape.
1. Accessing the AltText property.

The example below accesses the alternative text of group shape.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}
### **Finding The Angle Of Connector Lines**
In order to calculate the angle for the connector line, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation.
1. Obtain the reference of a slide by using its Index.
1. Access the Connector Line shape.
1. Use the line width, height, shape frame height and shape frame width to calculate the angle.
   In the example given below, we have calculated the angle for connector line shape in a slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConnectorLineAngle-ConnectorLineAngle.cpp" >}}
## **Getting Paragraph and Portion coordinates in a TextFrame**
Using Aspose.Slides for C++, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get the coordinates of portion inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with the position of portion inside a paragraph.
### **Getting Rectangular coordinates of a Paragraph**
The new method **GetRect()** has been added. It allows to get paragraph bounds rectangle.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Opening-GetRectangularCoordinatesofParagraph-GetRectangularCoordinatesofParagraph.cs" >}}
### **Getting position coordinates of a Portion**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Opening-GetPositionCoordinatesofPortion-GetPositionCoordinatesofPortion.cs" >}}
## **Handling OLE Object Frame**
OLE stands for Object Linking & Embedding. It's a Microsoft technology that allows objects created in one application to be embedded in another application. For example, you can create a chart in an Excel Worksheet and then embed that chart object into your PowerPoint slide. After the chart object is embedded, you just double click the object and the chart object will be opened in editable form as you see in MS Excel. Aspose.Slides for C++ supports adding OLE Objects to the slides in the form of OLE Object Frames. In this topic, we will work with OLE Object Frames to see that how can we add and access these objects to and from slides using Aspose.Slides for C++. This article explains different examples of working with Ole frames:

- Adding an OLE Object Frame to a Slide.
- Accessing an OLE Object Frame from a Slide.
- Changing an OLE Object data from a Slide.
### **Adding an OLE Object Frame to a Slide**
Suppose, you have created a Microsoft Excel Chart in an Excel file and want to embed that chart object in a slide as an OLE Object Frame using Aspose.Slides for C++. Then you can do that using the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Open the Excel file containing Microsoft Excel Chart object and save it to MemoryStream.
1. Add the OLE Object Frame to the slide containing the array of bytes and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example given below, a Microsoft Excel Chart object in an Excel file is added to a slide as an OLE Object Frame using Aspose.Slides for C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddOLEObjectFrame-AddOLEObjectFrame.cpp" >}}
### **Accessing an OLE Object Frame**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for C++. Please follow the steps below to find or access an OLE object from a slide:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Access the OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once the OLE Object Frame is accessed, you can perform any operation on it.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then all of its Object Data is written to an Excel file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessOLEObjectFrame-AccessOLEObjectFrame.cpp" >}}
### **Changing an OLE Object data**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for C++ and can modify its data. Please follow the steps below to find how to modify an OLE object data from a slide:

1. Open the desired presentation with embedded Ole Object by creating an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Access the OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once the OLE Object Frame is accessed, you can perform any operation on it.
1. Create the Workbook object and access the Ole Data.
1. Access the desired Worksheet and amend the data.
1. Save the updated Workbook in streams.
1. Change the Ole object data from stream data.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then its Object Data is modified to change the chart data.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeOLEObjectData-ChangeOLEObjectData.cpp" >}}
### **Set File Type for an Embedding Object**
Using Aspose.Slides for C++ you can set file type for an embedding object. For this purpose, new methods **addOleObjectFrame** and **insertOleObjectFrame** have been added into **IShapeCollection**.

These methods allow to get **IOleEmbeddedDataInfo** object as a parameter so now OLE object knows its type and PowerPoint can open created OLE objects.

The following example shows how to set file type for an embedding object:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetFileTypeForAnEmbeddingObject-SetFileTypeForAnEmbeddingObject.cpp" >}}
### **Extract Embedded Files from OLE Object**
Aspose.Slides for C++ supports extracting embedded files from OLE Object. In order to extract embedded files, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class and Load a presentation contains OLE Object
- Loop through all the shapes in a presentation and access the OLE Object Frame shape
- Access the data of the Embedded file from OLE Object Frame and write it to disk

The implementation of the above steps is demonstrated in the example below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ExtractEmbeddedFileDataFromOLEObject-ExtractEmbeddedFileDataFromOLEObject.cpp" >}}
## **Connecting shapes using connectors**
In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Call Reroute() method to create the shortest automatic connection path.
1. Write the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) as a PPTX file.
   In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConnectShapesUsingConnectors-ConnectShapesUsingConnectors.cpp" >}}




{{% alert color="primary" %}} 

Method IConnector.Reroute() reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the Reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

{{% /alert %}} 
### **Using desired connection site**
In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Setting the desired connection site on shape for a connector.
1. Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConnectShapeUsingConnectionSite-ConnectShapeUsingConnectionSite.cpp" >}}
## **Extracting Flash objects from Presentation**
Aspose.Slides for C++ provides a facility for extracting flash objects from a presentation. You can access the flash control by name and extract it from the presentation and including store SWF object data.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Properties-ExtractFlashFromPresentation-ExtractFlashFromPresentation.cs" >}}
