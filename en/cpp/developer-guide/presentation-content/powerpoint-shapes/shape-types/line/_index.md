---
title: Add Line Shapes to Presentations in C++
linktitle: Line
type: docs
weight: 50
url: /cpp/line/
keywords:
- line
- create line
- add line
- plain line
- configure line
- customize line
- dash style
- arrow head
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn to manipulate line formatting in PowerPoint presentations with Aspose.Slides for C++. Discover properties, methods, and examples."
---

## **Create a Plain Line**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) method exposed by Shapes object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **Create an Arrow-Shaped Line**
Aspose.Slides for C++ also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object.
- Set the Line Style to one of the styles as offered by Aspose.Slides for C++.
- Set the Width of the line.
- Set the [Dash Style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) of the line to one of the styles offered by Aspose.Slides for C++.
- Set the [Arrow Head Style](https://reference.aspose.com/slides/cpp/aspose.slides/lineformat/) and Length of the start point of the line.
- Set the Arrow Head Style and Length of the end point of the line.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/cpp/aspose.slides/connector/) type and the [corresponding APIs](/slides/cpp/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/cpp/shape-effective-properties/) through the [ILineFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformateffectivedata/) interfaces—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/get_autoshapelock/) that let you [disallow editing operations](/slides/cpp/applying-protection-to-presentation/).
