---
title: Extracting Images from Presentation shapes
type: docs
weight: 100
url: /java/extracting-images-from-presentation-shapes/
---

{{% alert color="primary" %}} 

Images are added in slide background and shapes. Sometimes, it is required to extract the images added in the presentation shapes. The images are added in **IPPImageCollection** inside Presentation Document Object Model (DOM). This article covers the feature of accessing the images in presentation shape, extracting them from presentation collection and saving them in a file.

{{% /alert %}} 
## **Extracting images from Presentation Shapes**
In Aspose.Slides for Java, images can be added to slide shape and slide background. The images are added in **IPPImageCollection** of the presentation. In this example we will traverse through each shape inside every slide of presentation and see if there is any image added in slide shape. If the image will be found for any shape, we will extract that and will save it in file.The following code snippet will serve the purpose.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ExtractImages-ExtractImages.java" >}}
