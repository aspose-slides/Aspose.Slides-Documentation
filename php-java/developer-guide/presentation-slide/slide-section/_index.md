---
title: Slide Section
type: docs
weight: 90
url: /php-java/slide-section/
---

With Aspose.Slides for PHP via Java, you can organize a PowerPoint Presentation into sections. You get to create sections that contain specific slides.

You may want to create sections and use them to organize or divide slides in a presentation into logical parts in these situations:

- When you are working on a large presentation with other people or a team—and you need to assign certain slides to a colleague or some team members. 
- When you are dealing with a presentation that contains many slides—and you are struggling to manage or edit its contents at once.

Ideally, you should create a section that houses similar slides—the slides have something in common or they can exist in a group based on a rule—and give the section a name that describes the slides inside it. 

## Creating Sections in Presentations

To add a section that will house slides in a presentation, Aspose.Slides for PHP via Java provides the [addSection()](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) method that allows you to specify the name of the section you intend to create and the slide from which the section starts.

This sample code shows you to create a section in a presentation :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 will be ended at newSlide2 and after it section2 will start

    $pres->save("pres-sections.pptx", SaveFormat->Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat->Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }

```

## Changing the Names of Sections

After you create a section in a PowerPoint presentation, you may decide to change its name. 

This sample code shows you how to change the name of a section in a presentation  using Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }

```



