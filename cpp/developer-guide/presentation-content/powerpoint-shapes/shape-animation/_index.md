---
title: Shape Animation
type: docs
weight: 60
url: /cpp/shape-animation/
keywords: "PowerPoint animation, Animation effect, Apply animation, PowerPoint presentation, C++, CPP, Aspose.Slides for C++"
description: "Apply PowerPoint animation in C++"
---

Animations are visual effects that can be applied to texts, images, shapes, or [charts](/slides/cpp/animated-charts/). They give life to presentations or its constituents. 

### **Why Use Animations in Presentations?**

Using animations, you can 

* control the flow of information
* emphasize important points
* increase interest or participation among your audience
* make content easier to read or assimilate or process
* draw your readers or viewers attention to important parts in a presentation

PowerPoint provides many options and tools for animations and animation effects across the **entrance**, **exit**, **emphasis**, and **motion paths** categories. 

### **Animations in Aspose.Slides**

* Aspose.Slides provides the classes and types you need to work with animations under the [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) namespace,
* Aspose.Slides provides over **150 animation effects** under the [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumeration. These effects are essentially the same (or equivalent) effects used in PowerPoint.

## **Apply Animation to TextBox**

Aspose.Slides for C++ allows you to apply animation to the text in a shape. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class.
2. Get a slide's reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. Add text to [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Get a main sequence of effects.
6. Add an animation effect to [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
7. Set the [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) property to the value from [BuildType Enumeration](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Write the presentation to disk as a PPTX file.

This C++ code shows you how to apply the `Fade` effect to AutoShape and set the text animation to the *By 1st Level Paragraphs* value:

```c++
// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Besides applying animations to text, you can also apply animations to a single [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph). See [**Animated Text**](/slides/cpp/animated-text/).

{{% /alert %}} 

## **Apply Animation to PictureFrame**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class.
2. Get a slide's reference through its index.
3. Add or get a [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) on the slide. 
4. Get the main sequence of effects.
5. Add an animation effect to the [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame).
6. Write the presentation to disk as a PPTX file.

This C++ code shows you how to apply the `Fly` effect to a picture frame:

```c++
// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Load Image to be added in presentaiton image collection
System::SharedPtr<System::Drawing::Image> img = System::MakeObject<System::Drawing::Bitmap>(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Adds picture frame to slide
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Adds Fly from Left animation effect to picture frame
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Save the PPTX file to disk
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Apply Animation to Shape**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class.
2. Get a slide's reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. Add a `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) (when this object is clicked, the animation gets played).
5. Create a sequence of effects on the bevel shape.
6. Create a custom `UserPath`.
7. Add commands for moving to the `UserPath`.
8. Write the presentation to disk as a PPTX file.

This C++ code shows you how to apply the `PathFootball` (path football) effect to a shape:

```c++
	// The path to the document directory.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Loads the presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accesses first slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accesses shapes collection for selected slide
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Creates PathFootball effect for existing shape from scratch.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Adds the PathFootBall animation effect
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Create some kind of "button".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Creates a sequence of effects for this button.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Creates a custom user path. Our object will be moved only after the button is clicked.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Adds commands for moving since created path is empty.
	 SharedPtr<MotionEffect> motionBhv = DynamicCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //Writes the PPTX file to Disk
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Get the Animation Effects Applied to Shape**

You may decide to find out the all animation effects applied to a single shape. 

This C++ code shows you how to get the all effects applied to a specific shape:

```c++
// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

System::SharedPtr<ISlide> firstSlide = pres->get_Slides()->idx_get(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on slide.
System::SharedPtr<IShape> shape = firstSlide->get_Shapes()->idx_get(0);

// Gets all animation effects applied to the shape.
System::ArrayPtr<System::SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    System::Console::WriteLine(System::String(u"The shape ") + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}
```

## **Change Animation Effect Timing Properties**

Aspose.Slides for C++ allows you to change the Timing properties of an animation effect.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) properties:

- PowerPoint Timing **Start** drop-down list matches the [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) property. 
- PowerPoint Timing **Duration** matches the [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) property. The duration of an animation (in seconds) is the total time it takes the animation to complete one cycle. 
- PowerPoint Timing **Delay** matches the [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) property. 

This is how you change the Effect Timing properties:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Set new values for the [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) properties you need. 
3. Save the modified PPTX file.

This C++ code demonstrates the operation:

```c++
// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Gets the first effect of main sequence.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Changes effect TriggerType to start on click
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Changes effect Duration
effect->get_Timing()->set_Duration(3.f);

// Changes effect TriggerDelayTime
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Saves the PPTX file to disk
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

