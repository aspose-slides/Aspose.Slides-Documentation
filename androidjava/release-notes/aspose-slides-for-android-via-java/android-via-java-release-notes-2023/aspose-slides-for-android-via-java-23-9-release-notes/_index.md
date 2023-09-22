---
title: Aspose.Slides for Android via Java 23.9 Release Notes
type: docs
weight: 40
url: /androidjava/aspose-slides-for-android-via-java-23-9-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for Android via Java 23.9](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/23.9/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESANDROID-439|[Use Aspose.Slides for Java 23.9 features](/slides/java/aspose-slides-for-java-23-9-release-notes/)|Enhancement|


## Public API Changes ##

### Text Animation Effect - AnimateTextType enum has been added ###

The new AnimateTextType enum has been added and it represents the animate text type of an animation effect. It allows to set the following text animation types:
- animate all text at once
- animate text by word
- animate text by letter

Example:

``` java
Presentation presentation = new Presentation("demo.pptx");
try {
    // Get the first effect of the first slide.
    IEffect firstSlideEffect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    // Change the effect Animate text type to "By letter"
    firstSlideEffect.setAnimateTextType(AnimateTextType.ByLetter);
} finally {
    if (presentation != null) presentation.dispose();
}
```
