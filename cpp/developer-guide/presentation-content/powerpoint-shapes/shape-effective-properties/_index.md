---
title: Shape Effective Properties
type: docs
weight: 40
url: /cpp/shape-effective-properties/
---


In this topic, we will discuss **effective** and **local** properties. When we set values directly at these levels

1. In portion properties on portion's slide.
1. In prototype shape text style on layout or master slide (if portion's text frame shape has one).
1. In presentation global text settings.

then those values are called **local** values. At any level, **local** values could be defined or omitted. But finally when it comes to the moment when the application needs to know what the portion should look like it uses **effective** values. You can get effective values by using **GetEffective()** method from the local format.

The following example shows how to get effective values.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}


## **Get Effective Properties of Camera**
Aspose.Slides for C++ allows developers to get effective properties of the camera. For this purpose, the **CameraEffectiveData** class has been added in Aspose.Slides. CameraEffectiveData class represents an immutable object which contains effective camera properties. An instance of **CameraEffectiveData** class is used as part of **ThreeDFormatEffectiveData** class which is an effective values pair for ThreeDFormat class.

The following code sample shows how to get effective properties for the camera.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Get Effective Properties of Light Rig**
Aspose.Slides for C++ allows developers to get effective properties of Light Rig. For this purpose, the **LightRigEffectiveData** class has been added in Aspose.Slides. LightRigEffectiveData class represents an immutable object which contains effective light rig properties. An instance of **LightRigEffectiveData** class is used as part of **ThreeDFormatEffectiveData** class which is an effective values pair for ThreeDFormat class.

The following code sample shows how to get effective properties for the Light Rig.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Get Effective Properties of Bevel Shape**
Aspose.Slides for C++ allows developers to get effective properties of Bevel Shape. For this purpose, the **ShapeBevelEffectiveData** class has been added in Aspose.Slides. ShapeBevelEffectiveData class represents an immutable object which contains effective shape's face relief properties. An instance of **ShapeBevelEffectiveData** class is used as part of **ThreeDFormatEffectiveData** class which is an effective values pair for ThreeDFormat class.

The following code sample shows how to get effective properties for the Bevel Shape.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Get Effective Properties of Text Frame**
Using Aspose.Slides for C++, you can get effective properties of Text Frame. For this purpose, the **TextFrameFormatEffectiveData** class has been added in Aspose.Slides which contains effective text frame formatting properties. 

The following code sample shows how to get effective text frame formatting properties.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Get Effective Properties of Text Style**
Using Aspose.Slides for C++, you can get effective properties of Text Style. For this purpose, the **TextStyleEffectiveData** class has been added in Aspose.Slides which contains effective text style properties. 

The following code sample shows how to get effective text style properties.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Get Effective Font Height Value**
Using Aspose.Slides for C++, you can get effective properties of Font Height.  Here is the code demonstrating the portion's effective font height value changing after setting local font height values on different presentation structure levels. 

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Get Effective Fill Format for Table**
Using Aspose.Slides for C++, you can get effective fill formatting for different table logic parts. For this purpose, the **IFillFormatEffectiveData** interface has been added in Aspose.Slides which contains effective fill formatting properties. Please note that cell formatting always has higher priority than row formatting, a row has higher priority than column and column higher that whole table. 

So finally **CellFormatEffectiveData** properties always used to draw the table. The following code sample shows how to get effective fill formatting for different table logic parts.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}


