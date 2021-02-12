---
title: Custom Font
type: docs
weight: 20
url: /java/custom-font/
---

{{% alert color="primary" %}} 

Aspose.Slides let you load fonts for rendering in presentations without even installing them. This article shows how to load fonts from custom directories without installing them.

{{% /alert %}} 
## **Load Fonts from External Directories**
To manage paragraph bullets using Aspose.Slides for Java:

1. Create an instance of [FontsLoader](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontsLoader) class and call the static method **loadExternalFonts**.
1. Perform renders the presentation.
1. Clear the cache in the [FontsLoader](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontsLoader) class.

The implementation of the above is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-UsingCustomFonts-UsingCustomFonts.java" >}}

## **Manage Fonts Externally**
Now, you can also load fonts externally into byte array. FontsLoader class now offer, LoadExternalFont(byte[] data) method that allows to add fonts from binary data. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-LoadExternalFonts-LoadExternalFonts.java" >}}


