---
title: Access Presentation Slides in C++
linktitle: Access Slide
type: docs
weight: 20
url: /cpp/access-slide-in-presentation/
keywords:
- access slide
- slide index
- slide id
- slide position
- change position
- slide properties
- slide number
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Learn how to access and manage slides in PowerPoint and OpenDocument presentations with Aspose.Slides for C++. Boost productivity with code examples."
---

Aspose.Slides allows you to access slides in two ways: by index and by ID.

## **Access a Slide by Index**

All slides in a presentation are arranged numerically based on the slide position starting from 0. The first slide is accessible through index 0; the second slide is accessed through index 1; etc.

The Presentation class, representing a presentation file, exposes all slides as an [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) collection (collection of [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) objects). This C++ code shows you how to access a slide through its index: 

```c++
	// The path to the documents directory.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instantiates the Presentation class
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Get a slide's reference through its index
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Access a Slide by ID**

Each slide in a presentation has a unique ID associated with it. You can use the [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) method (exposed by the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class) to target that ID. This C++ code shows you how to provide a valid slide ID and access that slide through the [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) method:

```c++
	// The path to the documents directory.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instantiates the Presentation class
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Gets a slide ID
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Accesses the slide through its ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Change Slide Position**

Aspose.Slides allow you to change a slide position. For example, you can specify that the first slide should become the second slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Get the slide's reference (whose position you want to change) through its index
1. Set a new position for the slide through the [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/) property. 
1. Save the modified presentation.

This C++ code demonstrates an operation in which the slide in position 1 is moved to position 2:

```c++
	// The path to the documents directory.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instantiates the Presentation class
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Gets the slide whose position will be changed
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Sets the new position for the slide
	slide->set_SlideNumber(2);

	// Saves the modified presentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

The first slide became the second; the second slide became the first. When you change a slide's position, other slides are automatically adjusted.


## **Set the Slide Number**

Using the [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) property (exposed by the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class), you can specify a new number for the first slide in a presentation. This operation causes other slide numbers to be recalculated.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Get the slide number.
1. Set the slide number.
1. Save the modified presentation.

This C++ code demonstrates an operation where the first slide number is set to 10: 

```c++
	// The path to the documents directory.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instantiates the Presentation class
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Gets the slide number
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Sets the slide number
	pres->set_FirstSlideNumber(2);
	
	// Saves the modified presentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

If you prefer to skip the first slide, you can start the numbering from the second slide (and hide the numbering for the first slide) this way:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Does the slide number a user sees match the collection’s zero-based index?**

The number shown on a slide can start from an arbitrary value (e.g., 10) and does not have to match the index; the relationship is controlled by the presentation’s [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) setting.

**Do hidden slides affect indexing?**

Yes. A hidden slide remains in the collection and is counted in indexing; "hidden" refers to display, not its position in the collection.

**Does a slide’s index change when other slides are added or removed?**

Yes. Indexes always reflect the current order in slides and are recalculated upon insert, delete, and move operations.
