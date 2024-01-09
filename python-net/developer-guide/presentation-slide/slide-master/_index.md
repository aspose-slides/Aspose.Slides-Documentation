---
title: Slide Master
type: docs
weight: 80
url: /python-net/slide-master/
keywords: "Add Slide Master, PPT master slide, slide master PowerPoint, Image to Slide Master, Placeholder, Multiple Slide Masters, Compare Slide Masters, Python, Aspose.Slides"
description: "Add or edit slide master in PowerPoint presentation in Python"
---

## **What is a Slide Master in PowerPoint**

A **Slide Master** is a slide template that defines the layout, styles, theme, fonts, background, and other properties for slides in a presentation. If you want to create a presentation (or series of presentations) with the same style and template for your company, you can use a slide master. 

A Slide Master is useful because it allows you to set and change the look of all presentation slides at once. Aspose.Slides supports the Slide Master mechanism from PowerPoint. 

VBA also allows you to manipulate a Slide Master and execute the same operations supported in PowerPoint: change backgrounds, add shapes, customize the layout, etc. Aspose.Slides provides flexible mechanisms to allow you to use Slide Masters and perform basic tasks with them. 

These are basic Slide Master operations:

- Create or Slide Master.
- Apply Slides Master to presentation slides.
- Change Slide Master background. 
- Add an image, placeholder, Smart Art, etc. to Slide Master.

These are more advanced operations involving Slide Master: 

- Compare Slide Masters.
- Merge Slide Masters.
- Apply several Slide Masters.
- Copy slide with Slide Master to another presentation.
- Find out duplicate Slide Masters in presentations.
- Set Slide Master as the presentation default view.

{{% alert color="primary" %}} 

You may want to check out Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) because it is a live implementation of some of the core processes described here.

{{% /alert %}} 

## **How is Slide Master applied**

Before you work with a slide master, you may want to understand how they are used in presentations and applied to slides. 

* Every presentation has at least one Slide Master by default. 
* A presentation can contain several Slide Masters. You can add several Slide Masters and use them to style different parts of a presentation in different ways. 

In **Aspose.Slides**, a Slide Master is represented by [**IMasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) type. 

Aspose.Slides' [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object contains the [**masters**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) list of [**IMasterSlideCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) type, which contains a list of all master slides that are defined in a presentation. 

Besides CRUD operations, the [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) interface contains these useful methods: [**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) and [**insert_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) methods. Those methods are inherited from the basic slide cloning function. But when dealing with Slide Masters, those methods allow you to implement complicated setups. 

When a new slide is added to a presentation, a Slide Master is applied to it automatically. The Slide Master of the previous slide is selected by default. 

**Note**: Presentation slides are stored in [Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) list, and every new slide is added to the end of the collection by default. If a presentation contains a single Slide Master, that slide master is selected for all new slides. This is the reason you do not have to define the Slide Master for every new slide you create.

The principle is the same for PowerPoint and Aspose.Slides. For example, in PowerPoint, when you add a new presentation, you can just press on the bottom line under the last slide and then a new slide (with the last presentation's Slide Master) will be created:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides, you can perform the equivalent task with the [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) method under the [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.

## **Slide Master in Slides hierarchy**

Using Slide Layouts with Slide Master allows for maximum flexibility. A Slide Layout allows you to set all the same styles as Slide Master (background, fonts, shapes, etc.). However, when several Slide Layouts are combined on a Slide Master, a new style is created. When you apply a Slide Layout to a single slide, you can change its style from the one applied by the Slide Master.

Slide Master outranks all setups items: Slide Master -> Slide Layout -> Slide:

![todo:image_alt_text](slide-master_2)



Each [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) object has a [**LayoutSlides**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) property with a list of Slide Layouts. A [Slide ](https://reference.aspose.com/slides/python-net/aspose.slides/slide) type has a [**LayoutSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) property with a link on a Slide Layout applied to the slide. The interaction between a slide and Slide Master occurs through a Slide Layout.

{{% alert color="info" title="Note" %}}

* In Aspose.Slides, all the slide setups (Slide Master, Slide Layout, and the slide itself) are actually slide objects implementing the [**IBaseSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) interface.
* Therefore, Slide Master and Slide Layout may implement the same properties and you need to know how their values will be applied to a [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) object. The Slide Master is applied first to a slide and then the Slide Layout is applied. For example, if the Slide Master and Slide Layout both have a background value, the Slide will end up with the background from the Slide Layout.

{{% /alert %}}

## **What A Slide Master Comprises**

To understand how a Slide Master can be changed, you need to know its constituents. These are [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) core properties. 

- `background` get/set slide background.
- `body_style` get/set text styles of the slide’s body.
- `shapes` get/set all the shapes of the Slide Master (placeholders, picture frames, etc).
- `controls` - get/set ActiveX controls.
- `theme_manager` - get theme manager.
- `header_footer_manager` - get header and footer manager.

Slide Master methods:

- `get_depending_slides()` - get all Slides depending on the Slide Master.
- `apply_external_theme_to_depending_slides(fname)` - allows you to create a new Slide Master based on the current Slide Master and a new theme. The new Slide Master will then be applied to all dependent slides.

## **Get Slide Master**

In PowerPoint, Slide Master can be accessed from the View -> Slide Master menu:

![todo:image_alt_text](slide-master_3.jpg)



Using Aspose.Slides, you can access a Slide Master this way:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    # Gives access to the Presentation's master slide
    masterSlide = pres.masters[0]
```

The [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) interface represents a Slide Master. The `masters` property (related to [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) type) contains a list of all Slide Masters that are defined in the presentation. 

## **Add Image to Slide Master**

When you add an image to a Slide Master, that image will appear on all slides dependent on that slide master. 

For example, you can place your company's logo and a few images on the Slide Master and then switch back to slide editing mode. You should see the image on every slide. 

![todo:image_alt_text](slide-master_4.png)

You can add images to a slide master with Aspose.Slides: xxx - add code for images

```python
import aspose.slides as slides

def readAllBytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

# Adds images to the presentation
logo = pres.images.add_image(readAllBytes("logo.png"))
image1 = pres.images.add_image(readAllBytes("slides.png"))
image2 = pres.images.add_image(readAllBytes("cells.png"))
image3 = pres.images.add_image(readAllBytes("words.png"))

# Adds images to the master slide
masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 25, 25, logo)
masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 40, 25, 25, image1)
masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 75, 25, 25, image2)
masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 110, 25, 25, image3)

