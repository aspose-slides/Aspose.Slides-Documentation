---
title: Aspose.Slides for Android via Java 23.8 Release Notes
type: docs
weight: 50
url: /androidjava/aspose-slides-for-android-via-java-23-8-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for Android via Java 23.8](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/23.8/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESANDROID-437|[Use Aspose.Slides for Java 23.8 features](/slides/java/aspose-slides-for-java-23-8-release-notes/)|Enhancement|


## Public API Changes ##

### ShowMediaControls property has been added for SlideShowSettings ###

The ShowMediaControls property was added for the SlideShowSettings class, which Represents the slide show settings for the presentation.

Example:

```java
Presentation pres = new Presentation();
try {
    pres.getSlideShowSettings().setShowMediaControls(true);
} finally {
    if (pres != null) pres.dispose();
}
```