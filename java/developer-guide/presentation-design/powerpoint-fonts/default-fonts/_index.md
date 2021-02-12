---
title: Default Fonts
type: docs
weight: 10
url: /java/default-fonts/
---

## **How to Set the Default Font in PowerPoint**
Using Aspose.Slides for Java you can set the default font in PowerPoint presentations. A new method [**setDefaultRegularFont()**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISaveOptions#setDefaultRegularFont-java.lang.String-) has been added to [**SaveOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/SaveOptions) class. It allows to set the default font used instead of all missing fonts during saving presentations to different formats without reloading the presentations .

The code snippet below demonstrates saving presentation to [HTML](https://wiki.fileformat.com/web/html/) and [PDF](https://wiki.fileformat.com/view/pdf/) with different default regular font.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-SetDefaultFont-SetDefaultFont.java" >}}


## **Set Default Font**
Aspose.Slides let you set the default font for rendering the presentation to PDF, XPS or thumbnails. This article shows how to define **DefaultRegular Font** and **DefaultAsian Font** for use as default fonts.

To manage paragraph bullets using Aspose.Slides for Java:

1. Create an instance of [LoadOptions](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/LoadOptions).
1. Set the DefaultRegularFont to your desired font. In the following example, I have used **Wingdings**.
1. Set the DefaultAsianFont to your desired font. I have used **Wingdings** in the following sample.
1. Load the presentation using [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) and setting the load options.
1. Now, generate the slide thumbnail, PDF, and XPS to verify the results

The implementation of the above is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-UsingDefaultFontsForRenderingPresentation-UsingDefaultFontsForRenderingPresentation.java" >}}

