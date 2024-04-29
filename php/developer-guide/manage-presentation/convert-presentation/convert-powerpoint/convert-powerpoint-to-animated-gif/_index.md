---
title: Convert PowerPoint to Animated GIF
type: docs
weight: 65
url: /java/convert-powerpoint-to-animated-gif/
keywords: "Convert PowerPoint to animated GIF, PPT to GIF, PPTX to GIF"
description: "Convert PowerPoint to animated GIF: PPT to GIF, PPTX to GIF, with Aspose.Slides API."
---

## Converting Presentations to Animated GIF Using Default Settings ##

This sample code in Java shows you how to convert a presentation to animated GIF using standard settings:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

The animated GIF will be created with default parameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

If you prefer to customize the parameters for the GIF, you can use the [GifOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/GifOptions) class. See the sample code below.

{{% /alert %}} 

## Converting Presentations to Animated GIF Using Custom Settings ##
This sample code shows you how to convert a presentation to animated GIF using custom settings in Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // the size of the resulted GIF  
	gifOptions.setDefaultDelay(2000); // how long each slide will be showed until it will be changed to the next one
	gifOptions.setTransitionFps(35); // increase FPS to better transition animation quality
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

You may want to check out a FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter developed by Aspose. 

{{% /alert %}}