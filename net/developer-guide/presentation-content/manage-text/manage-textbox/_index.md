---
title: Manage TextBox
type: docs
weight: 20
url: /net/manage-textbox/
---

## **Create TextBox on Slide**
Using Aspose.Slides for .NET, developers can create TextBox on a Slide in the Presentation. All you have to do is to add an AutoShape of Rectangle type and call the AddTextFrame method exposed by AutoShapeEX object. Please follow the steps below to create TextBox by using Aspose.Slides for .NET API:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of the first slide in the presentation which is created on the instantiation of Presentation.
- Add an [IAutoShape](https://apireference.aspose.com/net/slides/aspose.slides/iautoshape) with [ShapeType](https://apireference.aspose.com/net/slides/aspose.slides/igeometryshape/properties/shapetype) as Rectangle at a specified position of the slide and obtain the reference of that newly added IAutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Finally, write the [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file using the Presentation object.

The implementation of the above steps is demonstrated below in an example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cs" >}}
## **Add Column In TextBoxes**
Using Aspose.Slides for .NET, developers can add column in text boxes on a Slide in the Presentation, property ColumnCount and ColumnSpacing has been added to [ITextFrameFormat ](https://apireference.aspose.com/net/slides/aspose.slides/itextframeformat)interface and [TextFrameFormat](https://apireference.aspose.com/net/slides/aspose.slides/textframeformat) class respectively. These properties specify the number of columns in the textbox and set an amount of spacing in points between columns.

The implementation is demonstrated below in an example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-AddColumnInTexBoxes-AddColumnInTexBoxes.cs" >}}
## **Add Columns In Text Frame**
Using Aspose.Slides for .NET, developers can add columns in text frames on a Slide in the Presentation. **ColumnCount** property has been added to **[ITextFrameFormat](https://apireference.aspose.com/net/slides/aspose.slides/itextframeformat)** interface. This property specifies the number of columns in the text frame.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Text-AddColumnsinTextFrame-AddColumnsinTextFrame.cs" >}}

## **Create TextBox with Hyperlink**
In this topic, we will create a TextBox with a Hyperlink. You will have to instantiate [IHyperlinkManager](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkmanager) class and assign it to the desired portion of the TextFrame associated with the TextBox. Please follow the steps below to create a TextBox with Hyperlink by using Aspose.Slides for .NET API:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of the first slide in the presentation which is created on instantiation of Presentation.
- Add an AutoShape with ShapeType as Rectangle at a specified position of the slide and obtain the reference of that newly added AutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Instantiate the IHyperlinkManager class.
- Assign the IHyperlinkManager object to the HLinkClick property associated with the desired portion of the TextFrame.
- Finally, write the PPTX file using the Presentation object.

The implementation of the above steps is demonstrated below in an example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-TextBoxHyperlink-TextBoxHyperlink.cs" >}}

