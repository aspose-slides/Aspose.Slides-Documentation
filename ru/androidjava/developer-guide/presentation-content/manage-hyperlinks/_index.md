---
title: Управление гиперссылками
type: docs
weight: 20
url: /androidjava/manage-hyperlinks/
keywords: "Гиперссылка PowerPoint, текстовая гиперссылка, гиперссылка на слайд, гиперссылка на фигуру, гиперссылка на изображение, гиперссылка на видео, Java"
description: "Как добавить гиперссылку в презентацию PowerPoint на Java"
---

Гиперссылка - это ссылка на объект или данные или место в чем-то. Вот некоторые распространенные гиперссылки в презентациях PowerPoint:

* Ссылки на веб-сайты внутри текстов, фигур или медиа
* Ссылки на слайды

Aspose.Slides для Android через Java позволяет вам выполнять множество задач, связанных с гиперссылками в презентациях.

{{% alert color="primary" %}} 

Вы можете ознакомиться с простым, [бесплатным онлайн редактором PowerPoint Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Добавление гиперссылок URL**

### **Добавление гиперссылок URL к текстам**

Этот код на Java показывает, как добавить гиперссылку на веб-сайт к тексту:

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: API форматов файлов");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **Добавление гиперссылок URL к фигурам или рамкам**

Этот образец кода на Java показывает, как добавить гиперссылку на веб-сайт к фигуре:

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Добавление гиперссылок URL к медиа**

Aspose.Slides позволяет добавлять гиперссылки к изображениям, аудио и видеофайлам. 

Этот образец кода показывает, как добавить гиперссылку к **изображению**:

```java
Presentation pres = new Presentation();
try {
	// Добавляет изображение в презентацию
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Создает рамку для изображения на слайде 1, основываясь на ранее добавленном изображении
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Этот образец кода показывает, как добавить гиперссылку к **аудиофайлу**:

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Этот образец кода показывает, как добавить гиперссылку к **видео**:

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="Совет"  color="primary"  %}} 

Вы можете увидеть *[Управление OLE](/slides/androidjava/manage-ole/)*.

{{% /alert %}}

## **Использование гиперссылок для создания оглавления**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, вы можете использовать их для создания оглавления. 

Этот образец кода показывает, как создать оглавление с гиперссылками:

```java
Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Заголовок слайда 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Страница 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Форматирование гиперссылок**

### **Цвет**

С помощью свойства [ColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) в интерфейсе [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink) вы можете установить цвет для гиперссылок и также получить информацию о цвете из гиперссылок. Эта возможность была впервые введена в PowerPoint 2019, поэтому изменения, связанные с этим свойством, не применимы к более ранним версиям PowerPoint.

Этот образец кода демонстрирует операцию, в которой гиперссылки с различными цветами добавлены на один и тот же слайд:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("Это пример цветной гиперссылки.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("Это пример обычной гиперссылки.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Удаление гиперссылок в презентациях**

### **Удаление гиперссылок из текстов**

Этот код на Java показывает, как удалить гиперссылку из текста на слайде презентации:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Удаление гиперссылок из фигур или рамок**

Этот код на Java показывает, как удалить гиперссылку из фигуры на слайде презентации: 

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Изменяемая гиперссылка**

Класс [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink) является изменяемым. С помощью этого класса вы можете изменять значения следующих свойств:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Фрагмент кода показывает, как добавить гиперссылку на слайд и позже отредактировать ее подсказку:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: API форматов файлов");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Поддерживаемые свойства в IHyperlinkQueries**

Вы можете получить доступ к [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries) из презентации, слайда или текста, для которого определена гиперссылка.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Класс [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries) поддерживает следующие методы и свойства:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)
