---
title: Manage Presentation Slide Masters in PHP
linktitle: Slide Master
type: docs
weight: 70
url: /php-java/slide-master/
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
- PHP
- Aspose.Slides
description: "Manage slide masters in Aspose.Slides for PHP via Java: access, edit, clone, compare, and remove master slides in PowerPoint and OpenDocument presentations."
---

## **Overview**

A **slide master** defines shared design settings for a group of slides. It can contain common shapes, logos, backgrounds, text styles, theme settings, and footer settings. In PowerPoint, editing a slide master is the usual way to keep a presentation consistent without repeating the same formatting on every slide.

Aspose.Slides for PHP via Java supports the same model. A presentation can contain one or more master slides, and each master slide can contain several layout slides. Normal slides do not usually refer to a master slide directly. Instead, a normal slide uses a layout slide, and that layout slide belongs to a master slide.

The hierarchy is:

1. **Slide master** - defines the shared design and theme.
1. **Layout slide** - defines a specific arrangement of placeholders and layout-level formatting.
1. **Normal slide** - contains the actual presentation content and uses one layout slide.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

In Aspose.Slides, a slide master is represented by the [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) class. All master slides in a presentation are available through the [Presentation.getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) method, which returns a [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) object.

{{% alert color="info" title="Inheritance" %}}

When the same property is defined at more than one level, the more specific level wins. For example, if a master slide and a layout slide both define a background, slides based on that layout use the layout background. For more information about layout slides, see [Apply or Change Slide Layouts](/slides/php-java/slide-layout/).

{{% /alert %}}

## **Access Slide Masters**

In PowerPoint, you can open the Slide Master view from **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

In Aspose.Slides, use the `getMasters` method to access master slides:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

You can also get the master slide used by a normal slide through its layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **What a Slide Master Contains**

A master slide is a slide-like object. It extends [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/), so it exposes many of the same slide properties used by normal and layout slides. Master-specific members are listed on the [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) API page.

Commonly used master slide members include:

| Member | Purpose |
| --- | --- |
| `getBackground` | Sets the master-level slide background. |
| `getShapes` | Stores shapes placed on the master, such as logos, picture frames, and shared text. |
| `getLayoutSlides` | Stores the layout slides that belong to the master. |
| `getThemeManager` | Provides access to the master theme APIs. |
| `getHeaderFooterManager` | Controls headers, footers, dates, and slide numbers for the master and its child layouts. |
| `getDependingSlides` | Returns normal slides that depend on the master through their layouts. |

## **Add an Image to a Slide Master**

When you add an image to a master slide, it appears on slides that use layouts from that master. This is useful for logos, watermarks, decorative bands, and other repeated visual elements.

The following example adds a logo to the first master slide:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

For more information about picture frames, see [Picture Frame](/slides/php-java/picture-frame/).

## **Work with Placeholders**

Placeholders are normally defined on layout slides. The master slide provides the shared style and theme that those layouts inherit, while each layout decides which placeholders are available and where they are placed.

In PowerPoint, placeholder commands are available in Slide Master view.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

To add new placeholders with Aspose.Slides, work with the layout slide that belongs to the master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

You can also format placeholder shapes that already exist on a master slide. The following example finds the title placeholder and applies a linear gradient fill:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

For more placeholder and text formatting options, see [Set Prompt Text in Placeholder](/slides/php-java/manage-placeholder/) and [Text Formatting](/slides/php-java/text-formatting/).

## **Change a Slide Master Background**

A master background is inherited by layouts and slides that do not override it. The following example sets a solid background color for the first master slide:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

For related topics, see [Presentation Background](/slides/php-java/presentation-background/) and [Presentation Theme](/slides/php-java/presentation-theme/).

## **Clone a Slide Master to Another Presentation**

Use `addClone` from [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) to copy a master slide into another presentation. The copied master can then be used by layouts and slides in the destination presentation.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

If you need to clone normal slides together with their master, see [Clone Slides](/slides/php-java/clone-slides/).

## **Add Multiple Slide Masters**

A presentation can contain multiple master slides. This is useful when different sections require different branding, page structure, or theme settings.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

The following example clones the default master, gives the clone a different background, creates a layout under that cloned master, and adds a new slide based on that layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Compare Slide Masters**

Master slides can be compared with the `equals` method inherited from [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/). The comparison checks structure and static content, such as shapes, text, formatting, animations, and other slide settings. It does not compare unique identifiers, such as slide IDs, or dynamic placeholder values, such as the current date.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

For more information, see [Compare Presentation Slides](/slides/php-java/compare-slides/).

## **Set Slide Master View as the Default View**

Use the `setLastView` method on [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) to control the view that PowerPoint opens first. The following example opens the presentation in Slide Master view:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

For more view settings, see [Save Presentation](/slides/php-java/save-presentation/).

## **Remove Unused Master Slides**

Presentations sometimes contain master slides that are no longer used by any normal slides. Removing unused masters can reduce file size and simplify template maintenance.

Use `removeUnused` from [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) to remove unused masters from the `getMasters` collection:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

You can also use the low-code `removeUnusedMasterSlides` method from the [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) class:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**What is the difference between a slide master and a layout slide?**

A slide master defines shared design settings such as theme, background, common shapes, and text styles. A layout slide belongs to a master slide and defines a specific arrangement of placeholders. A normal slide uses a layout slide, so it inherits from both the layout and the master.

**Can one presentation contain several slide masters?**

Yes. A presentation can contain several slide masters. Use multiple masters when different sections need different visual systems or branding.

**Should I add placeholders to a master slide or a layout slide?**

In most cases, add placeholders to layout slides. Put shared visual elements and shared formatting on the master slide, then put content placeholders on the layouts that normal slides will use.

**Can I delete a master slide that is still used?**

No. A master slide that has dependent slides cannot be safely removed directly. First move those slides to layouts under another master, or use an unused-master cleanup method that removes only masters that are not in use.
