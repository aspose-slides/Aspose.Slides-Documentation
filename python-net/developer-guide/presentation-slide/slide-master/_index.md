---
title: Slide Master
type: docs
weight: 80
url: /python-net/slide-master/
keywords: "Add Slide Master, PPT master slide, slide master PowerPoint, Image to Slide Master, Placeholder, Multiple Slide Masters, Compare Slide Masters, Python, Aspose.Slides"
description: "Add or edit slide master in PowerPoint presentation in Python"
---


## **About Slide Master**
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

{{% alert color="primary" %}} 

You may want to check out Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) because it is a live implementation of some of the core processes described here.

{{% /alert %}} 


## **How is Slide Master applied**
While working with Slide Masters, its important to understand how they are used in presentations and applied to slides.

By default, each presentation has at least one Slide Master. However, its possible to add several Slide Masters into one presentation. Several Slide Masters can be used to make different parts of presentations to be stylized in different ways. 

In **Aspose.Slides** Slide Master is represented by 
[**IMasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) type. 
[Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)object has 
[**masters** ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)list of [**IMasterSlideCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) type, 
which contains a list of all master slides that are defined in this presentation. Appart from 
CRUD operations, 
[IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) type is interesting with 
[**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) 
and [**insert_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) methods. 
These methods are inherited from basic slides clone functionality. 
But, in case of Slide Masters, the methods allow to implement complicated abovementioned scenarios.



When a new slide is added into presentation, Slide Master is applied to it automatically. By default, the Slide Master of previous slide is choosed for that. (*Note: presentation slides are stored in [Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) list, and each new slide is added to the end of collection, by default.*)  In case, there is only one Slide Master in presentation - it is choosed for all new slides. So, there is no need to define the Slide Master for each new slide created.

This logic is the same for both Aspose.Slides and PowerPoint. For example, in PowerPoint when you add a new presentation, you can just press on a bottom line under the last slide. In this case, a new slide, with a Slide Master of last presentation, will be created:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides, the same is achieved with [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) method of [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)object.


## **Slide Master in Slides hierarchy**
For maximum flexibility, it is possible to use Slide Layouts with Slide Master. Slide Layout allows to set all the same styles as Slide Master (background, fonts, shapes, etc.). However, if we combine several Slide Layouts on a Slide Master, they will create a new style. With one Slide Layout applied to a single Slide, you can change its style from the one applied by Slide Master.

Slide Master stands over all, which can be illustrated as "Slide Master -> Slide Layout -> Slide":

![todo:image_alt_text](slide-master_2)



Each [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) 
object has [**LayoutSlides**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) property 
with a list of Slide Layouts. [Slide ](https://reference.aspose.com/slides/python-net/aspose.slides/slide)type has 
[**LayoutSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) with a link on a 
Slide Layout applied to this slide. The relation between Slide and Slide Master occurs through Slide Layout.


{{% alert color="info" title="Note" %}} 
In Aspose.Slides all Slide Masters, Slide Layouts and Slides - are actually Slide objects, 
implementing [**IBaseSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) interface.
{{% /alert %}}

Therefore, Slide Master and Slide Layout may implement the same properties, and its important to know how their value will be applied to Slide. First, Slide Master is applied to Slide, then Slide Layouts are applied. For example, if Slide Master and Slide Layout both have background value, the Slide will get background from Slide Layout.


## **What Slide Master consists from**
To understand how Slide Master can be changed, we should know what it consists from. Following are the core properties of ISlideMaster, that worth to know:

- [Background](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) - get/set slide background.
- [BodyStyle](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) - get/set text styles of the slide’s body.
- [Shapes](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) - get/set all the shapes of the Slide Master (placeholders, picture frames, etc).
- [Controls](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) - get/set ActiveX controls.
- [ThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/imasterthemeable/) - get theme manager.
- [HeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) - get header and footer manager.

Slide Master methods:

- [GetDependingSlides](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) - get all Slides depending on Slide Master.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) - allows to create a new Slide Master based on current Slide Master and a new theme. New Slide Master is being applied to all dependent slides.


## **Get Slide Master**
In PowerPoint, Slide Master can be found in "View -> Slide Master" menu:

![todo:image_alt_text](slide-master_3.jpg)



With Aspose.Slides its possible to access Slide Master this way:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # access to the Presentation's master slide
    masterSlide = pres.masters[0]
