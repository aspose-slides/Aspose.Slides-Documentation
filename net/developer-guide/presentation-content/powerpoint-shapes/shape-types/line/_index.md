---
title: Line
type: docs
weight: 10
url: /net/Line/
---

Aspose.Slides for .NET supports adding different kinds of shapes to the slides. In this topic, we will start working with shapes by adding lines to the slides. Using Aspose.Slides for .NET, developers can not only create simple lines , but some fancy lines can also be drawn on the slides.
## **Create Plain Line**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [AddAutoShape](https://apireference.aspose.com/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index) method exposed by Shapes object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddPlainLineToSlide-AddPlainLineToSlide.cs" >}}
## **Create Arrow Shaped Line**
Aspose.Slides for .NET also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object.
- Set the Line Style to one of the styles as offered by Aspose.Slides for .NET.
- Set the Width of the line.
- Set the [Dash Style](https://apireference.aspose.com/net/slides/aspose.slides/linedashstyle) of the line to one of the styles offered by Aspose.Slides for .NET.
- Set the [Arrow Head Style](https://apireference.aspose.com/net/slides/aspose.slides/linearrowheadstyle) and Length of the start point of the line.
- Set the Arrow Head Style and Length of the end point of the line.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cs" >}}
