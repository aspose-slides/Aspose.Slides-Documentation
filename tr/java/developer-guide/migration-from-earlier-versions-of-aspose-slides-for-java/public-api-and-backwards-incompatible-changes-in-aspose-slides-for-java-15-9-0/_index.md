---
title: Aspose.Slides for Java 15.9.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 15.8.0 API'siyle tanıtılan eklenen [added](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) veya [removed](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) sınıfları, metodları, özellikleri ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **renderToGraphics yöntemleri com.aspose.slides.ISlide, Slide'e eklendi**
Aşağıdaki metodlar eklendi:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
com.aspose.slides.ISlide arayüzüne ve com.aspose.slides.Slide sınıfına eklendi. Bu metodlar bir slaytı belirtilen Graphics2D nesnesine render etmeyi sağlar.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```