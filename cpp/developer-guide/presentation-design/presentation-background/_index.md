---
title: Presentation Background
type: docs
weight: 20
url: /cpp/presentation-background/
keywords: "PowerPoint background, set background"
description: "Set background in PowerPoint presentation in CPP"
---

Solid colors, gradient colors, and pictures are often used as background images for slides. You can set the background either for a **normal slide** (single slide) or **master slide** (several slides at once).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Set Solid Color as Background for Normal Slide**

Aspose.Slides allows you to set a solid color as the background for a specific slide in a presentation (even if that presentation contains a master slide). The background change affects only the selected slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) enum for the slide to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) enum for the slide background to `Solid`.
4. Use the [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) property exposed by [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) to specify a solid color for the background.
5. Save the modified presentation.

This C++ code shows you how to set a solid color (blue) as the background for a normal slide:

```c++
// The path to the documents directory.

	const String OutPath = L"../out/SetSlideBackgroundNormal_out.pptx";

	// Creates an instance of the Presentation class
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//  Sets the background color for the first ISlide to Blue
	pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	//Writes the presentation to disk
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Set Solid Color as Background for Master Slide**

Aspose.Slides allows you to set a solid color as the background for the master slide in a presentation. The master slide acts as a template that contains and controls formatting settings for all slides. Therefore, when you select a solid color as the background for the master slide, that new background will be used for all slides.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) enum for the master slide (`Masters`) to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) enum for the master slide background to `Solid`.
4. Use the [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) property exposed by [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) to specify a solid color for the background.
5. Save the modified presentation.

This C++ code shows you how to set a solid color (forest green) as the background for a master slide in a presentation:

```c++
	// The path to the documents directory.

	const String OutPath = L"../out/SetSlideBackgroundMaster_out.pptx";

	// Creates an instance of the Presentation class
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Sets the background color for the Master ISlide to Forest Green
	pres->get_Masters()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_ForestGreen());

	//Writes the presentation to disk
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Set Gradient Color as Background for Slide**

A gradient is a graphical effect based on a gradual change in color. Gradient colors, when used as backgrounds for slides, make presentations looks artistic and professional. Aspose.Slides allows you to set a gradient color as the background for slides in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) enum for the slide to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) enum for the master slide background to `Gradient`.
4. Use the [GradientFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#aa686ab9c84e7e20e65dfe73458f1a823) property exposed by [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) to specify your preferred gradient setting.
5. Save the modified presentation.

This C++ code shows you how to set a gradient color as the background for a slide:

```c++
// Creates an instance of the Presentation class
auto pres = System::MakeObject<Presentation>(u"SetBackgroundToGradient.pptx");

// Apply Gradient effect to the Background
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Writes the presentation to disk
pres->Save(u"ContentBG_Grad_out.pptx", SaveFormat::Pptx);
```

## **Set Image as Background for Slide**

Besides solid colors and gradient colors, Aspose.Slides also allows you to set images as the background for slides in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) enum for the slide to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) enum for the master slide background to `Picture`.
4. Load the image you want to use as the slide background.
5. Add the image to the presentation's image collection.
6. Use the [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a7f2b7e6afce822667cecd3e80336bfae) property exposed by [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) to set the image as the background.
7. Save the modified presentation.

This C++ code shows you how to set an image as the background for a slide:

```c++
// The path to the documents directory.

const String templatePath = L"../templates/SetImageAsBackground.pptx";
const String imagePath = L"../templates/Tulips.jpg";
const String outPath = L"../out/ContentBG_Img_out.pptx";

// Creates an instance of the Presentation class
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Sets conditions for background image
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Loads the image
auto image = Images::FromFile(imagePath);

// Adds image to presentation's images collection
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Writes the presentation to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Change Transparency of Background Image**

You may want to adjust the transparency of a slide's background image to make the contents of the slide stand out. This C++ code shows you how to change the transparency for a slide background image:

```c++
int32_t transparencyValue = 30;
// for example
// Gets a collection of picture transform operations
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();
// Finds a transparency effect with fixed percentage.
System::SharedPtr<AlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (System::ObjectExt::Is<AlphaModulateFixed>(operation))
    {
        transparencyOperation = System::ExplicitCast<AlphaModulateFixed>(operation);
        break;
    }
}
// Sets the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Get Value of Slide Background**

Aspose.Slides provides the [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data/) interface to allow you to get the effective values of slide backgrounds. This interface contains information on the effective [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a097ba368423bf4a9ab7a6a61870bfc8e) and effective [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a446676281ac4195cb7eb989e4a8110f8).

Using the [Background](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide#ac12d4a7683bf6fa20b3eef387219cf16) property from the [BaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide/) class, you can get the effective value for a slide background.

This C++ code shows you how to get a slide's effective background value:

```c++
// Creates an instance of the Presentation class
const String templatePath = u"../templates/SamplePresentation.pptx";
	

	auto pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<IBackgroundEffectiveData> effBackground = pres->get_Slides()->idx_get(0)->CreateBackgroundEffective();
	if (effBackground->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Solid)
	{
		System::Console::WriteLine(System::String(u"Fill color: ") + effBackground->get_FillFormat()->get_SolidFillColor());
	}
	else
	{
		System::Console::WriteLine(System::String(u"Fill type: ") + System::ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
	}
```

