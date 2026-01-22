---
title: Manage Presentation Slide Masters in JavaScript
linktitle: Slide Master
type: docs
weight: 70
url: /nodejs-java/slide-master/
keywords:
- slide master
- master slide
- PPT master slide
- multiple master slides
- compare master slides
- background
- placeholder
- clone master slide
- copy master slide
- duplicate master slide
- unused master slide
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Manage Slide Masters in Aspose.Slides for Node.js via Java: create, edit and apply layouts, themes and placeholders to PPT, PPTX and ODP with concise examples."
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

In **Aspose.Slides**, a Slide Master is represented by [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) type.

Aspose.Slides' [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)object contains the [**getMasters** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--)list of [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) type, which contains a list of all master slides that are defined in a presentation.

Besides CRUD operations, the [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) class contains these useful methods: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) and [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-) methods. Those methods are inherited from the basic slide cloning function. But when dealing with Slide Masters, those methods allow you to implement complicated setups.

When a new slide is added to a presentation, a Slide Master is applied to it automatically. The Slide Master of the previous slide is selected by default. 

**Note**: Presentation slides are stored in [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--) list, and every new slide is added to the end of the collection by default. If a presentation contains a single Slide Master, that slide master is selected for all new slides. This is the reason you do not have to define the Slide Master for every new slide you create.

The principle is the same for PowerPoint and Aspose.Slides. For example, in PowerPoint, when you add a new presentation, you can just press on the bottom line under the last slide and then a new slide (with the last presentation's Slide Master) will be created:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides, you can perform the equivalent task with the [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) method under the [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)class.


## **Slide Master in Slides hierarchy**

Using Slide Layouts with Slide Master allows for maximum flexibility. A Slide Layout allows you to set all the same styles as Slide Master (background, fonts, shapes, etc.). However, when several Slide Layouts are combined on a Slide Master, a new style is created. When you apply a Slide Layout to a single slide, you can change its style from the one applied by the Slide Master.

Slide Master outranks all setups items: Slide Master -> Slide Layout -> Slide:

![todo:image_alt_text](slide-master_2)



Each [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) object has a [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) property with a list of Slide Layouts. A [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) type has a [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) property with a link on a Slide Layout applied to the slide. The interaction between a slide and Slide Master occurs through a Slide Layout.

{{% alert color="info" title="Note" %}}

* In Aspose.Slides, all the slide setups (Slide Master, Slide Layout, and the slide itself) are actually slide objects implementing the [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) class.
* Therefore, Slide Master and Slide Layout may implement the same properties and you need to know how their values will be applied to a  [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) object. The Slide Master is applied first to a slide and then the Slide Layout is applied. For example, if the Slide Master and Slide Layout both have a background value, the Slide will end up with the background from the Slide Layout.

{{% /alert %}}


## **What A Slide Master Comprises**

To understand how a Slide Master can be changed, you need to know its constituents. These are [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) core properties.

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) get/set slide background.
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) - get/set text styles of the slide’s body.
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) get/set all the shapes of the Slide Master (placeholders, picture frames, etc).
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) get/set ActiveX controls.
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getThemeManager) - get theme manager.
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) - get header and footer manager.

Slide Master methods:

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) - get all Slides depending on the Slide Master.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - allows you to create a new Slide Master based on the current Slide Master and a new theme. The new Slide Master will then be applied to all dependent slides.


## **Get Slide Master**

In PowerPoint, Slide Master can be accessed from the View -> Slide Master menu:

![todo:image_alt_text](slide-master_3.jpg)



Using Aspose.Slides, you can access a Slide Master this way: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Gives access to the Presentation's master slide
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

The [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) class represents a Slide Master. The [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) property (related to [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) type) contains a list of all Slide Masters that are defined in the presentation. 


## **Add Image to Slide Master**

When you add an image to a Slide Master, that image will appear on all slides dependent on that slide master. 

For example, you can place your company's logo and a few images on the Slide Master and then switch back to slide editing mode. You should see the image on every slide. 

![todo:image_alt_text](slide-master_4.png)

You can add images to a slide master with Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="See also" %}} 

For more information on adding images to a slide, see the [Picture Frame](/slides/nodejs-java/picture-frame/#create-picture-frame) article.
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

```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    var placeHolder = findPlaceholder(master, aspose.slides.PlaceholderType.Title);
    placeHolder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    placeHolder.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    var awtColor = java.import('java.awt.Color');
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, java.newInstanceSync('java.awt.Color', 255, 0, 0));
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, java.newInstanceSync('java.awt.Color', 128, 0, 128));

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

function findPlaceholder(master, type)
{    
    for (var i = 0 ; i < master.getShapes().size(); i++)
    {
        var autoShape = master.getShapes().get_Item(i);
        if (autoShape != null)
        {
            if (autoShape.getPlaceholder().getType() == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```

The title style and formatting will change for all slides based on the slide master:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/nodejs-java/text-formatting/)