# Adds new slides with same master slide template
pres.slides.add_empty_slide(masterSlide.layout_slides[0])
pres.slides.add_empty_slide(masterSlide.layout_slides[1]) 
```

{{% alert color="primary" title="See also" %}} 

For more information on adding images to a slide, see the [Picture Frame](/slides/python-net/picture-frame/#create-picture-frame) article.
{{% /alert %}}

## **Add Placeholder to Slide Master**

These text fields are standard placeholders on a Slide Master: 

* Click to edit Master title style

* Edit Master text styles

* Second level

* Third level 

  They also appear on the slides based on Slide Master. You can edit those placeholders on a Slide Master and the changes are applied automatically to the slides. 

In PowerPoint, you can add a placeholder through the Slide Master -> Insert Placeholder path:



![todo:image_alt_text](slide-master_5.png)



Let's examine a more complicated example for placeholders with Aspose.Slides. Consider a slide with placeholders templated from the Slide Master:



![todo:image_alt_text](slide-master_6.png)



We want to change the Title and Subtitle formatting on the Slide Master this way:

![todo:image_alt_text](slide-master_7.png)



First, we retrieve the title placeholder content from the Slide Master object and then use the`PlaceHolder.FillFormat` field: 

```python
# Gets the reference to the master's title placeholder
titlePlaceholder = masterSlide.shapes[0]

# Sets format fill as gradient fill
titlePlaceholder.fill_format.fill_type = slides.FillType.GRADIENT
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```

The title style and formatting will change for all slides based on the slide master:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/python-net/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/python-net/text-formatting/)

{{% /alert %}}

## **Change Background on Slide Master**

When you change a master slide's background color, all the normal slides in the presentation will get the new color. This Python code demonstrates the operation:

```python
masterSlide.background.type = slides.BackgroundType.OWN_BACKGROUND
masterSlide.background.fill_format.fill_type = slides.FillType.SOLID
masterSlide.background.fill_format.solid_fill_color.color = draw.Color.gray
```

{{% alert color="primary" title="See also" %}} 

- [Presentation Background](https://docs.aspose.com/slides/python-net/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/python-net/presentation-theme/)

  {{% /alert %}}

## **Clone Slide Master to Another Presentation**

To clone a Slide Master to another presentation, call the `add_clone(source_slide, dest_master, allow_clone_missing_layout)`  method from the destination presentation alongside a Slide Master passed into it. This Python code shows you how to clone a Slide Master to another presentation:

```python
# Adds a new master slide 
pres1MasterSlide = pres.masters.add_clone(masterSlide)
```

## **Add Multiple Slide Masters to Presentation**

Aspose.Slides allows you to add several Slide Masters and Slide Layouts to any given presentation. This allows you to set up styles, layouts, and formatting options for presentation slides in many ways. 

In PowerPoint, you can add new Slide Masters and Layouts (from the "Slide Master menu) this way:

![todo:image_alt_text](slide-master_9.jpg)

Using Aspose.Slides, you can add a new Slide Master by calling the `add_clone` method:

```python
# Adds a new master slide
secondMasterSlide = pres.masters.add_clone(masterSlide)
```

## **Compare Slide Masters**

A Master Slide implements the [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) interface containing the `equals(slide)` method, which can then be used to compare slides. It returns `true` for Master Slides identical in structure and static content. 

Two Master Slides are equal if their shapes, styles, texts, animation and other settings, etc are equal. The comparison does not take unique identifier values (e.g. SlideId) and dynamic content (e.g. current date value in Date Placeholder) into account. 

## **Set Slide Master as Presentation Default View**

Aspose.Slides allows you to set a Slide Master as the default view for a presentation. The default view is what you see first when you open a presentation. 

This code shows you how to set a Slide Master as a presentation's default view in Python:

```py
import aspose.slides as slides

# Instantiates a Presentation class that represents the presentation file
with slides.Presentation() as presentation:
    # Sets the Default View as SlideMasterView
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Saves the presentation
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
