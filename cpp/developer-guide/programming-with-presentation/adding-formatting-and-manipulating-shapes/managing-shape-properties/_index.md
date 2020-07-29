---
title: Managing Shape Properties
type: docs
weight: 40
url: /cpp/managing-shape-properties/
---

## **Managing Shape Properties**
In this topic, we will explore the different properties of shapes. Shapes in a presentation could be distinguished by the AlternativeText or Shape Name property. AlternativeText property could be read or set by using Aspose.Slides as well as Microsoft Powerpoint. By using this property, you can tag a shape and can perform different operations as Removing a shape, Hiding a shape or Reordering shapes on a slide.
This article covers the following topics:

- Setting the AlternativeText property of shapes.
- Removing shapes from a slide.
- Hiding the shapes from a slide.
- Changing order of shapes.
### **Set AlternativeText property**
Aspose.Slides for C++ allows developers to set AlternateText of any shape. To set the AlternateText of a shape, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access the first slide.
1. Add any shape to the slide.
1. Do some work with the newly added shape.
1. Traverse through shapes to find a shape.
1. Set the AlternativeText.
1. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}
### **Removing Shape**
Aspose.Slides for C++ allows developers to remove any shape. To remove the shape from any slide, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Remove the shape.
1. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}
### **Hiding Shapes**
Aspose.Slides for C++ allows developers to hide any shape. To hide the shape from any slide, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Hide the shape.
1. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}
### **Changing order of shapes**
Aspose.Slides for C++ allows developers to reorder the shapes. Reordering the shape specifies which shape is on the front or which shape is at the back. To reorder the shape from any slide, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access the first slide.
1. Add a shape.
1. Add some text in shape's text frame.
1. Add another shape with the same co-ordinates.
1. Reorder the shapes.
1. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}
### **Getting Interop Shape ID**
Aspose.Slides for C++ allows developers to get a unique shape identifier in slide scope in contrast to the UniqueId property, which allows obtaining a unique identifier in presentation scope. Property OfficeInteropShapeId was added to IShape interfaces and Shape class respectively. The value returned by OfficeInteropShapeId property corresponds to the value of the Id of the Microsoft.Office.Interop.PowerPoint.Shape object. Below is the sample code is given.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}
### **Access Layout Formats For a Shape**
Aspose.Slides for C++ allows developers to access layout formats for a shape. This article demonstrates how you can access **FillFormat** and **LineFormat** properties for a shape.

Below is the sample code is given.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}
## **Managing Effective Properties**
In this topic, we will discuss **effective** and **local** properties. When we set values directly at these levels

1. In portion properties on portion's slide.
1. In prototype shape text style on layout or master slide (if portion's text frame shape has one).
1. In presentation global text settings.

then those values are called **local** values. At any level, **local** values could be defined or omitted. But finally when it comes to the moment when the application needs to know what the portion should look like it uses **effective** values. You can get effective values by using **GetEffective()** method from the local format.

The following example shows how to get effective values.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}
### **Get Effective Properties of Camera**
Aspose.Slides for C++ allows developers to get effective properties of the camera. For this purpose, the **CameraEffectiveData** class has been added in Aspose.Slides. CameraEffectiveData class represents an immutable object which contains effective camera properties. An instance of **CameraEffectiveData** class is used as part of **ThreeDFormatEffectiveData** class which is an effective values pair for ThreeDFormat class.

The following code sample shows how to get effective properties for the camera.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}
### **Get Effective Properties of Light Rig**
Aspose.Slides for C++ allows developers to get effective properties of Light Rig. For this purpose, the **LightRigEffectiveData** class has been added in Aspose.Slides. LightRigEffectiveData class represents an immutable object which contains effective light rig properties. An instance of **LightRigEffectiveData** class is used as part of **ThreeDFormatEffectiveData** class which is an effective values pair for ThreeDFormat class.

The following code sample shows how to get effective properties for the Light Rig.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}
### **Get Effective Properties of Bevel Shape**
Aspose.Slides for C++ allows developers to get effective properties of Bevel Shape. For this purpose, the **ShapeBevelEffectiveData** class has been added in Aspose.Slides. ShapeBevelEffectiveData class represents an immutable object which contains effective shape's face relief properties. An instance of **ShapeBevelEffectiveData** class is used as part of **ThreeDFormatEffectiveData** class which is an effective values pair for ThreeDFormat class.

The following code sample shows how to get effective properties for the Bevel Shape.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

### **Get Effective Properties of Text Frame**
Using Aspose.Slides for C++, you can get effective properties of Text Frame. For this purpose, the **TextFrameFormatEffectiveData** class has been added in Aspose.Slides which contains effective text frame formatting properties. 

The following code sample shows how to get effective text frame formatting properties.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

### **Get Effective Properties of Text Style**
Using Aspose.Slides for C++, you can get effective properties of Text Style. For this purpose, the **TextStyleEffectiveData** class has been added in Aspose.Slides which contains effective text style properties. 

The following code sample shows how to get effective text style properties.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}
### **Get Effective Font Height Value**
Using Aspose.Slides for C++, you can get effective properties of Font Height.  Here is the code demonstrating the portion's effective font height value changing after setting local font height values on different presentation structure levels. 

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}
### **Get Effective Fill Format for Table**
Using Aspose.Slides for C++, you can get effective fill formatting for different table logic parts. For this purpose, the **IFillFormatEffectiveData** interface has been added in Aspose.Slides which contains effective fill formatting properties. Please note that cell formatting always has higher priority than row formatting, a row has higher priority than column and column higher that whole table. 

So finally **CellFormatEffectiveData** properties always used to draw the table. The following code sample shows how to get effective fill formatting for different table logic parts.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}