{{% /alert %}}


## **Change Background on Slide Master**

When you change a master slide's background color, all the normal slides in the presentation will get the new color. This JavaScript code demonstrates the operation:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    master.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    master.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="See also" %}} 

- [Presentation Background](https://docs.aspose.com/slides/nodejs-java/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)

  {{% /alert %}}

## **Clone Slide Master to Another Presentation**

To clone a Slide Master to another presentation, call the [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) method from the destination presentation alongside a Slide Master passed into it. This JavaScript code shows you how to clone a Slide Master to another presentation:

```javascript
var presSource = new aspose.slides.Presentation();
var presTarget = new aspose.slides.Presentation();
try {
    var master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) {
        presSource.dispose();
    }
}
```


## **Add Multiple Slide Masters to Presentation**

Aspose.Slides allows you to add several Slide Masters and Slide Layouts to any given presentation. This allows you to set up styles, layouts, and formatting options for presentation slides in many ways. 

In PowerPoint, you can add new Slide Masters and Layouts (from the "Slide Master menu) this way:

![todo:image_alt_text](slide-master_9.jpg)

Using Aspose.Slides, you can add a new Slide Master by calling the  [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) method:

```javascript
// Adds a new master slide
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **Compare Slide Masters**

A Master Slide implements the [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) class containing the [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-) method, which can then be used to compare slides. It returns `true` for Master Slides identical in structure and static content.

Two Master Slides are equal if their shapes, styles, texts, animation and other settings, etc are equal. The comparison does not take unique identifier values (e.g. SlideId) and dynamic content (e.g. current date value in Date Placeholder) into account. 


## **Set Slide Master as Presentation Default View**

Aspose.Slides allows you to set a Slide Master as the default view for a presentation. The default view is what you see first when you open a presentation. 

This code shows you how to set a Slide Master as a presentation's default view in JavaScript:

```javascript
// Instantiates a Presentation class that represents the presentation file
var presentation = new aspose.slides.Presentation();
try {
    // Sets the Default View as SlideMasterView
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // Saves the presentation
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remove Unused Master Slide**

Aspose.Slides provides the [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) method (from the  [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) class) to allow you to delete unwanted and unused master slides. This JavaScript code shows you how to remove a master slide from a PowerPoint presentation:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**What is a Slide Master in PowerPoint?**

A Slide Master is a slide template that defines the layout, styles, themes, fonts, background, and other properties for slides in a presentation. It allows you to set and change the look of all presentation slides at once.  

**How is a Slide Master applied in a presentation?**

Every presentation has at least one Slide Master by default. When a new slide is added, a Slide Master is applied to it automatically, typically inheriting the master of the previous slide. A presentation can contain multiple Slide Masters to style different parts uniquely.  

**What elements can be customized in a Slide Master?**

A Slide Master comprises several core properties that can be customized:

- **Background**: Set the slide background.
- **BodyStyle**: Define text styles for the slide's body.
- **Shapes**: Manage all shapes on the Slide Master, including placeholders and picture frames.
- **Controls**: Handle ActiveX controls.
- **ThemeManager**: Access the theme manager.
- **HeaderFooterManager**: Manage headers and footers.  

**How can I add an image to a Slide Master?**

Adding an image to a Slide Master ensures it appears on all slides that depend on that master. For example, placing a company logo on the Slide Master will display it on every slide in the presentation.  

**How do Slide Masters relate to Slide Layouts?**

Slide Layouts work in conjunction with Slide Masters to provide flexibility in slide design. While a Slide Master defines overarching styles and themes, Slide Layouts allow for variations in content arrangement. The hierarchy is as follows:

- **Slide Master** → Defines global styles.
- **Slide Layout** → Provides different content arrangements.
- **Slide** → Inherits design from its Slide Layout.

**Can I have multiple Slide Masters in a single presentation?**

Yes, a presentation can contain several Slide Masters. This allows you to style different sections of a presentation in various ways, providing flexibility in design.  

**How do I access and modify a Slide Master using Aspose.Slides?**

In Aspose.Slides, a Slide Master is represented by the [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) class. You can access a Slide Master using the [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) method of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) object.
