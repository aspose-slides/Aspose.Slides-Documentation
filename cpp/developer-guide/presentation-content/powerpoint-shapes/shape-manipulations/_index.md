---
title: Shape Manipulations
type: docs
weight: 30
url: /cpp/shape-manipulations/
---

## **Find Shape in Slide**
This topic will describe a simple technique to make it easier for developers to find a specific shape on a slide without using its internal Id. It is important to know that PowerPoint Presentation files do not have any way to identify shapes on a slide except an internal unique Id. It seems to be difficult for developers to find a shape using its internal unique Id. All shapes added to the slides have some Alt Text. We suggest developers to use alternative text for finding a specific shape. You can use MS PowerPoint to define the alternative text for objects which you are planning to change in the future.

After setting the alternative text of any desired shape, you can then open that presentation using Aspose.Slides for C++ and iterate through all shapes added to a slide. During each iteration, you can check the alternative text of the shape and the shape with the matching alternative text would be the shape required by you. To demonstrate this technique in a better way, we have created a method, [FindShape](http://www.aspose.com/api/net/slides/aspose.slides.util/slideutil/methods/findshape/index) that does the trick to find a specific shape in a slide and then simply returns that shape.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **Clone Shape**
To clone a shape to a slide using Aspose.Slides for C++:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access the source slide shape collection.
1. Add a new slide to the presentation.
1. Clone shapes from the source slide shape collection to the new slide.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **Remove Shape**
Aspose.Slides for C++ allows developers to remove any shape. To remove the shape from any slide, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Remove the shape.
1. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **Rotate Shape**
Aspose.Slides for C++ allows developers to you rotate shapes as well in this topic, we will see how developers can rotate their shapes. Rotating a shape using Aspose.Slides for C++ is as easy as ABC. To rotate a shape added to the slide, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add a Shape to the slide.
- Rotate the Shape to some degrees.
- Write the modified presentation as a PPTX file.

In the example given below, we have rotated a rectangle shape to 90 degrees for the demonstration purpose.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingShapes-RotatingShapes.cpp" >}}

## **Hide Shape**
Aspose.Slides for C++ allows developers to hide any shape. To hide the shape from any slide, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Hide the shape.
1. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **Change Shape Order**
Aspose.Slides for C++ allows developers to reorder the shapes. Reordering the shape specifies which shape is on the front or which shape is at the back. To reorder the shape from any slide, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access the first slide.
1. Add a shape.
1. Add some text in shape's text frame.
1. Add another shape with the same co-ordinates.
1. Reorder the shapes.
1. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **Get Interop Shape ID**
Aspose.Slides for C++ allows developers to get a unique shape identifier in slide scope in contrast to the UniqueId property, which allows obtaining a unique identifier in presentation scope. Property OfficeInteropShapeId was added to IShape interfaces and Shape class respectively. The value returned by OfficeInteropShapeId property corresponds to the value of the Id of the Microsoft.Office.Interop.PowerPoint.Shape object. Below is the sample code is given.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **Access Layout Formats for Shape**
Aspose.Slides for C++ allows developers to access layout formats for a shape. This article demonstrates how you can access **FillFormat** and **LineFormat** properties for a shape.

Below is the sample code is given.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Shapes Alignment**
Aspose.Slides allows to align shapes either relative to the slide margins or relative to each other. For this purpose, overloaded method [SlidesUtil.AlignShapes()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) has been added. The [ShapesAlignmentType](https://apireference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) enumeration  defines possible alignment options.

### Example 1

Source code below aligns shapes with indices 1, 2 and 4 along the top border of the slide. 

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

### Example 2

The example below shows how to align the entire collection of shapes relative to the very bottom shape in the collection.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```