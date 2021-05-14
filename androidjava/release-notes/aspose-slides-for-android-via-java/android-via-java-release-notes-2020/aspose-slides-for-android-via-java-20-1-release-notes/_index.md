---
title: Aspose.Slides for Android via Java 20.1 Release Notes
type: docs
weight: 120
url: /androidjava/aspose-slides-for-android-via-java-20-1-release-notes/
---

{{% alert color="primary" %}} 

 This page contains release notes for Aspose.Slides for Android via Java 20.1

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESANDROID-235|Use [Aspose.Slides for Java 20.1](/slides/java/aspose-slides-for-java-20-1-release-notes/) features|Feature|
## **Public API Changes**
### **ISaveOptions.setDefaultRegularFont and ISaveOptions.getDefaultRegularFont methods have been added**
A new methods [**setDefaultRegularFont()**](https://apireference.aspose.com/androidjava/slides/com.aspose.slides/ISaveOptions#setDefaultRegularFont-java.lang.String-) and [**getDefaultRegularFont()**](https://apireference.aspose.com/androidjava/slides/com.aspose.slides/ISaveOptions#getDefaultRegularFont--) have been added to [**ISaveOptions**](https://apireference.aspose.com/androidjava/slides/com.aspose.slides/ISaveOptions) interface and [**SaveOptions**](https://apireference.aspose.com/androidjava/slides/com.aspose.slides/SaveOptions) abstract class.
It allows to get or set the default font used instead of all missing fonts during saving presentations to different formats without reloading the presentations with different [LoadOptions](https://apireference.aspose.com/androidjava/slides/com.aspose.slides/LoadOptions).

The code snippet below demonstrates saving presentation to HTML and PDF with different default regular font.

``` java
Presentation pres = new Presentation("SomePresentation.pptx");
try
{
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setDefaultRegularFont("Arial Black");
    pres.save("SomePresentation-out-ArialBlack.html", SaveFormat.Html, htmlOpts);
    
	htmlOpts.setDefaultRegularFont("Lucida Console");
    pres.save("Somepresentation-out-LucidaConsole.html", SaveFormat.Html, htmlOpts);

    PdfOptions pdfOpts = new PdfOptions();
    pdfOpts.setDefaultRegularFont("Arial Black");
    pres.save("SomePresentation-out-ArialBlack.pdf", SaveFormat.Pdf, pdfOpts);
} finally {
    if (pres != null) pres.dispose();
}
```
