---
title: Aspose.Slides for Java 15.9.0'de Genel API ve Geriye Dönük Uyumsuz Değişiklikler
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
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 15.8.0 API'si ile tanıtılan eklenen veya kaldırılan sınıflar, metodlar, özellikler vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **renderToGraphics yöntemleri com.aspose.slides.ISlide ve Slide'e eklendi**
Aşağıdaki yöntemler eklendi:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
com.aspose.slides.ISlide arayüzüne ve com.aspose.slides.Slide sınıfına eklendi. Bu yöntemler, bir slaytı belirtilen Graphics2D nesnesine render etmeye olanak tanır.

`renderToGraphics` yöntemleri daha sonra genel API'den kaldırıldı. Mevcut sürümlerde, bir slaytı aşağıdaki örnek gibi [ISlide.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) kullanarak render edebilirsiniz:

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