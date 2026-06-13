---
title: Aspose.Slides for Java 15.9.0 में सार्वजनिक API और पिछड़ी असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- माइग्रेशन
- लेगेसी कोड
- आधुनिक कोड
- लेगेसी दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) या [हटाए गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) वर्गों, तरीकों, गुणों आदि की सूची देता है, और Aspose.Slides for Java 15.8.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तन भी।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **renderToGraphics मेथड्स को com.aspose.slides.ISlide, Slide में जोड़ा गया**
निम्नलिखित मेथड्स जोड़े गए हैं:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
ये मेथड्स com.aspose.slides.ISlide इंटरफ़ेस और com.aspose.slides.Slide क्लास में जोड़े गए हैं। ये मेथड्स स्लाइड को निर्दिष्ट Graphics2D ऑब्जेक्ट में रेंडर करने की अनुमति देते हैं।

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```