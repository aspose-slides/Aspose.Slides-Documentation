---
title: Verify Presentation
type: docs
weight: 60
url: /java/verify-presentation/
---

## **Verify Presentation File without Loading**
Aspose.Slides for Java provides [PresentationFactory](https://apireference.aspose.com/slides/java/com.aspose.slides/PresentationFactory) class that is used to get the file format before even loading that using Aspose.Slides for Java [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class object.

```java
// Getting the file format using the PresentationFactory class instance
int format = PresentationFactory.getInstance().getPresentationInfo("Test.pdf").getLoadFormat();
System.out.println("Format: " + format);
```

## **Verify Presentation File Format**
In order to verify the file format. Please follow the steps below:

1. Create an instance of [IPresentationInfo](https://apireference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo) class.
1. Check whether the presentation format is old Microsoft PowerPoint 95.

In the example given below, we have got the file format.

```java
//Code snippet to check whether the presentation format is old Microsoft PowerPoint 95
boolean isOldFormat = PresentationFactory.getInstance().getPresentationInfo(pathToFile).getLoadFormat() == LoadFormat.Ppt95;
```
