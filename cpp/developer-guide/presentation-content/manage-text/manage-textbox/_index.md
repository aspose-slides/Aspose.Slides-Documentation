---
title: Manage TextBox
type: docs
weight: 20
url: /cpp/manage-textbox/
---


## **Create TextBox**
Using Aspose.Slides for C++, developers can create TextBox on a Slide in the Presentation. All you have to do is to add an AutoShape of Rectangle type and call the AddTextFrame method exposed by AutoShapeEX object. Please follow the steps below to create TextBox by using Aspose.Slides for C++ API:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
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

## **Create TextBox with Hyperlink**
In this topic, we will create a TextBox with a Hyperlink. You will have to instantiate [IHyperlinkManager](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_manager) class and assign it to the desired portion of the TextFrame associated with the TextBox. Please follow the steps below to create a TextBox with Hyperlink by using Aspose.Slides for C++ API:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Obtain the reference of the first slide in the presentation which is created on instantiation of Presentation.
- Add an AutoShape with ShapeType as Rectangle at a specified position of the slide and obtain the reference of that newly added AutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Instantiate the IHyperlinkManager class.
- Assign the IHyperlinkManager object to the SetExternalHyperlinkClick method associated with the desired portion of the TextFrame.
- Finally, write the PPTX file using the Presentation object.

The implementation of the above steps is demonstrated below in an example.

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

// Create directory if it is not already present.
bool IsExists = Directory::Exists(dataDir);
if (!IsExists)
{
    Directory::CreateDirectory_(dataDir);
}

// Instantiate a Presentation class that represents a PPTX
auto pptxPresentation = System::MakeObject<Presentation>();

// Get first slide
auto slide = pptxPresentation->get_Slides()->idx_get(0);

// Add an AutoShape of Rectangle Type
auto pptxShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Cast the shape to AutoShape
auto pptxAutoShape = System::DynamicCast<IAutoShape>(pptxShape);

// Access ITextFrame associated with the AutoShape
pptxAutoShape->AddTextFrame(u"");

auto ITextFrame = pptxAutoShape->get_TextFrame();

// Add some text to the frame
ITextFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Set Hyperlink for the portion text
System::SharedPtr<IHyperlinkManager> HypMan = ITextFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
HypMan->SetExternalHyperlinkClick(u"http://www.aspose.com");
// Save the PPTX Presentation
pptxPresentation->Save(dataDir + u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```
