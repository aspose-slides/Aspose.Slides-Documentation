---
title: Retrieve and Update Presentation Information in PHP
linktitle: Presentation Information
type: docs
weight: 30
url: /php-java/examine-presentation/
keywords:
- presentation format
- presentation properties
- document properties
- get properties
- read properties
- change properties
- modify properties
- update properties
- examine PPTX
- examine PPT
- examine ODP
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Explore slides, structure and metadata in PowerPoint and OpenDocument presentations using Aspose.Slides for PHP for faster insights and smarter content audits."
---

Aspose.Slides for PHP via Java allows you to examine a presentation to find out its properties and understand its behavior.

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) and [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **Check a Presentation Format**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this PHP code:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Get Presentation Properties**

This PHP code shows you how to get presentation properties (information about the presentation):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

You may want to see the [properties under the DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) class.

## **Update Presentation Properties**

Aspose.Slides provides the [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) method that allows you to make changes to presentation properties.

Let's say we have a PowerPoint presentation with the document properties shown below.

![Original document properties of the PowerPoint presentation](input_properties.png)

This code example shows you how to edit some presentation properties:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

The results of changing the document properties are shown below.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Look for [embedded-font information](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getembeddedfonts/) at the presentation level, then compare those entries with the set of [fonts actually used across content](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/) to identify which fonts are critical for rendering.

**How can I quickly tell if the file has hidden slides and how many?**

Iterate through the [slide collection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) and inspect each slide's [visibility flag](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/).

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Compare the current [slide size](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslidesize/) and orientation with the standard presets; this helps anticipate behavior for printing and export.

**Is there a quick way to see if charts reference external data sources?**

Yes. Traverse all [charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), check their [data source](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), and note whether the data is internal or link-based, including any broken links.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

For each slide, tally object counts and look for large images, transparency, shadows, animations, and multimedia; assign a rough complexity score to flag potential performance hotspots.