```



Slide Master is represented by [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) type. What you need is to get [Masters ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)list from [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)object. Masters list has a type of [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) and contains a list of all Slide Masters that are defined in the presentation. 


## **Add Image to Slide Master**
Lets add an image to Slide Master to see it on all the slides dependent on this Slide Master.

Place your company logo and few images to Slide Master, then switch back to slide editing mode and you will see them on each slide:

![todo:image_alt_text](slide-master_4.png)


The same can be achieved with Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

def readAllBytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

# add images to the presentation
logo = pres.images.add_image(readAllBytes("logo.png"))
image1 = pres.images.add_image(readAllBytes("slides.png"))
image2 = pres.images.add_image(readAllBytes("cells.png"))
image3 = pres.images.add_image(readAllBytes("words.png"))

# add these added images to the master slide
masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 25, 25, logo)
masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 40, 25, 25, image1)
masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 75, 25, 25, image2)
masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 110, 25, 25, image3)

# add new slides with same master slide template
pres.slides.add_empty_slide(masterSlide.layout_slides[0])
pres.slides.add_empty_slide(masterSlide.layout_slides[1]) 
```



First, we add images into the image collection of presentation. Now these images can be used in shapes, so we create a picture frame on Slide Master with [add_picture_frame ](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)method. After that, we add new slides, which are based on this Slide Master with [add_empty_slide ](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)method. Info `add_empty_slide` method we pass the layout of the Slide Master, so the new slides will be created with same master slide template.



{{% alert color="primary" title="See also" %}} 
- [Add Picure Frame](/slides/python-net/adding-shapes/#addingshapes-addpictureframe)[to ](/slides/python-net/adding-shapes/#addingshapes-addpictureframe)[Slide](/slides/python-net/adding-shapes/#addingshapes-addpictureframe)
{{% /alert %}}


## **Add Placeholder to Slide Master**
Text fields “Click to edit Master title style”, “Edit Master text styles”, “Second level”, “Third level” - are placeholders on the Slide Master. They will appear on the slides, that are based on this Slide Master. It is possible to edit these placeholders on Slide Master, and the changements will apply on the dependent slides.

In PowerPoint its possible to add Placeholder to presentation via "Slide Master -> Insert Placeholder" menu:



![todo:image_alt_text](slide-master_5.png)



But let's examine a more complicated example for placeholders with Aspose.Slides. For example, there is a slide with placeholders templated from the Slide Master:



![todo:image_alt_text](slide-master_6.png)



We are going to change the formatting of Title and Subtitle on Slides Master this way:



![todo:image_alt_text](slide-master_7.png)



With Aspose.Slides to change the formatting of title placeholder, we first retrieve it from Slide Master object, and then use PlaceHolder.FillFormat field:

```py
# get the reference to the master's title placeholder
titlePlaceholder = masterSlide.shapes[0]

# format fill as gradient fill
titlePlaceholder.fill_format.fill_type = slides.FillType.GRADIENT
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```



The style and formatting of the title will change for all slides, based on this Slide Master:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
- [Set Text to Placeholder](/slides/python-net/adding-and-formatting-text/#addingandformattingtext-setprompttextinaplaceholder)
{{% /alert %}}


## **Change Background on Slide Master**
It is possible to change the background of Slide Master and make it apply to all presentation slides this way. If you change the background color of the master slide, all normal slides in the presentation will receive the same background color settings. Follow the steps below to change the background color of the master slide:

```py
masterSlide.background.type = slides.BackgroundType.OWN_BACKGROUND
masterSlide.background.fill_format.fill_type = slides.FillType.SOLID
masterSlide.background.fill_format.solid_fill_color.color = draw.Color.gray
```

{{% alert color="primary" title="See also" %}} 
- [Presentation Background](/slides/python-net/presentation-background/)
{{% /alert %}}

## **Clone Slide Master to Another Presentation**
To clone Slide Master to another presentation, 
[**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method is called from destination presentation with a Slide Master passed into it:

```py
# add new master slide form another presentation
pres1MasterSlide = pres.masters.add_clone(masterSlide)
```

## **Add Multiple Slide Masters to Presentation**
It is possible to add any amount of Slide Masters and Layouts to presentation. Its useful, if you need maximum flexibility to set up the styles, layouts and formatting of presentation slides in multiple ways.

In PowerPoint you can add new Slide Masters and Layouts in "Slide Master menu" this way:

![todo:image_alt_text](slide-master_9.jpg)


With Aspose.Slides you can add new Slide Master by calling Presentation.Masters.add_clone method:

```py
# add new master slide
secondMasterSlide = pres.masters.add_clone(masterSlide)
```


## **Compare Slide Masters**
Master Slide implements [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) interface, containing [**equals** ](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)method, which can be used to compare slides. It returns true for Master Slides, that are identical by the structure and static content. Two Master Slides are equal if their shapes, styles, texts, animation and other settings, etc are equal. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.




## **Set Slide Master as Presentation Default View**
Its possible to set Slide Master as a default view, when you open the Aspose.Slides generated saved presentation:

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation() as presentation:
    # Set Default View as SlideMasterView
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Save presentation
    presentation.save("PresView.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Unused Master Slide**

Aspose.Slides provides the `remove_unused_master_slides` method (from the [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class) to allow you to delete unwanted and unused master slides. This Python code shows you how to remove a master slide from a PowerPoint presentation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```
