---
title: Hello World Application using Aspose.Slides
type: docs
weight: 80
url: /cpp/hello-world-application-using-aspose-slides/
---

## **Steps to Create Hello World Application**
In this simple application, we will create a PowerPoint presentation having **Hello World** text at a specified position of the slide.. Please follow the steps below to create **Hello World** application by using Aspose.Slides for C++ API:

- Create an instance of Presentation class
- Obtain the reference of the first slide in the presentation which is created on instantiation of Presentation.
- Add an AutoShape with ShapeType as Rectangle at a specified position of the slide.
- Add a TextFrame to the AutoShape containing Hello World as default text
- Change the Text Color to Black as it is white by default and is not visible on the slide with white background
- Change the Line Color of the shape to white in order to hide the shape border
- Remove the default Fill Format of the shape
- Finally, write the presentation to desired file format using the Presentation object

The implementation of above steps is demonstrated below in an example.
#### **C#**
{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SampleApplication.cs" >}}
#### **C++**
{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-VisualBasic-SampleApplication.vb" >}}
