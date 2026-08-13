---
title: "Aspose.Slides for Java 15.9.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन"
linktitle: "Aspose.Slides for Java 15.9.0"
type: docs
weight: 170
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- स्थांतरण
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- पावरप्वाइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकर बदलों की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट करें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) या [हटाए गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) क्लास, मेथड, प्रॉपर्टी आदि तथा Aspose.Slides for Java 15.8.0 API के साथIntroduced किए गए अन्य परिवर्तन सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **renderToGraphics मेथड्स को com.aspose.slides.ISlide, Slide में जोड़ा गया**
निम्नलिखित मेथड्स जोड़े गए हैं:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
were added to com.aspose.slides.ISlide interface and to com.aspose.slides.Slide class. These methods allow render a slide to specified Graphics2D object.

`renderToGraphics` मेथड्स को तब से सार्वजनिक API से हटा दिया गया है। वर्तमान संस्करणों में, एक स्लाइड को [ISlide.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) के साथ रेंडर किया जाता है, जैसा कि नीचे के उदाहरण में दिखाया गया है:

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```