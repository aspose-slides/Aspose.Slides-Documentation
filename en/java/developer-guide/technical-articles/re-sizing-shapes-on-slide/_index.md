---
title: Re-sizing Shapes on Slide
type: docs
weight: 110
url: /java/re-sizing-shapes-on-slide/
---

## **Re-sizing Shapes on Slide**
One of the most frequent questions asked by the Aspose.Slides for Java customers is how to re-size shapes so that when Slide size is changed the data does not cut off. This short technical tip shows how to achieve that. 

To avoid shapes disorientation, each shape on the slide needs to be updated according to new slide size.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

If there is any table in the slide then above code would not work perfect. In that case, every cell of the table needs to be resized.

{{% /alert %}} 

You need to use following code on your end if you need to re-size the slides with tables. Setting table width or height is a special case in shapes where you need to alter the individual row height and column width to alter the table height and width.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}
