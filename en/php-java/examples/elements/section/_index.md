---
title: Section
type: docs
weight: 90
url: /php-java/examples/elements/section/
keywords:
- section
- slide section
- add section
- access section
- remove section
- rename section
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Manage slide sections in PHP with Aspose.Slides: create, rename, reorder easily, move slides between sections, and control visibility for PPT, PPTX and ODP."
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for PHP via Java**.

## **Add a Section**

Create a section that starts at a specific slide.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Specify the slide that marks the beginning of the section.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Section**

Read section information from a presentation.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Access a section by index.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Section**

Delete a previously added section.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Remove the section.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rename a Section**

Change the name of an existing section.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
