---
title: HeaderFooter
type: docs
weight: 220
url: /php-java/examples/elements/header-footer/
keywords:
- header footer
- add header footer
- update header footer
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Control headers and footers in PHP with Aspose.Slides: add or edit date/time, slide numbers, and footer text, show or hide placeholders across PPT, PPTX and ODP."
---

Shows how to add footers and update date and time placeholders using **Aspose.Slides for PHP via Java**.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Update Date and Time**

Modify the date and time placeholder on a slide.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
