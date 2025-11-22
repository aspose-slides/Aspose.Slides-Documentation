---
title: Remove Slides from Presentations in C++
linktitle: Remove Slide
type: docs
weight: 30
url: /cpp/remove-slide-from-presentation/
keywords:
- remove slide
- delete slide
- remove unused slide
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Effortlessly remove slides from PowerPoint and OpenDocument presentations with Aspose.Slides for C++. Get clear code examples and boost your workflow."
---

If a slide (or its contents) becomes redundant, you can delete it. Aspose.Slides provides the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class that encapsulates [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/), which is a repository for all slides in a presentation. Using pointers (reference or index) for a known [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) object, you can specify the slide you want to remove. 

## **Remove Slide by Reference**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Get a reference of the slide you want to remove through its ID or Index.
1. Remove the referenced slide from the presentation.
1. Save the modified presentation. 

This C++ code shows you how to remove a slide through its reference: 

```c++
	// The path to the documents directory
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Instantiates a Presentation object that represents a presentation file
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Accesses a slide through its index in the slides collection
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Removes a slide through its reference
	pres->get_Slides()->Remove(slide);

	// Saves the modified presentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Remove Slide by Index**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Remove the slide from the presentation through its index position.
1. Save the modified presentation. 

This C++ code shows you how to remove a slide through its index: 

```c++
	// The path to the documents directory
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Instantiates a Presentation object that represents a presentation file
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Removes a slide through its slide index
	pres->get_Slides()->RemoveAt(0);

	// Saves the modified presentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Remove Unused Layout Slide**

Aspose.Slides provides the [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) method (from the [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) class) to allow you to delete unwanted and unused layout slides. This C++ code shows you how to remove a layout slide from a PowerPoint presentation:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Remove Unused Master Slide**

Aspose.Slides provides the [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) method (from the [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) class) to allow you to delete unwanted and unused master slides. This C++ code shows you how to remove a master slide from a PowerPoint presentation:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```



