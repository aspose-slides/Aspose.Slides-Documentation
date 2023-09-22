---
title: Aspose.Slides for Java 23.9 Release Notes
type: docs
weight: 40
url: /java/aspose-slides-for-java-23-9-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for Java 23.9](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/23.9/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|**Related Documentation**|
| :- | :- | :- | :- |
|SLIDESNET-44012|ODP Pie/Bubble charts support|Enhancement|https://docs.aspose.com/slides/net/convert-odp-to-pptx/|
|SLIDESNET-44013|ODP Net/Stock charts support|Enhancement|https://docs.aspose.com/slides/net/convert-odp-to-pptx/|
|SLIDESNET-44099|Getting the value from the Animate Text property of animation effect|Feature|https://docs.aspose.com/slides/net/shape-animation/|
|SLIDESJAVA-39020|[Use Aspose.Slides for Net 23.9 features](/slides/net/aspose-slides-for-net-23-9-release-notes/)|Enhancement||
|SLIDESJAVA-38613|Text is not displayed in Notes when converting PPTX to PDF|Bug|https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/|
|SLIDESJAVA-39249|validateChartLayout method fails with ArgumentOutOfRangeException|Bug|https://docs.aspose.com/slides/java/create-chart/|
|SLIDESJAVA-39279|Loading the PPT file without license throws PptxException|Bug|https://docs.aspose.com/slides/java/evaluate-aspose-slides/|
|SLIDESJAVA-39261|PPTX to ODP conversion throws InvalidOperationException|Bug|https://docs.aspose.com/slides/java/convert-openoffice-odp/|
|SLIDESJAVA-37635|Pptx file not properly converted to Html|Bug|https://docs.aspose.com/slides/java/convert-powerpoint-to-html/|


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