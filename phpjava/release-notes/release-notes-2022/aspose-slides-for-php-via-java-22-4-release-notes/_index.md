---
title: Aspose.Slides for PHP via Java 22.4 Release Notes
type: docs
weight: 100
url: /phpjava/aspose-slides-for-php-via-java-22-4-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|**Related Documentation**|
| :- | :- | :- | :- |
|||| |


## **Public API Changes**

## LowCode Compress - remove unused layout and master slides added ##

A new  LowCode Compress methods were added:

* [void RemoveUnusedMasterSlides(Presentation pres)]()
* [void RemoveUnusedLayoutSlides(Presentation pres)]()

### Remove unused master slides from Presentation

```java
$pres = new Presentation("pres.pptx");

Compress::removeUnusedMasterSlides($pres);

$pres->save("pres-out.pptx", SaveFormat::Pptx);
```

### Remove unused layout slides from Presentation

```java
$pres = new Presentation("pres.pptx");

Compress::removeUnusedLayoutSlides($pres);

$pres->save("pres-out.pptx", SaveFormat::Pptx);
```