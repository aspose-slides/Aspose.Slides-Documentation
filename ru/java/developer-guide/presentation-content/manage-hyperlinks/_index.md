---
title: "Управление гиперссылками презентаций в Java"
linktitle: "Управление гиперссылкой"
type: docs
weight: 20
url: /ru/java/manage-hyperlinks/
keywords:
- "добавить URL"
- "добавить гиперссылку"
- "создать гиперссылку"
- "форматировать гиперссылку"
- "удалить гиперссылку"
- "обновить гиперссылку"
- "текстовая гиперссылка"
- "гиперссылка на слайд"
- "гиперссылка на фигуру"
- "гиперссылка на изображение"
- "гиперссылка на видео"
- "изменяемая гиперссылка"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Java"
- "Aspose.Slides"
description: "Легко управляйте гиперссылками в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Java — повышайте интерактивность и ускоряйте рабочий процесс за считанные минуты."
---

Гиперссылка — это ссылка на объект, данные или место в документе. Ниже приведены распространённые гиперссылки в презентациях PowerPoint:

* Ссылки на веб‑сайты внутри текста, фигур или медиа
* Ссылки на слайды

Aspose.Slides для Java позволяет выполнять множество задач, связанных с гиперссылками в презентациях. 

{{% alert color="primary" %}} 

Вам может быть интересно ознакомиться с Aspose simple, [бесплатный онлайн‑редактор PowerPoint.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Добавление URL‑гиперссылок**

### **Добавление URL‑гиперссылок к тексту**

Этот код на Java демонстрирует, как добавить веб‑сайт гиперссылку к тексту:
```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```


### **Добавление URL‑гиперссылок к фигурам или фреймам**

Пример кода на Java показывает, как добавить веб‑сайт гиперссылку к фигуре:
```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


### **Добавление URL‑гиперссылок к медиа**

Aspose.Slides позволяет добавлять гиперссылки к изображениям, аудио‑ и видеофайлам. 

Этот пример кода показывает, как добавить гиперссылку к **изображению**:
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
	// Создаёт кадр изображения на слайде 1 на основе ранее добавленного изображения
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


Этот пример кода показывает, как добавить гиперссылку к **аудиофайлу**:
```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


Этот пример кода показывает, как добавить гиперссылку к **видео**:
```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


{{%  alert  title="Tip"  color="primary"  %}} 

Вам может быть интересно посмотреть *[Управление OLE](/slides/ru/java/manage-ole/)*.

{{% /alert %}}

## **Использование гиперссылок для создания таблицы содержимого**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, их можно использовать для создания таблицы содержимого. 

Этот пример кода показывает, как создать таблицу содержимого с гиперссылками:
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
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
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

С помощью свойства [ColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink#setColorSource-int-) в интерфейсе [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink) вы можете задать цвет гиперссылок и также получить информацию о цвете из гиперссылок. Эта возможность была впервые представлена в PowerPoint 2019, поэтому изменения, связанные со свойством, не применяются к более старым версиям PowerPoint.

Этот пример кода демонстрирует операцию, при которой к одному слайду были добавлены гиперссылки разных цветов:
```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Удаление гиперссылок из презентаций**

### **Удаление гиперссылок из текста**

Этот код на Java демонстрирует, как удалить гиперссылку из текста на слайде презентации:
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


### **Удаление гиперсылок из фигур или фреймов**

Этот код на Java демонстрирует, как удалить гиперссылку из фигуры на слайде презентации: 
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

Класс [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink) изменяемый. С помощью этого класса вы можете менять значения следующих свойств:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Этот фрагмент кода показывает, как добавить гиперссылку на слайд и позже изменить её всплывающую подсказку:
```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Поддерживаемые свойства в IHyperlinkQueries**

Вы можете получить доступ к [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries) из презентации, слайда или текста, для которого определена гиперссылка. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Класс [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries) поддерживает следующие методы и свойства: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Как можно создать внутреннюю навигацию не только к слайду, но и к «разделу» или к первому слайду раздела?**

Разделы в PowerPoint — это группы слайдов; навигация технически направлена на конкретный слайд. Чтобы «перейти к разделу», обычно ссылаются на его первый слайд.

**Можно ли привязать гиперссылку к элементам мастер‑слайда, чтобы она работала на всех слайдах?**

Да. Элементы мастер‑слайда и макета поддерживают гиперссылки. Такие ссылки отображаются на дочерних слайдах и активны во время показа.

**Будут ли гиперссылки сохранены при экспорте в PDF, HTML, изображения или видео?**

В [PDF](/slides/ru/java/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/java/convert-powerpoint-to-html/) — да, ссылки обычно сохраняются. При экспорте в [изображения](/slides/ru/java/convert-powerpoint-to-png/) и [видео](/slides/ru/java/convert-powerpoint-to-video/) кликабельность не сохраняется из‑за природы этих форматов (растровые кадры/видео не поддерживают гиперссылки).