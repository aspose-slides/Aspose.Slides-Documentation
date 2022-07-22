---
title: Extract Text from Presentation
type: docs
weight: 90
url: /cpp/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

It's not uncommon that developers need to extract the text from a presentation. To do so, you need to extract text from all the shapes on all the slides in a presentation. This article explains how to extract text from Microsoft PowerPoint PPTX presentations using Aspose.Slides. Text can be extracted in following ways:

- [Extracting text from one slide](/slides/cpp/extracting-text-from-the-presentation/)
- [Extracting text using GetAllTextBoxes method](/slides/cpp/extracting-text-from-the-presentation/)
- [Categorized and fast extraction of text](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extract Text from Slide**
Aspose.Slides for C++ provides the Aspose.Slides.Util namespace which includes the SlideUtil class. This class exposes a number of overloaded static methods for extracting the entire text from a presentation or slide. To extract the text from a slide in a PPTX presentation, 
use the [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) overloaded static method exposed by the SlideUtil class. This method accepts the Slide object as a parameter.
Upon execution, the Slide method scans the entire text from the slide passed as parameter and returns an array of TextFrame objects. This means that any text formatting associated with the text is available. The following piece of code extracts all the text on the first slide of the presentation:

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

// Instatiate Presentation class that represents a PPTX file
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Get an Array of ITextFrame objects from all slides in the PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Loop through the Array of TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Loop through paragraphs in current ITextFrame
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Loop through portions in the current IParagraph
		for (const auto& port : para->get_Portions())
		{
			// Display text in the current portion
			Console::WriteLine(port->get_Text());

			// Display font height of the text
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Display font name of the text
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **Extract Text from Presentation**
To scan the text from the whole presentation, use the
 [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) static method exposed by the SlideUtil class. It takes two parameters:

1. First, a Presentation object that represents the PPTX presentation the text is being extracted from.
1. Second, a Boolean value determining whether the master slide is to be included when the text is scanned from the presentation.
   The method returns an array of TextFrame objects, complete with text formatting information. The code below scans the text and formatting information from a presentation, including the master slides.

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

// Instatiate Presentation class that represents a PPTX file
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Get an Array of ITextFrame objects from all slides in the PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Loop through the Array of TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Loop through paragraphs in current ITextFrame
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Loop through portions in the current IParagraph
		for (const auto& port : para->get_Portions())
		{
			// Display text in the current portion
			Console::WriteLine(port->get_Text());

			// Display font height of the text
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Display font name of the text
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **Categorized and Fast Text Extraction**
The new static method GetPresentationText has been added to Presentation class. There are two overloads for this method:

``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```

The TextExtractionArrangingMode enum argument indicates the mode to organize the output of text result and can be set to the following values:  
Unarranged - The raw text with no respect to position on the slide  
Arranged - The text is positioned in the same order as on the slide

Unarranged mode can be used when speed is critical, it's faster than Arranged mode.

PresentationText represents the raw text extracted from the presentation. It contains a get_SlidesText() method from Aspose.Slides.Util namespace which returns an array of ISlideText objects. Every object represent the text on the corresponding slide. ISlideText object have the following methods:

get_Text() - The text on the slide's shapes.  
get_MasterText() - The text on the master page's shapes for this slide.  
get_LayoutText() - The text on the layout page's shapes for this slide.  
get_NotesText() - The text on the notes page's shapes for this slide.

There is also a SlideText class which implements the ISlideText interface.

The new API can be used like this:

``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```
