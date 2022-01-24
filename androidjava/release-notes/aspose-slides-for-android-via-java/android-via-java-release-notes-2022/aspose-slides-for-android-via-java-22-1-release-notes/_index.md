---
title: Aspose.Slides for Android via Java 22.1 Release Notes
type: docs
weight: 120
url: /androidjava/aspose-slides-for-android-via-java-22-1-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for Android via Java 22.1](https://repository.aspose.com/list/repo/com/aspose/aspose-slides/22.1/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESANDROID-334|[Use Aspose.Slides for Java 22.1 features](/slides/androidjava/aspose-slides-for-java-22-1-release-notes/)|Enhancement|


## Public API Changes ##

### None member have been added to TimeUnitType enumeration ###

A new *None* member have been added to [TimeUnitType](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/TimeUnitType) class. This member indicates that no unit should be set for the appropriate unit scale.

``` java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 10, 10, 400, 300, true);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.None);
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```