---
title: Aspose.Slides for Android via Java 19.11 Release Notes
type: docs
weight: 20
url: /androidjava/aspose-slides-for-android-via-java-19-11-release-notes/
---

{{% alert color="primary" %}} 

 This page contains release notes for Aspose.Slides for Android via Java 19.11

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESANDROID-147|[Use Aspose.Slides for Java 19.11 features](/slides/java/aspose-slides-for-java-19-11-release-notes/)|Feature|
## **Public API Changes**
### **Obsolete methods addFromSvg have been deleted**
Methods **IPPImage addFromSvg(String svgContent)** and **IPPImage addFromSvg(String svgContent, IExternalResourceResolver externalResResolver, String baseUri)** have been removed from **ImageCollection** class and corresponding **IImageCollection** interface.

Please use method **addImage(ISvgImage svgImage)** instead.




