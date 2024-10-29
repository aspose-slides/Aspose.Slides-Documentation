---
title: Line
type: docs
weight: 50
url: /cpp/Line/
---

## **Create Plain Line**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [AddAutoShape](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index) method exposed by Shapes object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **Create Arrow Shaped Line**
Aspose.Slides for C++ also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object.
- Set the Line Style to one of the styles as offered by Aspose.Slides for C++.
- Set the Width of the line.
- Set the [Dash Style](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle) of the line to one of the styles offered by Aspose.Slides for C++.
- Set the [Arrow Head Style](http://www.aspose.com/api/net/slides/aspose.slides/lineformat) and Length of the start point of the line.
- Set the Arrow Head Style and Length of the end point of the line.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}