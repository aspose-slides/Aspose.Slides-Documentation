---
title: Presentation Header and Footer
type: docs
weight: 140
url: /cpp/presentation-header-and-footer/
keywords: "Header and footer in PowerPoint"
description: "Header and footer in PowerPoint with Aspose.Slides."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/cpp/) provides support to work with slide's headers and footers text that are actually maintained on Slide master level.

{{% /alert %}} 

[Aspose.Slides for C++](/slides/cpp/) provides the feature for managing headers and footers inside presentation slides. These are in fact managed on the presentation master level.
## **Manage Header and Footer Text**
Notes of some specific slide could be updated as shown in the example below:

``` cpp
// Function to set Header/Footer Text
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::DynamicCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Load Presentation
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Setting Footer
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Access and Update Header
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Save presentation
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Manage Header and Footer in Handout and Notes Slides**
Aspose.Slides for C++ supports Header and Footer in Handout and notes slides. Please follow the steps below:

- Load a [Presentation ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)containing a video.
- Change Header and Footer settings for notes master and all notes slides.
- Set master notes slide and all child Footer placeholders visible.
- Set master notes slide and all child Date and time placeholders visible.
- Change Header and Footer settings for first notes slide only.
- Set notes slide Header placeholder visible.
- Set text to notes slide Header placeholder.
- Set text to notes slide Date-time placeholder.
- Write the modified presentation file.

Code Snippet provided in the below Example.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Change Header and Footer settings for notes master and all notes slides
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// make the master notes slide and all child Footer placeholders visible
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// make the master notes slide and all child Header placeholders visible
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// make the master notes slide and all child SlideNumber placeholders visible
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// make the master notes slide and all child Date and time placeholders visible
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// set text to master notes slide and all child Header placeholders
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// set text to master notes slide and all child Footer placeholders
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// set text to master notes slide and all child Date and time placeholders
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Change Header and Footer settings for first notes slide only
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// make this notes slide Header placeholder visible
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// make this notes slide Footer placeholder visible
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// make this notes slide SlideNumber placeholder visible
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// make this notes slide Date-time placeholder visible
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// set text to notes slide Header placeholder
	headerFooterManager->SetHeaderText(u"New header text");
	// set text to notes slide Footer placeholder
	headerFooterManager->SetFooterText(u"New footer text");
	// set text to notes slide Date-time placeholder
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

