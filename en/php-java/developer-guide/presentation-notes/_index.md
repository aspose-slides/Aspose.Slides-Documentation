---
title: Manage Presentation Notes in PHP
linktitle: Presentation Notes
type: docs
weight: 110
url: /php-java/presentation-notes/
keywords:
- notes
- notes slide
- add notes
- remove notes
- notes style
- master notes
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Remove slide notes and customize master notes text styles in PowerPoint and OpenDocument presentations with Aspose.Slides for PHP via Java."
---

## **Overview**

Aspose.Slides for PHP via Java lets you remove notes from individual slides or an entire presentation, customize the text style defined in the master notes slide, and remove notes and handout masters. This article shows how to perform these operations and save the updated presentation.

To read or change notes page dimensions, switch orientation, and check export behavior, see [Notes Page Size](/slides/php-java/notes-size/).

## **Remove Notes from a Slide**

To remove notes from a specific slide, call its [getNotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getnotesslidemanager/) method and call [removeNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/removenotesslide/). The example loads a presentation containing at least one slide and removes the notes from the first slide, accessed at index zero. Notes on other slides remain unchanged, and the updated presentation is saved in PPTX format.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $notesManager = $presentation->getSlides()->get_Item(0)->getNotesSlideManager();
    $notesManager->removeNotesSlide();

    $presentation->save("presentation_without_first_slide_notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Remove Notes from All Slides**

To remove all slide notes, iterate through the collection returned by the presentation's [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) method and call [removeNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/removenotesslide/) for each slide. This example processes every slide in an existing presentation and saves a PPTX copy without slide notes.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $presentation->getSlides()->get_Item($i)->getNotesSlideManager()->removeNotesSlide();
    }

    $presentation->save("presentation_without_notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Remove Notes and Handout Masters**

Notes and handout masters define shared formatting and placeholders for their respective page types. Removing a master is a separate operation from removing an individual slide's notes with [removeNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/removenotesslide/).

### **Remove an Unused Notes Master**

When cleaning up a template that has no notes pages, you can remove its unused notes master. Access [getMasterNotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasternotesslidemanager/), check [getMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--), and call [removeMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasternotesslidemanager/#removeMasterNotesSlide--).

The following example requires a presentation to contain no notes pages. It removes the notes master if one exists, including its formatting and header/footer placeholders, and saves the template.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template_without_notes.pptx");
try {
    $manager = $presentation->getMasterNotesSlideManager();
    if (!java_is_null($manager->getMasterNotesSlide())) {
        $manager->removeMasterNotesSlide();
    }

    $presentation->save("template_without_notes_master.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

After removal, [getMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) returns `null`. If the master is already absent, the example skips removal and still saves the presentation.

### **Remove a Handout Master**

To remove a handout master, access [getMasterHandoutSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasterhandoutslidemanager/), check [getMasterHandoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--), and call [removeMasterHandoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterhandoutslidemanager/#removeMasterHandoutSlide--).

For this example, use a presentation containing slide notes and customized notes and handout masters. Give the handout master a visible banner and header/footer text so that the effect of removal is easy to compare in handout output.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation_with_custom_masters.pptx");
try {
    $manager = $presentation->getMasterHandoutSlideManager();
    if (!java_is_null($manager->getMasterHandoutSlide())) {
        $manager->removeMasterHandoutSlide();
    }

    $presentation->save("presentation_without_handout_master.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

After removal, [getMasterHandoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) returns `null`. Existing slide notes and the notes master remain unchanged. If the handout master is already absent, the example simply saves the presentation.

In handout output, the removed master's banner, formatting, and header, footer, date/time, and page-number placeholders no longer appear. The presentation slides still appear in the handout layout, including any footer or date text on the slides themselves. Slide numbers added by the handout export settings are separate from the master's page-number placeholder.

If you only want to hide handout headers or footers, change the corresponding placeholder visibility through the [handout master's header/footer manager](/slides/php-java/presentation-header-and-footer/#set-headers-and-footers-on-the-handout-master) instead. This keeps the master and its other formatting, such as a custom banner.

## **Add a Notes Style**

The [getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/masternotesslide/getnotesstyle/) method of [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masternotesslide/) returns the master notes text style. The example accesses the existing notes master through [getMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) and uses [getLevel](https://reference.aspose.com/slides/php-java/aspose.slides/textstyle/getlevel/) with index zero to select the first paragraph level. It sets the bullet type to [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol) and saves the presentation in PPTX format. The input must contain a master notes slide with a defined first paragraph level for the style change to take effect; otherwise, the presentation is saved without changing the notes style.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\BulletType;

$presentation = new Presentation("presentation.pptx");
try {
    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesStyle = $notesMaster->getNotesStyle();
        $paragraphFormat = $notesStyle->getLevel(0);
        if (!java_is_null($paragraphFormat)) {
            $paragraphFormat->getBullet()->setType(BulletType::Symbol);
        }
    }

    $presentation->save("presentation_with_notes_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Which API provides access to the notes of a specific slide?**

Use the slide's [getNotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getnotesslidemanager/) method. The manager's [getNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/) method returns the notes slide, or `null` if the slide has no notes.

**Does working with notes require Microsoft PowerPoint to be installed?**

No. Aspose.Slides works with notes in PowerPoint and OpenDocument presentations without requiring Microsoft PowerPoint to be installed.
