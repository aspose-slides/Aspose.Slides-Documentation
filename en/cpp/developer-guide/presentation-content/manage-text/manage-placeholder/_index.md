---
title: Manage Placeholder
type: docs
weight: 10
url: /cpp/manage-placeholder/
keywords: "Placeholder, Placeholder text, Prompt text, PowerPoint presentation, C++, CPP, Aspose.Slides for C++"
description: "Change Placeholder text and prompt text in PowerPoint presentations in C++"
---

## **Change Text in Placeholder**
Using [Aspose.Slides for C++](/slides/cpp/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Prerequisite**: You need a presentation that contains a placeholder. You can create such a presentation in the standard Microsoft PowerPoint app.

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. Instantiate the [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class and pass the presentation as an argument.
2. Get a slide reference through its index.
3. Iterate through the shapes to find the placeholder.
4. Typecast the placeholder shape to an [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) and change the text using the [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) associated with the [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/).
5. Save the modified presentation.

This C++ code shows how to change the text in a placeholder:

```c++
// The path to the documents directory.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Loads the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accesses the first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Accesses the first and second placeholder in the slide and typecasts it as an AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Saves the presentation to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Set Prompt Text in Placeholder**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

This C++ code shows you how to set the prompt text in a placeholder:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // When there is no text in it, PowerPoint displays "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Does the same thing for subtitle.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Set Placeholder Image Transparency**

Aspose.Slides allows you to set the transparency of the background image in a text placeholder. By adjusting the transparency of the picture in such a frame, you can make the text or the image stand out (depending on the text's and picture's colors).

This C++ code shows you how to set the transparency for a picture background (inside a shape):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

