---
title: Slide Master
type: docs
weight: 70
url: /java/slide-master/
keywords: "PPT master slide, slide master PowerPoint"
description: "Add or edit slide master PowerPoint, PPT master slide with Aspose.Slides."
---


## **What is Slide Master**
**Slide Master** - is a slide template, which defines the layout, styles, theme, fonts, background to be applied to presentation slides. If there is a need to create a presentation for your company, having slides based on the same style template - Slide Master is used. Slide Master can be used to set and change the look of all presentation slides at once.

Slide Master mechanism came to us from PowerPoint presentations and is fully supported by **Aspose.Slides API**. VBA also allows to manipulate Slide Master with all the operations supported by PowerPoint, like: change background, add shapes, customize the layout, etc. However, it is very limited to implement any nontrivial scenarios with Slide Masters, when you have hundreds of presentations and need to apply multiple Slides Masters here and there, combine, compare, merge and move them in any way you want.

Aspose.Slides proposes flexible mechanisms to use Slide Masters, as well as supports all basic operations over them.

Basic operations with Slide Master can be:

- Open or create Slide Master.
- Apply Slides Master to presentation slides.
- Change background of Slide Master.
- Add image, placeholder, Smart Art, etc to Slide Master.

Extended operations with Slide Master can be:

- Compare Slide Masters.
- Merge Slide Masters.
- Apply several Slide Masters.
- Copy slide with Slide Master to another presentation.
- Find out duplicate Slide Masters in presentations.
- Set Slide Master as presentation default view.
- ... and many others.

## **How is Slide Master applied**
While working with Slide Masters, its important to understand how they are used in presentations and applied to slides.

By default, each presentation has at least one Slide Master. However, its possible to add several Slide Masters into one presentation. Several Slide Masters can be used to make different parts of presentations to be stylized in different ways. 

