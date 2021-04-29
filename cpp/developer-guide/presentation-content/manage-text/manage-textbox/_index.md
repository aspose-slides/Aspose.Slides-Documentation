---
title: Manage TextBox
type: docs
weight: 20
url: /cpp/manage-textbox/
---


## **Create TextBox**
Using Aspose.Slides for C++, developers can create TextBox on a Slide in the Presentation. All you have to do is to add an AutoShape of Rectangle type and call the AddTextFrame method exposed by AutoShapeEX object. Please follow the steps below to create TextBox by using Aspose.Slides for C++ API:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of the first slide in the presentation which is created on the instantiation of Presentation.
- Add an IAutoShape with ShapeType as Rectangle at a specified position of the slide and obtain the reference of that newly added IAutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Finally, write the PPTX file using the Presentation object.

The implementation of above steps is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}


## **Add Column to TextBox**
Using Aspose.Slides for C++, developers can add column in text boxes on a Slide in the Presentation, property ColumnCount and ColumnSpacing has been added to ITextFrameFormat interface and TextFrameFormat class respectively. These properties specify the number of columns in the textbox and set an amount of spacing in points between columns.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColumnInTexBoxes-AddColumnInTexBoxes.cpp" >}}



## **Add Column to TextFrame**
Using Aspose.Slides for C++, developers can add columns in text frames on a Slide in the Presentation. **ColumnCount** property has been added to **ITextFrameFormat** interface. This property specifies the number of columns in the text frame.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColumnsinTextFrame-AddColumnsinTextFrame.cpp" >}}

