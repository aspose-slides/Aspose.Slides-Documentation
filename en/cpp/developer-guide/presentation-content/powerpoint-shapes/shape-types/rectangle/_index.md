---
title: Add Rectangles to Presentations in C++
linktitle: Rectangle
type: docs
weight: 80
url: /cpp/rectangle/
keywords:
- add rectangle
- create rectangle
- rectangle shape
- simple rectangle
- formatted rectangle
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Boost your PowerPoint presentations by adding rectangles with Aspose.Slides for C++ — easily design and modify shapes programmatically."
---


## **Create Simple Rectangle**
Like previous topics, this one is also about adding a shape and this time the shape we will discuss about is Rectangle. In this topic, we have described that how developers can add simple or formatted rectangles to their slides using Aspose.Slides for C++ . To add a simple rectangle to a selected slide of the presentation, please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Obtain the reference of a slide by using its Index.
1. Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a simple rectangle to the first slide of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Create Formatted Rectangle**
To add a formatted rectangle to a slide, please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Obtain the reference of a slide by using its Index.
1. Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
1. Set the Fill Type of the Rectangle to Solid.
1. Set the Color of the Rectangle using SolidFillColor.Color property as exposed by FillFormat object associated with the IShape object.
1. Set the Color of the lines of the Rectangle.
1. Set the Width of the lines of the Rectangle.
1. Write the modified presentation as PPTX file.
   The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}