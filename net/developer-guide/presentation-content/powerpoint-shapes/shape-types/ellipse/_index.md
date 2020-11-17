---
title: Ellipse
type: docs
weight: 10
url: /net/ellipse/
---


## **Create Ellipse**
In this topic, we will introduce developers about adding ellipse shapes to their slides using Aspose.Slides for .NET . Aspose.Slides for .NET provides an easier set of APIs to draw different kinds of shapes with just a few lines of code. To add a simple ellipse to a selected slide of the presentation, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class
1. Obtain the reference of a slide by using its Index
1. Add an AutoShape of Ellipse type using AddAutoShape method exposed by IShapes object
1. Write the modified presentation as a PPTX file

In the example given below, we have added an ellipse to the first slide.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-SimpleEllipse-SimpleEllipse.cs" >}}

## **Create Formatted Ellipse**
To add a better formatted ellipse to a slide, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Ellipse type using AddAutoShape method exposed by IShapes object.
1. Set the Fill Type of the Ellipse to Solid.
1. Set the Color of the Ellipse using SolidFillColor.Color property as exposed by FillFormat object associated with the IShape object.
1. Set the Color of the lines of the Ellipse.
1. Set the Width of the lines of the Ellipse.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a formatted ellipse to the first slide of the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FormattedEllipse-FormattedEllipse.cs" >}}
