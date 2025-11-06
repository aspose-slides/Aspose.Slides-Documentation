---
title: What is Slide Master in PowerPoint? Definition & Usage Guide
linktitle: Slide Master
type: docs
weight: 80
url: /net/slide-master/
keywords: "Add Slide Master, PPT master slide, slide master PowerPoint, Image to Slide Master, Placeholder, Multiple Slide Masters, Compare Slide Masters, C#, Csharp, .NET, Aspose.Slides"
description: "Learn what a Slide Master is in PowerPoint and how it helps you control slide layouts, fonts, colors, and branding. Easy step-by-step guide with examples in C# or .NET."
---


## **What is a Slide Master in PowerPoint**
A **Slide Master** in PowerPoint is a feature that controls the layout, fonts, and styles across multiple slides. It helps maintain consistency and branding in presentations. If you want to create a presentation (or series of presentations) with the same style and template for your company, you can use a slide master. 

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

In **Aspose.Slides**, a Slide Master is represented by [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) type. 

Aspose.Slides' [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)object contains the [**Masters** ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters)list of [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) type, which contains a list of all master slides that are defined in a presentation. 

Besides CRUD operations, the [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) interface contains these useful methods: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) and [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone) methods. Those methods are inherited from the basic slide cloning function. But when dealing with Slide Masters, those methods allow you to implement complicated setups. 

When a new slide is added to a presentation, a Slide Master is applied to it automatically. The Slide Master of the previous slide is selected by default. 

**Note**: Presentation slides are stored in [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) list, and every new slide is added to the end of the collection by default. If a presentation contains a single Slide Master, that slide master is selected for all new slides. This is the reason you do not have to define the Slide Master for every new slide you create.

The principle is the same for PowerPoint and Aspose.Slides. For example, in PowerPoint, when you add a new presentation, you can just press on the bottom line under the last slide and then a new slide (with the last presentation's Slide Master) will be created:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides, you can perform the equivalent task with the [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) method under the [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.


## **Slide Master in Slides hierarchy**
Using Slide Layouts with Slide Master allows for maximum flexibility. A Slide Layout allows you to set all the same styles as Slide Master (background, fonts, shapes, etc.). However, when several Slide Layouts are combined on a Slide Master, a new style is created. When you apply a Slide Layout to a single slide, you can change its style from the one applied by the Slide Master.

Slide Master outranks all setups items: Slide Master -> Slide Layout -> Slide:

![todo:image_alt_text](slide-master_2)



Each [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) object has a [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) property with a list of Slide Layouts. A [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) type has a [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) property with a link on a Slide Layout applied to the slide. The interaction between a slide and Slide Master occurs through a Slide Layout.

{{% alert color="info" title="Note" %}}

* 
   In Aspose.Slides, all the slide setups (Slide Master, Slide Layout, and the slide itself) are actually slide objects implementing the [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) interface.
* Therefore, Slide Master and Slide Layout may implement the same properties and you need to know how their values will be applied to a [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/) object. The Slide Master is applied first to a slide and then the Slide Layout is applied. For example, if the Slide Master and Slide Layout both have a background value, the Slide will end up with the background from the Slide Layout.

{{% /alert %}}


## **What A Slide Master Comprises**
To understand how a Slide Master can be changed, you need to know its constituents. These are [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) core properties. 

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - get/set slide background.
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - get/set text styles of the slide’s body.
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - get/set all the shapes of the Slide Master (placeholders, picture frames, etc).
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - get/set ActiveX controls.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - get theme manager.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - get header and footer manager.

Slide Master methods:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - get all Slides depending on the Slide Master.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - allows you to create a new Slide Master based on the current Slide Master and a new theme. The new Slide Master will then be applied to all dependent slides.


## **Get Slide Master**
In PowerPoint, Slide Master can be accessed from the View -> Slide Master menu:

![todo:image_alt_text](slide-master_3.jpg)



Using Aspose.Slides, you can access a Slide Master this way:

```c#
IMasterSlide master = pres.Masters[0];
```

The [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) interface represents a Slide Master. The [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) property (related to [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) type) contains a list of all Slide Masters that are defined in the presentation. 


## **Add Image to Slide Master**
When you add an image to a Slide Master, that image will appear on all slides dependent on that slide master. 

For example, you can place your company's logo and a few images on the Slide Master and then switch back to slide editing mode. You should see the image on every slide. 

![todo:image_alt_text](slide-master_4.png)

You can add images to a slide master with Aspose.Slides: 

```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="See also" %}} 

For more information on adding images to a slide, see the [Picture Frame](/slides/net/picture-frame/#create-picture-frame) article.
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

```c#
public static void Main()
{
    using (var pres = new Presentation())
    {
        IMasterSlide master = pres.Masters[0];
        IAutoShape placeHolder = FindPlaceholder(master, PlaceholderType.Title);
        placeHolder.FillFormat.FillType = FillType.Gradient;
        placeHolder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(255, Color.FromArgb(128, 0, 128));
        
        pres.Save("pres.pptx", SaveFormat.Pptx);
    }
}

static IAutoShape FindPlaceholder(IMasterSlide master, PlaceholderType type)
{
    foreach (IShape shape in master.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            if (autoShape.Placeholder.Type == type)
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

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Change Background on Slide Master**
When you change a master slide's background color, all the normal slides in the presentation will get the new color. This C# code demonstrates the operation:

```c#
using (var pres = new Presentation())
{
    IMasterSlide master = pres.Masters[0];
    master.Background.Type = BackgroundType.OwnBackground;
    master.Background.FillFormat.FillType = FillType.Solid;
    master.Background.FillFormat.SolidFillColor.Color = Color.Green;
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)

  {{% /alert %}}

## **Clone Slide Master to Another Presentation**
To clone a Slide Master to another presentation, call the [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) method from the destination presentation alongside a Slide Master passed into it. This C# code shows you how to clone a Slide Master to another presentation:

```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **Add Multiple Slide Masters to Presentation**
Aspose.Slides allows you to add several Slide Masters and Slide Layouts to any given presentation. This allows you to set up styles, layouts, and formatting options for presentation slides in many ways. 

In PowerPoint, you can add new Slide Masters and Layouts (from the "Slide Master menu) this way:

![todo:image_alt_text](slide-master_9.jpg)

Using Aspose.Slides, you can add a new Slide Master by calling the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) method:

```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **Compare Slide Masters**
A Master Slide implements the [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) interface containing the [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals) method, which can then be used to compare slides. It returns `true` for Master Slides identical in structure and static content. 

Two Master Slides are equal if their shapes, styles, texts, animation and other settings, etc are equal. The comparison does not take unique identifier values (e.g. SlideId) and dynamic content (e.g. current date value in Date Placeholder) into account. 


## **Set Slide Master as Presentation Default View**
Aspose.Slides allows you to set a Slide Master as the default view for a presentation. The default view is what you see first when you open a presentation. 

This code shows you how to set a Slide Master as a presentation's default view in C#:

```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```

## **Remove Unused Master Slide**

Aspose.Slides provides the [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) method (from the [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class) to allow you to delete unwanted and unused master slides. This C# code shows you how to remove a master slide from a PowerPoint presentation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
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

In Aspose.Slides, a Slide Master is represented by the `IMasterSlide` interface. You can access a Slide Master using the `Masters` property of the `Presentation` object.
