---
title: Shape Manipulations
type: docs
weight: 60
url: /net/shape-manipulations/
---

## **Shape Manipulations**
### **Finding a Shape in a Slide**
This topic will describe a simple technique to make it easier for developers to find a specific shape on a slide without using its internal Id. It is important to know that PowerPoint Presentation files do not have any way to identify shapes on a slide except an internal unique Id. It seems to be difficult for developers to find a shape using its internal unique Id. All shapes added to the slides have some Alt Text. We suggest developers to use alternative text for finding a specific shape. You can use MS PowerPoint to define the alternative text for objects which you are planning to change in the future.

After setting the alternative text of any desired shape, you can then open that presentation using Aspose.Slides for .NET and iterate through all shapes added to a slide. During each iteration, you can check the alternative text of the shape and the shape with the matching alternative text would be the shape required by you. To demonstrate this technique in a better way, we have created a method, [FindShape](http://www.aspose.com/api/net/slides/aspose.slides.util/slideutil/methods/findshape/index) that does the trick to find a specific shape in a slide and then simply returns that shape.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FindShapeInSlide-FindShapeInSlide.cs" >}}
### **Picture Frame Formatting**
The picture frame that we created in the above section is simple. We can also control the formatting of a picture frame according to the requirement. There are many formatting settings that can be applied on a picture frame. To control the formatting of a picture frame in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) class.
- Obtain the reference of a slide by using its index.
- Create an [IPPImage](http://www.aspose.com/api/net/slides/aspose.slides/ippimage) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Calculate the width and height of image.
- Create a PictureFrame according to the width and height of the image by using the [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) method exposed by the [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) object associated with the referenced slide.
- Add the picture frame (containing the picture) to the slide.
- Set the picture frame's line color.
- Set the picture frame's line width.
- Rotate the picture frame by giving it either a positive or negative value.
- A positive value rotates it clockwise; a negative value rotates it anti-clockwise.
- Add the picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-PictureFrameFormatting-PictureFrameFormatting.cs" >}}
### **Add StretchOff Property**
The Properties StretchOffsetLeft, StretchOffsetTop, StretchOffsetRight and StretchOffsetBottom has been added to IPictureFillFormat interface and PictureFillFormat class respectively. These properties specify a fill rectangle. When stretching of an image is specified, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset, while a negative percentage specifies an outset.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) class.
- Obtain the reference of a slide by using its index.
- Add an AutoShape of Rectangle type.
- Create Image.
- Set shape's fill type.
- Set shape's picture fill mode.
- Add Set image to fill the shape.
- Specify image offsets from the corresponding edge of the shape's bounding box
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddStretchOffsetForImageFill-AddStretchOffsetForImageFill.cs" >}}
### **Cloning Shapes**
To clone a shape to a slide using Aspose.Slides for .NET:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access the source slide shape collection.
1. Add new slide to the presentation.
1. Clone shapes from the source slide shape collection to the new slide.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-CloneShapes-CloneShapes.cs" >}}
### **Render Shape as SVG**
Now Aspose.Slides for .NET support for rendering a shape as svg. WriteAsSvg method (and its overload) has been added to Shape class and IShape interface. This method allows to save content of the shape as an SVG file. Code snippet below shows how to export slide's shape to an SVG file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-ExportShapeToSVG-ExportShapeToSVG.cs" >}}
### **Adding Group Shape**
Aspose.Slides support working with group shapes on slides. This feature helps developers support richer presentations. Aspose.Slides for .NET supports adding or accessing group shapes. It is possible to add shapes to an added group shape to populate it or access any property of group shape. To add a group shape to a slide using Aspose.Slides for .NET:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index
1. Add a group shape to the slide.
1. Add the shapes to the added group shape.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-CreateGroupShape-CreateGroupShape.cs" >}}
### **Accessing AltText Property**
This topic shows simple steps, complete with code examples, for adding a group shape and accessing AltText property of group shapes on slides. To access AltText of a group shape in a slide using Aspose.Slides for .NET:

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class that represents PPTX file.
1. Obtain the reference of a slide by using its Index.
1. Accessing the shape collection of slides.
1. Accessing the group shape.
1. Accessing the AltText property.

The example below accesses alternative text of group shape.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cs" >}}
### **Finding The Angle Of Connector Lines**
In order to calculate the angle for connector line, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation.
1. Obtain the reference of a slide by using its Index.
1. Access the Connector Line shape.
1. Use the line width, height, shape frame height and shape frame width to calculate the angle.
   In the example given below, we have calculated the angle for connector line shape in slide.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-ConnectorLineAngle-ConnectorLineAngle.cs" >}}
## **Getting Paragraph and Portion coordinates in a TextFrame**
Using Aspose.Slides for .NET, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get the coordinates of portion inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with position of portion inside a paragraph.
### **Getting Rectangular coordinates of a Paragraph**
The new method **GetRect()** has been added. It allows to get paragraph bounds rectangle.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Opening-GetRectangularCoordinatesofParagraph-GetRectangularCoordinatesofParagraph.cs" >}}
### **Getting position coordinates of a Portion**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Opening-GetPositionCoordinatesofPortion-GetPositionCoordinatesofPortion.cs" >}}
## **Connecting shapes using connectors**
In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Call Reroute() method to create shortest automatic connection path.
1. Write the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) as a PPTX file.
   In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-ConnectShapesUsingConnectors-ConnectShapesUsingConnectors.cs" >}}




{{% alert color="primary" %}} 

Method IConnector.Reroute() reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the Reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

{{% /alert %}} 
### **Using desired connection site**
In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Setting the desired connection site on shape for connector.
1. Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-ConnectShapeUsingConnectionSite-ConnectShapeUsingConnectionSite.cs" >}}
## **Extracting Flash objects from Presentation**
Aspose.Slides for .NET provides a facility for extracting flash objects from presentation. You can access the flash control by name and extract it from presentation and including store SWF object data.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ExtractFlashFromPresentation-ExtractFlashFromPresentation.cs" >}}
## **Add Images as EMF in Slides**
Aspose.Slides for .NET provides a facility that generates EMF image of excel sheet and add the image as EMF in slides with the help of Aspose.Cells. The sample code is implemented in the example given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-ImageAsEMF-ImageAsEMF.cs" >}}
