---
title: Manage Text Boxes in Presentations Using C++
linktitle: Manage Text Box
type: docs
weight: 20
url: /cpp/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- create text box
- check text box
- add text column
- add hyperlink
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ makes it easy to create, edit, and clone text boxes in PowerPoint and OpenDocument files, enhancing your presentation automation."
---

Texts on slides typically exist in text boxes or shapes. Therefore, to add a text to a slide, you have to add a text box and then put some text inside the textbox. Aspose.Slides for C++ provides the [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) interface that allows you to add a shape containing some text.

{{% alert title="Info" color="info" %}}

Aspose.Slides also provides the [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) interface that allows you to add shapes to slides. However, not all shapes added through the `IShape` interface can hold text. But shapes added through the [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) interface may contain text. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Therefore, when dealing with a shape to which you want to add text, you may want to check and confirm that it was cast through the `IAutoShape` interface. Only then will you be able to work with [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame), which is a property under `IAutoShape`. See the [Update Text](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) section on this page. 

{{% /alert %}}

## **Create a Text Box on a Slide**

To create a textbox on a slide, go through these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class. 
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) object with [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) set as `Rectangle` at a specified position on the slide and obtain the reference for the newly added `IAutoShape` object. 
4. Add a `TextFrame` property to the `IAutoShape` object that will contain a text. In the example below, we added this text: *Aspose TextBox*
5. Finally, write the PPTX file through the `Presentation` object. 

This C++ code—an implementation of the steps above—shows you how to add text to a slide:

```cpp
// Instantiates Presentation
auto pres = System::MakeObject<Presentation>();

// Gets the first slide in the presentation
auto sld = pres->get_Slides()->idx_get(0);

// Adds an AutoShape with type set as Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Adds TextFrame to the Rectangle
ashp->AddTextFrame(u" ");

// Accesses the text frame
auto txtFrame = ashp->get_TextFrame();

// Creates the Paragraph object for text frame
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Creates a Portion object for paragraph
auto portion = para->get_Portions()->idx_get(0);

// Sets Text
portion->set_Text(u"Aspose TextBox");

// Saves the presentation to disk
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Check for a Text Box Shape**

Aspose.Slides provides the [get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) method from the [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) interface, allowing you to examine shapes and identify text boxes.

![Text box and shape](istextbox.png)

This C++ code shows you how to check whether a shape was created as a text box: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Note that if you simply add an autoshape using the `AddAutoShape` method from the [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) interface, the `get_IsTextBox` method of the autoshape will return `false`. However, after you add text to the autoshape using the `AddTextFrame` method or the `set_Text` method, the `get_IsTextBox` method returns `true`.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() returns false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() returns true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() returns false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() returns true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() returns false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() returns false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() returns false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() returns false
```

## **Add Columns to a Text Box**

Aspose.Slides provides the [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) and [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) methods (from the [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) interface and [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) class) that allow you to add columns to textboxes. You get to specify the number of columns in a text box and set the amount spacing in points between columns. 

This code in C++ demonstrates the described operation: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Gets the first slide in the presentation
auto slide = presentation->get_Slides()->idx_get(0);

// Add an AutoShape with type set as Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Add TextFrame to the Rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Gets the text format of TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Specifies the number of columns in TextFrame
format->set_ColumnCount(3);

// Specifies the spacing between columns
format->set_ColumnSpacing(10);

// Saves the presentation
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **Add Columns to a Text Frame**
Aspose.Slides for C++ provides the [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) method (from the [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) interface) that allows you to add columns in text frames. Through this method, you can specify your preferred number of columns in a text frame. 

This C++ code shows you how to add a column inside a text frame:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Update Text**

Aspose.Slides allows you to change or update the text contained in a text box or all the texts contained in a presentation. 

This C++ code demonstrates an operation where all the texts in a presentation are updated or changed:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Changes text
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Changes formatting
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Saves modified presentation
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Add a Text Box with a Hyperlink** 

You can insert a link inside a text box. When the text box is clicked, users are directed to open the link. 

 To add a text box containing a link, go through these steps:

1. Create an instance of the `Presentation` class. 
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an `AutoShape` object with `ShapeType` set as `Rectangle` at a specified position on the slide and obtain a reference of the newly added AutoShape object.
4. Add a `TextFrame` to the `AutoShape` object that contains *Aspose TextBox* as its default text. 
5. Instantiate the `IHyperlinkManager` class. 
6. Assign the `IHyperlinkManager` object to the [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) method associated with your preferred portion of the `TextFrame`. 
7. Finally, write the PPTX file through the `Presentation` object. 

This C++ code—an implementation of the steps above—shows you how to add a text box with a hyperlink to a slide:

```cpp
// Instantiates a Presentation class that represents a PPTX
auto presentation = System::MakeObject<Presentation>();

// Gets the first slide in the presentation
auto slide = presentation->get_Slides()->idx_get(0);

// Adds an AutoShape object with type set as Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Casts the shape to AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Accesses the ITextFrame property associated with the AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Adds some text to the frame
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Sets the Hyperlink for the portion text
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Saves the PPTX Presentation
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**What’s the difference between a text box and a text placeholder when working with master slides?**

A [placeholder](/slides/cpp/manage-placeholder/) inherits style/position from the [master](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) and can be overridden on [layouts](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/), whereas a regular text box is an independent object on a specific slide and doesn’t change when you switch layouts.

**How can I perform a bulk text replacement across the presentation without touching text inside charts, tables, and SmartArt?**

Limit your iteration to auto-shapes that have text frames and exclude embedded objects ([charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) by traversing their collections separately or skipping those object types.
