---
title: Master Slide
type: docs
weight: 30
url: /php-java/examples/elements/master-slide/
keywords:
- master slide
- add master slide
- access master slide
- remove master slide
- unused master slide
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Manage master slides in PHP with Aspose.Slides: create, edit, clone, and format themes, backgrounds, placeholders to unify slides in PowerPoint and OpenDocument."
---

Master slides form the top level of the slide inheritance hierarchy in PowerPoint. A **master slide** defines common design elements such as backgrounds, logos, and text formatting. **Layout slides** inherit from master slides, and **normal slides** inherit from layout slides.

This article demonstrates how to create, modify, and manage master slides using Aspose.Slides for PHP via Java.

## **Add a Master Slide**

This example shows how to create a new master slide by cloning the default one.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Clone the default master slide.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Master slides provide a way to apply consistent branding or shared design elements across all slides. Any changes made to the master will automatically reflect on dependent layout and normal slides.

> 💡 **Tip 2:** Any shapes or formatting added to a master slide are inherited by layout slides and, in turn, all normal slides using those layouts.
> The image below illustrates how a text box added on a master slide is automatically rendered on the final slide.

![Master Inheritance Example](master-slide-banner.png)

## **Access a Master Slide**

You can access master slides using the `Presentation::getMasters` method. Here’s how to retrieve and work with them:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Access the first master slide.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Master Slide**

Master slides can be removed either by index or by reference.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Remove by index.
        $presentation->getMasters()->removeAt(0);

        // Or remove by reference.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove Unused Master Slides**

Some presentations contain master slides that are not in use. Removing these slides can help reduce file size.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Remove all unused master slides (even those marked as Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** Use `removeUnused(true)` to clean up unused master slides and minimize the presentation size.