In **Aspose.Slides** Slide Master is represented by 
[**IMasterSlide**](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) type. 
[Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object has 
[**getMasters**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) list of [**IMasterSlideCollection**](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) type, 
which contains a list of all master slides that are defined in this presentation. Appart from 
CRUD operations, 
[IMasterSlideCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) type is interesting with 
[**addClone**](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterLayoutSlideCollection#addClone-com.aspose.slides.ILayoutSlide-) 
and [**insertClone**](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection#insertClone-int-com.aspose.slides.IMasterSlide-) methods. 
These methods are inherited from basic slides clone functionality. 
But, in case of Slide Masters, the methods allow to implement complicated abovementioned scenarios.

When a new slide is added into presentation, Slide Master is applied to it automatically. By default, the Slide Master of previous slide is choosed for that. (*Note: presentation slides are stored in [getSlides](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) list, and each new slide is added to the end of collection, by default.*)  In case, there is only one Slide Master in presentation - it is choosed for all new slides. So, there is no need to define the Slide Master for each new slide created.

This logic is the same for both Aspose.Slides and PowerPoint. For example, in PowerPoint when you add a new presentation, you can just press on a bottom line under the last slide. In this case, a new slide, with a Slide Master of last presentation, will be created:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides, the same is achieved with [addClone(ISlide)](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) method of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object.

## **Slide Master in Slides hierarchy**
For maximum flexibility, it is possible to use Slide Layouts with Slide Master. Slide Layout allows to set all the same styles as Slide Master (background, fonts, shapes, etc.). However, if we combine several Slide Layouts on a Slide Master, they will create a new style. With one Slide Layout applied to a single Slide, you can change its style from the one applied by Slide Master.

Slide Master stands over all, which can be illustrated as "Slide Master -> Slide Layout -> Slide":

![todo:image_alt_text](slide-master_2)

Each [IMasterSlide](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlide)
object has [**getLayoutSlides**](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) method 
with a list of Slide Layouts. [Slide](https://apireference.aspose.com/slides/java/com.aspose.slides/Slide) type has 
[**getLayoutSlide**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) with a link on a 
Slide Layout applied to this slide. The relation between Slide and Slide Master occurs through Slide Layout.


{{% alert color="info" title="Note" %}} 
In Aspose.Slides all Slide Masters, Slide Layouts and Slides - are actually Slide objects, 
implementing [**IBaseSlide**](https://apireference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) interface.
{{% /alert %}}

Therefore, Slide Master and Slide Layout may implement the same properties, and its important to know how their value will be applied to Slide. First, Slide Master is applied to Slide, then Slide Layouts are applied. For example, if Slide Master and Slide Layout both have background value, the Slide will get background from Slide Layout.

## **What Slide Master consists from**
To understand how Slide Master can be changed, we should know what it consists from. Following are the core properties of ISlideMaster, that worth to know:

- [getBackground](https://apireference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) - get/set slide background.
- [getBodyStyle](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) - get/set text styles of the slide’s body.
- [getShapes](https://apireference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) - get/set all the shapes of the Slide Master (placeholders, picture frames, etc).
- [getControls](https://apireference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) - get/set ActiveX controls.
- [getThemeManager](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) - get theme manager.
- [getHeaderFooterManager](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - get header and footer manager.

Slide Master methods:

- [getDependingSlides](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) - get all Slides depending on Slide Master.
- [applyExternalThemeToDependingSlides](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - allows to create a new Slide Master based on current Slide Master and a new theme. New Slide Master is being applied to all dependent slides.

## **Get Slide Master**
In PowerPoint, Slide Master can be found in "View -> Slide Master" menu:

![todo:image_alt_text](slide-master_3.jpg)

With Aspose.Slides its possible to access Slide Master this way:

```java
Presentation pres = new Presentation();
try {
    // access to the Presentation's master slide
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

Slide Master is represented by [IMasterSlide](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) type. What you need is to get [Masters](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) list from [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object. Masters list has a type of [IMasterSlideCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) and contains a list of all Slide Masters that are defined in the presentation. 

## **Add Image to Slide Master**
Lets add an image to Slide Master to see it on all the slides dependent on this Slide Master.

Place your company logo and few images to Slide Master, then switch back to slide editing mode and you will see them on each slide:

![todo:image_alt_text](slide-master_4.png)

The same can be achieved with Aspose.Slides for Java:

```java
// add images to the presentation
IPPImage logo = pres.getImages().addImage(Files.readAllBytes(Paths.get("logo.png")));
IPPImage image1 = pres.getImages().addImage(Files.readAllBytes(Paths.get("slides.png")));
IPPImage image2 = pres.getImages().addImage(Files.readAllBytes(Paths.get("cells.png")));
IPPImage image3 = pres.getImages().addImage(Files.readAllBytes(Paths.get("words.png")));

// add these added images to the master slide
masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 25, 25, logo);
masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 40, 25, 25, image1);
masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 75, 25, 25, image2);
masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 110, 25, 25, image3);

// add new slides with same master slide template
pres.getSlides().addEmptySlide(masterSlide.getLayoutSlides().get_Item(0));
pres.getSlides().addEmptySlide(masterSlide.getLayoutSlides().get_Item(1));
```

First, we add images into the image collection of presentation. Now these images can be used in shapes, so we create a picture frame on Slide Master with [addPictureFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) method. After that, we add new slides, which are based on this Slide Master with [addEmptySlide](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) method. Info AddEmptySlide method we pass the layout of the Slide Master, so the new slides will be created with same master slide template.

{{% alert color="primary" title="See also" %}} 
- [Add Picure Frame to Slide](/slides/java/picture-frame/#add-picture-frame-to-slide)
{{% /alert %}}

## **Add Placeholder to Slide Master**
Text fields “Click to edit Master title style”, “Edit Master text styles”, “Second level”, “Third level” - are placeholders on the Slide Master. They will appear on the slides, that are based on this Slide Master. It is possible to edit these placeholders on Slide Master, and the changements will apply on the dependent slides.

In PowerPoint its possible to add Placeholder to presentation via "Slide Master -> Insert Placeholder" menu:

![todo:image_alt_text](slide-master_5.png)

But let's examine a more complicated example for placeholders with Aspose.Slides. For example, there is a slide with placeholders templated from the Slide Master:

![todo:image_alt_text](slide-master_6.png)

We are going to change the formatting of Title and Subtitle on Slides Master this way:

![todo:image_alt_text](slide-master_7.png)

With Aspose.Slides to change the formatting of title placeholder, we first retrieve it from Slide Master object, and then use [Placeholder.getFillFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) field:

```java
// get the reference to the master's title placeholder
IShape titlePlaceholder = masterSlide.getShapes().get_Item(0);

// format fill as gradient fill
titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.RED);
titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(50, Color.GREEN);
titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.BLUE);
```

The style and formatting of the title will change for all slides, based on this Slide Master:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
- [Set Text to Placeholder](/slides/java/text-formatting/)
{{% /alert %}}

## **Change Background on Slide Master**
It is possible to change the background of Slide Master and make it apply to all presentation slides this way. If you change the background color of the master slide, all normal slides in the presentation will receive the same background color settings. Follow the steps below to change the background color of the master slide:

```java
masterSlide.getBackground().setType(BackgroundType.OwnBackground);
masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
```

{{% alert color="primary" title="See also" %}} 
- [Presentation Background](/slides/java/presentation-background/)
{{% /alert %}}

## **Clone Slide Master to Another Presentation**
To clone Slide Master to another presentation, [**addClone**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) method is called from destination presentation with a Slide Master passed into it:

```java
// add new master slide form another presentation
IMasterSlide pres1MasterSlide = pres.getMasters().addClone(pres1MasterSlide);
```

## **Add Multiple Slide Masters to Presentation**
It is possible to add any amount of Slide Masters and Layouts to presentation. Its useful, if you need maximum flexibility to set up the styles, layouts and formatting of presentation slides in multiple ways.

In PowerPoint you can add new Slide Masters and Layouts in "Slide Master menu" this way:

![todo:image_alt_text](slide-master_9.jpg)

With Aspose.Slides you can add new Slide Master by calling Presentation.Masters.AddClone method:

```java
// add new master slide
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```

## **Compare Slide Masters**
Master Slide implements [IBaseSlide](https://apireference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) interface, containing [**equals**](https://apireference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) method, which can be used to compare slides. It returns true for Master Slides, that are identical by the structure and static content. Two Master Slides are equal if their shapes, styles, texts, animation and other settings, etc are equal. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

{{% alert color="primary" title="See also" %}} 
- [Compare Slides](/slides/java/compare-slides/)
{{% /alert %}}

## **Set Slide Master as Presentation Default View**
Its possible to set Slide Master as a default view, when you open the Aspose.Slides generated saved presentation:

```java
// Instantiate Presentation class that represents the presentation file
Presentation presentation = new Presentation();
try {
    // Set Default View as SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Save presentation
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Live Example**
You can take a look at presentation from the examples above with [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/):
[![todo:image_alt_text](slides-master.png)](https://products.aspose.app/slides/viewer/)
