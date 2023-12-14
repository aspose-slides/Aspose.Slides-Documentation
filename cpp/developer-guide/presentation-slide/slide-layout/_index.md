---
title: Slide Layout
type: docs
weight: 60
url: /cpp/slide-layout/
keyword: "Set slide size, set slide options, specify slide size, Footer visibility, Child footer, Content scaling, page size, C++, CPP, Aspose.Slides"
description: "Set PowerPoint slide size and options in C++"
---

A slide layout contains the placeholder boxes and formatting information for all the content that appears on a slide. The layout determines the available content placeholders and where they are placed. 

Slide layouts allow you to create and design presentations quickly (whether simple or complex). These are some of the most popular slide layouts used in PowerPoint presentations: 

* **Title Slide layout**. This layout consists of two text placeholders. One placeholder is for the title and the other is for the subtitle. 
* **Title and Content layout**. This layout contains a relatively small placeholder at the top for the title and a bigger placeholder for the core content (chart, paragraphs, bullet list, numbered list, images, etc).
* **Blank layout**. This layout lacks placeholders, so it allows you to create elements from scratch. 

Since a slide master is the top hierarchical slide that stores information about slide layouts, you can use the master slide to access slide layouts and make changes to them. A layout slide can be accessed by type or name. Similarly, every slide has a unique id, which can be used to access it. 

Alternatively, you can make changes directly to a specific slide layout in a presentation. 

* To allow you to work with slide layouts (including those in master slides), Aspose.Slides provides properties like [get_LayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) and [get_Masters()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) under the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class. 
* To perform related tasks, Aspose.Slides provides [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/baseslideheaderfootermanager/), and many other types. 

