---
title: Aspose.Slides for PHP via Java 23.8 Release Notes
type: docs
weight: 50
url: /php-java/aspose-slides-for-php-via-java-23-8-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESPHP-33|[Use Aspose.Slides for Java 23.8 features](/slides/java/aspose-slides-for-java-23-8-release-notes/)|Enhancement|


## Public API Changes ##

### ShowMediaControls property has been added for SlideShowSettings ###

The ShowMediaControls property was added for the SlideShowSettings class, which Represents the slide show settings for the presentation.

Example:

```php
$pres = new Presentation();
$pres->getSlideShowSettings()->setShowMediaControls(true);
```