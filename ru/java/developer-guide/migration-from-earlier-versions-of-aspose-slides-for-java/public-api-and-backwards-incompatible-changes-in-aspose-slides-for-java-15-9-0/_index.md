---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides для Java 15.9.0
type: docs
weight: 170
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- миграция
- наследуемый код
- современный код
- наследуемый подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides for Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) или [удалённые](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **методы renderToGraphics были добавлены в com.aspose.slides.ISlide, Slide**
Следующие методы были добавлены:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);

были добавлены в интерфейс com.aspose.slides.ISlide и в класс com.aspose.slides.Slide. Эти методы позволяют отрисовать слайд в указанный объект Graphics2D.

Методы `renderToGraphics` впоследствии были удалены из публичного API. В текущих версиях отрисовка слайда осуществляется с помощью [ISlide.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), как показано в примере ниже:

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