For more information on working with Master Slides in particular, see the [Slide Master](https://docs.aspose.com/slides/cpp/slide-master/) article.

## **Add Slide Layout to Presentation**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Access the [MasterSlide collection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Go through the existing layout slides to confirm that the required layout slide already exists in the Layout Slide collection. Otherwise, add the Layout slide you want. 
1. Add an empty slide based on the new layout slide.
1. Save the presentation. 

This C++ code shows you how to add a slide layout to a PowerPoint presentation:

```c++
	// The path to the documents directory.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/AddLayoutSlides.pptx";

	// Instantiates a Presentation class that represents the presentation file
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	// Goes through layout slide types
	SharedPtr<IMasterLayoutSlideCollection> layoutSlides = pres->get_Masters()->idx_get(0)->get_LayoutSlides();


	SharedPtr<ILayoutSlide> layoutSlide;
	if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
	}
	else if (layoutSlides->GetByType(SlideLayoutType::Title) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
	}

	if (layoutSlide == NULL)
	{
		// The situation where a presentation doesn't contain some layout types.
		// presentation File only contains Blank and Custom layout types.
		// But layout slides with Custom types have different slide names,
		// like "Title", "Title and Content", etc. And it is possible to use these
		// names for layout slide selection.
		// You can also use a set of placeholder shape types. For example,
		// Title slide should have only Title pleceholder type, etc.

		for (int i = 0; i<layoutSlides->get_Count(); i++)
		{
			SharedPtr<ILayoutSlide> titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

			if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
			{
				layoutSlide = titleAndObjectLayoutSlide;
				break;
			}
		}

		if (layoutSlide == NULL)
		{
			for (int i = 0; i < layoutSlides->get_Count(); i++)
			{
				SharedPtr<ILayoutSlide> titleLayoutSlide = layoutSlides->idx_get(i);

				if (titleLayoutSlide->get_Name().Equals(u"Title"))
				{
					layoutSlide = titleLayoutSlide;
					break;
				}
			}

			if (layoutSlide == NULL)
			{
				layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
				if (layoutSlide == NULL)
				{
					layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
				}
			}
		}
	}

	// Adds empty slide with added layout slide  
	pres->get_Slides()->InsertEmptySlide(0, layoutSlide);

	// Saves the presentation 
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Remove Unused Layout Slide**

Aspose.Slides provides the [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) method from the [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) class to allow you to delete unwanted and unused layout slides. This C++ code shows you how to remove a layout slide from a PowerPoint presentation:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);

```


## **Set Size and Type for Slide Layout**

To allow you to set the size and type for a specific layout slide, Aspose.Slides provides the [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) and [get_Size()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_size/) properties (from the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class). This C++ demonstrates the operation:

```c++
	// The path to the documents directory.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/CloneToAnotherPresentationWithSetSizeAndType.pptx";
	// Instantiates a Presentation object that represents a presentation file
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	SharedPtr<Presentation> destPres = MakeObject<Presentation>();

	// Accesses Slide by ID from collection
	SharedPtr<ISlideCollection> slideCollection = destPres->get_Slides();
	
	// Sets the slide size for the generated presentation to that of the source
	destPres->get_SlideSize()->SetSize(pres->get_SlideSize()->get_Type(), Aspose::Slides::SlideSizeScaleType::DoNotScale);

	
	slideCollection->InsertClone(1, pres->get_Slides()->idx_get(0));

	// Saves presentation
	destPres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Set Footer Visibility Inside Slide**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Set the slide footer placeholder to visible. 
1. Set the date-time placeholder to visible. 
1. Save the presentation. 

This C++ code shows you how to set the visibility for a slide footer (and perform related tasks):

```c++
 // The path to the documents directory.
const String outPath = u"../out/HeaderFooterManager_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Instantiates a SlideCollection class
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

//	SharedPtr<IBaseSlideHeaderFooterManager> headerFooterManager = presentation->get_Slides()->idx_get(0)->get_HeaderFooterManager();
SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
if (!headerFooterManager->get_IsFooterVisible()) // Property IsFooterVisible is used to specify that a slide footer placeholder is missing
{
	headerFooterManager->SetFooterVisibility(true); // Method SetFooterVisibility is used to set a slide footer placeholder to visible
}
if (!headerFooterManager->get_IsSlideNumberVisible()) // Property IsSlideNumberVisible is used to specify that a slide page number placeholder is missing
{
	headerFooterManager->SetSlideNumberVisibility(true); // Method SetSlideNumberVisibility is used to set a slide page number placeholder to visible
}
if (!headerFooterManager->get_IsDateTimeVisible()) // Property IsDateTimeVisible is used to specify that a slide date-time placeholder is missing
{
	headerFooterManager->SetDateTimeVisibility(true); // Method SetFooterVisibility is used to set a slide date-time placeholder to visible
}


headerFooterManager->SetFooterText(u"Footer text"); // Method SetFooterText is used to set a text for a slide footer placeholder
headerFooterManager->SetDateTimeText(u"Date and time text"); // Method SetDateTimeText is used to set a text for a slide date-time placeholder.



presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Set Child Footer Visibility Inside Slide**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Get a reference for the master slide through its index. 
1. Set the master slide and all child footer placeholders to visible.
1. Set a text for the master slide and all child footer placeholders. 
1. Set a text for the master slide and all child date-time placeholders. 
1. Save the presentation. 

This C++ code demonstrates the operation:

```c++
// The path to the documents directory.
const String outPath = u"../out/SetChildFooter_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Instantiates a SlideCollection class
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true); // Method SetFooterAndChildFootersVisibility is used to set the master slide and all child footer placeholders to visible
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true); // Method SetSlideNumberAndChildSlideNumbersVisibility is used to set the master slide and all child page number placeholders to visible
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true); // Method SetDateTimeAndChildDateTimesVisibility is used to set a master slide and all child date-time placeholders to visible

headerFooterManager->SetFooterAndChildFootersText(u"Footer text"); // Method SetFooterAndChildFootersText is used to set texts for the master slide and all child footer placeholders
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text"); // Method SetDateTimeAndChildDateTimesText is used to set text for the master slide and all child date-time placeholders

presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Set Slide Size with Respect to Content Scaling**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class and load the presentation containing the slide whose size you want to set. 
1. Create another instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class to generate a new presentation. 
1. Get the slide's reference (from the first presentation) through its index.
1. Set the slide footer placeholder to visible. 
1. Set the date-time placeholder to visible. 
1. Save the presentation. 

This C++ code demonstrates the operation: 

```c++
// The path to the documents directory.
const String templatePath = u"../templates/AccessSlides.pptx";
const String outPath = u"../out/SetSlideSizeScale_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);
SharedPtr<Presentation> auxPresentation = MakeObject<Presentation>();

// Instantiates a SlideCollection class
SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

// Sets the slide size for the generated presentations to that of the source
auxPresentation->get_SlideSize()->SetSize(540, 720, SlideSizeScaleType::EnsureFit); // Method SetSize is used to set slide size with scale content to ensure fit
auxPresentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize); // Method SetSize is used to set slide size with maximum size of content

auxPresentation->get_Slides()->InsertClone(0, slide);
auxPresentation->get_Slides()->RemoveAt(0);

// Saves presentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Set Page Size when Generating PDF**

Certain presentations (like posters) are often converted to PDF docs. If you are looking to convert your PowerPoint to PDF to access the best printing and accessibility options, you want to set your slides to sizes that suit PDF documents (A4, for example).

Aspose.Slides provides the [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/) class to allow you to specify your preferred settings for slides. This C++ code shows you how to use the [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) property (from the `SlideSize` class) to set a specific paper size for the slides in a presentation:

```c++
// The path to the documents directory.
	const String outPath = u"../out/SetPDFPageSize_out.pptx";

	// Instantiates a Presentation object that represents a presentation file 
	SharedPtr<Presentation>pres = MakeObject<Presentation>();


	// Sets the SlideSize.Type Property
	pres->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);


	// Sets different properties of PDF Options
	Aspose::Slides::Export::PdfOptions opts = Aspose::Slides::Export::PdfOptions();
	opts.set_SufficientResolution (600);

	// Saves presentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pdf, &opts);
```
